using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Entities.General.Mail;
using SmartCore.Purchase;
using Convert = SmartCore.Auxiliary.Convert;

namespace CAS.UI.UIControls.MailControls
{
	public partial class MailChatListView : BaseListViewControl<MailChats>
	{
		#region Constrcuctor

		public MailChatListView()
		{
			InitializeComponent();
		}

		#endregion

		#region protected override void SetHeaders()

		protected override void SetHeaders()
		{
			ColumnHeaderList.Clear();

			var columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "From - To" };
			ColumnHeaderList.Add(columnHeader);
			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Description" };
			ColumnHeaderList.Add(columnHeader);
			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "CreateDate" };
			ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
		}

		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(MailChats item)

		protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(MailChats item)
		{
			var subItems = new List<ListViewItem.ListViewSubItem>();

			var operatorName = GlobalObjects.CasEnvironment.Operators[0].Name;
			var from = item.SupplierFrom != Supplier.Unknown ? item.SupplierFrom.ToString() : operatorName;
			var to = item.SupplierTo != Supplier.Unknown ? item.SupplierTo.ToString() : operatorName;

			var fromTo = $"{from} - {to}";

			var subItem = new ListViewItem.ListViewSubItem { Text = fromTo, Tag = fromTo };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.Description, Tag = item.Description };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = Convert.GetDateFormat(item.CreateDate), Tag = item.CreateDate };
			subItems.Add(subItem);

			return subItems.ToArray();
		}

		#endregion

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			if (SelectedItem != null)
			{
				e.TypeOfReflection = ReflectionTypes.DisplayInNew;
				e.DisplayerText = "MailListScreen";
				e.RequestedEntity = new MailListScreen(GlobalObjects.CasEnvironment.Operators[0], SelectedItem);
			}
		}

		#endregion

	}
}
