using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PadraInsurancePrescription
{
    public partial class MedicalCenterDoctorControl : UserControl
    {
        string c_str_sel_col;
        string cd_str_sel_col;
        string o_str_sel_col;

        int c_index_two;
        int c_selected_id;
        int c_index_one;
        bool c_is_switched;
        List<KeyValuePair<int,int>> c_selected_id_s;//1-row number 2-id
        CheckBox c_select_all_checkbox;

        List<KeyValuePair<int, int>> cd_selected_id_s;//1-row number 2-id
        CheckBox cd_select_all_checkbox;

        List<KeyValuePair<int, int>> o_selected_id_s;//1-row number 2-id
        CheckBox o_select_all_checkbox;

        PGSDialog pgs_dialog;
        PLConstants.enum_operation_results result_enum;

        PIPDataSetTableAdapters.TClinicTypeTableAdapter ct_adapter;
        PIPDataSet.TClinicTypeDataTable ct_data;

        PIPDataSetTableAdapters.TMedicineDegreeTableAdapter md_adapter;
        PIPDataSet.TMedicineDegreeDataTable degrees_data;

        public MedicalCenterDoctorControl()
        {
            //column 0 is checkboxes and not in arrays
            InitializeComponent();
            PLGlobalFuncs.changeDGVSettings(center_grid,center_doctors_grid,other_doctors_grid);
            c_str_sel_col = "c_select_column";
            cd_str_sel_col = "cd_select_column";
            o_str_sel_col = "o_select_column";

            c_selected_id_s = new List<KeyValuePair<int, int>>();
            c_selected_id = -1;
            c_select_all_checkbox = new CheckBox();
            //c_select_all_checkbox.CheckedChanged += c_select_all_checkbox_CheckedChanged;
            c_select_all_checkbox.Visible = false;
            c_index_two = -1;

            cd_selected_id_s = new List<KeyValuePair<int, int>>();
            cd_select_all_checkbox = new CheckBox();
            cd_select_all_checkbox.CheckedChanged += d_select_all_checkbox_CheckedChanged;

            o_selected_id_s = new List<KeyValuePair<int, int>>();
            o_select_all_checkbox = new CheckBox();
            o_select_all_checkbox.CheckedChanged += o_select_all_checkbox_CheckedChanged;

            ct_adapter = new PIPDataSetTableAdapters.TClinicTypeTableAdapter();
            md_adapter = new PIPDataSetTableAdapters.TMedicineDegreeTableAdapter();

            pgs_dialog = new PGSDialog(this);
            initTypeComboBox();
            initDegreeComboBox();

        }

        // //////////////////////////////////////////////// Medical Center

        // ///////////////////////// Center EVENTS
        # region Center Events

        private void c_search_button_Click(object sender, EventArgs e)
        {
            List<string> message_text = new List<string>();
            bool error = false;
            bool all_empty = true;
            string c_search_name = "";
            string c_search_national = "";
            int c_search_type = -1;
            center_grid.CellValueChanged -= center_grid_CellValueChanged;
            center_grid.CurrentCellDirtyStateChanged -= center_grid_CurrentCellDirtyStateChanged;
            if (!Regex.IsMatch(c_search_name = c_name_text.Text.Trim(), PLConstants.reg_title))
            {
                error = true;
                message_text.Add(PLConstants.error_title);
            }
            else if (c_search_name.Length > 0)
            {
                all_empty = false;
            }
            if (!Regex.IsMatch(c_search_national = c_national_id_text.Text.Trim(), PLConstants.reg_search_id_10))
            {
                error = true;
                message_text.Add(PLConstants.error_id_just_number);
            }
            else if (c_search_national.Length > 0)
            {
                all_empty = false;
            }
            if (c_type_comboBox.SelectedIndex > 0)
            {
                all_empty = false;
                c_search_type = (int)c_type_comboBox.SelectedValue;
            }

            if (error)
            {
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.error, message_text);
            }
            //else if (all_empty)
            //{
            //    pgs_dialog.singleMessage(PLConstants.dialog_types.error, PLConstants.error_search_fields_not_empty);
            //}
            else if (sMedicalCenterTableAdapter.FillBySearch(pIPDataSet.SMedicalCenter, c_search_name, c_search_national, c_search_type) == 0)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record_after_search);
                c_select_all_checkbox.Visible = false;
            }
            center_grid.CellValueChanged += center_grid_CellValueChanged;
            center_grid.CurrentCellDirtyStateChanged += center_grid_CurrentCellDirtyStateChanged;
        }

        private void c_doctors_button_Click(object sender, EventArgs e)
        {
            //getSelectedCenter();
            if (c_selected_id>-1)
            {
                center_doctors_grid.CellValueChanged -= center_doctors_grid_CellValueChanged;
                center_doctors_grid.CurrentCellDirtyStateChanged -= center_doctors_grid_CurrentCellDirtyStateChanged;
                if (tMedicalCenterDoctorsTableAdapter.Fill(pIPDataSet.TMedicalCenterDoctor, c_selected_id) == 0)
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record);
                }
                center_doctors_grid.CellValueChanged += center_doctors_grid_CellValueChanged;
                center_doctors_grid.CurrentCellDirtyStateChanged += center_doctors_grid_CurrentCellDirtyStateChanged;
                pIPDataSet.TDoctorNotInCenter.Rows.Clear();
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
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
            if (e.ColumnIndex == 0)
            {
                if (Convert.ToBoolean(center_grid.Rows[e.RowIndex].Cells[c_str_sel_col].Value))
                {
                    if (!c_is_switched)
                    {
                        int id_col = pIPDataSet.SMedicalCenter.idColumn.Ordinal;
                        c_index_one = c_index_two;
                        c_index_two = e.RowIndex;
                        c_selected_id = (int)pIPDataSet.SMedicalCenter.Rows[c_index_two][id_col];
                        center_grid.Rows[c_index_two].DefaultCellStyle.BackColor = SystemColors.Highlight;
                        center_grid.Rows[c_index_two].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
                        c_is_switched = true;
                    }
                    else
                    {
                        c_is_switched = false;
                        changeStatusOfPreviousCenterRow(c_index_one);
                    }
                }
                else if (c_index_two == e.RowIndex)
                {
                    center_grid.Rows[c_index_two].DefaultCellStyle.BackColor = SystemColors.Window;
                    center_grid.Rows[c_index_two].DefaultCellStyle.ForeColor = SystemColors.ControlText;
                    c_selected_id = -1;
                    c_index_two = -1;
                }
            }
        }

        # endregion

        // ///////////////////////// Center METHODS
        #region Center Methods

        private void getSelectedCenter()
        {
            c_selected_id_s.Clear();
            int id_col = pIPDataSet.SMedicalCenter.idColumn.Ordinal;
            for (int i=0;i<center_grid.Rows.Count;i++)
            {
                if (Convert.ToBoolean(center_grid.Rows[i].Cells[c_str_sel_col].Value))
                {
                    c_selected_id_s.Add(new KeyValuePair<int,int>(i,(int)center_grid.Rows[i].Cells[id_col].Value));
                }
            }
        }

        private List<string> getCenterDataForMessage()
        {
            int name_col = pIPDataSet.Province.nameColumn.Ordinal + 1;
            List<string> message_text = new List<string>();
            for (int i = 0; i < c_selected_id_s.Count; i++)
            {
                message_text.Add((string)center_grid.Rows[c_selected_id_s[i].Key].Cells[name_col].Value);
            }
            return message_text;
        }

        private DataTable selectedCenterToDataTable()
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
            PLGlobalFuncs.dataGridViewAfterFilling(center_grid, c_select_all_checkbox);
            //PLGlobalFuncs.createAllCheckBoxForDataGridView(center_grid, c_select_all_checkbox);

            for (int i = 0; i < center_grid.Rows.Count; i++)
            {
                center_grid.Rows[i].Cells[c_str_sel_col].Value = false;
            }
        }

        private void initTypeComboBox()
        {
            ct_data = ct_adapter.GetAllTypes();
            PIPDataSet.TClinicTypeRow mc_first_row = ct_data.NewTClinicTypeRow();
            mc_first_row.id = -1;
            mc_first_row.name = "--نوع مرکز--";
            ct_data.Rows.InsertAt(mc_first_row, 0);
            c_type_comboBox.DataSource = ct_data;
            c_type_comboBox.DisplayMember = ct_data.nameColumn.ColumnName;
            c_type_comboBox.ValueMember = ct_data.idColumn.ColumnName;
            c_type_comboBox.SelectedIndex = 0;
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(c_type_comboBox);
        }

        private void changeStatusOfPreviousCenterRow(int c_index_one)
        {
            if (c_index_one > -1)
            {
                center_grid.Rows[c_index_one].DefaultCellStyle.BackColor = SystemColors.Window;
                center_grid.Rows[c_index_one].DefaultCellStyle.ForeColor = SystemColors.ControlText;
                center_grid.Rows[c_index_one].Cells[c_str_sel_col].Value = false;
                c_index_one = -1;
            }
        }

        #endregion

        // ///////////////////////////////////////////////////// Doctors 

        // ///////////////////////// Doctors EVENTS
        #region Doctors Events
        
        private void d_search_button_Click(object sender, EventArgs e)
        {
            if (c_selected_id > 0)
            {
                center_doctors_grid.CellValueChanged -= center_doctors_grid_CellValueChanged;
                center_doctors_grid.CurrentCellDirtyStateChanged -= center_doctors_grid_CurrentCellDirtyStateChanged;
                other_doctors_grid.CellValueChanged -= other_doctors_grid_CellValueChanged;
                other_doctors_grid.CurrentCellDirtyStateChanged -= other_doctors_grid_CurrentCellDirtyStateChanged;
                List<string> message_text = new List<string>();
                bool error = false;
                bool all_empty = true;
                string d_search_name = "";
                string d_search_family = "";
                int d_search_degree = -1;

                if (!Regex.IsMatch(d_search_name = d_name_text.Text.Trim(), PLConstants.reg_small_name))
                {
                    error = true;
                    message_text.Add(PLConstants.error_names);
                }
                else if (d_search_name.Length > 0)
                {
                    all_empty = false;
                }
                if (!Regex.IsMatch(d_search_family = d_family_text.Text.Trim(), PLConstants.reg_small_name))
                {
                    error = true;
                    message_text.Add(PLConstants.error_names);
                }
                else if (d_search_family.Length > 0)
                {
                    all_empty = false;
                }
                if (d_degree_comboBox.SelectedIndex > 0)
                {
                    all_empty = false;
                    d_search_degree = (int)d_degree_comboBox.SelectedValue;
                }

                if (error)
                {
                    pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.error, message_text);
                }
                else if (all_empty)
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_search_fields_not_empty);
                }
                else if (tMedicalCenterDoctorsTableAdapter.FillBySearch(pIPDataSet.TMedicalCenterDoctor, c_selected_id, d_search_name, d_search_family, d_search_degree) == 0)
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record_medical_center_doctors);
                    cd_select_all_checkbox.Visible = false;
                }
                if (!all_empty)
                {
                    if (tDoctorsNotInCenterTableAdapter.FillBySearch(pIPDataSet.TDoctorNotInCenter, c_selected_id, d_search_name, d_search_family, d_search_degree) == 0)
                    {
                        pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record_after_search);
                        o_select_all_checkbox.Visible = false;
                    }
                }
                //center_doctors_grid.CellValueChanged += center_doctors_grid_CellValueChanged;
                //center_doctors_grid.CurrentCellDirtyStateChanged += center_doctors_grid_CurrentCellDirtyStateChanged;
                //other_doctors_grid.CellValueChanged += other_doctors_grid_CellValueChanged;
                //other_doctors_grid.CurrentCellDirtyStateChanged += other_doctors_grid_CurrentCellDirtyStateChanged;
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_medical_center_not_selected);
            }
        }

        private void edit_button_Click(object sender, EventArgs e)
        {
            getSelectedCenDoctors();
            if (cd_selected_id_s.Count > 0)
            {
                MedicalCenterDoctorForm mcd_form = new MedicalCenterDoctorForm((PIPDataSet.SMedicalCenterRow)pIPDataSet.SMedicalCenter.Rows[c_index_two], PLConstants.enum_data_operation.just_edit, selectedDoctorsToDataTable(), getDoctorsDataForMessage());
                mcd_form.ShowDialog();

                if (mcd_form.result_enum == PLConstants.enum_operation_results.success)
                {
                    center_doctors_grid.CellValueChanged -= center_doctors_grid_CellValueChanged;
                    center_doctors_grid.CurrentCellDirtyStateChanged -= center_doctors_grid_CurrentCellDirtyStateChanged;
                    other_doctors_grid.CellValueChanged -= other_doctors_grid_CellValueChanged;
                    other_doctors_grid.CurrentCellDirtyStateChanged -= other_doctors_grid_CurrentCellDirtyStateChanged;
                    tMedicalCenterDoctorsTableAdapter.Fill(pIPDataSet.TMedicalCenterDoctor, c_selected_id);
                    pIPDataSet.TDoctorNotInCenter.Clear();
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }
        }

        private void other_to_doctors_button_Click(object sender, EventArgs e)
        {
            getSelectedOthers();
            if (o_selected_id_s.Count > 0)
            {
                List<string> message_text = new List<string>();
                message_text.Add(this.Tag.ToString() + " :");

                message_text.Add(PLConstants.question_new_doctor_for_center);
                message_text.Add("مرکز درمانی انتخاب شده : " + pIPDataSet.SMedicalCenter.Rows[c_index_two][pIPDataSet.SMedicalCenter.nameColumn.Ordinal].ToString());
                message_text.Add("پزشک های انتخاب شده :");
                message_text.AddRange(getOthersDataForMessage());
                MedicalCenterDoctorForm mcd_form = new MedicalCenterDoctorForm((PIPDataSet.SMedicalCenterRow)pIPDataSet.SMedicalCenter.Rows[c_index_two], PLConstants.enum_data_operation.new_data, selectedOthersToDataTable(), getOthersDataForMessage());
                mcd_form.ShowDialog();
                if (mcd_form.result_enum == PLConstants.enum_operation_results.success)
                {
                    center_doctors_grid.CellValueChanged -= center_doctors_grid_CellValueChanged;
                    center_doctors_grid.CurrentCellDirtyStateChanged -= center_doctors_grid_CurrentCellDirtyStateChanged;
                    other_doctors_grid.CellValueChanged -= other_doctors_grid_CellValueChanged;
                    other_doctors_grid.CurrentCellDirtyStateChanged -= other_doctors_grid_CurrentCellDirtyStateChanged;
                    tMedicalCenterDoctorsTableAdapter.Fill(pIPDataSet.TMedicalCenterDoctor, c_selected_id);
                    pIPDataSet.TDoctorNotInCenter.Clear();
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }
        }

        private void doctors_to_other_button_Click(object sender, EventArgs e)
        {
            getSelectedCenDoctors();
            if (cd_selected_id_s.Count > 0)
            {
                List<string> message_text = new List<string>();
                message_text.Add(this.Tag.ToString() + " :");

                message_text.Add(PLConstants.question_delete_doctor_from_center);
                message_text.Add("مرکز درمانی انتخاب شده : " + pIPDataSet.SMedicalCenter.Rows[c_index_two][pIPDataSet.SMedicalCenter.nameColumn.Ordinal].ToString());
                message_text.Add("پزشک های انتخاب شده :");
                message_text.AddRange(getDoctorsDataForMessage());
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.delete, message_text);

                switch (pgs_dialog.user_choice)
                {
                    case PLConstants.enum_dialog_options.yes:
                        string delete_result = "";
                        tMedicalCenterDoctorsTableAdapter.DeleteDoctors(c_selected_id, selectedDoctorsToDataTable(), ref delete_result);
                        result_enum = PLEnumFuncs.opResultToEnum(delete_result);
                        pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.other);
                        if (result_enum == PLConstants.enum_operation_results.success)
                        {
                            center_doctors_grid.CellValueChanged -= center_doctors_grid_CellValueChanged;
                            center_doctors_grid.CurrentCellDirtyStateChanged -= center_doctors_grid_CurrentCellDirtyStateChanged;
                            tMedicalCenterDoctorsTableAdapter.Fill(pIPDataSet.TMedicalCenterDoctor, c_selected_id);
                            pIPDataSet.TDoctorNotInCenter.Clear();
                        }
                        break;
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }
        }

        private void center_doctors_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (center_doctors_grid.Rows.Count > 0)
            {
                PLGlobalFuncs.DGVAfterFilling(center_doctors_grid, cd_select_all_checkbox);
                center_doctors_grid.CellValueChanged += center_doctors_grid_CellValueChanged;
                center_doctors_grid.CurrentCellDirtyStateChanged += center_doctors_grid_CurrentCellDirtyStateChanged;
            }
        }

        private void other_doctors_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (other_doctors_grid.Rows.Count > 0)
            {
                PLGlobalFuncs.DGVAfterFilling(other_doctors_grid, o_select_all_checkbox);
                other_doctors_grid.CellValueChanged += other_doctors_grid_CellValueChanged;
                other_doctors_grid.CurrentCellDirtyStateChanged += other_doctors_grid_CurrentCellDirtyStateChanged;
            }
        }

        private void d_select_all_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (cd_select_all_checkbox.Checked)
            {
                for (int i = 0; i < center_doctors_grid.Rows.Count; i++)
                {
                    center_doctors_grid.Rows[i].Cells[cd_str_sel_col].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < center_doctors_grid.Rows.Count; i++)
                {
                    center_doctors_grid.Rows[i].Cells[cd_str_sel_col].Value = false;
                }
            }
        }

        private void o_select_all_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (o_select_all_checkbox.Checked)
            {
                for (int i = 0; i < other_doctors_grid.Rows.Count; i++)
                {
                    other_doctors_grid.Rows[i].Cells[o_str_sel_col].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < other_doctors_grid.Rows.Count; i++)
                {
                    other_doctors_grid.Rows[i].Cells[o_str_sel_col].Value = false;
                }
            }
        }

        private void center_doctors_grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (center_doctors_grid.IsCurrentCellDirty)
            {
                center_doctors_grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void center_doctors_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(center_doctors_grid.Rows[e.RowIndex].Cells[cd_str_sel_col].Value))
            {
                center_doctors_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                center_doctors_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
            }
            else
            {
                center_doctors_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                center_doctors_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.ControlText;
            }
        }

        private void other_doctors_grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (other_doctors_grid.IsCurrentCellDirty)
            {
                other_doctors_grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void other_doctors_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(other_doctors_grid.Rows[e.RowIndex].Cells[o_str_sel_col].Value))
            {
                other_doctors_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                other_doctors_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
            }
            else
            {
                other_doctors_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                other_doctors_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.ControlText;
            }
        }

        #endregion

        // ///////////////////////// Doctors METHODS
        #region Doctors Methods

        private void getSelectedCenDoctors()
        {
            cd_selected_id_s.Clear();
            int id_col = cd_cen_doc_seq_column.Index;
            for (int i = 0; i < center_doctors_grid.Rows.Count; i++)
            {
                if (Convert.ToBoolean(center_doctors_grid.Rows[i].Cells[cd_str_sel_col].Value))
                {
                    cd_selected_id_s.Add(new KeyValuePair<int, int>(i, (int)center_doctors_grid.Rows[i].Cells[id_col].Value));
                }
            }
        }

        private void getSelectedOthers()
        {
            o_selected_id_s.Clear();
            int id_col = o_id_column.Index;
            for (int i = 0; i < other_doctors_grid.Rows.Count; i++)
            {
                if (Convert.ToBoolean(other_doctors_grid.Rows[i].Cells[o_str_sel_col].Value))
                {
                    o_selected_id_s.Add(new KeyValuePair<int, int>(i, (int)other_doctors_grid.Rows[i].Cells[id_col].Value));
                }
            }
        }

        private List<string> getDoctorsDataForMessage()
        {
            int med_id_col = cd_doc_med_id_column.Index;
            int name_col = cd_doc_name_column.Index;
            int family_col = cd_doc_family_column.Index;
            int part_col = cd_part_name_column.Index;
            int degree_col = cd_deg_name_column.Index;
            int field_col = cd_fie_name_column.Index;
            List<string> message_text = new List<string>();
            for (int i = 0; i < cd_selected_id_s.Count; i++)
            {
                message_text.Add(center_doctors_grid.Rows[cd_selected_id_s[i].Key].Cells[med_id_col].Value.ToString() + "  " +
                                 center_doctors_grid.Rows[cd_selected_id_s[i].Key].Cells[name_col].Value.ToString() + "  " +
                                 center_doctors_grid.Rows[cd_selected_id_s[i].Key].Cells[family_col].Value.ToString() + "  " +
                                 center_doctors_grid.Rows[cd_selected_id_s[i].Key].Cells[part_col].Value.ToString() + "  " +
                                 center_doctors_grid.Rows[cd_selected_id_s[i].Key].Cells[degree_col].Value.ToString() + " " +
                                 center_doctors_grid.Rows[cd_selected_id_s[i].Key].Cells[field_col].Value.ToString());
            }
            return message_text;
        }

        private List<string> getOthersDataForMessage()
        {
            int med_id_col = o_medical_id_column.Index;
            int name_col = o_name_column.Index;
            int family_col = o_family_name_column.Index;
            int degree_col = o_degree_name_column.Index;
            int field_col = o_field_name_column.Index;
            List<string> message_text = new List<string>();
            for (int i = 0; i < o_selected_id_s.Count; i++)
            {
                message_text.Add(other_doctors_grid.Rows[o_selected_id_s[i].Key].Cells[med_id_col].Value.ToString() + "  " +
                                 (string)other_doctors_grid.Rows[o_selected_id_s[i].Key].Cells[name_col].Value + "  " +
                                 (string)other_doctors_grid.Rows[o_selected_id_s[i].Key].Cells[family_col].Value + "  " +
                                 (string)other_doctors_grid.Rows[o_selected_id_s[i].Key].Cells[degree_col].Value + " " +
                                 (string)other_doctors_grid.Rows[o_selected_id_s[i].Key].Cells[field_col].Value);
            }
            return message_text;
        }

        private DataTable selectedDoctorsToDataTable()
        {
            DataTable s_d_t = new DataTable();
            s_d_t.Columns.Add("d_id", typeof(int));
            foreach (KeyValuePair<int, int> d_id in cd_selected_id_s)
            {
                s_d_t.Rows.Add(d_id.Value);
            }
            return s_d_t;
        }

        private DataTable selectedOthersToDataTable()
        {
            DataTable s_o_t = new DataTable();
            s_o_t.Columns.Add("o_id", typeof(int));
            foreach (KeyValuePair<int, int> o_id in o_selected_id_s)
            {
                s_o_t.Rows.Add(o_id.Value);
            }
            return s_o_t;
        }

        //private void afterCenterDoctorsGridFilled()
        //{
        //    PLGlobalFuncs.dataGridViewAfterFilling(center_doctors_grid, cd_select_all_checkbox);
        //    PLGlobalFuncs.createAllCheckBoxForDataGridView(center_doctors_grid, cd_select_all_checkbox);

        //    for (int i = 0; i < center_doctors_grid.Rows.Count; i++)
        //    {
        //        center_doctors_grid.Rows[i].Cells[cd_str_sel_col].Value = false;
        //    }
        //}

        //private void afterOtherDoctorsGridFilled()
        //{
        //    PLGlobalFuncs.dataGridViewAfterFilling(other_doctors_grid, o_select_all_checkbox);
        //    PLGlobalFuncs.createAllCheckBoxForDataGridView(other_doctors_grid, o_select_all_checkbox);

        //    for (int i = 0; i < other_doctors_grid.Rows.Count; i++)
        //    {
        //        other_doctors_grid.Rows[i].Cells[o_str_sel_col].Value = false;
        //    }
        //}

        private void initDegreeComboBox()
        {
            degrees_data = md_adapter.GetAllDegrees();
            PIPDataSet.TMedicineDegreeRow md_first_row = degrees_data.NewTMedicineDegreeRow();
            md_first_row.id = -1;
            md_first_row.name = "--مدرک پزشکی--";
            degrees_data.Rows.InsertAt(md_first_row, 0);
            d_degree_comboBox.DataSource = degrees_data;
            d_degree_comboBox.DisplayMember = degrees_data.nameColumn.ColumnName;
            d_degree_comboBox.ValueMember = degrees_data.idColumn.ColumnName;
            d_degree_comboBox.SelectedIndex = 0;
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(d_degree_comboBox);
        }

        #endregion


    }
}
