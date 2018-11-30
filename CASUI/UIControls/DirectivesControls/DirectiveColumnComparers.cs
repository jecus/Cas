using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using CAS.UI.UIControls.DirectivesControls;

namespace CAS.UI.UIControls.DetailsControls
{
    ///<summary>
    ///</summary>
    public class DirectiveColumnComparers
    {
        #region Methods

        /// <summary>
        /// Метод возврашает Comparer по название колонки
        /// </summary>
        /// <param name="columnName">Название колонки</param>
        /// <returns></returns>
        public IComparer<DirectiveItem> ReturnComparer(string columnName)
        {
            switch(columnName)
            {
                case "#":
                    return new NumberComparer();
                case "Title":
                    return new TitleComparer();
                case "Status":
                    return new StatusComparer();
            }
            throw new Exception("Сolumn dose not exist");
        }

        #endregion
       
        #region private  NumberComparer:IComparer

        private class NumberComparer : IComparer<DirectiveItem>
        {
            public int Compare(DirectiveItem x, DirectiveItem y)
            {
                int intX = 0;
                int intY = 0;
                if (x != null)
                {
                    intX = Convert.ToInt32(x.NumberText) ;
                }
                if (y != null)
                {
                    intY = Convert.ToInt32(y.NumberText);
                }
                if (intX > intY) return 1;
                if (intX < intY) return -1;
                return 0;
            }

      
        }

        #endregion

        #region private class TitleComparer:IComparer

        private class TitleComparer : IComparer<DirectiveItem>
        {
            public int Compare(DirectiveItem x, DirectiveItem y)
            {
                return string.Compare(x.Title, y.Title);
            }
        }

        #endregion

        #region private class StatusComparer:IComparer

        private class StatusComparer : IComparer<DirectiveItem>
        {
            public int Compare(DirectiveItem x, DirectiveItem y)
            {
                return string.Compare(x.Status, y.Status);
            }
        }

        #endregion

    }
}
