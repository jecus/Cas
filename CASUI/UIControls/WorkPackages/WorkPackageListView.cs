using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Auxiliary;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Directives;
using CAS.Core.Core.Interfaces;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.WorkPackages;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DirectiveControls;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.EngineeringOrdersDirectives;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using Microsoft.VisualBasic.Devices;
using CAS.UI.UIControls.MaintenanceStatusControls;
using System.Drawing;

namespace CAS.UI.UIControls.WorkPackages
{
    /// <summary>
    /// ListView для отображения списка работ рабочего пакета
    /// </summary>
    public class WorkPackageListView : SDList<IMaintainable>, IReference
    {
        
        #region Fields

        private readonly WorkPackage currentWorkPackage;
        private NonRoutineJob nonRoutineJobBeforeSaving;
        private JobCard jobCardBeforeSaving;

        private readonly float[] HEADER_WIDTH = new float[] {0.05f, 0.2f, 0.53f, 0.07f, 0.06f, 0.07f};
        private readonly Queue<int> columnIndexQueue = new Queue<int>();
        private readonly int SORT_MEMORY_COUNT = 6;
        private Label labelTotalMH;
        private Label labelTotalCost;

        private readonly List<string> groups = new List<string>();

        
        #region private DisplayingEntity entity
        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        private IDisplayer displayer;
        /// <summary>
        /// Entity to display
        /// </summary>
        private IDisplayingEntity entity;
        private string displayerText;
        private ReflectionTypes reflectionType;

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Создает ListView для отображения списка работ рабочего пакета
        /// </summary>
        public WorkPackageListView(WorkPackage currentWorkPackage)
        {
            this.currentWorkPackage = currentWorkPackage;
            selectedItemsList = new List<IMaintainable>();
            ItemsListView.Font = Css.ListView.Fonts.SmallRegularFont;
            ItemsListView.ColumnClick += ItemsListView_ColumnClick;
            ItemsListView.MouseDoubleClick += ItemsListView_MouseDoubleClick;
            ItemsListView.SelectedIndexChanged += ItemsListView_SelectedIndexChanged;
            ItemsListView.PreviewKeyDown += ItemsListView_PreviewKeyDown;
            DisplayerRequested += WorkPackageListView_DisplayerRequested;
            oldColumnIndex = 1;
            columnIndexQueue.Enqueue(0);
            ShowGroups = true;
            SetHeaders();
            ModifyBottomPanel();
            SetGroupsOrder();
            UpdateItems();
        }

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

        #region public override void UpdateItems()

        /// <summary>
        /// Обновляет элементы ListView
        /// </summary>
        public override void UpdateItems()
        {
            ItemsHash.Clear();
            ListViewItemList.Clear();
            ItemsListView.Items.Clear();
            selectedItemsList.Clear();
            
            AddItems(currentWorkPackage.Items.ToArray());
            SetTotalText();
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
            for (int i = 0; i < items.Length; i++ )
            {
                manHours += items[i].ManHours;
                cost += items[i].Cost;
            }
            labelTotalMH.Text = "Total MH: " + Math.Round(manHours);
            labelTotalCost.Text = "Total Cost: " + Math.Round(cost);
        }

        #endregion

        #region public override IMaintainable[] GetItemsArray()
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
            columnHeader.Text = "Work Type";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[4]);
            columnHeader.Text = "MH";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int) (ItemsListView.Width * HEADER_WIDTH[5]);
            columnHeader.Text = "Cost (USD)";
            ColumnHeaderList.Add(columnHeader);

            if (ItemsListView.Columns.Count == 0) 
                ItemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
        }
        #endregion

        #region private void SetGroupsOrder()

        private void SetGroupsOrder()
        {
            groups.Clear();
            ItemsListView.Groups.Clear();

            Aircraft aircraft = (Aircraft) currentWorkPackage.Parent;

            groups.Add(aircraft + ". " + DirectiveTypeCollection.Instance.ADDirectiveType.CommonName);
            for (int i = 0; i < aircraft.Engines.Length; i++)
                groups.Add(aircraft + ". " + aircraft.Engines[i] + ". " + DirectiveTypeCollection.Instance.ADDirectiveType.CommonName);
            groups.Add(aircraft + ". " + aircraft.Apu + ". " + DirectiveTypeCollection.Instance.ADDirectiveType.CommonName);
            groups.Add(aircraft + ". " + DirectiveTypeCollection.Instance.AgineProgramDirectiveType.CommonName);
            groups.Add(aircraft + ". Component Status");
            for (int i = 0; i < aircraft.LandingGears.Length; i++ )
                groups.Add(aircraft + ". " + aircraft.LandingGears[i] + ". Component Status");
            for (int i = 0; i < aircraft.Engines.Length; i++)
                groups.Add(aircraft + ". " + aircraft.Engines[i] + ". LLP Disk Sheet Status");
            groups.Add(aircraft + ". " + aircraft.Apu + ". Component Status");
            groups.Add(aircraft + ". " + DirectiveTypeCollection.Instance.CPCPDirectiveType.CommonName);
            groups.Add(aircraft + ". " + DirectiveTypeCollection.Instance.DeferredItemsDirectiveType.CommonName);
            groups.Add(aircraft + ". " + DirectiveTypeCollection.Instance.EngineeringOrdersDirectiveType.CommonName);
            for (int i = 0; i < aircraft.Engines.Length; i++)
                groups.Add(aircraft + ". " + aircraft.Engines[i] + ". " + DirectiveTypeCollection.Instance.EngineeringOrdersDirectiveType.CommonName);
            groups.Add(aircraft + ". " + aircraft.Apu + ". " + DirectiveTypeCollection.Instance.EngineeringOrdersDirectiveType.CommonName);
            groups.Add(aircraft + ". " + DirectiveTypeCollection.Instance.ModificationDirectiveType.CommonName);
            groups.Add(aircraft + ". " + DirectiveTypeCollection.Instance.OutOffPhaseDirectiveType.CommonName);
            groups.Add(aircraft + ". " + DirectiveTypeCollection.Instance.RepairDirectiveType.CommonName);
            groups.Add(aircraft + ". " + DirectiveTypeCollection.Instance.SBDirectiveType.CommonName);
            for (int i = 0; i < aircraft.Engines.Length; i++)
                groups.Add(aircraft + ". " + aircraft.Engines[i] + ". " + DirectiveTypeCollection.Instance.SBDirectiveType.CommonName);
            groups.Add(aircraft + ". " + aircraft.Apu + ". " + DirectiveTypeCollection.Instance.SBDirectiveType.CommonName);
            groups.Add(aircraft + ". " + DirectiveTypeCollection.Instance.SSIDDirectiveType.CommonName);
            groups.Add(aircraft + ". Maintenance Program");
            groups.Add(aircraft + ". Jobs Cards");
            groups.Add(currentWorkPackage.Title + ". Non-Routine Jobs");
            for (int i = 0; i < groups.Count; i++)
                AddGroup(groups[i]);
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
            SortItems(e.Column);
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

        #region void ItemsListView_SelectedIndexChanged(object sender, EventArgs e)
        private void ItemsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSelectedItemsChange(this, new SelectedItemsChangeEventArgs(selectedItemsList.Count));
        }
        #endregion

        #region private void ItemsListView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)

        private void ItemsListView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
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

        #region private void WorkPackageListView_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void WorkPackageListView_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (SelectedItem is NonRoutineJob)
            {
                e.Cancel = true;
                nonRoutineJobBeforeSaving = (NonRoutineJob) SelectedItem;
                NonRoutineJobForm form = new NonRoutineJobForm(nonRoutineJobBeforeSaving);
                form.Saved += form_Saved;
                form.ShowDialog();
            }
            else if (SelectedItem is JobCard)
            {
                e.Cancel = true;
                jobCardBeforeSaving = (JobCard)SelectedItem;
                MaintenanceJobCardForm form = new MaintenanceJobCardForm(jobCardBeforeSaving);
                form.Saved += formJobCard_Saved;
                form.ShowDialog();
            }
            else if (SelectedItem is AbstractDetail || SelectedItem is DetailDirective)
            {
                AbstractDetail detail;
                if (SelectedItem is DetailDirective)
                    detail = (AbstractDetail)SelectedItem.Parent;
                else
                    detail = (AbstractDetail) SelectedItem;
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;

                if (detail is Detail || detail is DetailReal)//todo
                    e.DisplayerText = ((Aircraft)detail.Parent.Parent).RegistrationNumber + ". Component SN " + detail.SerialNumber;
                else
                    e.DisplayerText = ((Aircraft)detail.Parent).RegistrationNumber + ". Component SN " + detail.SerialNumber;
                e.RequestedEntity = new DispatcheredDetailScreen(detail);
            }
            else
            {
                BaseDetailDirective directive = (BaseDetailDirective)SelectedItem;
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;

                string regNumber = "";
                if (SelectedItem.Parent is AircraftFrame)
                    regNumber = SelectedItem.Parent.ToString();
                else
                {
                    if ((SelectedItem.Parent).Parent is Aircraft)
                        regNumber = ((Aircraft)((SelectedItem.Parent).Parent)).RegistrationNumber + ". " + SelectedItem.Parent;
                }
                e.DisplayerText = regNumber + ". " + directive.DirectiveType.CommonName + ". " + directive.Title;
                if (directive is EngineeringOrderDirective)
                    e.RequestedEntity = new DispatcheredEngineeringOrderDirectiveScreen((EngineeringOrderDirective)directive);
                else if (directive.DirectiveType == DirectiveTypeCollection.Instance.OutOffPhaseDirectiveType)
                    e.RequestedEntity = new DispatcheredOutOffPhaseReferenceScreen(directive);
                else if (directive.DirectiveType == DirectiveTypeCollection.Instance.CPCPDirectiveType)
                    e.RequestedEntity = new DispatcheredCPCPDirectiveScreen(directive);
                else
                    e.RequestedEntity = new DispatcheredDirectiveScreen(directive);
            }
        }

        #endregion

        #region private void form_Saved(NonRoutineJob nonRoutineJobAfterSaving)

        private void form_Saved(NonRoutineJob nonRoutineJobAfterSaving)
        {
            EditItem(nonRoutineJobBeforeSaving, nonRoutineJobAfterSaving);
        }

        #endregion

        #region private void formJobCard_Saved(NonRoutineJob nonRoutineJobAfterSaving)

        private void formJobCard_Saved(JobCard jobCardAfterSaving)
        {
            EditItem(jobCardBeforeSaving, jobCardAfterSaving);
        }

        #endregion


        #region protected override void AddItems(IMaintainable[] itemsArray)

        /// <summary>
        /// Добавляет элементы <see cref="IMaintainable"/> в ListView
        /// </summary>
        /// <param name="itemsArray"></param>
        protected override void AddItems(IMaintainable[] itemsArray)
        {
            if (itemsArray.Length != 0)
            {
                int count = itemsArray.Length;
                for (int i = 0; i < count; i++)
                    AddItem(itemsArray[i]);
                sortMultiplier = -1;
                SortItems(oldColumnIndex);
            }
        }

        #endregion

        #region private static string[] GetItemsString(IMaintainable item)

        private static string[] GetItemsString(IMaintainable item)
        {
            double e = 0.000000001;
            return new string[]
                {
                    item.AtaChapter.ShortName == "N/A" ? "" : item.AtaChapter.ShortName, item.Title, item.Description,
                    item.WorkType.ShortName,
                    item.ManHours < e ? "" : item.ManHours.ToString(),
                    item.Cost < e ? "" : item.Cost.ToString()
                };
        }

        #endregion

        #region protected override ListViewItem AddItem(IMaintainable item)

        /// <summary>
        /// Добавляет элемент 
        /// </summary>
        /// <param name="item"></param>
        protected override ListViewItem AddItem(IMaintainable item)
        {
            string[] itemsString = GetItemsString(item);
            ListViewItem listViewItem = new ListViewItem(itemsString);
            listViewItem.BackColor = GetIMaintainableColor(item);
            listViewItem.Tag = item;
            ItemsHash.Add(item, listViewItem);
            ListViewItemList.Add(listViewItem);
            return listViewItem;
        }

        #endregion
        
        #region public override void EditItem(IMaintainable oldItem, IMaintainable modifiedItem)

        /// <summary>
        /// Изменяет элемент
        /// </summary>
        /// <param name="oldItem">Элемент до измения</param>
        /// <param name="modifiedItem">Измененный элемент</param>
        public override void EditItem(IMaintainable oldItem, IMaintainable modifiedItem)
        {
            ListViewItem listViewItem = ItemsHash[GetIOverallsReferenceByIOverallsID(oldItem.ID)];
            PrepareItem(modifiedItem, ref listViewItem);
            ItemsHash.Remove(oldItem);
            ItemsHash.Add(modifiedItem, listViewItem);
            ItemsListView.Refresh();
            SetTotalText();
        }

        #endregion

        #region private IMaintainable GetIOverallsReferenceByIOverallsID(int id)

        private IMaintainable GetIOverallsReferenceByIOverallsID(int id)
        {
            IMaintainable[] iOveralses = GetItemsArray();
            for (int i = 0; i < iOveralses.Length; i++)
            {
                if (iOveralses[i].ID == id)
                    return iOveralses[i];
            }
            return null;
        }

        #endregion

        #region private void PrepareItem(IMaintainable item, ref ListViewItem listViewItem)

        private void PrepareItem(IMaintainable item, ref ListViewItem listViewItem)
        {
            string[] itemsString = GetItemsString(item);
            listViewItem.SubItems.Clear();
            listViewItem.Text = itemsString[0];
            for (int i = 1; i < itemsString.Length; i++)
                listViewItem.SubItems.Add(itemsString[i]);
            listViewItem.Tag = item;
        }

        #endregion

        #region protected override void Sort()

        /// <summary>
        /// Происходит сортировка списка
        /// </summary>
        protected override void Sort()
        {
            SortItems(oldColumnIndex);
        }

        #endregion
        
        #region private void SortItems(int columnIndex)

        private void SortItems(int columnIndex)
        {
            if (oldColumnIndex != columnIndex)
                sortMultiplier = -1;
            if (sortMultiplier == 1)
                sortMultiplier = -1;
            else
                sortMultiplier = 1;
            if (columnIndexQueue.Count >= SORT_MEMORY_COUNT)
            {
                columnIndexQueue.Dequeue();
                columnIndexQueue.Enqueue(columnIndex);
            }
            else columnIndexQueue.Enqueue(columnIndex);

            ItemsListView.Items.Clear();
            
            SetGroupsToItems();
            ListViewItemList.Sort(new CertainGroupsOrderListViewComparer(columnIndex, sortMultiplier, groups));

            ItemsListView.Items.AddRange(ListViewItemList.ToArray());
            
            oldColumnIndex = columnIndex;
        }

        #endregion

        #region private void SetGroupsToItems()

        private void SetGroupsToItems()
        {
            SetGroupsOrder();
            for (int i = 0; i < ListViewItemList.Count; i++)
                ListViewItemList[i].Group = ItemsListView.Groups[UsefulMethods.GetGroupNameInWorkPackageList(ListViewItemList[i].Tag, currentWorkPackage)];
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

        #region public static Color GetIMaintainableColor(IMaintainable item)
        /// <summary>
        /// Возвращает цвет IMaintainable в скрине WorkPackage
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static Color GetIMaintainableColor(IMaintainable item)
        {
            
            if (item is NonRoutineJob)
                     if (((NonRoutineJob)item).JobCard == null || ((NonRoutineJob)item).JobCard.AttachedFile.FileData == null) return Css.ListView.Colors.PendingColor;
                else if (item is AbstractDetail)
                         if (((AbstractDetail)item).JobCard == null || ((AbstractDetail)item).JobCard.AttachedFile.FileData == null) return Css.ListView.Colors.PendingColor;
                else if (item is BaseDetailDirective)
                             if (((BaseDetailDirective)item).JobCard == null || ((BaseDetailDirective)item).JobCard.AttachedFile.FileData == null) return Css.ListView.Colors.PendingColor;
                else if (item is JobCard)
                                 if (((JobCard)item).AttachedFile.FileData == null) return Css.ListView.Colors.PendingColor;
                else if (item is DetailDirective)
                           if (((DetailDirective)item).JobCard == null || ((DetailDirective)item).JobCard.AttachedFile.FileData == null) return Css.ListView.Colors.PendingColor;

            return Color.White;
                   
        }
        #endregion
               
        #endregion

    }

}
