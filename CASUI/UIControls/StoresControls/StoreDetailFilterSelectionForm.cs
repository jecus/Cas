using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.ReportFilters;
using CAS.UI.Appearance;
using CAS.UI.Properties;
using CASReports.Builders;

namespace CAS.UI.UIControls.StoresControls
{
    /// <summary>
    /// Форма выбора фильтра отображения списка агрегатов
    /// </summary>
    public partial class StoreDetailFilterSelectionForm : Form
    {

        #region Fields

        private string pageTitle;
        private readonly Store store;
        private Dictionary<string ,bool> ATAChapterAppliance;
        //private readonly Dictionary<string, BaseDetail> baseDetailDictionary = new Dictionary<string, BaseDetail>();
        private readonly Dictionary<string ,BaseDetail> engineLLPDictionary = new Dictionary<string, BaseDetail>();
        private readonly List<CheckBox> MaintenanceFilterCheckBoxes = new List<CheckBox>();
        private DetailCollectionFilter lastAppliedFilters;

        private StoreBuilder lastReportBuilder;
        private DetailCollectionFilter lastAppliedFiltersForReport;

        #endregion

        #region public StoreDetailFilterSelectionForm()
        /// <summary>
        /// Создается экземпляр класса StoreDetailFilterSelectionForm 
        /// </summary>
        public StoreDetailFilterSelectionForm()
        {
            InitializeComponent();
            Text = "Store Filter";
            Icon = Resources.LTR;
            Initialize();
            lastAppliedFiltersForReport = GetDetailCollectionFilter();
        }
        #endregion

        #region public StoreDetailFilterSelectionForm(Store store) : this()
        /// <summary>
        /// Создается экземпляр класса StoreDetailFilterSelectionForm с заданным складом
        /// </summary>
        /// <param name="store">Склад</param>
        public StoreDetailFilterSelectionForm(Store store) : this()
        {
            if (store == null) 
                throw new ArgumentNullException("store", "Can't be null");
            this.store = store;
        }
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

       /* #region ublic StoreBuilder ReportBuilder
        /// <summary>
        /// Create new instance type of current report builder
        /// </summary>
        public StoreBuilder ReportBuilder
        {
            get
            {
                DetailCollectionFilter newFilters = GetDetailCollectionFilter();
                if (!newFilters.Equals(lastAppliedFiltersForReport) || lastReportBuilder == null)
                {
                    lastAppliedFiltersForReport = newFilters;
                    //StoreBuilder reportBuilder = new StoreBuilder();
                 
                    lastReportBuilder = reportBuilder;
                    return reportBuilder;
                }
                return lastReportBuilder;
            }
            set { lastReportBuilder = value; }
        }
        #endregion*/
        
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
            Css.OrdinaryText.Adjust(textBoxSerialMask);
            Css.OrdinaryText.Adjust(textBoxATAChapter);

            checkedListBoxItems.BackColor = Css.CommonAppearance.Colors.BackColor;
            checkedListBoxItems.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            checkedListBoxATAChapter.BackColor = Css.CommonAppearance.Colors.BackColor;
            checkedListBoxATAChapter.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;

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

            LoadAtaChapters();
            LoadReport();
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

        #region private void LoadReport()
        private void LoadReport()
        {
            List<string> captions = new List<string>();
            if (store != null)
            {
                BaseDetail[] baseDetailArray = store.BaseDetails;
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
            Hide();
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

        #region private ATAChapterFilter GetATAChapterFillter()
        private ATAChapterFilter GetATAChapterFillter()
        {
            SelectCheckListBoxATAChapterByFilter(textBoxATAChapter.Text);
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
                filters.Add(new SerialNumberFilter(textBoxSerialMask.Text));
            }
            if (PartNumberFilterAppliance)
            {
                filters.Add(new PartNumberFilter(textBoxPartMask.Text));
            }
            if (filters.Count > 0) detailCollectionFilter.IsNonReportFilterApply = true;
            detailCollectionFilter.Filters = filters.ToArray();
            return detailCollectionFilter;
        }
        #endregion

        #region public void SetFilterParameters(DetailCollectionFilter filter)

        /// <summary>
        /// Задаются параеметры фильтрации
        /// </summary>
        /// <param name="filter"></param>
        public void SetFilterParameters(DetailCollectionFilter filter)
        {
            for (int i = 0; i < filter.Filters.Length; i++)
            {
                DetailFilter detailFilter = filter.Filters[i];
                if (detailFilter is PartNumberFilter)
                {
                    PartNumberFilterAppliance = true;
                    textBoxPartMask.Text = ((PartNumberFilter) detailFilter).Mask;
                }
                if (detailFilter is SerialNumberFilter)
                {
                    SerialNumberFilterAppliance = true;
                    textBoxSerialMask.Text = ((SerialNumberFilter) detailFilter).Mask;
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
        
        #region private void textBoxSerialMask_TextChanged(object sender, EventArgs e)

        private void textBoxSerialMask_TextChanged(object sender, EventArgs e)
        {
            checkBoxSerialFilterAppliance.Checked = textBoxSerialMask.Text != "";
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