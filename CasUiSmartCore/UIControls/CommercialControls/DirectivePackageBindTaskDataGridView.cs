using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.TreeDataGridView;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.WorkPackage;

namespace CAS.UI.UIControls.CommercialControls
{
    ///<summary>
    /// список для отображения событий системы безопасности полетов
    ///</summary>
    public partial class DirectivePackageBindTaskDataGridView : CommonTreeDataGridViewControl
    {
        #region public DirectivePackageBindTaskDataGridView()
        ///<summary>
        ///</summary>
        public DirectivePackageBindTaskDataGridView()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods

        #region public override void SetItemsArray(ICommonCollection itemsArray)

        public override void SetItemsArray(ICommonCollection itemsArray)
        {
            if (_selectedItemsList == null)
                _selectedItemsList = new CommonCollection<BaseEntityObject>();
            base.SetItemsArray(itemsArray);
        }
        #endregion

        #region public override void SetItemsArray(IEnumerable<BaseEntityObject> itemsArray)

        public override void SetItemsArray(IEnumerable<BaseEntityObject> itemsArray)
        {
            if (_selectedItemsList == null)
                _selectedItemsList = new CommonCollection<BaseEntityObject>();
            base.SetItemsArray(itemsArray);
        }
        #endregion

        #region protected override void SetHeaders()
        /// <summary>
        /// Устанавливает заголовки
        /// </summary>
        protected override void SetHeaders()
        {
            treeDataGridView.Columns.Clear();

            try
            {
                treeDataGridView.Columns.Clear();

                DataGridViewColumn columnHeader = new DataGridViewTextBoxColumn();
                columnHeader.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                columnHeader.Width = (int)(treeDataGridView.Width * 0.1f);
                columnHeader.HeaderText = "ATA";
                treeDataGridView.Columns.Add(columnHeader);
                columnHeader.ReadOnly = true;

                columnHeader = new DataGridViewTextBoxColumn();
                columnHeader.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                columnHeader.Width = (int)(treeDataGridView.Width * 0.15f);
                columnHeader.HeaderText = "Title";
                treeDataGridView.Columns.Add(columnHeader);
                columnHeader.ReadOnly = true;

                columnHeader = new DataGridViewTextBoxColumn();
                columnHeader.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                columnHeader.Width = (int)(treeDataGridView.Width * 0.3f);
                columnHeader.HeaderText = "Description";
                treeDataGridView.Columns.Add(columnHeader);
                columnHeader.ReadOnly = true;

                columnHeader = new DataGridViewTextBoxColumn();
                columnHeader.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                columnHeader.Width = (int)(treeDataGridView.Width * 0.08f);
                columnHeader.HeaderText = "Kit Required";
                treeDataGridView.Columns.Add(columnHeader);
                columnHeader.ReadOnly = true;

                columnHeader = new DataGridViewTextBoxColumn();
                columnHeader.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                columnHeader.Width = (int)(treeDataGridView.Width * 0.05f);
                columnHeader.HeaderText = "M.H.";
                treeDataGridView.Columns.Add(columnHeader);
                columnHeader.ReadOnly = true;

                columnHeader = new DataGridViewTextBoxColumn();
                columnHeader.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                columnHeader.Width = (int)(treeDataGridView.Width * 0.05f);
                columnHeader.HeaderText = "Cost (New)";
                treeDataGridView.Columns.Add(columnHeader);
                columnHeader.ReadOnly = true;

                columnHeader = new DataGridViewTextBoxColumn();
                columnHeader.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                columnHeader.Width = (int)(treeDataGridView.Width * 0.05f);
                columnHeader.HeaderText = "Cost Serv.";
                treeDataGridView.Columns.Add(columnHeader);
                columnHeader.ReadOnly = true;

                columnHeader = new DataGridViewTextBoxColumn();
                columnHeader.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                columnHeader.Width = (int)(treeDataGridView.Width * 0.08f);
                columnHeader.HeaderText = "Cost OH";
                treeDataGridView.Columns.Add(columnHeader);
                columnHeader.ReadOnly = true;

            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while building list headers", ex);
            }
        }
        #endregion

        #region protected override void DataGridViewMouseDoubleClick(object sender, MouseEventArgs e)
        protected override void DataGridViewMouseDoubleClick(object sender, MouseEventArgs e)
        {
        
        }
        #endregion

        #region protected override SetGroupsToItems()
        /// <summary>
        /// Выполняет группировку элементов
        /// </summary>
        protected override void SetGroupsToItems()
        {
            treeDataGridView.Groups.Clear();
            foreach (var item in PreResultRowList)
            {
                var temp = ListViewGroupHelper.GetGroupString(item.Tag);
                
                treeDataGridView.Groups.Add(temp, temp);
                item.Group = treeDataGridView.Groups[temp];
               
            }
        }
        #endregion

        #region protected override void SetRowBackColor(TreeDataGridViewRow treeDataGridViewRow, BaseEntityObject item)
        protected override void SetRowBackColor(TreeDataGridViewRow treeDataGridViewRow, BaseEntityObject item)
        {
            if (item == null)
                return;

            if (item is NextPerformance)
            {
                NextPerformance nextPerformance = item as NextPerformance;
                if (nextPerformance.Parent.IsDeleted)
                {
                    //запись так же может быть удаленной

                    //шрифт серым цветом
                    treeDataGridViewRow.DefaultCellStyle.ForeColor = Color.Gray;
                    if (treeDataGridViewRow.Cells[0].ToolTipText.Trim() != "")
                        treeDataGridViewRow.Cells[0].ToolTipText += "\n";
                    treeDataGridViewRow.Cells[0].ToolTipText +=
	                    $"This {nextPerformance.Parent.SmartCoreObjectType} is deleted";
                }
            }
            else if (item is AbstractPerformanceRecord)
            {
                AbstractPerformanceRecord apr = (AbstractPerformanceRecord) item;
                if (apr.Parent.IsDeleted)
                {
                    //запись так же может быть удаленной

                    //шрифт серым цветом
                    treeDataGridViewRow.DefaultCellStyle.ForeColor = Color.Gray;
                    if (treeDataGridViewRow.Cells[0].ToolTipText.Trim() != "")
                        treeDataGridViewRow.Cells[0].ToolTipText += "\n";
                    treeDataGridViewRow.Cells[0].ToolTipText += $"This {apr.Parent.SmartCoreObjectType} is deleted";
                }    
            }
            else
            {
                if(!(item is NonRoutineJob))
                {
                    //Если это не следующее выполнение, не запись о выполнении, и не рутинная работа
                    //значит, выполнение для данной задачи расчитать нельзя

                    //пометка этого выполнения синим цветом
                    treeDataGridViewRow.DefaultCellStyle.BackColor = Color.FromArgb(Highlight.Blue.Color);
                    //подсказка о том, что выполнение не возможео расчитать
                    treeDataGridViewRow.Cells[0].ToolTipText = "Performance for this directive can not be calculated";  
                }

                if (item.IsDeleted)
                {
                    //запись так же может быть удаленной

                    //шрифт серым цветом
                    treeDataGridViewRow.DefaultCellStyle.ForeColor = Color.Gray;
                    if (treeDataGridViewRow.Cells[0].ToolTipText.Trim() != "")
                        treeDataGridViewRow.Cells[0].ToolTipText += "\n";
                    treeDataGridViewRow.Cells[0].ToolTipText += $"This {item.SmartCoreObjectType} is deleted";
                }
            }
        }
        #endregion

        #region protected override void SetRowCellsValues(TreeDataGridViewRow row, BaseEntityObject item)

        protected override void SetRowCellsValues(TreeDataGridViewRow row, BaseEntityObject item)
        {
            AtaChapter ataChapter = null;
            string title = "";
            string description = "";
            //string zone = "";
            //string access = "";
            //string taskType = "";
            //MaintenanceDirectiveProgramType program = MaintenanceDirectiveProgramType.Unknown;
            //StaticDictionary workType = null;
            //string phase = "";
            double manHours = 0;
            //int mans = 0;
            //string categories = "";
            double cost = 0, costServiceable = 0, costOverhaul = 0;
            
            string kits = "";
            //Lifelength performance = Lifelength.Null;
            //Lifelength repeat = Lifelength.Null;
            //Lifelength remain = Lifelength.Null;
            //DateTime? performanceDate = null;

            if (item is NextPerformance)
            {
                NextPerformance np = (NextPerformance)item;
                IEngineeringDirective engineeringDirective = np.Parent as IEngineeringDirective;
                if (engineeringDirective != null)
                {
                    ataChapter = engineeringDirective.ATAChapter;
                    //zone = engineeringDirective.Zone;
                    //access = engineeringDirective.Access;
                    //program = engineeringDirective.Program;
                    //workType = engineeringDirective.WorkType;
                    //phase = engineeringDirective.Phase;
                    manHours = engineeringDirective.ManHours;
                    //mans = engineeringDirective.Mans;
                    //categories = engineeringDirective.CategoriesRecords.Aggregate("", (current, i) => current + (i.AircraftWorkerCategory + "; "));
                    cost = engineeringDirective.Cost;
                }
                title = np.Title;
                description = np.Description;
                //taskType = np.Parent.SmartCoreObjectType.ToString();
                kits = np.KitsToString;
                //performance = np.PerformanceSource;
                //repeat = np.Parent.Threshold != null ? np.Parent.Threshold.RepeatInterval : Lifelength.Null;
                //remain = np.Remains;
                //performanceDate = np.PerformanceDate;
            }
            else if (item is AbstractPerformanceRecord)
            {
                //DirectiveRecord directiveRecord = (DirectiveRecord)item;
                AbstractPerformanceRecord apr = (AbstractPerformanceRecord)item;

                IEngineeringDirective engineeringDirective = apr.Parent as IEngineeringDirective;
                if (engineeringDirective != null)
                {
                    ataChapter = engineeringDirective.ATAChapter;
                    //zone = engineeringDirective.Zone;
                    //access = engineeringDirective.Access;
                    //program = engineeringDirective.Program;
                    //workType = engineeringDirective.WorkType;
                    //phase = engineeringDirective.Phase;
                    manHours = engineeringDirective.ManHours;
                    //mans = engineeringDirective.Mans;
                    //categories = engineeringDirective.CategoriesRecords.Aggregate("", (current, i) => current + (i.AircraftWorkerCategory + "; "));
                    cost = engineeringDirective.Cost;
                }
                title = apr.Title;
                description = apr.Description;
                //taskType = apr.Parent.SmartCoreObjectType.ToString();
                kits = apr.KitsToString;
                //performance = apr.OnLifelength;
                //repeat = apr.Parent.Threshold != null ? apr.Parent.Threshold.RepeatInterval : Lifelength.Null;
                //performanceDate = apr.RecordDate;
            }
            else if (item is IEngineeringDirective)
            {
                IEngineeringDirective engineeringDirective = item as IEngineeringDirective;
                ataChapter = engineeringDirective.ATAChapter;
                //zone = engineeringDirective.Zone;
                //access = engineeringDirective.Access;
                //program = engineeringDirective.Program;
                //workType = engineeringDirective.WorkType;
                //phase = engineeringDirective.Phase;
                manHours = engineeringDirective.ManHours;
                //mans = engineeringDirective.Mans;
                //categories = engineeringDirective.CategoriesRecords.Aggregate("", (current, i) => current + (i.AircraftWorkerCategory + "; "));
                cost = engineeringDirective.Cost;
                title = engineeringDirective.Title;
                description = engineeringDirective.Description;
                //taskType = engineeringDirective.SmartCoreObjectType.ToString();
                kits = engineeringDirective is IKitRequired ? ((IKitRequired)engineeringDirective).Kits.ToString() : "";
                //performance = engineeringDirective.NextPerformanceSource;
                //repeat = engineeringDirective.Threshold != null ? engineeringDirective.Threshold.RepeatInterval : Lifelength.Null;
                //performanceDate = engineeringDirective.NextPerformanceDate;

                if (engineeringDirective is Component)
                {
                    Component d = engineeringDirective as Component;
                    costServiceable = d.CostServiceable;
                    costOverhaul = d.CostOverhaul;
                }
            }

            //if (performance == null)
            //    performance = Lifelength.Null;
            //if (repeat == null)
            //    repeat = Lifelength.Null;
            //if (remain == null)
            //    remain = Lifelength.Null;

            row.Cells[0].Value = ataChapter != null ? ataChapter.ToString() : "";
            row.Cells[0].Tag = ataChapter;
            row.Cells[1].Value = title;
            row.Cells[1].Tag = title;
            row.Cells[2].Value = description;
            row.Cells[2].Tag = description;
            //row.Cells[3].Value = zone;
            //row.Cells[3].Tag = zone;
            //row.Cells[4].Value = access;
            //row.Cells[4].Tag = access;
            row.Cells[3].Value = kits;
            row.Cells[3].Tag = kits;
            row.Cells[4].Value = manHours.ToString();
            row.Cells[4].Tag = manHours;
            row.Cells[5].Value = cost.ToString();
            row.Cells[5].Tag = cost;
            row.Cells[6].Value = costServiceable.ToString();
            row.Cells[6].Tag = costServiceable;
            row.Cells[7].Value = costOverhaul.ToString();
            row.Cells[7].Tag = costOverhaul;
            //row.Cells[14].Value = performance.ToString();
            //row.Cells[14].Tag = performance;
            //row.Cells[15].Value = repeat.ToString();
            //row.Cells[15].Tag = repeat;
            //row.Cells[16].Value = remain.ToString();
            //row.Cells[16].Tag = remain.ToString();
            //row.Cells[17].Value = performanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)performanceDate);
            //row.Cells[17].Tag = performanceDate;
        }

        #endregion

        #region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

        protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
        {
            e.Cancel = true;
        }
        #endregion

        #region private void MaintenanceDirectiveBindDetailListViewLoad(object sender, EventArgs e)
        private void MaintenanceDirectiveBindDetailListViewLoad(object sender, EventArgs e)
        {
            SetHeaders();
            treeDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        #endregion

        #endregion
    }
}
