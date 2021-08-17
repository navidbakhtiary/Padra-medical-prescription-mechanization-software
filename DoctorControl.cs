using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;

namespace PadraInsurancePrescription
{
    public partial class DoctorControl : UserControl
    {

        string d_str_sel_col;

        int d_index;
        PIPDataSet.TDoctorRow d_selected_data;
        List<KeyValuePair<int,int>> d_selected_id_s;//1-row number 2-id
        CheckBox d_select_all_checkbox;

        string d_search_name;
        string d_search_family;
        int d_search_degree;
        int d_search_id;

        PGSDialog pgs_dialog;
        PLConstants.enum_operation_results result_enum;

        PIPDataSetTableAdapters.TMedicineDegreeTableAdapter md_adapter;
        PIPDataSet.TMedicineDegreeDataTable degrees_data;

        public DoctorControl()
        {
            //column 0 is checkboxes and not in arrays
            InitializeComponent();
            PLGlobalFuncs.changeDGVSettings(doctor_grid);
            d_str_sel_col = "d_select_column";

            d_selected_id_s = new List<KeyValuePair<int, int>>();
            d_select_all_checkbox = new CheckBox();
            d_select_all_checkbox.CheckedChanged += d_select_all_checkbox_CheckedChanged;

            pgs_dialog = new PGSDialog(this);

            md_adapter = new PIPDataSetTableAdapters.TMedicineDegreeTableAdapter();
            initDegreeComboBox();
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(degree_comboBox);
        }

        // ///////////////////////////////////////////////////// Doctor

        // ///////////////////////// Doctor EVENTS
        # region doctor Events

        private void d_search_button_Click(object sender, EventArgs e)//checked
        {
            List<string> message_text = new List<string>();
            bool error = false;
            bool all_empty = true;
            d_search_name = "";
            d_search_family = "";
            d_search_degree = -1;
            d_search_id = -1;
            if (!Regex.IsMatch(d_search_name = name_text.Text.Trim(), PLConstants.reg_small_name))
            {
                error = true;
                message_text.Add(PLConstants.error_names);
            }
            else if(d_search_name.Length>0)
            {
                all_empty = false;
            }
            if (!Regex.IsMatch(d_search_family = family_text.Text.Trim(), PLConstants.reg_small_name))
            {
                error = true;
                message_text.Add(PLConstants.error_names);
            }
            else if(d_search_family.Length>0)
            {
                all_empty = false;
            }
            if (!Regex.IsMatch(id_text.Text.Trim(), PLConstants.reg_search_doctor_medical_id))
            {
                error = true;
                message_text.Add(PLConstants.error_id_just_number);
            }
            else if ((id_text.Text.Trim().Length>0))
            {
                all_empty = false;
                d_search_id = int.Parse(id_text.Text.Trim());
            }
            if (degree_comboBox.SelectedIndex > 0)
            {
                all_empty = false;
                d_search_degree = (int)degree_comboBox.SelectedValue;
            }
            doctor_grid.CellValueChanged -= doctor_grid_CellValueChanged;
            doctor_grid.CurrentCellDirtyStateChanged -= doctor_grid_CurrentCellDirtyStateChanged;
            if (error)
            {
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.error, message_text);
            }
            else if (all_empty)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_search_fields_not_empty);
            }
            else if (tDoctorTableAdapter.FillBySearch(pIPDataSet.TDoctor, d_search_name, d_search_family, d_search_degree, d_search_id) == 0)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record_after_search);
                d_select_all_checkbox.Visible = false;
            }
            doctor_grid.CellValueChanged += doctor_grid_CellValueChanged;
            doctor_grid.CurrentCellDirtyStateChanged += doctor_grid_CurrentCellDirtyStateChanged;
        }

        private void d_refresh_grid_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {//checked
            if (tDoctorTableAdapter.FillBySearch(pIPDataSet.TDoctor, d_search_name, d_search_family, d_search_degree, d_search_id) == 0)
            {
                pgs_dialog = new PGSDialog(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record_after_search);
                pgs_dialog.ShowDialog();
                d_select_all_checkbox.Visible = false;
            }
        }

        private void d_new_button_Click(object sender, EventArgs e)//checked
        {
            DoctorForm d_form = new DoctorForm(null, PLConstants.enum_data_operation.new_data, null);
            d_form.ShowDialog();
        }

        private void d_edit_button_Click(object sender, EventArgs e)//checked
        {
            getSelectedDoctors();
            if (d_selected_id_s.Count == 1)
            {
                d_index = d_selected_id_s[0].Key;
                d_selected_data = ((PIPDataSet.TDoctorRow)pIPDataSet.TDoctor.Rows[d_index]);
                DoctorForm d_form = new DoctorForm(d_selected_data, PLConstants.enum_data_operation.edit_data, null);
                d_form.ShowDialog();
            }
            else if (d_selected_id_s.Count > 1)
            {
                //d_selected_data = ((PIPDataSet.TDoctorRow)pIPDataSet.TDoctor.Rows[d_index]);
                DoctorForm d_form = new DoctorForm(null, PLConstants.enum_data_operation.batch_edit, selectedDoctorsToDataTable());
                d_form.ShowDialog();
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }
        }

        private void d_delete_doctor_Click(object sender, EventArgs e)//checked
        {
            getSelectedDoctors();
            if (d_selected_id_s.Count > 0)
            {
                List<string> message_text = new List<string>();
                message_text.Add(this.Tag.ToString() + " :");

                message_text.Add(PLConstants.question_delete);
                message_text.Add("پزشک های انتخاب شده :");
                message_text.AddRange(getDoctorsDataForMessage());
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.delete, message_text);

                switch (pgs_dialog.user_choice)
                {
                    case PLConstants.enum_dialog_options.yes:
                        string delete_result = "";
                        tDoctorTableAdapter.DeleteDoctors(selectedDoctorsToDataTable(), ref delete_result);
                        result_enum = PLEnumFuncs.opResultToEnum(delete_result);
                        pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.other);
                        switch (result_enum)
                        {
                            case PLConstants.enum_operation_results.success:
                                doctor_grid.CellValueChanged -= doctor_grid_CellValueChanged;
                                doctor_grid.CurrentCellDirtyStateChanged -= doctor_grid_CurrentCellDirtyStateChanged;
                                pIPDataSet.TDoctor.Clear();
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
                for (int i = 0; i < doctor_grid.Rows.Count; i++)
                {
                    doctor_grid.Rows[i].Cells[d_str_sel_col].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < doctor_grid.Rows.Count; i++)
                {
                    doctor_grid.Rows[i].Cells[d_str_sel_col].Value = false;
                }
            }
        }

        private void doctor_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)//checked
        {
            if (doctor_grid.Rows.Count > 0)
            {
                PLGlobalFuncs.DGVAfterFilling(doctor_grid, d_select_all_checkbox);
                doctor_grid.CellValueChanged += doctor_grid_CellValueChanged;
                doctor_grid.CurrentCellDirtyStateChanged += doctor_grid_CurrentCellDirtyStateChanged;
            }
        }

        private void doctor_grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (doctor_grid.IsCurrentCellDirty)
            {
                doctor_grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void doctor_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(doctor_grid.Rows[e.RowIndex].Cells[d_str_sel_col].Value))
            {
                doctor_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                doctor_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
            }
            else
            {
                doctor_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                doctor_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.ControlText;
            }
        }

        # endregion

        // ///////////////////////// doctor METHODS
        #region doctor Methods

        private void initDegreeComboBox()
        {
            degrees_data = md_adapter.GetAllDegrees();
            PIPDataSet.TMedicineDegreeRow md_first_row = degrees_data.NewTMedicineDegreeRow();
            md_first_row.id = -1;
            md_first_row.name = "--مدرک پزشکی--";
            degrees_data.Rows.InsertAt(md_first_row, 0);
            degree_comboBox.DataSource = degrees_data;
            degree_comboBox.DisplayMember = degrees_data.nameColumn.ColumnName;
            degree_comboBox.ValueMember = degrees_data.idColumn.ColumnName;
            degree_comboBox.SelectedIndex = 0;
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(degree_comboBox);
        }

        private void getSelectedDoctors()
        {
            d_selected_id_s.Clear();
            int id_col=pIPDataSet.TDoctor.idColumn.Ordinal+1;
            for (int i=0;i<doctor_grid.Rows.Count;i++)
            {
                if (Convert.ToBoolean(doctor_grid.Rows[i].Cells[d_str_sel_col].Value))
                {
                    d_selected_id_s.Add(new KeyValuePair<int,int>(i,(int)doctor_grid.Rows[i].Cells[id_col].Value));
                }
            }
        }

        private List<string> getDoctorsDataForMessage()
        {
            int medical_id_col = d_medical_id_column.Index;
            int name_col = d_name_column.Index;
            int family_col = d_family_name_column.Index;
            List<string> message_text = new List<string>();
            for (int i = 0; i < d_selected_id_s.Count; i++)
            {
                message_text.Add(doctor_grid.Rows[d_selected_id_s[i].Key].Cells[medical_id_col].Value.ToString()+"  "+
                                 (string)doctor_grid.Rows[d_selected_id_s[i].Key].Cells[name_col].Value+" "+
                                 (string)doctor_grid.Rows[d_selected_id_s[i].Key].Cells[family_col].Value);
            }
            return message_text;
        }

        private DataTable selectedDoctorsToDataTable()
        {
            DataTable s_d_t = new DataTable();
            s_d_t.Columns.Add(PLConstants.str_table_col_entity_id, typeof(int));
            foreach (KeyValuePair<int, int> d_id in d_selected_id_s)
            {
                s_d_t.Rows.Add(d_id.Value);
            }
            return s_d_t;
        }

        //private void afterDoctorGridFilled()
        //{
        //    PLGlobalFuncs.dataGridViewAfterFilling(doctor_grid, d_select_all_checkbox);
        //    PLGlobalFuncs.createAllCheckBoxForDataGridView(doctor_grid, d_select_all_checkbox);

        //    for (int i = 0; i < doctor_grid.Rows.Count; i++)
        //    {
        //        doctor_grid.Rows[i].Cells[d_str_sel_col].Value = false;
        //    }
        //}

        # endregion

    }
}
