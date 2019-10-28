using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MetroFramework.Forms;
using SmartCore.Entities.General;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls.Quatation
{
	public partial class QualificationNumberForm : MetroForm
	{
		private readonly RequestForQuotation _order;
		private readonly IEnumerable<Supplier> _suppliers;

		public QualificationNumberForm()
		{
			
			InitializeComponent();
			
		}

		public QualificationNumberForm(RequestForQuotation order, IEnumerable<Supplier> suppliers) : this()
		{
			_order = order;
			_suppliers = suppliers;
			UpdateInformation();
		}

		#region private void UpdateInformation()

		private void UpdateInformation()
		{
			comboBoxSupplier.Items.Clear();
			comboBoxSupplier.Items.AddRange(_suppliers.ToArray());
		}

		#endregion

		private void buttonOk_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void buttonApply_Click(object sender, EventArgs e)
		{
			var supplierId = ((BaseEntityObject)comboBoxSupplier.SelectedItem).ItemId;

			if (_order.AdditionalInformation.QualificationNumbers.ContainsKey(supplierId))
			{
				_order.AdditionalInformation.QualificationNumbers[supplierId] = textBoxQualificationNumber.Text;
			}
			else
			{
				_order.AdditionalInformation.QualificationNumbers.Add(supplierId, textBoxQualificationNumber.Text);
			}
				
		}

		private void comboBoxSupplier_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_order.AdditionalInformation.QualificationNumbers.ContainsKey(
				((BaseEntityObject) comboBoxSupplier.SelectedItem).ItemId))
				textBoxQualificationNumber.Text =
					_order.AdditionalInformation.QualificationNumbers[
						((BaseEntityObject) comboBoxSupplier.SelectedItem).ItemId];
			else
			{
				textBoxQualificationNumber.Text = "";
			}
		}
	}
}
