using System;
using System.Windows.Forms;
using CAS.UI.UIControls.NewGrid;
using CAS.UI.UIControls.SupplierControls;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Purchase;

namespace CAS.UI.UICAAControls.Suppliers
{
	///<summary>
	/// список для отображения ордеров запроса
	///</summary>
	public partial class CAASupplierCourseListView : BaseGridViewControl<SupplierCourse>
	{
		#region Fields

		#endregion

		#region Constructors

		#region public SupplierListViewNew()
		///<summary>
		///</summary>
		public CAASupplierCourseListView()
		{
			InitializeComponent();
			SortDirection = SortDirection.Asc;
			OldColumnIndex = 0;
			EnableCustomSorting = true;
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


	public class SupplierCourse : BaseEntityObject
	{
		
		[ListViewData(0.1f, "No")]
		public string No { get; set; }
		
		[ListViewData(0.2f, "Title")]
		public string Title { get; set; }

		[ListViewData(0.1f, "Total Cost")]
		public decimal? Total { get; set; }

		[ListViewData(0.1f, "Cost Per One")]
		public decimal? PerOne { get; set; }

		[ListViewData(0.1f, "Currency")]
		public string Currency { get; set; }

		[ListViewData(0.2f, "Duration")]
		public string Duration { get; set; }

		[ListViewData(0.2f, "Location")]
		public string Location { get; set; }
	}
}



