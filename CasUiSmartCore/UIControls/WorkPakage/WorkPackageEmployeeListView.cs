using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UIControls.WorkPakage
{
	public partial class WorkPackageEmployeeListView : BaseListViewControl<Specialist>
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
			ColumnHeaderList.Clear();

			var columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "First Name" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Last Name" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Occupation" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.4f), Text = "Privileges" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Author" };
			ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());

		}
		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Specialist item)

		protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Specialist item)
		{
			var subItems = new List<ListViewItem.ListViewSubItem>();
			var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);
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

			var subItem = new ListViewItem.ListViewSubItem { Text = item.FirstName, Tag = item.FirstName };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.LastName, Tag = item.LastName };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.Specialization.ToString(), Tag = item.Specialization };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = ratingString, Tag = ratingString };
			subItems.Add(subItem);
			subItems.Add(new ListViewItem.ListViewSubItem { Text = author, Tag = author });

			return subItems.ToArray();
		}

		#endregion
	}
}
