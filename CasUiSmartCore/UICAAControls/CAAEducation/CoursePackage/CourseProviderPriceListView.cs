using System;
using CAS.UI.UIControls.NewGrid;
using SmartCore.CAA.CAAWP;

namespace CAS.UI.UICAAControls.CAAEducation.CoursePackage
{
	///<summary>
	/// список для отображения ордеров запроса
	///</summary>
	public partial class CourseProviderPriceListView : BaseGridViewControl<CourseProviderPrice>
	{
		#region Fields

		#endregion

		#region Constructors

		#region public SupplierListViewNew()
		///<summary>
		///</summary>
		public CourseProviderPriceListView()
		{
			InitializeComponent();

			SortDirection = SortDirection.Desc;
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
