using System;
using System.Windows.Forms;
using System.Data;

namespace PadraInsurancePrescription
{
    public partial class SYMPermissionForm : Form
    {
        PGSDialog pgs_dialog;

        PIPDataSetTableAdapters.InsuranceSectorTableAdapter sector_adapter;
        PIPDataSet.InsuranceSectorDataTable sectors_data;

        DataTable years_data, monthes_data, contracts_data;
        
        public DataTable sel_years, sel_monthes, sel_sectors;
        public PLConstants.enum_sector_contract_status sel_contract_status;
        public bool go_to_action;

        public SYMPermissionForm()
        {
            InitializeComponent();
            PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.dialog);

            pgs_dialog = new PGSDialog(this);
            sector_adapter = new PIPDataSetTableAdapters.InsuranceSectorTableAdapter();
            sectors_data = new PIPDataSet.InsuranceSectorDataTable();
            sel_years = PLGlobalFuncs.emptyYearIDsDataTable();
            sel_monthes = PLGlobalFuncs.emptyMonthIDsDataTable();
            sel_sectors = PLGlobalFuncs.emptyIntIDsDataTable();

            initListBoxes();
            year_checkedListBox.Select();
        }

        private void initListBoxes()
        {
            sector_adapter.GetAll(sectors_data);
            PIPDataSet.InsuranceSectorRow s_first_row = sectors_data.NewInsuranceSectorRow();
            s_first_row.id = -1;
            s_first_row.name = "---انتخاب همه---";
            sectors_data.Rows.InsertAt(s_first_row, 0);
            foreach (PIPDataSet.InsuranceSectorRow row in sectors_data.Rows)
            {
                sector_checkedListBox.Items.Add(row.insurance_name + " > " + row.name);
            }
            PLGlobalFuncs.yearsForCheckedListBox(year_checkedListBox);
            years_data = (DataTable)year_checkedListBox.DataSource;
            PLGlobalFuncs.monthesForCheckedListBox(month_checkedListBox);
            monthes_data = (DataTable)month_checkedListBox.DataSource;
            PLGlobalFuncs.contractStatusForCheckedListBox(contract_status_checkedListBox);
            contracts_data = (DataTable)contract_status_checkedListBox.DataSource;
        }

        private void year_checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 0)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    for (int i = 1; i < year_checkedListBox.Items.Count; i++)
                    {
                        year_checkedListBox.SetItemChecked(i, true);
                    }
                }
                else if(e.NewValue == CheckState.Unchecked)
                {
                    for (int i = 1; i < year_checkedListBox.Items.Count; i++)
                    {
                        year_checkedListBox.SetItemChecked(i, false);
                    }
                }
            }
        }
        private void month_checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 0)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    for (int i = 1; i < month_checkedListBox.Items.Count; i++)
                    {
                        month_checkedListBox.SetItemChecked(i, true);
                    }
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    for (int i = 1; i < month_checkedListBox.Items.Count; i++)
                    {
                        month_checkedListBox.SetItemChecked(i, false);
                    }
                }
            }
        }
        private void sector_checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 0)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    for (int i = 1; i < sector_checkedListBox.Items.Count; i++)
                    {
                        sector_checkedListBox.SetItemChecked(i, true);
                    }
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    for (int i = 1; i < sector_checkedListBox.Items.Count; i++)
                    {
                        sector_checkedListBox.SetItemChecked(i, false);
                    }
                }
            }
        }
        private void contract_status_checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 0)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    for (int i = 1; i < contract_status_checkedListBox.Items.Count; i++)
                    {
                        contract_status_checkedListBox.SetItemChecked(i, true);
                    }
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    for (int i = 1; i < contract_status_checkedListBox.Items.Count; i++)
                    {
                        contract_status_checkedListBox.SetItemChecked(i, false);
                    }
                }
            }
        }

        private void refresh_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            initListBoxes();
        }
        private void save_button_Click(object sender, EventArgs e)
        {
            if (year_checkedListBox.CheckedItems.Count > 0 && month_checkedListBox.CheckedItems.Count > 0 && sector_checkedListBox.CheckedItems.Count > 0 && contract_status_checkedListBox.CheckedItems.Count>0)
            {
                sel_years.Rows.Clear();
                sel_monthes.Rows.Clear();
                sel_sectors.Rows.Clear();
                for (int i = 1; i < year_checkedListBox.Items.Count; i++)
                {
                    if (year_checkedListBox.GetItemCheckState(i) == CheckState.Checked)
                    {
                        sel_years.Rows.Add(years_data.Rows[i][0]);
                    }
                }
                for (int i = 1; i < month_checkedListBox.Items.Count; i++)
                {
                    if (month_checkedListBox.GetItemCheckState(i) == CheckState.Checked)
                    {
                        sel_monthes.Rows.Add(monthes_data.Rows[i][0]);
                    }
                }
                string col_name=sectors_data.idColumn.ColumnName;
                for (int i = 1; i < sector_checkedListBox.Items.Count; i++)
                {
                    if (sector_checkedListBox.GetItemCheckState(i) == CheckState.Checked)
                    {
                        sel_sectors.Rows.Add(sectors_data.Rows[i][col_name]);
                    }
                }

                if (contract_status_checkedListBox.CheckedItems.Count >= 2)
                {
                    sel_contract_status = PLConstants.enum_sector_contract_status.both;
                }
                else if (contract_status_checkedListBox.GetItemCheckState(1) == CheckState.Checked)
                {
                    sel_contract_status = PLConstants.enum_sector_contract_status.is_contracted;
                }
                else
                {
                    sel_contract_status = PLConstants.enum_sector_contract_status.not_contracted;
                }
                go_to_action=true;
                this.Close();
            }
            else
            {
                go_to_action = false;
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_choose_checkedlistbox);
            }
        }
        private void cancel_button_Click(object sender, EventArgs e)
        {
            go_to_action = false;
            this.Close();   
        }

        private void SYMPermissionForm_Activated(object sender, EventArgs e)
        {
            go_to_action = false;
        }

    }
}
