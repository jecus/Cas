using System.Windows.Forms;
using MetroFramework.Forms;
using SmartCore.Auxiliary;
using SmartCore.Entities.General.Accessory;

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
			UpdateControls();
			QR.IsChecked = true;
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
			
			//if (QR.IsChecked)
			//	code = BarcodeWriter.CreateBarcode(_component.ItemId.ToString(), BarcodeEncoding.QRCode);
			//else if(EAN128.IsChecked)
			//	code = BarcodeWriter.CreateBarcode(_component.ItemId.ToString(), BarcodeEncoding.EAN13);
			//else if (Code128.IsChecked)
			//	code = BarcodeWriter.CreateBarcode(_component.ItemId.ToString(), BarcodeEncoding.Code128);

			
			////code.AddAnnotationTextAboveBarcode("Product ID:");
			////code.AddBarcodeValueTextBelowBarcode();

			//pictureBox1.Image = code.ResizeTo(210, 50).Image;
			//pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
		}

		private void ButtonOk_Click(object sender, System.EventArgs e)
		{
			//BarCode = DbTypes.ImageToBytes(radBarcode1.ExportToImage(), ImageFormat.Jpeg);
			//BarCode = code.ResizeTo(210, 37).ToPngBinaryData();
			//DialogResult = DialogResult.OK;
		}


	}
}
