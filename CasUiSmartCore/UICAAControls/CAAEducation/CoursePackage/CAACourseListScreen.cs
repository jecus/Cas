using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.DTO;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CASTerms;
using Entity.Abstractions;
using Entity.Abstractions.Filters;
using SmartCore.CAA.CAAWP;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Filters;
using Telerik.WinControls.UI;

namespace CAS.UI.UICAAControls.CAAEducation.CoursePackage
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class CAACourseListScreen : ScreenControl
	{
        private readonly int _operatorId;

        #region Fields

		private CommonCollection<CAAWorkPackage> _initialDocumentArray = new CommonCollection<CAAWorkPackage>();
		private CommonCollection<CAAWorkPackage> _resultDocumentArray = new CommonCollection<CAAWorkPackage>();
		private CommonFilterCollection _filter;

		private CAACoursePackageListView _directivesViewer;

		private RadMenuSeparatorItem _toolStripSeparator2;
		private RadMenuItem _toolStripMenuItemOpen;
		private RadMenuItem _toolStripMenuItemEdit;
		private RadMenuItem _toolStripMenuItemPublish;
		private RadMenuItem _toolStripMenuItemClose;

		#endregion


		#region Constructors

		#region public RoutineAuditListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		public CAACourseListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public RoutineAuditListScreen(Operator currentOperator)

		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список директив
		///</summary>
		///<param name="currentOperator">ВС, которому принадлежат директивы</param>>
		public CAACourseListScreen(Operator currentOperator, int operatorId)
			: this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");
            _operatorId = operatorId;
            aircraftHeaderControl1.Operator = currentOperator;
            statusControl.ShowStatus = false;
			labelTitle.Visible = false;

			_filter = new CommonFilterCollection(typeof(CAAWorkPackage));

			InitToolStripMenuItems();
			InitListView();
			UpdateInformation();

			if (GlobalObjects.CaaEnvironment.IdentityUser.CAAUserType == CAAUserType.CAA ||
			    GlobalObjects.CaaEnvironment.IdentityUser.CAAUserType == CAAUserType.Operator)
			{
				_toolStripMenuItemEdit.Enabled = false;
				pictureBox1.Visible = buttonAddNew.Visible  = buttonDeleteSelected.Visible = false;
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
					.GetObjectListAll<CAAWorkPackageDTO, CAAWorkPackage>());
			}
			else
			{
				_initialDocumentArray.AddRange(GlobalObjects.CaaEnvironment.NewLoader
					.GetObjectListAll<CAAWorkPackageDTO, CAAWorkPackage>(new Filter("OperatorId", _operatorId)));
			}
			
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
			_toolStripMenuItemClose = new RadMenuItem();
			_toolStripMenuItemPublish = new RadMenuItem();
			_toolStripSeparator2 = new RadMenuSeparatorItem();
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
            
            // 
            // toolStripMenuItemView
            // 
            _toolStripMenuItemPublish.Text = "Publish";
            _toolStripMenuItemPublish.Click += ToolStripMenuItemPublishClick;
            // 
            // toolStripMenuItemClose
            // 
            _toolStripMenuItemClose.Text = "Close";
            _toolStripMenuItemClose.Click += ToolStripMenuItemCloseClick;
		}
		
        #endregion


        private void ToolStripMenuItemOpenClick(object sender, EventArgs e)
        {
	        if(_directivesViewer.SelectedItem == null)
		        return;
	        
	        var form = new CAAWorkPackageEditorForm(_directivesViewer.SelectedItem);
	        if(form.ShowDialog() == DialogResult.OK)
		        AnimatedThreadWorker.RunWorkerAsync();
        }

        #region private void ToolStripMenuItemOpenClick(object sender, EventArgs e)

		private void ToolStripMenuItemEditClick(object sender, EventArgs e)
		{
			if(_directivesViewer.SelectedItem == null)
				return;
			
			var form = new CAAWorkPackageEditorForm(_directivesViewer.SelectedItem);
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
			_directivesViewer = new CAACoursePackageListView(AnimatedThreadWorker, aircraftHeaderControl1.Operator);
			_directivesViewer.OperatorId = _operatorId;
			_directivesViewer.TabIndex = 2;
			_directivesViewer.Location = new Point(panel1.Left, panel1.Top);
			_directivesViewer.Dock = DockStyle.Fill;
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;
			Controls.Add(_directivesViewer);
			//события 
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

			_directivesViewer.AddMenuItems(_toolStripMenuItemOpen,
				_toolStripMenuItemEdit,
				_toolStripSeparator2,
				_toolStripMenuItemPublish,
				_toolStripMenuItemClose);

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
		
			#region private void ToolStripMenuItemCloseClick(object sender, EventArgs e)

		private void ToolStripMenuItemCloseClick(object sender, EventArgs e)
		{
            foreach (var item in _directivesViewer.SelectedItems)
            {
                if (item.Status == WPStatus.Closed)
                {
					MessageBox.Show($@"This audit {item.Title} is already closed!", (string)new GlobalTermsProvider()["SystemName"],
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button2);
					continue;
                }

                item.Status = WPStatus.Closed;
                item.Settings.ClosingDate = DateTime.Now;
                item.Settings.ClosedBy = GlobalObjects.CaaEnvironment.IdentityUser.ItemId;
                GlobalObjects.CaaEnvironment.NewKeeper.Save(item);
                AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
                AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
                AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

                AnimatedThreadWorker.RunWorkerAsync();
			}

        }

		#endregion


		#region private void ToolStripMenuItemPublishClick(object sender, EventArgs e)
		/// <summary>
		/// Публикует рабочий пакет
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ToolStripMenuItemPublishClick(object sender, EventArgs e)
        {
            foreach (var item in _directivesViewer.SelectedItems)
            {
                var audit = item;
                if (audit.Status != WPStatus.Closed)
                {
	                audit.Status = WPStatus.Published;
                    item.Settings.PublishingDate = DateTime.Now;
                    item.Settings.PublishedBy = GlobalObjects.CaaEnvironment.IdentityUser.ItemId;
					GlobalObjects.CaaEnvironment.NewKeeper.Save(audit);
                }
                else
                {
                    MessageBox.Show($@"This audit {item.Title} is already closed!", (string) new GlobalTermsProvider()["SystemName"],
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button2);
                }
            }

            AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
            AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
            AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

            AnimatedThreadWorker.RunWorkerAsync();
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
			var form = new CAAWorkPackageEditorForm(new CAAWorkPackage(){OperatorId = _operatorId});
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
		private void FilterItems(IEnumerable<CAAWorkPackage> initialCollection, ICommonCollection<CAAWorkPackage> resultCollection)
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
