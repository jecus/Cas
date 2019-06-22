using MetroFramework.Forms;
using Telerik.WinControls.UI.Barcode.Symbology;

namespace CAS.UI.UIControls.BarCode
{
	public partial class BarcodeForm : MetroForm
	{
		private readonly string _value;

		public BarcodeForm()
		{
			InitializeComponent();
		}

		public BarcodeForm(string value) : this()
		{
			_value = value;
			radBarcode1.Symbology = new QRCode();
			radBarcode1.Value = _value;
		}

		private void ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
		{
			if(QR.IsChecked)
				radBarcode1.Symbology = new QRCode(){};
			else if(EAN128.IsChecked)
				radBarcode1.Symbology = new EAN128(){ShowText = true, Stretch = true};
			else if (Code128.IsChecked)
				radBarcode1.Symbology = new Code128() { ShowText = true, Stretch = true }; 

			radBarcode1.Value = _value;
		}
	}
}
