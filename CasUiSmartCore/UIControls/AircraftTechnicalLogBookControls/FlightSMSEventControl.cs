using System;
using System.Linq;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.UIControls.SMSControls;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.SMS;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    /// <summary>
    /// Класс отображает список 
    /// </summary>
    public partial class FlightSmsEventControl : Interfaces.EditObjectControl
    {
        /*
         * Свойства 
         */
        #region public Event Event
        /// <summary>
        /// Отклонение, с которым связан контрол
        /// </summary>
        public Event Event
        {
            get { return AttachedObject as Event; }
            set { AttachedObject = value; }
        }
        #endregion

        #region public bool EnableExtendedControl
        ///<summary>
        /// Возвращает или задает значение видна ли панель расширения
        ///</summary>
        public bool EnableExtendedControl
        {
            get { return panelExtendable.Visible; }
            set
            {
                panelExtendable.Visible = value;
                if (value == false)
                {
                    panelMain.Visible = true;
                    flowLayoutPanelConditions.Visible = true;
                }
            }
        }
        #endregion

        #region public bool Extended
        ///<summary>
        /// Возвращает или задает значение Показывается ли елемент развернутым
        ///</summary>
        public bool Extended
        {
            get { return panelMain.Visible; }
            set
            {
                panelMain.Visible = value;
                flowLayoutPanelConditions.Visible = value;
            }
        }
        #endregion

        #region public DateTime EventDate
        ///<summary>
        /// Возвращает или задает дату события
        ///</summary>
        public DateTime EventDate
        {
            get { return dateTimePickerEventDate.Value; }
            set
            {
                if (Event.ItemId < 0)
                    dateTimePickerEventDate.Value = value;
            }
        }
        #endregion

        /*
         * Конструктор
         */

        #region public SMSEventControl()
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public FlightSmsEventControl()
        {
            InitializeComponent();
        }
        #endregion

        #region public SmsEventControl(Event smsEvent) : this ()
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public FlightSmsEventControl(Event smsEvent)
            : this()
        {
            AttachedObject = smsEvent;
        }
        #endregion

        /*
         * Перегруженные методы 
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
            if (Event != null)
            {
                Event.EventType = dictionaryComboEventType.SelectedItem as SmsEventType;
                Event.EventCategory = dictionaryComboBoxCategory.SelectedItem as EventCategory;
                Event.EventClass = dictionaryComboEventClass.SelectedItem as EventClass;
                Event.IncidentType = comboBoxIncident.SelectedItem as IncidentType;
                Event.RecordDate = dateTimePickerEventDate.Value;
                Event.Description = textBoxDescription.Text;
                Event.Remarks = textBoxRemarks.Text;

                Event.EventConditions.Clear();
                foreach (SmsConditionControl smsConditionControl in flowLayoutPanelConditions.Controls.OfType<SmsConditionControl>())
                {
                    smsConditionControl.ApplyChanges();
                    Event.EventConditions.Add(smsConditionControl.EventCondition);
                }

                SetExtendableControlCaption();
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
            BeginUpdate();
            
            dictionaryComboEventType.SelectedIndexChanged -= LookupComboboxEventTypeSelectedIndexChanged;
            dictionaryComboEventClass.SelectedIndexChanged -= DictionaryComboEventClassSelectedIndexChanged;
            dictionaryComboBoxCategory.SelectedIndexChanged -= DictionaryComboBoxCategorySelectedIndexChanged;

            comboBoxIncident.Items.Clear();
            foreach (IncidentType o in IncidentType.Items)
                comboBoxIncident.Items.Add(o);

            dictionaryComboEventClass.Type = typeof (EventClass);
            dictionaryComboBoxCategory.Type = typeof (EventCategory);

            dictionaryComboEventType.Type = typeof (SmsEventType);
            dictionaryComboEventType.ScreenControl = new EventTypesListScreen(Event);

            foreach (Control c in flowLayoutPanelConditions.Controls)
            {
                if (c != panelAddCondition) c.Dispose();
            }
            
            flowLayoutPanelConditions.Controls.Clear();
            if (Event != null)
            {
                dictionaryComboEventType.SelectedItem = Event.EventType;
                dictionaryComboBoxCategory.SelectedItem = Event.EventCategory;
                dictionaryComboEventClass.SelectedItem = Event.EventClass;
                comboBoxIncident.SelectedItem = Event.IncidentType;
                dateTimePickerEventDate.Value = Event.RecordDate;
                textBoxDescription.Text = Event.Description;
                textBoxRemarks.Text = Event.Remarks;


                foreach (EventCondition condition in Event.EventConditions)
                {
                    SmsConditionControl newControl = new SmsConditionControl(condition);
                    newControl.Deleted += ConditionControlDeleted;
                    if (flowLayoutPanelConditions.Controls.Count >= 1) newControl.ShowHeaders = false;
                    flowLayoutPanelConditions.Controls.Add(newControl);
                }
            }
            flowLayoutPanelConditions.Controls.Add(panelAddCondition);

            SetExtendableControlCaption();
            SetRiskIndex();

            dictionaryComboEventType.SelectedIndexChanged += LookupComboboxEventTypeSelectedIndexChanged;
            dictionaryComboEventClass.SelectedIndexChanged += DictionaryComboEventClassSelectedIndexChanged;
            dictionaryComboBoxCategory.SelectedIndexChanged += DictionaryComboBoxCategorySelectedIndexChanged;

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
            // Правильность ввода даты
            if (!ValidateEventDate())
            {
                MessageBox.Show("Event Date must be between 1 Jan 1950 and " + UsefulMethods.NormalizeDate(DateTime.Now),
                                (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return false;
            }

            if (flowLayoutPanelConditions.Controls.OfType<SmsConditionControl>().Any(scc => !scc.CheckData()))
            {
                MessageBox.Show("Not specified event condition or " +
                                "\nthe selected item is not the end node of the tree",
                                (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }
        #endregion

        /*
         * Реализация
         */

        #region private bool ValidateEventDate()
        /// <summary>
        /// Проверяем введенную дату
        /// </summary>
        /// <returns></returns>
        private bool ValidateEventDate()
        {
            if (dateTimePickerEventDate.Value > DateTime.Now)
                return false;
            return true;
        }
        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (Deleted != null)
                Deleted(this, EventArgs.Empty);
        }
        #endregion

        #region private void ExtendableRichContainerExtending(object sender, EventArgs e)
        private void ExtendableRichContainerExtending(object sender, EventArgs e)
        {
            panelMain.Visible = !panelMain.Visible;
            flowLayoutPanelConditions.Visible = panelMain.Visible;
        }
        #endregion

        #region private void SetExtendableControlCaption()
        private void SetExtendableControlCaption()
        {
            extendableRichContainer.labelCaption.Text = "";

            if (Event != null)
            {
                extendableRichContainer.labelCaption.Text = "";

                if (Event.EventType != null)
                    extendableRichContainer.labelCaption.Text += "Event: " + Event.EventType;
            }

        }
        #endregion

        #region private void SetRiskIndex()

        private void SetRiskIndex()
        {
            EventCategory cat = dictionaryComboBoxCategory.SelectedItem as EventCategory;
            EventClass eventClass = dictionaryComboEventClass.SelectedItem as EventClass;
            if(cat != null && eventClass != null)
            {
                textBoxRiskIndex.Text = eventClass.Weight + cat.ShortName + 
                    (eventClass.Weight * cat.Weight);
                            
            }
            else textBoxRiskIndex.Text = "";
        }
        #endregion

        #region private void LookupComboboxDefferedSelectedIndexChanged(object sender, EventArgs e)
        private void LookupComboboxEventTypeSelectedIndexChanged(object sender, EventArgs e)
        {
            SmsEventType eventType = dictionaryComboEventType.SelectedItem as SmsEventType;
            if(eventType != null && Event != null && Event.ItemId <= 0)
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
            if (Event == null) return;

            SmsConditionControl performance =
                new SmsConditionControl(new EventCondition { ParentId = Event.ItemId });
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
                    GlobalObjects.NewKeeper.Delete(cond);
                    Event.EventConditions.Remove(cond);
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

        #region Events
        /// <summary>
        /// </summary>
        public event EventHandler Deleted;

        #endregion
    }
}

