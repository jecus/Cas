using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.DTO;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CASTerms;
using Entity.Abstractions.Filters;
using SmartCore.CAA.Check;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Filters;
using Telerik.WinControls.UI;

namespace CAS.UI.UICAAControls.CheckList.EditionRevision
{
    ///<summary>
    ///</summary>
    [ToolboxItem(false)]
	public partial class EditionRevisionListScreen : ScreenControl
	{
        private readonly int _operatorId;
        private readonly SmartCore.CAA.StandartManual.StandartManual _manual;
        private CommonCollection<CheckListRevision> _initialDocumentArray = new CommonCollection<CheckListRevision>();
		private CommonCollection<CheckListRevision> _resultDocumentArray = new CommonCollection<CheckListRevision>();
		private CommonFilterCollection _filter;

		private EditionRevisionListView _directivesViewer;
        private RadMenuItem _toolStripMenuItemOpen;
        private RadMenuItem _toolStripMenuItemEdit;
        private RadMenuItem _toolStripMenuItemCreateRevision;

		
		public EditionRevisionListScreen()
		{
			InitializeComponent();
		}
		
        public EditionRevisionListScreen(Operator currentOperator, int operatorId, SmartCore.CAA.StandartManual.StandartManual manual)
            : this()
        {
            if (currentOperator == null)
                throw new ArgumentNullException("currentOperator");
            _operatorId = operatorId;
            _manual = manual;
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
			_initialDocumentArray.AddRange(GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CheckListRevisionDTO, CheckListRevision>(new []
			{
				new Filter("OperatorId", _operatorId),
				new Filter("ManualId", _manual.ItemId)
			}));

			foreach (var revision in _initialDocumentArray.Where(i => i.Type == RevisionType.Revision))
				revision.CurrentStatus = _initialDocumentArray.FirstOrDefault(i => i.ItemId == revision.EditionId).Status;
			
			foreach (var edition in _initialDocumentArray.Where(i => i.Type == RevisionType.Edition))
				edition.CurrentStatus = edition.Status;

			AnimatedThreadWorker.ReportProgress(70, "filter directives");

            FilterItems(_initialDocumentArray, _resultDocumentArray);

            AnimatedThreadWorker.ReportProgress(100, "Complete");

		}
		#endregion

		#region private void InitToolStripMenuItems()

		private void InitToolStripMenuItems()
		{
			_toolStripMenuItemOpen = new RadMenuItem();
			_toolStripMenuItemEdit = new RadMenuItem();
			_toolStripMenuItemCreateRevision = new RadMenuItem();
			// 
			// toolStripMenuItemView
			// 
			_toolStripMenuItemOpen.Text = "Open";
			_toolStripMenuItemOpen.Click += ToolStripMenuItemOpenClick;
			// 
			// _toolStripMenuItemEdit
			// 
			_toolStripMenuItemEdit.Text = "Edit";
			_toolStripMenuItemEdit.Click += ToolStripMenuItemEditClick;
			// 
			// _toolStripMenuItemCreateRevision
			// 
			_toolStripMenuItemCreateRevision.Text = "Create Revision";
			_toolStripMenuItemCreateRevision.Click += ToolStripMenuItemCreateRevisionClick;
		}

		private void ToolStripMenuItemCreateRevisionClick(object sender, EventArgs e)
		{
			var form = new EditionForm(new CheckListRevision
			{
				OperatorId = _operatorId,
				Type = RevisionType.Revision,
				Status = EditionRevisionStatus.Temporary,
				ManualId = _manual.ItemId,
				Settings = new CheckListRevisionSettings()
				{
					EditionId = _directivesViewer.SelectedItem.EditionId
				}
			});
			if(form.ShowDialog() == DialogResult.OK)
				AnimatedThreadWorker.RunWorkerAsync();
		}

		private void ToolStripMenuItemEditClick(object sender, EventArgs e)
		{
			var form = new EditionForm(_directivesViewer.SelectedItem);
			if(form.ShowDialog() == DialogResult.OK)
				AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion
		
		#region private void ToolStripMenuItemOpenClick(object sender, EventArgs e)

		private void ToolStripMenuItemOpenClick(object sender, EventArgs e)
		{
			var refE = new ReferenceEventArgs();
			var dp = new DisplayerParams()
			{
				Page = new EditionRevisionRecordListScreen(GlobalObjects.CaaEnvironment.Operators[0], _directivesViewer.SelectedItem, _operatorId, _manual),
				TypeOfReflection = ReflectionTypes.DisplayInNew,
				PageCaption = $"{_directivesViewer.SelectedItem.Type} : {_directivesViewer.SelectedItem.Number} {_manual.ProgramType}",
				DisplayerType = DisplayerType.Screen
			};
			refE.SetParameters(dp);
			InvokeDisplayerRequested(refE);
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
            _directivesViewer = new EditionRevisionListView(AnimatedThreadWorker, _manual);
            _directivesViewer.OperatorId = _operatorId;
			_directivesViewer.TabIndex = 2;
			_directivesViewer.Location = new Point(panel1.Left, panel1.Top);
			_directivesViewer.Dock = DockStyle.Fill;
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;
			Controls.Add(_directivesViewer);
			//события 
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

			_directivesViewer.AddMenuItems(_toolStripMenuItemOpen,_toolStripMenuItemEdit, _toolStripMenuItemCreateRevision);

			_directivesViewer.MenuOpeningAction = () =>
			{
				if (_directivesViewer.SelectedItems.Count <= 0)
					return;
				if (_directivesViewer.SelectedItems.Count > 1)
				{
					_toolStripMenuItemOpen.Enabled = false;
					_toolStripMenuItemEdit.Enabled = false;
					_toolStripMenuItemCreateRevision.Enabled = false;
				}
				else if (_directivesViewer.SelectedItems.Count == 1)
				{
					_toolStripMenuItemOpen.Enabled = true;
					if(_directivesViewer.SelectedItem.Status == EditionRevisionStatus.Previous)
						_toolStripMenuItemEdit.Enabled = false;
					else _toolStripMenuItemEdit.Enabled = true;
					
					if(_directivesViewer.SelectedItem.Type == RevisionType.Edition && 
					   (_directivesViewer.SelectedItem.Status == EditionRevisionStatus.Temporary ||
					   _directivesViewer.SelectedItem.Status == EditionRevisionStatus.Current))
						_toolStripMenuItemCreateRevision.Enabled = true;
					else _toolStripMenuItemCreateRevision.Enabled = false;
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
		private void FilterItems(IEnumerable<CheckListRevision> initialCollection, ICommonCollection<CheckListRevision> resultCollection)
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

		private void ButtonAddClick(object sender, EventArgs e)
		{
			var form = new EditionForm(new CheckListRevision
			{
				OperatorId = _operatorId,
				Type = RevisionType.Edition,
				Status = EditionRevisionStatus.Temporary,
				ManualId = _manual.ItemId
			});
			if(form.ShowDialog() == DialogResult.OK)
				AnimatedThreadWorker.RunWorkerAsync();
		}
	}
}
