using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.Entity.Models.DTO.Dictionaries;
using CAS.Entity.Models.DTO.General;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CASTerms;
using Entity.Abstractions.Filters;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Filters;
using SmartCore.Purchase;


namespace CAS.UI.UIControls.PurchaseControls
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class PurchaseStatusListScreen : ScreenControl
	{
		#region Fields
		private CommonFilterCollection _filter = new CommonFilterCollection(typeof(ILogistic));
		private ICommonCollection<PurchaseOrder> _purchaseArray = new CommonCollection<PurchaseOrder>();
		private ICommonCollection<PurchaseRequestRecord> _resultArray = new CommonCollection<PurchaseRequestRecord>();
		private IList<PurchaseRequestRecord> _addedQuatationOrderRecords = new List<PurchaseRequestRecord>();
		
		private readonly BaseEntityObject _parent;
		private PurchaseStatusListView _directivesViewer;		

		#endregion

		#region Constructors

		#region private PurchaseStatusListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		private PurchaseStatusListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public PurchaseStatusListScreen(Operator currentOperator) : this()
		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список директив
		///</summary>
		///<param name="currentOperator">Оператор, которому принадлежат директивы</param>
		public PurchaseStatusListScreen(Operator currentOperator)
			: this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");
			_parent = currentOperator;
			aircraftHeaderControl1.Operator = currentOperator;
			StatusTitle = "Operator Quotations";
			labelTitle.Visible = false;
			InitListView();
		}

		#endregion

		#endregion

		#region Methods
		
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
			_purchaseArray.Clear();
			_resultArray.Clear();
			_addedQuatationOrderRecords.Clear();
			
			AnimatedThreadWorker.ReportProgress(0, "load Quotations");

			try
			{
				_purchaseArray.AddRange(
					GlobalObjects.CasEnvironment.NewLoader.GetObjectList<PurchaseOrderDTO, PurchaseOrder>(
						new Filter("Status", WorkPackageStatus.Published)));
				var orderIds = _purchaseArray.Select(i => i.ItemId);
				if (orderIds.Count() > 0)
				{
					var records = GlobalObjects.CasEnvironment.Loader.GetObjectList<PurchaseRequestRecord>(
						new ICommonFilter[]
						{
							new CommonFilter<int>(PurchaseRequestRecord.ParentPackageIdProperty, FilterType.In,
								orderIds.ToArray())
						});
					var ids = records.Select(s => s.SupplierId).Distinct().ToArray();
					var productIds = records.Select(s => s.PackageItemId).Distinct().ToArray();
					var suppliers = GlobalObjects.CasEnvironment.Loader.GetObjectList<Supplier>(new ICommonFilter[]
					{
						new CommonFilter<int>(BaseEntityObject.ItemIdProperty, SmartCore.Filters.FilterType.In, ids),
					});
					var products = GlobalObjects.CasEnvironment.Loader.GetObjectList<Product>(new ICommonFilter[]
					{
						new CommonFilter<int>(BaseEntityObject.ItemIdProperty, SmartCore.Filters.FilterType.In,
							productIds),
					});

					var _supplierShipper = GlobalObjects.CasEnvironment.Loader.GetObjectList<Supplier>(
						new ICommonFilter[]
							{new CommonFilter<int>(Supplier.SupplierClassProperty, SupplierClass.Shipper.ItemId)});

					var stationIds = _purchaseArray.Select(i => i.StationId);
					var station =
						GlobalObjects.CasEnvironment.NewLoader.GetObjectList<AirportCodeDTO, AirportsCodes>(
							new Filter("ItemId", stationIds));

					foreach (var purchase in _purchaseArray)
					{
						purchase.Station = station.FirstOrDefault(i => i.ItemId == purchase.StationId);
						purchase.ShipCompany =
							_supplierShipper.FirstOrDefault(i => i.ItemId == purchase.ShipCompanyId) ??
							Supplier.Unknown;
					}

					foreach (var order in records.GroupBy(i => i.ParentPackageId))
					{
						var parentInitialId = (int) GlobalObjects.CasEnvironment.Execute(
							$@"select i.ItemId from PurchaseOrders p
			left join RequestsForQuotation q on q.ItemID = p.ParentID
			left join InitialOrders i on i.ItemID = q.ParentID where p.ItemId = {order.Key}").Tables[0].Rows[0][0];
						var initialRecords =
							GlobalObjects.CasEnvironment.NewLoader
								.GetObjectList<InitialOrderRecordDTO, InitialOrderRecord>(new Filter("ParentPackageId",
									parentInitialId));
						var initial =
							GlobalObjects.CasEnvironment.NewLoader.GetObject<InitialOrderDTO, InitialOrder>(
								new Filter("ItemId", parentInitialId));
						foreach (var record in order)
						{
							record.ParentPackage = _purchaseArray.FirstOrDefault(i => i.ItemId == order.Key);
							record.ParentInitialRecord =
								initialRecords.FirstOrDefault(i => i.ProductId == record.PackageItemId);
							if (record.ParentInitialRecord != null)
								record.ParentInitialRecord.ParentPackage = initial;
							record.Product = products.FirstOrDefault(i => i.ItemId == record.PackageItemId);
							record.Supplier = suppliers.FirstOrDefault(i => i.ItemId == record.SupplierId);
						}
					}

					_resultArray.AddRange(records);
				}
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while load Quotations", ex);
			}

			AnimatedThreadWorker.ReportProgress(20, "calculation Quotations");

			AnimatedThreadWorker.ReportProgress(70, "filter Quotations");

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

		#region private void InitListView()

		private void InitListView()
		{
			_directivesViewer = new PurchaseStatusListView
			{
										TabIndex = 2,
										Location = new Point(panel1.Left, panel1.Top),
										Dock = DockStyle.Fill
									};
			//события 
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

			panel1.Controls.Add(_directivesViewer);
		}

		#endregion

		#region private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

		private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
		{
			if (_directivesViewer.SelectedItems.Count > 0)
			{
				headerControl.EditButtonEnabled = true;
			}
			else
			{
				headerControl.EditButtonEnabled = false;
			}
		}

		#endregion

		#region private void ButtonAddNewClick(object sender, EventArgs e)

		private void ButtonAddNewClick(object sender, EventArgs e)
		{
			
		}
		#endregion

		#region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

		private void HeaderQuotationButtonReloadClick(object sender, EventArgs e)
		{
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		private void HeaderQuotationButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			//throw new System.NotImplementedException();
		}
		#endregion

		#region private void ButtonApplyFilterClick(object sender, EventArgs e)

		private void ButtonApplyFilterClick(object sender, EventArgs e)
		{
			var form = new CommonFilterForm(_filter, _purchaseArray);

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

			//FilterItems(_purchaseArray, _resultArray);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}

		#endregion

		#region private void FilterItems(IEnumerable<RequestForQuotation> initialCollection, ICommonCollection<Document> resultCollection)

		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		private void FilterItems(IEnumerable<RequestForQuotation> initialCollection, ICommonCollection<RequestForQuotation> resultCollection)
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
	}
}
