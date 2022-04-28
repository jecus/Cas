using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.Dictionary;
using CAA.Entity.Models.DTO;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.PersonnelControls.EmployeeControls;
using CASTerms;
using Entity.Abstractions.Filters;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Personnel;
using SmartCore.Files;
using SmartCore.Purchase;

namespace CAS.UI.UICAAControls.Specialists
{
    ///<summary>
    ///</summary>
    public partial class CAAEmployeeScreen : ScreenControl
    {
        #region Fields

        private bool _needReload;
        private Specialist _currentItem;
        private readonly int _opearatorId;
        private ContextMenuStrip _buttonPrintMenuStrip;
        private ToolStripMenuItem _itemPrintReportRecords;
        private ToolStripMenuItem _itemPrintReportHistory;
		private List<AircraftModel> aircraftModels = new List<AircraftModel>();
		private List<SmartCore.Purchase.Supplier> _suppliers = new List<SmartCore.Purchase.Supplier>();

        #endregion

        #region Constructors

        #region private EmployeeScreen()
        ///<summary>
        ///</summary>
        private CAAEmployeeScreen()
        {
            InitializeComponent();
        }
        #endregion

        #region public EmployeeScreen(Specialist employee) : this ()

        /// <summary>
        ///  Создает страницу для отображения информации об одной директиве
        /// </summary>
        ///  <param name="employee">Директива</param>
        /// <param name="opearatorId"></param>
        public CAAEmployeeScreen(Specialist employee, int opearatorId)
            : this()
        {
            if (employee == null)
                throw new ArgumentNullException("employee", "Argument cannot be null");

            _currentItem = employee;
            _opearatorId = opearatorId;

            aircraftHeaderControl1.Operator = GlobalObjects.CaaEnvironment?.Operators[0];

			Initialize();
        }

        #endregion

        #endregion

        #region Properties

        #endregion

        #region Methods

        #region public override void DisposeScreen()
        public override void DisposeScreen()
        {
            CancelAsync();

            AnimatedThreadWorker.Dispose();

            if (_itemPrintReportHistory != null) _itemPrintReportHistory.Dispose();
            if (_itemPrintReportRecords != null) _itemPrintReportRecords.Dispose();
            if (_buttonPrintMenuStrip != null) _buttonPrintMenuStrip.Dispose();

            _currentItem = null;

            Dispose(true);
        }

        #endregion

        #region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (AnimatedThreadWorker.CancellationPending)
                return;
            if(_currentItem == null)
                return;
            if(_currentItem.ItemId <= 0)
            {
                headerControl.ShowReloadButton = false;
                headerControl.ShowPrintButton = false;
                headerControl.ShowSaveButton2 = true;
                headerControl.SaveButtonToolTipText = "Save and Edit";
            }
            else
            {
                headerControl.ShowReloadButton = true;
                headerControl.ShowPrintButton = true;
                headerControl.ShowSaveButton2 = false;
                headerControl.SaveButtonToolTipText = "Save";
            }

            statusControl.ConditionState = ConditionState.Satisfactory;// GlobalObjects.CaaEnvironment.Calculator.GetConditionState(_currentItem);

            //extendableRichContainerSummary.LabelCaption.Text = "Summary " + _currentDirective.TaskNumberCheck
            //                                               + " Status: " + _currentDirective.Status;

	        employeeSummary.CurrentItem = _currentItem;
            //обновление главной информацию по директиве
            _directiveGeneralInformation.OperatorId = _opearatorId;
            _directiveGeneralInformation.CurrentItem = _currentItem;
			//обновление информации подзадач директивы
			DocumentsControl.Reload += DocumentsControl_Reload;
			DocumentsControl.CurrentItem = _currentItem;
			////обновление информации об выполнении директивы
			//complianceControl.cu = _currentItem;
			employeeLicenceControl.UpdateControl(_currentItem, aircraftModels);
			employeeMedicalControl1.UpdateControl(_currentItem);
			employeeTrainingListControl1.UpdateControl(_currentItem, _suppliers, aircraftModels, employeeLicenceControl.FlowLayoutPanelGeneralControl.Controls.OfType<EmployeeLicenceGeneralControl>());
	        employeeFlightControl.CurrentItem = _currentItem;
	        employeeFlightControl.Reload += DocumentsControl_Reload;

	        employeeWorkPackageControl.CurrentItem = _currentItem;
	        employeeWorkPackageControl.Reload += DocumentsControl_Reload;

        }
		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        {

            #region Загрузка элементов

			AnimatedThreadWorker.ReportProgress(0, "load directives");

            try
            {
				GlobalObjects.CaaEnvironment.NewLoader.ReloadDictionary(typeof(Occupation), typeof(LocationsType));
                if (_currentItem.ItemId > 0)
	                _currentItem = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<CAASpecialistDTO,Specialist>(_currentItem.ItemId, true);

                var links = GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<CAAItemFileLinkDTO, ItemFileLink>(new List<Filter>()
                {
                    new Filter("ParentId",_currentItem.ItemId),
                    new Filter("ParentTypeId",_currentItem.SmartCoreObjectType.ItemId)
                }, true);

                var fileIds = links.Where(i => i.FileId.HasValue).Select(i => i.FileId.Value);
                if (fileIds.Any())
                {
                    var files = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CAAAttachedFileDTO, AttachedFile>(new Filter("ItemId", values: fileIds));
                    foreach (var file in links)
                    {
                        var f = files.FirstOrDefault(i => i.ItemId == file.FileId)?.GetCopyUnsaved(false);
                        if (f == null) continue;
                        f.ItemId = file.FileId.Value;
                        file.File = (AttachedFile)f;

                    }
                }

                _currentItem.Files.Clear();
                _currentItem.Files.AddRange(links);


                var ds = GlobalObjects.CaaEnvironment.Execute($@"select r.ItemId  from [dbo].[CourseRecords] r
                inner join [dbo].[CoursePackage] p on p.ItemId = r.WorkPackageId
                where p.Status >= 1 and r.IsDeleted = 0 and p.IsDeleted = 0  and r.SpecialistId = {_currentItem.ItemId}");
                
                var data = ds.Tables[0].AsEnumerable().Select(dataRow => new
                {
	                ItemId = dataRow.Field<int>("ItemId")
                });
                var courses = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CAADocumentDTO, SmartCore.Entities.General.Document>(new Filter("ParentID",data.Select(i => i.ItemId)));
                _currentItem.EmployeeDocuments.AddRange(courses);
                if (_currentItem.EmployeeDocuments.Any())
                {
	                var docIds = _currentItem.EmployeeDocuments.Select(i => i.ItemId);
	                
	                links = GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<CAAItemFileLinkDTO, ItemFileLink>(new List<Filter>()
	                {
		                new Filter("ParentId",docIds),
		                new Filter("ParentTypeId",SmartCoreType.Document.ItemId)
	                }, false);
	                
	                foreach (var document in _currentItem.EmployeeDocuments)
	                {
		                document.Parent = _currentItem;
		                document.Files = new CommonCollection<ItemFileLink>(links.Where(i => i.ParentId == document.ItemId));
	                }
                }

                _currentItem.MedicalRecord = GlobalObjects.CaaEnvironment.NewLoader.GetObject<CAASpecialistMedicalRecordDTO, SpecialistMedicalRecord>(new Filter("SpecialistId", _currentItem.ItemId));

	            var types = new[]
	            {
		            SmartCoreType.SpecialistTraining.ItemId,
		            SmartCoreType.SpecialistMedicalRecord.ItemId,
		            SmartCoreType.SpecialistCAA.ItemId,
		            SmartCoreType.SpecialistLicense.ItemId

	            };

				var documents = GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<CAADocumentDTO, SmartCore.Entities.General.Document>(new Filter("ParentTypeId", types), true);

	            if (documents.Count > 0)
	            {
					if (_currentItem.MedicalRecord != null)
					{
						var crs = GlobalObjects.CaaEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Medical Records") as DocumentSubType;
						var personalTraining = documents.FirstOrDefault(d => d.ParentId == _currentItem.MedicalRecord.ItemId && d.ParentTypeId == SmartCoreType.SpecialistMedicalRecord.ItemId && d.DocumentSubType == crs);
						if (personalTraining != null)
						{
							_currentItem.MedicalRecord.Document = personalTraining;
							_currentItem.MedicalRecord.Document.Parent = _currentItem.MedicalRecord;
						}
					}
		            foreach (var license in _currentItem.Licenses)
		            {
			            var crs = GlobalObjects.CaaEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Personnel License") as DocumentSubType;
			            var p = documents.FirstOrDefault(d => d.ParentId == license.ItemId && d.ParentTypeId == SmartCoreType.SpecialistLicense.ItemId && d.DocumentSubType == crs);
			            if (p != null)
			            {
				            license.Document = p;
				            license.Document.Parent = license;
			            }
						foreach (var caa in license.CaaLicense)
			            {
				            var personalTraining = documents.FirstOrDefault(d => d.ParentId == caa.ItemId && d.ParentTypeId == SmartCoreType.SpecialistCAA.ItemId && d.DocumentSubType == crs);
				            if (personalTraining != null)
				            {
					            caa.Document = personalTraining;
					            caa.Document.Parent = caa;
				            }
						}
			            
		            }
					foreach (var training in _currentItem.SpecialistTrainings)
					{
						var crs = GlobalObjects.CaaEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Personnel Training") as DocumentSubType;
						var personalTraining = documents.FirstOrDefault(d => d.ParentId == training.ItemId && d.ParentTypeId == SmartCoreType.SpecialistTraining.ItemId && d.DocumentSubType == crs);
						if (personalTraining != null)
						{
							training.Document = personalTraining;
							training.Document.Parent = training;
						}
					}
				}
	            
	            _suppliers.Clear();
				_suppliers.AddRange(GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CAASupplierDTO, SmartCore.Purchase.Supplier>());

				aircraftModels.Clear();
				aircraftModels.AddRange(GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CAAAccessoryDescriptionDTO, AircraftModel>(new Filter("ModelingObjectTypeId", 7)));
	            foreach (var training in _currentItem.SpecialistTrainings)
	            {
		            if (training.AircraftTypeID > 0)
			            training.AircraftType = aircraftModels.FirstOrDefault(a => a.ItemId == training.AircraftTypeID);
	            }
				foreach (var license in _currentItem.Licenses)
	            {
		            if (license.AircraftTypeID > 0)
			            license.AircraftType = aircraftModels.FirstOrDefault(a => a.ItemId == license.AircraftTypeID);
	            }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while loading directives", ex);
            }

            if (AnimatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            #endregion

            #region Калькуляция состояния директив

            AnimatedThreadWorker.ReportProgress(40, "calculation of directives");

            if (AnimatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            #endregion

            #region Фильтрация директив
            AnimatedThreadWorker.ReportProgress(70, "filter directives");

            if (AnimatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            #endregion

            #region Сравнение с рабочими пакетами

            AnimatedThreadWorker.ReportProgress(90, "comparison with the Work Packages");

            if (AnimatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            #endregion

            AnimatedThreadWorker.ReportProgress(100, "Complete");
        }
		#endregion

		#region private void DocumentsControl_Reload(object sender, EventArgs e)

		private void DocumentsControl_Reload(object sender, EventArgs e)
	    {
		    _needReload = true;
		    AnimatedThreadWorker.RunWorkerAsync();
	    }

	    #endregion

		#region protected override void CancelAsync()
		/// <summary>
		/// Проверяет, выполняет ли AnimatedThreadWorker задачу, и производит отмену выполнения
		/// </summary>
		protected override void CancelAsync()
        {
            if (AnimatedThreadWorker.IsBusy)
                AnimatedThreadWorker.CancelAsync();

            if (DocumentsControl != null)
            {
                DocumentsControl.CancelAsync();
            }

            //if (_complianceControl != null)
            //{
            //    _complianceControl.CalcelAsync();
            //}
        }
        #endregion

        #region public override void OnInitCompletion(object sender)
        /// <summary>
        /// Метод, вызывается после добавления содежимого на отображатель(вкладку)
        /// </summary>
        /// <returns></returns>
        public override void OnInitCompletion(object sender)
        {
            AnimatedThreadWorker.RunWorkerAsync();

            base.OnInitCompletion(sender);
        }
        #endregion

        #region private void Initialize()
        /// <summary>
        /// Производит дополнительную инициализацию
        /// </summary>
        private void Initialize()
        {
            _needReload = false;

			#region ButtonPrintContextMenu

			_buttonPrintMenuStrip = new ContextMenuStrip();
            _itemPrintReportRecords = new ToolStripMenuItem { Text = "Records" };
            _itemPrintReportHistory = new ToolStripMenuItem { Text = "Compliance history" };
            _buttonPrintMenuStrip.Items.AddRange(new ToolStripItem[] { _itemPrintReportRecords, _itemPrintReportHistory });

            ButtonPrintMenuStrip = _buttonPrintMenuStrip;
            
            #endregion

            //обновление нижней шапки(через базовый скрин)
            //if (_currentItem.ParentBaseDetail != null)
            //{
            //    if (_currentItem.ParentBaseDetail.ParentAircraft != null)
            //        CurrentAircraft = _currentItem.ParentBaseDetail.ParentAircraft;
            //    else if (_currentItem.ParentBaseDetail.ParentStore != null)
            //        CurrentStore = _currentItem.ParentBaseDetail.ParentStore;
            //}

            //обновление суммарной информацию по директиве и суммарную информацию по её подзадачам
            StatusTitle = "Personnel Status";  
  
            if(_currentItem.ItemId <= 0)
            {
                //_directiveSummary.Visible = false;
                _directiveGeneralInformation.Visible = true;
                DocumentsControl.Visible = false;
            }
            else
            {
                //_directiveSummary.Visible = true;
                _directiveGeneralInformation.Visible = false;
                DocumentsControl.Visible = false;
            }
        }
        #endregion

        #region private bool ValidateData(out string message)
        /// <summary>
        /// Возвращает значение, показывающее является ли значение элемента управления допустимым
        /// </summary>
        /// <returns></returns>
        private bool ValidateData(out string message)
        {
            if (!_directiveGeneralInformation.ValidateData(out message) || 
                !DocumentsControl.ValidateData(out message) || 
                !employeeLicenceControl.ValidateData(out message) || 
				!employeeTrainingListControl1.ValidateData(out message))
            {
                return false;
            }
            return true;
        }

        #endregion

        #region private bool GetchangeStatus()
        /// <summary>
        /// Возвращает значение, показывающее является ли значение элемента управления допустимым
        /// </summary>
        /// <returns></returns>
        private bool GetChangeStatus()
        {
            if (_directiveGeneralInformation.GetChangeStatus(_currentItem.ItemId > 0 ) || 
                DocumentsControl.GetChangeStatus() ||
				employeeLicenceControl.GetChangeStatus() ||
				employeeTrainingListControl1.GetChangeStatus() ||
				employeeMedicalControl1.GetChangeStatus())
            {
                return true;
            }
            return false;
        }

        #endregion

        #region private bool SaveData()
        /// <summary>
        /// Сохранение измененных данных в редактируемом элементе
        /// </summary>
        private bool SaveData()
        {
            //Не менять функции местами - сбивается Threshold
            DocumentsControl.ApplyChanges();
            _directiveGeneralInformation.ApplyChanges();
			employeeLicenceControl.ApplyChanges();
			employeeTrainingListControl1.ApplyChanges();
			employeeMedicalControl1.ApplyChanges();

			DocumentsControl.SaveData();

            try
            {
				GlobalObjects.PersonnelCore.Save(_currentItem, true);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
                return false;
            }
            return true;
        }

        #endregion

        #region private void ClearFields()

        private void ClearFields()
        {
            _directiveGeneralInformation.ClearFields();
            DocumentsControl.ClearFields();
        }
        #endregion

        #region private void ButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)

        private void ButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            //BaseDetail baseDetail = _currentItem.ParentBaseDetail;
            //if (baseDetail == null)
            //    return;

            //if (sender == _itemPrintReportRecords)
            //{
            //    string caption = "";
            //    if (baseDetail.ParentAircraft != null)
            //        caption = baseDetail.ParentAircraft.RegistrationNumber + ". ";
            //    else if (baseDetail.ParentStore != null)
            //        caption = baseDetail.ParentStore.Name + ". ";
            //    caption += _currentDirective.WorkType + ". " + _currentDirective.MPDTaskNumber + ". Compliance List";

            //    DirectiveTasksReportBuilder builder = new DirectiveTasksReportBuilder();
            //    builder.ReportedBaseDetail = baseDetail;
            //    String selection = "";
            //    if (baseDetail.BaseDetailType == BaseDetailType.LandingGear)
            //    {
            //        selection = baseDetail.TransferRecords.GetLast().Position;
            //        builder.ReportTitle = "LANDING GEAR RECORD";
            //    }
            //    if (baseDetail.BaseDetailType == BaseDetailType.Engine)
            //    {
            //        selection = BaseDetailType.Engine + " " + baseDetail.TransferRecords.GetLast().Position;
            //        builder.ReportTitle = "ENGINE RECORD";
            //    }
            //    if (baseDetail.BaseDetailType == BaseDetailType.Apu)
            //    {
            //        selection = BaseDetailType.Apu.ToString();
            //        builder.ReportTitle = "APU RECORD";
            //    }
            //    builder.LifelengthAircraftSinceNew =
            //        GlobalObjects.CaaEnvironment.Calculator.GetClosingFlightLifelength(CurrentAircraft, DateTime.Today);
            //    builder.FilterSelection = selection;
            //    builder.AddDirectives(new [] { _currentDirective });
            //    builder.ForecastData = null;
            //    e.DisplayerText = caption;
            //    e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            //    e.RequestedEntity = new ReportScreen(builder);
            //}
            //else
            //{
                e.Cancel = true;
            //}
        }

        #endregion

        #region private void ComplianceControlComplianceAdded(object sender, EventArgs e)
        private void ComplianceControlComplianceAdded(object sender, EventArgs e)
        {
            CancelAsync();

            AnimatedThreadWorker.RunWorkerAsync();
        }
        #endregion

        #region private void HeaderControl1ReloadRised(object sender, EventArgs e)

        private void HeaderControl1ReloadRised(object sender, EventArgs e)
        {
            if (_directiveGeneralInformation.GetChangeStatus(true) || DocumentsControl.GetChangeStatus())
            {
                if (MessageBox.Show("All unsaved data will be lost. Are you sure you want to continue?",
                                    (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.YesNoCancel,
                                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    _needReload = true;
                    
                    CancelAsync();
                    AnimatedThreadWorker.RunWorkerAsync();
                }
            }
            else
            {
                _needReload = true;

                CancelAsync();
                AnimatedThreadWorker.RunWorkerAsync();
            }
        }
        #endregion

        #region private void ExtendableRichContainerSummaryExtending(object sender, EventArgs e)

        //private void ExtendableRichContainerSummaryExtending(object sender, EventArgs e)
        //{
        //    _directiveSummary.Visible = !_directiveSummary.Visible;
        //}
        #endregion

        #region private void ExtendableRichContainerGeneralExtending(object sender, EventArgs e)

        private void ExtendableRichContainerGeneralExtending(object sender, EventArgs e)
        {
            _directiveGeneralInformation.Visible = !_directiveGeneralInformation.Visible;
        }
		#endregion

		#region private void ExtendableRichContainerPerformanceExtending(object sender, EventArgs e)

		private void ExtendableRichContainerPerformanceExtending(object sender, EventArgs e)
        {
            DocumentsControl.Visible = !DocumentsControl.Visible;
        }
        #endregion

		#region private void ExtendableRichContainerLicense_Extending(object sender, EventArgs e)

		private void ExtendableRichContainerLicense_Extending(object sender, EventArgs e)
	    {
		    employeeLicenceControl.Visible = !employeeLicenceControl.Visible;
	    }

	    #endregion

		#region private void HeaderControlButtonSaveClick(object sender, EventArgs e)

		private void HeaderControlButtonSaveClick(object sender, EventArgs e)
        {
            string message;
            if (!ValidateData(out message))
            {
                message += "\nAbort operation";
                MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (GetChangeStatus())
            {
                if(SaveData())
                {
                    MessageBox.Show("Saving was successful", "Message infomation", MessageBoxButtons.OK,
                                     MessageBoxIcon.Information);

                    _needReload = true;

                    CancelAsync();
                    AnimatedThreadWorker.RunWorkerAsync();
                }
            }
            else
            {
                MessageBox.Show("No changes. Nothing to save", "Message infomation", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
        #endregion

        #region private void HeaderControlButtonSaveAndAddClick(object sender, EventArgs e)

        private void HeaderControlButtonSaveAndAddClick(object sender, EventArgs e)
        {
            string message;
            if (!ValidateData(out message))
            {
                message += "\nAbort operation";
                MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (GetChangeStatus())
            {
                SaveData();
            }

            if (MessageBox.Show("Directive added successfully" + "\nClear Fields before add new directive?",
                                       new GlobalTermsProvider()["SystemName"].ToString(),
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                ClearFields();
            }
            //BaseDetail bd = _currentItem.ParentBaseDetail;
            _currentItem = new Specialist();
        }

		#endregion

		#region private void FlightDateRouteControl1FlightDateChanget(Auxiliary.Events.DateChangedEventArgs e)

		//private void FlightDateRouteControl1FlightDateChanget(DateChangedEventArgs e)
		//{
		//    _performanceControl.EffectiveDate = e.Date;
		//}
		#endregion

		#region private void extendableRichContainerRecords_Extending(object sender, EventArgs e)

		private void extendableRichContainerRecords_Extending(object sender, EventArgs e)
		{
			employeeFlightControl.Visible = !employeeFlightControl.Visible;
		}


		#endregion

		#region private void extendableRichContainer1_Load(object sender, EventArgs e)

		private void extendableRichContainer1_Load(object sender, EventArgs e)
		{
			employeeWorkPackageControl.Visible = !employeeWorkPackageControl.Visible;
		}


		#endregion

		#region private void extendableRichContainer2_Load(object sender, EventArgs e)

		private void extendableRichContainer2_Load(object sender, EventArgs e)
	    {
		    employeeSummary.Visible = !employeeSummary.Visible;
	    }


		#endregion

		#region private void extendableRichContainerTraining_Extending(object sender, EventArgs e)

		private void extendableRichContainerTraining_Extending(object sender, EventArgs e)
	    {
		    employeeTrainingListControl1.Visible = !employeeTrainingListControl1.Visible;
	    }

		#endregion

		#endregion

		#region private void ExtendableRichContainerMedical_Extending(object sender, EventArgs e)

		private void ExtendableRichContainerMedical_Extending(object sender, EventArgs e)
	    {
		    employeeMedicalControl1.Visible = !employeeMedicalControl1.Visible;
	    }

		#endregion

		#region private void extendableRichContainerProcessing_Extending(object sender, EventArgs e)

		private void extendableRichContainerProcessing_Extending(object sender, EventArgs e)
	    {

        }

		#endregion

		#region private void ExtendableRichContainerLicenceRecords_Extending(object sender, EventArgs e)

		private void ExtendableRichContainerLicenceRecords_Extending(object sender, EventArgs e)
	    {
		    medicalCompliance.Visible = !medicalCompliance.Visible;
	    }

		#endregion

		#region private void ExtendableRichContainerTrainingRecords_Extending(object sender, EventArgs e)

		private void ExtendableRichContainerTrainingRecords_Extending(object sender, EventArgs e)
	    {
		    trainingCompliance.Visible = !trainingCompliance.Visible;
	    }

	    #endregion
    }
}
