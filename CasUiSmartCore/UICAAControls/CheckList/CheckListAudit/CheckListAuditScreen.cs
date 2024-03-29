﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.Dictionary;
using CAA.Entity.Models.DTO;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UICAAControls.Audit;
using CAS.UI.UICAAControls.Audit.PEL;
using CAS.UI.UICAAControls.CheckList.CheckListAudit.MoveToForms;
using CAS.UI.UICAAControls.CheckList.EditionRevision;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using Entity.Abstractions.Filters;
using SmartCore.CAA;
using SmartCore.CAA.Audit;
using SmartCore.CAA.Check;
using SmartCore.CAA.FindingLevel;
using SmartCore.CAA.PEL;
using SmartCore.CAA.RoutineAudits;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Personnel;
using SmartCore.Filters;
using Telerik.WinControls.UI;

namespace CAS.UI.UICAAControls.CheckList.CheckListAudit
{
	public enum CheckListAuditType
	{
		Admin,
		User
	}
	
	
	///<summary>
    ///</summary>
    [ToolboxItem(false)]
	public partial class CheckListAuditScreen : ScreenControl
	{
        private readonly int _operatorId;
        private readonly int _parentId;
        private readonly CheckListAuditType _type;
        private readonly int? _stage;
        private SmartCore.CAA.StandartManual.StandartManual _manual;

        #region Fields

        private  int? _currentRoutineId;

        private CommonCollection<CheckLists> _initialDocumentArray = new CommonCollection<CheckLists>();
		private CommonCollection<CheckLists> _resultDocumentArray = new CommonCollection<CheckLists>();
		private CommonFilterCollection _filter;

		private BaseGridViewControl<CheckLists> _directivesViewer;

		private RadMenuItem _toolStripMenuItemOpen;
		private RadMenuItem _toolStripMenuSendTo;
		private SmartCore.CAA.RoutineAudits.RoutineAudit _routineAudit;
        private CAAAudit _audit;

        #endregion


		#region Constructors
		
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		public CheckListAuditScreen()
		{
			InitializeComponent();
		}


		/// <summary>
		///  Создаёт экземпляр элемента управления, отображающего список директив
		/// </summary>
		public CheckListAuditScreen(Operator currentOperator, int operatorId, int parentId, CheckListAuditType type, int? stage = null)
            : this()
        {
            if (currentOperator == null)
                throw new ArgumentNullException("currentOperator");
            aircraftHeaderControl1.Operator = currentOperator;

            _operatorId = operatorId;
            _parentId = parentId;
            _type = type;
            _stage = stage;
            statusControl.ShowStatus = false;
            labelTitle.Visible = true;

            buttonPel.Visible = _type == CheckListAuditType.Admin;
            UpdateInformation();
		}

        
        #endregion

		#region Methods

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{

			pictureBox3.Visible = false;
			buttonRevisions.Visible = false;
	        
	        
			this.headerControl.ShowEditButton = true;
			this.headerControl.EditButtonClick += HeaderControl_EditButtonClick;
	            
			pictureBox6.Visible = true;
			buttonPel.Visible = true;
			
			labelTitle.Text = $"Audit Status : {_audit.StatusName}";
			labelTitle.Visible = true;
            
            if (_manual.CheckUIType == CheckUIType.Iosa)
	            _filter = new CommonFilterCollection(typeof(ICheckListFilterParams));
            else if (_manual.CheckUIType == CheckUIType.Safa)
	            _filter = new CommonFilterCollection(typeof(ICheckListSafaFilterParams));
            else if (_manual.CheckUIType == CheckUIType.Icao)
	            _filter = new CommonFilterCollection(typeof(ICheckListIcaoFilterParams));


            if (_directivesViewer == null)
            {
	            InitToolStripMenuItems();
	            InitListView();
            }
            
            
            if (_directivesViewer is CheckListAuditView lite)
            {
	            lite.AuditId = _parentId;
	            lite.IsAuditCheck = 
	                                (_routineAudit?.Type == ProgramType.CAAKG ||
	                                 _routineAudit?.Type == ProgramType.IOSA);
            }
            else if(_directivesViewer is CheckListSAFAAuditView view)
            {
	            view.AuditId = _parentId;
	            view.IsAuditCheck = (_routineAudit?.Type == ProgramType.CAAKG ||
	                                 _routineAudit?.Type == ProgramType.IOSA);
            }
            else if(_directivesViewer is CheckListICAOAuditView icao)
            {
	            icao.AuditId = _parentId;
	            icao.IsAuditCheck = (_routineAudit?.Type == ProgramType.CAAKG ||
	                                 _routineAudit?.Type == ProgramType.IOSA);
            }
            
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

	            _audit = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<CAAAuditDTO, CAAAudit>(_parentId);
                var records = GlobalObjects.CaaEnvironment.NewLoader
                    .GetObjectListAll<CAAAuditRecordDTO, CAAAuditRecord>(new Filter("AuditId", _parentId), loadChild: true).ToList();
                
                _currentRoutineId = records.Select(i => i.RoutineAuditId).FirstOrDefault();
                _routineAudit = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<RoutineAuditDTO, SmartCore.CAA.RoutineAudits.RoutineAudit>(_currentRoutineId.Value);
                var manuals = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<StandartManualDTO, SmartCore.CAA.StandartManual.StandartManual>(new []
                {
	                new Filter("OperatorId", new []{_operatorId, -1}.Distinct()),
	                new Filter("ProgramTypeId", _routineAudit.Settings.TypeId),
                });

                _manual = manuals.FirstOrDefault();
                
				var routines = GlobalObjects.CaaEnvironment.NewLoader
                    .GetObjectListAll<RoutineAuditRecordDTO, RoutineAuditRecord>(new Filter("RoutineAuditId", _currentRoutineId), loadChild: true).ToList();

				var ids = new List<int>();
				if (_type == CheckListAuditType.Admin)
				{
					if (_audit.Settings.Status == RoutineStatus.Published)
					{
						var ds = GlobalObjects.CaaEnvironment.NewLoader.Execute($@"select CheckListId from dbo.AuditChecks 
where AuditId in ({_parentId}) and IsDeleted = 0 and WorkflowStageId = {_stage.Value}");
						
						var dt = ds.Tables[0];
						ids.AddRange(from DataRow dr in dt.Rows select (int)dr[0]);
					}
					else
					{
						ids = routines.Select(i => i.CheckListId).Distinct().ToList();
					}
				}
				else
				{
					var condition = _stage.HasValue ? $" and ac.WorkflowStageId = {_stage}" : "";
					
					var ds = GlobalObjects.CaaEnvironment.NewLoader.Execute($@"SELECT rec.CheckListId
   FROM [AuditPelRecords] rec
   cross apply
   (
		select SpecialistId as Auditor from  [dbo].[PelSpecialist] where ItemId = rec.AuditorId
   ) as auditor
   cross apply
   (
		select SpecialistId as Auditee from  [dbo].[PelSpecialist] where ItemId = rec.AuditeeId
   ) as auditee
   cross apply
   (
		select JSON_VALUE(SettingsJSON, '$.WorkflowStageId') as WorkflowStageId   from  [dbo].AuditChecks 
		where AuditId = rec.AuditId and CheckListId = rec.CheckListId
   ) as ac
   where rec.AuditId in ({_parentId}) and rec.IsDeleted = 0  {condition} 
   and (auditor.Auditor = {GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId} or auditee.Auditee = {GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId})");
					
					var dt = ds.Tables[0];

					ids.AddRange(from DataRow dr in dt.Rows select (int)dr[0]);
				}
				
                
                if (ids.Any())
                {
	                var filter = new List<Filter>()
	                {
		                new Filter("CheckListId", ids),
		                new Filter("AuditId", _audit.ItemId)
	                };
	                
	                if(_stage.HasValue)
		                filter.Add(new Filter("WorkflowStageId", _stage.Value));
	                
                    var auditChecks = GlobalObjects.CaaEnvironment.NewLoader
                        .GetObjectListAll<AuditCheckDTO, AuditCheck>(filter, loadChild: true).ToList();

					_initialDocumentArray.AddRange(GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<CheckListDTO, CheckLists>(new Filter("ItemId", ids), loadChild: true, true));
					
                    var revisions = new List<CheckListRevision>();
                    var revedIds = _initialDocumentArray.Where(i => i.RevisionId.HasValue).Select(i => i.RevisionId.Value).Distinct().ToList();
                    revedIds.AddRange(_initialDocumentArray.Select(i =>i.EditionId).Distinct());
                    if (revedIds.Any())
                    {
	                    revisions.AddRange(GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CheckListRevisionDTO, CheckListRevision>(new List<Filter>()
	                    {
		                    new Filter("ItemId", values: revedIds),
	                    }));
                    }
		            
                    foreach (var check in _initialDocumentArray)
                    {
	                    check.AuditCheck = auditChecks.FirstOrDefault(i => i.CheckListId == check.ItemId);
	                    check.RevisionNumber = revisions.FirstOrDefault(i => i.ItemId == check.RevisionId)?.Number.ToString() ?? "";
	                    check.EditionNumber = revisions.FirstOrDefault(i => i.ItemId == check.RevisionId)?.Number.ToString() ?? "";
                    }
                    
				}
                
                
                var pelRecords = GlobalObjects.CaaEnvironment.NewLoader
	                .GetObjectListAll<AuditPelRecordDTO, AuditPelRecord>(new Filter("AuditId", _parentId));
                
                if (records.Any())
                {
	                var pelSpec = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<PelSpecialistDTO, PelSpecialist>(new Filter("AuditId", _parentId));

	                var specIds = pelSpec.Select(i => i.SpecialistId);
	                var specialists = GlobalObjects.CaaEnvironment.NewLoader
		                .GetObjectListAll<CAASpecialistDTO, Specialist>(new Filter("ItemId", specIds),
			                loadChild: true);
	            
	                foreach (var specialist in specialists)
		                specialist.Operator = GlobalObjects.CaaEnvironment.AllOperators.FirstOrDefault(i => i.ItemId == specialist.OperatorId) ?? AllOperators.Unknown;
            
	                foreach (var pel in pelSpec)
		                pel.Specialist = specialists.FirstOrDefault(i => i.ItemId == pel.SpecialistId);

	                
	                var dsTransfer = GlobalObjects.CaaEnvironment.NewLoader.Execute($@";WITH cte AS
(
   SELECT *,
         ROW_NUMBER() OVER (PARTITION BY CheckListId ORDER BY Created DESC) AS rn
   FROM [CheckListTransfer] where AuditId = {_parentId}
)
SELECT CheckListId, [From], [To]
FROM cte
WHERE rn = 1 and  IsDeleted = 0");
                
	                var transfers = dsTransfer.Tables[0].Rows.OfType<DataRow>().Select(i => new
	                {
		                CheckListId = (int)i[0],
		                From = (int)i[1],
		                To = (int)i[2],
	                });

	                foreach (var rec in pelRecords)
	                {
		                rec.CheckList = _initialDocumentArray.FirstOrDefault(i => i.ItemId == rec.CheckListId);
		                rec.Auditor = pelSpec.FirstOrDefault(i => i.ItemId == rec.AuditorId)?.Specialist ?? Specialist.Unknown;
		                rec.Auditee = pelSpec.FirstOrDefault(i => i.ItemId == rec.AuditeeId)?.Specialist ?? Specialist.Unknown;
		                
		                var tr = transfers.FirstOrDefault(i => i.CheckListId == rec.CheckListId);
		                if (tr != null)
		                {
			                rec.CurrentAuditor = pelSpec.FirstOrDefault(i => i.SpecialistId == tr.To)?.Specialist ?? Specialist.Unknown;
		                }
	                }
                }
                

                var levels = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<FindingLevelsDTO, FindingLevels>(new []
            {
	            new Filter("OperatorId", _operatorId),
	            new Filter("ProgramTypeId", _manual.ProgramTypeId),
            });
            
            foreach (var check in _initialDocumentArray)
            {
	            check.PelRecord = pelRecords.FirstOrDefault(i => i.CheckListId == check.ItemId);
	            
	            if (check.PelRecord?.CurrentAuditor?.ItemId == GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId)
		            check.IsEditable = true;
	            
	            
	            if (check.CheckUIType == CheckUIType.Iosa)
	            {
		            check.Level = levels.FirstOrDefault(i => i.ItemId == check.Settings.LevelId) ??
		                          FindingLevels.Unknown;
	            }
	            else if (check.CheckUIType == CheckUIType.Safa)
	            {
		            check.Level = levels.FirstOrDefault(i => i.ItemId == check.SettingsSafa.LevelId) ??
		                          FindingLevels.Unknown;
	            }
	            else if (check.CheckUIType == CheckUIType.Icao)
	            {
		            check.Level = levels.FirstOrDefault(i => i.ItemId == check.SettingsIcao.LevelId) ??
		                          FindingLevels.Unknown;
	            }
	            check.Remains = Lifelength.Null;
	            check.Condition = ConditionState.Satisfactory;
            }
           
            
			AnimatedThreadWorker.ReportProgress(40, "filter directives");

			AnimatedThreadWorker.ReportProgress(70, "filter directives");

			FilterItems(_initialDocumentArray, _resultDocumentArray);

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}
		#endregion

		#region private void InitToolStripMenuItems()

		private void InitToolStripMenuItems()
		{
			_toolStripMenuItemOpen = new RadMenuItem();
			_toolStripMenuSendTo = new RadMenuItem();
			// 
			// toolStripMenuItemView
			// 
			_toolStripMenuItemOpen.Text = "Open";
			_toolStripMenuItemOpen.Click += ToolStripMenuItemOpenClick;
			// 
			// toolStripMenuItemView
			// 
			_toolStripMenuSendTo.Text = _type == CheckListAuditType.User ?  "Send To" : "Show Chat";
			_toolStripMenuSendTo.Click += ToolStripMenuSendClick;
		}

		private void ToolStripMenuSendClick(object sender, EventArgs e)
		{
			if (_type == CheckListAuditType.User)
			{
				var form = new WorkflowCommentsForm(_directivesViewer.SelectedItem.AuditCheck);
				if (form.ShowDialog() == DialogResult.OK)
					AnimatedThreadWorker.RunWorkerAsync();
			}
			else
			{
				var form = new WorkflowCommentsTrackingForm(_directivesViewer.SelectedItem.AuditCheck);
				if (form.ShowDialog() == DialogResult.OK)
					AnimatedThreadWorker.RunWorkerAsync();
			}
			
			
		}

		#endregion

        private void HeaderControl_EditButtonClick(object sender, EventArgs e)
        {
			var form = new EditAuditForm(_parentId);
            if (form.ShowDialog() == DialogResult.OK)
                AnimatedThreadWorker.RunWorkerAsync();
		}
        

		#region private void ToolStripMenuItemOpenClick(object sender, EventArgs e)

		private void ToolStripMenuItemOpenClick(object sender, EventArgs e)
		{
            if ((_routineAudit?.Type == ProgramType.CAAKG || _routineAudit?.Type == ProgramType.IOSA))
            {
	            if (_directivesViewer.SelectedItem.AuditCheck.WorkflowStageId == WorkFlowStage.RCA.ItemId)
                {
	                var form = new CheckListAuditRootCaseForm(_directivesViewer.SelectedItem, _parentId, _directivesViewer.SelectedItem.IsEditable);
	                if (form.ShowDialog() == DialogResult.OK)
		                AnimatedThreadWorker.RunWorkerAsync();
                }
	            else if (_directivesViewer.SelectedItem.AuditCheck.WorkflowStageId == WorkFlowStage.CAP.ItemId)
	            {
		            var form = new CheckListCAPForm(_directivesViewer.SelectedItem, _parentId, _directivesViewer.SelectedItem.IsEditable);
		            if (form.ShowDialog() == DialogResult.OK)
			            AnimatedThreadWorker.RunWorkerAsync();
	            }
                else
                {
	                var form = new CheckListAuditForm(_directivesViewer.SelectedItem, _parentId, _directivesViewer.SelectedItem.IsEditable);
	                if (form.ShowDialog() == DialogResult.OK)
		                AnimatedThreadWorker.RunWorkerAsync();
                }
                
            }
		}

		#endregion
		
		#region private void InitListView()

		private void InitListView()
        {
	        if (_manual.CheckUIType == CheckUIType.Iosa)
		        _directivesViewer = new CheckListAuditView(AnimatedThreadWorker,_type);
	        else  if (_manual.CheckUIType == CheckUIType.Safa)
		        _directivesViewer = new CheckListSAFAAuditView(AnimatedThreadWorker,_type);
	        else  if (_manual.CheckUIType == CheckUIType.Icao)
		        _directivesViewer = new CheckListICAOAuditView(AnimatedThreadWorker,_type);
	        else return;

			_directivesViewer.TabIndex = 2;
			_directivesViewer.Location = new Point(panel1.Left, panel1.Top);
			_directivesViewer.Dock = DockStyle.Fill;
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;
			Controls.Add(_directivesViewer);
			//события 
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

			
			if(_audit.Settings.Status == RoutineStatus.Published)
				_directivesViewer.AddMenuItems(_toolStripMenuItemOpen, _toolStripMenuSendTo);
			else _directivesViewer.AddMenuItems(_toolStripMenuItemOpen);

			_directivesViewer.MenuOpeningAction = () =>
			{
				if (_directivesViewer.SelectedItems.Count <= 0)
					return;
				if (_directivesViewer.SelectedItems.Count == 1)
				{

					_toolStripMenuItemOpen.Enabled = true;
					_toolStripMenuSendTo.Enabled = true;
				}
				else
				{
					_toolStripMenuItemOpen.Enabled = false;
					_toolStripMenuSendTo.Enabled = false;
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
		private void FilterItems(IEnumerable<CheckLists> initialCollection, ICommonCollection<CheckLists> resultCollection)
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
		
        private void ButtonRevisionsClick(object sender, EventArgs e)
        {
	        var refE = new ReferenceEventArgs();
	        var dp = new DisplayerParams()
	        {
		        Page = new EditionRevisionListScreen(GlobalObjects.CaaEnvironment.Operators.FirstOrDefault(), _operatorId, _manual),
		        TypeOfReflection = ReflectionTypes.DisplayInNew,
		        PageCaption = $"Edition/Revision : {_manual.ProgramType}",
		        DisplayerType = DisplayerType.Screen
	        };
	        refE.SetParameters(dp);
	        InvokeDisplayerRequested(refE);
        }
        
        private void ButtonPelClick(object sender, EventArgs e)
        {
	        var form = new PelItemForm(_parentId, _operatorId, _initialDocumentArray);
	        if(form.ShowDialog() == DialogResult.OK)
		        AnimatedThreadWorker.RunWorkerAsync();
        }
	}
}
