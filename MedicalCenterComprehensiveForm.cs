using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Data;

namespace PadraInsurancePrescription
{
    public partial class MedicalCenterComprehensiveForm : Form
    {
        PGSDialog pgs_dialog;
        string t_str;
        string c_str_sel_col;
        List<KeyValuePair<int, int>> c_selected_id_s;//1-row number 2-id
        CheckBox c_select_all_checkbox;
        DataTable cen_dt;
        string title;
        int center_id;

        public MedicalCenterComprehensiveForm(int province,string p_name,int city,string c_name,int? clinic_type,string t_name,
            int? center,string cen_name,int insurance,string i_name,string center_contract_id,string year,string month)//checked
        {
            InitializeComponent();
            PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.sub_data);
            pgs_dialog = new PGSDialog(this);
            tMedicalCenterTableAdapter.FillBySimilarity(pIPDataSet.TMedicalCenter, city, clinic_type);
            c_str_sel_col = m_select_column.Name;
            c_selected_id_s = new List<KeyValuePair<int, int>>();
            c_select_all_checkbox = new CheckBox();
            c_select_all_checkbox.CheckedChanged += c_select_all_checkbox_CheckedChanged;
            c_select_all_checkbox.Visible = false;

            province_val_lbl.Text=p_name;
            city_val_lbl.Text=c_name;
            type_val_lbl.Text=t_name;
            name_val_lbl.Text=cen_name;
            insurance_val_lbl.Text=i_name;
            center_id_val_lbl.Text=center_contract_id;
            year_val_lbl.Text=year;
            month_val_lbl.Text=month;

            center_id = (int)center;
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

        private void afterCenterGridFilled()
        {
            PLGlobalFuncs.DGVAfterFilling(center_grid, c_select_all_checkbox);
            for (int i = 0; i < center_grid.Rows.Count; i++)
            {
                center_grid.Rows[i].Cells[c_str_sel_col].Value = false;
            }
        }
        private void getSelectedCenters()
        {
            c_selected_id_s.Clear();
            int id_col = m_id_column.Index;
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

        public string Title
        {
            get
            {
                if (title == "")
                {
                    return name_val_lbl.Text;
                }
                else
                {
                    return title;
                }
            }
        }
        public DataTable SelectedCenters
        {
            get
            {
                cen_dt = selectedCentersToDataTable();
                cen_dt.Rows.Add(center_id);
                return cen_dt;
            }
        }

        private void generate_button_Click(object sender, EventArgs e)
        {
            getSelectedCenters();
            title = title_txt.Text.Trim();
            if (title == "" || Regex.IsMatch(title, PLConstants.reg_title))
            {
                if (c_selected_id_s.Count == 0)
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_other_centers_for_comprehensive_report);
                }
                this.Close();
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_title);
            }
        }
        private void cancel_button_Click(object sender, EventArgs e)//checked
        {
            this.Close();
        }


    }
}
