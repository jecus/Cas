using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.NewGrid;
using SmartCore.Entities.Dictionaries;

namespace CAS.UI.UIControls.PersonnelControls
{
    ///<summary>
    /// список для отображения ордеров запроса
    ///</summary>
    public partial class SpecializationListView : BaseGridViewControl<Specialization>
    {
        #region Fields

        #endregion

        #region Constructors

        #region public SpecializationListView()
        ///<summary>
        ///</summary>
        public SpecializationListView()
        {
            InitializeComponent();
        }
        #endregion

        #endregion

        #region Methods

        #region protected override void SetHeaders()
        ///// <summary>
        ///// Устанавливает заголовки
        ///// </summary>
        //protected override void SetHeaders()
        //{
        //}
        #endregion

        #region protected override SetGroupsToItems()
        //protected override void SetGroupsToItems()
        //{
        //}

        #endregion

        #region protected override void SetItemColor(ListViewItem listViewItem, Specialization item)
        //protected override void SetItemColor(ListViewItem listViewItem, Specialization item)
        //{
        //}
        #endregion

        #region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Specialization item)

        //protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Specialization item)
        //{
           
        //}

        #endregion

        #region protected override void SortItems(int columnIndex)

        //protected override void SortItems(int columnIndex)
        //{
        //}

        #endregion

        #region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

        protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
        {
            if (SelectedItem != null)
            {
                e.Cancel = true;
                var form = new CommonEditorForm(SelectedItem);
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
