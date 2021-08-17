using System.Windows.Forms;

namespace PadraInsurancePrescription
{
    public partial class SearchedInsuredServiceForm : Form
    {
        public SearchedInsuredServiceForm()//checked
        {
            InitializeComponent();
            PLGlobalFuncs.changeDGVSettings(pres_service_grid);
            PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.sub_data);
        }

        public void showWithData(PLConstants.enum_insurances ins_enum, string ins_name, string sec_name, long insured_seq, string insured_str, int center_id, string center_str, string visit_day, string visit_month, string visit_year)
        {
            ins_title_label.Text = ins_name;
            sec_title_label.Text = sec_name;
            center_title_label.Text = center_str;
            insured_title_label.Text = insured_str;
            visit_date_title_label.Text = visit_year + "/" + visit_month + "/" + visit_day;
            
            switch (ins_enum)
            {
                case PLConstants.enum_insurances.Salamat:
                    tInsuredPrescriptionDataTableAdapter.FillSalamatByDay(pIPDataSet.TInsuredPrescriptionData, center_id, insured_seq, visit_day, visit_month, visit_year);
                    break;
                case PLConstants.enum_insurances.TaminEjtemaei:
                    tInsuredPrescriptionDataTableAdapter.FillTaminEjtemaeiByDay(pIPDataSet.TInsuredPrescriptionData, center_id, insured_seq, visit_day, visit_month, visit_year);
                    break;
                case PLConstants.enum_insurances.NirooMosalah:
                    tInsuredPrescriptionDataTableAdapter.FillNirooMosalahByDay(pIPDataSet.TInsuredPrescriptionData, center_id, insured_seq, visit_day, visit_month, visit_year);
                    break;
                case PLConstants.enum_insurances.KomitehEmdad:
                    tInsuredPrescriptionDataTableAdapter.FillKomitehEmdadByDay(pIPDataSet.TInsuredPrescriptionData, center_id, insured_seq, visit_day, visit_month, visit_year);
                    break;
                case PLConstants.enum_insurances.Other:
                    tInsuredPrescriptionDataTableAdapter.FillOtherByDay(pIPDataSet.TInsuredPrescriptionData, center_id, insured_seq, visit_day, visit_month, visit_year);
                    break;
            }
            ShowDialog();
        }

        private void pres_service_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            PLGlobalFuncs.dataGridViewRowNumbering(pres_service_grid);
        }

    }
}
