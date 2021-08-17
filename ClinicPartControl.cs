using System;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Drawing;

namespace PadraInsurancePrescription
{
    public partial class ClinicPartControl : UserControl
    {
        string p_str_sel_col;

        int p_index;
        PIPDataSet.SClinicPartRow p_selected_data;
        List<KeyValuePair<int, int>> p_selected_id_s;//1-row number 2-id
        CheckBox p_select_all_checkbox;

        string p_search_name;
        int p_search_clinic_type;

        PGSDialog pgs_dialog;
        PLConstants.enum_operation_results result_enum;

        PIPDataSetTableAdapters.TClinicTypeTableAdapter ct_adapter;
        PIPDataSet.TClinicTypeDataTable types_data;

        public ClinicPartControl()
        {
            //column 0 is checkboxes and not in arrays
            InitializeComponent();
            PLGlobalFuncs.changeDGVSettings(clinic_part_grid);
            p_str_sel_col = "p_select_column";

            p_selected_id_s = new List<KeyValuePair<int, int>>();
            p_select_all_checkbox = new CheckBox();
            p_select_all_checkbox.CheckedChanged += p_select_all_checkbox_CheckedChanged;

            pgs_dialog = new PGSDialog(this);

            ct_adapter = new PIPDataSetTableAdapters.TClinicTypeTableAdapter();
            initClinicTypeComboBox();
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(type_comboBox);
        }

        // ///////////////////////// ClinicPart EVENTS
        # region ClinicPart Events

        private void search_button_Click(object sender, EventArgs e)
        {
            List<string> message_text = new List<string>();
            bool error = false;
            bool all_empty = true;
            p_search_name = "";
            p_search_clinic_type = -1;

            if (!Regex.IsMatch(p_search_name = name_text.Text.Trim(), PLConstants.reg_clinic_part_title_search))
            {
                error = true;
                message_text.Add(PLConstants.error_title);
            }
            else if (p_search_name.Length > 0)
            {
                all_empty = false;
            }
            if (type_comboBox.SelectedIndex > 0)
            {
                all_empty = false;
                p_search_clinic_type = (int)type_comboBox.SelectedValue;
            }
            clinic_part_grid.CellValueChanged -= clinic_part_grid_CellValueChanged;
            clinic_part_grid.CurrentCellDirtyStateChanged -= clinic_part_grid_CurrentCellDirtyStateChanged;
            if (error)
            {
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.error, message_text);
            }
            else if (all_empty)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_search_fields_not_empty);
            }
            else if (sClinicPartTableAdapter.FillBySearch(pIPDataSet.SClinicPart, p_search_name, p_search_clinic_type) == 0)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record_after_search);
                p_select_all_checkbox.Visible = false;
            }
            clinic_part_grid.CellValueChanged += clinic_part_grid_CellValueChanged;
            clinic_part_grid.CurrentCellDirtyStateChanged += clinic_part_grid_CurrentCellDirtyStateChanged;
        }

        private void new_button_Click(object sender, EventArgs e)//checked
        {
            ClinicPartForm p_form = new ClinicPartForm(null, PLConstants.enum_data_operation.new_data, null);
            p_form.ShowDialog();
        }

        private void edit_button_Click(object sender, EventArgs e)//checked
        {
            getSelectedParts();
            if (p_selected_id_s.Count == 1)
            {
                p_index = p_selected_id_s[0].Key;
                p_selected_data = ((PIPDataSet.SClinicPartRow)pIPDataSet.SClinicPart.Rows[p_index]);
                ClinicPartForm p_form = new ClinicPartForm(p_selected_data, PLConstants.enum_data_operation.edit_data, null);
                p_form.ShowDialog();
            }
            else if (p_selected_id_s.Count > 1)
            {
                //d_selected_data = ((PIPDataSet.TDoctorRow)pIPDataSet.TDoctor.Rows[d_index]);
                ClinicPartForm p_form = new ClinicPartForm(null, PLConstants.enum_data_operation.batch_edit, selectedPartsToDataTable());
                p_form.ShowDialog();
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }
        }

        private void delete_button_Click(object sender, EventArgs e)//checked
        {
            getSelectedParts();
            if (p_selected_id_s.Count > 0)
            {
                List<string> message_text = new List<string>();
                message_text.Add(this.Tag.ToString() + " :");

                message_text.Add(PLConstants.question_delete);
                message_text.Add("بخش های درمانی انتخاب شده :");
                message_text.AddRange(getPartsDataForMessage());
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.delete, message_text);

                switch (pgs_dialog.user_choice)
                {
                    case PLConstants.enum_dialog_options.yes:
                        string delete_result = "";
                        sClinicPartTableAdapter.DeleteClinicParts(selectedPartsToDataTable(), ref delete_result);
                        result_enum = PLEnumFuncs.opResultToEnum(delete_result);
                        pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.other);
                        switch (result_enum)
                        {
                            case PLConstants.enum_operation_results.success:
                                clinic_part_grid.CellValueChanged -= clinic_part_grid_CellValueChanged;
                                clinic_part_grid.CurrentCellDirtyStateChanged -= clinic_part_grid_CurrentCellDirtyStateChanged;
                                pIPDataSet.MedicineDegree.Clear();
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

        private void p_select_all_checkbox_CheckedChanged(object sender, EventArgs e)//checked
        {
            if (p_select_all_checkbox.Checked)
            {
                for (int i = 0; i < clinic_part_grid.Rows.Count; i++)
                {
                    clinic_part_grid.Rows[i].Cells[p_str_sel_col].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < clinic_part_grid.Rows.Count; i++)
                {
                    clinic_part_grid.Rows[i].Cells[p_str_sel_col].Value = false;
                }
            }
        }

        private void clinic_part_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)//checked
        {
            if (clinic_part_grid.Rows.Count > 0)
            {
                PLGlobalFuncs.DGVAfterFilling(clinic_part_grid, p_select_all_checkbox);
                clinic_part_grid.CellValueChanged += clinic_part_grid_CellValueChanged;
                clinic_part_grid.CurrentCellDirtyStateChanged += clinic_part_grid_CurrentCellDirtyStateChanged;
            }
        }

        private void clinic_part_grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (clinic_part_grid.IsCurrentCellDirty)
            {
                clinic_part_grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void clinic_part_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(clinic_part_grid.Rows[e.RowIndex].Cells[p_str_sel_col].Value))
            {
                clinic_part_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                clinic_part_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
            }
            else
            {
                clinic_part_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                clinic_part_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.ControlText;
            }
        }

        # endregion

        // ///////////////////////// ClinicPart METHODS
        #region ClinicPart Methods

        private void initClinicTypeComboBox()
        {
            types_data = ct_adapter.GetAllTypes();
            PIPDataSet.TClinicTypeRow ct_first_row = types_data.NewTClinicTypeRow();
            ct_first_row.id = -1;
            ct_first_row.name = "--نوع مرکز پزشکی--";
            types_data.Rows.InsertAt(ct_first_row, 0);
            type_comboBox.DataSource = types_data;
            type_comboBox.DisplayMember = types_data.nameColumn.ColumnName;
            type_comboBox.ValueMember = types_data.idColumn.ColumnName;
            type_comboBox.SelectedIndex = 0;
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(type_comboBox);
        }

        private void getSelectedParts()
        {
            p_selected_id_s.Clear();
            int id_col=pIPDataSet.SClinicPart.idColumn.Ordinal+1;
            for (int i=0;i<clinic_part_grid.Rows.Count;i++)
            {
                if (Convert.ToBoolean(clinic_part_grid.Rows[i].Cells[p_str_sel_col].Value))
                {
                    p_selected_id_s.Add(new KeyValuePair<int, int>(i, (int)clinic_part_grid.Rows[i].Cells[id_col].Value));
                }
            }
        }

        private List<string> getPartsDataForMessage()
        {
            int name_col = p_name_column.Index;
            
            List<string> message_text = new List<string>();
            for (int i = 0; i < p_selected_id_s.Count; i++)
            {
                message_text.Add((string)clinic_part_grid.Rows[p_selected_id_s[i].Key].Cells[name_col].Value);
            }
            return message_text;
        }

        private DataTable selectedPartsToDataTable()
        {
            DataTable s_d_t = new DataTable();
            s_d_t.Columns.Add(PLConstants.str_table_col_entity_id, typeof(int));
            foreach (KeyValuePair<int, int> d_id in p_selected_id_s)
            {
                s_d_t.Rows.Add(d_id.Value);
            }
            return s_d_t;
        }

        //private void afterClinicPartGridFilled()
        //{
        //    PLGlobalFuncs.dataGridViewAfterFilling(clinic_part_grid, p_select_all_checkbox);
        //    PLGlobalFuncs.createAllCheckBoxForDataGridView(clinic_part_grid, p_select_all_checkbox);

        //    for (int i = 0; i < clinic_part_grid.Rows.Count; i++)
        //    {
        //        clinic_part_grid.Rows[i].Cells[p_str_sel_col].Value = false;
        //    }
        //}

        # endregion

        

    }
}
