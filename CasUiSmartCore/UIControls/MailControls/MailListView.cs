using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Mail;
using Convert = SmartCore.Auxiliary.Convert;

namespace CAS.UI.UIControls.MailControls
{
	public partial class MailListView : BaseGridViewControl<MailRecords>
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
			AddColumn("Status", (int)(radGridView1.Width * 0.2f));
			AddColumn("Doc.Class", (int)(radGridView1.Width * 0.2f));
			AddColumn("Doc.Type", (int)(radGridView1.Width * 0.2f));
			AddColumn("ReceiveDate", (int)(radGridView1.Width * 0.2f));
			AddColumn("№", (int)(radGridView1.Width * 0.2f));
			AddColumn("CreateMailDate", (int)(radGridView1.Width * 0.2f));
			AddColumn("PublishedDate", (int)(radGridView1.Width * 0.2f));
			AddColumn("ClosedDate", (int)(radGridView1.Width * 0.2f));
			AddColumn("Reference №", (int)(radGridView1.Width * 0.2f));
			AddColumn("Parent Reference №", (int)(radGridView1.Width * 0.2f));
			AddColumn("Title", (int)(radGridView1.Width * 0.2f));
			AddColumn("PerformeUpToDate", (int)(radGridView1.Width * 0.2f));
			AddColumn("Nomenclature", (int)(radGridView1.Width * 0.2f));
			AddColumn("Location", (int)(radGridView1.Width * 0.2f));
			AddColumn("Department", (int)(radGridView1.Width * 0.2f));
			AddColumn("Responsible", (int)(radGridView1.Width * 0.2f));
			AddColumn("Executor", (int)(radGridView1.Width * 0.2f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}

		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(MailRecords item)

		protected override List<CustomCell> GetListViewSubItems(MailRecords item)
		{
			var subItems = new List<CustomCell>();

			var status = item.IsClosed ? "Closed" : "Open";
			var parformUpToDate = item.PerformeUpTo ? Convert.GetDateFormat(item.PerformeUpToDate) : "";
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);

			subItems.Add(CreateRow(item.Status.ToString(), item.Status));
			subItems.Add(CreateRow(item.DocClass.ToString(), item.DocClass));
			subItems.Add(CreateRow(item.DocType.ToString(), item.DocType));
			subItems.Add(CreateRow(Convert.GetDateFormat(item.ReceiveMailDate), item.ReceiveMailDate));
			subItems.Add(CreateRow(item.MailNumber, item.MailNumber));
			subItems.Add(CreateRow(Convert.GetDateFormat(item.CreateMailRecordDate), item.CreateMailRecordDate));
			if (item.Status == MailStatus.Published)
			{
				subItems.Add(CreateRow(Convert.GetDateFormat(item.PublishingDate), item.PublishingDate));
			}
			else
			{
				subItems.Add(CreateRow("", ""));
			}
			if (item.Status == MailStatus.Closed)
			{
				subItems.Add(CreateRow(Convert.GetDateFormat(item.ClosingDate), item.ClosingDate));
			}
			else
			{
				subItems.Add(CreateRow("", ""));
			}
			subItems.Add(CreateRow(item.ReferenceNumber.ToString(), item.ReferenceNumber));
			subItems.Add(CreateRow(item.ParentId > 0 ? item.ParentId.ToString() : "", item.ParentId));
			subItems.Add(CreateRow(item.Title, item.Title));
			subItems.Add(CreateRow(parformUpToDate, item.CreateMailRecordDate));
			subItems.Add(CreateRow(item.Nomenclature.ToString(), item.Nomenclature));
			subItems.Add(CreateRow(item.Location.ToString(), item.Location));
			subItems.Add(CreateRow(item.Department.ToString(), item.Department));
			subItems.Add(CreateRow(item.Occupation.ToString(), item.Occupation));
			subItems.Add(CreateRow(item.Specialist.ToString(), item.Specialist));
			subItems.Add(CreateRow(author, author));

			return subItems;
		}

		#endregion

		#region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)

		protected override void RadGridView1_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedItem != null)
			{
				var form = new MailForm(SelectedItem);
				if (form.ShowDialog() == DialogResult.OK)
				{
					List<CustomCell> subs = GetListViewSubItems(SelectedItem);
					for (int i = 0; i < subs.Count; i++)
						radGridView1.SelectedRows[0].Cells[i].Value = subs[i].Text;
				}
			}
		}

		#endregion

		#region protected override void SetGroupsToItems(int colunmIndex)

		//protected override void SetGroupsToItems(int colunmIndex)
		//{
		//	itemsListView.Groups.Clear();
		//	itemsListView.Groups.Add("GroupOpened", "Opened");
		//	itemsListView.Groups.Add("GroupPublished", "Published");
		//	itemsListView.Groups.Add("GroupClosed", "Closed");
		//	itemsListView.Groups.Add("GroupUnknown", "Unknown");

		//	foreach (ListViewItem item in ListViewItemList)
		//	{
		//		switch (((MailRecords)item.Tag).Status)
		//		{
		//			case MailStatus.Closed:
		//				item.Group = itemsListView.Groups[2];
		//				break;
		//			case MailStatus.Published:
		//				item.Group = itemsListView.Groups[1];
		//				break;
		//			case MailStatus.Opened:
		//				item.Group = itemsListView.Groups[0];
		//				break;
		//			default:
		//				item.Group = itemsListView.Groups[3];
		//				break;
		//		}
		//	}
		//}

		#endregion
	}
}
