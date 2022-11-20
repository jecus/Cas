using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.Dictionary;
using CAA.Entity.Models.DTO;
using CAS.Entity.Models.DTO.General;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CASReports.Builders.CAA;
using CASTerms;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Entity.Abstractions.Filters;
using SmartCore.CAA.CAAEducation;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Personnel;
using SmartCore.Files;

namespace CAS.UI.UICAAControls.Specialists
{
    ///<summary>
    ///</summary>
    public partial class CAAEmployeeScreen : ScreenControl
    {
        #region Fields
        private DateTime? _toDate;
        private CommonCollection<CAAEducationManagment> _initialDocumentArray = new CommonCollection<CAAEducationManagment>();
        private bool _needReload;
        private Specialist _currentItem;
        private readonly int _opearatorId;
        private ContextMenuStrip _buttonPrintMenuStrip;
        private ToolStripMenuItem _itemPrintFCL;
        private ToolStripMenuItem _itemPrintAttachment;
        private ToolStripMenuItem _itemPrintElectronic;
        private ToolStripMenuItem _itemMedicalSertificat;
        private ToolStripMenuItem _itemPrintCabinCrew;
		private List<AircraftModel> aircraftModels = new List<AircraftModel>();
		private List<SmartCore.Purchase.Supplier> _suppliers = new List<SmartCore.Purchase.Supplier>();
		List<CAAEducationRecord> _records = new List<CAAEducationRecord>();

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
            statusControl.ShowStatus = true;
            statusControl.ShowOperatorAircraft = false;

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
            
            if (_itemPrintFCL != null) _itemPrintFCL.Dispose();
            if (_itemPrintAttachment != null) _itemPrintAttachment.Dispose();
            if (_itemPrintElectronic != null) _itemPrintElectronic.Dispose();
            if (_itemMedicalSertificat != null) _itemMedicalSertificat.Dispose();
            if (_itemPrintCabinCrew != null) _itemPrintCabinCrew.Dispose();
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
            employeeLicenceControl.OperatorId = _currentItem.OperatorId;
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
			employeeLicenceControl.Reload += DocumentsControl_Reload;
			
			employeeMedicalControl1.OperatorId = _currentItem.OperatorId;
			employeeMedicalControl1.UpdateControl(_currentItem);
			employeeTrainingListControl1.UpdateControl(_initialDocumentArray, aircraftHeaderControl1.Operator, _records);
	        employeeFlightControl.CurrentItem = _currentItem;
	        employeeFlightControl.Reload += DocumentsControl_Reload;

	        employeeWorkPackageControl.CurrentItem = _currentItem;
	        employeeWorkPackageControl.Reload += DocumentsControl_Reload;

	        headerControl.PrintButtonEnabled = 
	        ButtonPrintMenuStrip.Visible = ButtonPrintMenuStrip.Enabled = GlobalObjects.CaaEnvironment.IdentityUser.CAAUserType < CAAUserType.OperatorAdmin;

        }
		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        {

            #region Загрузка элементов

			AnimatedThreadWorker.ReportProgress(0, "load directives");

            try
            {
				GlobalObjects.CaaEnvironment.NewLoader.ReloadDictionary(typeof(Occupation), typeof(LocationsType), typeof(Department));
                if (_currentItem.ItemId > 0)
	                _currentItem = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<CAASpecialistDTO,Specialist>(_currentItem.ItemId, true);
                
                _currentItem.Images = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CAASpecialistImagesDTO,SpecialistImages>(new Filter("SpecialistId", _currentItem.ItemId)).FirstOrDefault() ?? new SpecialistImages();
                
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
                
                var docs = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CAADocumentDTO, SmartCore.Entities.General.Document>(new Filter("ParentID",_currentItem.ItemId), loadChild:true);
                _currentItem.EmployeeDocuments.Clear();
                _currentItem.EmployeeDocuments.AddRange(docs);

                if (data.Any())
                {
	                var courses = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CAADocumentDTO, SmartCore.Entities.General.Document>(new Filter("ParentID",data.Select(i => i.ItemId)), loadChild:true);
	                _currentItem.EmployeeDocuments.AddRange(courses);
                }
                
                
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
		                GlobalObjects.CaaEnvironment.CaaPerformanceRepository.GetNextPerformance(document);
		                document.Parent = _currentItem;
		                document.Files = new CommonCollection<ItemFileLink>(links.Where(i => i.ParentId == document.ItemId));
	                }
                }


                if (_currentItem.Licenses.Any())
                {
	                var ids = _currentItem.Licenses.Select(i => i.ItemId);
	                var caaLicense = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CAASpecialistCustomDTO, SpecialistCAA>(new Filter("SpecialistLicenseId", FilterType.In,ids));
	                var caaLicenseDetails = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<SpecialistLicenseDetailDTO, SpecialistLicenseDetail>(new Filter("SpecialistLicenseId", FilterType.In,ids));
	                var specialistLicenseRating = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<SpecialistLicenseRatingDTO, SpecialistLicenseRating>(new Filter("SpecialistLicenseId", FilterType.In,ids));
	                var specialistLicenseRemark = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<SpecialistLicenseRemarkDTO, SpecialistLicenseRemark>(new Filter("SpecialistLicenseId", FilterType.In,ids));
	                var specialistInstrumentRating = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<SpecialistInstrumentRatingDTO, SpecialistInstrumentRating>(new Filter("SpecialistLicenseId", FilterType.In,ids));

	                
	                var det = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<SpecialistLicenseDetailDTO, SpecialistLicenseDetail>(new Filter("SpecialistId",_currentItem.ItemId), loadChild:true);
	                var remarks = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<SpecialistLicenseRemarkDTO, SpecialistLicenseRemark>(new Filter("SpecialistId",_currentItem.ItemId), loadChild:true);

	                _currentItem.LicenseDetails = new CommonCollection<SpecialistLicenseDetail>(det);
	                _currentItem.LicenseRemark = new CommonCollection<SpecialistLicenseRemark>(remarks);
	                

	                foreach (var license in _currentItem.Licenses)
	                {
		                license.CaaLicense = new CommonCollection<SpecialistCAA>(caaLicense.Where(i => i.SpecialistLicenseId == license.ItemId));
		                license.LicenseDetails = new CommonCollection<SpecialistLicenseDetail>(caaLicenseDetails.Where(i => i.SpecialistLicenseId == license.ItemId));
		                license.LicenseRatings = new CommonCollection<SpecialistLicenseRating>(specialistLicenseRating.Where(i => i.SpecialistLicenseId == license.ItemId));
		                license.LicenseRemark = new CommonCollection<SpecialistLicenseRemark>(specialistLicenseRemark.Where(i => i.SpecialistLicenseId == license.ItemId));
		                license.SpecialistInstrumentRatings = new CommonCollection<SpecialistInstrumentRating>(specialistInstrumentRating.Where(i => i.SpecialistLicenseId == license.ItemId));
	                }
                }

                _currentItem.MedicalRecord = GlobalObjects.CaaEnvironment.NewLoader.GetObject<CAASpecialistMedicalRecordDTO, SpecialistMedicalRecord>(new Filter("SpecialistId", _currentItem.ItemId));



	            var documents = new List<SmartCore.Entities.General.Document>();

	            if (_currentItem.SpecialistTrainings.Any())
	            {
		            var ids = _currentItem.SpecialistTrainings.Select(i => i.ItemId);
		            var traningDoc = GlobalObjects.CaaEnvironment.NewLoader
			            .GetObjectListAll<CAADocumentDTO, SmartCore.Entities.General.Document>(new List<Filter>()
			            {
				            new Filter("ParentTypeId", SmartCoreType.SpecialistTraining.ItemId),
				            new Filter("ParentID", ids)
			            }, loadChild:true);

		            documents.AddRange(traningDoc);
	            }
	            
	            
	            if (_currentItem.Licenses.Any())
	            {
		            var ids = _currentItem.Licenses.Select(i => i.ItemId);
		            var lisenceDoc = GlobalObjects.CaaEnvironment.NewLoader
			            .GetObjectListAll<CAADocumentDTO, SmartCore.Entities.General.Document>(new List<Filter>()
			            {
				            new Filter("ParentTypeId", SmartCoreType.SpecialistLicense.ItemId),
				            new Filter("ParentID", ids)
			            }, loadChild:true);

		            documents.AddRange(lisenceDoc);


		            var caaIds = _currentItem.Licenses.SelectMany(i => i.CaaLicense).Select(i => i.ItemId);
		            if (caaIds.Any())
		            {
			            var caaDoc = GlobalObjects.CaaEnvironment.NewLoader
				            .GetObjectListAll<CAADocumentDTO, SmartCore.Entities.General.Document>(new List<Filter>()
				            {
					            new Filter("ParentTypeId", SmartCoreType.SpecialistCAA.ItemId),
					            new Filter("ParentID", caaIds)
				            }, loadChild:true);

			            documents.AddRange(caaDoc);
		            }
	            }
	            
	            if (_currentItem.MedicalRecord != null)
	            {
		            var medicalDoc = GlobalObjects.CaaEnvironment.NewLoader
			            .GetObjectListAll<CAADocumentDTO, SmartCore.Entities.General.Document>(new List<Filter>()
			            {
				            new Filter("ParentTypeId", SmartCoreType.SpecialistMedicalRecord.ItemId),
				            new Filter("ParentID", _currentItem.MedicalRecord.ItemId)
			            }, loadChild:true);
		            
		            documents.AddRange(medicalDoc);
	            }
	            
	            

				

	            if (documents.Count > 0)
	            {
		            var docIds = documents.Select(i => i.ItemId);
	                
		            links = GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<CAAItemFileLinkDTO, ItemFileLink>(new List<Filter>()
		            {
			            new Filter("ParentId",docIds),
			            new Filter("ParentTypeId",SmartCoreType.Document.ItemId)
		            }, false);
		            
		            foreach (var document in documents)
		            {
			            GlobalObjects.CaaEnvironment.CaaPerformanceRepository.GetNextPerformance(document);
			            document.Files = new CommonCollection<ItemFileLink>(links.Where(i => i.ParentId == document.ItemId));
		            }
		            
		            
		            
		            if (_currentItem.MedicalRecord != null)
					{
						var crs = GlobalObjects.CaaEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Medical Records") as DocumentSubType;
						var personalTraining = documents.FirstOrDefault(d => d.ParentId == _currentItem.MedicalRecord.ItemId && d.ParentTypeId == SmartCoreType.SpecialistMedicalRecord.ItemId && d.DocumentSubType.ItemId == crs.ItemId);
						if (personalTraining != null)
						{
							_currentItem.MedicalRecord.Document = personalTraining;
							_currentItem.MedicalRecord.Document.Parent = _currentItem.MedicalRecord;
						}
					}
		            foreach (var license in _currentItem.Licenses)
		            {
			            var q = GlobalObjects.CaaEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Personnel License") as DocumentSubType;
			            var conf = GlobalObjects.CaaEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Confirmation") as DocumentSubType;
			            var p = documents.FirstOrDefault(d => d.ParentId == license.ItemId && d.ParentTypeId == SmartCoreType.SpecialistLicense.ItemId && d.DocumentSubType.ItemId == q.ItemId);
			            if (p != null)
			            {
				            license.Document = p;
				            license.Document.Parent = license;
			            }
						foreach (var caa in license.CaaLicense)
			            {
				            if (caa.CaaType == CaaType.Licence)
				            {
					            var personalTraining = documents.FirstOrDefault(d => d.ParentId == caa.ItemId && d.ParentTypeId == SmartCoreType.SpecialistLicense.ItemId && d.DocumentSubType.ItemId == q.ItemId);
					            if (personalTraining != null)
					            {
						            caa.Document = personalTraining;
						            caa.Document.Parent = caa;
					            }
				            }
				            else
				            {
					            var personalTraining = documents.FirstOrDefault(d => d.ParentId == caa.ItemId && d.ParentTypeId == SmartCoreType.SpecialistCAA.ItemId && d.DocumentSubType.ItemId == conf.ItemId);
					            if (personalTraining != null)
					            {
						            caa.Document = personalTraining;
						            caa.Document.Parent = caa;
					            }
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
					
					
					foreach (var document in documents)
						GlobalObjects.CaaEnvironment.CaaPerformanceRepository.GetNextPerformance(document);

					_currentItem.EmployeeDocuments.AddRange(documents);
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
				
				
				var list = new List<ConditionState>();
				if (_currentItem.MedicalRecord != null)
				{
					GlobalObjects.CaaEnvironment.CaaPerformanceRepository.CalcRemain(_currentItem.MedicalRecord, _currentItem.MedicalRecord.IssueDate,_currentItem.MedicalRecord.NotifyLifelength, _currentItem.MedicalRecord.RepeatLifelength);
			                
					if(!_currentItem.MedicalRecord.RepeatLifelength.IsNullOrZero())
						_currentItem.MedicalRecord.ValidToDate = _currentItem.MedicalRecord.IssueDate.AddDays(_currentItem.MedicalRecord.RepeatLifelength.Days.Value);
					list.Add(_currentItem.MedicalRecord.Condition);
				}

				foreach (var license in _currentItem.Licenses)
				{
					foreach (var caa in license.CaaLicense)
					{
						if (!license.IsValidTo)
						{
							caa.Condition = ConditionState.UNK;
							caa.Remain = Lifelength.Null;
							continue;
						}
				                
						if (caa.CaaType == CaaType.Other)
							GlobalObjects.CaaEnvironment.CaaPerformanceRepository.CalcRemain(caa, caa.ValidToDate, caa.NotifyLifelength);
						else GlobalObjects.CaaEnvironment.CaaPerformanceRepository.CalcRemain(caa, license.ValidToDate, license.NotifyLifelength);
					}
					
					if(license.CaaLicense.Any(i => i.CaaType == CaaType.Other)) 
						list.Add(license.CaaLicense.FirstOrDefault(i => i.CaaType == CaaType.Other)?.Condition);
					if(license.CaaLicense.Any(i => i.CaaType == CaaType.Licence)) 
						list.Add(license.CaaLicense.FirstOrDefault(i => i.CaaType == CaaType.Licence)?.Condition);
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
            
            #region Training
            
            _initialDocumentArray.Clear();
            var educations = new List<SmartCore.CAA.CAAEducation.CAAEducation>();
            _records.Clear();

            IEnumerable<Occupation> occupation = new List<Occupation>();
            if(_opearatorId == -1)
	            occupation = GlobalObjects.CaaEnvironment?.GetDictionary<Occupation>().Cast<Occupation>();
            else occupation = GlobalObjects.CaaEnvironment?.GetDictionary<Occupation>().Cast<Occupation>().Where(i => i.OperatorId == _opearatorId);
            

            educations.AddRange(GlobalObjects.CaaEnvironment.NewLoader
	            .GetObjectListAll<EducationDTO, SmartCore.CAA.CAAEducation.CAAEducation>(new Filter("OperatorId", _opearatorId),loadChild:true));
            _records.AddRange(GlobalObjects.CaaEnvironment.NewLoader
	            .GetObjectListAll<EducationRecordsDTO, CAAEducationRecord>(new []
	            {
		            new Filter("OperatorId", _opearatorId),
		            new Filter("SpecialistId", _currentItem.ItemId),
	            }));


            var edIds = _records.Select(i => i.ItemId).ToList();
            var lastIds = _records
	            .Where(i => i.Settings?.LastCompliances != null)
	            .SelectMany(i => i.Settings.LastCompliances)
	            .Where(i => i.DocumentId.HasValue)
	            .Select(i => i.DocumentId.Value).ToList();
            if (edIds.Any())
            {
	            var documents = GlobalObjects.CaaEnvironment.NewLoader
		            .GetObjectListAll<CAADocumentDTO, SmartCore.Entities.General.Document>(new List<Filter>()
		            {
			            new Filter("ParentId", edIds), 
			            new Filter("ParentTypeId", SmartCoreType.CAAEducationRecord.ItemId), 
		            }  , true).ToList();
	            var docIds = documents.Select(i => i.ItemId);

	            var res = lastIds.Except(docIds);
	            if (res.Any())
	            {
		            var doc = GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<CAADocumentDTO, SmartCore.Entities.General.Document>(new Filter("ItemId", res), true);
		            documents.AddRange(doc);
	            }
	            
	            var links = GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<CAAItemFileLinkDTO, ItemFileLink>(new List<Filter>()
	            {
		            new Filter("ParentId",docIds),
		            new Filter("ParentTypeId",SmartCoreType.Document.ItemId)
	            }, false);
	            
	            foreach (var document in documents)
	            {
		            document.Parent = _records.FirstOrDefault(i => i.ItemId == document.ParentId);
		            document.Files = new CommonCollection<ItemFileLink>(links.Where(i => i.ParentId == document.ItemId));
		            GlobalObjects.CaaEnvironment.CaaPerformanceRepository.GetNextPerformance(document);
		            _currentItem.EmployeeDocuments.Add(document);
	            }
	            
            }
            
	        FillCollection(educations, _currentItem.Occupation, _currentItem,_records, false);
	        
	        var comb = new List<string>();
	        if (_currentItem.Combination.Contains(","))
		        comb = _currentItem.Combination.Split(',').ToList();
	        else comb.Add(_currentItem.Combination);
	        
	        foreach (Occupation dict in occupation.Where(i => !i.FullName.Equals(_currentItem.Occupation.FullName) && comb.Contains(i.FullName) ))
            {
	            if (dict.OperatorId == _currentItem.OperatorId)
		            FillCollection(educations, dict, _currentItem,_records);
            }
            
            
            var temp = new CommonCollection<CAAEducationManagment>();
            if (_toDate.HasValue)
            {
	            temp.AddRange(_initialDocumentArray.ToArray());
	            _initialDocumentArray.Clear();
				

	            foreach (var t in temp)
	            {
		            if (t.Record.Settings.NextCompliances != null &&  t.Record.Settings.NextCompliances.Any())
		            {
			            foreach (var next in t.Record.Settings.NextCompliances)
			            {
				            var newItem = t.DeepClone();
				            newItem.Record.Settings.NextCompliance = next;
				            _initialDocumentArray.Add(newItem);
			            }
		            }
		            else
		            {
			            var newItem = t.DeepClone();
			            newItem.Record.Settings.NextCompliance = new NextCompliance();
			            _initialDocumentArray.Add(t);
		            }
	            }
            }

            #endregion

            AnimatedThreadWorker.ReportProgress(100, "Complete");
        }
		#endregion
		
		
		private void FillCollection(List<SmartCore.CAA.CAAEducation.CAAEducation> education,
			Occupation occupation,
			Specialist specialist, List<CAAEducationRecord> records, bool isCombination = true)
		{
			var educations = education.Where(i => i.OccupationId == occupation.ItemId);
			if (educations.Any())
			{
				foreach (var ed in educations)
				{
					var rec = records.FirstOrDefault(i => i.OccupationId == occupation.ItemId 
					                                      && i.EducationId == ed.ItemId
					                                      && i.PriorityId == ed.Priority.ItemId && i.SpecialistId == specialist.ItemId);

					
					if(rec != null)
						rec.Education = ed;
					
					EducationCalculator.CalculateEducation(rec, _toDate);
					var item = new CAAEducationManagment()
					{
						Specialist = specialist,
						Occupation = occupation,
						Education = ed,
						IsCombination = isCombination,
						Record = rec
					};
					_initialDocumentArray.Add(item);
				}
			}
			else
			{
				var item = new CAAEducationManagment()
				{
					Specialist = specialist,
					Occupation = occupation,
					IsCombination = isCombination
				};
				_initialDocumentArray.Add(item);
				
			}
		}

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
			_itemPrintFCL = new ToolStripMenuItem { Text = "License FCL" };
			_itemPrintAttachment = new ToolStripMenuItem { Text = "Attachment to Licence" };
			_itemPrintElectronic = new ToolStripMenuItem { Text = "Electronic Personnel Licence" };
			_itemMedicalSertificat = new ToolStripMenuItem { Text = "Medical Certificate" };
			_itemPrintCabinCrew = new ToolStripMenuItem { Text = "Cabin Crew Attestation" };
            _buttonPrintMenuStrip.Items.AddRange(new ToolStripItem[] { _itemPrintFCL, _itemPrintAttachment,_itemPrintElectronic,_itemMedicalSertificat,_itemPrintCabinCrew });
   
            ButtonPrintMenuStrip = _buttonPrintMenuStrip;
            
            #endregion
            
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
                !employeeLicenceControl.ValidateData(out message))
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
			employeeMedicalControl1.ApplyChanges();

			DocumentsControl.SaveData();

            try
            {
				GlobalObjects.PersonnelCore.Save(_currentItem, true);


				foreach (var remark in _currentItem.LicenseRemark)
					remark.SpecialistId = _currentItem.ItemId;
				foreach (var detail in _currentItem.LicenseDetails)
					detail.SpecialistId = _currentItem.ItemId;

				foreach (var l in _currentItem.Licenses)
				{

					if(l.Document != null)
						l.Document.OperatorId = _currentItem.OperatorId;
					foreach (var specialistCaa in l.CaaLicense)
					{
						if(specialistCaa.Document != null)
							specialistCaa.Document.OperatorId = _currentItem.OperatorId;
					}
					
					l.SpecialistId = _currentItem.ItemId;

					foreach (var caa in l.CaaLicense)
						caa.SpecialistLicenseId = l.ItemId;

					foreach (var detail in l.LicenseDetails)
					{
						detail.SpecialistLicenseId = l.ItemId;
						detail.SpecialistId = _currentItem.ItemId;
					}
					
					foreach (var rating in l.LicenseRatings)
						rating.SpecialistLicenseId = l.ItemId;
					
					foreach (var remark in l.LicenseRemark)
					{
						remark.SpecialistLicenseId = l.ItemId;
						remark.SpecialistId = _currentItem.ItemId;
					}
					
					foreach (var inst in l.SpecialistInstrumentRatings)
						inst.SpecialistLicenseId = l.ItemId;
				}

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
	        if (sender == _itemPrintFCL)
	        {
		        var reporter = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<CAASpecialistDTO,Specialist>(GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId);
		        reporter.Images = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CAASpecialistImagesDTO,SpecialistImages>(new Filter("SpecialistId", reporter.ItemId)).FirstOrDefault() ?? new SpecialistImages();
		        
		        var builder = new SpecialistBuilder(_currentItem, reporter, _records
			        .Where(i => i.Education?.Task?.SubTaskCode == "5030").ToList());
		        e.DisplayerText = $"FCL {_currentItem.FirstName}";
		        e.TypeOfReflection = ReflectionTypes.DisplayInNew;
		        e.RequestedEntity = new ReportScreen(builder);
	        }
	        else if (sender == _itemPrintElectronic)
	        {
		        var reporter = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<CAASpecialistDTO,Specialist>(GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId);
		        reporter.Images = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CAASpecialistImagesDTO,SpecialistImages>(new Filter("SpecialistId", reporter.ItemId)).FirstOrDefault() ?? new SpecialistImages();
		        
		        var builder = new SpecialisLicensetBuilder(_currentItem, reporter, _records
			        .Where(i => i.Education?.Task?.SubTaskCode == "5030").ToList(), _initialDocumentArray);
		        e.DisplayerText = $"Licence {_currentItem.FirstName}";
		        e.TypeOfReflection = ReflectionTypes.DisplayInNew;
		        e.RequestedEntity = new ReportScreen(builder);
	        }
	        else if (sender == _itemMedicalSertificat)
	        {
		        var reporter = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<CAASpecialistDTO,Specialist>(GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId);
		        reporter.Images = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CAASpecialistImagesDTO,SpecialistImages>(new Filter("SpecialistId", reporter.ItemId)).FirstOrDefault() ?? new SpecialistImages();

		        var builder = new SpecialistMedicalBuilder(_currentItem, reporter);
		        e.DisplayerText = $"Medical {_currentItem.FirstName}";
		        e.TypeOfReflection = ReflectionTypes.DisplayInNew;
		        e.RequestedEntity = new ReportScreen(builder);

	        }
	        else if (sender == _itemPrintCabinCrew)
	        {
		        
			        
		        var reporter = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<CAASpecialistDTO,Specialist>(GlobalObjects.CaaEnvironment.IdentityUser.PersonnelId);
		        reporter.Images = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CAASpecialistImagesDTO,SpecialistImages>(new Filter("SpecialistId", reporter.ItemId)).FirstOrDefault() ?? new SpecialistImages();

		        var builder = new AttestationtBuilder(_currentItem, reporter);
		        e.DisplayerText = $"Attestation Cabin Crew {_currentItem.FirstName}";
		        e.TypeOfReflection = ReflectionTypes.DisplayInNew;
		        e.RequestedEntity = new ReportScreen(builder);
			        
	        }
	        else e.Cancel = true;
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
	    
	    private void ForecastMenuClick(object sender, EventArgs e)
	    {
		    _toDate = DateTime.Now;
		    switch ((string)sender)
		    {
			    case"1 Month" : _toDate = _toDate.Value.AddMonths(1);
				    break;
			    case	"3 Month" : _toDate = _toDate.Value.AddMonths(3);
				    break;
			    case	"6 Month": _toDate = _toDate.Value.AddMonths(6);
				    break;
			    case	"1 Year" : _toDate = _toDate.Value.AddYears(1);
				    break;
			    case	"2 Year" : _toDate = _toDate.Value.AddYears(2);
				    break;
			    case	"3 Year": _toDate = _toDate.Value.AddYears(3);
				    break;
			    case	"4 Year": _toDate = _toDate.Value.AddYears(4);
				    break;
			    case	"5 Year": _toDate = _toDate.Value.AddYears(5);
				    break;
			    case	"None": _toDate = null;
				    break;
		    }
			
		    AnimatedThreadWorker.RunWorkerAsync();
	    }
    }
}
