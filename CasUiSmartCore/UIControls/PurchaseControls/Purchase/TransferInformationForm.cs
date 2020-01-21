using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
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
				var count = record.Quantity - record.TransferInformation.Count;

				foreach (var tr in record.TransferInformation)
					tr.Product = record.Product;

				_records.AddRange(record.TransferInformation);

				if (count > 0)
				{
					for (int i = 0; i < count; i++)
					{
						_records.Add(new TransferInformation
						{
							Number = (byte) (i + 1),
							Product = record.Product,
							ProductId = record.Product.ItemId,
						});
					}
				}
			}

			
			_formListViewTransferInformation.SetItemsArray(_records.ToArray());
		}

		#endregion

		private void buttonOk_Click(object sender, EventArgs e)
		{
			foreach (var record in _addedRecord)
			{
				record.TransferInformation.AddRange(_records);
				GlobalObjects.CasEnvironment.NewKeeper.Save(record);
			}

			DialogResult = DialogResult.OK;
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
			_formListViewTransferInformation.SelectedItem.PartNumber = textBoxPartNumber.Text;
			_formListViewTransferInformation.SelectedItem.SerialNumber = textBoxSerialNumber.Text;

			_formListViewTransferInformation.SetItemsArray(_records.ToArray());
		}
		
		private void listViewTransferInformation_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
		{
			textBoxNumber.SelectedText = _formListViewTransferInformation.SelectedItem.Number.ToString();
			textBoxPartNumber.Text = _formListViewTransferInformation.SelectedItem.PartNumber;
			textBoxSerialNumber.Text = _formListViewTransferInformation.SelectedItem.SerialNumber;
		}
	}
}
