using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.Properties;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts.Templates;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.ReportFilters;
using CAS.Core.Types.ReportFilters.Templates;
using CAS.UI.Appearance;

namespace CAS.UI.UIControls.TemplatesControls.Forms
{
    /// <summary>
    /// Форма выбора фильтра отображения списка шаблонных агрегатов
    /// </summary>
    public partial class TemplateDetailFilterSelection : Form
    {

        #region Fields

        private string pageTitle;
        private readonly TemplateAircraft curentAircraft;
        private Dictionary<string ,bool> ATAChapterAppliance;
        private readonly Dictionary<string, TemplateBaseDetail> baseDetailDictionary = new Dictionary<string, TemplateBaseDetail>();
        private readonly string hardTimeStatus = "Hard Time Status";
        private readonly string onConditionStatus = "On Condition Status";
        private readonly string cmStatus = "Condition Monitoring Status";
        private readonly string landingGearStatus = "Landing Gear Status";
        private readonly string LLPStatus = "LLP Status";
        private readonly string avionicsInventory = "Avionics Inventory";
        //private readonly string componentStatus = "Component Status";
        private readonly Dictionary<string ,TemplateBaseDetail> engineLLPDictionary = new Dictionary<string, TemplateBaseDetail>();
        private readonly List<CheckBox> MaintenanceFilterCheckBoxes = new List<CheckBox>();
        //private TemplateDetailCollectionFilter lastAppliedFilters;

        private readonly string allComponents = "All";
        //private DetailListReportBuilder lastReportBuilder;
        //private TemplateDetailCollectionFilter lastAppliedFiltersForReport;

        #endregion

        #region Constructors

        #region public TemplateDetailFilterSelection()

        /// <summary>
        /// Создание экземпляра класса TemplateDetailFilterSelection
        /// </summary>
        public TemplateDetailFilterSelection()
        {
            InitializeComponent();
            Text = "Component Status Filter";
            Icon = Resources.LTR;
            Initialize();
        }

        #endregion

        #region public TemplateDetailFilterSelection(TemplateAircraft curentAircraft):this()

        /// <summary>
        /// Создается экзымпляр класс DetailFilterSelection с заданием воздушного судна
        /// </summary>
        /// <param name="curentAircraft">Воздушное судно</param>
        public TemplateDetailFilterSelection(TemplateAircraft curentAircraft):this()
        {
            if (curentAircraft == null) 
                throw new ArgumentNullException("curentAircraft","Can't be null");
            this.curentAircraft = curentAircraft;
        }
        
        #endregion

        #endregion

        #region Properties

        #region public string PageTitel
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
        
        #region private bool MaintenanceTypeCheckBoxesEnabled

        private bool MaintenanceTypeCheckBoxesEnabled
        {
            get
            {
                return
                    checkBoxConditionMonitoring.Enabled & checkBoxUnknown.Enabled & checkBoxOnCondition.Enabled &
                    checkBoxHardTime.Enabled;
            }
            /*set
            {
                checkBoxConditionMonitoring.Enabled = value;
                checkBoxUnknown.Enabled = value;
                checkBoxOnCondition.Enabled = value;
                checkBoxHardTime.Enabled = value;
            }*/
        }

        #endregion

        /*#region private bool MaintenanceTypeCheckBoxesChecked
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
        #endregion*/

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
                SelectCheckListBoxATAChapterByFilter(textBoxATAChapter.Text);
                return checkedListBoxATAChapter.SelectedIndices.Count != checkedListBoxATAChapter.Items.Count && checkedListBoxATAChapter.CheckedItems.Count != 0 ;
            }
        }
        #endregion
        
        #endregion
        
        #region Methods

        #region private void DetailFilterSelection_Load(object sender, EventArgs e)

        private void DetailFilterSelection_Load(object sender, EventArgs e)
        {
            Css.OrdinaryText.Adjust(this);
            Css.OrdinaryText.Adjust(checkedListBoxItems);
            Css.OrdinaryText.Adjust(textBoxPartMask);
            Css.OrdinaryText.Adjust(textBoxATAChapter);

            checkedListBoxItems.BackColor = Css.CommonAppearance.Colors.BackColor;
            checkedListBoxItems.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            checkedListBoxATAChapter.BackColor = Css.CommonAppearance.Colors.BackColor;
            checkedListBoxATAChapter.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;

            Css.OrdinaryText.Adjust(label3);
            Css.OrdinaryText.Adjust(labelATAChapter);
            Css.OrdinaryText.Adjust(label5);
            Css.OrdinaryText.Adjust(label6);
            Css.OrdinaryText.Adjust(checkBoxConditionMonitoring);

            checkBoxConditionMonitoring.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            Css.OrdinaryText.Adjust(checkBoxHardTime);
            checkBoxHardTime.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            Css.OrdinaryText.Adjust(checkBoxOnCondition);
            checkBoxOnCondition.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            Css.OrdinaryText.Adjust(checkBoxPartFilterAppliance);
            checkBoxPartFilterAppliance.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            Css.OrdinaryText.Adjust(checkBoxUnknown);
            checkBoxUnknown.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            
            Css.OrdinaryText.Adjust(comboBoxComponent);

            LoadAtaChapters();
            LoadComponent();
            LoadReport();
        }

        #endregion

        #region private void Initialize()
        /// <summary>
        /// Создание начальных параметров
        /// </summary>
        private void Initialize()
        {
            //lastAppliedFiltersForReport = new DetailCollectionFilter(new DetailFilter[] { });
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
                TemplateBaseDetail[] baseDetailArray = curentAircraft.BaseDetails;
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
                TemplateBaseDetail[] baseDetailArray = curentAircraft.BaseDetails;
                if (baseDetailArray != null)
                {
                    int length = baseDetailArray.Length;
                    for (int i = 0; i < length; i++)
                    {
                        if (baseDetailArray[i] is TemplateEngine)
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
        }

        #endregion

        #region private string GetEngineLLPString(TemplateBaseDetail baseDetail)

        private string GetEngineLLPString(TemplateBaseDetail baseDetail)
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
            /*try
            {
                if (ReloadForDate != null)
                    ReloadForDate(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading data" + Environment.NewLine + ex.Message, (string) new TermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/
            //TemplateDetailCollectionFilter newFilters = GetDetailCollectionFilter();
            if (ApplyFilter != null)
                ApplyFilter(this, new EventArgs()); //todo может нужна проверка
        }
        #endregion

        #region private void buttonClose_Click(object sender, EventArgs e)
        private void buttonClose_Click(object sender, EventArgs e)
        {
            ClearFilter();
            Hide();
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
            
            checkBoxPartFilterAppliance.Checked = false;
            textBoxPartMask.Text = "";

            int count = checkedListBoxATAChapter.Items.Count;
            for (int i = 0; i < count; i++)
            {
                checkedListBoxATAChapter.SetItemChecked(i, false);
            }
            textBoxATAChapter.Text = "";
            comboBoxComponent.SelectedIndex = 0;
        }
        #endregion

        #region private void textBoxATAChapter_Leave(object sender, EventArgs e)
        private void textBoxATAChapter_Leave(object sender, EventArgs e)
        {
            SelectCheckListBoxATAChapterByFilter(textBoxATAChapter.Text);
        }
        #endregion

        #region private void textBoxATAChapter_KeyPress(object sender, KeyPressEventArgs e)
        private void textBoxATAChapter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
            {
                SelectCheckListBoxATAChapterByFilter(textBoxATAChapter.Text);
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

        #region private TemplateATAChapterFilter GetATAChapterFillter()

        private TemplateATAChapterFilter GetATAChapterFillter()
        {
            SelectCheckListBoxATAChapterByFilter(textBoxATAChapter.Text);
            bool[] typesAppliance = new bool[checkedListBoxATAChapter.Items.Count];
            ATAChapterCollection ataChapters = ATAChapterCollection.Instance;
            for (int i = 0; i < typesAppliance.Length; i++)
            {
                typesAppliance[i] = ATAChapterAppliance[ataChapters[i].ShortName+ " " + ataChapters[i].FullName];
            }
            return new TemplateATAChapterFilter(typesAppliance);
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
            Hide();
        }
        #endregion

        #region private void DetailFilterSelection_FormClosing(object sender, FormClosingEventArgs e)
        private void DetailFilterSelection_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
        #endregion

        #region public TemplateDetailCollectionFilter GetDetailCollectionFilter()
        ///<summary>
        /// Создается фильтр коллекции шаблонных агрегатов
        ///</summary>
        ///<returns>Созданная коллекция шаблонных агрегатов</returns>
        public TemplateDetailCollectionFilter GetDetailCollectionFilter()
        {
            TemplateDetailCollectionFilter detailCollectionFilter = new TemplateDetailCollectionFilter(new TemplateDetailFilter[]{});
            List<TemplateDetailFilter> filters = new List<TemplateDetailFilter>();
            if (MaintenanceFilterAppliance)
            {
                if (MaintenanceTypeCheckBoxesEnabled)
                    filters.Add(
                        new TemplateMaintananceFilter(OnConditionChecked, UnknownChecked, ConditionMonitroringChecked,
                                                      HardTimeChecked));
                
            }
            if (ATAChapterFilterAppliance)
            {
                filters.Add(GetATAChapterFillter());
            }
            if (PartNumberFilterAppliance)
            {
                filters.Add(new TemplatePartNumberFilter(textBoxPartMask.Text));
            }
            if (filters.Count > 0) detailCollectionFilter.IsNonReportFilterApply = true;
            //AddSpecialReportFilters(filters);
            AddComponentFilters(filters);
            detailCollectionFilter.Filters = filters.ToArray();
            return detailCollectionFilter;
        }
        #endregion

        #region private void AddComponentFilters(List<TemplateDetailFilter> filters)

        private void AddComponentFilters(List<TemplateDetailFilter> filters)
        {
            if (checkBoxComponentAppliance.Checked)
            {
                if (comboBoxComponent.SelectedItem == null)
                    return;
                if (comboBoxComponent.SelectedItem == allComponents)
                    return;
                if (baseDetailDictionary.ContainsKey(comboBoxComponent.SelectedItem.ToString()))
                    filters.Add(new TemplateBaseDetailFilter(baseDetailDictionary[comboBoxComponent.SelectedItem.ToString()]));
            }
        }

        #endregion

        #region public void SetFilterParameters(TemplateDetailCollectionFilter filter)

        /// <summary>
        /// Задаются параеметры фильтрации
        /// </summary>
        /// <param name="filter"></param>
        public void SetFilterParameters(TemplateDetailCollectionFilter filter)
        {
            for (int i = 0; i < filter.Filters.Length; i++)
            {
                TemplateDetailFilter detailFilter = filter.Filters[i];
                if (detailFilter is TemplatePartNumberFilter)
                {
                    PartNumberFilterAppliance = true;
                    textBoxPartMask.Text = ((TemplatePartNumberFilter) detailFilter).Mask;
                }
                if (detailFilter is TemplateATAChapterFilter)
                {
                    SelectCheckListBoxATAChapterByFilter(((TemplateATAChapterFilter)detailFilter).TypeAppliance);
                }
                if (detailFilter is TemplateMaintananceFilter)
                {
                    TemplateMaintananceFilter maintananceFilter = (TemplateMaintananceFilter) detailFilter;
                    OnConditionChecked = maintananceFilter.OnConditionAcceptance;
                    HardTimeChecked = maintananceFilter.HardTimeAcceptance;
                    ConditionMonitroringChecked = maintananceFilter.ConditionMonitoringAcceptance;
                    UnknownChecked = maintananceFilter.UnknownAcceptance;
                }
                if (detailFilter is BaseDetailFilter)
                    comboBoxComponent.SelectedItem = ((TemplateBaseDetailFilter) detailFilter).CurentBaseDetail.ToString();

                /*if (detailFilter is HardTimeStatusFilter)
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
                if (detailFilter is TemplateEngineLLPFilter)
                {
                    comboReportType.SelectedItem = GetEngineLLPString(((TemplateEngineLLPFilter)detailFilter).CurentBaseDetail);
                }*/
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

        #region private void textBoxPartMask_TextChanged(object sender, EventArgs e)

        private void textBoxPartMask_TextChanged(object sender, EventArgs e)
        {
            checkBoxPartFilterAppliance.Checked = textBoxPartMask.Text != "";
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

        #endregion
    }
}