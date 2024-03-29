﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.Entity.Models.DTO.Dictionaries;
using CAS.Entity.Models.DTO.General;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using Entity.Abstractions.Filters;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Filters;
using SmartCore.Purchase;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.PurchaseControls
{
	public partial class ProductListScreen : ScreenControl
	{
		#region Fields

		private ICommonCollection<Product> _initialProductArray = new CommonCollection<Product>();
		private ICommonCollection<Product> _resultProductArray = new CommonCollection<Product>();

		private BaseGridViewControl<Product> _directivesViewer;

		private CommonFilterCollection _filter;

		private RadMenuItem _toolStripMenuItemShowImages;
		
		#endregion

		#region Constructor

		#region public ProductListScreen()

		public ProductListScreen()
		{
			InitializeComponent();
		}

		#endregion

		#region public ProductListScreen(Operator currentOperator)

		public ProductListScreen(Operator currentOperator) : this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");
			aircraftHeaderControl1.Operator = currentOperator;
			StatusTitle = "Operator Documentation";

			_filter = new CommonFilterCollection(typeof(Product));

			InitToolStripMenuItems();
			InitListView();
			UpdateInformation();
		}

		#endregion

		#endregion

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)

		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			_directivesViewer.SetItemsArray(_resultProductArray.ToArray());
			_directivesViewer.Focus();
		}

		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)

		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			_initialProductArray.Clear();
			_resultProductArray.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load products");

			try
			{
				_initialProductArray.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<AccessoryDescriptionDTO, Product>(new Filter("ModelingObjectTypeId", -1),true));

				var ids = _initialProductArray.SelectMany(i => i.SupplierRelations).Select(i => i.SupplierID).Distinct();
				if (ids.Count() > 0)
				{
					var suppliers = GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<SupplierDTO, Supplier>(new Filter("ItemId", ids));
					if (suppliers.Count > 0)
					{
						foreach (var product in _initialProductArray)
						{
							foreach (var relation in product.SupplierRelations)
							{
								var currentSup = suppliers.FirstOrDefault(i => i.ItemId == relation.SupplierID);
								if (currentSup != null)
								{
									relation.Supplier = currentSup;
									if (!product.Suppliers.Contains(currentSup))
									{
										product.Suppliers.Add(currentSup);
									}
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while load documents", ex);
			}

			AnimatedThreadWorker.ReportProgress(70, "filter products");
			FilterItems(_initialProductArray, _resultProductArray);

			AnimatedThreadWorker.ReportProgress(100, "Complete");
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

		#region private void InitListView()

		private void InitListView()
		{
			_directivesViewer = new ProductListView
			{
				TabIndex = 2,
				Location = new Point(panel1.Left, panel1.Top),
				Dock = DockStyle.Fill
			};
			
			_directivesViewer.AddMenuItems(_toolStripMenuItemShowImages);

			_directivesViewer.MenuOpeningAction = () =>
			{
				if (_directivesViewer.SelectedItems.Count <= 0)
				{
					_toolStripMenuItemShowImages.Enabled = false;
				}

				if (_directivesViewer.SelectedItems.Count == 1)
				{
					var product = _directivesViewer.SelectedItems[0];
					_toolStripMenuItemShowImages.Enabled = product.ImageFile != null;
				}
			};
			
			panel1.Controls.Add(_directivesViewer);
		}

		#endregion

		#region private void InitToolStripMenuItems()

		private void InitToolStripMenuItems()
		{
			_toolStripMenuItemShowImages = new RadMenuItem();

			// 
			// toolStripMenuItemShowTaskCard
			// 
			_toolStripMenuItemShowImages.Text = "Show Image";
			_toolStripMenuItemShowImages.Click += ShowImageItemsClick;
		}

		#endregion

		#region private void ShowImageItemsClick(object sender, EventArgs e)

		private void ShowImageItemsClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems == null ||
			    _directivesViewer.SelectedItems.Count == 0) return;

			var product = _directivesViewer.SelectedItems[0];
			try
			{
				string message;
				GlobalObjects.CasEnvironment.OpenFile(product.ImageFile, out message);
				if (message != "")
				{
					MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
						MessageBoxDefaultButton.Button1);
				}
			}
			catch (Exception ex)
			{
				string errorDescriptionSctring = $"Error while Open Attached File for {product}, id {product.ItemId}. \nFileId {product.ImageFile.ItemId}";
				Program.Provider.Logger.Log(errorDescriptionSctring, ex);
			}
		}

		#endregion

		#region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

		private void HeaderControlButtonReloadClick(object sender, EventArgs e)
		{
			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void HeaderControlSaveButtonClick(object sender, EventArgs e)

		private void HeaderControlSaveButtonClick(object sender, EventArgs e)
		{
			var unsaved = _directivesViewer.GetItemsArray().Where(i => i.ItemId <= 0).ToList();

			try
			{
				foreach (var product in unsaved)
					GlobalObjects.NewKeeper.Save(product);

				MessageBox.Show("Saving was successful", "Message infomation", MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				headerControl.ShowSaveButton = false;
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while save document", ex);
			}
		}

		#endregion

		#region private void ButtonDeleteClick(object sender, EventArgs e)
		
		private void ButtonDeleteClick(object sender, EventArgs e)
		{
			Delete();
		}

		#endregion

		#region private void Delete()

		private void Delete()
		{
			if (_directivesViewer.SelectedItems == null) return;

			var confirmResult =
				MessageBox.Show(
					_directivesViewer.SelectedItem != null
						? "Do you really want to delete Product " + _directivesViewer.SelectedItem.Description + "?"
						: "Do you really want to delete selected Product? ", "Confirm delete operation",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if (confirmResult == DialogResult.Yes)
			{
				var selectedItems = new List<Product>();
				selectedItems.AddRange(_directivesViewer.SelectedItems.ToArray());

				GlobalObjects.NewKeeper.Delete(selectedItems.OfType<BaseEntityObject>().ToList(), true);

				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
			else
			{
				MessageBox.Show("Failed to delete Product: Parent container is invalid", "Operation failed",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#endregion

		#region private void ButtonAddProductClick(object sender, EventArgs e)

		private void ButtonAddProductClick(object sender, EventArgs e)
		{
			var form = new ProductForm(new Product());

			if (form.ShowDialog() == DialogResult.OK)
			{
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void ButtonApplyFilterClick(object sender, EventArgs e)

		private void ButtonApplyFilterClick(object sender, EventArgs e)
		{
			var form = new CommonFilterForm(_filter, _initialProductArray);

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
			_resultProductArray.Clear();

			#region Фильтрация директив
			AnimatedThreadWorker.ReportProgress(50, "filter directives");

			FilterItems(_initialProductArray, _resultProductArray);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}

		#endregion

		#region private void FilterItems(IEnumerable<Document> initialCollection, ICommonCollection<Document> resultCollection)

		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		private void FilterItems(IEnumerable<Product> initialCollection, ICommonCollection<Product> resultCollection)
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

	}
}
