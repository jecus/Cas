using System;
using System.Windows.Forms;
using CAS.UI.UIControls.NewGrid;
using SmartCore.Entities.Dictionaries;

namespace CAS.UI.UIControls.SMSControls
{
    ///<summary>
    /// список для отображения категорий нерутинных работ
    ///</summary>
    public partial class EventTypesListView : CommonGridViewControl
    {
        #region public EventTypesListView()
        ///<summary>
        ///</summary>
        public EventTypesListView(): base()
        {
            InitializeComponent();
        }
        #endregion

        #region public new SmsEventType SelectedItem
        /// <summary>
        /// Выбранный элемент
        /// </summary>
        public new SmsEventType SelectedItem
        {
            get
            {
                if (radGridView1.SelectedRows.Count == 1)
                    return (radGridView1.SelectedRows[0].Tag as SmsEventType);
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
                var form = new SmsEventTypeForm(SelectedItem);
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
