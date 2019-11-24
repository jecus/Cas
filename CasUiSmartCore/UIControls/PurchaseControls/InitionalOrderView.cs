using System;
using CAS.UI.UIControls.NewGrid;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls
{
    ///<summary>
    /// список для отображения категорий нерутинных работ
    ///</summary>
    public partial class InitionalOrderView : BaseGridViewControl<InitialOrderRecord>
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

		
        #region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)

        /// <summary>
        /// Реагирует на двойной щелчок в списке элементов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void RadGridView1_DoubleClick(object sender, EventArgs e)
		{
            if (SelectedItem == null) return;

            InitialOrderRecordForm form = new InitialOrderRecordForm(SelectedItem);
            form.ShowDialog();
        }
        #endregion

        #endregion
    }
}
