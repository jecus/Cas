using System.Reflection;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using SmartCore.Entities.General.SMS;

namespace CAS.UI.UIControls.SMSControls
{
    ///<summary>
    /// список для отображения событий системы безопасности полетов
    ///</summary>
    public partial class EventsListView : CommonListViewControl
    {
        #region public EventsListView()
        ///<summary>
        ///</summary>
        public EventsListView()
        {
            InitializeComponent();
        }
        #endregion

        #region public EventsListView(PropertyInfo beginGroup) : base(beginGroup)
        ///<summary>
        ///</summary>
        public EventsListView(PropertyInfo beginGroup) : base(beginGroup)
        {
            InitializeComponent();
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
                if (itemsListView.SelectedItems.Count == 1)
                    return (itemsListView.SelectedItems[0].Tag as Event);
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
                SmsEventForm form = new SmsEventForm(SelectedItem);
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
