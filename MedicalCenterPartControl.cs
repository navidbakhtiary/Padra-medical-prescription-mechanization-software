using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PadraInsurancePrescription
{
    public partial class MedicalCenterPartControl : UserControl
    {
        string c_str_sel_col;
        string cp_str_sel_col;
        string o_str_sel_col;

        int c_index_one;
        int c_index_two;
        int c_selected_id;
        bool c_is_switched;
        List<KeyValuePair<int,int>> c_selected_id_s;//1-row number 2-id
        CheckBox c_select_all_checkbox;

        List<KeyValuePair<int, int>> cp_selected_id_s;//1-row number 2-id
        CheckBox cp_select_all_checkbox;

        List<KeyValuePair<int, int>> o_selected_id_s;//1-row number 2-id
        CheckBox o_select_all_checkbox;

        PGSDialog pgs_dialog;
        PLConstants.enum_operation_results result_enum;

        PIPDataSetTableAdapters.TClinicTypeTableAdapter ct_adapter;
        PIPDataSet.TClinicTypeDataTable ct_data;

        public MedicalCenterPartControl()
        {
            //column 0 is checkboxes and not in arrays
            InitializeComponent();
            PLGlobalFuncs.changeDGVSettings(center_grid,center_parts_grid,other_parts_grid);
            c_str_sel_col = "c_select_column";
            cp_str_sel_col = "cp_select_column";
            o_str_sel_col = "o_select_column";

            c_selected_id_s = new List<KeyValuePair<int, int>>();
            c_selected_id = -1;
            c_select_all_checkbox = new CheckBox();
            //c_select_all_checkbox.CheckedChanged += c_select_all_checkbox_CheckedChanged;
            c_select_all_checkbox.Visible = false;
            c_index_one = c_index_two = -1;
            c_is_switched = false;

            cp_selected_id_s = new List<KeyValuePair<int, int>>();
            cp_select_all_checkbox = new CheckBox();
            cp_select_all_checkbox.CheckedChanged += ic_select_all_checkbox_CheckedChanged;

            o_selected_id_s = new List<KeyValuePair<int, int>>();
            o_select_all_checkbox = new CheckBox();
            o_select_all_checkbox.CheckedChanged += o_select_all_checkbox_CheckedChanged;

            ct_adapter = new PIPDataSetTableAdapters.TClinicTypeTableAdapter();

            pgs_dialog = new PGSDialog(this);
            initTypeComboBox();
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

        private void c_parts_button_Click(object sender, EventArgs e)
        {
            //getSelectedCenter();
            if (c_selected_id>-1)
            {
                center_parts_grid.CellValueChanged -= center_parts_grid_CellValueChanged;
                center_parts_grid.CurrentCellDirtyStateChanged -= center_parts_grid_CurrentCellDirtyStateChanged;
                other_parts_grid.CellValueChanged -= other_parts_grid_CellValueChanged;
                other_parts_grid.CurrentCellDirtyStateChanged -= other_parts_grid_CurrentCellDirtyStateChanged;
                if (tMedicalCenterPartTableAdapter.Fill(pIPDataSet.TMedicalCenterPart, c_selected_id) == 0)
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record);
                }
                tClinicPartNotInMedicalCenterTableAdapter.Fill(pIPDataSet.TClinicPartNotInMedicalCenter, c_selected_id);
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
                pIPDataSet.TMedicalCenterPart.Rows.Clear();
                pIPDataSet.TClinicPartNotInMedicalCenter.Rows.Clear();
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
                c_index_one =c_index_two= -1;
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

        // ///////////////////////////////////////////////////// Parts 

        // ///////////////////////// Parts EVENTS
        #region Parts Events

        private void other_to_parts_button_Click(object sender, EventArgs e)
        {
            getSelectedOthers();
            if (o_selected_id_s.Count > 0)
            {
                string add_result = "";
                List<string> message_text = new List<string>();
                message_text.Add(PLConstants.question_new_part_for_center);
                message_text.Add("مرکز درمانی انتخاب شده : " + pIPDataSet.SMedicalCenter.Rows[c_index_two][pIPDataSet.SMedicalCenter.nameColumn.Ordinal].ToString());
                message_text.Add("بخش های انتخاب شده:");
                message_text.AddRange(getOthersDataForMessage());
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.save_new, message_text);
                switch (pgs_dialog.user_choice)
                {
                    case PLConstants.enum_dialog_options.yes:
                        tMedicalCenterPartTableAdapter.AddParts(c_selected_id, selectedOthersToDataTable(), ref add_result);
                        result_enum = PLEnumFuncs.opResultToEnum(add_result);
                        pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.other);
                        if (result_enum == PLConstants.enum_operation_results.success)
                        {
                            center_parts_grid.CellValueChanged -= center_parts_grid_CellValueChanged;
                            center_parts_grid.CurrentCellDirtyStateChanged -= center_parts_grid_CurrentCellDirtyStateChanged;
                            other_parts_grid.CellValueChanged -= other_parts_grid_CellValueChanged;
                            other_parts_grid.CurrentCellDirtyStateChanged -= other_parts_grid_CurrentCellDirtyStateChanged;
                            tMedicalCenterPartTableAdapter.Fill(pIPDataSet.TMedicalCenterPart, c_selected_id);
                            tClinicPartNotInMedicalCenterTableAdapter.Fill(pIPDataSet.TClinicPartNotInMedicalCenter, c_selected_id);
                        }
                        break;
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }
        }

        private void parts_to_other_button_Click(object sender, EventArgs e)
        {
            getSelectedParts();
            if (cp_selected_id_s.Count > 0)
            {
                List<string> message_text = new List<string>();
                message_text.Add(this.Tag.ToString() + " :");

                message_text.Add(PLConstants.question_delete_part_from_center);
                message_text.Add("مرکز درمانی انتخاب شده : " + pIPDataSet.SMedicalCenter.Rows[c_index_two][pIPDataSet.SMedicalCenter.nameColumn.Ordinal].ToString());
                message_text.Add("بخش های انتخاب شده :");
                message_text.AddRange(getPartsDataForMessage());
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.delete, message_text);
                switch (pgs_dialog.user_choice)
                {
                    case PLConstants.enum_dialog_options.yes:
                        string delete_result = "";
                        tMedicalCenterPartTableAdapter.DeleteParts(selectedPartsToDataTable(), ref delete_result);
                        result_enum = PLEnumFuncs.opResultToEnum(delete_result);
                        pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.other);
                        if (result_enum == PLConstants.enum_operation_results.success)
                        {
                            center_parts_grid.CellValueChanged -= center_parts_grid_CellValueChanged;
                            center_parts_grid.CurrentCellDirtyStateChanged -= center_parts_grid_CurrentCellDirtyStateChanged;
                            other_parts_grid.CellValueChanged -= other_parts_grid_CellValueChanged;
                            other_parts_grid.CurrentCellDirtyStateChanged -= other_parts_grid_CurrentCellDirtyStateChanged;
                            tMedicalCenterPartTableAdapter.Fill(pIPDataSet.TMedicalCenterPart, c_selected_id);
                            tClinicPartNotInMedicalCenterTableAdapter.Fill(pIPDataSet.TClinicPartNotInMedicalCenter, c_selected_id);
                        }
                        break;
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }
        }

        private void center_parts_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (center_parts_grid.Rows.Count > 0)
            {
                PLGlobalFuncs.DGVAfterFilling(center_parts_grid, cp_select_all_checkbox);
                center_parts_grid.CellValueChanged += center_parts_grid_CellValueChanged;
                center_parts_grid.CurrentCellDirtyStateChanged += center_parts_grid_CurrentCellDirtyStateChanged;
            }
        }

        private void other_parts_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (other_parts_grid.Rows.Count > 0)
            {
                PLGlobalFuncs.DGVAfterFilling(other_parts_grid, o_select_all_checkbox);
                other_parts_grid.CellValueChanged += other_parts_grid_CellValueChanged;
                other_parts_grid.CurrentCellDirtyStateChanged += other_parts_grid_CurrentCellDirtyStateChanged;
            }
        }

        private void ic_select_all_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (cp_select_all_checkbox.Checked)
            {
                for (int i = 0; i < center_parts_grid.Rows.Count; i++)
                {
                    center_parts_grid.Rows[i].Cells[cp_str_sel_col].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < center_parts_grid.Rows.Count; i++)
                {
                    center_parts_grid.Rows[i].Cells[cp_str_sel_col].Value = false;
                }
            }
        }

        private void o_select_all_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (o_select_all_checkbox.Checked)
            {
                for (int i = 0; i < other_parts_grid.Rows.Count; i++)
                {
                    other_parts_grid.Rows[i].Cells[o_str_sel_col].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < other_parts_grid.Rows.Count; i++)
                {
                    other_parts_grid.Rows[i].Cells[o_str_sel_col].Value = false;
                }
            }
        }

        private void center_parts_grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (center_parts_grid.IsCurrentCellDirty)
            {
                center_parts_grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void center_parts_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(center_parts_grid.Rows[e.RowIndex].Cells[cp_str_sel_col].Value))
            {
                center_parts_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                center_parts_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
            }
            else
            {
                center_parts_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                center_parts_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.ControlText;
            }
        }

        private void other_parts_grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (other_parts_grid.IsCurrentCellDirty)
            {
                other_parts_grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void other_parts_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(other_parts_grid.Rows[e.RowIndex].Cells[o_str_sel_col].Value))
            {
                other_parts_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                other_parts_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
            }
            else
            {
                other_parts_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                other_parts_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.ControlText;
            }
        }

        #endregion

        // ///////////////////////// Parts METHODS
        #region Parts Methods

        private void getSelectedParts()
        {
            cp_selected_id_s.Clear();
            int id_col = cp_cen_par_seq_column.Index;
            for (int i = 0; i < center_parts_grid.Rows.Count; i++)
            {
                if (Convert.ToBoolean(center_parts_grid.Rows[i].Cells[cp_str_sel_col].Value))
                {
                    cp_selected_id_s.Add(new KeyValuePair<int, int>(i, (int)center_parts_grid.Rows[i].Cells[id_col].Value));
                }
            }
        }

        private void getSelectedOthers()
        {
            o_selected_id_s.Clear();
            int id_col = o_id_column.Index;
            for (int i = 0; i < other_parts_grid.Rows.Count; i++)
            {
                if (Convert.ToBoolean(other_parts_grid.Rows[i].Cells[o_str_sel_col].Value))
                {
                    o_selected_id_s.Add(new KeyValuePair<int, int>(i, (int)other_parts_grid.Rows[i].Cells[id_col].Value));
                }
            }
        }

        private List<string> getPartsDataForMessage()
        {
            int id_col = cp_id_column.Index;
            int name_col = cp_name_column.Index;

            List<string> message_text = new List<string>();
            for (int i = 0; i < cp_selected_id_s.Count; i++)
            {
                message_text.Add(center_parts_grid.Rows[cp_selected_id_s[i].Key].Cells[id_col].Value.ToString() + " - " +
                                 center_parts_grid.Rows[cp_selected_id_s[i].Key].Cells[name_col].Value.ToString());
            }
            return message_text;
        }

        private List<string> getOthersDataForMessage()
        {
            int id_col = o_id_column.Index;
            int name_col = o_name_column.Index;
            
            List<string> message_text = new List<string>();
            for (int i = 0; i < o_selected_id_s.Count; i++)
            {
                message_text.Add(other_parts_grid.Rows[o_selected_id_s[i].Key].Cells[id_col].Value.ToString() + " - " +
                                 other_parts_grid.Rows[o_selected_id_s[i].Key].Cells[name_col].Value.ToString());
            }
            return message_text;
        }

        private DataTable selectedPartsToDataTable()
        {
            DataTable s_d_t = new DataTable();
            s_d_t.Columns.Add("c_id", typeof(int));
            foreach (KeyValuePair<int, int> c_id in cp_selected_id_s)
            {
                s_d_t.Rows.Add(c_id.Value);
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

        //private void afterCenterPartsGridFilled()
        //{
        //    PLGlobalFuncs.dataGridViewAfterFilling(center_parts_grid, cp_select_all_checkbox);
        //    PLGlobalFuncs.createAllCheckBoxForDataGridView(center_parts_grid, cp_select_all_checkbox);

        //    for (int i = 0; i < center_parts_grid.Rows.Count; i++)
        //    {
        //        center_parts_grid.Rows[i].Cells[cp_str_sel_col].Value = false;
        //    }
        //}

        //private void afterOtherPartsGridFilled()
        //{
        //    PLGlobalFuncs.dataGridViewAfterFilling(other_parts_grid, o_select_all_checkbox);
        //    PLGlobalFuncs.createAllCheckBoxForDataGridView(other_parts_grid, o_select_all_checkbox);

        //    for (int i = 0; i < other_parts_grid.Rows.Count; i++)
        //    {
        //        other_parts_grid.Rows[i].Cells[o_str_sel_col].Value = false;
        //    }
        //}

        #endregion


    }
}
