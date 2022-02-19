using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CAA.Entity.Models.DTO;
using CAS.UI.ExcelExport;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.UICAAControls.Activity;
using CAS.UI.UICAAControls.Airacraft;
using CAS.UI.UICAAControls.Audit;
using CAS.UI.UICAAControls.CheckList;
using CAS.UI.UICAAControls.Document;
using CAS.UI.UICAAControls.Operators;
using CAS.UI.UICAAControls.RoutineAudit;
using CAS.UI.UICAAControls.Specialists;
using CAS.UI.UICAAControls.Users;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.CAA;
using CAS.UI.UIControls.PersonnelControls;
using CASTerms;
using Entity.Abstractions.Filters;
using SmartCore.CAA;
using SmartCore.CAA.FindingLevel;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;

namespace CAS.UI.UICAAControls
{
	///<summary>
	///</summary>
	public partial class CurrentOperatorSymmaryCAADemoScreen : ScreenControl
	{
		#region Fields

		private AllOperators _currentOperator;
		private ExcelExportProvider _exportProvider;
		private AnimatedThreadWorker _worker;

		#endregion

        #region Constructors

		#region private OperatorSymmaryDemoScreen()
		///<summary>
		///</summary>
		private CurrentOperatorSymmaryCAADemoScreen()
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
		public CurrentOperatorSymmaryCAADemoScreen(AllOperators currentOperator)
			: this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");
			aircraftHeaderControl1.Operator = new Operator()
            {
                Address = currentOperator.Address,
                Email = currentOperator.Email,
                LogoTypeImage = currentOperator.LogoTypeImage,
                LogoTypeWhiteImage = currentOperator.LogoTypeWhiteImage,
                LogotypeReportLargeImage = currentOperator.LogotypeReportLargeImage,
                LogotypeReportVeryLargeImage = currentOperator.LogotypeReportVeryLargeImage,
                Name = currentOperator.FullName
            };
			_currentOperator = currentOperator;
			statusControl.ShowStatus = false;

            _worker = new AnimatedThreadWorker();
            _worker.DoWork += Worker_DoWork;
            _worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
			_worker.RunWorkerAsync();
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
        }
        #endregion

		#region private void HeaderControl1ReloadRised(object sender, EventArgs e)

		private void HeaderControl1ReloadRised(object sender, EventArgs e)
		{
            _worker.RunWorkerAsync();
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var operators = GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<AllOperatorsDTO, AllOperators>();
            var aircaraft = GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<CAAAircraftDTO, Aircraft>();
            _aircrafts.AircraftCollection = new CommonCollection<Aircraft>(aircaraft.Where(i => i.OperatorId == _currentOperator.ItemId));

            GlobalObjects.CaaEnvironment.AllOperators = new List<AllOperators>(operators);
            GlobalObjects.CaaEnvironment.Aircraft = new AircraftCollection(aircaraft);
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
			UpdateInformation();
		}

		#endregion

		#region private void LinkPersonnelDisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkPersonnelDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Personnel";
            e.RequestedEntity = new CAAPersonnelListScreen(_getOperator(), _currentOperator.ItemId);
        }

        #endregion


        #region private void LinkDepartmentsDisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkDepartmentsDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Departments";
            e.RequestedEntity = new CAACommonListScreen(typeof(Department), new List<Filter>()
            {
                new Filter("OperatorId",_currentOperator.ItemId )
            }) { OperatorId = _currentOperator.ItemId };
        }

		#endregion

        #region private void LinkNomenclaturesDisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkNomenclaturesDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Nomenclatures";
            e.RequestedEntity = new CAACommonListScreen(typeof(Nomenclatures), new List<Filter>()
                {
                    new Filter("OperatorId",_currentOperator.ItemId )
                })
                { OperatorId = _currentOperator.ItemId };
        }
        #endregion

        private void LinkFindingLevelsDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Finding Level";
            e.RequestedEntity = new CAACommonListScreen(typeof(FindingLevels), new List<Filter>()
                {
                    new Filter("OperatorId",_currentOperator.ItemId )
                })
                { OperatorId = _currentOperator.ItemId };
        }

        private void LinkRootCauseDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Root Cause";
            e.RequestedEntity = new CAACommonListScreen(typeof(RootCause), new List<Filter>()
                {
                    new Filter("OperatorId",_currentOperator.ItemId )
                })
                { OperatorId = _currentOperator.ItemId };
        }

        #region private void LinkSpecializationsDisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkSpecializationsDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Specializations";
            e.RequestedEntity = new SpecializationsListScreen(_getOperator(), _currentOperator.ItemId);
        }

		#endregion


        private void Aircraft_Click(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Aircrafts";
            e.RequestedEntity = new CAAAircraftListScreen(_getOperator());
        }

        private void Store_Click(object sender, ReferenceEventArgs e)
        {
            e.Cancel = true;
        }

        #region private void LabelDocumentsDisplayerRequested(object sender, ReferenceEventArgs e)

        private void LabelDocumentsDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = CurrentOperator.Name + ". " + "Documents";
            e.RequestedEntity = new CAADocumentationListScreen(_getOperator(), _currentOperator.ItemId);
        }

        #endregion


        private void Users_Click(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Users";
            e.RequestedEntity = new CAAUserListScreen(_getOperator(), _currentOperator.ItemId);
        }

        private void Activity_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Activity";
            e.RequestedEntity = new CAAActivityListScreen(_getOperator(), _currentOperator.ItemId);
        }


        #endregion

        private void LinkCheckListsDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "CheckList";
            e.RequestedEntity = new CheckListsScreen(_getOperator(), _currentOperator.ItemId);
        }


        private void LinkRoutineAuditDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Routine Audit";
            e.RequestedEntity = new RoutineAuditListScreen(_getOperator(), _currentOperator.ItemId);
        }

        private void LinkAuditDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Audit Operator";
            e.RequestedEntity = new AuditListScreen(_getOperator(), _currentOperator.ItemId);
        }


        private Operator _getOperator()
        {
            return GlobalObjects.CaaEnvironment.AllOperators.FirstOrDefault(i => i.ItemId == _currentOperator.ItemId).ToOperator();
        }

        private void LinkStandartManualDisplayerRequested(object sender, ReferenceEventArgs e)
        {
	        e.Cancel = true;
        }
	}
}

