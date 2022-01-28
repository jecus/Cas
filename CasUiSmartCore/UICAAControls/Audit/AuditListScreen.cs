using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using SmartCore.CAA;
using SmartCore.CAA.Audit;
using SmartCore.CAA.Check;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Filters;
using Telerik.WinControls.UI;

namespace CAS.UI.UICAAControls.Audit
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class AuditListScreen : ScreenControl
	{
		#region Fields

		private CommonCollection<CAAAudit> _initialDocumentArray = new CommonCollection<CAAAudit>();
		private CommonCollection<CAAAudit> _resultDocumentArray = new CommonCollection<CAAAudit>();
		private CommonFilterCollection _filter;

		private AuditListView _directivesViewer;

		private RadMenuItem _toolStripMenuItemOpen;
		private RadMenuItem _toolStripMenuItemEdit;
		private RadMenuItem _toolStripMenuItemHighlight;
		private RadMenuSeparatorItem _toolStripSeparator1;

        private RadMenuSeparatorItem _toolStripSeparator2;
		private RadMenuItem _toolStripMenuItemPublish;
        private RadMenuItem _toolStripMenuItemClose;

		#endregion


		#region Constructors

		#region public RoutineAuditListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		public AuditListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public RoutineAuditListScreen(Operator currentOperator)

		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список директив
		///</summary>
		///<param name="currentOperator">ВС, которому принадлежат директивы</param>>
		public AuditListScreen(Operator currentOperator)
			: this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");
			aircraftHeaderControl1.Operator = currentOperator;
            statusControl.ShowStatus = false;
			labelTitle.Visible = false;

			_filter = new CommonFilterCollection(typeof(IAuditFilterParams));

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

			_initialDocumentArray.AddRange(GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<CAAAuditDTO, CAAAudit>(loadChild:true));


            var ds = GlobalObjects.CaaEnvironment.NewLoader.Execute(@"select a.AuditId, Sum(a.MH) from dbo.AuditRecords ar
cross apply
(
	select ar.AuditId, rar.MH from dbo.RoutineAuditRecords ra
	cross apply
	(
		select cast(JSON_VALUE(SettingsJSON, '$.ManHours') as float) as MH 
		from dbo.CheckList 
		where ra.CheckListId = ItemId and IsDeleted = 0
	) rar
	where ar.RoutineAuditId = ra.RoutineAuditId and ra.IsDeleted = 0
) a
where ar.IsDeleted = 0 
group by a.AuditId
");

            var dt = ds.Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                var id = (int)dr[0];
                var find = _initialDocumentArray.FirstOrDefault(i => i.ItemId == id);

                if (find != null && !string.IsNullOrEmpty(dr[1].ToString()))
                    find.MH = Convert.ToDouble(dr[1].ToString());
            }

			foreach (var audit in _initialDocumentArray)
            {
                audit.Operator =  GlobalObjects.CaaEnvironment
                    .AllOperators
                    .FirstOrDefault(i => i.ItemId == audit.Settings.OperatorId) ?? AllOperators.Unknown;
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
			_toolStripMenuItemHighlight = new RadMenuItem();
            _toolStripMenuItemClose = new RadMenuItem();
            _toolStripMenuItemPublish = new RadMenuItem();
			_toolStripSeparator1 = new RadMenuSeparatorItem();
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
			// toolStripMenuItemHighlight
			// 
			_toolStripMenuItemHighlight.Text = "Highlight";


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


		#region private void ToolStripMenuItemCloseClick(object sender, EventArgs e)

		private void ToolStripMenuItemCloseClick(object sender, EventArgs e)
		{
            foreach (var item in _directivesViewer.SelectedItems)
            {
                if (item.Settings.Status == RoutineStatus.Closed)
                {
					MessageBox.Show($@"This audit {item.AuditNumber} is already closed!", (string)new GlobalTermsProvider()["SystemName"],
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button2);
					continue;
                }

                item.Settings.Status = RoutineStatus.Closed;
                item.Settings.ClosingDate = DateTime.Now;
                item.Settings.ClosedId = GlobalObjects.CaaEnvironment.IdentityUser.ItemId;
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
                if (audit.Settings.Status != RoutineStatus.Closed)
                {
                    audit.Settings.Status = RoutineStatus.Published;
                    item.Settings.PublishingDate = DateTime.Now;
                    item.Settings.PublishedId = GlobalObjects.CaaEnvironment.IdentityUser.ItemId;
					GlobalObjects.CaaEnvironment.NewKeeper.Save(audit);
                }
                else
                {
                    MessageBox.Show($@"This audit {item.AuditNumber} is already closed!", (string) new GlobalTermsProvider()["SystemName"],
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button2);
					continue;

                }
            }

            AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
            AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
            AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

            AnimatedThreadWorker.RunWorkerAsync();
        }

        #endregion


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
			if (_directivesViewer.SelectedItem != null)
            {
                var refE = new ReferenceEventArgs();
                var dp = new DisplayerParams()
                {
                    Page = new CheckListsScreen(GlobalObjects.CaaEnvironment.Operators.FirstOrDefault(), null, _directivesViewer.SelectedItem.ItemId),
                    TypeOfReflection = ReflectionTypes.DisplayInNew,
                    PageCaption = $"Audit: {_directivesViewer.SelectedItem.AuditNumber}",
                    DisplayerType = DisplayerType.Screen
                };
                refE.SetParameters(dp);
                InvokeDisplayerRequested(refE);
            }
		}

		#endregion

        private void ToolStripMenuItemEditClick(object sender, EventArgs e)
        {
            var form = new EditAuditForm(_directivesViewer.SelectedItem.ItemId);
            if (form.ShowDialog() == DialogResult.OK)
                AnimatedThreadWorker.RunWorkerAsync();
        }

		#region private void ButtonDeleteClick(object sender, EventArgs e)
		private void ButtonDeleteClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems == null ||
				_directivesViewer.SelectedItems.Count == 0) return;

			string typeName = nameof(CheckLists);

			DialogResult confirmResult =
				MessageBox.Show(_directivesViewer.SelectedItems.Count == 1
						? "Do you really want to delete " + typeName + " " + _directivesViewer.SelectedItems[0] + "?"
						: "Do you really want to delete selected " + typeName + "s?", "Confirm delete operation",
					MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if (confirmResult == DialogResult.Yes)
			{
				_directivesViewer.radGridView1.BeginUpdate();
				GlobalObjects.NewKeeper.Delete(_directivesViewer.SelectedItems.OfType<BaseEntityObject>().ToList());

                foreach (var audit in _directivesViewer.SelectedItems)
                {
                    GlobalObjects.CaaEnvironment.NewLoader.Execute(
                        $"update dbo.AuditRecords set IsDeleted = 1 where AuditId = {audit.ItemId}");
                }
                

				_directivesViewer.radGridView1.EndUpdate();
				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void InitListView()

		private void InitListView()
		{
			_directivesViewer = new AuditListView(AnimatedThreadWorker);
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
				_toolStripMenuItemClose,
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
            var form = new AuditForm(new CAAAudit()
            {
				Settings = new CAAAuditSettings()
                {
					CreateDate = DateTime.Now,
					AuthorId = GlobalObjects.CaaEnvironment.IdentityUser.ItemId
                }
            });
			if(form.ShowDialog() == DialogResult.OK)
				AnimatedThreadWorker.RunWorkerAsync();
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
		private void FilterItems(IEnumerable<CAAAudit> initialCollection, ICommonCollection<CAAAudit> resultCollection)
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
