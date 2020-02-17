using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.ExcelExport;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.CommercialControls;
using CAS.UI.UIControls.ComponentControls;
using CAS.UI.UIControls.DirectivesControls;
using CAS.UI.UIControls.Discrepancies;
using CAS.UI.UIControls.DocumentationControls;
using CAS.UI.UIControls.ForecastControls;
using CAS.UI.UIControls.MailControls;
using CAS.UI.UIControls.MaintenanceControlCenterControls;
using CAS.UI.UIControls.MonthlyUtilizationsControls;
using CAS.UI.UIControls.PersonnelControls;
using CAS.UI.UIControls.PurchaseControls;
using CAS.UI.UIControls.PurchaseControls.AllOrders;
using CAS.UI.UIControls.PurchaseControls.Quatation;
using CAS.UI.UIControls.QualityAssuranceControls;
using CAS.UI.UIControls.Reliability;
using CAS.UI.UIControls.ScheduleControls;
using CAS.UI.UIControls.ScheduleControls.AircraftStatus;
using CAS.UI.UIControls.ScheduleControls.PlanOPS;
using CAS.UI.UIControls.SupplierControls;
using CAS.UI.UIControls.Users;
using CAS.UI.UIControls.WorkPakage;
using CASReports.Builders;
using CASTerms;
using EntityCore.Filter;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Mail;

namespace CAS.UI.UIControls.OpepatorsControls
{
	///<summary>
	///</summary>
	public partial class OperatorSymmaryDemoScreen : ScreenControl
	{
		#region Fields

		private Operator _currentOperator;
		private ExcelExportProvider _exportProvider;
		private AnimatedThreadWorker _worker;

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

		#region private OperatorSymmaryDemoScreen()
		///<summary>
		///</summary>
		private OperatorSymmaryDemoScreen()
		{
			InitializeComponent();
			DoubleBuffered = true;
		}
		#endregion

		#region public OperatorSymmaryDemoScreen(Operator currentOperator)  : this()

		///<summary>
		/// Создает страницу для отображения информации о всех ВС, складах, и текущих делах оператора
		///</summary>
		/// <param name="currentOperator">Директива</param>
		public OperatorSymmaryDemoScreen(Operator currentOperator)
			: this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");
			aircraftHeaderControl1.Operator = currentOperator;
			_currentOperator = currentOperator;
			statusControl.ShowStatus = false;
#if KAC
			_vehicles.Visible = false;
			_hangars.Visible = false;
			_workShops.Visible = false;
#endif
			

			InitOperational();
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
			_stores.Location =  new Point(_aircrafts.Location.X + 400, 4);
			_stores.ItemsCollection = GlobalObjects.CasEnvironment.Stores;
			workStationCollectionControl1.ItemsCollection = GlobalObjects.CasEnvironment.WorkStations;

#if !KAC
			_vehicles.VehiclesCollection =
				new CommonCollection<Vehicle>(GlobalObjects.CasEnvironment.Vehicles.GetValidEntries());
			_hangars.ItemsCollection = GlobalObjects.CasEnvironment.Hangars;
			_workShops.ItemsCollection = GlobalObjects.CasEnvironment.WorkShops;
#endif
		}
#endregion

		#region private void InitOperational()
		private void InitOperational()
		{
#if DEBUG
			_operationalReferenceContainer.Visible = true;
#endif
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

		private void LinkAircraftStatusDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = "Aircraft Status";
			e.RequestedEntity = new AircraftStatusListScreen(GlobalObjects.CasEnvironment.Operators[0]);
		}
		private void LinkFligthPlanOPSDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = "PlanOPS";
			e.RequestedEntity = new FlightPlanOpsListScreen(GlobalObjects.CasEnvironment.Operators[0]);
		}

		#region private void LinkFligthScheduleDisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkFligthScheduleDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = "Schedule Flights";
			e.RequestedEntity = new FlightNumberListScreen(GlobalObjects.CasEnvironment.Operators[0], FlightNumberScreenType.Schedule);
		}

		#endregion

		#region private void LinkFligthUnScheduleDisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkFligthUnScheduleDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = "UnSchedule Flights";
			e.RequestedEntity = new FlightNumberListScreen(GlobalObjects.CasEnvironment.Operators[0], FlightNumberScreenType.UnSchedule);
		}

		#endregion

		#region private void SchedulePeriodDisplayerRequested(object sender, ReferenceEventArgs e)

		private void SchedulePeriodDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			var periodForm = new SchedulePeriodForm();
			periodForm.ShowDialog();
			e.Cancel = true;
		}

		#endregion

		#region private void LinkPurchaseOrderDisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkPurchaseOrderDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = "Purchase Orders";
			e.RequestedEntity = new PurchaseOrderListScreen(_currentOperator);
		}

		#endregion

		#region private void LinkPurchaseOrderDisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkRequestOffersDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = "Request Offers";
			e.RequestedEntity = new RequestOffersListScreen(_currentOperator);
		}

		#endregion

		#region private void LinkLinkPurchaseStatusDisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkLinkPurchaseStatusDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = "Purchase Status";
			e.RequestedEntity = new PurchaseStatusListScreen(_currentOperator);
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
			e.DisplayerText = "Equipment and Materials";
			e.RequestedEntity = new ProductListScreen(CurrentOperator);
		}

		#endregion

		private void LinkComponentModelsDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = "Component Models";
			e.RequestedEntity = new CommonListScreen(typeof(ComponentModel));
		}

		private void LinkAllProductsDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = "Products";
			e.RequestedEntity = new AllProductListScreen(CurrentOperator);
		}

		#region private void LinkOrders_DisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)

		private void LinkOrders_DisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = CurrentOperator.Name + " All Orders";
			e.RequestedEntity = new AllOrderListScreen(_currentOperator);
		}

		#endregion

		#region private void LinkInitialOrderDisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkInitialOrderDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = CurrentOperator.Name + " Initial Orders";
			e.RequestedEntity = new InitialOrderListScreen(_currentOperator);
		}

		#endregion

		#region private void LinkRequestForQuotationDisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkRequestForQuotationDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = "Request For Quotation";
			e.RequestedEntity = new RequestForQuotationListScreen(_currentOperator);
		}

		#endregion

		#region private void LinkMaintenanceControlCenterDisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkMaintenanceControlCenterDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = "Maintenance Control Center";
			e.TypeOfReflection = ReflectionTypes.DisplayInCurrent;
			e.RequestedEntity = new MaintenanceControlCenterScreen(_currentOperator);
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

		private void LinkSupplierComponentsDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = "Processing";
			e.TypeOfReflection = ReflectionTypes.DisplayInCurrent;
			e.RequestedEntity = new ProcessingListScreen(_currentOperator);
		}

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

		#region private void linkReport_DisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkReportDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			e.DisplayerText = "Air International. Air Fleet.";
			e.RequestedEntity = new ReportScreen(new AirFleetBuilder(GlobalObjects.AircraftsCore.GetAllAircrafts().ToList()));
		}

		#endregion

		#region private void LinkForecastAllAircraftDisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkForecastAllAircraftDisplayerRequested(object sender, ReferenceEventArgs e)
		{

			#region --Проверка--
			foreach (var item in GlobalObjects.AircraftsCore.GetAllAircrafts())
			{
				var averageUtilization = GlobalObjects.AverageUtilizationCore.GetAverageUtillization(item);

				if (averageUtilization == null || averageUtilization.CyclesPerMonth == 0 || averageUtilization.HoursPerMonth == 0)
				{
					if (MessageBox.Show("Average Utilization for aircraft " + item.RegistrationNumber + " is not set. Do you want to set it?", "", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
					{
						AverageUtilizationForm form = new AverageUtilizationForm(item);
						form.ShowDialog();
					}
				}

				averageUtilization = GlobalObjects.AverageUtilizationCore.GetAverageUtillization(item);
				if (averageUtilization == null || averageUtilization.CyclesPerMonth == 0 || averageUtilization.HoursPerMonth == 0)
				{
					MessageBox.Show(
						"Average Utilization for aircraft " + item.RegistrationNumber + " is not set. Abort operation",
						"", MessageBoxButtons.OK);
					e.Cancel = true;
					return;
				}
			}
			#endregion

			var tempArray = new List<Aircraft>();
			var temp = new ForecastFilterAircraft();
			temp.ShowDialog();
			if (temp.FilteAircraft != null)
			{
				tempArray.AddRange(temp.FilteAircraft.ToArray());
			}
			else
			{
				e.Cancel = true;
				MessageBox.Show("not selected item");
				return;

			}
			e.DisplayerText = "All Aircraft Forecast";
			e.RequestedEntity = new AirFleetForecastListScreen(tempArray);

		}

		#endregion

		#region private void LinkAllWorkPackagesDisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkAllWorkPackagesDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = "Work packages";
			e.RequestedEntity = new AirFleetWorkPackageListScreen(GlobalObjects.CasEnvironment.Operators[0]);
		}

		#endregion

		#region private void LinkDepartmentsDisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkDepartmentsDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = "Departments";
			e.RequestedEntity = new CommonListScreen(typeof (Department));
		}

		#endregion

		#region private void LinkProceduresDisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkProceduresDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = "Procedures";
			e.RequestedEntity = new ProceduresListScreen(GlobalObjects.CasEnvironment.Operators[0]);
		}

		#endregion

		#region private void LinkAuditsDisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkAuditsDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = CurrentOperator.Name + " Audits";
			e.RequestedEntity = new AuditListScreen(GlobalObjects.CasEnvironment.Operators[0]);
		}

		#endregion

		#region private void LinkWorkOrdersDisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkWorkOrdersDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = CurrentOperator.Name + " Work Orders";
			e.RequestedEntity = new WorkOrderListScreen(GlobalObjects.CasEnvironment.Operators[0]);
		}

		#endregion

		#region private void LinkRequestsDisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkRequestsDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = CurrentOperator.Name + " Requests";
			e.RequestedEntity = new RequestListScreen(GlobalObjects.CasEnvironment.Operators[0]);
		}

		#endregion

		#region private void LabelDocumentsDisplayerRequested(object sender, ReferenceEventArgs e)

		private void LabelDocumentsDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = CurrentOperator.Name + ". " + "Documents";
			e.RequestedEntity = new DocumentationListScreen(GlobalObjects.CasEnvironment.Operators[0]);
		}

		#endregion

		private void LinkRecords_DisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			e.DisplayerText = "MailChatScreen";
			e.RequestedEntity = new MailChatListScreen(GlobalObjects.CasEnvironment.Operators[0]);
		}

		private void LinkInternalDocuments_DisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			e.DisplayerText = "InternalDocumentScreen";
			e.RequestedEntity = new MailListScreen(GlobalObjects.CasEnvironment.Operators[0], new MailRecords {DocClass = DocumentClass.InternalDoc, MailChatId = -1});
		}

		#region private void LinkNomenclaturesDisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkNomenclaturesDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = "Nomenclatures";
			e.RequestedEntity = new CommonListScreen(typeof(Nomenclatures));
		}

		#endregion

		#endregion

		#region  private void LinkOccurencesDisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkOccurencesDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = "Occurrences and Interruptions";
			e.RequestedEntity = new OccurrencesListScreen(GlobalObjects.CasEnvironment.Operators[0]);
		}

		#endregion

		#region  private void LinkEventDisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkEventDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = "Event";
			e.RequestedEntity = new EventListScreen(GlobalObjects.CasEnvironment.Operators[0]);
		}

		#endregion

		#region  private void LinkDefectDisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkDefectDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = "Defects";
			e.RequestedEntity = new DefectListScreen(GlobalObjects.CasEnvironment.Operators[0]);
		}

		#endregion

		#region private void LinkSystemDisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkSystemDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = "System reliability";
			e.RequestedEntity = new SystemListScreen(GlobalObjects.CasEnvironment.Operators[0]);
		}

		#endregion

		#region private void LinkComponentsDisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkComponentsDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = "Components reliability";
			e.RequestedEntity = new SystemListScreen(GlobalObjects.CasEnvironment.Operators[0]);
		}

		#endregion

		#region private void LinkDefferedDefectsDisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkDefferedDefectsDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = "Deferred defects";
			e.RequestedEntity = new DefferedListScreen(GlobalObjects.CasEnvironment.Operators[0]);
		}

		#endregion

		private void Users_Click(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = "Users";
			e.RequestedEntity = new UserListScreen(GlobalObjects.CasEnvironment.Operators[0]);
		}

		#region Export

		private void ExportMonthly_Click(object sender, EventArgs e)
		{
			_worker = new AnimatedThreadWorker();
			_worker.DoWork += Worker_DoWork;
			_worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
			_worker.RunWorkerAsync();
		}

		private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			var sfd = new SaveFileDialog();
			sfd.Filter = ".xlsx Files (*.xlsx)|*.xlsx";

			if (sfd.ShowDialog() == DialogResult.OK)
			{
				_exportProvider.SaveTo(sfd.FileName);
				MessageBox.Show("File was success saved!");
			}

			_exportProvider.Dispose();
		}

		private void Worker_DoWork(object sender, DoWorkEventArgs e)
		{
			var t = new TimeSpan();
			for (int i = 0; i < 5; i++)
			{
				t+= new TimeSpan(25,40,0);
			}

			AnimatedThreadWorker.ReportProgress(0, "load directives");
			_worker.ReportProgress(0,"Generate file! Please wait....");

			_exportProvider = new ExcelExportProvider();
			_exportProvider.ReportProgress += (o, args) =>
			{
				_worker.ReportProgress(0, $"Generate page for {o}");
			};
			_worker.ReportProgress(0, "Finish");
			_exportProvider.ExportFlights();
		}

		private void ExportATLB_Click(object sender, EventArgs e)
		{
			_worker = new AnimatedThreadWorker();
			_worker.DoWork += ExportATLBWork;
			_worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
			_worker.RunWorkerAsync();
		}

		private void ExportATLBWork(object sender, DoWorkEventArgs e)
		{
			AnimatedThreadWorker.ReportProgress(0, "load ATLB");
			_worker.ReportProgress(0, "Generate file! Please wait....");

			_exportProvider = new ExcelExportProvider();
			
			_exportProvider.ExportATLB();


		}

		#endregion


		private void Activity_DisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = "Activity";
			e.RequestedEntity = new ActivityListScreen(GlobalObjects.CasEnvironment.Operators[0]);
		}

		private void LinkDocumentPurchase_DisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = "Documents";
			e.RequestedEntity = new DocumentationListScreen(GlobalObjects.CasEnvironment.Operators[0], new List<Filter>()
			{
				new Filter("ServiceTypeId", 7)
			});
		}

		private void LinkInvoice_DisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = "Invoice";
			e.RequestedEntity = new DocumentationListScreen(GlobalObjects.CasEnvironment.Operators[0], new List<Filter>()
			{
				new Filter("ServiceTypeId", 7),
				new Filter("DocTypeId", DocumentType.Invoice.ItemId)
			});
		}

		private void Purchase_DisplayerRequested(object sender, ReferenceEventArgs e)
		{
			var form = new PurchaseSettingForm();
			form.ShowDialog();
			e.Cancel = true;
		}

		private void QuotationSupp_DisplayerRequested(object sender, ReferenceEventArgs e)
		{
			var form = new QuotationSupplierForAllForm();
			form.ShowDialog();
			e.Cancel = true;
		}

		private void mail_DisplayerRequested(object sender, ReferenceEventArgs e)
		{
			var form = new MailSettingFrom();
			form.ShowDialog();
			e.Cancel = true;
		}
	}
}

