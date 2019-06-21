using System;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.NewGrid;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls
{
    ///<summary>
    /// список для отображения категорий нерутинных работ
    ///</summary>
    public partial class PurchaseOrderView : BaseGridViewControl<PurchaseRequestRecord>
    {
        #region public PurchaseOrderView()
        ///<summary>
        ///</summary>
        public PurchaseOrderView()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods

        #region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)

        protected override void RadGridView1_DoubleClick(object sender, EventArgs e)
		{
            if (SelectedItem != null)
            {
                PurchaseOrderKitForm form = new PurchaseOrderKitForm(SelectedItem);
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
