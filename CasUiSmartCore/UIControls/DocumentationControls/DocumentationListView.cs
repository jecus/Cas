using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Store;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.DocumentationControls
{
	///<summary>
	/// список для отображения документов
	///</summary>
	public partial class DocumentationListView : BaseGridViewControl<Document>
	{
		#region public DocumentationListView()
		///<summary>
		///</summary>
		public DocumentationListView()
		{
			InitializeComponent();
		}
		#endregion

		#region Methods

		#region protected override SetGroupsToItems()
	//    protected override void SetGroupsToItems(int columnIndex)
	//    {
	//        itemsListView.Groups.Clear();
	//        List<ListViewGroup> opGroups = new List<ListViewGroup>();
	//        List<ListViewGroup> aircraftGroups = new List<ListViewGroup>();
	   //     List<ListViewGroup> specialistGroups = new List<ListViewGroup>();

	//        foreach (ListViewItem item in ListViewItemList)
	//        {
	//            Document doc = (Document) item.Tag;
	//            ListViewGroup g = new ListViewGroup();
				//if (doc.ParentAircraftId > 0 && doc.Parent.ItemId <= 0)
		  //          doc.Parent = GlobalObjects.AircraftsCore.GetAircraftById(doc.ParentAircraftId);

	//            string groupName = doc.Parent + " " + doc.DocType;
	//            g.Name = groupName;
	//            g.Header = groupName;

	//            if (doc.Parent is Operator)
	//                opGroups.Add(g);
	//            if (doc.Parent is Aircraft)
	//                aircraftGroups.Add(g);
				//if (doc.Parent is Store)
				//	aircraftGroups.Add(g);
				//if (doc.Specialist != null)
	   //         {
		  //          groupName = $"{doc.Specialist.FirstName} {doc.Specialist.LastName} {doc.DocType}";
				//	g.Name = groupName;
		  //          g.Header = groupName;
				//	specialistGroups.Add(g);
				//}
	//        }
	//        itemsListView.Groups.AddRange(opGroups.ToArray());
	//        itemsListView.Groups.AddRange(aircraftGroups.ToArray());
	//        itemsListView.Groups.AddRange(specialistGroups.ToArray());

	//        foreach (ListViewItem item in ListViewItemList)
	//        {
	//            Document doc = (Document)item.Tag;
	   //         if (doc.Specialist != null)
	   //         {
				//	item.Group = itemsListView.Groups[$"{doc.Specialist.FirstName} {doc.Specialist.LastName} {doc.DocType}"];
				//}
				//else item.Group = itemsListView.Groups[doc.Parent + " " + doc.DocType];
	//        }
	//    }
		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetItemsString(Document item)

		protected override List<CustomCell> GetListViewSubItems(Document item)
		{
			Color? titleColor = null;
			if(!item.HaveFile)
				titleColor = Color.MediumVioletRed;

			var remainsString = item.Remains == null ? Lifelength.Null.ToString() : item.Remains.ToString();
			var revisionRemainsString = item.RevisionRemains == null ? Lifelength.Null.ToString() : item.RevisionRemains.ToString();

			var revisionDateValidFromString = item.Revision ? SmartCore.Auxiliary.Convert.GetDateFormat(item.RevisionDateFrom) : "";
			var revisionDateValidToString = item.RevisionValidTo ? SmartCore.Auxiliary.Convert.GetDateFormat(item.RevisionDateValidTo) : "";
			var issueDateValidToString = item.IssueValidTo ? SmartCore.Auxiliary.Convert.GetDateFormat(item.IssueDateValidTo) : "";
			var aboard = item.Aboard ? "Yes" : "No";
			var privy = item.Privy ? "Yes" : "No";
			var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);

			return new List<CustomCell>()
			{
				CreateRow(item.DocType.FullName, item.DocType.FullName),
				CreateRow(item.DocumentSubType.FullName, item.DocumentSubType.FullName, titleColor),
				CreateRow(item.ContractNumber, item.ContractNumber),
				CreateRow(item.Description, item.Description),
				CreateRow(SmartCore.Auxiliary.Convert.GetDateFormat(item.IssueDateValidFrom), item.IssueDateValidFrom),
				CreateRow(item.IssueNumber, item.IssueNumber),
				CreateRow(issueDateValidToString, item.IssueDateValidTo),
				CreateRow(remainsString, remainsString),
				CreateRow(revisionDateValidFromString, item.RevisionDateFrom),
				CreateRow(item.RevisionNumder, item.RevisionNumder),
				CreateRow(revisionDateValidToString, item.RevisionDateValidTo),
				CreateRow(revisionRemainsString, revisionRemainsString),
				CreateRow(item.Department.FullName, item.Department.FullName),
				CreateRow(item.ResponsibleOccupation.FullName, item.ResponsibleOccupation.FullName),
				CreateRow(item.ServiceType.FullName, item.ServiceType.FullName),
				CreateRow(aboard, aboard),
				CreateRow(privy, privy),
				CreateRow(item.Nomenсlature.ToString(), item.Nomenсlature.ToString()),
				CreateRow(item.Location.ToString(), item.Location.ToString()),
				CreateRow(item.ProlongationWay.ToString(), item.ProlongationWay.ToString()),
				CreateRow(item.Supplier.ToString(), item.Supplier),
				CreateRow(item.Status.FullName, item.Status.FullName),
				CreateRow(item.IdNumber, item.IdNumber),
				CreateRow(item.Remarks, item.Remarks),
				CreateRow(author, author)
			};
		}

		#endregion

		#region protected override void SetHeaders()
		///// <summary>
		///// Устанавливает заголовки
		///// </summary>
		protected override void SetHeaders()
		{
			AddColumn("Type", (int)(radGridView1.Width * 0.20f));
			AddColumn("Title", (int)(radGridView1.Width * 0.20f));
			AddColumn("№", (int)(radGridView1.Width * 0.20f));
			AddColumn("Description", (int)(radGridView1.Width * 0.20f));
			AddColumn("Issue", (int)(radGridView1.Width * 0.14f));
			AddColumn("№ Issue", (int)(radGridView1.Width * 0.06f));
			AddColumn("Valid To", (int)(radGridView1.Width * 0.14f));
			AddColumn("Remain", (int)(radGridView1.Width * 0.20f));
			AddColumn("Rev.Date", (int)(radGridView1.Width * 0.14f));
			AddColumn("№ Rev.", (int)(radGridView1.Width * 0.06f));
			AddColumn("Valid To", (int)(radGridView1.Width * 0.14f));
			AddColumn("Remain", (int)(radGridView1.Width * 0.20f));
			AddColumn("Department", (int)(radGridView1.Width * 0.20f));
			AddColumn("Responsible", (int)(radGridView1.Width * 0.20f));
			AddColumn("Service Type", (int)(radGridView1.Width * 0.20f));
			AddColumn("Aboard", (int)(radGridView1.Width * 0.08f));
			AddColumn("Privy", (int)(radGridView1.Width * 0.08f));
			AddColumn("Nomenclature", (int)(radGridView1.Width * 0.20f));
			AddColumn("Location", (int)(radGridView1.Width * 0.20f));
			AddColumn("Prolongation", (int)(radGridView1.Width * 0.20f));
			AddColumn("Contractor", (int)(radGridView1.Width * 0.20f));
			AddColumn("Status", (int)(radGridView1.Width * 0.08f));
			AddColumn("ID №", (int)(radGridView1.Width * 0.20f));
			AddColumn("Remarks", (int)(radGridView1.Width * 0.20f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.02f));
		}
		#endregion

		#region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
		protected override void RadGridView1_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedItem != null)
			{
				DocumentForm form = new DocumentForm(SelectedItem);
				if (form.ShowDialog() == DialogResult.OK)
				{
					GlobalObjects.PerformanceCalculator.GetNextPerformance(SelectedItem);
					var subs = GetListViewSubItems(SelectedItem);
					for (int i = 0; i < subs.Count; i++)
						radGridView1.SelectedRows[0].Cells[i].Value = subs[i].Text;
				}
			}
		}
		#endregion

		#region protected override void SetItemColor(GridViewRowInfo listViewItem, Document item)

		protected override void SetItemColor(GridViewRowInfo listViewItem, Document item)
		{
			var itemBackColor = UsefulMethods.GetColor(item);
			var itemForeColor = Color.Gray;

			foreach (GridViewCellInfo cell in listViewItem.Cells)
			{
				cell.Style.DrawFill = true;
				cell.Style.CustomizeFill = true;
				cell.Style.BackColor = UsefulMethods.GetColor(item);

				var listViewForeColor = cell.Style.ForeColor;

				if (listViewForeColor != Color.MediumVioletRed)
					cell.Style.ForeColor = itemForeColor;
				cell.Style.BackColor = itemBackColor;
			}
		}


		#endregion

		#endregion
	}
}
