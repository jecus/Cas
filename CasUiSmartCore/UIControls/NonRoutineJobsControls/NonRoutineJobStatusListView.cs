using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using CAS.UI.Management;
using CAS.UI.UIControls.Auxiliary;
using SmartCore.Entities.General;
using SmartCore.Entities.General.WorkPackage;

namespace CAS.UI.UIControls.NonRoutineJobsControls
{
    ///<summary>
    /// список для отображения категорий нерутинных работ
    ///</summary>
    public partial class NonRoutineJobStatusListView : CommonListViewControl
    {
        #region public NonRoutineJobListViewNew()
        ///<summary>
        ///</summary>
        public NonRoutineJobStatusListView()
        {
            InitializeComponent();
        }
        #endregion

        #region public NonRoutineJobListViewNew(PropertyInfo beginGroup) : base(beginGroup)
        ///<summary>
        ///</summary>
        public NonRoutineJobStatusListView(PropertyInfo beginGroup)
            : base(beginGroup)
        {
            InitializeComponent();
        }
        #endregion

        #region public new NonRoutineJob SelectedItem
        /// <summary>
        /// Выбранный элемент
        /// </summary>
        public new NonRoutineJob SelectedItem
        {
            get
            {
                if (itemsListView.SelectedItems.Count == 1)
                    return (itemsListView.SelectedItems[0].Tag as NonRoutineJob);
                return null;
            }
        }
        #endregion

        #region Methods

        #region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
        protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
        {
			if (SelectedItem == null) return;
			var form = ScreenAndFormManager.GetEditForm(SelectedItem);

			if (form.ShowDialog() == DialogResult.OK)
			{
				ListViewItem.ListViewSubItem[] subs = GetListViewSubItems(SelectedItem);
				for (int i = 0; i < subs.Length; i++)
					itemsListView.SelectedItems[0].SubItems[i].Text = subs[i].Text;
			}
		}
		#endregion

		#region protected override void SetItemColor(ListViewItem listViewItem, BaseEntityObject item)

		protected override void SetItemColor(ListViewItem listViewItem, BaseEntityObject item)
	    {
		    var nrj = item as NonRoutineJob;
		    if (nrj == null) return;

		    listViewItem.UseItemStyleForSubItems = false;

		    if (nrj.AttachedFile == null)
			    listViewItem.SubItems[1].ForeColor = Color.MediumVioletRed;
	    }

	    #endregion

	    #endregion
    }
}
