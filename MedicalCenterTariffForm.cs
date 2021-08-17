using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Data;


namespace PadraInsurancePrescription
{
    public partial class MedicalCenterTariffForm : Form
    {
        string t_str_sel_col;
        string o_str_sel_col;
        
        List<KeyValuePair<int, long>> t_selected_id_s;//1-row number 2-id
        CheckBox t_select_all_checkbox;

        List<KeyValuePair<int, long>> o_selected_id_s;//1-row number 2-id
        CheckBox o_select_all_checkbox;

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

        PIPDataSet.SMedicalCenterRow selected_center;

        public MedicalCenterTariffForm(PIPDataSet.SMedicalCenterRow selected_center)//checked
        {
            InitializeComponent();
            PLGlobalFuncs.changeDGVSettings(tariff_grid,other_grid);
            PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.data);

            this.selected_center = selected_center;

            t_str_sel_col = "t_select_column";
            o_str_sel_col = "o_select_column";

            t_selected_id_s = new List<KeyValuePair<int, long>>();
            t_select_all_checkbox = new CheckBox();
            t_select_all_checkbox.CheckedChanged += t_select_all_checkbox_CheckedChanged;

            o_selected_id_s = new List<KeyValuePair<int, long>>();
            o_select_all_checkbox = new CheckBox();
            o_select_all_checkbox.CheckedChanged += o_select_all_checkbox_CheckedChanged;

            pgs_dialog = new PGSDialog(this);

            center_name_label.Text = selected_center.clinic_type_name + ">" + selected_center.id + " - " + selected_center.name + " - " + selected_center.province_name + " - " + selected_center.city_name;

            c_adapter = new PIPDataSetTableAdapters.TMedicalServiceCategoryTableAdapter();
            i_adapter = new PIPDataSetTableAdapters.TInsuranceTableAdapter();
            s_adapter = new PIPDataSetTableAdapters.TInsuranceSectorTableAdapter();
            initCategoryComboBox();
            initInsuranceComboBox();
        }

        // ///////////////////////// Tariffs EVENTS
        #region Tariffs Events

        private void MedicalCenterTariffForm_Shown(object sender, EventArgs e)
        {
            //show_services_button_Click(null, EventArgs.Empty);
        }

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

        private void search_button_Click(object sender, EventArgs e)
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
            else if (t_search_name.Length > 0)
            {
                all_empty = false;
            }
            if (!Regex.IsMatch(t_search_code = code_textbox.Text.Trim(), PLConstants.reg_search_id_10))
            {
                error = true;
                message_text.Add(PLConstants.error_id_just_number);
            }
            else if (t_search_code.Length > 0)
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
            other_grid.CellValueChanged -= other_grid_CellValueChanged;
            other_grid.CurrentCellDirtyStateChanged -= other_grid_CurrentCellDirtyStateChanged;
            if (error)
            {
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.error, message_text);
            }
            else if (all_empty)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_search_fields_not_empty);
            }
            else if (tMedicalCenterTariffTableAdapter.FillBySearchBig(pIPDataSet.TMedicalCenterTariff, selected_center.id, t_search_name, t_search_category,
                t_search_code, t_search_alias, t_search_insurance, t_search_sector, t_search_cost, t_search_ins_sh, t_search_pat_sh, t_search_ins_percent) == 0)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record_medical_center_services);
                t_select_all_checkbox.Visible = false;
            }
            if (!all_empty)
            {
                if (tMedicalServiceTariffNotInCenterTableAdapter.FillBySearch(pIPDataSet.TMedicalServiceTariffNotInCenter, selected_center.id, t_search_name, t_search_category,
                    t_search_code, t_search_alias, t_search_insurance , t_search_sector, t_search_cost, t_search_ins_sh, t_search_pat_sh, t_search_ins_percent) == 0)
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record_after_search);
                    o_select_all_checkbox.Visible = false;
                }
            }
        }

        private void show_services_button_Click(object sender, EventArgs e)
        {
            tariff_grid.CellValueChanged -= tariff_grid_CellValueChanged;
            tariff_grid.CurrentCellDirtyStateChanged -= tariff_grid_CurrentCellDirtyStateChanged;
            if (tMedicalCenterTariffTableAdapter.Fill(pIPDataSet.TMedicalCenterTariff, selected_center.id) == 0)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record_medical_center_services);
            }
            pIPDataSet.TMedicalServiceTariffNotInCenter.Rows.Clear();
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            getSelectedTariffs();
            if (t_selected_id_s.Count > 0)
            {
                List<string> message_text = new List<string>();
                message_text.Add(this.Tag.ToString() + " :");

                message_text.Add(PLConstants.question_delete_tariff_from_center);
                message_text.Add("مرکز درمانی انتخاب شده : " + selected_center.name);
                message_text.Add("تعرفه های انتخاب شده :");
                message_text.AddRange(getTariffsDataForMessage());
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.delete, message_text);

                switch (pgs_dialog.user_choice)
                {
                    case PLConstants.enum_dialog_options.yes:
                        string delete_result = "";
                        tMedicalCenterTariffTableAdapter.DeleteTariffs(selectedTariffsToDataTable(), ref delete_result);
                        result_enum = PLEnumFuncs.opResultToEnum(delete_result);
                        pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.other);
                        if (result_enum == PLConstants.enum_operation_results.success)
                        {
                            //tariff_grid.CellValueChanged -= tariff_grid_CellValueChanged;
                            //tariff_grid.CurrentCellDirtyStateChanged -= tariff_grid_CurrentCellDirtyStateChanged;
                            //tMedicalCenterTariffTableAdapter.Fill(pIPDataSet.TMedicalCenterTariff, selected_center.id);
                            pIPDataSet.TMedicalServiceTariffNotInCenter.Clear();
                        }
                        break;
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            getSelectedOthers();
            if (o_selected_id_s.Count > 0)
            {
                List<string> message_text = new List<string>();
                message_text.Add(this.Tag.ToString() + " :");

                message_text.Add(PLConstants.question_new_tariff_for_center);
                message_text.Add("مرکز درمانی انتخاب شده : " + selected_center.name);
                message_text.Add("تعرفه های انتخاب شده :");
                message_text.AddRange(getOthersDataForMessage());
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.save_new, message_text);

                switch (pgs_dialog.user_choice)
                {
                    case PLConstants.enum_dialog_options.yes:
                        string add_result = "";
                        tMedicalCenterTariffTableAdapter.AddTariffs(selected_center.id,selectedOthersToDataTable(), ref add_result);
                        result_enum = PLEnumFuncs.opResultToEnum(add_result);
                        pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.other);
                        if (result_enum == PLConstants.enum_operation_results.success)
                        {
                            tariff_grid.CellValueChanged -= tariff_grid_CellValueChanged;
                            tariff_grid.CurrentCellDirtyStateChanged -= tariff_grid_CurrentCellDirtyStateChanged;
                            //tMedicalCenterTariffTableAdapter.Fill(pIPDataSet.TMedicalCenterTariff, selected_center.id);
                            pIPDataSet.TMedicalServiceTariffNotInCenter.Clear();
                        }
                        break;
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }
        }

        private void tariff_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (tariff_grid.Rows.Count > 0)
            {
                PLGlobalFuncs.DGVAfterFilling(tariff_grid, t_select_all_checkbox);
                tariff_grid.CellValueChanged += tariff_grid_CellValueChanged;
                tariff_grid.CurrentCellDirtyStateChanged += tariff_grid_CurrentCellDirtyStateChanged;
            }
        }

        private void other_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (other_grid.Rows.Count > 0)
            {
                PLGlobalFuncs.DGVAfterFilling(other_grid, o_select_all_checkbox);
                other_grid.CellValueChanged += other_grid_CellValueChanged;
                other_grid.CurrentCellDirtyStateChanged += other_grid_CurrentCellDirtyStateChanged;
            }
        }

        private void t_select_all_checkbox_CheckedChanged(object sender, EventArgs e)
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

        private void o_select_all_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (o_select_all_checkbox.Checked)
            {
                for (int i = 0; i < other_grid.Rows.Count; i++)
                {
                    other_grid.Rows[i].Cells[o_str_sel_col].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < other_grid.Rows.Count; i++)
                {
                    other_grid.Rows[i].Cells[o_str_sel_col].Value = false;
                }
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

        private void other_grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (other_grid.IsCurrentCellDirty)
            {
                other_grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void other_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(other_grid.Rows[e.RowIndex].Cells[o_str_sel_col].Value))
            {
                other_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                other_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
            }
            else
            {
                other_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                other_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.ControlText;
            }
        }

        #endregion Tariffs Events

        // ///////////////////////// Tariffs METHODS
        #region Tariffs Methods

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
            i_first_row.tag = "";
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
            int id_col = t_cen_tar_seq_column.Index;
            for (int i = 0; i < tariff_grid.Rows.Count; i++)
            {
                if (Convert.ToBoolean(tariff_grid.Rows[i].Cells[t_str_sel_col].Value))
                {
                    t_selected_id_s.Add(new KeyValuePair<int, long>(i, (long)tariff_grid.Rows[i].Cells[id_col].Value));
                }
            }
        }

        private List<string> getTariffsDataForMessage()
        {
            int tar_seq_col = t_sequence_column.Index;
            int alias_col = t_alias_name_column.Index;
            int name_col = t_name_column.Index;
            int national_id_col = t_national_id_column.Index;
            int ins_col = t_ins_name_column.Index;
            int sec_col = t_sector_name_column.Index;
            int ins_share = t_public_insurance_share_column.Index;
            List<string> message_text = new List<string>();
            for (int i = 0; i < t_selected_id_s.Count; i++)
            {
                message_text.Add(tariff_grid.Rows[t_selected_id_s[i].Key].Cells[tar_seq_col].Value.ToString() + " - " +
                                 tariff_grid.Rows[t_selected_id_s[i].Key].Cells[alias_col].Value.ToString() + " - " +
                                 tariff_grid.Rows[t_selected_id_s[i].Key].Cells[name_col].Value.ToString() + " - " +
                                 tariff_grid.Rows[t_selected_id_s[i].Key].Cells[national_id_col].Value.ToString() + " - " +
                                 tariff_grid.Rows[t_selected_id_s[i].Key].Cells[ins_col].Value.ToString() + " - " +
                                 tariff_grid.Rows[t_selected_id_s[i].Key].Cells[sec_col].Value.ToString() + " - " +
                                 tariff_grid.Rows[t_selected_id_s[i].Key].Cells[ins_share].Value.ToString());
            }
            return message_text;
        }

        private DataTable selectedTariffsToDataTable()
        {
            DataTable s_t_t = new DataTable();
            s_t_t.Columns.Add(PLConstants.str_table_col_entity_id, typeof(long));
            foreach (KeyValuePair<int, long> s_id in t_selected_id_s)
            {
                s_t_t.Rows.Add(s_id.Value);
            }
            return s_t_t;
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

        private void getSelectedOthers()
        {
            o_selected_id_s.Clear();
            int id_col = o_sequence_column.Index;
            for (int i = 0; i < other_grid.Rows.Count; i++)
            {
                if (Convert.ToBoolean(other_grid.Rows[i].Cells[o_str_sel_col].Value))
                {
                    o_selected_id_s.Add(new KeyValuePair<int, long>(i, (long)other_grid.Rows[i].Cells[id_col].Value));
                }
            }
        }

        private List<string> getOthersDataForMessage()
        {
            int tar_seq_col = o_sequence_column.Index;
            int alias_col = o_alias_name_column.Index;
            int name_col = o_name_column.Index;
            int national_id_col = o_national_id_column.Index;
            int ins_col = o_ins_name_column.Index;
            int sec_col = o_sector_name_column.Index;
            int ins_share = o_public_insurance_share_column.Index;
            List<string> message_text = new List<string>();
            for (int i = 0; i < o_selected_id_s.Count; i++)
            {
                message_text.Add(other_grid.Rows[o_selected_id_s[i].Key].Cells[tar_seq_col].Value.ToString() + " - " +
                                 other_grid.Rows[o_selected_id_s[i].Key].Cells[alias_col].Value.ToString() + " - " +
                                 other_grid.Rows[o_selected_id_s[i].Key].Cells[name_col].Value.ToString() + " - " +
                                 (string)other_grid.Rows[o_selected_id_s[i].Key].Cells[national_id_col].Value.ToString() + " - " +
                                 other_grid.Rows[o_selected_id_s[i].Key].Cells[ins_col].Value.ToString() + " - " +
                                 other_grid.Rows[o_selected_id_s[i].Key].Cells[sec_col].Value.ToString() + " - " +
                                 other_grid.Rows[o_selected_id_s[i].Key].Cells[ins_share].Value.ToString());
            }
            return message_text;
        }

        private DataTable selectedOthersToDataTable()
        {
            DataTable s_o_t = new DataTable();
            s_o_t.Columns.Add("o_id", typeof(int));
            foreach (KeyValuePair<int, long> o_id in o_selected_id_s)
            {
                s_o_t.Rows.Add(o_id.Value);
            }
            return s_o_t;
        }

        //private void afterOthersGridFilled()
        //{
        //    PLGlobalFuncs.dataGridViewAfterFilling(other_grid, o_select_all_checkbox);
        //    PLGlobalFuncs.createAllCheckBoxForDataGridView(other_grid, o_select_all_checkbox);

        //    for (int i = 0; i < other_grid.Rows.Count; i++)
        //    {
        //        other_grid.Rows[i].Cells[o_str_sel_col].Value = false;
        //    }
        //}

        #endregion

        
        
    }
}
