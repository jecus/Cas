using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using AvControls;
using CAS.UI.UIControls.KitControls;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Quality;

namespace CAS.UI.UIControls.QualityAssuranceControls
{
    ///<summary>
    /// ЭУ для отображения директивы детали
    ///</summary>
    [Designer(typeof(ProcedureParametersControlDesigner))]
    public partial class ProcedureParametersControl : UserControl
    {
        #region Fields

        private DateTime _effDate = DateTimeExtend.GetCASMinDateTime();
        private Procedure _currentDirective;

        #endregion

        #region Constructor

        #region ProcedureParametersControl()
        ///<summary>
        /// конструктор по умолчанию без параметров
        ///</summary>
        public ProcedureParametersControl()
        {
            InitializeComponent();
        }

        #endregion

        #region public ProcedureParametersControl(Procedure maintenanceDirective) : this()

        /// <summary>
        /// Создает элемент управления, использующийся для редактирования отдельной информации Compliance/Performance
        /// </summary>
        /// <param name="maintenanceDirective">Работа агрегата</param>
        public ProcedureParametersControl(Procedure maintenanceDirective)
            : this()
        {
            _currentDirective = maintenanceDirective;
            UpdateInformation();
        }

        #endregion

        #endregion

        #region Propeties

        #region public Procedure CurrentDirective
        /// <summary>
        /// Текущая директива для отображения
        /// </summary>
        public Procedure CurrentDirective
        {
            get { return _currentDirective; }
            set
            {
                _currentDirective = value;
                UpdateInformation();
            }
        }
        #endregion

        #region public bool isClosed { get; set; }
        ///<summary>
        ///</summary>
        private bool IsClosed { get; set; }

        #endregion

        #region public DateTime EffectiveDate
        /// <summary>
        /// Дата начала использования текущей директивы
        /// </summary>
        public DateTime EffectiveDate
        {
            set { _effDate = value; }
        }

        #endregion

        #endregion

        #region Methods

        #region private void SetTextBoxComponentsString()
        private void SetTextBoxComponentsString()
        {
            //if (_currentDirective.BindDetailDirectives.Count == 0)
            //    textBoxComponents.Text = "Select Items";
            //else if (_currentDirective.BindDetailDirectives.Count(dd => dd.ParentDetail != null) == 0)
            //    textBoxComponents.Text = _currentDirective.BindDetailDirectives.Count + " Items";
            //else
            //{
            //    string directives =
            //        _currentDirective.BindDetailDirectives
            //            .Where(dd => dd.ParentDetail != null)
            //            .Aggregate("", (current, dd) => current + String.Format("P/N:{0} S/N: {1} Desc. {2}",
            //                                                                    dd.ParentDetail.PartNumber,
            //                                                                    dd.ParentDetail.SerialNumber,
            //                                                                    dd.ParentDetail.Description) + "; ");

            //    int nullComponentCount = _currentDirective.BindDetailDirectives.Count(dd => dd.ParentDetail == null);
            //    if (nullComponentCount > 0)
            //        directives += string.Format("and more {0} Items", nullComponentCount);

            //    textBoxComponents.Text = directives;
            //}     
        }
        #endregion

        #region public bool GetChangeStatus()

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        public bool GetChangeStatus()
        {
            double manHours;
            double elapsed;
            double cost;
            if (!CheckDoubleValue("Man Hours", textBoxManHours.Text, out manHours))
                return false;
            if (!CheckDoubleValue("Elapsed", textBoxElapsed.Text, out elapsed))
                return false;
            if (!CheckDoubleValue("Cost", textBoxCost.Text, out cost))
                return false;

            MaintenanceDirectiveThreshold threshold = new MaintenanceDirectiveThreshold();
            threshold.EffectiveDate = _effDate;
            threshold.FirstPerformanceSinceNew = new Lifelength(lifelengthViewer_SinceNew.Lifelength);
            threshold.FirstPerformanceSinceEffectiveDate = new Lifelength(lifelengthViewer_SinceEffDate.Lifelength);
            threshold.FirstNotification = new Lifelength(lifelengthViewer_FirstNotify.Lifelength);
            threshold.RepeatInterval = new Lifelength(lifelengthViewer_Repeat.Lifelength);
            threshold.RepeatNotification = new Lifelength(lifelengthViewer_RepeatNotify.Lifelength);
            threshold.FirstPerformanceConditionType = radio_FirstWhicheverFirst.Checked
                                                      ? ThresholdConditionType.WhicheverFirst
                                                      : ThresholdConditionType.WhicheverLater;
            threshold.RepeatPerformanceConditionType = radio_RepeatWhicheverFirst.Checked
                                                      ? ThresholdConditionType.WhicheverFirst
                                                      : ThresholdConditionType.WhicheverLater; 

            try
            {
                //if (_currentDirective.MaintenanceCheck == null && lookupComboboxMaintenanceCheck.SelectedItemId > 0 ||
                //    _currentDirective.MaintenanceCheck != null && lookupComboboxMaintenanceCheck.SelectedItemId != _currentDirective.MaintenanceCheck.ItemId || 
                //    _currentDirective.ManHours != manHours || 
                //    _currentDirective.Elapsed != elapsed || 
                //    _currentDirective.Cost != cost || 
                //    _currentDirective.NonDestructiveTest != checkBoxNDT.Checked ||
                //    _currentDirective.IsClosed != IsClosed || 
                //    _currentDirective.Threshold.ToString() != threshold.ToString() || 
                //    _currentDirective.WorkType != comboBoxWorkType.SelectedItem)
                //{
                //    return true;
                //}

                if (_currentDirective.ManHours != manHours ||
                    _currentDirective.Elapsed != elapsed ||
                    _currentDirective.Cost != cost ||
                    _currentDirective.IsClosed != IsClosed ||
                    _currentDirective.Threshold.ToString() != threshold.ToString() ||
                    _currentDirective.ProcedureType != comboBoxWorkType.SelectedItem)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
                return true;
            }
            return false;
        }

        #endregion

        #region private void UpdateInformation()

        private void UpdateInformation()
        {
            _effDate = _currentDirective.Threshold.EffectiveDate;

            GlobalObjects.PerformanceCalculator.GetNextPerformance(_currentDirective);

            comboBoxWorkType.Items.Clear();
            CommonDictionaryCollection<ProcedureType> directiveTypes =
                ProcedureType.Items;
            foreach (ProcedureType t in directiveTypes)
            {
                comboBoxWorkType.Items.Add(t);
                if (_currentDirective.ProcedureType == t)
                    comboBoxWorkType.SelectedItem = t;
            }
            if (comboBoxWorkType.SelectedItem == null)
                comboBoxWorkType.SelectedIndex = 0;

            if (_currentDirective.Condition == ConditionState.Overdue)
                imageLinkLabelStatus.Status = Statuses.NotSatisfactory;
            if (_currentDirective.Condition == ConditionState.Notify)
                imageLinkLabelStatus.Status = Statuses.Notify;
            if (_currentDirective.Condition == ConditionState.Satisfactory)
                imageLinkLabelStatus.Status = Statuses.Satisfactory;
            if (Math.Abs(_currentDirective.ManHours) > 0.000001)
                textBoxManHours.Text = _currentDirective.ManHours.ToString();
            if (Math.Abs(_currentDirective.Elapsed) > 0.000001)
                textBoxElapsed.Text = _currentDirective.Elapsed.ToString();
            if (Math.Abs(_currentDirective.Cost) > 0.000001)
                textBoxCost.Text = _currentDirective.Cost.ToString();
            textBoxKitRequired.Text = _currentDirective.Kits.Count + " kits";
            checkBoxClose.Checked = _currentDirective.IsClosed;

            ////MPD Item может иметь привязку либо на MaintenanceCheck либо на Компоненты
            //if (_currentDirective.MaintenanceCheck != null)
            //{
            //    linkLabelEditComponents.Enabled = false;
            //    lookupComboboxMaintenanceCheck.Enabled = true;

            //    _currentDirective.BindDetailDirectives.Clear();
            //}
            //else if(_currentDirective.BindDetailDirectives.Count > 0)
            //{
            //    linkLabelEditComponents.Enabled = true;
            //    lookupComboboxMaintenanceCheck.Enabled = false;
            //}

            SetTextBoxComponentsString();

            #region MaintenanceCheck

            //lookupComboboxMaintenanceCheck.SelectedIndexChanged -= LookupComboboxMaintenanceCheckSelectedIndexChanged;

            //if (_currentDirective.ParentBaseDetail.BaseDetailType == BaseDetailType.Frame)
            //{
            //    string maintenanceScreenDisplayerText =
            //        _currentDirective.ParentBaseDetail.ParentAircraft.RegistrationNumber + " Maintenance Program";
            //    Aircraft pareAircraft = _currentDirective.ParentBaseDetail.ParentAircraft;
            //    lookupComboboxMaintenanceCheck.SetItemsScreenControl<MaintenanceScreen>(new[] { _currentDirective.ParentBaseDetail.ParentAircraft },
            //                                                                               maintenanceScreenDisplayerText);
            //    lookupComboboxMaintenanceCheck.LoadObjectsFunc = GlobalObjects.CasEnvironment.Loader.GetMaintenanceCheck;
            //    lookupComboboxMaintenanceCheck.FilterParam1 = pareAircraft;
            //    lookupComboboxMaintenanceCheck.SelectedItemId = _currentDirective.MaintenanceCheck != null
            //        ? _currentDirective.MaintenanceCheck.ItemId
            //        : -1;
            //    lookupComboboxMaintenanceCheck.UpdateInformation();
            //}

            //lookupComboboxMaintenanceCheck.SelectedIndexChanged += LookupComboboxMaintenanceCheckSelectedIndexChanged;

            #endregion

            if (_currentDirective.Threshold != null)
            {
                lifelengthViewer_SinceNew.Lifelength = _currentDirective.Threshold.FirstPerformanceSinceNew;
                lifelengthViewer_SinceEffDate.Lifelength = _currentDirective.Threshold.FirstPerformanceSinceEffectiveDate;
                lifelengthViewer_FirstNotify.Lifelength = _currentDirective.Threshold.FirstNotification;
                lifelengthViewer_Repeat.Lifelength = _currentDirective.Threshold.RepeatInterval;
                lifelengthViewer_RepeatNotify.Lifelength = _currentDirective.Threshold.RepeatNotification;
                if (_currentDirective.Threshold.FirstPerformanceConditionType == ThresholdConditionType.WhicheverFirst)
                    radio_FirstWhicheverFirst.Checked = true;
                else radio_FirstWhicheverLast.Checked = true;
                if (_currentDirective.Threshold.RepeatPerformanceConditionType == ThresholdConditionType.WhicheverFirst)
                    radio_RepeatWhicheverFirst.Checked = true;
                else radio_RepeatWhicheverLast.Checked = true;
            }
        }

        #endregion

        #region public void ApplyChanges(Procedure destinationItem)

        /// <summary>
        /// Применение изменений
        /// </summary>
        /// <returns></returns>
        public void ApplyChanges(Procedure destinationItem)
        {
            double manHours;
            double elapsed;
            double cost;
            if (!CheckDoubleValue("Man Hours", textBoxManHours.Text, out manHours))
                return;
            if (!CheckDoubleValue("Elapsed", textBoxElapsed.Text, out elapsed))
                return;
            if (!CheckDoubleValue("Cost", textBoxCost.Text, out cost))
                return;
            //_currentDirective.MaintenanceCheck = lookupComboboxMaintenanceCheck.SelectedItem as MaintenanceCheck;
            destinationItem.ProcedureType = ((ProcedureType)comboBoxWorkType.SelectedItem);
            destinationItem.ManHours = manHours;
            destinationItem.Elapsed = elapsed;
            destinationItem.Cost = cost;
            destinationItem.IsClosed = IsClosed;
            //_currentDirective.NonDestructiveTest = checkBoxNDT.Checked;

            MaintenanceDirectiveThreshold threshold = new MaintenanceDirectiveThreshold();
            threshold.EffectiveDate = _effDate;
            threshold.FirstPerformanceSinceNew = new Lifelength(lifelengthViewer_SinceNew.Lifelength);
            threshold.FirstPerformanceSinceEffectiveDate = new Lifelength(lifelengthViewer_SinceEffDate.Lifelength);
            threshold.FirstNotification = new Lifelength(lifelengthViewer_FirstNotify.Lifelength);
            threshold.RepeatInterval = new Lifelength(lifelengthViewer_Repeat.Lifelength);
            threshold.RepeatNotification = new Lifelength(lifelengthViewer_RepeatNotify.Lifelength);
            threshold.FirstPerformanceConditionType = radio_FirstWhicheverFirst.Checked
                                                      ? ThresholdConditionType.WhicheverFirst
                                                      : ThresholdConditionType.WhicheverLater;
            threshold.RepeatPerformanceConditionType = radio_RepeatWhicheverFirst.Checked
                                                     ? ThresholdConditionType.WhicheverFirst
                                                     : ThresholdConditionType.WhicheverLater;
            if (destinationItem.Threshold.ToString() != threshold.ToString())
            {
                destinationItem.Threshold = threshold;
            }
        }

        #endregion

        #region private bool CheckDoubleValue(string paramName, string checkedString, out double value)

        /// <summary>
        /// Проверяет значение ManHours
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="checkedString">Строковое значение value</param>
        /// <param name="value">Значение ManHours</param>
        /// <returns>Возвращает true если значение можно преобразовать в тип double, иначе возвращает false</returns>
        private bool CheckDoubleValue(string paramName, string checkedString, out double value)
        {
            if (checkedString == "")
            {
                value = 0;
                return true;
            }
            if (double.TryParse(checkedString, NumberStyles.Float, new NumberFormatInfo(), out value) == false)
            {
                MessageBox.Show(paramName + ". Invalid value", (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        #endregion

        #region public void ClearFields()

        /// <summary>
        /// Очищает поля
        /// </summary>
        public void ClearFields()
        {
            _currentDirective.Kits.Clear();

            textBoxComponents.Text = "";
            comboBoxWorkType.SelectedItem = null;
            imageLinkLabelStatus.Status = Statuses.NotActive;
            textBoxManHours.Text = "";
            textBoxElapsed.Text = "";
            textBoxCost.Text = "";
            textBoxKitRequired.Text = "";
            checkBoxClose.Checked = false;
            lifelengthViewer_SinceNew.Lifelength = Lifelength.Null;
            lifelengthViewer_SinceEffDate.Lifelength = Lifelength.Null;
            lifelengthViewer_FirstNotify.Lifelength = Lifelength.Null;
            lifelengthViewer_Repeat.Lifelength = Lifelength.Null;
            lifelengthViewer_RepeatNotify.Lifelength = Lifelength.Null;
            radio_FirstWhicheverFirst.Checked = true;
            radio_RepeatWhicheverFirst.Checked = true;
        }

        #endregion

        #region public void CancelAsync()
        ///<summary>
        /// запрашивает отмену асинхронной операции
        ///</summary>
        public void CancelAsync()
        {
            if(lookupComboboxMaintenanceCheck != null)
                lookupComboboxMaintenanceCheck.CancelAsync();
        }
        #endregion

        #region private void LinkLabelEditKitLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        private void LinkLabelEditKitLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KitForm dlg = new KitForm(_currentDirective);
            if (dlg.ShowDialog() == DialogResult.OK)
                textBoxKitRequired.Text = _currentDirective.Kits.Count + " kits";
        }
        #endregion

        #region private void CheckBoxCloseCheckedChanged(object sender, EventArgs e)
        private void CheckBoxCloseCheckedChanged(object sender, EventArgs e)
        {
            IsClosed = checkBoxClose.Checked;
        }
        #endregion

        #region private void LookupComboboxMaintenanceCheckSelectedIndexChanged(object sender, EventArgs e)
        private void LookupComboboxMaintenanceCheckSelectedIndexChanged(object sender, EventArgs e)
        {
            //if (lookupComboboxMaintenanceCheck.SelectedItem != null)
            //{
            //    MaintenanceCheck mc = (MaintenanceCheck)lookupComboboxMaintenanceCheck.SelectedItem;

            //    lifelengthViewer_SinceNew.Lifelength = mc.Interval;
            //    lifelengthViewer_SinceEffDate.Lifelength = Lifelength.Null;
            //    lifelengthViewer_FirstNotify.Lifelength = mc.Notify;
            //    lifelengthViewer_Repeat.Lifelength = mc.Interval;
            //    lifelengthViewer_RepeatNotify.Lifelength = mc.Notify;
            //    radio_FirstWhicheverFirst.Checked = true;
            //    radio_RepeatWhicheverFirst.Checked = true;

            //    lifelengthViewer_SinceNew.Enabled = false;
            //    lifelengthViewer_SinceEffDate.Enabled = false;
            //    lifelengthViewer_FirstNotify.Enabled = false;
            //    lifelengthViewer_Repeat.Enabled = false;
            //    lifelengthViewer_RepeatNotify.Enabled = false;
            //    radio_FirstWhicheverFirst.Enabled = false;
            //    radio_RepeatWhicheverFirst.Enabled = false;
            //}
            //else
            //{
            //    lifelengthViewer_SinceNew.Enabled = true;
            //    lifelengthViewer_SinceEffDate.Enabled = true;
            //    lifelengthViewer_FirstNotify.Enabled = true;
            //    lifelengthViewer_Repeat.Enabled = true;
            //    lifelengthViewer_RepeatNotify.Enabled = true;
            //    radio_FirstWhicheverFirst.Enabled = true;
            //    radio_RepeatWhicheverFirst.Enabled = true;
            //}
        }
        #endregion

        #region private void LinkLabelEditComponentsLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        private void LinkLabelEditComponentsLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //MaintenanceDirectiveBindDetailForm dlg = new MaintenanceDirectiveBindDetailForm(_currentDirective);
            //dlg.ShowDialog();

            //SetTextBoxComponentsString();
        }
        #endregion

        #endregion
    }

    #region internal class ProcedureParametersControlDesigner : ControlDesigner

    internal class ProcedureParametersControlDesigner : ControlDesigner
    {
        protected override void PostFilterProperties(IDictionary properties)
        {
            base.PostFilterProperties(properties);
            properties.Remove("CurrentDirective");
            properties.Remove("Interval");
            properties.Remove("IsClosed");
        }
    }
    #endregion
}
