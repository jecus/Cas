using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.DTO;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UICAAControls.CheckList;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CASTerms;
using Entity.Abstractions.Filters;
using SmartCore.CAA.StandartManual;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Filters;
using Telerik.WinControls.UI;

namespace CAS.UI.UICAAControls.StandartManual
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class StandartManualListScreen : ScreenControl
	{
        private readonly int _operatorId;

        #region Fields

		private CommonCollection<SmartCore.CAA.StandartManual.StandartManual> _initialDocumentArray = new CommonCollection<SmartCore.CAA.StandartManual.StandartManual>();
		private CommonCollection<SmartCore.CAA.StandartManual.StandartManual> _resultDocumentArray = new CommonCollection<SmartCore.CAA.StandartManual.StandartManual>();
		private CommonFilterCollection _filter;

		private StandartManualListView _directivesViewer;

		private RadMenuItem _toolStripMenuItemOpen;
		private RadMenuItem _toolStripMenuItemEdit;

		#endregion


		#region Constructors

		#region public RoutineAuditListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		public StandartManualListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public RoutineAuditListScreen(Operator currentOperator)

		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список директив
		///</summary>
		///<param name="currentOperator">ВС, которому принадлежат директивы</param>>
		public StandartManualListScreen(Operator currentOperator, int operatorId, bool isEditable = true)
			: this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");
            _operatorId = operatorId;
            aircraftHeaderControl1.Operator = currentOperator;
            statusControl.ShowStatus = false;
			labelTitle.Visible = false;

			_filter = new CommonFilterCollection(typeof(IStandartManualFilterParams));

			InitToolStripMenuItems();
			InitListView();
			UpdateInformation();

			if (!isEditable)
			{
				_toolStripMenuItemEdit.Enabled = false;
				pictureBox1.Visible = pictureBox2.Visible = buttonAddNew.Visible = buttonApplyFilter.Visible = buttonDeleteSelected.Visible = isEditable;
			}

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


			if (_operatorId == -1)
			{
				_initialDocumentArray.AddRange(GlobalObjects.CaaEnvironment.NewLoader
					.GetObjectListAll<StandartManualDTO, SmartCore.CAA.StandartManual.StandartManual>());
			}
			else
			{
				_initialDocumentArray.AddRange(GlobalObjects.CaaEnvironment.NewLoader
					.GetObjectListAll<StandartManualDTO, SmartCore.CAA.StandartManual.StandartManual>(new Filter("OperatorId", _operatorId)));
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
			_toolStripMenuItemEdit = new RadMenuItem();
			// 
            // toolStripMenuItemView
            // 
            _toolStripMenuItemOpen.Text = "Open";
            _toolStripMenuItemOpen.Click += ToolStripMenuItemOpenClick;
			// 
			// toolStripMenuItemView
			// 
            _toolStripMenuItemEdit.Text = "Edit";
            _toolStripMenuItemEdit.Click += ToolStripMenuItemEditClick;
		}
		
        #endregion


        private void ToolStripMenuItemOpenClick(object sender, EventArgs e)
        {
	        if (_directivesViewer.SelectedItem != null)
	        {
		        var refE = new ReferenceEventArgs();
		        var dp = new DisplayerParams()
		        {
			        Page = new CheckListsScreen(GlobalObjects.CaaEnvironment.Operators.FirstOrDefault(), _directivesViewer.SelectedItem.ItemId, _directivesViewer.SelectedItem),
			        TypeOfReflection = ReflectionTypes.DisplayInNew,
			        PageCaption = $"Check List: {_directivesViewer.SelectedItem.ProgramType}",
			        DisplayerType = DisplayerType.Screen
		        };
		        refE.SetParameters(dp);
		        InvokeDisplayerRequested(refE);
	        }
        }

        #region private void ToolStripMenuItemOpenClick(object sender, EventArgs e)

		private void ToolStripMenuItemEditClick(object sender, EventArgs e)
		{
			if(_directivesViewer.SelectedItem == null)
				return;
			
			var form = new StandartManualForm(_directivesViewer.SelectedItem);
			if(form.ShowDialog() == DialogResult.OK)
				AnimatedThreadWorker.RunWorkerAsync();
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
			_directivesViewer = new StandartManualListView(AnimatedThreadWorker);
			_directivesViewer.OperatorId = _operatorId;
			_directivesViewer.TabIndex = 2;
			_directivesViewer.Location = new Point(panel1.Left, panel1.Top);
			_directivesViewer.Dock = DockStyle.Fill;
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;
			Controls.Add(_directivesViewer);
			//события 
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

			_directivesViewer.AddMenuItems(_toolStripMenuItemOpen,
				_toolStripMenuItemEdit);

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
			var form = new StandartManualForm(new SmartCore.CAA.StandartManual.StandartManual{OperatorId = _operatorId});
			if(form.ShowDialog() == DialogResult.OK)
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
		private void FilterItems(IEnumerable<SmartCore.CAA.StandartManual.StandartManual> initialCollection, ICommonCollection<SmartCore.CAA.StandartManual.StandartManual> resultCollection)
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

    }
}
