using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.UIControls.NewGrid;
using CAS.UI.UIControls.WorkPakage;
using CASTerms;
using EntityCore.DTO.Dictionaries;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.WorkPackage;

namespace CAS.UI.UIControls.MaintenanceControlCenterControls
{
    ///<summary>
    /// список для отображения ордеров запроса
    ///</summary>
    public partial class AircraftMaintenanceControlListView : BaseGridViewControl<BaseEntityObject>
    {
        #region Fields

        private WorkPackage _currentWorkPackage;

        #endregion

        #region Constructors

        #region public AircraftMaintenanceControlListView()
        ///<summary>
        ///</summary>
        public AircraftMaintenanceControlListView()
        {
            InitializeComponent();
        }
        #endregion

        #region public WorkPackageView()
        ///<summary>
        ///</summary>
        public AircraftMaintenanceControlListView(WorkPackage currentWorkPackage) : this ()
        {
            _currentWorkPackage = currentWorkPackage;
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
			AddColumn("ATA", 75);
			AddColumn("Title", 100);
			AddColumn("Description", 125);
			AddColumn("MH", 60);
			AddColumn("Signer", (int)(radGridView1.Width * 0.2f));
        }
		#endregion

		#region protected override SetGroupsToItems(int columnIndex)
		/// <summary>
		/// Выполняет группировку элементов
		/// </summary>
		//protected override void SetGroupsToItems(int columnIndex)
  //      {
  //          itemsListView.Groups.Clear();
  //          foreach (var item in ListViewItemList)
  //          {
		//		var temp = ListViewGroupHelper.GetGroupString(item.Tag);

		//		itemsListView.Groups.Add(temp, temp);
		//		item.Group = itemsListView.Groups[temp];
		//	}
  //      }
        #endregion

        #region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(BaseSmartCoreObject item)

        protected override List<CustomCell> GetListViewSubItems(BaseEntityObject item)
        {
            var subItems = new List<CustomCell>();

            //if(item.ItemId == 41043)
            //{

            //}
            if(item is NextPerformance)
            {

                NextPerformance np = (NextPerformance) item;

                double manHours = np.Parent is IEngineeringDirective ? ((IEngineeringDirective)np.Parent).ManHours : 0;
                double cost = np.Parent is IEngineeringDirective ? ((IEngineeringDirective)np.Parent).Cost : 0;
                var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);

				subItems.Add(CreateRow(np.ATAChapter.ToString(), np.ATAChapter ));
                subItems.Add(CreateRow(np.Title, np.Title ));
                subItems.Add(CreateRow(np.Description, np.Description ));
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = np.KitsToString, Tag = np.Kits.Count });
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = np.PerformanceSource.ToString(), Tag = np.PerformanceSource });
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = np.Parent.Threshold.RepeatInterval.ToString(), Tag = np.Parent.Threshold.RepeatInterval });
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = np.Remains.ToString(), Tag = np.Remains });
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = np.WorkType, Tag = np.WorkType });
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = np.PerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)np.PerformanceDate), Tag = np.PerformanceDate });
                subItems.Add(CreateRow(manHours.ToString(),  manHours ));
				//subItems.Add(new ListViewItem.ListViewSubItem { Text = np.Parent.Cost.ToString(), Tag = np.Parent.Cost });
				subItems.Add(CreateRow(author, author ));

			}
            else if (item is AbstractPerformanceRecord)
            {
                //DirectiveRecord directiveRecord = (DirectiveRecord)item;
                AbstractPerformanceRecord apr = (AbstractPerformanceRecord)item;
                Lifelength remains = Lifelength.Null;

                double manHours = apr.Parent is IEngineeringDirective ? ((IEngineeringDirective)apr.Parent).ManHours : 0;
                double cost = apr.Parent is IEngineeringDirective ? ((IEngineeringDirective)apr.Parent).Cost : 0;

                subItems.Add(CreateRow(apr.ATAChapter.ToString(), apr.ATAChapter ));
                subItems.Add(CreateRow(apr.Title, apr.Title ));
                subItems.Add(CreateRow(apr.Description, apr.Description ));
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = apr.KitsToString, Tag = apr.Kits.Count });
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = apr.OnLifelength.ToString(), Tag = apr.OnLifelength });
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = apr.Parent.Threshold.RepeatInterval.ToString(), Tag = apr.Parent.Threshold.RepeatInterval });
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = remains.ToString(), Tag = remains });
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = apr.WorkType, Tag = apr.WorkType });
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = SmartCore.Auxiliary.Convert.GetDateFormat(apr.RecordDate), Tag = apr.RecordDate });
                subItems.Add(CreateRow(manHours.ToString(), manHours ));
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = apr.Parent.Cost.ToString(), Tag = apr.Parent.Cost });

            }
            else if (item is Directive)
            {
                Directive directive = (Directive)item;

                AtaChapter ata = directive.ATAChapter;
                subItems.Add(CreateRow(ata.ToString(), Tag = ata ));
                subItems.Add(CreateRow(directive.Title, directive.Title ));
                subItems.Add(CreateRow(directive.Description, directive.Description ));

                #region Определение текста для колонки "КИТы"
                //subItems.Add(new ListViewItem.ListViewSubItem
                //{
                //    Text = directive.Kits.Count > 0 ? directive.Kits.Count + " kits" : "",
                //    Tag = directive.Kits.Count
                //});
                #endregion

                #region Определение текста для колонки "Первое выполнение"

                //ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem();
                //if (directive.Threshold.FirstPerformanceSinceNew != null && !directive.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
                //{
                //    subItem.Text = "s/n: " + directive.Threshold.FirstPerformanceSinceNew;
                //    subItem.Tag = directive.Threshold.FirstPerformanceSinceNew;
                //}
                //if (directive.Threshold.FirstPerformanceSinceEffectiveDate != null &&
                //    !directive.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
                //{
                //    if (subItem.Text != "") subItem.Text += " or ";
                //    else
                //    {
                //        subItem.Text = "";
                //        subItem.Tag = directive.Threshold.FirstPerformanceSinceEffectiveDate;
                //    }
                //    subItem.Text += "s/e.d: " + directive.Threshold.FirstPerformanceSinceEffectiveDate;
                //}

                //subItems.Add(subItem);
                #endregion

                #region Определение текста для колонки "повторяющийся интервал"

                //subItem = new ListViewItem.ListViewSubItem();
                //if (!directive.Threshold.RepeatInterval.IsNullOrZero())
                //{
                //    subItem.Text = directive.Threshold.RepeatInterval.ToString();
                //    subItem.Tag = directive.Threshold.RepeatInterval;
                //}
                //else
                //{
                //    subItem.Text = "";
                //    subItem.Tag = Lifelength.Null;
                //}
                //subItems.Add(subItem);
                #endregion

                #region Определение текста для колонки "Остаток/Просрочено на сегодня"
                //subItems.Add(new ListViewItem.ListViewSubItem
                //{
                //    Text = directive.Remains.ToString(),
                //    Tag = directive.Remains
                //});
                #endregion

                #region Определение текста для колонки "Тип работ"

                //subItems.Add(new ListViewItem.ListViewSubItem { Text = directive.WorkType.ToString(), Tag = directive.WorkType });
                #endregion

                #region Определение текста для колонки "Следующее выполнение"
                //subItems.Add(new ListViewItem.ListViewSubItem
                //{
                //    Text = directive.NextPerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)directive.NextPerformanceDate),
                //    Tag = directive.NextPerformanceDate
                //});
                #endregion

                #region Определение текста для колонки "Человек/Часы"

                subItems.Add(CreateRow(directive.ManHours.ToString(), directive.ManHours ));
                #endregion

                #region Определение текста для колонки "Стоимость"

                //subItems.Add(new ListViewItem.ListViewSubItem { Text = directive.Cost.ToString(), Tag = directive.Cost });
                #endregion
            }
            else if (item is BaseComponent)
            {
                BaseComponent bd = (BaseComponent)item;
                AtaChapter ata = bd.ATAChapter;

                subItems.Add(CreateRow(ata.ToString(), ata ));
                subItems.Add(CreateRow(bd.PartNumber, bd.PartNumber ));
                subItems.Add(CreateRow(bd.Description, bd.Description ));
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = bd.Kits.Count > 0 ? bd.Kits.Count + " kits" : "", Tag = bd.Kits.Count });
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = bd.LifeLimit.ToString(), Tag = bd.LifeLimit });
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = Lifelength.Null });
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = bd.Remains.ToString(), Tag = bd.Remains });
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = DetailRecordType.Removal.ToString(), Tag = DetailRecordType.Removal });
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = bd.NextPerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)bd.NextPerformanceDate), Tag = bd.NextPerformanceDate });
                subItems.Add(CreateRow(bd.ManHours.ToString(), bd.ManHours ));
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = bd.Cost.ToString(), Tag = bd.Cost });
            }
            else if (item is Component)
            {
                Component d = (Component)item;
                AtaChapter ata = d.ATAChapter;

                subItems.Add(CreateRow(ata.ToString(), ata ));
                subItems.Add(CreateRow(d.PartNumber, d.PartNumber ));
                subItems.Add(CreateRow(d.Description, d.Description ));
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = d.Kits.Count > 0 ? d.Kits.Count + " kits" : "", Tag = d.Kits.Count });
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = d.LifeLimit != null ? d.LifeLimit.ToString() : "", Tag = d.LifeLimit });
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = Lifelength.Null });
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = d.Remains != null ? d.Remains.ToString() : "", Tag = d.Remains });
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = DetailRecordType.Removal.ToString(), Tag = DetailRecordType.Removal });
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = d.NextPerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)d.NextPerformanceDate), Tag = d.NextPerformanceDate });
                subItems.Add(CreateRow(d.ManHours.ToString(), d.ManHours ));
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = d.Cost.ToString(), Tag = d.Cost });
            }
            else if (item is ComponentDirective)
            {
                ComponentDirective dd = (ComponentDirective)item;
                AtaChapter ata = dd.ParentComponent.ATAChapter;

                subItems.Add(CreateRow(ata != null ? ata.ToString() : "", ata ));
                subItems.Add(CreateRow("", "" ));
                subItems.Add(CreateRow(dd.Remarks, dd.Remarks ));
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = dd.Kits.Count > 0 ? dd.Kits.Count + " kits" : "", Tag = dd.Kits.Count });
                #region Определение текста для колонки "Первое выполнение"

                //ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem();
                //if (dd.Threshold.FirstPerformanceSinceNew != null && !dd.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
                //{
                //    subItem.Text = "s/n: " + dd.Threshold.FirstPerformanceSinceNew;
                //    subItem.Tag = dd.Threshold.FirstPerformanceSinceNew;
                //}
                //subItems.Add(subItem);
                #endregion

                #region Определение текста для колонки "повторяющийся интервал"

                //subItem = new ListViewItem.ListViewSubItem();
                //if (!dd.Threshold.RepeatInterval.IsNullOrZero())
                //{
                //    subItem.Text = dd.Threshold.RepeatInterval.ToString();
                //    subItem.Tag = dd.Threshold.RepeatInterval;
                //}
                //else
                //{
                //    subItem.Text = "";
                //    subItem.Tag = Lifelength.Null;
                //}
                //subItems.Add(subItem);

                #endregion
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = dd.Remains.ToString(), Tag = dd.Remains });
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = dd.DirectiveType.ToString(), Tag = dd.DirectiveType });
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = dd.NextPerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)dd.NextPerformanceDate), Tag = dd.NextPerformanceDate });
                subItems.Add(CreateRow(dd.ManHours.ToString(), dd.ManHours ));
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = dd.Cost.ToString(), Tag = dd.Cost });
            }
            else if (item is MaintenanceCheck)
            {
                MaintenanceCheck mc = (MaintenanceCheck)item;
                subItems.Add(CreateRow("", null ));
                subItems.Add(CreateRow("", Tag = "" ));
                subItems.Add(CreateRow(mc.Name + (mc.Schedule ? " Shedule" : " Unshedule"), mc.Name ));
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = mc.Kits.Count > 0 ? mc.Kits.Count + " kits" : "", Tag = mc.Kits.Count });
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = mc.Interval.ToString(), Tag = mc.Interval });
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = Lifelength.Null });
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = mc.Remains.ToString(), Tag = mc.Remains });
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = mc.NextPerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)mc.NextPerformanceDate), Tag = mc.NextPerformanceDate });
                subItems.Add(CreateRow(mc.ManHours.ToString(), mc.ManHours ));
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = mc.Cost.ToString(), Tag = mc.Cost });
            }
            else if (item is MaintenanceDirective)
            {
                MaintenanceDirective md = (MaintenanceDirective)item;
                AtaChapter ata = md.ATAChapter;

                subItems.Add(CreateRow(ata != null ? ata.ToString() : "", ata ));
                subItems.Add(CreateRow(md.ToString(), md.ToString()));
                subItems.Add(CreateRow(md.Description, md.Description ));
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = md.Kits.Count > 0 ? md.Kits.Count + " kits" : "", Tag = md.Kits.Count });
                #region Определение текста для колонки "Первое выполнение"

                //ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem();
                //if (md.Threshold.FirstPerformanceSinceNew != null && !md.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
                //{
                //    subItem.Text = "s/n: " + md.Threshold.FirstPerformanceSinceNew;
                //    subItem.Tag = md.Threshold.FirstPerformanceSinceNew;
                //}
                //if (md.Threshold.FirstPerformanceSinceEffectiveDate != null &&
                //    !md.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
                //{
                //    if (subItem.Text != "") subItem.Text += " or ";
                //    else
                //    {
                //        subItem.Text = "";
                //        subItem.Tag = md.Threshold.FirstPerformanceSinceEffectiveDate;
                //    }
                //    subItem.Text += "s/e.d: " + md.Threshold.FirstPerformanceSinceEffectiveDate;
                //}

                //subItems.Add(subItem);
                #endregion

                #region Определение текста для колонки "повторяющийся интервал"

                //subItem = new ListViewItem.ListViewSubItem();
                //if (!md.Threshold.RepeatInterval.IsNullOrZero())
                //{
                //    subItem.Text = md.Threshold.RepeatInterval.ToString();
                //    subItem.Tag = md.Threshold.RepeatInterval;
                //}
                //else
                //{
                //    subItem.Text = "";
                //    subItem.Tag = Lifelength.Null;
                //}
                //subItems.Add(subItem);

                #endregion
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = md.Remains.ToString(), Tag = md.Remains });
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = md.WorkType.ToString(), Tag = md.WorkType });
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = md.NextPerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)md.NextPerformanceDate), Tag = md.NextPerformanceDate });
                subItems.Add(CreateRow(md.ManHours.ToString(), md.ManHours ));
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = md.Cost.ToString(), Tag = md.Cost });
            }
            else if (item is NonRoutineJob)
            {
                NonRoutineJob job = (NonRoutineJob)item;
                AtaChapter ata = job.ATAChapter;
                subItems.Add(CreateRow(ata != null ? ata.ToString() : "", ata ));
                subItems.Add(CreateRow(job.Title, job.Title ));
                subItems.Add(CreateRow(job.Description, job.Description ));
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = job.Kits.Count > 0 ? job.Kits.Count + " kits" : "", Tag = job.Kits.Count });
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = Lifelength.Null });
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = Lifelength.Null });
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = Lifelength.Null });
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = new DateTime(1950,1,1) });
                subItems.Add(CreateRow(job.ManHours.ToString(), job.ManHours ));
                //subItems.Add(new ListViewItem.ListViewSubItem { Text = job.Cost.ToString(), Tag = job.Cost });
            }
            else throw new ArgumentOutOfRangeException(String.Format("1135: Takes an argument has no known type {0}", item.GetType()));

            return subItems;
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
						radGridView1.SelectedRows[0].Tag = changedJob;

						var subs = GetListViewSubItems(SelectedItem);
						for (int i = 0; i < subs.Count; i++)
							radGridView1.SelectedRows[0].Cells[i].Value = subs[i].Text;
					}
					e.Cancel = true;
				}
			}
		}
        #endregion

        #endregion
    }
}
