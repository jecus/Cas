using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAS.UI.UIControls.DocumentationControls;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UIControls.PersonnelControls.EmployeeControls
{
	public partial class EmployeeLicenceCaaControl : UserControl
	{
		private SpecialistCAA _specialistCaa;

		#region Properties

		public SpecialistCAA SpecialistCaa
		{
			get { return _specialistCaa; }
		}
		public bool ShowButtonDelete
		{
			set
			{
				buttonDelete.Visible = value;
			}
		}
		public string IssueLabelText
		{
			set { labelIssueBy.Text = value; }
		}

		#endregion

		#region Constructot

		public EmployeeLicenceCaaControl()
		{
			InitializeComponent();
		}

		#endregion

		#region Methods

		#region public void UpdateControl(SpecialistCAA specialistCaa)

		public void UpdateControl(SpecialistCAA specialistCaa)
		{
			_specialistCaa = specialistCaa;

			comboBoxCAA.Items.Clear();
			foreach (var o in Citizenship.Items)
				comboBoxCAA.Items.Add(o);

			comboBoxCAA.SelectedItem = _specialistCaa.Caa;
			textBoxCAANumber.Text = _specialistCaa.CAANumber;
			dateTimePickerValidToCAA.Value = _specialistCaa.ValidToDate;
			dateTimePickerIssueDate.Value = _specialistCaa.IssueDate;
			lifelengthViewer1.Lifelength = _specialistCaa.NotifyLifelength;

			documentControl1.CurrentDocument = _specialistCaa.Document;
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
				_specialistCaa.Document = newDocument;
				documentControl1.CurrentDocument = newDocument;

			}
		}

		#endregion

		#region private Document CreateNewDocument()

		private Document CreateNewDocument()
		{
			var docSubType = GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Personnel License") as DocumentSubType;

			return new Document
			{
				ParentId = _specialistCaa.ItemId,
				Parent = _specialistCaa,
				ParentTypeId = _specialistCaa.SmartCoreObjectType.ItemId,
				DocType = DocumentType.Document,
				DocumentSubType = docSubType,
				IsClosed = true,
			};
		}

		#endregion

		#region public bool ValidateData(out string message)

		public bool ValidateData(out string message)
		{
			message = "";

			if (comboBoxCAA.SelectedItem == null)
			{
				if (message != "") message += "\n ";
				message += "Please select Issue Caa";
			}

			if (message != "")
				return false;
			return true;
		}

		#endregion

		#region public bool GetChangeStatus()

		public bool GetChangeStatus()
		{
			return _specialistCaa.Caa != (Citizenship)comboBoxCAA.SelectedItem ||
			       _specialistCaa.CAANumber != textBoxCAANumber.Text || 
			       _specialistCaa.ValidToDate != dateTimePickerValidToCAA.Value ||
			       _specialistCaa.IssueDate !=  dateTimePickerIssueDate.Value  ||
				   _specialistCaa.NotifyLifelength != lifelengthViewer1.Lifelength;
		}

		#endregion

		#region public void ApplyChanges()

		public void ApplyChanges()
		{
			_specialistCaa.Caa = (Citizenship) comboBoxCAA.SelectedItem;
			_specialistCaa.CAANumber = textBoxCAANumber.Text;
			_specialistCaa.ValidToDate = dateTimePickerValidToCAA.Value;
			_specialistCaa.IssueDate = dateTimePickerIssueDate.Value;
			_specialistCaa.NotifyLifelength = lifelengthViewer1.Lifelength;
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
