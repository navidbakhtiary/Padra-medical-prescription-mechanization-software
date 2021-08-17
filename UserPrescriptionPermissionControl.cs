using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace PadraInsurancePrescription
{
    public partial class UserPrescriptionPermissionControl : UserControl
    {
        string u_str_sel_col;
        string c_str_sel_col;
        string p_str_sel_col;
        string d_str_sel_col;

        List<KeyValuePair<int, int>> u_selected_id_s;//1-row number 2-id
        CheckBox u_select_all_checkbox;

        List<KeyValuePair<int,int>> c_selected_id_s;//1-row number 2-id
        CheckBox c_select_all_checkbox;

        List<KeyValuePair<int, int>> p_selected_id_s;//1-row number 2-id
        CheckBox p_select_all_checkbox;

        List<KeyValuePair<int, int>> d_selected_id_s;//1-row number 2-id
        CheckBox d_select_all_checkbox;

        PGSDialog pgs_dialog;
        string action_result;
        PLConstants.enum_operation_results result_enum;
        SYMPermissionForm permission_info_form;

        PIPDataSetTableAdapters.UserPermissionsTableAdapter permissions_adapter;

        public UserPrescriptionPermissionControl()
        {
            //column 0 is checkboxes and not in arrays
            InitializeComponent();
            PLGlobalFuncs.changeDGVSettings(user_grid, center_grid, part_grid, doctor_grid);
            u_str_sel_col = u_select_column.Name;
            c_str_sel_col = c_select_column.Name;
            p_str_sel_col = p_select_column.Name;
            d_str_sel_col = d_select_column.Name;

            u_selected_id_s = new List<KeyValuePair<int, int>>();
            u_select_all_checkbox = new CheckBox();
            u_select_all_checkbox.CheckedChanged += u_select_all_checkbox_CheckedChanged;

            c_selected_id_s = new List<KeyValuePair<int, int>>();
            c_select_all_checkbox = new CheckBox();
            c_select_all_checkbox.CheckedChanged += c_select_all_checkbox_CheckedChanged;

            p_selected_id_s = new List<KeyValuePair<int, int>>();
            p_select_all_checkbox = new CheckBox();
            p_select_all_checkbox.CheckedChanged += p_select_all_checkbox_CheckedChanged;

            d_selected_id_s = new List<KeyValuePair<int, int>>();
            d_select_all_checkbox = new CheckBox();
            d_select_all_checkbox.CheckedChanged += d_select_all_checkbox_CheckedChanged;

            pgs_dialog = new PGSDialog(this);
            permission_info_form = new SYMPermissionForm();

            permissions_adapter = new PIPDataSetTableAdapters.UserPermissionsTableAdapter();
        }

        private void enableFormControls(bool center, bool part, bool doctor)
        {
            center_grid.Enabled = c_show_parts_button.Enabled = c_other_parts_button.Enabled = c_delete_button.Enabled = c_change_button.Enabled = center;
            part_grid.Enabled = p_show_doctors_button.Enabled = p_other_doctors_button.Enabled = p_delete_button.Enabled = p_change_button.Enabled = part;
            doctor_grid.Enabled = d_delete_button.Enabled = d_change_button.Enabled = d_add_button.Enabled = doctor;
            if (!center)
            {
                pIPDataSet.SMedicalCenter.Rows.Clear();
                c_selected_id_s.Clear();
            }
            if(!part)
            {
                pIPDataSet.TMedicalCenterPart.Rows.Clear();
                p_selected_id_s.Clear();
            }
            if (!doctor)
            {
                pIPDataSet.TMedicalCenterDoctor.Rows.Clear();
                d_selected_id_s.Clear();
            }
        }
        private void enableCenterControls(bool for_new_center)
        {
            c_delete_button.Enabled = c_show_parts_button.Enabled = c_change_button.Enabled = !for_new_center;
        }
        private void enablePartControls(bool for_new_part)
        {
            p_delete_button.Enabled = p_show_doctors_button.Enabled = p_change_button.Enabled = !for_new_part;
        }
        private void enableDoctorControls(bool for_new_doctor)
        {
            d_delete_button.Enabled = d_change_button.Enabled = !(d_add_button.Enabled = for_new_doctor);
        }

        ////////////////////////////////////////////////// User
        ////////////////////////// User EVENTS
        # region User Events

        private void u_search_button_Click(object sender, EventArgs e)
        {
            List<string> message_text = new List<string>();
            bool error = false;
            bool all_empty = true;
            string u_search_name = "";
            string u_search_family = "";
            int u_search_id = -1;
            if (!Regex.IsMatch(u_search_name = u_name_text.Text.Trim(), PLConstants.reg_small_name))
            {
                error = true;
                message_text.Add(PLConstants.error_names);
            }
            else if (u_search_name.Length > 0)
            {
                all_empty = false;
            }
            if (!Regex.IsMatch(u_search_family = u_family_name_text.Text.Trim(), PLConstants.reg_small_name))
            {
                error = true;
                message_text.Add(PLConstants.error_names);
            }
            else if (u_search_family.Length > 0)
            {
                all_empty = false;
            }
            if (!Regex.IsMatch(u_id_text.Text.Trim(), PLConstants.reg_search_id_10))
            {
                error = true;
                message_text.Add(PLConstants.error_id_just_number);
            }
            else if ((u_id_text.Text.Trim().Length > 0))
            {
                all_empty = false;
                u_search_id = int.Parse(u_id_text.Text.Trim());
            }

            user_grid.CellValueChanged -= user_grid_CellValueChanged;
            user_grid.CurrentCellDirtyStateChanged -= user_grid_CurrentCellDirtyStateChanged;
            if (error)
            {
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.error, message_text);
            }
            else if (all_empty)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_search_fields_not_empty);
            }
            else if (tSystemUserTableAdapter.FillBySearch(pIPDataSet.TSystemUser, u_search_id, u_search_name, u_search_family) == 0)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record_after_search);
                u_select_all_checkbox.Visible = false;
            }
            user_grid.CellValueChanged += user_grid_CellValueChanged;
            user_grid.CurrentCellDirtyStateChanged += user_grid_CurrentCellDirtyStateChanged;
        }

        private void u_select_all_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (u_select_all_checkbox.Checked)
            {
                for (int i = 0; i < user_grid.Rows.Count; i++)
                {
                    user_grid.Rows[i].Cells[u_str_sel_col].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < user_grid.Rows.Count; i++)
                {
                    user_grid.Rows[i].Cells[u_str_sel_col].Value = false;
                }
            }
        }
        private void user_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            PLGlobalFuncs.DGVAfterFilling(user_grid, u_select_all_checkbox);
            user_grid.CellValueChanged += user_grid_CellValueChanged;
            user_grid.CurrentCellDirtyStateChanged += user_grid_CurrentCellDirtyStateChanged;
        }
        private void user_grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (user_grid.IsCurrentCellDirty)
            {
                user_grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void user_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(user_grid.Rows[e.RowIndex].Cells[u_str_sel_col].Value))
            {
                user_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                user_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
            }
            else
            {
                user_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                user_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.ControlText;
            }
        }

        private void u_activated_button_Click(object sender, EventArgs e)
        {
            getSelectedUsers();
            if (u_selected_id_s.Count == 1)
            {
                center_grid.CellValueChanged -= center_grid_CellValueChanged;
                center_grid.CurrentCellDirtyStateChanged -= center_grid_CurrentCellDirtyStateChanged;
                if (sMedicalCenterTableAdapter.FillByUser(pIPDataSet.SMedicalCenter, u_selected_id_s[0].Value, true) == 0)
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record);
                    enableFormControls(false, false, false);
                }
                else
                {
                    enableFormControls(true, false, false);
                    enableCenterControls(false);
                    center_grid.Select();
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_choose_one_user);
            }
        }
        private void u_other_centers_button_Click(object sender, EventArgs e)
        {
            getSelectedUsers();
            if (u_selected_id_s.Count == 1)
            {
                center_grid.CellValueChanged -= center_grid_CellValueChanged;
                center_grid.CurrentCellDirtyStateChanged -= center_grid_CurrentCellDirtyStateChanged;
                if (sMedicalCenterTableAdapter.FillByUser(pIPDataSet.SMedicalCenter, u_selected_id_s[0].Value, false) == 0)
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record);
                    enableFormControls(false, false, false);
                }
                else
                {
                    enableFormControls(true, false, false);
                    enableCenterControls(true);
                    center_grid.Select();
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_choose_one_user);
            }
        }
        private void u_change_button_Click(object sender, EventArgs e)
        {
            getSelectedUsers();
            if (u_selected_id_s.Count > 0)
            {
                permission_info_form.ShowDialog();
                if (permission_info_form.go_to_action)
                {
                    permissions_adapter.UpdatePermissionsInfo(selectedUsersToDataTable(), permission_info_form.sel_years, permission_info_form.sel_monthes, permission_info_form.sel_sectors,(byte?)permission_info_form.sel_contract_status, ref action_result);
                    result_enum = PLEnumFuncs.opResultToEnum(action_result);
                    pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.other);
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }
        }
        private void u_delete_button_Click(object sender, EventArgs e)
        {
            getSelectedUsers();
            if (u_selected_id_s.Count > 0)
            {
                permissions_adapter.DeletePermissionsByUsers(selectedUsersToDataTable(), ref action_result);
                result_enum = PLEnumFuncs.opResultToEnum(action_result);
                pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.other);
                if (result_enum == PLConstants.enum_operation_results.success)
                {
                    enableFormControls(false, false, false);
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }
        }

        # endregion

        /////////////////////////// User METHODS
        #region User Methods

        private void getSelectedUsers()
        {
            u_selected_id_s.Clear();
            int id_col = u_user_code_column.Index;
            for (int i=0;i<user_grid.Rows.Count;i++)
            {
                if (Convert.ToBoolean(user_grid.Rows[i].Cells[u_str_sel_col].Value))
                {
                    u_selected_id_s.Add(new KeyValuePair<int,int>(i,(int)user_grid.Rows[i].Cells[id_col].Value));
                }
            }
        }
        private DataTable selectedUsersToDataTable()
        {
            DataTable s_u_t = PLGlobalFuncs.emptyIntIDsDataTable();
            foreach (KeyValuePair<int, int> u_id in u_selected_id_s)
            {
                s_u_t.Rows.Add(u_id.Value);
            }
            return s_u_t;
        }

        #endregion

        /////////////////////////////////////////////////////// Center 
        /////////////////////////// Center EVENTS
        #region Center Events

        private void c_show_parts_button_Click(object sender, EventArgs e)
        {
            getSelectedCenters();
            if (c_selected_id_s.Count == 1)
            {
                part_grid.CellValueChanged -= part_grid_CellValueChanged;
                part_grid.CurrentCellDirtyStateChanged -= part_grid_CurrentCellDirtyStateChanged;
                bool? center_has_part = false;
                if (tMedicalCenterPartTableAdapter.FillByUser(pIPDataSet.TMedicalCenterPart, u_selected_id_s[0].Value, c_selected_id_s[0].Value, true, ref center_has_part) == 0)
                {
                    if (!(bool)center_has_part)
                    {
                        if (tMedicalCenterDoctorsTableAdapter.FillWithoutPartByUser(pIPDataSet.TMedicalCenterDoctor, u_selected_id_s[0].Value, c_selected_id_s[0].Value, true) == 0)
                        {
                            pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record);
                            enableFormControls(true, false, false);
                            enableCenterControls(false);
                        }
                        else
                        {
                            enableFormControls(true, false, true);
                            enableDoctorControls(false);
                            doctor_grid.Select();
                        }
                    }
                }
                else
                {
                    enableFormControls(true, true, false);
                    enablePartControls(false);
                    part_grid.Select();
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_choose_one_center);
            }
        }
        private void c_other_parts_button_Click(object sender, EventArgs e)
        {
            getSelectedCenters();
            if (c_selected_id_s.Count == 1)
            {
                part_grid.CellValueChanged -= part_grid_CellValueChanged;
                part_grid.CurrentCellDirtyStateChanged -= part_grid_CurrentCellDirtyStateChanged;
                bool? center_has_part = false;
                if (tMedicalCenterPartTableAdapter.FillByUser(pIPDataSet.TMedicalCenterPart, u_selected_id_s[0].Value, c_selected_id_s[0].Value, false, ref center_has_part) == 0)
                {
                    if (!(bool)center_has_part)
                    {
                        if (tMedicalCenterDoctorsTableAdapter.FillWithoutPartByUser(pIPDataSet.TMedicalCenterDoctor, u_selected_id_s[0].Value, c_selected_id_s[0].Value, false) == 0)
                        {
                            pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record);
                            enableFormControls(true, false, false);
                            enableCenterControls(true);
                        }
                        else
                        {
                            enableFormControls(true, false, true);
                            enableDoctorControls(true);
                            doctor_grid.Select();
                        }
                    }
                }
                else
                {
                    enableFormControls(true, true, false);
                    enablePartControls(true);
                    part_grid.Select();
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_choose_one_center);
            }
        }
        private void c_delete_button_Click(object sender, EventArgs e)
        {
            getSelectedCenters();
            if (c_selected_id_s.Count > 0)
            {
                permissions_adapter.DeletePermissionsByCenters(u_selected_id_s[0].Value, selectedCentersToDataTable(), ref action_result);
                result_enum = PLEnumFuncs.opResultToEnum(action_result);
                pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.other);
                if (result_enum == PLConstants.enum_operation_results.success)
                {
                    enableFormControls(false, false, false);
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }
        }
        private void c_change_button_Click(object sender, EventArgs e)
        {
            getSelectedCenters();
            if (c_selected_id_s.Count > 0)
            {
                permission_info_form.ShowDialog();
                if (permission_info_form.go_to_action)
                {
                    permissions_adapter.UpdatePermissionsInfoByCenters(u_selected_id_s[0].Value, selectedCentersToDataTable(), permission_info_form.sel_years, permission_info_form.sel_monthes, permission_info_form.sel_sectors, (byte?)permission_info_form.sel_contract_status, ref action_result);
                    result_enum = PLEnumFuncs.opResultToEnum(action_result);
                    pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.other);
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
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
            PLGlobalFuncs.DGVAfterFilling(center_grid, c_select_all_checkbox);
            center_grid.CellValueChanged += center_grid_CellValueChanged;
            center_grid.CurrentCellDirtyStateChanged += center_grid_CurrentCellDirtyStateChanged;
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
            if (Convert.ToBoolean(center_grid.Rows[e.RowIndex].Cells[c_str_sel_col].Value))
            {
                center_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                center_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
            }
            else
            {
                center_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                center_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.ControlText;
            }
        }

        #endregion

        /////////////////////////// Center METHODS
        #region Center Methods

        private void getSelectedCenters()
        {
            c_selected_id_s.Clear();
            int id_col = c_id_column.Index;
            for (int i = 0; i < center_grid.Rows.Count; i++)
            {
                if (Convert.ToBoolean(center_grid.Rows[i].Cells[c_str_sel_col].Value))
                {
                    c_selected_id_s.Add(new KeyValuePair<int, int>(i, (int)center_grid.Rows[i].Cells[id_col].Value));
                }
            }
        }
        private DataTable selectedCentersToDataTable()
        {
            DataTable s_c_t = PLGlobalFuncs.emptyIntIDsDataTable();
            foreach (KeyValuePair<int, int> c_id in c_selected_id_s)
            {
                s_c_t.Rows.Add(c_id.Value);
            }
            return s_c_t;
        }

        #endregion

        /////////////////////////////////////////////////////// Part 
        /////////////////////////// Part EVENTS
        #region Part Events
        private void p_show_doctors_button_Click(object sender, EventArgs e)
        {
            getSelectedParts();
            if (p_selected_id_s.Count == 1)
            {
                doctor_grid.CellValueChanged -= doctor_grid_CellValueChanged;
                doctor_grid.CurrentCellDirtyStateChanged -= doctor_grid_CurrentCellDirtyStateChanged;
                if (tMedicalCenterDoctorsTableAdapter.FillByUser(pIPDataSet.TMedicalCenterDoctor, u_selected_id_s[0].Value, c_selected_id_s[0].Value,p_selected_id_s[0].Value, true) == 0)
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record);
                    enableFormControls(true, true, false);
                    enablePartControls(false);
                }
                else
                {
                    enableFormControls(true, true, true);
                    enableDoctorControls(false);
                    doctor_grid.Select();
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_choose_one_user);
            }
        }
        private void p_other_doctors_button_Click(object sender, EventArgs e)
        {
            getSelectedParts();
            if (p_selected_id_s.Count == 1)
            {
                doctor_grid.CellValueChanged -= doctor_grid_CellValueChanged;
                doctor_grid.CurrentCellDirtyStateChanged -= doctor_grid_CurrentCellDirtyStateChanged;
                if (tMedicalCenterDoctorsTableAdapter.FillByUser(pIPDataSet.TMedicalCenterDoctor, u_selected_id_s[0].Value, c_selected_id_s[0].Value,p_selected_id_s[0].Value, false) == 0)
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record);
                    enableFormControls(true, true, false);
                    enablePartControls(true);
                }
                else
                {
                    enableFormControls(true, true, true);
                    enableDoctorControls(true);
                    doctor_grid.Select();
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_choose_one_part);
            }
        }
        private void p_delete_button_Click(object sender, EventArgs e)
        {
            getSelectedParts();
            if (p_selected_id_s.Count > 0)
            {
                permissions_adapter.DeletePermissionsByParts(u_selected_id_s[0].Value,c_selected_id_s[0].Value, selectedPartsToDataTable(), ref action_result);
                result_enum = PLEnumFuncs.opResultToEnum(action_result);
                pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.other);
                if (result_enum == PLConstants.enum_operation_results.success)
                {
                    enableFormControls(true, false, false);
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }
        }
        private void p_change_button_Click(object sender, EventArgs e)
        {
            getSelectedParts();
            if (p_selected_id_s.Count > 0)
            {
                permission_info_form.ShowDialog();
                if (permission_info_form.go_to_action)
                {
                    permissions_adapter.UpdatePermissionsInfoByParts(u_selected_id_s[0].Value, c_selected_id_s[0].Value, selectedPartsToDataTable(), permission_info_form.sel_years, permission_info_form.sel_monthes, permission_info_form.sel_sectors, (byte?)permission_info_form.sel_contract_status, ref action_result);
                    result_enum = PLEnumFuncs.opResultToEnum(action_result);
                    pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.other);
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }
        }

        private void p_select_all_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (p_select_all_checkbox.Checked)
            {
                for (int i = 0; i < part_grid.Rows.Count; i++)
                {
                    part_grid.Rows[i].Cells[p_str_sel_col].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < part_grid.Rows.Count; i++)
                {
                    part_grid.Rows[i].Cells[p_str_sel_col].Value = false;
                }
            }
        }
        private void part_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            PLGlobalFuncs.DGVAfterFilling(part_grid, p_select_all_checkbox);
            part_grid.CellValueChanged += part_grid_CellValueChanged;
            part_grid.CurrentCellDirtyStateChanged += part_grid_CurrentCellDirtyStateChanged;
        }
        private void part_grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (part_grid.IsCurrentCellDirty)
            {
                part_grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void part_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(part_grid.Rows[e.RowIndex].Cells[p_str_sel_col].Value))
            {
                part_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                part_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
            }
            else
            {
                part_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                part_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.ControlText;
            }
        }

        #endregion

        /////////////////////////// Part METHODS
        #region Part Methods

        private void getSelectedParts()
        {
            p_selected_id_s.Clear();
            int id_col = p_cen_par_seq_column.Index;
            for (int i = 0; i < part_grid.Rows.Count; i++)
            {
                if (Convert.ToBoolean(part_grid.Rows[i].Cells[p_str_sel_col].Value))
                {
                    p_selected_id_s.Add(new KeyValuePair<int, int>(i, (int)part_grid.Rows[i].Cells[id_col].Value));
                }
            }
        }
        private DataTable selectedPartsToDataTable()
        {
            DataTable s_p_t = PLGlobalFuncs.emptyIntIDsDataTable();
            foreach (KeyValuePair<int, int> p_id in p_selected_id_s)
            {
                s_p_t.Rows.Add(p_id.Value);
            }
            return s_p_t;
        }

        #endregion

        /////////////////////////////////////////////////////// Doctor 
        /////////////////////////// Doctor EVENTS
        #region Doctor Events
        private void d_delete_button_Click(object sender, EventArgs e)
        {
            bool has_part;
            getSelectedDoctors();
            if (d_selected_id_s.Count > 0)
            {
                if (pIPDataSet.TMedicalCenterPart.Rows.Count == 0)
                {
                    permissions_adapter.DeletePermissionsByDoctors(u_selected_id_s[0].Value, c_selected_id_s[0].Value, null, selectedDoctorsToDataTable(), ref action_result);
                    has_part = false;
                }
                else
                {
                    permissions_adapter.DeletePermissionsByDoctors(u_selected_id_s[0].Value, c_selected_id_s[0].Value, p_selected_id_s[0].Value, selectedDoctorsToDataTable(), ref action_result);
                    has_part = true;
                }
                result_enum = PLEnumFuncs.opResultToEnum(action_result);
                pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.other);
                if (result_enum == PLConstants.enum_operation_results.success)
                {
                    if (has_part)
                    {
                        enableFormControls(true, true, false);
                    }
                    else
                    {
                        enableFormControls(true, false, false);
                    }
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }
        }
        private void d_add_button_Click(object sender, EventArgs e)
        {
            bool has_part;
            getSelectedDoctors();
            if (d_selected_id_s.Count > 0)
            {
                permission_info_form.ShowDialog();
                if (permission_info_form.go_to_action)
                {
                    if (p_selected_id_s.Count == 0)
                    {
                        permissions_adapter.AddPermissionsByDoctors(u_selected_id_s[0].Value, c_selected_id_s[0].Value, null, selectedDoctorsToDataTable(), permission_info_form.sel_years, permission_info_form.sel_monthes, permission_info_form.sel_sectors,(byte?)permission_info_form.sel_contract_status, ref action_result);
                        has_part = false;
                    }
                    else
                    {
                        permissions_adapter.AddPermissionsByDoctors(u_selected_id_s[0].Value, c_selected_id_s[0].Value, p_selected_id_s[0].Value, selectedDoctorsToDataTable(), permission_info_form.sel_years, permission_info_form.sel_monthes, permission_info_form.sel_sectors,(byte?)permission_info_form.sel_contract_status, ref action_result);
                        has_part = true;
                    }
                    result_enum = PLEnumFuncs.opResultToEnum(action_result);
                    pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.other);
                    if (result_enum == PLConstants.enum_operation_results.success)
                    {
                        if (has_part)
                        {
                            enableFormControls(true, true, false);
                        }
                        else
                        {
                            enableFormControls(true, false, false);
                        }
                    }
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }
        }
        private void d_change_button_Click(object sender, EventArgs e)
        {
            getSelectedDoctors();
            if (d_selected_id_s.Count > 0)
            {
                permission_info_form.ShowDialog();
                if (permission_info_form.go_to_action)
                {
                    if (p_selected_id_s.Count == 0)
                    {
                        permissions_adapter.UpdatePermissionsInfoByDoctors(u_selected_id_s[0].Value, c_selected_id_s[0].Value, null, selectedDoctorsToDataTable(), permission_info_form.sel_years, permission_info_form.sel_monthes, permission_info_form.sel_sectors, (byte?)permission_info_form.sel_contract_status, ref action_result);
                    }
                    else
                    {
                        permissions_adapter.UpdatePermissionsInfoByDoctors(u_selected_id_s[0].Value, c_selected_id_s[0].Value, p_selected_id_s[0].Value, selectedDoctorsToDataTable(), permission_info_form.sel_years, permission_info_form.sel_monthes, permission_info_form.sel_sectors, (byte?)permission_info_form.sel_contract_status, ref action_result);
                    }
                    result_enum = PLEnumFuncs.opResultToEnum(action_result);
                    pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.other);
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }
        }

        private void d_select_all_checkbox_CheckedChanged(object sender, EventArgs e)
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
        private void doctor_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            PLGlobalFuncs.DGVAfterFilling(doctor_grid, d_select_all_checkbox);
            doctor_grid.CellValueChanged += doctor_grid_CellValueChanged;
            doctor_grid.CurrentCellDirtyStateChanged += doctor_grid_CurrentCellDirtyStateChanged;
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

        #endregion

        /////////////////////////// Doctor METHODS
        #region Doctor Methods

        private void getSelectedDoctors()
        {
            d_selected_id_s.Clear();
            int id_col = d_cen_doc_seq_column.Index;
            for (int i = 0; i < doctor_grid.Rows.Count; i++)
            {
                if (Convert.ToBoolean(doctor_grid.Rows[i].Cells[d_str_sel_col].Value))
                {
                    d_selected_id_s.Add(new KeyValuePair<int, int>(i, (int)doctor_grid.Rows[i].Cells[id_col].Value));
                }
            }
        }

        private DataTable selectedDoctorsToDataTable()
        {
            DataTable s_d_t = PLGlobalFuncs.emptyIntIDsDataTable();
            foreach (KeyValuePair<int, int> d_id in d_selected_id_s)
            {
                s_d_t.Rows.Add(d_id.Value);
            }
            return s_d_t;
        }

        #endregion

    }
}