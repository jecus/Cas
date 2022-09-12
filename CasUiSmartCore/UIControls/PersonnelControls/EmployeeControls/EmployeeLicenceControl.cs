using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UIControls.PersonnelControls.EmployeeControls
{
	public partial class EmployeeLicenceControl : UserControl
	{
		#region Fields

		private Specialist _currentItem;
		private List<AircraftModel> _aircraftModels = new List<AircraftModel>();

		#endregion

		#region Properties

		public FlowLayoutPanel FlowLayoutPanelGeneralControl
		{
			get { return flowLayoutPanelGeneralControl; }
		}

		public int OperatorId { get; set; }

		#endregion

		#region Constructor

		public EmployeeLicenceControl()
		{
			InitializeComponent();
			int vertScrollWidth = SystemInformation.VerticalScrollBarWidth;
			flowLayoutPanelGeneralControl.Padding = new Padding(0, 0, vertScrollWidth, 0);
			tableLayoutPanel1.Padding = new Padding(0, 0, vertScrollWidth, 0);
		}

		#endregion

		#region public void UpdateControl()

		public void UpdateControl(Specialist currentItem, List<AircraftModel> aircraftModels)
		{
			if (currentItem == null)
				return;

			_currentItem = currentItem;
			_aircraftModels = aircraftModels;

			var ints = new object[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

			comboBoxPersonnel.Items.Clear();
			foreach (var o in PersonnelCategory.Items)
				comboBoxPersonnel.Items.Add(o);

			comboBoxClass.Items.Clear();
			comboBoxClass.Items.AddRange(ints);
			comboBoxGrade.Items.Clear();
			comboBoxGrade.Items.AddRange(ints);

			comboBoxClass.SelectedItem = _currentItem.ClassNumber;
			comboBoxGrade.SelectedItem = _currentItem.GradeNumber;
			dateTimePickerClassIssue.Value = _currentItem.ClassIssueDate;
			dateTimePickerGradeIssue.Value = _currentItem.GradeIssueDate;
			comboBoxPersonnel.SelectedItem = _currentItem.PersonnelCategory;

			if (_currentItem.Licenses.Count > 0)
			{
				flowLayoutPanelGeneralControl.Controls.Clear();
				foreach (var license in _currentItem.Licenses)
					AddLicenseGeneralControl(license);
			}
			else
			{
				var newLicense = new SpecialistLicense {SpecialistId = _currentItem.ItemId};
				_currentItem.Licenses.Add(newLicense);
				employeeLicenceGeneralControl.UpdateControl(newLicense, _currentItem.PersonnelCategory, aircraftModels);
			}

			//Detail
			if(_currentItem.LicenseDetails.Count > 0)
				flowLayoutPanelOtherDetail.Controls.Clear();

			foreach (var licenseDetail in _currentItem.LicenseDetails)
				AddDetailControl(licenseDetail);

			//Remark
			if (_currentItem.LicenseRemark.Count > 0)
				flowLayoutPanelRemark.Controls.Clear();

			foreach (var instrumentRating in _currentItem.LicenseRemark)
				AddRemarkControl(instrumentRating);
		}

		#endregion

		#region public bool ValidateData(out string message)

		public bool ValidateData(out string message)
		{
			message = "";
			var messageGeneralControl = "";
			string detailControl = "";
			string remarkControl = "";

			if (comboBoxPersonnel.SelectedItem == null)
			{
				if (message != "") message += "\n ";
				message += "Please select Personnel";
			}

			foreach (var control in flowLayoutPanelGeneralControl.Controls.OfType<EmployeeLicenceGeneralControl>())
				control.ValidateData(out messageGeneralControl);

			foreach (var control in flowLayoutPanelOtherDetail.Controls.OfType<EmployeeLicenceOtherDetailControl>())
				control.ValidateData(out detailControl);

			foreach (var control in flowLayoutPanelRemark.Controls.OfType<EmployeeLicenceRemarkControl>())
				control.ValidateData(out remarkControl);

			message += messageGeneralControl;
			message += detailControl;
			message += remarkControl;

			if (message != "")
				return false;
			return true;
		}

		#endregion

		#region public bool GetChangeStatus()

		public bool GetChangeStatus()
		{
			var generalControls = flowLayoutPanelGeneralControl.Controls.OfType<EmployeeLicenceGeneralControl>();
			var detailControls = flowLayoutPanelOtherDetail.Controls.OfType<EmployeeLicenceOtherDetailControl>();
			var remarkControls = flowLayoutPanelRemark.Controls.OfType<EmployeeLicenceRemarkControl>();

			return _currentItem.PersonnelCategory.ItemId != ((PersonnelCategory)comboBoxPersonnel.SelectedItem).ItemId ||
				   _currentItem.ClassNumber != (int)comboBoxClass.SelectedItem ||
			       _currentItem.GradeNumber != (int)comboBoxGrade.SelectedItem ||
			       _currentItem.ClassIssueDate != dateTimePickerClassIssue.Value ||
			       _currentItem.GradeIssueDate != dateTimePickerGradeIssue.Value ||
			       generalControls.Any(e => e.GetChangeStatus()) ||
				   remarkControls.Any(e => e.GetChangeStatus()) || 
				   detailControls.Any(d => d.GetChangeStatus());
		}

		#endregion

		#region public void ApplyChanges()

		public void ApplyChanges()
		{
			_currentItem.PersonnelCategory = (PersonnelCategory)comboBoxPersonnel.SelectedItem;
			_currentItem.ClassNumber = (int) comboBoxClass.SelectedItem;
			_currentItem.GradeNumber = (int) comboBoxGrade.SelectedItem;
			_currentItem.ClassIssueDate = dateTimePickerClassIssue.Value;
			_currentItem.GradeIssueDate = dateTimePickerGradeIssue.Value;

			foreach (var control in flowLayoutPanelGeneralControl.Controls.OfType<EmployeeLicenceGeneralControl>())
				control.ApplyChanges();

			foreach (var control in flowLayoutPanelOtherDetail.Controls.OfType<EmployeeLicenceOtherDetailControl>())
				control.ApplyChanges();

			foreach (var control in flowLayoutPanelRemark.Controls.OfType<EmployeeLicenceRemarkControl>())
				control.ApplyChanges();
		}

		#endregion

		#region private void linkLabelRemark_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

		private void linkLabelRemark_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var newRemark = new SpecialistLicenseRemark();
			_currentItem.LicenseRemark.Add(newRemark);
			AddRemarkControl(newRemark);
		}

		#endregion

		#region private void RemarkControl_Deleted(object sender, EventArgs e)

		private void RemarkControl_Deleted(object sender, EventArgs e)
		{
			var control = sender as EmployeeLicenceRemarkControl;

			var dialogResult = MessageBox.Show("Do you really want to delete Remark?", "Deleting confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
			if (dialogResult == DialogResult.Yes)
			{
				if (control.LicenseRemark.ItemId > 0)
				{
					try
					{
						if(GlobalObjects.CasEnvironment != null)
							GlobalObjects.CasEnvironment.Manipulator.Delete(control.LicenseRemark, false);
						else GlobalObjects.CaaEnvironment.NewKeeper.Delete(control.LicenseRemark, false)
					}
					catch (Exception ex)
					{
						Program.Provider.Logger.Log("Error while removing data", ex);
					}
				}
				flowLayoutPanelRemark.Controls.Remove(control);
				flowLayoutPanelRemark.Height -= 60;
				control.Deleted -= RemarkControl_Deleted;
				control.Dispose();
			}
		}

		#endregion

		#region private void linkLabelAddOtherDetail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

		private void linkLabelAddOtherDetail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var newSpecialistLicense = new SpecialistLicenseDetail();
			_currentItem.LicenseDetails.Add(newSpecialistLicense);
			AddDetailControl(newSpecialistLicense);
		}

		#endregion

		#region private void OtherDetailControl_Deleted(object sender, EventArgs e)

		private void OtherDetailControl_Deleted(object sender, EventArgs e)
		{
			var control = sender as EmployeeLicenceOtherDetailControl;

			var dialogResult = MessageBox.Show("Do you really want to delete Other Detail?", "Deleting confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

			if (dialogResult == DialogResult.Yes)
			{
				if (control.LicenseDetail.ItemId > 0)
				{
					try
					{
						if(GlobalObjects.CasEnvironment != null)
							GlobalObjects.CasEnvironment.Manipulator.Delete(control.LicenseDetail, false);
						else GlobalObjects.CaaEnvironment.NewKeeper.Delete(control.LicenseDetail, false);
					}
					catch (Exception ex)
					{
						Program.Provider.Logger.Log("Error while removing data", ex);
					}
				}

				flowLayoutPanelOtherDetail.Controls.Remove(control);
				flowLayoutPanelOtherDetail.Height -= 80;
				control.Deleted -= OtherDetailControl_Deleted;
				control.Dispose();
			}
			
		}

		#endregion

		#region private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var newLicense = new SpecialistLicense { SpecialistId = _currentItem.ItemId };
			_currentItem.Licenses.Add(newLicense);
			AddLicenseGeneralControl(newLicense);
		}

		#endregion

		#region private void Control_Deleted(object sender, EventArgs e)

		private void Control_Deleted(object sender, EventArgs e)
		{
			var control = sender as EmployeeLicenceGeneralControl;

			var dialogResult = MessageBox.Show("Do you really want to delete license?", "Deleting confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

			if (dialogResult == DialogResult.Yes)
			{
				var license = control.License;
				if (control.License.ItemId > 0)
				{
					if(GlobalObjects.CasEnvironment != null)
						GlobalObjects.PersonnelCore.Delete(license);
					else
					{
						foreach (var remark in license.LicenseRemark)
							GlobalObjects.CaaEnvironment.NewKeeper.Delete(remark);
						foreach (var caa in license.CaaLicense)
							GlobalObjects.CaaEnvironment.NewKeeper.Delete(caa);
						foreach (var detail in license.LicenseDetails)
							GlobalObjects.CaaEnvironment.NewKeeper.Delete(detail);
						foreach (var rating in license.LicenseRatings)
							GlobalObjects.CaaEnvironment.NewKeeper.Delete(rating);
						foreach (var instrumentRating in license.SpecialistInstrumentRatings)
							GlobalObjects.CaaEnvironment.NewKeeper.Delete(instrumentRating);

						GlobalObjects.CaaEnvironment.NewKeeper.Delete(license);
					} 
				}

				flowLayoutPanelGeneralControl.Controls.Remove(control);
				control.Deleted -= Control_Deleted;
				control.Dispose();

				if (flowLayoutPanelGeneralControl.Controls.Count == 0)
				{
					var newLicense = new SpecialistLicense { SpecialistId = _currentItem.ItemId };
					_currentItem.Licenses.Add(newLicense);
					AddLicenseGeneralControl(newLicense, false);
				}
			}

			
		}

		#endregion

		#region private void comboBoxPersonnel_SelectedIndexChanged(object sender, EventArgs e)

		private void comboBoxPersonnel_SelectedIndexChanged(object sender, EventArgs e)
		{
			var selectedCategory = (PersonnelCategory) comboBoxPersonnel.SelectedItem;
			foreach (var control in flowLayoutPanelGeneralControl.Controls.OfType<EmployeeLicenceGeneralControl>())
				control.UpdateLicenceCombobox(selectedCategory);
		}

		#endregion

		#region private void AddDetailControl(SpecialistLicenseDetail licenseDetail)

		private void AddDetailControl(SpecialistLicenseDetail licenseDetail)
		{
			var control = new EmployeeLicenceOtherDetailControl();

			control.UpdateControl(licenseDetail);
			control.Deleted += OtherDetailControl_Deleted;

			flowLayoutPanelOtherDetail.Controls.Remove(linkLabelAddOtherDetail);
			flowLayoutPanelOtherDetail.Controls.Add(control);
			flowLayoutPanelOtherDetail.Controls.Add(linkLabelAddOtherDetail);
			flowLayoutPanelOtherDetail.Height += 80;
		}

		#endregion

		#region private void AddRemarkControl(SpecialistLicenseRemark licenseRemark)

		private void AddRemarkControl(SpecialistLicenseRemark licenseRemark)
		{
			var control = new EmployeeLicenceRemarkControl();
			control.UpdateInformation(licenseRemark);
			control.Deleted += RemarkControl_Deleted;

			flowLayoutPanelRemark.Controls.Remove(linkLabelRemark);
			flowLayoutPanelRemark.Controls.Add(control);
			flowLayoutPanelRemark.Controls.Add(linkLabelRemark);
			flowLayoutPanelRemark.Height += 60;
		}

		#endregion

		#region private void AddLicenseGeneralControl(SpecialistLicense license, bool showLink = true)

		private void AddLicenseGeneralControl(SpecialistLicense license, bool showLink = true)
		{
			var control = new EmployeeLicenceGeneralControl { ShowLinkDelete = showLink, OperatorId = OperatorId };
			control.UpdateControl(license, _currentItem.PersonnelCategory, _aircraftModels);
			control.Deleted += Control_Deleted;
			control.Reload += ControlOnReload;
			flowLayoutPanelGeneralControl.Controls.Add(control);
		}

		private void ControlOnReload(object sender, EventArgs e)
		{
			InvokeReload();
		}

		#endregion
		
		#region Events
		/// <summary>
		/// Событие возникает при добавлени, удалении и фильтрации(Производится перегрузка EmployeeScreen)
		/// </summary>
		public event EventHandler Reload;
		public void InvokeReload()
		{
			EventHandler handler = Reload;
			if (Reload != null) handler(this, new EventArgs());

		}
		#endregion
	}
}
