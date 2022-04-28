using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.DTO;
using CAS.UI.UIControls.DocumentationControls;
using CAS.UI.UIControls.WorkPakage;
using CASTerms;
using Entity.Abstractions.Filters;
using MetroFramework.Forms;
using SmartCore.CAA.CAAEducation;
using SmartCore.CAA.CAAWP;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UICAAControls.CAAEducation.CoursePackage
{
	public partial class CAACourseCloseForm : MetroForm
	{
		private readonly CAAWorkPackage _currentWp;
		private CommonCollection<CAAWorkPackageRecord> _initialDocumentArray = new CommonCollection<CAAWorkPackageRecord>();
		
		#region Costructor

		public CAACourseCloseForm()
		{
			InitializeComponent();
		}

		public CAACourseCloseForm(CAAWorkPackage currentWp) : this()
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
			_initialDocumentArray.AddRange(GlobalObjects.CaaEnvironment.NewLoader
				.GetObjectListAll<CoursePackageRecordDTO, CAAWorkPackageRecord>(new Filter("WorkPackageId", _currentWp.ItemId)));
			
			var ids = _initialDocumentArray.Select(i => i.ObjectId).Distinct();

			if (ids.Any())
			{
				var educationRecords = GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<EducationRecordsDTO, CAAEducationRecord>(new Filter("ItemId", ids));

				var edIds = educationRecords.Select(i => i.EducationId);
				var educations = GlobalObjects.CaaEnvironment.NewLoader
					.GetObjectListAll<EducationDTO, SmartCore.CAA.CAAEducation.CAAEducation>(new Filter("ItemId", edIds),loadChild:true);
				
				var spIds = educationRecords.Select(i => i.SpecialistId);
				var specialists = GlobalObjects.CaaEnvironment.NewLoader
					.GetObjectListAll<CAASpecialistDTO, Specialist>(new Filter("ItemId", spIds));

				
				foreach (var wpR in _initialDocumentArray)
				{
					var r = educationRecords.FirstOrDefault(i => i.ItemId == wpR.ObjectId);
					if(r == null)
						continue;
					//EducationCalculator.CalculateEducation(r);
					var item = new CAAEducationManagment()
					{
						Specialist = specialists.FirstOrDefault(i => i.ItemId == r.SpecialistId),
						Education = educations.FirstOrDefault(i => i.ItemId == r.EducationId),
						Record = r,
					};
					item.Occupation = item.Education.Occupation;
					item.IsCombination = item.Record.Settings.IsCombination;

					wpR.Parent = item;
				}


				foreach (var item in _initialDocumentArray)
				{
					var r = dataGridViewItems.Rows[dataGridViewItems.Rows.Add(new DataGridViewRow(){Tag = item})];
					r.Cells[0].Value = item.Parent.Specialist.FirstName;
					r.Cells[1].Value = item.Parent.Specialist.LastName;
					r.Cells[2].Value = false;
					r.Cells[2].ReadOnly = true;
				}
			}
			
			
			dataGridViewItems.CellClick +=DataGridViewItemsOnCellClick;
		}
		
		#endregion
		
		private void DataGridViewItemsOnCellClick(object sender, DataGridViewCellEventArgs e)
		{
			if(e.RowIndex < 0)
				return;

			var row = dataGridViewItems.Rows[e.RowIndex];
			var item = row.Tag as CAAWorkPackageRecord;
			
			if (item != null && item.Document == null)
			{
				var type = GlobalObjects.CaaEnvironment.GetDictionary<ServiceType>().GetByFullName("Training") as ServiceType;
				item.Document = new SmartCore.Entities.General.Document
				{
					Parent = item,
					ParentId = item.ItemId,
					ParentTypeId = item.SmartCoreObjectType.ItemId,
					DocType = DocumentType.Certificate,
					ServiceType = type
				};
			}
			
			var form = new DocumentForm(item.Document, false);
			if (form.ShowDialog() == DialogResult.OK)
				item.Document = item.Document;
		}

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
				
				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while save document", ex);
			}
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
