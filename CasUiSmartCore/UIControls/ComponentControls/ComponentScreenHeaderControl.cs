using System;
using System.Windows.Forms;
using AvControls;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.ComponentControls
{
    public partial class ComponentScreenHeaderControl : UserControl
    {
        private object _currentDetail;
        
        public ComponentScreenHeaderControl()
        {
            InitializeComponent();
        }

        public ComponentScreenHeaderControl(object currentDetail)
        {
            _currentDetail = currentDetail;

            InitializeComponent();

            UpdateInformation();
        }

        #region Methods

        #region public void UpdateInformation()
        /// <summary>
        /// Заполняет краткую информацию о директиве 
        /// </summary>
        public void UpdateInformation()
        {
            if (_currentDetail == null)
                return;

            Component inspectedComponent;
            if (_currentDetail is Component)
            {
                inspectedComponent = (Component) _currentDetail;
                ConditionState cond;
                cond = GlobalObjects.PerformanceCalculator.GetConditionState(inspectedComponent);

                if (cond == ConditionState.NotEstimated)
                {
                    imageLinkLabelComponentStatus.Text = "Status: Not active";
                    imageLinkLabelComponentStatus.Status = Statuses.NotActive;
                }
                else if (cond == ConditionState.Satisfactory)
                {
                    imageLinkLabelComponentStatus.Text = "Status: Satisfactory";
                    imageLinkLabelComponentStatus.Status = Statuses.Satisfactory;
                }
                else if (cond == ConditionState.Notify)
                {
                    imageLinkLabelComponentStatus.Text = "Status: Notify";
                    imageLinkLabelComponentStatus.Status = Statuses.Notify;
                }
                else if (cond == ConditionState.Overdue)
                {
                    imageLinkLabelComponentStatus.Text = "Status: Overdue";
                    imageLinkLabelComponentStatus.Status = Statuses.NotSatisfactory;
                }

                labelDateAsOfValue.Text = SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today);
                //Наработка самолета на сегодня
                Lifelength temp;
	            var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(inspectedComponent.ParentAircraftId);
                temp = parentAircraft != null
                    ? GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(parentAircraft)
                    : Lifelength.Zero;
                labelAircraftTCSNValue.Text = temp.ToString();
            }
            else
            {
                BaseComponent inspectedBaseComponent = (BaseComponent) _currentDetail;
				var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(inspectedBaseComponent.ParentAircraftId);
				labelDateAsOfValue.Text = SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today);
                //Наработка самолета на сегодня
                Lifelength temp;
                temp = parentAircraft != null
                    ? GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(parentAircraft)
                    : Lifelength.Zero;
                labelAircraftTCSNValue.Text = temp.ToString();  
            }
        }

        #endregion

        #endregion
    }
}
