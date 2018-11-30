using System;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Store;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls
{
    ///<summary>
    /// список для отображения ордеров запроса
    ///</summary>
    public partial class InitialOrderListView : BaseListViewControl<InitialOrder>
    {
        #region public InitialOrderListView()
        ///<summary>
        ///</summary>
        public InitialOrderListView()
        {
            InitializeComponent();
        }
		#endregion

		#region Methods

		#region protected override SetGroupsToItems(int columnIndex)
		protected override void SetGroupsToItems(int columnIndex)
        {
            itemsListView.Groups.Clear();
            itemsListView.Groups.Add("GroupOpened", "Opened");
            itemsListView.Groups.Add("GroupPublished", "Published");
            itemsListView.Groups.Add("GroupClosed", "Closed");
            itemsListView.Groups.Add("GroupUnknown", "Unknown");

            foreach (ListViewItem item in ListViewItemList)
            {
                if (((InitialOrder)item.Tag).Status == WorkPackageStatus.Closed)
                {
                    item.Group = itemsListView.Groups[2];
                }
                else if (((InitialOrder)item.Tag).Status == WorkPackageStatus.Published)
                {
                    item.Group = itemsListView.Groups[1];
                }
                else if (((InitialOrder)item.Tag).Status == WorkPackageStatus.Opened)
                {
                    item.Group = itemsListView.Groups[0];
                }
                else
                {
                    item.Group = itemsListView.Groups[3];
                }
            }   
        }
        #endregion

        #region protected override ListViewItem.ListViewSubItem[] GetItemsString(InitialOrder item)

        protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(InitialOrder item)
        {
            ListViewItem.ListViewSubItem[] subItems = new ListViewItem.ListViewSubItem[7];
            subItems[0] = new ListViewItem.ListViewSubItem {Text = item.Title, Tag = item.Title};
            subItems[1] = new ListViewItem.ListViewSubItem {Text = item.Description, Tag = item.Description};
            subItems[2] = new ListViewItem.ListViewSubItem
                              {
                                  Text = item.OpeningDate == (new DateTime(1852, 01, 01))
                                             ? ""
                                             : SmartCore.Auxiliary.Convert.GetDateFormat(item.OpeningDate),
                                  Tag = item.OpeningDate
                              };

            subItems[3] = new ListViewItem.ListViewSubItem
                              {
                                  Text = item.Status != WorkPackageStatus.Opened
                                             ? item.PublishingDate == (new DateTime(1852, 01, 01))
                                                   ? ""
                                                   : SmartCore.Auxiliary.Convert.GetDateFormat(item.PublishingDate)
                                             : "",
                                  Tag = item.PublishingDate
                              };

            subItems[4] = new ListViewItem.ListViewSubItem
                              {
                                  Text = item.Status == WorkPackageStatus.Closed
                                             ? item.ClosingDate == (new DateTime(1852, 01, 01))
                                                   ? ""
                                                   : SmartCore.Auxiliary.Convert.GetDateFormat(item.ClosingDate)
                                             : "",
                                  Tag = item.ClosingDate
                              };
            subItems[5] = new ListViewItem.ListViewSubItem {Text = item.Author, Tag = item.Author};
            subItems[6] = new ListViewItem.ListViewSubItem {Text = item.Remarks, Tag = item.Remarks};

            return subItems;
        }

        #endregion

        #region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
        
        protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
        {
            if (SelectedItem != null)
            {
                e.TypeOfReflection = ReflectionTypes.DisplayInCurrent;
                e.DisplayerText = SelectedItem.Title;
                e.RequestedEntity = new InitionalOrderScreen(SelectedItem);
            }
        }
        
        #endregion
        
        #endregion
    }
}
