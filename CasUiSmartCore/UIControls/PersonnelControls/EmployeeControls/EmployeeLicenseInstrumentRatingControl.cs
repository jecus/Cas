using System;
using System.Windows.Forms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UIControls.PersonnelControls.EmployeeControls
{
	public partial class EmployeeLicenseInstrumentRatingControl : UserControl
	{
		private SpecialistInstrumentRating _instrumentRating;

		#region Properties

		public SpecialistInstrumentRating InstrumentRating { get { return _instrumentRating; } }

		#endregion

		#region Constuctor

		public EmployeeLicenseInstrumentRatingControl()
		{
			InitializeComponent();
		}

		#endregion

		#region Methods

		#region public void UpdateControl(SpecialistLicenseDetail licenseDetail)

		public void UpdateControl(SpecialistInstrumentRating instrumentRating)
		{
			_instrumentRating = instrumentRating;

			comboBoxIcao.Items.Clear();
			comboBoxMCDH.Items.Clear();
			comboBoxMV.Items.Clear();
			comboBoxRVR.Items.Clear();
			comboBoxToRVR.Items.Clear();

			foreach (var o in LicenseIcao.Items)
				comboBoxIcao.Items.Add(o);

			var ints = new object[] {0,50,100,150,200,250,300,350,400,450,500,550,600,650,700,750,800,850,900,950,1000};
			comboBoxMCDH.Items.AddRange(new object[] {0,5,10,15,20,25,30,35,40,45,50,55,60});
			comboBoxMV.Items.AddRange(ints);
			comboBoxRVR.Items.AddRange(ints);
			comboBoxToRVR.Items.AddRange(ints);

			comboBoxIcao.SelectedItem = _instrumentRating.Icao;
			comboBoxMCDH.SelectedItem = _instrumentRating.MC;
			comboBoxMV.SelectedItem = _instrumentRating.MV;
			comboBoxRVR.SelectedItem = _instrumentRating.RVR;
			comboBoxToRVR.SelectedItem = _instrumentRating.TORVR;
			dateTimePickerIssue.Value = _instrumentRating.IssueDate;
		}

		#endregion

		#region public bool ValidateData(out string message)

		public bool ValidateData(out string message)
		{
			message = "";

			if (comboBoxIcao.SelectedItem == null)
			{
				if (message != "") message += "\n ";
				message += "Please select Icao Cat";
			}
			if (comboBoxMCDH.SelectedItem == null)
			{
				if (message != "") message += "\n ";
				message += "Please select MCDH";
			}
			if (comboBoxMV.SelectedItem == null)
			{
				if (message != "") message += "\n ";
				message += "Please select MV";
			}
			if (comboBoxRVR.SelectedItem == null)
			{
				if (message != "") message += "\n ";
				message += "Please select RVR";
			}
			if (comboBoxToRVR.SelectedItem == null)
			{
				if (message != "") message += "\n ";
				message += "Please select To RVR";
			}

			if (message != "")
				return false;
			return true;
		}

		#endregion

		#region public bool GetChangeStatus()

		public bool GetChangeStatus()
		{
			return comboBoxIcao.SelectedItem != _instrumentRating.Icao ||
			       _instrumentRating.MC !=  (int) comboBoxMCDH.SelectedItem   ||
			       _instrumentRating.MV != (int) comboBoxMV.SelectedItem  ||
			       _instrumentRating.RVR != (int) comboBoxRVR.SelectedItem ||
			       _instrumentRating.TORVR != (int) comboBoxToRVR.SelectedItem ||
			       dateTimePickerIssue.Value != _instrumentRating.IssueDate;
		}

		#endregion

		#region public void ApplyChanges()

		public void ApplyChanges()
		{
			_instrumentRating.Icao = (LicenseIcao) comboBoxIcao.SelectedItem;
			_instrumentRating.MC = (int) comboBoxMCDH.SelectedItem;
			_instrumentRating.MV = (int) comboBoxMV.SelectedItem;
			_instrumentRating.RVR = (int) comboBoxRVR.SelectedItem;
			_instrumentRating.TORVR = (int) comboBoxToRVR.SelectedItem;
			_instrumentRating.IssueDate = dateTimePickerIssue.Value;
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
