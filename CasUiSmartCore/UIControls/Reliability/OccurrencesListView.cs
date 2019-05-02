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
    public partial class OccurrencesListView : BaseListViewControl<Discrepancy>
    {
		#region Fields

		#endregion

		#region Constructors

		#region public OccurrencesListView()
		///<summary>
		///</summary>
		public OccurrencesListView()
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

	        columnHeader = new ColumnHeader { Width = 120, Text = "Aircraft" };
	        ColumnHeaderList.Add(columnHeader);

	        columnHeader = new ColumnHeader { Width = 140, Text = "Model" };
	        ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = 80, Text = "ATLB №" };
	        ColumnHeaderList.Add(columnHeader);

	        columnHeader = new ColumnHeader { Width = 80, Text = "Block №" };
	        ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = 80, Text = "Status" };
	        ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = 80, Text = "Page №" };
	        ColumnHeaderList.Add(columnHeader);

	        columnHeader = new ColumnHeader { Width = 80, Text = "WO" };
	        ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader {Width = 120, Text = "ATA"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 160, Text = "Description"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 160, Text = "Corr. Action"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 160, Text = "Flight Date"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 160, Text = "Route"};
            ColumnHeaderList.Add(columnHeader);

	        columnHeader = new ColumnHeader { Width = 160, Text = "Phase" };
	        ColumnHeaderList.Add(columnHeader);

	        columnHeader = new ColumnHeader { Width = 190, Text = "Deffect Confirm" };
	        ColumnHeaderList.Add(columnHeader);

	        columnHeader = new ColumnHeader { Width = 190, Text = "Deffect CAT" };
	        ColumnHeaderList.Add(columnHeader);

	        columnHeader = new ColumnHeader { Width = 190, Text = "Action Type" };
	        ColumnHeaderList.Add(columnHeader);
			
	        columnHeader = new ColumnHeader { Width = 190, Text = "Fault Consequence" };
	        ColumnHeaderList.Add(columnHeader);

	        columnHeader = new ColumnHeader { Width = 190, Text = "OPS Consequence" };
	        ColumnHeaderList.Add(columnHeader);

	        columnHeader = new ColumnHeader { Width = 120, Text = "Engine Shut Up" };
	        ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = 190, Text = "Consequence Type" };
	        ColumnHeaderList.Add(columnHeader);

	        columnHeader = new ColumnHeader { Width = 190, Text = "Occurrence Type" };
	        ColumnHeaderList.Add(columnHeader);

	        columnHeader = new ColumnHeader { Width = 190, Text = "Interruption Type" };
	        ColumnHeaderList.Add(columnHeader);

	        columnHeader = new ColumnHeader { Width = 100, Text = "Time Delay" };
	        ColumnHeaderList.Add(columnHeader);

	        columnHeader = new ColumnHeader { Width = 100, Text = "Substitution" };
	        ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 120, Text = "MEL"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 120, Text = "Event Type"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 120, Text = "Event Class"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 80, Text = "Event Category"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = 80, Text = "Risk Index"};
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

            columnHeader = new ColumnHeader { Width = 160, Text = "Comp. On P/N" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = 160, Text = "Comp. On S/N" };
            ColumnHeaderList.Add(columnHeader);

	        columnHeader = new ColumnHeader { Width = 120, Text = "Messages" };
	        ColumnHeaderList.Add(columnHeader);
	        columnHeader = new ColumnHeader { Width = 120, Text = "Sent by" };
	        ColumnHeaderList.Add(columnHeader);
	        columnHeader = new ColumnHeader { Width = 120, Text = "FDR" };
	        ColumnHeaderList.Add(columnHeader);


			columnHeader = new ColumnHeader {Width = 120, Text = "Remarks"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Signer" };
            ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
        }
		#endregion

		#region protected override SetGroupsToItems(int columnIndex)

	    protected override void SetGroupsToItems(int columnIndex)
	    {
		    itemsListView.Groups.Clear();
			foreach (var item in ListViewItemList)
			{
				if (item.Tag is Discrepancy)
				{
					var discrepancy = item.Tag as Discrepancy;
					var temp = $"{discrepancy.Status}";
					itemsListView.Groups.Add(temp, temp);
					item.Group = itemsListView.Groups[temp];
				}
			}
		}

	    #endregion

        #region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

        protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
        {
	        if (SelectedItem == null) return;

	        var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(SelectedItem.ParentFlight.AircraftId);

	        e.TypeOfReflection = ReflectionTypes.DisplayInNew;
	        e.RequestedEntity = new FlightScreen(SelectedItem.ParentFlight, true);
	        e.DisplayerText = aircraft.RegistrationNumber + ". " + SelectedItem;
		}
        #endregion

        #region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Discrepancy item)

        protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Discrepancy item)
        {
            var subItems = new List<ListViewItem.ListViewSubItem>();
            var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);


			subItems.Add(new ListViewItem.ListViewSubItem { Text = item.IsReliability ? "R" : "N", Tag = item.IsReliability });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Aircraft.ToString(), Tag = item.Aircraft });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Model.ShortName, Tag = item.Model });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = item.ParentFlight?.ParentATLB?.ATLBNo, Tag = item.ParentFlight?.ParentATLB?.ATLBNo });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Num.ToString(), Tag = item.Num });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Status.ToString(), Tag = item.Status });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = item.ParentFlight?.PageNo, Tag = item.ParentFlight?.PageNo });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = item.ATAChapter != null ? item.ATAChapter.ToString() : "", Tag = item.ATAChapter != null ? item.ATAChapter.ToString() : "" });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Description, Tag = item.Description });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.CorrectiveActionDescription, Tag = item.CorrectiveActionDescription });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.ParentFlightDate.Value.ToString(new GlobalTermsProvider()["DateFormat"].ToString()), Tag = item.ParentFlightDate });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.ParentFlightRoute, Tag = item.ParentFlightRoute });

            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.DeffeсtPhase.ToString(), Tag = item.DeffeсtPhase });
	        subItems.Add(new ListViewItem.ListViewSubItem { Text = item.DeffectConfirm.ToString(), Tag = item.DeffectConfirm });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = item.DeffeсtCategory.ToString(), Tag = item.DeffeсtCategory });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.ActionType.ToString(), Tag = item.ActionType });

	        subItems.Add(new ListViewItem.ListViewSubItem { Text = item.ConsequenceFault.ToString(), Tag = item.ConsequenceFault });
	        subItems.Add(new ListViewItem.ListViewSubItem { Text = item.ConsequenceOps.ToString(), Tag = item.ConsequenceOps });
	        subItems.Add(new ListViewItem.ListViewSubItem { Text = item.EngineShutUp ? GlobalObjects.ComponentCore.GetBaseComponentById(item.BaseComponentId).ToString() : "N/A", Tag = item.EngineShutUp });
	        subItems.Add(new ListViewItem.ListViewSubItem { Text = item.ConsequenceType.ToString(), Tag = item.ConsequenceType });
	        subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Occurrence.ToString(), Tag = item.Occurrence });
	        subItems.Add(new ListViewItem.ListViewSubItem { Text = item.InterruptionType.ToString(), Tag = item.InterruptionType });
	        subItems.Add(new ListViewItem.ListViewSubItem { Text = item.TimeDelay.ToString(), Tag = item.TimeDelay });
	        subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Substruction ? "Yes" : "No", Tag = item.Substruction });

			subItems.Add(new ListViewItem.ListViewSubItem { Text = item.DeferredCategory, Tag = item.DeferredCategory });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.EventType, Tag = item.EventType });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.EventClass, Tag = item.EventClass });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.EventCategory, Tag = item.EventCategory });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.RiskIndex, Tag = item.RiskIndex });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.FilledByString, Tag = item.FilledByString });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.ParentFlight.StationToId.ShortName, Tag = item.ParentFlight.StationToId });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.CertificateOfReleaseToService.Station, Tag = item.CertificateOfReleaseToService.Station });
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
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.CorrectiveAction.PartNumberOn, Tag = item.CorrectiveAction.PartNumberOn });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.CorrectiveAction.SerialNumberOn, Tag = item.CorrectiveAction.SerialNumberOn });

            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Messages, Tag = item.Messages });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Auth.ToString(), Tag = item.Auth });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.FDR, Tag = item.FDR });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Remark, Tag = item.Remark });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = author, Tag = author });

			return subItems.ToArray();
        }

        #endregion

        #endregion
    }
}
