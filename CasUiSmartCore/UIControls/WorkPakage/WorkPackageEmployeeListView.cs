using System.Collections.Generic;
using System.Linq;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UIControls.WorkPakage
{
	public partial class WorkPackageEmployeeListView : BaseGridViewControl<Specialist>
	{
		public WorkPackageEmployeeListView()
		{
			InitializeComponent();
		}

		#region protected override void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		protected override void SetHeaders()
		{
			AddColumn("First Name", (int)(radGridView1.Width * 0.4f));
			AddColumn("Last Name", (int)(radGridView1.Width * 0.4f));
			AddColumn("Occupation", (int)(radGridView1.Width * 0.4f));
			AddColumn("Privileges", (int)(radGridView1.Width * 0.8f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}
		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Specialist item)

		protected override List<CustomCell> GetListViewSubItems(Specialist item)
		{
			var subItems = new List<CustomCell>();
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);
			var ratingString = "";
			foreach (var license in item.Licenses)
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

			subItems.Add(CreateRow(item.FirstName, item.FirstName ));
			subItems.Add(CreateRow(item.LastName, item.LastName ));
			subItems.Add(CreateRow(item.Specialization.ToString(), item.Specialization ));
			subItems.Add(CreateRow(ratingString, ratingString ));
			subItems.Add(CreateRow(author, author ));

			return subItems;
		}

		#endregion
	}
}
