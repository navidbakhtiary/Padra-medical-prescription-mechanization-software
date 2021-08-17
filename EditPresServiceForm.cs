using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Data;
using System.ComponentModel;

namespace PadraInsurancePrescription
{
    public partial class EditPresServiceForm : Form
    {
        //////////////////////////////////////////////////////////////////// PUBLIC VARIABLES
        PGSDialog pgs_dialog;
        bool were_actions_successeded=false;

        int? sel_center;
        int? sel_part;
        int sel_insurance;
        int sel_sector;
        string sel_vis_year;
        string sel_vis_month;
        int sel_servicing_count;

        string op_result_str;
        PLConstants.enum_operation_results result_enum;
        
        //////////////////////////////////////////////////////////////////// SERVICE VARIABLES
        PIPDataSetTableAdapters.TMedicalServiceCategoryTableAdapter s_ser_category_adapter;
        PIPDataSet.TMedicalServiceCategoryDataTable s_ser_category_data;
        PIPDataSet.TMedicalCenterTariffDataTable s_temp_center_tariffs;
        
        CheckBox s_service_select_all_chk, s_choosed_select_all_chk;
        string s_ser_str_sel_col, s_cho_str_sel_col;
        List<KeyValuePair<int, long>> s_list_sel_tariffs;//1-row number 2-id
        DataTable p_table_preses_sequence;
        DataTable s_table_sel_tariffs;

        delegate void ORG_delete_pres_services_del();
        ORG_delete_pres_services_del org_delete_pres_services_func;
        delegate void ORG_edit_pres_services_del();
        ORG_edit_pres_services_del org_edit_pres_services_func;
        delegate void ORG_add_services_to_pres_del();
        ORG_add_services_to_pres_del org_add_services_to_pres_func;
        delegate void ORG_delete_all_pres_services_del();
        ORG_delete_all_pres_services_del org_delete_all_pres_services_func;

        public EditPresServiceForm(int center_id,string center_name,
                                   int center_part_id,string part_name,
                                   int insurance_id,string insurance_name,PLConstants.enum_insurances insurance_org,
                                   int sector_id,string sector_name,
                                   string year_value,
                                   string month_value,string month_name,
                                   DataTable preses_sequence,PIPDataSet.SPrescriptionInfoDataTable preses_details)//checked
        {
            InitializeComponent();
            PLGlobalFuncs.changeDGVSettings(preses_grid,s_service_grid);
            PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.main);

            sel_center = center_id;
            center_value_lbl.Text = center_name;
            sel_part = center_part_id;
            part_value_lbl.Text = part_name;
            sel_insurance = insurance_id;
            insurance_value_lbl.Text = insurance_name;
            sel_sector = sector_id;
            sector_value_lbl.Text = sector_name;
            year_value_lbl.Text=sel_vis_year = year_value;
            sel_vis_month = month_value;
            month_value_lbl.Text = month_name;
            preses_lbl.Text = preses_lbl.Text + "(" + preses_sequence.Rows.Count.ToString("N0") + " مورد)";

            s_ser_category_adapter = new PIPDataSetTableAdapters.TMedicalServiceCategoryTableAdapter();
            s_service_select_all_chk = new CheckBox();
            s_choosed_select_all_chk = new CheckBox();
            s_service_select_all_chk.CheckedChanged += s_service_select_all_checkbox_CheckedChanged;
            s_choosed_select_all_chk.CheckedChanged += s_choosed_select_all_checkbox_CheckedChanged;
            s_service_select_all_chk.Visible = false;
            s_choosed_select_all_chk.Visible = false;
            s_ser_str_sel_col = s_ser_select_column.Name;
            s_cho_str_sel_col = s_cho_select_column.Name;
            s_list_sel_tariffs = new List<KeyValuePair<int, long>>();
            s_table_sel_tariffs = PLGlobalFuncs.emptyLongIDsDataTable();
            s_temp_center_tariffs = new PIPDataSet.TMedicalCenterTariffDataTable();

            p_table_preses_sequence = preses_sequence;
            preses_grid.DataSource = preses_details;

            s_service_grid.CellValueChanged -= s_service_grid_CellValueChanged;
            s_service_grid.CurrentCellDirtyStateChanged -= s_service_grid_CurrentCellDirtyStateChanged;

            if (tMedicalCenterTariffTableAdapter.FillByInsurance(s_temp_center_tariffs, sel_center, sel_insurance, sel_sector) == 0)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record_medical_center_services);
                s_service_select_all_chk.Visible = false;
                s_100_rows_lbl.Visible = false;
            }
            else if (s_temp_center_tariffs.Rows.Count > 200)
            {
                s_100_rows_lbl.Visible = true;
            }
            else
            {
                s_100_rows_lbl.Visible = false;
                pIPDataSet.TMedicalCenterTariff.Rows.Clear();
                pIPDataSet.TMedicalCenterTariff.Merge(s_temp_center_tariffs);
            }

            pgs_dialog = new PGSDialog(this);
            initSCategoryComboBox();
            PLGlobalFuncs.tariffInsSearchTypeForComboBox(s_ins_type_cbx);
            s_delete_from_pres_btn.Enabled = s_edit_in_pres_btn.Enabled = s_add_to_pres_btn.Enabled = false;


            switch (insurance_org)
            {
                case PLConstants.enum_insurances.Salamat:
                    org_delete_pres_services_func = new ORG_delete_pres_services_del(deletePresServicesFromSalamat);
                    org_add_services_to_pres_func = new ORG_add_services_to_pres_del(addServicesToPresOFSalamat);
                    org_edit_pres_services_func = new ORG_edit_pres_services_del(editPresServicesOfSalamat);
                    org_delete_all_pres_services_func = new ORG_delete_all_pres_services_del(deleteAllPresServicesFromSalamat);
                    break;
                case PLConstants.enum_insurances.TaminEjtemaei:
                    org_delete_pres_services_func = new ORG_delete_pres_services_del(deletePresServicesFromTaminEjtemaei);
                    org_add_services_to_pres_func = new ORG_add_services_to_pres_del(addServicesToPresOFTaminEjtemaei);
                    org_edit_pres_services_func = new ORG_edit_pres_services_del(editPresServicesOfTaminEjtemaei);
                    org_delete_all_pres_services_func = new ORG_delete_all_pres_services_del(deleteAllPresServicesFromTaminEjtemaei);
                    break;
                case PLConstants.enum_insurances.NirooMosalah:
                    org_delete_pres_services_func = new ORG_delete_pres_services_del(deletePresServicesFromNirooMosalah);
                    org_add_services_to_pres_func = new ORG_add_services_to_pres_del(addServicesToPresOFNirooMosalah);
                    org_edit_pres_services_func = new ORG_edit_pres_services_del(editPresServicesOfNirooMosalah);
                    org_delete_all_pres_services_func = new ORG_delete_all_pres_services_del(deleteAllPresServicesFromNirooMosalah);
                    break;
                case PLConstants.enum_insurances.KomitehEmdad:
                    org_delete_pres_services_func = new ORG_delete_pres_services_del(deletePresServicesFromKomitehEmdad);
                    org_add_services_to_pres_func = new ORG_add_services_to_pres_del(addServicesToPresOFKomitehEmdad);
                    org_edit_pres_services_func = new ORG_edit_pres_services_del(editPresServicesOfKomitehEmdad);
                    org_delete_all_pres_services_func = new ORG_delete_all_pres_services_del(deleteAllPresServicesFromKomitehEmdad);
                    break;
                case PLConstants.enum_insurances.Other:
                    org_delete_pres_services_func = new ORG_delete_pres_services_del(deletePresServicesFromOther);
                    org_add_services_to_pres_func = new ORG_add_services_to_pres_del(addServicesToPresOFOther);
                    org_edit_pres_services_func = new ORG_edit_pres_services_del(editPresServicesOfOther);
                    org_delete_all_pres_services_func = new ORG_delete_all_pres_services_del(deleteAllPresServicesFromOther);
                    break;
            }
            
        }

        ///////////////////////////////////////////////////////////////////////// EVENTS
        #region EVENTS

        private void preses_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            PLGlobalFuncs.dataGridViewRowNumbering(preses_grid);
        }

        private void s_search_btn_Click(object sender, EventArgs e)
        {
            List<string> message_text = new List<string>();
            bool error = false;
            string t_search_name = "";
            string t_search_code = "";
            int t_search_category = -1;
            string t_search_alias = "";
            string t_ins_search_type = PLConstants.enum_tariff_ins_search_type.all.ToString();
            float? t_search_percent = null;
           
            if (!Regex.IsMatch(t_search_name = s_name_txt.Text.Trim(), PLConstants.reg_m_service_name_search))
            {
                error = true;
                message_text.Add(PLConstants.error_medical_service_name);
            }
            if (!Regex.IsMatch(t_search_alias = s_alias_txt.Text.Trim(), PLConstants.reg_m_service_name_search))
            {
                error = true;
                message_text.Add(PLConstants.error_medical_service_name);
            }
            if (!Regex.IsMatch(t_search_code = s_code_txt.Text.Trim(), PLConstants.reg_search_id_10))
            {
                error = true;
                message_text.Add(PLConstants.error_id_just_number);
            }
            if (s_category_cbx.SelectedIndex > 0)
            {
                t_search_category = (int)s_category_cbx.SelectedValue;
            }
            if (!Regex.IsMatch(s_ins_percent_txt.Text.Trim(), PLConstants.reg_float_code))
            {
                error = true;
                message_text.Add(PLConstants.error_numbers_float);
            }
            else if (s_ins_percent_txt.Text.Trim().Length > 0)
            {
                t_search_percent = Single.Parse(s_ins_percent_txt.Text.Trim());
            }
            t_ins_search_type = s_ins_type_cbx.SelectedValue.ToString();
            
            s_service_grid.CellValueChanged -= s_service_grid_CellValueChanged;
            s_service_grid.CurrentCellDirtyStateChanged -= s_service_grid_CurrentCellDirtyStateChanged;
            if (error)
            {
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.error, message_text);
            }
            else if (tMedicalCenterTariffTableAdapter.FillBySearchSmall(s_temp_center_tariffs, sel_center, sel_insurance, sel_sector,
                t_search_name, t_search_alias, t_search_code, t_search_category,t_ins_search_type, t_search_percent) == 0)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record_after_search);
                s_service_select_all_chk.Visible = false;
            }
            else if (s_temp_center_tariffs.Rows.Count > 200)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_searched_tariffs_more_than_200);
            }
            else
            {
                pIPDataSet.TMedicalCenterTariff.Rows.Clear();
                pIPDataSet.TMedicalCenterTariff.Merge(s_temp_center_tariffs);
            }
                
            s_service_grid.CellValueChanged += s_service_grid_CellValueChanged;
            s_service_grid.CurrentCellDirtyStateChanged += s_service_grid_CurrentCellDirtyStateChanged;
        }

        private void s_service_select_all_checkbox_CheckedChanged(object sender, EventArgs e)//checked
        {
            if (s_service_select_all_chk.Checked)
            {
                for (int i = 0; i < s_service_grid.Rows.Count; i++)
                {
                    s_service_grid.Rows[i].Cells[s_ser_str_sel_col].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < s_service_grid.Rows.Count; i++)
                {
                    s_service_grid.Rows[i].Cells[s_ser_str_sel_col].Value = false;
                }
            }
        }
        private void s_choosed_select_all_checkbox_CheckedChanged(object sender, EventArgs e)//checked
        {
            if (s_choosed_select_all_chk.Checked)
            {
                for (int i = 0; i < s_choosed_grid.Rows.Count; i++)
                {
                    s_choosed_grid.Rows[i].Cells[s_cho_str_sel_col].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < s_choosed_grid.Rows.Count; i++)
                {
                    s_choosed_grid.Rows[i].Cells[s_cho_str_sel_col].Value = false;
                }
            }
        }

        private void s_service_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)//checked
        {
            if (s_service_grid.Rows.Count > 0)
            {
                PLGlobalFuncs.DGVAfterFilling(s_service_grid, s_service_select_all_chk);
                s_service_grid.CellValueChanged += s_service_grid_CellValueChanged;
                s_service_grid.CurrentCellDirtyStateChanged += s_service_grid_CurrentCellDirtyStateChanged;
            }
        }
        private void s_service_grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (s_service_grid.IsCurrentCellDirty)
            {
                s_service_grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void s_service_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(s_service_grid.Rows[e.RowIndex].Cells[s_ser_str_sel_col].Value))
            {
                s_service_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                s_service_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
            }
            else
            {
                s_service_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                s_service_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.ControlText;
            }
        }
        
        private void s_choosed_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)//checked
        {
            if (s_choosed_grid.Rows.Count > 0)
            {
                PLGlobalFuncs.DGVAfterFilling(s_choosed_grid, s_choosed_select_all_chk);
                s_choosed_grid.CellValueChanged += s_choosed_grid_CellValueChanged;
                s_choosed_grid.CurrentCellDirtyStateChanged += s_choosed_grid_CurrentCellDirtyStateChanged;
            }
        }
        private void s_choosed_grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (s_choosed_grid.IsCurrentCellDirty)
            {
                s_choosed_grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void s_choosed_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(s_choosed_grid.Rows[e.RowIndex].Cells[s_cho_str_sel_col].Value))
            {
                s_choosed_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                s_choosed_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
            }
            else
            {
                s_choosed_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                s_choosed_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.ControlText;
            }
        }

        private void s_add_to_list_btn_Click(object sender, EventArgs e)
        {
            bool has_repetitive = false;
            getSelectedSServices();
            if (s_list_sel_tariffs.Count > 0)
            {
                int national_id_ind = s_national_id_column.Index;
                for (int i = 0; i < s_list_sel_tariffs.Count; i++)
                {
                    if (s_table_sel_tariffs.Select(PLConstants.str_table_col_entity_id+"=" + s_list_sel_tariffs[i].Value.ToString()).Length > 0)
                    {
                        has_repetitive = true;
                        break;
                    }
                }
                if (has_repetitive)
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_repetitive_service);
                }
                else
                {
                    s_delete_from_pres_btn.Enabled = s_edit_in_pres_btn.Enabled = s_add_to_pres_btn.Enabled = true;
                    s_choosed_grid.CellValueChanged -= s_choosed_grid_CellValueChanged;
                    s_choosed_grid.CurrentCellDirtyStateChanged -= s_choosed_grid_CurrentCellDirtyStateChanged;
                    for (int i = 0; i < s_list_sel_tariffs.Count; i++)
                    {
                        s_table_sel_tariffs.Rows.Add(new object[] { s_list_sel_tariffs[i].Value });
                        s_choosed_grid.Rows.Add(new object[] {false, 
                                s_service_grid.Rows[s_list_sel_tariffs[i].Key].Cells[s_sequence_column.Name].Value,
                                s_service_grid.Rows[s_list_sel_tariffs[i].Key].Cells[s_national_id_column.Name].Value,
                                s_service_grid.Rows[s_list_sel_tariffs[i].Key].Cells[s_name_column.Name].Value,
                                s_service_grid.Rows[s_list_sel_tariffs[i].Key].Cells[s_alias_name_column.Name].Value,
                                s_service_grid.Rows[s_list_sel_tariffs[i].Key].Cells[s_pub_tot_cost_column.Name].Value,
                                s_service_grid.Rows[s_list_sel_tariffs[i].Key].Cells[s_pub_ins_sha_column.Name].Value,
                                s_service_grid.Rows[s_list_sel_tariffs[i].Key].Cells[s_pub_pat_sha_column.Name].Value,
                                s_service_grid.Rows[s_list_sel_tariffs[i].Key].Cells[s_public_discount_column.Name].Value});
                    }
                    s_choosed_grid_DataBindingComplete(s_choosed_grid, new DataGridViewBindingCompleteEventArgs(ListChangedType.ItemAdded));
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }
        }
        private void s_delete_from_list_btn_Click(object sender, EventArgs e)
        {
            getSelectedSChoosed();
            if (s_list_sel_tariffs.Count > 0)
            {
                s_choosed_grid.CellValueChanged -= s_choosed_grid_CellValueChanged;
                s_choosed_grid.CurrentCellDirtyStateChanged -= s_choosed_grid_CurrentCellDirtyStateChanged;
                for (int i = s_list_sel_tariffs.Count - 1; i >= 0; i--)
                {
                    s_choosed_grid.Rows.RemoveAt(s_list_sel_tariffs[i].Key);
                    s_table_sel_tariffs.Rows.RemoveAt(s_list_sel_tariffs[i].Key);
                }
                s_choosed_grid_DataBindingComplete(s_choosed_grid, new DataGridViewBindingCompleteEventArgs(ListChangedType.ItemDeleted));
                if (s_table_sel_tariffs.Rows.Count == 0)
                {
                    s_delete_from_pres_btn.Enabled = s_edit_in_pres_btn.Enabled = s_add_to_pres_btn.Enabled = false;
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }
        }

        private void s_delete_from_pres_btn_Click(object sender, EventArgs e)
        {
            List<string> message_text = new List<string>();
            message_text.Add(this.Tag.ToString() + " :");
            message_text.Add(PLConstants.question_delete_service_from_prescription);
            pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.delete, message_text);

            switch (pgs_dialog.user_choice)
            {
                case PLConstants.enum_dialog_options.yes:
                    org_delete_pres_services_func();
                    result_enum = PLEnumFuncs.opResultToEnum(op_result_str);
                    pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.other);
                    setReturnValue();
                    break;
            }
        }
        private void s_edit_in_pres_btn_Click(object sender, EventArgs e)
        {
            List<string> message_text = new List<string>();
            message_text.Add(this.Tag.ToString() + " :");
            message_text.Add(PLConstants.question_edit_service_of_prescription);
            pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.save_edit, message_text);

            switch (pgs_dialog.user_choice)
            {
                case PLConstants.enum_dialog_options.yes:
                    ServiceCountForm count_form = new ServiceCountForm();
                    sel_servicing_count = count_form.getCount();
                    if (sel_servicing_count > 0)
                    {
                        org_edit_pres_services_func();
                        result_enum = PLEnumFuncs.opResultToEnum(op_result_str);
                        pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.other);
                        setReturnValue();
                    }
                    break;
            }
        }
        private void s_add_to_pres_btn_Click(object sender, EventArgs e)
        {
            List<string> message_text = new List<string>();
            message_text.Add(this.Tag.ToString() + " :");
            message_text.Add(PLConstants.question_add_service_to_prescription);
            pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.save_new, message_text);

            switch (pgs_dialog.user_choice)
            {
                case PLConstants.enum_dialog_options.yes:
                    ServiceCountForm count_form = new ServiceCountForm();
                    sel_servicing_count = count_form.getCount();
                    if (sel_servicing_count > 0)
                    {
                        org_add_services_to_pres_func();
                        result_enum = PLEnumFuncs.opResultToEnum(op_result_str);
                        pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.other);
                        setReturnValue();
                    }
                    break;
            }
        }
        private void s_delete_all_from_pres_btn_Click(object sender, EventArgs e)
        {
            List<string> message_text = new List<string>();
            message_text.Add(this.Tag.ToString() + " :");
            message_text.Add(PLConstants.question_delete_all_services_from_prescription);
            pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.delete, message_text);

            switch (pgs_dialog.user_choice)
            {
                case PLConstants.enum_dialog_options.yes:
                    org_delete_all_pres_services_func();
                    result_enum = PLEnumFuncs.opResultToEnum(op_result_str);
                    pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.other);
                    setReturnValue();
                    break;
            }
        }

        #endregion EVENTS

        ///////////////////////////////////////////////////////////////////////// METHODS
        #region METHODS

        public bool formStart()
        {
            this.ShowDialog();
            return were_actions_successeded;
        }

        private void initSCategoryComboBox()
        {
            s_ser_category_data = s_ser_category_adapter.GetAllCategories();
            PIPDataSet.TMedicalServiceCategoryRow c_first_row = s_ser_category_data.NewTMedicalServiceCategoryRow();
            c_first_row.id = -1;
            c_first_row.name = "--نوع خدمت پزشکی--";
            s_ser_category_data.Rows.InsertAt(c_first_row, 0);
            s_category_cbx.DataSource = s_ser_category_data;
            s_category_cbx.DisplayMember = s_ser_category_data.nameColumn.ColumnName;
            s_category_cbx.ValueMember = s_ser_category_data.idColumn.ColumnName;
            s_category_cbx.SelectedIndex = 0;
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(s_category_cbx);
        }

        private void getSelectedSServices()
        {
            s_list_sel_tariffs.Clear();
            int id_col = s_sequence_column.Index;
            for (int i = 0; i < s_service_grid.Rows.Count; i++)
            {
                if (Convert.ToBoolean(s_service_grid.Rows[i].Cells[s_ser_str_sel_col].Value))
                {
                    s_list_sel_tariffs.Add(new KeyValuePair<int, long>(i, (long)s_service_grid.Rows[i].Cells[id_col].Value));
                }
            }
        }
        private void getSelectedSChoosed()
        {
            s_list_sel_tariffs.Clear();
            int id_col = s_cho_sequence_column.Index;
            for (int i = 0; i < s_choosed_grid.Rows.Count; i++)
            {
                if (Convert.ToBoolean(s_choosed_grid.Rows[i].Cells[s_cho_str_sel_col].Value))
                {
                    s_list_sel_tariffs.Add(new KeyValuePair<int, long>(i, (long)s_choosed_grid.Rows[i].Cells[id_col].Value));
                }
            }
        }

        //private void afterSServiceGridFilled()
        //{
        //    PLGlobalFuncs.dataGridViewAfterFilling(s_service_grid, s_service_select_all_chk);
        //    PLGlobalFuncs.createAllCheckBoxForDataGridView(s_service_grid, s_service_select_all_chk);

        //    for (int i = 0; i < s_service_grid.Rows.Count; i++)
        //    {
        //        s_service_grid.Rows[i].Cells[s_ser_str_sel_col].Value = false;
        //    }
        //}
        //private void afterSChoosedGridFilled()
        //{
        //    PLGlobalFuncs.dataGridViewAfterFilling(s_choosed_grid, s_choosed_select_all_chk);
        //    PLGlobalFuncs.createAllCheckBoxForDataGridView(s_choosed_grid, s_choosed_select_all_chk);

        //    for (int i = 0; i < s_choosed_grid.Rows.Count; i++)
        //    {
        //        s_choosed_grid.Rows[i].Cells[s_cho_str_sel_col].Value = false;
        //    }
        //}

        private void deletePresServicesFromOther()
        {
            tPrescriptionServiceTableAdapter.DeleteOther_ServicesOfPrescriptions(sel_insurance, (short?)PLConstants.enum_activity_types.DeletePresService, PLConstants.UserCode, p_table_preses_sequence, s_table_sel_tariffs, ref op_result_str);
        }
        private void deletePresServicesFromKomitehEmdad()
        {
            tPrescriptionServiceTableAdapter.DeleteKomitehEmdad_ServicesOfPrescriptions(sel_insurance, (short?)PLConstants.enum_activity_types.DeletePresService, PLConstants.UserCode, p_table_preses_sequence, s_table_sel_tariffs, ref op_result_str);
        }
        private void deletePresServicesFromNirooMosalah()
        {
            tPrescriptionServiceTableAdapter.DeleteNirooMosalah_ServicesOfPrescriptions(sel_insurance, (short?)PLConstants.enum_activity_types.DeletePresService, PLConstants.UserCode, p_table_preses_sequence, s_table_sel_tariffs, ref op_result_str);
        }
        private void deletePresServicesFromTaminEjtemaei()
        {
            tPrescriptionServiceTableAdapter.DeleteTaminEjtemaei_ServicesOfPrescriptions(sel_insurance, (short?)PLConstants.enum_activity_types.DeletePresService, PLConstants.UserCode, p_table_preses_sequence, s_table_sel_tariffs, ref op_result_str);
        }
        private void deletePresServicesFromSalamat()
        {
            tPrescriptionServiceTableAdapter.DeleteSalamat_ServicesOfPrescriptions(sel_insurance, (short?)PLConstants.enum_activity_types.DeletePresService, PLConstants.UserCode, p_table_preses_sequence, s_table_sel_tariffs, ref op_result_str);
        }

        private void editPresServicesOfOther()
        {
            tPrescriptionServiceTableAdapter.EditOther_ServicesOfPrescriptions(sel_insurance, (short?)PLConstants.enum_activity_types.EditPresService, PLConstants.UserCode, p_table_preses_sequence, s_table_sel_tariffs, sel_servicing_count, ref op_result_str);
        }
        private void editPresServicesOfKomitehEmdad()
        {
            tPrescriptionServiceTableAdapter.EditKomitehEmdad_ServicesOfPrescriptions(sel_insurance, (short?)PLConstants.enum_activity_types.EditPresService, PLConstants.UserCode, p_table_preses_sequence, s_table_sel_tariffs, sel_servicing_count, ref op_result_str);
        }
        private void editPresServicesOfNirooMosalah()
        {
            tPrescriptionServiceTableAdapter.EditNirooMosalah_ServicesOfPrescriptions(sel_insurance, (short?)PLConstants.enum_activity_types.EditPresService, PLConstants.UserCode, p_table_preses_sequence, s_table_sel_tariffs, sel_servicing_count, ref op_result_str);
        }
        private void editPresServicesOfTaminEjtemaei()
        {
            tPrescriptionServiceTableAdapter.EditTaminEjtemaei_ServicesOfPrescriptions(sel_insurance, (short?)PLConstants.enum_activity_types.EditPresService, PLConstants.UserCode, p_table_preses_sequence, s_table_sel_tariffs, sel_servicing_count, ref op_result_str);
        }
        private void editPresServicesOfSalamat()
        {
            tPrescriptionServiceTableAdapter.EditSalamat_ServicesOfPrescriptions(sel_insurance, (short?)PLConstants.enum_activity_types.EditPresService, PLConstants.UserCode, p_table_preses_sequence, s_table_sel_tariffs, sel_servicing_count, ref op_result_str);
        }

        private void addServicesToPresOFTaminEjtemaei()
        {
            tPrescriptionServiceTableAdapter.AddServicesToPresesOfTaminEjtemaei(sel_insurance, (short?)PLConstants.enum_activity_types.AddPresService, PLConstants.UserCode, p_table_preses_sequence, s_table_sel_tariffs, sel_servicing_count, ref op_result_str);
        }
        private void addServicesToPresOFNirooMosalah()
        {
            tPrescriptionServiceTableAdapter.AddServicesToPresesOfNirooMosalah(sel_insurance, (short?)PLConstants.enum_activity_types.AddPresService, PLConstants.UserCode, p_table_preses_sequence, s_table_sel_tariffs, sel_servicing_count, ref op_result_str);
        }
        private void addServicesToPresOFKomitehEmdad()
        {
            tPrescriptionServiceTableAdapter.AddServicesToPresesOfKomitehEmdad(sel_insurance, (short?)PLConstants.enum_activity_types.AddPresService, PLConstants.UserCode, p_table_preses_sequence, s_table_sel_tariffs, sel_servicing_count, ref op_result_str);
        }
        private void addServicesToPresOFOther()
        {
            tPrescriptionServiceTableAdapter.AddServicesToPresesOfOther(sel_insurance, (short?)PLConstants.enum_activity_types.AddPresService, PLConstants.UserCode, p_table_preses_sequence, s_table_sel_tariffs, sel_servicing_count, ref op_result_str);
        }
        private void addServicesToPresOFSalamat()
        {
            tPrescriptionServiceTableAdapter.AddServicesToPresesOfSalamat(sel_insurance, (short?)PLConstants.enum_activity_types.AddPresService, PLConstants.UserCode, p_table_preses_sequence, s_table_sel_tariffs, sel_servicing_count, ref op_result_str);
        }

        private void deleteAllPresServicesFromOther()
        {
            tPrescriptionServiceTableAdapter.DeleteOther_AllPresesServices(sel_insurance, (short?)PLConstants.enum_activity_types.DeletePresService, PLConstants.UserCode, p_table_preses_sequence, ref op_result_str);
        }
        private void deleteAllPresServicesFromKomitehEmdad()
        {
            tPrescriptionServiceTableAdapter.DeleteKomitehEmdad_AllPresesServices(sel_insurance, (short?)PLConstants.enum_activity_types.DeletePresService, PLConstants.UserCode, p_table_preses_sequence, ref op_result_str);
        }
        private void deleteAllPresServicesFromNirooMosalah()
        {
            tPrescriptionServiceTableAdapter.DeleteNirooMosalah_AllPresesServices(sel_insurance, (short?)PLConstants.enum_activity_types.DeletePresService, PLConstants.UserCode, p_table_preses_sequence, ref op_result_str);
        }
        private void deleteAllPresServicesFromTaminEjtemaei()
        {
            tPrescriptionServiceTableAdapter.DeleteTaminEjtemaei_AllPresesServices(sel_insurance, (short?)PLConstants.enum_activity_types.DeletePresService, PLConstants.UserCode, p_table_preses_sequence, ref op_result_str);
        }
        private void deleteAllPresServicesFromSalamat()
        {
            tPrescriptionServiceTableAdapter.DeleteSalamat_AllPresesServices(sel_insurance, (short?)PLConstants.enum_activity_types.DeletePresService, PLConstants.UserCode, p_table_preses_sequence, ref op_result_str);
        }

        private void setReturnValue()
        {
            switch (result_enum)
            {
                case PLConstants.enum_operation_results.success:
                    were_actions_successeded = true;
                    break;
            }
        }

        #endregion METHODS

    }
}