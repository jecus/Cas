using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.Directives;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DirectiveControls;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using Microsoft.VisualBasic.Devices;
using Auxiliary;

namespace CAS.UI.UIControls.DirectivesControls
{
    ///<summary>
    /// Элемент управления для отображения списка агрегатов, хранящихся на складе
    ///</summary>
    public class DamageDirectiveListView : SDList<BaseDetailDirective> , IReference
    {

        #region Fields

        private readonly float[] HEADER_WIDTH = new float[] {0.1f, 0.15f, 0.12f, 0.12f, 0.12f, 0.12f, 0.07f, 0.07f, 0.11f};
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

        #region Constructors

        #region public DamageDirectiveListView()

        /// <summary>
        /// Создает элемент управления отображающий список CPCP директив
        /// </summary>
        public DamageDirectiveListView()
        {
            selectedItemsList = new List<BaseDetailDirective>();
            ItemsListView.ColumnClick += ItemsListView_ColumnClick;
            ItemsListView.MouseDoubleClick += ItemsListView_MouseDoubleClick;
            ItemsListView.SelectedIndexChanged += ItemsListView_SelectedIndexChanged;
            ItemsListView.PreviewKeyDown += ItemsListView_PreviewKeyDown;
            DisplayerRequested += ComponentStatusListView_DisplayerRequested;
            oldColumnIndex = 0;
            columnIndexQueue.Enqueue(0);
            SetHeaders();
        }

        #endregion
        
        #endregion

        #region Properties

        #region public BaseDetailDirective SelectedItem

        /// <summary>
        /// Выбранный элемент
        /// </summary>
        public override BaseDetailDirective SelectedItem
        {
            get
            {
                if (ItemsListView.SelectedItems.Count == 1)
                    return (ItemsListView.SelectedItems[0].Tag as BaseDetailDirective);
                return null;
            }
        }
        #endregion

        #region public override List<BaseDetailDirective>  SelectedItems
        /// <summary>
        /// Свойство возвращает массив выбранных элементов
        /// </summary>
        public override List<BaseDetailDirective> SelectedItems
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
        }

        #endregion

        #region protected override void AddItems(BaseDetailDirective[] itemsArray)

        /// <summary>
        /// Добавляет элементы <see cref="BaseDetailDirective"/> в ListView
        /// </summary>
        /// <param name="itemsArray"></param>
        protected override void AddItems(BaseDetailDirective[] itemsArray)
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

        #region protected override ListViewItem AddItem(BaseDetailDirective item)
        /// <summary>
        /// Добавляет элемент с указанием группы в которой он находится
        /// </summary>
        /// <param name="item">Добавляемый элемент</param>
        protected override ListViewItem AddItem(BaseDetailDirective item)
        {
            string[] itemsString = GetItemString(item);
            ListViewItem listViewItem = new ListViewItem(itemsString);
            if (!item.Closed)
                listViewItem.ForeColor = Color.Black;
            listViewItem.BackColor = UsefulMethods.GetDirectiveColor(item);
            listViewItem.Tag = item;
            ItemsHash.Add(item,listViewItem);
            ListViewItemList.Add(listViewItem);
            return listViewItem;
        }
        #endregion

        #region public override void EditItem(BaseDetailDirective oldItem, BaseDetailDirective modifiedItem)

        public override void EditItem(BaseDetailDirective oldItem, BaseDetailDirective modifiedItem)
        {
            string[] itemsString = GetItemString(modifiedItem);
            BaseDetailDirective detail = GetDirectiveReferenceByDirectiveID(modifiedItem.ID);
            if (detail == null) return;
            ListViewItem listViewItem = ItemsHash[detail];
            listViewItem.SubItems.Clear();
            if (!modifiedItem.Closed)
                listViewItem.ForeColor = Color.Black;
            listViewItem.Text = itemsString[0];
            for (int i = 1; i < itemsString.Length; i++ )
                listViewItem.SubItems.Add(itemsString[i]);
            listViewItem.BackColor = UsefulMethods.GetDirectiveColor(modifiedItem);
            listViewItem.Tag = modifiedItem;
            ItemsHash.Remove(modifiedItem);
            ItemsHash.Add(modifiedItem,listViewItem);
            ItemsListView.Refresh();
            SetTotalText();
        }

        #endregion

        #region private static string[] GetItemString(BaseDetailDirective item)

        private static string[] GetItemString(BaseDetailDirective item)
        {
            DateTime manufactureDate = ((BaseDetail)item.Parent).ManufactureDate;
            string inspectionDocument = "";
            if (item.LastPerformance != null)
                inspectionDocument = item.LastPerformance.Reference;
            return new string[]
                {item.Title, 
                    item.Description,
                    item.References, 
                    inspectionDocument, 
                    item.Boundery,
                    item.Closed ? "" : ((item.RepeatPerform != null && item.RepeatPerform != Lifelength.NullLifelength) ? (item.RepeatedlyPerform ? item.RepeatPerform.ToRepeatIntervalsFormat() : "") : ""), 
                    item.LastPerformance == null ? "" : item.LastPerformance.Lifelength.ToCPCPListViewItemString(manufactureDate),
                    item.NextPerformance == null ||!item.NextPerformance.Applicable ? "" : item.NextPerformance.ToListViewNextCompliance(item.ApproximateDate, item.Condition),
                    item.LeftTillNextPerformance == null ? "" : item.LeftTillNextPerformance.ToRepeatIntervalsFormat()
                };
        }

        #endregion

        #region private BaseDetailDirective GetDirectiveReferenceByDirectiveID(int id)

        private BaseDetailDirective GetDirectiveReferenceByDirectiveID(int id)
        {
            BaseDetailDirective[] directives = GetItemsArray();
            for (int i = 0; i < directives.Length; i++)
            {
                if (directives[i].ID == id)
                    return directives[i];
            }
            return null;
        }

        #endregion

        #region public override BaseDetailDirective[] GetItemsArray()

        /// <summary>
        /// Метод возвращает массив директив
        /// </summary>
        /// <returns>Массив директив</returns>
        public override BaseDetailDirective[] GetItemsArray()
        {
            int count = ListViewItemList.Count;
            BaseDetailDirective[] returnDetailArray = new BaseDetailDirective[0];
            if (count > 0)
            {
                returnDetailArray = new BaseDetailDirective[count];
                for (int i = 0; i < count; i++)
                {
                    returnDetailArray[i] = (BaseDetailDirective)ListViewItemList[i].Tag;
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
            columnHeader.Text = "Item #";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int) (ItemsListView.Width*HEADER_WIDTH[1]);
            columnHeader.Text = "Description";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int) (ItemsListView.Width*HEADER_WIDTH[2]);
            columnHeader.Text = "Initial Documents";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[3]);
            columnHeader.Text = "Inspection Document";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[4]);
            columnHeader.Text = "Required Inspection";
            ColumnHeaderList.Add(columnHeader);
            
            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[5]);
            columnHeader.Text = "Repeat Interval";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[6]);
            columnHeader.Text = "Last";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[7]);
            columnHeader.Text = "Next";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[8]);
            columnHeader.Text = "Remain";
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
            e.DisplayerText = SelectedItem.Parent + ". " + SelectedItem.DirectiveType.CommonName + ". " + SelectedItem.Title;
            e.RequestedEntity = new DispatcheredDamageDirectiveScreen(SelectedItem);
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
