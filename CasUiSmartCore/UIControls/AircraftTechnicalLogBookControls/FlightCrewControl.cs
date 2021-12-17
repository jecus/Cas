using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary.Events;
using CASTerms;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Personnel;


namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{

    /// <summary>
    /// Контрол позволяет внести информацию по экипажу полета
    /// </summary>
    public partial class FlightCrewControl : Interfaces.EditObjectControl
    {

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

        #region public FlightCrewControl()
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public FlightCrewControl()
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
            if (Flight != null)
            {
                Flight.FlightCrewRecords.Clear();
                List<FlightCrewRecordControl> fcs = flowLayoutPanelMain.Controls.OfType<FlightCrewRecordControl>().ToList();

                foreach (FlightCrewRecordControl fc in fcs)
                {
                    fc.ApplyChanges();
                    Flight.FlightCrewRecords.Add(fc.FlightCrewRecord);
                }
            }
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
            BeginUpdate();
            BuildControls();
            EndUpdate();
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
            // В этом контроле только текстовые данные
            List<FlightCrewRecordControl> fcs = flowLayoutPanelMain.Controls.OfType<FlightCrewRecordControl>().ToList();

            //if(fcs.Count == 0)
            //{
            //    MessageBox.Show(flowLayoutPanelMain, "Not assigned crew", "Error");
            //    return false;    
            //}

            foreach (FlightCrewRecordControl fc in fcs.Where(fc => !fc.CheckData()))
            {
                MessageBox.Show(fc, "Not specified crew member", "Error");
                return false;
            }

            foreach (FlightCrewRecordControl fc in fcs)
            {
                if(fcs.Count(f => f.Specialist.ItemId == fc.Specialist.ItemId) > 1)
                {
                    MessageBox.Show(fc, "Can't have one crew member more that once", "Error");
                    return false;
                }
            }

            return fcs.All(fc => fcs.Count(f => f.Specialist.ItemId == fc.Specialist.ItemId) <= 1);
            //
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

            if (Flight != null && Flight.FlightCrewRecords != null)
            {
                for (int i = 0; i < Flight.FlightCrewRecords.Count; i++)
                {
                    // Добавляем контрол для ввода данных по маслу
                    FlightCrewRecordControl c = new FlightCrewRecordControl(Flight.FlightCrewRecords[i]);
                    c.Deleted += ConditionControlDeleted;
                    c.CrewMemberChanged += CrewMemberChanged;
                    if (i > 0) c.ShowHeaders = false;
                    flowLayoutPanelMain.Controls.Add(c);
                }  
            }

            flowLayoutPanelMain.Controls.Add(panelAdd);
        }
        #endregion

        #region private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FlightCrewRecordControl performance =
                new FlightCrewRecordControl(new FlightCrewRecord{FlightId = Flight.ItemId});
            performance.Deleted += ConditionControlDeleted;
            performance.CrewMemberChanged += CrewMemberChanged;
            if (flowLayoutPanelMain.Controls.Count > 1) performance.ShowHeaders = false;
            flowLayoutPanelMain.Controls.Remove(panelAdd);
            flowLayoutPanelMain.Controls.Add(performance);
            flowLayoutPanelMain.Controls.Add(panelAdd);
            performance.Focus();
        }
        #endregion

        #region private void ConditionControlDeleted(object sender, EventArgs e)

        private void ConditionControlDeleted(object sender, EventArgs e)
        {
            FlightCrewRecordControl control = (FlightCrewRecordControl)sender;
            FlightCrewRecord cond = control.FlightCrewRecord;

            if (cond.ItemId > 0 && MessageBox.Show("Do you really want to delete flight crew record?", "Deleting confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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
                control.Deleted -= ConditionControlDeleted;
                control.CrewMemberChanged -= CrewMemberChanged;
                control.Dispose();
                InvokeCrewChanged();
            }
            else if (cond.ItemId <= 0)
            {
                flowLayoutPanelMain.Controls.Remove(control);
                control.Deleted -= ConditionControlDeleted;
                control.CrewMemberChanged -= CrewMemberChanged;
                control.Dispose();
                InvokeCrewChanged();
            }
        }

        #endregion

        #region private void CrewMemberChanged(object sender, EventArgs e)
        private void CrewMemberChanged(object sender, EventArgs e)
        {
            InvokeCrewChanged();
        }
        #endregion

        #region Events
        /// <summary>
        /// Событие, возникающее при изменении состава экипажа
        /// </summary>
        [Category("Crew data")]
        [Description("Событие, возникающее при изменении экипажа")]
        public event CrewChangedEventHandler CrewChanged;

        private void InvokeCrewChanged()
        {
            if (CrewChanged != null)
            {
                List<FlightCrewRecordControl> fcs = flowLayoutPanelMain.Controls.OfType<FlightCrewRecordControl>().ToList();
                List<Specialist> crew = fcs.Where(fc => fc.Specialist != null)
                                           .Select(fc => fc.Specialist).ToList();
                CrewChanged(new CrewChangedEventArgs(crew));
            }     
        }
        #endregion
    }
}

