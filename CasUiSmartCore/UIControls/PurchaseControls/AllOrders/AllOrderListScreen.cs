using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.PurchaseControls.Initial;
using CAS.UI.UIControls.PurchaseControls.Purchase;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Filters;
using SmartCore.Purchase;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.PurchaseControls.AllOrders
{
    ///<summary>
    ///</summary>
    [ToolboxItem(false)]
    public partial class AllOrderListScreen : ScreenControl
    {
        #region Fields
        private CommonFilterCollection _filter = new CommonFilterCollection(typeof(ILogistic));
        private ICommonCollection<ILogistic> _initialArray = new CommonCollection<ILogistic>();
        private ICommonCollection<ILogistic> _resultArray = new CommonCollection<ILogistic>();
        private readonly BaseEntityObject _parent;
        
        private AllOrderListView _directivesViewer;
        private RadDropDownMenu _contextMenuStrip;
        private RadMenuItem _toolStripMenuItemPublish;
        private RadMenuItem _toolStripMenuItemCreateQuatation;
        private RadMenuItem _toolStripMenuItemClose;
        private RadMenuItem _toolStripMenuItemDelete;
        private RadMenuSeparatorItem _toolStripSeparator1;
        private RadMenuItem _toolStripMenuItemEdit;
        private RadMenuItem _toolStripMenuItemCreatePurchase;

        #endregion
        
        #region Constructors

        #region private InitialOrderListScreen()
        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        private AllOrderListScreen()
        {
            InitializeComponent();
        }
        #endregion

        #region public InitialOrderListScreen(Operator currentOperator) : this()
        ///<summary>
        /// Создаёт экземпляр элемента управления, отображающего список директив
        ///</summary>
        ///<param name="currentOperator">Оператор, которому принадлежат директивы</param>
        public AllOrderListScreen(Operator currentOperator)
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

            if (_directivesViewer != null)
	            _directivesViewer.Dispose();

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

            AnimatedThreadWorker.ReportProgress(0, "load Orders");

            try
            {
                _initialArray.AddRange(GlobalObjects.PurchaseCore.GetInitialOrders(null));
                _initialArray.AddRange(GlobalObjects.PurchaseCore.GetRequestForQuotation(null));
                _initialArray.AddRange(GlobalObjects.PurchaseCore.GetPurchaseOrders(null));
			}
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while load Orders", ex);
            }

            AnimatedThreadWorker.ReportProgress(70, "filter Orders");
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
        
        #region private void InitListView()

        private void InitListView()
        {
            _directivesViewer = new AllOrderListView()
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
		            var wp = _directivesViewer.SelectedItem;
		            if (wp.Status == WorkPackageStatus.Closed || wp.Status == WorkPackageStatus.Opened)
		            {
			            _toolStripMenuItemClose.Enabled = false;
			            _toolStripMenuItemPublish.Enabled = true;
		            }
		            else if (wp.Status == WorkPackageStatus.Published)
		            {
			            _toolStripMenuItemClose.Enabled = true;
			            _toolStripMenuItemPublish.Enabled = false;
		            }
		            else
		            {
			            _toolStripMenuItemClose.Enabled = true;
			            _toolStripMenuItemPublish.Enabled = true;
		            }

		            _toolStripMenuItemCreateQuatation.Enabled = true;

		            if (wp is InitialOrder)
		            {
			            _toolStripMenuItemCreatePurchase.Enabled = false;
			            _toolStripMenuItemCreateQuatation.Enabled = true;
		            }
		            else if (wp is RequestForQuotation)
		            {
			            _toolStripMenuItemCreatePurchase.Enabled = true;
			            _toolStripMenuItemCreateQuatation.Enabled = false;
		            }
		            else
		            {
			            _toolStripMenuItemCreatePurchase.Enabled = false;
			            _toolStripMenuItemCreateQuatation.Enabled = false;
		            }
	            }

	            else
	            {
		            _toolStripMenuItemCreateQuatation.Enabled = false;
		            _toolStripMenuItemClose.Enabled = true;
		            _toolStripMenuItemPublish.Enabled = true;
		            _toolStripMenuItemCreatePurchase.Enabled = false;
	            }
            };

			panel1.Controls.Add(_directivesViewer);
        }

		#endregion

		#region private void InitToolStripMenuItems()

		private void InitToolStripMenuItems()
		{
			_contextMenuStrip = new RadDropDownMenu();
			_toolStripMenuItemPublish = new RadMenuItem();
			_toolStripMenuItemCreateQuatation = new RadMenuItem();
			_toolStripMenuItemCreatePurchase = new RadMenuItem();
			_toolStripMenuItemClose = new RadMenuItem();
			_toolStripMenuItemDelete = new RadMenuItem();
			_toolStripSeparator1 = new RadMenuSeparatorItem();
			_toolStripMenuItemEdit = new RadMenuItem();
			// 
			// contextMenuStrip
			// 
			_contextMenuStrip.Name = "_contextMenuStrip";
			_contextMenuStrip.Size = new Size(179, 176);

			_toolStripMenuItemEdit.Text = "Edit";
			_toolStripMenuItemEdit.Click += _toolStripMenuItemEdit_Click;
			// 
			// toolStripMenuItemView
			// 
			_toolStripMenuItemPublish.Text = "Publish";
			_toolStripMenuItemPublish.Click += _toolStripMenuItemPublish_Click;
			// 
			// toolStripMenuItemCreatePurchas
			//
			_toolStripMenuItemCreatePurchase.Text = "Create Purchase Order";
			_toolStripMenuItemCreatePurchase.Click += _toolStripMenuItemCreatePurchase_Click; ;
			// 
			// toolStripMenuItemCreateQuatation
			//
			_toolStripMenuItemCreateQuatation.Text = "Create Quatation Order";
			_toolStripMenuItemCreateQuatation.Click += _toolStripMenuItemCreateQuatation_Click;
			// 
			// toolStripMenuItemClose
			// 
			_toolStripMenuItemClose.Text = "Close";
			_toolStripMenuItemClose.Click += _toolStripMenuItemClose_Click;
			// 
			// toolStripMenuItemDelete
			// 
			_toolStripMenuItemDelete.Text = "Delete";
			_toolStripMenuItemDelete.Click += _toolStripMenuItemDelete_Click;

			_contextMenuStrip.Items.Clear();

			
			_contextMenuStrip.Items.AddRange(_toolStripMenuItemCreatePurchase,
													new RadMenuSeparatorItem(),
													_toolStripMenuItemPublish,
													_toolStripMenuItemClose,
													_toolStripSeparator1,
													_toolStripMenuItemEdit,
													_toolStripSeparator1,
													_toolStripMenuItemDelete);
		}

		#endregion

		#region private void _toolStripMenuItemCreatePurchase_Click(object sender, EventArgs e)

		private void _toolStripMenuItemCreatePurchase_Click(object sender, EventArgs e)
		{
			var editForm = new CreatePurchaseOrderForm(_directivesViewer.SelectedItems[0] as RequestForQuotation);
			if (editForm.ShowDialog() == DialogResult.OK)
			{
				MessageBox.Show("Create purchase successful", "Message infomation", MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
		}

		#endregion

		#region private void _contextMenuStrip_Opening(object sender, CancelEventArgs e)

		private void _contextMenuStrip_Opening(object sender, CancelEventArgs e)
		{
			
		}

		#endregion

		#region private void _toolStripMenuItemDelete_Click(object sender, EventArgs e)

		private void _toolStripMenuItemDelete_Click(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems.Count == 1)
			{
				GlobalObjects.CasEnvironment.Manipulator.Delete(_directivesViewer.SelectedItem as BaseEntityObject);
			}
			else
			{
				foreach (var rfq in _directivesViewer.SelectedItems)
				{
					GlobalObjects.CasEnvironment.Manipulator.Delete(rfq as BaseEntityObject);
				}
			}
			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void _toolStripMenuItemClose_Click(object sender, EventArgs e)

		private void _toolStripMenuItemClose_Click(object sender, EventArgs e)
		{
			var selected = _directivesViewer.SelectedItems.ToArray();

			try
			{
				foreach (var rfq in selected)
				{
					if (rfq.Status == WorkPackageStatus.Closed)
					{
						MessageBox.Show("Initional Order " + rfq.Title + " is already closed.",
							(string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK,
							MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
						continue;
					}

					rfq.Status = WorkPackageStatus.Closed;
					rfq.ClosingDate = DateTime.Now;
					rfq.CloseByUser = GlobalObjects.CasEnvironment.IdentityUser.ToString();
					rfq.ClosedById = GlobalObjects.CasEnvironment.IdentityUser.ItemId;
					GlobalObjects.CasEnvironment.NewKeeper.Save(rfq as BaseEntityObject);
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

		private void _toolStripMenuItemCreateQuatation_Click(object sender, EventArgs e)
		{

		}

		#region private void _toolStripMenuItemPublish_Click(object sender, EventArgs e)

		private void _toolStripMenuItemPublish_Click(object sender, EventArgs e)
		{
			foreach (var rfq in _directivesViewer.SelectedItems)
			{
				if (rfq.Status == WorkPackageStatus.Published)
				{
					MessageBox.Show("Initional Order " + rfq.Title + " is already publisher.",
						(string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK,
						MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
					continue;
				}

				rfq.Status = WorkPackageStatus.Published;
				rfq.PublishingDate = DateTime.Now;
				rfq.PublishedByUser = GlobalObjects.CasEnvironment.IdentityUser.ToString();
				rfq.PublishedById = GlobalObjects.CasEnvironment.IdentityUser.ItemId;
				GlobalObjects.CasEnvironment.NewKeeper.Save(rfq as BaseEntityObject);
			}
			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void _toolStripMenuItemEdit_Click(object sender, EventArgs e)

		private void _toolStripMenuItemEdit_Click(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItem == null) return;

			if (_directivesViewer.SelectedItem is InitialOrder)
			{
				var editForm = new InitialOrderFormNew(_directivesViewer.SelectedItem as InitialOrder);
				if (editForm.ShowDialog() == DialogResult.OK)
				{
					AnimatedThreadWorker.RunWorkerAsync();
				}
			}
			else if (_directivesViewer.SelectedItem is RequestForQuotation)
			{
				var editForm = new QuatationOrderFormNew(_directivesViewer.SelectedItem as RequestForQuotation);
				if (editForm.ShowDialog() == DialogResult.OK)
				{
					AnimatedThreadWorker.RunWorkerAsync();
				}
			}
			else
			{
				var editForm = new PurchaseOrderForm(_directivesViewer.SelectedItem as PurchaseOrder);
				if (editForm.ShowDialog() == DialogResult.OK)
				{
					AnimatedThreadWorker.RunWorkerAsync();
				}
			}
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

            var confirmResult =
                MessageBox.Show(
                    _directivesViewer.SelectedItem != null
                        ? "Do you really want to delete Order " + _directivesViewer.SelectedItem.Title + "?"
                        : "Do you really want to delete Orders? ", "Confirm delete operation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (confirmResult == DialogResult.Yes)
            {
                int count = _directivesViewer.SelectedItems.Count;

                var selectedItems = new List<ILogistic>();
                selectedItems.AddRange(_directivesViewer.SelectedItems.ToArray());
                for (int i = 0; i < count; i++)
                {
                    try
                    {
                        GlobalObjects.CasEnvironment.Manipulator.Delete(selectedItems[i] as BaseEntityObject);
                    }
                    catch (Exception ex)
                    {
                        Program.Provider.Logger.Log("Error while deleting data", ex);
                        return;
                    }
                }
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
            //var form = new InitialOrderFormNew(new InitialOrder(){ParentId = CurrentParent.ItemId, ParentType = CurrentParent.SmartCoreObjectType});
            //if(form.ShowDialog() == DialogResult.OK)
            //    AnimatedThreadWorker.RunWorkerAsync(); 
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

        #region private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
        private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            
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
        private void FilterItems(IEnumerable<ILogistic> initialCollection, ICommonCollection<ILogistic> resultCollection)
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
                    var acceptable = true;
                    foreach (var filter in _filter)
                        acceptable = filter.Acceptable(pd as BaseEntityObject); if (!acceptable) break;

                    if (acceptable) resultCollection.Add(pd);
                }
                else
                {
                    var acceptable = true;
                    foreach (var filter in _filter)
                    {
                        if (filter.Values == null || filter.Values.Length == 0)
                            continue;
                        acceptable = filter.Acceptable(pd as BaseEntityObject); if (acceptable) break;
                    }
                    if (acceptable) resultCollection.Add(pd);
                }
            }
        }
        #endregion

        #endregion
    }
}
