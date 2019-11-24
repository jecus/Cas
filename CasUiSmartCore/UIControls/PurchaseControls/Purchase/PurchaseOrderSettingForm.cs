using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls.Purchase
{
	public partial class PurchaseOrderSettingForm : MetroForm
	{
		private readonly PurchaseOrder _order;
		private readonly List<Supplier> _supplierShipper;
		private readonly List<AirportsCodes> _airportsCodes;

		public PurchaseOrderSettingForm()
		{
			InitializeComponent();
		}

		public PurchaseOrderSettingForm(PurchaseOrder order, List<Supplier> supplierShipper,
			List<AirportsCodes> airportsCodes) : this()
		{
			_order = order;
			_supplierShipper = supplierShipper;
			_airportsCodes = airportsCodes;
			UpdateControls();
			UpdateInitialControls();
		}

		#region private void UpdateInitialControls()

		private void UpdateInitialControls()
		{
			comboBoxStatus.Items.Clear();
			comboBoxStatus.DataSource = Enum.GetValues(typeof(WorkPackageStatus));
			comboBoxStatus.SelectedItem = _order.Status;

			textBoxTitle.Text = _order.Title;
			metroTextBoxNumber.Text = _order.Number;
			dateTimePickerOpeningDate.Value = _order.OpeningDate;
			dateTimePickerClosingDate.Value = _order.ClosingDate;
			dateTimePickerPublishDate.Value = _order.PublishingDate;
			textBoxClosingBy.Text = _order.CloseByUser;
			textBoxPublishedBy.Text = _order.PublishedByUser;
			textBoxAuthor.Text = GlobalObjects.CasEnvironment.IdentityUser.ToString();
			textBoxRemarks.Text = _order.Remarks;
		}

		#endregion

		#region private void UpdateControls()

		private void UpdateControls()
		{
			comboBoxDesignation.Items.Clear();
			comboBoxDesignation.Items.AddRange(Designation.Items.ToArray());

			comboBoxIncoTerm.Items.Clear();
			comboBoxIncoTerm.Items.AddRange(IncoTerm.Items.ToArray());

			comboBoxShipComp.Items.Clear();
			comboBoxShipComp.Items.AddRange(_supplierShipper.ToArray());
			comboBoxShipComp.Items.Add(Supplier.Unknown);

			comboBoxShipTo.Items.Clear();
			comboBoxShipTo.Items.AddRange(_supplierShipper.ToArray());
			comboBoxShipTo.Items.Add(Supplier.Unknown);

			comboBoxPayTerm.Items.Clear();
			comboBoxPayTerm.DataSource = Enum.GetValues(typeof(PayTerm));

			comboBoxStation.Items.Clear();
			comboBoxStation.Items.AddRange(_airportsCodes.ToArray());
			
			comboBoxIncoTerm.SelectedItem = _order.IncoTerm;
			comboBoxDesignation.SelectedItem = _order.Designation;
			comboBoxPayTerm.SelectedItem = _order.PayTerm;
			textBoxBruttoWeight.Text = _order.BruttoWeight;
			textBoxCargoVolume.Text = _order.CargoVolume;
			textBoxNettoWeight.Text = _order.NettoWeight;
			numericUpDownNet.Value = (decimal) _order.Net;
			metroTextBoxIncoTermRef.Text = _order.IncoTermRef;
			metroTextBoxTrackingNo.Text = _order.TrackingNo;
			comboBoxShipTo.SelectedItem = _supplierShipper.FirstOrDefault(i => i.ItemId == _order.ShipToId) ?? Supplier.Unknown;
			comboBoxShipComp.SelectedItem = _supplierShipper.FirstOrDefault(i => i.ItemId == _order.ShipCompanyId) ?? Supplier.Unknown;
			comboBoxStation.SelectedItem = _airportsCodes.FirstOrDefault(i => i.ItemId == _order.StationId) ?? AirportsCodes.Unknown;
		}

		#endregion

		#region private void ApplyOrderData()
		private void ApplyPurchaseData()
		{
			_order.Title = textBoxTitle.Text;
			_order.Number = metroTextBoxNumber.Text;
			_order.Status = (WorkPackageStatus)comboBoxStatus.SelectedItem;
			_order.Remarks = textBoxRemarks.Text;

			_order.IncoTerm = (IncoTerm)comboBoxIncoTerm.SelectedItem;
			_order.Designation = (Designation)comboBoxDesignation.SelectedItem;
			_order.PayTerm = (PayTerm)comboBoxPayTerm.SelectedItem;
			_order.BruttoWeight = textBoxBruttoWeight.Text;
			_order.CargoVolume = textBoxCargoVolume.Text;
			_order.NettoWeight = textBoxNettoWeight.Text;
			_order.ShipCompanyId = ((Supplier)comboBoxShipComp.SelectedItem).ItemId;
			_order.ShipCompany = (Supplier)comboBoxShipComp.SelectedItem;
			_order.ShipToId = ((Supplier)comboBoxShipTo.SelectedItem).ItemId;
			_order.Net = (float) numericUpDownNet.Value;
			_order.IncoTermRef = metroTextBoxIncoTermRef.Text;
			_order.StationId = ((AirportsCodes)comboBoxStation.SelectedItem).ItemId;
			_order.TrackingNo = metroTextBoxTrackingNo.Text;

			if (_order.ItemId <= 0)
				_order.Author = GlobalObjects.CasEnvironment.IdentityUser.ToString();

			if (_order.Status == WorkPackageStatus.All)
			{
				_order.OpeningDate = dateTimePickerOpeningDate.Value;
				_order.ClosingDate = dateTimePickerClosingDate.Value;
				_order.PublishingDate = dateTimePickerPublishDate.Value;
			}
			else if (_order.Status == WorkPackageStatus.Opened)
			{
				_order.OpeningDate = dateTimePickerOpeningDate.Value;
			}
			else if (_order.Status == WorkPackageStatus.Closed)
			{
				_order.ClosingDate = dateTimePickerClosingDate.Value;
			}
			else if (_order.Status == WorkPackageStatus.Published)
			{
				_order.PublishingDate = dateTimePickerPublishDate.Value;
			}
		}
		#endregion

		private void buttonOk_Click(object sender, EventArgs e)
		{
			if (textBoxTitle.Text == "")
			{
				MessageBox.Show("Please, enter a Title", (string)new GlobalTermsProvider()["SystemName"],
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation);
			}
			//запись новой информации в запросный ордер
			ApplyPurchaseData();
			//сохранение запросного ордера
			GlobalObjects.CasEnvironment.NewKeeper.Save(_order);
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
