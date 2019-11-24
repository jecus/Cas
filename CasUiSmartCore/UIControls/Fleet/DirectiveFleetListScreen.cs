using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.ExcelExport;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CAS.UI.UIControls.DirectivesControls;
using CAS.UI.UIControls.FiltersControls;
using CASTerms;
using EntityCore.DTO.General;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Filters;
using Telerik.WinControls.UI;
using TempUIExtentions;
using Point = System.Drawing.Point;

namespace CAS.UI.UIControls.Fleet
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class DirectiveFleetListScreen : ScreenControl
	{
		#region Fields
		private ICommonCollection<Directive> _initialDirectiveArray = new DirectiveCollection();
		private ICommonCollection<Directive> _resultDirectiveArray = new CommonCollection<Directive>();

		private DirectiveFleetListView _directivesViewer;

		private CommonFilterCollection _filter = new CommonFilterCollection(typeof(Directive));

		private RadDropDownMenu _contextMenuStrip;
		private RadMenuItem _toolStripMenuItemOpen;
		private RadMenuItem _toolStripMenuItemDelete;
		private RadMenuItem _toolStripMenuItemShowADFile;
		private RadMenuItem _toolStripMenuItemShowSBFile;
		private RadMenuItem _toolStripMenuItemShowEOFile;
		private RadMenuSeparatorItem _toolStripSeparator1;
		private RadMenuSeparatorItem _toolStripSeparator2;
		private RadMenuSeparatorItem _toolStripSeparator4;
		private AnimatedThreadWorker _worker;
		private ExcelExportProvider _exportProvider;
		private RadMenuItem _toolStripMenuItemChangeToAd;

		#endregion

		#region Constructors

		#region public DirectiveFleetListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		public DirectiveFleetListScreen()
		{
			InitializeComponent();
		}
		#endregion

		public DirectiveFleetListScreen(Operator currentOperator) : this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");
			aircraftHeaderControl1.Operator = currentOperator;
			statusControl.ShowStatus = false;
			labelTitle.Visible = false;

			InitToolStripMenuItems();
			InitListView(new DirectiveFleetListView(DirectiveType.AirworthenessDirectives));
		}


		#endregion

		#region Methods

		#region public override void DisposeScreen()
		public override void DisposeScreen()
		{
			if (AnimatedThreadWorker.IsBusy)
				AnimatedThreadWorker.CancelAsync();

			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.RunWorkerCompleted -= AnimatedThreadWorkerRunWorkerCompleted;

			AnimatedThreadWorker.Dispose();

			_resultDirectiveArray.Clear();
			_resultDirectiveArray = null;

			_initialDirectiveArray.Clear();
			_initialDirectiveArray = null;

			if (_toolStripMenuItemShowADFile != null) _toolStripMenuItemShowADFile.Dispose();
			if (_toolStripMenuItemShowSBFile != null) _toolStripMenuItemShowSBFile.Dispose();
			if (_toolStripMenuItemShowEOFile != null) _toolStripMenuItemShowEOFile.Dispose();
			if (_toolStripMenuItemOpen != null) _toolStripMenuItemOpen.Dispose();
			if (_toolStripMenuItemDelete != null) _toolStripMenuItemDelete.Dispose();
			if (_toolStripSeparator1 != null) _toolStripSeparator1.Dispose();
			if (_toolStripSeparator2 != null) _toolStripSeparator2.Dispose();
			if (_toolStripSeparator4 != null) _toolStripSeparator4.Dispose();
			if (_contextMenuStrip != null) _contextMenuStrip.Dispose();
			if (_directivesViewer != null) _directivesViewer.Dispose();

			Dispose(true);
		}

		#endregion

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)

		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			_directivesViewer.SetItemsArray(_resultDirectiveArray.ToArray());

			var resultList = new List<Directive>();
			var list = _directivesViewer.radGridView1.Rows.Select(i => i).ToList();
			list.Sort(new DirectiveGridViewDataRowInfoComparer(0, -1));

			foreach (var item in list)
				resultList.Add(item.Tag as Directive);

			_directivesViewer.SetItemsArray(resultList.ToArray());

			headerControl.PrintButtonEnabled = _directivesViewer.ItemsCount != 0;
			_directivesViewer.Focus();
		}

		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			_initialDirectiveArray.Clear();
			_resultDirectiveArray.Clear();
			AnimatedThreadWorker.ReportProgress(0, "load directives");

			if (!string.IsNullOrEmpty(TextBoxFilter.Text))
			{
				var dir = new List<Directive>();

				try
				{
					dir.AddRange(GlobalObjects.DirectiveCore.GetDirectivesFromAllAircrafts(DirectiveType.AirworthenessDirectives, TextBoxFilter.Text, TextBoxFilterParagraph.Text));
				}
				catch (Exception ex)
				{
					Program.Provider.Logger.Log("Error while loading directives", ex);
				}


				AnimatedThreadWorker.ReportProgress(40, "filter directives");

				#region Калькуляция состояния директив

				AnimatedThreadWorker.ReportProgress(60, "calculation of directives");

				foreach (Directive pd in dir)
				{
					var aircrraft =
						GlobalObjects.AircraftsCore.GetAircraftById(pd.ParentBaseComponent?.ParentAircraftId ?? -1);

					if (aircrraft != null)
					{
						GlobalObjects.PerformanceCalculator.GetNextPerformance(pd);
						_initialDirectiveArray.Add(pd);
					}
				}

				AnimatedThreadWorker.ReportProgress(70, "filter directives");

				FilterItems(_initialDirectiveArray, _resultDirectiveArray);

				if (AnimatedThreadWorker.CancellationPending)
				{
					e.Cancel = true;
					return;
				}


				if (AnimatedThreadWorker.CancellationPending)
				{
					e.Cancel = true;
					return;
				}
				#endregion

				AnimatedThreadWorker.ReportProgress(100, "Complete");
			}
		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)
		private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)
		{
			_resultDirectiveArray.Clear();

			#region Фильтрация директив
			AnimatedThreadWorker.ReportProgress(50, "filter directives");

			FilterItems(_initialDirectiveArray, _resultDirectiveArray);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}
		#endregion

		#region public override void OnInitCompletion(object sender)
		/// <summary>
		/// Метод, вызывается после добавления содежимого на отображатель(вкладку)
		/// </summary>
		/// <returns></returns>
		public override void OnInitCompletion(object sender)
		{
			AnimatedThreadWorker.RunWorkerAsync();

			base.OnInitCompletion(sender);
		}
		#endregion

		#region private void InitToolStripMenuItems()

		private void InitToolStripMenuItems()
		{
			_contextMenuStrip = new RadDropDownMenu();
			_toolStripMenuItemChangeToAd = new RadMenuItem();
			_toolStripMenuItemOpen = new RadMenuItem();
			_toolStripMenuItemDelete = new RadMenuItem();
			_toolStripMenuItemShowADFile = new RadMenuItem();
			_toolStripMenuItemShowSBFile = new RadMenuItem();
			_toolStripMenuItemShowEOFile = new RadMenuItem();
			_toolStripSeparator1 = new RadMenuSeparatorItem();
			_toolStripSeparator2 = new RadMenuSeparatorItem();
			_toolStripSeparator4 = new RadMenuSeparatorItem();
			// 
			// contextMenuStrip
			// 
			_contextMenuStrip.Name = "_contextMenuStrip";
			_contextMenuStrip.Size = new Size(179, 176);
			// 
			// toolStripMenuItemView
			// 
			_toolStripMenuItemChangeToAd.Text = "Change to AD";
			_toolStripMenuItemChangeToAd.Click += _toolStripMenuItemChangeToAd_Click;
			// 
			// toolStripMenuItemView
			// 
			_toolStripMenuItemOpen.Text = "Open";
			_toolStripMenuItemOpen.Click += ToolStripMenuItemOpenClick;
			// 
			// _toolStripMenuItemShowADFile
			// 
			_toolStripMenuItemShowADFile.Text = "Show AD File";
			_toolStripMenuItemShowADFile.Click += ToolStripMenuItemShowTaskCardClick;
			// 
			// _toolStripMenuItemShowSBFile
			// 
			_toolStripMenuItemShowSBFile.Text = "Show SB File";
			_toolStripMenuItemShowSBFile.Click += ToolStripMenuItemShowTaskCardClick;
			// 
			// _toolStripMenuItemShowEOFile
			// 
			_toolStripMenuItemShowEOFile.Text = "Show EO File";
			_toolStripMenuItemShowEOFile.Click += ToolStripMenuItemShowTaskCardClick;
			// 
			// toolStripMenuItemDelete
			// 
			_toolStripMenuItemDelete.Text = "Delete";
			_toolStripMenuItemDelete.Click += ButtonDeleteClick;


			_contextMenuStrip.Items.Clear();

			_contextMenuStrip.Items.AddRange(
				_toolStripMenuItemOpen,
				_toolStripMenuItemShowADFile,
				_toolStripMenuItemShowSBFile,
				_toolStripMenuItemShowEOFile,
				new RadMenuSeparatorItem(),
				_toolStripSeparator4,
				_toolStripMenuItemDelete
			);
		}

		private void _toolStripMenuItemChangeToAd_Click(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems.Count == 0)
				return;


			foreach (var directive in _directivesViewer.SelectedItems)
				directive.DirectiveType = DirectiveType.AirworthenessDirectives;

			GlobalObjects.CasEnvironment.NewKeeper.BulkUpdate<Directive, DirectiveDTO>(_directivesViewer.SelectedItems.Cast<BaseEntityObject>().ToList());
			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void ToolStripMenuItemOpenClick(object sender, EventArgs e)

		private void ToolStripMenuItemOpenClick(object sender, EventArgs e)
		{
			List<Directive> selected = _directivesViewer.SelectedItems;

			foreach (Directive t in selected)
			{
				ReferenceEventArgs refE = new ReferenceEventArgs();
				string regNumber = "";
				if (t.ParentBaseComponent.BaseComponentType.ItemId == 4)
					regNumber = t.ParentBaseComponent.ToString();
				else
				{
					if (t.ParentBaseComponent.ParentAircraftId > 0)
						regNumber = $"{t.ParentBaseComponent.GetParentAircraftRegNumber()}. {t.ParentBaseComponent}";
				}
				refE.TypeOfReflection = ReflectionTypes.DisplayInNew;
				refE.DisplayerText = regNumber + ". " + t.DirectiveType.CommonName + ". " + t.Title;
				refE.RequestedEntity = new DirectiveScreen(t);
				InvokeDisplayerRequested(refE);
			}
		}

		#endregion

		#region private void ToolStripMenuItemShowTaskCardClick(object sender, EventArgs e)

		private void ToolStripMenuItemShowTaskCardClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems == null ||
				_directivesViewer.SelectedItems.Count == 0) return;

			BaseEntityObject o = _directivesViewer.SelectedItems[0];
			IBaseEntityObject parent;
			if (o is NextPerformance)
			{
				parent = ((NextPerformance)o).Parent;
			}
			else if (o is AbstractPerformanceRecord)
			{
				parent = ((AbstractPerformanceRecord)o).Parent;
			}
			else parent = o;

			Directive dir = null;
			if (parent is Directive)
			{
				dir = (Directive)parent;
			}

			AttachedFile attachedFile = null;
			if (sender == _toolStripMenuItemShowADFile && dir != null)
				attachedFile = dir.ADNoFile;
			if (sender == _toolStripMenuItemShowSBFile && dir != null)
				attachedFile = dir.ServiceBulletinFile;
			if (sender == _toolStripMenuItemShowEOFile && dir != null)
				attachedFile = dir.EngineeringOrderFile;
			if (attachedFile == null)
			{
				MessageBox.Show("Not set required File", (string)new GlobalTermsProvider()["SystemName"],
								MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
								MessageBoxDefaultButton.Button1);
				return;
			}
			try
			{
				string message;
				GlobalObjects.CasEnvironment.OpenFile(attachedFile, out message);
				if (message != "")
				{
					MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
								MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
								MessageBoxDefaultButton.Button1);
					return;
				}
			}
			catch (Exception ex)
			{
				string errorDescriptionSctring =
					string.Format("Error while Open Attached File for {0}, id {1}. \nFileId {2}", dir, dir.ItemId, attachedFile.ItemId);
				Program.Provider.Logger.Log(errorDescriptionSctring, ex);
			}
		}

		#endregion

		#region private void InitListView()

		private void InitListView(DirectiveFleetListView directiveListView)
		{
			_directivesViewer = directiveListView;
			_directivesViewer.TabIndex = 2;
			_directivesViewer.CustomMenu = _contextMenuStrip;
			_directivesViewer.Location = new Point(panel1.Left, panel1.Top);
			_directivesViewer.Dock = DockStyle.Fill;
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;
			Controls.Add(_directivesViewer);
			//события 
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

			_directivesViewer.MenuOpeningAction = () =>
			{
				if (_directivesViewer.SelectedItems.Count <= 0)
				{
					_toolStripMenuItemChangeToAd.Enabled = false;
					_toolStripMenuItemOpen.Enabled = false;
					_toolStripMenuItemShowADFile.Enabled = false;
					_toolStripMenuItemShowSBFile.Enabled = false;
					_toolStripMenuItemShowEOFile.Enabled = false;
					_toolStripMenuItemDelete.Enabled = false;

				}

				if (_directivesViewer.SelectedItems.Count == 1)
				{
					_toolStripMenuItemChangeToAd.Enabled =
						_directivesViewer.SelectedItem.DirectiveType == DirectiveType.SB;

					_toolStripMenuItemOpen.Enabled = true;

					BaseEntityObject o = _directivesViewer.SelectedItems[0];
					IBaseEntityObject parent;
					if (o is NextPerformance)
					{
						parent = ((NextPerformance)o).Parent;
					}
					else if (o is AbstractPerformanceRecord)
					{
						parent = ((AbstractPerformanceRecord)o).Parent;
					}
					else parent = o;

					Directive dir = null;
					if (parent is Directive)
					{
						dir = (Directive)parent;
					}

					if (dir != null)
					{
						_toolStripMenuItemShowEOFile.Enabled = dir.EngineeringOrderFile != null;
						_toolStripMenuItemShowSBFile.Enabled = dir.ServiceBulletinFile != null;
						_toolStripMenuItemShowADFile.Enabled = dir.ADNoFile != null;
					}
				}

				if (_directivesViewer.SelectedItems.Count > 0)
				{
					_toolStripMenuItemOpen.Enabled = true;
					_toolStripMenuItemDelete.Enabled = true;
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

		#region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

		private void HeaderControlButtonReloadClick(object sender, EventArgs e)
		{
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void HeaderControlSaveButtonClick(object sender, System.EventArgs e)
		private void HeaderControlSaveButtonClick(object sender, System.EventArgs e)
		{
			List<Directive> unsaved = _directivesViewer.GetItemsArray().Where(i => i.ItemId <= 0).ToList();

			try
			{
				foreach (Directive directive in unsaved)
				{
					GlobalObjects.DirectiveCore.Save(directive);
				}

				MessageBox.Show("Saving was successful", "Message infomation", MessageBoxButtons.OK,
									 MessageBoxIcon.Information);

				headerControl.ShowSaveButton = unsaved.Count(i => i.ItemId <= 0) > 0;
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while save directive from directives list", ex);
			}
		}
		#endregion

		#region private void ButtonApplyFilterClick(object sender, EventArgs e)

		private void ButtonApplyFilterClick(object sender, EventArgs e)
		{
			CommonFilterForm form = new CommonFilterForm(_filter, _initialDirectiveArray);

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoFilteringWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void ButtonDeleteClick(object sender, EventArgs e)
		private void ButtonDeleteClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems == null) return;

			List<Directive> directives = _directivesViewer.SelectedItems;

			DialogResult confirmResult =
				MessageBox.Show(directives.Count == 1
						? "Do you really want to delete directive " + directives[0].Title + "?"
						: "Do you really want to delete selected directives? ", "Confirm delete operation",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if (confirmResult == DialogResult.Yes)
			{
				_directivesViewer.radGridView1.BeginUpdate();
				GlobalObjects.CasEnvironment.NewKeeper.Delete(directives.OfType<BaseEntityObject>().ToList(), true);

				_directivesViewer.radGridView1.EndUpdate();

				List<Directive> unsaved = _directivesViewer.GetItemsArray().Where(i => i.ItemId <= 0).ToList();

				if (unsaved.Count > 0)
				{
					if (MessageBox.Show("All unsaved data will be lost. Are you sure you want to save data?",
									(string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.YesNo,
									MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
					{
						try
						{
							foreach (Directive directive in unsaved)
							{
								GlobalObjects.DirectiveCore.Save(directive);
							}
							headerControl.ShowSaveButton = unsaved.Count(i => i.ItemId <= 0) > 0;
						}
						catch (Exception ex)
						{
							Program.Provider.Logger.Log("Error while save directive from directives list", ex);
						}
					}
				}
				else headerControl.ShowSaveButton = false;

				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void ButtonImportFromExcelClick(object sender, EventArgs e)

		private void ButtonImportFromExcelClick(object sender, EventArgs e)
		{
			_worker = new AnimatedThreadWorker();
			_worker.DoWork += ExportDirectiveWork;
			_worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
			_worker.RunWorkerAsync();
		}

		private void ExportDirectiveWork(object sender, DoWorkEventArgs e)
		{
			_worker.ReportProgress(0, "load Directive");
			_worker.ReportProgress(0, "Generate file! Please wait....");

			_exportProvider = new ExcelExportProvider();
			_exportProvider.ExportDirective(_resultDirectiveArray.ToList());
		}

		private void Worker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			var sfd = new SaveFileDialog();
			sfd.Filter = ".xlsx Files (*.xlsx)|*.xlsx";

			if (sfd.ShowDialog() == DialogResult.OK)
			{
				_exportProvider.SaveTo(sfd.FileName);
				MessageBox.Show("File was success saved!");
			}

			_exportProvider.Dispose();
		}

		#endregion

		#region private void FilterItems(IEnumerable<Directive> initialCollection, ICommonCollection<Directive> resultCollection)

		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		private void FilterItems(IEnumerable<Directive> initialCollection, ICommonCollection<Directive> resultCollection)
		{
			if (_filter == null || _filter.All(i => i.Values.Length == 0))
			{
				resultCollection.Clear();
				resultCollection.AddRange(initialCollection);
				return;
			}

			resultCollection.Clear();

			foreach (Directive pd in initialCollection)
			{
				//if (pd.MaintenanceCheck != null && pd.MaintenanceCheck.Name == "2C")
				//{
				//    pd.MaintenanceCheck.ToString();
				//}
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

		#endregion

		private void ButtonFilterClick(object sender, EventArgs e)
		{
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.RunWorkerAsync();
		}
	}
}
