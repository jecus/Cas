using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.ATLBs;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.AircraftTechnicalLogBookControls;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using Microsoft.VisualBasic.Devices;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    /// <summary>
    /// Элемент управления отображающий бортовой журнал ВС
    /// </summary>
    public class ATLBsListView : SDList<ATLB> , IReference
    {

        #region Fields

        private readonly Aircraft currentAircraft;
        private readonly float[] HEADER_WIDTH = new float[] {0.6f, 0.15f, 0.23f};
       // private readonly Color[] COLORS = new Color[] { Css.CommonAppearance.Colors.BackColor, Css.ListView.Colors.NotifyColor, Css.ListView.Colors.NotSatisfactoryColor};
        //private readonly Color highlightColor = Css.ListView.Colors.PendingColor;
        private readonly Queue<int> columnIndexQueue = new Queue<int>();
        private readonly int SORT_MEMORY_COUNT = 8;
        private readonly TermsProvider termsProvider = new TermsProvider();
        
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
        /// <param name="aircraft">ВС</param>
        public ATLBsListView(Aircraft aircraft)
        {
            currentAircraft = aircraft;
            selectedItemsList = new List<ATLB>();
            ItemsListView.ColumnClick += ItemsListView_ColumnClick;
            ItemsListView.MouseDoubleClick += ItemsListView_MouseDoubleClick;
            ItemsListView.SelectedIndexChanged += ItemsListView_SelectedIndexChanged;
            ItemsListView.PreviewKeyDown += ItemsListView_PreviewKeyDown;
            DisplayerRequested += ComponentStatusListView_DisplayerRequested;
            oldColumnIndex = 0;
            columnIndexQueue.Enqueue(0);
            ShowGroups = true;
            SetHeaders();
            UpdateItems();
        }

        #endregion

        #region Properties

        #region public ATLB SelectedItem

        /// <summary>
        /// Выбранный элемент
        /// </summary>
        public override ATLB SelectedItem
        {
            get
            {
                if (ItemsListView.SelectedItems.Count == 1)
                    return (ItemsListView.SelectedItems[0].Tag as ATLB);
                return null;
            }
        }
        #endregion

        #region public override List<ATLB>  SelectedItems
        /// <summary>
        /// Свойство возвращает массив выбранных элементов
        /// </summary>
        public override List<ATLB> SelectedItems
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

            AddItems(currentAircraft.ATLBs);
            SetTotalText();
        }

        #endregion

        #region protected override void AddItems(ATLB[] itemsArray)

        /// <summary>
        /// Добавляет элементы <see cref="ATLB"/> в ListView
        /// </summary>
        /// <param name="itemsArray"></param>
        protected override void AddItems(ATLB[] itemsArray)
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

        #region protected override void AddItem(ATLB item)
        /// <summary>
        /// Добавляет элемент с указанием группы в которой он находится
        /// </summary>
        /// <param name="item">Добавляемый элемент</param>
        protected override ListViewItem AddItem(ATLB item)
        {
            string[] subItemsString = GetSubItemsString(item);
            ListViewItem listViewItem = new ListViewItem(item.ATLBNo);
            listViewItem.SubItems.AddRange(subItemsString);
            listViewItem.Tag = item;
            ItemsHash.Add(item,listViewItem);
            ListViewItemList.Add(listViewItem);
            return listViewItem;
        }
        #endregion

        #region private string[] GetSubItemsString(ATLB item)

        private string[] GetSubItemsString(ATLB item)
        {
            return
                new string[]
                    {
                        item.StartPageNo + " - " + (item.StartPageNo + 25),
                        item.DateFrom == null ? "" : item.DateFrom.Value.ToString(termsProvider["DateFormat"].ToString()) + " - " +
                        item.DateFrom == null ? "" : item.DateTo.Value.ToString(termsProvider["DateFormat"].ToString())
                    };
        }

        #endregion
        
        #region public override void EditItem(ATLB oldItem, ATLB modifiedItem)

        public override void EditItem(ATLB oldItem, ATLB modifiedItem)
        {
            string[] subItemsString = GetSubItemsString(modifiedItem);
            ATLB atlb = GetATLBReferenceByATLBID(oldItem.ID);
            if (atlb == null) 
                return;
            ListViewItem listViewItem = ItemsHash[atlb];
            listViewItem.SubItems.Clear();
            listViewItem.Text = modifiedItem.ATLBNo;
            listViewItem.SubItems.AddRange(subItemsString);
            listViewItem.Tag = modifiedItem;
            ItemsHash.Remove(oldItem);
            ItemsHash.Add(modifiedItem,listViewItem);
            ItemsListView.Refresh();
            SetTotalText();
        }

        #endregion

        #region private ATLB GetATLBReferenceByATLBID(int id)

        private ATLB GetATLBReferenceByATLBID(int id)
        {
            ATLB[] atlbs = GetItemsArray();
            for (int i = 0; i < atlbs.Length; i++)
            {
                if (atlbs[i].ID == id)
                    return atlbs[i];
            }
            return null;
        }

        #endregion

        #region public override ATLB[] GetItemsArray()

        /// <summary>
        /// Метод возвращает массив <see cref="ATLB"/>
        /// </summary>
        /// <returns>Массив агрегатов</returns>
        public override ATLB[] GetItemsArray()
        {
            int count = ListViewItemList.Count;
            ATLB[] returnDetailArray = new ATLB[0];
            if (count > 0)
            {
                returnDetailArray = new ATLB[count];
                for (int i = 0; i < count; i++)
                {
                    returnDetailArray[i] = (ATLB)ListViewItemList[i].Tag;
                }
            }
            return returnDetailArray;
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
            columnHeader.Text = "ATLB No";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int) (ItemsListView.Width*HEADER_WIDTH[1]);
            columnHeader.Text = "Pages";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int) (ItemsListView.Width*HEADER_WIDTH[2]);
            columnHeader.Text = "Date";
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

            ListViewItemList.Sort(new ListViewItemsComparer(columnIndex, sortMultiplier));

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

        #region private void ComponentStatusListView_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void ComponentStatusListView_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.DisplayerText = ((Aircraft)SelectedItem.Parent).RegistrationNumber + ". ATLB No " + SelectedItem.ATLBNo;
            e.RequestedEntity = new DispatcheredATLBFlightsScreen(SelectedItem);
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
