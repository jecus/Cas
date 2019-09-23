using System.Collections.Generic;
using System.Linq;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.NewGrid;
using CAS.UI.UIControls.WorkPakage;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Entities.General.Personnel;
using SmartCore.Entities.General.WorkPackage;

namespace CAS.UI.UIControls.PersonnelControls
{
	public partial class EmployeeWorkPackageListView : BaseGridViewControl<WorkPackage>
	{
		public Specialist CurrentSpecialist { get; set; }

		#region Constructor

		public EmployeeWorkPackageListView()
		{
			InitializeComponent();
		}

		#endregion

		#region protected override void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		protected override void SetHeaders()
		{
			AddDateColumn("Date", (int)(radGridView1.Width * 0.16f));
			AddColumn("Aircraft", (int)(radGridView1.Width * 0.32f));
			AddColumn("Work Type", (int)(radGridView1.Width * 0.34f));
			AddColumn("Privileges", (int)(radGridView1.Width * 0.6f));
			AddColumn("Occupation", (int)(radGridView1.Width * 0.34f));
			AddColumn("Station", (int)(radGridView1.Width * 0.30f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.2f));
		}
		#endregion

		#region protected override List<CustomCell> GetListViewSubItems(WorkPackage item)

		protected override List<CustomCell> GetListViewSubItems(WorkPackage item)
		{
			var subItems = new List<CustomCell>();

			var ratingString = "";
			foreach (var license in CurrentSpecialist.Licenses)
			{
				if (license.LicenseRatings.Count == 0)
					continue;

				if (ratingString != "")
					ratingString += " / ";

				ratingString += license.AircraftType.ShortName;
				ratingString += "-";

				foreach (var rating in license.LicenseRatings.GroupBy(r => r.LicenseFunction))
					ratingString += $"{rating.Key} ({string.Join(",", rating.Select(r => r.Rights.ShortName).ToArray())}) ";
			}

			var closingDate = item.ClosingDate <= DateTimeExtend.GetCASMinDateTime().Date ? "" : item.ClosingDate.ToString("dd.MM.yyyy");
			var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(item.ParentId);
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);

			return new List<CustomCell>
			{
				CreateRow(closingDate, item.ClosingDate),
				CreateRow($"{aircraft?.RegistrationNumber} {aircraft?.Model.ShortName}", aircraft),
				CreateRow($"Performed WP:{item.Title}", item.Title),
				CreateRow(ratingString, ratingString),
				CreateRow(CurrentSpecialist.Specialization.ToString(), CurrentSpecialist.Specialization),
				CreateRow(item.Station, item.Status),
				CreateRow(author, author)
			};
		}

		#endregion

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			if (SelectedItem != null)
			{
				var item = SelectedItem;
				e.TypeOfReflection = ReflectionTypes.DisplayInNew;
				item.Aircraft = GlobalObjects.AircraftsCore.GetAircraftById(item.ParentId);
				e.DisplayerText = item.Aircraft != null ? item.Aircraft.RegistrationNumber + "." + item.Title : item.Title;
				e.RequestedEntity = new WorkPackageScreen(item);
			}
		}
		#endregion
	}
}
