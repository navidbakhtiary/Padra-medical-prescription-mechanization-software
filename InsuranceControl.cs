using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;

namespace PadraInsurancePrescription
{
    public partial class InsuranceControl : UserControl
    {

        string i_str_sel_col;

        int i_index;
        PIPDataSet.InsuranceRow i_selected_data;
        List<KeyValuePair<int,int>> i_selected_id_s;//1-row number 2-id
        CheckBox i_select_all_checkbox;

        string i_search_name;
        string i_search_tag;
        int i_search_id;

        PGSDialog pgs_dialog;
        PLConstants.enum_operation_results result_enum;

        public InsuranceControl()
        {
            //column 0 is checkboxes and not in arrays
            InitializeComponent();
            PLGlobalFuncs.changeDGVSettings(insurance_grid);
            i_str_sel_col = i_select_column.Name;

            i_selected_id_s = new List<KeyValuePair<int, int>>();
            i_select_all_checkbox = new CheckBox();
            i_select_all_checkbox.CheckedChanged += i_select_all_checkbox_CheckedChanged;

            pgs_dialog = new PGSDialog(this);
        }

        // ///////////////////////////////////////////////////// Insurance

        // ///////////////////////// Insurance EVENTS
        # region insurance Events

        private void search_button_Click(object sender, EventArgs e)//checked
        {
            List<string> message_text = new List<string>();
            bool error = false;
            bool all_empty = true;
            i_search_name = "";
            i_search_tag = "";
            i_search_id = -1;
            if (!Regex.IsMatch(i_search_name = name_text.Text.Trim(), PLConstants.reg_small_name))
            {
                error = true;
                message_text.Add(PLConstants.error_names);
            }
            else if(i_search_name.Length>0)
            {
                all_empty = false;
            }
            if (!Regex.IsMatch(i_search_tag = tag_text.Text.Trim(), PLConstants.reg_search_english_title))
            {
                error = true;
                message_text.Add(PLConstants.error_title_english);
            }
            else if(i_search_tag.Length>0)
            {
                all_empty = false;
            }
            if (!Regex.IsMatch(id_text.Text.Trim(), PLConstants.reg_number))
            {
                error = true;
                message_text.Add(PLConstants.error_id_just_number);
            }
            else if ((id_text.Text.Trim().Length>0))
            {
                all_empty = false;
                i_search_id = int.Parse(id_text.Text.Trim());
            }
            insurance_grid.CellValueChanged -= insurance_grid_CellValueChanged;
            insurance_grid.CurrentCellDirtyStateChanged -= insurance_grid_CurrentCellDirtyStateChanged;
            if (error)
            {
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.error, message_text);
            }
            //else if (all_empty)
            //{
            //    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_search_fields_not_empty);
            //}
            else if (insuranceTableAdapter.FillBySearch(pIPDataSet.Insurance, i_search_name, i_search_tag, i_search_id) == 0)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record_after_search);
                i_select_all_checkbox.Visible = false;
            }
            insurance_grid.CellValueChanged += insurance_grid_CellValueChanged;
            insurance_grid.CurrentCellDirtyStateChanged += insurance_grid_CurrentCellDirtyStateChanged;
        }

        private void new_button_Click(object sender, EventArgs e)//checked
        {
            InsuranceForm i_form = new InsuranceForm(null, PLConstants.enum_data_operation.new_data, null);
            i_form.ShowDialog();
        }

        private void edit_button_Click(object sender, EventArgs e)//checked
        {
            getSelectedInsurances();
            if (i_selected_id_s.Count == 1)
            {
                int col_mod_ind = pIPDataSet.Insurance.allow_modifyColumn.Ordinal;
                if ((bool)pIPDataSet.Insurance.Rows[i_selected_id_s[0].Key][col_mod_ind] == true)
                {
                    i_index = i_selected_id_s[0].Key;
                    i_selected_data = ((PIPDataSet.InsuranceRow)pIPDataSet.Insurance.Rows[i_index]);
                    InsuranceForm i_form = new InsuranceForm(i_selected_data, PLConstants.enum_data_operation.edit_data, null);
                    i_form.ShowDialog();
                }
                else
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_edit_main_insurances);
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_choose_one);
            }
        }

        private void delete_button_Click(object sender, EventArgs e)//checked
        {
            getSelectedInsurances();
            bool is_main_insurances=false;
            if (i_selected_id_s.Count > 0)
            {
                int col_mod_ind=pIPDataSet.Insurance.allow_modifyColumn.Ordinal;
                for (int i = 0; i < i_selected_id_s.Count; i++)
                {
                    if ((bool)pIPDataSet.Insurance.Rows[i_selected_id_s[i].Key][col_mod_ind] == false)
                    {
                        is_main_insurances = true;
                        break;
                    }
                }
                if (!is_main_insurances)
                {
                    List<string> message_text = new List<string>();
                    message_text.Add(this.Tag.ToString() + " :");

                    message_text.Add(PLConstants.question_delete);
                    message_text.Add("بیمه های انتخاب شده :");
                    message_text.AddRange(getInsurancesDataForMessage());
                    pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.delete, message_text);

                    switch (pgs_dialog.user_choice)
                    {
                        case PLConstants.enum_dialog_options.yes:
                            string delete_result = "";
                            insuranceTableAdapter.DeleteInsurances(selectedInsurancesToDataTable(), ref delete_result);
                            result_enum = PLEnumFuncs.opResultToEnum(delete_result);
                            pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.other);
                            switch (result_enum)
                            {
                                case PLConstants.enum_operation_results.success:
                                    insurance_grid.CellValueChanged -= insurance_grid_CellValueChanged;
                                    insurance_grid.CurrentCellDirtyStateChanged -= insurance_grid_CurrentCellDirtyStateChanged;
                                    pIPDataSet.Insurance.Clear();
                                    break;
                            }
                            break;
                    }
                }
                else
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_edit_main_insurances);
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

        # endregion

        // ///////////////////////// insurance METHODS
        #region insurance Methods

        private void getSelectedInsurances()
        {
            i_selected_id_s.Clear();
            int id_col=pIPDataSet.Insurance.idColumn.Ordinal+1;
            for (int i=0;i<insurance_grid.Rows.Count;i++)
            {
                if (Convert.ToBoolean(insurance_grid.Rows[i].Cells[i_str_sel_col].Value))
                {
                    i_selected_id_s.Add(new KeyValuePair<int,int>(i,(int)insurance_grid.Rows[i].Cells[id_col].Value));
                }
            }
        }

        private List<string> getInsurancesDataForMessage()
        {
            int id_col = i_id_column.Index;
            int name_col = i_name_column.Index;
            int tag_col = i_tag_column.Index;
            List<string> message_text = new List<string>();
            for (int i = 0; i < i_selected_id_s.Count; i++)
            {
                message_text.Add(insurance_grid.Rows[i_selected_id_s[i].Key].Cells[id_col].Value.ToString()+"  "+
                                 insurance_grid.Rows[i_selected_id_s[i].Key].Cells[name_col].Value.ToString() + " " +
                                 insurance_grid.Rows[i_selected_id_s[i].Key].Cells[tag_col].Value.ToString());
            }
            return message_text;
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

        # endregion

    }
}
