using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.NewGrid;
using CAS.UI.UIControls.Users;
using CASTerms;
using SmartCore.CAA;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UICAAControls.Users
{
	///<summary>
	/// список для отображения документов
	///</summary>
	public partial class CAAUserListView : BaseGridViewControl<CAAUser>
	{
		#region public CAAUserListView()
		public CAAUserListView()
		{
			SortDirection = SortDirection.Desc;
			InitializeComponent();
		}

		public CommonCollection<Specialist> Specialists { get; set; }
		public AnimatedThreadWorker AnimatedThreadWorker { get; set; }

		#endregion

		#region Methods

		#region protected override SetGroupsToItems()
		protected override void GroupingItems()
		{
			Grouping("User Type");
		}
		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetItemsString(Document item)

		protected override List<CustomCell> GetListViewSubItems(CAAUser item)
		{
			var userName = $"{item.Surname} {item.Name}";
			var op = (GlobalObjects.CaaEnvironment.AllOperators.FirstOrDefault(
                i => i.ItemId == item.Personnel?.OperatorId) ?? AllOperators.Unknown).ToString();

            if (item.Personnel.IsCAA)
                op = "CAA";
			var subItems = new List<CustomCell>()
			{
				CreateRow(userName,userName),
				CreateRow(item.Login,item.Login),
				CreateRow(item.Password,item.Password),
				CreateRow(item.Personnel.ToString(),item.Personnel),
				CreateRow(op,op),
				CreateRow(item.UserType.ToString(),item.UserType),
				CreateRow(item.UiType.ToString(),item.UiType),
			};

			return subItems;
		}

		#endregion

		#region protected override void SetHeaders()
		///// <summary>
		///// Устанавливает заголовки
		///// </summary>
		protected override void SetHeaders()
		{
			AddColumn("UserName", (int)(radGridView1.Width * 0.20f));
			AddColumn("Login", (int)(radGridView1.Width * 0.20f));
			AddColumn("Password", (int)(radGridView1.Width * 0.20f));
			AddColumn("Personnel", (int)(radGridView1.Width * 0.20f));
			AddColumn("Operator", (int)(radGridView1.Width * 0.20f));
			AddColumn("User Type", (int)(radGridView1.Width * 0.20f));
			AddColumn("Ui Type", (int)(radGridView1.Width * 0.20f));
		}
		#endregion

		#region protected override void RadGridView1_DoubleClick(object sender, EventArgs e)
		protected override void RadGridView1_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedItem != null)
			{
                var form = new CAAUserForm(SelectedItem, Specialists);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var subs = GetListViewSubItems(SelectedItem);
                    for (int i = 0; i < subs.Count; i++)
                        radGridView1.SelectedRows[0].Cells[i].Value = subs[i].Text;

                    AnimatedThreadWorker.RunWorkerAsync();
                }
            }
		}
		#endregion

		#endregion
	}
}
