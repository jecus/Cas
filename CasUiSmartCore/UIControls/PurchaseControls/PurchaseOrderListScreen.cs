using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.StoresControls;
using CASTerms;
using EntityCore.DTO.General;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Interfaces;
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
	public partial class PurchaseOrderListScreen : ScreenControl
	{
		#region Fields
		private CommonFilterCollection _filter = new CommonFilterCollection(typeof(ILogistic));
		private ICommonCollection<PurchaseOrder> _purchaseArray = new CommonCollection<PurchaseOrder>();
		private ICommonCollection<PurchaseOrder> _resultArray = new CommonCollection<PurchaseOrder>();
		private readonly BaseEntityObject _parent;

		private PurchaseOrderListView _directivesViewer;

		private RadDropDownMenu _contextMenuStrip;
		private RadMenuItem _toolStripMenuItemMoveTo;
		private RadMenuItem _toolStripMenuItemEdit;
		private RadMenuItem _toolStripMenuItemDelete;
		private RadMenuSeparatorItem _toolStripSeparator1;
		private Filter filter;

		#endregion

		#region Constructors

		#region public PurchaseOrderListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		public PurchaseOrderListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public PurchaseOrderListScreen(Aircraft currentAircraft) : this()
		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список директив
		///</summary>
		///<param name="currentAircraft">ВС, которому принадлежат директивы</param>
		public PurchaseOrderListScreen(Aircraft currentAircraft)
			: this()
		{
			if (currentAircraft == null) 
				throw new ArgumentNullException("currentAircraft");
			_parent = currentAircraft;
			CurrentAircraft = currentAircraft;
			StatusTitle = "Quotation orders";
			InitToolStripMenuItems();
			InitListView();
		}

		#endregion

		#region public PurchaseOrderListScreen(Operator currentOperator) : this()
		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список директив
		///</summary>
		///<param name="currentOperator">Оператор, которому принадлежат директивы</param>
		public PurchaseOrderListScreen(Operator currentOperator)
			: this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");
			_parent = currentOperator;
			aircraftHeaderControl1.Operator = currentOperator;
			StatusTitle = "Operator Purchases";
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

			_purchaseArray.Clear();
			_purchaseArray = null;

			if (_toolStripMenuItemMoveTo != null) _toolStripMenuItemMoveTo.Dispose();
			if (_toolStripMenuItemEdit != null) _toolStripMenuItemEdit.Dispose();
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

			_directivesViewer.SetItemsArray(_purchaseArray.ToArray());
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

			AnimatedThreadWorker.ReportProgress(0, "load Quotations");

			try
			{
				if (filter != null)
					_purchaseArray.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<PurchaseOrderDTO, PurchaseOrder>(filter));
				else _purchaseArray.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<PurchaseOrderDTO, PurchaseOrder>());
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while load Quotations", ex);
			}

			AnimatedThreadWorker.ReportProgress(20, "calculation Quotations");

			AnimatedThreadWorker.ReportProgress(70, "filter Quotations");
			FilterItems(_purchaseArray, _resultArray);
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

		#region private void InitToolStripMenuItems(Aircraft aircraft)

		private void InitToolStripMenuItems()
		{
			_contextMenuStrip = new RadDropDownMenu();
			_toolStripMenuItemMoveTo = new RadMenuItem();
			_toolStripMenuItemDelete = new RadMenuItem();
			_toolStripSeparator1 = new RadMenuSeparatorItem();
			_toolStripMenuItemEdit = new RadMenuItem();
			// 
			// contextMenuStrip
			// 
			_contextMenuStrip.Name = "_contextMenuStrip";
			_contextMenuStrip.Size = new Size(179, 176);

			_toolStripMenuItemEdit.Text = "Edit";
			_toolStripMenuItemEdit.Click += ToolStripMenuItemEditClick;
			// 
			// toolStripMenuItemView
			// 
			_toolStripMenuItemMoveTo.Text = "Move to Store";
			_toolStripMenuItemMoveTo.Click += ToolStripMenuItemMoveToClick;
			// 
			// toolStripMenuItemDelete
			// 
			_toolStripMenuItemDelete.Text = "Delete";
			_toolStripMenuItemDelete.Click += ToolStripMenuItemDeleteClick;

			_contextMenuStrip.Items.Clear();
			_contextMenuStrip.Items.AddRange(new RadItem[]
												{
													_toolStripMenuItemMoveTo,
													_toolStripSeparator1,
													_toolStripMenuItemEdit,
													_toolStripMenuItemDelete

												});
		}
		#endregion


		#region private void ToolStripMenuItemMoveToClick(object sender, EventArgs e)
		/// <summary>
		/// Публикует рабочий пакет
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ToolStripMenuItemMoveToClick(object sender, EventArgs e)
		{
			var form = new MoveProductForm(_directivesViewer.SelectedItem);
			if (form.ShowDialog() == DialogResult.OK)
			{
				_directivesViewer.SelectedItem.Status = WorkPackageStatus.Published;
				_directivesViewer.SelectedItem.ClosingDate = DateTime.Now;
				_directivesViewer.SelectedItem.CloseByUser = GlobalObjects.CasEnvironment.IdentityUser.ToString();
				_directivesViewer.SelectedItem.ClosedById = GlobalObjects.CasEnvironment.IdentityUser.ItemId;
				GlobalObjects.CasEnvironment.NewKeeper.Save(_directivesViewer.SelectedItem);
				AnimatedThreadWorker.RunWorkerAsync();
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
				foreach (PurchaseOrder rfq in _directivesViewer.SelectedItems)
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
						MessageBox.Show("Purchase Order " + rfq.Title + " is already closed.",
							(string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK,
							MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
						continue;
					}

					rfq.Status = WorkPackageStatus.Closed;
					rfq.ClosingDate = DateTime.Now;
					rfq.CloseByUser = GlobalObjects.CasEnvironment.IdentityUser.ToString();
					rfq.ClosedById = GlobalObjects.CasEnvironment.IdentityUser.ItemId;
					GlobalObjects.CasEnvironment.NewKeeper.Save(rfq);
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
			if (_directivesViewer.SelectedItems.Count == 1)
			{
				GlobalObjects.PurchaseCore.LoadPurchaseOrderItems(_directivesViewer.SelectedItem);
				PurchaseRequestForm editForm = new PurchaseRequestForm(_directivesViewer.SelectedItems[0]);
				if(editForm.ShowDialog() == DialogResult.OK)
					AnimatedThreadWorker.RunWorkerAsync();
			}   
		}

		#endregion

		#region private void InitListView()

		private void InitListView()
		{
			_directivesViewer = new PurchaseOrderListView
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
					PurchaseOrder po = _directivesViewer.SelectedItem;
					if (po.Status == WorkPackageStatus.Closed || po.Status == WorkPackageStatus.Opened)
					{
						_toolStripMenuItemMoveTo.Enabled = true;
					}
					else if (po.Status == WorkPackageStatus.Published)
					{
						_toolStripMenuItemMoveTo.Enabled = false;
					}
					else
					{
						_toolStripMenuItemMoveTo.Enabled = true;
					}

				}
				else
				{
					_toolStripMenuItemMoveTo.Enabled = true;
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
				headerControl.EditButtonEnabled= false;
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
						? "Do you really want to delete Purchase order " + _directivesViewer.SelectedItem.Title + "?"
						: "Do you really want to delete Purchase orders? ", "Confirm delete operation",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if (confirmResult == DialogResult.Yes)
			{
				List<PurchaseOrder> selectedItems = new List<PurchaseOrder>();
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

		#region private void ButtonReleaseToServiceClick(object sender, EventArgs e)
		private void ButtonReleaseToServiceClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItem == null) return;

			GlobalObjects.PurchaseCore.LoadPurchaseOrderItems(_directivesViewer.SelectedItem);
			
			ReferenceEventArgs refe = new ReferenceEventArgs
			{
				DisplayerText = "Release To Service",
				TypeOfReflection = ReflectionTypes.DisplayInNew,
				//RequestedEntity = new DispatcheredRequestForQuotationReport(_directivesViewer.SelectedItem)
			};
			InvokeDisplayerRequested(refe);
			//  MessageBox.Show("Показать репорт с распечаткой титульной страницы");
		}
		#endregion

		#region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

		private void HeaderControlButtonReloadClick(object sender, EventArgs e)
		{
			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			//throw new System.NotImplementedException();
		}
		#endregion

		#region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

		private void HeaderButtonReloadClick(object sender, EventArgs e)
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

		private void HeaderControlButtonPrintRequested(object sender, ReferenceEventArgs e)
		{
			//throw new NotImplementedException();
		}

		#endregion

		#region private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)

		private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)
		{
			_resultArray.Clear();

			#region Фильтрация директив
			AnimatedThreadWorker.ReportProgress(50, "filter directives");

			FilterItems(_purchaseArray, _resultArray);

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
		private void FilterItems(IEnumerable<PurchaseOrder> initialCollection, ICommonCollection<PurchaseOrder> resultCollection)
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

		#region private void ButtonAddNewClick(object sender, EventArgs e)

		private void ButtonAddNewClick(object sender, EventArgs e)
		{

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
			var res = GlobalObjects.CasEnvironment.Execute(OrdersQueries.PurchaseSearch(TextBoxFilter.Text));
			var ids = new List<int>();
			foreach (DataRow dRow in res.Tables[0].Rows)
				ids.Add(int.Parse(dRow[0].ToString()));

			filter = new Filter("ItemId", ids);
			AnimatedThreadWorker.RunWorkerAsync();
		}
	}
}
