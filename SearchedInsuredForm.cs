using System.Windows.Forms;

namespace PadraInsurancePrescription
{
    public partial class SearchedInsuredForm : Form
    {
        public SearchedInsuredForm()//checked
        {
            InitializeComponent();
            PLGlobalFuncs.changeDGVSettings(insured_grid);
            PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.sub_data);
        }

        public void showWithData(PLConstants.enum_insurances ins_enum, string ins_name, string sec_name,string insured_id)//checked
        {
            ins_title_label.Text = ins_name;
            sec_title_label.Text = sec_name;
            
            switch (ins_enum)
            {
                case PLConstants.enum_insurances.Salamat:
                    tInsuredTableAdapter.FillSalamatFromSectors(pIPDataSet.TInsured, insured_id);
                    break;
                case PLConstants.enum_insurances.TaminEjtemaei:
                    tInsuredTableAdapter.FillTaminEjtemaeiFromSectors(pIPDataSet.TInsured, insured_id);
                    break;
                case PLConstants.enum_insurances.NirooMosalah:
                    tInsuredTableAdapter.FillNirooMosalahFromSectors(pIPDataSet.TInsured, insured_id);
                    break;
                case PLConstants.enum_insurances.KomitehEmdad:
                    tInsuredTableAdapter.FillKomitehEmdadFromSectors(pIPDataSet.TInsured, insured_id);
                    break;
                case PLConstants.enum_insurances.Other:
                    tInsuredTableAdapter.FillOtherFromSectors(pIPDataSet.TInsured, insured_id);
                    break;
            }
            ShowDialog();
        }

        private void insured_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            PLGlobalFuncs.dataGridViewRowNumbering(insured_grid);
        }

    }
}
