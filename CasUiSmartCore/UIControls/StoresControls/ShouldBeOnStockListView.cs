using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Store;

namespace CAS.UI.UIControls.StoresControls
{
    ///<summary>
    /// список для отображения событий системы безопасности полетов
    ///</summary>
    public partial class ShouldBeOnStockListView : CommonListViewControl
    {
        #region public ShouldBeOnStockListView()
        ///<summary>
        ///</summary>
        public ShouldBeOnStockListView()
        {
            InitializeComponent();
        }
        #endregion

        #region public ShouldBeOnStockListView(PropertyInfo beginGroup) : base(beginGroup)
        ///<summary>
        ///</summary>
        public ShouldBeOnStockListView(PropertyInfo beginGroup)
            : base(beginGroup)
        {
            InitializeComponent();
        }
        #endregion

        #region public new StockDetailInfo SelectedItem
        /// <summary>
        /// Выбранный элемент
        /// </summary>
        public new StockComponentInfo SelectedItem
        {
            get
            {
                if (itemsListView.SelectedItems.Count == 1)
                    return (itemsListView.SelectedItems[0].Tag as StockComponentInfo);
                return null;
            }
        }
        #endregion

        #region Methods

        #region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
        protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SelectedItem != null)
            {
                StockComponentInfoForm form = new StockComponentInfoForm(SelectedItem);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    GlobalObjects.StockCalculator.CalculateStock(SelectedItem);
                    ListViewItem.ListViewSubItem[] subs = GetListViewSubItems(SelectedItem);
                    for (int i = 0; i < subs.Length; i++)
                        itemsListView.SelectedItems[0].SubItems[i].Text = subs[i].Text;

                    SetItemColor(itemsListView.SelectedItems[0], SelectedItem);
                }
            }
        }
        #endregion

        #region protected override void SetItemColor(ListViewItem listViewItem, BaseSmartCoreObject item)
        protected override void SetItemColor(ListViewItem listViewItem, BaseEntityObject item)
        {
            StockComponentInfo sdi = item as StockComponentInfo;
            if (sdi == null) return;

            if (sdi.Current < sdi.ShouldBeOnStock)
                listViewItem.BackColor = Color.FromArgb(Highlight.Red.Color);
            if (sdi.Current == sdi.ShouldBeOnStock)
                listViewItem.BackColor = Color.FromArgb(Highlight.Yellow.Color);
            if (sdi.ShouldBeOnStock == 0)
                listViewItem.BackColor = Color.FromArgb(Highlight.Blue.Color);
        }
        #endregion

        #endregion
    }
}
