using System;
using CAS.UI.UIControls.NewGrid;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.SupplierControls
{
    ///<summary>
    /// список для отображения ордеров запроса
    ///</summary>
    public partial class SupplierPriceListView : BaseGridViewControl<SupplierPrice>
    {
        #region Fields

        #endregion

        #region Constructors

        #region public SupplierListViewNew()
        ///<summary>
        ///</summary>
        public SupplierPriceListView()
        {
            InitializeComponent();

            SortMultiplier = 0;
        }
		#endregion

		#endregion

		#region Methods

        #region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
        protected override void RadGridView1_DoubleClick(object sender, EventArgs e)
		{
            
        }
        #endregion

        #endregion
    }
}
