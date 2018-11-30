using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.SupplierControls
{
    ///<summary>
    /// список для отображения ордеров запроса
    ///</summary>
    public partial class SupplierListView : BaseListViewControl<Supplier>
    {
        #region Fields

        #endregion

        #region Constructors

        #region public SupplierListViewNew()
        ///<summary>
        ///</summary>
        public SupplierListView()
        {
            InitializeComponent();

            SortMultiplier = 1;
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
		//    ColumnHeaderList.Clear();
		//    ColumnHeader columnHeader;
		//    columnHeader = new ColumnHeader();
		//    columnHeader.Width = (int)(ItemsListView.Width * _headerWidth[0]);
		//    columnHeader.Text = "Name";
		//    ColumnHeaderList.Add(columnHeader);

		//    columnHeader = new ColumnHeader();
		//    columnHeader.Width = (int)(ItemsListView.Width * _headerWidth[1]);
		//    columnHeader.Text = "ShortName";
		//    ColumnHeaderList.Add(columnHeader);

		//    columnHeader = new ColumnHeader();
		//    columnHeader.Width = (int)(ItemsListView.Width * _headerWidth[2]);
		//    columnHeader.Text = "Vendor Code";
		//    ColumnHeaderList.Add(columnHeader);

		//    columnHeader = new ColumnHeader();
		//    columnHeader.Width = (int)(ItemsListView.Width * _headerWidth[3]);
		//    columnHeader.Text = "Phone";
		//    ColumnHeaderList.Add(columnHeader);

		//    columnHeader = new ColumnHeader();
		//    columnHeader.Width = (int)(ItemsListView.Width * _headerWidth[4]);
		//    columnHeader.Text = "Fax";
		//    ColumnHeaderList.Add(columnHeader);

		//    columnHeader = new ColumnHeader();
		//    columnHeader.Width = (int)(ItemsListView.Width * _headerWidth[5]);
		//    columnHeader.Text = "Address";
		//    ColumnHeaderList.Add(columnHeader);

		//    columnHeader = new ColumnHeader();
		//    columnHeader.Width = (int)(ItemsListView.Width * _headerWidth[6]);
		//    columnHeader.Text = "Contact Person";
		//    ColumnHeaderList.Add(columnHeader);

		//    columnHeader = new ColumnHeader();
		//    columnHeader.Width = (int)(ItemsListView.Width * _headerWidth[7]);
		//    columnHeader.Text = "Email";
		//    ColumnHeaderList.Add(columnHeader);

		//    columnHeader = new ColumnHeader();
		//    columnHeader.Width = (int)(ItemsListView.Width * _headerWidth[8]);
		//    columnHeader.Text = "Web Site";
		//    ColumnHeaderList.Add(columnHeader);

		//    columnHeader = new ColumnHeader();
		//    columnHeader.Width = (int)(ItemsListView.Width * _headerWidth[9]);
		//    columnHeader.Text = "Products";
		//    ColumnHeaderList.Add(columnHeader);

		//    columnHeader = new ColumnHeader();
		//    columnHeader.Width = (int)(ItemsListView.Width * _headerWidth[10]);
		//    columnHeader.Text = "Status";
		//    ColumnHeaderList.Add(columnHeader);

		//    columnHeader = new ColumnHeader();
		//    columnHeader.Width = (int)(ItemsListView.Width * _headerWidth[11]);
		//    columnHeader.Text = "Approved";
		//    ColumnHeaderList.Add(columnHeader);

		//    columnHeader = new ColumnHeader();
		//    columnHeader.Width = (int)(ItemsListView.Width * _headerWidth[12]);
		//    columnHeader.Text = "Remarks";
		//    ColumnHeaderList.Add(columnHeader);

		//    ItemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
		//}
		#endregion

		#region protected override SetGroupsToItems(int columnIndex)
		protected override void SetGroupsToItems(int columnIndex)
        {
        }
        #endregion

        #region protected override void SetItemColor(ListViewItem listViewItem, Supplier item)
        //protected override void SetItemColor(ListViewItem listViewItem, Supplier item)
        //{
        //}
        #endregion

        #region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Supplier item)

        //protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Supplier item)
        //{
        //    List<ListViewItem.ListViewSubItem> subItems = new List<ListViewItem.ListViewSubItem>();

        //    //////////////////////////////////////////////////////////////////////////////////////
        //    //         Определение последнего выполнения директивы и KitRequiered               //
        //    //////////////////////////////////////////////////////////////////////////////////////
        //    DateTime defaultDateTime = new DateTime(1950,1,1);
        //    DateTime lastComplianceDate = defaultDateTime;
        //    DateTime nextComplianceDate = defaultDateTime;
        //    Lifelength lastComplianceLifeLength = Lifelength.Zero;
        //    //Lifelength nextComplianceLifelength = Lifelength.Null;

        //    string lastPerformanceString, firstPerformanceString = "N/A";

        //    AtaChapter ata = item.ATAChapter;
        //    if(item.LastPerformance != null)
        //    {
        //        lastComplianceDate = item.LastPerformance.RecordDate;
        //        lastComplianceLifeLength = item.LastPerformance.OnLifelength;    
        //    }
        //    if (item.Threshold.FirstPerformanceSinceNew != null && !item.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
        //    {
        //        firstPerformanceString = "s/n: " + item.Threshold.FirstPerformanceSinceNew;
        //    }
        //    if (item.Threshold.FirstPerformanceSinceEffectiveDate != null &&
        //        !item.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
        //    {
        //        if (firstPerformanceString != "N/A") firstPerformanceString += " or ";
        //        else firstPerformanceString = "";
        //        firstPerformanceString += "s/e.d: " + item.Threshold.FirstPerformanceSinceEffectiveDate;
        //    }

        //    //if (item.BindDetailDirectives.Count == 0)
        //    //{
        //        if (item.NextComplianceDate != null && item.NextComplianceDate > defaultDateTime)
        //            nextComplianceDate = Convert.ToDateTime(item.NextComplianceDate);
        //    //    nextComplianceLifelength = item.NextCompliance;
        //    //}
        //    //else
        //    //{
        //    //    DetailDirective firstLimitter =
        //    //            item.BindDetailDirectives.Where(bdd => bdd.NextComplianceDate != null &&
        //    //                                                   bdd.NextComplianceDate > defaultDateTime)
        //    //                                     .OrderBy(d => d)
        //    //                                     .FirstOrDefault();
        //    //    if (firstLimitter != null)
        //    //    {
        //    //        nextComplianceDate = Convert.ToDateTime(firstLimitter.NextComplianceDate);
        //    //        nextComplianceLifelength = firstLimitter.NextCompliance;
        //    //    }
        //    //}

        //    string kitRequieredString = item.Kits.Count + " kits";
        //    string ndtString = item.NonDestructiveTest ? "Y" : "N";
        //    string remarksString = item.Remarks;
        //    string hiddenRemarksString = item.HiddenRemarks;

        //    if (lastComplianceDate <= defaultDateTime)
        //        lastPerformanceString = "N/A";
        //    else
        //        lastPerformanceString = SmartCore.Auxiliary.Convert.GetDateFormat(lastComplianceDate) + " " +
        //                                lastComplianceLifeLength;
        //    string nextComplianceString = ((nextComplianceDate <= defaultDateTime)
        //                                       ? ""
        //                                       : SmartCore.Auxiliary.Convert.GetDateFormat(nextComplianceDate) + " ") +
        //                                  item.NextPerformanceSource;
        //    string nextRemainString = item.Remains != null && !item.Remains.IsNullOrZero()
        //                                  ? item.Remains.ToString()
        //                                  : "N/A";

        //    //////////////////////////////////////////////////////////////////////////////////////
        //    string description = item.Description != "" ? item.Description : "N/A";
        //    string taskNumber = item.MPDTaskNumber != "" ? item.MPDTaskNumber : "N/A";
        //    string taskCheck = item.TaskNumberCheck != "" ? item.TaskNumberCheck : "N/A";
        //    string maintManual = item.MaintenanceManual != "" ? item.MaintenanceManual : "N/A";
        //    string mrb = item.MRB != "" ? item.MRB : "N/A";
        //    string check = item.MaintenanceCheck != null ? item.MaintenanceCheck.Name : "N/A";
        //    DirectiveStatus status = item.Status;

        //    subItems.Add( new ListViewItem.ListViewSubItem { Text = taskCheck, Tag = taskCheck } );
        //    subItems.Add(new ListViewItem.ListViewSubItem { Text = item.TaskCardNumber, Tag = item.TaskCardNumber });
        //    subItems.Add(new ListViewItem.ListViewSubItem { Text = description, Tag = description });
        //    subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Program.ToString(), Tag = item.Program });
        //    subItems.Add(new ListViewItem.ListViewSubItem { Text = item.WorkType.ToString(), Tag = item.WorkType });
        //    subItems.Add(new ListViewItem.ListViewSubItem { Text = check, Tag = check });
        //    subItems.Add(new ListViewItem.ListViewSubItem { Text = firstPerformanceString, Tag = firstPerformanceString });
        //    subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Threshold.RepeatInterval.ToString(), Tag = item.Threshold.RepeatInterval });
        //    subItems.Add(new ListViewItem.ListViewSubItem { Text = nextComplianceString, Tag = nextComplianceDate });
        //    subItems.Add(new ListViewItem.ListViewSubItem { Text = nextRemainString, Tag = nextRemainString });
        //    subItems.Add(new ListViewItem.ListViewSubItem { Text = lastPerformanceString, Tag = lastComplianceDate });
        //    subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Zone, Tag = item.Zone });
        //    subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Access, Tag = item.Access });
        //    subItems.Add(new ListViewItem.ListViewSubItem { Text = status.ToString(), Tag = status });
        //    subItems.Add( new ListViewItem.ListViewSubItem { Text = taskNumber, Tag = taskNumber });
        //    subItems.Add(new ListViewItem.ListViewSubItem { Text = maintManual, Tag = maintManual });
        //    subItems.Add(new ListViewItem.ListViewSubItem { Text = mrb, Tag = mrb });
        //    subItems.Add(new ListViewItem.ListViewSubItem { Text = item.EngineeringOrders, Tag = item.EngineeringOrders });
        //    subItems.Add(new ListViewItem.ListViewSubItem { Text = item.TaskCardNumber, Tag = item.TaskCardNumber });
        //    subItems.Add(new ListViewItem.ListViewSubItem { Text = item.CriticalSystem.ToString(), Tag = item.CriticalSystem });
        //    subItems.Add( new ListViewItem.ListViewSubItem { Text = ata.ToString(), Tag = ata });
        //    subItems.Add( new ListViewItem.ListViewSubItem { Text = kitRequieredString, Tag = kitRequieredString });
        //    subItems.Add( new ListViewItem.ListViewSubItem { Text = ndtString, Tag = ndtString });
        //    subItems.Add( new ListViewItem.ListViewSubItem { Text = item.Elapsed <= 0 ? "" : item.Elapsed.ToString(), Tag = item.Elapsed });
        //    subItems.Add( new ListViewItem.ListViewSubItem { Text = item.ManHours <= 0 ? "" : item.ManHours.ToString(), Tag = item.ManHours });
        //    subItems.Add( new ListViewItem.ListViewSubItem { Text = item.Cost <= 0 ? "" : item.Cost.ToString(), Tag = item.Cost });
        //    subItems.Add( new ListViewItem.ListViewSubItem { Text = remarksString, Tag = remarksString });
        //    subItems.Add( new ListViewItem.ListViewSubItem { Text = hiddenRemarksString, Tag = hiddenRemarksString});

        //    return subItems.ToArray();
        //}

        #endregion

        #region protected override void SortItems(int columnIndex)

        //protected override void SortItems(int columnIndex)
        //{
        //    if (OldColumnIndex != columnIndex)
        //        SortMultiplier = -1;
        //    if (SortMultiplier == 1)
        //        SortMultiplier = -1;
        //    else
        //        SortMultiplier = 1;
        //    itemsListView.Items.Clear();
        //    SetGroupsToItems();

        //    List<ListViewItem> resultList = new List<ListViewItem>();

        //    if (columnIndex <= 4 || columnIndex == 7 || columnIndex >= 18)
        //    {
        //        ListViewItemList.Sort(new DirectiveListViewComparer(columnIndex, SortMultiplier));
        //        //добавление остальных подзадач
        //        foreach (ListViewItem item in ListViewItemList)
        //        {
        //            if (item.Tag is MaintenanceDirective)
        //            {
        //                resultList.Add(item);

        //                //PrimaryDirective detail = (PrimaryDirective)item.Tag;
        //                //IEnumerable<ListViewItem> items =
        //                //    ListViewItemList
        //                //    .Where(lvi => lvi.Tag is Directive && ((Directive)lvi.Tag).PrimeDirectiveId == detail.ItemId);
        //                //foreach (ListViewItem listViewItem in items)
        //                //{
        //                //    listViewItem.Group = item.Group;
        //                //}
        //                //resultList.AddRange(items);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        //добавление остальных подзадач
        //        foreach (ListViewItem item in ListViewItemList)
        //        {
        //            if (item.Tag is MaintenanceDirective)
        //            {
        //                resultList.Add(item);

        //                //PrimaryDirective detail = (PrimaryDirective)item.Tag;
        //                //IEnumerable<ListViewItem> items =
        //                //    ListViewItemList
        //                //    .Where(lvi => lvi.Tag is Directive && ((Directive)lvi.Tag).PrimeDirectiveId == detail.ItemId);
        //                //foreach (ListViewItem listViewItem in items)
        //                //{
        //                //    listViewItem.Group = item.Group;
        //                //}
        //                //resultList.AddRange(items);
        //            }
        //        }
        //        resultList.Sort(new DirectiveListViewComparer(columnIndex, SortMultiplier));
        //    }
        //    itemsListView.Items.AddRange(resultList.ToArray());
        //    OldColumnIndex = columnIndex;
        //}

        #endregion

        #region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
        protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SelectedItem != null)
            {
                SupplierForm form = new SupplierForm(SelectedItem);
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
