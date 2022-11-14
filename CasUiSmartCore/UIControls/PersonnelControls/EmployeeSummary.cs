using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using QRCoder;
using SmartCore.Entities.General.Personnel;
using Convert = SmartCore.Auxiliary.Convert;

namespace CAS.UI.UIControls.PersonnelControls
{
	public partial class EmployeeSummary : UserControl
	{
		private Specialist _currentItem;

		#region public Specialist CurrentItem
		///<summary>
		///Текущая директива
		///</summary>
		public Specialist CurrentItem
		{
			set
			{
				_currentItem = value;
				if (_currentItem != null)
				{
					UpdateInformation();
				}
			}
		}

		#endregion

		public EmployeeSummary()
		{
			InitializeComponent();
		}

		#region private void UpdateInformation()

		private void UpdateInformation()
		{
			if(_currentItem == null)
				return;

			labelFirstNameValue.Text = _currentItem.FirstName;
			labelLastNameValue.Text = _currentItem.LastName;
			labelDateOfBirthValue.Text = Convert.GetDateFormat(_currentItem.DateOfBirth);
			labelSexValue.Text = _currentItem.Gender.ToString();
			labelNationalityValue.Text = _currentItem.Citizenship.ToString();
			labelAddressValue.Text = _currentItem.Address;
			labelInformationValue.Text = _currentItem.Information;
			labelFamilyStatusValue.Text = _currentItem.FamilyStatus.ToString();
			labelOccupationValue.Text = _currentItem.Occupation.ToString();
			labelEducationValue.Text = _currentItem.Education.ToString();
			labelPositionValue.Text = _currentItem.Position.ToString();
			labelLocationVAlue.Text = _currentItem.Facility.ToString();
			labelStatusValue.Text = _currentItem.Status.ToString();
			labelPhoneMobileValue.Text = _currentItem.PhoneMobile;
			labelPhoneValue.Text = _currentItem.Phone;
			labelEmailValue.Text = _currentItem.Email;
			labelSkypeValue.Text = _currentItem.Skype;

			if (GlobalObjects.CaaEnvironment != null)
			{
				_pictureBoxTransparentLogotype.BackgroundImage = _currentItem.Images.PhotoImage;
				pictureBoxSign.BackgroundImage = _currentItem.Images.SignImage;
			}
			else
			{
				_pictureBoxTransparentLogotype.BackgroundImage = _currentItem.PhotoImage;
				pictureBoxSign.BackgroundImage = _currentItem.SignImage;
			}
			
			


			if (GlobalObjects.CaaEnvironment == null)
			{
				pictureBox1.Visible = false;
				label4.Visible = false;
				labelQR.Visible = false;
				pictureBoxQR.Visible = false;
			}
			else
			{
				

				var text = $"First Name: {_currentItem.FirstName}\n" +
				            $"Last Name: {_currentItem.LastName}\n" +
				            $"Date of Birth: {Convert.GetDateFormat(_currentItem.DateOfBirth)}\n" +
				            $"Sex: {_currentItem.Gender.ToString()}\n" +
				            $"Nationality: {_currentItem.Citizenship}\n";

				var licence = _currentItem.Licenses.FirstOrDefault();
				
				if (licence != null)
				{
					var licenseCaa = licence.CaaLicense.FirstOrDefault(c => c.CaaType == CaaType.Licence);
					text += $"Issue by CAA:{licenseCaa?.Caa.ShortName} \n" +
					        $"Licence Type: {licence.EmployeeLicenceType}\n" +
					        $"Licence №: {licenseCaa?.CAANumber}\n" +
					        $"Valid To: {licence?.ValidToDate:dd.MM.yyyy}\n";
				}
				

				//text += $"Contact: {_currentItem.Email}";
				
				var qrGenerator = new QRCodeGenerator();
				var qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.H);
				var qrCode = new QRCode(qrCodeData);
				var qrCodeImage = qrCode.GetGraphic(15);

				ImageConverter converter = new ImageConverter();
				_currentItem.Images.QR = (byte[])converter.ConvertTo(qrCodeImage, typeof(byte[]));

				pictureBoxQR.BackgroundImage = qrCodeImage;
				if (GlobalObjects.CaaEnvironment != null)
					pictureBox1.BackgroundImage = _currentItem.Images.StampImage;
				else pictureBox1.BackgroundImage = _currentItem.StampImage;
			}
			
			
			labelGradeValue.Text =_currentItem.GradeNumber.ToString();
			labelClassValue.Text =_currentItem.ClassNumber.ToString();

			var ratingString = "";
			foreach (var license in _currentItem.Licenses)
			{
				if (license.LicenseRatings.Count == 0)
					continue;

				if (ratingString != "")
					ratingString += " / ";

				ratingString += license.AircraftType.ShortName;
				ratingString += "-";

				foreach (var rating in license.LicenseRatings.GroupBy(r => r.LicenseFunction))
					ratingString += $"{rating.Key} ({string.Join(",", rating.Select(r => r.Rights.ShortName).ToArray())}) ";
			}

			labelRightVAlue.Text = ratingString;

		}

		#endregion

	}
}
