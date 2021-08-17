using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;

namespace PadraInsurancePrescription
{
    public partial class MedicalServiceTariffControl : UserControl
    {

        string t_str_sel_col;

        int t_index;
        PIPDataSet.TMedicalServiceTariffRow t_selected_data;
        List<KeyValuePair<int,long>> t_selected_id_s;//1-row number 2-id
        CheckBox t_select_all_checkbox;

        string t_search_name;
        string t_search_code;
        int t_search_category;
        string t_search_alias;
        int t_search_insurance;
        int t_search_sector;
        int t_search_cost;
        int t_search_ins_sh;
        int t_search_pat_sh;
        float? t_search_ins_percent;

        int temp_ins;

        PGSDialog pgs_dialog;
        PLConstants.enum_operation_results result_enum;

        PIPDataSetTableAdapters.TMedicalServiceCategoryTableAdapter c_adapter;
        PIPDataSetTableAdapters.TInsuranceTableAdapter i_adapter;
        PIPDataSetTableAdapters.TInsuranceSectorTableAdapter s_adapter;

        PIPDataSet.TMedicalServiceCategoryDataTable categories_data;
        PIPDataSet.TInsuranceDataTable insurances_data;
        PIPDataSet.TInsuranceSectorDataTable s_data;

        public MedicalServiceTariffControl()
        {
            //column 0 is checkboxes and not in arrays
            InitializeComponent();
            PLGlobalFuncs.changeDGVSettings(tariff_grid);
            t_str_sel_col = t_select_column.Name;

            t_selected_id_s = new List<KeyValuePair<int, long>>();
            t_select_all_checkbox = new CheckBox();
            t_select_all_checkbox.CheckedChanged += t_select_all_checkbox_CheckedChanged;

            pgs_dialog = new PGSDialog(this);

            c_adapter = new PIPDataSetTableAdapters.TMedicalServiceCategoryTableAdapter();
            i_adapter = new PIPDataSetTableAdapters.TInsuranceTableAdapter();
            s_adapter = new PIPDataSetTableAdapters.TInsuranceSectorTableAdapter();
            initCategoryComboBox();
            initInsuranceComboBox();
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(category_combobox);
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(insurance_combobox);
        }

        // ///////////////////////////////////////////////////// Medical Service Tariff

        // ///////////////////////// Medical Service Tariff EVENTS
        # region medical service tariff Events
        private void insurance_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (insurance_combobox.SelectedIndex > 0)
            {
                temp_ins = (int)insurance_combobox.SelectedValue;
                initInsSectorComboBox(temp_ins);
                sector_combobox.Enabled = true;
            }
            else
            {
                temp_ins = -1;
                sector_combobox.Enabled = false;
                sector_combobox.DataSource = null;
            }
        }

        private void search_button_Click(object sender, EventArgs e)//checked
        {
            List<string> message_text = new List<string>();
            bool error = false;
            bool all_empty = true;
            t_search_name = "";
            t_search_code = "";
            t_search_category = -1;
            t_search_alias = "";
            t_search_insurance = -1;
            t_search_sector = -1;
            string t_s_temp;
            t_search_cost = -1;
            t_search_ins_sh = -1;
            t_search_pat_sh = -1;
            t_search_ins_percent = null;
            
            if (!Regex.IsMatch(t_search_name = name_textbox.Text.Trim(), PLConstants.reg_m_service_name_search))
            {
                error = true;
                message_text.Add(PLConstants.error_medical_service_name);
            }
            else if(t_search_name.Length>0)
            {
                all_empty = false;
            }
            if (!Regex.IsMatch(t_search_code = code_textbox.Text.Trim(), PLConstants.reg_search_id_10))
            {
                error = true;
                message_text.Add(PLConstants.error_id_just_number);
            }
            else if(t_search_code.Length>0)
            {
                all_empty = false;
            }
            if (category_combobox.SelectedIndex > 0)
            {
                all_empty = false;
                t_search_category = (int)category_combobox.SelectedValue;
            }
            if (!Regex.IsMatch(t_search_alias = alias_textbox.Text.Trim(), PLConstants.reg_m_service_name_search))
            {
                error = true;
                message_text.Add(PLConstants.error_medical_service_name);
            }
            else if (t_search_alias.Length > 0)
            {
                all_empty = false;
            }
            if (insurance_combobox.SelectedIndex > 0)
            {
                all_empty = false;
                t_search_insurance = (int)insurance_combobox.SelectedValue;
            }
            if (sector_combobox.SelectedIndex > 0)
            {
                all_empty = false;
                t_search_sector = (int)sector_combobox.SelectedValue;
            }
            if ((t_s_temp = total_textbox.Text.Trim()) != "")
            {
                if ((!int.TryParse(t_s_temp, out t_search_cost)) || (t_search_cost <= 0))
                {
                    error = true;
                    message_text.Add(PLConstants.error_cost_int);
                }
                else
                {
                    all_empty = false;
                }
            }
            if ((t_s_temp = ins_share_textbox.Text.Trim()) != "")
            {
                if ((!int.TryParse(t_s_temp, out t_search_ins_sh)) || (t_search_ins_sh <= 0))
                {
                    error = true;
                    message_text.Add(PLConstants.error_cost_int);
                }
                else
                {
                    all_empty = false;
                }
            }
            if ((t_s_temp = pat_share_textbox.Text.Trim()) != "")
            {
                if ((!int.TryParse(t_s_temp, out t_search_pat_sh)) || (t_search_pat_sh <= 0))
                {
                    error = true;
                    message_text.Add(PLConstants.error_cost_int);
                }
                else
                {
                    all_empty = false;
                }
            }
            if (!Regex.IsMatch(ins_percent_textbox.Text.Trim(), PLConstants.reg_float_code))
            {
                error = true;
                message_text.Add(PLConstants.error_numbers_float);
            }
            else if (ins_percent_textbox.Text.Trim().Length > 0)
            {
                t_search_ins_percent = Single.Parse(ins_percent_textbox.Text.Trim());
                all_empty = false;
            }

            tariff_grid.CellValueChanged -= tariff_grid_CellValueChanged;
            tariff_grid.CurrentCellDirtyStateChanged -= tariff_grid_CurrentCellDirtyStateChanged;
            if (error)
            {
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.error, message_text);
            }
            else if (all_empty)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_search_fields_not_empty);
            }
            else if (tMedicalServiceTariffTableAdapter.FillBySearch(pIPDataSet.TMedicalServiceTariff,t_search_name,t_search_category,
                t_search_code,t_search_alias,t_search_insurance,t_search_sector,t_search_cost,t_search_ins_sh,t_search_pat_sh,t_search_ins_percent) == 0)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record_after_search);
                t_select_all_checkbox.Visible = false;
            }
            tariff_grid.CellValueChanged += tariff_grid_CellValueChanged;
            tariff_grid.CurrentCellDirtyStateChanged += tariff_grid_CurrentCellDirtyStateChanged;
        }

        private void new_button_Click(object sender, EventArgs e)//checked
        {
            MedicalServiceTariffForm t_form = new MedicalServiceTariffForm(null, PLConstants.enum_data_operation.new_data, null);
            t_form.ShowDialog();
        }

        private void edit_button_Click(object sender, EventArgs e)//checked
        {
            getSelectedTariffs();
            if (t_selected_id_s.Count == 1)
            {
                t_index = t_selected_id_s[0].Key;
                t_selected_data = ((PIPDataSet.TMedicalServiceTariffRow)pIPDataSet.TMedicalServiceTariff.Rows[t_index]);
                MedicalServiceTariffForm t_form = new MedicalServiceTariffForm(t_selected_data, PLConstants.enum_data_operation.edit_data, null);
                t_form.ShowDialog();
            }
            //else if (t_selected_id_s.Count > 1)
            //{
            //    //d_selected_data = ((PIPDataSet.TDoctorRow)pIPDataSet.TDoctor.Rows[d_index]);
            //    MedicalServiceTariffForm t_form = new MedicalServiceTariffForm(null, PLConstants.data_operation.batch_edit, selectedTariffsToDataTable());
            //    t_form.ShowDialog();
            //}
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_choose_one);
            }
        }

        private void delete_button_Click(object sender, EventArgs e)//checked
        {
            getSelectedTariffs();
            if (t_selected_id_s.Count > 0)
            {
                List<string> message_text = new List<string>();
                message_text.Add(this.Tag.ToString() + " :");

                message_text.Add(PLConstants.question_delete);
                message_text.Add("تعرفه پزشکی انتخاب شده :");
                message_text.AddRange(getTariffsDataForMessage());
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.delete, message_text);

                switch (pgs_dialog.user_choice)
                {
                    case PLConstants.enum_dialog_options.yes:
                        string delete_result = "";
                        tMedicalServiceTariffTableAdapter.DeleteMedicalTariffs(selectedTariffsToDataTable(), ref delete_result);
                        result_enum = PLEnumFuncs.opResultToEnum(delete_result);
                        pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.other);
                        switch (result_enum)
                        {
                            case PLConstants.enum_operation_results.success:
                                tariff_grid.CellValueChanged -= tariff_grid_CellValueChanged;
                                tariff_grid.CurrentCellDirtyStateChanged -= tariff_grid_CurrentCellDirtyStateChanged;
                                pIPDataSet.TMedicalServiceTariff.Clear();
                                break;
                        }
                        break;
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }
        }

        private void copy_button_Click(object sender, EventArgs e)
        {
            getSelectedTariffs();
            if (t_selected_id_s.Count == 1)
            {
                t_index = t_selected_id_s[0].Key;
                t_selected_data = ((PIPDataSet.TMedicalServiceTariffRow)pIPDataSet.TMedicalServiceTariff.Rows[t_index]);
                MedicalServiceTariffForm s_form = new MedicalServiceTariffForm(t_selected_data, PLConstants.enum_data_operation.copy_data, null);
                s_form.ShowDialog();
            }
            //else if (t_selected_id_s.Count > 1)
            //{
            //    MedicalServiceTariffForm s_form = new MedicalServiceTariffForm(null, PLConstants.data_operation.batch_copy, selectedTariffsToDataTable());
            //    s_form.ShowDialog();
            //}
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_choose_one);
            }
        }
        
        private void update_button_Click(object sender, EventArgs e)
        {

        }

        private void export_button_Click(object sender, EventArgs e)
        {

        }

        private void import_button_Click(object sender, EventArgs e)
        {

        }

        private void t_select_all_checkbox_CheckedChanged(object sender, EventArgs e)//checked
        {
            if (t_select_all_checkbox.Checked)
            {
                for (int i = 0; i < tariff_grid.Rows.Count; i++)
                {
                    tariff_grid.Rows[i].Cells[t_str_sel_col].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < tariff_grid.Rows.Count; i++)
                {
                    tariff_grid.Rows[i].Cells[t_str_sel_col].Value = false;
                }
            }
        }

        private void tariff_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)//checked
        {
            if (tariff_grid.Rows.Count > 0)
            {
                PLGlobalFuncs.DGVAfterFilling(tariff_grid, t_select_all_checkbox);
                tariff_grid.CellValueChanged += tariff_grid_CellValueChanged;
                tariff_grid.CurrentCellDirtyStateChanged += tariff_grid_CurrentCellDirtyStateChanged;
            }
        }

        private void tariff_grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tariff_grid.IsCurrentCellDirty)
            {
                tariff_grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void tariff_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(tariff_grid.Rows[e.RowIndex].Cells[t_str_sel_col].Value))
            {
                tariff_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                tariff_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
            }
            else
            {
                tariff_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                tariff_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.ControlText;
            }
        }

        # endregion

        // ///////////////////////// medical service tariff METHODS
        #region medical service tariff Methods

        private void initCategoryComboBox()
        {
            categories_data = c_adapter.GetAllCategories();
            PIPDataSet.TMedicalServiceCategoryRow c_first_row = categories_data.NewTMedicalServiceCategoryRow();
            c_first_row.id = -1;
            c_first_row.name = "--نوع خدمت پزشکی--";
            categories_data.Rows.InsertAt(c_first_row, 0);
            category_combobox.DataSource = categories_data;
            category_combobox.DisplayMember = categories_data.nameColumn.ColumnName;
            category_combobox.ValueMember = categories_data.idColumn.ColumnName;
            category_combobox.SelectedIndex = 0;
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(category_combobox);
        }

        private void initInsuranceComboBox()//checked
        {
            insurances_data = i_adapter.GetAllInsurances();
            PIPDataSet.TInsuranceRow i_first_row = insurances_data.NewTInsuranceRow();
            i_first_row.id = -1;
            i_first_row.name = "---شرکت بیمه---";
            insurances_data.Rows.InsertAt(i_first_row, 0);
            insurance_combobox.DataSource = insurances_data;
            insurance_combobox.DisplayMember = insurances_data.nameColumn.ColumnName;
            insurance_combobox.ValueMember = insurances_data.idColumn.ColumnName;
            insurance_combobox.SelectedIndex = 0;
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(insurance_combobox);
        }
        private void initInsSectorComboBox(int selected_insurance)//checked
        {
            s_data = s_adapter.GetAllSectors(selected_insurance);
            PIPDataSet.TInsuranceSectorRow s_first_row = s_data.NewTInsuranceSectorRow();
            s_first_row.id = -1;
            s_first_row.name = "--صندوق بیمه--";
            s_data.Rows.InsertAt(s_first_row, 0);
            sector_combobox.DataSource = s_data;
            sector_combobox.DisplayMember = s_data.nameColumn.ColumnName;
            sector_combobox.ValueMember = s_data.idColumn.ColumnName;
            sector_combobox.SelectedIndex = 0;
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(sector_combobox);
        }

        private void getSelectedTariffs()
        {
            t_selected_id_s.Clear();
            int id_col=pIPDataSet.TMedicalService.sequenceColumn.Ordinal+1;
            for (int i=0;i<tariff_grid.Rows.Count;i++)
            {
                if (Convert.ToBoolean(tariff_grid.Rows[i].Cells[t_str_sel_col].Value))
                {
                    t_selected_id_s.Add(new KeyValuePair<int,long>(i,(long)tariff_grid.Rows[i].Cells[id_col].Value));
                }
            }
        }

        private List<string> getTariffsDataForMessage()
        {
            int alias_col = t_alias_name_column.Index;
            int name_col = t_name_column.Index;
            int national_id_col = t_national_id_column.Index;
            int ins_col = t_t_ins_name_column.Index;
            int sec_col = t_t_sec_name_column.Index;
            int public_ins = t_pub_ins_sha_column.Index;
            List<string> message_text = new List<string>();
            for (int i = 0; i < t_selected_id_s.Count; i++)
            {
                message_text.Add(tariff_grid.Rows[t_selected_id_s[i].Key].Cells[alias_col].Value.ToString()+" - "+
                                 tariff_grid.Rows[t_selected_id_s[i].Key].Cells[name_col].Value.ToString() + " - " +
                                 tariff_grid.Rows[t_selected_id_s[i].Key].Cells[national_id_col].Value.ToString() + " - " +
                                 tariff_grid.Rows[t_selected_id_s[i].Key].Cells[ins_col].Value.ToString() + " - " +
                                 tariff_grid.Rows[t_selected_id_s[i].Key].Cells[sec_col].Value.ToString() + " - " +
                                 tariff_grid.Rows[t_selected_id_s[i].Key].Cells[public_ins].Value.ToString());
            }
            return message_text;
        }

        private DataTable selectedTariffsToDataTable()
        {
            DataTable s_s_t = new DataTable();
            s_s_t.Columns.Add(PLConstants.str_table_col_entity_id, typeof(int));
            foreach (KeyValuePair<int, long> s_id in t_selected_id_s)
            {
                s_s_t.Rows.Add(s_id.Value);
            }
            return s_s_t;
        }

        //private void afterTariffGridFilled()
        //{
        //    PLGlobalFuncs.dataGridViewAfterFilling(tariff_grid, t_select_all_checkbox);
        //    PLGlobalFuncs.createAllCheckBoxForDataGridView(tariff_grid, t_select_all_checkbox);

        //    for (int i = 0; i < tariff_grid.Rows.Count; i++)
        //    {
        //        tariff_grid.Rows[i].Cells[t_str_sel_col].Value = false;
        //    }
        //}

        # endregion

    }
}
