using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using EntityCore.DTO.Dictionaries;
using EntityCore.DTO.General;
using MetroFramework.Forms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Mail;
using SmartCore.Entities.General.Personnel;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.MailControls
{
	public partial class MailForm : MetroForm
	{
		#region Fields

		private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
		private MailRecords _currentRecords;
		private List<Supplier> _suppliers = new List<Supplier>();
		private List<Department> _departments = new List<Department>();
		private List<Specialist> _specialists = new List<Specialist>();
		private List<Specialization> _specializations = new List<Specialization>();
		private List<Nomenclatures> _nomenclatures = new List<Nomenclatures>();

		#endregion

		#region Constructor

		public MailForm()
		{
			InitializeComponent();
		}

		public MailForm(MailRecords selectedItem) : this()
		{
			if (selectedItem == null)
				_currentRecords = new MailRecords();
			else _currentRecords = selectedItem;

			_animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
			_animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
		}

		#endregion

		#region private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)

		private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			comboBoxDocumentType.Items.Clear();
			comboBoxDocumentType.Items.AddRange(DocumentType.Items.ToArray());

			comboBoxSupplier.Items.Clear();
			comboBoxSupplier.Items.AddRange(_suppliers.ToArray());
			comboBoxSupplier.Items.Add(Supplier.Unknown);

			comboBoxDepartment.Items.Clear();
			comboBoxDepartment.Items.AddRange(_departments.ToArray());
			comboBoxDepartment.Items.Add(Department.Unknown);

			comboBoxSpecialist.Items.Clear();
			comboBoxSpecialist.Items.AddRange(_specialists.ToArray());
			comboBoxSpecialist.Items.Add(Specialist.Unknown);

			comboBoxOccupation.Items.Clear();
			comboBoxOccupation.Items.AddRange(_specializations.ToArray());
			comboBoxOccupation.Items.Add(Specialization.Unknown);

			comboBoxNomenclature.Items.Clear();
			comboBoxNomenclature.Items.AddRange(_nomenclatures.ToArray());
			comboBoxNomenclature.Items.Add(Nomenclatures.Unknown);

			dictionaryComboBoxLocation.Type = typeof(Locations);
			Program.MainDispatcher.ProcessControl(dictionaryComboBoxLocation);

			comboBoxDocumentClass.Items.Clear();
			comboBoxDocumentClass.Items.AddRange(DocumentClass.Items.ToArray());


			comboBoxDocumentType.SelectedItem = _currentRecords.DocType;
			comboBoxSupplier.SelectedItem = _currentRecords.Supplier;
			comboBoxDepartment.SelectedItem = _currentRecords.Department;
			comboBoxSpecialist.SelectedItem = _currentRecords.Specialist;
			comboBoxOccupation.SelectedItem = _currentRecords.Specialization;
			comboBoxNomenclature.SelectedItem = _currentRecords.Nomenclature;
			comboBoxDocumentClass.SelectedItem = _currentRecords.DocClass;
			dictionaryComboBoxLocation.SelectedItem = _currentRecords.Location;
			textBoxNumber.Text = _currentRecords.MailNumber;
			textBoxTitle.Text = _currentRecords.Title;
			textBoxRemarks.Text = _currentRecords.Remarks;
			textBoxDescription.Text = _currentRecords.Description;

			textBoxReferenceNumber.Enabled = false;
			textBoxReferenceNumber.Text = _currentRecords.ReferenceNumber;

			numericUpDownRevisionNotify.Value = _currentRecords.RevisionNotify;

			checkBoxRevisionPerformeUpTo.Checked = _currentRecords.PerformeUpTo;

			dateTimePickerReceiveMailDate.Value = _currentRecords.ReceiveMailDate;
			dateTimePickerCreateMailDate.Value = _currentRecords.CreateMailRecordDate;
			dateTimePickerRevisionPerformeUpTo.Value = _currentRecords.PerformeUpToDate;

			fileControl.UpdateInfo(_currentRecords.AttachedFile, "Adobe PDF Files|*.pdf",
				"This record does not contain a file proving the Mail. Enclose PDF file to prove the Mail.",
				"Attached file proves the Mail.");
		}

		#endregion

		#region private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)

		private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
		{
			_suppliers.Clear();
			_departments.Clear();
			_specialists.Clear();
			_specializations.Clear();

			_animatedThreadWorker.ReportProgress(0, "Loading");

			_suppliers.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<SupplierDTO,Supplier>());
			_departments.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<DepartmentDTO,Department>());
			_specialists.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<SpecialistDTO,Specialist>());
			_specializations.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<SpecializationDTO,Specialization>());
			_nomenclatures.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<NomenclatureDTO,Nomenclatures>());

			_animatedThreadWorker.ReportProgress(100, "Loading complete");
		}

		#endregion

		#region private void ReceiveMailForm_Load(object sender, System.EventArgs e)

		private void ReceiveMailForm_Load(object sender, EventArgs e)
		{
			_animatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void checkBoxRevisionPerformeUpTo_CheckedChanged(object sender, System.EventArgs e)

		private void checkBoxRevisionPerformeUpTo_CheckedChanged(object sender, EventArgs e)
		{
			dateTimePickerRevisionPerformeUpTo.Enabled =
				numericUpDownRevisionNotify.Enabled = checkBoxRevisionPerformeUpTo.Checked;
		}

		#endregion

		#region private void ApplyChanges()

		private void ApplyChanges()
		{
			_currentRecords.DocType = comboBoxDocumentType.SelectedItem as DocumentType;
			_currentRecords.Supplier = comboBoxSupplier.SelectedItem as Supplier;
			_currentRecords.Department = comboBoxDepartment.SelectedItem as Department;
			_currentRecords.Specialist = comboBoxSpecialist.SelectedItem as Specialist;
			_currentRecords.Specialization = comboBoxOccupation.SelectedItem as Specialization;
			_currentRecords.Nomenclature = comboBoxNomenclature.SelectedItem as Nomenclatures;
			_currentRecords.Location = dictionaryComboBoxLocation.SelectedItem as Locations;
			_currentRecords.DocClass = comboBoxDocumentClass.SelectedItem as DocumentClass;
			_currentRecords.Title = textBoxTitle.Text;
			_currentRecords.Remarks = textBoxRemarks.Text;
			_currentRecords.Description = textBoxDescription.Text;
			_currentRecords.MailNumber = textBoxNumber.Text;

			_currentRecords.RevisionNotify = (int) numericUpDownRevisionNotify.Value;

			_currentRecords.PerformeUpTo = checkBoxRevisionPerformeUpTo.Checked;

			_currentRecords.ReceiveMailDate = dateTimePickerReceiveMailDate.Value;
			_currentRecords.CreateMailRecordDate = dateTimePickerCreateMailDate.Value;
			_currentRecords.PerformeUpToDate = dateTimePickerRevisionPerformeUpTo.Value;

			if (fileControl.GetChangeStatus())
			{
				fileControl.ApplyChanges();
				_currentRecords.AttachedFile = fileControl.AttachedFile;
			}
		}

		#endregion

		#region private void buttonClose_Click(object sender, EventArgs e)

		private void buttonClose_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		#endregion

		#region private void buttonOk_Click(object sender, EventArgs e)

		private void buttonOk_Click(object sender, EventArgs e)
		{
			try
			{
				ApplyChanges();
				GlobalObjects.CasEnvironment.NewKeeper.Save(_currentRecords);


				if (_currentRecords.DocClass == DocumentClass.Inbox || _currentRecords.DocClass == DocumentClass.InternalDoc)
				{
					_currentRecords.MailNumber = textBoxNumber.Text;
					_currentRecords.ReferenceNumber = _currentRecords.ItemId.ToString();
				}
				else
				{
					_currentRecords.MailNumber = _currentRecords.ItemId.ToString();
				}
				GlobalObjects.CasEnvironment.NewKeeper.Save(_currentRecords);

				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while save document", ex);
			}
		}

		#endregion

		#region private void comboBoxDocumentClass_SelectedIndexChanged(object sender, EventArgs e)

		private void comboBoxDocumentClass_SelectedIndexChanged(object sender, EventArgs e)
		{
			var docClass = comboBoxDocumentClass.SelectedItem as DocumentClass;

			if (docClass == DocumentClass.Inbox)
			{
				labelFrom.Text = "To:";
				comboBoxDocumentType.SelectedItem = DocumentType.Letter;
				comboBoxDocumentType.Enabled = false;
				textBoxNumber.Enabled = true;
			}
			else if (docClass == DocumentClass.Outbox)
			{
				labelFrom.Text = "From:";
				comboBoxDocumentType.SelectedItem = DocumentType.Letter;
				comboBoxDocumentType.Enabled = false;
				textBoxNumber.Enabled = false;
			}
			else
			{
				comboBoxDocumentType.SelectedItem = DocumentType.Other;
				comboBoxDocumentType.Enabled = true;
				textBoxNumber.Enabled = true;
			}
		}

		#endregion
	}
}
