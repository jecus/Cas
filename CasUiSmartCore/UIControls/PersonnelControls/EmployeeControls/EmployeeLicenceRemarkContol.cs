using System;
using System.Windows.Forms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UIControls.PersonnelControls.EmployeeControls
{
	public partial class EmployeeLicenceRemarkControl : UserControl
	{
		private SpecialistLicenseRemark _licenseRemark;

		#region Properties

		public SpecialistLicenseRemark LicenseRemark { get { return _licenseRemark; } }

		#endregion

		#region Constuctor

		public EmployeeLicenceRemarkControl()
		{
			InitializeComponent();
		}

		#endregion

		#region Methods

		#region public void UpdateInformation(SpecialistLicenseRemark licenseRemark)

		public void UpdateInformation(SpecialistLicenseRemark licenseRemark)
		{
			_licenseRemark = licenseRemark;

			dictionaryComboBoxRestriction.Type = typeof(LicenseRestriction);
			dictionaryComboBoxRights.Type = typeof(LicenseRemarkRights);

			dictionaryComboBoxRights.SelectedItem = _licenseRemark.Rights;
			dictionaryComboBoxRestriction.SelectedItem = _licenseRemark.LicenseRestriction;
			dateTimePickerIssue.Value = _licenseRemark.IssueDate;
		}

		#endregion

		#region public bool ValidateData(out string message)

		public bool ValidateData(out string message)
		{
			message = "";

			if (dictionaryComboBoxRights.SelectedItem == null)
			{
				if (message != "") message += "\n ";
				message += "Please select Rights";
			}

			if (dictionaryComboBoxRestriction.SelectedItem == null)
			{
				if (message != "") message += "\n ";
				message += "Please select Restriction";
			}

			if (message != "")
				return false;
			return true;
		}

		#endregion

		#region public bool GetChangeStatus()

		public bool GetChangeStatus()
		{
			return dictionaryComboBoxRights.SelectedItem != _licenseRemark.Rights ||
				   dictionaryComboBoxRestriction.SelectedItem != _licenseRemark.LicenseRestriction ||
			       dateTimePickerIssue.Value != _licenseRemark.IssueDate;
		}

		#endregion

		#region public void ApplyChanges()

		public void ApplyChanges()
		{
			_licenseRemark.Rights = (LicenseRemarkRights)dictionaryComboBoxRights.SelectedItem;
			_licenseRemark.LicenseRestriction = (LicenseRestriction)dictionaryComboBoxRestriction.SelectedItem;
			_licenseRemark.IssueDate = dateTimePickerIssue.Value;
		}

		#endregion

		#region Events

		private void buttonDelete_Click_1(object sender, EventArgs e)
		{
			if (Deleted != null)
				Deleted(this, EventArgs.Empty);
		}

		public event EventHandler Deleted;

#endregion

		#endregion

	}
}
