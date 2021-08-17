using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace PadraInsurancePrescription
{
    public partial class PrescriptionsStatisticsControl : UserControl
    {
        string c_str_sel_col;
        string p_str_sel_col;
        string d_str_sel_col;
        string i_str_sel_col;
        string s_str_sel_col;

        List<KeyValuePair<int,int>> c_selected_id_s;//1-row number 2-id
        CheckBox c_select_all_checkbox;
        List<KeyValuePair<int, int>> p_selected_id_s;//1-row number 2-id
        CheckBox p_select_all_checkbox;
        List<KeyValuePair<int, int>> d_selected_id_s;//1-row number 2-id
        CheckBox d_select_all_checkbox;
        List<KeyValuePair<int, string>> y_selected_id_s;//1-row number 2-id
        List<KeyValuePair<int, int>> i_selected_id_s;//1-row number 2-id
        CheckBox i_select_all_checkbox;
        List<KeyValuePair<int, int>> s_selected_id_s;//1-row number 2-id
        CheckBox s_select_all_checkbox;

        PIPDataSetTableAdapters.ProvinceTableAdapter c_province_adapter;
        PIPDataSetTableAdapters.CityTableAdapter c_city_adapter;
        PIPDataSetTableAdapters.TClinicTypeTableAdapter ct_adapter;
        PIPDataSetTableAdapters.PrescriptionsStatsReportTableAdapter stats_adapter;
        PIPDataSetTableAdapters.TSystemUserTableAdapter user_adapter;
        PIPDataSet.ProvinceDataTable c_province_data;
        PIPDataSet.CityDataTable c_city_data;
        PIPDataSet.TClinicTypeDataTable ct_data;


        DataTable years_data;

        PGSDialog pgs_dialog;
        PLConstants.enum_operation_results result_enum;
        PrintForm p_form;
        FileStream report_stream;
        RequestDateForm rd_form;

        public PrescriptionsStatisticsControl()
        {
            //column 0 is checkboxes and not in arrays
            InitializeComponent();
            PLGlobalFuncs.changeDGVSettings(center_grid,part_grid,doctor_grid,insurance_grid,sector_grid);
            c_str_sel_col = c_select_column.Name;
            p_str_sel_col = p_select_column.Name;
            d_str_sel_col = d_select_column.Name;
            i_str_sel_col = i_select_column.Name;
            s_str_sel_col = s_select_column.Name;

            c_selected_id_s = new List<KeyValuePair<int, int>>();
            c_select_all_checkbox = new CheckBox();
            c_select_all_checkbox.CheckedChanged += c_select_all_checkbox_CheckedChanged;
            p_selected_id_s = new List<KeyValuePair<int, int>>();
            p_select_all_checkbox = new CheckBox();
            p_select_all_checkbox.CheckedChanged += p_select_all_checkbox_CheckedChanged;
            d_selected_id_s = new List<KeyValuePair<int, int>>();
            d_select_all_checkbox = new CheckBox();
            d_select_all_checkbox.CheckedChanged += d_select_all_checkbox_CheckedChanged;
            i_selected_id_s = new List<KeyValuePair<int, int>>();
            i_select_all_checkbox = new CheckBox();
            i_select_all_checkbox.CheckedChanged += i_select_all_checkbox_CheckedChanged;
            s_selected_id_s = new List<KeyValuePair<int, int>>();
            s_select_all_checkbox = new CheckBox();
            s_select_all_checkbox.CheckedChanged += s_select_all_checkbox_CheckedChanged;

            c_province_adapter=new PIPDataSetTableAdapters.ProvinceTableAdapter();
            c_city_adapter=new PIPDataSetTableAdapters.CityTableAdapter();
            ct_adapter=new PIPDataSetTableAdapters.TClinicTypeTableAdapter();
            stats_adapter = new PIPDataSetTableAdapters.PrescriptionsStatsReportTableAdapter();
            user_adapter=new PIPDataSetTableAdapters.TSystemUserTableAdapter();
            
            initCProvinceComboBox();
            initCTypeComboBox();

            PLGlobalFuncs.yearsForCheckedListBox(year_checkedListBox);
            years_data = (DataTable)year_checkedListBox.DataSource;

            insurance_grid.CurrentCellDirtyStateChanged -= insurance_grid_CurrentCellDirtyStateChanged;
            insurance_grid.CellValueChanged -= insurance_grid_CellValueChanged;
            insuranceTableAdapter.Fill(pIPDataSet.Insurance);

            pgs_dialog = new PGSDialog(this);
            p_form = new PrintForm();
            rd_form = new RequestDateForm();
        }

        // ///////////////////////// Center EVENTS
        # region Center Events

        private void c_province_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (c_province_cbx.SelectedIndex > 0)
            {
                initCCityComboBox();
            }
            else
            {
                c_city_cbx.DataSource = null;
                c_city_cbx.Enabled = false;
            }
        }

        private void c_search_btn_Click(object sender, EventArgs e)
        {
            List<string> message_text = new List<string>();
            bool error = false;
            bool all_empty = true;
            int c_search_province = -1;
            int c_search_city = -1;
            int c_search_type = -1;
            string c_search_name = "";
            
            center_grid.CellValueChanged -= center_grid_CellValueChanged;
            center_grid.CurrentCellDirtyStateChanged -= center_grid_CurrentCellDirtyStateChanged;
            if (c_province_cbx.SelectedIndex > 0)
            {
                all_empty = false;
                c_search_province = (int)c_province_cbx.SelectedValue;
            }
            if (c_city_cbx.SelectedIndex > 0)
            {
                all_empty = false;
                c_search_province = (int)c_province_cbx.SelectedValue;
            }
            if (c_type_cbx.SelectedIndex > 0)
            {
                all_empty = false;
                c_search_type = (int)c_type_cbx.SelectedValue;
            }
            if (!Regex.IsMatch(c_search_name = c_name_txt.Text.Trim(), PLConstants.reg_title))
            {
                error = true;
                message_text.Add(PLConstants.error_title);
            }
            else if (c_search_name.Length > 0)
            {
                all_empty = false;
            }

            if (error)
            {
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.error, message_text);
            }
            else if (all_empty)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_search_fields_not_empty);
            }
            else if (sMedicalCenterTableAdapter.FillByProvince(pIPDataSet.SMedicalCenter, c_search_province, c_search_city, c_search_type,c_search_name) == 0)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record_after_search);
                c_select_all_checkbox.Visible = false;
            }
        }

        private void c_show_parts_button_Click(object sender, EventArgs e)
        {
            getSelectedCenters();
            if (c_selected_id_s.Count==1)
            {
                part_grid.CellValueChanged -= part_grid_CellValueChanged;
                part_grid.CurrentCellDirtyStateChanged -= part_grid_CurrentCellDirtyStateChanged;
                if (tMedicalCenterPartTableAdapter.Fill(pIPDataSet.TMedicalCenterPart, c_selected_id_s[0].Value) == 0)
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record);
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_choose_one);
            }
        }

        private void c_select_all_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (c_select_all_checkbox.Checked)
            {
                for (int i = 0; i < center_grid.Rows.Count; i++)
                {
                    center_grid.Rows[i].Cells[c_str_sel_col].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < center_grid.Rows.Count; i++)
                {
                    center_grid.Rows[i].Cells[c_str_sel_col].Value = false;
                }
            }
        }

        private void center_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (center_grid.Rows.Count > 0)
            {
                afterCenterGridFilled();
                center_grid.CellValueChanged += center_grid_CellValueChanged;
                center_grid.CurrentCellDirtyStateChanged += center_grid_CurrentCellDirtyStateChanged;
            }
        }

        private void center_grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (center_grid.IsCurrentCellDirty)
            {
                center_grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void center_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(center_grid.Rows[e.RowIndex].Cells[c_str_sel_col].Value))
            {
                center_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                center_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
            }
            else
            {
                center_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                center_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.ControlText;
            }
        }

        private void c_all_chk_CheckedChanged(object sender, EventArgs e)
        {
            if (c_all_chk.Checked)
            {
                center_grid.Enabled = show_parts_button.Enabled = p_all_chk.Enabled = part_grid.Enabled = 
                    show_doctors_btn.Enabled = d_all_chk.Enabled = doctor_grid.Enabled = false;
                p_all_chk.Checked = true;
                d_all_chk.Checked = true;
            }
            else
            {
                center_grid.Enabled = show_parts_button.Enabled = p_all_chk.Enabled = part_grid.Enabled =
                    show_doctors_btn.Enabled = d_all_chk.Enabled = doctor_grid.Enabled = true;
                p_all_chk.Checked = false;
                d_all_chk.Checked = false;
            }
        }

        # endregion

        // ///////////////////////// Center METHODS
        #region Center Methods

        private void getSelectedCenters()
        {
            c_selected_id_s.Clear();
            int id_col = c_id_column.Index;
            for (int i=0;i<center_grid.Rows.Count;i++)
            {
                if (Convert.ToBoolean(center_grid.Rows[i].Cells[c_str_sel_col].Value))
                {
                    c_selected_id_s.Add(new KeyValuePair<int,int>(i,(int)center_grid.Rows[i].Cells[id_col].Value));
                }
            }
        }

        private DataTable selectedCentersToDataTable()
        {
            DataTable s_p_t = new DataTable();
            s_p_t.Columns.Add("p_id", typeof(int));
            foreach (KeyValuePair<int, int> p_id in c_selected_id_s)
            {
                s_p_t.Rows.Add(p_id.Value);
            }
            return s_p_t;
        }

        private void afterCenterGridFilled()
        {
            PLGlobalFuncs.DGVAfterFilling(center_grid, c_select_all_checkbox);
            //PLGlobalFuncs.createAllCheckBoxForDataGridView(center_grid, c_select_all_checkbox);

            for (int i = 0; i < center_grid.Rows.Count; i++)
            {
                center_grid.Rows[i].Cells[c_str_sel_col].Value = false;
            }
        }

        private void initCProvinceComboBox()
        {
            c_province_data = c_province_adapter.GetAllProvinces();
            PIPDataSet.ProvinceRow c_first_row = c_province_data.NewProvinceRow();
            c_first_row.id = -1;
            c_first_row.name = "--استان--";
            c_province_data.Rows.InsertAt(c_first_row, 0);
            c_province_cbx.DataSource = c_province_data;
            c_province_cbx.DisplayMember = c_province_data.nameColumn.ColumnName;
            c_province_cbx.ValueMember = c_province_data.idColumn.ColumnName;
            c_province_cbx.SelectedIndex = 0;
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(c_province_cbx);
        }
        private void initCCityComboBox()
        {
            c_city_data = c_city_adapter.GetCitiesOfProvince((int)c_province_cbx.SelectedValue);
            if (c_city_data.Rows.Count > 0)
            {
                PIPDataSet.CityRow c_first_row = c_city_data.NewCityRow();
                c_first_row.id = -1;
                c_first_row.name = "--شهر--";
                c_first_row.province = (int)c_province_cbx.SelectedValue;
                c_city_data.Rows.InsertAt(c_first_row, 0);
                c_city_cbx.DataSource = c_city_data;
                c_city_cbx.DisplayMember = c_city_data.nameColumn.ColumnName;
                c_city_cbx.ValueMember = c_city_data.idColumn.ColumnName;
                c_city_cbx.SelectedIndex = 0;
                PLGlobalFuncs.adjustDropDownWidthOfComboBox(c_city_cbx);
                c_city_cbx.Enabled = true;
            }
        }
        private void initCTypeComboBox()
        {
            ct_data = ct_adapter.GetAllTypes();
            PIPDataSet.TClinicTypeRow mc_first_row = ct_data.NewTClinicTypeRow();
            mc_first_row.id = -1;
            mc_first_row.name = "--نوع مرکز--";
            ct_data.Rows.InsertAt(mc_first_row, 0);
            c_type_cbx.DataSource = ct_data;
            c_type_cbx.DisplayMember = ct_data.nameColumn.ColumnName;
            c_type_cbx.ValueMember = ct_data.idColumn.ColumnName;
            c_type_cbx.SelectedIndex = 0;
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(c_type_cbx);
        }

        #endregion

        // ///////////////////////// Parts EVENTS
        #region Parts Events

        private void show_doctors_button_Click(object sender, EventArgs e)
        {
            getSelectedParts();
            if (p_selected_id_s.Count == 1)
            {
                doctor_grid.CellValueChanged -= doctor_grid_CellValueChanged;
                doctor_grid.CurrentCellDirtyStateChanged -= doctor_grid_CurrentCellDirtyStateChanged;
                if (c_sMedicalCenterPartDoctorTableAdapter.FillByClinicPart(pIPDataSet.SMedicalCenterPartDoctor, c_selected_id_s[0].Value, p_selected_id_s[0].Value) == 0)
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record_center_part_doctors);
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_choose_one);
            }
        }

        private void part_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (part_grid.Rows.Count > 0)
            {
                PLGlobalFuncs.DGVAfterFilling(part_grid, p_select_all_checkbox);
                part_grid.CellValueChanged += part_grid_CellValueChanged;
                part_grid.CurrentCellDirtyStateChanged += part_grid_CurrentCellDirtyStateChanged;
            }
        }

        private void part_grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (part_grid.IsCurrentCellDirty)
            {
                part_grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void part_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(part_grid.Rows[e.RowIndex].Cells[p_str_sel_col].Value))
            {
                part_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                part_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
            }
            else
            {
                part_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                part_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.ControlText;
            }
        }

        private void p_select_all_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (p_select_all_checkbox.Checked)
            {
                for (int i = 0; i < part_grid.Rows.Count; i++)
                {
                    part_grid.Rows[i].Cells[p_str_sel_col].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < part_grid.Rows.Count; i++)
                {
                    part_grid.Rows[i].Cells[p_str_sel_col].Value = false;
                }
            }
        }

        private void p_all_chk_CheckedChanged(object sender, EventArgs e)
        {
            if (p_all_chk.Checked)
            {
                part_grid.Enabled = show_doctors_btn.Enabled = d_all_chk.Enabled = doctor_grid.Enabled = false;
                d_all_chk.Checked = true;
            }
            else
            {
                part_grid.Enabled = show_doctors_btn.Enabled = d_all_chk.Enabled = doctor_grid.Enabled = true;
                d_all_chk.Checked = false;
            }
        }

        #endregion

        // ///////////////////////// Parts METHODS
        #region Parts Methods

        private void getSelectedParts()
        {
            p_selected_id_s.Clear();
            int id_col = p_cen_par_seq_column.Index;
            for (int i = 0; i < part_grid.Rows.Count; i++)
            {
                if (Convert.ToBoolean(part_grid.Rows[i].Cells[p_str_sel_col].Value))
                {
                    p_selected_id_s.Add(new KeyValuePair<int, int>(i, (int)part_grid.Rows[i].Cells[id_col].Value));
                }
            }
        }

        private DataTable selectedPartsToDataTable()
        {
            DataTable s_p_t = new DataTable();
            s_p_t.Columns.Add("p_id", typeof(int));
            foreach (KeyValuePair<int, int> p_id in p_selected_id_s)
            {
                s_p_t.Rows.Add(p_id.Value);
            }
            return s_p_t;
        }

        #endregion

        // ///////////////////////// Doctors EVENTS
        #region Doctors Events

        private void doctor_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (doctor_grid.Rows.Count > 0)
            {
                PLGlobalFuncs.DGVAfterFilling(doctor_grid, d_select_all_checkbox);
                doctor_grid.CellValueChanged += doctor_grid_CellValueChanged;
                doctor_grid.CurrentCellDirtyStateChanged += doctor_grid_CurrentCellDirtyStateChanged;
            }
        }

        private void doctor_grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (doctor_grid.IsCurrentCellDirty)
            {
                doctor_grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void doctor_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(doctor_grid.Rows[e.RowIndex].Cells[d_str_sel_col].Value))
            {
                doctor_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                doctor_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
            }
            else
            {
                doctor_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                doctor_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.ControlText;
            }
        }

        private void d_select_all_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (d_select_all_checkbox.Checked)
            {
                for (int i = 0; i < doctor_grid.Rows.Count; i++)
                {
                    doctor_grid.Rows[i].Cells[d_str_sel_col].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < doctor_grid.Rows.Count; i++)
                {
                    doctor_grid.Rows[i].Cells[d_str_sel_col].Value = false;
                }
            }
        }

        private void d_all_chk_CheckedChanged(object sender, EventArgs e)
        {
            if (d_all_chk.Checked)
            {
                doctor_grid.Enabled = false;
            }
            else
            {
                doctor_grid.Enabled = true;
            }
        }

        #endregion

        // ///////////////////////// Doctors METHODS
        #region Doctors Methods

        private void getSelectedDoctors()
        {
            d_selected_id_s.Clear();
            int id_col = d_id_column.Index;
            for (int i = 0; i < doctor_grid.Rows.Count; i++)
            {
                if (Convert.ToBoolean(doctor_grid.Rows[i].Cells[d_str_sel_col].Value))
                {
                    d_selected_id_s.Add(new KeyValuePair<int, int>(i, (int)doctor_grid.Rows[i].Cells[id_col].Value));
                }
            }
        }

        private DataTable selectedDoctorsToDataTable()
        {
            DataTable s_d_t = new DataTable();
            s_d_t.Columns.Add("c_id", typeof(int));
            foreach (KeyValuePair<int, int> c_id in d_selected_id_s)
            {
                s_d_t.Rows.Add(c_id.Value);
            }
            return s_d_t;
        }

        #endregion

        // ///////////////////////// Years EVENTS
        #region Years Events

        private void year_checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 0)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    for (int i = 1; i < year_checkedListBox.Items.Count; i++)
                    {
                        year_checkedListBox.SetItemChecked(i, true);
                    }
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    for (int i = 1; i < year_checkedListBox.Items.Count; i++)
                    {
                        year_checkedListBox.SetItemChecked(i, false);
                    }
                }
            }
        }

        #endregion

        // ///////////////////////// Year METHODS
        #region Year Methods

        private DataTable selectedYearsToDataTable()
        {
            DataTable sel_years = PLGlobalFuncs.emptyYearIDsDataTable();
            for (int i = 1; i < year_checkedListBox.Items.Count; i++)
            {
                if (year_checkedListBox.GetItemCheckState(i) == CheckState.Checked)
                {
                    sel_years.Rows.Add(years_data.Rows[i][0]);
                }
            }
            return sel_years;
        }

        #endregion

        // ///////////////////////// Insurance EVENTS
        #region Insurance Events

        private void i_select_all_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (i_select_all_checkbox.Checked)
            {
                for (int i = 0; i < insurance_grid.Rows.Count; i++)
                {
                    insurance_grid.Rows[i].Cells[i_str_sel_col].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < insurance_grid.Rows.Count; i++)
                {
                    insurance_grid.Rows[i].Cells[i_str_sel_col].Value = false;
                }
            }
        }

        private void show_sectors_btn_Click(object sender, EventArgs e)
        {
            getSelectedInsurances();
            if (i_selected_id_s.Count == 1)
            {
                sector_grid.CellValueChanged -= sector_grid_CellValueChanged;
                sector_grid.CurrentCellDirtyStateChanged -= sector_grid_CurrentCellDirtyStateChanged;
                if (insuranceSectorTableAdapter.FillByInsurance(pIPDataSet.InsuranceSector, i_selected_id_s[0].Value) == 0)
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record);
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_choose_one);
            }
        }

        private void insurance_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)//checked
        {
            if (insurance_grid.Rows.Count > 0)
            {
                PLGlobalFuncs.DGVAfterFilling(insurance_grid, i_select_all_checkbox);
                insurance_grid.CellValueChanged += insurance_grid_CellValueChanged;
                insurance_grid.CurrentCellDirtyStateChanged += insurance_grid_CurrentCellDirtyStateChanged;
            }
        }

        private void insurance_grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (insurance_grid.IsCurrentCellDirty)
            {
                insurance_grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void insurance_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(insurance_grid.Rows[e.RowIndex].Cells[i_str_sel_col].Value))
            {
                insurance_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                insurance_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
            }
            else
            {
                insurance_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                insurance_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.ControlText;
            }
        }

        #endregion

        // ///////////////////////// Insurance METHODS
        #region Insurance Methods

        private void getSelectedInsurances()
        {
            i_selected_id_s.Clear();
            int id_col = pIPDataSet.Insurance.idColumn.Ordinal + 1;
            for (int i = 0; i < insurance_grid.Rows.Count; i++)
            {
                if (Convert.ToBoolean(insurance_grid.Rows[i].Cells[i_str_sel_col].Value))
                {
                    i_selected_id_s.Add(new KeyValuePair<int, int>(i, (int)insurance_grid.Rows[i].Cells[id_col].Value));
                }
            }
        }

        private DataTable selectedInsurancesToDataTable()
        {
            DataTable s_i_t = new DataTable();
            s_i_t.Columns.Add(PLConstants.str_table_col_entity_id, typeof(int));
            foreach (KeyValuePair<int, int> i_id in i_selected_id_s)
            {
                s_i_t.Rows.Add(i_id.Value);
            }
            return s_i_t;
        }

        #endregion

        // ///////////////////////// Sector EVENTS
        #region Sector Events

        private void s_select_all_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (s_select_all_checkbox.Checked)
            {
                for (int i = 0; i < sector_grid.Rows.Count; i++)
                {
                    sector_grid.Rows[i].Cells[s_str_sel_col].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < sector_grid.Rows.Count; i++)
                {
                    sector_grid.Rows[i].Cells[s_str_sel_col].Value = false;
                }
            }
        }

        private void sector_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)//checked
        {
            if (sector_grid.Rows.Count > 0)
            {
                PLGlobalFuncs.DGVAfterFilling(sector_grid, s_select_all_checkbox);
                sector_grid.CellValueChanged += sector_grid_CellValueChanged;
                sector_grid.CurrentCellDirtyStateChanged += sector_grid_CurrentCellDirtyStateChanged;
            }
        }

        private void sector_grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (sector_grid.IsCurrentCellDirty)
            {
                sector_grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void sector_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(sector_grid.Rows[e.RowIndex].Cells[s_str_sel_col].Value))
            {
                sector_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                sector_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
            }
            else
            {
                sector_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                sector_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.ControlText;
            }
        }

        #endregion

        // ///////////////////////// Sector METHODS
        #region Sector Methods

        private void getSelectedSectors()
        {
            s_selected_id_s.Clear();
            int id_col = pIPDataSet.InsuranceSector.idColumn.Ordinal + 1;
            for (int i = 0; i < sector_grid.Rows.Count; i++)
            {
                if (Convert.ToBoolean(sector_grid.Rows[i].Cells[s_str_sel_col].Value))
                {
                    s_selected_id_s.Add(new KeyValuePair<int, int>(i, (int)sector_grid.Rows[i].Cells[id_col].Value));
                }
            }
        }

        private DataTable selectedSectorsToDataTable()
        {
            DataTable s_s_t = new DataTable();
            s_s_t.Columns.Add(PLConstants.str_table_col_entity_id, typeof(int));
            foreach (KeyValuePair<int, int> s_id in s_selected_id_s)
            {
                s_s_t.Rows.Add(s_id.Value);
            }
            return s_s_t;
        }

        #endregion

        // ///////////////////////// Report Events
        #region Report Events
        private void generate_report_btn_Click(object sender, EventArgs e)
        {
            try
            {
                getSelectedCenters();
                getSelectedParts();
                getSelectedDoctors();
                getSelectedInsurances();
                getSelectedSectors();

                if (((Button)sender).Equals(generate_report_btn))
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_stats_report_wait);
                    
                    stats_adapter.FillByCustomization(pIPDataSet.PrescriptionsStatsReport,
                        false, selectedInsurancesToDataTable(), selectedSectorsToDataTable(), c_all_chk.Checked, selectedCentersToDataTable(),
                        p_all_chk.Checked, selectedPartsToDataTable(), d_all_chk.Checked, selectedDoctorsToDataTable(), selectedYearsToDataTable(),
                        PLGlobalFuncs.monthesCompleteDataTable());

                    p_form.main_reportViewer.LocalReport.ReportEmbeddedResource = PLReportConstants.str_prescriptions_stats_letter_rdlc;
                    p_form.main_reportViewer.LocalReport.EnableExternalImages = true;
                    string insurance;
                    if (i_selected_id_s.Count > 1)
                    {
                        insurance = i_selected_id_s.Count.ToString() + " سازمان بیمه گر انتخاب شده اند"; ;
                    }
                    else
                    {
                        insurance = pIPDataSet.Insurance.Rows[i_selected_id_s[0].Key][pIPDataSet.Insurance.nameColumn.ColumnName].ToString();
                    }
                    string sector = " ";
                    if (s_selected_id_s.Count > 1)
                    {
                        sector = s_selected_id_s.Count.ToString() + " صندوق بیمه ای انتخاب شده اند"; ;
                    }
                    else if (s_selected_id_s.Count == 1)
                    {
                        sector = pIPDataSet.InsuranceSector.Rows[s_selected_id_s[0].Key][pIPDataSet.InsuranceSector.nameColumn.ColumnName].ToString();
                    }
                    else
                    {
                        sector = "همه صندوق های سازمان های بیمه ای انتخاب شده";
                    }
                    string center = " ";
                    if (c_selected_id_s.Count > 1)
                    {
                        center = c_selected_id_s.Count.ToString() + " مرکز درمانی انتخاب شده اند"; ;
                    }
                    else if (c_selected_id_s.Count == 1)
                    {
                        center = pIPDataSet.SMedicalCenter.Rows[c_selected_id_s[0].Key][pIPDataSet.SMedicalCenter.nameColumn.ColumnName].ToString();
                    }
                    else if (c_all_chk.Checked)
                    {
                        center = "همه مراکز ثبت شده در سیستم";
                    }
                    string part = " ";
                    if (p_selected_id_s.Count > 1)
                    {
                        part = p_selected_id_s.Count.ToString() + " بخش درمانی انتخاب شده اند"; ;
                    }
                    else if (p_selected_id_s.Count == 1)
                    {
                        part = pIPDataSet.TMedicalCenterPart.Rows[p_selected_id_s[0].Key][pIPDataSet.TMedicalCenterPart.nameColumn.ColumnName].ToString();
                    }
                    else if (p_all_chk.Checked)
                    {
                        part = "همه بخش های مراکز انتخاب شده";
                    }
                    string year = "";
                    for (int i = 1; i < year_checkedListBox.Items.Count; i++)
                    {
                        if (year_checkedListBox.GetItemCheckState(i) == CheckState.Checked)
                        {
                            year += years_data.Rows[i][0] + ",";
                        }
                    }
                    year = year.Remove(year.Length - 1);
                    p_form.main_reportViewer.LocalReport.SetParameters(new ReportParameter(PLReportConstants.enum_stats_params.insurance.ToString(), insurance));
                    p_form.main_reportViewer.LocalReport.SetParameters(new ReportParameter(PLReportConstants.enum_stats_params.sector.ToString(), sector));
                    p_form.main_reportViewer.LocalReport.SetParameters(new ReportParameter(PLReportConstants.enum_stats_params.request_date.ToString(), rd_form.RDate));
                    p_form.main_reportViewer.LocalReport.SetParameters(new ReportParameter(PLReportConstants.enum_stats_params.center.ToString(), center));
                    p_form.main_reportViewer.LocalReport.SetParameters(new ReportParameter(PLReportConstants.enum_stats_params.part.ToString(), part));
                    p_form.main_reportViewer.LocalReport.SetParameters(new ReportParameter(PLReportConstants.enum_stats_params.year.ToString(), year));
                    p_form.main_reportViewer.LocalReport.SetParameters(new ReportParameter(PLReportConstants.enum_stats_params.padra_description.ToString(), PLPadraConstants.report_padra_title_str));
                    p_form.main_reportViewer.LocalReport.SetParameters(new ReportParameter(PLReportConstants.enum_stats_params.padra_website.ToString(), PLPadraConstants.report_padra_website_str));
                    p_form.main_reportViewer.LocalReport.DataSources.Clear();
                    p_form.main_reportViewer.LocalReport.DataSources.Add(new ReportDataSource(PLReportConstants.str_public_letter_dataset, (DataTable)pIPDataSet.PrescriptionsStatsReport));
                    createReportPDF(PLReportConstants.str_prescriptions_stats_letter_pdf);
                }
                else if (((Button)sender).Equals(generate_xlsx_btn))
                {
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    fbd.ShowNewFolderButton = true;
                    fbd.ShowDialog();
                    string directory = fbd.SelectedPath;

                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_export_file_wait);

                    stats_adapter.FillByCustomization(pIPDataSet.PrescriptionsStatsReport,
                        true, selectedInsurancesToDataTable(), selectedSectorsToDataTable(), c_all_chk.Checked, selectedCentersToDataTable(),
                        p_all_chk.Checked, selectedPartsToDataTable(), d_all_chk.Checked, selectedDoctorsToDataTable(), selectedYearsToDataTable(),
                        PLGlobalFuncs.monthesCompleteDataTable());

                    if (directory != "" && directory != null)
                    {
                        Excel.Application excel_app = new Excel.Application();
                        Excel.Workbook workbook = excel_app.Workbooks.Add(Type.Missing);
                        Excel.Worksheet worksheet;
                        DataTable dt = pIPDataSet.PrescriptionsStatsReport;
                        worksheet = workbook.Worksheets.Add();
                        worksheet.Name = dt.TableName;
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            worksheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;
                            worksheet.Cells[1, i + 1].EntireColumn.NumberFormat = "@";
                            Type d_type = dt.Columns[i].DataType;
                            if (d_type == typeof(Int16) || d_type == typeof(Int32) || d_type == typeof(Int64) ||
                                d_type == typeof(UInt16) || d_type == typeof(UInt32) || d_type == typeof(UInt64) ||
                                d_type == typeof(float) || d_type == typeof(double) || d_type == typeof(decimal))
                            {
                                worksheet.Cells[2, i + 1] = PLConstants.enum_data_types.number_type.ToString();
                            }
                            else if (d_type == typeof(bool))
                            {
                                worksheet.Cells[2, i + 1] = PLConstants.enum_data_types.bool_type.ToString();
                            }
                            else if (d_type == typeof(string) || d_type == typeof(char))
                            {
                                worksheet.Cells[2, i + 1] = PLConstants.enum_data_types.string_type.ToString();
                            }
                            else
                            {
                                worksheet.Cells[2, i + 1] = PLConstants.enum_data_types.other_type.ToString();
                            }
                        }
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            if (dt.Columns[j].DataType == typeof(bool))
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    if (dt.Rows[i][j] == System.DBNull.Value)
                                    {
                                        worksheet.Cells[i + 3, j + 1] = null;
                                    }
                                    else
                                    {
                                        worksheet.Cells[i + 3, j + 1] = (bool)dt.Rows[i][j] ? "1" : "0";
                                    }
                                    worksheet.Cells[i + 3, j + 1].NumberFormat = "0";
                                }
                            }
                            else
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    worksheet.Cells[i + 3, j + 1] = dt.Rows[i][j];
                                }
                            }
                        }
                        string pass = "";
                        user_adapter.GetUserPassword(PLConstants.UserCode, ref pass);
                        workbook.Password = pass;
                        char[] pass_arr = pass.ToCharArray();
                        Array.Reverse(pass_arr);
                        workbook.WritePassword = new string(pass_arr);
                        workbook.SaveAs(directory + "\\PIP_prescriptions_stats_from_" + PLConstants.UserName + "_" + rd_form.RDate.Replace('/', '-') + ".xlsx");
                        workbook.Close();
                        excel_app.Quit();
                        System.Diagnostics.Process.Start(directory);
                    }
                }
            }
            catch (Exception exp)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_report_file_creating);
            }
            finally
            {
                if (report_stream != null)
                {
                    report_stream.Close();
                }
            }
        }

        #endregion

        // ///////////////////////// Report Methods
        #region Report Methods
        private void createReportPDF(string file_name)
        {
            PageSettings portrait_page_setting = new PageSettings();
            PaperSize ps1 = new PaperSize();
            ps1.RawKind = (int)PaperKind.A4;
            portrait_page_setting.PaperSize = ps1;
            p_form.main_reportViewer.SetPageSettings(portrait_page_setting);
            p_form.main_reportViewer.LocalReport.Refresh();
            p_form.main_reportViewer.RefreshReport();
            byte[] report_bytes = p_form.main_reportViewer.LocalReport.Render("PDF");
            FileStream report_stream = new FileStream(file_name, FileMode.Create);
            report_stream.Write(report_bytes, 0, report_bytes.Length);
            report_stream.Close();
            System.Diagnostics.Process.Start(file_name);
        }

        #endregion

        

    }
}
