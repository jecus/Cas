using System;
using System.Windows.Forms;
using CAS.UI.UIControls.NewGrid;
using SmartCore.Entities.General.SMS;

namespace CAS.UI.UIControls.SMSControls
{
	///<summary>
	/// список для отображения событий системы безопасности полетов
	///</summary>
	public partial class EventsListView : CommonGridViewControl
	{
		#region public EventsListView()
		///<summary>
		///</summary>
		public EventsListView() : base()
		{
			InitializeComponent();
			DisableContectMenu();
		}
		#endregion

		#region public new Event SelectedItem
		/// <summary>
		/// Выбранный элемент
		/// </summary>
		public new Event SelectedItem
		{
			get
			{
				if (radGridView1.SelectedRows.Count == 1)
					return (radGridView1.SelectedRows[0].Tag as Event);
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
				var form = new SmsEventForm(SelectedItem);
				if (form.ShowDialog() == DialogResult.OK)
				{
					var subs = GetListViewSubItems(SelectedItem);
					for (int i = 0; i < subs.Count; i++)
						radGridView1.SelectedRows[0].Cells[i].Value = subs[i].Text;
				}
			}
		}
		#endregion

		#endregion
	}
}
