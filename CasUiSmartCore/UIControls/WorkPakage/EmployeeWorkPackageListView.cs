using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UIControls.WorkPakage
{
	public partial class EmployeeWorkPackageListView : BaseListViewControl<Specialist>
	{
		public EmployeeWorkPackageListView()
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

			var columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "First Name" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Last Name" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Occupation" };
			ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
		}
		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Specialist item)

		protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Specialist item)
		{
			var subItems = new List<ListViewItem.ListViewSubItem>();

			var subItem = new ListViewItem.ListViewSubItem { Text = item.FirstName, Tag = item.FirstName };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.LastName, Tag = item.LastName };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.Specialization.ToString(), Tag = item.Specialization };
			subItems.Add(subItem);

			return subItems.ToArray();
		}

		#endregion
	}
}
