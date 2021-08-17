using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;

namespace PadraInsurancePrescription
{
    public partial class DBConnectionForm : Form
    {
        PGSDialog pgs_dialog;
        public DBConnectionForm()
        {
            InitializeComponent();
            PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.dialog);
            pgs_dialog = new PGSDialog(this);
            DBTestExecuteForm exe_form = new DBTestExecuteForm();
            exe_form.Show();
        }

        private void connect_button_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb.ConnectionString = "Data Source=" + server_textbox.Text.Trim() +
                                ";Initial Catalog=" + db_textbox.Text.Trim();
            string sec = security_textbox.Text.Trim();
            if (!string.IsNullOrEmpty(sec)) { sb.ConnectionString += ";" + sec; }
            string oth = other_textbox.Text.Trim();
            if (!string.IsNullOrEmpty(oth)) { sb.ConnectionString += ";" + oth; }
            using (SqlConnection sqlcon = new SqlConnection(sb.ConnectionString))
            {
                try
                {
                    sqlcon.Open();
                    sqlcon.Close();
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.ConnectionStrings.ConnectionStrings[PLConstants.config_connection_string_name].ConnectionString = sqlcon.ConnectionString;
                    config.Save();
                    ConfigurationManager.RefreshSection(PLConstants.config_tag_connectionStrings);
                    Properties.Settings.Default[PLConstants.setting_connection_string_name] = sqlcon.ConnectionString;
                    Properties.Settings.Default.Save();
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.connection_success_message);
                }
                catch (SqlException sql_exp)
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.connection_parameters_error_message + "\nErr Num: " + sql_exp.Number + "\nErr Cod: " + sql_exp.ErrorCode + "\nErr Mes: " + sql_exp.Message);
                }
                catch (Exception exp)
                {
                    var st = new StackTrace(exp, true);
                    // Get the top stack frame
                    var frame = st.GetFrame(0);
                    // Get the line number from the stack frame
                    var line = frame.GetFileLineNumber();
                    MessageBox.Show(exp.ToString() + "\n" + st.ToString() + "\n" + frame.ToString() + "\n" + line.ToString());
                }
            }
        }
    }
}
