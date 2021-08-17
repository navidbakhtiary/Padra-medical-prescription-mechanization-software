using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;

namespace PadraInsurancePrescription
{
    public partial class InsuredControl : UserControl
    {
        string i_str_sel_col;

        int i_index;
        PIPDataSet.TInsuredRow i_selected_data;
        List<KeyValuePair<int,long>> i_selected_id_s;//1-row number 2-id
        CheckBox i_select_all_checkbox;

        PIPDataSet.TInsuranceRow[] i_search_ins_rows;
        PLConstants.enum_insurances i_search_ins_enum;
        int i_search_ins_id,i_temp_ins;
        string i_search_ins_tag;
        int i_search_sec;
        string i_search_name;
        string i_search_family;
        string i_search_id;
        bool search_all_empty;

        PGSDialog pgs_dialog;
        PLConstants.enum_operation_results result_enum;

        PIPDataSetTableAdapters.TInsuranceTableAdapter ins_adapter;
        PIPDataSetTableAdapters.TInsuranceSectorTableAdapter sector_adapter;
        PIPDataSet.TInsuranceDataTable ins_data;
        PIPDataSet.TInsuranceSectorDataTable sector_data;

        public InsuredControl()
        {
            //column 0 is checkboxes and not in arrays
            InitializeComponent();
            PLGlobalFuncs.changeDGVSettings(insured_grid);
            i_str_sel_col = "i_select_column";

            i_search_ins_rows=null;
            i_search_ins_id=i_temp_ins=-1;
            i_search_ins_tag="";
            i_search_sec=-1;
            i_search_name="";
            i_search_family="";
            i_search_id="";

            i_selected_id_s = new List<KeyValuePair<int, long>>();
            i_select_all_checkbox = new CheckBox();
            i_select_all_checkbox.CheckedChanged += i_select_all_checkbox_CheckedChanged;

            pgs_dialog = new PGSDialog(this);

            ins_adapter = new PIPDataSetTableAdapters.TInsuranceTableAdapter();
            sector_adapter = new PIPDataSetTableAdapters.TInsuranceSectorTableAdapter();
            initInsuranceComboBox();
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(insurance_combobox);
        }

        // ///////////////////////////////////////////////////// insured

        // ///////////////////////// insured EVENTS
        # region insured Events

        private void i_search_button_Click(object sender, EventArgs e)//checked
        {
            List<string> message_text = new List<string>();
            bool error = false;
            search_all_empty = true;
            i_search_name = "";
            i_search_family = "";
            i_search_id = "";

            if (i_temp_ins < 0)
            {
                error = true;
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_combo_insurance_not_selected);
            }
            else
            {
                i_search_ins_id = i_temp_ins;
                i_search_ins_rows = (PIPDataSet.TInsuranceRow[])ins_data.Select("id=" + i_temp_ins.ToString());
                if (i_search_ins_rows.Length > 0)
                {
                    i_search_ins_tag = i_search_ins_rows[0].tag;
                }   
                // i_search_sec does not need to check because in index_changed event has checked
                if ((!Regex.IsMatch(i_search_name = name_text.Text.Trim(), PLConstants.reg_small_name)) || (!Regex.IsMatch(i_search_family = family_text.Text.Trim(), PLConstants.reg_small_name)))
                {
                    error = true;
                    message_text.Add(PLConstants.error_names);
                }
                else if ((i_search_name.Length >= PLConstants.len_search_min_names_2) || (i_search_family.Length >= PLConstants.len_search_min_names_2))
                {
                    search_all_empty = false;
                }
                if (!Regex.IsMatch(id_text.Text.Trim(), PLConstants.reg_search_insured_id))
                {
                    error = true;
                    message_text.Add(PLConstants.error_search_insured_id);
                }
                else if ((i_search_id=id_text.Text.Trim()).Length >= PLConstants.len_search_min_insured_code_3)
                {
                    search_all_empty = false;
                }

                if (error)
                {
                    pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.error, message_text);
                }
                else if (search_all_empty)
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_search_insureds_fields_not_empty);
                }
                else
                {
                    insured_grid.CellValueChanged -= insured_grid_CellValueChanged;
                    insured_grid.CurrentCellDirtyStateChanged -= insured_grid_CurrentCellDirtyStateChanged;
                    i_search_ins_enum = PLEnumFuncs.convertInsuranceTagToEnum(i_search_ins_tag);
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_search_wait);
                    switch (i_search_ins_enum)
                    {
                        case PLConstants.enum_insurances.Salamat:
                            tInsuredTableAdapter.FillSalamatBySearch(pIPDataSet.TInsured, (int?)i_search_ins_id, (int?)i_search_sec, i_search_name, i_search_family, i_search_id);
                            break;
                        case PLConstants.enum_insurances.TaminEjtemaei:
                            tInsuredTableAdapter.FillTaminEjtemaeiBySearch(pIPDataSet.TInsured, i_search_ins_id, i_search_sec, i_search_name, i_search_family, i_search_id);
                            break;
                        case PLConstants.enum_insurances.NirooMosalah:
                            tInsuredTableAdapter.FillNirooMosalahBySearch(pIPDataSet.TInsured, i_search_ins_id, i_search_sec, i_search_name, i_search_family, i_search_id);
                            break;
                        case PLConstants.enum_insurances.KomitehEmdad:
                            tInsuredTableAdapter.FillKomitehEmdadBySearch(pIPDataSet.TInsured, i_search_ins_id, i_search_sec, i_search_name, i_search_family, i_search_id);
                            break;
                        case PLConstants.enum_insurances.Other:
                            tInsuredTableAdapter.FillOtherBySearch(pIPDataSet.TInsured, i_search_ins_id, i_search_sec, i_search_name, i_search_family, i_search_id);
                            break;
                    }
                    if (pIPDataSet.TInsured.Rows.Count == 0)
                    {
                        pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record_after_search);
                        i_select_all_checkbox.Visible = false;
                    }
                }
            }
        }

        private void insurance_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (insurance_combobox.SelectedIndex > 0)
            {
                i_temp_ins = (int)insurance_combobox.SelectedValue;
                initInsSectorComboBox(i_temp_ins);
                sector_combobox.Enabled = true;
            }
            else
            {
                i_temp_ins = -1;
                i_search_sec = -1;
                //sector_combobox.SelectedIndex = 0;
                sector_combobox.Enabled = false;
            }
        }
        
        private void sector_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sector_combobox.SelectedIndex > 0)
            {
                i_search_sec = (int)sector_combobox.SelectedValue;
            }
            else
            {
                i_search_sec = -1;
            }
        }

        private void i_new_button_Click(object sender, EventArgs e)//checked
        {
            InsuredForm i_form = new InsuredForm(null, i_search_ins_enum, null, PLConstants.enum_data_operation.new_data, null);
            i_form.ShowDialog();
        }

        private void i_edit_button_Click(object sender, EventArgs e)//checked
        {
            getSelectedInsureds();
            if (i_selected_id_s.Count == 1)
            {
                i_index = i_selected_id_s[0].Key;
                i_selected_data = ((PIPDataSet.TInsuredRow)pIPDataSet.TInsured.Rows[i_index]);
                InsuredForm i_form = new InsuredForm(i_search_ins_rows[0], i_search_ins_enum, i_selected_data, PLConstants.enum_data_operation.edit_data, null);
                i_form.ShowDialog();
            }
            else if (i_selected_id_s.Count > 1)
            {
                InsuredForm i_form = new InsuredForm(i_search_ins_rows[0], i_search_ins_enum, null, PLConstants.enum_data_operation.batch_edit, selectedInsuredsToDataTable());
                i_form.ShowDialog();
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }
        }

        private void i_delete_insured_Click(object sender, EventArgs e)//checked
        {
            getSelectedInsureds();
            if (i_selected_id_s.Count > 0)
            {
                List<string> message_text = new List<string>();
                message_text.Add(this.Tag.ToString() + " :");

                message_text.Add(PLConstants.question_delete);
                message_text.Add("بیمه شده های انتخاب شده :");
                message_text.AddRange(getInsuredsDataForMessage());
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.delete, message_text);

                switch (pgs_dialog.user_choice)
                {
                    case PLConstants.enum_dialog_options.yes:
                        string delete_result = "";
                        switch (i_search_ins_enum)
                        {
                            case PLConstants.enum_insurances.Salamat:
                                tInsuredTableAdapter.DeleteFromSalamat( i_search_ins_id, (short?)PLConstants.enum_activity_types.DeleteInsured, PLConstants.UserCode,selectedInsuredsToDataTable(), ref delete_result);
                                break;
                            case PLConstants.enum_insurances.TaminEjtemaei:
                                tInsuredTableAdapter.DeleteFromTaminEjtemaei(i_search_ins_id, (short?)PLConstants.enum_activity_types.DeleteInsured, PLConstants.UserCode, selectedInsuredsToDataTable(), ref delete_result);
                                break;
                            case PLConstants.enum_insurances.NirooMosalah:
                                tInsuredTableAdapter.DeleteFromNirooMosalah(i_search_ins_id, (short?)PLConstants.enum_activity_types.DeleteInsured, PLConstants.UserCode, selectedInsuredsToDataTable(), ref delete_result);
                                break;
                            case PLConstants.enum_insurances.KomitehEmdad:
                                tInsuredTableAdapter.DeleteFromKomitehEmdad(i_search_ins_id, (short?)PLConstants.enum_activity_types.DeleteInsured, PLConstants.UserCode, selectedInsuredsToDataTable(), ref delete_result);
                                break;
                            case PLConstants.enum_insurances.Other:
                                tInsuredTableAdapter.DeleteFromOther(i_search_ins_id, (short?)PLConstants.enum_activity_types.DeleteInsured, PLConstants.UserCode, selectedInsuredsToDataTable(), ref delete_result);
                                break;
                        }
                        result_enum = PLEnumFuncs.opResultToEnum(delete_result);
                        pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.other);
                        switch (result_enum)
                        {
                            case PLConstants.enum_operation_results.success:
                                pIPDataSet.TInsured.Clear();
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

        private void i_select_all_checkbox_CheckedChanged(object sender, EventArgs e)//checked
        {
            if (i_select_all_checkbox.Checked)
            {
                for (int i = 0; i < insured_grid.Rows.Count; i++)
                {
                    insured_grid.Rows[i].Cells[i_str_sel_col].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < insured_grid.Rows.Count; i++)
                {
                    insured_grid.Rows[i].Cells[i_str_sel_col].Value = false;
                }
            }
        }

        private void insured_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)//checked
        {
            if (insured_grid.Rows.Count > 0)
            {
                PLGlobalFuncs.DGVAfterFilling(insured_grid, i_select_all_checkbox);
                insured_grid.CellValueChanged += insured_grid_CellValueChanged;
                insured_grid.CurrentCellDirtyStateChanged += insured_grid_CurrentCellDirtyStateChanged;
            }
        }

        private void insured_grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (insured_grid.IsCurrentCellDirty)
            {
                insured_grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void insured_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(insured_grid.Rows[e.RowIndex].Cells[i_str_sel_col].Value))
            {
                insured_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                insured_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
            }
            else
            {
                insured_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                insured_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.ControlText;
            }
        }

        # endregion

        // ///////////////////////// Insured METHODS
        #region insured Methods

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

        private void getSelectedInsureds()
        {
            i_selected_id_s.Clear();
            int id_col = i_sequence_column.Index;
            for (int i=0;i<insured_grid.Rows.Count;i++)
            {
                if (Convert.ToBoolean(insured_grid.Rows[i].Cells[i_str_sel_col].Value))
                {
                    i_selected_id_s.Add(new KeyValuePair<int,long>(i,(long)insured_grid.Rows[i].Cells[id_col].Value));
                }
            }
        }

        private List<string> getInsuredsDataForMessage()
        {
            int ins_col = i_ins_name_column.Index;
            int sec_col = i_sector_name_column.Index;
            int id_col = i_id_column.Index;
            int name_col = i_name_column.Index;
            int family_col = i_family_name_column.Index;
            List<string> message_text = new List<string>();
            for (int i = 0; i < i_selected_id_s.Count; i++)
            {
                message_text.Add(insured_grid.Rows[i_selected_id_s[i].Key].Cells[ins_col].Value.ToString()+" - "+
                                 insured_grid.Rows[i_selected_id_s[i].Key].Cells[sec_col].Value.ToString() + " - " +
                                 insured_grid.Rows[i_selected_id_s[i].Key].Cells[id_col].Value.ToString()+" - "+
                                 insured_grid.Rows[i_selected_id_s[i].Key].Cells[name_col].Value.ToString()+" - "+
                                 insured_grid.Rows[i_selected_id_s[i].Key].Cells[family_col].Value.ToString()+" - ");
            }
            return message_text;
        }

        private DataTable selectedInsuredsToDataTable()
        {
            DataTable s_i_t = new DataTable();
            s_i_t.Columns.Add(PLConstants.str_table_col_entity_id, typeof(long));
            foreach (KeyValuePair<int, long> i_id in i_selected_id_s)
            {
                s_i_t.Rows.Add(i_id.Value);
            }
            return s_i_t;
        }

        # endregion

    }
}
