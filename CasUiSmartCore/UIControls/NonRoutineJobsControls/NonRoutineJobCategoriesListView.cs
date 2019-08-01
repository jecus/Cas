using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CAS.UI.UIControls.NewGrid;
using CAS.UI.UIControls.WorkPakage;
using SmartCore.Entities.General;
using SmartCore.Entities.General.WorkPackage;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.NonRoutineJobsControls
{
	///<summary>
	/// список для отображения категорий нерутинных работ
	///</summary>
	public partial class NonRoutineJobCategoriesListView : CommonGridViewControl
	{

		#region public NonRoutineJobCategoriesListView()
		///<summary>
		///</summary>
		public NonRoutineJobCategoriesListView()
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

		#region protected override List<PropertyInfo> GetTypeProperties()
		protected override List<PropertyInfo> GetTypeProperties()
		{
			var props = base.GetTypeProperties();
			var prop = props.FirstOrDefault(p => p.Name.ToLower() == "parentworkpackage");
			props.Remove(prop);

			return props;
		}
		#endregion

		#region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
		protected override void RadGridView1_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedItem != null)
			{
				var form = new NonRoutineJobForm(SelectedItem);
				if (form.ShowDialog() == DialogResult.OK)
				{
					var subs = GetListViewSubItems(SelectedItem);
					for (var i = 0; i < subs.Count; i++)
						radGridView1.SelectedRows[0].Cells[i].Value = subs[i].Text;
				}
			}
		}
		#endregion

		#region protected override void SetItemColor(ListViewItem listViewItem, BaseEntityObject item)

		protected override void SetItemColor(GridViewRowInfo listViewItem, BaseEntityObject item)
		{
			var nrj = item as NonRoutineJob;
			if (nrj == null) return;

			if (nrj.AttachedFile != null)
			{
				if (nrj.BlockedByPackage != null)
				{
					foreach (GridViewCellInfo cell in listViewItem.Cells)
					{
						cell.Style.CustomizeFill = true;
						cell.Style.BackColor = Color.DarkGray; 
						cell.Style.ForeColor = Color.Black;
					}
				}
			}
			else
			{
				for (var i = 0; i < listViewItem.Cells.Count; i++)
				{
					listViewItem.Cells[i].Style.CustomizeFill = true;
					if (nrj.BlockedByPackage != null)
					{
						listViewItem.Cells[i].Style.BackColor = Color.DarkGray;
						listViewItem.Cells[i].Style.ForeColor = Color.Black;
					}
					else listViewItem.Cells[i].Style.BackColor = Color.White;

					if (i == 1)
						listViewItem.Cells[i].Style.ForeColor = Color.MediumVioletRed;
				}
			}
		}

		#endregion

		#endregion
	}
}
