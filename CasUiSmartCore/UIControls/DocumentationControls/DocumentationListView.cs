using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.Store;

namespace CAS.UI.UIControls.DocumentationControls
{
    ///<summary>
    /// список для отображения документов
    ///</summary>
    public partial class DocumentationListView : BaseListViewControl<Document>
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
        protected override void SetGroupsToItems(int columnIndex)
        {
            itemsListView.Groups.Clear();
            List<ListViewGroup> opGroups = new List<ListViewGroup>();
            List<ListViewGroup> aircraftGroups = new List<ListViewGroup>();
	        List<ListViewGroup> specialistGroups = new List<ListViewGroup>();

            foreach (ListViewItem item in ListViewItemList)
            {
                Document doc = (Document) item.Tag;
                ListViewGroup g = new ListViewGroup();
				if (doc.ParentAircraftId > 0 && doc.Parent.ItemId <= 0)
		            doc.Parent = GlobalObjects.AircraftsCore.GetAircraftById(doc.ParentAircraftId);

                string groupName = doc.Parent + " " + doc.DocType;
                g.Name = groupName;
                g.Header = groupName;

                if (doc.Parent is Operator)
                    opGroups.Add(g);
                if (doc.Parent is Aircraft)
                    aircraftGroups.Add(g);
				if (doc.Parent is Store)
					aircraftGroups.Add(g);
				if (doc.Specialist != null)
	            {
		            groupName = $"{doc.Specialist.FirstName} {doc.Specialist.LastName} {doc.DocType}";
					g.Name = groupName;
		            g.Header = groupName;
					specialistGroups.Add(g);
				}
            }
            itemsListView.Groups.AddRange(opGroups.ToArray());
            itemsListView.Groups.AddRange(aircraftGroups.ToArray());
            itemsListView.Groups.AddRange(specialistGroups.ToArray());

            foreach (ListViewItem item in ListViewItemList)
            {
                Document doc = (Document)item.Tag;
	            if (doc.Specialist != null)
	            {
					item.Group = itemsListView.Groups[$"{doc.Specialist.FirstName} {doc.Specialist.LastName} {doc.DocType}"];
				}
				else item.Group = itemsListView.Groups[doc.Parent + " " + doc.DocType];
            }
        }
		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetItemsString(Document item)

		protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Document item)
		{
			var subItems = new List<ListViewItem.ListViewSubItem>();

			var titleColor = itemsListView.ForeColor;
			if(!item.HaveFile)
				titleColor = Color.MediumVioletRed;

			var remainsString = item.Remains == null ? Lifelength.Null.ToString() : item.Remains.ToString();
			var revisionRemainsString = item.RevisionRemains == null ? Lifelength.Null.ToString() : item.RevisionRemains.ToString();

			var revisionDateValidFromString = item.Revision ? SmartCore.Auxiliary.Convert.GetDateFormat(item.RevisionDateFrom) : "";
			var revisionDateValidToString = item.RevisionValidTo ? SmartCore.Auxiliary.Convert.GetDateFormat(item.RevisionDateValidTo) : "";
			var issueDateValidToString = item.IssueValidTo ? SmartCore.Auxiliary.Convert.GetDateFormat(item.IssueDateValidTo) : "";
			var aboard = item.Aboard ? "Yes" : "No";
			var privy = item.Privy ? "Yes" : "No";

			subItems.Add(new ListViewItem.ListViewSubItem {Text = item.DocType.FullName, Tag = item.DocType.FullName });
			subItems.Add(new ListViewItem.ListViewSubItem {Text = item.DocumentSubType.FullName, Tag = item.DocumentSubType.FullName, ForeColor = titleColor });
			subItems.Add(new ListViewItem.ListViewSubItem {Text = item.ContractNumber, Tag = item.ContractNumber });
			subItems.Add(new ListViewItem.ListViewSubItem {Text = item.Description, Tag = item.Description });
			subItems.Add(new ListViewItem.ListViewSubItem {Text = SmartCore.Auxiliary.Convert.GetDateFormat(item.IssueDateValidFrom), Tag = item.IssueDateValidFrom });
			subItems.Add(new ListViewItem.ListViewSubItem {Text = item.IssueNumber, Tag = item.IssueNumber });
			subItems.Add(new ListViewItem.ListViewSubItem {Text = issueDateValidToString, Tag = item.IssueDateValidTo });
			subItems.Add(new ListViewItem.ListViewSubItem {Text = remainsString, Tag = remainsString });
			subItems.Add(new ListViewItem.ListViewSubItem {Text = revisionDateValidFromString, Tag = item.RevisionDateFrom });
			subItems.Add(new ListViewItem.ListViewSubItem {Text = item.RevisionNumder, Tag = item.RevisionNumder });
			subItems.Add(new ListViewItem.ListViewSubItem {Text = revisionDateValidToString, Tag = item.RevisionDateValidTo });
			subItems.Add(new ListViewItem.ListViewSubItem {Text = revisionRemainsString, Tag = revisionRemainsString });
			subItems.Add(new ListViewItem.ListViewSubItem {Text = item.Department.FullName, Tag = item.Department.FullName });
			subItems.Add(new ListViewItem.ListViewSubItem {Text = item.ResponsibleOccupation.FullName, Tag = item.ResponsibleOccupation.FullName });
			subItems.Add(new ListViewItem.ListViewSubItem {Text = item.ServiceType.FullName, Tag = item.ServiceType.FullName });
			subItems.Add(new ListViewItem.ListViewSubItem {Text = aboard, Tag = aboard });
			subItems.Add(new ListViewItem.ListViewSubItem {Text = privy, Tag = privy });
			subItems.Add(new ListViewItem.ListViewSubItem {Text = item.Nomenсlature.ToString(), Tag = item.Nomenсlature.ToString() });
			subItems.Add(new ListViewItem.ListViewSubItem {Text = item.Location.ToString(), Tag = item.Location.ToString() });
			subItems.Add(new ListViewItem.ListViewSubItem {Text = item.ProlongationWay.ToString(), Tag = item.ProlongationWay.ToString() });
			subItems.Add(new ListViewItem.ListViewSubItem {Text = item.Supplier.ToString(), Tag = item.Supplier });
			subItems.Add(new ListViewItem.ListViewSubItem {Text = item.Status.FullName, Tag = item.Status.FullName });
			subItems.Add(new ListViewItem.ListViewSubItem {Text = item.Remarks, Tag = item.Remarks });

			return subItems.ToArray();
		}

		#endregion

		#region protected override void SetHeaders()
		///// <summary>
		///// Устанавливает заголовки
		///// </summary>
		protected override void SetHeaders()
		{
			ColumnHeaderList.Clear();

			var columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Type" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Title" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "№" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Description" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.07f), Text = "Issue" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.03f), Text = "№ Issue" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.07f), Text = "Valid To" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Remain" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.07f), Text = "Rev.Date" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.03f), Text = "№ Rev." };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.07f), Text = "Valid To" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Remain" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Department" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Responsible" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Service Type" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.04f), Text = "Aboard" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.04f), Text = "Privy" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Nomenclature" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Location" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Prolongation" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Contractor" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.04f), Text = "Status" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "Remarks" };
			ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
		}
		#endregion

		#region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
		protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SelectedItem != null)
            {
                DocumentForm form = new DocumentForm(SelectedItem);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    GlobalObjects.PerformanceCalculator.GetNextPerformance(SelectedItem);
                    ListViewItem.ListViewSubItem[] subs = GetListViewSubItems(SelectedItem);
                    for (int i = 0; i < subs.Length; i++)
                        itemsListView.SelectedItems[0].SubItems[i].Text = subs[i].Text;
                }
                itemsListView.SelectedItems[0].Group = itemsListView.Groups[SelectedItem.Parent + " " + SelectedItem.DocType];
            }
        }
        #endregion

		#region protected override void SetItemColor(ListViewItem listViewItem, MaintenanceDirective item)
		protected override void SetItemColor(ListViewItem listViewItem, Document item)
		{
			var itemBackColor = UsefulMethods.GetColor(item);
			var itemForeColor = Color.Gray;

			listViewItem.BackColor = UsefulMethods.GetColor(item);

			var listViewForeColor = ItemListView.ForeColor;
			var listViewBackColor = ItemListView.BackColor;

			if (listViewItem.SubItems.OfType<ListViewItem.ListViewSubItem>().All(lvsi => lvsi.ForeColor.ToArgb() == listViewForeColor.ToArgb()
																						 && lvsi.BackColor.ToArgb() == listViewBackColor.ToArgb()))
			{
				listViewItem.ForeColor = itemForeColor;
				listViewItem.BackColor = itemBackColor;
			}
			else
			{
				listViewItem.UseItemStyleForSubItems = false;
				foreach (ListViewItem.ListViewSubItem subItem in listViewItem.SubItems)
				{
					if (subItem.ForeColor.ToArgb() == listViewForeColor.ToArgb())
						subItem.ForeColor = itemForeColor;
					if (subItem.BackColor.ToArgb() == listViewBackColor.ToArgb())
						subItem.BackColor = itemBackColor;
				}
			}
		}
		#endregion

		#endregion
	}
}
