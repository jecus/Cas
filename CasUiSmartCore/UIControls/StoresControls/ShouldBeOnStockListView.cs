using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Store;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.StoresControls
{
    ///<summary>
    /// список для отображения событий системы безопасности полетов
    ///</summary>
    public partial class ShouldBeOnStockListView : CommonGridViewControl
    {
        #region public ShouldBeOnStockListView()
        ///<summary>
        ///</summary>
        public ShouldBeOnStockListView() : base()
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
                if (radGridView1.SelectedRows.Count == 1)
                    return (radGridView1.SelectedRows[0].Tag as StockComponentInfo);
                return null;
            }
        }
		#endregion

		#region Methods

		#region protected override void RadGridView1_DoubleClick(object sender, EventArgs e)
		protected override void RadGridView1_DoubleClick(object sender, EventArgs e)
		{
            if (SelectedItem != null)
            {
                var form = new StockComponentInfoForm(SelectedItem);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    GlobalObjects.StockCalculator.CalculateStock(SelectedItem);
                    var subs = GetListViewSubItems(SelectedItem);
                    for (int i = 0; i < subs.Count; i++)
                        radGridView1.SelectedRows[0].Cells[i].Value = subs[i].Text;

                    SetItemColor(radGridView1.SelectedRows[0], SelectedItem);
                }
            }
        }
		#endregion

		#region protected override void SetItemColor(GridViewRowInfo listViewItem, Document item)
		protected override void SetItemColor(GridViewRowInfo listViewItem, BaseEntityObject item)
		{
            var sdi = item as StockComponentInfo;
            if (sdi == null) return;

            foreach (GridViewCellInfo cell in listViewItem.Cells)
            {
	            cell.Style.CustomizeFill = true;

				if (sdi.Current < sdi.ShouldBeOnStock)
					cell.Style.BackColor = Color.FromArgb(Highlight.Red.Color);
				if (sdi.Current == sdi.ShouldBeOnStock)
					cell.Style.BackColor = Color.FromArgb(Highlight.Yellow.Color);
				if (sdi.ShouldBeOnStock == 0)
					cell.Style.BackColor = Color.FromArgb(Highlight.Blue.Color);
			}
            
        }
        #endregion

        #endregion
    }
}
