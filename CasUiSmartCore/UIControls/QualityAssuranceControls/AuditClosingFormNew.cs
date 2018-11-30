using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary.DataGridViewElements;
using CAS.UI.UIControls.WorkPakage;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.Quality;
using SmartCore.Entities.General.Store;
using TempUIExtentions;
using Convert = System.Convert;

namespace CAS.UI.UIControls.QualityAssuranceControls
{
    ///<summary>
    ///</summary>
    public partial class AuditClosingFormNew : Form
    {
        #region Fields
        
        private readonly Audit _currentAudit;

        //private List<WorkPackageClosingFormItem> _closingItems;
        
        #endregion

        #region Constructors

        #region public AuditClosingFormNew()
        ///<summary>
        ///</summary>
        public AuditClosingFormNew()
        {
            InitializeComponent();
        }
        #endregion

        #region public AuditClosingFormNew(Audit workPackage) : this ()
        ///<summary>
        ///</summary>
        ///<param name="workPackage"></param>
        public AuditClosingFormNew(Audit workPackage)
            : this()
        {
            _currentAudit = workPackage;

            UpdateInformation();
        }

        #endregion

        #endregion

        #region Properties

        #region public DateTime ClosingDate
        ///<summary>
        ///</summary>
        public DateTime ClosingDate
        {
            get
            {
                return dateTimePickerClosingDate.Value;
            }
            set
            {
                dateTimePickerClosingDate.Value = value;
            }
        }
        #endregion

        #endregion

        #region Methods

        #region private void UpdateInformation()
        ///<summary>
        ///</summary>
        private void UpdateInformation()
        {
            if(_currentAudit == null)return;
            
            Text = _currentAudit.Title;
            dataGridViewItems.Rows.Clear();
            
            DateTime minComplianceDate = DateTimeExtend.GetCASMinDateTime();

            IEnumerable<AuditRecord> proceduresRecords =
                _currentAudit.AuditRecords.Where(wpr => wpr.Task != null &&
                                                        wpr.Task is Procedure);

            List<IGrouping<string, AuditRecord>> groupedDirectiveWprs =
                proceduresRecords.GroupBy(wpr => (((Procedure)wpr.Task).ProcedureType).FullName).ToList();

            checkBoxSelectAll.CheckedChanged -= CheckBoxSelectAllCheckedChanged;

            foreach (IGrouping<string , AuditRecord> grouping in groupedDirectiveWprs)
            {
                //добавить расчеты ComlianceDate
                foreach (AuditRecord item in grouping)
                {
                    if(item.Task is Procedure ||
                       item.Task is Directive ||
                       item.Task is ComponentDirective ||
                       item.Task is MaintenanceCheck ||
                       item.Task is MaintenanceDirective)
                    {
                        //WorkPackageClosingDataGridViewRow r = new WorkPackageClosingDataGridViewRow();
                        //r.CreateCells(dataGridViewItems);
                        //int index = dataGridViewItems.Rows.Add(r);
                        //index.ToString();

                        WorkPackageClosingDataGridViewRow r = (WorkPackageClosingDataGridViewRow)
                            dataGridViewItems.Rows[dataGridViewItems.Rows.Add(new WorkPackageClosingDataGridViewRow())];
                        if (item.Task.NextPerformances.Count > 0)
                        {
                            SetValues(r, _currentAudit, item.Task.NextPerformances[0]);
                        }
                        else if (item.Task.PerformanceRecords.Cast<AbstractPerformanceRecord>().Any(pr => pr.DirectivePackageId == _currentAudit.ItemId))
                        {
                            AbstractPerformanceRecord apr =
                                item.Task.PerformanceRecords
                                .Cast<AbstractPerformanceRecord>()
                                .First(pr => pr.DirectivePackageId == _currentAudit.ItemId);
                            SetValues(r, _currentAudit, apr);
                        }
                        else SetValues(r, _currentAudit, item);
                    }

                    if(item.Task is Component)
                    {
                        //WorkPackageClosingDataGridViewRow r = new WorkPackageClosingDataGridViewRow();
                        //r.CreateCells(dataGridViewItems);
                        //dataGridViewItems.Rows.Add(r);

                        WorkPackageClosingDataGridViewRow r = (WorkPackageClosingDataGridViewRow)
                            dataGridViewItems.Rows[dataGridViewItems.Rows.Add(new WorkPackageClosingDataGridViewRow())];

                        Component component = (Component)item.Task;
                        if (component.NextPerformances.Count > 0)
                        {
                            SetValues(r, _currentAudit, component.NextPerformances[0]);
                        }
                        else if (component.TransferRecords.Any(pr => pr.DirectivePackageId == _currentAudit.ItemId))
                        {
                            AbstractPerformanceRecord apr =
                                component.TransferRecords
                                .Cast<AbstractPerformanceRecord>()
                                .First(pr => pr.DirectivePackageId == _currentAudit.ItemId);
                            SetValues(r, _currentAudit, apr);
                        }
                        else SetValues(r, _currentAudit, item);
                    }
                }
            }

            dateTimePickerClosingDate.ValueChanged -= DateTimePickerClosingDateValueChanged;

            dateTimePickerClosingDate.Value = _currentAudit.Status != WorkPackageStatus.Closed 
                ? minComplianceDate 
                : _currentAudit.ClosingDate;
            dateTimePickerClosingDate.MinDate = _currentAudit.MinClosingDate != null
                ? _currentAudit.MinClosingDate.Value
                : DateTimeExtend.GetCASMinDateTime();
            dateTimePickerClosingDate.MaxDate = _currentAudit.MaxClosingDate != null
                ? _currentAudit.MaxClosingDate.Value
                : DateTimeExtend.GetCASMinDateTime();

            dateTimePickerClosingDate.ValueChanged += DateTimePickerClosingDateValueChanged;

            checkBoxSelectAll.CheckedChanged += CheckBoxSelectAllCheckedChanged;

            fileControl.AttachedFile = _currentAudit.AttachedFile;
        }
        #endregion

        #region private bool ValidateData()

        private bool ValidateData()
        {
            foreach (WorkPackageClosingDataGridViewRow row in dataGridViewItems.Rows.OfType<WorkPackageClosingDataGridViewRow>())
            {
                if ((bool)row.Cells[ColumnClosed.Index].Value == false)
                    continue;

                string message;
                if (row.ClosingItem is Component)
                {
                    TransferRecord tr = row.Record as TransferRecord;
                    if (tr == null)
                    {
                        message =
                        string.Format("Performance for:" +
                                      "\n{0} " +
                                      "\nin not transfer record",
                                      row.ClosingItem);
                        message += "\nAbort operation";
                        MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (tr.DestinationObjectId == 0 || tr.TransferDate < DateTimeExtend.GetCASMinDateTime())
                    {
                        message = @"Displacement parameters are specified components" +
                                   "\nClick the link 'Edit Transfer' for set it";
                        message += "\nAbort operation";
                        MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    if (!Lifelength.ValidateHours((string)row.Cells[ColumnHours.Index].Value))
                    {
                        MessageBox.Show("Invalid value for hours parameter",
                                        new GlobalTermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                        
                        row.Cells[ColumnHours.Index].Style.BackColor = Color.Red;
                        
                        return false;
                    }
                    if (!Lifelength.ValidateCyclesOrDays((string)row.Cells[ColumnCycles.Index].Value))
                    {
                        MessageBox.Show("Invalid value for cycles parameter",
                                        new GlobalTermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);

                        row.Cells[ColumnCycles.Index].Style.BackColor = Color.Red;

                        return false;
                    }
                }
            }
            return true;
        }
        #endregion

        #region private bool SaveData()

        /// <summary>
        /// Данные работы обновляются по введенным значениям
        /// </summary>
        private void SaveData()
        {
            foreach (WorkPackageClosingDataGridViewRow row in dataGridViewItems.Rows.OfType<WorkPackageClosingDataGridViewRow>())
            {
                if ((bool)row.Cells[ColumnClosed.Index].Value == false)
                    continue;
                try
                {
                    DateTime performDate = (DateTime) row.Cells[ColumnDate.Index].Value;
                    if (row.ClosingItem is Procedure)
                    {
                        Procedure dir = (Procedure)row.ClosingItem;
                        DirectiveRecord directiveRecord = (DirectiveRecord)row.Record;

                        if (directiveRecord.ItemId <= 0)
                        {
                            directiveRecord.Completed = true;
                            directiveRecord.RecordType = DirectiveRecordType.Perfromed;
                            directiveRecord.RecordTypeId = DirectiveRecordType.Perfromed.ItemId;
                            directiveRecord.Remarks = "Audit " + _currentAudit.Title + " Close " + dir.ProcedureType.CommonName + " Procedure";
                        }
                        directiveRecord.RecordDate = performDate;
                        Lifelength performanceSource;
                        directiveRecord.OnLifelength = Lifelength.TryParse((string) row.Cells[ColumnHours.Index].Value,
                                                                           (string) row.Cells[ColumnCycles.Index].Value,
                                                                           (string) row.Cells[ColumnDays.Index].Value,
                                                                           out performanceSource) ? performanceSource : Lifelength.Zero;

                        GlobalObjects.PerformanceCore.RegisterPerformance(dir, directiveRecord, _currentAudit);
                    }
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while saving performance for directive", ex);
                }
            }
            //_closingItems.All(item => item.SaveData());

            IEnumerable<MaintenanceCheck> closedChecks = 
                dataGridViewItems.Rows.OfType<WorkPackageClosingDataGridViewRow>()
                                      .Where(ci => ci.ClosingItem is MaintenanceCheck)
                                      .Select(ci => ci.ClosingItem as MaintenanceCheck);

            foreach (MaintenanceCheck mc in closedChecks)
            {
                MaintenanceCheckRecord mcRecord =
                    mc.PerformanceRecords.FirstOrDefault(pr => pr.DirectivePackageId == _currentAudit.ItemId);
                if(mcRecord == null)
                    continue;
                IEnumerable<DirectiveRecord> bindedMpdsRecords =
                    dataGridViewItems.Rows.OfType<WorkPackageClosingDataGridViewRow>()
                                          .Where(ci => ci.ClosingItem is MaintenanceDirective)
                                          .Select(ci => ci.ClosingItem as MaintenanceDirective)
                                          .Where(mpd => mpd.MaintenanceCheck != null 
                                                     && mpd.MaintenanceCheck.ItemId == mc.ItemId 
                                                     && mpd.PerformanceRecords.FirstOrDefault(pr => pr.DirectivePackageId == _currentAudit.ItemId) != null)
                                          .Select(mpd => mpd.PerformanceRecords.FirstOrDefault(pr => pr.DirectivePackageId == _currentAudit.ItemId));
                foreach (DirectiveRecord mpdsRecord in bindedMpdsRecords)
                {
                    mpdsRecord.MaintenanceCheckRecordId = mcRecord.ItemId;
                    GlobalObjects.CasEnvironment.NewKeeper.Save(mpdsRecord, false);
                }
            }
        }

        #endregion

        #region private void ButtonCloceWpClick(object sender, EventArgs e)

        private void ButtonCloceWpClick(object sender, EventArgs e)
        {
            if(!ValidateData())
            {
                return;
            }

            if(fileControl.GetChangeStatus())
            {
                fileControl.ApplyChanges();
                _currentAudit.AttachedFile = fileControl.AttachedFile;
            }
            _currentAudit.Status = WorkPackageStatus.Closed;
            _currentAudit.ClosingDate = dateTimePickerClosingDate.Value;
            _currentAudit.ClosedBy = GlobalObjects.CasEnvironment.CurrentUser.Login;
            _currentAudit.ClosingRemarks = "";

            if (string.IsNullOrEmpty(_currentAudit.PublishedBy))
                _currentAudit.PublishedBy = GlobalObjects.CasEnvironment.CurrentUser.Login;
            if (_currentAudit.PublishingDate <= _currentAudit.OpeningDate)
                _currentAudit.PublishingDate = _currentAudit.OpeningDate;
            try
            {
                GlobalObjects.CasEnvironment.NewKeeper.Save(_currentAudit);
                SaveData();
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error, while close Audit.", ex);
                return;
            }

            DialogResult = DialogResult.OK;
        }
        
        #endregion

        #region private void ButtonCancelClick(object sender, EventArgs e)

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        #endregion

        #region private void CheckBoxSelectAllCheckedChanged(object sender, EventArgs e)
        private void CheckBoxSelectAllCheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxSelectAll.CheckState == CheckState.Indeterminate)
                return;

            dataGridViewItems.CellValueChanged -= DataGridViewItemsCellValueChanged;

            foreach (WorkPackageClosingDataGridViewRow row in dataGridViewItems.Rows.OfType<WorkPackageClosingDataGridViewRow>()
                                                                               .Where(r => r.ClosingItem != null
                                                                                        && !r.ClosingItem.IsClosed))
            {
                row.Cells[ColumnClosed.Index].Value = checkBoxSelectAll.Checked;
            }

            dataGridViewItems.CellValueChanged += DataGridViewItemsCellValueChanged;
        }
        #endregion

        #region private void DataGridViewItemsCellContentClick(object sender, DataGridViewCellEventArgs e)

        private void DataGridViewItemsCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0)
                return;
            //if(e.ColumnIndex == ColumnHours.Index)
            //{
            //    if (_currentAudit == null) return;

            //    WorkPackageClosingDataGridViewRow row =
            //       dataGridViewItems.Rows[e.RowIndex] as WorkPackageClosingDataGridViewRow;
            //    if (row != null && 
            //        row.ClosingItem is Detail &&
            //        row.Record is TransferRecord &&
            //        row.Cells[ColumnHours.Index] is DataGridViewLinkCell)
            //    {
            //        Detail detail = (Detail)row.ClosingItem;
            //        Aircraft currentAircraft = detail.ParentAircraft;
            //        MoveDetailForm form = new MoveDetailForm(new[] { detail }, currentAircraft, _currentAudit);

            //        form.ShowDialog();
            //        if (form.DialogResult == DialogResult.OK)
            //        {
            //            try
            //            {
            //                if (row.Record.ItemId <= 0)
            //                {
            //                    //Запись о перемещении еще на была сохранена
            //                    //Реинициализация
            //                    row.Record = form.GetTransferData();
            //                }
            //                else
            //                {
            //                    TransferRecord changet = form.GetTransferData();
            //                    TransferRecord tr = (TransferRecord)row.Record;
            //                    tr.DestinationObjectId = changet.DestinationObjectId;
            //                    tr.DestinationObjectType = changet.DestinationObjectType;
            //                    tr.Position = changet.Position;
            //                    tr.Remarks = changet.Remarks;
            //                    if (!tr.PODR) tr.StartTransferDate = changet.StartTransferDate;
            //                    if (!tr.DODR) tr.TransferDate = changet.TransferDate;
            //                }

            //                if (row.Record != null)
            //                {
            //                    DataGridViewCalendarCell calendarCell =
            //                        (DataGridViewCalendarCell)row.Cells[ColumnDate.Index];

            //                    row.Cells[ColumnCycles.Index].Value = "Transfer to: " + GetDestination((TransferRecord)row.Record);
            //                    if (row.Record.RecordDate > calendarCell.MaxDate
            //                        && (row.Record.RecordDate - calendarCell.MaxDate).TotalDays < 1.0)
            //                    {
            //                        calendarCell.MaxDate = row.Record.RecordDate;
            //                    }
            //                    calendarCell.Value = row.Record.RecordDate;
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                Program.Provider.Logger.Log("Error while create transfer record", ex);
            //            }
            //        }
            //    }
            //}
        }
        #endregion

        #region private void DataGridViewItemsDataError(object sender, DataGridViewDataErrorEventArgs e)
        private void DataGridViewItemsDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Program.Provider.Logger.Log("Error in Audit Closing Form Data Grid", e.Exception);
        }
        #endregion

        #region private void DataGridViewItemsCurrentCellDirtyStateChanged(object sender, EventArgs e)

        private void DataGridViewItemsCurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            Point po = ((DataGridView)sender).CurrentCellAddress;

            if (po.X == ColumnDate.Index || po.X == ColumnClosed.Index)
                dataGridViewItems.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        #endregion

        #region private void DataGridViewItemsCellValueChanged(object sender, DataGridViewCellEventArgs e)

        private void DataGridViewItemsCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            #region //Проверка колонки "Выполнено"
            if (e.ColumnIndex == ColumnClosed.Index)
            {
                checkBoxSelectAll.CheckedChanged -= CheckBoxSelectAllCheckedChanged;

                IEnumerable<WorkPackageClosingDataGridViewRow> rows =
                    dataGridViewItems.Rows.OfType<WorkPackageClosingDataGridViewRow>();
                bool checkedValue = rows.FirstOrDefault(r => (bool)r.Cells[ColumnClosed.Index].Value) != null;
                bool unCheckedValue = rows.FirstOrDefault(r => !(bool)r.Cells[ColumnClosed.Index].Value) != null;
                if (checkedValue && unCheckedValue)
                    checkBoxSelectAll.CheckState = CheckState.Indeterminate;
                else if (checkedValue)
                    checkBoxSelectAll.CheckState = CheckState.Checked;
                else checkBoxSelectAll.CheckState = CheckState.Unchecked;

                checkBoxSelectAll.CheckedChanged += CheckBoxSelectAllCheckedChanged;
            }
            #endregion

            #region //Проверка колонки "Часы"
            if (e.ColumnIndex == ColumnHours.Index)
            {
                WorkPackageClosingDataGridViewRow row =
                    dataGridViewItems.Rows[e.RowIndex] as WorkPackageClosingDataGridViewRow;
                if (row == null || row.ClosingItem is Component)
                    return;
                DataGridViewCell cell = dataGridViewItems[e.ColumnIndex, e.RowIndex];
                string value = cell.Value as string;
                if (value == null)
                    return;
                if (Lifelength.ValidateHours(value))
                {
                    int? totalMinutes = Lifelength.ParseTotalMinutes(value);
                    if(totalMinutes == null)
                        return;

                    if (row.MinPerfSource != null &&
                        row.MinPerfSource.TotalMinutes != null &&
                        row.MinPerfSource.TotalMinutes > totalMinutes)
                    {
                        cell.Style.BackColor = Color.Red;
                    }
                    else cell.Style.BackColor = Color.White;
                }
                else cell.Style.BackColor = Color.Red;
            }
            #endregion

            #region //Проверка колонки "Циклы"
            if (e.ColumnIndex == ColumnCycles.Index)
            {
                WorkPackageClosingDataGridViewRow row =
                    dataGridViewItems.Rows[e.RowIndex] as WorkPackageClosingDataGridViewRow;
                if (row == null || row.ClosingItem is Component)
                    return;

                DataGridViewCell cell = dataGridViewItems[e.ColumnIndex, e.RowIndex];
                string value = cell.Value as string;
                if (value == null)
                    return;
                if (Lifelength.ValidateCyclesOrDays(value))
                {
                    int? cycles = Lifelength.ParseCyclesOrDays(value);
                    if (cycles == null)
                        return;
                    if (row.MinPerfSource != null &&
                        row.MinPerfSource.Cycles != null &&
                        row.MinPerfSource.Cycles > cycles)
                    {
                        cell.Style.BackColor = Color.Red;
                    }
                    else cell.Style.BackColor = Color.White;
                }
                else cell.Style.BackColor = Color.Red;
            }
            #endregion

            #region //Проверка колонки "Дни"
            if (e.ColumnIndex == ColumnDays.Index)
            {
                WorkPackageClosingDataGridViewRow row =
                    dataGridViewItems.Rows[e.RowIndex] as WorkPackageClosingDataGridViewRow;
                if (row == null || row.ClosingItem is Component)
                    return;

                DataGridViewCell cell = dataGridViewItems[e.ColumnIndex, e.RowIndex];
                string value = cell.Value as string;
                if (value == null)
                    return;
                if (Lifelength.ValidateCyclesOrDays(value))
                {
                    int? cycles = Lifelength.ParseCyclesOrDays(value);
                    if (cycles == null)
                        return;
                    if (row.MinPerfSource != null &&
                        row.MinPerfSource.Days != null &&
                        row.MinPerfSource.Days > cycles)
                    {
                        cell.Style.BackColor = Color.Red;
                    }
                    else cell.Style.BackColor = Color.White;
                }
                else cell.Style.BackColor = Color.Red;
            }
            #endregion

            #region //Проверка колонки "Дата"

            if (e.ColumnIndex == ColumnDate.Index)
            {
                WorkPackageClosingDataGridViewRow row =
                    dataGridViewItems.Rows[e.RowIndex] as WorkPackageClosingDataGridViewRow;
                if (row != null && !(row.ClosingItem is Component))
                {
                    DateTime dateTime = Convert.ToDateTime(row.Cells[ColumnDate.Index].Value);

                    if (row.PrevPerfDate != null && dateTime < row.PrevPerfDate)
                        row.Cells[ColumnDate.Index].Value = row.PrevPerfDate.Value;
                    else if (dateTime < new DateTime(1950, 1, 1))
                        row.Cells[ColumnDate.Index].Value = DateTimeExtend.GetCASMinDateTime();
                    if (row.NextPerfDate != null && dateTime > row.NextPerfDate)
                        row.Cells[ColumnDate.Index].Value = row.NextPerfDate.Value;
                    else if (dateTime > DateTime.Now)
                        row.Cells[ColumnDate.Index].Value = DateTime.Now;

                    if (row.ClosingItem.LifeLengthParent is Operator)
                    {
                        row.Cells[ColumnHours.Index].Value = "n/a";
                        row.Cells[ColumnCycles.Index].Value = "n/a";
                        row.Cells[ColumnDays.Index].Value = "n/a";    
                    }
                    else
                    {
                        Lifelength performanceSource =
                            GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnStartOfDay(row.ClosingItem.LifeLengthParent, dateTime);
                        row.Cells[ColumnHours.Index].Value = performanceSource.Hours != null ? performanceSource.ToHoursMinutesFormat("") : "n/a";
                        row.Cells[ColumnCycles.Index].Value = performanceSource.Cycles != null ? performanceSource.Cycles.ToString() : "n/a";
                        row.Cells[ColumnDays.Index].Value = performanceSource.Days != null ? performanceSource.Days.ToString() : "n/a";
                    }
                }
            }
            #endregion
        }
        #endregion

        #region private void DateTimePickerClosingDateValueChanged(object sender, EventArgs e)

        private void DateTimePickerClosingDateValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerClosingDate.Value > DateTime.Today)
            {
                dateTimePickerClosingDate.Value = DateTime.Today;
                return;
            }

            if(_currentAudit == null) return;
            foreach (WorkPackageClosingDataGridViewRow row in dataGridViewItems.Rows.OfType<WorkPackageClosingDataGridViewRow>()
                                                                                    .Where(r => r.ClosingItem != null 
                                                                                             && !r.ClosingItem.IsClosed))
            {
                DataGridViewCalendarCell calendarCell;
                if(row.Cells.Count >= ColumnDate.Index && (calendarCell = row.Cells[ColumnDate.Index] as DataGridViewCalendarCell) != null)
                {
                    calendarCell.Value = dateTimePickerClosingDate.Value;
                }
            }
        }
        #endregion

        #region private string GetDestination(TransferRecord record)
        ///<summary>
        ///</summary>
        ///<param name="record"></param>
        ///<returns></returns>
        //TODO:(Evgenii Babak) убрать метод и его использования т.к. сюда не передается TransferRecord
        private string GetDestination(TransferRecord record)
        {
            if (record.DestinationObjectType == SmartCoreType.Store)
            {
                Store parentStore =
                    GlobalObjects.CasEnvironment.Stores.GetItemById(record.DestinationObjectId);
                if (parentStore == null) parentStore = GlobalObjects.CasEnvironment.Stores[0];

                return parentStore.Name;
            }

            if (record.DestinationObjectType == SmartCoreType.BaseComponent)
            {
                //объект перемещается на базовую деталь
                BaseComponent destinationBaseComponent =
                    GlobalObjects.CasEnvironment.BaseComponents.
                    GetItemById(record.DestinationObjectId);

                if (destinationBaseComponent == null)
                {
                    //Назначенная базовая отсутствует
                    return "error: can't find base detail";
                }
                if (destinationBaseComponent.ParentAircraftId > 0)
                {
                    //Назначенная базовая деталь находится на самолете
                    return $"{destinationBaseComponent.GetParentAircraftRegNumber()} {destinationBaseComponent.Description}";
				}
				var parentStore = GlobalObjects.StoreCore.GetStoreById(destinationBaseComponent.ParentStoreId);
				if (parentStore != null)
                {
                    //Назначенная базовая деталь находится на складу
                    return $"{parentStore.Name} {destinationBaseComponent.Description}";
				}

            }

            if (record.DestinationObjectType == SmartCoreType.Aircraft)
            {
                //Объект перемещается на самолет 
                var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(record.DestinationObjectId);//TODO:(Evgenii Babak) пересмотреть использование DestinationObjectId здесь
				if (parentAircraft != null)
				{
					var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(parentAircraft.AircraftFrameId);
                    return parentAircraft.RegistrationNumber + " Frame: " + aircraftFrame.SerialNumber;
                }
            }
            return "error: can't find destination object";
        }
        #endregion

        #region private void GetRecordInstance(WorkPackageClosingDataGridViewRow row, WorkPackage wp, NextPerformance nextPerformance = null, WorkPackageRecord workPackageRecord = null)
        /// <summary>
        /// 
        /// </summary>
        private void GetRecordInstance(WorkPackageClosingDataGridViewRow row,
                                       Audit wp,
                                       NextPerformance nextPerformance = null,
                                       AuditRecord workPackageRecord = null)
        {
            if (row.ClosingItem == null) return;

            IDirective currentClosingItem = row.ClosingItem;

            if (currentClosingItem is Procedure)
                row.Record = new DirectiveRecord();
            if (nextPerformance != null)
                row.Record.PerformanceNum = nextPerformance.PerformanceNum;
            if (workPackageRecord != null)
                row.Record.PerformanceNum = workPackageRecord.PerformanceNumFromStart;

            row.Record.Parent = currentClosingItem;
            row.Record.ParentId = currentClosingItem.ItemId;
            row.Record.DirectivePackageId = wp.ItemId;
        }
        #endregion

        #region private void SetCellReadOnly(DataGridViewRow row, IEnumerable<int> cellIndexes, bool readOnly)
        private void SetCellReadOnly(DataGridViewRow row, IEnumerable<int> cellIndexes, bool readOnly)
        {
            foreach (int cellIndex in cellIndexes)
            {
                if(cellIndex < 0 || row.Cells.Count < cellIndex)   
                    continue;
                row.Cells[cellIndex].ReadOnly = readOnly;
                row.Cells[cellIndex].Style.BackColor = Color.DimGray;
            }   
        }
        #endregion

        #region private void SetLabelsAndText(WorkPackageClosingDataGridViewRow row)

        private void SetLabelsAndText(WorkPackageClosingDataGridViewRow row)
        {
            if (row.ClosingItem == null) return;

            IDirective closingItem = row.ClosingItem;

            if (closingItem is Procedure)
            {
                Procedure directive = (Procedure)closingItem;
                row.Cells[ColumnType.Index].Value = "Procedure: ";
                row.Cells[ColumnTask.Index].Value = directive.Title + " " + directive.ProcedureType;

                string taskCardCellValue;
                Color taskCardCellBackColor = Color.White;

                if (string.IsNullOrEmpty(directive.CheckList) && directive.CheckListFile == null)
                {
                    taskCardCellValue = "Not set Check List file.";
                    taskCardCellBackColor = Color.Red;
                }
                else if (!string.IsNullOrEmpty(directive.CheckList) && directive.CheckListFile == null)
                {
                    taskCardCellValue = string.Format("Not set Check List File. (Check List No {0}.)", directive.CheckList);
                    taskCardCellBackColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(directive.CheckList) && directive.CheckListFile != null)
                {
                    taskCardCellValue = string.Format("Not set Check List name. (File name {0}.)", directive.CheckListFile.FileName);
                    taskCardCellBackColor = Color.Red;
                }
                else taskCardCellValue = directive.CheckList;

                row.Cells[ColumnTaskCard.Index].Value = taskCardCellValue;
                row.Cells[ColumnTaskCard.Index].Style.BackColor = taskCardCellBackColor;
            }
        }
        #endregion

        #region private void SetValues(WorkPackageClosingDataGridViewRow row, Audit wp, NextPerformance nextPerformance)

        private void SetValues(WorkPackageClosingDataGridViewRow row, 
                               Audit wp, 
                               NextPerformance nextPerformance)
        {
            row.WorkPackage = wp;
            row.NextPerformance = nextPerformance;
            if (row.NextPerformance != null)
                row.ClosingItem = nextPerformance.Parent;

            GetRecordInstance(row, wp, nextPerformance);
            SetLabelsAndText(row);

            if (row.ClosingItem == null) return;

            if (row.ClosingItem.IsClosed)
            {
                DataGridViewCell cell = row.Cells[ColumnClosed.Index];

                cell.Value = false;
                cell.ReadOnly = true;
                cell.Style.BackColor = Color.DimGray;
                cell.ToolTipText = "This item is closed and can't be perform";

                SetCellReadOnly(row,
                                new[]{
                                        ColumnClosed.Index, 
                                        ColumnHours.Index, 
                                        ColumnCycles.Index, 
                                        ColumnDays.Index,
                                        ColumnDate.Index
                                    }, 
                                false);
            }

            if(nextPerformance == null)return;

            row.PrevPerfDate = nextPerformance.PrevPerformanceDate;
            row.NextPerfDate = nextPerformance.NextPerformanceDate;
            row.MinPerfSource = nextPerformance.PrevPerformanceSource.IsNullOrZero()
                                    ? Lifelength.Zero
                                    : nextPerformance.PrevPerformanceSource;
            row.MaxPerfSource = nextPerformance.NextPerformanceSource.IsNullOrZero()
                                    ? GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(row.ClosingItem.LifeLengthParent, DateTime.Now)
                                    : nextPerformance.NextPerformanceSource;
            
            row.Cells[ColumnClosed.Index].Value = true;
            //if(!(row.ClosingItem is Detail))
            //{
            //    Lifelength performanceSource = nextPerformance.PerformanceSource;
            //    row.Cells[ColumnHours.Index].Value = performanceSource.Hours != null ? performanceSource.Hours.ToString() : "n/a";
            //    row.Cells[ColumnCycles.Index].Value = performanceSource.Cycles != null ? performanceSource.Cycles.ToString() : "n/a";
            //    row.Cells[ColumnDays.Index].Value = performanceSource.Days != null ? performanceSource.Days.ToString() : "n/a";    
            //}
            if (nextPerformance.PerformanceDate != null)
                row.Cells[ColumnDate.Index].Value = (DateTime)nextPerformance.PerformanceDate;

            DataGridViewCalendarCell cc = row.Cells[ColumnDate.Index] as DataGridViewCalendarCell;
            if (cc != null)
            {
                if (row.PrevPerfDate != null)
                {
                    cc.MinDate = (DateTime)row.PrevPerfDate;
                }
                else
                {
                    cc.MinDate = DateTimeExtend.GetCASMinDateTime();
                }

                if (row.NextPerfDate != null)
                {
                    cc.MaxDate = (DateTime)row.NextPerfDate;
                }
                else
                {
                    cc.MaxDate = DateTime.Now;
                }
            }
        }
        #endregion

        #region private void SetValues(WorkPackageClosingDataGridViewRow row, Audit wp, AbstractPerformanceRecord apr)

        private void SetValues(WorkPackageClosingDataGridViewRow row,
                               Audit wp,
                               AbstractPerformanceRecord apr)
        {
            row.WorkPackage = wp;
            row.Record = apr;
            if (apr != null) 
                row.ClosingItem = apr.Parent;

            if (row.ClosingItem == null || apr == null) return;

            SetLabelsAndText(row);

            if (apr is DirectiveRecord || apr is MaintenanceCheckRecord)
            {
                row.Cells[ColumnClosed.Index].Value = true;
                //Lifelength performanceSource = apr.OnLifelength;
                //row.Cells[ColumnHours.Index].Value = performanceSource.Hours != null ? performanceSource.Hours.ToString() : "n/a";
                //row.Cells[ColumnCycles.Index].Value = performanceSource.Cycles != null ? performanceSource.Cycles.ToString() : "n/a";
                //row.Cells[ColumnDays.Index].Value = performanceSource.Days != null ? performanceSource.Days.ToString() : "n/a";
                row.Cells[ColumnDate.Index].Value = apr.RecordDate;

                row.PrevPerfDate = apr.PrevPerformanceDate;
                row.NextPerfDate = apr.NextPerformanceDate;
            }
            else if (apr is TransferRecord)
            {
                TransferRecord tr = (TransferRecord)apr;
                if (tr.ItemId > 0)
                {
                    //если запись о перемещении имеет itemID > 0
                    //и она не подтвержддена стороной получателя, то ее можно редактировать и удалять
                    //если подтверждена, то редактировать и удалять ее нельзя
                    if (tr.DODR)
                    {
                        row.Cells[ColumnHours.Index].ReadOnly = false;
                        row.PrevPerfDate = tr.PrevPerformanceDate;
                        row.NextPerfDate = tr.TransferDate;
                    }
                    else
                    {
                        row.Cells[ColumnHours.Index].ReadOnly = true;
                        row.PrevPerfDate = tr.PrevPerformanceDate;
                        row.NextPerfDate = tr.NextPerformanceDate;
                    }
                    row.Cells[ColumnCycles.Index].Value = "Transfer to: " + GetDestination(tr);
                    row.Cells[ColumnDate.Index].Value = tr.StartTransferDate;
                }
                else
                {
                    row.Cells[ColumnCycles.Index].Value = "Transfer to: ";
                    row.PrevPerfDate = apr.PrevPerformanceDate;
                    row.NextPerfDate = apr.NextPerformanceDate;
                }
                row.Cells[ColumnClosed.Index].Value = true;
            }

            DataGridViewCalendarCell cc = row.Cells[ColumnDate.Index] as DataGridViewCalendarCell;
            if (cc != null)
            {
                if (row.PrevPerfDate != null)
                {
                    cc.MinDate = (DateTime)row.PrevPerfDate;
                }
                else
                {
                    cc.MinDate = DateTimeExtend.GetCASMinDateTime();
                }
                if (row.NextPerfDate != null)
                {
                    cc.MaxDate = (DateTime)row.NextPerfDate;
                }
                else
                {
                    cc.MaxDate = DateTime.Now;
                }
            }

            row.MinPerfSource = apr.PrevPerformanceSource.IsNullOrZero()
                                    ? Lifelength.Zero
                                    : apr.PrevPerformanceSource;
            row.MaxPerfSource = apr.NextPerformanceSource.IsNullOrZero()
									//TODO:(Evgenii Babak) пересмотреть подход, наработка считается на конец дня, а в метод передаем DateTime.Now(может быть и концом дня)
									? GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(row.ClosingItem.LifeLengthParent, DateTime.Now)
                                    : apr.NextPerformanceSource;
        }
        #endregion

        #region private void SetValues(WorkPackageClosingDataGridViewRow row, Audit wp, AuditRecord workPackageRecord)

        private void SetValues(WorkPackageClosingDataGridViewRow row,
                               Audit wp,
                               AuditRecord workPackageRecord)
        {
            if (workPackageRecord != null)
            {
                row.WorkPackage = wp;
                row.ClosingItem = workPackageRecord.Task;
            }

            GetRecordInstance(row, wp, workPackageRecord:workPackageRecord);
            SetLabelsAndText(row);

            if (row.ClosingItem.IsClosed)
            {
                DataGridViewCell cell = row.Cells[ColumnClosed.Index];

                cell.Value = false;
                cell.ReadOnly = true;
                cell.Style.BackColor = Color.DimGray;
                cell.ToolTipText = "This item is closed and can't be perform";

                SetCellReadOnly(row,
                                new[]{
                                        ColumnClosed.Index, 
                                        ColumnHours.Index, 
                                        ColumnCycles.Index, 
                                        ColumnDays.Index,
                                        ColumnDate.Index
                                    },
                                false);
            }
        }
        #endregion

        #endregion
    }
}
