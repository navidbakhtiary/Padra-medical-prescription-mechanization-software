using System.Windows.Forms;

namespace PadraInsurancePrescription
{
    public partial class UserNoPermissionsForm : Form
    {
        public UserNoPermissionsForm()
        {
            InitializeComponent();
            PLGlobalFuncs.changeDGVSettings(permission_grid);
            PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.sub_data);
        }

        public void showWithData(PIPDataSet.TUserPermissionsDataTable permission_data)
        {
            user_title_label.Text = PLConstants.UserText;
            tUserPermissionsBindingSource.DataSource = permission_data;
            ShowDialog();
        }

        private void permission_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            PLGlobalFuncs.dataGridViewRowNumbering(permission_grid);
        }

    }
}
