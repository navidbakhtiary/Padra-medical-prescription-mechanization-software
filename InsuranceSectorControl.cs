using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;

namespace PadraInsurancePrescription
{
    public partial class InsuranceSectorControl : UserControl
    {
        string s_str_sel_col;

        int s_index;
        PIPDataSet.InsuranceSectorRow s_selected_data;
        List<KeyValuePair<int,int>> s_selected_id_s;//1-row number 2-id
        CheckBox s_select_all_checkbox;

        string s_search_name;
        string s_search_tag;
        int s_search_id;
        string s_search_ins;

        PGSDialog pgs_dialog;
        PLConstants.enum_operation_results result_enum;

        public InsuranceSectorControl()
        {
            //column 0 is checkboxes and not in arrays
            InitializeComponent();
            PLGlobalFuncs.changeDGVSettings(sector_grid);
            s_str_sel_col = s_select_column.Name;

            s_selected_id_s = new List<KeyValuePair<int, int>>();
            s_select_all_checkbox = new CheckBox();
            s_select_all_checkbox.CheckedChanged += s_select_all_checkbox_CheckedChanged;

            pgs_dialog = new PGSDialog(this);
        }

        // ///////////////////////////////////////////////////// Sector

        // ///////////////////////// sector EVENTS
        # region sector Events

        private void search_button_Click(object sender, EventArgs e)//checked
        {
            List<string> message_text = new List<string>();
            bool error = false;
            bool all_empty = true;
            s_search_name = "";
            s_search_tag = "";
            s_search_id = -1;
            if (!Regex.IsMatch(s_search_name = name_text.Text.Trim(), PLConstants.reg_small_name))
            {
                error = true;
                message_text.Add(PLConstants.error_names);
            }
            else if(s_search_name.Length>0)
            {
                all_empty = false;
            }
            if (!Regex.IsMatch(s_search_tag = tag_text.Text.Trim(), PLConstants.reg_search_english_title))
            {
                error = true;
                message_text.Add(PLConstants.error_title_english);
            }
            else if(s_search_tag.Length>0)
            {
                all_empty = false;
            }
            if (!Regex.IsMatch(id_text.Text.Trim(), PLConstants.reg_number))
            {
                error = true;
                message_text.Add(PLConstants.error_id_just_number);
            }
            else if ((id_text.Text.Trim().Length > 0))
            {
                all_empty = false;
                s_search_id = int.Parse(id_text.Text.Trim());
            }
            if (!Regex.IsMatch(s_search_ins = ins_text.Text.Trim(), PLConstants.reg_small_name))
            {
                error = true;
                message_text.Add(PLConstants.error_names);
            }
            else if (s_search_ins.Length > 0)
            {
                all_empty = false;
            }
            sector_grid.CellValueChanged -= sector_grid_CellValueChanged;
            sector_grid.CurrentCellDirtyStateChanged -= sector_grid_CurrentCellDirtyStateChanged;
            if (error)
            {
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.error, message_text);
            }
            else if (all_empty)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_search_fields_not_empty);
            }
            else if (insuranceSectorTableAdapter.FillBySearch(pIPDataSet.InsuranceSector, s_search_name, s_search_tag, s_search_id,s_search_ins) == 0)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record_after_search);
                s_select_all_checkbox.Visible = false;
            }
            sector_grid.CellValueChanged += sector_grid_CellValueChanged;
            sector_grid.CurrentCellDirtyStateChanged += sector_grid_CurrentCellDirtyStateChanged;
        }

        private void new_button_Click(object sender, EventArgs e)//checked
        {
            InsuranceSectorForm s_form = new InsuranceSectorForm(null, PLConstants.enum_data_operation.new_data, null);
            s_form.ShowDialog();
        }

        private void edit_button_Click(object sender, EventArgs e)//checked
        {
            getSelectedSectors();
            if (s_selected_id_s.Count == 1)
            {
                int col_mod_ind = pIPDataSet.InsuranceSector.allow_modifyColumn.Ordinal;
                if ((bool)pIPDataSet.InsuranceSector.Rows[s_selected_id_s[0].Key][col_mod_ind] == true)
                {
                    s_index = s_selected_id_s[0].Key;
                    s_selected_data = ((PIPDataSet.InsuranceSectorRow)pIPDataSet.InsuranceSector.Rows[s_index]);
                    InsuranceSectorForm s_form = new InsuranceSectorForm(s_selected_data, PLConstants.enum_data_operation.edit_data, null);
                    s_form.ShowDialog();
                }
                else
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_edit_main_ins_sectors);
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_choose_one);
            }
        }

        private void delete_button_Click(object sender, EventArgs e)//checked
        {
            getSelectedSectors();
            bool is_main_insurances=false;
            if (s_selected_id_s.Count > 0)
            {
                int col_mod_ind=pIPDataSet.InsuranceSector.allow_modifyColumn.Ordinal;
                for (int i = 0; i < s_selected_id_s.Count; i++)
                {
                    if ((bool)pIPDataSet.InsuranceSector.Rows[s_selected_id_s[i].Key][col_mod_ind] == false)
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
                    message_text.Add("صندوق های انتخاب شده :");
                    message_text.AddRange(getSectorsDataForMessage());
                    pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.delete, message_text);

                    switch (pgs_dialog.user_choice)
                    {
                        case PLConstants.enum_dialog_options.yes:
                            string delete_result = "";
                            insuranceSectorTableAdapter.DeleteSectors(selectedSectorsToDataTable(), ref delete_result);
                            result_enum = PLEnumFuncs.opResultToEnum(delete_result);
                            pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.other);
                            switch (result_enum)
                            {
                                case PLConstants.enum_operation_results.success:
                                    sector_grid.CellValueChanged -= sector_grid_CellValueChanged;
                                    sector_grid.CurrentCellDirtyStateChanged -= sector_grid_CurrentCellDirtyStateChanged;
                                    pIPDataSet.InsuranceSector.Clear();
                                    break;
                            }
                            break;
                    }
                }
                else
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_edit_main_ins_sectors);
                }

            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }

        }

        private void s_select_all_checkbox_CheckedChanged(object sender, EventArgs e)//checked
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

        # endregion

        // ///////////////////////// sector METHODS
        #region sector Methods

        private void getSelectedSectors()
        {
            s_selected_id_s.Clear();
            int id_col=pIPDataSet.InsuranceSector.idColumn.Ordinal+1;
            for (int i=0;i<sector_grid.Rows.Count;i++)
            {
                if (Convert.ToBoolean(sector_grid.Rows[i].Cells[s_str_sel_col].Value))
                {
                    s_selected_id_s.Add(new KeyValuePair<int,int>(i,(int)sector_grid.Rows[i].Cells[id_col].Value));
                }
            }
        }

        private List<string> getSectorsDataForMessage()
        {
            int id_col = s_id_column.Index;
            int name_col = s_name_column.Index;
            int ins_col = s_insurance_name_column.Index;
            int tag_col = s_tag_column.Index;
            List<string> message_text = new List<string>();
            for (int i = 0; i < s_selected_id_s.Count; i++)
            {
                message_text.Add(sector_grid.Rows[s_selected_id_s[i].Key].Cells[id_col].Value.ToString()+"  "+
                                 sector_grid.Rows[s_selected_id_s[i].Key].Cells[name_col].Value.ToString() + " " +
                                 sector_grid.Rows[s_selected_id_s[i].Key].Cells[ins_col].Value.ToString() + " " +
                                 sector_grid.Rows[s_selected_id_s[i].Key].Cells[tag_col].Value.ToString());
            }
            return message_text;
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

        # endregion

    }
}
