using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{


    /*
     * Общий принцип - пользователю всегда отображается минимум 4 отклонения и те отклонения которые он заполнил сохраняются в базу данных
     * Если на форме отображается 4 отклонения но заполнено только одно, это означает, что во время полета было обнаружено только одно отклонение
     */

    /// <summary>
    /// Строит список отклонений воздушного судна
    /// </summary>
    public partial class EngineMonitoringListControl : Interfaces.EditObjectControl
    {
        private Dictionary<int, double> _componentOilFlow = new Dictionary<int, double>();

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

        #region public EngineMonitoringListControl()
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public EngineMonitoringListControl()
        {
            InitializeComponent();
            FillControls();
        }
        #endregion

        /*
         * Своиства
         */

        #region public DateTime RecordTime
        ///<summary>
        /// Возвращает или задает время проведения замеров
        ///</summary>
        public DateTime RecordTime
        {
            get
            {
                foreach (Control c in flowLayoutPanelMain.Controls)
                {
                    if (!(c is EngineGeneralConditionControl))
                        continue;

                    return ((EngineGeneralConditionControl)c).RecordDate;
                }
                return DateTime.Today;
            }
            set
            {
                foreach (Control c in flowLayoutPanelMain.Controls)
                {
                    if(!(c is EngineGeneralConditionControl))
                        continue;

                    ((EngineGeneralConditionControl)c).RecordDate = value;
                }
            }
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
                EngineGeneralConditionControl d = flowLayoutPanelMain.Controls[i] as EngineGeneralConditionControl;
                if (d != null)
                {
                    d.ApplyChanges();
                    EnginesGeneralCondition genCond = d.EngineGeneral;
                    if(genCond == null)return;
                    foreach (EngineCondition cond in genCond.EngineConditions)
                    {
                        if (Flight != null && Flight.EngineConditionCollection != null && !ConditionExists(cond))
                            Flight.EngineConditionCollection.Add(cond);    
                    }
                }
            }
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
            // Проверяем только те отклонения которые реально были вбиты пользователем (!d.IsNull)
            for (int i = 0; i < flowLayoutPanelMain.Controls.Count; i++)
            {
                EngineGeneralConditionControl d = flowLayoutPanelMain.Controls[i] as EngineGeneralConditionControl;
                if (d != null) 
                    if (!d.CheckData())
                    {
                        Visible = true;
                        return false;
                    }
            }

            List<EngineGeneralConditionControl> fcs = flowLayoutPanelMain.Controls.OfType<EngineGeneralConditionControl>().ToList();

            foreach (EngineGeneralConditionControl fc in fcs)
            {
                if (fcs.Where(f => f.RecordDate == fc.RecordDate).Count() <= 1) continue;
                MessageBox.Show(fc, "You can not create two measuring at the same time", "Error");
                Visible = true;
                return false;
            }

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

            if(Flight != null && Flight.EngineConditionCollection.Count > 0)
            {
				var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(Flight.AircraftId);

				flowLayoutPanelMain.Controls.Clear();
                flowLayoutPanelMain.Controls.Remove(panelAdd);

                //группировка данных по времени замера
                List<IGrouping<TimeSpan, EngineCondition>> groupConditions =
                    Flight.EngineConditionCollection.GroupBy(e => e.TimeGMT).ToList();

                //создание для каждой группы нового элемента EngineGeneralCondition
                //и EngineGeneralConditionControl и помещение их на панель
                foreach (IGrouping<TimeSpan, EngineCondition> condition in groupConditions)
                {
                    EnginesGeneralCondition engineGeneral = new EnginesGeneralCondition(condition.First());
                    engineGeneral.EngineConditions.AddRange(condition.ToArray());

                    EngineGeneralConditionControl egc = new EngineGeneralConditionControl(aircraft, engineGeneral);
                    egc.Deleted += ConditionControlDeleted;
                    flowLayoutPanelMain.Controls.Add(egc);
                }
                flowLayoutPanelMain.Controls.Add(panelAdd);
            }
        }
        #endregion

        #region public void SetPowerUnitWorkTime(BaseDetail powerUnit, double workTime)
        ///<summary>
        /// Изменяет время работы определенной силовой установки
        ///</summary>
        ///<param name="powerUnit">Силовая установка</param>
        ///<param name="flow">Время работы</param>
        public void SetComponentOilFlow(BaseComponent powerUnit, double flow)
        {
            if (powerUnit == null) return;
            if (_componentOilFlow.ContainsKey(powerUnit.ItemId))
                _componentOilFlow[powerUnit.ItemId] = flow;
            else _componentOilFlow.Add(powerUnit.ItemId, flow);

            List<EngineGeneralConditionControl> fcs =
               flowLayoutPanelMain.Controls
               .OfType<EngineGeneralConditionControl>()
               .ToList();
            
            foreach (EngineGeneralConditionControl fc in fcs)
            {
                fc.SetComponentOilFlow(powerUnit, flow);
            }
        }
        #endregion

        #region protected override void OnSizeChanged(EventArgs e)
        /// <summary>
        /// При изменении размера контрола расширяем Flow Layout Panel т.к. сама она этого делать не умеет )
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            if(flowLayoutPanelMain != null)flowLayoutPanelMain.Dock = DockStyle.Fill;
            base.OnSizeChanged(e);
        }
        #endregion

        #region private bool ConditionExists(EngineCondition con)
        /// <summary>
        /// Существует ли информация по уровню масла для заданного агрегата
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        private bool ConditionExists(EngineCondition con)
        {
            //
            if (Flight == null || Flight.EngineConditionCollection == null) return false;

            //
            return Flight.EngineConditionCollection.Any(t => t == con);

            //
        }
        #endregion

        #region private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EngineGeneralConditionControl last = 
                flowLayoutPanelMain.Controls
                .OfType<EngineGeneralConditionControl>()
                .OrderBy(c => c.RecordDate)
                .LastOrDefault();
			var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(Flight.AircraftId);
			EngineGeneralConditionControl engineGeneral = new EngineGeneralConditionControl(aircraft);
            engineGeneral.SetComponentOilFlow(_componentOilFlow);
            if(last != null)
            {
                engineGeneral.RecordDate = last.RecordDate;
                engineGeneral.PressAlt = last.PressAlt;
                engineGeneral.GrossWeight = last.GrossWeight;
                engineGeneral.IAS = last.IAS;
                engineGeneral.Mach = last.Mach;
                engineGeneral.TAT = last.TAT;
                engineGeneral.OAT = last.OAT;
            }

            engineGeneral.Deleted += ConditionControlDeleted;
            flowLayoutPanelMain.Controls.Remove(panelAdd);
            flowLayoutPanelMain.Controls.Add(engineGeneral);
            flowLayoutPanelMain.Controls.Add(panelAdd);
        }
        #endregion

        #region private void ConditionControlDeleted(object sender, EventArgs e)

        private void ConditionControlDeleted(object sender, EventArgs e)
        {
            EngineGeneralConditionControl control = (EngineGeneralConditionControl)sender;
            EnginesGeneralCondition cond = control.EngineGeneral;

            if (cond.EngineConditions.Count > 0 && MessageBox.Show("Do you really want to delete engine condition?", "Deleting confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //если информация о состоянии сохранена в БД 
                //и получен положительный ответ на ее удаление
                foreach (EngineCondition ec in cond.EngineConditions)
                {
                    try
                    {
                        GlobalObjects.CasEnvironment.NewKeeper.Delete(ec);
                    }
                    catch (Exception ex)
                    {
                        Program.Provider.Logger.Log("Error while removing data", ex);
                    }  
                }
                flowLayoutPanelMain.Controls.Remove(control);
                control.Deleted -= ConditionControlDeleted;
                control.Dispose();
            }
        }

        #endregion
    }
}


