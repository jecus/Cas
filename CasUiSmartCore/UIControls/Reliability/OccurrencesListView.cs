using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.AircraftTechnicalLogBookControls;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Entities.General.Atlbs;

namespace CAS.UI.UIControls.Reliability
{
	///<summary>
	/// список для отображения ордеров запроса
	///</summary>
	public partial class OccurrencesListView : BaseGridViewControl<Discrepancy>
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

			SortDirection = SortDirection.Desc;
			OldColumnIndex = 11;
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
			AddColumn("Reliability", 40);
			AddColumn("Aircraft", 120);
			AddColumn("Model", 140);
			AddColumn("ATLB №", 80);
			AddColumn("Block №", 80);
			AddColumn("Status", 80);
			AddColumn("Page №", 80);
			AddColumn("WO", 80);
			AddColumn("ATA", 120);
			AddColumn("Description", 160);
			AddColumn("Corr. Action", 160);
			AddColumn("Flight Date", 160);
			AddColumn("Route", 160);
			AddColumn("Phase", 160);
			AddColumn("Deffect Confirm", 190);
			AddColumn("Deffect CAT", 190);
			AddColumn("Action Type", 190);
			AddColumn("Fault Consequence", 190);
			AddColumn("OPS Consequence", 190);
			AddColumn("Engine Shut Up", 120);
			AddColumn("Consequence Type", 190);
			AddColumn("Occurrence Type", 190);
			AddColumn("Interruption Type", 190);
			AddColumn("Time Delay", 100);
			AddColumn("Substitution", 100);
			AddColumn("MEL", 120);
			AddColumn("Event Type", 120);
			AddColumn("Event Class", 120);
			AddColumn("Event Category", 80);
			AddColumn("Risk Index", 80);
			AddColumn("Filled By", 80);
			AddColumn("Station", 80);
			AddColumn("MRO", 80);
			AddColumn("SRC Record Date", 160);
			AddColumn("Auth. B1", 120);
			AddColumn("Auth. B2", 120);
			AddColumn("Comp. Off P/N", 160);
			AddColumn("Comp. Off S/N", 160);
			AddColumn("Comp. On P/N", 160);
			AddColumn("Comp. On S/N", 160);
			AddColumn("Messages", 120);
			AddColumn("Sent by", 120);
			AddColumn("FDR", 120);
			AddColumn("Remarks", 120);
			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}
		#endregion

		#region protected override SetGroupsToItems(int columnIndex)

	 //   protected override void SetGroupsToItems(int columnIndex)
	 //   {
		//    itemsListView.Groups.Clear();
		//	foreach (var item in ListViewItemList)
		//	{
		//		if (item.Tag is Discrepancy)
		//		{
		//			var discrepancy = item.Tag as Discrepancy;
		//			var temp = $"{discrepancy.Status}";
		//			itemsListView.Groups.Add(temp, temp);
		//			item.Group = itemsListView.Groups[temp];
		//		}
		//	}
		//}

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

		#region protected override List<CustomCell> GetListViewSubItems(Discrepancy item)

		protected override List<CustomCell> GetListViewSubItems(Discrepancy item)
		{
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);

			return new List<CustomCell>
			{
				CreateRow(item.IsReliability ? "R" : "N", item.IsReliability ),
				CreateRow(item.Aircraft.ToString(), item.Aircraft ),
				CreateRow(item.Model.ShortName, item.Model ),
				CreateRow(item.ParentFlight?.ParentATLB?.ATLBNo, item.ParentFlight?.ParentATLB?.ATLBNo ),
				CreateRow(item.Num.ToString(), item.Num ),
				CreateRow(item.Status.ToString(), item.Status ),
				CreateRow(item.ParentFlight?.PageNo, item.ParentFlight?.PageNo ),
				CreateRow("", "" ),
				CreateRow(item.ATAChapter != null ? item.ATAChapter.ToString() : "", item.ATAChapter != null ? item.ATAChapter.ToString() : "" ),
				CreateRow(item.Description, item.Description ),
				CreateRow(item.CorrectiveActionDescription, item.CorrectiveActionDescription ),
				CreateRow(item.ParentFlightDate.Value.ToString(new GlobalTermsProvider()["DateFormat"].ToString()), item.ParentFlightDate ),
				CreateRow(item.ParentFlightRoute, item.ParentFlightRoute ),
				CreateRow(item.DeffeсtPhase.ToString(), item.DeffeсtPhase ),
				CreateRow(item.DeffectConfirm.ToString(), item.DeffectConfirm ),
				CreateRow(item.DeffeсtCategory.ToString(), item.DeffeсtCategory ),
				CreateRow(item.ActionType.ToString(), item.ActionType ),
				CreateRow(item.ConsequenceFault.ToString(), item.ConsequenceFault ),
				CreateRow(item.ConsequenceOps.ToString(), item.ConsequenceOps ),
				CreateRow(item.EngineShutUp ? GlobalObjects.ComponentCore.GetBaseComponentById(item.BaseComponentId).ToString() : "N/A", item.EngineShutUp ),
				CreateRow(item.ConsequenceType.ToString(), item.ConsequenceType ),
				CreateRow(item.Occurrence.ToString(), item.Occurrence ),
				CreateRow(item.InterruptionType.ToString(),  item.InterruptionType ),
				CreateRow(item.TimeDelay.ToString(), item.TimeDelay ),
				CreateRow(item.Substruction ? "Yes" : "No", item.Substruction ),
				CreateRow(item.DeferredCategory, item.DeferredCategory ),
				CreateRow(item.EventType, item.EventType ),
				CreateRow(item.EventClass, item.EventClass ),
				CreateRow(item.EventCategory, item.EventCategory ),
				CreateRow(item.RiskIndex, item.RiskIndex ),
				CreateRow(item.FilledByString, item.FilledByString ),
				CreateRow(item.ParentFlight.StationToId.ShortName, item.ParentFlight.StationToId ),
				CreateRow(item.CertificateOfReleaseToService.Station, item.CertificateOfReleaseToService.Station ),
				CreateRow(item.CertificateOfReleaseToServiceRecordDate.ToString(), item.CertificateOfReleaseToServiceRecordDate ),
				CreateRow(item.CertificateOfReleaseToServiceAuthorizationB1 != null
					? item.CertificateOfReleaseToServiceAuthorizationB1.ToString() : "",
				item.CertificateOfReleaseToServiceAuthorizationB1),
				CreateRow(item.CertificateOfReleaseToServiceAuthorizationB2 != null
					? item.CertificateOfReleaseToServiceAuthorizationB2.ToString() : "",
				item.CertificateOfReleaseToServiceAuthorizationB2),
				CreateRow(item.CorrectiveAction.PartNumberOff, item.CorrectiveAction.PartNumberOff ),
				CreateRow(item.CorrectiveAction.SerialNumberOff, item.CorrectiveAction.SerialNumberOff ),
				CreateRow(item.CorrectiveAction.PartNumberOn, item.CorrectiveAction.PartNumberOn ),
				CreateRow(item.CorrectiveAction.SerialNumberOn, item.CorrectiveAction.SerialNumberOn ),
				CreateRow(item.Messages, item.Messages ),
				CreateRow(item.Auth.ToString(), item.Auth ),
				CreateRow(item.FDR, item.FDR ),
				CreateRow(item.Remark, item.Remark ),
				CreateRow(author, author )
			};
		}

		#endregion

		#endregion
	}
}
