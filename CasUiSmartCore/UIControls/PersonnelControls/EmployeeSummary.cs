using System.Linq;
using System.Windows.Forms;
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
			labelOccupationValue.Text = _currentItem.Specialization.ToString();
			labelEducationValue.Text = _currentItem.Education.ToString();
			labelPositionValue.Text = _currentItem.Position.ToString();
			labelLocationVAlue.Text = _currentItem.Facility.ToString();
			labelStatusValue.Text = _currentItem.Status.ToString();
			labelPhoneMobileValue.Text = _currentItem.PhoneMobile;
			labelPhoneValue.Text = _currentItem.Phone;
			labelEmailValue.Text = _currentItem.Email;
			labelSkypeValue.Text = _currentItem.Skype;
			_pictureBoxTransparentLogotype.BackgroundImage = _currentItem.PhotoImage;
			pictureBoxSign.BackgroundImage = _currentItem.SignImage;

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
