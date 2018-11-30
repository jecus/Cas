using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.WorkPakage;
using SmartCore.Entities.General;
using SmartCore.Entities.General.WorkPackage;

namespace CAS.UI.UIControls.NonRoutineJobsControls
{
	///<summary>
	/// список для отображения категорий нерутинных работ
	///</summary>
	public partial class NonRoutineJobCategoriesListView : CommonListViewControl
	{
		#region public NonRoutineJobCategoriesListView()
		///<summary>
		///</summary>
		public NonRoutineJobCategoriesListView()
		{
			InitializeComponent();
		}
		#endregion

		#region public NonRoutineJobCategoriesListView(PropertyInfo beginGroup) : base(beginGroup)
		///<summary>
		///</summary>
		public NonRoutineJobCategoriesListView(PropertyInfo beginGroup)
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

		#region protected override List<PropertyInfo> GetTypeProperties()
		protected override List<PropertyInfo> GetTypeProperties()
		{
			List<PropertyInfo> props = base.GetTypeProperties();
			PropertyInfo prop = props.FirstOrDefault(p => p.Name.ToLower() == "parentworkpackage");
			props.Remove(prop);

			return props;
		}
		#endregion

		#region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
		protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (SelectedItem != null)
			{
				NonRoutineJobForm form = new NonRoutineJobForm(SelectedItem);
				if (form.ShowDialog() == DialogResult.OK)
				{
					ListViewItem.ListViewSubItem[] subs = GetListViewSubItems(SelectedItem);
					for (int i = 0; i < subs.Length; i++)
						itemsListView.SelectedItems[0].SubItems[i].Text = subs[i].Text;
				}
			}
		}
		#endregion

		#region protected override void SetItemColor(ListViewItem listViewItem, BaseEntityObject item)

		protected override void SetItemColor(ListViewItem listViewItem, BaseEntityObject item)
		{
			var nrj = item as NonRoutineJob;
			if (nrj == null) return;

			if (nrj.AttachedFile != null)
			{
				if (nrj.BlockedByPackage != null)
				{
					listViewItem.ToolTipText = nrj.BlockedByPackage.Title;
					listViewItem.BackColor = Color.DarkGray;
					listViewItem.ForeColor = Color.Black;
				}
			}
			else
			{
				listViewItem.UseItemStyleForSubItems = false;
				for (int i = 0; i < listViewItem.SubItems.Count; i++)
				{
					if (nrj.BlockedByPackage != null)
					{
						listViewItem.ToolTipText = nrj.BlockedByPackage.Title;
						listViewItem.SubItems[i].BackColor = Color.DarkGray;
						listViewItem.SubItems[i].ForeColor = Color.Black;
					}
					else listViewItem.SubItems[i].BackColor = Color.White;

					if (i == 1)
						listViewItem.SubItems[i].ForeColor = Color.MediumVioletRed;
				}
			}
		}

		#endregion

		#endregion
	}
}
