using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.MaintenanceWorkscope;
using Convert = System.Convert;

namespace CAS.UI.UIControls.MaintananceProgram
{
    ///<summary>
    /// список для отображения ордеров запроса
    ///</summary>
    public partial class MaintenanceDirectiveListView : BaseListViewControl<MaintenanceDirective>
    {
        #region Fields

        #endregion

        #region Constructors

        #region public MaintenanceDirectiveListView()
        ///<summary>
        ///</summary>
        public MaintenanceDirectiveListView()
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

            ColumnHeader columnHeader = new ColumnHeader { Width = (int) (itemsListView.Width*0.08f), Text = "AMP" };
            ColumnHeaderList.Add(columnHeader);

	        columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "MPD Item" };
	        ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Task Card №" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Description" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Program" };
            ColumnHeaderList.Add(columnHeader);

	        columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Program Indicator" };
	        ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Work Type" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Check" };
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

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Zone" };
            ColumnHeaderList.Add(columnHeader);

	        columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Work Area" };
	        ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Access" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Status" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int) (itemsListView.Width*0.12f),  Text = "Doc. No" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Maint. Manual" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "MRB" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Old Task Card Number" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Critical System" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = (int) (itemsListView.Width*0.05f), Text = "ATA Chapter"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = (int) (itemsListView.Width*0.05f), Text = "Kit"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = (int) (itemsListView.Width*0.05f), Text = "NDT"};
            ColumnHeaderList.Add(columnHeader);

	        columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.05f), Text = "Skill" };
	        ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.05f), Text = "Category" };
	        ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Elapsed M.H." };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = (int) (itemsListView.Width*0.08f), Text = "M.H."};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = (int) (itemsListView.Width*0.08f), Text = "Cost"};
            ColumnHeaderList.Add(columnHeader);

	        columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.05f), Text = "Applicability" };
	        ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader {Width = (int) (itemsListView.Width*0.12f), Text = "Remarks"};
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader {Width = (int) (itemsListView.Width*0.12f), Text = "Hidden remarks"};
            ColumnHeaderList.Add(columnHeader);

            itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
        }
        #endregion

        #region protected override SetGroupsToItems()
        protected override void SetGroupsToItems(int columnIndex)
        {
        }
        #endregion

        #region protected override void SetItemColor(ListViewItem listViewItem, MaintenanceDirective item)
        protected override void SetItemColor(ListViewItem listViewItem, MaintenanceDirective item)
        {
            Color itemBackColor = UsefulMethods.GetColor(item);
            Color itemForeColor = Color.Black;

            listViewItem.BackColor = UsefulMethods.GetColor(item);

            //Color white = Color.White;
            //Color itemBackColor = UsefulMethods.GetColor(item);
            Color listViewForeColor = ItemListView.ForeColor;
			Color listViewBackColor = ItemListView.BackColor;

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

        #region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(MaintenanceDirective item)

        protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(MaintenanceDirective item)
        {
            List<ListViewItem.ListViewSubItem> subItems = new List<ListViewItem.ListViewSubItem>();

            //////////////////////////////////////////////////////////////////////////////////////
            //         Определение последнего выполнения директивы и KitRequiered               //
            //////////////////////////////////////////////////////////////////////////////////////
            DateTime defaultDateTime = DateTimeExtend.GetCASMinDateTime();
            DateTime lastComplianceDate = defaultDateTime;
            DateTime nextComplianceDate = defaultDateTime;
            Lifelength lastComplianceLifeLength = Lifelength.Zero;
            //Lifelength nextComplianceLifelength = Lifelength.Null;

            string lastPerformanceString, firstPerformanceString = "N/A";

            Color tcnColor = itemsListView.ForeColor;
			Color kitColor = itemsListView.BackColor;
			AtaChapter ata = item.ATAChapter;
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

           if (item.NextPerformanceDate != null && item.NextPerformanceDate > defaultDateTime)
              nextComplianceDate = Convert.ToDateTime(item.NextPerformanceDate);


			string kitRequieredString = item.KitsApplicable ? item.Kits.Count + " kits" : "N/A";
			string ndtString = item.NDTType.ShortName;
			string skillString = item.Skill.ShortName;
			string categoryString = item.Category.ShortName;
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
            string description = item.Description != "" ? item.Description : "N/A";
            string app = item.IsApplicability ? $"APL {item.Applicability}" : $"N/A {item.Applicability}";
			string taskNumber = item.MPDTaskNumber != "" ? item.MPDTaskNumber : "N/A";
            string taskCheck = item.TaskNumberCheck != "" ? item.TaskNumberCheck : "N/A";
            string maintManual = item.MaintenanceManual != "" ? item.MaintenanceManual : "N/A";
            string mrb = item.MRB != "" ? item.MRB : "N/A";
            string check = item.MaintenanceCheck != null ? item.MaintenanceCheck.Name : "N/A";
            DirectiveStatus status = item.Status;

            if (item.TaskCardNumberFile == null)
                tcnColor = Color.MediumVioletRed;

			if(item.KitsApplicable && item.Kits.Count == 0)
				kitColor = Color.FromArgb(Highlight.Red.Color);

			subItems.Add( new ListViewItem.ListViewSubItem { Text = item.ScheduleItem, Tag = item.ScheduleItem } );
			subItems.Add( new ListViewItem.ListViewSubItem { Text = taskCheck, Tag = taskCheck } );
            subItems.Add(new ListViewItem.ListViewSubItem { ForeColor = tcnColor, Text = item.TaskCardNumber, Tag = item.TaskCardNumber});
            subItems.Add(new ListViewItem.ListViewSubItem { Text = description, Tag = description });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Program.ToString(), Tag = item.Program });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.ProgramIndicator.ToString(), Tag = item.ProgramIndicator });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.WorkType.ToString(), Tag = item.WorkType });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = check, Tag = check });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = firstPerformanceString, Tag = firstPerformanceString });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Threshold.RepeatInterval.ToString(), Tag = item.Threshold.RepeatInterval });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = nextComplianceString, Tag = nextComplianceDate });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = nextRemainString, Tag = nextRemainString });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = lastPerformanceString, Tag = lastComplianceDate });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Zone, Tag = item.Zone });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Workarea, Tag = item.Workarea });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.Access, Tag = item.Access });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = status.ToString(), Tag = status });
            subItems.Add( new ListViewItem.ListViewSubItem { Text = taskNumber, Tag = taskNumber });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = maintManual, Tag = maintManual });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = mrb, Tag = mrb });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.TaskCardNumber, Tag = item.TaskCardNumber });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = item.CriticalSystem.ToString(), Tag = item.CriticalSystem });
            subItems.Add( new ListViewItem.ListViewSubItem { Text = ata.ToString(), Tag = ata });
            subItems.Add( new ListViewItem.ListViewSubItem { Text = kitRequieredString, Tag = kitRequieredString, BackColor = kitColor});
            subItems.Add( new ListViewItem.ListViewSubItem { Text = ndtString, Tag = ndtString });
            subItems.Add( new ListViewItem.ListViewSubItem { Text = skillString, Tag = skillString });
            subItems.Add( new ListViewItem.ListViewSubItem { Text = categoryString, Tag = categoryString });
            subItems.Add( new ListViewItem.ListViewSubItem { Text = item.Elapsed <= 0 ? "" : item.Elapsed.ToString(), Tag = item.Elapsed });
            subItems.Add( new ListViewItem.ListViewSubItem { Text = item.ManHours <= 0 ? "" : item.ManHours.ToString(), Tag = item.ManHours });
            subItems.Add( new ListViewItem.ListViewSubItem { Text = item.Cost <= 0 ? "" : item.Cost.ToString(), Tag = item.Cost });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = app, Tag = app });
			subItems.Add( new ListViewItem.ListViewSubItem { Text = remarksString, Tag = remarksString });
            subItems.Add( new ListViewItem.ListViewSubItem { Text = hiddenRemarksString, Tag = hiddenRemarksString});

            return subItems.ToArray();
        }

        #endregion

        #region protected override void SortItems(int columnIndex)

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
                resultList.AddRange(ListViewItemList.Where(item => item.Tag is MaintenanceDirective));

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
                resultList.AddRange(ListViewItemList.Where(item => item.Tag is MaintenanceDirective));
                resultList.Sort(new DirectiveListViewComparer(columnIndex, SortMultiplier));
            }
            itemsListView.Items.AddRange(resultList.ToArray());
            OldColumnIndex = columnIndex;
        }

        #endregion

        #region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

        protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
        {
            if (SelectedItem != null)
            {
	            var dp = ScreenAndFormManager.GetMaintenanceDirectiveScreen(SelectedItem);
				e.SetParameters(dp);
            }
        }
        #endregion

	    protected override void SetTotalText()
	    {
		    var dir = ListViewItemList.Select(i => i.Tag).OfType<MaintenanceDirective>();

			var dict = new List<string>();
		    foreach (var directive in dir)
		    {
			    var value = directive.TaskNumberCheck;
			    if (value.LastIndexOf("(") > 0)
				    value = value.Substring(0, value.LastIndexOf("("));

				if(!dict.Contains(value))
					dict.Add(value);
			}


			this.labelTotal.Text = $"Total: {dict.Count}/{itemsListView.Items.Count}";
		}

	    #endregion
    }
}
