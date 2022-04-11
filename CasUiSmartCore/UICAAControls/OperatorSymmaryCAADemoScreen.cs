﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using CAA.Entity.Models.DTO;
using CAS.UI.ExcelExport;
using CAS.UI.Interfaces;
using CAS.UI.UICAAControls.Activity;
using CAS.UI.UICAAControls.Airacraft;
using CAS.UI.UICAAControls.Audit;
using CAS.UI.UICAAControls.CheckList;
using CAS.UI.UICAAControls.CheckList.CheckListAudit;
using CAS.UI.UICAAControls.Document;
using CAS.UI.UICAAControls.Event;
using CAS.UI.UICAAControls.FindingLevel;
using CAS.UI.UICAAControls.Operators;
using CAS.UI.UICAAControls.RoutineAudit;
using CAS.UI.UICAAControls.Specialists;
using CAS.UI.UICAAControls.StandartManual;
using CAS.UI.UICAAControls.Users;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.CAA;
using CAS.UI.UIControls.PersonnelControls;
using CAS.UI.UIControls.SMSControls;
using CASTerms;
using Entity.Abstractions.Filters;
using SmartCore.CAA;
using SmartCore.CAA.Check;
using SmartCore.CAA.Event;
using SmartCore.CAA.FindingLevel;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;

namespace CAS.UI.UICAAControls
{
	///<summary>
	///</summary>
	public partial class OperatorSymmaryCAADemoScreen : ScreenControl
	{
		#region Fields

		private Operator _currentOperator;
		private ExcelExportProvider _exportProvider;
		private AnimatedThreadWorker _worker;

		#endregion

        #region Constructors

		#region private OperatorSymmaryDemoScreen()
		///<summary>
		///</summary>
		private OperatorSymmaryCAADemoScreen()
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
		public OperatorSymmaryCAADemoScreen(Operator currentOperator)
			: this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");
			aircraftHeaderControl1.Operator = currentOperator;
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
            _operators.OperatorCollection = new CommonCollection<AllOperators>(operators);
            var aircaraft = GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<CAAAircraftDTO, Aircraft>();
            _aircrafts.AircraftCollection = new CommonCollection<Aircraft>(aircaraft);

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
            e.RequestedEntity = new CAAPersonnelListScreen(_currentOperator, -1);
        }

        #endregion

		private void Users_Click(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Users";
            e.RequestedEntity = new CAAUserListScreen(GlobalObjects.CaaEnvironment.Operators[0], -1);
        }

        private void Activity_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Activity";
            e.RequestedEntity = new CAAActivityListScreen(GlobalObjects.CaaEnvironment.Operators[0], -1);
        }


        #region private void LinkDepartmentsDisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkDepartmentsDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.RequestedEntity = new CAACommonListScreen(typeof(Department), new List<Filter>()
            {
                new Filter("OperatorId",-1 )
            });
        }

		#endregion

        #region private void LinkNomenclaturesDisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkNomenclaturesDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Nomenclatures";
            e.RequestedEntity = new CAACommonListScreen(typeof(Nomenclatures), new List<Filter>()
            {
                new Filter("OperatorId",-1 )
            });
        }
        #endregion

        private void LinkFindingLevelsDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Finding Level";
            e.RequestedEntity = new FindingLevelslListScreen(GlobalObjects.CaaEnvironment.Operators[0], -1);
        }

        private void LinkRootCauseDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Root Cause";
            e.RequestedEntity = new CAACommonListScreen(typeof(RootCause), new List<Filter>()
            {
                new Filter("OperatorId",-1 )
            });
        }

        #region private void LinkSpecializationsDisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkSpecializationsDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Specializations";
            e.RequestedEntity = new SpecializationsListScreen(_currentOperator, -1);
        }

		#endregion


		private void Operator_Click(object sender, ReferenceEventArgs e)
        {
			e.DisplayerText = "Operators";
            e.RequestedEntity = new CAAOperatorlListScreen(GlobalObjects.CaaEnvironment.Operators[0]);
		}

        private void Aircraft_Click(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Aircrafts";
            e.RequestedEntity = new CAAAircraftListScreen(GlobalObjects.CaaEnvironment.Operators[0]);
        }

        #region private void LabelDocumentsDisplayerRequested(object sender, ReferenceEventArgs e)

        private void LabelDocumentsDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = CurrentOperator.Name + ". " + "Documents";
            e.RequestedEntity = new CAADocumentationListScreen(GlobalObjects.CaaEnvironment.Operators[0], -1);
        }

        #endregion


		#endregion

        private void LinkCheckListsDisplayerRequested(object sender, ReferenceEventArgs e)
        {
	        e.DisplayerText = "Standart Manual";
	        e.RequestedEntity = new StandartManualListScreen(GlobalObjects.CaaEnvironment.Operators[0], -1);
        }


        private void LinkRoutineAuditDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Routine Audit";
            e.RequestedEntity = new RoutineAuditListScreen(GlobalObjects.CaaEnvironment.Operators[0], -1);
        }

        private void LinkAuditDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Audit CAA";
            e.RequestedEntity = new AuditListScreen(GlobalObjects.CaaEnvironment.Operators[0], -1, AuditType.CAA, CheckListAuditType.User);
        }

        private void LinkAuditOpDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Audit Operator";
            e.RequestedEntity = new AuditListScreen(GlobalObjects.CaaEnvironment.Operators[0], -1, AuditType.Operator, CheckListAuditType.User);
        }

        private void LinkAuditAllDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Audit All";
            e.RequestedEntity = new AuditListScreen(GlobalObjects.CaaEnvironment.Operators[0],-1,  AuditType.All, CheckListAuditType.User);
        }

        private void LinkStandartManualDisplayerRequested(object sender, ReferenceEventArgs e)
        {
	        e.DisplayerText = "Standart Manual";
	        e.RequestedEntity = new StandartManualListScreen(GlobalObjects.CaaEnvironment.Operators[0], -1);
        }

        private void LinkAuditManagmentDisplayerRequested(object sender, ReferenceEventArgs e)
        {
	        e.DisplayerText = "Audit Management";
	        e.RequestedEntity = new AuditListScreen(GlobalObjects.CaaEnvironment.Operators[0], -1,AuditType.All, CheckListAuditType.Admin, true);
        }

        private void LinkOccurenceReReportRequested(object sender, ReferenceEventArgs e)
        {
	        e.Cancel = true;
        }

        private void LinkConcessionRequestLinkRequested(object sender, ReferenceEventArgs e)
        {
	        e.Cancel = true;
        }

        private void EventsLinkRequested(object sender, ReferenceEventArgs e)
        {
	        e.Cancel = true;
        }

        private void LinkDirectiveLinkRequested(object sender, ReferenceEventArgs e)
        {
	        e.Cancel = true;
        }

        private void LinkPersonnelTrainingRequested(object sender, ReferenceEventArgs e)
        {
	        e.Cancel = true;
        }

        private void LinkAuditRiskManagmentRequested(object sender, ReferenceEventArgs e)
        {
	        e.Cancel = true;
        }

        private void LinkEventsRequested(object sender, ReferenceEventArgs e)
        {
	        e.DisplayerText = "Events";
	        e.RequestedEntity = new CAAEventsListScreen(GlobalObjects.CaaEnvironment.Operators[0], -1);
        }
        
        private void LinkEventsCategoriesRequested(object sender, ReferenceEventArgs e)
        {
	        e.DisplayerText = "Events Categories";
	        e.RequestedEntity = new CAACommonListScreen(typeof(CAAEventCategory), new List<Filter>()
	        {
		        new Filter("OperatorId",-1 )
	        });
        }
        
        private void LinkEventsClassesRequested(object sender, ReferenceEventArgs e)
        {
	        e.DisplayerText = "Events Classes";
	        e.RequestedEntity = new CAACommonListScreen(typeof(CAAEventClass), new List<Filter>()
	        {
		        new Filter("OperatorId",-1 )
	        });
        }
        
        private void LinkEventsTypesRequested(object sender, ReferenceEventArgs e)
        {
	        e.DisplayerText = "Events Types";
	        e.RequestedEntity = new CAAEventTypesListScreen(GlobalObjects.CaaEnvironment.Operators[0], -1);
        }
	}
}

