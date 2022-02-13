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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UICAAControls.Audit;
using CAS.UI.UIControls.NewGrid;
using SmartCore.CAA.Audit;
using Telerik.WinControls.UI;

namespace CAS.UI.UICAAControls.CheckList
{
    ///<summary>
    ///</summary>
    [ToolboxItem(false)]
	public partial class CheckListsScreen : ScreenControl
	{
        private readonly int _operatorId;

        #region Fields

        private  int? _currentRoutineId;
        private readonly int? _routingId;
        private readonly int? _auditId;

        private CommonCollection<CheckLists> _initialDocumentArray = new CommonCollection<CheckLists>();
		private CommonCollection<CheckLists> _resultDocumentArray = new CommonCollection<CheckLists>();
		private CommonFilterCollection _filter;

		private BaseGridViewControl<CheckLists> _directivesViewer;

		private RadMenuItem _toolStripMenuItemOpen;
		private RadMenuItem _toolStripMenuItemHighlight;
		private RadMenuSeparatorItem _toolStripSeparator1;
        private SmartCore.CAA.RoutineAudits.RoutineAudit _routineAudit;
        private CAAAudit _audit;

        #endregion


		#region Constructors

		#region public CAAPersonnelListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		public CheckListsScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public PersonnelListScreen(Operator currentOperator)

        ///<summary>
        /// Создаёт экземпляр элемента управления, отображающего список директив
        ///</summary>
        ///<param name="currentOperator">ВС, которому принадлежат директивы</param>>
        public CheckListsScreen(Operator currentOperator,int operatorId, int? routingId = null, int? auditId = null)
            : this()
        {
            if (currentOperator == null)
                throw new ArgumentNullException("currentOperator");
            aircraftHeaderControl1.Operator = currentOperator;
            _routingId = routingId;
            _auditId = auditId;
            _operatorId = operatorId;
            statusControl.ShowStatus = false;
            labelTitle.Visible = false;

            _filter = new CommonFilterCollection(typeof(ICheckListFilterParams));

			InitToolStripMenuItems();
			InitListView();
			UpdateInformation();
		}


        public CheckListsScreen(Operator currentOperator, int operatorId)
            : this()
        {
            if (currentOperator == null)
                throw new ArgumentNullException("currentOperator");
            _operatorId = operatorId;
            aircraftHeaderControl1.Operator = currentOperator;
            statusControl.ShowStatus = false;
            labelTitle.Visible = false;

            _filter = new CommonFilterCollection(typeof(ICheckListFilterParams));

            InitToolStripMenuItems();
            InitListView();
            UpdateInformation();
        }

		#endregion

		#endregion

		#region Methods

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{

			if (_routingId.HasValue)
			{
				pictureBox1.Visible = true;
				buttonAddNew.Visible = true;
			}
	        
	        if (_routingId.HasValue || _auditId.HasValue)
	        {
		        pictureBox3.Visible = false;
		        buttonRevisions.Visible = false;
	        }
	        
            if (_auditId.HasValue)
            {
	            this.headerControl.ShowEditButton = true;
	            this.headerControl.EditButtonClick += HeaderControl_EditButtonClick;
	            
	            pictureBox6.Visible = true;
	            buttonPel.Visible = true;
	            
	            labelTitle.Text = $"Workflow Stage : {WorkFlowStage.GetItemById(_audit.Settings.WorkflowStageId)}";
                labelTitle.Visible = true;
            }
            
            if (_directivesViewer is CheckListLiteView lite)
            {
                lite.AuditId = _auditId;
                lite.IsAuditCheck = _auditId.HasValue &&
                                    (_routineAudit?.Type == ProgramType.CAAKG ||
                                     _routineAudit?.Type == ProgramType.IOSA);
			}
			else if(_directivesViewer is CheckListView view)

            {
                view.AuditId = _auditId;
                view.IsAuditCheck = _auditId.HasValue &&
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


            if (_routingId.HasValue)
            {
                _currentRoutineId = _routingId;
				var records = GlobalObjects.CaaEnvironment.NewLoader
                    .GetObjectListAll<RoutineAuditRecordDTO, RoutineAuditRecord>(new Filter("RoutineAuditId", _routingId), loadChild: true).ToList();

                var ids = records.Select(i => i.CheckListId);

                if (ids.Any())
                    _initialDocumentArray.AddRange(GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<CheckListDTO, CheckLists>(new Filter("ItemId", ids), loadChild: true));

			}
			else if (_auditId.HasValue)
            {

                _audit = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<CAAAuditDTO, CAAAudit>(_auditId.Value);
                var records = GlobalObjects.CaaEnvironment.NewLoader
                    .GetObjectListAll<CAAAuditRecordDTO, CAAAuditRecord>(new Filter("AuditId", _auditId), loadChild: true).ToList();

                _currentRoutineId = records.Select(i => i.RoutineAuditId).FirstOrDefault();
                _routineAudit = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<RoutineAuditDTO, SmartCore.CAA.RoutineAudits.RoutineAudit>(_currentRoutineId.Value);

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
	            var editions = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CheckListRevisionDTO, CheckListRevision>(new Filter("Status", (int)EditionRevisionStatus.Open));
	            if (editions.Any())
	            {
		            var edition = editions.FirstOrDefault();
		            _initialDocumentArray.AddRange(GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<CheckListDTO, CheckLists>(new Filter("EditionId", edition.ItemId), loadChild:true));
		            
		            foreach (var check in _initialDocumentArray)
			            check.EditionNumber = edition.Number;
	            }
            }

            var levels = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<FindingLevelsDTO, FindingLevels>(new Filter("OperatorId", _operatorId));
            

//             var dsRevision = GlobalObjects.CaaEnvironment.Execute($@"
// select c.ItemId as CheckId, res.Number from dbo.CheckList c
// cross apply
// (
// 	select top 1 r.Number from dbo.CheckListRevisionRecord  rec
// 	cross apply
// 	(
// 		select Number,EffDate, Type, OperatorId from dbo.CheckListRevision 
// 		where ItemId = rec.ParentId
// 	)r
// 	where c.IsDeleted = 0 and rec.CheckListId = c.ItemId and rec.IsDeleted = 0 and r.Type = 1 and r.OperatorId = {_operatorId}
// 	order by r.EffDate desc
// ) res");
//             
//
//             var revisions = dsRevision.Tables[0].AsEnumerable()
//                 .Select(dataRow => new
//                 {
//                     Id = dataRow.Field<int>("CheckId"),
//                     Number = dataRow.Field<int>("Number"),
//                 }).ToList();


			foreach (var check in _initialDocumentArray)
            {
                check.Level = levels.FirstOrDefault(i => i.ItemId == check.Settings.LevelId) ??
                              FindingLevels.Unknown;


				check.Remains = Lifelength.Null;
                check.Condition = ConditionState.Satisfactory;


                // var revision = revisions.FirstOrDefault(i => i.Id == check.ItemId);
                // if (revision != null)
                //     check.RevisionNumber = revision.Number;
                
				//             var days = (check.Settings.RevisonValidToDate - DateTime.Today).Days;
				//             var editionDays = 0;
				// if (!check.Settings.RevisonValidTo)
				//                 editionDays = (check.Settings.EditionDate - DateTime.Today).Days;
				//             else
				//             {
				//                 var revision = revisions.FirstOrDefault(i => i.Id == check.ItemId);
				// 	if(revision != null)
				//                     editionDays = (revision.Date - DateTime.Today).Days;
				//             }
				//
				//             check.Remains = new Lifelength(days - editionDays, null, null);
				//
				//
				// if(check.Remains.Days < 0)
				//                 check.Condition = ConditionState.Overdue;
				// else if (check.Remains.Days >= 0 && check.Remains.Days <= check.Settings.RevisonValidToNotify)
				//                 check.Condition = ConditionState.Notify;
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
			_toolStripMenuItemHighlight = new RadMenuItem();
			_toolStripSeparator1 = new RadMenuSeparatorItem();
			// 
			// toolStripMenuItemView
			// 
			_toolStripMenuItemOpen.Text = "Open";
			_toolStripMenuItemOpen.Click += ToolStripMenuItemOpenClick;
			// 
			// toolStripMenuItemHighlight
			// 
			_toolStripMenuItemHighlight.Text = "Highlight";
			
			_toolStripMenuItemHighlight.Items.Clear();

			foreach (Highlight highlight in Highlight.HighlightList)
			{
				if (highlight == Highlight.Blue || highlight == Highlight.Yellow || highlight == Highlight.Red)
					continue;
				RadMenuItem item = new RadMenuItem(highlight.FullName);
				item.Click += HighlightItemClick;
				item.Tag = highlight;
				_toolStripMenuItemHighlight.Items.Add(item);
			}
		}
		#endregion

        private void HeaderControl_EditButtonClick(object sender, EventArgs e)
        {
			var form = new EditAuditForm(_auditId.Value);
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
            if (_auditId.HasValue && (_routineAudit?.Type == ProgramType.CAAKG || _routineAudit?.Type == ProgramType.IOSA))
            {
                var form = new CheckListAuditForm(_directivesViewer.SelectedItem, _auditId.Value);
                if (form.ShowDialog() == DialogResult.OK)
                    AnimatedThreadWorker.RunWorkerAsync();
            }
            else
            {
				var form = new CheckListForm(_directivesViewer.SelectedItem);
                if (form.ShowDialog() == DialogResult.OK)
                    AnimatedThreadWorker.RunWorkerAsync();
			}
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
            if (_auditId.HasValue)
                _directivesViewer = new CheckListLiteView(AnimatedThreadWorker);
            else _directivesViewer = new CheckListView(AnimatedThreadWorker);

			_directivesViewer.TabIndex = 2;
			_directivesViewer.Location = new Point(panel1.Left, panel1.Top);
			_directivesViewer.Dock = DockStyle.Fill;
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;
			Controls.Add(_directivesViewer);
			//события 
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

			_directivesViewer.AddMenuItems(_toolStripMenuItemOpen,
				_toolStripSeparator1,
				_toolStripMenuItemHighlight);

			_directivesViewer.MenuOpeningAction = () =>
			{
				if (_directivesViewer.SelectedItems.Count <= 0)
					return;
				if (_directivesViewer.SelectedItems.Count == 1)
				{
					_toolStripMenuItemOpen.Enabled = true;
				}
			};


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
		        Page = new EditionRevisionListScreen(GlobalObjects.CaaEnvironment.Operators.FirstOrDefault(), _operatorId),
		        TypeOfReflection = ReflectionTypes.DisplayInNew,
		        PageCaption = $"Edition/Revision",
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
		        Page = new PELListScreen(GlobalObjects.CaaEnvironment.Operators.FirstOrDefault(), _operatorId, _auditId.Value, _initialDocumentArray),
		        TypeOfReflection = ReflectionTypes.DisplayInNew,
		        PageCaption = $"PEL {_audit.AuditNumber}",
		        DisplayerType = DisplayerType.Screen
	        };
	        refE.SetParameters(dp);
	        InvokeDisplayerRequested(refE);
        }
	}
}
