using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using EFCore.DTO.General;
using EFCore.Filter;
using MetroFramework.Forms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Filters;
using SmartCore.Purchase;
using FilterType = EFCore.Attributte.FilterType;

namespace CAS.UI.UIControls.PurchaseControls.Purchase
{
    public partial class CreatePurchaseOrderForm : MetroForm
    {
	    private readonly RequestForQuotation _quotation;
		private List<SupplierPrice> _prices = new List<SupplierPrice>();

	    #region Fields



		#endregion


		#region Constructor

		public CreatePurchaseOrderForm()
	    {
		    InitializeComponent();
		}

		public CreatePurchaseOrderForm(RequestForQuotation quotation):this()
		{
			_quotation = quotation;
			Task.Run(() => DoWork())
				.ContinueWith(task => Completed(), TaskScheduler.FromCurrentSynchronizationContext());
		}

		#endregion

		#region private void Completed()

		private void Completed()
		{
			quatationSupplierPriceListView1.SetItemsArray(_prices.ToArray());
			UpdateControls();
		}

		#endregion

		#region private void DoWork()

		private void DoWork()
		{
			_prices.Clear();

			var records = GlobalObjects.CasEnvironment.NewLoader.GetObjectList<RequestForQuotationRecordDTO, RequestForQuotationRecord>(new Filter("ParentPackageId", _quotation.ItemId));
			var ids = records.SelectMany(i => i.SupplierPrice).Select(s => s.SupplierId).Distinct().ToArray();
			var productIds = records.Select(s => s.PackageItemId).Distinct().ToArray();
			var suppliers = GlobalObjects.CasEnvironment.Loader.GetObjectList<Supplier>(new ICommonFilter[]{new CommonFilter<int>(BaseEntityObject.ItemIdProperty, SmartCore.Filters.FilterType.In, ids), });
			var products = GlobalObjects.CasEnvironment.Loader.GetObjectList<Product>(new ICommonFilter[]{new CommonFilter<int>(BaseEntityObject.ItemIdProperty, SmartCore.Filters.FilterType.In, productIds), });

			foreach (var record in records)
			{
				record.Product = products.FirstOrDefault(i => i.ItemId == record.PackageItemId);
				foreach (var price in record.SupplierPrice)
				{
					price.Supplier = suppliers.FirstOrDefault(i => i.ItemId == price.SupplierId);
					price.Parent = record;
				}
			}

			_prices.AddRange(records.SelectMany(i => i.SupplierPrice));
		}

		#endregion

		private void UpdateControls()
		{
			comboBoxMeasure.Items.Clear();
			comboBoxMeasure.Items.AddRange(Measure.GetByCategories(new[] { MeasureCategory.Mass, MeasureCategory.EconomicEntity }));

			comboBoxCondition.Items.Clear();
			comboBoxCondition.DataSource = Enum.GetValues(typeof(ComponentStatus));
		}

	}
}
