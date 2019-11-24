using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.ComponentControls;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using TempUIExtentions;

namespace CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls
{
    ///<summary>
    /// ЭУ для отображения суммарной информации по компоненту самолета
    ///</summary>
    public partial class BaseComponentSummary : UserControl
    {
        #region Fields

        private BaseComponent _currentComponent;
        private ComponentCollection _baseComponentComponents;
        private List <BaseComponentDirectiveSummaryControl> _componentDirectivesPerformances;

        #endregion

        #region Properties

        ///<summary>
        ///</summary>
        public BaseComponent CurrentComponent
        {
            set
            {
                _currentComponent = value;
                UpdateInformation();
            }
        }

        #region public bool EnableExtendedControl
        ///<summary>
        ///</summary>
        public bool EnableExtendedControl
        {
            get { return panelExtendable.Visible; }
            set
            {
                panelExtendable.Visible = value;
                if (value == false) _mainPanel.Visible = true;
            }
        }
        #endregion

        #endregion

        #region Constructor

        ///<summary>
        /// конструктор по умолчанию для простого создания ЭУ
        ///</summary>
        public BaseComponentSummary()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Создает объект отображающий краткую информацию о компоненте
        /// </summary>
        /// <param name="currentComponent/param>
        public BaseComponentSummary(BaseComponent currentComponent)
            : this()
        {
            _currentComponent = currentComponent;
            _componentDirectivesPerformances = new List<BaseComponentDirectiveSummaryControl>();

            UpdateInformation();
        }

		#endregion

		#region Methods

		#region ppublic void SetParameters(BaseComponent currentComponent, ComponentCollection componentComponents = null)
		/// <summary>
		/// Задает параметры контрола
		/// </summary>
		/// <param name="currentComponent">компонент, информацию которого требуется отобразить</param>
		/// <param name="componentComponents">Коллекция компонентов, связанных с основным компонентом</param>
		public void SetParameters(BaseComponent currentComponent, ComponentCollection componentComponents = null)
        {
            _currentComponent = currentComponent;

            if(_baseComponentComponents != componentComponents)
            {
                if(_baseComponentComponents != null && _baseComponentComponents.Count > 0)
                    _baseComponentComponents.Clear();
                if (componentComponents != null)
                    _baseComponentComponents = componentComponents;
            }

            UpdateInformation();
        }
        #endregion

        #region private void UpdateInformation()
        /// <summary>
        /// Заполняет краткую информацию о директиве 
        /// </summary>
        private void UpdateInformation()
        {
            if (_currentComponent == null)
                return;
            if (_componentDirectivesPerformances == null)
                _componentDirectivesPerformances = new List<BaseComponentDirectiveSummaryControl>();
            else _componentDirectivesPerformances.Clear();
            //очищение плавающей панели и списка контролов отображения директив деталей
            flowLayoutPanel_Compliance.Controls.Clear();

            referenceLinkLabelLLPStatus.Visible = _currentComponent.BaseComponentType == BaseComponentType.Engine;

            var inspectedBaseComponent = _currentComponent;

            var baseComponentTypeString = inspectedBaseComponent.BaseComponentType.ToString();
            var baseComponentModelString = inspectedBaseComponent.Model != null
                                               ? " " + inspectedBaseComponent.Model
                                               : "";
            var engineThrustString = 
                inspectedBaseComponent.BaseComponentType == BaseComponentType.Engine && 
                !string.IsNullOrEmpty(inspectedBaseComponent.Thrust)
                                            ? "/" +inspectedBaseComponent.Thrust
                                            : "";

            extendableRichContainer.Caption = baseComponentTypeString + baseComponentModelString + engineThrustString
                              //+ " P/N:" + _currentComponent.PartNumber
                              + " S/N:" + _currentComponent.SerialNumber
                              + " M/P:" + _currentComponent.MaintenanceControlProcess.ShortName
                              + " Pos:" + _currentComponent.TransferRecords.GetLast().Position;

            referenceLinkLabelBaseDetail.Text = baseComponentTypeString;


            labelCompntTCSN.Text = baseComponentTypeString + " Total:";
            labelCompntInstallDate.Text = baseComponentTypeString + " install date:";
            labelCompntTCSNonInstall.Text = baseComponentTypeString + " on Install:";
            labelCompntTCSNsinceInstall.Text = baseComponentTypeString + " since Install:";


            labelRemarksValue.Text = inspectedBaseComponent.Remarks;
            labelManufactureDateValue.Text = SmartCore.Auxiliary.Convert.GetDateFormat(inspectedBaseComponent.ManufactureDate);
            labelWarrantyValue.Text = inspectedBaseComponent.Warranty.ToString();

            labelCompntInstallDateValue.Text = SmartCore.Auxiliary.Convert.GetDateFormat(inspectedBaseComponent.TransferRecords.GetLast().TransferDate);
            Lifelength temp, temp2;
            //Наработка компонента на сегодня
            temp = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(inspectedBaseComponent);
            labelCompntTCSNValue.Text = temp.ToString();

            //Остаток жизненного времени на сегодня
            temp2 = new Lifelength(inspectedBaseComponent.LifeLimit);
            temp2.Substract(temp);
            temp2.Resemble(inspectedBaseComponent.LifeLimit);


            if (inspectedBaseComponent.BaseComponentType == BaseComponentType.Engine)
            {
                Component firstLimitter = _baseComponentComponents != null && _baseComponentComponents.Count > 0
                                           ? _baseComponentComponents.Where(d => d.NextPerformanceDate != null)
                                                 .OrderBy(d => d.NextPerformanceDate)
                                                 .FirstOrDefault()
                                           : null;

                labelCompntLifeLimit.Text = baseComponentTypeString + " Life Limit / First Limit";

                labelCompntLifeLimitValue.Text =
                    ((inspectedBaseComponent.LifeLimit.IsNullOrZero() ? "N/A" : inspectedBaseComponent.LifeLimit.ToString()) +
                     " / " +
                     (firstLimitter == null || firstLimitter.LifeLimit.IsNullOrZero() ? "N/A" : firstLimitter.LifeLimit.ToString()));

                labelCompntLifeLimitRemains.Text = baseComponentTypeString + " Life Limit Remain / First Remains";

                labelCompntLifeLimitRemainsValue.Text =
                    ((inspectedBaseComponent.Remains.IsNullOrZero() ? "N/A" : inspectedBaseComponent.Remains.ToString()) +
                     " / " +
                     (firstLimitter == null || firstLimitter.Remains.IsNullOrZero() ? "N/A" : firstLimitter.Remains.ToString()));
            }
            else
            {
                labelCompntLifeLimit.Text = baseComponentTypeString + " Life Limit";
                labelCompntLifeLimitValue.Text = inspectedBaseComponent.LifeLimit.ToString();
                labelCompntLifeLimitRemains.Text = baseComponentTypeString + " Life Limit Remain";
                labelCompntLifeLimitRemainsValue.Text = temp2.ToString();
            }

	        var lastTransferRecord = inspectedBaseComponent.TransferRecords.GetLast();
			//Наработка компонента на момент установки
			temp2 = lastTransferRecord.OnLifelength;
			labelCompntTCSNonInstallValue.Text = temp2.ToString();

            //Наработка компонента с момента установки и по сей день
            temp.Substract(temp2);
            labelCompntTCSNsinceInstallValue.Text = temp.ToString();

	        var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(inspectedBaseComponent.ParentAircraftId);
            //Наработка самолета на сегодня
            temp = parentAircraft != null
                       ? GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(parentAircraft)
                       : Lifelength.Zero;
            labelAircraftTCSNValue.Text = temp.ToString();

            //Наработка самолета на момент установки детали
            temp = parentAircraft != null
                       ? GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(GlobalObjects.ComponentCore.GetBaseComponentById(parentAircraft.AircraftFrameId),
																			                   lastTransferRecord.TransferDate)
                       : Lifelength.Zero;
            labelAircraftTCSNonInstallValue.Text = temp.ToString();

            //Обновление таблиц выполнения директив
            //На каждую из директив детали создается отдельная таблица выполнения
            //После каждая таблица помещается в плавающую панель для отображения

            var componentDirectives = new List<ComponentDirective>(_currentComponent.ComponentDirectives.ToArray());
            for (int i = 0; i < componentDirectives.Count; i++)
            {
                var summaryCompliancePerformanceControl = new BaseComponentDirectiveSummaryControl(componentDirectives[i]);
                
                summaryCompliancePerformanceControl.UpdateInformation();
                
                _componentDirectivesPerformances.Add(summaryCompliancePerformanceControl);
                flowLayoutPanel_Compliance.Controls.Add(summaryCompliancePerformanceControl);
            }          
        }

        #endregion

        #region private void ExtendableRichContainerExtending(object sender, EventArgs e)
        private void ExtendableRichContainerExtending(object sender, EventArgs e)
        {
            _mainPanel.Visible = extendableRichContainer.Extended;
        }
        #endregion

        #region private void ReferenceLinkLabelBaseDetailDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)

        private void ReferenceLinkLabelBaseDetailDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
        {
            e.DisplayerText = $"{_currentComponent.GetParentAircraftRegNumber()}. Component SN {_currentComponent.SerialNumber}";
			e.RequestedEntity = new ComponentScreenNew(_currentComponent);
        }
        #endregion

        #region private void ReferenceLinkLabelComponentsDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)

        private void ReferenceLinkLabelComponentsDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
        {
            e.DisplayerText = _currentComponent + ". Component Status";
            e.RequestedEntity = new ComponentsListScreen(_currentComponent, MaintenanceControlProcess.Items.ToArray(), false);
        }
		#endregion

		#region private void ReferenceLinkLabelLLPStatusDisplayerRequested(object sender, ReferenceEventArgs e)

		private void ReferenceLinkLabelLLPStatusDisplayerRequested(object sender, ReferenceEventArgs e)
	    {
		    e.DisplayerText = _currentComponent + ". LLP Disc Sheet Status";
		    e.RequestedEntity = new ComponentsListScreen(_currentComponent, MaintenanceControlProcess.Items.ToArray(), true);
	    }

	    #endregion

		#endregion
	}
}

