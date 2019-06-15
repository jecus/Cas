using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using CAS.UI.Management;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.NewGrid;
using SmartCore.Entities.General;
using SmartCore.Entities.General.WorkPackage;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.NonRoutineJobsControls
{
    ///<summary>
    /// список для отображения категорий нерутинных работ
    ///</summary>
    public partial class NonRoutineJobStatusListView : CommonGridViewControl
    {
	    #region public NonRoutineJobListViewNew(PropertyInfo beginGroup) : base(beginGroup)
        ///<summary>
        ///</summary>
        public NonRoutineJobStatusListView()
            : base()
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
                if (radGridView1.SelectedRows.Count == 1)
                    return (radGridView1.SelectedRows[0].Tag as NonRoutineJob);
                return null;
            }
        }
		#endregion

		#region Methods

		#region protected override void RadGridView1_DoubleClick(object sender, EventArgs e)
		protected override void RadGridView1_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedItem == null) return;
			var form = ScreenAndFormManager.GetEditForm(SelectedItem);

			if (form.ShowDialog() == DialogResult.OK)
			{
				var subs = GetListViewSubItems(SelectedItem);
				for (int i = 0; i < subs.Count; i++)
					radGridView1.SelectedRows[0].Cells[i].Value = subs[i].Text;
			}
		}
		#endregion

		#region protected override void SetItemColor(GridViewRowInfo listViewItem, BaseEntityObject item)

		protected override void SetItemColor(GridViewRowInfo listViewItem, BaseEntityObject item)
		{
		    var nrj = item as NonRoutineJob;
		    if (nrj == null) return;

		    if (nrj.AttachedFile == null)
		    {
			    listViewItem.Cells[1].Style.CustomizeFill = true;
				listViewItem.Cells[1].Style.ForeColor = Color.MediumVioletRed;
		    }
	    }

	    #endregion

	    #endregion
    }
}
