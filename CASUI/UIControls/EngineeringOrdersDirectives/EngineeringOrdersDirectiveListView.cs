using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Directives;
using CAS.Core.Types.ReportFilters;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.EngineeringOrdersDirectives;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using Microsoft.VisualBasic.Devices;

namespace CAS.UI.UIControls.EngineeringOrdersDirectives
{
    /// <summary>
    /// Элемент управления для отображения списка директив Engineering Orders
    /// </summary>
    public class EngineeringOrdersDirectiveListView : SDList<EngineeringOrderDirective>, IReference
    {
        
        #region Fields

        private readonly BaseDetail parentBaseDetail;
        private readonly DirectiveCollectionFilter directiveFilter;
        private readonly float[] HEADER_WIDTH = new float[] { 0.15f, 0.55f, 0.28f };
        private readonly int SORT_MEMORY_COUNT = 6;
        private readonly Queue<int> columnIndexQueue = new Queue<int>();
        private readonly Color[] COLORS = new Color[] { Css.CommonAppearance.Colors.BackColor, Css.ListView.Colors.NotifyColor, Css.ListView.Colors.NotSatisfactoryColor, Css.ListView.Colors.PendingColor };

        #endregion
        
        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения списка директив Engineering Orders
        /// </summary>
        public EngineeringOrdersDirectiveListView(BaseDetail parentBaseDetail)
        {
            selectedItemsList = new List<EngineeringOrderDirective>();
            ItemsListView.Font = Css.ListView.Fonts.SmallRegularFont;
            ItemsListView.ColumnClick += ItemsListView_ColumnClick;
            ItemsListView.MouseDoubleClick += ItemsListView_MouseDoubleClick;
            ItemsListView.SelectedIndexChanged += ItemsListView_SelectedIndexChanged;
            ItemsListView.PreviewKeyDown += ItemsListView_PreviewKeyDown;
            DisplayerRequested += EngineeringOrdersDirectiveListView_DisplayerRequested;
            columnIndexQueue.Enqueue(0);

            this.parentBaseDetail = parentBaseDetail;
            directiveFilter = new DirectiveCollectionFilter(new DirectiveFilter[1] {new EngeneeringOrderFilter()});
        }

        #endregion

        #region Properties

        #region public override EngineeringOrderDirective SelectedItem

        /// <summary>
        /// Выбранная директива
        /// </summary>
        public override EngineeringOrderDirective SelectedItem
        {
            get
            {
                if (ItemsListView.SelectedItems.Count == 1)
                    return (ItemsListView.SelectedItems[0].Tag as EngineeringOrderDirective);
                return null;
            }
        }
        #endregion

        #region public override List<EngineeringOrderDirective> SelectedItems

        /// <summary>
        /// Возвращает список выбранных директив
        /// </summary>
        public override List<EngineeringOrderDirective> SelectedItems
        {
            get
            {
                return selectedItemsList;
            }
        }
        #endregion

/*        #region public ListView ItemsListView

        /// <summary>
        /// Возвращает ListView
        /// </summary>
        public ListView ItemsListView
        {
            get
            {
                return listViewDirectives;
            }
        }

        #endregion

        #region public EngineeringOrderDirective[] Directives

        /// <summary>
        /// Возвращает или устанавливает отображаемые директивы
        /// </summary>
        public EngineeringOrderDirective[] Directives
        {
            get
            {
                return directives.ToArray();
            }
            set
            {
                directives.Clear();
                directives.AddRange(value);
                UpdateItems();
            }
        }

        #endregion*/

        #endregion

        #region Methods

        #region public override void UpdateItems()

        /// <summary>
        /// Обновляет элементы ListView
        /// </summary>
        public override void UpdateItems()
        {
            directiveFilter.InitialCollection = parentBaseDetail.ContainedDirectives;
            BaseDetailDirective[] baseDetailDirectiveArray = directiveFilter.GatherDirectives();
            List<EngineeringOrderDirective> directives = new List<EngineeringOrderDirective>();
            for (int i = 0; i < baseDetailDirectiveArray.Length; i++)
                directives.Add((EngineeringOrderDirective)baseDetailDirectiveArray[i]);
            SetItemsArray(directives.ToArray());
        }
        #endregion

        #region protected override void AddItems(EngineeringOrderDirective[] itemsArray)

        /// <summary>
        /// Добавляет элементы <see cref="EngineeringOrderDirective"/> в ListView
        /// </summary>
        /// <param name="itemsArray"></param>
        protected override void AddItems(EngineeringOrderDirective[] itemsArray)
        {
            if (itemsArray.Length != 0)
            {
                int count = itemsArray.Length;
                for (int i = 0; i < count; i++)
                {
                    AddItem(itemsArray[i]);
                }
                ItemsListView.Items.AddRange(ListViewItemList.ToArray());
                SortItems(oldColumnIndex);
            }
        }

        #endregion

        #region public override EngineeringOrderDirective[] GetItemsArray()

        /// <summary>
        /// Метод возвращает массив элементов
        /// </summary>
        /// <returns></returns>
        public override EngineeringOrderDirective[] GetItemsArray()
        {
            int count = ListViewItemList.Count;
            EngineeringOrderDirective[] returnDetailArray = new EngineeringOrderDirective[0];
            if (count > 0)
            {
                returnDetailArray = new EngineeringOrderDirective[count];
                for (int i = 0; i < count; i++)
                {
                    returnDetailArray[i] = (EngineeringOrderDirective)ListViewItemList[i].Tag;
                }
            }
            return returnDetailArray;
        }
        #endregion

        #region private string[] GetItemsString(EngineeringOrderDirective directives)

        private string[] GetItemsString(EngineeringOrderDirective directive)
        {
            return new string[] { directive.Title, directive.Subject, directive.InspectedDetailLifelength.ToString() };
        }

        #endregion

        #region protected override ListViewItem AddItem(EngineeringOrderDirective directive)

        protected override ListViewItem AddItem(EngineeringOrderDirective directive)
        {
            string[] itemsString = GetItemsString(directive);
            ListViewItem listViewItem = new ListViewItem(itemsString);
            listViewItem.Tag = directive;
            listViewItem.BackColor = COLORS[directive.Condition.GetHashCode()];
            ItemsHash.Add(directive, listViewItem);
            ListViewItemList.Add(listViewItem);
            return listViewItem;

        }

        #endregion

        #region public override void EditItem(EngineeringOrderDirective oldItem, EngineeringOrderDirective modifiedItem)

        public override void EditItem(EngineeringOrderDirective oldItem, EngineeringOrderDirective modifiedItem)
        {
            string[] itemsString = GetItemsString(modifiedItem);
            string[] itemsStringModified = new string[itemsString.Length - 1];
            Array.Copy(itemsString, 1, itemsStringModified, 0, itemsStringModified.Length);
            ListViewItem listViewItem = ItemsHash[GetDirectiveReferenceByDirectiveID(oldItem.ID)];
            listViewItem.SubItems.Clear();
            listViewItem.Text = modifiedItem.Title;
            listViewItem.SubItems.AddRange(itemsStringModified);
            listViewItem.Tag = modifiedItem;
            listViewItem.BackColor = COLORS[modifiedItem.Condition.GetHashCode()];
            ItemsHash.Remove(oldItem);
            ItemsHash.Add(modifiedItem, listViewItem);
            ItemsListView.Refresh();
        }

        #endregion

        #region private EngineeringOrderDirective GetDirectiveReferenceByDirectiveID(int id)

        private EngineeringOrderDirective GetDirectiveReferenceByDirectiveID(int id)
        {
            EngineeringOrderDirective[] directives = GetItemsArray();
            for (int i = 0; i < directives.Length; i++)
            {
                if (directives[i].ID == id)
                    return directives[i];
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
            columnHeader.Text = "Title";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[1]);
            columnHeader.Text = "Subject";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[2]);
            columnHeader.Text = "Compliance Deadline";
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

            ListViewItemList.Sort(new ListViewItemsComparer(columnIndex, sortMultiplier));
            ItemsListView.Items.Clear();
            ItemsListView.Groups.Clear();
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
                ColumnHeaderList[i].Width = (int)(Width * HEADER_WIDTH[i]);
            }
        }
        #endregion

        #region private void EngineeringOrdersDirectiveListView_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void EngineeringOrdersDirectiveListView_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            string regNumber = "";
            if (SelectedItem.Parent is AircraftFrame)
                regNumber = SelectedItem.Parent.ToString();
            else
            {
                if ((SelectedItem.Parent).Parent is Aircraft)
                    regNumber = ((Aircraft)((SelectedItem.Parent).Parent)).RegistrationNumber + ". " + SelectedItem.Parent;
            }
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.DisplayerText = regNumber + ". " + SelectedItem.DirectiveType.CommonName + ". " + SelectedItem.Title;
            e.RequestedEntity = new DispatcheredEngineeringOrderDirectiveScreen(SelectedItem);
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
            if (SelectedItem != null && e.Button == MouseButtons.Left)
            {
                OnDisplayerRequested();
            }
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
}
