using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Atlbs;


namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{

    /// <summary>
    /// Строит список контролов для отображения информации по маслу
    /// </summary>
    public partial class PowerUnitAccelerationListControl : Interfaces.EditObjectControl
    {

        #region public DetailType DetailType

        private BaseComponentType _componentType;
        ///<summary>
        /// Задает тип деталей для которых будут производится записи о пусках
        ///</summary>
        public BaseComponentType ComponentType
        {
            set { _componentType = value; }
        }
        #endregion

        #region public AircraftFlight Flight
        /// <summary>
        /// Полет, с которым связан контрол
        /// </summary>
        public AircraftFlight Flight
        {
            get { return AttachedObject as AircraftFlight; }
        }
        #endregion

        /*
         * Конструктор
         */

        #region public PowerUnitAccelerationListControl()
        /// <summary>
        /// Строит список контролов для отображения информации по маслу
        /// </summary>
        public PowerUnitAccelerationListControl()
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
                PowerUnitAccelerationControlItem c = flowLayoutPanelMain.Controls[i] as PowerUnitAccelerationControlItem;
                if (c == null) continue;
                c.ApplyChanges();
                if (Flight != null && Flight.EngineAccelerationTimeCollection != null && !ConditionExists(c.Condition))
                    Flight.EngineAccelerationTimeCollection.Add(c.Condition);
            }


            /*
             * Все изменения сохранены в коллекции 
             * 
             * Здесь необходимо сохранить внесенные данные 
             * Коллекция является StringConvertibleCollection и не имеет отдельной таблицы в базе данных, 
             * а хранится в качестве поля таблицы AircraftFlights
             */

            //
            base.ApplyChanges();
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
                PowerUnitAccelerationControlItem c = flowLayoutPanelMain.Controls[i] as PowerUnitAccelerationControlItem;
                if (c != null)
                    if (!c.CheckData()) return false;
            }

            // Все данные введены корректно
            return true;
        }
        #endregion

        /*
         * Реализация
         */

        #region private void BuildControls()
        /// <summary>
        /// Строит нужные контролы
        /// </summary>
        private void BuildControls()
        {
            // Освобождаем старые контролы
            flowLayoutPanelMain.Controls.Clear();
            flowLayoutPanelMain.Controls.Add(label);
            if (Flight != null && Flight.EngineAccelerationTimeCollection != null)
            {
	            var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(Flight.AircraftId);

                List<EngineAccelerationTime> runUps =
                    Flight.EngineAccelerationTimeCollection.ToArray().Where(r => r.BaseComponent.BaseComponentType.ItemId == _componentType.ItemId).
                        ToList();
                //группировка запусков по ИД детали и определение первого запуска в каждой группе
                for (int i = 0; i < runUps.Count; i++)
                {
                    // Добавляем контрол для ввода данных по запускам
                    PowerUnitAccelerationControlItem c = new PowerUnitAccelerationControlItem(aircraft, runUps[i]) { DetailLabelText = _componentType.ToString() };
                    if (i > 0) c.ShowHeaders = false;
                    
                    flowLayoutPanelMain.Controls.Add(c);
                }
            }

            flowLayoutPanelMain.Controls.Add(panelAdd);
        }
        #endregion

        #region private bool ConditionExists(EngineAccelerationTime con)
        /// <summary>
        /// Существует ли информация по уровню масла для заданного агрегата
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        private bool ConditionExists(EngineAccelerationTime con)
        {
            //
            if (Flight == null || Flight.EngineAccelerationTimeCollection == null) return false;

            //
            return Flight.EngineAccelerationTimeCollection.Any(t => t == con);

            //
        }
        #endregion

        #region private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        
        private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
			var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(Flight.AircraftId);
			PowerUnitAccelerationControlItem performance =
                new PowerUnitAccelerationControlItem(aircraft, new EngineAccelerationTime());
            performance.Deleted += OilConditionControlDeleted;
            if (flowLayoutPanelMain.Controls.Count > 2) performance.ShowHeaders = false;
            flowLayoutPanelMain.Controls.Remove(panelAdd);
            flowLayoutPanelMain.Controls.Add(performance);
            flowLayoutPanelMain.Controls.Add(panelAdd);
        }
        #endregion

        #region private void OilConditionControlDeleted(object sender, EventArgs e)

        private void OilConditionControlDeleted(object sender, EventArgs e)
        {
            PowerUnitAccelerationControlItem control = (PowerUnitAccelerationControlItem)sender;
            EngineAccelerationTime cond = control.Condition;

            if(cond.ItemId > 0 && MessageBox.Show("Do you really want to delete Time in regime record?", "Deleting confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //если информация о состоянии сохранена в БД 
                //и получен положительный ответ на ее удаление
                try
                {
                    GlobalObjects.CasEnvironment.NewKeeper.Delete(cond);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while removing data", ex);
                }

                flowLayoutPanelMain.Controls.Remove(control);
                control.Deleted -= OilConditionControlDeleted;
                control.Dispose();
            }
            else if(cond.ItemId <= 0)
            {
                flowLayoutPanelMain.Controls.Remove(control);
                control.Deleted -= OilConditionControlDeleted;
                control.Dispose();
            }
        }

        #endregion
    }
}

