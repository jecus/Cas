using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Quality;
using Convert = System.Convert;

namespace CAS.UI.UIControls.QualityAssuranceControls
{
    ///<summary>
    /// список для отображения ордеров запроса
    ///</summary>
    public partial class ProceduresListView : BaseListViewControl<Procedure>
    {
        #region Fields

        #endregion

        #region Constructors

        #region public ProceduresListView()
        ///<summary>
        ///</summary>
        public ProceduresListView()
        {
            InitializeComponent();
        }
        #endregion

        #endregion

        #region Methods

        #region protected override void SetHeaders()
        /// <summary>
        /// Устанавливает заголовки
        /// </summary>
        protected override void SetHeaders()
        {
            ColumnHeaderList.Clear();

            ColumnHeader columnHeader = new ColumnHeader { Width = (int) (itemsListView.Width*0.12f), Text = "Title" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Description" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Rating" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Level" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Audited Object" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Proc. Type" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "1st. Perf." };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Rpt. Intv." };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Next" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Remain/Overdue" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.05f), Text = "Last" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Status" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int) (itemsListView.Width*0.12f),  Text = "Ref. Docs." };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = (int) (itemsListView.Width*0.05f), Text = "Kit"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = (int) (itemsListView.Width*0.08f), Text = "M.H."};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = (int) (itemsListView.Width*0.08f), Text = "Cost"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = (int) (itemsListView.Width*0.12f), Text = "Remarks"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = (int) (itemsListView.Width*0.12f), Text = "Hidden remarks"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Signer" };
            ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
        }
		#endregion

		#region protected override SetGroupsToItems(int columnIndex)
		/// <summary>
		/// 
		/// </summary>
		protected override void SetGroupsToItems(int columnIndex)
        {
        }
        #endregion

        #region protected override void SetItemColor(ListViewItem listViewItem, Procedure item)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listViewItem"></param>
        /// <param name="item"></param>
        protected override void SetItemColor(ListViewItem listViewItem, Procedure item)
        {
            listViewItem.ForeColor = Color.Black;
            base.SetItemColor(listViewItem, item);
        }
        #endregion

        #region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Procedure item)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Procedure item)
        {
            List<ListViewItem.ListViewSubItem> subItems = new List<ListViewItem.ListViewSubItem>();

            //////////////////////////////////////////////////////////////////////////////////////
            //         Определение последнего выполнения директивы и KitRequiered               //
            //////////////////////////////////////////////////////////////////////////////////////
            DateTime defaultDateTime = DateTimeExtend.GetCASMinDateTime();
            DateTime lastComplianceDate = defaultDateTime;
            DateTime nextComplianceDate = defaultDateTime;
            Lifelength lastComplianceLifeLength = Lifelength.Zero;

            string lastPerformanceString, firstPerformanceString = "N/A";

            if(item.LastPerformance != null)
            {
                lastComplianceDate = item.LastPerformance.RecordDate;
                lastComplianceLifeLength = item.LastPerformance.OnLifelength;    
            }
            if (item.Threshold.FirstPerformanceSinceNew != null && !item.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
            {
                firstPerformanceString = "s/n: " + item.Threshold.FirstPerformanceSinceNew;
            }
            if (item.Threshold.FirstPerformanceSinceEffectiveDate != null &&
                !item.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
            {
                if (firstPerformanceString != "N/A") firstPerformanceString += " or ";
                else firstPerformanceString = "";
                firstPerformanceString += "s/e.d: " + item.Threshold.FirstPerformanceSinceEffectiveDate;
            }

            //if (item.BindDetailDirectives.Count == 0)
            //{
                if (item.NextPerformanceDate != null && item.NextPerformanceDate > defaultDateTime)
                    nextComplianceDate = Convert.ToDateTime(item.NextPerformanceDate);
            //    nextComplianceLifelength = item.NextCompliance;
            //}
            //else
            //{
            //    DetailDirective firstLimitter =
            //            item.BindDetailDirectives.Where(bdd => bdd.NextComplianceDate != null &&
            //                                                   bdd.NextComplianceDate > defaultDateTime)
            //                                     .OrderBy(d => d)
            //                                     .FirstOrDefault();
            //    if (firstLimitter != null)
            //    {
            //        nextComplianceDate = Convert.ToDateTime(firstLimitter.NextComplianceDate);
            //        nextComplianceLifelength = firstLimitter.NextCompliance;
            //    }
            //}

            string kitRequieredString = item.Kits.Count + " kits";
            string remarksString = item.Remarks;
            string hiddenRemarksString = item.HiddenRemarks;

            if (lastComplianceDate <= defaultDateTime)
                lastPerformanceString = "N/A";
            else
                lastPerformanceString = SmartCore.Auxiliary.Convert.GetDateFormat(lastComplianceDate) + " " +
                                        lastComplianceLifeLength;
            string nextComplianceString = ((nextComplianceDate <= defaultDateTime)
                                               ? ""
                                               : SmartCore.Auxiliary.Convert.GetDateFormat(nextComplianceDate) + " ") +
                                          item.NextPerformanceSource;
            string nextRemainString = item.Remains != null && !item.Remains.IsNullOrZero()
                                          ? item.Remains.ToString()
                                          : "N/A";

			//////////////////////////////////////////////////////////////////////////////////////

			var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);
			string description = item.Description != "" ? item.Description : "N/A";
            string title = item.Title != "" ? item.Title : "N/A";
            string reqiredDocuments = item.DocumentReferences.Count > 0 ? item.DocumentReferences.Aggregate("", (current, i) => current + (i.Document + "; ")): "N/A";
            DirectiveStatus status = item.Status;

            subItems.Add(new ListViewItem.ListViewSubItem { Text = title, Tag = title });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = description, Tag = description });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.ProcedureRating.ToString(), Tag = item.ProcedureRating });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Level.ToString(), Tag = item.Level });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.AuditedObject, Tag = item.AuditedObject });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.ProcedureType.ToString(), Tag = item.ProcedureType });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = firstPerformanceString, Tag = firstPerformanceString });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Threshold.RepeatInterval.ToString(), Tag = item.Threshold.RepeatInterval });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = nextComplianceString, Tag = nextComplianceDate });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = nextRemainString, Tag = nextRemainString });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = lastPerformanceString, Tag = lastComplianceDate });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = status.ToString(), Tag = status });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = reqiredDocuments, Tag = reqiredDocuments });
            subItems.Add( new ListViewItem.ListViewSubItem { Text = kitRequieredString, Tag = kitRequieredString });
            subItems.Add( new ListViewItem.ListViewSubItem { Text = item.ManHours <= 0 ? "" : item.ManHours.ToString(), Tag = item.ManHours });
            subItems.Add( new ListViewItem.ListViewSubItem { Text = item.Cost <= 0 ? "" : item.Cost.ToString(), Tag = item.Cost });
            subItems.Add( new ListViewItem.ListViewSubItem { Text = remarksString, Tag = remarksString });
            subItems.Add( new ListViewItem.ListViewSubItem { Text = hiddenRemarksString, Tag = hiddenRemarksString});
            subItems.Add(new ListViewItem.ListViewSubItem { Text = author, Tag = author });

			return subItems.ToArray();
        }

        #endregion

        #region protected override void SortItems(int columnIndex)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnIndex"></param>
        protected override void SortItems(int columnIndex)
        {
            if (OldColumnIndex != columnIndex)
                SortMultiplier = -1;
            if (SortMultiplier == 1)
                SortMultiplier = -1;
            else
                SortMultiplier = 1;
            itemsListView.Items.Clear();
            SetGroupsToItems(columnIndex);

            List<ListViewItem> resultList = new List<ListViewItem>();

            if (columnIndex == 8)
            {
                resultList.AddRange(ListViewItemList.Where(item => item.Tag is Procedure));

                resultList.Sort(new BaseListViewComparer(columnIndex, SortMultiplier));

                itemsListView.Groups.Clear();
                foreach (var item in resultList)
                {
					var temp = ListViewGroupHelper.GetGroupStringByPerformanceDate(item.Tag);
					itemsListView.Groups.Add(temp, temp);
                    item.Group = itemsListView.Groups[temp];
                }

            }
            else
            {
                itemsListView.Groups.Clear();
                //добавление остальных подзадач
                resultList.AddRange(ListViewItemList.Where(item => item.Tag is Procedure));
                resultList.Sort(new DirectiveListViewComparer(columnIndex, SortMultiplier));
            }
            itemsListView.Items.AddRange(resultList.ToArray());
            OldColumnIndex = columnIndex;
        }

        #endregion

        #region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
        {
            if (SelectedItem != null)
            {
                string regNumber = SelectedItem.Title;
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                e.DisplayerText = regNumber;
                e.RequestedEntity = new ProcedureScreen(SelectedItem);
            }
        }
        #endregion

        #endregion
    }
}
