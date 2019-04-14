using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.SupplierControls
{
    ///<summary>
    /// список для отображения ордеров запроса
    ///</summary>
    public partial class SupplierPriceListView : BaseListViewControl<SupplierPrice>
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

            SortMultiplier = 1;
        }
		#endregion

		#endregion

		#region Methods

        #region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
        protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }
        #endregion

        #endregion
    }
}
