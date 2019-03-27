using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAS.UI.UIControls.OpepatorsControls
{
    public partial class PasswordChangeForm : Form
    {
        public PasswordChangeForm()
        {
            InitializeComponent();
        }

        private void ButtonOkClick(object sender, EventArgs e)
        {
            try
            {
                //ApplyChanges();

                //GlobalObjects.DocumentCore.SaveDocumentsList(_parent, new List<Document> { CurrentDocument });
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while save document", ex);
            }
        }

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
