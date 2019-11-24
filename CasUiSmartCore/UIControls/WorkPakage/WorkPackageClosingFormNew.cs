using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Helpers;
using CAS.UI.UIControls.Auxiliary.DataGridViewElements;
using CAS.UI.UIControls.DocumentationControls;
using CAS.UI.UIControls.StoresControls;
using CASTerms;
using EntityCore.DTO.General;
using EntityCore.Filter;
using MetroFramework.Forms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.MTOP;
using SmartCore.Entities.General.WorkPackage;
using Convert = System.Convert;

namespace CAS.UI.UIControls.WorkPakage
{
    ///<summary>
    ///</summary>
    public partial class WorkPackageClosingFormNew : MetroForm
    {
        #region Fields
        
        private readonly WorkPackage _workPackage;
	    bool checkClosed = false;
		private List<DocumentControl> DocumentControls = new List<DocumentControl>();

        //private List<WorkPackageClosingFormItem> _closingItems;
        
        #endregion

        #region Constructors

        #region public WorkPackageClosingFormNew()
        ///<summary>
        ///</summary>
        public WorkPackageClosingFormNew()
        {
            InitializeComponent();
        }
        #endregion

        #region public WorkPackageClosingFormNew(WorkPackage workPackage) : this ()
        ///<summary>
        ///</summary>
        ///<param name="workPackage"></param>
        public WorkPackageClosingFormNew(WorkPackage workPackage)
            : this()
        {
            _workPackage = workPackage;
            DocumentControls.AddRange(new []{documentControl1,documentControl2,documentControl3, documentControl4, documentControl5, documentControl6, documentControl7, documentControl8, documentControl9, documentControl10});

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
            if(_workPackage == null)return;
            
            Text = _workPackage.Title;
            dataGridViewItems.Rows.Clear();
            
            var minComplianceDate = DateTimeExtend.GetCASMinDateTime();

            var wprs =
                _workPackage.WorkPakageRecords.Where(wpr => wpr.Task != null && 
                                                            !(wpr.Task is NonRoutineJob) &&
                                                            !(wpr.Task is Directive));
            var groupedWprs =
                wprs.GroupBy(wpr => wpr.Task.SmartCoreObjectType.FullName).ToList();

            var directiveWprs =
	            _workPackage.WorkPakageRecords.Where(wpr => wpr.Task != null &&
	                                                        wpr.Task is Directive);

            var groupedDirectiveWprs =
	            directiveWprs.GroupBy(wpr => (((Directive)wpr.Task).DirectiveType).FullName).ToList();

            groupedWprs.AddRange(groupedDirectiveWprs);

            checkBoxSelectAll.CheckedChanged -= CheckBoxSelectAllCheckedChanged;

            foreach (IGrouping<string , WorkPackageRecord> grouping in groupedWprs)
            {
                //добавить расчеты ComlianceDate
                foreach (WorkPackageRecord item in grouping)
                {
                    if(item.Task is Directive ||
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
                        if (item.Task is MaintenanceCheck && 
                            item.Task.NextPerformances.OfType<MaintenanceNextPerformance>().Any())
                        {
                            SetValues(r, _workPackage,
                                      item.Task.NextPerformances.OfType<MaintenanceNextPerformance>().First());
                        }
                        else if (item.Task.NextPerformances.Count > 0)
                        {
                            SetValues(r, _workPackage, item.Task.NextPerformances[0]);
                        }
                        else if (item.Task.PerformanceRecords.Cast<AbstractPerformanceRecord>().Count(pr => pr.DirectivePackageId == _workPackage.ItemId) > 0)
                        {
                            AbstractPerformanceRecord apr =
                                item.Task.PerformanceRecords.Cast<AbstractPerformanceRecord>()
                                                            .First(pr => pr.DirectivePackageId == _workPackage.ItemId);
                            SetValues(r, _workPackage, apr);
                        }
                        else SetValues(r, _workPackage, item);
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
                            SetValues(r, _workPackage, component.NextPerformances[0]);
                        }
                        else if (component.TransferRecords.Count(pr => pr.DirectivePackageId == _workPackage.ItemId) > 0)
                        {
                            AbstractPerformanceRecord apr =
                                component.TransferRecords.Cast<AbstractPerformanceRecord>()
                                                      .First(pr => pr.DirectivePackageId == _workPackage.ItemId);
                            SetValues(r, _workPackage, apr);
                        }
                        else SetValues(r, _workPackage, item);
                    }
                }
            }

            dateTimePickerClosingDate.ValueChanged -= DateTimePickerClosingDateValueChanged;

            dateTimePickerClosingDate.Value = _workPackage.Status != WorkPackageStatus.Closed 
                ? minComplianceDate 
                : _workPackage.ClosingDate;
			//dateTimePickerClosingDate.MinDate = _workPackage.MinClosingDate != null
			//    ? _workPackage.MinClosingDate.Value
			//    : DateTimeExtend.GetCASMinDateTime();
			//dateTimePickerClosingDate.MaxDate = _workPackage.MaxClosingDate != null
			//    ? _workPackage.MaxClosingDate.Value
			//    : DateTimeExtend.GetCASMinDateTime();
			dateTimePickerClosingDate.MinDate = DateTimeExtend.GetCASMinDateTime();
			

			dateTimePickerClosingDate.ValueChanged += DateTimePickerClosingDateValueChanged;
			dateTimePickerClosingDate.Value = DateTime.Today;
			checkBoxSelectAll.CheckedChanged += CheckBoxSelectAllCheckedChanged;

            foreach (var control in DocumentControls)
	            control.Added += DocumentControl1_Added;

			for (int i = 0; i < _workPackage.ClosingDocument.Count; i++)
            {
	            var control = DocumentControls[i];
	            control.CurrentDocument = _workPackage.ClosingDocument[i];
			}
        }

		#endregion

		private void DocumentControl1_Added(object sender, EventArgs e)
		{
			var control = sender as DocumentControl;
			var newDocument = CreateNewDocument();
			var form = new DocumentForm(newDocument, false);
			if (form.ShowDialog() == DialogResult.OK)
			{
				_workPackage.ClosingDocument.Add(newDocument);
				control.CurrentDocument = newDocument;

			}
		}

		#region private Document CreateNewDocument()

		private Document CreateNewDocument()
		{
			var docSubType = GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Work package") as DocumentSubType;

			return new Document
			{
				Parent = _workPackage,
				ParentId = _workPackage.ItemId,
				ParentTypeId = _workPackage.SmartCoreObjectType.ItemId,
				DocType = DocumentType.TechnicalRecords,
				DocumentSubType = docSubType,
				IsClosed = true,
				ContractNumber = $"{_workPackage.Number}",
				Description = _workPackage.Title,
				ParentAircraftId = _workPackage.ParentId
			};
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

                if (row.ClosingItem.IsClosed)
                {
	                message = $"Cant close workpackage with alredy closer directive:  {row.ClosingItem}";
	                MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
		                MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
                }

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
                    if (row.ClosingItem is Directive)
                    {
                        Directive dir = (Directive)row.ClosingItem;
                        DirectiveRecord directiveRecord = (DirectiveRecord)row.Record;

                        if (directiveRecord.ItemId <= 0)
                        {
                            directiveRecord.Completed = true;
                            directiveRecord.RecordType = DirectiveRecordType.Perfromed;
                            directiveRecord.RecordTypeId = DirectiveRecordType.Perfromed.ItemId;
                            directiveRecord.Remarks = "WorkPackage " + _workPackage.Title + " Close " + dir.DirectiveType.CommonName + " Directive";
                        }
                        directiveRecord.RecordDate = performDate;
                        Lifelength performanceSource;
                        directiveRecord.OnLifelength = Lifelength.TryParse((string) row.Cells[ColumnHours.Index].Value,
                                                                           (string) row.Cells[ColumnCycles.Index].Value,
                                                                           (string) row.Cells[ColumnDays.Index].Value,
                                                                           out performanceSource) ? performanceSource : Lifelength.Zero;

                        GlobalObjects.PerformanceCore.RegisterPerformance(dir, directiveRecord, _workPackage);
                    }
                    else if (row.ClosingItem is ComponentDirective)
                    {
                        ComponentDirective detDir = (ComponentDirective)row.ClosingItem;
                        DirectiveRecord directiveRecord = (DirectiveRecord)row.Record;

                        if (directiveRecord.ItemId <= 0)
                        {
                            directiveRecord.Completed = true;
                            directiveRecord.RecordType = DirectiveRecordType.Perfromed;
                            directiveRecord.RecordTypeId = DirectiveRecordType.Perfromed.ItemId;
                            directiveRecord.Remarks = "WorkPackage " + _workPackage.Title + " Close Component Directive";
                        }
                        directiveRecord.RecordDate = performDate;
                        Lifelength performanceSource;
                        directiveRecord.OnLifelength = Lifelength.TryParse((string)row.Cells[ColumnHours.Index].Value,
                                                                           (string)row.Cells[ColumnCycles.Index].Value,
                                                                           (string)row.Cells[ColumnDays.Index].Value,
                                                                           out performanceSource) ? performanceSource : Lifelength.Zero;

                        GlobalObjects.PerformanceCore.RegisterPerformance(detDir, directiveRecord, _workPackage);
                    }
                    else if (row.ClosingItem is MaintenanceCheck)
                    {
                        MaintenanceCheck check = (MaintenanceCheck)row.ClosingItem;
                        MaintenanceCheckRecord directiveRecord = (MaintenanceCheckRecord)row.Record;

                        if (directiveRecord.ItemId <= 0)
                        {
                            directiveRecord.Remarks = "WorkPackage " + _workPackage.Title + " Close Maintenance Check";
                            MaintenanceNextPerformance mnp;
                            if (row.NextPerformance != null && (mnp = row.NextPerformance as MaintenanceNextPerformance) != null)
                                directiveRecord.ComplianceCheckName = mnp.PerformanceGroup.GetGroupName();
                        }
                        directiveRecord.RecordDate = performDate;
                        Lifelength performanceSource;
                        directiveRecord.OnLifelength = Lifelength.TryParse((string)row.Cells[ColumnHours.Index].Value,
                                                                           (string)row.Cells[ColumnCycles.Index].Value,
                                                                           (string)row.Cells[ColumnDays.Index].Value,
                                                                           out performanceSource) ? performanceSource : Lifelength.Zero;
                        GlobalObjects.PerformanceCore.RegisterPerformance(check, directiveRecord, _workPackage);
                    }
                    else if (row.ClosingItem is MaintenanceDirective)
                    {
                        MaintenanceDirective mdp = (MaintenanceDirective)row.ClosingItem;
                        DirectiveRecord directiveRecord = (DirectiveRecord)row.Record;

                        if (directiveRecord.ItemId <= 0)
                        {
                            directiveRecord.Remarks = "WorkPackage " + _workPackage.Title + " Close Maintenance Directive";
                        }
                        directiveRecord.RecordDate = performDate;
                        Lifelength performanceSource;
                        directiveRecord.OnLifelength = Lifelength.TryParse((string)row.Cells[ColumnHours.Index].Value,
                                                                           (string)row.Cells[ColumnCycles.Index].Value,
                                                                           (string)row.Cells[ColumnDays.Index].Value,
                                                                           out performanceSource) ? performanceSource : Lifelength.Zero;
                        GlobalObjects.PerformanceCore.RegisterPerformance(mdp, directiveRecord, _workPackage);

	                    if (checkBox1.Checked && !checkClosed)
	                    {
		                    checkClosed = true;

							var rec = _workPackage.WorkPakageRecords.FirstOrDefault(i => i.Task is MaintenanceDirective);

		                    var check = GlobalObjects.CasEnvironment.NewLoader.GetObject<MTOPCheckDTO, MTOPCheck>(new Filter("ItemId",rec.ParentCheckId));


							var frame = GlobalObjects.CasEnvironment.BaseComponents.FirstOrDefault(i =>
			                    i.ParentAircraftId == mdp.ParentBaseComponent.ParentAircraftId && Equals(i.BaseComponentType, BaseComponentType.Frame));


		                    if (check != null || rec.Group > 0)
		                    {
			                    var checkRecord = new MTOPCheckRecord
			                    {
				                    RecordDate = dateTimePickerClosingDate.Value,
				                    CheckName = check.Name,
				                    GroupName = rec.Group,
				                    CalculatedPerformanceSource = lifelengthViewer1.Lifelength,
				                    ParentId = rec.ParentCheckId,
				                    Remarks = $"Closed by WP {_workPackage.Title}",
				                    AverageUtilization = frame.AverageUtilization
			                    };

			                    GlobalObjects.CasEnvironment.NewKeeper.Save(checkRecord);
							}

							
						}
                    }
                    else if (row.ClosingItem is Component)
                    {
                        var component = (Component)row.ClosingItem;
                        TransferRecord tr = (TransferRecord)row.Record;
                        if (!tr.DODR)
                        {
                            //подтверждения на стороне получателя нет, поэтому можно менять дату
                            //окончания перемещения
                            tr.TransferDate = performDate;
                            //если подтверждения на стороне получателя нет
                            //и при этом была изменена дата перемещения
                            //необходимо произвести манипуляции с актуальным состоянием
                            //для правильной информации о наработке
                            if (tr.StartTransferDate != performDate)
                            {
                                var comp = (Component)row.ClosingItem;
                                //Извлечения актуального состояния на старое значение даты о перемещении
                                ActualStateRecord actual = comp.ActualStateRecords[tr.StartTransferDate];
                                if (actual != null)
                                {
                                    if (tr.StartTransferDate >= performDate)
                                    {
                                        //Дата установки изменена на более раннюю
                                        if (comp is BaseComponent)
                                        {
                                            actual.OnLifelength =
                                                GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay((BaseComponent)comp, performDate);
                                        }
                                        else
                                        {
                                            actual.OnLifelength =
                                                GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(comp, performDate);
                                        }
                                        actual.RecordDate = performDate;
                                        GlobalObjects.CasEnvironment.NewKeeper.Save(actual);
                                    }
                                    else if (tr.StartTransferDate < performDate)
                                    {
                                        if (comp is BaseComponent)
                                        {
                                            actual.OnLifelength =
                                                GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay((BaseComponent)comp, performDate);
                                            actual.RecordDate = performDate;
                                            GlobalObjects.ComponentCore.RegisterActualState(comp, actual);
                                        }
                                        else
                                        {
                                            actual.OnLifelength =
                                                GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(comp, performDate);
                                            actual.RecordDate = performDate;
                                            GlobalObjects.ComponentCore.RegisterActualState(comp, actual);
                                        }
                                    }
                                }
                                else
                                {
                                    actual = new ActualStateRecord
                                    {
                                        ComponentId = comp.ItemId,
                                        RecordDate = performDate,
                                        OnLifelength = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(comp, performDate)
                                    };
                                    GlobalObjects.ComponentCore.RegisterActualState(comp, actual);
                                }
                            }
                        }
                        //дату начала перемещения разрешено менять независимо от 
                        //подтверждений на стороне отправителя и получателя
                        tr.StartTransferDate = performDate;
                        tr.Remarks = "WorkPackage " + _workPackage.Title + " Transfer component";
                        tr.DirectivePackageId = _workPackage.ItemId;
                        try
                        {
                            GlobalObjects.PerformanceCore.RegisterPerformance(component, tr, _workPackage);
                        }
                        catch (Exception ex)
                        {
                            Program.Provider.Logger.Log("Error on save transfer record", ex);
                        }
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
                    mc.PerformanceRecords.FirstOrDefault(pr => pr.DirectivePackageId == _workPackage.ItemId);
                if(mcRecord == null)
                    continue;
                IEnumerable<DirectiveRecord> bindedMpdsRecords =
                    dataGridViewItems.Rows.OfType<WorkPackageClosingDataGridViewRow>()
                                          .Where(ci => ci.ClosingItem is MaintenanceDirective)
                                          .Select(ci => ci.ClosingItem as MaintenanceDirective)
                                          .Where(mpd => mpd.MaintenanceCheck != null 
                                                     && mpd.MaintenanceCheck.ItemId == mc.ItemId 
                                                     && mpd.PerformanceRecords.FirstOrDefault(pr => pr.DirectivePackageId == _workPackage.ItemId) != null)
                                          .Select(mpd => mpd.PerformanceRecords.FirstOrDefault(pr => pr.DirectivePackageId == _workPackage.ItemId));
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
            _workPackage.Status = WorkPackageStatus.Closed;
            _workPackage.ClosingDate = dateTimePickerClosingDate.Value;
            _workPackage.ClosedBy = GlobalObjects.CasEnvironment.IdentityUser.Login;
            _workPackage.ClosingRemarks = "";

            if (_workPackage.PublishedBy == "")
                _workPackage.PublishedBy = GlobalObjects.CasEnvironment.IdentityUser.Login;
            if (_workPackage.PublishingDate <= _workPackage.OpeningDate)
                _workPackage.PublishingDate = _workPackage.OpeningDate;
            try
            {
                GlobalObjects.CasEnvironment.NewKeeper.Save(_workPackage);
                SaveData();
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error, while close work package.", ex);
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
            if(e.ColumnIndex == ColumnHours.Index)
            {
                if (_workPackage == null) return;

                WorkPackageClosingDataGridViewRow row =
                   dataGridViewItems.Rows[e.RowIndex] as WorkPackageClosingDataGridViewRow;
                if (row != null && 
                    row.ClosingItem is Component &&
                    row.Record is TransferRecord &&
                    row.Cells[ColumnHours.Index] is DataGridViewLinkCell)
                {
                    var component = (Component)row.ClosingItem;
                    var currentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(component.ParentAircraftId);//TODO:(Evgenii Babak) пересмотреть использование ParentAircrafId здесь
					var form = new MoveComponentForm(new[] { component }, currentAircraft, _workPackage);

                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                    {
                        try
                        {
                            if (row.Record.ItemId <= 0)
                            {
                                //Запись о перемещении еще на была сохранена
                                //Реинициализация
                                row.Record = form.GetTransferData();
                            }
                            else
                            {
                                TransferRecord changet = form.GetTransferData();
                                TransferRecord tr = (TransferRecord)row.Record;
                                tr.DestinationObjectId = changet.DestinationObjectId;
                                tr.DestinationObjectType = changet.DestinationObjectType;
                                tr.Position = changet.Position;
                                tr.Remarks = changet.Remarks;
                                if (!tr.PODR) tr.StartTransferDate = changet.StartTransferDate;
                                if (!tr.DODR) tr.TransferDate = changet.TransferDate;
                            }

                            if (row.Record != null)
                            {
                                var calendarCell = (DataGridViewCalendarCell)row.Cells[ColumnDate.Index];

                                row.Cells[ColumnCycles.Index].Value = "Transfer to: " + DestinationHelper.GetCurrentDestination((TransferRecord)row.Record);
                                if (row.Record.RecordDate > calendarCell.MaxDate
                                    && (row.Record.RecordDate - calendarCell.MaxDate).TotalDays < 1.0)
                                {
                                    calendarCell.MaxDate = row.Record.RecordDate;
                                }
                                calendarCell.Value = row.Record.RecordDate;
                            }
                        }
                        catch (Exception ex)
                        {
                            Program.Provider.Logger.Log("Error while create transfer record", ex);
                        }
                    }
                }
            }
        }
        #endregion

        #region private void DataGridViewItemsDataError(object sender, DataGridViewDataErrorEventArgs e)
        private void DataGridViewItemsDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Program.Provider.Logger.Log("Error in Work Package Closing Form Data Grid", e.Exception);
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

                    //if (row.PrevPerfDate != null && dateTime < row.PrevPerfDate)
                    //    row.Cells[ColumnDate.Index].Value = row.PrevPerfDate.Value;
                    //else if (dateTime < DateTimeExtend.GetCASMinDateTime())
                    //    row.Cells[ColumnDate.Index].Value = DateTimeExtend.GetCASMinDateTime();
                    //if (row.NextPerfDate != null && dateTime > row.NextPerfDate)
                    //    row.Cells[ColumnDate.Index].Value = row.NextPerfDate.Value;
                    //else if (dateTime > DateTime.Now)
                    //    row.Cells[ColumnDate.Index].Value = DateTime.Now;

                    Lifelength performanceSource =
                        GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnStartOfDay(row.ClosingItem.LifeLengthParent, dateTime);
                    row.Cells[ColumnHours.Index].Value = performanceSource.Hours != null ? performanceSource.ToHoursMinutesFormat("") : "n/a";
                    row.Cells[ColumnCycles.Index].Value = performanceSource.Cycles != null ? performanceSource.Cycles.ToString() : "n/a";
                    row.Cells[ColumnDays.Index].Value = performanceSource.Days != null ? performanceSource.Days.ToString() : "n/a";
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

            if(_workPackage == null) return;
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
			
	        var flights = GlobalObjects.AircraftFlightsCore.GetAircraftFlightsOnDate(_workPackage.Aircraft.ItemId, dateTimePickerClosingDate.Value);

	        checkedListBox1.Items.Clear();
	        checkedListBox1.Items.AddRange(flights.ToArray());

	        lifelengthViewer1.Lifelength = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnStartOfDay(_workPackage.Aircraft, dateTimePickerClosingDate.Value);
		}
        #endregion

        #region private void GetRecordInstance(WorkPackageClosingDataGridViewRow row, WorkPackage wp, NextPerformance nextPerformance = null, WorkPackageRecord workPackageRecord = null)
        /// <summary>
        /// 
        /// </summary>
        private void GetRecordInstance(WorkPackageClosingDataGridViewRow row,
                                       WorkPackage wp,
                                       NextPerformance nextPerformance = null,
                                       WorkPackageRecord workPackageRecord = null)
        {
            if (row.ClosingItem == null) return;

            IDirective currentClosingItem = row.ClosingItem;

            if (currentClosingItem is MaintenanceCheck)
            {
                if (nextPerformance is MaintenanceNextPerformance)
                {
                    MaintenanceNextPerformance mnp = nextPerformance as MaintenanceNextPerformance;
                    row.Record = new MaintenanceCheckRecord
                    {
                        CalculatedPerformanceSource = ((MaintenanceCheck)currentClosingItem).Interval * mnp.PerformanceNum,
                        NumGroup = mnp.PerformanceGroupNum,
                        PerformanceNum = mnp.PerformanceNum,
                    };
                }
                else
                {
                    row.Record = new MaintenanceCheckRecord
                    {
                        CalculatedPerformanceSource = ((MaintenanceCheck)currentClosingItem).Interval * 
                                                      (nextPerformance != null
                                                          ? nextPerformance.PerformanceNum
                                                          : workPackageRecord != null
                                                              ? workPackageRecord.PerformanceNumFromStart
                                                              : 0),
                        NumGroup = nextPerformance != null
                                       ? nextPerformance.PerformanceNum
                                       : workPackageRecord != null
                                             ? workPackageRecord.PerformanceNumFromStart
                                             : 0,
                        PerformanceNum = nextPerformance != null
                                        ? nextPerformance.PerformanceNum
                                        : workPackageRecord != null
                                          ? workPackageRecord.PerformanceNumFromStart
                                          : 0
                    };
                }
            }
            else
            {
                if (currentClosingItem is Directive)
                    row.Record = new DirectiveRecord();
                else if (currentClosingItem is MaintenanceDirective)
                    row.Record = new DirectiveRecord();
                else if (currentClosingItem is ComponentDirective)
                    row.Record = new DirectiveRecord();
                else if (currentClosingItem is BaseComponent)
                    row.Record = new TransferRecord();
                else if (currentClosingItem is Component)
                    row.Record = new TransferRecord();

                if (nextPerformance != null)
                    row.Record.PerformanceNum = nextPerformance.PerformanceNum;
                if (workPackageRecord != null)
                    row.Record.PerformanceNum = workPackageRecord.PerformanceNumFromStart;
            }

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

            if (closingItem is Directive)
            {
                Directive directive = (Directive)closingItem;
                if (directive is DeferredItem)
                {
                    DeferredItem df = (DeferredItem)directive;
                    row.Cells[ColumnType.Index].Value = "Deffered: ";
                    row.Cells[ColumnTask.Index].Value = df.Title + " " + directive.WorkType;
                }
                else if (directive.DirectiveType == DirectiveType.OutOfPhase)
                {
                    row.Cells[ColumnType.Index].Value = "Out of phase: ";
                    row.Cells[ColumnTask.Index].Value = directive.Title + " " + directive.WorkType;
                }
                else if (directive is DamageItem)
                {
                    DamageItem damage = (DamageItem)directive;
                    row.Cells[ColumnType.Index].Value = "Damage: ";
                    row.Cells[ColumnTask.Index].Value = damage.Title + " " + directive.WorkType;

                }
                else
                {
					if(!string.IsNullOrEmpty(directive.EngineeringOrders) && (string.IsNullOrEmpty(directive.Title) || directive.Title == "N/A"))
						row.Cells[ColumnType.Index].Value = "EO: ";
					else row.Cells[ColumnType.Index].Value = "AD: ";
                    row.Cells[ColumnTask.Index].Value = directive.Title + " " + directive.WorkType;
                }

                string taskCardCellValue;
                Color taskCardCellBackColor = Color.White;

                if (string.IsNullOrEmpty(directive.EngineeringOrders) && directive.EngineeringOrderFile == null)
                {
                    taskCardCellValue = "Not set Engineering Order file.";
                    taskCardCellBackColor = Color.Red;
                }
                else if (!string.IsNullOrEmpty(directive.EngineeringOrders) && directive.EngineeringOrderFile == null)
                {
                    taskCardCellValue = string.Format("Not set Engineering Order File. (Engineering Order No {0}.)", directive.EngineeringOrders);
                    taskCardCellBackColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(directive.EngineeringOrders) && directive.EngineeringOrderFile != null)
                {
                    taskCardCellValue = string.Format("Not set Engineering Order name. (File name {0}.)", directive.EngineeringOrderFile.FileName);
                    taskCardCellBackColor = Color.Red;
                }
                else taskCardCellValue = directive.EngineeringOrders;

                row.Cells[ColumnTaskCard.Index].Value = taskCardCellValue;
                row.Cells[ColumnTaskCard.Index].Style.BackColor = taskCardCellBackColor;
            }
            else if (closingItem is ComponentDirective)
            {
	            var componentDirective = closingItem as ComponentDirective;
                row.Cells[ColumnType.Index].Value = "Comp Directive";
                string temp = ((ComponentDirective)closingItem).ParentComponent != null
                                  ? ((ComponentDirective)closingItem).ParentComponent.ToString()
                                  : "Comp Directive";
                row.Cells[ColumnTask.Index].Value = $"Comp: {componentDirective.MaintenanceDirective?.TaskCardNumber} " + componentDirective.DirectiveType + " for " + componentDirective.Description + " P/N:" + componentDirective.PartNumber + " S/N:" + componentDirective.SerialNumber;
				row.Cells[ColumnTaskCard.Index].Value = componentDirective.MaintenanceDirective?.TaskCardNumber;
			}
            else if (closingItem is BaseComponent)
            {
                row.Cells[ColumnType.Index].Value = "Base Component: ";
                row.Cells[ColumnTask.Index].Value = ((BaseComponent)closingItem).Description;
                row.Cells[ColumnHours.Index] = new DataGridViewLinkCell { TrackVisitedState = false, UseColumnTextForLinkValue = false, Value = "Edit Transfer" };
                row.Cells[ColumnCycles.Index] = new DataGridViewTextBoxCell { Value = "Transfer to: " };
                row.Cells[ColumnCycles.Index].ReadOnly = true;
            }
            else if (closingItem is Component)
            {
                row.Cells[ColumnType.Index].Value = "Comp: ";
                row.Cells[ColumnTask.Index].Value = ((Component)closingItem).Description;
                row.Cells[ColumnHours.Index] = new DataGridViewLinkCell { TrackVisitedState = false,  UseColumnTextForLinkValue = false, Value = "Edit Transfer" };
                row.Cells[ColumnCycles.Index] = new DataGridViewTextBoxCell { Value = "Transfer to: " };
                row.Cells[ColumnCycles.Index].ReadOnly = true;
            }
            else if (closingItem is MaintenanceCheck)
            {
                row.Cells[ColumnType.Index].Value = "Maintenance check: ";
                row.Cells[ColumnTask.Index].Value = ((MaintenanceCheck)closingItem).Name + (((MaintenanceCheck)closingItem).Schedule ? " Shedule" : " Unshedule");
            }
            else if (closingItem is MaintenanceDirective)
            {
                MaintenanceDirective checkMpd = (MaintenanceDirective)closingItem;
                
                string checkMpdTaskCardCellValue;
                Color checkMpdTaskCardCellBackColor = Color.White;

                if (string.IsNullOrEmpty(checkMpd.TaskCardNumber) && checkMpd.TaskCardNumberFile == null)
                {
                    checkMpdTaskCardCellValue = "Not set Task Card file.";
                    checkMpdTaskCardCellBackColor = Color.Red;
                }
                else if (!string.IsNullOrEmpty(checkMpd.TaskCardNumber) && checkMpd.TaskCardNumberFile == null)
                {
                    checkMpdTaskCardCellValue = string.Format("Not set Task Card file. (Task Card No {0}.)", checkMpd.TaskCardNumber);
                    checkMpdTaskCardCellBackColor = Color.Red;
                }
                else if (string.IsNullOrEmpty(checkMpd.TaskCardNumber) && checkMpd.TaskCardNumberFile != null)
                {
                    checkMpdTaskCardCellValue = string.Format("Not set Task Card name. (File name {0}.)", checkMpd.TaskCardNumberFile.FileName);
                    checkMpdTaskCardCellBackColor = Color.Red;
                }
                else checkMpdTaskCardCellValue = checkMpd.TaskCardNumber;

                row.Cells[ColumnType.Index].Value = "MPD: ";
                row.Cells[ColumnTask.Index].Value = ((MaintenanceDirective)closingItem).TaskNumberCheck;
                row.Cells[ColumnTaskCard.Index].Value = checkMpdTaskCardCellValue;
                row.Cells[ColumnTaskCard.Index].Style.BackColor = checkMpdTaskCardCellBackColor;
            }
        }
        #endregion

        #region private void SetValues(WorkPackageClosingDataGridViewRow row, WorkPackage wp, NextPerformance nextPerformance)

        private void SetValues(WorkPackageClosingDataGridViewRow row, 
                               WorkPackage wp, 
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
                                    ? GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(row.ClosingItem.LifeLengthParent)
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
			else row.Cells[ColumnDate.Index].Value = DateTime.Now;

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

        #region private void SetValues(WorkPackageClosingDataGridViewRow row, WorkPackage wp, AbstractPerformanceRecord apr)

        private void SetValues(WorkPackageClosingDataGridViewRow row,
                               WorkPackage wp,
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

					row.Cells[ColumnCycles.Index].Value = "Transfer to: " + DestinationHelper.GetCurrentDestination(tr);
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
                                    ? GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(row.ClosingItem.LifeLengthParent)
                                    : apr.NextPerformanceSource;
        }
        #endregion

        #region private void SetValues(WorkPackageClosingDataGridViewRow row, WorkPackage wp, WorkPackageRecord workPackageRecord)

        private void SetValues(WorkPackageClosingDataGridViewRow row,
                               WorkPackage wp,
                               WorkPackageRecord workPackageRecord)
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

		private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			var flight = checkedListBox1.Items[e.Index] as AircraftFlight;
			if (e.NewValue == CheckState.Checked)
			{
				lifelengthViewer1.Lifelength += flight.FlightTimeLifelength;
			}
			else if (e.NewValue == CheckState.Unchecked)
			{
				lifelengthViewer1.Lifelength -= flight.FlightTimeLifelength;
			}

			if (_workPackage == null) return;
			foreach (var row in dataGridViewItems.Rows.OfType<WorkPackageClosingDataGridViewRow>().Where(r => r.ClosingItem != null && !r.ClosingItem.IsClosed))
			{
				DataGridViewCell cycleCell;
				DataGridViewCell hoursCell;
				if (row.Cells.Count >= ColumnCycles.Index && (cycleCell = row.Cells[ColumnCycles.Index]) != null)
					cycleCell.Value = lifelengthViewer1.Lifelength.Cycles.ToString();
				if (row.Cells.Count >= ColumnHours.Index && (hoursCell = row.Cells[ColumnHours.Index]) != null)
					hoursCell.Value = lifelengthViewer1.Lifelength.Hours.ToString();
			}
		}

		private void lifelengthViewer1_LifelengthChanged_1(object sender, EventArgs e)
		{
			if (_workPackage == null) return;
			foreach (var row in dataGridViewItems.Rows.OfType<WorkPackageClosingDataGridViewRow>().Where(r => r.ClosingItem != null && !r.ClosingItem.IsClosed))
			{
				DataGridViewCell cycleCell;
				DataGridViewCell hoursCell;
				if (row.Cells.Count >= ColumnCycles.Index && (cycleCell = row.Cells[ColumnCycles.Index]) != null)
					cycleCell.Value = lifelengthViewer1.Lifelength.Cycles.ToString();
				if (row.Cells.Count >= ColumnHours.Index && (hoursCell = row.Cells[ColumnHours.Index]) != null)
					hoursCell.Value = lifelengthViewer1.Lifelength.Hours.ToString();
			}
		}
	}
}
