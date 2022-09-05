using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UIControls.PersonnelControls.EmployeeControls
{
	public partial class EmployeeLicenceRatingControl : UserControl
	{
		private SpecialistLicenseRating _licenseRating;

		#region Properties

		public SpecialistLicenseRating LicenseRating {get { return _licenseRating; } }

		#endregion

		#region Constuctor

		public EmployeeLicenceRatingControl()
		{
			InitializeComponent();
		}

		#endregion

		#region Methods

		#region public void UpdateInformation(SpecialistLicenseRating licenseRating)

		public void UpdateInformation(SpecialistLicenseRating licenseRating, EmployeeLicenceType licenseEmployeeLicenceType)
		{
			_licenseRating = licenseRating;

			UpdateComboboxs(licenseEmployeeLicenceType);

			dateTimePickerIssue.Value = _licenseRating.IssueDate;
		}

		#endregion

		#region public bool ValidateData(out string message)

		public bool ValidateData(out string message)
		{
			message = "";

			if (comboBoxRights.SelectedItem == null)
			{
				if (message != "") message += "\n ";
				message += "Please select Rights";
			}

			if (comboBoxFunction.SelectedItem == null)
			{
				if (message != "") message += "\n ";
				message += "Please select Function";
			}

			if (message != "")
				return false;
			return true;
		}

		#endregion

		#region public bool GetChangeStatus()

		public bool GetChangeStatus()
		{
			return comboBoxRights.SelectedItem != _licenseRating.Rights ||
			       comboBoxFunction.SelectedItem != _licenseRating.LicenseFunction ||
			       dateTimePickerIssue.Value != _licenseRating.IssueDate;
		}

		#endregion

		#region public void ApplyChanges()

		public void ApplyChanges()
		{
			_licenseRating.Rights = (LicenseRights)comboBoxRights.SelectedItem;
			_licenseRating.LicenseFunction = (LicenseFunction) comboBoxFunction.SelectedItem;
			_licenseRating.IssueDate = dateTimePickerIssue.Value;
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

		public void UpdateComboboxs(EmployeeLicenceType selectedCategory)
		{
			comboBoxFunction.Items.Clear();
			comboBoxRights.Items.Clear();

			IEnumerable<LicenseFunction> listFunction = null;
			IEnumerable<LicenseRights> listRights = null;

			if (selectedCategory.Category == PersonnelCategory.FlightCrewMembersPilots)
			{
				listFunction = LicenseFunction.Items.Where(l => l.Category == selectedCategory.Category);
				foreach (var o in listFunction)
					comboBoxFunction.Items.Add(o);

				comboBoxFunction.Items.Add(LicenseFunction.UNK);

				listRights = LicenseRights.Items.Where(l => l.Category == selectedCategory.Category);
				foreach (var o in listRights)
					comboBoxRights.Items.Add(o);
				comboBoxRights.Items.Add(LicenseRights.UNK);
			}
			else if (selectedCategory == EmployeeLicenceType.AircraftMaintenanceEngineer ||
			         selectedCategory == EmployeeLicenceType.AircraftMaintenanceMechanic ||
			         selectedCategory == EmployeeLicenceType.AircraftMaintenanceTechnician)
			{
				listFunction = LicenseFunction.Items.Where(l => l.Category != PersonnelCategory.FlightCrewMembersPilots);
				foreach (var o in listFunction)
					comboBoxFunction.Items.Add(o);

				listRights = LicenseRights.Items.Where(l => l.Category != PersonnelCategory.FlightCrewMembersPilots);
				foreach (var o in listRights)
					comboBoxRights.Items.Add(o);
			}
			else
			{
				comboBoxFunction.Items.Add(LicenseFunction.UNK);
				comboBoxRights.Items.Add(LicenseRights.UNK);
			}


			if (listFunction != null)
				comboBoxFunction.SelectedItem = listFunction.FirstOrDefault(e => e == _licenseRating.LicenseFunction) ??LicenseFunction.UNK;
			else comboBoxFunction.SelectedItem = LicenseFunction.UNK;

			if(listRights != null)
				comboBoxRights.SelectedItem = listRights.FirstOrDefault(e => e == _licenseRating.Rights) ?? LicenseRights.UNK;
			else comboBoxRights.SelectedItem = LicenseRights.UNK;
		}
	}
}
