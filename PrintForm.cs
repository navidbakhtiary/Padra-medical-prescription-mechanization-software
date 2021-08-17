using System.Windows.Forms;

namespace PadraInsurancePrescription
{
    public partial class PrintForm : Form
    {
        public PrintForm()
        {
            InitializeComponent();
            PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.main);
        }

    }
}
