using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Auxiliary;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.ATLBs;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using Microsoft.VisualBasic.Devices;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    /// <summary>
    /// Элемент управления отображающий бортовой журнал ВС
    /// </summary>
    public class ATLBFlightsListView : SDList<AircraftFlight> , IReference
    {

        #region Fields

        private readonly ATLB currentATLB;
        private readonly float[] HEADER_WIDTH = new float[] {0.1f, 0.2f, 0.2f, 0.1f, 0.38f};
//        private readonly Color[] COLORS = new Color[] { Css.CommonAppearance.Colors.BackColor, Css.ListView.Colors.NotifyColor, Css.ListView.Colors.NotSatisfactoryColor};
        private readonly Queue<int> columnIndexQueue = new Queue<int>();
        private readonly int SORT_MEMORY_COUNT = 8;
        
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

        #region Constructor

        /// <summary>
        /// Создает элемент управления отображающий бортовой журнал ВС
        /// </summary>
        /// <param name="atlb">Текущий бортовой журнал</param>
        public ATLBFlightsListView(ATLB atlb)
        {
            currentATLB = atlb;
            selectedItemsList = new List<AircraftFlight>();
            ItemsListView.ColumnClick += ItemsListView_ColumnClick;
            ItemsListView.MouseDoubleClick += ItemsListView_MouseDoubleClick;
            ItemsListView.SelectedIndexChanged += ItemsListView_SelectedIndexChanged;
            ItemsListView.PreviewKeyDown += ItemsListView_PreviewKeyDown;
            DisplayerRequested += ATLBFlightsListView_DisplayerRequested;
            oldColumnIndex = 0;
            columnIndexQueue.Enqueue(0);
            ShowGroups = true;
            SetHeaders();
            UpdateItems();
        }

        #endregion

        #region Properties

        #region public AircraftFlight SelectedItem

        /// <summary>
        /// Выбранный элемент
        /// </summary>
        public override AircraftFlight SelectedItem
        {
            get
            {
                if (ItemsListView.SelectedItems.Count == 1) 
                    return (ItemsListView.SelectedItems[0].Tag as AircraftFlight);
                return null;
            }
        }
        #endregion

        #region public override List<AircraftFlight>  SelectedItems
        /// <summary>
        /// Свойство возвращает массив выбранных элементов
        /// </summary>
        public override List<AircraftFlight> SelectedItems
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
            ItemsHash.Clear();
            ListViewItemList.Clear();
            ItemsListView.Items.Clear();
            selectedItemsList.Clear();

            
            AddItems(currentATLB.Flights);
            SetTotalText();
            //ItemsListView.EndUpdate(); // Если не вызвать этот метод список не появится после обновления
        }

        #endregion

        #region protected override void AddItems(AircraftFlight[] itemsArray)

        /// <summary>
        /// Добавляет элементы <see cref="AircraftFlight"/> в ListView
        /// </summary>
        /// <param name="itemsArray"></param>
        protected override void AddItems(AircraftFlight[] itemsArray)
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

        #region protected override void AddItem(AircraftFlight item)
        /// <summary>
        /// Добавляет элемент с указанием группы в которой он находится
        /// </summary>
        /// <param name="item">Добавляемый элемент</param>
        protected override ListViewItem AddItem(AircraftFlight item)
        {
            string[] subItemsString = GetSubItemsString(item);
            ListViewItem listViewItem = new ListViewItem(item.ATLBPageNo.ToString());
            listViewItem.SubItems.AddRange(subItemsString);
            listViewItem.Tag = item;
            ItemsHash.Add(item,listViewItem);
            ListViewItemList.Add(listViewItem);
            return listViewItem;
        }
        #endregion

        #region private static string[] GetSubItemsString(AircraftFlight item)

        private static string[] GetSubItemsString(AircraftFlight item)
        {
            return new string[]
                {item.FlightNo, item.FlightDate.ToString(new TermsProvider()["DateFormat"].ToString()) + " " + UsefulMethods.TimeToString(item.OutTime) + " - " + UsefulMethods.TimeToString(item.InTime), item.StationFrom + " - " + item.StationTo, item.Discrepancies.Length > 0 ? "avaliable" : ""};
        }

        #endregion


        #region public override void EditItem(AircraftFlight oldItem, AircraftFlight modifiedItem)

        public override void EditItem(AircraftFlight oldItem, AircraftFlight modifiedItem)
        {
            string[] subItemsString = GetSubItemsString(modifiedItem);
            AircraftFlight detail = GetFlightReferenceByFlightID(oldItem.ID);
            if (detail == null) 
                return;
            ListViewItem listViewItem = ItemsHash[detail];
            listViewItem.SubItems.Clear();
            listViewItem.Text = modifiedItem.ATLBPageNo.ToString();
            listViewItem.SubItems.AddRange(subItemsString);
            listViewItem.Tag = modifiedItem;
            ItemsHash.Remove(oldItem);
            ItemsHash.Add(modifiedItem,listViewItem);
            ItemsListView.Refresh();
            SetTotalText();
        }

        #endregion

        #region private AircraftFlight GetFlightReferenceByFlightID(int id)

        private AircraftFlight GetFlightReferenceByFlightID(int id)
        {
            AircraftFlight[] details = GetItemsArray();
            for (int i = 0; i < details.Length; i++)
            {
                if (details[i].ID == id)
                    return details[i];
            }
            return null;
        }

        #endregion

        #region public override AircraftFlight[] GetItemsArray()

        /// <summary>
        /// Метод возвращает массив полетов ВС
        /// </summary>
        /// <returns>Массив агрегатов</returns>
        public override AircraftFlight[] GetItemsArray()
        {
            int count = ListViewItemList.Count;
            AircraftFlight[] flightsArray = new AircraftFlight[0];
            if (count > 0)
            {
                flightsArray = new AircraftFlight[count];
                for (int i = 0; i < count; i++)
                {
                    flightsArray[i] = (AircraftFlight)ListViewItemList[i].Tag;
                }
            }
            return flightsArray;
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
            columnHeader.Width = (int) (ItemsListView.Width*HEADER_WIDTH[0]);
            columnHeader.Text = "Page No";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int) (ItemsListView.Width*HEADER_WIDTH[1]);
            columnHeader.Text = "Flight No";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int) (ItemsListView.Width*HEADER_WIDTH[2]);
            columnHeader.Text = "Date";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[3]);
            columnHeader.Text = "Route";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[4]);
            columnHeader.Text = "Discrepancies";
            ColumnHeaderList.Add(columnHeader);

            ItemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
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
            //ListViewItemList.Sort(new CertainGroupsOrderListViewComparer(columnIndex, sortMultiplier, groups));

            ItemsListView.Items.AddRange(ListViewItemList.ToArray());

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
        
        #region private void SetGroupsToItems()

        private void SetGroupsToItems()
        {
/*            for (int i = 0; i < ListViewItemList.Count; i++)
                ListViewItemList[i].Group = ItemsListView.Groups[GetGroupNameInStoreDetailList(ListViewItemList[i].Tag)];*/
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
                ColumnHeaderList[i].Width = (int) (Width*HEADER_WIDTH[i]);
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

        #region private void ATLBFlightsListView_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void ATLBFlightsListView_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            FlightDialog.Show(SelectedItem);
            e.Cancel = true;
        }

        #endregion

        #region private void ItemsListView_SelectedIndexChanged(object sender, EventArgs e)

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

        #endregion
        
        #region IReference Members

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

        #region public event EventHandler<ReferenceEventArgs> DisplayerRequested

        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        #endregion

        #endregion
        
    }
 
}

