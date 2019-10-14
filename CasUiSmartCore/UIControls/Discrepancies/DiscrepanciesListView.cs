using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.AircraftTechnicalLogBookControls;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Entities.General.Atlbs;

namespace CAS.UI.UIControls.Discrepancies
{
	///<summary>
	/// список для отображения ордеров запроса
	///</summary>
	public partial class DiscrepanciesListView : BaseGridViewControl<Discrepancy>
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
			SortMultiplier = 1;
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
			AddColumn("Status", 40);
			AddColumn("Reliability", 40);
			AddColumn("ATLB №", 140);
			AddColumn("Page №", 80);
			AddColumn("ATA", 80);
			AddColumn("Description", 160);
			AddColumn("Corr. Action", 160);
			AddColumn("Corr. Action Add№", 160);
			AddDateColumn("Flight Date", 160);
			AddColumn("Route", 160);
			AddColumn("Delay", 160);
			AddColumn("Cancellation", 160);
			AddColumn("MEL", 120);
			AddColumn("Damage", 120);
			AddColumn("Repeat", 80);
			AddColumn("Event Type", 120);
			AddColumn("Event Class", 120);
			AddColumn("Event Category", 80);
			AddColumn("Risk Index", 80);
			AddColumn("Accident/Incident", 80);
			AddColumn("Condition", 120);
			AddColumn("Filled By", 80);
			AddColumn("Station", 80);
			AddColumn("MRO", 80);
			AddDateColumn("SRC Record Date", 160);
			AddColumn("Auth. B1", 120);
			AddColumn("Auth. B2", 120);
			AddColumn("Comp. Off P/N", 160);
			AddColumn("Comp. Off S/N", 160);
			AddColumn("Comp. Off Life Limit Remains", 160);
			AddColumn("Comp. Off Overhaul Remains", 160);
			AddColumn("Comp. Off Warranty Remains", 160);
			AddColumn("Comp. Off POOL", 80);
			AddColumn("Comp. Off Manuf. Date", 120);
			AddColumn("Comp. Off Since Install.", 120);
			AddColumn("Comp. Off Manufacturer", 120);
			AddColumn("Comp. Off Supplier", 120);
			AddColumn("Comp.Off MP", 120);
			AddColumn("Comp. Off Avionix.", 120);
			AddColumn("Comp. On P/N", 160);
			AddColumn("Comp. On S/N", 160);
			AddColumn("Comp. On Life Limit Remains", 160);
			AddColumn("Comp. On Overhaul Remains", 160);
			AddColumn("Comp. On Warranty Remains", 160);
			AddColumn("Comp. On POOL", 80);
			AddColumn("Comp. On Manuf. Date", 120);
			AddColumn("Comp. On Since Install.", 120);
			AddColumn("Comp. On Manufacturer", 120);
			AddColumn("Comp. On Supplier", 120);
			AddColumn("Comp. On MP", 120);
			AddColumn("Comp. On Avionix.", 120);
			AddColumn("Remarks", 80);
			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}
		#endregion
		#region protected override SetGroupsToItems(int columnIndex)
		protected override void GroupingItems()
		{
			Grouping("Status");
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

		#region  protected override List<CustomCell> GetListViewSubItems(Discrepancy item)

		protected override List<CustomCell> GetListViewSubItems(Discrepancy item)
		{
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);

			return new List<CustomCell>
			{
				CreateRow(item.Status.ToString(), item.Status),
				CreateRow(item.IsReliability ? "R" : "N", item.IsReliability),
				CreateRow(item.ParentFlight.ParentATLB.ATLBNo, item.ParentFlight.ParentATLB.ATLBNo),
				CreateRow(item.ParentFlight.PageNo, item.ParentFlight.PageNo),
				CreateRow(item.ATAChapter != null ? item.ATAChapter.ToString() : "",
					item.ATAChapter != null ? item.ATAChapter.ToString() : ""),
				CreateRow(item.Description, item.Description),
				CreateRow(item.CorrectiveActionDescription, item.CorrectiveActionDescription),
				CreateRow(item.CorrectiveActionAddNo, item.CorrectiveActionAddNo),
				CreateRow(item.ParentFlightDate.Value.ToString(new GlobalTermsProvider()["DateFormat"].ToString()),
					item.ParentFlightDate),
				CreateRow(item.ParentFlightRoute, item.ParentFlightRoute),
				CreateRow(item.ParentFlightDelayReason, item.ParentFlightDelayReason),
				CreateRow(item.ParentFlightCancellation, item.ParentFlightCancellation),
				CreateRow(item.DeferredCategory, item.DeferredCategory),
				CreateRow(item.Damage, item.Damage),
				CreateRow("", ""),
				CreateRow(item.EventType, item.EventType),
				CreateRow(item.EventClass, item.EventClass),
				CreateRow(item.EventCategory, item.EventCategory),
				CreateRow(item.RiskIndex, item.RiskIndex),
				CreateRow(item.Accident, item.Accident),
				CreateRow(item.Condition, item.Condition),
				CreateRow(item.FilledByString, item.FilledByString),
				CreateRow(item.CertificateOfReleaseToServiceStation, item.CertificateOfReleaseToServiceStation),
				CreateRow(item.CertificateOfReleaseToServiceMRO, item.CertificateOfReleaseToServiceMRO),
				CreateRow(item.CertificateOfReleaseToServiceRecordDate.ToString(),
					item.CertificateOfReleaseToServiceRecordDate),
				CreateRow(
					item.CertificateOfReleaseToServiceAuthorizationB1 != null
						? item.CertificateOfReleaseToServiceAuthorizationB1.ToString()
						: "",
					item.CertificateOfReleaseToServiceAuthorizationB1),
				CreateRow(
					item.CertificateOfReleaseToServiceAuthorizationB2 != null
						? item.CertificateOfReleaseToServiceAuthorizationB2.ToString()
						: "",
					item.CertificateOfReleaseToServiceAuthorizationB2),
				CreateRow(item.CorrectiveAction.PartNumberOff, item.CorrectiveAction.PartNumberOff),
				CreateRow(item.CorrectiveAction.SerialNumberOff, item.CorrectiveAction.SerialNumberOff),
				CreateRow("", ""),
				CreateRow("", ""),
				CreateRow("", ""),
				CreateRow("", ""),
				CreateRow("", ""),
				CreateRow("", ""),
				CreateRow("", ""),
				CreateRow("", ""),
				CreateRow("", ""),
				CreateRow("", ""),
				CreateRow(item.CorrectiveAction.PartNumberOn, item.CorrectiveAction.PartNumberOn),
				CreateRow(item.CorrectiveAction.SerialNumberOn, item.CorrectiveAction.SerialNumberOn),
				CreateRow("", ""),
				CreateRow("", ""),
				CreateRow("", ""),
				CreateRow("", ""),
				CreateRow("", ""),
				CreateRow("", ""),
				CreateRow("", ""),
				CreateRow("", ""),
				CreateRow("", ""),
				CreateRow("", ""),
				CreateRow(item.Remarks, item.Remarks),
				CreateRow(author, author)
			};
		}

		#endregion

		#endregion
	}
}
