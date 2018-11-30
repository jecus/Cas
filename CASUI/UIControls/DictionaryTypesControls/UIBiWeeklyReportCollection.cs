using System;
using System.Windows.Forms;
using LTR.Core.Types.Dictionaries;
using LTR.UI.UIControls.Auxiliary;

namespace LTR.UI.UIControls.DictionaryTypesControls
{
    /// <summary>
    /// Класс, предназначенный для отображения коллекции Bi-Weekly отчетов
    /// </summary>
    internal partial class UIBiWeeklyReportCollection : UIDictionaryTypeCollection
    {
        #region Constructors

        internal UIBiWeeklyReportCollection()
        {
            TitleText = "Bi-Weekly Reports";   
            ListViewHeaders.Add(new ListViewHeader(COLUMN_RECIEVED_DATE_TEXT, COLUMN_RECIEVED_DATE_WIDTH));
            ListViewHeaders.Add(new ListViewHeader(COLUMN_REAL_NAME_TEXT, COLUMN_REAL_NAME_WIDTH));
            ListViewControl.ColumnClick += ListViewControl_ColumnClick;
            Initialize();
        }


        #endregion

        #region Field

        private const int COLUMN_RECIEVED_DATE_WIDTH = 200;
        private const int COLUMN_REAL_NAME_WIDTH = 200;
        private const string COLUMN_RECIEVED_DATE_TEXT = "Recieved Date";
        private const string COLUMN_REAL_NAME_TEXT = "Real Name";
        
        #endregion

        #region Methods

        #region protected override void Initialize()

        /// <summary>
        /// Производит инициализацию элемента управления для дальнейшей работы с пользователем
        /// </summary>
        protected override void Initialize()
        {
            Collection = BiWeekliesCollection.Instance;
            base.Initialize();
        }

        #endregion
        
        #region public override void FillUIElementsFromCollection()

        /// <summary>
        /// Осуществляет заполнение данных элемента управления ListView
        /// </summary>
        public override void FillUIElementsFromCollection()
        {
            BiWeekliesCollection tempBiWeeklyCollection = Collection as BiWeekliesCollection;
            if (tempBiWeeklyCollection==null) return;
            ListViewControl.Items.Clear();
            for (int i=0;i<tempBiWeeklyCollection.Count;i++)
            {
                string tempID = Convert.ToString(tempBiWeeklyCollection[i].ID);
                string tempShortName = tempBiWeeklyCollection[i].ShortName;
                string tempFullName = tempBiWeeklyCollection[i].FullName;
                string tempRecievedDate = tempBiWeeklyCollection[i].RecievedDate.ToString();
                string tempRealName = tempBiWeeklyCollection[i].RealName;
                AddItemToListViewControl(tempID,tempShortName,tempFullName,tempRecievedDate,tempRealName);
            }
        }

        #endregion

        #region protected void AddItemToListViewControl(string id,string shortName,string fullName,string recievedDate, string realName)

        /// <summary>
        /// Метод, предназначенный для добавления новой строки в элемент управления ListView
        /// </summary>
        protected void AddItemToListViewControl(string id, string shortName, string fullName, string recievedDate, string realName)
        {
            ListViewControl.Items.Add(id).SubItems.AddRange(new string[] { shortName, fullName, recievedDate, realName });
        }

        #endregion

        #region void ListViewControl_ColumnClick(object sender, ColumnClickEventArgs e)

        void ListViewControl_ColumnClick(object sender, ColumnClickEventArgs e)
        {

            //ListViewControl.ListViewItemSorter = new TypeComparers.IntComparer();
            //ListViewControl.Sorting = SortOrder.Ascending;
            //ListViewControl.Sort();
        }

        #endregion
        
        #endregion

    }
}