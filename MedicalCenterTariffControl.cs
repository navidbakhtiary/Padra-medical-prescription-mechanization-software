using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PadraInsurancePrescription
{
    public partial class MedicalCenterTariffControl : UserControl
    {
        string c_str_sel_col;

        int c_index_two;
        int c_selected_id;
        int c_index_one;
        bool c_is_switched;
        PIPDataSet.SMedicalCenterRow c_data_row;
        List<KeyValuePair<int,int>> c_selected_id_s;//1-row number 2-id
        CheckBox c_select_all_checkbox;

        PGSDialog pgs_dialog;

        PIPDataSetTableAdapters.TClinicTypeTableAdapter ct_adapter;
        PIPDataSet.TClinicTypeDataTable ct_data;

        public MedicalCenterTariffControl()
        {
            //column 0 is checkboxes and not in arrays
            InitializeComponent();
            PLGlobalFuncs.changeDGVSettings(center_grid);
            c_str_sel_col = "c_select_column";

            c_selected_id_s = new List<KeyValuePair<int, int>>();
            c_selected_id = -1;
            c_select_all_checkbox = new CheckBox();
            //c_select_all_checkbox.CheckedChanged += c_select_all_checkbox_CheckedChanged;
            c_select_all_checkbox.Visible = false;
            c_index_two = -1;

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
            else if (all_empty)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_search_fields_not_empty);
            }
            else if (sMedicalCenterTableAdapter.FillBySearch(pIPDataSet.SMedicalCenter, c_search_name, c_search_national, c_search_type) == 0)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record_after_search);
                c_select_all_checkbox.Visible = false;
            }
            center_grid.CellValueChanged += center_grid_CellValueChanged;
            center_grid.CurrentCellDirtyStateChanged += center_grid_CurrentCellDirtyStateChanged;
        }

        private void c_tariffs_button_Click(object sender, EventArgs e)
        {
            //getSelectedCenter();
            if (c_selected_id>-1)
            {
                MedicalCenterTariffForm mct_form = new MedicalCenterTariffForm(c_data_row);
                mct_form.ShowDialog();
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }
        }

        private void center_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (center_grid.Rows.Count > 0)
            {
                afterCenterGridFilled();
                center_grid.CellValueChanged += center_grid_CellValueChanged;
                center_grid.CurrentCellDirtyStateChanged += center_grid_CurrentCellDirtyStateChanged;
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
                        c_data_row = (PIPDataSet.SMedicalCenterRow)pIPDataSet.SMedicalCenter.Rows[c_index_two];
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
                    c_data_row = null;
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

    }
}
