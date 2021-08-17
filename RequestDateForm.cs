using System;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;

namespace PadraInsurancePrescription
{
    public partial class RequestDateForm : Form
    {
        string request_date;
        PersianCalendar pc;
        PGSDialog pgs_dialog;
        bool error_exist;

        public RequestDateForm()
        {
            InitializeComponent();
            PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.dialog);
            pgs_dialog = new PGSDialog(this);
            pc=new PersianCalendar();
            //date_masked.Text = request_date = (new DateTime(pc.GetYear(DateTime.Now), pc.GetMonth(DateTime.Now), pc.GetDayOfMonth(DateTime.Now))).ToString("yyyy/MM/dd");
            date_masked.Text = request_date = pc.GetYear(DateTime.Now)+"/"+pc.GetMonth(DateTime.Now).ToString("00")+"/"+pc.GetDayOfMonth(DateTime.Now).ToString("00");
            date_masked.Enabled = false;
            system_date_radio.Checked = true;
        }

        private void system_date_radio_CheckedChanged(object sender, EventArgs e)
        {
            if (system_date_radio.Checked)
            {
                date_masked.Text = request_date = pc.GetYear(DateTime.Now) + "/" + pc.GetMonth(DateTime.Now).ToString("00") + "/" + pc.GetDayOfMonth(DateTime.Now).ToString("00");
                date_masked.Enabled = false;
                error_exist = false;
            }
            else
            {
                date_masked.Enabled = true;
                date_masked.SelectAll();
            }
        }

        private void set_button_Click(object sender, EventArgs e)
        {
            if (!system_date_radio.Checked)
            {
                string d_text = date_masked.Text;
                if (!Regex.IsMatch(d_text, PLConstants.reg_date_slash))
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_date);
                    error_exist = true;
                }
                else
                {
                    error_exist = false;
                    request_date = d_text;
                }
            }
            if (!error_exist)
            {
                Close();
            }
        }

        public string RDate
        {
            get
            {
                return request_date;
            }
        }
    }
}
