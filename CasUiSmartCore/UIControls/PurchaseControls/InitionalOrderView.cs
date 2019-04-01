using System;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls
{
    ///<summary>
    /// список для отображения категорий нерутинных работ
    ///</summary>
    public partial class InitionalOrderView : BaseListViewControl<InitialOrderRecord>
    {
        #region public InitionalOrderView()
        ///<summary>
        ///</summary>
        public InitionalOrderView()
        {
            InitializeComponent();
        }
		#endregion

		#region Methods

		#region protected override SetGroupsToItems(int columnIndex)
		/// <summary>
		/// Выполняет группировку элементов
		/// </summary>
		protected override void SetGroupsToItems(int columnIndex)
        {
            itemsListView.Groups.Clear();

            foreach (ListViewItem item in ListViewItemList)
            {
                String temp;
                InitialOrderRecord record = item.Tag as InitialOrderRecord;
                if (record == null)
                    return;
                if (record.Product == null)
                {
                    temp = "Another accessory";
                    itemsListView.Groups.Add(temp, temp);
                    item.Group = itemsListView.Groups[temp];
                }
                else
                {
                    temp = record.Product.GoodsClass.ShortName;
                    itemsListView.Groups.Add(temp, temp);
                    item.Group = itemsListView.Groups[temp];
                }
            }
        }
        #endregion

        #region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)

        /// <summary>
        /// Реагирует на двойной щелчок в списке элементов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SelectedItem == null) return;

            InitialOrderRecordForm form = new InitialOrderRecordForm(SelectedItem);
            form.ShowDialog();
        }
        #endregion

        #endregion
    }
}
