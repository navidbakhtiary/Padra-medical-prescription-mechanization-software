using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace PadraInsurancePrescription
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.dialog);
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default[PLConstants.setting_connection_string_name] = ConfigurationManager.ConnectionStrings[PLConstants.config_connection_string_name].ConnectionString;
            Properties.Settings.Default.Save();
            PGSDialog pgs_dialog = new PGSDialog(this);
            PIPDataSetTableAdapters.TSystemUserTableAdapter user_adapter = new PIPDataSetTableAdapters.TSystemUserTableAdapter();
            PIPDataSet.TSystemUserDataTable user_data = new PIPDataSet.TSystemUserDataTable();
            error_label.Visible = false;
            string user_name = user_text.Text.Trim();
            string pass_word = pass_text.Text;
            try
            {
                if (user_adapter.FillForLogin(user_data, user_name, pass_word) == 1)
                {
                    PIPDataSet.TSystemUserRow srow = (PIPDataSet.TSystemUserRow)user_data.Rows[0];
                    PLConstants.SYSUser = new DLSystemUser(srow.user_code, srow.user_name, srow.name, srow.family_name);
                    PadraMainForm main_form = new PadraMainForm(this);
                    this.Hide();
                    main_form.Show();
                }
                else
                {
                    error_label.Visible = true;
                }
            }
            catch (SqlException sql_exp)
            {
                pgs_dialog.connectionResult(PLConstants.enum_operation_results.error, "Err Num: " + sql_exp.Number + "\nErr Cod: " + sql_exp.ErrorCode + "\nErr Mes: " + sql_exp.Message);
                if (pgs_dialog.user_choice == PLConstants.enum_dialog_options.yes)
                {
                    DBConnectionForm db_con_form = new DBConnectionForm();
                    db_con_form.ShowDialog();
                }
            }
        }

        private void general_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
