using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UIControls.PersonnelControls
{
    ///<summary>
    /// список для отображения сотрудников
    ///</summary>
    public partial class PersonnelListView : BaseListViewControl<Specialist>
    {
        #region Fields

        #endregion

        #region Constructors

        #region public PersonnelListView()
        ///<summary>
        ///</summary>
        public PersonnelListView()
        {
            InitializeComponent();
	        SortMultiplier = 0;
			OldColumnIndex = 6;
		}
		#endregion

		#endregion

		#region Methods

		#region protected override void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		protected override void SetHeaders()
		{
			ColumnHeaderList.Clear();

			var columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Status" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "First Name" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Last Name" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Short Name" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Occupation" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Combination" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.15f), Text = "Department" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.25f), Text = "Privileges" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.15f), Text = "Date of Birth" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.17f), Text = "Education" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Position" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.15f), Text = "Facility" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.05f), Text = "Sex" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Nationality" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Address" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Family Status" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "PhoneMobile" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.30f), Text = "Phone" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.07f), Text = "Email" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.07f), Text = "Skype" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Signer" };
			ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());

		}
		#endregion

		#region protected override SetGroupsToItems()

	    protected override void SetGroupsToItems(int columnIndex)
	    {
		 //   itemsListView.Groups.Clear();

			//if (columnIndex == 7)
		 //   {
			//    string temp;
			//    foreach (var item in ListViewItemList.OrderBy(i => (i.Tag as Specialist).DateOfBirth.Month))
			//    {
			//	    if (item.Tag is Specialist)
			//	    {
			//		    var specialist = item.Tag as Specialist;
			//		    temp = specialist.DateOfBirth.ToString("MMMM");
			//		    itemsListView.Groups.Add(temp, temp);
			//		    item.Group = itemsListView.Groups[temp];
			//	    }
			//    }
			//}
	    }

	    #endregion

		#region protected override void SetItemColor(ListViewItem listViewItem, Specialization item)
		//protected override void SetItemColor(ListViewItem listViewItem, Specialization item)
		//{
		//}
		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Specialization item)

	    protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Specialist item)
	    {
			var subItems = new List<ListViewItem.ListViewSubItem>();

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

		    var department = item.Specialization?.Department ??  Department.Unknown;
		    var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);
			var phone = string.IsNullOrEmpty(item.Additional) ? item.Phone : $"{item.Phone} | Add.: {item.Additional}";

			var subItem = new ListViewItem.ListViewSubItem { Text = item.Status.ToString(), Tag = item.Status };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.FirstName, Tag = item.FirstName };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.LastName, Tag = item.LastName };
			subItems.Add(subItem);
		    subItem = new ListViewItem.ListViewSubItem { Text = item.ShortName, Tag = item.ShortName };
		    subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.Specialization.ToString(), Tag = item.Specialization };
			subItems.Add(subItem);
		    subItem = new ListViewItem.ListViewSubItem { Text = item.Combination, Tag = item.Combination };
		    subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = department.ToString(), Tag = department };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = ratingString, Tag = ratingString };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.DateOfBirth.ToString("dd-MMMM-yyyy"), Tag = item.DateOfBirth };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.Education.ToString(), Tag = item.Education };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.Position.ToString(), Tag = item.Position };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.Facility.ShortName, Tag = item.Facility };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.Gender.ToString(), Tag = item.Gender };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.Citizenship.ToString(), Tag = item.Citizenship };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.Address, Tag = item.Address };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.FamilyStatus.ToString(), Tag = item.FamilyStatus };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.PhoneMobile, Tag = item.PhoneMobile };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = phone, Tag = item.Phone };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.Email, Tag = item.Email };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.Skype, Tag = item.Skype };
			subItems.Add(subItem);
			subItems.Add(new ListViewItem.ListViewSubItem { Text = author, Tag = author });

			return subItems.ToArray();
		}

		#endregion

	    #region protected override void SortItems(int columnIndex)

	    protected override void SortItems(int columnIndex)
	    {
		    if (OldColumnIndex != columnIndex)
			    SortMultiplier = -1;
		    if (SortMultiplier == 1)
			    SortMultiplier = -1;
		    else
			    SortMultiplier = 1;
		    itemsListView.Items.Clear();

		    SetGroupsToItems(columnIndex);

			if (columnIndex == 7)
				itemsListView.Items.AddRange(ListViewItemList.OrderBy(i => ((Specialist)i.Tag).DateOfBirth.Month).ThenBy(i => ((Specialist)i.Tag).DateOfBirth.Day).ToArray());
			else
			{
				ListViewItemList.Sort(new BaseListViewComparer(columnIndex, SortMultiplier));
				itemsListView.Items.AddRange(ListViewItemList.ToArray());
			}

			OldColumnIndex = columnIndex;
		    SetItemsColor();
	    }

	    #endregion

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
        {
            if (SelectedItem != null)
            {
                //e.Cancel = true;
                //CommonEditorForm form = new CommonEditorForm(SelectedItem);
                //if (form.ShowDialog() == DialogResult.OK)
                //{
                //    itemsListView.Items[itemsListView.Items.IndexOf(itemsListView.SelectedItems[0])] =
                //        new ListViewItem(GetListViewSubItems(SelectedItem), null) { Tag = SelectedItem };
                //}

                string regNumber = SelectedItem.FirstName + " " + SelectedItem.LastName;
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                e.DisplayerText = regNumber;
                e.RequestedEntity = new EmployeeScreen(SelectedItem);
            }
        }
        #endregion

        #endregion
    }
}
