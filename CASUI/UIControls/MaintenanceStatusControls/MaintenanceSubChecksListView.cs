using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Directives;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.MaintenanceStatusControls;
using CAS.UI.UIControls.Auxiliary;
using Microsoft.VisualBasic.Devices;

namespace CAS.UI.UIControls.MaintenanceStatusControls
{
    /// <summary>
    /// Элемент управления для отображения списка SubCheck-ов
    /// </summary>
    public class MaintenanceSubChecksListView : SDList<MaintenanceSubCheck>, IReference
    {

        #region Fields

        private readonly MaintenanceDirective directive;
        private readonly float[] HEADER_WIDTH = new float[] { 0.75f, 0.23f };
        private readonly int SORT_MEMORY_COUNT = 6;
        private readonly Queue<int> columnIndexQueue = new Queue<int>();


        #endregion

        #region Constructors

        #region public MaintenanceSubChecksListView(MaintenanceDirective directive)

        /// <summary>
        /// Создает элемент управления для отображения списка SubCheck-ов
        /// </summary>
        /// <param name="directive"></param>
        public MaintenanceSubChecksListView(MaintenanceDirective directive)
        {
            
/*            //
            // listViewSubChecks
            //
            listViewSubChecks.Dock = DockStyle.Fill;
            listViewSubChecks.Font = Css.ListView.Fonts.RegularFont;
            listViewSubChecks.FullRowSelect = true;
            listViewSubChecks.View = View.Details;
            listViewSubChecks.ItemSelectionChanged += listViewSubChecks_ItemSelectionChanged;
            listViewSubChecks.MouseDoubleClick += listViewSubChecks_MouseDoubleClick;
            listViewSubChecks.ColumnClick += listViewSubChecks_ColumnClick;

            DisplayerRequested += MaintenanceSubChecksListView_DisplayerRequested;
            Controls.Add(listViewSubChecks);*/


            selectedItemsList = new List<MaintenanceSubCheck>();
            ItemsListView.Font = Css.ListView.Fonts.SmallRegularFont;
            ItemsListView.ColumnClick += listViewJobCards_ColumnClick;
            ItemsListView.MouseDoubleClick += listViewJobCards_MouseDoubleClick;
            ItemsListView.SelectedIndexChanged += ItemsListView_SelectedIndexChanged;
            ItemsListView.PreviewKeyDown += ItemsListView_PreviewKeyDown;
            DisplayerRequested += MaintenanceJobCardsListView_DisplayerRequested;
            columnIndexQueue.Enqueue(0);

            this.directive = directive;
            UpdateItems();
        }

        #endregion
        
        #endregion

        #region Properties

        #region public override MaintenanceSubCheck SelectedItem

        /// <summary>
        /// Выбранный SubCheck
        /// </summary>
        public override MaintenanceSubCheck SelectedItem
        {
            get
            {
                if (ItemsListView.SelectedItems.Count == 1)
                    return (ItemsListView.SelectedItems[0].Tag as MaintenanceSubCheck);
                return null;
            }
        }

        #endregion

        #region public override List<MaintenanceSubCheck> SelectedItems

        /// <summary>
        /// Возвращает список выбранных SubCheck-ов
        /// </summary>
        public override List<MaintenanceSubCheck> SelectedItems
        {
            get
            {
                return selectedItemsList;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region public override void UpdateItems()

        /// <summary>
        /// Обновляет элементы ListView
        /// </summary>
        public override void UpdateItems()
        {
            List<MaintenanceSubCheck> maintenanceSubChecks = new List<MaintenanceSubCheck>();
            for (int i = 0; i < directive.Limitations.Length; i++)
                maintenanceSubChecks.AddRange(directive.Limitations[i].SubChecks);
            SetItemsArray(maintenanceSubChecks.ToArray());
        }

        #endregion

        #region protected override void AddItems(MaintenanceSubCheck[] itemsArray)

        /// <summary>
        /// Добавляет элементы <see cref="MaintenanceSubCheck"/> в ListView
        /// </summary>
        /// <param name="itemsArray"></param>
        protected override void AddItems(MaintenanceSubCheck[] itemsArray)
        {
            if (itemsArray.Length != 0)
            {
                int count = itemsArray.Length;
                for (int i = 0; i < count; i++)
                {
                    AddItem(itemsArray[i]);
                }
                SetGroupsToItems();
                ItemsListView.Items.AddRange(ListViewItemList.ToArray());
                ShowGroups = true;
                sortMultiplier = -1;
                SortItems(oldColumnIndex);
            }
        }

        #endregion

        #region private void SetGroupsToItems()

        private void SetGroupsToItems()
        {
            for (int i = 0; i < directive.Limitations.Length; i++)
                AddGroup(directive.Limitations[i].CheckType.FullName);
            for (int i = 0; i < ListViewItemList.Count; i++)
                ListViewItemList[i].Group = GetListViewGroup(ListViewItemList[i]);

        }

        #endregion

        #region private ListViewGroup GetListViewGroup(ListViewItem item)

        private ListViewGroup GetListViewGroup(ListViewItem item)
        {
            return ItemsListView.Groups[((MaintenanceLimitation)((MaintenanceSubCheck)item.Tag).Parent).CheckType.FullName];
        }

        #endregion


        #region public override MaintenanceSubCheck[] GetItemsArray()

        /// <summary>
        /// Метод возвращает массив элементов
        /// </summary>
        /// <returns></returns>
        public override MaintenanceSubCheck[] GetItemsArray()
        {
            int count = ListViewItemList.Count;
            MaintenanceSubCheck[] returnDetailArray = new MaintenanceSubCheck[0];
            if (count > 0)
            {
                returnDetailArray = new MaintenanceSubCheck[count];
                for (int i = 0; i < count; i++)
                {
                    returnDetailArray[i] = (MaintenanceSubCheck)ListViewItemList[i].Tag;
                }
            }
            return returnDetailArray;
        }

        #endregion

        #region private string[] GetItemsString(MaintenanceSubCheck subCheck)

        private string[] GetItemsString(MaintenanceSubCheck subCheck)
        {
            string name = subCheck.Name + " check";
            if (subCheck.JoinedSubChecks.Count > 0)
            {
                name += " (includes";
                for (int i = 0; i < subCheck.JoinedSubChecks.Count; i++)
                {
                    name += " " + subCheck.JoinedSubChecks[i].Name + " check";
                    if (i < subCheck.JoinedSubChecks.Count - 1)
                        name += ",";
                    else
                        name += ")";
                }
            }
            int count = subCheck.JobCards.Count;
            for (int i = 0; i < subCheck.JoinedSubChecks.Count; i++)
                count += subCheck.JoinedSubChecks[i].JobCards.Count;
            return new string[] {name, count.ToString()};
        }

        #endregion

        #region protected override ListViewItem AddItem(MaintenanceSubCheck subCheck)

        protected override ListViewItem AddItem(MaintenanceSubCheck subCheck)
        {
            string[] itemsString = GetItemsString(subCheck);
            ListViewItem listViewItem = new ListViewItem(itemsString);
            listViewItem.Tag = subCheck;
            ItemsHash.Add(subCheck, listViewItem);
            ListViewItemList.Add(listViewItem);
            return listViewItem;
        }

        #endregion

        #region public override void EditItem(MaintenanceSubCheck oldItem, MaintenanceSubCheck modefiedItem)

        public override void EditItem(MaintenanceSubCheck oldItem, MaintenanceSubCheck modefiedItem)
        {
            string[] itemsString = GetItemsString(modefiedItem);
            string[] itemsStringModified = new string[itemsString.Length - 1];
            Array.Copy(itemsString, 1, itemsStringModified, 0, itemsStringModified.Length);
            ListViewItem listViewItem = ItemsHash[GetSubCheckReferenceBySubCheckID(oldItem.ID)];
            listViewItem.SubItems.Clear();
            listViewItem.SubItems.AddRange(itemsStringModified);
            listViewItem.Text = itemsString[0];

            listViewItem.Tag = modefiedItem;
            ItemsHash.Remove(oldItem);
            ItemsHash.Add(modefiedItem, listViewItem);
            ItemsListView.Refresh();
        }

        #endregion

        #region private MaintenanceSubCheck GetSubCheckReferenceBySubCheckID(int id)

        private MaintenanceSubCheck GetSubCheckReferenceBySubCheckID(int id)
        {
            MaintenanceSubCheck[] subChecks = GetItemsArray();
            for (int i = 0; i < subChecks.Length; i++)
            {
                if (subChecks[i].ID == id)
                    return subChecks[i];
            }
            return null;
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
            columnHeader.Text = "Name";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[1]);
            columnHeader.Text = "Job cards";
            ColumnHeaderList.Add(columnHeader);

            ItemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
        }
        #endregion

        #region private void SortItems(int columnIndex)

        private void SortItems(int columnIndex)
        {
            if (oldColumnIndex != columnIndex)
            {
                sortMultiplier = -1;

            }
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

            ListViewItemList.Sort(new MaintenanceSubChecksListViewComparer(columnIndex, sortMultiplier));
            ItemsListView.Items.Clear();
            ItemsListView.Groups.Clear();
            SetGroupsToItems();
            ItemsListView.Items.AddRange(ListViewItemList.ToArray());
            ShowGroups = true;
            oldColumnIndex = columnIndex;
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
                if (k.ShiftKeyDown && reflection == ReflectionTypes.DisplayInCurrent) reflection = ReflectionTypes.DisplayInNew;
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
                ColumnHeaderList[i].Width = (int)(Width * HEADER_WIDTH[i]);
            }
        }
        #endregion

        #region private void listViewJobCards_ColumnClick(object sender, ColumnClickEventArgs e)

        private void listViewJobCards_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SortItems(e.Column);
        }

        #endregion

        #region private void listViewJobCards_MouseDoubleClick(object sender, MouseEventArgs e)

        private void listViewJobCards_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SelectedItem != null && e.Button == MouseButtons.Left)
            {
                OnDisplayerRequested();
            }
        }

        #endregion

        #region private void MaintenanceJobCardsListView_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void MaintenanceJobCardsListView_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.DisplayerText = ((Aircraft)SelectedItem.Parent.Parent.Parent).RegistrationNumber + ". " + SelectedItem.Name + " Check. Maintenance Job Cards";
            e.RequestedEntity = new DispatcheredJobCardsCollectionScreen(SelectedItem);
        }

        #endregion

        #region private void ItemsListView_SelectedIndexChanged(object sender, EventArgs e)

        private void ItemsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedItemsChanged != null)
                SelectedItemsChanged.Invoke(this, new SelectedItemsChangeEventArgs(selectedItemsList.Count));
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

        #endregion

        #region Events

        #region public event EventHandler SelectedItemsChanged;
        /// <summary>
        /// Событие возникающее при изменении массива выбранных элементов в списке элементов, которые отображаются в списке, вот!
        /// </summary>
        public event EventHandler SelectedItemsChanged;
        #endregion

        #endregion

        #region IReference Members

        private IDisplayer displayer;
        private string displayerText;
        private IDisplayingEntity entity;
        private ReflectionTypes reflectionType;

        public IDisplayer Displayer
        {
            get { return displayer; }
            set { displayer = value; }
        }

        public string DisplayerText
        {
            get { return displayerText; }
            set { displayerText = value; }
        }

        public IDisplayingEntity Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        public ReflectionTypes ReflectionType
        {
            get { return reflectionType; }
            set { reflectionType = value; }
        }

        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        #endregion

    }

    #region MaintenanceSubChecksListViewComparer

    /// <summary>
    /// Сравнивалка <see cref="ListViewItem"/>
    /// </summary>
    internal class MaintenanceSubChecksListViewComparer : IComparer<ListViewItem>
    {
        private readonly int columnIndex;
        private readonly int sortMultiplier;

        #region Fields



        #endregion

        #region Constructor

        public MaintenanceSubChecksListViewComparer(int columnIndex, int sortMultiplier)
        {
            this.columnIndex = columnIndex;
            this.sortMultiplier = sortMultiplier;
        }

        #endregion

        #region IComparer<MaintenanceJobCard> Members

        public int Compare(ListViewItem x, ListViewItem y)
        {
            if (columnIndex == 0)
                return sortMultiplier * string.Compare(NormalizeSubCheckName(x.SubItems[columnIndex].Text), NormalizeSubCheckName(y.SubItems[columnIndex].Text));
            else
                return sortMultiplier * string.Compare(x.SubItems[columnIndex].Text, y.SubItems[columnIndex].Text);
        }

        #endregion

        #region private string NormalizeSubCheckName(string name)

        private string NormalizeSubCheckName(string name)
        {
            if (name.Length > 0 && Regex.IsMatch(name[0].ToString(), "[0-9]"))
            {
                int i = 0;
                string number = "";
                string type = "";
                while (Regex.IsMatch(name[i].ToString(), "[0-9]"))
                    number += name[i++];
                while (name[i] != ' ' || i >= name.Length)
                    type += name[i++];
                return type + number;
            }
            else
                return name;
        }

        #endregion

    }

    #endregion

}
