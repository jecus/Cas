using System;
using System.Drawing;
using System.Windows.Forms;
using AvControls;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.ComponentControls;
using CAS.UI.UIControls.DetailsControls;
using CAS.UI.UIControls.PersonnelControls;
using CAS.UI.UIControls.PurchaseControls;
using CAS.UI.UIControls.ScheduleControls;
using CAS.UI.UIControls.SupplierControls;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.OpepatorsControls
{
    ///<summary>
    ///</summary>
    public partial class OperatorSummaryScreen : ScreenControl
    {
        #region Fields

        private Operator _currentOperator;

        private ReferenceStatusImageLinkLabel _linkFlightSchedule;

        private ReferenceStatusImageLinkLabel _linkPurchaseOrders;
        private ReferenceStatusImageLinkLabel _products;
        private ReferenceStatusImageLinkLabel _requestForQuotations;
        private ReferenceStatusImageLinkLabel _supplier;
        private ReferenceStatusImageLinkLabel _maintanenceLink;

        private ReferenceStatusImageLinkLabel _linkSpecializations;
        private ReferenceStatusImageLinkLabel _linkPersonnel;

        private ReferenceStatusImageLinkLabel _linkGroundEquipment;

        #endregion

        #region protected Operator CurrentOperator
        /// <summary>
        /// Текущий эксплуатант
        /// </summary>
        public Operator CurrentOperator
        {
            get { return _currentOperator; }
            set { _currentOperator = value; }
        }
        #endregion

        #region Constructors

        #region private OperatorSummaryScreen()
        ///<summary>
        ///</summary>
        private OperatorSummaryScreen()
        {
            InitializeComponent();
        }
        #endregion

        #region public OperatorSummaryScreen(Operator currentOperator)  : this()

        ///<summary>
        /// Создает страницу для отображения информации о всех ВС, складах, и текущих делах оператора
        ///</summary>
        /// <param name="currentOperator">Директива</param>
        public OperatorSummaryScreen(Operator currentOperator)
            : this()
        {
            if (currentOperator == null)
                throw new ArgumentNullException("currentOperator");
            aircraftHeaderControl1.Operator = currentOperator;
            _currentOperator = currentOperator;
            statusControl.ShowStatus = false;
#if !DEBUG
            _vehicles.Visible = false;
            _hangars.Visible = false;
            _workShops.Visible = false;
            _groundEquipmentReferenceContainer.Visible = false;
#endif
            InitOperational();
            InitPersonnel();
            InitPurchase();
            InitGroundEquipment();
            UpdateInformation();
        }

        #endregion

        #endregion

        #region Methods

        #region private void UpdateInformation()
        /// <summary>
        /// Происзодит обновление отображения элементов
        /// </summary>
        private void UpdateInformation()
        {
            _operatorInfoReference.CurrentOperator = _currentOperator;
            _aircrafts.AircraftCollection = 
                new CommonCollection<Aircraft>(GlobalObjects.AircraftsCore.GetAllAircrafts());
            _vehicles.VehiclesCollection =
                new CommonCollection<Vehicle>(GlobalObjects.CasEnvironment.Vehicles.GetValidEntries());
            _stores.Location =  new Point(_aircrafts.Location.X + 400, 4);
            _stores.ItemsCollection = GlobalObjects.CasEnvironment.Stores;

            _hangars.ItemsCollection = GlobalObjects.CasEnvironment.Hangars;
            _workShops.ItemsCollection = GlobalObjects.CasEnvironment.WorkShops;
        }
        #endregion

        #region private void InitOperational()
        private void InitOperational()
        {
#if KAC
            _operationalReferenceContainer.Visible = false;
#else
            _operationalReferenceContainer.Reset();
            //
            // _linkFlightSchedule
            //
            _linkFlightSchedule = new ReferenceStatusImageLinkLabel();
            _linkFlightSchedule.Text = "Flight Schedule";
            _linkFlightSchedule.Enabled = true;
            _linkFlightSchedule.Status = Statuses.NotActive;
            _linkFlightSchedule.Margin = new Padding(1);
            _linkFlightSchedule.ReflectionType = ReflectionTypes.DisplayInNew;
            _linkFlightSchedule.DisplayerRequested += LinkFligthScheduleDisplayerRequested;
            
            _operationalReferenceContainer.AddLink(_linkFlightSchedule);
#endif
        }
        #endregion

        #region private void InitPurchase()
        private void InitPurchase()
        {
            _purchaseReferenceContainer.Reset();
            //
            // linkPurchaseOrders
            //
            _linkPurchaseOrders = new ReferenceStatusImageLinkLabel();
            _linkPurchaseOrders.Text = "Purchase Orders";
            _linkPurchaseOrders.Enabled = true;
            _linkPurchaseOrders.Status = Statuses.NotActive;
            _linkPurchaseOrders.Margin = new Padding(1);
            _linkPurchaseOrders.ReflectionType = ReflectionTypes.DisplayInNew;
            _linkPurchaseOrders.DisplayerRequested += LinkPurchaseOrderDisplayerRequested;
            //
            // _products
            //
            _products = new ReferenceStatusImageLinkLabel();
            _products.Text = "Products";
            _products.Enabled = true;
            _products.Status = Statuses.NotActive;
            _products.Margin = new Padding(1);
            _products.ReflectionType = ReflectionTypes.DisplayInNew;
            _products.DisplayerRequested += LinkProductsDisplayerRequested;
            //
            // Qoutation Orders
            //
            _requestForQuotations = new ReferenceStatusImageLinkLabel();
            _requestForQuotations.Text = "Qoutation Orders";
            _requestForQuotations.Enabled = true;
            _requestForQuotations.Status = Statuses.NotActive;
            _requestForQuotations.Margin = new Padding(1);
            _requestForQuotations.ReflectionType = ReflectionTypes.DisplayInNew;
            _requestForQuotations.DisplayerRequested += LinkRequestForQuotationDisplayerRequested;
            //
            // Supplier
            //
            _supplier = new ReferenceStatusImageLinkLabel();
            _supplier.Text = "Supplier";
            _supplier.Enabled = true;
            _supplier.Status = Statuses.NotActive;
            _supplier.Margin = new Padding(1);
            _supplier.ReflectionType = ReflectionTypes.DisplayInNew;
            _supplier.DisplayerRequested += LinkSupplierDisplayerRequested;
            //
            // MaintanenceLink
            //
            _maintanenceLink = new ReferenceStatusImageLinkLabel();
            _maintanenceLink.Text = "Maintanence";
            _maintanenceLink.Enabled = false;
            _maintanenceLink.Status = Statuses.NotActive;
            _maintanenceLink.Margin = new Padding(1);
            _maintanenceLink.ReflectionType = ReflectionTypes.DisplayInNew;
            _maintanenceLink.DisplayerRequested += linkMaintanence_DisplayerRequested;

            _purchaseReferenceContainer.AddLink(_products);
            _purchaseReferenceContainer.AddLink(_linkPurchaseOrders);
            _purchaseReferenceContainer.AddLink(_requestForQuotations);
            _purchaseReferenceContainer.AddLink(_supplier);
            _purchaseReferenceContainer.AddLink(_maintanenceLink);
        }
        #endregion

        #region private void InitGroundEquipment()
        private void InitGroundEquipment()
        {
            _groundEquipmentReferenceContainer.Reset();
            //
            // _linkGroundEquipment
            //
            _linkGroundEquipment = new ReferenceStatusImageLinkLabel();
            _linkGroundEquipment.Text = "Ground Equip.";
            _linkGroundEquipment.Enabled = true;
            _linkGroundEquipment.Status = Statuses.NotActive;
            _linkGroundEquipment.Margin = new Padding(1);
            _linkGroundEquipment.ReflectionType = ReflectionTypes.DisplayInNew;
            _linkGroundEquipment.DisplayerRequested += LinkGroundEquipmentDisplayerRequested;

            _groundEquipmentReferenceContainer.AddLink(_linkGroundEquipment);
        }
        #endregion

        #region private void InitPersonnel()
        private void InitPersonnel()
        {
            _personnelReferenceContainer.Reset();
            //
            // _linkPersonnel
            //
            _linkPersonnel = new ReferenceStatusImageLinkLabel();
            _linkPersonnel.Text = "Personnel";
            _linkPersonnel.Enabled = true;
            _linkPersonnel.Status = Statuses.NotActive;
            _linkPersonnel.ReflectionType = ReflectionTypes.DisplayInNew;
            _linkPersonnel.DisplayerRequested += LinkPersonnelDisplayerRequested;
            //
            // _linkSpecializations
            //
            _linkSpecializations = new ReferenceStatusImageLinkLabel();
            _linkSpecializations.Text = "Occupations";
            _linkSpecializations.Enabled = true;
            _linkSpecializations.Status = Statuses.NotActive;
            _linkSpecializations.ReflectionType = ReflectionTypes.DisplayInNew;
            _linkSpecializations.DisplayerRequested += LinkSpecializationsDisplayerRequested;

            _personnelReferenceContainer.AddLink(_linkPersonnel);
            _personnelReferenceContainer.AddLink(_linkSpecializations);
        }
        #endregion

        #region public bool GetChangeStatus()

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        public bool GetChangeStatus()
        {
            // Проверяем, изменены ли поля WestAircraft
            return false;
        }

        #endregion

        #region private void HeaderControl1ReloadRised(object sender, EventArgs e)

        private void HeaderControl1ReloadRised(object sender, EventArgs e)
        {
            if (GetChangeStatus())
            {
                if (MessageBox.Show("All unsaved data will be lost. Are you sure you want to continue?",
                                    (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                {
                    return;
                }
            }

            UpdateInformation();
        }
        #endregion

        #region private void LinkFligthScheduleDisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkFligthScheduleDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Flights";
            e.RequestedEntity = new FlightNumberListScreen(GlobalObjects.CasEnvironment.Operators[0], FlightNumberScreenType.Schedule);
        }

        #endregion

        #region private void LinkPurchaseOrderDisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkPurchaseOrderDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Purchase Orders";
            e.RequestedEntity = new PurchaseOrderListScreen(_currentOperator);
        }

        #endregion

        #region private void LinkPersonnelDisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkPersonnelDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Personnel";
            e.RequestedEntity = new PersonnelListScreen(_currentOperator);
        }

        #endregion

        #region private void LinkSpecializationsDisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkSpecializationsDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Specializations";
            e.RequestedEntity = new SpecializationsListScreen(_currentOperator);
        }

        #endregion

        #region private void linkPurchaseRequest_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkPurchaseRequest_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            //e.DisplayerText = "Purchase  Request";
            //e.RequestedEntity = new DispatcheredPurchaseRequestView(GlobalObjects.CasEnvironment.Aircrafts[0]);
        }

        #endregion

        #region private void LinkProductsDisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkProductsDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Products";
            e.RequestedEntity = new CommonListScreen(typeof(Product));
        }

        #endregion

        #region private void LinkRequestForQuotationDisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkRequestForQuotationDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Request For Quotation";
            e.RequestedEntity = new RequestForQuotationListScreen(_currentOperator);
        }

        #endregion

        #region private void LinkSupplierDisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkSupplierDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Supplier";
            e.TypeOfReflection = ReflectionTypes.DisplayInCurrent;
            e.RequestedEntity = new SupplierListScreen(_currentOperator);
        }

        #endregion

        #region private void LinkGroundEquipmentDisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkGroundEquipmentDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            Operator op = GlobalObjects.CasEnvironment.Operators[0];
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.DisplayerText = op.Name + " Ground Equipment";
            e.RequestedEntity = new ComponentsListScreen(op, null);
        }

        #endregion

        #region private void linkMaintanence_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkMaintanence_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            //e.DisplayerText = "Maintanence";
            //e.RequestedEntity = new DispatcheredMaintanenceView(GlobalObjects.CasEnvironment.Aircrafts[0]);

            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.DisplayerText = "test screen";
            //e.RequestedEntity = new AircraftsScreen();
        }

        #endregion

        #endregion
    }
}

