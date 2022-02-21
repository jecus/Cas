using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
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

namespace CAS.UI.UIControls.PurchaseControls.Quatation
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class RequestOffersListScreen : ScreenControl
	{
		#region Fields
		private CommonFilterCollection _filter = new CommonFilterCollection(typeof(ILogistic));
		private ICommonCollection<RequestForQuotation> _quotatioArray = new CommonCollection<RequestForQuotation>();
		private ICommonCollection<RequestForQuotationRecord> _resultArray = new CommonCollection<RequestForQuotationRecord>();
		private IList<RequestForQuotationRecord> _addedQuatationOrderRecords = new List<RequestForQuotationRecord>();
		private IList<SupplierPriceCustom> _data = new List<SupplierPriceCustom>();

		private readonly BaseEntityObject _parent;
		private RequestOffersListView _directivesViewer;
		

		#endregion

		#region Constructors

		#region private RequestOffersListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		private RequestOffersListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public RequestOffersListScreen(Operator currentOperator) : this()
		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список директив
		///</summary>
		///<param name="currentOperator">Оператор, которому принадлежат директивы</param>
		public RequestOffersListScreen(Operator currentOperator)
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
			
			_directivesViewer.SetItemsArray(_data.ToArray());
			headerControl.PrintButtonEnabled = _directivesViewer.ItemsCount != 0;

			_directivesViewer.Focus();
		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			if (_parent == null) return;
			_quotatioArray.Clear();
			_resultArray.Clear();
			_addedQuatationOrderRecords.Clear();
			_data.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load Quotations");

			try
			{
				_quotatioArray.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<RequestForQuotationDTO, RequestForQuotation>(new Filter("Status", WorkPackageStatus.Opened)));
				var quotaIds = _quotatioArray.Select(i => i.ItemId);

				if (quotaIds.Count() > 0)
				{
					var _quotationCosts =
						GlobalObjects.CasEnvironment.NewLoader.GetObjectList<QuotationCostDTO, QuotationCost>(
							new Filter("QuotationId", quotaIds));
					_addedQuatationOrderRecords =
						GlobalObjects.CasEnvironment.NewLoader
							.GetObjectList<RequestForQuotationRecordDTO, RequestForQuotationRecord>(
								new Filter("ParentPackageId", quotaIds), true);
					var ids = _addedQuatationOrderRecords.Select(i => i.PackageItemId);


					if (ids.Count() > 0)
					{
						var products = GlobalObjects.CasEnvironment.Loader.GetObjectList<Product>(
							new CommonFilter<int>(BaseEntityObject.ItemIdProperty, FilterType.In, ids.ToArray()), true);
						var supplierId = _addedQuatationOrderRecords.SelectMany(i => i.SupplierPrice)
							.Select(i => i.SupplierId);
						var suppliers =
							GlobalObjects.CasEnvironment.NewLoader.GetObjectList<SupplierDTO, Supplier>(new Filter(
								"ItemId",
								supplierId));

						foreach (var record in _addedQuatationOrderRecords.GroupBy(i => i.ParentPackageId))
						{

							var parentInitialId = (int) GlobalObjects.CasEnvironment.Execute(
									$@"select i.ItemId from RequestsForQuotation q
			left join InitialOrders i on i.ItemID = q.ParentID where q.ItemId = {record.Key}").Tables[0]
								.Rows[0][0];
							var initialOrderRecords =
								GlobalObjects.CasEnvironment.NewLoader
									.GetObjectList<InitialOrderRecordDTO, InitialOrderRecord>(
										new Filter("ParentPackageId", parentInitialId));
							var initial = GlobalObjects.CasEnvironment.NewLoader.GetObject<InitialOrderDTO, InitialOrder>(new Filter("ItemId", parentInitialId));


							foreach (var addedInitialOrderRecord in record)
							{
								addedInitialOrderRecord.ParentInitialRecord =
									initialOrderRecords.FirstOrDefault(i =>
										i.ProductId == addedInitialOrderRecord.PackageItemId);
								addedInitialOrderRecord.ParentPackage = _quotatioArray.FirstOrDefault(i =>
									i.ItemId == addedInitialOrderRecord.ParentPackageId);
								if (addedInitialOrderRecord.ParentInitialRecord != null)
									addedInitialOrderRecord.ParentInitialRecord.ParentPackage = initial;
								var product = products.FirstOrDefault(i =>
									i.ItemId == addedInitialOrderRecord.PackageItemId);
								foreach (var relation in product.SupplierRelations)
								{
									var findCost = _quotationCosts.FirstOrDefault(i =>
										i.ProductId == product.ItemId && i.SupplierId == relation.Supplier.ItemId);
									if (findCost != null)
									{
										findCost.SupplierName = relation.Supplier.Name;
										product.QuatationCosts.Add(findCost);
									}
								}

								addedInitialOrderRecord.Product = product;

								foreach (var price in addedInitialOrderRecord.SupplierPrice)
								{
									price.Parent = addedInitialOrderRecord;
									price.Supplier = suppliers.FirstOrDefault(i => i.ItemId == price.SupplierId);


									_data.Add(new SupplierPriceCustom
									{
										Record = addedInitialOrderRecord,
										Price = price,
									});
								}
							}
						}
					}
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
			_directivesViewer = new RequestOffersListView
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
			var form = new CommonFilterForm(_filter, _quotatioArray);

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

			//FilterItems(_quotatioArray, _resultArray);

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
