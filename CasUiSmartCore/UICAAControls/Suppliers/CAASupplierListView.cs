using System;
using System.Windows.Forms;
using CAS.UI.UIControls.NewGrid;
using CAS.UI.UIControls.SupplierControls;
using SmartCore.Purchase;

namespace CAS.UI.UICAAControls.Suppliers
{
	///<summary>
	/// список для отображения ордеров запроса
	///</summary>
	public partial class CAASupplierListView : BaseGridViewControl<SmartCore.Purchase.Supplier>
	{
		#region Fields

		#endregion

		#region Constructors

		#region public SupplierListViewNew()
		///<summary>
		///</summary>
		public CAASupplierListView()
		{
			InitializeComponent();
			SortDirection = SortDirection.Desc;
			OldColumnIndex = 0;
			EnableCustomSorting = true;
		}
		#endregion

		#endregion

		#region Methods

		#region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
		protected override void RadGridView1_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedItem != null)
			{
				var form = new CAASupplierForm(SelectedItem);
				if (form.ShowDialog() == DialogResult.OK)
				{
					var subs = GetListViewSubItems(SelectedItem);
					for (int i = 0; i < subs.Count; i++)
						radGridView1.SelectedRows[0].Cells[i].Value = subs[i].Text;
				}
			}
		}
		#endregion

		#endregion
	}
}
