using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CASTerms;
using EFCore.DTO.Dictionaries;
using EFCore.DTO.General;
using EFCore.Filter;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Filters;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls
{
	public partial class AllProductListScreen : ScreenControl
	{
		#region Fields

		private ICommonCollection<Product> _initialProductArray = new CommonCollection<Product>();
		private ICommonCollection<Product> _resultProductArray = new CommonCollection<Product>();

		private BaseListViewControl<Product> _directivesViewer;

		private CommonFilterCollection _filter;

		private ContextMenuStrip _contextMenuStrip;
		private ToolStripMenuItem _toolStripMenuItemCopy;
		private ToolStripMenuItem _toolStripMenuItemPaste;
		private ToolStripMenuItem _toolStripMenuItemShowImages;
		private ToolStripMenuItem _toolStripMenuItemDelete;

		#endregion

		#region Constructor

		#region public ProductListScreen()

		public AllProductListScreen()
		{
			InitializeComponent();
		}

		#endregion

		#region public ProductListScreen(Operator currentOperator)

		public AllProductListScreen(Operator currentOperator) : this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");
			aircraftHeaderControl1.Operator = currentOperator;
			StatusTitle = "Operator Documentation";

			_filter = new CommonFilterCollection(typeof(IAllProductsFilterParams));

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
				_initialProductArray.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<AccessoryDescriptionDTO, Product>(loadChild:true));

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
			_directivesViewer = new AllProductListView
			{
				TabIndex = 2,
				Location = new Point(panel1.Left, panel1.Top),
				Dock = DockStyle.Fill
			};

			_directivesViewer.ContextMenuStrip = _contextMenuStrip;
			panel1.Controls.Add(_directivesViewer);
		}

		#endregion

		#region private void InitToolStripMenuItems()

		private void InitToolStripMenuItems()
		{
			_contextMenuStrip = new ContextMenuStrip();
			_toolStripMenuItemCopy = new ToolStripMenuItem();
			_toolStripMenuItemPaste = new ToolStripMenuItem();
			_toolStripMenuItemDelete = new ToolStripMenuItem();
			_toolStripMenuItemShowImages = new ToolStripMenuItem();

			// 
			// contextMenuStrip
			// 
			_contextMenuStrip.Name = "_contextMenuStrip";
			_contextMenuStrip.Size = new Size(179, 176);

			// 
			// toolStripMenuItemCopy
			// 
			_toolStripMenuItemCopy.Text = "Copy";
			_toolStripMenuItemCopy.Click += CopyItemsClick;

			// 
			// toolStripMenuItemPaste
			// 
			_toolStripMenuItemPaste.Text = "Paste";
			_toolStripMenuItemPaste.Click += PasteItemsClick;
			// 
			// toolStripMenuItemPaste
			// 
			_toolStripMenuItemDelete.Text = "Delete";
			_toolStripMenuItemDelete.Click += DeleteItemsClick;
			// 
			// toolStripMenuItemShowTaskCard
			// 
			_toolStripMenuItemShowImages.Text = "Show Image";
			_toolStripMenuItemShowImages.Click += ShowImageItemsClick;

			_contextMenuStrip.Items.AddRange(new ToolStripItem[]
			{

				_toolStripMenuItemShowImages,
				new ToolStripSeparator(),
				_toolStripMenuItemCopy,
				_toolStripMenuItemPaste,
				_toolStripMenuItemDelete
				
			});

			_contextMenuStrip.Opening += ContextMenuStripOpen;
		}

		#endregion

		#region private void ContextMenuStripOpen(object sender, CancelEventArgs e)

		private void ContextMenuStripOpen(object sender, CancelEventArgs e)
		{
			if (_directivesViewer.SelectedItems.Count <= 0)
			{
				_toolStripMenuItemShowImages.Enabled = false;
			}

			if (_directivesViewer.SelectedItems.Count == 1)
			{
				var product = _directivesViewer.SelectedItems[0];
				_toolStripMenuItemShowImages.Enabled =  product.ImageFile != null;
			}
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

		#region private void DeleteItemsClick(object sender, EventArgs e)

		private void DeleteItemsClick(object sender, EventArgs e)
		{
			Delete();
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
					GlobalObjects.CasEnvironment.NewKeeper.Save(product);

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

				foreach (var product in selectedItems)
				{
					try
					{
						GlobalObjects.CasEnvironment.NewKeeper.Delete(product);
					}
					catch (Exception ex)
					{
						Program.Provider.Logger.Log("Error while deleting data", ex);
						return;
					}
				}

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
			if (_filter == null || _filter.Count == 0)
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

		#region private void PasteItemsClick(object sender, EventArgs e)

		private void PasteItemsClick(object sender, EventArgs e)
		{
			GetFromClipboard();
		}

		#endregion

		#region private void CopyItemsClick(object sender, EventArgs e)

		private void CopyItemsClick(object sender, EventArgs e)
		{
			CopyToClipboard();
		}

		#endregion

		#region private void CopyToClipboard()
		private void CopyToClipboard()
		{
			// регистрация формата данных либо получаем его, если он уже зарегистрирован
			var format = DataFormats.GetFormat(typeof(Product[]).FullName);

			if (_directivesViewer.SelectedItems == null || _directivesViewer.SelectedItems.Count == 0)
				return;

			var pds = new List<Product>();
			var selectedItems = _directivesViewer.SelectedItems.ToArray();
			foreach (var product in selectedItems)
			{
				pds.Add(product.GetCopyUnsaved());
			}

			if (pds.Count <= 0)
				return;

			//todo:(EvgeniiBabak) Нужен другой способ проверки сереализуемости объекта
			using (var mem = new System.IO.MemoryStream())
			{
				var bin = new BinaryFormatter();
				try
				{
					bin.Serialize(mem, pds);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Объект не может быть сериализован. \n" + ex);
					return;
				}
			}
			// копирование в буфер обмена
			IDataObject dataObj = new DataObject();
			dataObj.SetData(format.Name, false, pds.ToArray());
			Clipboard.SetDataObject(dataObj, false);

			pds.Clear();
		}
		#endregion

		#region private void GetFromClipboard()

		private void GetFromClipboard()
		{
			try
			{
				var format = typeof(Product[]).FullName;

				if (string.IsNullOrEmpty(format))
					return;
				if (!Clipboard.ContainsData(format))
					return;
				var documents = (Product[])Clipboard.GetData(format);
				if (documents == null)
					return;

				var objectsToPaste = new List<Product>();
				foreach (var product in documents)
				{
					_initialProductArray.Add(product);
					objectsToPaste.Add(product);
				}

				if (objectsToPaste.Count > 0)
				{
					_directivesViewer.InsertItems(objectsToPaste.ToArray());

					headerControl.ShowSaveButton = true;
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show("Error while inserting new object(s). \n" + ex);
				headerControl.ShowSaveButton = false;
				Program.Provider.Logger.Log(ex);
			}
			finally
			{
				Clipboard.Clear();
			}
		}
		#endregion
	}
}
