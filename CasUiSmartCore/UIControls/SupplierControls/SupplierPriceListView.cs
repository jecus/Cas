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
        public bool GroupBySupplie { get; set; }

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


		protected override void GroupingItems()
		{
			if(GroupBySupplie)
				Grouping("Supplier");
			else
			{
				radGridView1.Columns["Product"].Width = 0;
			}
		}


		#endregion
	}
}
