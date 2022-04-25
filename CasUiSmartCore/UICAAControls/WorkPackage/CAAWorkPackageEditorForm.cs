﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.UIControls.DocumentationControls;
using CAS.UI.UIControls.WorkPakage;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.Entities.Dictionaries;

namespace CAS.UI.UICAAControls.WorkPackage
{
	public partial class CAAWorkPackageEditorForm : MetroForm
	{
		private readonly SmartCore.Entities.General.WorkPackage.WorkPackage _currentWp;
		private List<DocumentControl> DocumentControls = new List<DocumentControl>();

		#region Costructor

		public CAAWorkPackageEditorForm()
		{
			InitializeComponent();
		}

		public CAAWorkPackageEditorForm(SmartCore.Entities.General.WorkPackage.WorkPackage currentWp) : this()
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
			metroTextBox1.Text = $"{_currentWp.ProviderPrice.Count} Count";
			textBoxWpNumber.Text = _currentWp.Number;
			textBoxDescription.Text = _currentWp.Description;
			dateTimePickerIssueCreateDate.Value = _currentWp.CreateDate;
			dateTimePickerPublishingDate.Value = _currentWp.PublishingDate;
			textBoxAuthor.Text = _currentWp.Author;
			textBoxClosedBy.Text = _currentWp.ClosedBy;
			textBoxPublishingRemark.Text = _currentWp.PublishingRemarks;
			textBoxDuration.Text = _currentWp.MaintenanceRepairOrzanization;
			textBoxTitle.Text = _currentWp.Title;
			textBoxStatus.Text = _currentWp.Status.ToString();
			dateTimePickerOpeningDate.Value = _currentWp.OpeningDate;
			dateTimePickerClosingDate.Value = _currentWp.ClosingDate;
			textBoxPublishedBy.Text = _currentWp.PublishedBy;
			textBoxRemarks.Text = _currentWp.Remarks;
			textBoxClosingRemarks.Text = _currentWp.ClosingRemarks;
			textBoxLocation.Text = _currentWp.Station;
			dateTimePickerFlightDate.Value = _currentWp.PerfAfter.PerformDate;
			

			foreach (var control in DocumentControls)
				control.Added += DocumentControl1_Added;

			for (int i = 0; i < _currentWp.ClosingDocument.Count; i++)
			{
				var control = DocumentControls[i];
				control.CurrentDocument = _currentWp.ClosingDocument[i];
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
				ContractNumber = $"{_currentWp.Number}",
				Description = _currentWp.Title,
				ParentAircraftId = _currentWp.ParentId
			};

			var form = new DocumentForm(newDocument, false);
			if (form.ShowDialog() == DialogResult.OK)
			{
				_currentWp.ClosingDocument.Add(newDocument);
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
			_currentWp.Number = textBoxWpNumber.Text;
			_currentWp.Description = textBoxDescription.Text;
			_currentWp.PublishingDate = dateTimePickerPublishingDate.Value;
			_currentWp.PublishingRemarks = textBoxPublishingRemark.Text;
			_currentWp.MaintenanceRepairOrzanization = textBoxDuration.Text;
			_currentWp.Title = textBoxTitle.Text;
			_currentWp.OpeningDate = dateTimePickerOpeningDate.Value;
			_currentWp.ClosingDate = dateTimePickerClosingDate.Value;
			_currentWp.Remarks = textBoxRemarks.Text;
			_currentWp.ClosingRemarks = textBoxClosingRemarks.Text;
			_currentWp.Station = textBoxLocation.Text;
			_currentWp.PerfAfter.FlightNumId = _currentWp.PerfAfter.FlightNum?.ItemId ?? -1;
			_currentWp.PerfAfter.AirportFromId = _currentWp.PerfAfter.AirportFrom?.ItemId ?? -1;
			_currentWp.PerfAfter.AirportToId = _currentWp.PerfAfter.AirportTo?.ItemId ?? -1;

			_currentWp.PerfAfter.PerformDate = dateTimePickerFlightDate.Value;
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
			var form = new WpProviderForm(_currentWp);
			if (form.ShowDialog() == DialogResult.OK)
				metroTextBox1.Text = $"{_currentWp.ProviderPrice.Count} Count";
		}
	}
}
