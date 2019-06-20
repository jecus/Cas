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
using CAS.UI.UIControls.NewGrid;
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
    public partial class ProceduresListView : BaseGridViewControl<Procedure>
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
			AddColumn("Title", (int)(radGridView1.Width * 0.24f));
			AddColumn("Description", (int)(radGridView1.Width * 0.24f));
			AddColumn("Rating", (int)(radGridView1.Width * 0.16f));
			AddColumn("Level", (int)(radGridView1.Width * 0.16f));
			AddColumn("Audited Object", (int)(radGridView1.Width * 0.24f));
			AddColumn("Proc. Type", (int)(radGridView1.Width * 0.16f));
			AddColumn("1st. Perf.", (int)(radGridView1.Width * 0.24f));
			AddColumn("Rpt. Intv.", (int)(radGridView1.Width * 0.24f));
			AddColumn("Next", (int)(radGridView1.Width * 0.24f));
			AddColumn("Remain/Overdue", (int)(radGridView1.Width * 0.24f));
			AddColumn("Last", (int)(radGridView1.Width * 0.10f));
			AddColumn("Status", (int)(radGridView1.Width * 0.24f));
			AddColumn("Ref. Docs.", (int)(radGridView1.Width * 0.24f));
			AddColumn("Kit", (int)(radGridView1.Width * 0.10f));
			AddColumn("M.H.", (int)(radGridView1.Width * 0.16f));
			AddColumn("Cost", (int)(radGridView1.Width * 0.16f));
			AddColumn("Remarks", (int)(radGridView1.Width * 0.24f));
			AddColumn("Hidden remarks", (int)(radGridView1.Width * 0.24f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.2f));
        }
		#endregion

		#region protected override SetGroupsToItems(int columnIndex)
		/// <summary>
		/// 
		/// </summary>
		//protected override void SetGroupsToItems(int columnIndex)
        //{
        //}
        #endregion

        #region protected override void SetItemColor(ListViewItem listViewItem, Procedure item)
		//TODO COLOR!
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listViewItem"></param>
        /// <param name="item"></param>
        //protected override void SetItemColor(ListViewItem listViewItem, Procedure item)
        //{
        //    listViewItem.ForeColor = Color.Black;
        //    base.SetItemColor(listViewItem, item);
        //}
        #endregion

        #region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Procedure item)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override List<CustomCell> GetListViewSubItems(Procedure item)
        {
            var subItems = new List<CustomCell>();

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

			subItems.Add(CreateRow(title, title ));
			subItems.Add(CreateRow(description, description ));
			subItems.Add(CreateRow(item.ProcedureRating.ToString(), item.ProcedureRating ));
			subItems.Add(CreateRow(item.Level.ToString(), item.Level ));
			subItems.Add(CreateRow(item.AuditedObject, item.AuditedObject ));
			subItems.Add(CreateRow(item.ProcedureType.ToString(), item.ProcedureType ));
			subItems.Add(CreateRow(firstPerformanceString, firstPerformanceString ));
			subItems.Add(CreateRow(item.Threshold.RepeatInterval.ToString(), item.Threshold.RepeatInterval ));
			subItems.Add(CreateRow(nextComplianceString, nextComplianceDate ));
			subItems.Add(CreateRow(nextRemainString, nextRemainString ));
			subItems.Add(CreateRow(lastPerformanceString, lastComplianceDate ));
			subItems.Add(CreateRow(status.ToString(), status ));
			subItems.Add(CreateRow(reqiredDocuments, reqiredDocuments ));
			subItems.Add(CreateRow(kitRequieredString, kitRequieredString ));
			subItems.Add(CreateRow(item.ManHours <= 0 ? "" : item.ManHours.ToString(), item.ManHours ));
            subItems.Add(CreateRow(item.Cost <= 0 ? "" : item.Cost.ToString(), item.Cost ));
			subItems.Add(CreateRow(remarksString, remarksString ));
			subItems.Add(CreateRow(hiddenRemarksString, hiddenRemarksString ));
			subItems.Add(CreateRow(author, author ));

			return subItems;
        }

        #endregion

        #region protected override void SortItems(int columnIndex)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnIndex"></param>
     //   protected override void SortItems(int columnIndex)
     //   {
     //       if (OldColumnIndex != columnIndex)
     //           SortMultiplier = -1;
     //       if (SortMultiplier == 1)
     //           SortMultiplier = -1;
     //       else
     //           SortMultiplier = 1;
     //       itemsListView.Items.Clear();
     //       SetGroupsToItems(columnIndex);

     //       List<ListViewItem> resultList = new List<ListViewItem>();

     //       if (columnIndex == 8)
     //       {
     //           resultList.AddRange(ListViewItemList.Where(item => item.Tag is Procedure));

     //           resultList.Sort(new BaseListViewComparer(columnIndex, SortMultiplier));

     //           itemsListView.Groups.Clear();
     //           foreach (var item in resultList)
     //           {
					//var temp = ListViewGroupHelper.GetGroupStringByPerformanceDate(item.Tag);
					//itemsListView.Groups.Add(temp, temp);
     //               item.Group = itemsListView.Groups[temp];
     //           }

     //       }
     //       else
     //       {
     //           itemsListView.Groups.Clear();
     //           //добавление остальных подзадач
     //           resultList.AddRange(ListViewItemList.Where(item => item.Tag is Procedure));
     //           resultList.Sort(new DirectiveListViewComparer(columnIndex, SortMultiplier));
     //       }
     //       itemsListView.Items.AddRange(resultList.ToArray());
     //       OldColumnIndex = columnIndex;
     //   }

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
