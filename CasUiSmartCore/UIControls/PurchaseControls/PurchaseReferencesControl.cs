using System;
using System.Drawing;
using System.Windows.Forms;
using Auxiliary;
using AvControls;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.ReferenceControls;

namespace CAS.UI.UIControls.PurchaseControls
{
    /// <summary>
    /// Элемент управления для отображения коллекции ссылок для ВС и его отчетов
    /// </summary>
    public class PurchaseReferencesControl:RichReferenceContainer
    {

        #region Fields

        private ReferenceStatusImageLinkLabel _linkPurchaseOrders;
        private ReferenceStatusImageLinkLabel _requestForQuotations;
        private ReferenceStatusImageLinkLabel _supplier;
        private ReferenceStatusImageLinkLabel _maintanenceLink;

        private FlowLayoutPanel _flowLayoutPanelContainer;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения коллекции ссылок для ВС и его отчетов
        /// </summary>
        public PurchaseReferencesControl()
        {
            InitializeComponent();
        }

        #endregion
        
        #region Methods

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            _linkPurchaseOrders = new ReferenceStatusImageLinkLabel();
            _requestForQuotations=new ReferenceStatusImageLinkLabel();
            _supplier=new ReferenceStatusImageLinkLabel();
            _maintanenceLink=new ReferenceStatusImageLinkLabel();
            //linkSSIDStatus = new ReferenceStatusImageLinkLabel();

            _flowLayoutPanelContainer = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // flowLayoutPanelContainer
            // 
            _flowLayoutPanelContainer.AutoSize = true;
            _flowLayoutPanelContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _flowLayoutPanelContainer.FlowDirection = FlowDirection.TopDown;
            _flowLayoutPanelContainer.Dock = DockStyle.Top;
            _flowLayoutPanelContainer.Location = new Point(208, 43);
            _flowLayoutPanelContainer.Name = "_flowLayoutPanelContainer";
            _flowLayoutPanelContainer.TabIndex = 1;
             //
            // linkPurchaseOrders
            //
            _linkPurchaseOrders.Text = "Purchase Orders";
            _linkPurchaseOrders.Margin = new Padding(5);
            _linkPurchaseOrders.Enabled = true;
            _linkPurchaseOrders.Status = Statuses.NotActive;
            _linkPurchaseOrders.Margin = new Padding(1);
            _linkPurchaseOrders.ReflectionType = ReflectionTypes.DisplayInNew;
            _linkPurchaseOrders.DisplayerRequested += linkPurchaseOrder_DisplayerRequested;
            Css.ImageLink.Adjust(_linkPurchaseOrders);
            //
            // linkPurchaseRequest
            //
            _requestForQuotations.Text = "Qoutation Orders";
            _requestForQuotations.Margin = new Padding(5);
            _requestForQuotations.Enabled = true;
            _requestForQuotations.Status = Statuses.NotActive;
            _requestForQuotations.Margin = new Padding(1);
            _requestForQuotations.ReflectionType = ReflectionTypes.DisplayInNew;
            _requestForQuotations.DisplayerRequested += linkRequestForQuotations_DisplayerRequested;
            Css.ImageLink.Adjust(_requestForQuotations);
            //
            // Supplier
            //
            _supplier.Text = "Supplier";
            _supplier.Margin = new Padding(5);
            _supplier.Enabled = true;
            _supplier.Status = Statuses.NotActive;
            _supplier.Margin = new Padding(1);
            _supplier.ReflectionType = ReflectionTypes.DisplayInNew;
            _supplier.DisplayerRequested += linkSupplier_DisplayerRequested;
            Css.ImageLink.Adjust(_supplier);
            //
            // MaintanenceLink
            //
            _maintanenceLink.Text = "Maintanence";
            _maintanenceLink.Margin = new Padding(5);
            _maintanenceLink.Enabled = true;
            _maintanenceLink.Status = Statuses.NotActive;
            _maintanenceLink.Margin = new Padding(1);
            _maintanenceLink.ReflectionType = ReflectionTypes.DisplayInNew;
            _maintanenceLink.DisplayerRequested += linkMaintanence_DisplayerRequested;
            Css.ImageLink.Adjust(_maintanenceLink);
            
            
            _flowLayoutPanelContainer.Controls.Add(_linkPurchaseOrders);
            _flowLayoutPanelContainer.Controls.Add(_requestForQuotations);
            _flowLayoutPanelContainer.Controls.Add(_supplier);
            _flowLayoutPanelContainer.Controls.Add(_maintanenceLink);
            // 
            // AircraftReferencesControl
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            MainControl = _flowLayoutPanelContainer;
            Name = "PurchaseReferencesControl";
            Size = new Size(411, 146);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        #region private void linkPurchaseOrder_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkPurchaseOrder_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkPurchaseOrderDisplayerRequested != null) LinkPurchaseOrderDisplayerRequested(sender, e);
        }

        #endregion

        #region private void linkRequestForQuotations_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkRequestForQuotations_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkRequestForQuotationsDisplayerRequested != null) LinkRequestForQuotationsDisplayerRequested(sender, e);
        }

        #endregion

        #region private void linkSupplier_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkSupplier_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkSupplierDisplayerRequested != null) LinkSupplierDisplayerRequested(sender, e);
        }

        #endregion

        #region private void linkMaintanence_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkMaintanence_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (LinkMaintanenceDisplayerRequested != null) LinkMaintanenceDisplayerRequested(sender, e);
        }

        #endregion

        #region protected override void OnEnabledChanged(EventArgs e)

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            
            _linkPurchaseOrders.Enabled = Enabled;
            //linkSSIDStatus.Enabled = Enabled;
            
        }

        #endregion

        #endregion

        #region Events

        #region public event EventHandler<ReferenceEventArgs> LinkPurchaseOrderDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке Purchase Orders
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkPurchaseOrderDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkRequestForQuotationsDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке Purchase Orders
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkRequestForQuotationsDisplayerRequested;
        
        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkSupplierDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке Purchase Orders
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkSupplierDisplayerRequested;

        #endregion

        #region public event EventHandler<ReferenceEventArgs> LinkMaintanenceDisplayerRequested;

        /// <summary>
        /// Событие перехода по ссылке Purchase Orders
        /// </summary>
        public event EventHandler<ReferenceEventArgs> LinkMaintanenceDisplayerRequested;

        #endregion

        

        #endregion

    }
}