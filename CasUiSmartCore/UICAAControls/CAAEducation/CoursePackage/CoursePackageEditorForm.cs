using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.DTO;
using CAS.UI.UIControls.DocumentationControls;
using CASTerms;
using Entity.Abstractions.Filters;
using MetroFramework.Forms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Purchase;

namespace CAS.UI.UICAAControls.CAAEducation.CoursePackage
{
	public partial class WorkPackageEditorForm : MetroForm
	{
		private readonly SmartCore.CAA.CAAWP.CoursePackage _currentWp;
		private List<DocumentControl> DocumentControls = new List<DocumentControl>();

		#region Costructor

		public WorkPackageEditorForm()
		{
			InitializeComponent();
		}

		public WorkPackageEditorForm(SmartCore.CAA.CAAWP.CoursePackage currentWp) : this()
		{
			if(currentWp == null)
				return;

			DocumentControls.AddRange(new[] { documentControl1, documentControl2, documentControl3, documentControl4});
			_currentWp = currentWp;
			UpdateInformation();
		}

		#endregion

		#region private void UpdateInformation()

		private void UpdateInformation()
		{
			var providers = GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<CAASupplierDTO, Supplier>();
			comboBoxProvider.Items.Clear();
			comboBoxProvider.Items.AddRange(providers.ToArray());
			comboBoxProvider.Items.Add(Supplier.Unknown);
			comboBoxProvider.SelectedItem = providers.FirstOrDefault(i => i.ItemId == _currentWp.Settings.Offering.ProviderId) ?? Supplier.Unknown;


			comboBoxTotal.Items.Clear();
			comboBoxTotal.Items.AddRange(Сurrency.Items.ToArray());
			comboBoxTotal.SelectedItem = Сurrency.UNK;
			
			
			
			if (_currentWp.ItemId <= 0)
				_currentWp.Settings.Number = $"{GlobalObjects.CaaEnvironment.ObtainId()} {DateTime.Now:G}";


			var author = GlobalObjects.CaaEnvironment?.GetCorrector(_currentWp.Settings.Author);
			var published = GlobalObjects.CaaEnvironment?.GetCorrector(_currentWp.Settings.PublishedBy);
			var closed = GlobalObjects.CaaEnvironment?.GetCorrector(_currentWp.Settings.ClosedBy);
			
			textBoxWpNumber.Text = _currentWp.Settings.Number;
			textBoxDescription.Text = _currentWp.Settings.Description;
			dateTimePickerIssueCreateDate.Value = _currentWp.Settings.CreateDate;
			dateTimePickerPublishingDate.Value = _currentWp.Settings.PublishingDate ?? SmartCore.Auxiliary.DateTimeExtend.GetCASMinDateTime();
			textBoxAuthor.Text =author;
			textBoxClosedBy.Text = closed;
			textBoxPublishingRemark.Text = _currentWp.Settings.PublishingRemarks;
			
			textBoxTitle.Text = _currentWp.Title;
			textBoxStatus.Text = _currentWp.Status.ToString();
			dateTimePickerOpeningDate.Value = _currentWp.Settings.OpeningDate;
			dateTimePickerClosingDate.Value = _currentWp.Settings.ClosingDate ?? SmartCore.Auxiliary.DateTimeExtend.GetCASMinDateTime();
			textBoxPublishedBy.Text = published;
			textBoxRemarks.Text = _currentWp.Settings.Remarks;
			textBoxClosingRemarks.Text = _currentWp.Settings.ClosingRemarks;
			
			
			lifelengthViewerDuration.Lifelength = _currentWp.Settings.Offering.Duration;
			textBoxLocation.Text = _currentWp.Settings.Offering.Location;
			dateTimePickerFlightDate.Value = _currentWp.Settings.Offering.PerformDate;
			comboBoxTotal.SelectedItem = Сurrency.GetItemById(_currentWp.Settings.Offering.TotalCurrency);
			numericUpTotal.Value = _currentWp.Settings.Offering.Total;
			numericUpDownPerOne.Value = _currentWp.Settings.Offering.PerOne;
			numericUpDownMin.Value = _currentWp.Settings.Offering.Min;
			numericUpDownMax.Value = _currentWp.Settings.Offering.Max;
			numericUpDownFact.Value = _currentWp.Settings.Offering.Fact;
			
			
			foreach (var control in DocumentControls)
				control.Added += DocumentControl1_Added;

			if (_currentWp.Settings.ClosingDocument == null)
				_currentWp.Settings.ClosingDocument = new List<SmartCore.Entities.General.Document>();

			if (_currentWp.Settings.DocumentIds != null && _currentWp.Settings.DocumentIds.Any())
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
			var docSubType = GlobalObjects.CaaEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Work package") as DocumentSubType;
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
				if (_currentWp.Settings.ClosingDocument == null)
					_currentWp.Settings.ClosingDocument = new List<SmartCore.Entities.General.Document>();
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
			_currentWp.Settings.ClosingRemarks = textBoxClosingRemarks.Text;
			_currentWp.Settings.Remarks = textBoxRemarks.Text;
			_currentWp.Settings.Description = textBoxDescription.Text;
			
			
			_currentWp.Settings.Offering.PerformDate = dateTimePickerFlightDate.Value;
			_currentWp.Settings.Offering.Location = textBoxLocation.Text;
			_currentWp.Settings.Offering.Duration = lifelengthViewerDuration.Lifelength;
			_currentWp.Settings.Offering.TotalCurrency = (comboBoxTotal.SelectedItem as Сurrency).ItemId;
			_currentWp.Settings.Offering.Total = numericUpTotal.Value;
			_currentWp.Settings.Offering.PerOne = numericUpDownPerOne.Value;
			_currentWp.Settings.Offering.Min = numericUpDownMin.Value;
			_currentWp.Settings.Offering.Max = numericUpDownMax.Value;
			_currentWp.Settings.Offering.Fact = numericUpDownFact.Value;
			_currentWp.Settings.Offering.ProviderId = (comboBoxProvider.SelectedItem as Supplier).ItemId;
			
			
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
	}
}
