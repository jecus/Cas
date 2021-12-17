using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary.Events;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Atlbs;


namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{

    /// <summary>
    /// Контрол позволяет внести информацию по экипажу полета
    /// </summary>
    public partial class CargoListControl : Interfaces.EditObjectControl
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

        #region public CargoListControl()
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public CargoListControl()
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
                Flight.FlightCargoRecords.Clear();
                List<CargoRecordControl> fcs = flowLayoutPanelMain.Controls.OfType<CargoRecordControl>().ToList();

                foreach (CargoRecordControl fc in fcs)
                {
                    fc.ApplyChanges();
                    Flight.FlightCargoRecords.Add(fc.FlightCargoRecord);
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
            List<CargoRecordControl> fcs = flowLayoutPanelMain.Controls.OfType<CargoRecordControl>().ToList();

            foreach (CargoRecordControl fc in fcs.Where(fc => !fc.CheckData()))
            {
                MessageBox.Show(fc, "Not set cargo category", "Error");
                return false;
            }

            foreach (CargoRecordControl fc in fcs)
            {
                if (fcs.Where(f => f.CargoCategory.ItemId ==
                                   fc.CargoCategory.ItemId).Count() > 1)
                {
                    MessageBox.Show(fc, "Can't have one cargo category more that once", "Error");
                    return false;
                }
            }
            return true;
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

            if (Flight != null && Flight.FlightCargoRecords != null)
            {
                for (int i = 0; i < Flight.FlightCargoRecords.Count; i++)
                {
                    // Добавляем контрол для ввода данных по маслу
                    CargoRecordControl c = new CargoRecordControl(Flight.FlightCargoRecords[i]);
                    c.Deleted += ConditionControlDeleted;
                    c.WeightChanged += ControlWeightChanged;
                    if (i > 0) c.ShowHeaders = false;
                    flowLayoutPanelMain.Controls.Add(c);
                }
            }

            flowLayoutPanelMain.Controls.Add(panelAdd);
           
            GetTotal();
        }
        #endregion

        #region private void GetTotal()
        private void GetTotal()
        {
            List<CargoRecordControl> fcs = flowLayoutPanelMain.Controls.OfType<CargoRecordControl>().ToList();

            double t = fcs.Sum(cr => Measure.Convert(cr.Weigth, cr.Measure, Measure.Kilograms));

            textWeightTotal.Text = t.ToString("F") + " " + Measure.Kilograms; 
   
            InvokeCargoWeightChanget(t);
        }
        #endregion

        #region private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CargoRecordControl performance =
                new CargoRecordControl(new FlightCargoRecord { FlightId = Flight.ItemId });
            performance.Deleted += ConditionControlDeleted;
            performance.WeightChanged += ControlWeightChanged;
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
            CargoRecordControl control = (CargoRecordControl)sender;
            FlightCargoRecord cond = control.FlightCargoRecord;

            if (cond.ItemId > 0 && MessageBox.Show("Do you really want to delete flight cargo record?", 
                                                   "Deleting confirmation", MessageBoxButtons.YesNoCancel, 
                                                   MessageBoxIcon.Exclamation, 
                                                   MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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
                control.WeightChanged -= ControlWeightChanged;
                control.Dispose();
            }
            else if (cond.ItemId <= 0)
            {
                flowLayoutPanelMain.Controls.Remove(control);
                control.Deleted -= ConditionControlDeleted;
                control.WeightChanged -= ControlWeightChanged;
                control.Dispose();
            }
        }

        #endregion

        #region private void ControlWeightChanged(object sender, EventArgs e)
        private void ControlWeightChanged(object sender, EventArgs e)
        {
            GetTotal();
        }
        #endregion

        #region Events

        ///<summary>
        /// Возникает при изменении веса груза
        ///</summary>
        [Category("Cargo data")]
        [Description("Возникает при изменении топлива на борту")]
        public event ValueChangedEventHandler OnCargoWeightChanget;

        ///<summary>
        /// Сигнализирует об изменении изменении веса груза
        ///</summary>
        ///<param name="value"></param>
        private void InvokeCargoWeightChanget(double value)
        {
            ValueChangedEventHandler handler = OnCargoWeightChanget;
            if (handler != null) handler(new ValueChangedEventArgs(value));
        }

        #endregion
    }
}

