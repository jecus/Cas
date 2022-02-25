using CAA.Entity.Models.Dictionary;
using CAA.Entity.Models.DTO;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CASTerms;
using Entity.Abstractions.Filters;
using SmartCore.CAA.Check;
using SmartCore.CAA.FindingLevel;
using SmartCore.CAA.RoutineAudits;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UICAAControls.Audit;
using CAS.UI.UICAAControls.Audit.PEL;
using CAS.UI.UICAAControls.CheckList.CheckListAudit;
using CAS.UI.UICAAControls.CheckList.EditionRevision;
using CAS.UI.UIControls.NewGrid;
using SmartCore.CAA.Audit;
using Telerik.WinControls.UI;

namespace CAS.UI.UICAAControls.CheckList
{
	public enum CheckListType
	{
		CheckList,
		Routine,
		Audit
	}
	
    ///<summary>
    ///</summary>
    [ToolboxItem(false)]
	public partial class CheckListsScreen : ScreenControl
	{
        private readonly int _operatorId;
        private readonly CheckListType _type;
        private readonly int _parentId;
        private SmartCore.CAA.StandartManual.StandartManual _manual;

        #region Fields

        private  int? _currentRoutineId;

        private CommonCollection<CheckLists> _initialDocumentArray = new CommonCollection<CheckLists>();
		private CommonCollection<CheckLists> _resultDocumentArray = new CommonCollection<CheckLists>();
		private CommonFilterCollection _filter;

		private BaseGridViewControl<CheckLists> _directivesViewer;

		private RadMenuItem _toolStripMenuItemOpen;
		private SmartCore.CAA.RoutineAudits.RoutineAudit _routineAudit;
        private CAAAudit _audit;

        #endregion


		#region Constructors
		
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		public CheckListsScreen()
		{
			InitializeComponent();
		}


        ///<summary>
        /// Создаёт экземпляр элемента управления, отображающего список директив
        ///</summary>
        ///<param name="currentOperator">ВС, которому принадлежат директивы</param>>
        public CheckListsScreen(Operator currentOperator,int operatorId, CheckListType type, int parentId)
            : this()
        {
            if (currentOperator == null)
                throw new ArgumentNullException("currentOperator");
            aircraftHeaderControl1.Operator = currentOperator;

            _operatorId = operatorId;
            _type = type;
            _parentId = parentId;
            statusControl.ShowStatus = false;
            labelTitle.Visible = false;
            
            UpdateInformation();
		}


        public CheckListsScreen(Operator currentOperator, int operatorId, SmartCore.CAA.StandartManual.StandartManual manual)
            : this()
        {
            if (currentOperator == null)
                throw new ArgumentNullException("currentOperator");
            _type = CheckListType.CheckList;
            _operatorId = operatorId;
            _manual = manual;
            aircraftHeaderControl1.Operator = currentOperator;
            statusControl.ShowStatus = false;
            labelTitle.Visible = false;
            
            UpdateInformation();
        }

        #endregion

		#region Methods

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (_type == CheckListType.Routine)
			{
				buttonAddNew.Visible = true;
			}
	        
	        if (_type == CheckListType.Routine || _type == CheckListType.Audit)
	        {
		        pictureBox3.Visible = false;
		        buttonRevisions.Visible = false;
	        }
	        
            if (_type == CheckListType.Audit)
            {
	            this.headerControl.ShowEditButton = true;
	            this.headerControl.EditButtonClick += HeaderControl_EditButtonClick;
	            
	            pictureBox6.Visible = true;
	            buttonPel.Visible = true;
	            
	            labelTitle.Text = $"Workflow Stage : {WorkFlowStage.GetItemById(_audit.Settings.WorkflowStageId)}";
                labelTitle.Visible = true;
            }
            
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
            
            if (_directivesViewer is CheckListLiteView lite)
            {
	            lite.AuditId = _parentId;
	            lite.IsAuditCheck = _type == CheckListType.Audit &&
	                                (_routineAudit?.Type == ProgramType.CAAKG ||
	                                 _routineAudit?.Type == ProgramType.IOSA);
            }
            else if(_directivesViewer is CheckListView view)
            {
	            view.AuditId = _parentId;
	            view.IsAuditCheck = _type == CheckListType.Audit &&
	                                (_routineAudit?.Type == ProgramType.CAAKG ||
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
			
            if (_type == CheckListType.Routine)
            {
	            _currentRoutineId = _parentId;
				var records = GlobalObjects.CaaEnvironment.NewLoader
                    .GetObjectListAll<RoutineAuditRecordDTO, RoutineAuditRecord>(new Filter("RoutineAuditId", _parentId), loadChild: true).ToList();
				
				var routine = GlobalObjects.CaaEnvironment.NewLoader
					.GetObjectById<RoutineAuditDTO, SmartCore.CAA.RoutineAudits.RoutineAudit>(_parentId);
				var manuals = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<StandartManualDTO, SmartCore.CAA.StandartManual.StandartManual>(new []
				{
					new Filter("OperatorId", _operatorId),
					new Filter("ProgramTypeId", routine.Settings.TypeId),
				});

				_manual = manuals.FirstOrDefault();

                var ids = records.Select(i => i.CheckListId);

                if (ids.Any())
                    _initialDocumentArray.AddRange(GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<CheckListDTO, CheckLists>(new Filter("ItemId", ids), loadChild: true));

			}
			else if (_type == CheckListType.Audit)
            {

                _audit = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<CAAAuditDTO, CAAAudit>(_parentId);
                var records = GlobalObjects.CaaEnvironment.NewLoader
                    .GetObjectListAll<CAAAuditRecordDTO, CAAAuditRecord>(new Filter("AuditId", _parentId), loadChild: true).ToList();

                _currentRoutineId = records.Select(i => i.RoutineAuditId).FirstOrDefault();
                _routineAudit = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<RoutineAuditDTO, SmartCore.CAA.RoutineAudits.RoutineAudit>(_currentRoutineId.Value);
                var manuals = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<StandartManualDTO, SmartCore.CAA.StandartManual.StandartManual>(new []
                {
	                new Filter("OperatorId", _operatorId),
	                new Filter("ProgramTypeId", _routineAudit.Settings.TypeId),
                });

                _manual = manuals.FirstOrDefault();
                
				var routines = GlobalObjects.CaaEnvironment.NewLoader
                    .GetObjectListAll<RoutineAuditRecordDTO, RoutineAuditRecord>(new Filter("RoutineAuditId", _currentRoutineId), loadChild: true).ToList();

                var ids = routines.Select(i => i.CheckListId).Distinct();
                if (ids.Any())
                {
                    var auditChecks = GlobalObjects.CaaEnvironment.NewLoader
                        .GetObjectListAll<AuditCheckDTO, AuditCheck>(new Filter("CheckListId", ids), loadChild: true).ToList();

					_initialDocumentArray.AddRange(GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<CheckListDTO, CheckLists>(new Filter("ItemId", ids), loadChild: true));
                    foreach (var check in _initialDocumentArray)
                        check.AuditCheck = auditChecks.FirstOrDefault(i => i.CheckListId == check.ItemId);
				}
			}
            else
            {
	            var editions = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CheckListRevisionDTO, CheckListRevision>(new List<Filter>()
	            {
		            new Filter("Status", (byte)EditionRevisionStatus.Current),
		            new Filter("Type", (byte)RevisionType.Edition),
		            new Filter("ManualId", _manual.ItemId),
	            });
	            if (editions.Any())
	            {
		            var edition = editions.FirstOrDefault();
		            _initialDocumentArray.AddRange(GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<CheckListDTO, CheckLists>(new Filter("EditionId", edition.ItemId), loadChild:true));
		            
		            foreach (var check in _initialDocumentArray)
			            check.EditionNumber = edition.Number;
	            }
            }


            var levels = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<FindingLevelsDTO, FindingLevels>(new []
            {
	            new Filter("OperatorId", _operatorId),
	            new Filter("ProgramTypeId", _manual.ProgramTypeId),
            });
            
            foreach (var check in _initialDocumentArray)
            {
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
			// 
			// toolStripMenuItemView
			// 
			_toolStripMenuItemOpen.Text = "Open";
			_toolStripMenuItemOpen.Click += ToolStripMenuItemOpenClick;
		}
		#endregion

        private void HeaderControl_EditButtonClick(object sender, EventArgs e)
        {
			var form = new EditAuditForm(_parentId);
            if (form.ShowDialog() == DialogResult.OK)
                AnimatedThreadWorker.RunWorkerAsync();
		}


		#region private void HighlightItemClick(object sender, EventArgs e)

		private void HighlightItemClick(object sender, EventArgs e)
		{
			for (int i = 0; i < _directivesViewer.SelectedItems.Count; i++)
			{
				Highlight highLight = (Highlight)((RadMenuItem)sender).Tag;
				foreach (GridViewCellInfo cell in _directivesViewer.radGridView1.SelectedRows[i].Cells)
				{
					cell.Style.CustomizeFill = true;
					cell.Style.BackColor = Color.FromArgb(highLight.Color);
				}
			}
		}

		#endregion

		#region private void ToolStripMenuItemOpenClick(object sender, EventArgs e)

		private void ToolStripMenuItemOpenClick(object sender, EventArgs e)
		{
            if (_type == CheckListType.Audit && (_routineAudit?.Type == ProgramType.CAAKG || _routineAudit?.Type == ProgramType.IOSA))
            {
                var form = new CheckListAuditForm(_directivesViewer.SelectedItem, _parentId);
                if (form.ShowDialog() == DialogResult.OK)
                    AnimatedThreadWorker.RunWorkerAsync();
            }
            else
            {
				var form = new CheckListForm.CheckListForm(_directivesViewer.SelectedItem, false);
                if (form.ShowDialog() == DialogResult.OK)
                    AnimatedThreadWorker.RunWorkerAsync();
			}
        }

		#endregion
		
		#region private void InitListView()

		private void InitListView()
        {
	        if (_type == CheckListType.Audit)
	        {
		        if (_manual.CheckUIType == CheckUIType.Iosa)
			        _directivesViewer = new CheckListLiteView(AnimatedThreadWorker);
		        else  if (_manual.CheckUIType == CheckUIType.Safa)
			        _directivesViewer = new CheckListSAFAView(AnimatedThreadWorker, false);
		        else  if (_manual.CheckUIType == CheckUIType.Icao)
			        _directivesViewer = new CheckListICAOView(AnimatedThreadWorker, false);
		        else return;
	        }
            else
            {
	            if (_manual.CheckUIType == CheckUIType.Iosa)
		            _directivesViewer = new CheckListView(AnimatedThreadWorker, false);
	            else  if (_manual.CheckUIType == CheckUIType.Safa)
		            _directivesViewer = new CheckListSAFAView(AnimatedThreadWorker, false);
	            else  if (_manual.CheckUIType == CheckUIType.Icao)
		            _directivesViewer = new CheckListICAOView(AnimatedThreadWorker, false);
	            else return;
            }

			_directivesViewer.TabIndex = 2;
			_directivesViewer.Location = new Point(panel1.Left, panel1.Top);
			_directivesViewer.Dock = DockStyle.Fill;
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;
			Controls.Add(_directivesViewer);
			//события 
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

			_directivesViewer.AddMenuItems(_toolStripMenuItemOpen);

			_directivesViewer.MenuOpeningAction = () =>
			{
				if (_directivesViewer.SelectedItems.Count <= 0)
					return;
				if (_directivesViewer.SelectedItems.Count == 1)
				{
					_toolStripMenuItemOpen.Enabled = true;
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

		#region private void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)

		private void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)
		{
            if (_currentRoutineId.HasValue)
            {
                var form = new CheckListRoutineForm(_currentRoutineId.Value, _operatorId);
                if (form.ShowDialog() == DialogResult.OK)
                    AnimatedThreadWorker.RunWorkerAsync();
			}
            e.Cancel = true;
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
	        var refE = new ReferenceEventArgs();
	        var dp = new DisplayerParams()
	        {
		        Page = new PELListScreen(GlobalObjects.CaaEnvironment.Operators.FirstOrDefault(), _operatorId, _parentId, _initialDocumentArray),
		        TypeOfReflection = ReflectionTypes.DisplayInNew,
		        PageCaption = $"PEL {_audit.AuditNumber}",
		        DisplayerType = DisplayerType.Screen
	        };
	        refE.SetParameters(dp);
	        InvokeDisplayerRequested(refE);
        }
	}
}
