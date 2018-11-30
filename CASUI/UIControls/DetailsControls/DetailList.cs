using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using Controls.ExtendableList;
using LTR.Core.Types.Aircrafts.Parts;
using LTR.UI.UIControls.Auxiliary;

namespace LTR.UI.UIControls.DetailsControls
{
    /// <summary>
    /// Список для отборажения деталей
    /// </summary>
    [ToolboxItem(false)]
    public partial class DetailList : ExtendableList
    {
        #region Constructors

        #region public DetailList(Detail[] details)
        /// <summary>
        /// Конструктор создающий список деталей
        /// </summary>
        /// <param name="details"></param>
        public DetailList(Detail[] details) : this()
        {
            DisplayDetails(details, false);
        }
        #endregion

        #region public DetailList()
        /// <summary>
        /// Пустой констуктор
        /// </summary>
        public DetailList()
        {
            InitializeComponent();
            listGroupItem = new List<DetailATAChapterGroupItem>();
            listExtendableItem = new List<IExtendableItem>();
        }
        #endregion

        #endregion

        #region Fields
        private List<IExtendableItem> listExtendableItem;
        private List<DetailATAChapterGroupItem> listGroupItem;
        private Detail[] detailArray;
        private DetailHeaderItem headersItem;
        private bool isATAChapterShowen;

  

        private SortOrder sortOrder = SortOrder.Ascended;
        #endregion

        #region Methods

        #region public void DisplayDetails(Detail[] details,bool showATAChapter)

        /// <summary>
        /// Метод осуществляет отображение деталей
        /// </summary>
        /// <param name="details">Массив деталей</param>
        /// <param name="showATAChapter">Отображение ATAChapter</param>
        public void DisplayDetails(Detail[] details,bool showATAChapter)
        {
            isATAChapterShowen = showATAChapter;
            detailArray = details;
            Clear(headersItem);
            listExtendableItem.Clear();
            listGroupItem.Clear();
            if (headersItem == null)
            {
                headersItem = new DetailHeaderItem(details.Length);
                headersItem.HeaderClick += headersItem_HeaderClick;
                headersItem.Width = Width;
                AddHeaderItem(headersItem);
            }
            if (!showATAChapter)
            {
                FillDetailList(details);
                DisplayDetailList(listExtendableItem, details.Length);
            }
            else
            {
                FillDetailList(details);
                listExtendableItem.Sort(new DetailsColumnComparers(SortOrder.Ascended).ReturnComparer("ATA"));
                FillGroupItem(listExtendableItem);
                DisplayGroupDetailList(listGroupItem);
            }
            AdjustSize();
            headersItem.DetailsAmount = details.Length;
        }

        #endregion

        #region private void FillGroupItem(List<DetailItem> detailItemList)
        private void FillGroupItem(List<IExtendableItem> detailItemList)
        {
            if (detailItemList.Count == 0) return;
            DetailATAChapterGroupItem oldGroup = new DetailATAChapterGroupItem(((DetailItem)detailItemList[0]).ATAChapterFullText);
            listGroupItem.Add(oldGroup);
            foreach (IExtendableItem item in detailItemList)
            {
                if (oldGroup.ATAChapterText != ((DetailItem)item).ATAChapterFullText)
                {
                    oldGroup = new DetailATAChapterGroupItem(((DetailItem)item).ATAChapterFullText);
                    listGroupItem.Add(oldGroup);
                }
                oldGroup.ItemList.Add(item);
            }            
        }
        #endregion

        #region private void FillDetailList(Detail[] details, bool showATAChapter)
        private void FillDetailList(Detail[] details)
        {
            foreach (Detail detail in details)
            {
                listExtendableItem.Add(new DetailItem(detail));
            }
        }
        #endregion

        #region private void DisplayGroupDetailList(List<DetailATAChapterGroupItem> groupItemList)
        private void DisplayGroupDetailList(List<DetailATAChapterGroupItem> groupItemList)
        {
            for (int i = 0; i < groupItemList.Count; i++)
            {
                AddGroupItem(groupItemList[i]);
            }
        }
        #endregion

        #region private void DisplayDetailList(List<DetailItem> listExtendableItem, int Length)

        private void DisplayDetailList(List<IExtendableItem> listItem, int Length)
        {
            for (int i = 0; i < Length; i++)
            {
                Add(listItem[i]);
            }
        }

      
        #endregion

        #region  void headersItem_HeaderClick(object sender, HeaderClickEventArgs e)

        void headersItem_HeaderClick(object sender, HeaderClickEventArgs e)
        {
            Clear(headersItem);
            if (sortOrder == SortOrder.Ascended) sortOrder = SortOrder.Descended;
            else sortOrder = SortOrder.Ascended;
            if (!isATAChapterShowen)
            {
                listExtendableItem.Sort(new DetailsColumnComparers(sortOrder).ReturnComparer(e.ColumnName));
                DisplayDetailList(listExtendableItem, detailArray.Length);
            }
            else
            {
                if (e.ColumnName != "ATA")
                {
                    for (int i = 0; i < listGroupItem.Count; i++)
                    {
                        listGroupItem[i].ItemList.Sort(new DetailsColumnComparers(sortOrder).ReturnComparer(e.ColumnName));
                      
                    }
                    DisplayGroupDetailList(listGroupItem);
                }
                else
                {
                    listGroupItem.Sort(new DetailsColumnComparers(sortOrder).ReturnATAGroupComparer());
                    DisplayGroupDetailList(listGroupItem);
                }
               
            }
        }

        #endregion

        #region protected override void OnSizeChanged(EventArgs e)

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            AdjustSize();
        }
        #endregion

        
        #endregion
    }
}
