using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using EFCore.DTO.Dictionaries;
using EFCore.DTO.General;
using EFCore.Filter;
using MetroFramework.Forms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Filters;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls.Initial
{
    public partial class InitialOrderFormNew : MetroForm
    {
		#region Fields

		private List<InitialOrderRecord> _addedInitialOrderRecords = new List<InitialOrderRecord>();
		private List<InitialOrderRecord> _deleteExistInitialOrderRecords = new List<InitialOrderRecord>();

		private readonly InitialOrder _order;
		private List<BaseEntityObject> destinations = new List<BaseEntityObject>();

		private readonly ProductPartNumberFilter _partNumberFilter = new ProductPartNumberFilter();
		private readonly ProductCollectionFilter _collectionFilter = new ProductCollectionFilter();

		#endregion

		#region Constructor

		public InitialOrderFormNew()
	    {
		    InitializeComponent();
	    }

	    public InitialOrderFormNew(InitialOrder order, List<Product> products = null) : this()
	    {
		    if (products != null)
		    {
			    foreach (var product in products)
			    {
					var newRequest = new InitialOrderRecord(-1, product, 1);
					newRequest.Product = product;
					_addedInitialOrderRecords.Add(newRequest);
				}
		    }

		    _order = order;

		    _collectionFilter.Filters.Add(_partNumberFilter);

			Task.Run(() => DoWork())
			    .ContinueWith(task => Completed(), TaskScheduler.FromCurrentSynchronizationContext());
		}

		#endregion

		#region private void Completed()

		private void Completed()
		{
			var filteredCollection = _collectionFilter.GatherDirectives();
			listViewKits.SetItemsArray(filteredCollection.ToArray());
			listViewInitialItems.SetItemsArray(_addedInitialOrderRecords.ToArray());

			UpdateInitialRecordsControls();
		}

		#endregion

		#region private void DoWork()

		private void DoWork()
		{
			destinations.Clear();

			var currentAircraftKits = GlobalObjects.CasEnvironment.NewLoader.GetObjectList<AccessoryDescriptionDTO, Product>(loadChild: true).ToList();
			_collectionFilter.InitialCollection = currentAircraftKits;

			if (_order != null && _order.ItemId > 0)
			{
				_addedInitialOrderRecords.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<InitialOrderRecordDTO, InitialOrderRecord>(new Filter("ParentPackageId", _order.ItemId)));
				var ids = _addedInitialOrderRecords.Select(i => i.ProductId);
				if (ids.Count() > 0)
				{
					foreach (var addedInitialOrderRecord in _addedInitialOrderRecords)
						addedInitialOrderRecord.Product = currentAircraftKits.FirstOrDefault(i => i.ItemId == addedInitialOrderRecord.ProductId);
				}
			}

			destinations.AddRange(GlobalObjects.AircraftsCore.GetAllAircrafts().ToArray());
			destinations.AddRange(GlobalObjects.CasEnvironment.Stores.GetValidEntries());
			destinations.AddRange(GlobalObjects.CasEnvironment.Hangars.GetValidEntries());
		}

		#endregion

		#region private void UpdateInitialRecordsControls()

		private void UpdateInitialRecordsControls()
		{
			dictionaryComboProduct.SetType(typeof(Product), true);
			Program.MainDispatcher.ProcessControl(dictionaryComboProduct);

			comboBoxMeasure.Items.Clear();
			comboBoxMeasure.Items.AddRange(Measure.GetByCategories(new[] { MeasureCategory.Mass, MeasureCategory.EconomicEntity }));

			comboBoxDestination.Items.Clear();
			comboBoxDestination.Items.AddRange(destinations.ToArray());

			comboBoxPriority.Items.Clear();
			comboBoxPriority.Items.AddRange(Priority.Items.ToArray());

			comboBoxReason.Items.Clear();
			comboBoxReason.Items.AddRange(InitialReason.Items.ToArray());
		}

		#endregion

		private void comboBoxDestination_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}

		#region private void comboBoxMeasure_SelectedIndexChanged(object sender, System.EventArgs e)

		private void comboBoxMeasure_SelectedIndexChanged(object sender, EventArgs e)
		{
			SetForMeasure();
		}

		#endregion

		#region private void numericUpDownQuantity_ValueChanged(object sender, System.EventArgs e)

		private void numericUpDownQuantity_ValueChanged(object sender, EventArgs e)
		{
			SetForMeasure();
		}

		#endregion

		#region private void SetForMeasure()
		/// <summary>
		/// Изменяет контрол в соотствествии с выбранной единицей измерения
		/// </summary>
		private void SetForMeasure()
		{
			var measure = comboBoxMeasure.SelectedItem as Measure;
			if (measure == null || measure.MeasureCategory != MeasureCategory.Mass)
				numericUpDownQuantity.DecimalPlaces = 0;
			else numericUpDownQuantity.DecimalPlaces = 2;

			var quantity = numericUpDownQuantity.Value;

			textBoxTotal.Text = $"{quantity:0.##}" + (measure != null ? " " + measure + "(s)" : "");
		}
		#endregion

		#region private void UpdateListViewItems()
		private void UpdateListViewItems()
		{
			var filteredCollection = _collectionFilter.GatherDirectives();
			listViewKits.SetItemsArray(filteredCollection.ToArray());
		}
		#endregion

		#region private void textBoxSearchPartNumber_TextChanged(object sender, EventArgs e)

		private void textBoxSearchPartNumber_TextChanged(object sender, EventArgs e)
		{
			_partNumberFilter.Mask = textBoxSearchPartNumber.Text;
			UpdateListViewItems();
		}

		#endregion

		#region private void buttonCancel_Click(object sender, EventArgs e)

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		#endregion

		#region private void buttonOk_Click(object sender, EventArgs e)

		private void buttonOk_Click(object sender, EventArgs e)
		{

		}

		#endregion

		private void ButtonAdd_Click(object sender, EventArgs e)
		{
			foreach (var product in listViewKits.SelectedItems.ToArray())
			{
				var newRequest = new InitialOrderRecord(-1, product, 1);
				newRequest.Product = product;
				_addedInitialOrderRecords.Add(newRequest);
			}

			listViewInitialItems.SetItemsArray(_addedInitialOrderRecords.ToArray());
		}

		private void ButtonDelete_Click(object sender, EventArgs e)
		{
			if(listViewInitialItems.SelectedItems.Count == 0) return;

			foreach (var item in listViewInitialItems.SelectedItems.ToArray())
			{
				if (item.ItemId > 0)
					_deleteExistInitialOrderRecords.Add(item);

				_addedInitialOrderRecords.Remove(item);
			}

			listViewInitialItems.SetItemsArray(_addedInitialOrderRecords.ToArray());
		}

		
	}
}
