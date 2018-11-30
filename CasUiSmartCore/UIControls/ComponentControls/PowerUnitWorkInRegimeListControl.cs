using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.DetailsControls
{

    /// <summary>
    /// Строит список контролов для отображения информации по маслу
    /// </summary>
    public partial class PowerUnitWorkInRegimeListControl : Interfaces.EditObjectControl
    {

        #region public BaseDetail BaseDetail
        /// <summary>
        /// Полет, с которым связан контрол
        /// </summary>
        public BaseComponent BaseComponent
        {
            get { return AttachedObject as BaseComponent; }
            set
            {
                AttachedObject = value;
                UpdateInformation();
            }
        }
        #endregion

        /*
         * Конструктор
         */

        #region public PowerUnitWorkInRegimeListControl()
        /// <summary>
        /// Строит список контролов для отображения информации по маслу
        /// </summary>
        public PowerUnitWorkInRegimeListControl()
        {
            InitializeComponent();
        }
        #endregion

        /*
         * Перегружаемые методы
         */

        #region public override void ApplyChanges()
        /// <summary>
        /// Применить к объекту сделанные изменения на контроле. 
        /// Если не все данные удовлетворяют формату ввода (например при вводе чисел), свойства объекта не изменяются, возвращается false
        /// Вызов base.ApplyChanges() обязателен
        /// </summary>
        /// <returns></returns>
        public override void ApplyChanges()
        {
            // Применяем сделанные изменения объектам
            for (int i = 0; i < flowLayoutPanelMain.Controls.Count; i++)
            {
                PowerUnitWorkInRegimeParamsControl c = flowLayoutPanelMain.Controls[i] as PowerUnitWorkInRegimeParamsControl;
                if (c == null) continue;
                c.ApplyChanges();
                if (BaseComponent != null && BaseComponent.ComponentWorkParams != null && !ConditionExists(c.Condition))
                    BaseComponent.ComponentWorkParams.Add(c.Condition);
            }


            /*
             * Все изменения сохранены в коллекции 
             * 
             * Здесь необходимо сохранить внесенные данные 
             * Коллекция является StringConvertibleCollection и не имеет отдельной таблицы в базе данных, 
             * а хранится в качестве поля таблицы AircraftFlights
             */
            if (BaseComponent != null)
            {
                BaseComponent.AccelerationGround = dateTimePickerTime.Value.Second;
                BaseComponent.AccelerationAir = dateTimePickerAccelerationAir.Value.Second;
            }
            //
            base.ApplyChanges();
        }
        #endregion

        #region public override bool CheckData()
        /// <summary>
        /// Проверяет введенные данные.
        /// Если какое-либо поле не подходит по формату, следует сразу кидать MessageBox, ставить курсор в необходимое поле и возвращать false в качестве результата метода
        /// </summary>
        /// <returns></returns>
        public override bool CheckData()
        {

            // Проверяем введенные данные
            for (int i = 0; i < flowLayoutPanelMain.Controls.Count; i++)
            {
                PowerUnitWorkInRegimeParamsControl c = flowLayoutPanelMain.Controls[i] as PowerUnitWorkInRegimeParamsControl;
                if (c != null)
                {
                    if (!c.CheckData())
                    {
                        Visible = true;
                        return false;
                    }
                }
            }

            // Все данные введены корректно
            return true;
        }
        #endregion

        #region public override void FillControls()
        /// <summary>
        /// Обновляет значения полей
        /// </summary>
        public override void FillControls()
        {
            BuildControls();
        }
        #endregion

        #region public override bool GetChangeStatus()
        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        public override bool GetChangeStatus()
        {
            if (BaseComponent != null)
            {
                if (BaseComponent.AccelerationGround != dateTimePickerTime.Value.Second ||
                    BaseComponent.AccelerationAir != dateTimePickerAccelerationAir.Value.Second)
                    return true;
            }
            
            IEnumerable<PowerUnitWorkInRegimeParamsControl> ppc =
                flowLayoutPanelMain.Controls.OfType<PowerUnitWorkInRegimeParamsControl>();
            try
            {
                return ppc.Any(c => c.GetChangeStatus());
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while check data", ex);
                return true;
            }
        }

        #endregion

        /*
         * Реализация
         */
        #region public void UpdateInformation()
        /// <summary>
        /// Обновляет информацию контрола
        /// </summary>
        public void UpdateInformation()
        {
            BuildControls();
        }
        #endregion

        #region private void BuildControls()
        /// <summary>
        /// Строит нужные контролы
        /// </summary>
        private void BuildControls()
        {
            if (BaseComponent != null)
            {
                dateTimePickerTime.Value = DateTime.Today.AddSeconds(BaseComponent.AccelerationGround);
                dateTimePickerAccelerationAir.Value = DateTime.Today.AddSeconds(BaseComponent.AccelerationAir);
            }
            
            // Освобождаем старые контролы
            foreach (Control control in flowLayoutPanelMain.Controls)
            {
                if (control is PowerUnitWorkInRegimeParamsControl)
                {
                    PowerUnitWorkInRegimeParamsControl c = (PowerUnitWorkInRegimeParamsControl) control;
                    c.Deleted -= OilConditionControlDeleted;
                    c.RegimeChanged -= RegimeChanged;
                }
            }
            flowLayoutPanelMain.Controls.Clear();
            
            if (BaseComponent != null && BaseComponent.ComponentWorkParams != null)
            {
                for (int i = 0; i < BaseComponent.ComponentWorkParams.Count; i++)
                {
                    // Добавляем контрол для ввода данных по запускам
                    PowerUnitWorkInRegimeParamsControl c = 
                        new PowerUnitWorkInRegimeParamsControl(BaseComponent.ComponentWorkParams[i]);
                    c.Extended = false;
                    c.Deleted += OilConditionControlDeleted;
                    c.RegimeChanged += RegimeChanged;
                    if (i > 0) c.ShowHeaders = false;
                    
                    flowLayoutPanelMain.Controls.Add(c);
                }
            }

            flowLayoutPanelMain.Controls.Add(panelAdd);
        }

        #endregion

        #region private bool ConditionExists(DetailWorkInRegimeParams con)
        /// <summary>
        /// Существует ли информация по уровню масла для заданного агрегата
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        private bool ConditionExists(ComponentWorkInRegimeParams con)
        {
            //
            if (BaseComponent == null || BaseComponent.ComponentWorkParams == null) return false;

            //
            return BaseComponent.ComponentWorkParams.Any(t => t == con);

            //
        }
        #endregion

        #region private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        
        private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PowerUnitWorkInRegimeParamsControl performance =
                new PowerUnitWorkInRegimeParamsControl(BaseComponent);
            performance.Extended = true;
            performance.Deleted += OilConditionControlDeleted;
            performance.RegimeChanged += RegimeChanged;
            if (flowLayoutPanelMain.Controls.Count > 1) performance.ShowHeaders = false;
            flowLayoutPanelMain.Controls.Remove(panelAdd);
            flowLayoutPanelMain.Controls.Add(performance);
            flowLayoutPanelMain.Controls.Add(panelAdd);
        }
        #endregion

        #region void RegimeChanged(object sender, EventArgs e)
        void RegimeChanged(object sender, EventArgs e)
        {
            PowerUnitWorkInRegimeParamsControl pc = sender as PowerUnitWorkInRegimeParamsControl;
            if (pc == null || pc.FlightRegime == null) return;

            List<PowerUnitWorkInRegimeParamsControl> pcList
                = flowLayoutPanelMain.Controls
                .OfType<PowerUnitWorkInRegimeParamsControl>()
                .Where(c=>c.FlightRegime == pc.FlightRegime)
                .ToList();
            pcList.Remove(pc);

            foreach (PowerUnitWorkInRegimeParamsControl control in pcList)
            {
                control.FlightRegime = pc.FlightRegime;
                control.Persent = pc.Persent;
                control.ResourceProvider = pc.ResourceProvider;
            }
        }
        #endregion

        #region private void OilConditionControlDeleted(object sender, EventArgs e)

        private void OilConditionControlDeleted(object sender, EventArgs e)
        {
            PowerUnitWorkInRegimeParamsControl control = (PowerUnitWorkInRegimeParamsControl)sender;
            ComponentWorkInRegimeParams cond = control.Condition;

            if(cond.ItemId > 0 && MessageBox.Show("Do you really want to delete detail params?", "Deleting confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //если информация о состоянии сохранена в БД 
                //и получен положительный ответ на ее удаление
                try
                {
                    GlobalObjects.CasEnvironment.Manipulator.Delete(cond);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while removing data", ex);
                }

                flowLayoutPanelMain.Controls.Remove(control);
                control.Deleted -= OilConditionControlDeleted;
                control.RegimeChanged -= RegimeChanged;
                control.Dispose();
            }
            else if(cond.ItemId <= 0)
            {
                flowLayoutPanelMain.Controls.Remove(control);
                control.Deleted -= OilConditionControlDeleted;
                control.RegimeChanged -= RegimeChanged;
                control.Dispose();
            }
        }

        #endregion
    }
}

