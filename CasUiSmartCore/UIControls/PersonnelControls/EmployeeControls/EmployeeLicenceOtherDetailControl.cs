using System;
using System.Windows.Forms;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UIControls.PersonnelControls.EmployeeControls
{
	public partial class EmployeeLicenceOtherDetailControl : UserControl
	{
		#region Properties

		private SpecialistLicenseDetail _licenseDetail;

		public SpecialistLicenseDetail LicenseDetail
		{
			get { return _licenseDetail; }
		}

		#endregion

		#region Constructor

		public EmployeeLicenceOtherDetailControl()
		{
			InitializeComponent();
		}

		#endregion

		#region Methods

		#region public void UpdateControl(SpecialistLicenseDetail licenseDetail)

		public void UpdateControl(SpecialistLicenseDetail licenseDetail)
		{
			_licenseDetail = licenseDetail;

			textboxDescription.Text = _licenseDetail.Description;
			dateTimePickerIssue.Value = _licenseDetail.IssueDate;
		}

		#endregion

		#region public bool ValidateData(out string message)

		public bool ValidateData(out string message)
		{
			message = "";
			

			if (message != "")
				return false;
			return true;
		}

		#endregion

		#region public bool GetChangeStatus()

		public bool GetChangeStatus()
		{
			return textboxDescription.Text != _licenseDetail.Description ||
			       dateTimePickerIssue.Value != _licenseDetail.IssueDate;
		}

		#endregion

		#region public void ApplyChanges()

		public void ApplyChanges()
		{
			_licenseDetail.Description = textboxDescription.Text;
			_licenseDetail.IssueDate = dateTimePickerIssue.Value;
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
