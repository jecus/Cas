using System;
using System.Windows.Forms;
using CAS.UI.UIControls.NewGrid;
using CAS.UI.UIControls.SMSControls;
using SmartCore.CAA.Event;

namespace CAS.UI.UICAAControls.Event
{
	///<summary>
	/// список для отображения категорий нерутинных работ
	///</summary>
	public partial class CAAEventTypesListView : CommonGridViewControl
	{
		#region public EventTypesListView()
		///<summary>
		///</summary>
		public CAAEventTypesListView(): base()
		{
			InitializeComponent();
			DisableContectMenu();
		}
		#endregion

		#region public new SmsEventType SelectedItem
		/// <summary>
		/// Выбранный элемент
		/// </summary>
		public new CAASmsEventType SelectedItem
		{
			get
			{
				if (radGridView1.SelectedRows.Count == 1)
					return (radGridView1.SelectedRows[0].Tag as CAASmsEventType);
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
				var form = new CAASmsEventTypeForm(SelectedItem);
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
