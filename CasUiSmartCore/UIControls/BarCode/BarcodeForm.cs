using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using MetroFramework.Forms;
using SmartCore.Auxiliary;
using SmartCore.Entities.General.Accessory;
using SmartCore.Management;
using Telerik.WinControls.UI.Barcode.Symbology;

namespace CAS.UI.UIControls.BarCode
{
	public partial class BarcodeForm : MetroForm
	{
		private Component _component;
		public byte[] BarCode { get; set; }
	

		public BarcodeForm()
		{
			InitializeComponent();
		}

		public BarcodeForm(Component component) : this()
		{
			_component = component;
			radBarcode1.Symbology = new QRCode();
			radBarcode1.Value = _component.ItemId.ToString();
			
			UpdateControls();
		}

		private void UpdateControls()
		{
			var transferDate = _component.TransferRecords.GetLast().TransferDate;

			textBoxName.Text = _component.Name;
			textBoxAta.Text = _component.AtaSorted.ToString();
			textBoxSerialNo.Text = _component.SerialNumber;
			textBoxPartNo.Text = _component.PartNumber;
			textBoxStatus.Text = _component.Status.ToString();
			textBoxQty.Text = _component.Quantity.ToString();
			textBoxBatchNo.Text = _component.BatchNumber;
			textBoxInstData.Text = transferDate > DateTimeExtend.GetCASMinDateTime()
				? SmartCore.Auxiliary.Convert.GetDateFormat(transferDate) : "";
		}

		private void ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
		{
			if(QR.IsChecked)
				radBarcode1.Symbology = new QRCode(){};
			else if(EAN128.IsChecked)
				radBarcode1.Symbology = new EAN128(){ShowText = true, Stretch = true};
			else if (Code128.IsChecked)
				radBarcode1.Symbology = new Code128() { ShowText = true, Stretch = true }; 

			radBarcode1.Value = _component.ItemId.ToString();
		}

		private void ButtonOk_Click(object sender, System.EventArgs e)
		{
			BarCode = DbTypes.ImageToBytes(radBarcode1.ExportToImage(), ImageFormat.Jpeg);
			DialogResult = DialogResult.OK;
		}


	}
}
