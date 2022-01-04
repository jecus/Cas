using System.Windows.Forms;
using MetroFramework.Forms;

namespace CAS.UI.UICAAControls.CheckList
{
    public partial class CheckListForm : MetroForm
    {
        public CheckListForm()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var control = new AuditControl();
            //control.UpdateInformation(training, _suppliers, aircraftModels, _employeeLicenceControl);
            //control.Deleted += Control_Deleted;
            flowLayoutPanel1.Controls.Remove(linkLabel1);
            flowLayoutPanel1.Controls.Add(control);
            flowLayoutPanel1.Controls.Add(linkLabel1);
        }
    }
}
