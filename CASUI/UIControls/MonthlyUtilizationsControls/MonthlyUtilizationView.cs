using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Auxiliary;
using Auxiliary.Comparers;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.ATLBs;
using CAS.UI.Appearance;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CASTerms;

namespace CAS.UI.UIControls.MonthlyUtilizationsControls
{
    /// <summary>
    /// Элемент управления отображающий список полетов ВС
    /// </summary>
    public class MonthlyUtilizationView : SDList<AircraftFlight>
    {
        
        #region Fields

        private List<AircraftFlight> currentFlights = new List<AircraftFlight>();
        private readonly Aircraft currentAircraft;
        private readonly float[] headerWidth = new[] {0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.15f, 0.17f, 0.16f};
        private readonly Queue<int> columnIndexQueue = new Queue<int>();
        private const int SORT_MEMORY_COUNT = 8;
        private Lifelength lifelengthFrom;
        private List<AircraftFlight> sortedAircraftsFlights;
        
        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления отображающий список полетов ВС
        /// </summary>
        /// <param name="aircraft">Текущее ВС</param>
        public MonthlyUtilizationView(Aircraft aircraft)
        {
            currentAircraft = aircraft;
            selectedItemsList = new List<AircraftFlight>();
            ItemsListView.ColumnClick += ItemsListView_ColumnClick;
            ItemsListView.MouseDoubleClick += ItemsListView_MouseDoubleClick;
            ItemsListView.SelectedIndexChanged += ItemsListView_SelectedIndexChanged;
            ItemsListView.PreviewKeyDown += ItemsListView_PreviewKeyDown;
            oldColumnIndex = 0;
            columnIndexQueue.Enqueue(0);
            ShowGroups = true;
            SetHeaders();
            //UpdateItems();
        }

        #endregion

        #region Properties

        #region public List<AircraftFlight> Flights

        /// <summary>
        /// Возвращает ил иустанавливает отображаемые полеты
        /// </summary>
        public List<AircraftFlight> Flights
        {
            get { return currentFlights; }
            set
            {
                currentFlights = value;
                sortedAircraftsFlights = new List<AircraftFlight>(Flights);
                sortedAircraftsFlights.Sort(new AircraftFlightsComparer());
                lifelengthFrom = sortedAircraftsFlights.Count > 0 ? currentAircraft.GetLifelength(sortedAircraftsFlights[0].FlightDate) : null;
            }
        }

        #endregion

        /// <summary>
        /// Возвращает ил иустанавливает отображаемые полеты
        /// </summary>
        public List<AircraftFlight> SortedFlights
        {
            get { return sortedAircraftsFlights; }
            
        }

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
            AddItems(Flights.ToArray());
            SetTotalText();
        }

        #endregion

        #region private Lifelength GetPerMonth(int index)

        private Lifelength GetPerMonth(int index)
        {
            TimeSpan hours = new TimeSpan(0, 0, 0);
            int cycles = 0;
            for (int i = 0; i <= index; i++)
            {
                if (sortedAircraftsFlights[i].FlightDate.Year == sortedAircraftsFlights[index].FlightDate.Year && sortedAircraftsFlights[i].FlightDate.Month == sortedAircraftsFlights[index].FlightDate.Month)
                {
                    hours += sortedAircraftsFlights[i].FlightTime;
                    cycles++;
                }
            }
            return new Lifelength(new TimeSpan(0, 0, 0), cycles, hours);
        }

        #endregion

        #region private Lifelength GetAC_TFT(int index)

        private Lifelength GetAC_TFT(int index)
        {
            if (lifelengthFrom == null)
                return null;
            TimeSpan hours = lifelengthFrom.Hours;
            int cycles = lifelengthFrom.Cycles;
            for (int i = 0; i <= index; i++)
            {
                hours += sortedAircraftsFlights[i].FlightTime;
                cycles++;
            }
            return new Lifelength(lifelengthFrom.Calendar, cycles, hours);
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
            string[] itemsString = GetItemsString(item);
            ListViewItem listViewItem = new ListViewItem(itemsString);
            listViewItem.BackColor = item.Highlight.Color;
            if (!item.Correct)
                listViewItem.BackColor = Css.ListView.Colors.PendingColor;
            listViewItem.Tag = item;
            ItemsHash.Add(item,listViewItem);
            ListViewItemList.Add(listViewItem);
            return listViewItem;
        }
        #endregion

        #region private static string[] GetItemsString(AircraftFlight item)

        private string[] GetItemsString(AircraftFlight item)
        {
            Lifelength perMonth = GetPerMonth(sortedAircraftsFlights.IndexOf(item));
            Lifelength acTft = GetAC_TFT(sortedAircraftsFlights.IndexOf(item));
            return new[]
                       {item.FlightDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString()),  
                           item.FlightNo, 
                           item.StationFrom + " - " + item.StationTo, 
                           "", 
                           "",
                           UsefulMethods.TimeToString(item.FlightTime) + " (" + UsefulMethods.TimePeriodToString(item.TakeOffTime, item.LdgTime) + ")", 
                           perMonth == null ? "" : perMonth.ToHoursMinutesAndCyclesFormat(), 
                           acTft == null ? "" : acTft.ToHoursAndCyclesFormat("hrs","cyc")};
        }

        #endregion


        #region public override void EditItem(AircraftFlight oldItem, AircraftFlight modifiedItem)

        public override void EditItem(AircraftFlight oldItem, AircraftFlight modifiedItem)
        {
            AircraftFlight detail = GetFlightReferenceByFlightID(oldItem.ID);
            if (detail == null) 
                return;
            ListViewItem listViewItem = ItemsHash[detail];
            string[] itemsString = GetItemsString(modifiedItem);
            listViewItem.SubItems.Clear();
            listViewItem.Text = itemsString[0];
            for (int i = 1; i < itemsString.Length; i++)
                listViewItem.SubItems.Add(itemsString[i]);
            listViewItem.BackColor = modifiedItem.Highlight.Color;
            if (!modifiedItem.Correct)
                listViewItem.BackColor = Css.ListView.Colors.PendingColor;
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
            ColumnHeader columnHeader = new ColumnHeader();
            columnHeader.Width = (int) (ItemsListView.Width*headerWidth[0]);
            columnHeader.Text = "Date";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int) (ItemsListView.Width*headerWidth[1]);
            columnHeader.Text = "Flight No";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int) (ItemsListView.Width*headerWidth[2]);
            columnHeader.Text = "Direction";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * headerWidth[3]);
            columnHeader.Text = "Reference";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * headerWidth[4]);
            columnHeader.Text = "Page No";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * headerWidth[5]);
            columnHeader.Text = "Flight Time";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * headerWidth[6]);
            columnHeader.Text = "Per Month";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * headerWidth[7]);
            columnHeader.Text = "AC TFT";
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
            ListViewItemList.Sort(new MonthlyUtilizationListViewComparer(columnIndex, sortMultiplier));

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
            ItemsListView.Groups.Clear();
            for (int i = 0;i< ListViewItemList.Count; i++)
            {
                string groupName = ((AircraftFlight)ListViewItemList[i].Tag).FlightDate.ToString("MMMM yyyy", CultureInfo.CurrentCulture);
                if (!ContainsGroup(groupName))
                    AddGroup(groupName);
                ListViewItemList[i].Group = ItemsListView.Groups[groupName];
            }
        }

        #endregion

        #region private bool ContainsGroup(string groupName)

        private bool ContainsGroup(string groupName)
        {
            for (int i = 0; i < ItemsListView.Groups.Count; i++)
            {
                if (ItemsListView.Groups[i].Name == groupName)
                    return true;
            }
            return false;
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
                ColumnHeaderList[i].Width = (int) (Width*headerWidth[i]);
            }
        }
        #endregion

        #region private void ItemsListView_ColumnClick(object sender, ColumnClickEventArgs e)

        private void ItemsListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SortItems(e.Column);
        }

        #endregion

        #region private void OnMouseDoubleClicked()

        private void OnMouseDoubleClicked()
        {
            if (SelectedItem != null)
            {
                AircraftFlightForm form = new AircraftFlightForm(SelectedItem);
                form.Show();
            }
        }

        #endregion
        
        #region private void ItemsListView_MouseDoubleClick(object sender, MouseEventArgs e)

        private void ItemsListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OnMouseDoubleClicked();
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
                        OnMouseDoubleClicked();
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        #endregion
        
  
    }

    internal class MonthlyUtilizationListViewComparer : IComparer<ListViewItem>
    {

        #region Fields

        private readonly int columnIndex;
        private readonly int sortMultiplier;

        #endregion

        #region Constructors

        #region public MonthlyUtilizationListViewComparer(int columnIndex)

        /// <summary>
        /// Создает компаратор для MonthlyUtilizationListView
        /// </summary>
        /// <param name="columnIndex"></param>
        public MonthlyUtilizationListViewComparer(int columnIndex)
        {
            this.columnIndex = columnIndex;
        }

        #endregion

        #region public MonthlyUtilizationListViewComparer(int index, int sortMultiplier) : this(index)

        /// <summary>
        /// Создает компаратор для MonthlyUtilizationListView
        /// </summary>
        public MonthlyUtilizationListViewComparer(int index, int sortMultiplier)
            : this(index)
        {
            this.sortMultiplier = sortMultiplier;
        }

        #endregion

        #endregion

        #region Methods

        #region public int Compare(object x, object y)

        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <returns>
        /// Value Condition Less than zerox is less than y.Zerox equals y.Greater than zerox is greater than y.
        /// </returns>
        /// <param name="y">The second object to compare.</param><param name="x">The first object to compare.</param>
        public int Compare(ListViewItem x, ListViewItem y)
        {
            if (columnIndex == 0)
            {
                return
                    sortMultiplier *
                    DateTime.Compare(Convert.ToDateTime(x.SubItems[columnIndex].Text, new CultureInfo("ru-Ru", true)),
                                     Convert.ToDateTime(y.SubItems[columnIndex].Text, new CultureInfo("ru-Ru", true)));
            }
            return sortMultiplier * string.Compare(x.SubItems[columnIndex].Text, y.SubItems[columnIndex].Text);
        }
        #endregion

        #endregion

    }

}