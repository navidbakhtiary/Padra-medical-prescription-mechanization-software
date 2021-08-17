using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;

namespace PadraInsurancePrescription
{
    public partial class MedicalServiceControl : UserControl
    {

        string s_str_sel_col;

        int s_index;
        PIPDataSet.TMedicalServiceRow s_selected_data;
        List<KeyValuePair<int,long>> s_selected_id_s;//1-row number 2-id
        CheckBox s_select_all_checkbox;

        string s_search_name;
        string s_search_code;
        int s_search_category;

        PGSDialog pgs_dialog;
        PLConstants.enum_operation_results result_enum;

        PIPDataSetTableAdapters.TMedicalServiceCategoryTableAdapter c_adapter;
        PIPDataSet.TMedicalServiceCategoryDataTable categories_data;

        public MedicalServiceControl()
        {
            //column 0 is checkboxes and not in arrays
            InitializeComponent();
            PLGlobalFuncs.changeDGVSettings(service_grid);
            s_str_sel_col = "s_select_column";

            s_selected_id_s = new List<KeyValuePair<int, long>>();
            s_select_all_checkbox = new CheckBox();
            s_select_all_checkbox.CheckedChanged += s_select_all_checkbox_CheckedChanged;

            pgs_dialog = new PGSDialog(this);

            c_adapter = new PIPDataSetTableAdapters.TMedicalServiceCategoryTableAdapter();
            initCategoryComboBox();
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(category_combobox);
        }

        // ///////////////////////////////////////////////////// Medical Service

        // ///////////////////////// Medical Service EVENTS
        # region medical service Events

        private void search_button_Click(object sender, EventArgs e)//checked
        {
            List<string> message_text = new List<string>();
            bool error = false;
            bool all_empty = true;
            s_search_name = "";
            s_search_code = "";
            s_search_category = -1;
            
            if (!Regex.IsMatch(s_search_name = name_text.Text.Trim(), PLConstants.reg_m_service_name_search))
            {
                error = true;
                message_text.Add(PLConstants.error_medical_service_name);
            }
            else if(s_search_name.Length>0)
            {
                all_empty = false;
            }
            if (!Regex.IsMatch(s_search_code = code_text.Text.Trim(), PLConstants.reg_search_id_10))
            {
                error = true;
                message_text.Add(PLConstants.error_id_just_number);
            }
            else if(s_search_code.Length>0)
            {
                all_empty = false;
            }
            if (category_combobox.SelectedIndex > 0)
            {
                all_empty = false;
                s_search_category = (int)category_combobox.SelectedValue;
            }
            service_grid.CellValueChanged -= service_grid_CellValueChanged;
            service_grid.CurrentCellDirtyStateChanged -= service_grid_CurrentCellDirtyStateChanged;
            if (error)
            {
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.error, message_text);
            }
            else if (all_empty)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_search_fields_not_empty);
            }
            else if (tMedicalServiceTableAdapter.FillBySearch(pIPDataSet.TMedicalService, s_search_name, s_search_category,s_search_code) == 0)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record_after_search);
                s_select_all_checkbox.Visible = false;
            }
            //service_grid.CellValueChanged += service_grid_CellValueChanged;
            //service_grid.CurrentCellDirtyStateChanged += service_grid_CurrentCellDirtyStateChanged;
        }

        private void d_refresh_grid_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {//checked
            //if (tDoctorTableAdapter.FillBySearch(pIPDataSet.TDoctor, s_search_name, s_search_code, s_search_category, d_search_id) == 0)
            //{
            //    pgs_dialog = new PGSDialog(PLConstants.dialog_types.notice, PLConstants.notice_no_record_after_search);
            //    pgs_dialog.ShowDialog();
            //    s_select_all_checkbox.Visible = false;
            //}
        }

        private void new_button_Click(object sender, EventArgs e)//checked
        {
            MedicalServiceForm s_form = new MedicalServiceForm(null, PLConstants.enum_data_operation.new_data, null);
            s_form.ShowDialog();
        }

        private void edit_button_Click(object sender, EventArgs e)//checked
        {
            getSelectedServices();
            if (s_selected_id_s.Count == 1)
            {
                s_index = s_selected_id_s[0].Key;
                s_selected_data = ((PIPDataSet.TMedicalServiceRow)pIPDataSet.TMedicalService.Rows[s_index]);
                MedicalServiceForm s_form = new MedicalServiceForm(s_selected_data, PLConstants.enum_data_operation.edit_data, null);
                s_form.ShowDialog();
            }
            else if (s_selected_id_s.Count > 1)
            {
                //d_selected_data = ((PIPDataSet.TDoctorRow)pIPDataSet.TDoctor.Rows[d_index]);
                MedicalServiceForm s_form = new MedicalServiceForm(null, PLConstants.enum_data_operation.batch_edit, selectedServicesToDataTable());
                s_form.ShowDialog();
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }
        }

        private void delete_button_Click(object sender, EventArgs e)//checked
        {
            getSelectedServices();
            if (s_selected_id_s.Count > 0)
            {
                List<string> message_text = new List<string>();
                message_text.Add(this.Tag.ToString() + " :");

                message_text.Add(PLConstants.question_delete);
                message_text.Add("خدمات پزشکی انتخاب شده :");
                message_text.AddRange(getServicesDataForMessage());
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.delete, message_text);

                switch (pgs_dialog.user_choice)
                {
                    case PLConstants.enum_dialog_options.yes:
                        string delete_result = "";
                        tMedicalServiceTableAdapter.DeleteMedicalServices(selectedServicesToDataTable(), ref delete_result);
                        result_enum = PLEnumFuncs.opResultToEnum(delete_result);
                        pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.other);
                        switch (result_enum)
                        {
                            case PLConstants.enum_operation_results.success:
                                service_grid.CellValueChanged -= service_grid_CellValueChanged;
                                service_grid.CurrentCellDirtyStateChanged -= service_grid_CurrentCellDirtyStateChanged;
                                pIPDataSet.TMedicalService.Clear();
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
            getSelectedServices();
            if (s_selected_id_s.Count == 1)
            {
                s_index = s_selected_id_s[0].Key;
                s_selected_data = ((PIPDataSet.TMedicalServiceRow)pIPDataSet.TMedicalService.Rows[s_index]);
                MedicalServiceForm s_form = new MedicalServiceForm(s_selected_data, PLConstants.enum_data_operation.copy_data, null);
                s_form.ShowDialog();
            }
            else if (s_selected_id_s.Count > 1)
            {
                MedicalServiceForm s_form = new MedicalServiceForm(null, PLConstants.enum_data_operation.batch_copy, selectedServicesToDataTable());
                s_form.ShowDialog();
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }
        }

        private void export_button_Click(object sender, EventArgs e)
        {

        }

        private void import_button_Click(object sender, EventArgs e)
        {

        }

        private void s_select_all_checkbox_CheckedChanged(object sender, EventArgs e)//checked
        {
            if (s_select_all_checkbox.Checked)
            {
                for (int i = 0; i < service_grid.Rows.Count; i++)
                {
                    service_grid.Rows[i].Cells[s_str_sel_col].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < service_grid.Rows.Count; i++)
                {
                    service_grid.Rows[i].Cells[s_str_sel_col].Value = false;
                }
            }
        }

        private void service_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (service_grid.Rows.Count > 0)
            {
                PLGlobalFuncs.DGVAfterFilling(service_grid, s_select_all_checkbox);
                service_grid.CellValueChanged += service_grid_CellValueChanged;
                service_grid.CurrentCellDirtyStateChanged += service_grid_CurrentCellDirtyStateChanged;
            }
        }

        private void service_grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (service_grid.IsCurrentCellDirty)
            {
                service_grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void service_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(service_grid.Rows[e.RowIndex].Cells[s_str_sel_col].Value))
            {
                service_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                service_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
            }
            else
            {
                service_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                service_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.ControlText;
            }
        }

        # endregion

        // ///////////////////////// medical service METHODS
        #region medical service Methods

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

        private void getSelectedServices()
        {
            s_selected_id_s.Clear();
            int id_col = s_sequence_column.Index;
            for (int i=0;i<service_grid.Rows.Count;i++)
            {
                if (Convert.ToBoolean(service_grid.Rows[i].Cells[s_str_sel_col].Value))
                {
                    s_selected_id_s.Add(new KeyValuePair<int,long>(i,(long)service_grid.Rows[i].Cells[id_col].Value));
                }
            }
        }

        private List<string> getServicesDataForMessage()
        {
            int national_id = s_national_id_column.Index;
            int name_col = s_name_column.Index;
            int insurance_col = s_insurance_name_column.Index;
            int sector_col = s_sector_name_column.Index;
            List<string> message_text = new List<string>();
            for (int i = 0; i < s_selected_id_s.Count; i++)
            {
                message_text.Add(service_grid.Rows[s_selected_id_s[i].Key].Cells[national_id].Value.ToString()+" - "+
                                 service_grid.Rows[s_selected_id_s[i].Key].Cells[name_col].Value.ToString() + " - " +
                                 service_grid.Rows[s_selected_id_s[i].Key].Cells[insurance_col].Value.ToString() + " - " +
                                 service_grid.Rows[s_selected_id_s[i].Key].Cells[sector_col].Value.ToString());
            }
            return message_text;
        }

        private DataTable selectedServicesToDataTable()
        {
            DataTable s_s_t = new DataTable();
            s_s_t.Columns.Add(PLConstants.str_table_col_entity_id, typeof(int));
            foreach (KeyValuePair<int, long> s_id in s_selected_id_s)
            {
                s_s_t.Rows.Add(s_id.Value);
            }
            return s_s_t;
        }

        //private void afterServiceGridFilled()
        //{
        //    PLGlobalFuncs.dataGridViewAfterFilling(service_grid, s_select_all_checkbox);
        //    PLGlobalFuncs.createAllCheckBoxForDataGridView(service_grid, s_select_all_checkbox);

        //    for (int i = 0; i < service_grid.Rows.Count; i++)
        //    {
        //        service_grid.Rows[i].Cells[s_str_sel_col].Value = false;
        //    }
        //}

        # endregion

        

    }
}
