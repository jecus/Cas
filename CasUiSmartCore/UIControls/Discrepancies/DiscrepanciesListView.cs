using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.AircraftTechnicalLogBookControls;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Entities.General.Atlbs;

namespace CAS.UI.UIControls.Discrepancies
{
    ///<summary>
    /// список для отображения ордеров запроса
    ///</summary>
    public partial class DiscrepanciesListView : BaseListViewControl<Discrepancy>
    {
        #region Fields

        #endregion

        #region Constructors

        #region public DiscrepanciesListView()
        ///<summary>
        ///</summary>
        public DiscrepanciesListView()
        {
            InitializeComponent();
        }
        #endregion

        #endregion

        #region Methods

        #region protected override List<PropertyInfo> GetTypeProperties()
        protected override List<PropertyInfo> GetTypeProperties()
        {
            List<PropertyInfo> props = base.GetTypeProperties();
            PropertyInfo prop = props.FirstOrDefault(p => p.Name.ToLower() == "aircraft");
            props.Remove(prop);

            return props;
        }
        #endregion

        #region protected override void SetHeaders()
        /// <summary>
        /// Устанавливает заголовки
        /// </summary>
        protected override void SetHeaders()
        {
            ColumnHeaderList.Clear();

	        ColumnHeader columnHeader = new ColumnHeader { Width = 40, Text = "Reliability" };
	        ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = 80, Text = "ATLB №" };
	        ColumnHeaderList.Add(columnHeader);

	        columnHeader = new ColumnHeader { Width = 80, Text = "Page №" };
	        ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader {Width = 80, Text = "ATA"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 160, Text = "Description"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 160, Text = "Corr. Action"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 160, Text = "Corr. Action Add№"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 160, Text = "Flight Date"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 160, Text = "Route"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 160, Text = "Delay"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 160, Text = "Cancellation"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 120, Text = "MEL"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 120, Text = "Damage"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = 80, Text = "Repeat" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 120, Text = "Event Type"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 120, Text = "Event Class"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 80, Text = "Event Category"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 80, Text = "Risk Index"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 80, Text = "Accident/Incident"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 120, Text = "Condition"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 80, Text = "Filled By"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 80, Text = "Station"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 80, Text = "MRO"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 160, Text = "SRC Record Date"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 120, Text = "Auth. B1"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 120, Text = "Auth. B2"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = 160, Text = "Comp. Off P/N" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = 160, Text = "Comp. Off S/N" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 160, Text = "Comp. Off Life Limit Remains"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 160, Text = "Comp. Off Overhaul Remains"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 160, Text = "Comp. Off Warranty Remains"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 80, Text = "Comp. Off POOL"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = 120, Text = "Comp. Off Manuf. Date" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = 120, Text = "Comp. Off Since Install." };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 120, Text = "Comp. Off Manufacturer"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 120, Text = "Comp. Off Supplier"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 120, Text = "Comp. Off MP"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 120, Text = "Comp. Off Avionix."};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = 160, Text = "Comp. On P/N" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = 160, Text = "Comp. On S/N" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = 160, Text = "Comp. On Life Limit Remains" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = 160, Text = "Comp. On Overhaul Remains" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = 160, Text = "Comp. On Warranty Remains" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = 80, Text = "Comp. On POOL" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = 120, Text = "Comp. On Manuf. Date" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = 120, Text = "Comp. On Since Install." };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = 120, Text = "Comp. On Manufacturer" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = 120, Text = "Comp. On Supplier" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = 120, Text = "Comp. On MP" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = 120, Text = "Comp. On Avionix." };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 80, Text = "Remarks"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Author" };
            ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
        }
		#endregion

		#region protected override SetGroupsToItems(int columnIndex)
		protected override void SetGroupsToItems(int columnIndex)
        {
            //itemsListView.Groups.Clear();
            //itemsListView.Groups.Add("GroupOpened", "Opened");
            //itemsListView.Groups.Add("GroupPublished", "Published");
            //itemsListView.Groups.Add("GroupClosed", "Closed");

            //foreach (ListViewItem item in ListViewItemList)
            //{
            //    switch (((Discrepancy)item.Tag).Status)
            //    {
            //        case WorkPackageStatus.Closed:
            //            item.Group = itemsListView.Groups[2];
            //            break;
            //        case WorkPackageStatus.Published:
            //            item.Group = itemsListView.Groups[1];
            //            break;
            //        case WorkPackageStatus.Opened:
            //            item.Group = itemsListView.Groups[0];
            //            break;
            //        default:
            //            throw new ArgumentOutOfRangeException(String.Format("1135: Takes an argument has no known type {0}", item.GetType()));
            //    }
            //}
        }
        #endregion

        #region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

        protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
        {
	        if (SelectedItem == null) return;

	        var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(SelectedItem.ParentFlight.AircraftId);

	        e.TypeOfReflection = ReflectionTypes.DisplayInNew;
	        e.RequestedEntity = new FlightScreen(SelectedItem.ParentFlight);
	        e.DisplayerText = aircraft.RegistrationNumber + ". " + SelectedItem;
		}
        #endregion

        #region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Discrepancy item)

        protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Discrepancy item)
        {
            List<ListViewItem.ListViewSubItem> subItems = new List<ListViewItem.ListViewSubItem>();

			//if(item.ItemId == 41043)
			//{

			//}

			var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);

			subItems.Add(new ListViewItem.ListViewSubItem { Text = item.IsReliability ? "R" : "N", Tag = item.IsReliability });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = item.ParentFlight.ParentATLB.ATLBNo, Tag = item.ParentFlight.ParentATLB.ATLBNo });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = item.ParentFlight.PageNo, Tag = item.ParentFlight.PageNo });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = item.ATAChapter != null ? item.ATAChapter.ToString() : "", Tag = item.ATAChapter != null ? item.ATAChapter.ToString() : "" });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Description, Tag = item.Description });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.CorrectiveActionDescription, Tag = item.CorrectiveActionDescription });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.CorrectiveActionAddNo, Tag = item.CorrectiveActionAddNo });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.ParentFlightDate.Value.ToString(new GlobalTermsProvider()["DateFormat"].ToString()), Tag = item.ParentFlightDate });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.ParentFlightRoute, Tag = item.ParentFlightRoute });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.ParentFlightDelayReason, Tag = item.ParentFlightDelayReason });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.ParentFlightCancellation, Tag = item.ParentFlightCancellation });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.DeferredCategory, Tag = item.DeferredCategory });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Damage, Tag = item.Damage });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.EventType, Tag = item.EventType });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.EventClass, Tag = item.EventClass });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.EventCategory, Tag = item.EventCategory });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.RiskIndex, Tag = item.RiskIndex });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Accident, Tag = item.Accident });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Condition, Tag = item.Condition });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.FilledByString, Tag = item.FilledByString });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.CertificateOfReleaseToServiceStation, Tag = item.CertificateOfReleaseToServiceStation });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.CertificateOfReleaseToServiceMRO, Tag = item.CertificateOfReleaseToServiceMRO });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.CertificateOfReleaseToServiceRecordDate.ToString(), Tag = item.CertificateOfReleaseToServiceRecordDate });
            subItems.Add(new ListViewItem.ListViewSubItem
            {
                Text = item.CertificateOfReleaseToServiceAuthorizationB1 != null 
                    ? item.CertificateOfReleaseToServiceAuthorizationB1.ToString() 
                    : "",
                Tag = item.CertificateOfReleaseToServiceAuthorizationB1
            });
            subItems.Add(new ListViewItem.ListViewSubItem
            {
                Text = item.CertificateOfReleaseToServiceAuthorizationB2 != null
                    ? item.CertificateOfReleaseToServiceAuthorizationB2.ToString()
                    : "",
                Tag = item.CertificateOfReleaseToServiceAuthorizationB2
            });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.CorrectiveAction.PartNumberOff, Tag = item.CorrectiveAction.PartNumberOff });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.CorrectiveAction.SerialNumberOff, Tag = item.CorrectiveAction.SerialNumberOff });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.CorrectiveAction.PartNumberOn, Tag = item.CorrectiveAction.PartNumberOn });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.CorrectiveAction.SerialNumberOn, Tag = item.CorrectiveAction.SerialNumberOn });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Remarks, Tag = item.Remarks });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = author, Tag = author });

			return subItems.ToArray();
        }

        #endregion

        #endregion
    }
}
