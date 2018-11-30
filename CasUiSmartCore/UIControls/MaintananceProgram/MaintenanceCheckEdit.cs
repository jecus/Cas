using System;
using System.Windows.Forms;
using CAS.UI.UIControls.KitControls;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace CAS.UI.UIControls.MaintananceProgram
{
    ///<summary>
    ///</summary>
    public partial class MaintenanceCheckEdit : Form
    {
        #region Fields
        private MaintenanceCheck _maintenanceLiminationItem;
        private MaintenanceCheckCollection _allMaintenanceChecks = new MaintenanceCheckCollection();
        #endregion

        #region Constructor
        ///<summary>
        ///</summary>
        public MaintenanceCheckEdit()
        {
            InitializeComponent();
        }
        ///<summary>
        ///</summary>
        ///<param name="maintenanceLiminationItem"></param>
        public MaintenanceCheckEdit(MaintenanceCheck maintenanceLiminationItem) : this()
        {
            _maintenanceLiminationItem = maintenanceLiminationItem;
        }

        #endregion

        #region Methods

        #region private void UpdateInformation()

        private void UpdateInformation()
        {
            if (_maintenanceLiminationItem.ParentAircraft.ItemId > 0)
            {
                _textBoxName.Text = _maintenanceLiminationItem.Name;

                _lifelengthViewerNotify.Lifelength = _maintenanceLiminationItem.Notify;
                _lifelengthViewerInterval.Lifelength = _maintenanceLiminationItem.Interval;

                numericUpDownCost.Value = (decimal)_maintenanceLiminationItem.Cost;
                numericUpDownManHours.Value = (decimal)_maintenanceLiminationItem.ManHours;

                textBoxKitRequired.Text = _maintenanceLiminationItem.Kits.Count + " kits";
                _comboBoxCheckType.Type = typeof(MaintenanceCheckType);
                _comboBoxCheckType.SelectedItem = _maintenanceLiminationItem.CheckType;
                Program.MainDispatcher.ProcessControl(_comboBoxCheckType);
            }

            comboBoxMainSource.SelectedItem = _maintenanceLiminationItem.Resource;
            checkBoxSchedule.Checked = _maintenanceLiminationItem.Schedule;
            checkBoxGrouping.Checked = _maintenanceLiminationItem.Grouping;
        }
        #endregion

        #region private void FillCheckType()
        private void FillCheckType()
        {
            _comboBoxCheckType.Type = typeof(MaintenanceCheckType);
            _comboBoxCheckType.SelectedItem = _maintenanceLiminationItem.CheckType;
            Program.MainDispatcher.ProcessControl(_comboBoxCheckType);

            _allMaintenanceChecks.Clear();
            if (_maintenanceLiminationItem.ParentAircraft != null)
            {
                _allMaintenanceChecks.AddRange(
                    GlobalObjects.MaintenanceCore
                    .GetMaintenanceCheck(_maintenanceLiminationItem.ParentAircraft,
                                         _maintenanceLiminationItem.ParentAircraft.Schedule));
            }

            //comboBoxWhickDependetChecks.Items.Clear();
            //foreach (MaintenanceCheck check in _allMaintenanceChecks)
            //{
            //    if(check.ItemId != _maintenanceLiminationItem.ItemId)
            //        comboBoxWhickDependetChecks.Items.Add(check);
            //}

            //comboBoxDependedSource.Items.Clear();
            comboBoxMainSource.Items.Clear();
            foreach (object o in Enum.GetValues(typeof(LifelengthSubResource)))
            {
                if ((LifelengthSubResource)o == LifelengthSubResource.Minutes)
                    continue;
                //comboBoxDependedSource.Items.Add(o);
                comboBoxMainSource.Items.Add(o);
            }


        }
        #endregion

        #region private bool ValidateData(out string message)
        /// <summary>
        /// Возвращает значение, показывающее является ли значение элемента управления допустимым
        /// </summary>
        /// <returns></returns>
        private bool ValidateData(out string message)
        {
            message = "";
            if (_comboBoxCheckType.SelectedItem == null)
            {
                message = "Select check type";
                return false;
            }

            if (comboBoxMainSource.SelectedItem == null || 
                !(comboBoxMainSource.SelectedItem is LifelengthSubResource))
            {
                message = "Not set main source";
                return false;
            }

            LifelengthSubResource sub = (LifelengthSubResource)comboBoxMainSource.SelectedItem;

            int? subSource = _lifelengthViewerInterval.Lifelength.GetSubresource(sub);

            if (subSource == null || subSource == 0)
            {
                message = "Enter correct interval." +
                          "\n" + sub + " must be > 0.";
                return false;
            }

            #region проверка на кратность интервала
            if(checkBoxGrouping.Checked)
            {
                //(для групповых чеков)

                //поиск минимального чека по заданному типу программы обслуживания
                MaintenanceCheck mc = _allMaintenanceChecks.GetMinStepCheck(checkBoxSchedule.Checked, checkBoxGrouping.Checked, sub);
                //если минимальный чек есть, то производится проверка на кратность интервала
                if (mc != null && mc.ItemId != _maintenanceLiminationItem.ItemId)
                {
                    int? minStep = mc.Interval.GetSubresource(sub);
                    if (minStep == null || minStep < 0) return true;
                    if (subSource > minStep && (subSource.Value % minStep.Value) > 0)
                    {
                        //интервал редактируемого чека больше интервала минимального чека
                        message = "interval of check must be a multiple of " + minStep.Value;
                        return false;
                    }
                    if (subSource < minStep && (minStep.Value % subSource.Value) > 0)
                    {
                        //интервал редактируемого чека меньше интервала минимального чека
                        message = "interval of check must be a fraction of " + minStep.Value;
                        return false;
                    }
                }
                //если минимального чека нет, то интевал редактируемого чека и будет минимальным   
            }
            #endregion

            #region Проверка корректности данных, зависящих от выполнения другого чека
            //if (checkBoxDependet.Checked)
            //{
            //    if(comboBoxWhickDependetChecks.SelectedItem == null)
            //    {
            //        message = "Not set check, which depends current check";
            //        return false;
            //    }
            //    if (comboBoxDependedSource.SelectedItem == null)
            //    {
            //        message = "Not set depended source";
            //        return false;
            //    }
            //    if (comboBoxMainSource.SelectedItem == null)
            //    {
            //        message = "Not set main source";
            //        return false;
            //    }

            //    LifelengthSubResource depends = 
            //        (LifelengthSubResource)comboBoxDependedSource.SelectedItem;
            //    LifelengthSubResource main =
            //        (LifelengthSubResource) comboBoxMainSource.SelectedItem;
            //    if(depends == main)
            //    {
            //        message = "Main and Dependent resources should not be equal";
            //        return false;    
            //    }

            //    MaintenanceCheck wdmc = (MaintenanceCheck) comboBoxWhickDependetChecks.SelectedItem;
            //    int? whichDepends = wdmc.Interval.GetSubresource(depends);

            //    if (whichDepends == null || whichDepends == 0)
            //    {
            //        message = "In check, on which depends the execution of the check is not specified dependent resources";
            //        return false;
            //    }
            //}
            #endregion

            return true;
        }

        #endregion

        #region private void Save()
        private void Save()
        {
            _maintenanceLiminationItem.Name = _textBoxName.Text;
            _maintenanceLiminationItem.CheckType = _comboBoxCheckType.SelectedItem as MaintenanceCheckType ?? MaintenanceCheckType.Unknown;

            _maintenanceLiminationItem.Notify = _lifelengthViewerNotify.Lifelength;
            _maintenanceLiminationItem.Interval = _lifelengthViewerInterval.Lifelength;

            _maintenanceLiminationItem.ManHours = (double)numericUpDownManHours.Value;
            _maintenanceLiminationItem.Cost = (double)numericUpDownCost.Value;

            _maintenanceLiminationItem.Resource = (LifelengthSubResource)comboBoxMainSource.SelectedItem;
            _maintenanceLiminationItem.Schedule = checkBoxSchedule.Checked;
            _maintenanceLiminationItem.Grouping = checkBoxGrouping.Checked;

            //_maintenanceLiminationItem.Dependent = checkBoxDependet.Checked;
            //if(_maintenanceLiminationItem.Dependent)
            //{
            //    _maintenanceLiminationItem.WhichDependsCheckId =
            //        ((MaintenanceCheck) comboBoxWhickDependetChecks.SelectedItem).ItemId;
            //    _maintenanceLiminationItem.DependSubResource =
            //        (LifelengthSubResource) comboBoxDependedSource.SelectedItem;
            //    _maintenanceLiminationItem.MainSubResource =
            //        (LifelengthSubResource)comboBoxMainSource.SelectedItem;
            //}

            GlobalObjects.CasEnvironment.NewKeeper.Save(_maintenanceLiminationItem);
        }

        #endregion

        #region private void ButtonCancelClick(object sender, System.EventArgs e)
        private void ButtonCancelClick(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region private void ButtonOkClick(object sender, System.EventArgs e)
        private void ButtonOkClick(object sender, EventArgs e)
        {
            string message;
            if (!ValidateData(out message))
            {
                message += "\nAbort operation";
                MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Save();
            Close();
        }
        #endregion

        #region private void CheckBoxScheduleCheckedChanged(object sender, System.EventArgs e)
        private void CheckBoxScheduleCheckedChanged(object sender, EventArgs e)
        {
            _lifelengthViewerInterval.EnabledCycle = checkBoxSchedule.Checked;
            _lifelengthViewerInterval.EnabledHours = checkBoxSchedule.Checked;
            _lifelengthViewerNotify.EnabledCycle = checkBoxSchedule.Checked;
            _lifelengthViewerNotify.EnabledHours = checkBoxSchedule.Checked;
        }
        #endregion

        #region private void LinkLabelEditKitLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        private void LinkLabelEditKitLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KitForm dlg = new KitForm(_maintenanceLiminationItem);
            if (dlg.ShowDialog() == DialogResult.OK)
                textBoxKitRequired.Text = _maintenanceLiminationItem.Kits.Count + " kits";
        }
        #endregion

        #region private void MaintenanceLimitationEditLoad(object sender, System.EventArgs e)
        private void MaintenanceLimitationEditLoad(object sender, EventArgs e)
        {
            FillCheckType();
            UpdateInformation();
            CheckBoxScheduleCheckedChanged(null, null);
        }
        #endregion

        #region private void CheckBoxDependetCheckedChanged(object sender, System.EventArgs e)
        //private void CheckBoxDependetCheckedChanged(object sender, EventArgs e)
        //{
        //    comboBoxWhickDependetChecks.Enabled = checkBoxDependet.Checked;
        //    comboBoxDependedSource.Enabled = checkBoxDependet.Checked;
        //    comboBoxMainSource.Enabled = checkBoxDependet.Checked;
        //}
        #endregion

        #endregion
    }
}
