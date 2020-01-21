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
		private readonly List<PurchaseRequestRecord> _addedRecord;
		private List<TransferInformation> _records;

		public TransferInformationForm(List<PurchaseRequestRecord> addedRecord)
		{
			_addedRecord = addedRecord;
			InitializeComponent();
			UpdateInformation();
		}

		#region private void UpdateInformation()

		private void UpdateInformation()
		{
			_records = new List<TransferInformation>();
			foreach (var record in _addedRecord)
			{
				for (int i = 0; i < record.Quantity; i++)
				{
					_records.Add(new TransferInformation
					{
						Number = (byte) (i+1),
						Product = record.Product
					});
				}
			}
			_formListViewTransferInformation.SetItemsArray(_records.ToArray());
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
