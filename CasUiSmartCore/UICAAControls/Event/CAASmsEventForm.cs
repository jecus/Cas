using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UICAAControls.Event;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.CAA.Event;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.SMS;

namespace CAS.UI.UIControls.SMSControls
{
    ///<summary>
    /// Форма для редактирования типа события системы безопасности полетов
    ///</summary>
    public partial class CAASmsEventForm : MetroForm
    {
        private CAAEvent _smsEvent;

        #region public SmsEventForm()

        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        public CAASmsEventForm()
        {
            InitializeComponent();
        }

        #endregion

        #region public SmsEventForm()

        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        public CAASmsEventForm(CAAEvent smsEvent)
            : this()
        {
            _smsEvent = smsEvent;
            FillControls();
        }

        #endregion

        #region private void SetRiskIndex()

        private void SetRiskIndex()
        {
            EventCategory cat = dictionaryComboBoxCategory.SelectedItem as EventCategory;
            EventClass eventClass = dictionaryComboEventClass.SelectedItem as EventClass;
            if (cat != null && eventClass != null)
            {
                textBoxRiskIndex.Text = eventClass.Weight + cat.ShortName +
                    (eventClass.Weight * cat.Weight);

            }
            else textBoxRiskIndex.Text = "";
        }
        #endregion

        #region private void FillControls()
        /// <summary>
        /// Обновляет значения полей
        /// </summary>
        private void FillControls()
        {
            Program.MainDispatcher.ProcessControl(dictionaryComboEventType);
            Program.MainDispatcher.ProcessControl(dictionaryComboEventClass);
            Program.MainDispatcher.ProcessControl(dictionaryComboBoxCategory);

            foreach (Control c in flowLayoutPanelConditions.Controls)
            {
                if(c != panelAddCondition) c.Dispose();
            }
            flowLayoutPanelConditions.Controls.Clear();

            dictionaryComboEventType.SelectedIndexChanged -= LookupComboboxEventTypeSelectedIndexChanged;
            dictionaryComboEventClass.SelectedIndexChanged -= DictionaryComboEventClassSelectedIndexChanged;
            dictionaryComboBoxCategory.SelectedIndexChanged -= DictionaryComboBoxCategorySelectedIndexChanged;

            comboBoxIncident.Items.Clear();
            foreach (IncidentType o in IncidentType.Items)
                comboBoxIncident.Items.Add(o);

            dictionaryComboEventClass.Type = typeof(CAAEventClass);
            dictionaryComboBoxCategory.Type = typeof(CAAEventCategory);

            dictionaryComboEventType.Type = typeof(CAASmsEventType);
            dictionaryComboEventType.ScreenControl = new CAAEventTypesListScreen();

            if (_smsEvent != null)
            {
                dictionaryComboEventType.SelectedItem = _smsEvent.EventType;
                dictionaryComboBoxCategory.SelectedItem = _smsEvent.EventCategory;
                dictionaryComboEventClass.SelectedItem = _smsEvent.EventClass;
                comboBoxIncident.SelectedItem = _smsEvent.IncidentType;
                dateTimePickerEventDate.Value = _smsEvent.RecordDate;
                textBoxDescription.Text = _smsEvent.Description;
                textBoxRemarks.Text = _smsEvent.Remarks;

                foreach (var condition in _smsEvent.EventConditions)
                {
                    var newControl = new CAASmsConditionControl(condition);
                    newControl.Deleted += ConditionControlDeleted;
                    if (flowLayoutPanelConditions.Controls.Count >= 1) newControl.ShowHeaders = false;
                    flowLayoutPanelConditions.Controls.Add(newControl);
                }
            }
            flowLayoutPanelConditions.Controls.Add(panelAddCondition);

            SetRiskIndex();

            dictionaryComboEventType.SelectedIndexChanged += LookupComboboxEventTypeSelectedIndexChanged;
            dictionaryComboEventClass.SelectedIndexChanged += DictionaryComboEventClassSelectedIndexChanged;
            dictionaryComboBoxCategory.SelectedIndexChanged += DictionaryComboBoxCategorySelectedIndexChanged;
            
            flowLayoutPanelConditions.Controls.Add(panelAddCondition);
        }
        #endregion

        #region private bool GetChangeStatus()
        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        private bool GetChangeStatus(CAAEvent obj)
        {
            if (textBoxDescription.Text != obj.Description 
                ||  dictionaryComboEventType.SelectedItem != _smsEvent.EventType
                || dictionaryComboBoxCategory.SelectedItem != _smsEvent.EventCategory
                || dictionaryComboEventClass.SelectedItem != _smsEvent.EventClass
                || comboBoxIncident.SelectedItem != _smsEvent.IncidentType
                || dateTimePickerEventDate.Value != _smsEvent.RecordDate
                || textBoxDescription.Text != _smsEvent.Description
                || textBoxRemarks.Text != _smsEvent.Remarks)
            {
                return true;
            }

            //Проверка на содержание объекта в коллекции
            IEnumerable<CAASmsConditionControl> conds = flowLayoutPanelConditions.Controls.OfType<CAASmsConditionControl>();
            if (conds.Select(scc => _smsEvent.EventConditions.GetItemById(scc.EventCondition.ItemId)).Any(r => r == null))
            {
                return true;
            }
            //Проверка на null-значение объекта находящагося в коллекции при не-null-значении объекта в контроле
            if (conds.Any(cond => _smsEvent.EventConditions.GetItemById(cond.EventCondition.ItemId).Value == null 
                               && cond.ConditionValue != null))
            {
                return true;
            }

            //Проверка эквивалентность значений объектов в коллекции и контролах
            if (conds.Any(cond => !_smsEvent.EventConditions.GetItemById(cond.EventCondition.ItemId).Value.Equals(cond.ConditionValue)))
            {
                return true;
            }
            return false;
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

            if (textBoxDescription.Text == "")
            {
                if (message != "") message += "\n ";
                message += "Not set Description";
                return false;
            }

            if (flowLayoutPanelConditions.Controls.OfType<SmsConditionControl>().Any(scc => !scc.CheckData()))
            {
                if (message != "") message += "\n ";
                message += "Not specified event condition or " + 
                           "\nthe selected item is not the end node of the tree";
                return false;
            }
            return true;
        }

        #endregion

        #region private void ApplyChanges(BaseSmartCoreObject obj)
        /// <summary>
        /// Применить к объекту сделанные изменения на контроле. 
        /// Если не все данные удовлетворяют формату ввода (например при вводе чисел), свойства объекта не изменяются, возвращается false
        /// Вызов base.ApplyChanges() обязателен
        /// </summary>
        /// <returns></returns>
        private void ApplyChanges(CAAEvent obj)
        {
            obj.EventType = dictionaryComboEventType.SelectedItem as CAASmsEventType;
            obj.EventCategory = dictionaryComboBoxCategory.SelectedItem as CAAEventCategory;
            obj.EventClass = dictionaryComboEventClass.SelectedItem as CAAEventClass;
            obj.IncidentType = comboBoxIncident.SelectedItem as IncidentType;
            obj.RecordDate = dateTimePickerEventDate.Value;
            obj.Description = textBoxDescription.Text;
            obj.Remarks = textBoxRemarks.Text;

            obj.EventConditions.Clear();
            foreach (var smsConditionControl in flowLayoutPanelConditions.Controls.OfType<CAASmsConditionControl>())
            {
                smsConditionControl.ApplyChanges();
                obj.EventConditions.Add(smsConditionControl.EventCondition);
            }
        }
        #endregion

        #region private void Save()
        private void Save()
        {
            try
            {
                GlobalObjects.CaaEnvironment.NewKeeper.Save(_smsEvent);

                foreach (var eventCondition in _smsEvent.EventConditions)
                {
                    eventCondition.ParentId = _smsEvent.ItemId;
                    eventCondition.ParentType = _smsEvent.SmartCoreObjectType;
                    eventCondition.OperatorId = _smsEvent.OperatorId;
                    GlobalObjects.CaaEnvironment.NewKeeper.Save(eventCondition);
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while save SMS Event", ex);
            }
        }
        #endregion

        #region private void LookupComboboxDefferedSelectedIndexChanged(object sender, EventArgs e)
        private void LookupComboboxEventTypeSelectedIndexChanged(object sender, EventArgs e)
        {
            SmsEventType eventType = dictionaryComboEventType.SelectedItem as SmsEventType;
            if (eventType != null && _smsEvent != null && _smsEvent.ItemId <= 0)
            {
                textBoxDescription.Text = eventType.Description;
                dictionaryComboEventClass.SelectedItem = eventType.EventClass;
                dictionaryComboBoxCategory.SelectedItem = eventType.EventCategory;
                comboBoxIncident.SelectedItem = eventType.IncidentType;
            }
        }
        #endregion

        #region private void DictionaryComboEventClassSelectedIndexChanged(object sender, EventArgs e)

        private void DictionaryComboEventClassSelectedIndexChanged(object sender, EventArgs e)
        {
            SetRiskIndex();
        }
        #endregion

        #region private void DictionaryComboBoxCategorySelectedIndexChanged(object sender, EventArgs e)

        private void DictionaryComboBoxCategorySelectedIndexChanged(object sender, EventArgs e)
        {
            SetRiskIndex();
        }
        #endregion

        #region private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        private void LinkLabelAddNewConditionLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(_smsEvent == null) return;

            SmsConditionControl performance =
                new SmsConditionControl(new EventCondition {ParentId = _smsEvent.ItemId});
            performance.Deleted += ConditionControlDeleted;
            if (flowLayoutPanelConditions.Controls.Count > 1) performance.ShowHeaders = false;
            flowLayoutPanelConditions.Controls.Remove(panelAddCondition);
            flowLayoutPanelConditions.Controls.Add(performance);
            flowLayoutPanelConditions.Controls.Add(panelAddCondition);
            performance.Focus();
        }
        #endregion

        #region private void ConditionControlDeleted(object sender, EventArgs e)

        private void ConditionControlDeleted(object sender, EventArgs e)
        {
            var control = (CAASmsConditionControl)sender;
            var cond = control.EventCondition;

            if (cond.ItemId > 0 && MessageBox.Show("Do you really want to delete event condition?", "Deleting confirmation", 
                                                   MessageBoxButtons.YesNoCancel, 
                                                   MessageBoxIcon.Exclamation, 
                                                   MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //если информация о состоянии сохранена в БД 
                //и получен положительный ответ на ее удаление
                try
                {
                    GlobalObjects.NewKeeper.Delete(cond);
                    _smsEvent.EventConditions.Remove(cond);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while removing data", ex);
                }

                flowLayoutPanelConditions.Controls.Remove(control);
                control.Deleted -= ConditionControlDeleted;
                control.Dispose();
            }
            else if (cond.ItemId <= 0)
            {
                flowLayoutPanelConditions.Controls.Remove(control);
                control.Deleted -= ConditionControlDeleted;
                control.Dispose();
            }
        }

        #endregion

        #region private void ButtonCancelClick(object sender, EventArgs e)

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            if(_smsEvent != null)
            {
                if (GetChangeStatus(_smsEvent))
                {
                    DialogResult result = MessageBox.Show("Do you want to save changes?",
                                                          (string)new GlobalTermsProvider()["SystemName"],
                                                          MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation,
                                                          MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Cancel)
                    {
                        DialogResult = DialogResult.None;
                        return;
                    }
                    if (result == DialogResult.No)
                    {
                        DialogResult = DialogResult.Cancel;
                        Close();
                    }
                    else
                    {
                        string message;
                        if (!ValidateData(out message))
                        {
                            message += "\nAbort operation";
                            MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        ApplyChanges(_smsEvent);
                        Save();
                    }
                }
                else
                {
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
            }
            else
            {
                DialogResult = DialogResult.Cancel;
                Close();    
            }
        }

        #endregion

        #region private void ButtonOkClick(object sender, EventArgs e)

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
            if (GetChangeStatus(_smsEvent))
            {
                DialogResult result = MessageBox.Show("Do you want to save changes?",
                                                      (string) new GlobalTermsProvider()["SystemName"],
                                                      MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation,
                                                      MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Cancel)
                {
                    AcceptButton.DialogResult = DialogResult.Cancel;
                    return;
                }
                if (result == DialogResult.No)
                {
                    DialogResult = DialogResult.Cancel;
                    Close();    
                }
                else
                {
                    ApplyChanges(_smsEvent);
                    Save();
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        #endregion
    }
}
