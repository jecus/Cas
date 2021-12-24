using System;
using System.ComponentModel;
using System.Windows.Forms;
using CAA.Entity.Models.DTO;
using CAS.UI.ExcelExport;
using CAS.UI.Interfaces;
using CAS.UI.UICAAControls.Activity;
using CAS.UI.UICAAControls.Document;
using CAS.UI.UICAAControls.Operators;
using CAS.UI.UICAAControls.Specialists;
using CAS.UI.UICAAControls.Users;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.CAA;
using CAS.UI.UIControls.PersonnelControls;
using CASTerms;
using SmartCore.CAA;
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
            e.RequestedEntity = new CAAPersonnelListScreen(_currentOperator);
        }

        #endregion

		private void Users_Click(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Users";
            e.RequestedEntity = new CAAUserListScreen(GlobalObjects.CaaEnvironment.Operators[0]);
        }

        private void Activity_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Activity";
            e.RequestedEntity = new CAAActivityListScreen(GlobalObjects.CaaEnvironment.Operators[0]);
        }


        #region private void LinkDepartmentsDisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkDepartmentsDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Departments";
            e.RequestedEntity = new CAACommonListScreen(typeof(Department));
        }

		#endregion

        #region private void LinkNomenclaturesDisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkNomenclaturesDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Nomenclatures";
            e.RequestedEntity = new CAACommonListScreen(typeof(Nomenclatures));
        }

		#endregion

        #region private void LinkSpecializationsDisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkSpecializationsDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Specializations";
            e.RequestedEntity = new SpecializationsListScreen(_currentOperator);
        }

		#endregion


		private void Operator_Click(object sender, ReferenceEventArgs e)
        {
			e.DisplayerText = "Operators";
            e.RequestedEntity = new CAAOperatorlListScreen(GlobalObjects.CaaEnvironment.Operators[0]);
		}

        private void Aircraft_Click(object sender, ReferenceEventArgs e)
        {
            e.Cancel = true;
        }

        private void Store_Click(object sender, ReferenceEventArgs e)
        {
            e.Cancel = true;
        }

        #region private void LabelDocumentsDisplayerRequested(object sender, ReferenceEventArgs e)

        private void LabelDocumentsDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = CurrentOperator.Name + ". " + "Documents";
            e.RequestedEntity = new CAADocumentationListScreen(GlobalObjects.CaaEnvironment.Operators[0]);
        }

        #endregion


		#endregion

	}
}

