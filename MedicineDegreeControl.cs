using System;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using System.Drawing;

namespace PadraInsurancePrescription
{
    public partial class MedicineDegreeControl : UserControl
    {
        string d_str_sel_col;

        int d_index;
        PIPDataSet.MedicineDegreeRow d_selected_data;
        List<KeyValuePair<int,int>> d_selected_id_s;//1-row number 2-id
        CheckBox d_select_all_checkbox;

        PGSDialog pgs_dialog;
        PLConstants.enum_operation_results result_enum;

        PIPDataSetTableAdapters.MedicineDegreeTableAdapter md_adapter;

        public MedicineDegreeControl()
        {
            //column 0 is checkboxes and not in arrays
            InitializeComponent();
            PLGlobalFuncs.changeDGVSettings(medicine_degree_grid);
            d_str_sel_col = "d_select_column";

            d_selected_id_s = new List<KeyValuePair<int, int>>();
            d_select_all_checkbox = new CheckBox();
            d_select_all_checkbox.CheckedChanged += d_select_all_checkbox_CheckedChanged;

            pgs_dialog = new PGSDialog(this);

            md_adapter = new PIPDataSetTableAdapters.MedicineDegreeTableAdapter();
        }

        // ///////////////////////// MedicineDegree EVENTS
        # region MedicineDegree Events
        
        private void refresh_grid_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {//checked
            medicine_degree_grid.CellValueChanged -= medicine_degree_grid_CellValueChanged;
            medicine_degree_grid.CurrentCellDirtyStateChanged -= medicine_degree_grid_CurrentCellDirtyStateChanged;
            if (medicineDegreeTableAdapter.Fill(pIPDataSet.MedicineDegree) == 0)
            {
                pgs_dialog = new PGSDialog(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record);
                pgs_dialog.ShowDialog();
                d_select_all_checkbox.Visible = false;
            }
            medicine_degree_grid.CellValueChanged += medicine_degree_grid_CellValueChanged;
            medicine_degree_grid.CurrentCellDirtyStateChanged += medicine_degree_grid_CurrentCellDirtyStateChanged;
        }

        private void new_button_Click(object sender, EventArgs e)//checked
        {
            MedicineDegreeForm d_form = new MedicineDegreeForm(null, PLConstants.enum_data_operation.new_data, null);
            d_form.ShowDialog();
        }

        private void edit_button_Click(object sender, EventArgs e)//checked
        {
            getSelectedDegrees();
            if (d_selected_id_s.Count == 1)
            {
                d_index = d_selected_id_s[0].Key;
                d_selected_data = ((PIPDataSet.MedicineDegreeRow)pIPDataSet.MedicineDegree.Rows[d_index]);
                MedicineDegreeForm d_form = new MedicineDegreeForm(d_selected_data, PLConstants.enum_data_operation.edit_data, null);
                d_form.ShowDialog();
            }
            else if (d_selected_id_s.Count > 1)
            {
                //d_selected_data = ((PIPDataSet.TDoctorRow)pIPDataSet.TDoctor.Rows[d_index]);
                MedicineDegreeForm d_form = new MedicineDegreeForm(null, PLConstants.enum_data_operation.batch_edit, selectedDegreesToDataTable());
                d_form.ShowDialog();
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }
        }

        private void delete_button_Click(object sender, EventArgs e)//checked
        {
            getSelectedDegrees();
            if (d_selected_id_s.Count > 0)
            {
                List<string> message_text = new List<string>();
                message_text.Add(this.Tag.ToString() + " :");

                message_text.Add(PLConstants.question_delete);
                message_text.Add("مدرک های پزشکی انتخاب شده :");
                message_text.AddRange(getDegreesDataForMessage());
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.delete, message_text);

                switch (pgs_dialog.user_choice)
                {
                    case PLConstants.enum_dialog_options.yes:
                        string delete_result = "";
                        medicineDegreeTableAdapter.DeleteDegrees(selectedDegreesToDataTable(), ref delete_result);
                        result_enum = PLEnumFuncs.opResultToEnum(delete_result);
                        pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.other);
                        switch (result_enum)
                        {
                            case PLConstants.enum_operation_results.success:
                                medicine_degree_grid.CellValueChanged -= medicine_degree_grid_CellValueChanged;
                                medicine_degree_grid.CurrentCellDirtyStateChanged -= medicine_degree_grid_CurrentCellDirtyStateChanged;
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

        private void d_select_all_checkbox_CheckedChanged(object sender, EventArgs e)//checked
        {
            if (d_select_all_checkbox.Checked)
            {
                for (int i = 0; i < medicine_degree_grid.Rows.Count; i++)
                {
                    medicine_degree_grid.Rows[i].Cells[d_str_sel_col].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < medicine_degree_grid.Rows.Count; i++)
                {
                    medicine_degree_grid.Rows[i].Cells[d_str_sel_col].Value = false;
                }
            }
        }

        private void medicine_degree_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)//checked
        {
            if (medicine_degree_grid.Rows.Count > 0)
            {
                PLGlobalFuncs.DGVAfterFilling(medicine_degree_grid, d_select_all_checkbox);
                medicine_degree_grid.CellValueChanged += medicine_degree_grid_CellValueChanged;
                medicine_degree_grid.CurrentCellDirtyStateChanged += medicine_degree_grid_CurrentCellDirtyStateChanged;
            }
        }

        private void medicine_degree_grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (medicine_degree_grid.IsCurrentCellDirty)
            {
                medicine_degree_grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void medicine_degree_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(medicine_degree_grid.Rows[e.RowIndex].Cells[d_str_sel_col].Value))
            {
                medicine_degree_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                medicine_degree_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
            }
            else
            {
                medicine_degree_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                medicine_degree_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.ControlText;
            }
        }

        # endregion

        // ///////////////////////// MedicineDegree METHODS
        #region MedicineDegree Methods

        private void getSelectedDegrees()
        {
            d_selected_id_s.Clear();
            int id_col=pIPDataSet.TDoctor.idColumn.Ordinal+1;
            for (int i=0;i<medicine_degree_grid.Rows.Count;i++)
            {
                if (Convert.ToBoolean(medicine_degree_grid.Rows[i].Cells[d_str_sel_col].Value))
                {
                    d_selected_id_s.Add(new KeyValuePair<int, int>(i, (int)medicine_degree_grid.Rows[i].Cells[id_col].Value));
                }
            }
        }

        private List<string> getDegreesDataForMessage()
        {
            int name_col = d_name_column.Index;
            
            List<string> message_text = new List<string>();
            for (int i = 0; i < d_selected_id_s.Count; i++)
            {
                message_text.Add((string)medicine_degree_grid.Rows[d_selected_id_s[i].Key].Cells[name_col].Value);
            }
            return message_text;
        }

        private DataTable selectedDegreesToDataTable()
        {
            DataTable s_d_t = new DataTable();
            s_d_t.Columns.Add(PLConstants.str_table_col_entity_id, typeof(int));
            foreach (KeyValuePair<int, int> d_id in d_selected_id_s)
            {
                s_d_t.Rows.Add(d_id.Value);
            }
            return s_d_t;
        }

        //private void afterMedicineDegreeGridFilled()
        //{
        //    PLGlobalFuncs.dataGridViewAfterFilling(medicine_degree_grid, d_select_all_checkbox);
        //    PLGlobalFuncs.createAllCheckBoxForDataGridView(medicine_degree_grid, d_select_all_checkbox);

        //    for (int i = 0; i < medicine_degree_grid.Rows.Count; i++)
        //    {
        //        medicine_degree_grid.Rows[i].Cells[d_str_sel_col].Value = false;
        //    }
        //}

        # endregion

    }
}
