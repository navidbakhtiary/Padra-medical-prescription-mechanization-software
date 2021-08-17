using System;
using System.Windows.Forms;

namespace PadraInsurancePrescription
{
    public partial class VisitDayForm : Form
    {
        public string selected_day;
        char enter_char;

        public VisitDayForm(int month)
        {
            InitializeComponent();
            PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.dialog);

            PLGlobalFuncs.daysForComboBox(day_cbx, month);
            day_cbx.SelectAll();
            enter_char = (char)Keys.Enter;
        }

        private void VisitDayForm_Load(object sender, EventArgs e)
        {
            day_cbx.SelectedIndexChanged += day_cbx_SelectedIndexChanged;
            day_cbx.Select();
        }

        private void day_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (day_cbx.SelectedIndex > 0)
            {
                selected_day = day_cbx.SelectedValue.ToString();
            }
            else
            {
                selected_day = null;
                MessageBox.Show("روز ویزیت نامعتبر است");
                day_cbx.Select();
            }
        }

        private void general_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == enter_char)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void set_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void VisitDayForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            day_cbx.SelectedIndexChanged -= day_cbx_SelectedIndexChanged;
        }


    }
}
