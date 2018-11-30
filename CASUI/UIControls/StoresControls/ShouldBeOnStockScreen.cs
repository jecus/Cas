using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core;
using CAS.Core.Types;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports;
using CAS.UI.Properties;
using CAS.UI.UIControls.Auxiliary;
using CASReports.Builders;
using CASTerms;
using Controls;
using Controls.AvButtonT;
using Controls.AvMultitabControl;
using Controls.AvMultitabControl.Auxiliary;
using Controls.StatusImageLink;

namespace CAS.UI.UIControls.StoresControls
{
    /// <summary>
    /// Элемент управления для отображения списка агрегатов, которые должны быть на складе
    /// </summary>
    [ToolboxItem(false)]
    public class ShouldBeOnStockScreen : Control, IReference
    {

        #region Fields

        private readonly Store currentStore;
        private readonly Operator currentOperator;

        private StockDetailInfo stockDetailInfoBeforeSave;
        private StockDetailInfo stockDetailInfoBeforeReload;

        /*private readonly StoreDetailFilterSelectionForm filterSelection;
        //private readonly DetailCollectionFilter initialFilter;
        private DetailCollectionFilter additionalFilter = new DetailCollectionFilter(new DetailFilter[0]);*/

        private OperatorHeaderControl operatorHeaderControl;
        private AvButtonT buttonAddRecord;
        private AvButtonT buttonDeleteSelected;
        private ShouldBeOnStockListView shouldBeOnStockDetailsViewer;
        private ContextMenuStrip contextMenuStrip;
        private FooterControl footerControl;
        private HeaderControl headerControl;
        /// <summary>
        /// Панель содержащая кнопки управления
        /// </summary>
        protected Panel panelTopContainer;
        private StatusImageLinkLabel statusImageLinkLabel;

        private ToolStripMenuItem toolStripMenuItemTitle;
        private ToolStripMenuItem toolStripMenuItemAdd;
        private ToolStripMenuItem toolStripMenuItemDelete;
        //private ToolStripMenuItem toolStripMenuItemHighlight;
        private ToolStripSeparator toolStripSeparator1;

        private readonly Icons icons = new Icons();

        private IDisplayer displayer;
        private string displayerText;
        private IDisplayingEntity entity;
        private ReflectionTypes reflectionType;
        //private readonly bool permissionForUpdate = true;
        private readonly bool permissionForDelete = true;
        private readonly bool permissionForCreate = true;

        #endregion

        #region Constructors

        #region public ShouldBeOnStockScreen(Store store)

        /// <summary>
        /// Создает элемент управления для отображения списка агрегатов, которые должны быть на складе
        /// </summary>
        public ShouldBeOnStockScreen(Store store)
        {
            if (store == null)
                throw new ArgumentNullException("store", "Cannot display null-currentStore");
            //((DispatcheredStoreScreen) this).InitComplition += StoreScreen_InitComplition;
            currentStore = store;
            InitializeComponent();
            HookStockDetailInfosCollection();
            HookStockDetailInfos();
            UpdateInformation();
        }

        #endregion

        #region public ShouldBeOnStockScreen(Operator op)

        /// <summary>
        /// Создает элемент управления для отображения списка агрегатов, которые должны быть на складе
        /// </summary>
        public ShouldBeOnStockScreen(Operator op)
        {
            if (op == null)
                throw new ArgumentNullException("op", "Cannot display null-currentStore");
            currentOperator = op;
//            currentStore = store;
            InitializeComponent();
            HookStockDetailInfosCollection();
            HookStockDetailInfos();
            UpdateInformation();
        }

        #endregion

        #endregion

        #region Methods

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            panelTopContainer = new Panel();
            buttonDeleteSelected = new AvButtonT();
            buttonAddRecord = new AvButtonT();
            footerControl = new FooterControl();
            headerControl = new HeaderControl();
            if (currentStore != null)
            {
                operatorHeaderControl = new OperatorHeaderControl(currentStore.Operator, true);
                shouldBeOnStockDetailsViewer = new ShouldBeOnStockListView(currentStore);
            }
            else
            {
                operatorHeaderControl = new OperatorHeaderControl(currentOperator, true);
                shouldBeOnStockDetailsViewer = new ShouldBeOnStockListView(currentOperator);
            }
            statusImageLinkLabel = new StatusImageLinkLabel();
            
            #region Context menu

            contextMenuStrip = new ContextMenuStrip();
            toolStripMenuItemTitle = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMenuItemAdd = new ToolStripMenuItem();
            toolStripMenuItemDelete = new ToolStripMenuItem();
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[]
                                                 {
                                                     toolStripMenuItemTitle,
                                                     toolStripSeparator1,
                                                     toolStripMenuItemAdd,
                                                     toolStripMenuItemDelete
                                                 });
            contextMenuStrip.Size = new Size(179, 176);
            // 
            // toolStripMenuItemTitle
            // 
            toolStripMenuItemTitle.Text = "Edit";
            toolStripMenuItemTitle.Click += toolStripMenuItemEdit_Click;
            // 
            // toolStripMenuItemAdd
            // 
            toolStripMenuItemAdd.Text = "Add Component";
            toolStripMenuItemAdd.Click += toolStripMenuItemAdd_Click;
            // 
            // toolStripMenuItemDelete
            // 
            toolStripMenuItemDelete.Size = new Size(178, 22);
            toolStripMenuItemDelete.Text = "Delete";
            toolStripMenuItemDelete.Click += toolStripMenuItemDelete_Click;

            #endregion

            // 
            // panelTopContainer
            // 
            panelTopContainer.AutoSize = true;
            panelTopContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelTopContainer.BackColor = Color.FromArgb(211,211,211);
            panelTopContainer.Controls.Add(statusImageLinkLabel);
            panelTopContainer.Controls.Add(buttonAddRecord);
            panelTopContainer.Controls.Add(buttonDeleteSelected);
            panelTopContainer.Dock = DockStyle.Top;
            panelTopContainer.Location = new Point(0, 0);
            panelTopContainer.Name = "panelTopContainer";
            panelTopContainer.Size = new Size(1042, 62);
            panelTopContainer.TabIndex = 14;
            // 
            // buttonAddRecord
            // 
            buttonAddRecord.ActiveBackColor = Color.FromArgb(200, 200, 200);
            buttonAddRecord.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddRecord.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddRecord.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddRecord.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddRecord.Icon = icons.Add;
            buttonAddRecord.IconNotEnabled = icons.AddGray;
            buttonAddRecord.Size = new Size(140, 59);
            buttonAddRecord.TabIndex = 15;
            buttonAddRecord.TextAlignMain = ContentAlignment.BottomCenter;
            buttonAddRecord.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonAddRecord.TextMain = "Add new";
            buttonAddRecord.TextSecondary = "record";
            buttonAddRecord.Click += buttonAddRecord_Click;
            buttonAddRecord.Enabled = currentStore != null;
            // 
            // buttonDeleteSelected
            // 
            buttonDeleteSelected.ActiveBackColor = Color.FromArgb(200, 200, 200);
            buttonDeleteSelected.Enabled = false;
            buttonDeleteSelected.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteSelected.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteSelected.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteSelected.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteSelected.Icon = icons.Delete;
            buttonDeleteSelected.IconNotEnabled = icons.DeleteGray;
            buttonDeleteSelected.PaddingSecondary = new Padding(4, 0, 0, 0);
            buttonDeleteSelected.Size = new Size(145, 59);
            buttonDeleteSelected.TabIndex = 20;
            buttonDeleteSelected.TextAlignMain = ContentAlignment.BottomLeft;
            buttonDeleteSelected.TextAlignSecondary = ContentAlignment.TopLeft;
            buttonDeleteSelected.TextMain = "Delete";
            buttonDeleteSelected.TextSecondary = "selected";
            buttonDeleteSelected.Click += buttonDeleteSelected_Click;
            // 
            // footerControl
            // 
            footerControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            footerControl.BackColor = Color.Transparent;
            footerControl.Dock = DockStyle.Bottom;
            footerControl.Location = new Point(0, 568);
            footerControl.Margin = new Padding(0);
            footerControl.MaximumSize = new Size(0, 48);
            footerControl.MinimumSize = new Size(0, 48);
            footerControl.Name = "footerControl";
            footerControl.Size = new Size(1042, 48);
            footerControl.TabIndex = 10;
            // 
            // headerControl
            // 
            headerControl.ActionControlSplitterVisible = true;
            headerControl.ContextActionControl.ShowPrintButton = true;
            headerControl.BackColor = Color.Transparent;
            headerControl.BackgroundImage = Resources.HeaderBar;
            headerControl.Controls.Add(operatorHeaderControl);
            headerControl.Dock = DockStyle.Top;
            headerControl.EditDisplayerText = "Component Status Operator";
            headerControl.EditReflectionType = ReflectionTypes.DisplayInNew;
            headerControl.Location = new Point(0, 0);
            headerControl.Name = "headerControl";
            headerControl.Size = new Size(1042, 58);
            headerControl.TabIndex = 6;
            headerControl.ContextActionControl.ButtonPrint.DisplayerRequested += PrintButton_DisplayerRequested;
            headerControl.ReloadRised += headerControl1_ReloadRised;
            headerControl.ContextActionControl.ButtonHelp.TopicID = "component-status.html";
            headerControl.ActionControl.ShowEditButton = false;
            // 
            // statusImageLinkLabel
            // 
            statusImageLinkLabel.ActiveLinkColor = Color.Black;
            statusImageLinkLabel.Enabled = false;
            statusImageLinkLabel.HoveredLinkColor = Color.Black;
            statusImageLinkLabel.ImageBackColor = Color.Transparent;
            statusImageLinkLabel.ImageLayout = ImageLayout.Center;
            statusImageLinkLabel.LinkColor = Color.DimGray;
            statusImageLinkLabel.LinkMouseCapturedColor = Color.Empty;
            statusImageLinkLabel.Location = new Point(28, 3);
            statusImageLinkLabel.Margin = new Padding(0);
            statusImageLinkLabel.Name = "statusImageLinkLabel";
            statusImageLinkLabel.Size = new Size(412, 27);
            statusImageLinkLabel.Status = Statuses.Satisfactory;
            statusImageLinkLabel.TabIndex = 16;
            statusImageLinkLabel.Text = "Component Status";
            statusImageLinkLabel.TextAlign = ContentAlignment.MiddleLeft;
            statusImageLinkLabel.TextFont = new Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            //
            // shouldBeOnStockDetailsViewer
            //
            shouldBeOnStockDetailsViewer.ContextMenuStrip = contextMenuStrip;
            shouldBeOnStockDetailsViewer.Location = new Point(panelTopContainer.Left, panelTopContainer.Bottom);
            shouldBeOnStockDetailsViewer.Size = new Size(Width, Height - headerControl.Height - footerControl.Height - panelTopContainer.Height);
            shouldBeOnStockDetailsViewer.SelectedItemsChanged += componentStatusesViewer_SelectedItemsChanged;
            // 
            // ComponentStatusControl
            // 
            BackColor = Color.FromArgb(241, 241, 241);
            Controls.Add(footerControl);
            Controls.Add(panelTopContainer);
            Controls.Add(shouldBeOnStockDetailsViewer);
            Controls.Add(headerControl);
            Size = new Size(1042, 616);
        }

        #endregion

        #region private void buttonDeleteSelected_Click(object sender, EventArgs e)

        private void buttonDeleteSelected_Click(object sender, EventArgs e)
        {
            if ((shouldBeOnStockDetailsViewer.SelectedItems == null) && (shouldBeOnStockDetailsViewer.SelectedItem == null))
                return;
            DialogResult confirmResult = MessageBox.Show(shouldBeOnStockDetailsViewer.SelectedItem != null ? "Do you really want to delete record " + shouldBeOnStockDetailsViewer.SelectedItem.PartNumber + "?"
                        : "Do you really want to delete selected records? ", "Confirm delete operation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (confirmResult == DialogResult.Yes)
            {
                    int count = shouldBeOnStockDetailsViewer.SelectedItems.Count;
                    try
                    {
                        List<StockDetailInfo> selectedItems = new List<StockDetailInfo>(shouldBeOnStockDetailsViewer.SelectedItems);
                        shouldBeOnStockDetailsViewer.ItemsListView.BeginUpdate();
                        if (currentStore != null)
                            for (int i = 0; i < count; i++)
                                currentStore.RemoveStockDetailInfo(selectedItems[i]);
                        else
                        {
                            for (int i = 0; i < count; i++)
                            {
                                Store parentStore = (Store) selectedItems[i].Parent;
                                parentStore.RemoveStockDetailInfo(selectedItems[i]);
                            }
                        }
                        shouldBeOnStockDetailsViewer.ItemsListView.EndUpdate();
                    }
                    catch (Exception ex)
                    {
                        Program.Provider.Logger.Log("Error while deleting data", ex); 
                        return;
                    }
            }
        }

        #endregion

        #region public virtual void UpdateElements()

        /// <summary>
        /// Происходит обновление отображения элементов
        /// </summary>
        public virtual void UpdateInformation()
        {
            if (currentStore != null)
                statusImageLinkLabel.Text = currentStore.RegistrationNumber + ": Should be on stock";
            else
                statusImageLinkLabel.Text = currentOperator.Name + ": Should be on stock";
            shouldBeOnStockDetailsViewer.UpdateItems();
            HookStockDetailInfos();
            buttonAddRecord.Enabled = (currentStore != null && permissionForCreate);
            toolStripMenuItemAdd.Enabled = permissionForCreate;

            SetContextMenuParameters(shouldBeOnStockDetailsViewer.SelectedItems.Count);

            headerControl.ContextActionControl.ButtonPrint.Enabled = shouldBeOnStockDetailsViewer.ItemsListView.Items.Count != 0;
        }

        #endregion
        
        #region private void headerControl_ReloadRised(object sender, EventArgs e)

        private void headerControl1_ReloadRised(object sender, EventArgs e)
        {
            ReloadElements();
        }

        #endregion

        #region protected void OnDisplayerRequested()

        /// <summary>
        /// 
        /// </summary>
        protected void OnDisplayerRequested(ReferenceEventArgs e)
        {
            if (null != DisplayerRequested)
            {
                DisplayerRequested(this, e);
            }
        }

        #endregion
        
        #region private void buttonAddRecord_Click(object sender, EventArgs e)

        private void buttonAddRecord_Click(object sender, EventArgs e)
        {
            StockDetailInfoForm form = new StockDetailInfoForm(currentStore);
            form.Show();
        }

        #endregion

        #region protected void ReloadElements()

        /// <summary>
        /// Происходит перезагрузка элементов и синхронизация с базой данных
        /// </summary>
        protected void ReloadElements()
        {
            try
            {
                if (currentStore != null)
                    currentStore.Reload(true);            
                else
                {
                    for (int i = 0; i < currentOperator.Stores.Count; i++)
                        currentOperator.Stores[i].Reload(true);
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while loading data", ex);
                return;
            }
            UpdateInformation();
        }

        #endregion

        #region private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void PrintButton_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                
            if (currentStore != null)
            {
                e.DisplayerText = currentStore.RegistrationNumber + ". Should be on stock report";
                e.RequestedEntity = new DispatcheredShouldBeOnStockReport(new ShouldBeOnStockBuilder(currentStore));
            }
            else
            {
                e.DisplayerText = currentOperator.Name + ". Should be on stock report";
                e.RequestedEntity = new DispatcheredShouldBeOnStockReport(new ShouldBeOnStockBuilder(currentOperator));
            }
        }

        #endregion

        #region private void componentStatusesViewer_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

        private void componentStatusesViewer_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            SetContextMenuParameters(e.ItemsCount);
        }

        #endregion

        


        #region private void SetContextMenuParameters(int count)

        private void SetContextMenuParameters(int count)
        {
            //toolStripMenuItemAdd.Enabled = buttonAddRecord.Enabled = StockDetailInfoCollection HasAccess(Users.CurrentUser.Role, DataEvent.Create);
            toolStripMenuItemTitle.Enabled = count == 1;
            buttonDeleteSelected.Enabled = permissionForDelete && (count > 0);
            toolStripMenuItemDelete.Enabled = buttonDeleteSelected.Enabled;

/*            bool highlight = false;
            bool allHighlight = true;
            for (int i = 0; i < shouldBeOnStockDetailsViewer.SelectedItems.Count; i++)
            {
                if (shouldBeOnStockDetailsViewer.SelectedItems[i].Highlight)
                    highlight = true;
                else
                    allHighlight = false;
            }
            if (allHighlight)
                toolStripMenuItemHighlight.CheckState = CheckState.Checked;
            else if (highlight)
                toolStripMenuItemHighlight.CheckState = CheckState.Indeterminate;
            else
                toolStripMenuItemHighlight.CheckState = CheckState.Unchecked;*/
        }

        #endregion

        #region private void toolStripMenuItemEdit_Click(object sender, EventArgs e)

        private void toolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            if (shouldBeOnStockDetailsViewer.SelectedItem != null)
            {
                StockDetailInfoForm form = new StockDetailInfoForm(shouldBeOnStockDetailsViewer.SelectedItem);
                form.ShowDialog();
            }
        }

        #endregion

        #region private void toolStripMenuItemHighlight_Click(object sender, EventArgs e)

        private void toolStripMenuItemHighlight_Click(object sender, EventArgs e)
        {
/*            for (int i = 0; i < shouldBeOnStockDetailsViewer.SelectedItems.Count; i++)
            {
                shouldBeOnStockDetailsViewer.SelectedItems[i].Highlight = toolStripMenuItemHighlight.Checked;
                shouldBeOnStockDetailsViewer.SelectedItems[i].Save(true);
            }*/
        }
        
        #endregion

        #region private void toolStripMenuItemAdd_Click(object sender, EventArgs e)

        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            StockDetailInfoForm form = new StockDetailInfoForm(currentStore);
            form.Show();
        }

        #endregion

        #region private void toolStripMenuItemDelete_Click(object sender, EventArgs e)

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            buttonDeleteSelected_Click(sender, e);
        }

        #endregion

        #region public void CloseFilter()

        /// <summary>
        /// Закрытие формы выбора фильтра
        /// </summary>
        public void CloseFilter()
        {
         //   filterSelection.Close();
        }

        #endregion




        #region private void UnHookStockDetailInfos()

        private void UnHookStockDetailInfos()
        {
            StockDetailInfo[] stockDetailInfos = shouldBeOnStockDetailsViewer.GetItemsArray();
            for (int i = 0; i < stockDetailInfos.Length; i++)
            {
                UnHookStockDetailInfo(stockDetailInfos[i]);
            }
        }
        
        #endregion

        #region private void UnHookStockDetailInfo(CoreType stockDetailInfo)

        private void UnHookStockDetailInfo(CoreType stockDetailInfo)
        {
            stockDetailInfo.Saving -= stockDetailInfo_Saving;
            stockDetailInfo.Saved -= stockDetailInfo_Saved;
            stockDetailInfo.Reloading -= stockDetailInfo_Reloading;
            stockDetailInfo.Reloaded -= stockDetailInfo_Reloaded;

        }

        #endregion

        #region private void HookStockDetailInfos()

        private void HookStockDetailInfos()
        {
            StockDetailInfo[] stockDetailInfos = shouldBeOnStockDetailsViewer.GetItemsArray();
            for (int i = 0; i < stockDetailInfos.Length; i++)
            {
                UnHookStockDetailInfo(stockDetailInfos[i]);
                HookStockDetailInfo(stockDetailInfos[i]);
            }
        }

        #endregion

        #region private void HookStockDetailInfo(CoreType stockDetailInfo)

        private void HookStockDetailInfo(CoreType stockDetailInfo)
        {
            stockDetailInfo.Saving += stockDetailInfo_Saving;
            stockDetailInfo.Saved += stockDetailInfo_Saved;
            stockDetailInfo.Reloading += stockDetailInfo_Reloading;
            stockDetailInfo.Reloaded += stockDetailInfo_Reloaded;
        }

        #endregion

        #region private void HookStockDetailInfosCollection()

        private void HookStockDetailInfosCollection()
        {
            UnHookStockDetailInfosCollection();
            if (currentStore != null)
            {
                currentStore.StockDetailInfoAdded += currentStore_StockDetailInfoAdded;
                currentStore.StockDetailInfoRemoved += currentStore_StockDetailInfoRemoved;
            }
            else
            {
                for (int i = 0; i < currentOperator.Stores.Count; i++)
                {
                    currentOperator.Stores[i].StockDetailInfoAdded += currentStore_StockDetailInfoAdded;
                    currentOperator.Stores[i].StockDetailInfoRemoved += currentStore_StockDetailInfoRemoved;    
                }
            }
        }

        #endregion

        #region private void UnHookStockDetailInfosCollection()

        private void UnHookStockDetailInfosCollection()
        {
            if (currentStore != null)
            {
                currentStore.DetailRemoved -= currentStore_StockDetailInfoRemoved;
                currentStore.BaseDetailRemoved -= currentStore_StockDetailInfoRemoved;
                currentStore.DetailAdded -= currentStore_StockDetailInfoAdded;
                currentStore.BaseDetailAdded -= currentStore_StockDetailInfoAdded;
            }
            else
            {
                for (int i = 0; i < currentOperator.Stores.Count; i++)
                {
                    currentOperator.Stores[i].DetailRemoved -= currentStore_StockDetailInfoRemoved;
                    currentOperator.Stores[i].BaseDetailRemoved -= currentStore_StockDetailInfoRemoved;
                    currentOperator.Stores[i].DetailAdded -= currentStore_StockDetailInfoAdded;
                    currentOperator.Stores[i].BaseDetailAdded -= currentStore_StockDetailInfoAdded;
                }
            }
        }

        #endregion

        #region private void stockDetailInfo_Saving(object sender, CancelEventArgs e)

        private void stockDetailInfo_Saving(object sender, CancelEventArgs e)
        {
            stockDetailInfoBeforeSave = (StockDetailInfo)sender;
        }

        #endregion

        #region private void stockDetailInfo_Saved(object sender, EventArgs e)

        private void stockDetailInfo_Saved(object sender, EventArgs e)
        {
            shouldBeOnStockDetailsViewer.EditItem(stockDetailInfoBeforeSave, (StockDetailInfo)sender);
        }

        #endregion

        #region private void stockDetailInfo_Reloading(object sender, CancelEventArgs e)

        private void stockDetailInfo_Reloading(object sender, CancelEventArgs e)
        {
            if (!InvokeRequired)
                stockDetailInfoBeforeReload = (StockDetailInfo)sender;
        }

        #endregion

        #region private void stockDetailInfo_Reloaded(object sender, EventArgs e)

        private void stockDetailInfo_Reloaded(object sender, EventArgs e)
        {
            if (!InvokeRequired)
                shouldBeOnStockDetailsViewer.EditItem(stockDetailInfoBeforeReload, (StockDetailInfo)sender);
        }

        #endregion

        #region private void currentStore_StockDetailInfoAdded(object sender, CollectionChangeEventArgs e)

        private void currentStore_StockDetailInfoAdded(object sender, CollectionChangeEventArgs e)
        {
            shouldBeOnStockDetailsViewer.AddNewItem((StockDetailInfo)e.Element);
            HookStockDetailInfo((StockDetailInfo)e.Element);
        }

        #endregion

        #region private void currentStore_StockDetailInfoRemoved(object sender, CollectionChangeEventArgs e)

        private void currentStore_StockDetailInfoRemoved(object sender, CollectionChangeEventArgs e)
        {
            shouldBeOnStockDetailsViewer.DeleteItem((StockDetailInfo)e.Element);
            UnHookStockDetailInfo((StockDetailInfo)e.Element);
        }

        #endregion



        #region private void StoreScreen_InitComplition(object sender, EventArgs e)

        private void StoreScreen_InitComplition(object sender, EventArgs e)
        {
            ((DispatcheredMultitabControl)sender).Closed += control_Closed;
            ((AvMultitabControl)sender).Selected += ComponentStatusControl_Selected;
        }

        #endregion
        
        #region private void ComponentStatusControl_Selected(object sender, AvMultitabControlEventArgs e)

        private void ComponentStatusControl_Selected(object sender, AvMultitabControlEventArgs e)
        {
            shouldBeOnStockDetailsViewer.ItemsListView.Focus();
        }

        #endregion
        
        #region private void control_Closed(object sender, AvMultitabControlEventArgs e)

        private void control_Closed(object sender, AvMultitabControlEventArgs e)
        {
            if (e.TabPage == Parent as DispatcheredTabPage)
            {
                UnHookStockDetailInfos();
                UnHookStockDetailInfosCollection();
            }
        }

        #endregion

        #region protected override void OnSizeChanged(EventArgs e)

        ///<summary>
        ///Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged"></see> event.
        ///</summary>
        ///
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (buttonDeleteSelected != null)
                buttonDeleteSelected.Location = new Point(Width - buttonDeleteSelected.Width - 5, 0);
            if (buttonAddRecord != null)
                buttonAddRecord.Location = new Point(buttonDeleteSelected.Left - buttonAddRecord.Width - 5, 0);

            if (shouldBeOnStockDetailsViewer != null)
            {
                shouldBeOnStockDetailsViewer.Location = new Point(panelTopContainer.Left, panelTopContainer.Bottom);
                shouldBeOnStockDetailsViewer.Size =
                    new Size(Width,
                             Height - headerControl.Height - footerControl.Height - panelTopContainer.Height);
            }
        }

        #endregion

        #endregion

        #region IRefernce Members

                #region public IDisplayer Displayer

        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        public IDisplayer Displayer
        {
            get { return displayer; }
            set { displayer = value; }
        }

        /// <summary>
        /// Text of page's header that Reference lead to
        /// </summary>
        public string DisplayerText
        {
            get { return displayerText; }
            set { displayerText = value; }
        }

        #endregion

        #region public DisplayingEntity Entity

        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        /// <summary>
        /// Type of reflection [:|||:]
        /// </summary>
        public ReflectionTypes ReflectionType
        {
            get { return reflectionType; }
            set { reflectionType = value; }
        }

        #endregion

        #region Events

        #region public event EventHandler<ReferenceEventArgs> DisplayerRequested

        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        #endregion

        #endregion

        #endregion

    }
}