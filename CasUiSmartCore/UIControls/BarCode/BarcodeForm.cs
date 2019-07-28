using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using MetroFramework.Forms;
using SmartCore.Auxiliary;
using SmartCore.Entities.General.Accessory;
using Telerik.WinControls.UI.Barcode.Symbology;

namespace CAS.UI.UIControls.BarCode
{
	public partial class BarcodeForm : MetroForm
	{
		private Component _component;

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

		private Bitmap bmp;

		private void ButtonOk_Click(object sender, System.EventArgs e)
		{
			Graphics g = CreateGraphics();
			bmp = new Bitmap(Size.Width, Size.Height, g);
			Graphics mg = Graphics.FromImage(bmp);
			mg.CopyFromScreen(Location.X, Location.Y+55, 0, 0, new Size(Size.Width, Size.Height-105));
			var print = new PrintPreviewDialog();
			var doc = new PrintDocument();
			doc.PrintPage += Doc_PrintPage;
			print.Document = doc;
			print.ShowDialog();
		}

		private void Doc_PrintPage(object sender, PrintPageEventArgs e)
		{
			e.Graphics.DrawImage(bmp, 0, 0);
		}
	}
}
