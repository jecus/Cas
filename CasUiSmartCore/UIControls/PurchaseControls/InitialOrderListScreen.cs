using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.MaintananceProgram;
using CAS.UI.UIControls.PurchaseControls.Initial;
using CASReports.Builders;
using CASReports.ReportTemplates;
using CASTerms;
using EntityCore.DTO.Dictionaries;
using EntityCore.DTO.General;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Personnel;
using SmartCore.Filters;
using SmartCore.Purchase;
using SmartCore.Queries;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Filter = EntityCore.Filter.Filter;

namespace CAS.UI.UIControls.PurchaseControls
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class InitialOrderListScreen : ScreenControl
	{
		#region Fields
		private CommonFilterCollection _filter = new CommonFilterCollection(typeof(ILogistic));
		private ICommonCollection<InitialOrder> _initialArray = new CommonCollection<InitialOrder>();
		private ICommonCollection<InitialOrder> _resultArray = new CommonCollection<InitialOrder>();
		private readonly BaseEntityObject _parent;
		
		private InitialOrderListView _directivesViewer;

		private RadDropDownMenu _contextMenuStrip;
		private RadMenuItem _toolStripMenuItemEdit;
		private RadMenuItem _toolStripMenuItemReport;
		private RadMenuItem _toolStripMenuItemClose;
		private RadMenuItem _toolStripMenuItemDelete;
		private RadMenuItem _toolStripMenuItemCreateQuatation;
		private RadMenuSeparatorItem _toolStripSeparator1;

		private Filter filter = null;

		#endregion

		#region Constructors

		#region private InitialOrderListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		private InitialOrderListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public InitialOrderListScreen(Aircraft currentAircraft) : this()
		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список директив
		///</summary>
		///<param name="currentAircraft">ВС, которому принадлежат директивы</param>
		public InitialOrderListScreen(Aircraft currentAircraft)
			: this()
		{
			if (currentAircraft == null) 
				throw new ArgumentNullException("currentAircraft");
			_parent = currentAircraft;
			CurrentAircraft = currentAircraft;
			StatusTitle = "Aircraft Initials";
			InitToolStripMenuItems();
			InitListView();
		}

		#endregion

		#region public InitialOrderListScreen(Operator currentOperator) : this()
		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список директив
		///</summary>
		///<param name="currentOperator">Оператор, которому принадлежат директивы</param>
		public InitialOrderListScreen(Operator currentOperator)
			: this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");
			_parent = currentOperator;
			aircraftHeaderControl1.Operator = currentOperator;
			StatusTitle = "Operator Initials";
			labelTitle.Visible = false;
			InitToolStripMenuItems();
			InitListView();
		}

		#endregion

		#endregion

		#region Methods

		#region public override void DisposeScreen()
		public override void DisposeScreen()
		{
			if (AnimatedThreadWorker.IsBusy)
				AnimatedThreadWorker.CancelAsync();
			AnimatedThreadWorker.Dispose();

			_initialArray.Clear();
			_initialArray = null;

			if (_toolStripMenuItemCreateQuatation != null) _toolStripMenuItemCreateQuatation.Dispose();
			if (_toolStripMenuItemEdit != null) _toolStripMenuItemEdit.Dispose();
			if (_toolStripMenuItemClose != null) _toolStripMenuItemClose.Dispose();
			if (_toolStripMenuItemDelete != null) _toolStripMenuItemDelete.Dispose();
			if (_toolStripSeparator1 != null) _toolStripSeparator1.Dispose();
			if (_contextMenuStrip != null) _contextMenuStrip.Dispose();
			if (_directivesViewer != null) _directivesViewer.Dispose();

			Dispose(true);
		}

		#endregion

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (CurrentAircraft != null)
			{
				labelTitle.Text = "Date as of: " +
					SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today) + " Aircraft TSN/CSN: " +
					GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(CurrentAircraft);
			}
			else
			{
				labelTitle.Text = "Date as of: " + SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today);
			}
			
			_directivesViewer.SetItemsArray(_resultArray.ToArray());
			headerControl.PrintButtonEnabled = _directivesViewer.ItemsCount != 0;

			_directivesViewer.Focus();
		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			if (_parent == null) return;
			_initialArray.Clear();
			_resultArray.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load Quotations");

			try
			{
				if(filter != null)
					_initialArray.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<InitialOrderDTO, InitialOrder>(filter));
				else _initialArray.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<InitialOrderDTO, InitialOrder>());
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while load Quotations", ex);
			}

			AnimatedThreadWorker.ReportProgress(20, "calculation Quotations");

			AnimatedThreadWorker.ReportProgress(70, "filter Quotations");
			FilterItems(_initialArray, _resultArray);
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
			_toolStripMenuItemCreateQuatation = new RadMenuItem();
			_toolStripMenuItemClose = new RadMenuItem();
			_toolStripMenuItemDelete = new RadMenuItem();
			_toolStripSeparator1 = new RadMenuSeparatorItem();
			_toolStripMenuItemEdit = new RadMenuItem();
			_toolStripMenuItemReport = new RadMenuItem();
			// 
			// contextMenuStrip
			// 
			_contextMenuStrip.Name = "_contextMenuStrip";
			_contextMenuStrip.Size = new Size(179, 176);

			_toolStripMenuItemEdit.Text = "Edit";
			_toolStripMenuItemEdit.Click += ToolStripMenuItemEditClick;


			_toolStripMenuItemReport.Text = "Show Report";
			_toolStripMenuItemReport.Click += _toolStripMenuItemReport_Click; ;

			_toolStripMenuItemCreateQuatation.Text = "Publish";
			_toolStripMenuItemCreateQuatation.Click += _toolStripMenuItemCreateQuatation_Click; ;
			// 
			// toolStripMenuItemClose
			// 
			_toolStripMenuItemClose.Text = "Close";
			_toolStripMenuItemClose.Click += ToolStripMenuItemCloseClick;
			// 
			// toolStripMenuItemDelete
			// 
			_toolStripMenuItemDelete.Text = "Delete";
			_toolStripMenuItemDelete.Click += ToolStripMenuItemDeleteClick;

			_contextMenuStrip.Items.Clear();
			_contextMenuStrip.Items.AddRange(new RadItem[]
												{
													_toolStripMenuItemCreateQuatation,
													_toolStripMenuItemClose,
													_toolStripSeparator1,
													_toolStripMenuItemReport,
													_toolStripSeparator1,
													_toolStripMenuItemEdit,
													_toolStripSeparator1,
													_toolStripMenuItemDelete

												});
		}


		#endregion


		private void _toolStripMenuItemReport_Click(object sender, EventArgs e)
		{
			if(_directivesViewer.SelectedItem == null)
				return;;

			var records = new List<InitialOrderRecord>();
			records.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<InitialOrderRecordDTO, InitialOrderRecord>(new Filter("ParentPackageId", _directivesViewer.SelectedItem.ItemId)));
			var ids = records.Select(i => i.ProductId);
			var products = GlobalObjects.CasEnvironment.Loader.GetObjectList<Product>(new CommonFilter<int>(BaseEntityObject.ItemIdProperty, FilterType.In, ids.ToArray()), true);

			var destinations = new List<BaseEntityObject>();
			destinations.AddRange(GlobalObjects.AircraftsCore.GetAllAircrafts().ToArray());
			destinations.AddRange(GlobalObjects.CasEnvironment.Stores.GetValidEntries());
			destinations.AddRange(GlobalObjects.CasEnvironment.Hangars.GetValidEntries());

			var airportCodeIds = records.Select(i => i.AirportCodeId);
			var codes = GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<AirportCodeDTO, AirportsCodes>(new Filter("ItemId", airportCodeIds));

			ids = new List<int>() { _directivesViewer.SelectedItem.AuthorId, _directivesViewer.SelectedItem.PublishedById};
			var personnel = GlobalObjects.CasEnvironment.Loader.GetObjectList<Specialist>(new CommonFilter<int>(BaseEntityObject.ItemIdProperty, FilterType.In, ids.ToArray()));

			foreach (var record in records)
			{
				record.Product = products.FirstOrDefault(i => i.ItemId == record.ProductId);
				record.DestinationObject = destinations.FirstOrDefault(i =>
					i.ItemId == record.DestinationObjectId &&
					record.DestinationObjectType.ItemId == i.SmartCoreObjectType.ItemId);
				record.AirportCode = codes.FirstOrDefault(i => i.ItemId == record.AirportCodeId);
			}

			var builder = new InitialOrderReportBuilder(GlobalObjects.CasEnvironment.Operators[0], records, _directivesViewer.SelectedItem)
			{
				AuthorSign = personnel.FirstOrDefault(i => i.ItemId == _directivesViewer.SelectedItem.AuthorId)?.Sign,
				PublishSign = personnel.FirstOrDefault(i => i.ItemId == _directivesViewer.SelectedItem.PublishedById)?.Sign,
			};
			var refArgs = new ReferenceEventArgs();
			refArgs.TypeOfReflection = ReflectionTypes.DisplayInNew;
			refArgs.DisplayerText = "initialOrderReport";
			refArgs.RequestedEntity = new ReportScreen(builder);
			Program.MainDispatcher.DisplayerRequest(refArgs);

		}


		#region private void _toolStripMenuItemCreateQuatation_Click(object sender, EventArgs e)

		private void _toolStripMenuItemCreateQuatation_Click(object sender, EventArgs e)
		{
			try
			{
				var initial = _directivesViewer.SelectedItem;
				var quatation = new RequestForQuotation
				{
					Parent =  initial,
					ParentType = initial.SmartCoreObjectType,
					Title = initial.Title,
					OpeningDate = DateTime.Now,
					Author = initial.Author,
					Remarks = initial.Remarks,
					Number = initial.Number,
				};

				GlobalObjects.CasEnvironment.NewKeeper.Save(quatation);

				var initialRecords = GlobalObjects.CasEnvironment.NewLoader.GetObjectList<InitialOrderRecordDTO, InitialOrderRecord>(new Filter("ParentPackageId", initial.ItemId));
				var ids = initialRecords.Select(i => i.ProductId);
				if (ids.Count() > 0)
				{
					var product = GlobalObjects.CasEnvironment.NewLoader.GetObjectList<AccessoryDescriptionDTO, Product>(new Filter("ItemId", ids));
					foreach (var addedInitialOrderRecord in initialRecords)
						addedInitialOrderRecord.Product = product.FirstOrDefault(i => i.ItemId == addedInitialOrderRecord.ProductId);
				}

				foreach (var record in initialRecords)
				{
					var newquatationRecord = new RequestForQuotationRecord(quatation.ItemId, record.Product, record.Quantity);
					newquatationRecord.Priority = record.Priority;
					newquatationRecord.Measure = record.Measure;
					newquatationRecord.DeferredCategory = record.DeferredCategory;
					newquatationRecord.CostCondition = record.CostCondition;
					newquatationRecord.DestinationObjectType = record.DestinationObjectType;
					newquatationRecord.DestinationObjectId = record.DestinationObjectId;
					newquatationRecord.InitialReason = record.InitialReason;
					newquatationRecord.Remarks = record.Remarks;
					newquatationRecord.LifeLimit = new Lifelength(record.LifeLimit);
					newquatationRecord.LifeLimitNotify = new Lifelength(record.LifeLimitNotify);

					GlobalObjects.CasEnvironment.Keeper.Save(newquatationRecord);
				}
				MessageBox.Show("Create quatation successful", "Message infomation", MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				initial.Status = WorkPackageStatus.Published;
				initial.PublishingDate = DateTime.Now;
				initial.PublishedByUser = GlobalObjects.CasEnvironment.IdentityUser.ToString();
				initial.PublishedById = GlobalObjects.CasEnvironment.IdentityUser.ItemId;
				GlobalObjects.CasEnvironment.NewKeeper.Save(initial);

				var form = new QuatationOrderFormNew(quatation);
				form.ShowDialog();
				AnimatedThreadWorker.RunWorkerAsync();
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while saving data", ex);
				throw;
			}

			
		}

		#endregion

		#region private void ToolStripMenuItemDeleteClick(object sender, EventArgs e)
		//Удаляет рабочий пакет
		private void ToolStripMenuItemDeleteClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems.Count == 1)
			{
				GlobalObjects.CasEnvironment.Manipulator.Delete(_directivesViewer.SelectedItem);
			}
			else
			{
				foreach (InitialOrder rfq in _directivesViewer.SelectedItems)
				{
					GlobalObjects.CasEnvironment.Manipulator.Delete(rfq);
				}
			}
			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void ToolStripMenuItemCloseClick(object sender, EventArgs e)

		private void ToolStripMenuItemCloseClick(object sender, EventArgs e)
		{
			var selected = _directivesViewer.SelectedItems.ToArray();

			try
			{
				foreach (var rfq in selected)
				{
					if (rfq.Status == WorkPackageStatus.Closed)
					{
						MessageBox.Show("Initional Order " + rfq.Title + " is already closed.",
							(string) new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK,
							MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
						continue;
					}

					rfq.Status = WorkPackageStatus.Closed;
					rfq.ClosingDate = DateTime.Now;
					rfq.CloseByUser = GlobalObjects.CasEnvironment.IdentityUser.ToString();
					rfq.ClosedById = GlobalObjects.CasEnvironment.IdentityUser.ItemId;
					GlobalObjects.CasEnvironment.NewKeeper.Save(rfq);

					//var initial = _directivesViewer.SelectedItem;
					//      var quatation = new RequestForQuotation
					//      {
					//       Parent = initial,
					//       ParentType = initial.SmartCoreObjectType,
					//       Title = initial.Title,
					//       Description = initial.Description,
					//       OpeningDate = initial.OpeningDate,
					//       Author = initial.Author,
					//       Remarks = initial.Remarks,
					//      };

					//      GlobalObjects.CasEnvironment.NewKeeper.Save(quatation);

					//      var initialRecords =
					//       GlobalObjects.CasEnvironment.NewLoader.GetObjectList<InitialOrderRecordDTO, InitialOrderRecord>(
					//        new Filter("ParentPackageId", initial.ItemId));
					//      var ids = initialRecords.Select(i => i.ProductId);
					//      if (ids.Count() > 0)
					//      {
					//       var product =
					//        GlobalObjects.CasEnvironment.NewLoader.GetObjectList<AccessoryDescriptionDTO, Product>(
					//	        new Filter("ItemId", ids));
					//       foreach (var addedInitialOrderRecord in initialRecords)
					//        addedInitialOrderRecord.Product =
					//	        product.FirstOrDefault(i => i.ItemId == addedInitialOrderRecord.ProductId);
					//      }

					//      foreach (var record in initialRecords)
					//      {
					//       var newquatationRecord =
					//        new RequestForQuotationRecord(quatation.ItemId, record.Product, record.Quantity);
					//       newquatationRecord.Priority = record.Priority;
					//       newquatationRecord.Measure = record.Measure;
					//       newquatationRecord.DeferredCategory = record.DeferredCategory;
					//       newquatationRecord.CostCondition = record.CostCondition;
					//       newquatationRecord.DestinationObjectType = record.DestinationObjectType;
					//       newquatationRecord.DestinationObjectId = record.DestinationObjectId;
					//       newquatationRecord.InitialReason = record.InitialReason;
					//       newquatationRecord.Remarks = record.Remarks;
					//       newquatationRecord.LifeLimit = new Lifelength(record.LifeLimit);
					//       newquatationRecord.LifeLimitNotify = new Lifelength(record.LifeLimitNotify);

					//       GlobalObjects.CasEnvironment.Keeper.Save(newquatationRecord);
					//      }
				}
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while saving data", ex);
				throw;
			}

			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void ToolStripMenuItemEditClick(object sender, EventArgs e)

		private void ToolStripMenuItemEditClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems.Count != 1) return;

			var editForm = new InitialOrderFormNew(_directivesViewer.SelectedItems[0]);
			if(editForm.ShowDialog() == DialogResult.OK)
				AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void InitListView()

		private void InitListView()
		{
			_directivesViewer = new InitialOrderListView()
									{
										CustomMenu = _contextMenuStrip,
										TabIndex = 2,
										Location = new Point(panel1.Left, panel1.Top),
										Dock = DockStyle.Fill
									};
			//события 
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

			_directivesViewer.MenuOpeningAction = () =>
			{
				if (_directivesViewer.SelectedItems.Count <= 0)
					return;
				else if (_directivesViewer.SelectedItems.Count == 1)
				{
					InitialOrder wp = _directivesViewer.SelectedItem;
					if (wp.Status == WorkPackageStatus.Closed || wp.Status == WorkPackageStatus.Opened)
					{
						_toolStripMenuItemClose.Enabled = false;
					}
					else if (wp.Status == WorkPackageStatus.Published)
					{
						_toolStripMenuItemClose.Enabled = true;
					}
					else
					{
						_toolStripMenuItemClose.Enabled = true;
					}

					_toolStripMenuItemCreateQuatation.Enabled = wp.Status == WorkPackageStatus.Opened;
				}
				else
				{
					_toolStripMenuItemCreateQuatation.Enabled = false;
					_toolStripMenuItemClose.Enabled = true;
				}
			};


			panel1.Controls.Add(_directivesViewer);
		}

		#endregion

		#region private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

		private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
		{
			if (_directivesViewer.SelectedItems.Count > 0)
			{
				buttonDeleteSelected.Enabled = true;
				headerControl.EditButtonEnabled = true;
			}
			else
			{
				headerControl.EditButtonEnabled = false;
				buttonDeleteSelected.Enabled = false;
			}
		}

		#endregion

		#region private void ButtonDeleteClick(object sender, EventArgs e)
		private void ButtonDeleteClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems == null) return;

			DialogResult confirmResult =
				MessageBox.Show(
					_directivesViewer.SelectedItem != null
						? "Do you really want to delete Initial Order " + _directivesViewer.SelectedItem.Title + "?"
						: "Do you really want to delete Initial Orders? ", "Confirm delete operation",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if (confirmResult == DialogResult.Yes)
			{
				List<InitialOrder> selectedItems = new List<InitialOrder>();
				selectedItems.AddRange(_directivesViewer.SelectedItems.ToArray());
				GlobalObjects.CasEnvironment.NewKeeper.Delete(selectedItems.OfType<BaseEntityObject>().ToList(), true);
				AnimatedThreadWorker.RunWorkerAsync();
			}
			else
			{
				MessageBox.Show("Failed to delete directive: Parent container is invalid", "Operation failed",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		#region private void ButtonAddNewClick(object sender, EventArgs e)

		private void ButtonAddNewClick(object sender, EventArgs e)
		{
			var form = new InitialOrderFormNew(new InitialOrder(){ParentId = CurrentParent.ItemId, ParentType = CurrentParent.SmartCoreObjectType});
			if(form.ShowDialog() == DialogResult.OK)
				AnimatedThreadWorker.RunWorkerAsync(); 
		}
		#endregion

		#region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

		private void HeaderControlButtonReloadClick(object sender, EventArgs e)
		{
			filter = null;
			TextBoxFilter.Clear();

			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			//throw new System.NotImplementedException();
		}
		#endregion

		#region private void ButtonApplyFilterClick(object sender, EventArgs e)

		private void ButtonApplyFilterClick(object sender, EventArgs e)
		{
			var form = new CommonFilterForm(_filter, _initialArray);

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoFilteringWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)

		private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)
		{
			_resultArray.Clear();

			#region Фильтрация директив
			AnimatedThreadWorker.ReportProgress(50, "filter directives");

			FilterItems(_initialArray, _resultArray);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}

		#endregion

		#region private void FilterItems(IEnumerable<InitialOrder> initialCollection, ICommonCollection<Document> resultCollection)

		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		private void FilterItems(IEnumerable<InitialOrder> initialCollection, ICommonCollection<InitialOrder> resultCollection)
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

		#endregion


		private void ButtonFilterClick(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(TextBoxFilter.Text))
			{
				filter = null;
				AnimatedThreadWorker.RunWorkerAsync();
				return;
			}
			var res = GlobalObjects.CasEnvironment.Execute(OrdersQueries.InitialSearch(TextBoxFilter.Text));
			var ids = new List<int>();
			foreach (DataRow dRow in res.Tables[0].Rows)
				ids.Add(int.Parse(dRow[0].ToString()));

			filter = new Filter("ItemId", ids);
			AnimatedThreadWorker.RunWorkerAsync();
		}
	}
}
