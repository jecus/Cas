using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.ReportFilters;
using CAS.UI.Appearance;
using CAS.UI.Properties;
using CASReports;
using CASReports.Builders;

namespace CAS.UI.UIControls.FiltersControls
{
    /// <summary>
    /// Форма выбора фильтра отображения списка агрегатов
    /// </summary>
    public partial class DetailFilterSelection : Form
    {

        #region Fields

        private string pageTitle;
        private readonly Aircraft curentAircraft;
        private Dictionary<string ,bool> ATAChapterAppliance;
        private readonly Dictionary<string, BaseDetail> baseDetailDictionary = new Dictionary<string, BaseDetail>();
        private readonly string hardTimeStatus = "Hard Time Status";
        private readonly string onConditionStatus = "On Condition Status";
        private readonly string cmStatus = "Condition Monitoring Status";
        private readonly string landingGearStatus = "Landing Gear Status";
        private readonly string LLPStatus = "LLP Status";
        private readonly string avionicsInventory = "Avionics Inventory";
        private readonly string componentStatus = "Component Status";
        private readonly Dictionary<string ,BaseDetail> engineLLPDictionary = new Dictionary<string, BaseDetail>();
        private readonly List<CheckBox> MaintenanceFilterCheckBoxes = new List<CheckBox>();
        private DetailCollectionFilter lastAppliedFilters;

        private readonly string allComponents = "All";
        private DetailListReportBuilder lastReportBuilder;
        private DetailCollectionFilter lastAppliedFiltersForReport;
        private bool dateAsOfChanged = false;

        #endregion

        #region public DetailFilterSelection()
        /// <summary>
        /// Создание экземпляра класса DetailFilterSelection
        /// </summary>
        public DetailFilterSelection()
        {
            InitializeComponent();
            Text = "Component Status Filter";
            Icon = Resources.LTR;
            Initialize();
            dateTimePicker.Value = DateTime.Now;
            dateTimePicker.MaxDate = DateTime.Now;
            lastAppliedFiltersForReport = GetDetailCollectionFilter();
        }

        #endregion

        #region public DetailFilterSelection(Aircraft curentAircraft):this()
        /// <summary>
        /// Создается экзымпляр класс DetailFilterSelection с заданием воздушного судна
        /// </summary>
        /// <param name="curentAircraft">Воздушное судно</param>
        public DetailFilterSelection(Aircraft curentAircraft):this()
        {
            if (curentAircraft == null) throw new ArgumentNullException("curentAircraft","Can't be null");
            this.curentAircraft = curentAircraft;
        }
        #endregion

        #region Properties

        #region public string PageTitle
        /// <summary>
        /// Заголовок страницы на котророй испоьзуется фильтр
        /// </summary>
        public string PageTitle
        {
            get { return pageTitle; }
            set
            {
                pageTitle = value;
                label8.Text = value + ". Filter";
            }
        }
        #endregion

        #region public DateTime DateSelected
        /// <summary>
        /// Дата на которую происходит загрузка данных
        /// </summary>
        public DateTime DateSelected
        {
            get { return dateTimePicker.Value; }
            set { dateTimePicker.Value = value; }
        }
        #endregion

        #region public DetailListReportBuilder ReportBuilder
        /// <summary>
        /// Create new instance type of current report builder
        /// </summary>
        public DetailListReportBuilder ReportBuilder
        {
            get
            {
                DetailCollectionFilter newFilters = GetDetailCollectionFilter();
                if (!newFilters.Equals(lastAppliedFiltersForReport) || lastReportBuilder == null)
                {
                    lastAppliedFiltersForReport = newFilters;
                    string selectedType = "";
                    if (comboReportType.SelectedItem != null)
                        selectedType = comboReportType.SelectedItem.ToString();
                    DetailListReportBuilder reportBuilder = new ComponentStatusReportBuilder(null);
                    if (checkBoxHardTime.Checked)
                        reportBuilder = new ComponentStatusReportBuilder(MaintenanceTypeCollection.Instance.HardTimeType);
                    if (checkBoxOnCondition.Checked || checkBoxConditionMonitoring.Checked)
                        reportBuilder = new ComponentStatusOCCMReportBuilder();
                    if (selectedType == LLPStatus)
                        reportBuilder = new LLPStatusReportBuilder();
                    if (selectedType == avionicsInventory)
                        reportBuilder = new AvionicsInventoryStatusReportBuilder();
                    if (selectedType == landingGearStatus)
                        reportBuilder = new LandingGearStatusReportBuilder(curentAircraft);
                    if (engineLLPDictionary.ContainsKey(selectedType))
                        reportBuilder = new LLPStatusReportBuilder((Engine)engineLLPDictionary[selectedType]);
                    reportBuilder.IsFiltered = GetDetailCollectionFilter().IsNonReportFilterApply;
                    lastReportBuilder = reportBuilder;
                    return reportBuilder;
                }
                return lastReportBuilder;
            }
            set
            {
                lastReportBuilder = value;
                UpdateByBuilder();
                lastAppliedFiltersForReport = GetDetailCollectionFilter();
            }
        }

        #endregion
        
        #region ConditionStatusCheckBoxesProperties

        #region private bool SatisfactoryChecked
        private bool SatisfactoryChecked
        {
            get { return checkBoxSatisfactory.Checked; }
            set { checkBoxSatisfactory.Checked = value; }
        }
        #endregion

        #region private bool NotSatisfactoryChecked
        private bool NotSatisfactoryChecked
        {
            get { return checkBoxNotSatisfactory.Checked; }
            set { checkBoxNotSatisfactory.Checked = value; }
        }
        #endregion

        #region private bool NotificationChecked
        private bool NotificationChecked
        {
            get { return checkBoxNotification.Checked; }
            set { checkBoxNotification.Checked = value; }
        }
        #endregion

        #endregion

        #region private bool MaintenanceTypeCheckBoxesEnabled
        private bool MaintenanceTypeCheckBoxesEnabled
        {
            get
            {
                return
                    checkBoxConditionMonitoring.Enabled & checkBoxUnknown.Enabled & checkBoxOnCondition.Enabled &
                    checkBoxHardTime.Enabled;
            }
            set
            {
                checkBoxConditionMonitoring.Enabled = value;
                checkBoxUnknown.Enabled = value;
                checkBoxOnCondition.Enabled = value;
                checkBoxHardTime.Enabled = value;
            }
        }
        #endregion

        #region private bool MaintenanceTypeCheckBoxesChecked
        private bool MaintenanceTypeCheckBoxesChecked
        {
            set
            {
                checkBoxConditionMonitoring.Checked = value;
                checkBoxUnknown.Checked = value;
                checkBoxOnCondition.Checked = value;
                checkBoxHardTime.Checked = value;                
            }
        }
        #endregion

        #region private bool ConditionMonitroringChecked
        private bool ConditionMonitroringChecked
        {
            get { return checkBoxConditionMonitoring.Checked; }
            set { checkBoxConditionMonitoring.Checked = value; }
        }
        #endregion

        #region private bool HardTimeChecked
        private bool HardTimeChecked
        {
            get { return checkBoxHardTime.Checked; }
            set { checkBoxHardTime.Checked = value; }
        }
        #endregion

        #region private bool OnConditionChecked
        private bool OnConditionChecked
        {
            get { return checkBoxOnCondition.Checked; }
            set { checkBoxOnCondition.Checked = value; }
        }
        #endregion

        #region private bool UnknownChecked
        private bool UnknownChecked
        {
            get { return checkBoxUnknown.Checked; }
            set { checkBoxUnknown.Checked = value; }
        }
        #endregion

        #region private bool PartNumberFilterAppliance
        ///<summary>
        /// Применимость фильтра по (PartNumber)
        ///</summary>
        private bool PartNumberFilterAppliance
        {
            get
            {                
                return checkBoxPartFilterAppliance.Checked;
            }
            set
            {
                checkBoxPartFilterAppliance.Checked = value;
            }
        }
        #endregion

        #region private bool SerialNumberFilterAppliance
        ///<summary>
        /// Применимость фильтра по (SerialNumber)
        ///</summary>
        private bool SerialNumberFilterAppliance
        {
            get
            {
                return checkBoxSerialFilterAppliance.Checked;
            }
            set { checkBoxSerialFilterAppliance.Checked = value; }
        }
        #endregion

        #region private bool DetailConditionFilterAppliance
        /// <summary>
        /// Применимость фильтра для статуса агрегатов
        /// </summary>
        private bool DetailConditionFilterAppliance
        {
            get { return (!(SatisfactoryChecked & NotSatisfactoryChecked & NotificationChecked)); }
        }
        #endregion

        #region private bool MaintenaceFilterAppliance
        ///<summary>
        /// Применимость фильтра по Типу технического обслуживания (MaintenanceType)
        ///</summary>
        private bool MaintenanceFilterAppliance
        {
            get
            {
                for (int i = 0; i < MaintenanceFilterCheckBoxes.Count; i++)
                {
                    if (!MaintenanceFilterCheckBoxes[i].Checked) return true;
                }
                return false;
            }
        }
        #endregion

        #region private bool ATAChapterFilterAppliance
        ///<summary>
        /// Применимость фильтра (ATAChapter)
        ///</summary>
        private bool ATAChapterFilterAppliance
        {
            get
            {
                SelectCheckListBoxATAChapterByFilter((string) textBoxATAChapter.Text);
                return checkedListBoxATAChapter.SelectedIndices.Count != checkedListBoxATAChapter.Items.Count && checkedListBoxATAChapter.CheckedItems.Count != 0 ;
            }
        }
        #endregion
        
        #region private bool DateAsOfFilterAppliance

        /// <summary>
        /// Применимость загрузки данных на заданную дату
        /// </summary>
        public bool DateAsOfFilterAppliance
        {
            get { return checkBoxDateAsOfAppliance.Checked; }
            set { checkBoxDateAsOfAppliance.Checked = value; }
        }
        #endregion

        #endregion
        
        #region Methods

        #region private void UpdateByBuilder()

        private void UpdateByBuilder()
        {
            LoadReport();
            if (lastReportBuilder is ComponentStatusOCCMReportBuilder)
            {
                checkBoxConditionMonitoring.Checked = true;
                checkBoxOnCondition.Checked = true;
                checkBoxHardTime.Checked = false;
                checkBoxUnknown.Checked = false;
            }
            else if (lastReportBuilder is ComponentStatusReportBuilder)
            {
                checkBoxConditionMonitoring.Checked = false;
                checkBoxOnCondition.Checked = false;
                checkBoxHardTime.Checked = true;
                checkBoxUnknown.Checked = false;
            }
            else if (lastReportBuilder is AvionicsInventoryStatusReportBuilder)
                comboReportType.SelectedItem = avionicsInventory;
        }

        #endregion


        #region private void DetailFilterSelection_Load(object sender, EventArgs e)

        private void DetailFilterSelection_Load(object sender, EventArgs e)
        {
            Css.OrdinaryText.Adjust(this);
            Css.OrdinaryText.Adjust(checkedListBoxItems);
            Css.OrdinaryText.Adjust(dateTimePicker);
            Css.OrdinaryText.Adjust(comboReportType);
            Css.OrdinaryText.Adjust(textBoxPartMask);
            Css.OrdinaryText.Adjust(textBoxSerialMask);
            Css.OrdinaryText.Adjust(textBoxATAChapter);

            checkedListBoxItems.BackColor = Css.CommonAppearance.Colors.BackColor;
            checkedListBoxItems.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            checkedListBoxATAChapter.BackColor = Css.CommonAppearance.Colors.BackColor;
            checkedListBoxATAChapter.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;

            Css.OrdinaryText.Adjust(checkBoxDateAsOfAppliance);
            Css.OrdinaryText.Adjust(label3);
            Css.OrdinaryText.Adjust(labelATAChapter);
            Css.OrdinaryText.Adjust(label5);
            Css.OrdinaryText.Adjust(label6);
            Css.OrdinaryText.Adjust(label7);
            Css.OrdinaryText.Adjust(checkBoxConditionMonitoring);

            checkBoxConditionMonitoring.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            Css.OrdinaryText.Adjust(checkBoxHardTime);
            checkBoxHardTime.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            Css.OrdinaryText.Adjust(checkBoxOnCondition);
            checkBoxOnCondition.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            Css.OrdinaryText.Adjust(checkBoxPartFilterAppliance);
            checkBoxPartFilterAppliance.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            checkBoxDateAsOfAppliance.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            Css.OrdinaryText.Adjust(checkBoxUnknown);
            checkBoxUnknown.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            Css.OrdinaryText.Adjust(checkBoxSerialFilterAppliance);
            checkBoxSerialFilterAppliance.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            Css.OrdinaryText.Adjust(checkBoxNotSatisfactory);
            checkBoxNotSatisfactory.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            Css.OrdinaryText.Adjust(checkBoxNotification);
            checkBoxNotification.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            Css.OrdinaryText.Adjust(checkBoxSatisfactory);
            checkBoxSatisfactory.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;

            Css.OrdinaryText.Adjust(comboBoxComponent);

            LoadAtaChapters();
            LoadComponent();
            lastAppliedFiltersForReport = GetDetailCollectionFilter();

        }

        #endregion

        #region private void Initialize()
        /// <summary>
        /// Создание начальных параметров
        /// </summary>
        private void Initialize()
        {
            
            //
            // this
            //
            BackColor = Css.CommonAppearance.Colors.BackColor;
            //
            // buttonClose
            //
            buttonClose.FlatAppearance.BorderSize = 1;
            buttonClose.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            //
            // buttonApply
            //
            buttonApply.FlatAppearance.BorderSize = 1;
            buttonApply.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            //
            // buttonClear
            //
            buttonClear.FlatAppearance.BorderSize = 1;
            buttonClear.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            //
            // butonOk
            //
            buttonOK.FlatAppearance.BorderSize = 1;
            buttonOK.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            //
            // label8
            //
            Css.HeaderText.Adjust(label8);
            //
            // MaintenanceFillterCheckBoxes
            //
            MaintenanceFilterCheckBoxes.Add(checkBoxConditionMonitoring);
            MaintenanceFilterCheckBoxes.Add(checkBoxHardTime);
            MaintenanceFilterCheckBoxes.Add(checkBoxOnCondition);
            MaintenanceFilterCheckBoxes.Add(checkBoxUnknown);
        }
        #endregion

        #region private void LoadAtaChapters()
        private void LoadAtaChapters()
        {
            ATAChapterCollection ataChapters = ATAChapterCollection.Instance;
            int count = ataChapters.Count;
            ATAChapterAppliance = new Dictionary<string, bool>();
            for (int i = 0; i < count; i++)
            {
                ATAChapterAppliance.Add(ataChapters[i].ShortName + " " + ataChapters[i].FullName, false);
                checkedListBoxATAChapter.Items.Add(ataChapters[i].ShortName + " " + ataChapters[i].FullName, false);
            }
        }
        #endregion

        #region private void LoadComponent()
        private void LoadComponent()
        {
            if (curentAircraft!= null)
            {
                BaseDetail[] baseDetailArray = curentAircraft.BaseDetails;
                if (baseDetailArray != null)
                {
                    int count = baseDetailArray.Length;
                    comboBoxComponent.Items.Add(allComponents);
                    for (int i = 0; i < count; i++)
                    {
                        baseDetailDictionary.Add(baseDetailArray[i].ToString(), baseDetailArray[i]);
                        comboBoxComponent.Items.Add(baseDetailArray[i].ToString());
                    }
                    comboBoxComponent.SelectedIndex = 0;
                }
            }
        }
        #endregion

        #region private void LoadReport()
        private void LoadReport()
        {
            List<string> captions = new List<string>();
            if (curentAircraft!=null)
            {
                BaseDetail[] baseDetailArray = curentAircraft.BaseDetails;
                if (baseDetailArray != null)
                {
                    int length = baseDetailArray.Length;
                    for (int i = 0; i < length; i++)
                    {
                        if (baseDetailArray[i] is Engine)
                        {
                            engineLLPDictionary.Add(GetEngineLLPString(baseDetailArray[i]),baseDetailArray[i]);
                            captions.Add(GetEngineLLPString(baseDetailArray[i]));
                        }
                    }
                }
            }
            captions.Add(avionicsInventory);
            captions.Add(cmStatus);
            captions.Add(onConditionStatus);
            captions.Add(landingGearStatus);
            captions.Add(hardTimeStatus);
            captions.Add(LLPStatus);
            captions.Sort();
            comboReportType.Items.Add(componentStatus);
            comboReportType.Items.AddRange(captions.ToArray());
            comboReportType.SelectedIndex = 0;
        }
        #endregion

        #region private string GetEngineLLPString(BaseDetail baseDetail)

        private string GetEngineLLPString(BaseDetail baseDetail)
        {
            return baseDetail + " LLP Status";
        }

        #endregion

        #region private void buttonApply_Click(object sender, EventArgs e)
        private void buttonApply_Click(object sender, EventArgs e)
        {
            OnFilterApplying();
        }
        #endregion

        #region protected virtual void OnFilterApplying()
        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnFilterApplying()
        {

            try
            {
                if (ReloadForDate != null)
                {
                    if (DateAsOfFilterAppliance && dateAsOfChanged)
                        ReloadForDate(dateTimePicker.Value);
                    else if (!DateAsOfFilterAppliance && dateTimePicker.Value < DateTime.Today)
                        ReloadForDate(DateTime.Today);
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while loading data", ex);
                return;
            }

            DetailCollectionFilter newFilters = GetDetailCollectionFilter();
            if (!newFilters.Equals(lastAppliedFilters))
            {
                lastAppliedFilters = newFilters;
                if (ApplyFilter != null)
                    ApplyFilter(this, new EventArgs());
            }
        }
        #endregion

        #region private void buttonClose_Click(object sender, EventArgs e)
        private void buttonClose_Click(object sender, EventArgs e)
        {
            ClearFilter();
            CheckDateAsOf();
            Hide();
        }
        #endregion

        #region private void comboReportType_SelectedIndexChanged(object sender, EventArgs e)
        private void comboReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            MaintenanceTypeCheckBoxesEnabled = true;
            MaintenanceTypeCheckBoxesChecked = true;
            if (comboReportType.Items[comboReportType.SelectedIndex].ToString() == "Hard Time Status")
            {
                MaintenanceTypeCheckBoxesEnabled= false;
                MaintenanceTypeCheckBoxesChecked = false;
                HardTimeChecked = true;
            }
            if (comboReportType.Items[comboReportType.SelectedIndex].ToString() == "On Condition Status")
            {
                MaintenanceTypeCheckBoxesEnabled = false;
                MaintenanceTypeCheckBoxesChecked = false;
                OnConditionChecked = true;
            }
            if (comboReportType.Items[comboReportType.SelectedIndex].ToString() == "Condition Monitor Status")
            {
                MaintenanceTypeCheckBoxesEnabled = false;
                MaintenanceTypeCheckBoxesChecked = false;
                ConditionMonitroringChecked = true;
            }
            checkBoxReportTypeAppliance.Checked = comboReportType.SelectedItem.ToString() != componentStatus;
        }
        #endregion

        #region private void comboBoxComponent_SelectedIndexChanged(object sender, EventArgs e)

        private void comboBoxComponent_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBoxComponentAppliance.Checked = comboBoxComponent.SelectedItem.ToString() != allComponents;
        }

        #endregion
        
        #region private void checkBoxPartFilterAppliance_Click(object sender, EventArgs e)
        private void checkBoxPartFilterAppliance_Click(object sender, EventArgs e)
        {
            if (checkBoxPartFilterAppliance.Checked) textBoxPartMask.Focus();
        }
        #endregion

        #region private void checkBoxSerialFilterAppliance_Click(object sender, EventArgs e)
        private void checkBoxSerialFilterAppliance_Click(object sender, EventArgs e)
        {
            if (checkBoxSerialFilterAppliance.Checked) textBoxSerialMask.Focus();
        }
        #endregion

        #region private void buttonClear_Click(object sender, EventArgs e)
        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearFilter();
        }


        #endregion

        #region private void ClearFilter()

        private void ClearFilter()
        {
            foreach (CheckBox checkBox in MaintenanceFilterCheckBoxes)
            {
                checkBox.Checked = true;
            }
            checkBoxSatisfactory.Checked = true;
            checkBoxNotSatisfactory.Checked = true;
            checkBoxNotification.Checked = true;

            checkBoxPartFilterAppliance.Checked = false;
            textBoxPartMask.Text = "";
            checkBoxSerialFilterAppliance.Checked = false;
            textBoxSerialMask.Text = "";

            int count = checkedListBoxATAChapter.Items.Count;
            for (int i = 0; i < count; i++)
            {
                checkedListBoxATAChapter.SetItemChecked(i, false);
            }
            textBoxATAChapter.Text = "";
            comboBoxComponent.SelectedIndex = 0;
            comboReportType.SelectedIndex = 0;
            dateTimePicker.Value = DateTime.Today;
        }
        #endregion

        #region private void textBoxATAChapter_Leave(object sender, EventArgs e)
        private void textBoxATAChapter_Leave(object sender, EventArgs e)
        {
            SelectCheckListBoxATAChapterByFilter((string) textBoxATAChapter.Text);
        }
        #endregion

        #region private void textBoxATAChapter_KeyPress(object sender, KeyPressEventArgs e)
        private void textBoxATAChapter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
            {
                SelectCheckListBoxATAChapterByFilter((string) textBoxATAChapter.Text);
            }
            if (e.KeyChar == '*')
            {
                int count = checkedListBoxATAChapter.Items.Count;
                for (int i = 0; i < count; i++)
                {
                    checkedListBoxATAChapter.SetItemChecked(i,true);
                }
                
            }
        }
        #endregion
        
        #region private void SetAllCheckListBoxATAChapterValuesBy(bool value)
        private void SetAllCheckListBoxATAChapterValuesBy(bool value)
        {
            for (int i = 0; i < checkedListBoxATAChapter.Items.Count; i++)
            {
                checkedListBoxATAChapter.SetItemChecked(i, value);
            }
        }
        #endregion

        #region private void SelectCheckListBoxATAChapterByFilter(string text)
        private void SelectCheckListBoxATAChapterByFilter(string text)
        {
            SetAllCheckListBoxATAChapterValuesBy(false);
            string[] selections = text.Split(',');
            for (int i = 0; i < selections.Length; i++)
            {
                string s = selections[i];
                for (int j = 0; j < checkedListBoxATAChapter.Items.Count; j++)
                {
                    if (checkedListBoxATAChapter.Items[j].ToString().Contains(s.Trim()) && s.Trim() != "")
                    {
                        checkedListBoxATAChapter.SetItemChecked(j, true);
                    }
                }
            }            
        }
        #endregion

        #region private void CheckTextBoxOnContained()
        private void CheckTextBoxATAOnContained()
        {
            int count = checkedListBoxATAChapter.Items.Count;
            string stringOutput = "";                     
            for (int i = 0; i<count;i++)
            {
                string checkedItem = checkedListBoxATAChapter.Items[i].ToString();
                if (checkedListBoxATAChapter.GetItemChecked(i))
                {
                    stringOutput += checkedItem;
                    if (i != count - 1) stringOutput +=",";
                }
            }
            textBoxATAChapter.Text = stringOutput;
        }
        #endregion

        #region private ATAChapterFilter GetATAChapterFillter()
        private ATAChapterFilter GetATAChapterFillter()
        {
            SelectCheckListBoxATAChapterByFilter((string) textBoxATAChapter.Text);
            bool[] typesAppliance = new bool[checkedListBoxATAChapter.Items.Count];
            ATAChapterCollection ataChapters = ATAChapterCollection.Instance;
            for (int i = 0; i < typesAppliance.Length; i++)
            {
                typesAppliance[i] = ATAChapterAppliance[ataChapters[i].ShortName+ " " + ataChapters[i].FullName];
            }
            return new ATAChapterFilter(typesAppliance);
        }
        #endregion

        #region private void checkedListBoxATAChapter_Click(object sender, EventArgs e)
        private void checkedListBoxATAChapter_Click(object sender, EventArgs e)
        {
            CheckTextBoxATAOnContained();
        }
        #endregion

        #region private void checkedListBoxATAChapter_SelectedIndexChanged(object sender, EventArgs e)
        private void checkedListBoxATAChapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckTextBoxATAOnContained();
        }
        #endregion

        #region private void checkedListBoxATAChapter_ItemCheck(object sender, ItemCheckEventArgs e)
        private void checkedListBoxATAChapter_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ATAChapterAppliance[checkedListBoxATAChapter.Items[e.Index].ToString()] = e.CurrentValue != CheckState.Checked;
        }
        #endregion

        #region protected void buttonOK_Click(object sender, EventArgs e)
        private void buttonOK_Click(object sender, EventArgs e)
        {
            OnFilterApplying();
            CheckDateAsOf();
            Hide();
        }
        #endregion

        #region private void DetailFilterSelection_FormClosing(object sender, FormClosingEventArgs e)
        private void DetailFilterSelection_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            CheckDateAsOf();
            Hide();
        }
        #endregion

        #region public DetailCollectionFilter GetDetailCollectionFilter()
        ///<summary>
        /// Создается фильтр коллекции агрегатов
        ///</summary>
        ///<returns>Созданная коллекция агрегатов</returns>
        public DetailCollectionFilter GetDetailCollectionFilter()
        {
            DetailCollectionFilter detailCollectionFilter = new DetailCollectionFilter(new DetailFilter[]{});
            List<DetailFilter> filters = new List<DetailFilter>();
            if (MaintenanceFilterAppliance)
            {
                if (MaintenanceTypeCheckBoxesEnabled)
                    filters.Add(
                        new MaintananceFilter(OnConditionChecked, UnknownChecked, ConditionMonitroringChecked,
                                              HardTimeChecked));
                
            }
            if (ATAChapterFilterAppliance)
            {
                filters.Add(GetATAChapterFillter());
            }
            if (DetailConditionFilterAppliance)
            {
                filters.Add(new DetailConditionFilter(SatisfactoryChecked, NotSatisfactoryChecked, NotificationChecked));
            }
            if (SerialNumberFilterAppliance)
            {
                filters.Add(new Core.Types.ReportFilters.SerialNumberFilter(textBoxSerialMask.Text));
            }
            if (PartNumberFilterAppliance)
            {
                filters.Add(new PartNumberFilter(textBoxPartMask.Text));
            }
            if (filters.Count > 0) detailCollectionFilter.IsNonReportFilterApply = true;
            AddSpecialReportFilters(filters);
            AddComponentFilters(filters);
            if (DateAsOfFilterAppliance)
            {
                filters.Add(new DateAsOfFilter(dateTimePicker.Value));
            }

            detailCollectionFilter.Filters = filters.ToArray();
            return detailCollectionFilter;
        }
        #endregion

        #region private void AddComponentFilters(List<DetailFilter> filters)

        private void AddComponentFilters(List<DetailFilter> filters)
        {
            if (checkBoxComponentAppliance.Checked)
            {
                if (comboBoxComponent.SelectedItem == null)
                    return;
                if (comboBoxComponent.SelectedItem == allComponents)
                    return;
                if (baseDetailDictionary.ContainsKey(comboBoxComponent.SelectedItem.ToString()))
                    filters.Add(new BaseDetailFilter(baseDetailDictionary[comboBoxComponent.SelectedItem.ToString()]));
            }
        }

        #endregion

        #region private void AddSpecialReportFilters(List<DetailFilter> filters)

        private void AddSpecialReportFilters(List<DetailFilter> filters)
        {
            if (checkBoxReportTypeAppliance.Checked)
            {
                string selectedType;
                if (comboReportType.SelectedItem == null)
                    return;
                selectedType = comboReportType.SelectedItem.ToString();
                if (selectedType == componentStatus)
                    return;
                if (selectedType == hardTimeStatus)
                    filters.Add(new HardTimeStatusFilter());
                if (selectedType == onConditionStatus)
                    filters.Add(new OnConditionStatusFilter());
                if (selectedType == cmStatus)
                    filters.Add(new ConditionMonitoringStatusFilter());
                if (selectedType == LLPStatus)
                    filters.Add(new LLPFilter());
                if (selectedType == avionicsInventory)
                    filters.Add(new AvionicsInventoryFilter(true, true, true));
                if (selectedType == landingGearStatus)
                    filters.Add(new LandingGearsFilter(true, true, true, true));
                if (engineLLPDictionary.ContainsKey(selectedType))
                {
                    filters.Add(new EngineLLPFilter(engineLLPDictionary[selectedType]));
                }
            }
        }

        #endregion
        
        #region public void SetFilterParameters(DetailCollectionFilter filter)

        /// <summary>
        /// Задаются параеметры фильтрации
        /// </summary>
        /// <param name="filter"></param>
        public void SetFilterParameters(DetailCollectionFilter filter)
        {
            dateAsOfChanged = false;
            for (int i = 0; i < filter.Filters.Length; i++)
            {
                DetailFilter detailFilter = filter.Filters[i];
                if (detailFilter is PartNumberFilter)
                {
                    PartNumberFilterAppliance = true;
                    textBoxPartMask.Text = ((PartNumberFilter) detailFilter).Mask;
                }
                if (detailFilter is Core.Types.ReportFilters.SerialNumberFilter)
                {
                    SerialNumberFilterAppliance = true;
                    textBoxSerialMask.Text = ((Core.Types.ReportFilters.SerialNumberFilter) detailFilter).Mask;
                }
                if (detailFilter is DetailConditionFilter)
                {
                    DetailConditionFilter detailConditionFilter = (DetailConditionFilter) detailFilter;
                    SatisfactoryChecked = detailConditionFilter.SatisfactoryAcceptance;
                    NotSatisfactoryChecked = detailConditionFilter.NotSatisfactoryAcceptance;
                    NotificationChecked = detailConditionFilter.NotificationAcceptance;
                }
                if (detailFilter is ATAChapterFilter)
                {
                    SelectCheckListBoxATAChapterByFilter(((ATAChapterFilter)detailFilter).TypeAppliance);
                }
                if (detailFilter is MaintananceFilter)
                {
                    MaintananceFilter maintananceFilter = (MaintananceFilter) detailFilter;
                    OnConditionChecked = maintananceFilter.OnConditionAcceptance;
                    HardTimeChecked = maintananceFilter.HardTimeAcceptance;
                    ConditionMonitroringChecked = maintananceFilter.ConditionMonitoringAcceptance;
                    UnknownChecked = maintananceFilter.UnknownAcceptance;
                }
                if (detailFilter is BaseDetailFilter)
                    comboBoxComponent.SelectedItem = ((BaseDetailFilter) detailFilter).CurentBaseDetail.ToString();

                if (detailFilter is HardTimeStatusFilter)
                    comboReportType.SelectedItem = hardTimeStatus;
                if (detailFilter is OnConditionStatusFilter)
                    comboReportType.SelectedItem = onConditionStatus;
                if (detailFilter is ConditionMonitoringStatusFilter)
                    comboReportType.SelectedItem = cmStatus;
                if (detailFilter is LLPFilter)
                    comboReportType.SelectedItem = LLPStatus;
                if (detailFilter is AvionicsInventoryFilter)
                    comboReportType.SelectedItem = avionicsInventory;
                if (detailFilter is LandingGearsFilter)
                    comboReportType.SelectedItem = landingGearStatus;
                if (detailFilter is EngineLLPFilter)
                {
                    comboReportType.SelectedItem = GetEngineLLPString(((EngineLLPFilter)detailFilter).CurentBaseDetail);
                }
            }
        }
        #endregion

        #region private void SelectCheckListBoxATAChapterByFilter(bool[] appliance)

        private void SelectCheckListBoxATAChapterByFilter(bool[] appliance)
        {
            SetAllCheckListBoxATAChapterValuesBy(false);
            bool[] typesAppliance = appliance;
            ATAChapterCollection ataChapters = ATAChapterCollection.Instance;
            for (int i = 0; i < typesAppliance.Length; i++)
            {
                ATAChapterAppliance[ataChapters[i].ShortName + " " + ataChapters[i].FullName] = typesAppliance[i];
            }
            for (int i = 0; i < checkedListBoxATAChapter.Items.Count; i++)
            {
                if (ATAChapterAppliance.ContainsKey(checkedListBoxATAChapter.Items[i].ToString()))
                    checkedListBoxATAChapter.SetItemChecked(i, ATAChapterAppliance[checkedListBoxATAChapter.Items[i].ToString()]);
                else
                    checkedListBoxATAChapter.SetItemChecked(i, false);
            }
            CheckTextBoxATAOnContained();
        }

        #endregion

        #region private void dateTimePicker_ValueChanged(object sender, EventArgs e)

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            dateAsOfChanged = true;
            if (dateTimePicker.Value < DateTime.Today)
            {
                DateAsOfFilterAppliance = true;
            }
            else
                DateAsOfFilterAppliance = false;
        }

        #endregion

        #region private void textBoxPartMask_TextChanged(object sender, EventArgs e)

        private void textBoxPartMask_TextChanged(object sender, EventArgs e)
        {
            checkBoxPartFilterAppliance.Checked = textBoxPartMask.Text != "";
        }

        #endregion
        
        #region private void textBoxSerialMask_TextChanged(object sender, EventArgs e)

        private void textBoxSerialMask_TextChanged(object sender, EventArgs e)
        {
            checkBoxSerialFilterAppliance.Checked = textBoxSerialMask.Text != "";
        }

        #endregion

        #region private void CheckDateAsOf()

        private void CheckDateAsOf()
        {
            if (!DateAsOfFilterAppliance)
                dateTimePicker.Value = DateTime.Today;
        }

        #endregion

        #endregion

        #region Events

        #region public event EventHandler ApplyFilter;
        /// <summary>
        /// Событие запроса принятия филтра
        /// </summary>
        public event EventHandler ApplyFilter;
        #endregion

        #region public event DateAsOfEventHandler ReloadForDate;
        /// <summary>
        /// Событие запроса загрузки на заданную дату
        /// </summary>
        public event DateAsOfEventHandler ReloadForDate;
        #endregion

        #endregion

        #region Delegates

        /// <summary>
        /// Делегат для посылки даты DateAsOf
        /// </summary>
        /// <param name="dateAsOf"></param>
        public delegate void DateAsOfEventHandler(DateTime dateAsOf);

        #endregion

    }
}