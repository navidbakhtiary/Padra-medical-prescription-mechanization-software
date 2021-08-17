using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace PadraInsurancePrescription
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //try
            //{
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            PIPDataSetTableAdapters.TSystemUserTableAdapter user_adapter = new PIPDataSetTableAdapters.TSystemUserTableAdapter();
            PIPDataSet.TSystemUserDataTable user_data = new PIPDataSet.TSystemUserDataTable();
            string user_name = "boss";
            string pass_word = "1234";
            //string user_name = "hkarimi";
            //string pass_word = "271232";
            LoginForm log_form = new LoginForm();
            if (user_adapter.FillForLogin(user_data, user_name, pass_word) == 1)
            {
                PIPDataSet.TSystemUserRow srow=(PIPDataSet.TSystemUserRow)user_data.Rows[0];
                PLConstants.SYSUser = new DLSystemUser(srow.user_code, srow.user_name, srow.name, srow.family_name);
                Application.Run(new PadraMainForm(log_form));
            }
            //}
            //catch (Exception exc)
            //{
            //    var st = new StackTrace(exc, true);
            //    // Get the top stack frame
            //    var frame = st.GetFrame(0);
            //    // Get the line number from the stack frame
            //    var line = frame.GetFileLineNumber();
            //    PGSDialog pgs_dialog = new PGSDialog();
            //    pgs_dialog.changeFontOfMessageBox();
            //    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, exc.ToString() + "\n" + st.ToString() + "\n" + frame.ToString() + "\n" + line.ToString());
            //}
        }
    }
}
