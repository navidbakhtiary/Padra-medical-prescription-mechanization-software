using System;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Drawing;

namespace PadraInsurancePrescription
{
    public partial class ProvinceCityControl : UserControl
    {
        string p_str_sel_col;
        string c_str_sel_col;

        int p_index;
        object[] p_selected_data;
        List<KeyValuePair<int,int>> p_selected_id_s;//1-row number 2-id
        CheckBox p_select_all_checkbox;

        int c_index;
        object[] c_selected_data;
        List<KeyValuePair<int, int>> c_selected_id_s;//1-row number 2-id
        CheckBox c_select_all_checkbox;
        bool c_is_filled_by_search;
        string c_search_name;

        PGSDialog pgs_dialog;
        PLConstants.enum_operation_results result_enum;

        public ProvinceCityControl()
        {
            //column 0 is checkboxes and not in arrays
            InitializeComponent();
            PLGlobalFuncs.changeDGVSettings(city_grid,province_grid);
            p_str_sel_col = "p_select_column";
            c_str_sel_col = "c_select_column";

            p_selected_id_s = new List<KeyValuePair<int, int>>();
            p_select_all_checkbox = new CheckBox();
            p_select_all_checkbox.CheckedChanged += p_select_all_checkbox_CheckedChanged;

            c_selected_id_s = new List<KeyValuePair<int, int>>();
            c_select_all_checkbox = new CheckBox();
            c_select_all_checkbox.CheckedChanged += c_select_all_checkbox_CheckedChanged;
            c_is_filled_by_search = false;

            provinceTableAdapter.Fill(pIPDataSet.Province);

            pgs_dialog = new PGSDialog(this);

        }

        // ///////////////////////////////////////////////////// PROVINCE

        // ///////////////////////// PROVINCE EVENTS
        # region PROVINCE Events

        private void p_search_button_Click(object sender, EventArgs e)
        {
            string p_name = p_name_search.Text.Trim();
            if (p_name == "")
            {
                provinceTableAdapter.Fill(pIPDataSet.Province);
            }
            else if (Regex.IsMatch(p_name, PLConstants.reg_name))
            {
                province_grid.CellValueChanged -= province_grid_CellValueChanged;
                province_grid.CurrentCellDirtyStateChanged -= province_grid_CurrentCellDirtyStateChanged;
                if (provinceTableAdapter.FillByName(pIPDataSet.Province, p_name) == 0)
                {
                    pgs_dialog = new PGSDialog(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record_after_search);
                    pgs_dialog.ShowDialog();
                    p_select_all_checkbox.Visible = false;
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_letters_only);
            }
        }

        private void p_refresh_grid_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            province_grid.CellValueChanged -= province_grid_CellValueChanged;
            province_grid.CurrentCellDirtyStateChanged -= province_grid_CurrentCellDirtyStateChanged;
            provinceTableAdapter.Fill(pIPDataSet.Province);
        }

        private void p_cities_button_Click(object sender, EventArgs e)
        {
            getSelectedProvinces();
            if (p_selected_id_s.Count > 0)
            {
                city_grid.CellValueChanged -= city_grid_CellValueChanged;
                city_grid.CurrentCellDirtyStateChanged -= city_grid_CurrentCellDirtyStateChanged;
                tCityTableAdapter.FillByProvinces(pIPDataSet.TCity, selectedProvincesToDataTable());
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }
        }

        private void p_new_button_Click(object sender, EventArgs e)
        {
            ProvinceForm p_form = new ProvinceForm(null, PLConstants.enum_data_operation.new_data);
            p_form.ShowDialog();
        }

        private void p_edit_button_Click(object sender, EventArgs e)
        {
            getSelectedProvinces();
            if (p_selected_id_s.Count == 1)
            {
                p_index = p_selected_id_s[0].Key;
                p_selected_data = pIPDataSet.Province.Rows[p_index].ItemArray.Clone() as object[];
                ProvinceForm p_form = new ProvinceForm(p_selected_data, PLConstants.enum_data_operation.edit_data);
                p_form.ShowDialog();
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_choose_one);
            }
        }

        private void p_delete_province_Click(object sender, EventArgs e)
        {
            getSelectedProvinces();
            if (p_selected_id_s.Count > 0)
            {
                List<string> message_text = new List<string>();
                message_text.Add(this.Tag.ToString() + " :");

                message_text.Add(PLConstants.question_delete);
                message_text.Add("استان های انتخاب شده :");
                message_text.AddRange(getProvincesDataForMessage());
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.delete, message_text);

                switch (pgs_dialog.user_choice)
                {
                    case PLConstants.enum_dialog_options.yes:
                        string delete_result = "";
                        provinceTableAdapter.DeleteProvinces(selectedProvincesToDataTable(), ref delete_result);
                        result_enum = PLEnumFuncs.opResultToEnum(delete_result);
                        pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.province);
                        switch (result_enum)
                        {
                            case PLConstants.enum_operation_results.success:
                                province_grid.CellValueChanged -= province_grid_CellValueChanged;
                                province_grid.CurrentCellDirtyStateChanged -= province_grid_CurrentCellDirtyStateChanged;
                                pIPDataSet.Province.Clear();
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

        private void p_select_all_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (p_select_all_checkbox.Checked)
            {
                for (int i = 0; i < province_grid.Rows.Count; i++)
                {
                    province_grid.Rows[i].Cells[p_str_sel_col].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < province_grid.Rows.Count; i++)
                {
                    province_grid.Rows[i].Cells[p_str_sel_col].Value = false;
                }
            }
        }

        private void province_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (province_grid.Rows.Count > 0)
            {
                PLGlobalFuncs.DGVAfterFilling(province_grid, p_select_all_checkbox);
                province_grid.CellValueChanged += province_grid_CellValueChanged;
                province_grid.CurrentCellDirtyStateChanged += province_grid_CurrentCellDirtyStateChanged;
            }
        }

        private void province_grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (province_grid.IsCurrentCellDirty)
            {
                province_grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void province_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(province_grid.Rows[e.RowIndex].Cells[p_str_sel_col].Value))
            {
                province_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                province_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
            }
            else
            {
                province_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                province_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.ControlText;
            }
        }

        # endregion

        // ///////////////////////// PROVINCE METHODS
        #region PROVINCE Methods

        private void getSelectedProvinces()
        {
            p_selected_id_s.Clear();
            int id_col=pIPDataSet.Province.idColumn.Ordinal+1;
            for (int i=0;i<province_grid.Rows.Count;i++)
            {
                if (Convert.ToBoolean(province_grid.Rows[i].Cells[p_str_sel_col].Value))
                {
                    p_selected_id_s.Add(new KeyValuePair<int,int>(i,(int)province_grid.Rows[i].Cells[id_col].Value));
                }
            }
        }

        private List<string> getProvincesDataForMessage()
        {
            int name_col = pIPDataSet.Province.nameColumn.Ordinal + 1;
            List<string> message_text = new List<string>();
            for (int i = 0; i < p_selected_id_s.Count; i++)
            {
                message_text.Add((string)province_grid.Rows[p_selected_id_s[i].Key].Cells[name_col].Value);
            }
            return message_text;
        }

        private DataTable selectedProvincesToDataTable()
        {
            DataTable s_p_t = new DataTable();
            s_p_t.Columns.Add("p_id", typeof(int));
            foreach (KeyValuePair<int, int> p_id in p_selected_id_s)
            {
                s_p_t.Rows.Add(p_id.Value);
            }
            return s_p_t;
        }

        //private void afterProvinceGridFilled()
        //{
        //    PLGlobalFuncs.dataGridViewAfterFilling(province_grid, p_select_all_checkbox);
        //    PLGlobalFuncs.createAllCheckBoxForDataGridView(province_grid, p_select_all_checkbox);

        //    for (int i = 0; i < province_grid.Rows.Count; i++)
        //    {
        //        province_grid.Rows[i].Cells[p_str_sel_col].Value = false;
        //    }
        //}

        #endregion

        // ///////////////////////////////////////////////////// CITY

        // ///////////////////////// CITY EVENTS
        #region CITY Events
        
        private void c_search_button_Click(object sender, EventArgs e)
        {

            c_is_filled_by_search = false;
            c_search_name = c_name_search.Text.Trim();
            if (c_search_name.Length < 2)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_search_text_not_empty);
            }
            else if (Regex.IsMatch(c_search_name, PLConstants.reg_search_name))
            {
                city_grid.CellValueChanged -= city_grid_CellValueChanged;
                city_grid.CurrentCellDirtyStateChanged -= city_grid_CurrentCellDirtyStateChanged;
                if (tCityTableAdapter.FillByName(pIPDataSet.TCity, c_search_name) == 0)
                {
                    pgs_dialog = new PGSDialog(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record_after_search);
                    pgs_dialog.ShowDialog();
                    c_select_all_checkbox.Visible = false;
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_letters_only);
            }
        }

        private void c_refresh_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            city_grid.CellValueChanged -= city_grid_CellValueChanged;
            city_grid.CurrentCellDirtyStateChanged -= city_grid_CurrentCellDirtyStateChanged;
            if (c_is_filled_by_search)
            {
                tCityTableAdapter.FillByName(pIPDataSet.TCity, c_search_name);
                PLGlobalFuncs.DGVAfterFilling(city_grid, c_select_all_checkbox);
            }
            else
            {
                tCityTableAdapter.FillByProvinces(pIPDataSet.TCity, selectedProvincesToDataTable());
                PLGlobalFuncs.DGVAfterFilling(city_grid, c_select_all_checkbox);
            }
        }

        private void c_new_button_Click(object sender, EventArgs e)
        {
            CityForm c_form = new CityForm(null, PLConstants.enum_data_operation.new_data, null);
            c_form.ShowDialog();
        }

        private void c_edit_button_Click(object sender, EventArgs e)
        {
            getSelectedCities();
            if (c_selected_id_s.Count == 1)
            {
                c_index = c_selected_id_s[0].Key;
                c_selected_data = pIPDataSet.TCity.Rows[c_index].ItemArray.Clone() as object[];
                CityForm c_form = new CityForm(c_selected_data, PLConstants.enum_data_operation.edit_data, null);
                c_form.ShowDialog();
            }
            else if (c_selected_id_s.Count > 1)
            {
                c_selected_data = pIPDataSet.TCity.Rows[c_index].ItemArray.Clone() as object[];
                CityForm c_form = new CityForm(c_selected_data, PLConstants.enum_data_operation.batch_edit, selectedCitiesToDataTable());
                c_form.ShowDialog();
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }
        }

        private void c_delete_button_Click(object sender, EventArgs e)
        {
            getSelectedCities();
            if (c_selected_id_s.Count > 0)
            {
                List<string> message_text = new List<string>();
                message_text.Add(this.Tag.ToString() + " :");
                message_text.Add(PLConstants.question_delete);
                message_text.Add(c_selected_id_s.Count+" شهر انتخاب شده اند.");
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.delete, message_text);

                switch (pgs_dialog.user_choice)
                {
                    case PLConstants.enum_dialog_options.yes:
                        string delete_result = "";
                        tCityTableAdapter.DeleteCities(selectedCitiesToDataTable(), ref delete_result);
                        result_enum = PLEnumFuncs.opResultToEnum(delete_result);
                        pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.city);
                        switch (result_enum)
                        {
                            case PLConstants.enum_operation_results.success:
                                city_grid.CellValueChanged -= city_grid_CellValueChanged;
                                city_grid.CurrentCellDirtyStateChanged -= city_grid_CurrentCellDirtyStateChanged;
                                pIPDataSet.TCity.Clear();
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

        private void c_select_all_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (c_select_all_checkbox.Checked)
            {
                for (int i = 0; i < city_grid.Rows.Count; i++)
                {
                    city_grid.Rows[i].Cells[c_str_sel_col].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < city_grid.Rows.Count; i++)
                {
                    city_grid.Rows[i].Cells[c_str_sel_col].Value = false;
                }
            }
        }

        private void city_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (city_grid.Rows.Count > 0)
            {
                PLGlobalFuncs.DGVAfterFilling(city_grid, c_select_all_checkbox);
                city_grid.CellValueChanged += city_grid_CellValueChanged;
                city_grid.CurrentCellDirtyStateChanged += city_grid_CurrentCellDirtyStateChanged;
            }
        }

        private void city_grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (city_grid.IsCurrentCellDirty)
            {
                city_grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void city_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(city_grid.Rows[e.RowIndex].Cells[c_str_sel_col].Value))
            {
                city_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                city_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
            }
            else
            {
                city_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                city_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.ControlText;
            }
        }

        #endregion

        // ///////////////////////// CITY METHODS
        #region CITY Methods

        private void getSelectedCities()
        {
            c_selected_id_s.Clear();
            int id_col = pIPDataSet.TCity.idColumn.Ordinal + 1;
            for (int i = 0; i < city_grid.Rows.Count; i++)
            {
                if (Convert.ToBoolean(city_grid.Rows[i].Cells[c_str_sel_col].Value))
                {
                    c_selected_id_s.Add(new KeyValuePair<int, int>(i, (int)city_grid.Rows[i].Cells[id_col].Value));
                }
            }
        }

        private List<string> getCitiesDataForMessage()
        {
            int name_col = pIPDataSet.TCity.nameColumn.Ordinal + 1;
            List<string> message_text = new List<string>();
            for (int i = 0; i < c_selected_id_s.Count; i++)
            {
                message_text.Add((string)city_grid.Rows[c_selected_id_s[i].Key].Cells[name_col].Value);
            }
            return message_text;
        }

        private DataTable selectedCitiesToDataTable()
        {
            DataTable s_c_t = new DataTable();
            s_c_t.Columns.Add("c_id", typeof(int));
            foreach (KeyValuePair<int, int> c_id in c_selected_id_s)
            {
                s_c_t.Rows.Add(c_id.Value);
            }
            return s_c_t;
        }

        //private void afterCityGridFilled()
        //{
        //    PLGlobalFuncs.dataGridViewAfterFilling(city_grid, c_select_all_checkbox);
        //    PLGlobalFuncs.createAllCheckBoxForDataGridView(city_grid, c_select_all_checkbox);

        //    for (int i = 0; i < city_grid.Rows.Count; i++)
        //    {
        //        city_grid.Rows[i].Cells[c_str_sel_col].Value = false;
        //    }
        //}

        #endregion CITY Methods

        
   
    }
}
