using System;
using System.Collections.Generic;
using Controls.ExtendableList;
using LTR.UI.UIControls.Auxiliary;

namespace LTR.UI.UIControls.DetailsControls
{
    /// <summary>
    /// Компараторы для сортировки списка деталей
    /// </summary>
    public class DetailsColumnComparers
    {
        #region Constructors

        #region public DetailsColumnComparers(SortOrder sortOrder)
        /// <summary>
        /// Создается компаратор 
        /// </summary>
        /// <param name="orderOfSort">Порядок сортировки</param>
        public DetailsColumnComparers(SortOrder orderOfSort)
        {
            sortOrder = orderOfSort;
        }
        #endregion


        #endregion

        #region Methods

        #region public IComparer<DetailItem> ReturnComparer(string columnName)
        /// <summary>
        /// Метод возврашает Comparer по название колонки
        /// </summary>
        /// <param name="columnName">Название колонки</param>
        /// <returns></returns>
        public IComparer<IExtendableItem> ReturnComparer(string columnName)
        {
            switch (columnName)
            {
                case "#":
                    return new NumberComparer();
                case "ATA":
                    return new ATAChapterComparer();
                case "Part No.":
                    return new PartNumberComparer();
                case "Description":
                    return new DescriptionComparer();
                case "Maint.\nType.":
                    return new MaintenceTypeComparer();
                case "Serial No.":
                    return new SerialNumberComparer();
            }
            throw new Exception("Сolumn dose not exist");
        }
        #endregion

        #region public IComparer<DetailATAChapterGroupItem> ReturnATAGroupComparer()
        /// <summary>
        /// Метод возврашает Comparer для групп
        /// </summary>
        /// <returns>Сomparer</returns>
        public IComparer<DetailATAChapterGroupItem> ReturnATAGroupComparer()
        {
            return new ATAGroupComparer();
        }
        #endregion

        #region private static void ChangeSortOrder(ref IExtendableItem x,ref IExtendableItem y)
        private static void ChangeSortOrder(ref IExtendableItem x,ref IExtendableItem y)
        {
            IExtendableItem tempIExtendableItem = x;
            x = y;
            y = tempIExtendableItem;
        }
        #endregion

        #region private static void ChangeGroupSortOrder(ref DetailATAChapterGroupItem x,ref DetailATAChapterGroupItem y)
        private static void ChangeGroupSortOrder(ref DetailATAChapterGroupItem x,ref DetailATAChapterGroupItem y)
        {
            DetailATAChapterGroupItem tempDetailATAChapterGroupItem = x;
            x = y;
            y = tempDetailATAChapterGroupItem;
            
        }
        #endregion

        #endregion

        #region Fields
        private static SortOrder sortOrder;
        #endregion

        #region private class ATAGroupComparer:IComparer<DetailATAChapterGroupItem>
        private class ATAGroupComparer:IComparer<DetailATAChapterGroupItem>
        {
            public int Compare(DetailATAChapterGroupItem x, DetailATAChapterGroupItem y)
            {
                if (sortOrder == SortOrder.Descended) ChangeGroupSortOrder(ref x, ref y);
                return string.Compare(x.ATAChapterText, y.ATAChapterText);
            }
        }
        #endregion

        #region private class  NumberComparer:IComparer<IExtendableItem>

        private class  NumberComparer:IComparer<IExtendableItem>
        {
            public int Compare(IExtendableItem x, IExtendableItem y)
            {
                if (sortOrder == SortOrder.Descended) ChangeSortOrder(ref x, ref y);
                int intX = 0;
                int intY = 0;
                if (x != null)
                {
                    intX = Convert.ToInt32(((DetailItem)x).NumberText) ;
                }
                if (y != null)
                {
                    intY = Convert.ToInt32(((DetailItem)y).NumberText);
                }
                if (intX > intY) return 1;
                if (intX < intY) return -1;
                return 0;
            }

      
        }

        #endregion

        #region private class ATAChapterComparer:IComparer<IExtendableItem>

        private class ATAChapterComparer : IComparer<IExtendableItem>
        {
            public int Compare(IExtendableItem x, IExtendableItem y)
            {
                if (sortOrder == SortOrder.Descended) ChangeSortOrder(ref x, ref y);
                return string.Compare(((DetailItem)x).ATAChapterText,((DetailItem)y).ATAChapterText);
            }
        }

        #endregion

        #region private class PartNumberComparer:IComparer<IExtendableItem>

        private class PartNumberComparer : IComparer<IExtendableItem>
        {
            public int Compare(IExtendableItem x, IExtendableItem y)
            {
                if (sortOrder == SortOrder.Descended) ChangeSortOrder(ref x, ref y);
                return string.Compare(((DetailItem)x).PartNumberText, ((DetailItem)y).PartNumberText);
            }
        }

        #endregion

        #region private class DescriptionComparer:IComparer<IExtendableItem>

        private class DescriptionComparer : IComparer<IExtendableItem>
        {
            public int Compare(IExtendableItem x, IExtendableItem y)
            {
                if (sortOrder == SortOrder.Descended) ChangeSortOrder(ref x, ref y);
                return string.Compare(((DetailItem)x).DescriptionText, ((DetailItem)y).DescriptionText);
            }
        }

        #endregion

        #region private class MaintenceTypeComparer:IComparer<DetailItem>

        private class MaintenceTypeComparer : IComparer<IExtendableItem>
        {
            public int Compare(IExtendableItem x, IExtendableItem y)
            {
                if (sortOrder == SortOrder.Descended) ChangeSortOrder(ref x, ref y);
                return string.Compare(((DetailItem)x).MaintenceTypeText, ((DetailItem)y).MaintenceTypeText);
            }
        }

        #endregion

        #region private class SerialNumberComparer:IComparer<IExtendableItem>

        private class SerialNumberComparer : IComparer<IExtendableItem>
        {
            public int Compare(IExtendableItem x, IExtendableItem y)
            {
                if (sortOrder == SortOrder.Descended) ChangeSortOrder(ref x, ref y);
                return string.Compare(((DetailItem)x).SerialNumber, ((DetailItem)y).SerialNumber);
            }
        }

        #endregion
    }
}
