using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls
{
    ///<summary>
    /// список для отображения категорий нерутинных работ
    ///</summary>
    public partial class PurchaseOrderView : BaseListViewControl<PurchaseRequestRecord>
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

        protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SelectedItem != null)
            {
                PurchaseOrderKitForm form = new PurchaseOrderKitForm(SelectedItem);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    itemsListView.Items[itemsListView.Items.IndexOf(itemsListView.SelectedItems[0])] = 
                        new ListViewItem(GetListViewSubItems(SelectedItem), null) { Tag = SelectedItem };
                }
            }
        }
        #endregion

        #endregion
    }
}
