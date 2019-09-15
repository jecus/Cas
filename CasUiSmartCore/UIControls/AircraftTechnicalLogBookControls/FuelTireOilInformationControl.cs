using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary.Events;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    ///<summary>
    /// ЭУ для отображения информации о топливе, шинах и масле
    ///</summary>
    public partial class FuelTireOilInformationControl : EditObjectControl
    {
        
        ///<summary>
        /// Возвращает редактируемый полет
        ///</summary>
        public AircraftFlight Flight
        {
            get { return AttachedObject as AircraftFlight; }
        }

        #region public void SetPowerUnitWorkTime(BaseDetail powerUnit, TimeSpan workTime)
        ///<summary>
        /// Изменяет время работы определенной силовой установки
        ///</summary>
        ///<param name="powerUnit">Силовая установка</param>
        ///<param name="workTime">Время работы</param>
        public void SetPowerUnitWorkTime(BaseComponent powerUnit, TimeSpan workTime)
        {
            componentOilListControl1.SetPowerUnitWorkTime(powerUnit, workTime);
        }

        public void SetPowerUnitWorkTime(TimeSpan workTime)
        {
	        componentOilListControl1.SetPowerUnitWorkTime(GlobalObjects.ComponentCore.GetAicraftBaseComponents(Flight.AircraftId, BaseComponentType.Engine.ItemId).ToList(),workTime);
        }

		#endregion

		#region public FuelTireOilInformationControl()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		public FuelTireOilInformationControl()
        {
            InitializeComponent();
        }
        #endregion

        #region public override void FillControls()
        /// <summary>
        /// Обновляет значения полей
        /// </summary>
        public override void FillControls()
        {
            BeginUpdate();
            if (Flight != null)
            {
                foreach (Control c in flowLayoutPanelMain.Controls)
                {
                    EditObjectControl cc = c as EditObjectControl;
                    if (cc != null) 
                        cc.AttachedObject = AttachedObject;
                }
            }
            EndUpdate();
        }
        #endregion

        #region public override bool CheckData()
        /// <summary>
        /// Сохраняет данные текущей директивы
        /// </summary>
        public override bool CheckData()
        {
            // Просматриваем до первой "провалившейся" проверки
            foreach (Control c in flowLayoutPanelMain.Controls)
            {
                EditObjectControl cc = c as EditObjectControl;
                if (cc != null)
                    if (!cc.CheckData()) return false;
            }
            // Все проверки завершились успешно
            return true;
        }

        #endregion

        #region public override void ApplyChanges()
        /// <summary>
        /// Вызывает метод ApplyChanges у каждого контрола
        /// </summary>
        /// <returns></returns>
        public override void ApplyChanges()
        {
            // Просматриваем до первой "провалившейся" проверки
            foreach (Control c in flowLayoutPanelMain.Controls)
            {
                EditObjectControl cc = c as EditObjectControl;
                if (cc != null) cc.ApplyChanges();
            }
        }
        #endregion

        #region private void fuelControl1_OnBoardChanget(ValueChangedEventArgs e)
        private void fuelControl1_OnBoardChanget(ValueChangedEventArgs e)
        {
            InvokeOnBoardChanget(e);
        }
        #endregion

        #region private void FuelControl1RemainAfterChanget(ValueChangedEventArgs e)
        private void FuelControl1RemainAfterChanget(ValueChangedEventArgs e)
        {
            InvokeRemainAfterChanget(e);
        }
        #endregion

        #region private void ComponentOilListControl1OilFlowChanget(object sender, EventArgs e)
        private void ComponentOilListControl1OilFlowChanget(object sender, EventArgs e)
        {
            if (sender as BaseComponent == null
                || e as ValueChangedEventArgs == null
                || !(((ValueChangedEventArgs)e).Value is double )) return;

            BaseComponent powerUnit = (BaseComponent)sender;
            double oilFlow = (double)((ValueChangedEventArgs)e).Value;
            InvokeOilFlowChanget(powerUnit, oilFlow);
        }
        #endregion

        #region Events

        ///<summary>
        /// Возникает при изменении топлива на борту
        ///</summary>
        [Category("Fuel data")]
        [Description("Возникает при изменении топлива на борту")]
        public event ValueChangedEventHandler OnBoardChanget;

        ///<summary>
        /// Возникает при изменении топлива на после полета
        ///</summary>
        [Category("Fuel data")]
        [Description("Возникает при изменении топлива после полета")]
        public event ValueChangedEventHandler RemainAfterChanget;

        ///<summary>
        /// Возникает при изменении расхода масла
        ///</summary>
        [Category("Oil data")]
        [Description("Возникает при изменении расхода масла")]
        public event EventHandler OilFlowChanget;

        ///<summary>
        /// Сигнализирует об изменении топлива на борту
        ///</summary>
        ///<param name="e"></param>
        private void InvokeOnBoardChanget(ValueChangedEventArgs e)
        {
            ValueChangedEventHandler handler = OnBoardChanget;
            if (handler != null) handler(e);
        }

        ///<summary>
        /// Сигнализирует об изменении топлива после полета
        ///</summary>
        ///<param name="e"></param>
        private void InvokeRemainAfterChanget(ValueChangedEventArgs e)
        {
            ValueChangedEventHandler handler = RemainAfterChanget;
            if (handler != null) handler(e);
        }

        ///<summary>
        /// Сигнализирует об изменении расхода масла
        ///</summary>
        private void InvokeOilFlowChanget(BaseComponent powerUnit, double oilFlow)
        {
            EventHandler handler = OilFlowChanget;
            if (handler != null)
                handler(powerUnit, new ValueChangedEventArgs(oilFlow));
        }

        #endregion

    }
}
