using System;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Drawing;

namespace PadraInsurancePrescription
{
    public partial class MedicineFieldControl : UserControl
    {
        string f_str_sel_col;

        int f_index;
        PIPDataSet.MedicineFieldRow f_selected_data;
        List<KeyValuePair<int,int>> f_selected_id_s;//1-row number 2-id
        CheckBox f_select_all_checkbox;

        PGSDialog pgs_dialog;
        PLConstants.enum_operation_results result_enum;

        PIPDataSetTableAdapters.MedicineFieldTableAdapter mf_adapter;

        public MedicineFieldControl()
        {
            //column 0 is checkboxes and not in arrays
            InitializeComponent();
            PLGlobalFuncs.changeDGVSettings(medicine_field_grid);
            f_str_sel_col = "f_select_column";

            f_selected_id_s = new List<KeyValuePair<int, int>>();
            f_select_all_checkbox = new CheckBox();
            f_select_all_checkbox.CheckedChanged += f_select_all_checkbox_CheckedChanged;

            pgs_dialog = new PGSDialog(this);

            mf_adapter = new PIPDataSetTableAdapters.MedicineFieldTableAdapter();
        }

        // ///////////////////////// MedicineField EVENTS
        # region MedicineField Events

        private void search_button_Click(object sender, EventArgs e)
        {
            string f_name = name_text.Text.Trim();
            medicine_field_grid.CellValueChanged -= medicine_field_grid_CellValueChanged;
            medicine_field_grid.CurrentCellDirtyStateChanged -= medicine_field_grid_CurrentCellDirtyStateChanged;
            if (f_name == "")
            {
                if (medicineFieldTableAdapter.Fill(pIPDataSet.MedicineField) == 0)
                {
                    pgs_dialog = new PGSDialog(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record);
                    pgs_dialog.ShowDialog();
                    f_select_all_checkbox.Visible = false;
                }
            }
            else if (Regex.IsMatch(f_name, PLConstants.reg_name))
            {
                if (medicineFieldTableAdapter.FillBySearch(pIPDataSet.MedicineField, f_name) == 0)
                {
                    pgs_dialog = new PGSDialog(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record_after_search);
                    pgs_dialog.ShowDialog();
                    f_select_all_checkbox.Visible = false;
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_letters_only);
            }
            medicine_field_grid.CellValueChanged += medicine_field_grid_CellValueChanged;
            medicine_field_grid.CurrentCellDirtyStateChanged += medicine_field_grid_CurrentCellDirtyStateChanged;
        }

        private void new_button_Click(object sender, EventArgs e)//checked
        {
            MedicineFieldForm f_form = new MedicineFieldForm(null, PLConstants.enum_data_operation.new_data, null);
            f_form.ShowDialog();
        }

        private void edit_button_Click(object sender, EventArgs e)//checked
        {
            getSelectedFields();
            if (f_selected_id_s.Count == 1)
            {
                f_index = f_selected_id_s[0].Key;
                f_selected_data = ((PIPDataSet.MedicineFieldRow)pIPDataSet.MedicineField.Rows[f_index]);
                MedicineFieldForm f_form = new MedicineFieldForm(f_selected_data, PLConstants.enum_data_operation.edit_data, null);
                f_form.ShowDialog();
            }
            else if (f_selected_id_s.Count > 1)
            {
                //d_selected_data = ((PIPDataSet.TDoctorRow)pIPDataSet.TDoctor.Rows[d_index]);
                MedicineFieldForm f_form = new MedicineFieldForm(null, PLConstants.enum_data_operation.batch_edit, selectedFieldsToDataTable());
                f_form.ShowDialog();
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }
        }

        private void delete_button_Click(object sender, EventArgs e)//checked
        {
            getSelectedFields();
            if (f_selected_id_s.Count > 0)
            {
                List<string> message_text = new List<string>();
                message_text.Add(this.Tag.ToString() + " :");

                message_text.Add(PLConstants.question_delete);
                message_text.Add("رشته های پزشکی انتخاب شده :");
                message_text.AddRange(getFieldsDataForMessage());
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.delete, message_text);

                switch (pgs_dialog.user_choice)
                {
                    case PLConstants.enum_dialog_options.yes:
                        string delete_result = "";
                        medicineFieldTableAdapter.DeleteFields(selectedFieldsToDataTable(), ref delete_result);
                        result_enum = PLEnumFuncs.opResultToEnum(delete_result);
                        pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.other);
                        switch (result_enum)
                        {
                            case PLConstants.enum_operation_results.success:
                                medicine_field_grid.CellValueChanged -= medicine_field_grid_CellValueChanged;
                                medicine_field_grid.CurrentCellDirtyStateChanged -= medicine_field_grid_CurrentCellDirtyStateChanged;
                                pIPDataSet.MedicineField.Clear();
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

        private void f_select_all_checkbox_CheckedChanged(object sender, EventArgs e)//checked
        {
            if (f_select_all_checkbox.Checked)
            {
                for (int i = 0; i < medicine_field_grid.Rows.Count; i++)
                {
                    medicine_field_grid.Rows[i].Cells[f_str_sel_col].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < medicine_field_grid.Rows.Count; i++)
                {
                    medicine_field_grid.Rows[i].Cells[f_str_sel_col].Value = false;
                }
            }
        }

        private void medicine_field_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)//checked
        {
            if (medicine_field_grid.Rows.Count > 0)
            {
                PLGlobalFuncs.DGVAfterFilling(medicine_field_grid, f_select_all_checkbox);
                medicine_field_grid.CellValueChanged += medicine_field_grid_CellValueChanged;
                medicine_field_grid.CurrentCellDirtyStateChanged += medicine_field_grid_CurrentCellDirtyStateChanged;
            }
        }

        private void medicine_field_grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (medicine_field_grid.IsCurrentCellDirty)
            {
                medicine_field_grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void medicine_field_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(medicine_field_grid.Rows[e.RowIndex].Cells[f_str_sel_col].Value))
            {
                medicine_field_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                medicine_field_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
            }
            else
            {
                medicine_field_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                medicine_field_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.ControlText;
            }
        }

        # endregion

        // ///////////////////////// MedicineField METHODS
        #region MedicineField Methods

        private void getSelectedFields()
        {
            f_selected_id_s.Clear();
            int id_col=pIPDataSet.MedicineField.idColumn.Ordinal+1;
            for (int i=0;i<medicine_field_grid.Rows.Count;i++)
            {
                if (Convert.ToBoolean(medicine_field_grid.Rows[i].Cells[f_str_sel_col].Value))
                {
                    f_selected_id_s.Add(new KeyValuePair<int, int>(i, (int)medicine_field_grid.Rows[i].Cells[id_col].Value));
                }
            }
        }

        private List<string> getFieldsDataForMessage()
        {
            int name_col = f_name_column.Index;
            
            List<string> message_text = new List<string>();
            for (int i = 0; i < f_selected_id_s.Count; i++)
            {
                message_text.Add((string)medicine_field_grid.Rows[f_selected_id_s[i].Key].Cells[name_col].Value);
            }
            return message_text;
        }

        private DataTable selectedFieldsToDataTable()
        {
            DataTable s_d_t = new DataTable();
            s_d_t.Columns.Add(PLConstants.str_table_col_entity_id, typeof(int));
            foreach (KeyValuePair<int, int> d_id in f_selected_id_s)
            {
                s_d_t.Rows.Add(d_id.Value);
            }
            return s_d_t;
        }

        //private void afterMedicineFieldGridFilled()
        //{
        //    PLGlobalFuncs.dataGridViewAfterFilling(medicine_field_grid, f_select_all_checkbox);
        //    PLGlobalFuncs.createAllCheckBoxForDataGridView(medicine_field_grid, f_select_all_checkbox);

        //    for (int i = 0; i < medicine_field_grid.Rows.Count; i++)
        //    {
        //        medicine_field_grid.Rows[i].Cells[f_str_sel_col].Value = false;
        //    }
        //}

        # endregion

    }
}
