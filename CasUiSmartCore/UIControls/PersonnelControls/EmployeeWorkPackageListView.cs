using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.WorkPakage;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Entities.General.Personnel;
using SmartCore.Entities.General.WorkPackage;

namespace CAS.UI.UIControls.PersonnelControls
{
	public partial class EmployeeWorkPackageListView : BaseListViewControl<WorkPackage>
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
			ColumnHeaderList.Clear();

			var columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Date" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.16f), Text = "Aircraft" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.17f), Text = "Work Type" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.3f), Text = "Privileges" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.17f), Text = "Occupation" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.15f), Text = "Station" };
			ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());

		}
		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(WorkPackage item)

		protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(WorkPackage item)
		{
			var subItems = new List<ListViewItem.ListViewSubItem>();

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

			var subItem = new ListViewItem.ListViewSubItem { Text = closingDate, Tag = item.ClosingDate };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = $"{aircraft?.RegistrationNumber} {aircraft?.Model.ShortName}", Tag = aircraft };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = $"Performed WP:{item.Title}", Tag = item.Title };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = ratingString, Tag = ratingString };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = CurrentSpecialist.Specialization.ToString(), Tag = CurrentSpecialist.Specialization };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.Station, Tag = item.Status };
			subItems.Add(subItem);

			return subItems.ToArray();
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
