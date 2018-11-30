using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.SMS;

namespace CAS.UI.UIControls.SMSControls
{
    ///<summary>
    /// Форма для редактирования типа события системы безопасности полетов
    ///</summary>
    public partial class SmsEventTypeForm : Form
    {
        private readonly Type _viewedType = typeof (EventTypeRiskLevelChangeRecord);
        private readonly SmsEventType _smsEventType;

        #region public SmsEventTypeForm()

        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        public SmsEventTypeForm()
        {
            InitializeComponent();
        }

        #endregion

        #region public SmsEventTypeForm( SmsEventType smsEventType) : this()

        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        public SmsEventTypeForm( SmsEventType smsEventType) : this()
        {
            _smsEventType = smsEventType;
            SetHeaders();
            FillControls();
        }

        #endregion

        #region private List<PropertyInfo> GetTypeProperties()
        private List<PropertyInfo> GetTypeProperties()
        {
            if (_viewedType == null)
                throw new NullReferenceException("_viewedType is null");
            //определение своиств, имеющих атрибут "отображаемое в списке"
            List<PropertyInfo> properties =
                _viewedType.GetProperties().Where(p => p.GetCustomAttributes(typeof(ListViewDataAttribute), false).Length != 0).ToList();

            //поиск своиств у которых задан порядок отображения
            //своиства, имеющие порядок отображения
            Dictionary<int, PropertyInfo> orderedProperties = new Dictionary<int, PropertyInfo>();
            //своиства, НЕ имеющие порядок отображения
            List<PropertyInfo> unOrderedProperties = new List<PropertyInfo>();
            foreach (PropertyInfo propertyInfo in properties)
            {
                ListViewDataAttribute lvda = (ListViewDataAttribute)
                    propertyInfo.GetCustomAttributes(typeof(ListViewDataAttribute), false).FirstOrDefault();
                if (lvda.Order > 0) orderedProperties.Add(lvda.Order, propertyInfo);
                else unOrderedProperties.Add(propertyInfo);
            }

            var ordered = orderedProperties.OrderBy(p => p.Key).ToList();

            properties.Clear();
            properties.AddRange(ordered.Select(keyValuePair => keyValuePair.Value));
            properties.AddRange(unOrderedProperties);

            return properties;

        }
        #endregion

        #region private void SetHeaders()
        /// <summary>
        /// Устанавливает заголовки
        /// </summary>
        private void SetHeaders()
        {
            listViewCompliance.Columns.Clear();

            try
            {
                List<PropertyInfo> properties = GetTypeProperties();
                ColumnHeader columnHeader;
                foreach (PropertyInfo propertyInfo in properties)
                {
                    ListViewDataAttribute attr =
                        (ListViewDataAttribute)propertyInfo.GetCustomAttributes(typeof(ListViewDataAttribute), false)[0];
                    columnHeader = new ColumnHeader();
                    columnHeader.Width = (int)(listViewCompliance.Width * attr.HeaderWidth);
                    columnHeader.Text = attr.Title;
                    columnHeader.Tag = propertyInfo.PropertyType;
                    listViewCompliance.Columns.Add(columnHeader);
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while building list headers", ex);
                return;
            }
        }
        #endregion

        #region private ListViewItem.ListViewSubItem[] GetListViewSubItems(EventTypeRiskLevelChangeRecord item)

        private ListViewItem.ListViewSubItem[] GetListViewSubItems(EventTypeRiskLevelChangeRecord item)
        {
            List<PropertyInfo> properties = GetTypeProperties();

            ListViewItem.ListViewSubItem[] subItems = new ListViewItem.ListViewSubItem[properties.Count];
            for (int i = 0; i < properties.Count; i++)
            {
                object value = properties[i].GetValue(item, null);
                if (value != null)
                {
                    string valueString;
                    if (value is DateTime)
                        valueString = SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)value);
                    else valueString = value.ToString();


                    subItems[i] = new ListViewItem.ListViewSubItem
                    {
                        Text = valueString,
                        Tag = value
                    };
                }
                else
                {
                    subItems[i] = new ListViewItem.ListViewSubItem
                    {
                        Text = "",
                        Tag = ""
                    };
                }
            }
            return subItems;
        }

        #endregion

        #region private void AddPerformance()
        private void AddPerformance()
        {
            try
            {
                EventTypeRiskLevelChangeRecord newRecord =
                    new EventTypeRiskLevelChangeRecord { ParentEventType = _smsEventType };
                CommonEditorForm form = new CommonEditorForm(newRecord);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    listViewCompliance.Items.Add(new ListViewItem(GetListViewSubItems(newRecord), null) { Tag = newRecord });
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while building new object", ex);
                return;
            }
        }
        #endregion

        #region private void EditPerformance()
        private void EditPerformance()
        {
            if (listViewCompliance.SelectedItems.Count == 0 
                || !(listViewCompliance.SelectedItems[0].Tag is EventTypeRiskLevelChangeRecord))
            {
                return;
            }

            EventTypeRiskLevelChangeRecord changeRecord =
                listViewCompliance.SelectedItems[0].Tag as EventTypeRiskLevelChangeRecord;
            CommonEditorForm form = new CommonEditorForm(changeRecord);
            if (form.ShowDialog() == DialogResult.OK)
            {
                listViewCompliance.Items[listViewCompliance.Items.IndexOf(listViewCompliance.SelectedItems[0])] =
                    new ListViewItem(GetListViewSubItems(changeRecord), null) { Tag = changeRecord };
            }
        }
        #endregion

        #region private void DeletePerformance()
        private void DeletePerformance()
        {
            if (listViewCompliance.SelectedItems.Count == 0
                || !(listViewCompliance.SelectedItems[0].Tag is EventTypeRiskLevelChangeRecord))
            {
                return;
            }

            DialogResult confirmResult =
               MessageBox.Show(listViewCompliance.SelectedItems.Count == 1
                       ? "Do you really want to delete risk level record " + listViewCompliance.SelectedItems[0].Tag + "?"
                       : "Do you really want to delete selected level records?", "Confirm delete operation",
                   MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (confirmResult == DialogResult.Yes)
            {
                listViewCompliance.BeginUpdate();
                foreach (ListViewItem lvi in listViewCompliance.SelectedItems)
                {
                    EventTypeRiskLevelChangeRecord changeRecord = lvi.Tag as EventTypeRiskLevelChangeRecord;
                    
                    if(changeRecord == null) continue;

                    try
                    {
                        GlobalObjects.CasEnvironment.NewKeeper.Delete(changeRecord, true);
                    }
                    catch (Exception ex)
                    {
                        Program.Provider.Logger.Log("Error while deleting data", ex);
                        return;
                    }
                }
                listViewCompliance.EndUpdate();
            }
        }
        #endregion

        #region public void FillControls()
        /// <summary>
        /// Обновляет значения полей
        /// </summary>
        public void FillControls()
        {
            textBoxDescription.Text = _smsEventType.Description;
            textBoxName.Text = _smsEventType.FullName;

            foreach (Control c in flowLayoutPanelConditions.Controls)
            {
                if(c != panelAddCondition) c.Dispose();
            }
            flowLayoutPanelConditions.Controls.Clear();
            listViewCompliance.Items.Clear();

            if (_smsEventType != null)
            {
                textBoxDescription.Text = _smsEventType.Description;
                textBoxName.Text = _smsEventType.FullName;

                foreach (EventCondition condition in _smsEventType.EventConditions)
                {
                    SmsConditionControl newControl = new SmsConditionControl(condition);
                    newControl.Deleted += ConditionControlDeleted;
                    if (flowLayoutPanelConditions.Controls.Count >= 1) 
                        newControl.ShowHeaders = false;
                    flowLayoutPanelConditions.Controls.Add(newControl);
                }

                foreach (EventTypeRiskLevelChangeRecord record in _smsEventType.ChangeRecords)
                {
                    listViewCompliance.Items.Add(new ListViewItem(GetListViewSubItems(record), null) { Tag = record });
                }
            }
            
            flowLayoutPanelConditions.Controls.Add(panelAddCondition);
        }
        #endregion

        #region private bool GetChangeStatus()
        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        private bool GetChangeStatus(SmsEventType obj)
        {
            if (textBoxDescription.Text != obj.Description || textBoxName.Text != obj.FullName)
            {
                return true;
            }

            //Проверка на содержание объекта в коллекции
            IEnumerable<SmsConditionControl> conds = flowLayoutPanelConditions.Controls.OfType<SmsConditionControl>();
            if (conds.Select(scc => _smsEventType.EventConditions.GetItemById(scc.EventCondition.ItemId)).Any(r => r == null))
            {
                return true;
            }
            //Проверка на null-значение объекта находящагося в коллекции при не-null-значении объекта в контроле
            if (conds.Any(cond => _smsEventType.EventConditions.GetItemById(cond.EventCondition.ItemId).Value == null 
                               && cond.ConditionValue != null))
            {
                return true;
            }

            //Проверка эквивалентность значений объектов в коллекции и контролах
            if (conds.Any(cond => !_smsEventType.EventConditions.GetItemById(cond.EventCondition.ItemId).Value.Equals(cond.ConditionValue != null)))
            {
                return true;
            }


            IEnumerable<EventTypeRiskLevelChangeRecord> records =
                                listViewCompliance.Items
                                .OfType<ListViewItem>()
                                .Where(lvi => lvi.Tag != null && lvi.Tag is EventTypeRiskLevelChangeRecord)
                                .Select(lvi => lvi.Tag as EventTypeRiskLevelChangeRecord);

            foreach (EventTypeRiskLevelChangeRecord changeRecord in records)
            {
                EventTypeRiskLevelChangeRecord r = _smsEventType.ChangeRecords.GetItemById(changeRecord.ItemId);
                if (r == null || !r.Equals(changeRecord)) return true;
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
            if (textBoxName.Text == "")
            {
                if (message != "") message += "\n ";
                message += "Not set Name";
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
        private void ApplyChanges(SmsEventType obj)
        {
            obj.Description = textBoxDescription.Text;
            obj.FullName = textBoxName.Text;

            obj.EventConditions.Clear();
            foreach (SmsConditionControl smsConditionControl in flowLayoutPanelConditions.Controls.OfType<SmsConditionControl>())
            {
                smsConditionControl.ApplyChanges();  
                obj.EventConditions.Add(smsConditionControl.EventCondition);
            }

            IEnumerable<EventTypeRiskLevelChangeRecord> records =
                                listViewCompliance.Items
                                .OfType<ListViewItem>()
                                .Where(lvi => lvi.Tag != null && lvi.Tag is EventTypeRiskLevelChangeRecord)
                                .Select(lvi => lvi.Tag as EventTypeRiskLevelChangeRecord);
            obj.ChangeRecords.Clear();
            obj.ChangeRecords.AddRange(records);
        }
        #endregion

        #region private void Save()
        private void Save()
        {
            try
            {
                GlobalObjects.SmsCore.Save(_smsEventType);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while save smsEventType", ex);
            }
        }
        #endregion

        #region private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        private void LinkLabelAddNewConditionLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(_smsEventType == null) return;

            var performance = new SmsConditionControl(new EventCondition {ParentId = _smsEventType.ItemId});
            performance.Deleted += ConditionControlDeleted;
            if (flowLayoutPanelConditions.Controls.Count > 1) performance.ShowHeaders = false;
            flowLayoutPanelConditions.Controls.Remove(panelAddCondition);
            flowLayoutPanelConditions.Controls.Add(performance);
            performance.Dock = DockStyle.Top;
            flowLayoutPanelConditions.Controls.Add(panelAddCondition);
            panelAddCondition.Dock = DockStyle.Top;
            performance.Focus();
        }
        #endregion

        #region private void ConditionControlDeleted(object sender, EventArgs e)

        private void ConditionControlDeleted(object sender, EventArgs e)
        {
            SmsConditionControl control = (SmsConditionControl)sender;
            EventCondition cond = control.EventCondition;

            if (cond.ItemId > 0 && MessageBox.Show("Do you really want to delete event condition?", "Deleting confirmation", 
                                                   MessageBoxButtons.YesNoCancel, 
                                                   MessageBoxIcon.Exclamation, 
                                                   MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //если информация о состоянии сохранена в БД 
                //и получен положительный ответ на ее удаление
                try
                {
                    GlobalObjects.CasEnvironment.NewKeeper.Delete(cond);
                    _smsEventType.EventConditions.Remove(cond);
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

        #region private void ButtonAddClick(object sender, EventArgs e)
        private void ButtonAddClick(object sender, EventArgs e)
        {
            AddPerformance();
        }

        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            DeletePerformance();
        }
        #endregion

        #region private void ButtonEditClick(object sender, EventArgs e)
        private void ButtonEditClick(object sender, EventArgs e)
        {
            EditPerformance();
        }

        #endregion

        #region private void ListViewComplainceClick(object sender, EventArgs e)
        private void ListViewComplainceClick(object sender, EventArgs e)
        {
            if (listViewCompliance.SelectedItems.Count == 0)
            {
                buttonEdit.Enabled = false;
                buttonAdd.Enabled = true;
                buttonDelete.Enabled = false;
            }
            else
            {
                if (listViewCompliance.SelectedItems[0].Tag is EventTypeRiskLevelChangeRecord)
                {
                    buttonEdit.Enabled = true;
                    buttonAdd.Enabled = true;
                    buttonDelete.Enabled = true;
                }
                else
                {
                    buttonEdit.Enabled = false;
                    buttonAdd.Enabled = true;
                    buttonDelete.Enabled = false;
                }
            }
        }
        #endregion

        #region private void ListViewComplainceMouseDoubleClick(object sender, MouseEventArgs e)

        private void ListViewComplainceMouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditPerformance();
        }

        #endregion

        #region private void ButtonCancelClick(object sender, EventArgs e)

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            if(_smsEventType != null)
            {
                if (GetChangeStatus(_smsEventType))
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
                        if (_smsEventType.ItemId <= 0)
                        {
                            IEnumerable<EventTypeRiskLevelChangeRecord> records =
                                listViewCompliance.Items
                                .OfType<ListViewItem>()
                                .Where(lvi => lvi.Tag != null && lvi.Tag is EventTypeRiskLevelChangeRecord)
                                .Select(lvi => lvi.Tag as EventTypeRiskLevelChangeRecord);

                            foreach (EventTypeRiskLevelChangeRecord record in records)
                            {
                                try
                                {
                                    GlobalObjects.CasEnvironment.Manipulator.Delete(record, false);
                                }
                                catch (Exception ex)
                                {
                                    Program.Provider.Logger.Log("Error while delete risk level change record", ex);
                                }
                            }
                        }
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
                        ApplyChanges(_smsEventType);
                        Save();
                    }
                }
                else
                {
                    if (_smsEventType.ItemId <= 0)
                    {
                        IEnumerable<EventTypeRiskLevelChangeRecord> records =
                            listViewCompliance.Items
                            .OfType<ListViewItem>()
                            .Where(lvi => lvi.Tag != null && lvi.Tag is EventTypeRiskLevelChangeRecord)
                            .Select(lvi => lvi.Tag as EventTypeRiskLevelChangeRecord);

                        foreach (EventTypeRiskLevelChangeRecord record in records)
                        {
                            try
                            {
                                GlobalObjects.CasEnvironment.Manipulator.Delete(record, false);
                            }
                            catch (Exception ex)
                            {
                                Program.Provider.Logger.Log("Error while delete risk level change record", ex);
                            }
                        }
                    }
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
            if (GetChangeStatus(_smsEventType))
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
                    ApplyChanges(_smsEventType);
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
