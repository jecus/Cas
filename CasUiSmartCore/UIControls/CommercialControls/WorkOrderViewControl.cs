using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.WorkPakage;
using CASTerms;
using EntityCore.DTO.Dictionaries;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.WorkPackage;

namespace CAS.UI.UIControls.CommercialControls
{
    ///<summary>
    /// ЭУ для предствления списков объектов определенного типа, унаследованных от <see cref="BaseEntityObject"/>
    ///</summary>
    [Designer(typeof(WorkOrderViewControlDesigner))]
    public partial class WorkOrderViewControl : CommonDataGridViewControl
    {
        #region Fields

        private WorkPackage _currentWorkPackage;

        #endregion

        #region Properties

        public WorkPackage WorkPackage
        {
            get { return _currentWorkPackage; }
            set { _currentWorkPackage = value; }
        }

        #endregion

        #region Properties

        #endregion

        #region Constructors

        #region public WorkOrderViewControl()
        ///<summary>
        /// конструктор по умолчанию для простого создания ЭУ в Дизайнере
        ///</summary>
        public WorkOrderViewControl()
        {
            InitializeComponent();

            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        #endregion

        #region public WorkOrderViewControl(PropertyInfo beginGroup) : this()
        ///<summary>
        /// конструктор по умолчанию для простого создания ЭУ в Дизайнере
        ///</summary>
        ///<param name="beginGroup">Задает своиство класса, по которому нужно сделать первичную группировку</param>
        public WorkOrderViewControl(PropertyInfo beginGroup)
            : this()
        {
            _beginGroup = beginGroup;
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
            try
            {
                dataGridView.Columns.Clear();

                DataGridViewColumn columnHeader;

                columnHeader = new DataGridViewTextBoxColumn();
                columnHeader.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                columnHeader.Width = (int)(dataGridView.Width * 0.05f);
                columnHeader.HeaderText = "ATA";
                dataGridView.Columns.Add(columnHeader);
                columnHeader.ReadOnly = true;

                columnHeader = new DataGridViewTextBoxColumn();
                columnHeader.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                columnHeader.Width = (int)(dataGridView.Width * 0.10f);
                columnHeader.HeaderText = "Title";
                dataGridView.Columns.Add(columnHeader);
                columnHeader.ReadOnly = true;

                columnHeader = new DataGridViewTextBoxColumn();
                columnHeader.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                columnHeader.Width = (int)(dataGridView.Width * 0.3f);
                columnHeader.HeaderText = "Description";
                dataGridView.Columns.Add(columnHeader);
                columnHeader.ReadOnly = true;

                //columnHeader = new DataGridViewTextBoxColumn();
                //columnHeader.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //columnHeader.Width = (int)(dataGridView.Width * 0.10f);
                //columnHeader.HeaderText = "Zone";
                //dataGridView.Columns.Add(columnHeader);
                //columnHeader.ReadOnly = true;

                //columnHeader = new DataGridViewTextBoxColumn();
                //columnHeader.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //columnHeader.Width = (int)(dataGridView.Width * 0.10f);
                //columnHeader.HeaderText = "Access";
                //dataGridView.Columns.Add(columnHeader);
                //columnHeader.ReadOnly = true;

                columnHeader = new DataGridViewTextBoxColumn();
                columnHeader.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                columnHeader.Width = (int)(dataGridView.Width * 0.1f);
                columnHeader.HeaderText = "Task Type";
                dataGridView.Columns.Add(columnHeader);
                columnHeader.ReadOnly = true;

                columnHeader = new DataGridViewTextBoxColumn();
                columnHeader.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                columnHeader.Width = (int)(dataGridView.Width * 0.1f);
                columnHeader.HeaderText = "Program";
                dataGridView.Columns.Add(columnHeader);
                columnHeader.ReadOnly = true;

                columnHeader = new DataGridViewTextBoxColumn();
                columnHeader.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                columnHeader.Width = (int)(dataGridView.Width * 0.08f);
                columnHeader.HeaderText = "Work Type";
                dataGridView.Columns.Add(columnHeader);
                columnHeader.ReadOnly = true;

                //columnHeader = new DataGridViewTextBoxColumn();
                //columnHeader.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //columnHeader.Width = (int)(dataGridView.Width * 0.10f);
                //columnHeader.HeaderText = "Phase";
                //dataGridView.Columns.Add(columnHeader);
                ////columnHeader.ReadOnly = true;

                columnHeader = new DataGridViewTextBoxColumn();
                columnHeader.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                columnHeader.Width = (int)(dataGridView.Width * 0.05f);
                columnHeader.HeaderText = "MH";
                dataGridView.Columns.Add(columnHeader);
                columnHeader.ReadOnly = true;

                columnHeader = new DataGridViewTextBoxColumn();
                columnHeader.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                columnHeader.Width = (int)(dataGridView.Width * 0.05f);
                columnHeader.HeaderText = "Mans";
                dataGridView.Columns.Add(columnHeader);
                //columnHeader.ReadOnly = true;

                columnHeader = new DataGridViewTextBoxColumn();
                columnHeader.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                columnHeader.Width = (int)(dataGridView.Width * 0.08f);
                columnHeader.HeaderText = "Categories";
                dataGridView.Columns.Add(columnHeader);
                //columnHeader.ReadOnly = true;

                columnHeader = new DataGridViewTextBoxColumn();
                columnHeader.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                columnHeader.Width = (int)(dataGridView.Width * 0.05f);
                columnHeader.HeaderText = "Cost";
                dataGridView.Columns.Add(columnHeader);
                columnHeader.ReadOnly = true;

                columnHeader = new DataGridViewTextBoxColumn();
                columnHeader.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                columnHeader.Width = (int)(dataGridView.Width * 0.08f);
                columnHeader.HeaderText = "Kit Required";
                dataGridView.Columns.Add(columnHeader);
                columnHeader.ReadOnly = true;

                //columnHeader = new DataGridViewTextBoxColumn();
                //columnHeader.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //columnHeader.Width = (int)(dataGridView.Width * 0.08f);
                //columnHeader.HeaderText = "Performance";
                //dataGridView.Columns.Add(columnHeader);
                //columnHeader.ReadOnly = true;

                //columnHeader = new DataGridViewTextBoxColumn();
                //columnHeader.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //columnHeader.Width = (int)(dataGridView.Width * 0.08f);
                //columnHeader.HeaderText = "Rpt. Intv.";
                //dataGridView.Columns.Add(columnHeader);
                //columnHeader.ReadOnly = true;

                //columnHeader = new DataGridViewTextBoxColumn();
                //columnHeader.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //columnHeader.Width = (int)(dataGridView.Width * 0.08f);
                //columnHeader.HeaderText = "Overdue/Remain";
                //dataGridView.Columns.Add(columnHeader);
                //columnHeader.ReadOnly = true;

                //columnHeader = new DataGridViewTextBoxColumn();
                //columnHeader.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //columnHeader.Width = (int)(dataGridView.Width * 0.08f);
                //columnHeader.HeaderText = "Perf. Date";
                //dataGridView.Columns.Add(columnHeader);
                //columnHeader.ReadOnly = true;

            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while building list headers", ex);
                return;
            }
        }
        #endregion

        //#region protected override void SortItems(int columnIndex)
        //protected override void SortItems(int columnIndex)
        //{
        //    if (OldColumnIndex != columnIndex)
        //        SortMultiplier = -1;
        //    if (SortMultiplier == 1)
        //        SortMultiplier = -1;
        //    else
        //        SortMultiplier = 1;
        //    dataGridView.Rows.Clear();
        //    SetGroupsToItems();
        //    PreResultRowList.Sort(new BaseDataGridViewRowComparer(columnIndex, SortMultiplier));

        //    for (int i = 0; i < PreResultRowList.Count; i++)
        //    {
        //        PreResultRowList[i].Cells[0].Value = (i + 1).ToString();
        //        dataGridView.Rows.Add(PreResultRowList[i]);
        //    }

        //    OldColumnIndex = columnIndex;
        //    SetRowsBackColor();
        //}
        //#endregion

        #region protected override void SetGroupsToItems()
        protected override void SetGroupsToItems()
        {
            //if(_beginGroup == null || 
            //   _beginGroup.ReflectedType.Name != _viewedType.Name ||
            //   _viewedType.GetProperty(_beginGroup.Name) == null)
            //    return;

            //dataGridView.Groups.Clear();
            //foreach (ListViewItem item in PreResultRowList)
            //{
            //    String temp;

            //    if (item.Tag == null) continue;
            //    BaseEntityObject ob = item.Tag as BaseEntityObject;
            //    if (ob == null) continue;

            //    //Извлечение значения
            //    object value = _beginGroup.GetValue(ob, null);
            //    //Проверка значения на null
            //    if (value == null) 
            //        continue;

            //    if (value is IDictionaryItem)
            //        temp = ((IDictionaryItem)value).FullName;
            //    else if (value is BaseEntityObject)
            //        temp = value.ToString();
            //    else if (value is IThreshold)
            //        temp = value.ToString();
            //    else if (value is Lifelength)
            //        temp = value.ToString();
            //    else if (value.GetType().IsEnum)
            //        temp = UsefulMethods.EnumToString((Enum)value);
            //    else if (value is string)
            //        temp = (string)value;  
            //    else if (value is int)
            //        temp = ((int)value).ToString();
            //    else if (value is short)
            //        temp = ((short)value).ToString();
            //    else if (value is DateTime)
            //        temp = SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)value);
            //    else if (value is bool)
            //        temp = value.ToString();
            //    else if (value is double)
            //        temp = ((double)value).ToString();
            //    else
            //        temp = "Can't define group";

            //    itemsListView.Groups.Add(temp, temp);
            //    item.Group = itemsListView.Groups[temp];
            //}
        }
        #endregion

        #region protected override void SetItemColor(DataGridViewRow dataGridViewRow, BaseSmartCoreObject item)
        protected override void SetRowBackColor(DataGridViewRow dataGridViewRow, BaseEntityObject item)
        {
            if (item is NextPerformance)
            {
                NextPerformance nextPerformance = item as NextPerformance;
                if (_currentWorkPackage.Status != WorkPackageStatus.Closed)
                {
                    if (nextPerformance.BlockedByPackage != null)
                    {
                        dataGridViewRow.Cells[0].ToolTipText = "This performance blocked by work package:" +
                           nextPerformance.BlockedByPackage.Title;
                        dataGridViewRow.DefaultCellStyle.BackColor = Color.FromArgb(Highlight.Grey.Color);
                    }
                    else if (nextPerformance.Condition == ConditionState.Notify)
                        dataGridViewRow.DefaultCellStyle.BackColor = Color.FromArgb(Highlight.Yellow.Color);
                    else if (nextPerformance.Condition == ConditionState.Overdue)
                        dataGridViewRow.DefaultCellStyle.BackColor = Color.FromArgb(Highlight.Red.Color);
                }
                else
                {
                    //Если это следующее выполнение, но рабочий пакет при этом закрыт
                    //значит, выполнение для данной задачи в рамках данного рабочего пакета
                    //не было введено

                    //пометка этого выполнения краным цветом
                    dataGridViewRow.DefaultCellStyle.BackColor = Color.FromArgb(Highlight.Red.Color);
                    //подсказка о том, что выполнение не было введено
                    dataGridViewRow.Cells[0].ToolTipText = "Performance for this directive within this work package is not entered.";
                    if (nextPerformance.BlockedByPackage != null)
                    {
                        //дополнитльная подсказака, если предшествующее выполнение 
                        //имеется в другом открытом рабочем пакете
                        dataGridViewRow.Cells[0].ToolTipText += "\nThis performance blocked by work package:" +
                           nextPerformance.BlockedByPackage.Title +
                           "\nFirst, enter the performance of this directive as part of this work package ";
                    }
                }

                if (nextPerformance.Parent.IsDeleted)
                {
                    //запись так же может быть удаленной

                    //шрифт серым цветом
                    dataGridViewRow.DefaultCellStyle.ForeColor = Color.Gray;
                    if (dataGridViewRow.Cells[0].ToolTipText.Trim() != "")
                        dataGridViewRow.Cells[0].ToolTipText += "\n";
                    dataGridViewRow.Cells[0].ToolTipText +=
	                    $"This {nextPerformance.Parent.SmartCoreObjectType} is deleted";
                }
            }
            else if (item is AbstractPerformanceRecord)
            {
                AbstractPerformanceRecord apr = (AbstractPerformanceRecord)item;
                if (apr.Parent.IsDeleted)
                {
                    //запись так же может быть удаленной

                    //шрифт серым цветом
                    dataGridViewRow.DefaultCellStyle.ForeColor = Color.Gray;
                    if (dataGridViewRow.Cells[0].ToolTipText.Trim() != "")
                        dataGridViewRow.Cells[0].ToolTipText += "\n";
                    dataGridViewRow.Cells[0].ToolTipText += $"This {apr.Parent.SmartCoreObjectType} is deleted";
                }
            }
            else
            {
                if (!(item is NonRoutineJob))
                {
                    //Если это не следующее выполнение, не запись о выполнении, и не рутинная работа
                    //значит, выполнение для данной задачи расчитать нельзя

                    //пометка этого выполнения синим цветом
                    dataGridViewRow.DefaultCellStyle.BackColor = Color.FromArgb(Highlight.Blue.Color);
                    //подсказка о том, что выполнение не возможео расчитать
                    dataGridViewRow.Cells[0].ToolTipText = "Performance for this directive can not be calculated";
                }

                if (item.IsDeleted)
                {
                    //запись так же может быть удаленной

                    //шрифт серым цветом
                    dataGridViewRow.DefaultCellStyle.ForeColor = Color.Gray;
                    if (dataGridViewRow.Cells[0].ToolTipText.Trim() != "")
                        dataGridViewRow.Cells[0].ToolTipText += "\n";
                    dataGridViewRow.Cells[0].ToolTipText += $"This {item.SmartCoreObjectType} is deleted";
                }
            }
        }
        #endregion

        #region protected override void SetRowCellsValues(DataGridViewRow row, BaseEntityObject item)

        protected override void SetRowCellsValues(DataGridViewRow row, BaseEntityObject item)
        {
            AtaChapter ataChapter = null;
            string title = "";
            string description = "";
            //string zone = "";
            //string access = "";
            string taskType = "";
            MaintenanceDirectiveProgramType program = MaintenanceDirectiveProgramType.Unknown;
            StaticDictionary workType = null;
            //string phase = "";
            double manHours = 0;
            int mans = 0;
            string categories = "";
            double cost = 0;
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
                    program = engineeringDirective.Program;
                    workType = engineeringDirective.WorkType;
                    //phase = engineeringDirective.Phase;
                    manHours = engineeringDirective.ManHours;
                    mans = engineeringDirective.Mans;
                    categories = engineeringDirective.CategoriesRecords.Aggregate("", (current, i) => current + (i.AircraftWorkerCategory + "; "));
                    cost = engineeringDirective.Cost;
                }
                title = np.Title;
                description = np.Description;
                taskType = np.Parent.SmartCoreObjectType.ToString();
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
                    program = engineeringDirective.Program;
                    workType = engineeringDirective.WorkType;
                    //phase = engineeringDirective.Phase;
                    manHours = engineeringDirective.ManHours;
                    mans = engineeringDirective.Mans;
                    categories = engineeringDirective.CategoriesRecords.Aggregate("", (current, i) => current + (i.AircraftWorkerCategory + "; "));
                    cost = engineeringDirective.Cost;
                }
                title = apr.Title;
                description = apr.Description;
                taskType = apr.Parent.SmartCoreObjectType.ToString();
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
                program = engineeringDirective.Program;
                workType = engineeringDirective.WorkType;
                //phase = engineeringDirective.Phase;
                manHours = engineeringDirective.ManHours;
                mans = engineeringDirective.Mans;
                categories = engineeringDirective.CategoriesRecords.Aggregate("", (current, i) => current + (i.AircraftWorkerCategory + "; "));
                cost = engineeringDirective.Cost;
                title = engineeringDirective.Title;
                description = engineeringDirective.Description;
                taskType = engineeringDirective.SmartCoreObjectType.ToString();
                kits = engineeringDirective is IKitRequired ? ((IKitRequired)engineeringDirective).Kits.ToString() : "";
                //performance = engineeringDirective.NextPerformanceSource;
                //repeat = engineeringDirective.Threshold != null ? engineeringDirective.Threshold.RepeatInterval : Lifelength.Null;
                //performanceDate = engineeringDirective.NextPerformanceDate;
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
            row.Cells[3].Value = taskType;
            row.Cells[3].Tag = taskType;
            row.Cells[4].Value = program.ToString();
            row.Cells[4].Tag = program;
            row.Cells[5].Value = workType != null ? workType.ToString() : DirectiveType.Unknown.ToString();
            row.Cells[5].Tag = workType != null ? workType.ToString() : DirectiveType.Unknown.ToString();
            //row.Cells[8].Value = phase;
            //row.Cells[8].Tag = phase;
            row.Cells[6].Value = manHours.ToString();
            row.Cells[6].Tag = manHours;
            row.Cells[7].Value = mans.ToString();
            row.Cells[7].Tag = mans;
            row.Cells[8].Value = categories;
            row.Cells[8].Tag = categories;
            row.Cells[9].Value = cost.ToString();
            row.Cells[9].Tag = cost;
            row.Cells[10].Value = kits;
            row.Cells[10].Tag = kits;
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
            if (SelectedItem == null) return;

			var dp = ScreenAndFormManager.GetEditScreenOrForm(SelectedItem);
			if (dp.DisplayerType == DisplayerType.Screen)
				e.SetParameters(dp);
			else
			{
				if (dp.Form.ShowDialog() == DialogResult.OK)
				{
					if (dp.Form is NonRoutineJobForm)
					{
						var changedJob = GlobalObjects.CasEnvironment.NewLoader.GetObjectById<NonRoutineJobDTO,NonRoutineJob>(((NonRoutineJobForm)dp.Form).CurrentJob.ItemId, true);
						dataGridView.SelectedRows[0].Tag = changedJob;

						DataGridViewCell[] subs = GetRowCells(SelectedItem);
						for (int i = 0; i < subs.Length; i++)
							dataGridView.SelectedRows[0].Cells[i].Value = subs[i].Value;
					}
					e.Cancel = true;
				}
			}
        }
        #endregion

        #region private void HangarWorkPackageViewControlLoad(object sender, EventArgs e)
        private void HangarWorkPackageViewControlLoad(object sender, EventArgs e)
        {
            dataGridView.AllowUserToAddRows = false;
            dataGridView.RowHeadersVisible = false;
            SetHeaders();
        }
        #endregion

        #endregion
    }

    internal class WorkOrderViewControlDesigner : ControlDesigner
    {
        protected override void PostFilterProperties(IDictionary properties)
        {
            base.PostFilterProperties(properties);
            properties.Remove("WorkPackage");
            properties.Remove("ViewedType");
        }
    }
}
