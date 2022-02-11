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
using CAS.UI.UICAAControls.Audit.PEL;
using SmartCore.CAA.PEL;
using SmartCore.Entities.General.Personnel;
using Telerik.WinControls.UI;

namespace CAS.UI.UICAAControls.CheckList
{
    ///<summary>
    ///</summary>
    [ToolboxItem(false)]
	public partial class PELListScreen : ScreenControl
	{
        private readonly int _operatorId;
        private readonly int _auditId;
        private readonly CommonCollection<CheckLists> _checks;
        private CommonCollection<AuditPelRecord> _initialDocumentArray = new CommonCollection<AuditPelRecord>();
		private CommonCollection<AuditPelRecord> _resultDocumentArray = new CommonCollection<AuditPelRecord>();
		private CommonFilterCollection _filter;

		private AuditPelRecordListView _directivesViewer;
        private RadMenuItem _toolStripMenuItemOpen;

		
		public PELListScreen()
		{
			InitializeComponent();
		}
		
        public PELListScreen(Operator currentOperator, int operatorId, int auditId, CommonCollection<CheckLists> checks)
            : this()
        {
            if (currentOperator == null)
                throw new ArgumentNullException("currentOperator");
            _operatorId = operatorId;
            _auditId = auditId;
            _checks = checks;
            aircraftHeaderControl1.Operator = currentOperator;
            statusControl.ShowStatus = false;
            labelTitle.Visible = false;

            _filter = new CommonFilterCollection(typeof(IAuditPelRecordFilterParams));

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
            
            var records = GlobalObjects.CaaEnvironment.NewLoader
	            .GetObjectListAll<AuditPelRecordDTO, AuditPelRecord>(new Filter("AuditRecordId", _auditId));

            if (records.Any())
            {
	            var ids = records.Select(i => i.SpecialistId).Distinct();
	            var specialists = GlobalObjects.CaaEnvironment.NewLoader
		            .GetObjectListAll<CAASpecialistDTO, Specialist>(new Filter("ItemId", ids),
			            loadChild: true);
            
	            foreach (var rec in records)
	            {
		            rec.CheckList = _checks.FirstOrDefault(i => i.ItemId == rec.CheckListId);;
		            rec.Specialist = specialists.FirstOrDefault(i => i.ItemId == rec.SpecialistId) ?? Specialist.Unknown;
	            }
            }
            
            _initialDocumentArray.AddRange(records);
            

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
            _directivesViewer.ButtonDeleteClick(sender, e);
		}

		#endregion

		#region private void InitListView()

		private void InitListView()
        {
            _directivesViewer = new AuditPelRecordListView();
            _directivesViewer.OperatorId = _operatorId;
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
		private void FilterItems(IEnumerable<AuditPelRecord> initialCollection, ICommonCollection<AuditPelRecord> resultCollection)
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
			var form = new PelItemForm(_auditId, _operatorId, _checks);
			if(form.ShowDialog() == DialogResult.OK)
				AnimatedThreadWorker.RunWorkerAsync();
		}
	}
}
