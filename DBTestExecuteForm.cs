using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Diagnostics;

namespace PadraInsurancePrescription
{
    public partial class DBTestExecuteForm : Form
    {
        public DBTestExecuteForm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.padra_icon;
        }

        private void select_button_Click(object sender, EventArgs e)
        {
            try
            {
                PIPDataSetTableAdapters.ConnectionTestTableAdapter test_adapter = new PIPDataSetTableAdapters.ConnectionTestTableAdapter();
                PIPDataSet.ConnectionTestDataTable dt=new PIPDataSet.ConnectionTestDataTable();
                test_adapter.Fill(dt);
                test_dataGridView.DataSource = dt;
            }
            catch (SqlException exp)
            {
                MessageBox.Show(exp.Number + " >> " + exp.ErrorCode + " >> " + exp.Message);
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

        private void insert_button_Click(object sender, EventArgs e)
        {
            try
            {
                string mac = "";
                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (nic.OperationalStatus == OperationalStatus.Up && (!nic.Description.Contains("Virtual") && !nic.Description.Contains("Pseudo")))
                    {
                        if (nic.GetPhysicalAddress().ToString() != "")
                        {
                            mac = nic.GetPhysicalAddress().ToString();
                            break;
                        }
                    }
                }

                if (string.IsNullOrEmpty(mac)) { mac = ""; }
                PersianCalendar pc = new PersianCalendar();
                PIPDataSetTableAdapters.ConnectionTestTableAdapter test_adapter = new PIPDataSetTableAdapters.ConnectionTestTableAdapter();
                test_adapter.Add(pc.GetDayOfMonth(DateTime.Now),pc.GetMonth(DateTime.Now),pc.GetYear(DateTime.Now),pc.GetHour(DateTime.Now) + ":" + pc.GetMinute(DateTime.Now) + ":" + pc.GetSecond(DateTime.Now),mac,Environment.MachineName);
            }
            catch (SqlException exp)
            {
                MessageBox.Show(exp.Number + " >> " + exp.ErrorCode + " >> " + exp.Message);
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
