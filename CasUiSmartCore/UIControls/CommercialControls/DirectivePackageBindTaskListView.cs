using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary;
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
    public partial class DirectivePackageBindTaskListView : CommonListViewControl
    {
        #region public DirectivePackageBindTaskListView()
        ///<summary>
        ///</summary>
        public DirectivePackageBindTaskListView()
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
            try
            {
                itemsListView.Columns.Clear();

                ColumnHeader columnHeader = new ColumnHeader();
                columnHeader.Width = (int)(itemsListView.Width * 0.05f);
                columnHeader.Text = "ATA";
                itemsListView.Columns.Add(columnHeader);

                columnHeader = new ColumnHeader();
                columnHeader.Width = (int)(itemsListView.Width * 0.10f);
                columnHeader.Text = "Title";
                itemsListView.Columns.Add(columnHeader);

                columnHeader = new ColumnHeader();
                columnHeader.Width = (int)(itemsListView.Width * 0.3f);
                columnHeader.Text = "Description";
                itemsListView.Columns.Add(columnHeader);

                columnHeader = new ColumnHeader();
                columnHeader.Width = (int)(itemsListView.Width * 0.08f);
                columnHeader.Text = "Kit Required";
                itemsListView.Columns.Add(columnHeader);

                columnHeader = new ColumnHeader();
                columnHeader.Width = (int)(itemsListView.Width * 0.05f);
                columnHeader.Text = "M.H.";
                itemsListView.Columns.Add(columnHeader);

                columnHeader = new ColumnHeader();
                columnHeader.Width = (int)(itemsListView.Width * 0.05f);
                columnHeader.Text = "Cost (New)";
                itemsListView.Columns.Add(columnHeader);

                columnHeader = new ColumnHeader();
                columnHeader.Width = (int)(itemsListView.Width * 0.05f);
                columnHeader.Text = "Cost Serv.";
                itemsListView.Columns.Add(columnHeader);

                columnHeader = new ColumnHeader();
                columnHeader.Width = (int)(itemsListView.Width * 0.08f);
                columnHeader.Text = "Cost OH";
                itemsListView.Columns.Add(columnHeader);

            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while building list headers", ex);
            }
        }
        #endregion

        #region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
        protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
        {
        
        }
        #endregion

        #region protected override SetGroupsToItems()
        /// <summary>
        /// Выполняет группировку элементов
        /// </summary>
        protected override void SetGroupsToItems()
        {
            itemsListView.Groups.Clear();
            foreach (var item in ListViewItemList)
            {
                var temp = ListViewGroupHelper.GetGroupString(item.Tag);
                
                itemsListView.Groups.Add(temp, temp);
                item.Group = itemsListView.Groups[temp];
            }
        }
        #endregion

        #region protected override void SetItemColor(ListViewItem listViewItem, BaseEntityObject item)
        protected override void SetItemColor(ListViewItem listViewItem, BaseEntityObject item)
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
                    listViewItem.ForeColor = Color.Gray;
                    if (listViewItem.ToolTipText.Trim() != "")
                        listViewItem.ToolTipText += "\n";
                    listViewItem.ToolTipText += $"This {nextPerformance.Parent.SmartCoreObjectType} is deleted";
                }
            }
            else if (item is AbstractPerformanceRecord)
            {
                AbstractPerformanceRecord apr = (AbstractPerformanceRecord) item;
                if (apr.Parent.IsDeleted)
                {
                    //запись так же может быть удаленной

                    //шрифт серым цветом
                    listViewItem.ForeColor = Color.Gray;
                    if (listViewItem.ToolTipText.Trim() != "")
                        listViewItem.ToolTipText += "\n";
                    listViewItem.ToolTipText += $"This {apr.Parent.SmartCoreObjectType} is deleted";
                }    
            }
            else
            {
                if(!(item is NonRoutineJob))
                {
                    //Если это не следующее выполнение, не запись о выполнении, и не рутинная работа
                    //значит, выполнение для данной задачи расчитать нельзя

                    //пометка этого выполнения синим цветом
                    listViewItem.BackColor = Color.FromArgb(Highlight.Blue.Color);
                    //подсказка о том, что выполнение не возможео расчитать
                    listViewItem.ToolTipText = "Performance for this directive can not be calculated";  
                }

                if (item.IsDeleted)
                {
                    //запись так же может быть удаленной

                    //шрифт серым цветом
                    listViewItem.ForeColor = Color.Gray;
                    if (listViewItem.ToolTipText.Trim() != "")
                        listViewItem.ToolTipText += "\n";
                    listViewItem.ToolTipText += $"This {item.SmartCoreObjectType} is deleted";
                }
            }
        }
        #endregion

        #region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(BaseEntityObject item)

        protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(BaseEntityObject item)
        {
            List<ListViewItem.ListViewSubItem> subItems = new List<ListViewItem.ListViewSubItem> ();

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

            subItems.Add(new ListViewItem.ListViewSubItem { Text = ataChapter != null ? ataChapter.ToString() : "", Tag = ataChapter });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = title, Tag = title });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = description, Tag = description });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = kits, Tag = kits });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = manHours.ToString(), Tag = manHours });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = cost.ToString(), Tag = cost });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = costServiceable.ToString(), Tag = costServiceable });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = costOverhaul.ToString(), Tag = costOverhaul });

            return subItems.ToArray();
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
        }
        #endregion

        #endregion
    }
}
