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
using CASTerms;
using EFCore.DTO.Dictionaries;
using EFCore.DTO.General;
using EFCore.Filter;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Filters;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls
{
    ///<summary>
    ///</summary>
    [ToolboxItem(false)]
    public partial class InitialOrderListScreen : ScreenControl
    {
        #region Fields
        private CommonFilterCollection _filter = new CommonFilterCollection(typeof(InitialOrder));
        private ICommonCollection<InitialOrder> _initialArray = new CommonCollection<InitialOrder>();
        private ICommonCollection<InitialOrder> _resultArray = new CommonCollection<InitialOrder>();
        private readonly BaseEntityObject _parent;
        
        private InitialOrderListView _directivesViewer;

        private ContextMenuStrip _contextMenuStrip;
        private ToolStripMenuItem _toolStripMenuItemPublish;
        private ToolStripMenuItem _toolStripMenuItemEdit;
        private ToolStripMenuItem _toolStripMenuItemClose;
        private ToolStripMenuItem _toolStripMenuItemDelete;
        private ToolStripMenuItem _toolStripMenuItemCreateQuatation;
        private ToolStripSeparator _toolStripSeparator1;

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

            if (_toolStripMenuItemPublish != null) _toolStripMenuItemPublish.Dispose();
            if (_toolStripMenuItemCreateQuatation != null) _toolStripMenuItemCreateQuatation.Dispose();
            if (_toolStripMenuItemEdit != null) _toolStripMenuItemEdit.Dispose();
            if (_toolStripMenuItemClose != null) _toolStripMenuItemClose.Dispose();
            if (_toolStripMenuItemDelete != null) _toolStripMenuItemDelete.Dispose();
            if (_toolStripSeparator1 != null) _toolStripSeparator1.Dispose();
            if (_contextMenuStrip != null) _contextMenuStrip.Dispose();
            if (_directivesViewer != null) _directivesViewer.DisposeView();

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
            headerControl.PrintButtonEnabled = _directivesViewer.ListViewItemList.Count != 0;

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
                _initialArray.AddRange(GlobalObjects.PurchaseCore.GetInitialOrders(_parent as Aircraft));
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
            _contextMenuStrip = new ContextMenuStrip();
            _toolStripMenuItemPublish = new ToolStripMenuItem();
	        _toolStripMenuItemCreateQuatation = new ToolStripMenuItem();
            _toolStripMenuItemClose = new ToolStripMenuItem();
            _toolStripMenuItemDelete = new ToolStripMenuItem();
            _toolStripSeparator1 = new ToolStripSeparator();
            _toolStripMenuItemEdit = new ToolStripMenuItem();
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
            _toolStripMenuItemPublish.Text = "Publish";
            _toolStripMenuItemPublish.Click += ToolStripMenuItemPublishClick;

	        _toolStripMenuItemCreateQuatation.Text = "Create Quatation Order";
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
            _contextMenuStrip.Opening += ContextMenuStripOpen;
            _contextMenuStrip.Items.AddRange(new ToolStripItem[]
                                                {
	                                                _toolStripMenuItemCreateQuatation,
													new ToolStripSeparator(), 
													_toolStripMenuItemPublish,
                                                    _toolStripMenuItemClose,
                                                    _toolStripSeparator1,
                                                    _toolStripMenuItemEdit,
                                                    _toolStripSeparator1,
                                                    _toolStripMenuItemDelete

                                                });
        }


		#endregion


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
				    Description = initial.Description,
				    OpeningDate = initial.OpeningDate,
				    Author = initial.Author,
				    Remarks = initial.Remarks,
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

				    GlobalObjects.CasEnvironment.NewKeeper.Save(newquatationRecord);
			    }
		    }
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while saving data", ex);
				throw;
		    }

			MessageBox.Show("Saving was successful", "Message infomation", MessageBoxButtons.OK,
				MessageBoxIcon.Information);
		}

		#region private void ContextMenuStripOpen(object sender,CancelEventArgs e)
		/// <summary>
		/// Проверка на выделение 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ContextMenuStripOpen(object sender, CancelEventArgs e)
        {
            if (_directivesViewer.SelectedItems.Count <= 0)
                e.Cancel = true;
            else if (_directivesViewer.SelectedItems.Count == 1)
            {
                InitialOrder wp = _directivesViewer.SelectedItem;
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
            }
            else
            {
	            _toolStripMenuItemCreateQuatation.Enabled = false;
				_toolStripMenuItemClose.Enabled = true;
                _toolStripMenuItemPublish.Enabled = true;
            }
        }

        #endregion

        #region private void ToolStripMenuItemPublishClick(object sender, EventArgs e)
        /// <summary>
        /// Публикует рабочий пакет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemPublishClick(object sender, EventArgs e)
        {
            foreach (var rfq in _directivesViewer.SelectedItems)
            {
	            if (rfq.Status != WorkPackageStatus.Closed)
	            {
		            rfq.Status = WorkPackageStatus.Published;
		            rfq.PublishingDate = DateTime.Now;
		            rfq.PublishedByUser = GlobalObjects.CasEnvironment.IdentityUser.ToString();
		            rfq.PublishedById = GlobalObjects.CasEnvironment.IdentityUser.ItemId;
					GlobalObjects.CasEnvironment.NewKeeper.Save(rfq);
	            }
                else
                {
                    switch (MessageBox.Show(@"This initial order is already closed," +
                                             "\nif you want to republish it," +
                                             "\nInformation entered at the closing will be erased." + "\n\n Republish " + rfq.Title + " initial order?", (string)new GlobalTermsProvider()["SystemName"],
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
                                        MessageBoxDefaultButton.Button2))
                    {
                        case DialogResult.Yes:
                            GlobalObjects.PackageCore.PublishPackage<InitialOrder, InitialOrderRecord>(rfq, DateTime.Now);
                            break;
                        case DialogResult.No:
                            //arguments.Cancel = true;
                            break;
                    }
                }
            }
            AnimatedThreadWorker.RunWorkerAsync();
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
            //foreach (InitionalOrder rfq in _directivesViewer.SelectedItems)
            //{
            //    if (rfq.Status == WorkPackageStatus.Closed)
            //    {
            //        MessageBox.Show("Initional Order " + rfq.Title + " is already closed.",
            //                        (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK,
            //                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            //        continue;
            //    }
            //    RequestForQuotationClosingForm form = new RequestForQuotationClosingForm(rfq);
            //    form.ShowDialog();

            //    if (form.CreatePurchaseOrder)
            //    {
            //        GlobalObjects.CasEnvironment.Loader.LoadInitionalOrderItems(rfq);
            //        rfq.Products.Sort();
            //        PurchaseOrderKitForm kitForm = new PurchaseOrderKitForm(rfq);
            //        if (kitForm.ShowDialog() == DialogResult.OK)
            //        {
            //            ReferenceEventArgs refe = new ReferenceEventArgs
            //            {
            //                DisplayerText = kitForm.CurrentOrder.Title,
            //                TypeOfReflection = ReflectionTypes.DisplayInNew,
            //                RequestedEntity = new PurchaseOrderScreen(kitForm.CurrentOrder)
            //            };
            //            InvokeDisplayerRequested(refe);
            //        }
            //    }
            //}
            //AnimatedThreadWorker.RunWorkerAsync();
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
                                        ContextMenuStrip = _contextMenuStrip,
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
                        ? "Do you really want to delete Initial Order " + _directivesViewer.SelectedItem.Title + "?"
                        : "Do you really want to delete Initial Orders? ", "Confirm delete operation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (confirmResult == DialogResult.Yes)
            {
                int count = _directivesViewer.SelectedItems.Count;

                List<InitialOrder> selectedItems = new List<InitialOrder>();
                selectedItems.AddRange(_directivesViewer.SelectedItems.ToArray());
                for (int i = 0; i < count; i++)
                {
                    try
                    {
                        GlobalObjects.CasEnvironment.Manipulator.Delete(selectedItems[i]);
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
            var form = new InitialOrderFormNew(new InitialOrder(){ParentId = CurrentParent.ItemId, ParentType = CurrentParent.SmartCoreObjectType});
            if(form.ShowDialog() == DialogResult.OK)
            {
                AnimatedThreadWorker.RunWorkerAsync();

                var refe = new ReferenceEventArgs
                                              {
                                                  DisplayerText = form.AddedInitial.Title,
                                                  TypeOfReflection = ReflectionTypes.DisplayInNew,
                                                  RequestedEntity = new InitionalOrderScreen(form.AddedInitial)
                                              };
                InvokeDisplayerRequested(refe);    
            }
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

        #endregion


    }
}
