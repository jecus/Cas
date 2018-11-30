using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using SmartCore.Entities.Dictionaries;

namespace CAS.UI.UIControls.SMSControls
{
    ///<summary>
    /// список для отображения категорий нерутинных работ
    ///</summary>
    public partial class EventTypesListView : CommonListViewControl
    {
        #region public EventTypesListView()
        ///<summary>
        ///</summary>
        public EventTypesListView()
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
                if (itemsListView.SelectedItems.Count == 1)
                    return (itemsListView.SelectedItems[0].Tag as SmsEventType);
                return null;
            }
        }
        #endregion

        #region Methods

        #region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
        protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SelectedItem != null)
            {
                SmsEventTypeForm form = new SmsEventTypeForm(SelectedItem);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ListViewItem.ListViewSubItem[] subs = GetListViewSubItems(SelectedItem);
                    for (int i = 0; i < subs.Length; i++)
                        itemsListView.SelectedItems[0].SubItems[i].Text = subs[i].Text;
                }
            }
        }
        #endregion

        #endregion
    }
}
