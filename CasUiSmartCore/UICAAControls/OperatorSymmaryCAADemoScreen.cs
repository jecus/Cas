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




		#endregion

	}
}

