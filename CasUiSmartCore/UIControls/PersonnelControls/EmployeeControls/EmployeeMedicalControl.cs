using System;
using System.Windows.Forms;
using CAS.UI.UIControls.DocumentationControls;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UIControls.PersonnelControls.EmployeeControls
{
	public partial class EmployeeMedicalControl : UserControl
	{
		private SpecialistMedicalRecord _currentItem;

		#region Constructor

		public EmployeeMedicalControl()
		{
			InitializeComponent();
		}

		public int OperatorId { get; set; }

		#endregion

		#region public void UpdateControl(Specialist currentSpecialist)

		public void UpdateControl(Specialist currentSpecialist)
		{
			if (currentSpecialist == null)
				return;

			_currentItem = currentSpecialist.MedicalRecord ?? new SpecialistMedicalRecord{ClassNumber = 0};

			currentSpecialist.MedicalRecord = _currentItem;

			comboBoxClass.Items.Clear();
			comboBoxClass.Items.AddRange(new object[]{0,1,2,3});

			comboBoxClass.SelectedItem = _currentItem.ClassNumber;
			dateTimePickerClassIssue.Value = _currentItem.IssueDate;
			lifelengthViewerNotify.Lifelength = _currentItem.NotifyLifelength;
			lifelengthViewerRepeat.Lifelength = _currentItem.RepeatLifelength;
			textBoxRemarks.Text = _currentItem.Remarks;

			documentControl1.CurrentDocument = _currentItem.Document;
			documentControl1.Added += DocumentControl1_Added;

		}

		#endregion

		#region private void DocumentControl1_Added(object sender, EventArgs e)

		private void DocumentControl1_Added(object sender, EventArgs e)
		{
			var newDocument = CreateNewDocument();
			var form = new DocumentForm(newDocument, false);
			if (form.ShowDialog() == DialogResult.OK)
			{
				_currentItem.Document = newDocument;
				documentControl1.CurrentDocument = newDocument;

			}
		}

		#endregion

		#region private Document CreateNewDocument()

		private Document CreateNewDocument()
		{
			DocumentSubType docSubType;
			if(GlobalObjects.CasEnvironment != null)
				docSubType = GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Medical Records") as DocumentSubType;
			else docSubType = GlobalObjects.CaaEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Medical Records") as DocumentSubType;

			return new Document
			{
				OperatorId = OperatorId,
				ParentId = _currentItem.ItemId,
				Parent = _currentItem,
				ParentTypeId = _currentItem.SmartCoreObjectType.ItemId,
				DocType = DocumentType.Certificate,
				DocumentSubType = docSubType,
				IsClosed = false,
			};
		}

		#endregion

		#region public bool GetChangeStatus()

		public bool GetChangeStatus()
		{
			return _currentItem.ClassNumber != (int) comboBoxClass.SelectedItem ||
			       _currentItem.IssueDate != dateTimePickerClassIssue.Value ||
			       _currentItem.NotifyLifelength != lifelengthViewerNotify.Lifelength ||
			       _currentItem.RepeatLifelength != lifelengthViewerRepeat.Lifelength ||
				   textBoxRemarks.Text != _currentItem.Remarks; ;
		}

		#endregion

		#region public void ApplyChanges()

		public void ApplyChanges()
		{
			_currentItem.IssueDate = dateTimePickerClassIssue.Value;
			_currentItem.ClassNumber = (int)comboBoxClass.SelectedItem;
			_currentItem.NotifyLifelength = lifelengthViewerNotify.Lifelength;
			_currentItem.RepeatLifelength = lifelengthViewerRepeat.Lifelength;
			_currentItem.Remarks = textBoxRemarks.Text;
		}

		#endregion
	}
}
