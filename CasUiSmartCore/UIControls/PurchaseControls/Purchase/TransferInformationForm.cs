using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MetroFramework.Forms;
using SmartCore.Entities.General;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls.Purchase
{
	public partial class TransferInformationForm : MetroForm
	{
		public TransferInformationForm()
		{
			InitializeComponent();
		}

		#region private void UpdateInformation()

		private void UpdateInformation()
		{
			
		}

		#endregion

		private void buttonOk_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		#region private void ButtonCancel_Click(object sender, EventArgs e)

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		#endregion

		private void buttonApply_Click(object sender, EventArgs e)
		{
			
		}

		
	}
}
