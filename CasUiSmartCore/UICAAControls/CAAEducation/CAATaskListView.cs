using System;
using CAS.UI.UIControls.NewGrid;
using SmartCore.CAA.Tasks;

namespace CAS.UI.UICAAControls.CAAEducation
{
	///<summary>
	/// список для отображения событий системы безопасности полетов
	///</summary>
	public partial class CAATaskListView : CommonGridViewControl
	{
		#region public EventsListView()
		///<summary>
		///</summary>
		public CAATaskListView() : base()
		{
			InitializeComponent();
			DisableContectMenu();
		}
		#endregion

		#region public new Event SelectedItem
		/// <summary>
		/// Выбранный элемент
		/// </summary>
		public new CAATask SelectedItem
		{
			get
			{
				if (radGridView1.SelectedRows.Count == 1)
					return (radGridView1.SelectedRows[0].Tag as CAATask);
				return null;
			}
		}
		#endregion

		#region Methods

		#region protected override void RadGridView1_DoubleClick(object sender, EventArgs e)
		protected override void RadGridView1_DoubleClick(object sender, EventArgs e)
		{
			
		}
		#endregion

		#endregion
	}
}
