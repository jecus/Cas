using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CAS.Core;
using CAS.Core.Core.Interfaces;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts.Templates;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.Directives.Templates;
using CAS.Core.Types.ReportFilters.Templates;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DirectiveControls;
using CAS.UI.UIControls.Auxiliary;
using Microsoft.VisualBasic.Devices;

namespace CAS.UI.UIControls.TemplatesControls
{
    internal class TemplateDirectiveListView : SDList<TemplateBaseDetailDirective>, IReference
    {
        
        #region Fields

        private readonly ITemplateDirectiveContainer directiveSource;
        private readonly TemplateDirectiveCollectionFilter filter;
        private TemplateDirectiveCollectionFilter additionalFilter;
        private readonly Queue<int> columnIndexQueue = new Queue<int>();
        private readonly int SORT_MEMORY_COUNT = 6;
        private readonly float[] HEADER_WIDTH = new float[] { 0.20f, 0.58f, 0.20f};

        private IDisplayer displayer;
        private IDisplayingEntity entity;
        private string displayerText;
        private ReflectionTypes reflectionType;
     
        #endregion

        #region Constructors

        #region public TemplateDirectiveListView(ITemplateDirectiveContainer directiveSource, TemplateDirectiveCollectionFilter filter)

        /// <summary>
        /// Создает элемент управления отображающий listview по заданому масиву шаблонных директив
        /// </summary>
        /// <param name="directiveSource">Контейнер директив</param>
        /// <param name="filter"></param>
        public TemplateDirectiveListView(ITemplateDirectiveContainer directiveSource, TemplateDirectiveCollectionFilter filter)
        {
            sortMultiplier = -1;
            selectedItemsList = new List<TemplateBaseDetailDirective>();
            ItemsListView.ColumnClick += ItemsListView_ColumnClick;
            ItemsListView.MouseDoubleClick += ItemsListView_MouseDoubleClick;
            ItemsListView.SelectedIndexChanged += ItemsListView_SelectedIndexChanged;
            ItemsListView.KeyDown += ItemsListView_KeyDown;
            DisplayerRequested += DirectiveListView_DisplayerRequested;
            columnIndexQueue.Enqueue(0);

            this.directiveSource = directiveSource;
            this.filter = filter;
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

        #endregion

        #region public string DisplayerText

        /// <summary>
        /// Text of page's header that Reference lead to
        /// </summary>
        public string DisplayerText
        {
            get { return displayerText; }
            set { displayerText = value; }
        }

        #endregion

        #region public IDisplayingEntity Entity

        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        #endregion

        #region public ReflectionTypes ReflectionType

        /// <summary>
        /// Type of reflection [:|||:]
        /// </summary>
        public ReflectionTypes ReflectionType
        {
            get { return reflectionType; }
            set { reflectionType = value;}
        }

        #endregion

        #region public override TemplateBaseDetailDirective SelectedItem

        /// <summary>
        /// Возвращает выделенную шаблонную директиву
        /// </summary>
        public override TemplateBaseDetailDirective SelectedItem
        {
            get
            {
                if (ItemsListView.SelectedItems.Count == 1) return (ItemsListView.SelectedItems[0].Tag as TemplateBaseDetailDirective);
                return null;
            }
        }

        #endregion

        #region public override List<TemplateBaseDetailDirective> SelectedItems

        /// <summary>
        /// Свойство возвращает массив выбранных шаблонных директив
        /// </summary>
        public override List<TemplateBaseDetailDirective> SelectedItems
        {
            get
            {
                return selectedItemsList;
            }
        }

        #endregion

        #region public TemplateDirectiveCollectionFilter AdditionalFilter

        /// <summary>
        /// Возвращает или устанавливает дополнительный фильтр 
        /// </summary>
        public TemplateDirectiveCollectionFilter AdditionalFilter
        {
            get
            {
                return additionalFilter;
            }
            set
            {
                additionalFilter = value;
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
            SetItemsArray(GatherDirectives());
        }

        #endregion

        #region public TemplateBaseDetailDirective[] GatherDirectives()

        /// <summary>
        /// Собирает все директивы
        /// </summary>
        /// <returns></returns>
        public TemplateBaseDetailDirective[] GatherDirectives()
        {
            List<TemplateDirectiveFilter> filters = new List<TemplateDirectiveFilter>(filter.Filters);
            if (additionalFilter != null)
                filters.AddRange(additionalFilter.Filters);
            TemplateDirectiveCollectionFilter generalFilter =
                new TemplateDirectiveCollectionFilter(directiveSource.ContainedDirectives, filters.ToArray());
            TemplateBaseDetailDirective[] directives = generalFilter.GatherDirectives();
            return directives;
        }

        #endregion

        #region protected override void AddItems(TemplateBaseDetailDirective[] itemsArray)

        /// <summary>
        /// Добавляет элементы <see cref="TemplateBaseDetailDirective"/> в ListView
        /// </summary>
        /// <param name="itemsArray"></param>
        protected override void AddItems(TemplateBaseDetailDirective[] itemsArray)
        {
            if (itemsArray.Length != 0)
            {
                int count = itemsArray.Length;
                for (int i = 0; i < count; i++)
                {
                    AddItem(itemsArray[i]);
                }
                ItemsListView.Items.AddRange(ListViewItemList.ToArray());
                if (itemsArray[0].DirectiveType == DirectiveTypeCollection.Instance.ADDirectiveType)
                    sortMultiplier = -1;
                else
                    sortMultiplier = 1;
                ShowGroups = true;
                //if (columnIndexQueue.Count == 1) 
                    SortItems(0, sortMultiplier);
            }
        }

        #endregion
        
        #region public override TemplateBaseDetailDirective[] GetItemsArray()

        /// <summary>
        /// Метод возвращает массив шаблонных директив
        /// </summary>
        /// <returns>Массив шаблонных директив</returns>
        public override TemplateBaseDetailDirective[] GetItemsArray()
        {
            int count = ListViewItemList.Count;
            TemplateBaseDetailDirective[] returnDetailArray = new TemplateBaseDetailDirective[0];
            if (count > 0)
            {
                returnDetailArray = new TemplateBaseDetailDirective[count];
                for (int i = 0; i < count; i++)
                {
                    returnDetailArray[i] = (TemplateBaseDetailDirective)ListViewItemList[i].Tag;
                }
            }
            return returnDetailArray;
        }

        #endregion

        #region protected override void AddItem(TemplateBaseDetailDirective item)

        /// <summary>
        /// Добавляет элемент в список шаблонных директив
        /// </summary>
        /// <param name="item">Добавляемый элемент</param>
        protected override ListViewItem AddItem(TemplateBaseDetailDirective item)
        {
            string[] itemsString = GetItemsString(item);
            ListViewItem listViewItem = new ListViewItem(itemsString);
            if (item.AtaChapter != null)
                listViewItem.SubItems.Add(item.AtaChapter.FullName);
            else
                listViewItem.SubItems.Add("0");
            listViewItem.Tag = item;
            ItemsHash.Add(item, listViewItem);
            ListViewItemList.Add(listViewItem);
            return listViewItem;
        }

        #endregion

        #region public override void EditItem(TemplateBaseDetailDirective oldItem, TemplateBaseDetailDirective modifiedItem)

        /// <summary>
        /// Изменяет элемент
        /// </summary>
        /// <param name="oldItem">Элемент до измения</param>
        /// <param name="modifiedItem">Измененный элемент</param>
        public override void EditItem(TemplateBaseDetailDirective oldItem, TemplateBaseDetailDirective modifiedItem)
        {
            string[] itemsString = GetItemsString(modifiedItem);
            string[] itemsStringModified = new string[itemsString.Length - 1];
            Array.Copy(itemsString, 1, itemsStringModified, 0, itemsStringModified.Length);
            ListViewItem listViewItem = ItemsHash[GetDirectiveReferenceByDirectiveID(oldItem.ID)];
            listViewItem.SubItems.Clear();
            listViewItem.Text = modifiedItem.Title;
            listViewItem.SubItems.AddRange(itemsStringModified);
            listViewItem.Tag = modifiedItem;
            ItemsHash.Remove(oldItem);
            ItemsHash.Add(modifiedItem, listViewItem);
            ItemsListView.Refresh();
        }

        #endregion

        #region private TemplateBaseDetailDirective GetDirectiveReferenceByDirectiveID(int id)

        private TemplateBaseDetailDirective GetDirectiveReferenceByDirectiveID(int id)
        {
            TemplateBaseDetailDirective[] directives = GetItemsArray();
            for (int i = 0; i < directives.Length; i++)
            {
                if (directives[i].ID == id)
                    return directives[i];
            }
            return null;
        }

        #endregion

        #region private string[] GetItemsString(TemplateBaseDetailDirective item)

        private string[] GetItemsString(TemplateBaseDetailDirective item)
        {
            string description = Regex.Replace(item.Description, "\r\n", " ");
            LifelengthFormatter lifelengthFormatter = new LifelengthFormatter();
            return
                new string[]
                    {
                        item.Title, description,
                        item.RepeatPerform != null
                            ? lifelengthFormatter.GetData(item.RepeatPerform, " h ", " c ", " d")
                            : ""
                    };
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
            columnHeader.Text = "Title";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[1]);
            columnHeader.Text = "Subject";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[2]);
            columnHeader.Text = "Repeat Intervals";
            ColumnHeaderList.Add(columnHeader);

/*            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[3]);
            columnHeader.Text = "Amount";
            ColumnHeaderList.Add(columnHeader);*/

            ItemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
        }

        #endregion

        #region private void SortItems(int columnIndex,int sortMultiplier)

        private void SortItems(int columnIndex, int columnSortMultiplier)
        {
            if (columnIndexQueue.Count >= SORT_MEMORY_COUNT)
            {
                columnIndexQueue.Dequeue();
                columnIndexQueue.Enqueue(columnIndex);
            }
            else columnIndexQueue.Enqueue(columnIndex);
            ListViewItemList.Sort(new DirectiveListViewComparer(columnIndexQueue, columnSortMultiplier));
            ItemsListView.Items.Clear();
            ItemsListView.Groups.Clear();
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
            SortItems(oldColumnIndex, sortMultiplier);
        }

        #endregion

        #region public void PreviousSort()

        /// <summary>
        /// Осушествляет предидущую сортировку
        /// </summary>
        public void PreviousSort()
        {
            SortItems(oldColumnIndex, sortMultiplier);
        }

        #endregion



        #region protected void OnDisplayerRequested()

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

        #region private void ItemsListView_ColumnClick(object sender, ColumnClickEventArgs e)

        private void ItemsListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (oldColumnIndex != e.Column) sortMultiplier = -1;
            if (sortMultiplier == 1)
                sortMultiplier = -1;
            else
                sortMultiplier = 1;
            SortItems(e.Column,sortMultiplier);
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

        #region private void DirectiveListView_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void DirectiveListView_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            if (SelectedItem != null)
            {
                string model = ((TemplateAircraft)SelectedItem.Parent.Parent).Model;
                if (!(SelectedItem.Parent is TemplateAircraftFrame))
                    model += ". " + SelectedItem.Parent;
                //e.DisplayerText = "Templates. " + model + ". " + SelectedItem.DirectiveType.CommonName + ". " + SelectedItem.Title;
                e.DisplayerText = model + ". " + SelectedItem.DirectiveType.CommonName + ". " + SelectedItem.Title;
                e.RequestedEntity = new DispatcheredTemplateDirectiveScreen(SelectedItem);
            }
        }

        #endregion

        #region private void ItemsListView_SelectedIndexChanged(object sender, EventArgs e)

        private void ItemsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedItemsChanged!=null) SelectedItemsChanged.Invoke(this,new SelectedItemsChangeEventArgs(selectedItemsList.Count));
        }

        #endregion

        #region private void ItemsListView_KeyDown(object sender, KeyEventArgs e)
        private void ItemsListView_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyData)
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
        public event EventHandler<SelectedItemsChangeEventArgs> SelectedItemsChanged;
        #endregion

        #endregion

    }
}