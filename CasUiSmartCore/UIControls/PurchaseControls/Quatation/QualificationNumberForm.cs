using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace CAS.UI.UIControls.PurchaseControls.Quatation
{
	public partial class QualificationNumberForm : MetroForm
	{
		public QualificationNumberForm()
		{
			InitializeComponent();
		}

		#region private void UpdateInformation()

		private void UpdateInformation()
		{
			
		}

		#endregion

		#region private void ApplyChanges()

		private void ApplyChanges()
		{
			
		}



		#endregion

		private void buttonOk_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
