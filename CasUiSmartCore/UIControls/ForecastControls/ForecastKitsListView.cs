using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.UIControls.KitControls;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.ForecastControls
{
	///<summary>
	/// список для отображения ордеров запроса
	///</summary>
	public partial class ForecastKitsListView : BaseGridViewControl<AccessoryRequired>
	{
		#region public ForecastKitsListView()
		///<summary>
		///</summary>
		public ForecastKitsListView()
		{
			InitializeComponent();
		}
		#endregion

		#region Methods

		#region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)

		protected override void RadGridView1_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedItem == null) return;

			var form = new KitForm(SelectedItem);

			if (form.ShowDialog() == DialogResult.OK)
			{
				List<CustomCell> subs = GetListViewSubItems(SelectedItem);
				for (int i = 0; i < subs.Capacity; i++)
					radGridView1.SelectedRows[0].Cells[i].Value = subs[i].Text;
			}
		}
		#endregion

		#region protected override SetGroupsToItems(int columnIndex)
		//protected override void SetGroupsToItems(int columnIndex)
  //      {
  //          itemsListView.Groups.Clear();

  //          IEnumerable<IGrouping<Product, ListViewItem>> groupByDescription =
  //              ListViewItemList.Where(l => l.Tag != null && l.Tag is AccessoryRequired)
  //                              .GroupBy(acr => ((AccessoryRequired)acr.Tag).Product);

  //          foreach (IGrouping<Product, ListViewItem> grouping in groupByDescription)
  //          {
  //              //Необходимые комплектующие
  //              IEnumerable<AccessoryRequired> requireds = grouping.Select(lvi => lvi.Tag as AccessoryRequired);
  //              //Описание необходимых комплектующих
  //              Product ad = grouping.Key;
  //              //кол-во необходимого комплектующего на период прогноза
  //              double qtyOnPeriod = requireds.Sum(r => r.TaskQuantity);
  //              string temp = ad + " Total per period: " + qtyOnPeriod;
  //              itemsListView.Groups.Add(temp, temp);

  //              foreach (ListViewItem item in grouping)
  //              {
  //                  item.Group = itemsListView.Groups[temp];
  //              }
  //          } 
  //      }
		#endregion

		#region protected override void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		protected override void SetHeaders()
		{
			AddColumn("Standart", (int)(radGridView1.Width * 0.2f));
			AddColumn("Part Number", (int)(radGridView1.Width * 0.2f));
			AddColumn("Product", (int)(radGridView1.Width * 0.2f));
			AddColumn("Manufacturer", (int)(radGridView1.Width * 0.2f));
			AddColumn("Suppliers", (int)(radGridView1.Width * 0.2f));
			AddColumn("Check", (int)(radGridView1.Width * 0.2f));
			AddColumn("Task", (int)(radGridView1.Width * 0.2f));
			AddColumn("Cost new", (int)(radGridView1.Width * 0.2f));
			AddColumn("Cost OH", (int)(radGridView1.Width * 0.2f));
			AddColumn("Cost Serv.", (int)(radGridView1.Width * 0.2f));
			AddColumn("Q-ty.", (int)(radGridView1.Width * 0.2f));
			AddColumn("Task Q-ty.", (int)(radGridView1.Width * 0.2f));
			AddColumn("Class", (int)(radGridView1.Width * 0.2f));
			AddColumn("Remarks", (int)(radGridView1.Width * 0.2f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}
		#endregion

		#region protected override List<CustomCell> GetListViewSubItems(AccessoryRequired item)

		protected override List<CustomCell> GetListViewSubItems(AccessoryRequired item)
		{
			var check = item.MaintenanceCheck != null ? item.MaintenanceCheck.ToString() : "";
			var standart = item.Standart != null ? item.Standart.ToString() : "";
			var product = item.Product != null ? item.Product.ToString() : "";
			var supplier = item.Suppliers != null ? item.Suppliers.ToString() : "";
			var quantity = Math.Round(item.Quantity, 2).ToString();
			var taskQuantity = Math.Round(item.TaskQuantity, 2).ToString();
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);

			return new List<CustomCell>
			{
				CreateRow(standart, standart),
				CreateRow(item.PartNumber, item.PartNumber),
				CreateRow(product, product),
				CreateRow(item.Manufacturer, item.Manufacturer),
				CreateRow(supplier, supplier),
				CreateRow(check, check),
				CreateRow(item.ParentString, item.ParentString),
				CreateRow(item.CostNew.ToString(), item.CostNew),
				CreateRow(item.CostOverhaul.ToString(), item.CostOverhaul),
				CreateRow(item.CostServiceable.ToString(), item.CostServiceable),
				CreateRow(quantity, item.Quantity),
				CreateRow(taskQuantity, item.TaskQuantity),
				CreateRow(item.GoodsClass.ToString(), item.GoodsClass),
				CreateRow(item.Remarks, item.Remarks),
				CreateRow(author, author)
			};
		}

		#endregion

		#endregion
	}
}
