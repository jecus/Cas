using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.KitControls;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.PurchaseControls
{
	///<summary>
	/// список для отображения ордеров запроса
	///</summary>
	public partial class AccessoryRequiredListView : BaseGridViewControl<AccessoryRequired>
	{
		#region Fields

		#endregion

		#region Constructors

		#region public AccessoryRequiredListView()
		///<summary>
		///</summary>
		public AccessoryRequiredListView()
		{
			InitializeComponent();
		}
		#endregion

		#endregion

		#region Methods

		#region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)

		protected override void RadGridView1_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedItem == null) return;

			KitForm form = new KitForm(SelectedItem);

			if (form.ShowDialog() == DialogResult.OK)
			{
				List<CustomCell> subs = GetListViewSubItems(SelectedItem);
				for (int i = 0; i < subs.Count; i++)
					radGridView1.SelectedRows[0].Cells[i].Value = subs[i].Text;
			}
		}
		#endregion

		#region protected override void SetItemColor(ListViewItem listViewItem, AccessoryRequired item)
		//protected override void SetItemColor(ListViewItem listViewItem, AccessoryRequired item)
		//{
			//if (item == null)return;
			//IDirective imd = item.ParentObject as IDirective;
			//if (imd == null) return;

			//if (imd.NextPerformanceIsBlocked)
			//{
			//    listViewItem.BackColor = Color.FromArgb(Highlight.Grey.Color);
			//    listViewItem.ToolTipText = "This performance is involved on Work Package:" + imd.NextPerformances[0].BlockedByPackage.Title;
			//}
			//else
			//{
			//    if (imd.Condition == ConditionState.Overdue)
			//        listViewItem.BackColor = Color.FromArgb(Highlight.Red.Color);
			//    if (imd.Condition == ConditionState.Notify)
			//        listViewItem.BackColor = Color.FromArgb(Highlight.Yellow.Color);
			//    if (imd.Condition == ConditionState.NotEstimated)
			//        listViewItem.BackColor = Color.FromArgb(Highlight.Blue.Color);
			//}
		//}
		#endregion

		#region protected override SetGroupsToItems(int columnIndex)
		//protected override void SetGroupsToItems(int columnIndex)
		//{
		//	itemsListView.Groups.Clear();

		//	IEnumerable<IGrouping<Product, ListViewItem>> groupByDescription =
		//		ListViewItemList.Where(l => l.Tag is AccessoryRequired)
		//						.GroupBy(acr => ((AccessoryRequired)acr.Tag).Product);

		//	foreach (IGrouping<Product, ListViewItem> grouping in groupByDescription)
		//	{
		//		//Необходимые комплектующие
		//		IEnumerable<AccessoryRequired> requireds = grouping.Select(lvi => lvi.Tag as AccessoryRequired);
		//		//Описание необходимых комплектующих
		//		Product ad = grouping.Key;
		//		//кол-во необходимого комплектующего на период прогноза
		//		double qtyOnPeriod = requireds.Sum(r => r.TaskQuantity);
		//		string temp = ad + " Total per period: " + qtyOnPeriod;
		//		itemsListView.Groups.Add(temp, temp);

		//		foreach (ListViewItem item in grouping)
		//		{
		//			item.Group = itemsListView.Groups[temp];
		//		}
		//	}
		//}
		#endregion

		#region protected override void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		protected override void SetHeaders()
		{
			AddColumn("Reference", (int)(radGridView1.Width * 0.2f));
			AddColumn("Standart", (int)(radGridView1.Width * 0.2f));
			AddColumn("Part Number", (int)(radGridView1.Width * 0.2f));
			AddColumn("Product", (int)(radGridView1.Width * 0.2f));
			AddColumn("Description", (int)(radGridView1.Width * 0.2f));
			AddColumn("Task", (int)(radGridView1.Width * 0.2f));
			AddColumn("Q-ty.", (int)(radGridView1.Width * 0.2f));
			AddColumn("Task Q-ty.", (int)(radGridView1.Width * 0.2f));
			AddColumn("Class", (int)(radGridView1.Width * 0.2f));
			AddColumn("Manufacturer", (int)(radGridView1.Width * 0.2f));
			AddColumn("Suppliers", (int)(radGridView1.Width * 0.2f));
			AddColumn("Check", (int)(radGridView1.Width * 0.2f));
			AddColumn("Cost new", (int)(radGridView1.Width * 0.2f));
			AddColumn("Cost OH", (int)(radGridView1.Width * 0.2f));
			AddColumn("Cost Serv.", (int)(radGridView1.Width * 0.2f));
			AddColumn("Remarks", (int)(radGridView1.Width * 0.2f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.2f));
		}
		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(AccessoryRequired item)

		protected override List<CustomCell> GetListViewSubItems(AccessoryRequired item)
		{
			var subItems = new List<CustomCell>();

			var check = item.MaintenanceCheck != null ? item.MaintenanceCheck.ToString() : "";
			var standart = item.Standart != null ? item.Standart.ToString() : "";
			var product = item.Product != null ? item.Product.Name : "";
			var description = item.Description != null ? item.Description : "";
			var supplier = item.Suppliers != null ? item.Suppliers.ToString() : "";
			bool isComponent =
					item.GoodsClass.IsNodeOrSubNodeOf(new IDictionaryTreeItem[]
					{
						GoodsClass.ComponentsAndParts,
						GoodsClass.ProductionAuxiliaryEquipment,
					});

			var quantity = isComponent ? 1 : item.Quantity;
			var quantityString = $"{quantity} {item.Measure.ShortName}";
			var taskQuantity = Math.Round(item.TaskQuantity, 2).ToString();
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);
			var reference = item.Product?.Reference;

			subItems.Add(CreateRow(reference, reference));
			subItems.Add(CreateRow(standart, standart));
			subItems.Add(CreateRow(item.PartNumber, item.PartNumber));
			subItems.Add(CreateRow(product, product));
			subItems.Add(CreateRow(description, description));
			subItems.Add(CreateRow(item.ParentString, item.ParentString));
			subItems.Add(CreateRow(quantityString, item.Quantity));
			subItems.Add(CreateRow(taskQuantity, item.TaskQuantity));
			subItems.Add(CreateRow(item.GoodsClass.ToString(), item.GoodsClass));
			subItems.Add(CreateRow(item.Manufacturer, item.Manufacturer));
			subItems.Add(CreateRow(supplier, supplier));
			subItems.Add(CreateRow(check, check));
			subItems.Add(CreateRow(item.CostNew.ToString(), item.CostNew));
			subItems.Add(CreateRow(item.CostOverhaul.ToString(), item.CostOverhaul));
			subItems.Add(CreateRow(item.CostServiceable.ToString(), item.CostServiceable));
			subItems.Add(CreateRow(item.Remarks, item.Remarks));
			subItems.Add(CreateRow(author, author));


			return subItems;
		}

		#endregion

		protected override void SetTotalText()
		{
			var groupByDescription =
				GetItemsArray().Where(l => l is AccessoryRequired)
					.GroupBy(acr => ((AccessoryRequired)acr).Product);

			this.labelTotal.Text = $"Total: {groupByDescription.Count()}/{_items.Count}";
		}

		#endregion
	}
}
