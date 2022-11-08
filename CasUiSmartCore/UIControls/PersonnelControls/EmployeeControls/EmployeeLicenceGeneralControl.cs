using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.DocumentationControls;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UIControls.PersonnelControls.EmployeeControls
{
	public partial class EmployeeLicenceGeneralControl : UserControl
	{
		#region Fields

		private SpecialistLicense _license;

		#endregion

		#region Properties

		#region public bool ShowLinkDelete {set;}

		public bool ShowLinkDelete
		{
			set
			{
				linkLabelRemove.Visible = value;
			}
		}

		#endregion

		public SpecialistLicense License { get { return _license; } }

		public int EmployeeLicenceTypeId { get { return ((EmployeeLicenceType) comboBoxLicenceType.SelectedItem).ItemId; } }
		public int OperatorId { get; set; }

		#endregion

		#region Constructors

		public EmployeeLicenceGeneralControl()
		{
			InitializeComponent();

			employeeLicenceLicenseCaaControl.IssueLabelText = "Issue:";
			int vertScrollWidth = SystemInformation.VerticalScrollBarWidth;
			tableLayoutPanel1.Padding = new Padding(0, 0, vertScrollWidth, 0);

		}

		#endregion

		public void UpdateControl(SpecialistLicense license, PersonnelCategory personnelCategory, List<AircraftModel> aircraftModels)
		{
			_license = license;
			UpdateLicenceCombobox(personnelCategory);

			//CAA
			var licenseCaa = _license.CaaLicense.FirstOrDefault(c => c.CaaType == CaaType.Licence);
			if (licenseCaa != null)
				employeeLicenceLicenseCaaControl.UpdateControl(licenseCaa);
			else
			{
				var newCaaLicense = new SpecialistCAA { CaaType = CaaType.Licence };
				employeeLicenceLicenseCaaControl.UpdateControl(newCaaLicense);
				_license.CaaLicense.Add(newCaaLicense);
			}

			foreach (var caa in _license.CaaLicense.Where(c => c.CaaType == CaaType.Other))
				AddCaaControl(caa);

			//Detail
			foreach (var licenseDetail in _license.LicenseDetails)
				AddDetailControl(licenseDetail);

			//Rating
			foreach (var licenseRating in _license.LicenseRatings)
				AddRatingControl(licenseRating);

			//InstrumentRating
			foreach (var instrumentRating in _license.SpecialistInstrumentRatings)
				AddInstrumentRatingControl(instrumentRating);

			//Remark
			foreach (var instrumentRating in _license.LicenseRemark)
				AddRemarkControl(instrumentRating);

			comboBoxCategory.Items.Clear();
			foreach (var aircraftModel in aircraftModels.OrderBy(i => i.FullName))
				comboBoxCategory.Items.Add(aircraftModel);

			comboBoxCategory.Items.Add(AircraftModel.Unknown);


			flowLayoutPanelCaa.Enabled = _license.Confirmation;

			
			UpdateInformation();
		}

		#region public void UpdateInformation()

		public void UpdateInformation()
		{
			checkBoxConfirmation.Checked = _license.Confirmation;
			comboBoxLicenceType.SelectedItem = _license.EmployeeLicenceType;
			comboBoxCategory.SelectedItem = _license.AircraftType;
			dateTimePickerValidToCAA.Value = _license.ValidToDate;
			dateTimePickerIssueDate.Value = _license.IssueDate;
			lifelengthViewer1.Lifelength = _license.NotifyLifelength;
			checkBoxIsValid.Checked = _license.IsValidTo;

			documentControl1.CurrentDocument = _license.Document;
			documentControl1.Added += DocumentControl1_Added;
			documentControl1.Remove += DocumentControl1_Removed;
		}

		#endregion
		
		private void DocumentControl1_Removed(object sender, EventArgs e)
		{
			InvokeReload();
		}

		#region private void DocumentControl1_Added(object sender, EventArgs e)

		private void DocumentControl1_Added(object sender, EventArgs e)
		{
			var newDocument = CreateNewDocument();
			var form = new DocumentForm(newDocument, false);
			if (form.ShowDialog() == DialogResult.OK)
			{
				_license.Document = newDocument;
				documentControl1.CurrentDocument = newDocument;
				InvokeReload();
			}
		}

		#endregion

		#region private Document CreateNewDocument()

		private Document CreateNewDocument()
		{
			DocumentSubType docSubType;
			if(GlobalObjects.CasEnvironment != null)
				docSubType = GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Personnel License") as DocumentSubType;
			else docSubType = GlobalObjects.CaaEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Personnel License") as DocumentSubType;

			
			if(_license.ItemId <= 0)
				GlobalObjects.CaaEnvironment.NewKeeper.Save(_license);
			
			return new Document
			{
				OperatorId = OperatorId,
				ParentId = _license.ItemId,
				Parent = _license,
				ParentTypeId = _license.SmartCoreObjectType.ItemId,
				DocType = DocumentType.Document,
				DocumentSubType = docSubType,
				IsClosed = false,
			};
		}

		#endregion

		#region public bool ValidateData(out string message)

		public bool ValidateData(out string message)
		{
			message = "";
			string caaControl = "";
			string caaLicenseControl;
			string detailControl = "";
			string ratingControl = "";
			string instrumentRatingControl = "";
			string remarkControl = "";

			if (comboBoxLicenceType.SelectedItem == null)
			{
				if (message != "") message += "\n ";
				message += "Please select License Type";
			}

			if (comboBoxCategory.SelectedItem == null)
			{
				if (message != "") message += "\n ";
				message += "Please select Aircraft Type";
			}

			foreach (var control in flowLayoutPanelCaa.Controls.OfType<EmployeeLicenceCaaControl>())
				control.ValidateData(out caaControl);

			employeeLicenceLicenseCaaControl.ValidateData(out caaLicenseControl);

			foreach (var control in flowLayoutPanelOtherDetail.Controls.OfType<EmployeeLicenceOtherDetailControl>())
				control.ValidateData(out detailControl);

			foreach (var control in flowLayoutPanelRating.Controls.OfType<EmployeeLicenceRatingControl>())
				control.ValidateData(out ratingControl);

			foreach (var control in flowLayoutPanelInstrumentRatings.Controls.OfType<EmployeeLicenseInstrumentRatingControl>())
				control.ValidateData(out instrumentRatingControl);

			foreach (var control in flowLayoutPanelRemark.Controls.OfType<EmployeeLicenceRemarkControl>())
				control.ValidateData(out remarkControl);

			message += caaControl;
			message += caaLicenseControl;
			message += detailControl;
			message += ratingControl;
			message += instrumentRatingControl;
			message += remarkControl;

			if (message != "")
				return false;
			return true;
		}

		#endregion

		#region public bool GetChangeStatus()

		public bool GetChangeStatus()
		{
			var caaControls = flowLayoutPanelCaa.Controls.OfType<EmployeeLicenceCaaControl>();
			var detailControls = flowLayoutPanelOtherDetail.Controls.OfType<EmployeeLicenceOtherDetailControl>();
			var ratingControls = flowLayoutPanelRating.Controls.OfType<EmployeeLicenceRatingControl>();
			var instrumentRatingControls = flowLayoutPanelInstrumentRatings.Controls.OfType<EmployeeLicenseInstrumentRatingControl>();
			var remarkControls = flowLayoutPanelRemark.Controls.OfType<EmployeeLicenceRemarkControl>();

			return _license.Confirmation != checkBoxConfirmation.Checked ||
			       _license.EmployeeLicenceType != (EmployeeLicenceType)comboBoxLicenceType.SelectedItem ||
			       _license.AircraftType != (AircraftModel)comboBoxCategory.SelectedItem ||
			       _license.ValidToDate != dateTimePickerValidToCAA.Value ||
			       _license.IsValidTo != checkBoxIsValid.Checked ||
			       _license.IssueDate != dateTimePickerIssueDate.Value ||
			       _license.NotifyLifelength != lifelengthViewer1.Lifelength ||
				   caaControls.Any(c => c.GetChangeStatus()) ||
				   ratingControls.Any(r => r.GetChangeStatus()) ||
				   detailControls.Any(d => d.GetChangeStatus()) ||
				   remarkControls.Any(d => d.GetChangeStatus()) ||
				   instrumentRatingControls.Any(d => d.GetChangeStatus()) ||
				   employeeLicenceLicenseCaaControl.GetChangeStatus();
		}

		#endregion

		#region public void ApplyChanges()

		public void ApplyChanges()
		{
			_license.Confirmation = checkBoxConfirmation.Checked;
			_license.EmployeeLicenceType = (EmployeeLicenceType) comboBoxLicenceType.SelectedItem;
			_license.AircraftTypeID = ((AircraftModel) comboBoxCategory.SelectedItem).ItemId;
			_license.ValidToDate = dateTimePickerValidToCAA.Value;
			_license.IssueDate = dateTimePickerIssueDate.Value;
			_license.NotifyLifelength = lifelengthViewer1.Lifelength;
			_license.IsValidTo = checkBoxIsValid.Checked;

			foreach (var control in flowLayoutPanelCaa.Controls.OfType<EmployeeLicenceCaaControl>())
				control.ApplyChanges();
			employeeLicenceLicenseCaaControl.ApplyChanges();

			foreach (var control in flowLayoutPanelOtherDetail.Controls.OfType<EmployeeLicenceOtherDetailControl>())
				control.ApplyChanges();

			foreach (var control in flowLayoutPanelRating.Controls.OfType<EmployeeLicenceRatingControl>())
				control.ApplyChanges();

			foreach (var control in flowLayoutPanelInstrumentRatings.Controls.OfType<EmployeeLicenseInstrumentRatingControl>())
				control.ApplyChanges();

			foreach (var control in flowLayoutPanelRemark.Controls.OfType<EmployeeLicenceRemarkControl>())
				control.ApplyChanges();
		}

		#endregion

		#region private void checkBoxConfirmation_CheckedChanged(object sender, EventArgs e)

		private void checkBoxConfirmation_CheckedChanged(object sender, EventArgs e)
		{
			flowLayoutPanelCaa.Enabled = checkBoxConfirmation.Checked;
		}

		#endregion

		#region private void linkLabelAddNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

		private void linkLabelAddNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var newCaa = new SpecialistCAA { SpecialistLicenseId = _license.ItemId, CaaType = CaaType.Other };
			_license.CaaLicense.Add(newCaa);
			AddCaaControl(newCaa);
		}

		#endregion

		#region private void Control_Deleted(object sender, EventArgs e)

		private void Control_Deleted(object sender, EventArgs e)
		{
			var control = sender as EmployeeLicenceCaaControl;

			var dialogResult = MessageBox.Show($"Do you really want to delete CAA {control.SpecialistCaa.CAANumber}?", "Deleting confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

			if (dialogResult == DialogResult.Yes)
			{
				if (control.SpecialistCaa.ItemId > 0)
				{
					try
					{
						_license.Confirmation = false;
						checkBoxConfirmation.Checked = false;
						_license.CaaLicense.RemoveById(control.SpecialistCaa.ItemId);
						
						if(GlobalObjects.CasEnvironment != null)
							GlobalObjects.CasEnvironment.Manipulator.Delete(control.SpecialistCaa, false);
						else
						{
							GlobalObjects.CaaEnvironment.NewKeeper.Save(_license);
							if(control.SpecialistCaa.Document != null)
								GlobalObjects.CaaEnvironment.NewKeeper.Delete(control.SpecialistCaa.Document, false);
							GlobalObjects.CaaEnvironment.NewKeeper.Delete(control.SpecialistCaa, false);
						}
					}
					catch (Exception ex)
					{
						Program.Provider.Logger.Log("Error while removing data", ex);
					}
				}
				
				flowLayoutPanelCaa.Controls.Remove(control);
				flowLayoutPanelCaa.Height -= 30;
				control.Deleted -= Control_Deleted;
				control.Dispose();
				InvokeReload();
			}
		}

		#endregion

		#region private void linkLabelAddNewRating_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

		private void linkLabelAddNewRating_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var newRating = new SpecialistLicenseRating();
			_license.LicenseRatings.Add(newRating);
			AddRatingControl(newRating);
		}

		#endregion

		#region private void RatingControl_Deleted(object sender, EventArgs e)

		private void RatingControl_Deleted(object sender, EventArgs e)
		{
			var control = sender as EmployeeLicenceRatingControl;

			var dialogResult = MessageBox.Show("Do you really want to delete Rating?", "Deleting confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
			if (dialogResult == DialogResult.Yes)
			{
				if (control.LicenseRating.ItemId > 0)
				{
					try
					{
						if(GlobalObjects.CasEnvironment != null)
							GlobalObjects.CasEnvironment.Manipulator.Delete(control.LicenseRating, false);
						else GlobalObjects.CaaEnvironment.NewKeeper.Delete(control.LicenseRating, false);
						
						_license.LicenseRatings.Remove(control.LicenseRating);
					}
					catch (Exception ex)
					{
						Program.Provider.Logger.Log("Error while removing data", ex);
					}
				}

				flowLayoutPanelRating.Controls.Remove(control);
				flowLayoutPanelRating.Height -= 60;
				control.Deleted -= RatingControl_Deleted;
				control.Dispose();
				InvokeReload();
			}
		}

		#endregion

		#region private void linkLabelInstrumentRatings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

		private void linkLabelInstrumentRatings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var newInstrumentRating = new SpecialistInstrumentRating();
			_license.SpecialistInstrumentRatings.Add(newInstrumentRating);
			AddInstrumentRatingControl(newInstrumentRating);
		}

		#endregion

		#region private void InstrumentRatingControl_Deleted(object sender, EventArgs e)

		private void InstrumentRatingControl_Deleted(object sender, EventArgs e)
		{
			var control = sender as EmployeeLicenseInstrumentRatingControl;

			var dialogResult = MessageBox.Show("Do you really want to delete Instrument Rating?", "Deleting confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

			if (dialogResult == DialogResult.Yes)
			{
				if (control.InstrumentRating.ItemId > 0)
				{
					try
					{
						if(GlobalObjects.CasEnvironment != null)
							GlobalObjects.CasEnvironment.Manipulator.Delete(control.InstrumentRating, false);
						else GlobalObjects.CaaEnvironment.NewKeeper.Delete(control.InstrumentRating, false);
						
						_license.SpecialistInstrumentRatings.Remove(control.InstrumentRating);
					}
					catch (Exception ex)
					{
						Program.Provider.Logger.Log("Error while removing data", ex);
					}
				}
				flowLayoutPanelInstrumentRatings.Controls.Remove(control);
				flowLayoutPanelInstrumentRatings.Height -= 60;
				control.Deleted -= InstrumentRatingControl_Deleted;
				control.Dispose();
			}
		}

		#endregion

		#region private void linkLabelRemark_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

		private void linkLabelRemark_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var newRemark = new SpecialistLicenseRemark();
			_license.LicenseRemark.Add(newRemark);
			AddRemarkControl(newRemark);
		}

		#endregion

		#region private void RemarkControl_Deleted(object sender, EventArgs e)

		private void RemarkControl_Deleted(object sender, EventArgs e)
		{
			var control = sender as EmployeeLicenceRemarkControl;

			var dialogResult = MessageBox.Show($"Do you really want to delete Remark?", "Deleting confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
			if (dialogResult == DialogResult.Yes)
			{
				if (control.LicenseRemark.ItemId > 0)
				{
					try
					{
						if(GlobalObjects.CasEnvironment != null)
							GlobalObjects.CasEnvironment.Manipulator.Delete(control.LicenseRemark, false);
						else GlobalObjects.CaaEnvironment.NewKeeper.Delete(control.LicenseRemark, false);
						
						_license.LicenseRemark.Remove(control.LicenseRemark);
						
						
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
				InvokeReload();
			}
		}

		#endregion

		#region private void linkLabelAddOtherDetail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

		private void linkLabelAddOtherDetail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var newSpecialistLicense = new SpecialistLicenseDetail();
			_license.LicenseDetails.Add(newSpecialistLicense);
			AddDetailControl(newSpecialistLicense);
		}

		#endregion

		#region private void OtherDetailControl_Deleted(object sender, EventArgs e)

		private void OtherDetailControl_Deleted(object sender, EventArgs e)
		{
			var control = sender as EmployeeLicenceOtherDetailControl;
			var dialogResult = MessageBox.Show($"Do you really want to delete Other Detail?", "Deleting confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

			if (dialogResult == DialogResult.Yes)
			{
				if (control.LicenseDetail.ItemId > 0)
				{
					try
					{
						if(GlobalObjects.CasEnvironment != null)
							GlobalObjects.CasEnvironment.Manipulator.Delete(control.LicenseDetail, false);
						else GlobalObjects.CaaEnvironment.NewKeeper.Delete(control.LicenseDetail, false);
						
						_license.LicenseDetails.Remove(control.LicenseDetail);
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
				InvokeReload();
			}
		}

		#endregion

		#region Events

		public event EventHandler Deleted;
		private void linkLabelRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (Deleted != null)
				Deleted(this, EventArgs.Empty);
		}
		#endregion

		#region private void AddCaaControl(SpecialistCAA caa)

		private void AddCaaControl(SpecialistCAA caa)
		{

			_license.Confirmation = true;
			if(GlobalObjects.CaaEnvironment != null)
				GlobalObjects.CaaEnvironment.NewKeeper.Save(_license);
			var control = new EmployeeLicenceCaaControl { ShowButtonDelete = true, OperatorId = OperatorId };
			control.Deleted += Control_Deleted;
			control.Reload += ControlOnReload;

			control.UpdateControl(caa);

			flowLayoutPanelCaa.Controls.Remove(linkLabelAddNewCAA);
			flowLayoutPanelCaa.Controls.Add(control);
			flowLayoutPanelCaa.Controls.Add(linkLabelAddNewCAA);
			flowLayoutPanelCaa.Height += 30;
		}

		#endregion
		private void ControlOnReload(object sender, EventArgs e)
		{
			InvokeReload();
		}
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

		#region private void AddRatingControl(SpecialistLicenseRating rating)

		private void AddRatingControl(SpecialistLicenseRating rating)
		{
			var control = new EmployeeLicenceRatingControl();

			control.UpdateInformation(rating, _license.EmployeeLicenceType);
			control.UpdateComboboxs((EmployeeLicenceType)comboBoxLicenceType.SelectedItem);
			control.Deleted += RatingControl_Deleted;

			flowLayoutPanelRating.Controls.Remove(linkLabelAddNewRating);
			flowLayoutPanelRating.Controls.Add(control);
			flowLayoutPanelRating.Controls.Add(linkLabelAddNewRating);
			flowLayoutPanelRating.Height += 60;
		}

		#endregion

		#region private void AddInstrumentRatingControl(SpecialistInstrumentRating instrumentRating)

		private void AddInstrumentRatingControl(SpecialistInstrumentRating instrumentRating)
		{
			var control = new EmployeeLicenseInstrumentRatingControl();
			control.UpdateControl(instrumentRating);
			control.Deleted += InstrumentRatingControl_Deleted;

			flowLayoutPanelInstrumentRatings.Controls.Remove(linkLabelInstrumentRatings);
			flowLayoutPanelInstrumentRatings.Controls.Add(control);
			flowLayoutPanelInstrumentRatings.Controls.Add(linkLabelInstrumentRatings);
			flowLayoutPanelInstrumentRatings.Height += 60;
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

		#region public void UpdateLicenceCombobox(PersonnelCategory selectedCategory)

		public void UpdateLicenceCombobox(PersonnelCategory selectedCategory)
		{
			comboBoxLicenceType.Items.Clear();

			var list = EmployeeLicenceType.Items.Where(e => e.Category == selectedCategory || e.Category == PersonnelCategory.UNK);
			foreach (var o in list)
				comboBoxLicenceType.Items.Add(o);

			if (_license != null)
				comboBoxLicenceType.SelectedItem = list.Any(e => e == _license.EmployeeLicenceType) ? _license.EmployeeLicenceType : EmployeeLicenceType.UNK;

		}

		#endregion


		public event EventHandler LisenceChanged;

		private void comboBoxLicenceType_SelectedIndexChanged(object sender, EventArgs e)
		{
			var selectedCategory = (EmployeeLicenceType)comboBoxLicenceType.SelectedItem;

			if (LisenceChanged != null)
				LisenceChanged(selectedCategory, EventArgs.Empty);

			foreach (var control in flowLayoutPanelRating.Controls.OfType<EmployeeLicenceRatingControl>())
				control.UpdateComboboxs(selectedCategory);
		}
		
		
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

		private void checkBoxIsValid_CheckedChanged(object sender, EventArgs e)
		{
			lifelengthViewer1.Enabled = dateTimePickerValidToCAA.Enabled = checkBoxIsValid.Checked;
		}
	}
}
