using System;
using System.Collections.Generic;
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
    ///</summary>
    public partial class PowerUnitRunupsListControl : EditObjectControl
    {
        private DateTime _flightDate = DateTime.Today;

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

        #region public PowerUnitRunupsListControl()
        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        public PowerUnitRunupsListControl()
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
                PowerUnitRunupControl c = flowLayoutPanelMain.Controls[i] as PowerUnitRunupControl;
                if (c == null) continue;
                c.ApplyChanges();
                if (Flight != null && Flight.RunupsCollection != null && !ConditionExists(c.Runup))
                    Flight.RunupsCollection.Add(c.Runup);
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
                PowerUnitRunupControl c = flowLayoutPanelMain.Controls[i] as PowerUnitRunupControl;
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

        /*
         * Своиства
         */

        #region public DateTime FlightDate
        ///<summary>
        /// Возвращает или задает дату полета
        ///</summary>
        public DateTime FlightDate
        {
            set
            {
                _flightDate = value;
                foreach (Control c in flowLayoutPanelMain.Controls)
                {
                    if (!(c is PowerUnitRunupControl))
                        continue;

                    ((PowerUnitRunupControl)c).FligthDate = _flightDate;
                }
            }
        }
        #endregion

        #region public DateTime StartTime
        ///<summary>
        /// Возвращает или задает время запуска силовых установок
        ///</summary>
        public DateTime StartTime
        {
            set
            {
                foreach (Control c in flowLayoutPanelMain.Controls)
                {
                    if (!(c is PowerUnitRunupControl))
                        continue;

                    ((PowerUnitRunupControl)c).StartTime = value;
                }
            }
        }
        #endregion

        #region public DateTime EndTime
        ///<summary>
        /// Возвращает или задает время остановки силовых установок
        ///</summary>
        public DateTime EndTime
        {
            set
            {
                foreach (Control c in flowLayoutPanelMain.Controls)
                {
                    if (!(c is PowerUnitRunupControl))
                        continue;

                    ((PowerUnitRunupControl)c).EndTime = value;
                }
            }
        }
        #endregion

        #region public DateTime TakeOffTime
        ///<summary>
        /// задает время взлета
        ///</summary>
        public DateTime TakeOffTime
        {
            set
            {
                //_takeOffTime = value;
                foreach (Control c in flowLayoutPanelMain.Controls)
                {
                    if (!(c is PowerUnitRunupControl))
                        continue;

                    ((PowerUnitRunupControl)c).TakeOffTime = value;
                }
            }
        }
        #endregion

        #region public DateTime LandingTime
        ///<summary>
        /// задает время посадки
        ///</summary>
        public DateTime LandingTime
        {
            set
            {
                //_landTime = value;
                foreach (Control c in flowLayoutPanelMain.Controls)
                {
                    if (!(c is PowerUnitRunupControl))
                        continue;

                    ((PowerUnitRunupControl)c).LandingTime = value;
                }
            }
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

            if (Flight != null && Flight.RunupsCollection != null)
            {
				var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(Flight.AircraftId);

				List<RunUp> runUps =
                    Flight.RunupsCollection.ToArray().Where(r => r.BaseComponent.BaseComponentType.ItemId == _componentType.ItemId).
                        ToList();
                //группировка запусков по ИД детали и определение первого запуска в каждой группе
                List<RunUp> firsts = 
                    Flight.RunupsCollection.GroupBy(r => r.BaseComponentId).Select(ups => ups.First()).ToList();
                for (int i = 0; i < runUps.Count; i++)
                {
                    // Добавляем контрол для ввода данных по запускам
                    PowerUnitRunupControl c = 
                        new PowerUnitRunupControl(aircraft,
                                                  Flight, 
                                                  runUps[i])
                            {
                                DetailLabelText = _componentType.ToString(),
                                FligthDate = _flightDate,
                            };
                    if (i > 0) c.ShowHeaders = false;
                    //если добавляемый запуск является первым в группе, то блокируется список выбора
                    foreach (RunUp first in firsts)
                    {
                        if (runUps[i] == first)
                        {
                            c.EnableDetailCombobox = false;
                        }
                        else
                        {
                            c.Deleted += RunUpControlDeleted;
                        }
                    }
                    c.WorkTimeChanged += RunUpControlWorkTimeChanged;
                    flowLayoutPanelMain.Controls.Add(c);
                    
                    RunUpControlWorkTimeChanged(c, null);
                }
            }

            flowLayoutPanelMain.Controls.Add(panelAddRunUp);
        }
        #endregion

        #region private bool ConditionExists(RunUp con)
        /// <summary>
        /// Существует ли информация по уровню масла для заданного агрегата
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        private bool ConditionExists(RunUp con)
        {
            //
            if (Flight == null || Flight.RunupsCollection == null) return false;

            //
            return Flight.RunupsCollection.Any(t => t == con);

            //
        }
        #endregion

        #region private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
			var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(Flight.AircraftId);
			PowerUnitRunupControl performance =
                new PowerUnitRunupControl(aircraft, _componentType)
                    {
                        FligthDate = _flightDate,
                    };
            performance.Deleted += RunUpControlDeleted;
            performance.WorkTimeChanged += RunUpControlWorkTimeChanged;
            if (flowLayoutPanelMain.Controls.Count > 1) performance.ShowHeaders = false;
            flowLayoutPanelMain.Controls.Remove(panelAddRunUp);
            flowLayoutPanelMain.Controls.Add(performance);
            flowLayoutPanelMain.Controls.Add(panelAddRunUp);
        }
        #endregion

        #region private void RunUpControlDeleted(object sender, EventArgs e)

        private void RunUpControlDeleted(object sender, EventArgs e)
        {
            PowerUnitRunupControl control = (PowerUnitRunupControl)sender;
            RunUp cond = control.Runup;

            if (cond.ItemId > 0 && MessageBox.Show("Do you really want to delete run-up?", "Deleting confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //если информация о состоянии сохранена в БД 
                //и получен положительный ответ на ее удаление
                try
                {
                    GlobalObjects.NewKeeper.Delete(cond);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while removing data", ex);
                }

                flowLayoutPanelMain.Controls.Remove(control);
                control.Deleted -= RunUpControlDeleted;
                control.WorkTimeChanged -= RunUpControlWorkTimeChanged;
                control.Dispose();
            }
            else if (cond.ItemId <= 0)
            {
                flowLayoutPanelMain.Controls.Remove(control);
                control.Deleted -= RunUpControlDeleted;
                control.WorkTimeChanged -= RunUpControlWorkTimeChanged;
                control.Dispose();
            }
        }

        #endregion

        #region private void RunUpControlWorkTimeChanged(object sender, EventArgs e)
        private void RunUpControlWorkTimeChanged(object sender, EventArgs e)
        {
            if (sender as PowerUnitRunupControl == null) return;
            BaseComponent prevPowerUnit = ((PowerUnitRunupControl)sender).PrevPowerUnit;
            if(prevPowerUnit != null)
            {
                TimeSpan prevtWorkTime = new TimeSpan();
                            prevtWorkTime = flowLayoutPanelMain.Controls
                        .OfType<PowerUnitRunupControl>()
                        .Where(purc => purc.PowerUnit != null && purc.PowerUnit.ItemId == prevPowerUnit.ItemId)
                        .Aggregate(prevtWorkTime, (current, purc) => current + purc.WorkTime);
                    InvokeWorkTimeChanget(prevPowerUnit, prevtWorkTime);
                
            };
            BaseComponent powerUnit = ((PowerUnitRunupControl)sender).PowerUnit;
            if(powerUnit != null)
            {
                TimeSpan currentWorkTime = new TimeSpan();
                currentWorkTime = flowLayoutPanelMain.Controls
                    .OfType<PowerUnitRunupControl>()
                    .Where(purc => purc.PowerUnit != null && purc.PowerUnit.ItemId == powerUnit.ItemId)
                    .Aggregate(currentWorkTime, (current, purc) => current + purc.WorkTime);
                InvokeWorkTimeChanget(powerUnit, currentWorkTime);    
            }
        }
        #endregion

        #region Events

        /// <summary>
        /// Событие, оповещающее об изменении времени работы Силовой установки
        /// </summary>
        [Category("Power unit work time data")]
        [Description("Событие, оповещающее об изменении времени работы Силовой установки")]
        public event EventHandler WorkTimeChanged;

        ///<summary>
        /// Возбуждает событие оповещающее об изменении времени работы Силовой установки
        ///</summary>
        private void InvokeWorkTimeChanget(BaseComponent powerUnit, TimeSpan workTime)
        {
            EventHandler handler = WorkTimeChanged;
            if (handler != null)
                handler(powerUnit, new ValueChangedEventArgs(workTime));
        }

        #endregion

    }
}
