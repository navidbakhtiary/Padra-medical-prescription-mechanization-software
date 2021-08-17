using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;

namespace PadraInsurancePrescription
{
    public partial class PresDataParametersControl : UserControl
    {

        string p_str_sel_col;

        int p_index;
        PIPDataSet.TPresDataParametersRow p_selected_data;
        List<KeyValuePair<int,int>> p_selected_id_s;//1-row number 2-id
        CheckBox p_select_all_checkbox;

        int p_search_type,p_search_part,p_search_ins,p_search_sec;

        PGSDialog pgs_dialog;
        PLConstants.enum_operation_results result_enum;

        PIPDataSetTableAdapters.TClinicTypeTableAdapter ct_adapter;
        PIPDataSet.TClinicTypeDataTable ct_data;
        PIPDataSetTableAdapters.SClinicPartTableAdapter cp_adapter;
        PIPDataSet.SClinicPartDataTable cp_data;
        PIPDataSetTableAdapters.TInsuranceTableAdapter ins_adapter;
        PIPDataSet.TInsuranceDataTable ins_data;
        PIPDataSetTableAdapters.TInsuranceSectorTableAdapter sec_adapter;
        PIPDataSet.TInsuranceSectorDataTable sec_data;

        public PresDataParametersControl()
        {
            //column 0 is checkboxes and not in arrays
            InitializeComponent();
            PLGlobalFuncs.changeDGVSettings(params_grid);
            p_str_sel_col = "p_select_column";

            p_selected_id_s = new List<KeyValuePair<int, int>>();
            p_select_all_checkbox = new CheckBox();
            p_select_all_checkbox.CheckedChanged += p_select_all_checkbox_CheckedChanged;

            pgs_dialog = new PGSDialog(this);

            ct_adapter = new PIPDataSetTableAdapters.TClinicTypeTableAdapter();
            cp_adapter = new PIPDataSetTableAdapters.SClinicPartTableAdapter();
            ins_adapter = new PIPDataSetTableAdapters.TInsuranceTableAdapter();
            sec_adapter = new PIPDataSetTableAdapters.TInsuranceSectorTableAdapter();
            ct_data = new PIPDataSet.TClinicTypeDataTable();
            cp_data = new PIPDataSet.SClinicPartDataTable();
            ins_data = new PIPDataSet.TInsuranceDataTable();
            sec_data = new PIPDataSet.TInsuranceSectorDataTable();
            initComboBoxes();
        }

        // ///////////////////////// Params EVENTS
        # region params Events

        private void p_search_button_Click(object sender, EventArgs e)//checked
        {
            List<string> message_text = new List<string>();
            p_search_type = p_search_part = p_search_ins = p_search_sec = -1;

            if (type_comboBox.SelectedIndex > 0) { p_search_type = (int)type_comboBox.SelectedValue; }
            if (part_comboBox.SelectedIndex > 0) { p_search_part = (int)part_comboBox.SelectedValue; }
            if (insurance_comboBox.SelectedIndex > 0) { p_search_ins = (int)insurance_comboBox.SelectedValue; }
            if (sector_comboBox.SelectedIndex > 0) { p_search_sec = (int)sector_comboBox.SelectedValue; }

            if (p_search_type + p_search_part + p_search_ins + p_search_sec > 0)
            {
                params_grid.CellValueChanged -= params_grid_CellValueChanged;
                params_grid.CurrentCellDirtyStateChanged -= params_grid_CurrentCellDirtyStateChanged;
                if (tPresDataParametersTableAdapter.FillBySearch(pIPDataSet.TPresDataParameters, p_search_type, p_search_part, p_search_ins, p_search_sec) == 0)
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record_after_search);
                    p_select_all_checkbox.Visible = false;
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_search_fields_not_empty);
            }
        }

        private void p_new_button_Click(object sender, EventArgs e)//checked
        {
            PresDataParametersForm pd_form = new PresDataParametersForm(null, PLConstants.enum_data_operation.new_data, null);
            pd_form.ShowDialog();
        }

        private void p_edit_button_Click(object sender, EventArgs e)//checked
        {
            getSelectedParams();
            if (p_selected_id_s.Count == 1)
            {
                p_index = p_selected_id_s[0].Key;
                p_selected_data = ((PIPDataSet.TPresDataParametersRow)pIPDataSet.TPresDataParameters.Rows[p_index]);
                PresDataParametersForm pd_form = new PresDataParametersForm(p_selected_data, PLConstants.enum_data_operation.edit_data, null);
                pd_form.ShowDialog();
            }
            else if (p_selected_id_s.Count > 1)
            {
                PresDataParametersForm pd_form = new PresDataParametersForm(null, PLConstants.enum_data_operation.batch_edit, selectedParamsToDataTable());
                pd_form.ShowDialog();
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }
        }

        private void p_delete_doctor_Click(object sender, EventArgs e)//checked
        {
            getSelectedParams();
            if (p_selected_id_s.Count > 0)
            {
                List<string> message_text = new List<string>();
                message_text.Add(this.Tag.ToString() + " :");

                message_text.Add(PLConstants.question_delete);
                message_text.Add("تنظیمات انتخاب شده :");
                message_text.AddRange(getParamsDataForMessage());
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.delete, message_text);

                switch (pgs_dialog.user_choice)
                {
                    case PLConstants.enum_dialog_options.yes:
                        string delete_result = "";
                        tPresDataParametersTableAdapter.DeleteDataParams(selectedParamsToDataTable(), ref delete_result);
                        result_enum = PLEnumFuncs.opResultToEnum(delete_result);
                        pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.other);
                        switch (result_enum)
                        {
                            case PLConstants.enum_operation_results.success:
                                params_grid.CellValueChanged -= params_grid_CellValueChanged;
                                params_grid.CurrentCellDirtyStateChanged -= params_grid_CurrentCellDirtyStateChanged;
                                pIPDataSet.TPresDataParameters.Clear();
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

        private void type_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (type_comboBox.SelectedIndex > 0)
            {
                initPartComboBox((int)type_comboBox.SelectedValue);
                part_comboBox.Enabled = true;
            }
            else
            {
                part_comboBox.Enabled = false;
            }
        }

        private void insurance_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (insurance_comboBox.SelectedIndex > 0)
            {
                initInsSectorComboBox((int)insurance_comboBox.SelectedValue);
                sector_comboBox.Enabled = true;
            }
            else
            {
                sector_comboBox.Enabled = false;
            }
        }

        private void p_select_all_checkbox_CheckedChanged(object sender, EventArgs e)//checked
        {
            if (p_select_all_checkbox.Checked)
            {
                for (int i = 0; i < params_grid.Rows.Count; i++)
                {
                    params_grid.Rows[i].Cells[p_str_sel_col].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < params_grid.Rows.Count; i++)
                {
                    params_grid.Rows[i].Cells[p_str_sel_col].Value = false;
                }
            }
        }

        private void params_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)//checked
        {
            if (params_grid.Rows.Count > 0)
            {
                PLGlobalFuncs.DGVAfterFilling(params_grid, p_select_all_checkbox);
                params_grid.CellValueChanged += params_grid_CellValueChanged;
                params_grid.CurrentCellDirtyStateChanged += params_grid_CurrentCellDirtyStateChanged;
            }
        }

        private void params_grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (params_grid.IsCurrentCellDirty)
            {
                params_grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void params_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(params_grid.Rows[e.RowIndex].Cells[p_str_sel_col].Value))
            {
                params_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                params_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
            }
            else
            {
                params_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                params_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.ControlText;
            }
        }

        # endregion

        // ///////////////////////// Params METHODS
        #region Params Methods

        private void initComboBoxes()
        {
            ct_data = ct_adapter.GetAllTypes();
            PIPDataSet.TClinicTypeRow mc_first_row = ct_data.NewTClinicTypeRow();
            mc_first_row.id = -1;
            mc_first_row.name = "--نوع مرکز--";
            ct_data.Rows.InsertAt(mc_first_row, 0);
            type_comboBox.DataSource = ct_data;
            type_comboBox.DisplayMember = ct_data.nameColumn.ColumnName;
            type_comboBox.ValueMember = ct_data.idColumn.ColumnName;
            type_comboBox.SelectedIndex = 0;
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(type_comboBox);

            ins_data = ins_adapter.GetAllInsurances();
            PIPDataSet.TInsuranceRow i_first_row = ins_data.NewTInsuranceRow();
            i_first_row.id = -1;
            i_first_row.name = "---شرکت بیمه---";
            ins_data.Rows.InsertAt(i_first_row, 0);
            insurance_comboBox.DataSource = ins_data;
            insurance_comboBox.DisplayMember = ins_data.nameColumn.ColumnName;
            insurance_comboBox.ValueMember = ins_data.idColumn.ColumnName;
            insurance_comboBox.SelectedIndex = 0;
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(insurance_comboBox);
        }

        private void initPartComboBox(int selected_type)//checked
        {
            cp_adapter.FillByClinicType(cp_data,selected_type);
            PIPDataSet.SClinicPartRow p_first_row = cp_data.NewSClinicPartRow();
            p_first_row.id = -1;
            p_first_row.name = "--بخش درمانی از مرکز--";
            cp_data.Rows.InsertAt(p_first_row, 0);
            part_comboBox.DataSource = cp_data;
            part_comboBox.DisplayMember = cp_data.nameColumn.ColumnName;
            part_comboBox.ValueMember = cp_data.idColumn.ColumnName;
            part_comboBox.SelectedIndex = 0;
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(part_comboBox);
        }
        private void initInsSectorComboBox(int selected_insurance)//checked
        {
            sec_data = sec_adapter.GetAllSectors(selected_insurance);
            PIPDataSet.TInsuranceSectorRow s_first_row = sec_data.NewTInsuranceSectorRow();
            s_first_row.id = -1;
            s_first_row.name = "--صندوق بیمه--";
            sec_data.Rows.InsertAt(s_first_row, 0);
            sector_comboBox.DataSource = sec_data;
            sector_comboBox.DisplayMember = sec_data.nameColumn.ColumnName;
            sector_comboBox.ValueMember = sec_data.idColumn.ColumnName;
            sector_comboBox.SelectedIndex = 0;
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(sector_comboBox);
        }

        private void getSelectedParams()
        {
            p_selected_id_s.Clear();
            int id_col=pIPDataSet.TDoctor.idColumn.Ordinal+1;
            for (int i=0;i<params_grid.Rows.Count;i++)
            {
                if (Convert.ToBoolean(params_grid.Rows[i].Cells[p_str_sel_col].Value))
                {
                    p_selected_id_s.Add(new KeyValuePair<int,int>(i,(int)params_grid.Rows[i].Cells[id_col].Value));
                }
            }
        }

        private List<string> getParamsDataForMessage()
        {
            int type_col = p_ctype_name_column.Index;
            int part_col = p_cpart_name_column.Index;
            int ins_col = p_ins_name_column.Index;
            int sec_col = p_sec_name_column.Index;
            List<string> message_text = new List<string>();
            for (int i = 0; i < p_selected_id_s.Count; i++)
            {
                message_text.Add(params_grid.Rows[p_selected_id_s[i].Key].Cells[type_col].Value.ToString() + "  " +
                                 params_grid.Rows[p_selected_id_s[i].Key].Cells[part_col].Value.ToString() + " " +
                                 params_grid.Rows[p_selected_id_s[i].Key].Cells[ins_col].Value.ToString() + " " +
                                 params_grid.Rows[p_selected_id_s[i].Key].Cells[sec_col].Value.ToString());
            }
            return message_text;
        }

        private DataTable selectedParamsToDataTable()
        {
            DataTable s_d_t = PLGlobalFuncs.emptyIntIDsDataTable();
            foreach (KeyValuePair<int, int> d_id in p_selected_id_s)
            {
                s_d_t.Rows.Add(d_id.Value);
            }
            return s_d_t;
        }

        # endregion


    }
}
