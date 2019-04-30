using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using SmartCore.Entities.General.WorkPackage;

namespace CAS.UI.UIControls.WorkPakage
{
    ///<summary>
    /// список для отображения ордеров запроса
    ///</summary>
    public partial class ProviderPriceListView : BaseListViewControl<ProviderPrice>
    {
        #region Fields

        #endregion

        #region Constructors

        #region public SupplierListViewNew()
        ///<summary>
        ///</summary>
        public ProviderPriceListView()
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
