using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Mail;
using Convert = SmartCore.Auxiliary.Convert;

namespace CAS.UI.UIControls.MailControls
{
	public partial class MailListView : BaseListViewControl<MailRecords>
	{
		#region Constructor

		public MailListView()
		{
			InitializeComponent();
		}

		#endregion

		#region protected override void SetHeaders()

		protected override void SetHeaders()
		{
			ColumnHeaderList.Clear();

			var columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Status" };
			ColumnHeaderList.Add(columnHeader);
			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Doc.Class" };
			ColumnHeaderList.Add(columnHeader);
			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Doc.Type" };
			ColumnHeaderList.Add(columnHeader);
			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "ReceiveDate" };
			ColumnHeaderList.Add(columnHeader);
			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "№" };
			ColumnHeaderList.Add(columnHeader);
			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "CreateMailDate" };
			ColumnHeaderList.Add(columnHeader);
			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "PublishedDate" };
			ColumnHeaderList.Add(columnHeader);
			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "ClosedDate" };
			ColumnHeaderList.Add(columnHeader);
			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Reference №" };
			ColumnHeaderList.Add(columnHeader);
			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Parent Reference №" };
			ColumnHeaderList.Add(columnHeader);
			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Title" };
			ColumnHeaderList.Add(columnHeader);
			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "PerformeUpToDate" };
			ColumnHeaderList.Add(columnHeader);
			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Nomenclature" };
			ColumnHeaderList.Add(columnHeader);
			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Location" };
			ColumnHeaderList.Add(columnHeader);
			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Department" };
			ColumnHeaderList.Add(columnHeader);
			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Responsible" };
			ColumnHeaderList.Add(columnHeader);
			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Executor" };
			ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
		}

		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(MailRecords item)

		protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(MailRecords item)
		{
			var subItems = new List<ListViewItem.ListViewSubItem>();

			var status = item.IsClosed ? "Closed" : "Open";
			var parformUpToDate = item.PerformeUpTo ? Convert.GetDateFormat(item.PerformeUpToDate) : "";

			var subItem = new ListViewItem.ListViewSubItem { Text = item.Status.ToString(), Tag = item.Status };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.DocClass.ToString(), Tag = item.DocClass };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.DocType.ToString(), Tag = item.DocType };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = Convert.GetDateFormat(item.ReceiveMailDate), Tag = item.ReceiveMailDate };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.MailNumber, Tag = item.MailNumber };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = Convert.GetDateFormat(item.CreateMailRecordDate), Tag = item.CreateMailRecordDate };
			subItems.Add(subItem);
			if (item.Status == MailStatus.Published)
			{
				subItem = new ListViewItem.ListViewSubItem { Text = Convert.GetDateFormat(item.PublishingDate), Tag = item.PublishingDate };
				subItems.Add(subItem);
			}
			else
			{
				subItem = new ListViewItem.ListViewSubItem { Text = "", Tag = "" };
				subItems.Add(subItem);
			}
			if (item.Status == MailStatus.Closed)
			{
				subItem = new ListViewItem.ListViewSubItem { Text = Convert.GetDateFormat(item.ClosingDate), Tag = item.ClosingDate };
				subItems.Add(subItem);
			}
			else
			{
				subItem = new ListViewItem.ListViewSubItem { Text = "", Tag = "" };
				subItems.Add(subItem);
			}
			subItem = new ListViewItem.ListViewSubItem { Text = item.ReferenceNumber.ToString(), Tag = item.ReferenceNumber };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.ParentId > 0 ? item.ParentId.ToString() : "", Tag = item.ParentId };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.Title, Tag = item.Title };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = parformUpToDate, Tag = item.CreateMailRecordDate };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.Nomenclature.ToString(), Tag = item.Nomenclature };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.Location.ToString(), Tag = item.Location };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.Department.ToString(), Tag = item.Department };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.Specialization.ToString(), Tag = item.Specialization };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.Specialist.ToString(), Tag = item.Specialist };
			subItems.Add(subItem);

			return subItems.ToArray();
		}

		#endregion

		#region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)

		protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (SelectedItem != null)
			{
				var form = new MailForm(SelectedItem);
				if (form.ShowDialog() == DialogResult.OK)
				{
					ListViewItem.ListViewSubItem[] subs = GetListViewSubItems(SelectedItem);
					for (int i = 0; i < subs.Length; i++)
						itemsListView.SelectedItems[0].SubItems[i].Text = subs[i].Text;
				}
			}
		}

		#endregion

		#region protected override void SetGroupsToItems(int colunmIndex)

		protected override void SetGroupsToItems(int colunmIndex)
		{
			itemsListView.Groups.Clear();
			itemsListView.Groups.Add("GroupOpened", "Opened");
			itemsListView.Groups.Add("GroupPublished", "Published");
			itemsListView.Groups.Add("GroupClosed", "Closed");
			itemsListView.Groups.Add("GroupUnknown", "Unknown");

			foreach (ListViewItem item in ListViewItemList)
			{
				switch (((MailRecords)item.Tag).Status)
				{
					case MailStatus.Closed:
						item.Group = itemsListView.Groups[2];
						break;
					case MailStatus.Published:
						item.Group = itemsListView.Groups[1];
						break;
					case MailStatus.Opened:
						item.Group = itemsListView.Groups[0];
						break;
					default:
						item.Group = itemsListView.Groups[3];
						break;
				}
			}
		}

		#endregion
	}
}
