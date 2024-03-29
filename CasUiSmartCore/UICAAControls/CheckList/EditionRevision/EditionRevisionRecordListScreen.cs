﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.Dictionary;
using CAA.Entity.Models.DTO;
using CAS.UI.Interfaces;
using CAS.UI.UICAAControls.CheckList.EditionRevision.Icao;
using CAS.UI.UICAAControls.CheckList.EditionRevision.Iosa;
using CAS.UI.UICAAControls.CheckList.EditionRevision.Safa;
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
using Telerik.WinControls.UI;

namespace CAS.UI.UICAAControls.CheckList.EditionRevision
{
    ///<summary>
    ///</summary>
    [ToolboxItem(false)]
	public partial class EditionRevisionRecordListScreen : ScreenControl
	{
		private readonly int _operatorId;
		private readonly SmartCore.CAA.StandartManual.StandartManual _manual;
		private CommonCollection<CheckLists> _initialDocumentArray = new CommonCollection<CheckLists>();
		private CommonCollection<CheckLists> _resultDocumentArray = new CommonCollection<CheckLists>();
		private CommonFilterCollection _filter;

		private CheckListView _directivesViewer;
		private readonly CheckListRevision _parent;


        public EditionRevisionRecordListScreen()
		{
			InitializeComponent();
		}
		
        public EditionRevisionRecordListScreen(Operator currentOperator, CheckListRevision parent, int operatorId, SmartCore.CAA.StandartManual.StandartManual manual)
            : this()
        {
            if (currentOperator == null)
                throw new ArgumentNullException("currentOperator");
            _parent = parent;
            _operatorId = operatorId;
            _manual = manual;
            aircraftHeaderControl1.Operator = currentOperator;
            statusControl.ShowStatus = false;
            labelTitle.Visible = false;

            if (_manual.CheckUIType == CheckUIType.Iosa)
				_filter = new CommonFilterCollection(typeof(ICheckListFilterParams));
            else if (_manual.CheckUIType == CheckUIType.Safa)
	            _filter = new CommonFilterCollection(typeof(ICheckListSafaFilterParams));
            else if (_manual.CheckUIType == CheckUIType.Icao)
	            _filter = new CommonFilterCollection(typeof(ICheckListIcaoFilterParams));


            if (parent.Status == EditionRevisionStatus.Previous || (parent.Status == EditionRevisionStatus.Current && parent.Type == RevisionType.Revision))
            {
	            buttonRevison.Visible =
		            pictureBox2.Visible =
		            buttonAddNew.Visible =
	            pictureBox4.Visible = false;
            }
            InitListView();
			UpdateInformation();
		}



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

            AnimatedThreadWorker.ReportProgress(0, "load");


            if (_parent.Type == RevisionType.Edition)
            {
	            _initialDocumentArray.AddRange(GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CheckListDTO, CheckLists>(new []
	            {
		            new Filter("EditionId", _parent.ItemId), 
		            new Filter("ManualId", _manual.ItemId), 
	            }));
	            
	            var revisions = new List<CheckListRevision>();
	            var revIds = _initialDocumentArray.Where(i => i.RevisionId.HasValue).Select(i => i.RevisionId.Value).Distinct();
	            if (revIds.Any())
	            {
		            revisions.AddRange(GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CheckListRevisionDTO, CheckListRevision>(new List<Filter>()
		            {
			            new Filter("ItemId", values: revIds),
		            }));
	            }
	            
	            foreach (var check in _initialDocumentArray)
	            {
		            check.RevisionNumber = revisions.FirstOrDefault(i => i.ItemId == check.RevisionId)?.Number.ToString() ?? "";
		            check.EditionNumber = _parent.Number.ToString();
	            }
            }
            else
            {
	            var records = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CheckListRevisionRecordDTO, CheckListRevisionRecord>(new []
	            {
		            new Filter("ParentId", _parent.ItemId),
	            });
	            if (records.Any())
	            {
		            var ids = records.Select(i => i.CheckListId);
		            _initialDocumentArray.AddRange(GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CheckListDTO, CheckLists>(new Filter("ItemId", ids), getDeleted:true));
		            var edition = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<CheckListRevisionDTO, CheckListRevision>(_parent.Settings.EditionId);
		            foreach (var check in _initialDocumentArray)
		            {
			            var rec = records.FirstOrDefault(i => i.CheckListId == check.ItemId);
			            if (rec != null)
				            check.Changes = string.Join(", ", rec.Settings.ModData.Select(i => i.Key));

			            check.RevisionStatus = records.FirstOrDefault(i => i.CheckListId == check.ItemId)?.Settings?.RevisionCheckType ?? RevisionCheckType.None;
			            check.EditionNumber = edition.Number.ToString();
			            check.RevisionNumber = _parent.Number.ToString();
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
	            if (check.CheckUIType == CheckUIType.Iosa)
	            {
		            check.Level = levels.FirstOrDefault(i => i.ItemId == check.Settings.LevelId) ??
		                          FindingLevels.Unknown;
	            }
	            else
	            {
		            check.Level = levels.FirstOrDefault(i => i.ItemId == check.SettingsSafa.LevelId) ??
		                          FindingLevels.Unknown;
	            }
	            
             check.Remains = Lifelength.Null;
             check.Condition = ConditionState.Satisfactory;
            }

            AnimatedThreadWorker.ReportProgress(70, "filter directives");

            FilterItems(_initialDocumentArray, _resultDocumentArray);

            AnimatedThreadWorker.ReportProgress(100, "Complete");

		}
		#endregion

		#region private void InitListView()

		private void InitListView()
		{
			if (_parent.Type == RevisionType.Edition)
			{
				if (_manual.CheckUIType == CheckUIType.Iosa)
					_directivesViewer = new CheckListView(AnimatedThreadWorker);
				else  if (_manual.CheckUIType == CheckUIType.Safa)
					_directivesViewer = new CheckListSAFAView(AnimatedThreadWorker);
				else  if (_manual.CheckUIType == CheckUIType.Icao)
					_directivesViewer = new CheckListICAOView(AnimatedThreadWorker);
				else return;
				
			}
			else
			{
				if (_manual.CheckUIType == CheckUIType.Iosa)
					_directivesViewer = new CheckListRevisionView(AnimatedThreadWorker);
				else  if (_manual.CheckUIType == CheckUIType.Safa)
					_directivesViewer = new CheckListRevisionSAFAView(AnimatedThreadWorker);
				else  if (_manual.CheckUIType == CheckUIType.Icao)
					_directivesViewer = new CheckListRevisionICAOView(AnimatedThreadWorker);
				else return;
			}
			
            _directivesViewer.IsRevision = _parent.Type == RevisionType.Revision;
            _directivesViewer.Revision = _parent.Type == RevisionType.Revision ? _parent : null;

			_directivesViewer.TabIndex = 2;
			_directivesViewer.Location = new Point(panel1.Left, panel1.Top);
			_directivesViewer.Dock = DockStyle.Fill;
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;
			Controls.Add(_directivesViewer);
			//события 
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;
			
			_directivesViewer.DisableContectMenu();

			_directivesViewer.MenuOpeningAction = () =>
			{
				if (_directivesViewer.SelectedItems.Count <= 0)
					return;
				if (_directivesViewer.SelectedItems.Count == 1)
				{
					
				}
			};

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
		
		private void ButtonRevisionClick(object sender, EventArgs e)
		{
			if (_parent.Type == RevisionType.Revision)
			{
				var form = new CheckListRevisionEditForm(_operatorId, _parent, _initialDocumentArray, _manual);
				if (form.ShowDialog(this) == DialogResult.OK || form.ShowDialog(this) == DialogResult.Cancel)
					AnimatedThreadWorker.RunWorkerAsync();
			}
			else
			{
				if (_manual.CheckUIType == CheckUIType.Iosa)
				{
					var form = new CheckListRevisionForm(_operatorId, _parent, _manual);
					if (form.ShowDialog(this) == DialogResult.OK || form.ShowDialog(this) == DialogResult.Cancel)
						AnimatedThreadWorker.RunWorkerAsync();
				}
				else if (_manual.CheckUIType == CheckUIType.Safa)
				{
					var form = new CheckListSafaRevisionForm(_operatorId, _parent, _manual);
					if (form.ShowDialog(this) == DialogResult.OK || form.ShowDialog(this) == DialogResult.Cancel)
						AnimatedThreadWorker.RunWorkerAsync();
				}
				else if (_manual.CheckUIType == CheckUIType.Icao)
				{
					var form = new CheckListIcaoRevisionForm(_operatorId, _parent, _manual);
					if (form.ShowDialog(this) == DialogResult.OK || form.ShowDialog(this) == DialogResult.Cancel)
						AnimatedThreadWorker.RunWorkerAsync();
				}
			}
		}

		private void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			var check = new CheckLists
			{
				OperatorId = _operatorId,
				ManualId = _manual.ItemId,
				ProgramType = ProgramType.GetItemById(_manual.ProgramTypeId)
			};

			if (check.CheckUIType == CheckUIType.Iosa)
			{
				check.Settings = new CheckListSettings()
				{
					ProgramTypeId = _manual.ProgramType.ItemId
				};
				
				if (_parent.Type == RevisionType.Revision)
				{
					check.EditionId = -1;
					var form = new CheckListForm.CheckListForm(check, _parent.ItemId);
					if (form.ShowDialog() == DialogResult.OK)
						AnimatedThreadWorker.RunWorkerAsync();
				}
				else
				{
					check.EditionId = _parent.ItemId;
					var form = new CheckListForm.CheckListForm(check);
					if (form.ShowDialog() == DialogResult.OK)
						AnimatedThreadWorker.RunWorkerAsync();
				}
			}
			else if (check.CheckUIType == CheckUIType.Safa)
			{
				check.SettingsSafa = new CheckListSettingsSAFA()
				{
					ProgramTypeId = _manual.ProgramType.ItemId
				};
				
				if (_parent.Type == RevisionType.Revision)
				{
					check.EditionId = -1;
					var form = new CheckListForm.CheckListSAFAForm(check, _parent.ItemId);
					if (form.ShowDialog() == DialogResult.OK)
						AnimatedThreadWorker.RunWorkerAsync();
				}
				else
				{
					check.EditionId = _parent.ItemId;
					var form = new CheckListForm.CheckListSAFAForm(check);
					if (form.ShowDialog() == DialogResult.OK)
						AnimatedThreadWorker.RunWorkerAsync();
				}
			}
			else if (check.CheckUIType == CheckUIType.Icao)
			{
				check.SettingsIcao = new CheckListICAOSettings()
				{
					ProgramTypeId = _manual.ProgramType.ItemId
				};
				
				if (_parent.Type == RevisionType.Revision)
				{
					check.EditionId = -1;
					var form = new CheckListForm.CheckListICAOForm(check, _parent.ItemId);
					if (form.ShowDialog() == DialogResult.OK)
						AnimatedThreadWorker.RunWorkerAsync();
				}
				else
				{
					check.EditionId = _parent.ItemId;
					var form = new CheckListForm.CheckListICAOForm(check);
					if (form.ShowDialog() == DialogResult.OK)
						AnimatedThreadWorker.RunWorkerAsync();
				}
			}
			else
			{
				MessageBox.Show($"For ProgramType:{_manual.ProgramType} form not found!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
				e.Cancel = true;

			}
			
		}
	}
}
