using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls
{
    ///<summary>
    ///</summary>
    [ToolboxItem(false)]
    public partial class PurchaseOrderListScreen : ScreenControl
    {
        #region Fields

        private readonly BaseEntityObject _parent;

        private List<PurchaseOrder> _directives = new List<PurchaseOrder>();

        private PurchaseOrderListView _directivesViewer;

        private ContextMenuStrip _contextMenuStrip;
        private ToolStripMenuItem _toolStripMenuItemPublish;
        private ToolStripMenuItem _toolStripMenuItemEdit;
        private ToolStripMenuItem _toolStripMenuItemClose;
        private ToolStripMenuItem _toolStripMenuItemDelete;
        private ToolStripSeparator _toolStripSeparator1;

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

            _directives.Clear();
            _directives = null;

            if (_toolStripMenuItemPublish != null) _toolStripMenuItemPublish.Dispose();
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

            _directivesViewer.SetItemsArray(_directives.ToArray());
            headerControl.PrintButtonEnabled = _directivesViewer.ListViewItemList.Count != 0;

            _directivesViewer.Focus();
        }
        #endregion

        #region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            if (_parent == null) return;
            _directives.Clear();

            AnimatedThreadWorker.ReportProgress(0, "load Quotations");

            try
            {
                _directives.AddRange(GlobalObjects.PurchaseCore.GetPurchaseOrders(_parent as Aircraft));
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

        #region private void InitToolStripMenuItems(Aircraft aircraft)

        private void InitToolStripMenuItems()
        {
            _contextMenuStrip = new ContextMenuStrip();
            _toolStripMenuItemPublish = new ToolStripMenuItem();
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
                                                    _toolStripMenuItemPublish,
                                                    _toolStripMenuItemClose,
                                                    _toolStripSeparator1,
                                                    _toolStripMenuItemEdit,
                                                    _toolStripSeparator1,
                                                    _toolStripMenuItemDelete

                                                });
        }
        #endregion

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
                PurchaseOrder po = _directivesViewer.SelectedItem;
                if (po.Status == WorkPackageStatus.Closed || po.Status == WorkPackageStatus.Opened)
                {
                    _toolStripMenuItemClose.Enabled = false;
                    _toolStripMenuItemPublish.Enabled = true;
                }
                else if (po.Status == WorkPackageStatus.Published)
                {
                    _toolStripMenuItemClose.Enabled = true;
                    _toolStripMenuItemPublish.Enabled = false;
                }
                else
                {
                    _toolStripMenuItemClose.Enabled = true;
                    _toolStripMenuItemPublish.Enabled = true;
                }
            }
            else
            {
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
            foreach (PurchaseOrder po in _directivesViewer.SelectedItems)
            {
                if (po.Status != WorkPackageStatus.Closed)
                    GlobalObjects.PurchaseCore.Publish(po, DateTime.Now);
                else
                {
                    switch (MessageBox.Show(@"This request for quotation order is already closed," +
                                             "\nif you want to republish it," +
                                             "\nInformation entered at the closing will be erased." + "\n\n Republish " + po.Title + " purchase order?", (string)new GlobalTermsProvider()["SystemName"],
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
                                        MessageBoxDefaultButton.Button2))
                    {
                        case DialogResult.Yes:
                            GlobalObjects.PurchaseCore.Publish(po, DateTime.Now);
                            AnimatedThreadWorker.RunWorkerAsync();
                            break;
                        case DialogResult.No:
                            //arguments.Cancel = true;
                            break;
                    }
                }
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
            foreach (PurchaseOrder rfq in _directivesViewer.SelectedItems)
            {
                if (rfq.Status == WorkPackageStatus.Closed)
                {
                    MessageBox.Show("Purchase order " + rfq.Title + " is already closed.",
                                    (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    continue;
                }
                GlobalObjects.PurchaseCore.LoadPurchaseOrderItems(rfq);
                PurchaseOrderClosingForm form = new PurchaseOrderClosingForm(rfq);
                if(form.ShowDialog() == DialogResult.OK)
                    AnimatedThreadWorker.RunWorkerAsync();
            }
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
                buttonReleaseToService.Enabled = true;
                headerControl.EditButtonEnabled = true;
            }
            else
            {
                headerControl.EditButtonEnabled= false;
                buttonDeleteSelected.Enabled = false;
                buttonReleaseToService.Enabled = false;
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
                int count = _directivesViewer.SelectedItems.Count;

                List<PurchaseOrder> selectedItems = new List<PurchaseOrder>();
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

        #endregion
    }
}
