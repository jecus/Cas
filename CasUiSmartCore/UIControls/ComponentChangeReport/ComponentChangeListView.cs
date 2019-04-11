using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Helpers;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.ComponentChangeReport
{
	public partial class ComponentChangeListView : BaseListViewControl<TransferRecord>
	{
		public ComponentChangeListView()
		{
			InitializeComponent();
		}

		#region protected override void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		protected override void SetHeaders()
		{
			itemsListView.Columns.Clear();
			ColumnHeaderList.Clear();

			ColumnHeader columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Date" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "From: => To:" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.3f), Text = "Off" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.3f), Text = "On" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "ATA" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Class" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Description" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Reason" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Author" };
			ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
		}
		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(TransferRecord item)

		protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(TransferRecord item)
		{
			var subItems = new List<ListViewItem.ListViewSubItem>();
			string on, off,  ata, goodClass, reason = "", description = "", fromTo = "";

			if (item.IsReplaceComponentRemoved)
			{
				off = item.ReplaceComponent.ToString();
				on = item.ParentComponent.ToString();

				ata = item.ReplaceComponent.ATAChapter.ToString();
				goodClass = item.ReplaceComponent.GoodsClass.ToString();

				var tr = item.ReplaceComponent.TransferRecords.LastOrDefault(x => x.TransferDate.Date.Equals(item.TransferDate.Date));
				if (tr?.DestinationObject != null)
				{
					reason = tr.Reason.ToString();
					description = tr.Description;

					var from = "";
					if (tr.FromAircraft != null)
						from = "Aircraft: " + tr.FromAircraft;
					if (tr.FromStore != null)
						from = "Store: " + tr.FromStore;
					if (tr.FromBaseComponent != null)
					{
						if (from != "") from += " ";
						from += "Base Component:" + tr.FromBaseComponent;
					}

					fromTo += $"{from} => {DestinationHelper.GetDestinationObjectString(tr)}";
				}
					
			}
			else
			{
				on = item.ReplaceComponent.ToString();
				off = item.ParentComponent.ToString();

				ata = item.ParentComponent.ATAChapter.ToString();
				goodClass = item.ParentComponent.GoodsClass.ToString();

				var tr = item.ReplaceComponent.TransferRecords.FirstOrDefault(x => x.TransferDate.Date.Equals(item.TransferDate.Date));
				if (tr != null)
				{
					reason = tr.Reason.ToString();
					description = tr.Description;
				}

				var from = "";
				if (item.FromAircraft != null)
					from = "Aircraft: " + item.FromAircraft;
				if (item.FromStore != null)
					from = "Store: " + item.FromStore;
				if (item.FromBaseComponent != null)
				{
					if (from != "") from += " ";
					from += "Base Component:" + item.FromBaseComponent;
				}
				fromTo += $"{from} => {DestinationHelper.GetDestinationObjectString(item)}";
			}

			var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);
			var subItem = new ListViewItem.ListViewSubItem { Text = item.TransferDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString()), Tag = item.TransferDate };

			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = fromTo, Tag = fromTo };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = off, Tag = off };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = on, Tag = on };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = ata, Tag = ata };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = goodClass, Tag = goodClass };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = description, Tag = description };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = reason, Tag = reason };
			subItems.Add(subItem);
			subItems.Add(new ListViewItem.ListViewSubItem { Text = author, Tag = author });


			return subItems.ToArray();
		}

		#endregion

		#region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)

		protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
		{
			
		}

		#endregion
	}
}
