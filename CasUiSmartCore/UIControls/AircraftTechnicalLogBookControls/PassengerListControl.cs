using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary.Events;
using CASTerms;
using SmartCore.Entities.General.Atlbs;


namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{

    /// <summary>
    /// Контрол позволяет внести информацию по экипажу полета
    /// </summary>
    public partial class PassengerListControl : Interfaces.EditObjectControl
    {

        private int _maxEconomy;
        private int _maxBusiness;
        private int _maxFirst;
        private int _maxAll;

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

        #region public PassengerListControl()
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public PassengerListControl()
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
                Flight.FlightPassengerRecords.Clear();
                List<PassengerControl> fcs = flowLayoutPanelMain.Controls.OfType<PassengerControl>().ToList();

                foreach (PassengerControl fc in fcs)
                {
                    fc.ApplyChanges();
                    Flight.FlightPassengerRecords.Add(fc.FlightPassengerRecord);
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
            List<PassengerControl> fcs = flowLayoutPanelMain.Controls.OfType<PassengerControl>().ToList();

            foreach (PassengerControl fc in fcs.Where(fc => !fc.CheckData()))
            {
                MessageBox.Show(fc, "Not set Passenger category", "Error");
                return false;
            }

            foreach (PassengerControl fc in fcs)
            {
                if (fcs.Where(f => f.PassengerCategory.ItemId ==
                                   fc.PassengerCategory.ItemId).Count() > 1)
                {
                    MessageBox.Show(fc, "Can't have one passenger category more that once", "Error");
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
            double countEconomy = 0;
            double countBusiness = 0;
            double countFirst = 0;
            _maxEconomy = 0;
            _maxBusiness = 0;
            _maxFirst = 0;
            // Освобождаем старые контролы
            flowLayoutPanelMain.Controls.Clear();

            if (Flight != null)
            {
				var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(Flight.AircraftId);
				if (aircraft != null)
                {
                    _maxEconomy = aircraft.SeatingEconomy;
                    _maxBusiness = aircraft.SeatingBusiness;
                    _maxFirst = aircraft.SeatingFirst;
                }
                if(Flight.FlightPassengerRecords != null)
                {
                    for (int i = 0; i < Flight.FlightPassengerRecords.Count; i++)
                    {
                        // Добавляем контрол для ввода данных по маслу
                        PassengerControl c = new PassengerControl(Flight.FlightPassengerRecords[i]);
                        c.Deleted += ConditionControlDeleted;
                        c.PassengerCountChanged += ControlPassengerCountChanged;
                        c.PassengerCategoryChanged += PassengerCategoryChanged;
                        if (i > 0) c.ShowHeaders = false;
                        flowLayoutPanelMain.Controls.Add(c);

                        countEconomy += c.CountEconomy;
                        countBusiness += c.CountBusiness;
                        countFirst += c.CountFirst;
                    }  
                } 
            }

            flowLayoutPanelMain.Controls.Add(panelAdd);

            double persentEconomy = _maxEconomy != 0 ? countEconomy / _maxEconomy * 100 : 0;
            double persentBusiness = _maxBusiness != 0 ? (countBusiness / _maxBusiness) * 100 : 0;
            double persentFirst = _maxFirst != 0 ? (countFirst / _maxFirst) * 100 : 0;
            double countAll = countFirst + countBusiness + countEconomy;
            _maxAll = _maxEconomy + _maxBusiness + _maxFirst;
            double persentAll = _maxAll != 0 ? (countAll / _maxAll) * 100 : 0;

            textEconomyTotal.Text = countEconomy.ToString();
            textBusinessTotal.Text = countBusiness.ToString();
            textFirstTotal.Text = countFirst.ToString();
            textBoxAllTotal.Text = countAll.ToString();

            textBoxEconomyMax.Text = _maxEconomy.ToString();
            textBoxBusinessMax.Text = _maxBusiness.ToString();
            textBoxFirstMax.Text = _maxFirst.ToString();
            textBoxAllMax.Text = _maxAll.ToString();

            textBoxAllPersents.Text = persentAll.ToString("F") + " %";
            textBoxEconomyPersents.Text = persentEconomy.ToString("F") + " %";
            textBoxBusinessPersents.Text = persentBusiness.ToString("F") + " %";
            textBoxFirstPersents.Text = persentFirst.ToString("F") + " %";
        }
        #endregion

        #region private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PassengerControl performance =
                new PassengerControl(new FlightPassengerRecord { FlightId = Flight.ItemId });
            performance.Deleted += ConditionControlDeleted;
            performance.PassengerCountChanged += ControlPassengerCountChanged;
            performance.PassengerCategoryChanged += PassengerCategoryChanged;
            if (flowLayoutPanelMain.Controls.Count > 1) performance.ShowHeaders = false;
            flowLayoutPanelMain.Controls.Remove(panelAdd);
            flowLayoutPanelMain.Controls.Add(performance);
            flowLayoutPanelMain.Controls.Add(panelAdd);
            performance.Focus();
        }
        #endregion

        #region private void ControlPassengerCountChanged(object sender, EventArgs e)
        private void ControlPassengerCountChanged(object sender, EventArgs e)
        {
            double countEconomy = 0;
            double countBusiness = 0;
            double countFirst = 0;
            double weight = 0;

            List<PassengerControl> fcs = flowLayoutPanelMain.Controls.OfType<PassengerControl>().ToList();

            foreach (PassengerControl fc in fcs)
            {
                countEconomy += fc.CountEconomy;
                countBusiness += fc.CountBusiness;
                countFirst += fc.CountFirst;
                if (fc.PassengerCategory != null)
                    weight += (fc.CountEconomy + fc.CountBusiness + fc.CountFirst)*fc.PassengerCategory.WeightSummer;
            }

            double countAll = countFirst + countBusiness + countEconomy;
            double persentEconomy = _maxEconomy != 0 ? (countEconomy / _maxEconomy) * 100 : 0;
            double persentBusiness = _maxBusiness != 0 ? (countBusiness / _maxBusiness) * 100 : 0;
            double persentFirst = _maxFirst != 0 ? (countFirst / _maxFirst) * 100 : 0;
            double persentAll = _maxAll != 0 ? (countAll / _maxAll) * 100 : 0;

            textEconomyTotal.Text = countEconomy.ToString();
            textBusinessTotal.Text = countBusiness.ToString();
            textFirstTotal.Text = countFirst.ToString();
            textBoxAllTotal.Text = countAll.ToString();

            textBoxAllPersents.Text = persentAll.ToString("F") + " %";
            textBoxEconomyPersents.Text = persentEconomy.ToString("F") + " %";
            textBoxBusinessPersents.Text = persentBusiness.ToString("F") + " %";
            textBoxFirstPersents.Text = persentFirst.ToString("F") + " %";

            InvokePassengersWeightChanget(weight);
        }
        #endregion

        #region private void ConditionControlDeleted(object sender, EventArgs e)

        private void ConditionControlDeleted(object sender, EventArgs e)
        {
            PassengerControl control = (PassengerControl)sender;
            FlightPassengerRecord cond = control.FlightPassengerRecord;

            if (cond.ItemId > 0 && MessageBox.Show("Do you really want to delete flight passenger record?", 
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
                control.PassengerCountChanged -= ControlPassengerCountChanged;
                control.PassengerCategoryChanged -= PassengerCategoryChanged;
                control.Dispose();
            }
            else if (cond.ItemId <= 0)
            {
                flowLayoutPanelMain.Controls.Remove(control);
                control.Deleted -= ConditionControlDeleted;
                control.PassengerCountChanged -= ControlPassengerCountChanged;
                control.PassengerCategoryChanged -= PassengerCategoryChanged;
                control.Dispose();
            }
        }

        #endregion

        #region private void PassengerCategoryChanged(object sender, EventArgs e)
        private void PassengerCategoryChanged(object sender, EventArgs e)
        {
            double weight = 0;

            List<PassengerControl> fcs = flowLayoutPanelMain.Controls.OfType<PassengerControl>().ToList();

            foreach (PassengerControl fc in fcs)
            {
                if (fc.PassengerCategory != null)
                    weight += (fc.CountEconomy + fc.CountBusiness + fc.CountFirst) * fc.PassengerCategory.WeightSummer;
            }
            InvokePassengersWeightChanget(weight);
        }
        #endregion

        #region Events

        ///<summary>
        /// Возникает при изменении состава пассажиров на борту
        ///</summary>
        [Category("Passengers data")]
        [Description("Возникает при изменении топлива на борту")]
        public event ValueChangedEventHandler OnPassengersWeightChanget;

        ///<summary>
        /// Сигнализирует об изменении состава пассажиров на борту
        ///</summary>
        ///<param name="value"></param>
        private void InvokePassengersWeightChanget(double value)
        {
            ValueChangedEventHandler handler = OnPassengersWeightChanget;
            if (handler != null) handler(new ValueChangedEventArgs(value));
        }

        #endregion
    }
}

