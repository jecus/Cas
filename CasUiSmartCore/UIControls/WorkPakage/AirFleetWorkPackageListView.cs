using System;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.WorkPackage;

namespace CAS.UI.UIControls.WorkPakage
{
    ///<summary>
    /// список для отображения ордеров запроса
    ///</summary>
    public partial class AirFleetWorkPackageListView : BaseListViewControl<WorkPackage>
    {
        #region Fields

        #endregion

        #region Constructors

        #region public AirFleetWorkPackageListView()
        ///<summary>
        ///</summary>
        public AirFleetWorkPackageListView()
        {
            InitializeComponent();
        }
		#endregion

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
                switch (((WorkPackage)item.Tag).Status)
                {
                    case WorkPackageStatus.Closed:
                        item.Group = itemsListView.Groups[2];
                        break;
                    case WorkPackageStatus.Published:
                        item.Group = itemsListView.Groups[1];
                        break;
                    case WorkPackageStatus.Opened:
                        item.Group = itemsListView.Groups[0];
                        break;
                    default:
                        item.Group = itemsListView.Groups[3];
                        break;
                }
            }
        }
        #endregion

        #region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

        protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
        {
            if (SelectedItem != null)
            {
                WorkPackage item = SelectedItem;
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                e.DisplayerText = item.Aircraft != null ? item.Aircraft.RegistrationNumber + "." + item.Title : item.Title;
                e.RequestedEntity = new WorkPackageScreen(item);
            }
        }
        #endregion

        #endregion
    }
}
