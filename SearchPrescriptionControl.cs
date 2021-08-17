using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;

namespace PadraInsurancePrescription
{
    public partial class SearchPrescriptionControl : UserControl
    {
        bool? is_user_admin;
        PIPDataSet.TInsuranceRow[] search_ins_rows;
        PLConstants.enum_insurances search_ins_enum;
        int search_ins_id,temp_ins;
        string search_ins_tag;
        int? search_sec;
        string search_name, search_family, search_id, search_serial;
        int? search_doctor;
        string search_year, search_month, search_day;
        bool search_all_empty;
        int search_items_count;
        int minimum_sea_items_count = 2;

        PGSDialog pgs_dialog;

        int index_two;
        long selected_id;
        int index_one;
        bool is_switched;
        int selected_show_ind;
        PIPDataSet.TSearchPrescriptionRow p_data_row;
        List<KeyValuePair<int, long>> selected_id_s;//1-row number 2-id
        CheckBox select_all_checkbox;
        string p_str_sel_col;

        List<int> list_start_index;
        int col_ordinal_1;

        PIPDataSetTableAdapters.TInsuranceTableAdapter ins_adapter;
        PIPDataSetTableAdapters.TInsuranceSectorTableAdapter sector_adapter;
        PIPDataSetTableAdapters.SDoctorTableAdapter doctor_adapter;
        PIPDataSetTableAdapters.TSearchPrescriptionTableAdapter pres_search_adapter;
        PIPDataSet.TInsuranceDataTable ins_data;
        PIPDataSet.TInsuranceSectorDataTable sector_data;
        PIPDataSet.SDoctorDataTable doctor_data;
        PIPDataSet.TPrescriptionServiceDataTable table_pres_services;

        int temp_int;

        public SearchPrescriptionControl()
        {
            //column 0 is checkboxes and not in arrays
            InitializeComponent();
            PLGlobalFuncs.changeDGVSettings(pres_grid,service_grid);
            p_str_sel_col = p_select_column.Name;
            is_switched = false;

            search_ins_rows=null;
            search_ins_id=temp_ins=-1;
            search_ins_tag="";
            search_sec=search_doctor=null;
            search_name = search_family = search_id = search_serial = search_year = search_month = search_day = "";
            
            selected_id_s = new List<KeyValuePair<int, long>>();
            select_all_checkbox = new CheckBox();
            selected_show_ind = -1;
            index_one = index_two = -1;
            
            list_start_index = new List<int>();
            col_ordinal_1 = pIPDataSet.TPrescriptionInfo.number_of_servicesColumn.Ordinal;
            table_pres_services = new PIPDataSet.TPrescriptionServiceDataTable();

            pgs_dialog = new PGSDialog(this);

            ins_adapter = new PIPDataSetTableAdapters.TInsuranceTableAdapter();
            sector_adapter = new PIPDataSetTableAdapters.TInsuranceSectorTableAdapter();
            doctor_adapter = new PIPDataSetTableAdapters.SDoctorTableAdapter();
            pres_search_adapter = new PIPDataSetTableAdapters.TSearchPrescriptionTableAdapter();
            ins_data = new PIPDataSet.TInsuranceDataTable();
            sector_data = new PIPDataSet.TInsuranceSectorDataTable(); ;
            doctor_data = new PIPDataSet.SDoctorDataTable();
            initInsuranceComboBox();
            initDoctorComboBox();
            PLGlobalFuncs.yearsForComboBox(visit_year_combobox);
            PLGlobalFuncs.monthesForComboBox(visit_month_combobox);
            PLGlobalFuncs.allDaysForComboBox(visit_day_combobox);
        }

        // ///////////////////////////////////////////////////// Prescription
        
        // ///////////////////////// Prescription EVENTS
        # region Prescription Events

        private void search_button_Click(object sender, EventArgs e)//checked
        {
            List<string> message_text = new List<string>();
            bool error = false;
            search_all_empty = true;
            search_name = "";
            search_family = "";
            search_id = "";

            if (temp_ins < 0)
            {
                error = true;
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_combo_insurance_not_selected);
            }
            else
            {
                search_items_count=0;
                search_ins_id = temp_ins;
                search_ins_rows = (PIPDataSet.TInsuranceRow[])ins_data.Select("id=" + temp_ins.ToString());
                if (search_ins_rows.Length > 0)
                {
                    search_ins_tag = search_ins_rows[0].tag;
                }
                if (sector_combobox.SelectedIndex > 0)
                {
                    search_sec = (int)sector_combobox.SelectedValue;
                    search_items_count++;
                }
                else { search_sec = null; }

                if ((!Regex.IsMatch(search_name = name_text.Text.Trim(), PLConstants.reg_small_name)) || (!Regex.IsMatch(search_family = family_text.Text.Trim(), PLConstants.reg_small_name)))
                {
                    error = true;
                    message_text.Add(PLConstants.error_names);
                }
                else 
                {
                    if (search_name.Length >= PLConstants.len_search_min_names_2){search_items_count++;}
                    if (search_family.Length >= PLConstants.len_search_min_names_2) { search_items_count++;}
                }

                if (!Regex.IsMatch(id_text.Text.Trim(), PLConstants.reg_search_insured_id))
                {
                    error = true;
                    message_text.Add(PLConstants.error_search_insured_id);
                }
                else if ((search_id=id_text.Text.Trim()).Length >= PLConstants.len_search_min_insured_code_3)
                {
                    search_items_count++;
                }

                if (!Regex.IsMatch(serial_text.Text.Trim(), PLConstants.reg_search_insured_id))
                {
                    error = true;
                    message_text.Add(PLConstants.error_search_insured_id);
                }
                else if ((search_serial = serial_text.Text.Trim()).Length >= PLConstants.len_search_min_insured_code_3)
                {
                    search_items_count++;
                }

                if (doctor_combobox.SelectedIndex > 0)
                {
                    search_doctor = (int)doctor_combobox.SelectedValue;
                    search_items_count++;
                }
                else { search_doctor = null; }

                if (visit_year_combobox.SelectedIndex > 0)
                {
                    search_year = visit_year_combobox.SelectedValue.ToString();
                    search_items_count++;
                }
                else { search_year = null; }

                if (visit_month_combobox.SelectedIndex > 0)
                {
                    search_month = visit_month_combobox.SelectedValue.ToString();
                    search_items_count++;
                }
                else { search_month = null; }

                if (visit_day_combobox.SelectedIndex > 0)
                {
                    search_day = visit_day_combobox.SelectedValue.ToString();
                    search_items_count++;
                }
                else { search_day = null; }

                if (error)
                {
                    pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.error, message_text);
                }
                else if (search_items_count<minimum_sea_items_count)
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_search_pres_min_search_items_count);
                }
                else
                {
                    search_ins_enum = PLEnumFuncs.convertInsuranceTagToEnum(search_ins_tag);
                    loadPrescriptionsData();
                }
            }
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
                search_sec = -1;
                //sector_combobox.SelectedIndex = 0;
                sector_combobox.Enabled = false;
            }
        }

        private void edit_button_Click(object sender, EventArgs e)//checked
        {
            getSelectedPreses();
            if (selected_id>-1)
            {
                if (is_user_admin==true || p_data_row.submit_user == PLConstants.UserCode)
                {
                    EditPresInfoForm p_form = new EditPresInfoForm(PLConstants.enum_data_operation.edit_data, p_data_row, selectedPresesToDataTable());
                    if (p_form.formStart())
                    {
                        pIPDataSet.TSearchPrescription.Rows.Clear();
                    }
                }
                else
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_user_does_not_allow);
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }
        }

        private void pres_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)//checked
        {
            if (pres_grid.Rows.Count > 0)
            {
                afterPresGridFilled();
                pres_grid.CellValueChanged += pres_grid_CellValueChanged;
                pres_grid.CurrentCellDirtyStateChanged += pres_grid_CurrentCellDirtyStateChanged;
                pres_grid.SelectionChanged += pres_grid_SelectionChanged;
                pres_grid.ClearSelection();
                pres_grid.Rows[0].Selected = true;
                index_one = index_two = -1;
            }
        }

        private void pres_grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (pres_grid.IsCurrentCellDirty)
            {
                pres_grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        //private void pres_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex == 0)
        //    {
        //        if (Convert.ToBoolean(pres_grid.Rows[e.RowIndex].Cells[p_str_sel_col].Value))
        //        {
        //            if (!is_switched)
        //            {
        //                int id_col = pIPDataSet.TSearchPrescription.save_sequenceColumn.Ordinal;
        //                index_one = index_two;
        //                index_two = e.RowIndex;
        //                selected_id = (long)pIPDataSet.TSearchPrescription.Rows[index_two][id_col];
        //                p_data_row = (PIPDataSet.TSearchPrescriptionRow)pIPDataSet.TSearchPrescription.Rows[index_two];
        //                pres_grid.Rows[index_two].DefaultCellStyle.BackColor = SystemColors.Highlight;
        //                pres_grid.Rows[index_two].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
        //                is_switched = true;
        //            }
        //            else
        //            {
        //                is_switched = false;
        //                changeStatusOfPreviousPresRow(index_one);
        //            }
        //        }
        //        else if (index_two == e.RowIndex)
        //        {
        //            pres_grid.Rows[index_two].DefaultCellStyle.BackColor = SystemColors.Window;
        //            pres_grid.Rows[index_two].DefaultCellStyle.ForeColor = SystemColors.ControlText;
        //            selected_id = -1;
        //            p_data_row = null;
        //            index_two = -1;
        //        }
        //    }
        //}

        private void pres_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (Convert.ToBoolean(pres_grid.Rows[e.RowIndex].Cells[p_str_sel_col].Value))
                {
                    if (e.RowIndex != index_two)
                    {
                        int id_col = pIPDataSet.TSearchPrescription.save_sequenceColumn.Ordinal;
                        if (index_two == -1)
                        {
                            index_two = e.RowIndex;
                        }
                        else
                        {
                            index_one = index_two;
                            index_two = e.RowIndex;
                            pres_grid.Rows[index_one].DefaultCellStyle.BackColor = SystemColors.Window;
                            pres_grid.Rows[index_one].DefaultCellStyle.ForeColor = SystemColors.ControlText;
                            pres_grid.Rows[index_one].Cells[p_str_sel_col].Value = false;
                            index_one = -1;
                        }
                        selected_id = (long)pIPDataSet.TSearchPrescription.Rows[index_two][id_col];
                        p_data_row = (PIPDataSet.TSearchPrescriptionRow)pIPDataSet.TSearchPrescription.Rows[index_two];
                        pres_grid.Rows[index_two].DefaultCellStyle.BackColor = SystemColors.Highlight;
                        pres_grid.Rows[index_two].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
                    }
                }
                else if(index_two==e.RowIndex)
                {
                    pres_grid.Rows[index_two].DefaultCellStyle.BackColor = SystemColors.Window;
                    pres_grid.Rows[index_two].DefaultCellStyle.ForeColor = SystemColors.ControlText;
                    index_two = -1;
                }
            }
        }

        private void pres_grid_SelectionChanged(object sender, EventArgs e)
        {
            temp_int = pres_grid.CurrentCell.RowIndex;
            if ((temp_int > -1) && (temp_int != selected_show_ind))
            {
                selected_show_ind = temp_int;
                pIPDataSet.TPrescriptionService.Rows.Clear();
                for (temp_int = list_start_index[selected_show_ind]; temp_int < list_start_index[selected_show_ind + 1]; temp_int++)
                {
                    pIPDataSet.TPrescriptionService.Rows.Add(table_pres_services[temp_int].ItemArray);
                }
                service_grid.DataSource = pIPDataSet.TPrescriptionService;
            }
        }

        private void service_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (service_grid.Rows.Count > 0)
            {
                PLGlobalFuncs.dataGridViewRowNumbering(service_grid);
            }
        }

        # endregion

        // ///////////////////////// Prescription METHODS
        #region Prescription Methods

        private void initInsuranceComboBox()
        {
            ins_data = ins_adapter.GetAllInsurances();
            PIPDataSet.TInsuranceRow i_first_row = ins_data.NewTInsuranceRow();
            i_first_row.id = -1;
            i_first_row.name = "---شرکت بیمه---";
            ins_data.Rows.InsertAt(i_first_row, 0);
            insurance_combobox.DataSource = ins_data;
            insurance_combobox.DisplayMember = ins_data.nameColumn.ColumnName;
            insurance_combobox.ValueMember = ins_data.idColumn.ColumnName;
            insurance_combobox.SelectedIndex = 0;
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(insurance_combobox);
        }

        private void initInsSectorComboBox(int selected_insurance)//checked
        {
            sector_data = sector_adapter.GetAllSectors(selected_insurance);
            PIPDataSet.TInsuranceSectorRow s_first_row = sector_data.NewTInsuranceSectorRow();
            s_first_row.id = -1;
            s_first_row.name = "--صندوق بیمه--";
            sector_data.Rows.InsertAt(s_first_row, 0);
            sector_combobox.DataSource = sector_data;
            sector_combobox.DisplayMember = sector_data.nameColumn.ColumnName;
            sector_combobox.ValueMember = sector_data.idColumn.ColumnName;
            sector_combobox.SelectedIndex = 0;
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(sector_combobox);
        }

        private void initDoctorComboBox()
        {
            if (doctor_adapter.FillAll(doctor_data) > 0)
            {
                PIPDataSet.SDoctorRow d_first_row = doctor_data.NewSDoctorRow();
                d_first_row.medical_id = -1;
                d_first_row.title = "--پزشک ها--";
                doctor_data.Rows.InsertAt(d_first_row, 0);
                doctor_combobox.DataSource = doctor_data;
                doctor_combobox.DisplayMember = doctor_data.titleColumn.ColumnName;
                doctor_combobox.ValueMember = doctor_data.medical_idColumn.ColumnName;
                doctor_combobox.SelectedIndex = 0;
                PLGlobalFuncs.adjustDropDownWidthOfComboBox(doctor_combobox);
                doctor_combobox.Enabled = true;
            }
        }

        private void getSelectedPreses()
        {
            selected_id_s.Clear();
            if (p_data_row != null)
            {
                selected_id_s.Add(new KeyValuePair<int, long>(index_two, p_data_row.save_sequence));
            }
            //int id_col = p_save_sequence_column.Index;
            //for (int i=0;i<pres_grid.Rows.Count;i++)
            //{
            //    if (Convert.ToBoolean(pres_grid.Rows[i].Cells[p_str_sel_col].Value))
            //    {
            //        selected_id_s.Add(new KeyValuePair<int,long>(i,(long)pres_grid.Rows[i].Cells[id_col].Value));
            //    }
            //}
        }

        private DataTable selectedPresesToDataTable()
        {
            DataTable s_p_t = new DataTable();
            s_p_t.Columns.Add(PLConstants.str_table_col_entity_id, typeof(long));
            foreach (KeyValuePair<int, long> p_id in selected_id_s)
            {
                s_p_t.Rows.Add(p_id.Value);
            }
            return s_p_t;
        }

        private void afterPresGridFilled()
        {
            PLGlobalFuncs.dataGridViewAfterFilling(pres_grid, select_all_checkbox);
            for (int i = 0; i < pres_grid.Rows.Count; i++)
            {
                pres_grid.Rows[i].Cells[p_str_sel_col].Value = false;
            }
        }

        private void changeStatusOfPreviousPresRow(int index_one)
        {
            if (index_one > -1)
            {
                pres_grid.Rows[index_one].DefaultCellStyle.BackColor = SystemColors.Window;
                pres_grid.Rows[index_one].DefaultCellStyle.ForeColor = SystemColors.ControlText;
                pres_grid.Rows[index_one].Cells[p_str_sel_col].Value = false;
                index_one = -1;
            }
        }

        private void loadPrescriptionsData()
        {
            pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_load_wait);
            pres_grid.CellValueChanged -= pres_grid_CellValueChanged;
            pres_grid.CurrentCellDirtyStateChanged -= pres_grid_CurrentCellDirtyStateChanged;
            pres_grid.SelectionChanged -= pres_grid_SelectionChanged;
            list_start_index.Clear();
            switch (search_ins_enum)
            {
                case PLConstants.enum_insurances.Salamat:
                    pres_search_adapter.FillSalamatBySearch(pIPDataSet.TSearchPrescription, (int?)search_ins_id, (int?)search_sec, search_name, search_family, search_id, search_serial, search_doctor, search_year, search_month, search_day, PLConstants.UserCode, ref is_user_admin);
                    break;
                case PLConstants.enum_insurances.TaminEjtemaei:
                    pres_search_adapter.FillTaminEjtemaeiBySearch(pIPDataSet.TSearchPrescription, (int?)search_ins_id, (int?)search_sec, search_name, search_family, search_id, search_serial, search_doctor, search_year, search_month, search_day, PLConstants.UserCode, ref is_user_admin);
                    break;
                case PLConstants.enum_insurances.NirooMosalah:
                    pres_search_adapter.FillNirooMosalahBySearch(pIPDataSet.TSearchPrescription, (int?)search_ins_id, (int?)search_sec, search_name, search_family, search_id, search_serial, search_doctor, search_year, search_month, search_day, PLConstants.UserCode, ref is_user_admin);
                    break;
                case PLConstants.enum_insurances.KomitehEmdad:
                    pres_search_adapter.FillKomitehEmdadBySearch(pIPDataSet.TSearchPrescription, (int?)search_ins_id, (int?)search_sec, search_name, search_family, search_id, search_serial, search_doctor, search_year, search_month, search_day, PLConstants.UserCode, ref is_user_admin);
                    break;
                case PLConstants.enum_insurances.Other:
                    pres_search_adapter.FillOtherBySearch(pIPDataSet.TSearchPrescription, (int?)search_ins_id, (int?)search_sec, search_name, search_family, search_id, search_serial, search_doctor, search_year, search_month, search_day, PLConstants.UserCode, ref is_user_admin);
                    break;
            }
            if (pIPDataSet.TSearchPrescription.Rows.Count > 0)
            {
                temp_int = pIPDataSet.TSearchPrescription.number_of_servicesColumn.Ordinal;
                list_start_index.Add(0);
                for (int i = 1; i < pIPDataSet.TSearchPrescription.Rows.Count; i++)
                {
                    list_start_index.Add(list_start_index[i - 1] + (int)pIPDataSet.TSearchPrescription.Rows[i - 1][temp_int]);
                }
                //add another row for prevent from array out of bound exception in SelectionChanged event 
                list_start_index.Add(list_start_index[list_start_index.Count - 1] + (int)pIPDataSet.TSearchPrescription.Rows[list_start_index.Count - 1][temp_int]);
                DataView dtv = new DataView(pIPDataSet.TSearchPrescription);
                DataTable table_pres_seqs = dtv.ToTable(false, pIPDataSet.TSearchPrescription.save_sequenceColumn.ColumnName);
                table_pres_seqs.Columns.Add(new DataColumn(PLConstants.str_table_col_row_number, typeof(int)));
                for (int i = 0; i < table_pres_seqs.Rows.Count; i++)
                {
                    table_pres_seqs.Rows[i][1] = i + 1;
                }
                switch (search_ins_enum)
                {
                    case PLConstants.enum_insurances.Salamat:
                        p_tPrescriptionServiceTableAdapter.FillSalamatPresService(table_pres_services, table_pres_seqs);
                        break;
                    case PLConstants.enum_insurances.TaminEjtemaei:
                        p_tPrescriptionServiceTableAdapter.FillTaminEjtemaeiPresService(table_pres_services, table_pres_seqs);
                        break;
                    case PLConstants.enum_insurances.NirooMosalah:
                        p_tPrescriptionServiceTableAdapter.FillNirooMosalahPresService(table_pres_services, table_pres_seqs);
                        break;
                    case PLConstants.enum_insurances.KomitehEmdad:
                        p_tPrescriptionServiceTableAdapter.FillKomitehEmdadPresService(table_pres_services, table_pres_seqs);
                        break;
                    case PLConstants.enum_insurances.Other:
                        p_tPrescriptionServiceTableAdapter.FillOtherPresService(table_pres_services, table_pres_seqs);
                        break;
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record_after_search);
            }

        }

        # endregion

    }
}
