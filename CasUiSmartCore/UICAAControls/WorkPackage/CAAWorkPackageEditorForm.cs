using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.DTO;
using CAS.UI.UIControls.DocumentationControls;
using CASTerms;
using Entity.Abstractions.Filters;
using MetroFramework.Forms;
using SmartCore.CAA.CAAWP;
using SmartCore.Entities.Dictionaries;

namespace CAS.UI.UICAAControls.WorkPackage
{
	public partial class CAAWorkPackageEditorForm : MetroForm
	{
		private readonly CAAWorkPackage _currentWp;
		private List<DocumentControl> DocumentControls = new List<DocumentControl>();

		#region Costructor

		public CAAWorkPackageEditorForm()
		{
			InitializeComponent();
		}

		public CAAWorkPackageEditorForm(CAAWorkPackage currentWp) : this()
		{
			if(currentWp == null)
				return;

			DocumentControls.AddRange(new[] { documentControl1, documentControl2, documentControl3, documentControl4, documentControl5, documentControl6 , documentControl7, documentControl8, documentControl9, documentControl10});
			_currentWp = currentWp;
			UpdateInformation();
		}

		#endregion

		#region private void UpdateInformation()

		private void UpdateInformation()
		{
			//metroTextBox1.Text = $"{_currentWp.ProviderPrice.Count} Count";

			if (_currentWp.ItemId <= 0)
				_currentWp.Settings.Number = $"{GlobalObjects.CaaEnvironment.ObtainId()} {DateTime.Now:G}";


			var author = GlobalObjects.CaaEnvironment?.GetCorrector(_currentWp.Settings.Author);
			var published = GlobalObjects.CaaEnvironment?.GetCorrector(_currentWp.Settings.PublishedBy);
			var closed = GlobalObjects.CaaEnvironment?.GetCorrector(_currentWp.Settings.ClosedBy);
			
			textBoxWpNumber.Text = _currentWp.Settings.Number;
			textBoxDescription.Text = _currentWp.Settings.Description;
			dateTimePickerIssueCreateDate.Value = _currentWp.Settings.CreateDate;
			dateTimePickerPublishingDate.Value = _currentWp.Settings.PublishingDate;
			textBoxAuthor.Text =author;
			textBoxClosedBy.Text = closed;
			textBoxPublishingRemark.Text = _currentWp.Settings.PublishingRemarks;
			textBoxDuration.Text = _currentWp.Settings.Duration;
			textBoxTitle.Text = _currentWp.Title;
			textBoxStatus.Text = _currentWp.Status.ToString();
			dateTimePickerOpeningDate.Value = _currentWp.Settings.OpeningDate;
			dateTimePickerClosingDate.Value = _currentWp.Settings.ClosingDate;
			textBoxPublishedBy.Text = published;
			textBoxRemarks.Text = _currentWp.Settings.Remarks;
			textBoxClosingRemarks.Text = _currentWp.Settings.ClosingRemarks;
			textBoxLocation.Text = _currentWp.Settings.Location;
			dateTimePickerFlightDate.Value = _currentWp.Settings.PerformDate;
			

			foreach (var control in DocumentControls)
				control.Added += DocumentControl1_Added;



			if (_currentWp.Settings.DocumentIds.Any())
				_currentWp.Settings.ClosingDocument.AddRange(GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CAADocumentDTO, SmartCore.Entities.General.Document>(new Filter("ItemId",_currentWp.Settings.DocumentIds )));
			
			if (_currentWp.Settings.ClosingDocument != null)
			{
				for (int i = 0; i < _currentWp.Settings.ClosingDocument.Count; i++)
				{
					var control = DocumentControls[i];
					control.CurrentDocument = _currentWp.Settings.ClosingDocument[i];
				}
			}
		}

		#endregion

		#region private void DocumentControl1_Added(object sender, EventArgs e)

		private void DocumentControl1_Added(object sender, EventArgs e)
		{
			var control = sender as DocumentControl;
			var docSubType = GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Work package") as DocumentSubType;
			var newDocument = new SmartCore.Entities.General.Document
			{
				Parent = _currentWp,
				ParentId = _currentWp.ItemId,
				ParentTypeId = _currentWp.SmartCoreObjectType.ItemId,
				DocType = DocumentType.TechnicalRecords,
				DocumentSubType = docSubType,
				IsClosed = true,
				ContractNumber = $"{_currentWp.Settings.Number}",
				Description = _currentWp.Title,
			};

			var form = new DocumentForm(newDocument, false);
			if (form.ShowDialog() == DialogResult.OK)
			{
				_currentWp.Settings.ClosingDocument.Add(newDocument);
				control.CurrentDocument = newDocument;

			}
		}

		#endregion

		#region private void buttonOk_Click(object sender, EventArgs e)

		private void buttonOk_Click(object sender, EventArgs e)
		{
			try
			{
				ApplyChanges();
				GlobalObjects.NewKeeper.Save(_currentWp);

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
			_currentWp.Title = textBoxTitle.Text;
			_currentWp.Settings.Number = textBoxWpNumber.Text;
			_currentWp.Settings.PublishingRemarks = textBoxPublishingRemark.Text;
			_currentWp.Settings.Location = textBoxLocation.Text;
			_currentWp.Settings.Duration = textBoxDuration.Text;
			_currentWp.Settings.ClosingRemarks = textBoxClosingRemarks.Text;
			_currentWp.Settings.Remarks = textBoxRemarks.Text;
			_currentWp.Settings.PerformDate = dateTimePickerFlightDate.Value;

			_currentWp.Settings.DocumentIds = new List<int>();
			_currentWp.Settings.DocumentIds.Clear();
			foreach (var control in DocumentControls.Where(control => control.CurrentDocument != null))
				_currentWp.Settings.DocumentIds.Add(control.CurrentDocument.ItemId);

			if (_currentWp.ItemId > 0) return;
			_currentWp.Settings.OpeningDate = DateTime.Now;
			_currentWp.Settings.CreateDate = DateTime.Now;
			_currentWp.Settings.Author = GlobalObjects.CaaEnvironment.IdentityUser.ItemId;
		}

		#endregion

		#region private void buttonClose_Click(object sender, EventArgs e)

		private void buttonClose_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			this.Close();
		}

		#endregion

		private void LinkLabelEditComponents_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			// var form = new WpProviderForm(_currentWp);
			// if (form.ShowDialog() == DialogResult.OK)
			// 	metroTextBox1.Text = $"{_currentWp.ProviderPrice.Count} Count";
		}
	}
}
