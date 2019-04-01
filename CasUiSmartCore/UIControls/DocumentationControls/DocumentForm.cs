using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Helpers;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using EFCore.DTO.General;
using EFCore.Filter;
using SmartCore.Auxiliary;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Personnel;
using SmartCore.Entities.General.Schedule;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Files;
using SmartCore.Purchase;
using Component = SmartCore.Entities.General.Accessory.Component;

namespace CAS.UI.UIControls.DocumentationControls
{
    ///<summary>
    /// Форма для представления информации о документе
    ///</summary>
    public partial class DocumentForm : Form
    {
        #region Fields

        private Document _currentDocument;
        private BaseEntityObject _parent;
		private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
		List<Document> parentDocs = new List<Document>();
		List<Supplier> _suppliers = new List<Supplier>();
	    private bool _loadTemplate;

		#endregion

		#region Properties

		///<summary>
		/// Возвращает или задает текуший документ
		///</summary>
		public Document CurrentDocument
        {
            get { return _currentDocument; }
            set
            {
                _currentDocument = value;
                if (_currentDocument != null) _parent = _currentDocument.Parent;
                UpdateInformation();
            }
        }

        #endregion

        #region Constructors

        #region public DocumentForm()
        ///<summary>
        /// создает простую форму без параметров
        ///</summary>
        public DocumentForm()
        {
            InitializeComponent();
        }
        #endregion

        #region public DocumentForm(Document doc) : this()
        ///<summary>
        /// создает форму на основе документа
        ///</summary>
        public DocumentForm(Document doc, bool loadtemplate = true) : this()
        {
            _currentDocument = doc;
            if (_currentDocument != null)
                _parent = _currentDocument.Parent;
	        _loadTemplate = loadtemplate;
			_animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
			_animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;

			UpdateControls();
		}
	    #endregion

        #region public DocumentForm(Document doc, BaseSmartCoreObject parent) : this()
        ///<summary>
        /// создает форму на основе документа и его родителя
        ///</summary>
        public DocumentForm(Document doc, BaseEntityObject parent)
            : this()
        {
            if ((parent as Aircraft == null) && 
                (parent as Operator == null) && 
                (parent as Specialist == null) && 
                (parent as Supplier == null)) return;

            _currentDocument = doc;
            _parent = parent;

			_animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
			_animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
        }
		#endregion

		#endregion

		#region Methods


		#region private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)

		private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
	    {
		    UpdateInformation();
	    }

		#endregion

		#region private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)

		private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
	    {
		    if (_currentDocument == null) return;

		    parentDocs.Clear();
			_suppliers.Clear();

			_animatedThreadWorker.ReportProgress(0, "Loading");

		    if (_currentDocument.ItemId <= 0 && _currentDocument.IssueDateValidTo == DateTimeExtend.GetCASMinDateTime() && _loadTemplate)
		    {
			    if (_parent is Operator)
				    parentDocs = GlobalObjects.DocumentCore.GetDocuments(_parent, DocumentType.Other, true);
			    else if (_parent is Specialist || _parent is Supplier)
				    parentDocs = GlobalObjects.DocumentCore.GetDocumentsByParentType(_parent, DocumentType.Other);
			    else parentDocs = GlobalObjects.DocumentCore.GetDocuments(_parent.SmartCoreObjectType, DocumentType.Other, true);
		    }

			var links = GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<ItemFileLinkDTO, ItemFileLink>(new List<Filter>()
			{
				new Filter("ParentId",_currentDocument.ItemId),
				new Filter("ParentTypeId",_currentDocument.SmartCoreObjectType.ItemId)
			}, true);

			_currentDocument.Files.AddRange(links);

			_animatedThreadWorker.ReportProgress(80, "Loading Suppliers");
			_suppliers.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<SupplierDTO, Supplier>());

		    var q = _suppliers.Where(i => i.Name == null);
		    foreach (var supplier in q)
		    {
			    GlobalObjects.CasEnvironment.Keeper.Delete(supplier);
		    }

			_animatedThreadWorker.ReportProgress(100, "Loading complete");
	    }

		#endregion

		#region private void DocumentForm_Load(object sender, System.EventArgs e)

		private void DocumentForm_Load(object sender, EventArgs e)
	    {
		    _animatedThreadWorker.RunWorkerAsync();
	    }

	    #endregion

		#region private void UpdateInformation()
		private void UpdateInformation()
        {
            if(_currentDocument == null) return;

			fileControl.UpdateInfo(_currentDocument.AttachedFile, "Adobe PDF Files|*.pdf",
										 "This record does not contain a file proving the Document. Enclose PDF file to prove the Document.",
										 "Attached file proves the Document.");

			if (_currentDocument.ItemId <= 0 && _currentDocument.IssueDateValidTo == DateTimeExtend.GetCASMinDateTime())
			{
				comboBoxTemplate.Items.Clear();
				comboBoxTemplate.Items.AddRange(parentDocs.ToArray());
				comboBoxTemplate.Enabled = comboBoxTemplate.Items.Count != 0;
				_currentDocument.IssueDateValidTo = DateTime.Today.AddYears(1);
			}
			else comboBoxTemplate.Enabled = false;

			//обновление вып. списка типов документа
			comboBoxDocumentType.Items.Clear();
			comboBoxDocumentType.Items.AddRange(DocumentType.Items.ToArray());
			//оператору недоступен тип Equipment
			if (_parent is Operator) comboBoxDocumentType.Items.Remove(DocumentType.Equipment);
			comboBoxDocumentType.SelectedItem = _currentDocument.DocType;

			//обновление под.типа
			var fromEnv = (DocumentSubTypeCollection)GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>();
			var certificatesSubs = new DocumentSubTypeCollection();
			certificatesSubs.AddRange(fromEnv.GetSubTypesByDocType(_currentDocument.DocType));

			comboBoxSubType.Items.Clear();
			comboBoxSubType.Items.AddRange(certificatesSubs.ToArray());
			comboBoxSubType.Items.Add(DocumentSubType.Unknown);

			comboBoxSupplier.Items.Clear();
			comboBoxSupplier.Items.AddRange(_suppliers.ToArray());
			comboBoxSupplier.Items.Add(Supplier.Unknown);
			comboBoxSupplier.SelectedItem = _currentDocument.Supplier;

			//оператору недоступен тип AW
			if (_parent is Operator) comboBoxSubType.Items.Remove(certificatesSubs.GetTypeByName("AW"));
			//воздушному судну недоступен тип AOC
			if (_parent is Aircraft) comboBoxSubType.Items.Remove(certificatesSubs.GetTypeByName("AOC"));
			comboBoxSubType.SelectedItem = _currentDocument.DocumentSubType;

			textBoxContractNumber.Text = _currentDocument.ContractNumber;
			textBoxRemarks.Text = _currentDocument.Remarks;

			#region Заполнение comboBoxPrologWay значениями из ProlongationWay

			comboBoxPrologWay.DisplayMember = "Key";
			comboBoxPrologWay.ValueMember = "Value";
			comboBoxPrologWay.DataSource = EnumHelper.GetDisplayValueMemberDict<ProlongationWay>();
			comboBoxPrologWay.SelectedValue = _currentDocument.ProlongationWay;

			#endregion

			#region Заполнение comboBoxNomenclature

			//var nomenclatures = GlobalObjects.CasEnvironment.GetDictionary<Nomenclatures>().ToArray();
			//comboBoxNomenclature.Items.Clear();
			//comboBoxNomenclature.Items.AddRange(nomenclatures);
			//comboBoxNomenclature.Items.Add(Nomenclatures.Unknown);
			//comboBoxNomenclature.SelectedItem = _currentDocument.Nomenсlature;

			#endregion

			#region Заполнение comboBoxServiceType

			dictComboBoxServiceType.Type = typeof (ServiceType);
			dictComboBoxServiceType.SelectedItem = _currentDocument.ServiceType;
			Program.MainDispatcher.ProcessControl(dictComboBoxServiceType);

			#endregion

			#region Заполнение comboBoxDepartment

			var departments = GlobalObjects.CasEnvironment.GetDictionary<Department>().ToArray();
			comboBoxDepartment.Items.Clear();
			comboBoxDepartment.Items.AddRange(departments);
			comboBoxDepartment.Items.Add(Department.Unknown);
			comboBoxDepartment.SelectedItem = _currentDocument.Department;

			#endregion

			#region Заполнение comboBoxResponsible

			//var specialization = GlobalObjects.CasEnvironment.GetDictionary<Specialization>().ToArray();
			//comboBoxResponsible.Items.Clear();
			//comboBoxResponsible.Items.AddRange(specialization);
			//comboBoxResponsible.Items.Add(Specialization.Unknown);
			//comboBoxResponsible.SelectedItem = _currentDocument.ResponsibleOccupation;

			#endregion

			#region Заполнение comboBoxServiceType
	  
			//dictionaryComboBoxLocation.Type = typeof(Locations);
			//dictionaryComboBoxLocation.SelectedItem = _currentDocument.Location;
			//Program.MainDispatcher.ProcessControl(dictionaryComboBoxLocation);

			#endregion


			dateTimePickerRevisionValidTo.Value = _currentDocument.RevisionDateValidTo < DateTimeExtend.GetCASMinDateTime() ? DateTime.Today : _currentDocument.RevisionDateValidTo;
			numericUpDownRevisionNotify.Value = _currentDocument.RevisionNotify;
			checkBoxAboard.Checked = _currentDocument.Aboard;
			checkBoxPrivy.Checked = _currentDocument.Privy;
			textBoxDescription.Text = _currentDocument.Description;
			dateTimePickerIssueValidFrom.Value = _currentDocument.IssueDateValidFrom < DateTimeExtend.GetCASMinDateTime() ? DateTime.Today : _currentDocument.IssueDateValidFrom;
			checkBoxIssueValidTo.Checked = _currentDocument.IssueValidTo;
			dateTimePickerIssueValidTo.Value = _currentDocument.IssueDateValidTo < DateTimeExtend.GetCASMinDateTime() ? DateTime.Today : _currentDocument.IssueDateValidTo;
			textBoxNumberIssue.Text = _currentDocument.IssueNumber;
			numericUpDownIssueNotify.Value = _currentDocument.IssueNotify;
			checkBoxRevision.Checked = _currentDocument.Revision;
			checkBoxRevisionValidTo.Checked = _currentDocument.RevisionValidTo;
			checkBoxClosed.Checked = _currentDocument.IsClosed;
			dateTimePickerRevisionDateFrom.Value = _currentDocument.RevisionDateFrom;
			textBoxRevNumber.Text = _currentDocument.RevisionNumder;
            textBoxIdNumber.Text = _currentDocument.IdNumber;


        }
		#endregion

		#region private void UpdateControls()

		private void UpdateControls()
		{
			if(_parent == null) return;

			if (_parent is DirectiveRecord || _parent is Component || _parent is ComponentDirective || _parent is WorkPackage)
			{
				comboBoxDocumentType.Enabled = false;
				comboBoxSubType.Enabled = false;
				textBoxContractNumber.Enabled = false;
				textBoxDescription.Enabled = false;
				checkBoxClosed.Enabled = false;
			}
			else if (_parent is SpecialistTraining)
			{
				comboBoxSubType.Enabled = false;
			}
			else if (_parent is SpecialistMedicalRecord || _parent is SpecialistCAA || _parent is SpecialistLicense || _parent is FlightNumberPeriod || _parent is FlightPlanOpsRecords)
			{
				comboBoxDocumentType.Enabled = false;
				comboBoxSubType.Enabled = false;
			}
			else if (_parent is AircraftFlight)
			{
				comboBoxDocumentType.Enabled = false;
				comboBoxSubType.Enabled = false;
				textBoxContractNumber.Enabled = false;
				textBoxDescription.Enabled = false;
				dateTimePickerIssueValidFrom.Enabled = false;
			}
		}
		#endregion

		#region private void CheckExist()
		private bool CheckExist()
        {
            //Проверка на то, не существует ли такой подтип для данного типа документов у текущего родителя
            List<Document> parentDocs =
                GlobalObjects.DocumentCore.GetDocuments(_parent, 
                    comboBoxDocumentType.SelectedItem != null 
                        ? (DocumentType)comboBoxDocumentType.SelectedItem
                        : DocumentType.Other);

            if (parentDocs.Count == 0) return true;//данный родитель пока не имеет документов
            if (comboBoxSubType.SelectedItem == null) return true;//подтип не задан

            //Поиск документа с заданным подтипом
            //Document exist = parentDocs.Where(d => d.DocumentSubType ==
            //                                       ((DocumentSubType) comboBoxSubType.SelectedItem).ItemId).FirstOrDefault();
            if (comboBoxDocumentType.SelectedItem == DocumentType.Certificate)
            {
                //Для сертификатов нельзя оздавать 2 и более документов одного подпита 
                //для каждого родителя 
                Document exist = parentDocs.FirstOrDefault(d => d.DocumentSubType == comboBoxSubType.SelectedItem
                                                                && d.ParentId == _parent.ItemId);
                if (exist != null)
                {
                    //документа с заданным типом нет - проверка проидена
                    return exist.ItemId == _currentDocument.ItemId;
                }
                return true;
            }
            return true;
        }
		#endregion

		#region  private void ApplyChanges()

		private void ApplyChanges()
	    {
		    _currentDocument.ParentId = _parent.ItemId;
		    _currentDocument.Parent = _parent;
		    _currentDocument.ParentTypeId = _parent.SmartCoreObjectType.ItemId;
		    _currentDocument.DocType = (DocumentType) comboBoxDocumentType.SelectedItem;
		    _currentDocument.DocumentSubType = comboBoxSubType.SelectedItem != null
			    ? ((DocumentSubType)comboBoxSubType.SelectedItem)
			    : DocumentSubType.Unknown;
		    _currentDocument.Description = textBoxDescription.Text;
		    _currentDocument.IssueDateValidFrom = dateTimePickerIssueValidFrom.Value;
		    _currentDocument.IssueValidTo = checkBoxIssueValidTo.Checked;
		    _currentDocument.IssueDateValidTo = dateTimePickerIssueValidTo.Value;
		    _currentDocument.IssueNotify = (int)numericUpDownIssueNotify.Value;
		    _currentDocument.IssueNumber = textBoxNumberIssue.Text;
		    _currentDocument.Remarks = textBoxRemarks.Text;
		    _currentDocument.Revision = checkBoxRevision.Checked;
		    _currentDocument.RevisionDateFrom = dateTimePickerRevisionDateFrom.Value;
			_currentDocument.RevisionValidTo = checkBoxRevisionValidTo.Checked;
			_currentDocument.RevisionDateValidTo = dateTimePickerRevisionValidTo.Value;
			_currentDocument.RevisionNotify = (int)numericUpDownRevisionNotify.Value;
			_currentDocument.RevisionNumder = textBoxRevNumber.Text;
		    _currentDocument.ContractNumber = textBoxContractNumber.Text;
		    _currentDocument.Supplier = comboBoxSupplier.SelectedItem as Supplier;
		    _currentDocument.IsClosed = checkBoxClosed.Checked;
			_currentDocument.Aboard = checkBoxAboard.Checked;
			_currentDocument.Privy = checkBoxPrivy.Checked;
            _currentDocument.IdNumber = textBoxIdNumber.Text;


            if (_parent is Aircraft)
			    _currentDocument.ParentAircraftId = _parent.ItemId;

			_currentDocument.ProlongationWay = comboBoxPrologWay.SelectedValue != null 
				?((ProlongationWay)comboBoxPrologWay.SelectedValue)
				: ProlongationWay.Unknown;

			_currentDocument.Nomenсlature = comboBoxNomenclature.SelectedItem != null
				? (Nomenclatures)comboBoxNomenclature.SelectedItem
				: Nomenclatures.Unknown;

			_currentDocument.ServiceType = dictComboBoxServiceType.SelectedItem != null
				? (ServiceType)dictComboBoxServiceType.SelectedItem
				: ServiceType.Unknown;

			_currentDocument.Department = comboBoxDepartment.SelectedItem != null
				? (Department)comboBoxDepartment.SelectedItem
				: Department.Unknown;

			_currentDocument.ResponsibleOccupation = comboBoxResponsible.SelectedItem != null
				? (Specialization) comboBoxResponsible.SelectedItem
				: Specialization.Unknown;

		    _currentDocument.Location = dictionaryComboBoxLocation.SelectedItem != null
			    ? (Locations)dictionaryComboBoxLocation.SelectedItem
			    : Locations.Unknown;

			if (fileControl.GetChangeStatus())
		    {
			    fileControl.ApplyChanges();
			    _currentDocument.AttachedFile = fileControl.AttachedFile;
		    }
	    }
		#endregion

		#region private void CheckBoxIssueValidToCheckedChanged(object sender, EventArgs e)

		private void CheckBoxIssueValidToCheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerIssueValidTo.Enabled = numericUpDownIssueNotify.Enabled = checkBoxIssueValidTo.Checked;
        }

		#endregion

		#region private void CheckBoxRevisionCheckedChanged(object sender, EventArgs e)

		private void CheckBoxRevisionCheckedChanged(object sender, EventArgs e)
        {
			checkBoxRevisionValidTo.Enabled = dateTimePickerRevisionDateFrom.Enabled = textBoxRevNumber.Enabled = checkBoxRevision.Checked;

	        if (checkBoxRevisionValidTo.Checked)
		        checkBoxRevisionValidTo.Checked = false;
        }

        #endregion

        #region private void ComboBoxDocumentTypeSelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxDocumentTypeSelectedIndexChanged(object sender, EventArgs e)
        {
            DocumentType type = (DocumentType) comboBoxDocumentType.SelectedItem;
            comboBoxSubType.Items.Clear();
            //List<DocumentSubType> list = GlobalObjects.CasEnvironment.DocSubTypes.GetSubTypesByDocType((DocumentType)comboBoxDocumentType.SelectedItem);
            var dstc = (DocumentSubTypeCollection) GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>();
            List<DocumentSubType> list = dstc.GetSubTypesByDocType((DocumentType)comboBoxDocumentType.SelectedItem);
            
            foreach (DocumentSubType item in list)
            {
                comboBoxSubType.Items.Add(item);
            }
            //if(type.ItemID != DocumentType.Contract.ItemID)
            //{
            //    textBoxContractNumber.Enabled =
            //    textBoxPayerName.Enabled =
            //    textBoxProlongation.Enabled =
            //    textBoxServiceType.Enabled =
            //    textBoxResponsible.Enabled = false;    
            //}
            //else 
            if (type.ItemId == DocumentType.Equipment.ItemId)
            {
                //textBoxContractNumber.Enabled =
                //    textBoxPayerName.Enabled =
                //    textBoxProlongation.Enabled =
                //    textBoxServiceType.Enabled =
                //    textBoxResponsible.Enabled =
                    checkBoxIssueValidTo.Enabled =
                    dateTimePickerIssueValidFrom.Enabled =
                    dateTimePickerIssueValidTo.Enabled = false;
            }
            //else
            //{
            //    textBoxContractNumber.Enabled =
            //    textBoxPayerName.Enabled =
            //    textBoxProlongation.Enabled =
            //    textBoxServiceType.Enabled =
            //    textBoxResponsible.Enabled = true;      
            //}
        }
        #endregion

        private void comboBoxSubType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #region private void ButtonOkClick(object sender, EventArgs e)
        private void ButtonOkClick(object sender, EventArgs e)
        {
	        try
	        {
		        ApplyChanges();

		        GlobalObjects.DocumentCore.SaveDocumentsList(_parent, new List<Document> {CurrentDocument});
			    DialogResult = DialogResult.OK;
			    Close();
	        }
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while save document", ex);
			}
		}
        #endregion

        #region private void ButtonCancelClick(object sender, EventArgs e)
        private void ButtonCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
		#endregion

		#region private void DateTimePickerIssueValidFromValueChanged(object sender, EventArgs e)
		private void DateTimePickerIssueValidFromValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerIssueValidFrom.Value > dateTimePickerIssueValidTo.Value)
                dateTimePickerIssueValidFrom.Value = dateTimePickerIssueValidTo.Value;
        }
		#endregion

		#region private void DateTimePickerIssueValidToValueChanged(object sender, EventArgs e)
		private void DateTimePickerIssueValidToValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerIssueValidTo.Value < dateTimePickerIssueValidFrom.Value)
                dateTimePickerIssueValidTo.Value = dateTimePickerIssueValidFrom.Value;
        }
        #endregion

        #region private void ButtonEditTypesClick(object sender, EventArgs e)
        private void ButtonEditTypesClick(object sender, EventArgs e)
        {
            DocumentSubTypeForm maintenanceTypeEdit = new DocumentSubTypeForm((DocumentType)comboBoxDocumentType.SelectedItem);
            maintenanceTypeEdit.ShowDialog(this);
           
            comboBoxSubType.Items.Clear();

            var dstc = (DocumentSubTypeCollection) GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>();
            List<DocumentSubType> list = dstc.GetSubTypesByDocType((DocumentType)comboBoxDocumentType.SelectedItem);
            foreach (DocumentSubType item in list)
            {
                comboBoxSubType.Items.Add(item);
            }
        }
        #endregion

        private void comboBoxSubType_TextUpdate(object sender, EventArgs e)
        {
	        
		}

        #region private void ComboBoxTemplateSelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxTemplateSelectedIndexChanged(object sender, EventArgs e)
        {
            if( comboBoxTemplate.SelectedItem == null ||
                comboBoxTemplate.SelectedItem as Document == null) return;
            _currentDocument.SetProperties(comboBoxTemplate.SelectedItem as Document);
            UpdateInformation();
        }
		#endregion

		#region private void CheckBoxRevisionValidToCheckedChanged(object sender, EventArgs e)

		private void CheckBoxRevisionValidToCheckedChanged(object sender, EventArgs e)
		{
			dateTimePickerRevisionValidTo.Enabled = numericUpDownRevisionNotify.Enabled = checkBoxRevisionValidTo.Checked;
		}

		#endregion

		#endregion

		private void comboBoxDepartment_SelectedIndexChanged(object sender, EventArgs e)
		{
			var department = comboBoxDepartment.SelectedItem as Department;

			var nomenclatures = GlobalObjects.CasEnvironment.GetDictionary<Nomenclatures>().Cast<Nomenclatures>().Where(i => i.Department?.ItemId == department.ItemId).ToArray();
			comboBoxNomenclature.Items.Clear();
			comboBoxNomenclature.Items.AddRange(nomenclatures);
			comboBoxNomenclature.Items.Add(Nomenclatures.Unknown);
			comboBoxNomenclature.SelectedItem = _currentDocument.Nomenсlature;

			var specialization = GlobalObjects.CasEnvironment.GetDictionary<Specialization>().Cast<Specialization>().Where(i => i.Department?.ItemId == department.ItemId).ToArray();
			comboBoxResponsible.Items.Clear();
			comboBoxResponsible.Items.AddRange(specialization);
			comboBoxResponsible.Items.Add(Specialization.Unknown);
			comboBoxResponsible.SelectedItem = _currentDocument.ResponsibleOccupation;

			dictionaryComboBoxLocation.Type = typeof(Locations);
			dictionaryComboBoxLocation.SelectedItem = _currentDocument.Location;
			Program.MainDispatcher.ProcessControl(dictionaryComboBoxLocation);
			dictionaryComboBoxLocation.UpdateDepartment(department.ItemId);
		}

		private void comboBoxNomenclature_TextUpdate(object sender, EventArgs e)
		{
			var _filterString = comboBoxNomenclature.Text;

			comboBoxNomenclature.Items.Clear();
			var department = comboBoxDepartment.SelectedItem as Department;
			foreach (var dic in GlobalObjects.CasEnvironment.GetDictionary<Nomenclatures>().Cast<Nomenclatures>().Where(i => i.Department?.ItemId == department.ItemId).Where(i => i.ToString().ToLowerInvariant().Contains(_filterString.ToLowerInvariant())))
				comboBoxNomenclature.Items.Add(dic);

			comboBoxNomenclature.DropDownStyle = ComboBoxStyle.DropDown;
			comboBoxNomenclature.SelectionStart = _filterString.Length;
		}
	}
}
