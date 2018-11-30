using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAS.UI.UIControls.DocumentationControls;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.WorkPackage;

namespace CAS.UI.UIControls.WorkPakage
{
	public partial class WorkPackageEditorForm : Form
	{
		private readonly WorkPackage _currentWp;

		#region Costructor

		public WorkPackageEditorForm()
		{
			InitializeComponent();
		}

		public WorkPackageEditorForm(WorkPackage currentWp) : this()
		{
			if(currentWp == null)
				return;

			_currentWp = currentWp;
			UpdateInformation();
		}

		#endregion

		#region private void UpdateInformation()

		private void UpdateInformation()
		{
			textBoxWpNumber.Text = _currentWp.Number;
			textBoxDescription.Text = _currentWp.Description;
			dateTimePickerIssueCreateDate.Value = _currentWp.CreateDate;
			dateTimePickerPublishingDate.Value = _currentWp.PublishingDate;
			textBoxAuthor.Text = _currentWp.Author;
			textBoxClosedBy.Text = _currentWp.ClosedBy;
			textBoxPublishingRemark.Text = _currentWp.PublishingRemarks;
			textBoxReleaseCertificate.Text = _currentWp.ReleaseCertificateNo;
			textBoxCheckType.Text = _currentWp.CheckType;
			textBoxMRO.Text = _currentWp.MaintenanceRepairOrzanization;
			textBoxTitle.Text = _currentWp.Title;
			textBoxStatus.Text = _currentWp.Status.ToString();
			dateTimePickerOpeningDate.Value = _currentWp.OpeningDate;
			dateTimePickerClosingDate.Value = _currentWp.ClosingDate;
			textBoxPublishedBy.Text = _currentWp.PublishedBy;
			textBoxRemarks.Text = _currentWp.Remarks;
			textBoxClosingRemarks.Text = _currentWp.ClosingRemarks;
			textBoxRevision.Text = _currentWp.Revision;
			textBoxStation.Text = _currentWp.Station;

			documentControl1.CurrentDocument = _currentWp.ClosingDocument;
			documentControl1.Added += DocumentControl1_Added;

		}

		#endregion

		#region private void DocumentControl1_Added(object sender, EventArgs e)

		private void DocumentControl1_Added(object sender, EventArgs e)
		{
			var docSubType = GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Work package") as DocumentSubType;
			var newDocument = new Document
			{
				Parent = _currentWp,
				ParentId = _currentWp.ItemId,
				ParentTypeId = _currentWp.SmartCoreObjectType.ItemId,
				DocType = DocumentType.TechnicalRecords,
				DocumentSubType = docSubType,
				IsClosed = true,
				ContractNumber = $"{_currentWp.Title}",
				Description = _currentWp.Description,
				ParentAircraftId = _currentWp.ParentId
			};

			var form = new DocumentForm(newDocument, false);
			if (form.ShowDialog() == DialogResult.OK)
			{
				_currentWp.ClosingDocument = newDocument;
				documentControl1.CurrentDocument = newDocument;

			}
		}

		#endregion

		#region private void buttonOk_Click(object sender, EventArgs e)

		private void buttonOk_Click(object sender, EventArgs e)
		{
			try
			{
				ApplyChanges();
				GlobalObjects.CasEnvironment.NewKeeper.Save(_currentWp);

				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while save document", ex);
			}
		}

		#endregion

		#region private void ApplyChanges()

		private void ApplyChanges()
		{
			_currentWp.Number = textBoxWpNumber.Text;
			_currentWp.Description = textBoxDescription.Text;
			_currentWp.PublishingDate = dateTimePickerPublishingDate.Value;
			_currentWp.PublishingRemarks = textBoxPublishingRemark.Text;
			_currentWp.ReleaseCertificateNo = textBoxReleaseCertificate.Text;
			_currentWp.CheckType = textBoxCheckType.Text;
			_currentWp.MaintenanceRepairOrzanization = textBoxMRO.Text;
			_currentWp.Title = textBoxTitle.Text;
			_currentWp.OpeningDate = dateTimePickerOpeningDate.Value;
			_currentWp.ClosingDate = dateTimePickerClosingDate.Value;
			_currentWp.Remarks = textBoxRemarks.Text;
			_currentWp.ClosingRemarks = textBoxClosingRemarks.Text;
			_currentWp.Revision = textBoxRevision.Text;
			_currentWp.Station = textBoxStation.Text;
		}

		#endregion

		#region private void buttonClose_Click(object sender, EventArgs e)

		private void buttonClose_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			this.Close();
		}

		#endregion
	}
}
