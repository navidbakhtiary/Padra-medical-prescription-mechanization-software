using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;

namespace PadraInsurancePrescription
{
    public partial class MedicalCenterControl : UserControl
    {

        string m_str_sel_col;

        int m_index;
        PIPDataSet.TMedicalCenterRow m_selected_data;
        List<KeyValuePair<int,int>> m_selected_id_s;//1-row number 2-id
        CheckBox m_select_all_checkbox;

        string m_search_name;
        string m_search_national;
        int d_search_type;

        PGSDialog pgs_dialog;
        PLConstants.enum_operation_results result_enum;

        PIPDataSetTableAdapters.TClinicTypeTableAdapter ct_adapter;
        PIPDataSet.TClinicTypeDataTable types_data;

        public MedicalCenterControl()
        {
            //column 0 is checkboxes and not in arrays
            InitializeComponent();
            PLGlobalFuncs.changeDGVSettings(medical_center_grid);
            m_str_sel_col = "m_select_column";

            m_selected_id_s = new List<KeyValuePair<int, int>>();
            m_select_all_checkbox = new CheckBox();
            m_select_all_checkbox.CheckedChanged += m_select_all_checkbox_CheckedChanged;

            pgs_dialog = new PGSDialog(this);

            ct_adapter = new PIPDataSetTableAdapters.TClinicTypeTableAdapter();
            initTypeComboBox();
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(type_comboBox);
        }

        // ///////////////////////////////////////////////////// MedicalCenter

        // ///////////////////////// MedicalCenter EVENTS
        # region medical center Events

        private void m_search_button_Click(object sender, EventArgs e)//checked
        {
            List<string> message_text = new List<string>();
            bool error = false;
            bool all_empty = true;
            m_search_name = "";
            m_search_national = "";
            d_search_type = -1;
            
            if (!Regex.IsMatch(m_search_name = name_text.Text.Trim(), PLConstants.reg_small_name))
            {
                error = true;
                message_text.Add(PLConstants.error_names);
            }
            else if(m_search_name.Length>0)
            {
                all_empty = false;
            }
            if (!Regex.IsMatch(m_search_national = national_id_text.Text.Trim(), PLConstants.reg_search_id_10))
            {
                error = true;
                message_text.Add(PLConstants.error_names);
            }
            else if(m_search_national.Length>0)
            {
                all_empty = false;
            }
            if (type_comboBox.SelectedIndex > 0)
            {
                all_empty = false;
                d_search_type = (int)type_comboBox.SelectedValue;
            }
            medical_center_grid.CellValueChanged -= medical_center_grid_CellValueChanged;
            medical_center_grid.CurrentCellDirtyStateChanged -= medical_center_grid_CurrentCellDirtyStateChanged;
            if (error)
            {
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.error, message_text);
            }
            else if (all_empty)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_search_fields_not_empty);
            }
            else if (tMedicalCenterTableAdapter.FillBySearch(pIPDataSet.TMedicalCenter, m_search_name, m_search_national, d_search_type) == 0)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record_after_search);
                m_select_all_checkbox.Visible = false;
            }
            medical_center_grid.CellValueChanged += medical_center_grid_CellValueChanged;
            medical_center_grid.CurrentCellDirtyStateChanged += medical_center_grid_CurrentCellDirtyStateChanged;
        }

        private void m_refresh_grid_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {//checked
            if (tMedicalCenterTableAdapter.FillBySearch(pIPDataSet.TMedicalCenter, m_search_name, m_search_national, d_search_type) == 0)
            {
                pgs_dialog = new PGSDialog(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record_after_search);
                pgs_dialog.ShowDialog();
                m_select_all_checkbox.Visible = false;
            }
        }

        private void m_new_button_Click(object sender, EventArgs e)//checked
        {
            MedicalCenterForm m_form = new MedicalCenterForm(null, PLConstants.enum_data_operation.new_data, null);
            m_form.ShowDialog();
        }

        private void m_edit_button_Click(object sender, EventArgs e)//checked
        {
            getSelectedCenters();
            if (m_selected_id_s.Count == 1)
            {
                m_index = m_selected_id_s[0].Key;
                m_selected_data = ((PIPDataSet.TMedicalCenterRow)pIPDataSet.TMedicalCenter.Rows[m_index]);
                MedicalCenterForm m_form = new MedicalCenterForm(m_selected_data, PLConstants.enum_data_operation.edit_data, null);
                m_form.ShowDialog();
            }
            else if (m_selected_id_s.Count > 1)
            {
                //d_selected_data = ((PIPDataSet.TDoctorRow)pIPDataSet.TDoctor.Rows[d_index]);
                MedicalCenterForm m_form = new MedicalCenterForm(null, PLConstants.enum_data_operation.batch_edit, selectedCentersToDataTable());
                m_form.ShowDialog();
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }
        }

        private void m_delete_doctor_Click(object sender, EventArgs e)//checked
        {
            getSelectedCenters();
            if (m_selected_id_s.Count > 0)
            {
                List<string> message_text = new List<string>();
                message_text.Add(this.Tag.ToString() + " :");

                message_text.Add(PLConstants.question_delete);
                message_text.Add("مراکز انتخاب شده :");
                message_text.AddRange(getCentersDataForMessage());
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.delete, message_text);

                switch (pgs_dialog.user_choice)
                {
                    case PLConstants.enum_dialog_options.yes:
                        string delete_result = "";
                        tMedicalCenterTableAdapter.DeleteMedicalCenters(selectedCentersToDataTable(), ref delete_result);
                        result_enum = PLEnumFuncs.opResultToEnum(delete_result);
                        pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.other);
                        switch (result_enum)
                        {
                            case PLConstants.enum_operation_results.success:
                                medical_center_grid.CellValueChanged -= medical_center_grid_CellValueChanged;
                                medical_center_grid.CurrentCellDirtyStateChanged -= medical_center_grid_CurrentCellDirtyStateChanged;
                                pIPDataSet.TMedicalCenter.Clear();
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

        private void m_select_all_checkbox_CheckedChanged(object sender, EventArgs e)//checked
        {
            if (m_select_all_checkbox.Checked)
            {
                for (int i = 0; i < medical_center_grid.Rows.Count; i++)
                {
                    medical_center_grid.Rows[i].Cells[m_str_sel_col].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < medical_center_grid.Rows.Count; i++)
                {
                    medical_center_grid.Rows[i].Cells[m_str_sel_col].Value = false;
                }
            }
        }

        private void medical_center_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)//checked
        {
            if (medical_center_grid.Rows.Count > 0)
            {
                PLGlobalFuncs.DGVAfterFilling(medical_center_grid, m_select_all_checkbox);
                medical_center_grid.CellValueChanged += medical_center_grid_CellValueChanged;
                medical_center_grid.CurrentCellDirtyStateChanged += medical_center_grid_CurrentCellDirtyStateChanged;
            }
        }

        private void medical_center_grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (medical_center_grid.IsCurrentCellDirty)
            {
                medical_center_grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void medical_center_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(medical_center_grid.Rows[e.RowIndex].Cells[m_str_sel_col].Value))
            {
                medical_center_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                medical_center_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
            }
            else
            {
                medical_center_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                medical_center_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.ControlText;
            }
        }

        # endregion

        // ///////////////////////// medical center METHODS
        #region medical center Methods

        private void initTypeComboBox()
        {
            types_data = ct_adapter.GetAllTypes();
            PIPDataSet.TClinicTypeRow mc_first_row = types_data.NewTClinicTypeRow();
            mc_first_row.id = -1;
            mc_first_row.name = "--نوع مرکز--";
            types_data.Rows.InsertAt(mc_first_row, 0);
            type_comboBox.DataSource = types_data;
            type_comboBox.DisplayMember = types_data.nameColumn.ColumnName;
            type_comboBox.ValueMember = types_data.idColumn.ColumnName;
            type_comboBox.SelectedIndex = 0;
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(type_comboBox);
        }

        private void getSelectedCenters()
        {
            m_selected_id_s.Clear();
            int id_col = m_id_column.Index;
            //int id_col=pIPDataSet.TMedicalCenter.idColumn.Ordinal+1;
            for (int i=0;i<medical_center_grid.Rows.Count;i++)
            {
                if (Convert.ToBoolean(medical_center_grid.Rows[i].Cells[m_str_sel_col].Value))
                {
                    m_selected_id_s.Add(new KeyValuePair<int,int>(i,(int)medical_center_grid.Rows[i].Cells[id_col].Value));
                }
            }
        }

        private List<string> getCentersDataForMessage()
        {
            int national_id_col = m_national_id_column.Index;
            int name_col = m_name_column.Index;
            int city_col = m_city_name_column.Index;
            List<string> message_text = new List<string>();
            for (int i = 0; i < m_selected_id_s.Count; i++)
            {
                message_text.Add(((medical_center_grid.Rows[m_selected_id_s[i].Key].Cells[national_id_col].Value!=DBNull.Value)?(string)medical_center_grid.Rows[m_selected_id_s[i].Key].Cells[national_id_col].Value+" ":"")+
                                 (string)medical_center_grid.Rows[m_selected_id_s[i].Key].Cells[name_col].Value+" "+
                                 (string)medical_center_grid.Rows[m_selected_id_s[i].Key].Cells[city_col].Value);
            }
            return message_text;
        }

        private DataTable selectedCentersToDataTable()
        {
            DataTable s_mc_t = new DataTable();
            s_mc_t.Columns.Add(PLConstants.str_table_col_entity_id, typeof(int));
            foreach (KeyValuePair<int, int> d_id in m_selected_id_s)
            {
                s_mc_t.Rows.Add(d_id.Value);
            }
            return s_mc_t;
        }

        # endregion

    }
}
