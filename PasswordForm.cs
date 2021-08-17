using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace PadraInsurancePrescription
{
    public partial class PasswordForm : Form
    {
        bool pass_is_correct = false;
        string entered_pass_word;
        public PasswordForm()
        {
            InitializeComponent();
            PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.dialog);
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
        }

        private void check_button_Click(object sender, EventArgs e)
        {
            PGSDialog pgs_dialog = new PGSDialog(this);
            PIPDataSetTableAdapters.TSystemUserTableAdapter user_adapter = new PIPDataSetTableAdapters.TSystemUserTableAdapter();
            PIPDataSet.TSystemUserDataTable user_data = new PIPDataSet.TSystemUserDataTable();
            error_label.Visible = false;
            string entered_pass_word = pass_text.Text;
            string db_pass_word = "";
            user_adapter.GetUserPassword(PLConstants.UserCode, ref db_pass_word);
            if (entered_pass_word.Equals(db_pass_word))
            {
                pass_is_correct = true;
                Close();
            }
            else
            {
                error_label.Visible = true;
                pass_is_correct = false;
            }
        }

        private void just_entered_button_Click(object sender, EventArgs e)
        {
            entered_pass_word = pass_text.Text;
            Close();
        }

        private void general_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        public bool ShowUserVer()
        {
            check_button.Click += check_button_Click;
            this.ShowDialog();
            return pass_is_correct;
        }

        public string ShowEmptyVer()
        {
            check_button.Click += just_entered_button_Click;
            this.ShowDialog();
            return entered_pass_word;
        }

    }
}
