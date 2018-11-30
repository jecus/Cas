using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Auxiliary;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Directives;
using CAS.Core;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.ReportFilters;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DirectiveControls;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.EngineeringOrdersDirectives;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.MaintenanceStatusControls;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using Microsoft.VisualBasic.Devices;

namespace CAS.UI.UIControls.DiscrepanciesControls
{
    /// <summary>
    /// Элемент управления отображения списка отклонений
    /// </summary>
    public class DiscrepanciesListView : SDList<IMaintainable>, IReference
    {

        #region Fields
        private Aircraft currentAircraft;
        private BaseDetail currentBaseDetail;
        private readonly Dictionary<string, List<ListViewItem>> dictionaryGroupOrder;
        private readonly SortedList<string, IFilter> dictionaryFiltersType;
        private readonly IList<string> listGroupOrder;
        private DirectiveFilter filter = new DiscrepanciesFilter(false, true);
        private Label labelTotalMH;
        private Label labelTotalCost;

        /// <summary>
        /// Словарь содержаший в себе следующую структуру:
        /// Словарь по базовых агрегатов содержаший список отсортированых по статусам директив и агрегатов
        /// </summary>
        private Dictionary<BaseDetail, Dictionary<string, List<ListViewItem>>> dictionaryBaseDetail;

        private readonly float[] HEADER_WIDTH = new float[] {0.05f, 0.2f, 0.19f, 0.13f, 0.10f, 0.07f, 0.11f, 0.06f, 0.07f};
        private String registrationNumber = "";
        private readonly Queue<int> columnIndexQueue = new Queue<int>();
        private readonly int SORT_MEMORY_COUNT = 6;

        #region private IDisplayer displayer
        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        private IDisplayer displayer;
        #endregion

        #region private DisplayingEntity entity
        /// <summary>
        /// Entity to display
        /// </summary>
        private IDisplayingEntity entity;
        #endregion

        #region private ReflectionTypes reflectionType
        private string displayerText;
        private ReflectionTypes reflectionType;

        #endregion

        #endregion

        #region Constructors

        #region public DiscrepanciesListView()
        /// <summary>
        /// Создает элемент управления отображающий listview
        /// </summary>
        public DiscrepanciesListView()
        {
            dictionaryFiltersType =
                (SortedList<string, IFilter>)(new TermsProvider()["DirectiveFilterTypes"]);
            dictionaryGroupOrder = new Dictionary<string, List<ListViewItem>>();
            listGroupOrder = dictionaryFiltersType.Keys;
            int count = listGroupOrder.Count;
            for (int i = 0; i < count; i++)
            {
                dictionaryGroupOrder.Add(listGroupOrder[i], new List<ListViewItem>());
            }
            ModifyBottomPanel();

            ItemsListView.ColumnClick += ItemsListView_ColumnClick;
            ItemsListView.MouseDoubleClick += ItemsListView_MouseDoubleClick;
            ItemsListView.SelectedIndexChanged += ItemsListView_SelectedIndexChanged;
            ItemsListView.KeyDown += ItemsListView_KeyDown;
            DisplayerRequested += DiscrepanciesListView_DisplayerRequested;
        }

        #endregion

        #endregion

        #region Properties

        #region public IDisplayer Displayer
        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        public IDisplayer Displayer
        {
            get { return displayer; }
            set { displayer = value; }
        }

        /// <summary>
        /// Text of page's header that Reference lead to
        /// </summary>
        public string DisplayerText
        {
            get { return displayerText; }
            set { displayerText = value; }
        }
        #endregion

        #region public DisplayingEntity Entity
        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        /// <summary>
        /// Type of reflection [:|||:]
        /// </summary>
        public ReflectionTypes ReflectionType
        {
            get { return reflectionType; }
            set { reflectionType = value; }
        }
        #endregion

        #region public override IMaintainable SelectedItem
        /// <summary>
        /// Возврашет выделеный элемент
        /// </summary>
        public override IMaintainable SelectedItem
        {
            get
            {
                if (ItemsListView.SelectedItems.Count == 1)
                {
                    return ItemsListView.SelectedItems[0].Tag as IMaintainable;
                }
                return null;
            }
        }
        #endregion

        #region public override List<IMaintainable> SelectedItems
        /// <summary>
        /// Свойство возвращает массив выбранных элементов
        /// </summary>
        public override List<IMaintainable> SelectedItems
        {
            get { return selectedItemsList; }
        }
        #endregion

        #region public DirectiveFilter Filter
        /// <summary>
        /// Фильтр по директивам
        /// </summary>
        public DirectiveFilter Filter
        {
            get { return filter; }
            set { filter = value; }
        }
        #endregion

        #region public IMaintainable[] Items
        /// <summary>
        /// Return array of contained items
        /// </summary>
        public IMaintainable[] Items
        {
            get
            {
                Int32 count = ListViewItemList.Count;
                IMaintainable[] result = new IMaintainable[count];

                for (int i = 0; i < count; i++)
                {
                    result[i] = ListViewItemList[i].Tag as IMaintainable;
                }
                return result;
            }
        }
        #endregion     


        #endregion

        #region Events

        #region public event EventHandler<ReferenceEventArgs> DisplayerRequested
        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;
        #endregion

        #region public event EventHandler<SelectedItemsChangeEventArgs> SelectedItemsChanged;
        /// <summary>
        /// Событие возникающее при изменении массива выбранных элементов в списке элементов, которые отображаются в списке, вот!
        /// </summary>
        //public event EventHandler<SelectedItemsChangeEventArgs> SelectedItemsChanged;
        #endregion

        #endregion

        #region Methods

        #region private void SetResource()

        private void SetResource()
        {
            ItemsListView.Items.Clear();
            ItemsListView.Groups.Clear();
            ItemsListView.Columns.Clear();
            ColumnHeaderList.Clear();
            ListViewItemList.Clear();
            SetHeaders();
        }

        #endregion

        #region public void SetResource(Aircraft aircraft)

        /// <summary>
        /// Добавляет в список все отклонения заданого воздушного судна
        /// </summary>
        /// <param name="aircraft">Воздушное судно</param>
        public void SetResource(Aircraft aircraft)
        {
            if (aircraft == null) 
                throw new ArgumentNullException("aircraft", "Can't be null");
            currentAircraft = aircraft;
            SetResource();
            int length = aircraft.BaseDetails.Length;
            dictionaryBaseDetail = new Dictionary<BaseDetail, Dictionary<string, List<ListViewItem>>>();
            BaseDetail[] baseDetails = aircraft.BaseDetails;
            for (int i = 0; i < length; i++)
            {
                Dictionary<string, List<ListViewItem>> groupOrder = new Dictionary<string, List<ListViewItem>>();
                int count = listGroupOrder.Count;
                for (int j = 0; j < count; j++)
                {
                    groupOrder.Add(listGroupOrder[j], new List<ListViewItem>());
                }
                dictionaryBaseDetail.Add(baseDetails[i], groupOrder);
            }
            
            List<AbstractDetail> allDetails = new List<AbstractDetail>(aircraft.ContainedDetails);
            allDetails.AddRange(baseDetails);
            SetDetailItemArray(allDetails.ToArray());
            SetDirectiveItemArray(aircraft.AllDirectives);

            sortMultiplier = -1;
            SortListView(6);
            
            ItemsListView.ShowGroups = true;
            registrationNumber = aircraft.RegistrationNumber;
            SetTotalText();
        }

      
        #endregion

        #region public void SetResource(BaseDetail baseDetail)
        /// <summary>
        /// Добавляет в список все отклонения заданного базового агрегата
        /// </summary>
        /// <param name="baseDetail">Базовый агрегат</param>
        public void SetResource(BaseDetail baseDetail)
        {
            if (baseDetail == null) 
                throw new ArgumentNullException("baseDetail", "Can't be null");
            currentBaseDetail = baseDetail;
            foreach (KeyValuePair<string, List<ListViewItem>> pair in dictionaryGroupOrder)
            {
                pair.Value.Clear();
            }
            SetResource();
            SetDetailItemArray(baseDetail.ContainedDetails);
            SetDirectiveItemArray(baseDetail.AllDirectives);
            SortListView(6);
            ItemsListView.ShowGroups = true;

            registrationNumber = baseDetail.ParentAircraft.RegistrationNumber;
            SetTotalText();
        }
        #endregion

        #region private void SetDetailItemArray(Detail[] itemsArray)
        /// <summary>
        /// Заполняет Dictionary элементами по группам
        /// </summary>
        /// <param name="detailArray">Массив элементов</param>
        private void SetDetailItemArray(AbstractDetail[] detailArray)
        {
/*
            DetailLimitationFilter detailFilter = new DetailLimitationFilter(filter);
            int length = detailArray.Length;
            BaseDetail baseDetail;
            if (currentAircraft != null)
                baseDetail = currentAircraft.AircraftContainer;
            else
                baseDetail = currentBaseDetail;
            for (int i = 0; i < length; i++)
            {
                if (detailFilter.Acceptable(detailArray[i]))
                {
                    ListViewItem addedItem = CreateListViewItem(detailArray[i]);
                    if (dictionaryBaseDetail != null)
                    {
                        dictionaryBaseDetail[baseDetail]["Component Status"].Add(addedItem);
                    }
                    else
                        dictionaryGroupOrder["Component Status"].Add(addedItem);
                }

            }
*/
        }


        #endregion

        #region private void SetDirectiveItemArray(BaseDetailDirective[] directiveArray)
        /// <summary>
        /// Заполняет Dictionary элементами по группам
        /// </summary>
        /// <param name="directiveArray">Массив элементов</param>
        private void SetDirectiveItemArray(BaseDetailDirective[] directiveArray)
        {
            int length = directiveArray.Length;
            for (int i = 0; i < length; i++)
            {
                int count = listGroupOrder.Count;
                for (int j = 0; j < count; j++)
                {
                    if (dictionaryFiltersType[listGroupOrder[j]].Acceptable(directiveArray[i]) &&
                        filter.Acceptable(directiveArray[i]))
                    {
                        ListViewItem addedItem = CreateListViewItem(directiveArray[i]);
                        if (dictionaryBaseDetail != null)
                            dictionaryBaseDetail[directiveArray[i].Parent as BaseDetail][listGroupOrder[j]].Add(
                                addedItem);
                        else dictionaryGroupOrder[listGroupOrder[j]].Add(addedItem);
                    }
                }
            }
        }
        #endregion

        #region protected override void SetTotalText()

        /// <summary>
        /// Устанавивает информацию об общем количестве элементов в нижней панели
        /// </summary>
        protected override void SetTotalText()
        {
            base.SetTotalText();
            double manHours = 0;
            double cost = 0;
            IMaintainable[] items = Items;
            for (int i = 0; i < items.Length; i++)
            {
                manHours += items[i].ManHours;
                cost += items[i].Cost;
            }
            labelTotalMH.Text = "Total MH: " + Math.Round(manHours);
            labelTotalCost.Text = "Total Cost: " + Math.Round(cost);
        }

        #endregion

        #region public override CoreType[] GetItemsArray()
        /// <summary>
        /// Метод возвращает массив базовых элементов (CoreType)
        /// </summary>
        /// <returns>Массив базовых элементов (CoreType)</returns>
        public override IMaintainable[] GetItemsArray()
        {
            int count = ListViewItemList.Count;
            IMaintainable[] returnCoreTypeArray = new IMaintainable[0];
            if (count > 0)
            {
                returnCoreTypeArray = new IMaintainable[count];
                for (int i = 0; i < count; i++)
                {
                    returnCoreTypeArray[i] = (IMaintainable)ListViewItemList[i].Tag;
                }
            }
            return returnCoreTypeArray;
        }
        #endregion

        #region private string ProcessText(string text)
        private string ProcessText(string text)
        {
            string result = text;
            result = Regex.Replace(result, Environment.NewLine, " ");
            result = Regex.Replace(result, @"^\s+", "");
            result = Regex.Replace(result, @"\s+$", "");
            return result;
        }
        #endregion

        #region private ListViewItem CreateListViewItem(IMaintainable item)
        /// <summary>
        /// Создание обекта для списка 
        /// </summary>
        /// <param name="item">Добавляемое отклонение</param>
        private ListViewItem CreateListViewItem(IMaintainable item)
        {
            double e = 0.000000001;
            string[] itemsString = new string[]
                {
                    item.AtaChapter != null ? item.AtaChapter.ShortName:"",
                    item.Title,
                    ProcessText(item.Description),
                    GetNextLifelength(item),
                    item.NextRemains == null ? "" : item.NextRemains.ToString().Trim(),
                    item.WorkType != null ? item.WorkType.ShortName.Trim() : "",
                    UsefulMethods.NormalizeDate(item.ApproximateDate), 
                    item.ManHours < e ? "" : item.ManHours.ToString(),
                    item.Cost < e ? "" : item.Cost.ToString()
                };

            ListViewItem listViewItem = new ListViewItem(itemsString);
            listViewItem.Tag = item;
            return listViewItem;
        }
        #endregion

        #region private string GetNextLifelength(IMaintainable item)

        private string GetNextLifelength(IMaintainable item)
        {
            if (item.Next == null)// || !item.Next.IsCalendarApplicable) 
                return "";
            if (item is MaintenanceDirective)
            {
                if (item.Next.IsCalendarApplicable)
                    return item.Next.ToListViewItemString(item.NextDate, false);
                else
                    return item.Next.ToHoursAndCyclesFormat("h", "c");
            }
            else
            {
/*
                if (item is BaseDetailDirective)
                    if (((BaseDetailDirective)item).Title.StartsWith("99-26-07")) MessageBox.Show("asdgas");
*/
                return item.Next.ToListViewItemString(item.NextDate, false);
            }
        }

        #endregion
        
        #region private void SetGroup(Aircraft curentAircraft)

        private void SetGroup(Aircraft curentAircraft)
        {
            int length = curentAircraft.BaseDetails.Length;
            for (int i = 0; i < length; i++)
            {
                foreach (KeyValuePair<string, List<ListViewItem>> pair in dictionaryBaseDetail[curentAircraft.BaseDetails[i]])
                {
                    string groupName = curentAircraft.BaseDetails[i] + ". " + pair.Key;
                    AddGroup(groupName);
                    int count = pair.Value.Count;
                    for (int j = 0; j < count; j++)
                    {
                        pair.Value[j].Group = ItemsListView.Groups[groupName];
                        ((IMaintainable) pair.Value[j].Tag).GroupName = groupName;
                    }
                }
            }
        }

        #endregion

        #region private void SetGroup()

        private void SetGroup()
        {
            foreach (string groupName in dictionaryGroupOrder.Keys)
            {
                AddGroup(groupName);
                int count = dictionaryGroupOrder[groupName].Count;
                for (int i = 0; i < count; i++)
                {
                    dictionaryGroupOrder[groupName][i].Group = ItemsListView.Groups[groupName];
                    ((IMaintainable) dictionaryGroupOrder[groupName][i].Tag).GroupName = groupName;
                }
            }
        }

        #endregion

        #region protected override void SetHeaders()
        /// <summary>
        /// Устанавливает заголовки
        /// </summary>
        protected override void SetHeaders()
        {
            ColumnHeader columnHeader;
            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[0]);
            columnHeader.Text = "ATA";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int) (ItemsListView.Width * HEADER_WIDTH[1]);
            columnHeader.Text = "Ref No";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int) (ItemsListView.Width * HEADER_WIDTH[2]);
            columnHeader.Text = "Description";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int) (ItemsListView.Width * HEADER_WIDTH[3]);
            columnHeader.Text = "Compliance";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[4]);
            columnHeader.Text = "Overdue/Remain";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int) (ItemsListView.Width * HEADER_WIDTH[5]);
            columnHeader.Text = "Work Type";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[6]);
            columnHeader.Text = "Approximate Date";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[7]);
            columnHeader.Text = "MH";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[8]);
            columnHeader.Text = "Cost (USD)";
            ColumnHeaderList.Add(columnHeader);

            if (ItemsListView.Columns.Count == 0) 
                ItemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
        }
        #endregion

        #region private void SortListView(int columnIndex)

        private void SortListView(int columnIndex)
        {
            if (oldColumnIndex != columnIndex) sortMultiplier = -1;
            if (sortMultiplier == 1) sortMultiplier = -1;
            else
                sortMultiplier = 1;
            if (columnIndexQueue.Count >= SORT_MEMORY_COUNT)
            {
                columnIndexQueue.Dequeue();
                columnIndexQueue.Enqueue(columnIndex);
            }
            else columnIndexQueue.Enqueue(columnIndex);

            ItemsListView.Items.Clear();
            List<ListViewItem> commonList = new List<ListViewItem>();
            if (currentAircraft != null)
            {
                foreach (
                    KeyValuePair<BaseDetail, Dictionary<string, List<ListViewItem>>> dictionaryBaseDetailPair in
                        dictionaryBaseDetail)
                {
                    foreach (KeyValuePair<string, List<ListViewItem>> group in dictionaryBaseDetailPair.Value)
                    {
                        group.Value.Sort(new DiscrepanciesListViewComparer(columnIndexQueue, sortMultiplier));
                        commonList.AddRange(group.Value);
                    }
                }
                SetGroup(currentAircraft);
            }
            if (currentBaseDetail != null)
            {
                foreach (KeyValuePair<string, List<ListViewItem>> group in dictionaryGroupOrder)
                {
                    group.Value.Sort(new DiscrepanciesListViewComparer(columnIndexQueue, sortMultiplier));
                    commonList.AddRange(group.Value);                    
                }
                SetGroup();
            }
            ListViewItemList.Clear();
            ListViewItemList = commonList;
            ItemsListView.Items.AddRange(commonList.ToArray());
            if (currentAircraft != null)
                if (currentAircraft.MaintenanceDirectiveCondition != DirectiveConditionState.Satisfactory)
                    AddMaintenanceStatusDirective();
            ShowGroups = true;
            oldColumnIndex = columnIndex;
        }

        #endregion

        #region private void AddMaintenanceStatusDirective()

        private void AddMaintenanceStatusDirective()
        {
            
            string groupName;
            if (currentBaseDetail != null)
                groupName = currentBaseDetail.ToString();
            else
                groupName = currentAircraft.ToString();
            groupName += ". Maintenance Program";
            ListViewItem addedItem;
            addedItem = CreateListViewItem(currentAircraft.MaintenanceDirective);
            AddGroup(groupName);
            addedItem.Group = ItemsListView.Groups[groupName];
            ListViewItemList.Add(addedItem);
            ItemsListView.Items.Add(addedItem);
            
        }

        #endregion

        #region protected void OnDisplayerRequested()
        /// <summary>
        /// Метод обработки события DisplayerRequested
        /// </summary>
        protected void OnDisplayerRequested()
        {
            if (null != DisplayerRequested)
            {
                ReflectionTypes reflection = reflectionType;
                Keyboard k = new Keyboard();
                if (k.ShiftKeyDown && reflection == ReflectionTypes.DisplayInCurrent)
                    reflection = ReflectionTypes.DisplayInNew;
                
                if (null != displayer)
                {
                    DisplayerRequested(this, new ReferenceEventArgs(entity, reflection, displayer, displayerText));
                }
                else
                {
                    DisplayerRequested(this, new ReferenceEventArgs(entity, reflection, displayerText));
                }
            }
        }
        #endregion

        #region protected override void OnSizeChanged(EventArgs e)

        ///<summary>
        ///Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged"></see> event.
        ///</summary>
        ///
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            int count = ColumnHeaderList.Count;
            for (int i = 0; i < count; i++)
            {
                ColumnHeaderList[i].Width = (int) (Width * HEADER_WIDTH[i]);
            }
        }
        #endregion

        #region private void ItemsListView_ColumnClick(object sender, ColumnClickEventArgs e)

        private void ItemsListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SortListView(e.Column);
        }

        #endregion

        #region private void ItemsListView_MouseDoubleClick(object sender, MouseEventArgs e)
        private void ItemsListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SelectedItem != null)
            {
                OnDisplayerRequested();
            }
        }
        #endregion

        #region void DiscrepanciesListView_DisplayerRequested(object sender, ReferenceEventArgs e)
        private void DiscrepanciesListView_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            if (SelectedItem is AbstractDetail)
            {
                e.DisplayerText = currentAircraft.RegistrationNumber + ". " + SelectedItem.Title;
                e.RequestedEntity = new DispatcheredDetailScreen((AbstractDetail) SelectedItem);
            }
            else if (SelectedItem is BaseDetailDirective)
            {
                BaseDetailDirective directive = (BaseDetailDirective) SelectedItem;
                string regNumber = "";
                if (directive.Parent is AircraftFrame)
                    regNumber = directive.Parent.ToString();
                else
                {
                    if ((directive.Parent).Parent is Aircraft)
                        regNumber = ((Aircraft) ((directive.Parent).Parent)).RegistrationNumber + ". " +
                                    directive.Parent;
                }
                e.DisplayerText = regNumber + ". " + directive.DirectiveType.CommonName + ". " + directive.Title;
                if (directive is EngineeringOrderDirective)
                    e.RequestedEntity =
                        new DispatcheredEngineeringOrderDirectiveScreen((EngineeringOrderDirective) directive);
                else if (directive.DirectiveType == DirectiveTypeCollection.Instance.OutOffPhaseDirectiveType)
                    e.RequestedEntity = new DispatcheredOutOffPhaseReferenceScreen(directive);
                else if (directive.DirectiveType == DirectiveTypeCollection.Instance.CPCPDirectiveType)
                    e.RequestedEntity = new DispatcheredCPCPDirectiveScreen(directive);
                else
                    e.RequestedEntity = new DispatcheredDirectiveScreen(directive);
            }
            else if (SelectedItem is MaintenanceDirective)
            {
                e.DisplayerText = currentAircraft.RegistrationNumber + ". Maintenance Program";
                e.RequestedEntity = new DispatcheredMaintenanceStatusControl((MaintenanceDirective) SelectedItem);
            }
            else
                e.Cancel = true;
            /*IDisplayingEntity displayingEntity = new DiscrepanciesDisplayerProvider().GetDisplayer((IMaintainable) ((ProxyType)SelectedItem).CloneForCurrentData());
            displayingEntity.ContainedData = SelectedItem as CoreType;
            e.RequestedEntity = displayingEntity;
            e.DisplayerText = String.Format("{0}. {1} {2}", registrationNumber, SelectedItem.TypeCaption, SelectedItem.Title);*/
        }

        #endregion

        #region void ItemsListView_SelectedIndexChanged(object sender, EventArgs e)
        private void ItemsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSelectedItemsChange(this, new SelectedItemsChangeEventArgs(selectedItemsList.Count));
            //if (SelectedItemsChanged != null)
              //  SelectedItemsChanged.Invoke(this, new SelectedItemsChangeEventArgs(selectedItemsList.Count));
        }
        #endregion

        #region private void ItemsListView_KeyDown(object sender, KeyEventArgs e)
        private void ItemsListView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Enter:
                    if (SelectedItem != null)
                    {
                        OnDisplayerRequested();
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region private void ModifyBottomPanel()

        private void ModifyBottomPanel()
        {
            labelTotalMH = new Label();
            labelTotalCost = new Label();
            //
            // labelTotalMH
            //
            labelTotalMH.AutoSize = true;
            labelTotalMH.Font = Css.SmallHeader.Fonts.RegularFont;
            labelTotalMH.ForeColor = Css.SmallHeader.Colors.ForeColor;
            labelTotalMH.Dock = DockStyle.Right;
            labelTotalMH.Padding = new Padding(0, 5, 25, 0);
            labelTotalMH.Text = "Total MH: ";
            //
            // labelTotalCost
            //
            labelTotalCost.AutoSize = true;
            labelTotalCost.Font = Css.SmallHeader.Fonts.RegularFont;
            labelTotalCost.ForeColor = Css.SmallHeader.Colors.ForeColor;
            labelTotalCost.Dock = DockStyle.Right;
            labelTotalCost.Padding = new Padding(0, 5, 25, 0);
            labelTotalCost.Text = "Total Cost: ";

            BottomPanel.Controls.Add(labelTotalMH);
            BottomPanel.Controls.Add(labelTotalCost);
        }

        #endregion

        #region Unused Methods

        #region public override void UpdateItems()

        /// <summary>
        /// Обновляет элементы ListView
        /// </summary>
        public override void UpdateItems()
        {

        }

        #endregion

        protected override void AddItems(IMaintainable[] itemsArray)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Добавляет элемент 
        /// </summary>
        /// <param name="item"></param>
        protected override ListViewItem AddItem(IMaintainable item)
        {
            //throw new NotImplementedException();
            return null;
        }

        /// <summary>
        /// Происходит сортировка списка
        /// </summary>
        protected override void Sort()
        {
            //throw new NotImplementedException();
        }


        #endregion

        #endregion

    }

    #region internal class DiscrepanciesListViewComparer : IComparer<ListViewItem>

    internal class DiscrepanciesListViewComparer : IComparer<ListViewItem>
    {
        #region Fields
        private readonly int[] indexArray;
        private readonly int sortMultiplier = 1;
        #endregion

        #region Constructors

        #region public DiscrepanciesListViewComparer(Queue<int> columnIndexQueue)

        /// <summary>
        /// Создает компаратор для ListViewItem
        /// </summary>
        /// <param name="columnIndexQueue"></param>
        public DiscrepanciesListViewComparer(Queue<int> columnIndexQueue)
        {
            indexArray = columnIndexQueue.ToArray();
        }
        #endregion

        #region public DiscrepanciesListViewComparer(Queue<int> columnIndexQueue, int sortMultiplier): this(columnIndexQueue)
        /// <summary>
        /// Создает компаратор для ListViewItem
        /// </summary>
        /// <param name="columnIndexQueue"></param>
        /// <param name="sortMultiplier"></param>
        public DiscrepanciesListViewComparer(Queue<int> columnIndexQueue, int sortMultiplier)
            : this(columnIndexQueue)
        {
            this.sortMultiplier = sortMultiplier;
        }
        #endregion

        #endregion

        #region Methods

        #region private int ColumnComparer(int columnIndex, ListViewItem x, ListViewItem y)
        private int ColumnComparer(int columnIndex, ListViewItem x, ListViewItem y)
        {
            if (columnIndex == 2)
                return ComparerMethods.DescriptionComparer(x.SubItems[columnIndex].Text, y.SubItems[columnIndex].Text);
            if (columnIndex == 1)
                return ComparerMethods.AdStatusComparer(x.SubItems[columnIndex].Text, y.SubItems[columnIndex].Text);
            if (columnIndex == 6)
                return
                    DateTime.Compare(((IMaintainable) x.Tag).ApproximateDate,
                                     ((IMaintainable) y.Tag).ApproximateDate);
            return String.Compare(x.SubItems[columnIndex].Text, y.SubItems[columnIndex].Text);

        }
        #endregion

        #region private int CheckColumnIndexQueue(int index ,ListViewItem x,ListViewItem y)

        private int CheckColumnIndexQueue(int index, ListViewItem x, ListViewItem y)
        {
            if (index < 0) return 0;
            if (0 != ColumnComparer(indexArray[index], x, y))
                return ColumnComparer(indexArray[index], x, y);
            else
                return CheckColumnIndexQueue(index - 1, x, y);

        }
        #endregion

        #region public int Compare(ListViewItem x, ListViewItem y)

        public int Compare(ListViewItem x, ListViewItem y)
        {
            if (x.Group == y.Group)
            {
                return sortMultiplier * CheckColumnIndexQueue(indexArray.Length - 1, x, y);
            }
            return String.Compare(x.Group.Name, y.Group.Name) ;

        }

     
        #endregion

        #endregion
    }

    #endregion

}
