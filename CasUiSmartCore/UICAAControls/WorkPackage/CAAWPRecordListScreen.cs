using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.DTO;
using CAS.UI.Interfaces;
using CAS.UI.UICAAControls.CAAEducation;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CASTerms;
using Entity.Abstractions;
using Entity.Abstractions.Filters;
using SmartCore.CAA.CAAEducation;
using SmartCore.CAA.CAAWP;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Personnel;
using SmartCore.Filters;
using Telerik.WinControls.UI;

namespace CAS.UI.UICAAControls.WorkPackage
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class CAAWPRecordListScreen : ScreenControl
	{
		private readonly CAAWorkPackage _wp;

		#region Fields

		private CommonCollection<CAAWorkPackageRecord> _initialDocumentArray = new CommonCollection<CAAWorkPackageRecord>();
		private CommonCollection<CAAWorkPackageRecord> _resultDocumentArray = new CommonCollection<CAAWorkPackageRecord>();
		private CommonFilterCollection _filter;

		private CAAWPREducationListView _directivesViewer;
		
		#endregion


		#region Constructors

		#region public RoutineAuditListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		public CAAWPRecordListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public RoutineAuditListScreen(Operator currentOperator)

		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список директив
		///</summary>
		///<param name="currentOperator">ВС, которому принадлежат директивы</param>>
		public CAAWPRecordListScreen(Operator currentOperator, CAAWorkPackage wp)
			: this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");
			_wp = wp;
			aircraftHeaderControl1.Operator = currentOperator;
            statusControl.ShowStatus = false;
			labelTitle.Visible = false;

			_filter = new CommonFilterCollection(typeof(CAAWorkPackageRecord));
			
			InitListView();
			UpdateInformation();
			
		}

		#endregion

		#endregion

		#region Methods

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			_directivesViewer.SetItemsArray(_resultDocumentArray.ToArray());
			headerControl.PrintButtonEnabled = _directivesViewer.ItemsCount != 0;
			_directivesViewer.Focus();
		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			_initialDocumentArray.Clear();
			_resultDocumentArray.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load directives");


			_initialDocumentArray.AddRange(GlobalObjects.CaaEnvironment.NewLoader
				.GetObjectListAll<CAAWorkPackageRecordDTO, CAAWorkPackageRecord>(new Filter("WorkPackageId", _wp.ItemId)));
			
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
					EducationCalculator.CalculateEducation(r);
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
				
			}
			
			AnimatedThreadWorker.ReportProgress(70, "filter directives");

			FilterItems(_initialDocumentArray, _resultDocumentArray);

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}
		#endregion

		
		

		#region private void ButtonDeleteClick(object sender, EventArgs e)
		private void ButtonDeleteClick(object sender, EventArgs e)
		{
            _directivesViewer.ButtonDeleteClick(sender, e);
		}

		#endregion

		#region private void InitListView()

		private void InitListView()
		{
			_directivesViewer = new CAAWPREducationListView(AnimatedThreadWorker);
			_directivesViewer.TabIndex = 2;
			_directivesViewer.Location = new Point(panel1.Left, panel1.Top);
			_directivesViewer.Dock = DockStyle.Fill;
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;
			Controls.Add(_directivesViewer);
			//события 
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

			_directivesViewer.AddMenuItems();

			_directivesViewer.MenuOpeningAction = () =>
			{
				if (_directivesViewer.SelectedItems.Count <= 0)
					return;
				if (_directivesViewer.SelectedItems.Count == 1)
				{
					
				}
			};
			
			_directivesViewer.DisableDeleteContext();
			_directivesViewer.DisableCopyPaste();


			panel1.Controls.Add(_directivesViewer);
		}

		#endregion
		
		
		#region private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

		private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
		{
			headerControl.EditButtonEnabled = _directivesViewer.SelectedItems.Count > 0;
		}

		#endregion

		#region private void UpdateInformation()
		/// <summary>
		/// Происзодит обновление отображения элементов
		/// </summary>
		private void UpdateInformation()
		{
			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

		private void HeaderControlButtonReloadClick(object sender, EventArgs e)
		{
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		
		#region private void ButtonApplyFilterClick(object sender, EventArgs e)

		private void ButtonApplyFilterClick(object sender, EventArgs e)
		{
			var form = new CommonFilterForm(_filter, _initialDocumentArray);

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoFilteringWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void FilterItems(IEnumerable<Specialist> initialCollection, ICommonCollection<Specialist> resultCollection)

		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		private void FilterItems(IEnumerable<CAAWorkPackageRecord> initialCollection, ICommonCollection<CAAWorkPackageRecord> resultCollection)
		{
			if (_filter == null || _filter.All(i => i.Values.Length == 0))
			{
				resultCollection.Clear();
				resultCollection.AddRange(initialCollection);
				return;
			}

			resultCollection.Clear();

			foreach (var pd in initialCollection)
			{
				if (_filter.FilterTypeAnd)
				{
					bool acceptable = true;
					foreach (ICommonFilter filter in _filter)
					{
						acceptable = filter.Acceptable(pd); if (!acceptable) break;
					}
					if (acceptable) resultCollection.Add(pd);
				}
				else
				{
					bool acceptable = true;
					foreach (ICommonFilter filter in _filter)
					{
						if (filter.Values == null || filter.Values.Length == 0)
							continue;
						acceptable = filter.Acceptable(pd); if (acceptable) break;
					}
					if (acceptable) resultCollection.Add(pd);
				}
			}
		}
		#endregion

		#region private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)

		private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)
		{
			_resultDocumentArray.Clear();

			#region Фильтрация директив
			AnimatedThreadWorker.ReportProgress(50, "filter directives");

			FilterItems(_initialDocumentArray, _resultDocumentArray);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}

		#endregion

		#endregion

		private void HeaderControlOnEditButtonClick(object sender, EventArgs e)
		{
			var form = new CAAWorkPackageEditorForm(_wp);
			if(form.ShowDialog() == DialogResult.OK)
				AnimatedThreadWorker.RunWorkerAsync();
		}
	}
}
