using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.PurchaseControls.Initial;
using CAS.UI.UIControls.PurchaseControls.Purchase;
using CASReports.Builders;
using CASTerms;
using EntityCore.DTO.General;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Setting;
using SmartCore.Filters;
using SmartCore.Purchase;
using Filter = EntityCore.Filter.Filter;

namespace CAS.UI.UIControls.PurchaseControls
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
			
			_directivesViewer.SetItemsArray(_addedQuatationOrderRecords.ToArray());
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

			AnimatedThreadWorker.ReportProgress(0, "load Quotations");

			try
			{
				_quotatioArray.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<RequestForQuotationDTO, RequestForQuotation>(new Filter("Status", WorkPackageStatus.Opened)));
				var quotaIds = _quotatioArray.Select(i => i.ItemId);

				var _quotationCosts = GlobalObjects.CasEnvironment.NewLoader.GetObjectList<QuotationCostDTO, QuotationCost>(new Filter("QuotationId",EntityCore.Attributte.FilterType.In, quotaIds));
				_addedQuatationOrderRecords = GlobalObjects.CasEnvironment.NewLoader.GetObjectList<RequestForQuotationRecordDTO, RequestForQuotationRecord>(new Filter("ParentPackageId", EntityCore.Attributte.FilterType.In, quotaIds));
				var ids = _addedQuatationOrderRecords.Select(i => i.PackageItemId);
				var products = GlobalObjects.CasEnvironment.Loader.GetObjectList<Product>(new CommonFilter<int>(BaseEntityObject.ItemIdProperty, FilterType.In, ids.ToArray()), true);
				var supplierId = _addedQuatationOrderRecords.SelectMany(i => i.SupplierPrice).Select(i => i.SupplierId);
				var suppliers = GlobalObjects.CasEnvironment.NewLoader.GetObjectList<SupplierDTO, Supplier>(new Filter("ItemId", supplierId));

				if (ids.Count() > 0)
				{
					foreach (var addedInitialOrderRecord in _addedQuatationOrderRecords)
					{
						var product = products.FirstOrDefault(i => i.ItemId == addedInitialOrderRecord.PackageItemId);

						foreach (var relation in product.SupplierRelations)
						{
							var findCost = _quotationCosts.FirstOrDefault(i => i.ProductId == product.ItemId && i.SupplierId == relation.Supplier.ItemId);
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
						? "Do you really want to delete Request for quotation record" + _directivesViewer.SelectedItem.ParentPackage.Title + "?"
						: "Do you really want to delete Request for quotations? ", "Confirm delete operation",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if (confirmResult == DialogResult.Yes)
			{
				List<RequestForQuotationRecord> selectedItems = new List<RequestForQuotationRecord>();
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
			var  form = new QuatationOrderFormNew(new RequestForQuotation());
			if (form.ShowDialog() == DialogResult.OK)
			{
				AnimatedThreadWorker.RunWorkerAsync();

				var refe = new ReferenceEventArgs
											  {
												  DisplayerText = form.AddedInitial.Title,
												  TypeOfReflection = ReflectionTypes.DisplayInNew,
												  RequestedEntity = new RequestForQuotationScreen(form.AddedInitial)
											  };
				InvokeDisplayerRequested(refe);    
			}
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
