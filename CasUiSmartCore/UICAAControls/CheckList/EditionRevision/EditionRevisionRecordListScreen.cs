using CAA.Entity.Models.DTO;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CASTerms;
using Entity.Abstractions.Filters;
using SmartCore.CAA.Check;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.Dictionary;
using SmartCore.CAA.FindingLevel;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using Telerik.WinControls.UI;

namespace CAS.UI.UICAAControls.CheckList
{
    ///<summary>
    ///</summary>
    [ToolboxItem(false)]
	public partial class EditionRevisionRecordListScreen : ScreenControl
	{
		private readonly int _operatorId;
		private CommonCollection<CheckLists> _initialDocumentArray = new CommonCollection<CheckLists>();
		private CommonCollection<CheckLists> _resultDocumentArray = new CommonCollection<CheckLists>();
		private CommonFilterCollection _filter;

		private CheckListView _directivesViewer;
        private RadMenuItem _toolStripMenuItemOpen;
        private readonly CheckListRevision _parent;


        public EditionRevisionRecordListScreen()
		{
			InitializeComponent();
		}
		
        public EditionRevisionRecordListScreen(Operator currentOperator, CheckListRevision parent, int operatorId)
            : this()
        {
            if (currentOperator == null)
                throw new ArgumentNullException("currentOperator");
            _parent = parent;
            _operatorId = operatorId;
            aircraftHeaderControl1.Operator = currentOperator;
            statusControl.ShowStatus = false;
            labelTitle.Visible = false;

            _filter = new CommonFilterCollection(typeof(ICheckListRevisionFilterParams));
            
			InitToolStripMenuItems();
			InitListView();
			UpdateInformation();
		}



        #region Methods

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
	        if (_parent.Type == RevisionType.Revision)
	        {
		        buttonRevison.Visible = false;
		        pictureBox4.Visible = false;
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

            AnimatedThreadWorker.ReportProgress(0, "load");


            if (_parent.Type == RevisionType.Edition)
            {
	            _initialDocumentArray.AddRange(GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CheckListDTO, CheckLists>(new Filter("EditionId", _parent.ItemId)));
	            foreach (var check in _initialDocumentArray)
		            check.EditionNumber = _parent.Number;
            }
            else
            {
	            var records = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CheckListRevisionRecordDTO, CheckListRevisionRecord>(new Filter("ParentId", _parent.ItemId));
	            if (records.Any())
	            {
		            var ids = records.Select(i => i.CheckListId);
		            _initialDocumentArray.AddRange(GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CheckListDTO, CheckLists>(new Filter("ItemId", ids)));
		            var edition = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<CheckListRevisionDTO, CheckListRevision>(_parent.Settings.EditionId);
		            foreach (var check in _initialDocumentArray)
			            check.EditionNumber = edition.Number;
	            }
            }
            
            var lvlids = _initialDocumentArray.Select(i => i.Settings.LevelId);
            var levels = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<FindingLevelsDTO, FindingLevels>(new Filter("ItemId", lvlids));
            
            foreach (var check in _initialDocumentArray)
            {
	            
             check.Level = levels.FirstOrDefault(i => i.ItemId == check.Settings.LevelId) ??
                           FindingLevels.Unknown;
            
            
             check.Remains = Lifelength.Null;
             check.Condition = ConditionState.Satisfactory;
            }
            

            // var records = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CheckListRevisionRecordDTO, CheckListRevisionRecord>(new Filter("ParentId", _parentId));
            //
            // if (records.Any())
            // {
	           //  var ids = records.Select(i => i.CheckListId);
	           //  _initialDocumentArray.AddRange(GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CheckListDTO, CheckLists>(new Filter("ItemId", ids)));
            // }
            //

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
		
		#region private void ToolStripMenuItemOpenClick(object sender, EventArgs e)

		private void ToolStripMenuItemOpenClick(object sender, EventArgs e)
		{
            
        }

		#endregion

		#region private void ButtonDeleteClick(object sender, EventArgs e)
		private void ButtonDeleteClick(object sender, EventArgs e)
		{
			if (_parent.Type == RevisionType.Revision)
			{
				if (_directivesViewer.SelectedItems == null ||
				    _directivesViewer.SelectedItems.Count == 0) return;
				
				string typeName = nameof(CheckLists);
				
				DialogResult confirmResult =
					MessageBox.Show(_directivesViewer.SelectedItems.Count == 1
							? "Do you really want to delete " + typeName + " " + _directivesViewer.SelectedItems[0] + "?"
							: "Do you really want to delete selected " + typeName + "s?", "Confirm delete operation",
						MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
				
				
				if (confirmResult == DialogResult.Yes)
				{
					GlobalObjects.CaaEnvironment.NewLoader.Execute(
						$"delete from  dbo.CheckListRevisionRecord where ParentId = {_parent.ItemId} and CheckListId in ({string.Join(",", _directivesViewer.SelectedItems.Select(i => i.ItemId))})");
					AnimatedThreadWorker.RunWorkerAsync();
				}
			}
            else _directivesViewer.ButtonDeleteClick(sender, e);
		}

		#endregion

		#region private void InitListView()

		private void InitListView()
        {
            _directivesViewer = new CheckListView();

			_directivesViewer.TabIndex = 2;
			_directivesViewer.Location = new Point(panel1.Left, panel1.Top);
			_directivesViewer.Dock = DockStyle.Fill;
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;
			Controls.Add(_directivesViewer);
			//события 
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

			_directivesViewer.AddMenuItems(_toolStripMenuItemOpen);
			_directivesViewer.DisableContectMenu();

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
			var form = new CheckListRevisionForm(_operatorId, _parent);

			if (form.ShowDialog(this) == DialogResult.OK || form.ShowDialog(this) == DialogResult.Cancel)
				AnimatedThreadWorker.RunWorkerAsync();
		}

		private void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			if (_parent.Type == RevisionType.Revision)
			{
				var form = new CheckListRevEditForm();
				if (form.ShowDialog() == DialogResult.OK)
					AnimatedThreadWorker.RunWorkerAsync();
			}
			else
			{
				var form = new CheckListForm(new CheckLists(){OperatorId = _operatorId, EditionId = _parent.ItemId});
				if (form.ShowDialog() == DialogResult.OK)
					AnimatedThreadWorker.RunWorkerAsync();
			}
			
		}
	}
}
