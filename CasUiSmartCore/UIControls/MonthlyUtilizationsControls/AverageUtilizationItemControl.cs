using System;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.MonthlyUtilizationsControls
{
    ///<summary>
    /// ЭУ для редактирования средней утилизации указанного базового агрегата 
    ///</summary>
    public partial class AverageUtilizationItemControl : UserControl
    {
        private BaseComponent _currentBaseComponent;

        #region Properties
        ///<summary>
        /// Меняет текст названия базовой детали
        ///</summary>
        public string DetailNameText
        {
            set { labelBaseDetailName.Text = value; }
        }

	    public string LabelHoursText
		{
            set { labelHours.Text = value; }
        }

	    public string LabelCyclesText
		{
		    set { labelCycles.Text = value; }
	    }

	    public bool ShowCycDay
	    {
		    set
		    {
			    numericUpDown1.Visible = value;
			    label1.Visible = value;
		    }
	    }

		public bool ShowRadioButtons
	    {
		    set
		    {
			    radioButtonDayly.Visible = value;
			    radioButtonMonthly.Visible = value;
		    }
	    }

        ///<summary>
        /// Возвращает базовую деталь переданную в конструкторе
        ///</summary>
        public BaseComponent CurrentBaseComponent
        {
            get { return _currentBaseComponent; }
        }
        #endregion

        #region Constructors

        #region public AverageUtilizationItemControl()
        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        public AverageUtilizationItemControl()
        {
            InitializeComponent();
        }
        #endregion

        #region public AverageUtilizationItemControl(BaseDetail baseDetail) : this()
        ///<summary>
        /// Конструктор создает форму для указанной базовой детали
        ///</summary>
        public AverageUtilizationItemControl(BaseComponent baseComponent) : this()
        {
            _currentBaseComponent = baseComponent;
            UpdateInformation();
        }
        #endregion

        #endregion

	    public void UpdateControl(BaseComponent baseComponent)
	    {
		    _currentBaseComponent = baseComponent;
		    UpdateInformation();
		}

        #region private void UpdateInformation()

        private void UpdateInformation()
        {
            if(_currentBaseComponent == null)return;
            if (_currentBaseComponent.AverageUtilization.SelectedInterval == UtilizationInterval.Dayly)
                radioButtonDayly.Checked = true;
            else
                radioButtonMonthly.Checked = true;
            labelBaseDetailName.Text = _currentBaseComponent.BaseComponentType+ " S/N:" +
                                        _currentBaseComponent.SerialNumber;

            numericUpDownHours.Value = _currentBaseComponent.AverageUtilization.Hours > 0 
                ? (decimal)_currentBaseComponent.AverageUtilization.Hours
                : 1;
            numericUpDownCycles.Value = _currentBaseComponent.AverageUtilization.Cycles > 0
                ? (decimal)_currentBaseComponent.AverageUtilization.Cycles
                : 1;
        }
        #endregion

        #region public AverageUtilization GetAverageUtilization()
        ///<summary>
        /// Возвращает объект средне утилизации в соотвествии со значениями заданными а ЭУ
        ///</summary>
        ///<returns></returns>
        public AverageUtilization GetAverageUtilization()
        {
            double eps = 0.00000001;
            double hours = (double)numericUpDownHours.Value;
            double cycles = (double)numericUpDownCycles.Value;

            if (radioButtonDayly.Checked && numericUpDownHours.Value >= 24)
            {
                MessageBox.Show(numericUpDownHours.Value + ". Invalid value", (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
            if (radioButtonMonthly.Checked && numericUpDownHours.Value >= 744)
            {
                MessageBox.Show(numericUpDownHours.Value + ". Invalid value", (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

            AverageUtilization au = new AverageUtilization();
            if (radioButtonDayly.Checked)
                au.SelectedInterval = UtilizationInterval.Dayly;
            else au.SelectedInterval = UtilizationInterval.Monthly;

            if (Math.Abs(au.Hours - hours) > eps)
            {
                if (au.SelectedInterval == UtilizationInterval.Dayly)
                    au.HoursPerDay = hours;
                else
                    au.HoursPerMonth = hours;
            }
            if (Math.Abs(au.Cycles - cycles) > eps)
                if (au.SelectedInterval == UtilizationInterval.Dayly)
                    au.CyclesPerDay = cycles;
                else
                    au.CyclesPerMonth = cycles;
            return au;
        }
        #endregion

        #region public bool SaveData()

        /// <summary>
        /// Данные работы обновляются по введенным значениям
        /// </summary>
        public bool SaveData()
        {
            AverageUtilization au = GetAverageUtilization();
            if (au == null) return false;
            _currentBaseComponent.AverageUtilization = au;

            try
            {
                GlobalObjects.ComponentCore.Save(_currentBaseComponent);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while loading data", ex);
                return false;
            }
            return true;
        }

        #endregion

        #region private void NumericUpDownHoursValueChanged(object sender, System.EventArgs e)

        private void NumericUpDownHoursValueChanged(object sender, EventArgs e)
        {
            if (radioButtonDayly.Checked && numericUpDownHours.Value >= 24)
            {
                numericUpDownHours.Value = (decimal)23.9;
            }
            if (radioButtonMonthly.Checked && numericUpDownHours.Value >= 744)
            {
                numericUpDownHours.Value = (decimal)743.9;
            }

	        numericUpDown1.Value = numericUpDownHours.Value / numericUpDownCycles.Value;
        }
        #endregion

        #region  private void RadioButtonDaylyCheckedChanged(object sender, System.EventArgs e)

        private void RadioButtonDaylyCheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDayly.Checked && numericUpDownHours.Value >= 24)
            {
                numericUpDownHours.Value = (decimal)23.9;
            }
            if (radioButtonMonthly.Checked && numericUpDownHours.Value >= 744)
            {
                numericUpDownHours.Value = (decimal)743.9;
            }
        }
        #endregion
    }
}
