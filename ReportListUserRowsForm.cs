using System;
using System.Windows.Forms;

namespace PadraInsurancePrescription
{
    public partial class ReportListUserRowsForm : Form
    {
        int count;
        public ReportListUserRowsForm()
        {
            InitializeComponent();
            PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.dialog);

            rows_numUD.Select();
            //this.count = count;
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            count = 0;
            Close();
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            this.count = (int)rows_numUD.Value;
            if (count > 0)
            {
                Close();
            }
            else
            {
                PGSDialog error_dialog = new PGSDialog(PLConstants.enum_dialog_types.error, PLConstants.error_service_count_zero);
            }
        }

        public int getCount()
        {
            ShowDialog();
            return count;
        }
    }
}
