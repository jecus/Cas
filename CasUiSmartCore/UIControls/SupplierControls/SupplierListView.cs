using System;
using System.Windows.Forms;
using CAS.UI.UIControls.NewGrid;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.SupplierControls
{
	///<summary>
	/// список для отображения ордеров запроса
	///</summary>
	public partial class SupplierListView : BaseGridViewControl<Supplier>
	{
		#region Fields

		#endregion

		#region Constructors

		#region public SupplierListViewNew()
		///<summary>
		///</summary>
		public SupplierListView()
		{
			InitializeComponent();
			SortMultiplier = 0;
			OldColumnIndex = 0;
		}
		#endregion

		#endregion

		#region Methods

		#region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
		protected override void RadGridView1_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedItem != null)
			{
				SupplierForm form = new SupplierForm(SelectedItem);
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
