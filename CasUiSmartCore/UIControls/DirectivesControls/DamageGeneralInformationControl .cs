using System;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Events;
using CAS.UI.UIControls.JobCardControls;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Deprecated;
using SmartCore.Entities.General.Directives;
using TempUIExtentions;

namespace CAS.UI.UIControls.DirectivesControls
{
    ///<summary>
    ///</summary>
    public partial class DamageGeneralInformationControl : UserControl, IReference
    {
        #region Fields

        private DamageItem _currentDirective;

        #endregion

        #region Constructors

        #region public DamageGeneralInformationControl()

        ///<summary>
        /// Создает объект для отображения информации о директиве
        ///</summary>
        public DamageGeneralInformationControl()
        {
            InitializeComponent();
            //ataChapterComboBox.UpdateInformation();
        }
        #endregion

        #region public DamageGeneralInformationControl(Aircraft currentAircraft)

        ///<summary>
        /// Создает объект для отображения информации о директиве
        ///</summary>
        public DamageGeneralInformationControl(Aircraft currentAircraft)
        {
            InitializeComponent();
            ataChapterComboBox.UpdateInformation();
        }
        #endregion

        #region public DamageGeneralInformationControl(DamageItem currentDirective)
        ///<summary>
        /// Создает экземпляр класса для отображения информации о директиве
        ///</summary>
        ///<param name="currentDirective"></param>
        public DamageGeneralInformationControl(DamageItem currentDirective)
        {
            if (null == currentDirective)
                throw new ArgumentNullException("currentDirective", "Argument cannot be null");
            _currentDirective = currentDirective;
            InitializeComponent();
            ataChapterComboBox.UpdateInformation();

            AttachedFile adNofile = null;
            if (currentDirective.ADNoFile != null) adNofile = currentDirective.ADNoFile;
            fileControlADNo.UpdateInfo(adNofile, "Adobe PDF Files|*.pdf",
                                             "This record does not contain a file proving the AD No. Enclose PDF file to prove the compliance.",
                                             "Attached file proves the AD No.");
            AttachedFile sBfile = null;
            if (currentDirective.ServiceBulletinFile != null) sBfile = currentDirective.ServiceBulletinFile;
            fileControlSB.UpdateInfo(sBfile, "Adobe PDF Files|*.pdf",
                                           "This record does not contain a file proving the Service bulletin. Enclose PDF file to prove the compliance.",
                                           "Attached file proves the Service bulletin.");
            AttachedFile eOfile = null;
            if (currentDirective.EngineeringOrderFile != null) eOfile = currentDirective.EngineeringOrderFile;
            fileControlEO.UpdateInfo(eOfile, "Adobe PDF Files|*.pdf",
                                           "This record does not contain a file proving the Engineering order. Enclose PDF file to prove the compliance.",
                                           "Attached file proves the Engineering order.");
        }

        #endregion

        #endregion

        #region Properties

        #region public DamageItem CurrentDamageItem
        ///<summary>
        ///Текущая директива
        ///</summary>
        public DamageItem CurrentDamageItem
        {
            get
            {
                return _currentDirective;
            }
            set
            {
                _currentDirective = value;
                if (_currentDirective != null)
                {
                    ataChapterComboBox.UpdateInformation();
                    UpdateInformation();
                }
            }
        }

        #endregion

        #region public ATAChapter ATAChapter
        ///<summary>
        ///ATAChapter текущего агрегата
        ///</summary>
        public AtaChapter ATAChapter
        {
            get
            {
                return ataChapterComboBox.ATAChapter;
            }
            set
            {
                ataChapterComboBox.ATAChapter = value;
            }
        }

        #endregion

        #region public ComboBox ComboBoxATAChapter
        ///<summary>
        ///Возвращает ComboBox с ATAChapter
        ///</summary>
        public ComboBox ComboBoxATAChapter
        {
            get
            {
                return ataChapterComboBox;
            }
        }

        #endregion

        #region public string EngOrderNumber

        /// <summary>
        /// Engineering order no
        /// </summary>
        public string EngOrderNumber
        {
            get
            {
                return textBoxEngOrderNo.Text;
            }
            set
            {
                textBoxEngOrderNo.Text = value;
            }
        }

        #endregion

        #region public ADType ADType

        /// <summary>
        /// Возвращает или устанавливает ADType
        /// </summary>
        public ADType ADType
        {
            get
            {
                if (radioButtonAirFrame.Checked)
                    return ADType.Airframe;
                return ADType.Apliance;
            }
            set
            {
                if (value == ADType.Airframe)
                    radioButtonAirFrame.Checked = true;
                else
                    radioButtonAppliance.Checked = true;
            }
        }

        #endregion

        #region public string Title
        ///<summary>
        ///Имя текущей директивы
        ///</summary>
        public string Title
        {
            get
            {
                return textboxTitle.Text;
            }
            set
            {
                textboxTitle.Text = value;
            }
        }

        #endregion

        #region public string ServiceBulletin
        ///<summary>
        ///Наименование сервисного бюллетеня
        ///</summary>
        public string ServiceBulletin
        {
            get
            {
                return textBoxServiceBulletin.Text;
            }
            set
            {
                textBoxServiceBulletin.Text = value;
            }
        }

        #endregion

        #region public string InspectionDocuments
        ///<summary>
        ///Наименование документов инспекции
        ///</summary>
        public string InspectionDocuments
        {
            get
            {
                return textBoxInspectionDocs.Text;
            }
            set
            {
                textBoxInspectionDocs.Text = value;
            }
        }

        #endregion

        #region public string Paragraph

        /// <summary>
        /// Paragraph текущей директивы
        /// </summary>
        public string Paragraph { get; set; }
        //{
        //    get
        //    {
        //        return textboxParagraph.Text;
        //    }
        //    set
        //    {
        //        textboxParagraph.Text = value;
        //    }
        //}

        #endregion

        #region public DateTime EffectiveDate
        /// <summary>
        /// Дата начала использования текущей директивы
        /// </summary>
        public DateTime EffectiveDate
        {
            get
            {
                return dateTimePickerEffDate.Value;
            }
            set
            {
                dateTimePickerEffDate.Value = value;
            }
        }

        #endregion

        #region public string References

        /// <summary>
        /// References текущей директивы
        /// </summary>
        public string References { get; set; }
        //{
        //    get
        //    {
        //        return textBoxReferences.Text;
        //    }
        //    set
        //    {
        //        textBoxReferences.Text = value;
        //    }
        //}

        #endregion

        #region public string TLPNo
        /// <summary>
        /// TLPNo текущей директивы
        /// </summary>
        public string Applicability
        {
            get
            {
                return textboxApplicability.Text;
            }
            set
            {
                textboxApplicability.Text = value;
            }
        }

		#endregion

		public string Corrective
		{
			get
			{
				return textBoxCorrective.Text;
			}
			set
			{
				textBoxCorrective.Text = value;
			}
		}

		#region public string BiWeeklyReport

		/// <summary>
		/// BiWeeklyReport текущей директивы
		/// </summary>
		public string BiWeeklyReport
        {
            get
            {
                return textboxBiWeeklyReport.Text;
            }
            set
            {
                textboxBiWeeklyReport.Text = value;
            }
        }

        #endregion

        #region public string Subject
        /// <summary>
        /// Описание текущей директивы
        /// </summary>
        public string Subject
        {
            get { return textboxSubject.Text; }
            set
            {
                textboxSubject.Text = value;
            }
        }

        #endregion

        #region public string Remarks
        ///  <summary>
        ///  Заметки текущей директивы
        ///  </summary>
        public string Remarks
        {
            get
            {
                return textboxRemarks.Text;
            }
            set
            {
                textboxRemarks.Text = value;
            }
        }

        #endregion

        #region public string HiddenRemarks
        /// <summary>
        /// Заметки текущей директивы
        /// </summary>
        public string HiddenRemarks
        {
            get
            {
                return textboxHiddenRemarks.Text;
            }
            set
            {
                textboxHiddenRemarks.Text = value;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region public void CancelAsync()
        ///<summary>
        /// запрашивает отмену асинхронной операции
        ///</summary>
        public void CancelAsync()
        {
            if (lookupComboboxJobCard != null)
                lookupComboboxJobCard.CancelAsync();
        }
        #endregion

        #region public bool GetChangeStatus(bool directiveExist)
        ///<summary>
        ///Возвращает значение, показывающее были ли изменения в данном элементе управления
        ///</summary>
        ///<param name="directiveExist">Показывает, существует ли уже директива или нет</param>
        ///<returns></returns>
        public bool GetChangeStatus(bool directiveExist)
        {
            DateTime oldEffDate = _currentDirective.Threshold.EffectiveDate;
            if (directiveExist)
                return (ATAChapter != _currentDirective.ATAChapter ||
                        HiddenRemarks != _currentDirective.HiddenRemarks ||
                        Title != _currentDirective.Title ||
                        EffectiveDate != oldEffDate ||
                        ServiceBulletin != _currentDirective.ServiceBulletinNo ||
                        EngOrderNumber != _currentDirective.EngineeringOrders ||
                        InspectionDocuments != _currentDirective.InspectionDocumentsNo ||
                        Applicability != _currentDirective.Applicability ||
                        Corrective != _currentDirective.CorrectiveAction ||
                        Subject != _currentDirective.Description ||
                        fileControlEO.GetChangeStatus() ||
                        fileControlSB.GetChangeStatus() ||
                        fileControlADNo.GetChangeStatus() ||
                        fileControlInspectionDocs.GetChangeStatus() ||
                        Remarks != _currentDirective.Remarks ||
                        comboBoxMeasure.SelectedItem != _currentDirective.DamageMeasure ||
                        (DamageType)comboBoxDamageType.SelectedItem != _currentDirective.DamageType ||
                        (DamageClass)comboBoxClass.SelectedItem != _currentDirective.DamageClass ||
                        _currentDirective.JobCard == null && lookupComboboxJobCard.SelectedItemId > 0 ||
                        _currentDirective.JobCard != null && lookupComboboxJobCard.SelectedItemId != _currentDirective.JobCard.ItemId || 
                        textBoxLocation.Text != _currentDirective.Location ||
                        textBoxDamageNumber.Text != _currentDirective.Number ||
                        numericUpDownDepth.Value != (decimal)_currentDirective.DamageDepth ||
                        numericUpDownDepthLimit.Value != (decimal)_currentDirective.DamageDepthLimit ||
                        numericUpDownLenght.Value != (decimal)_currentDirective.DamageLenght ||
                        numericUpDownLenghtLimit.Value != (decimal)_currentDirective.DamageLenghtLimit ||
                        numericUpDownWidth.Value != (decimal)_currentDirective.DamageWidth ||
                        numericUpDownWidthLimit.Value != (decimal)_currentDirective.DamageWidthLimit);
            return ((ATAChapter != null) ||
                    (Paragraph != "") ||
                    (ADType != ADType.Airframe) ||
                    (Title != "") ||
                    (EffectiveDate != DateTime.Today) ||
                    (ServiceBulletin != "") ||
                    (EngOrderNumber != "") ||
                    (References != "") ||
                    (Applicability != "") ||
                    (Corrective != "") ||
                    (BiWeeklyReport != "") ||
                    (Subject != "") ||
                    (Remarks != ""));
        }

        #endregion

        #region private void UpdateInformation()
        /// <summary>
        /// 3аполняет поля для редактирования директивы
        /// </summary>
        private void UpdateInformation()
        {
            if (_currentDirective == null)
                return;

            dateTimePickerEffDate.ValueChanged -= DateTimePickerEffDateValueChanged;

            comboBoxMeasure.Items.Clear();
            comboBoxMeasure.Items.Add(Measure.Millimeters);
            comboBoxMeasure.Items.Add(Measure.Inches);

            comboBoxDamageType.Items.Clear();
            foreach (object o in Enum.GetValues(typeof(DamageType)))
                comboBoxDamageType.Items.Add(o);

	        comboBoxClass.Items.Clear();
            foreach (object o in Enum.GetValues(typeof(DamageClass)))
	            comboBoxClass.Items.Add(o);

            ATAChapter = _currentDirective.ATAChapter;
            Title = _currentDirective.Title;
            EffectiveDate = _currentDirective.Threshold.EffectiveDate;
            ServiceBulletin = _currentDirective.ServiceBulletinNo;
            EngOrderNumber = _currentDirective.EngineeringOrders;
            InspectionDocuments = _currentDirective.InspectionDocumentsNo;
            Applicability = "";
	        Corrective = _currentDirective.CorrectiveAction;
            Subject = _currentDirective.Description;
            Remarks = _currentDirective.Remarks;
            HiddenRemarks = _currentDirective.HiddenRemarks;

            comboBoxMeasure.SelectedItem = _currentDirective.DamageMeasure;
            comboBoxDamageType.SelectedItem = _currentDirective.DamageType;
	        comboBoxClass.SelectedItem = _currentDirective.DamageClass;
            textBoxLocation.Text = _currentDirective.Location;
            textBoxDamageNumber.Text = _currentDirective.Number;
            numericUpDownDepth.Value = (decimal)_currentDirective.DamageDepth;
            numericUpDownDepthLimit.Value = (decimal)_currentDirective.DamageDepthLimit;
            numericUpDownLenght.Value = (decimal)_currentDirective.DamageLenght;
            numericUpDownLenghtLimit.Value = (decimal)_currentDirective.DamageLenghtLimit;
            numericUpDownWidth.Value = (decimal)_currentDirective.DamageWidth;
            numericUpDownWidthLimit.Value = (decimal)_currentDirective.DamageWidthLimit;

            if(_currentDirective.DamageType == DamageType.Dent)
                numericUpDownAY.Value = (decimal)(_currentDirective.DamageWidth / _currentDirective.DamageDepth);

            #region Job Card

            lookupComboboxJobCard.SelectedIndexChanged -= LookupComboboxJobCardSelectedIndexChanged;

	        var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(_currentDirective.ParentBaseComponent.ParentAircraftId);//TODO:(Evgenii Babak) пересмотреть использование ParentAircrafId здесь
			if (parentAircraft != null)
            {
                string maintenanceScreenDisplayerText =
                    _currentDirective.ParentBaseComponent.GetParentAircraftRegNumber() + " Job Cards";
				lookupComboboxJobCard.SetItemsScreenControl<CommonListScreen>(new[] { parentAircraft }, maintenanceScreenDisplayerText);
                lookupComboboxJobCard.SetEditScreenControl<JobCardScreen>(maintenanceScreenDisplayerText);
                lookupComboboxJobCard.SetAddScreenControl<JobCardScreen>(new object[] { _currentDirective }, _currentDirective + ". New Job Card");
                lookupComboboxJobCard.LoadObjectsFunc = GlobalObjects.CasEnvironment.NewLoader.GetJobCard;
                lookupComboboxJobCard.FilterParam1 = _currentDirective;
                lookupComboboxJobCard.SelectedItemId = _currentDirective.JobCard != null
                    ? _currentDirective.JobCard.ItemId
                    : -1;
                lookupComboboxJobCard.UpdateInformation();
            }

            lookupComboboxJobCard.SelectedIndexChanged += LookupComboboxJobCardSelectedIndexChanged;

            #endregion

            fileControlADNo.UpdateInfo(_currentDirective.ADNoFile, 
                                    "Adobe PDF Files|*.pdf",
                                    "This record does not contain a file proving the AD No. Enclose PDF file to prove the compliance.",
                                    "Attached file proves the AD No.");

            fileControlSB.UpdateInfo(_currentDirective.ServiceBulletinFile, 
                                    "Adobe PDF Files|*.pdf",
                                    "This record does not contain a file proving the Service bulletin. Enclose PDF file to prove the compliance.",
                                    "Attached file proves the Service bulletin.");
            fileControlEO.UpdateInfo(_currentDirective.EngineeringOrderFile, 
                                    "Adobe PDF Files|*.pdf",
                                    "This record does not contain a file proving the Engineering order. Enclose PDF file to prove the compliance.",
                                    "Attached file proves the Engineering order.");
            fileControlInspectionDocs.UpdateInfo(_currentDirective.InspectionDocumentsFile, 
                                           "Adobe PDF Files|*.pdf",
                                           "This record does not contain a file proving the Inspection documents. Enclose PDF file to prove the compliance.",
                                           "Attached file proves the Inspection documents.");

            dateTimePickerEffDate.ValueChanged += DateTimePickerEffDateValueChanged;
        }

        #endregion

        #region public bool ValidateData(out string message)
        /// <summary>
        /// Возвращает значение, показывающее является ли значение элемента управления допустимым
        /// </summary>
        /// <returns></returns>
        public bool ValidateData(out string message)
        {
            message = "";
            if (ATAChapter == null || ATAChapter.ItemId <= 0)
            {
                if (message != "") message += "\n ";
                message += "Please select ATA chapter";
            }
            if (Title == "")
            {
                message += "You should enter Title ";
            }

            string validateFiles;
            if (!fileControlADNo.ValidateData(out validateFiles))
            {
                if (message != "") message += "\n ";
                message += "AD File: " + validateFiles;
            }

            if (!fileControlSB.ValidateData(out validateFiles))
            {
                if (message != "") message += "\n ";
                message += "SB File: " + validateFiles;
            }

            if (!fileControlEO.ValidateData(out validateFiles))
            {
                if (message != "") message += "\n ";
                message += "EO File: " + validateFiles;
            }

            if (!fileControlInspectionDocs.ValidateData(out validateFiles))
            {
                if (message != "") message += "\n ";
                message += "Inspection Doc File: " + validateFiles;
            }

            if (message != "")
                return false;
            return true;
        }

        #endregion

        #region public void ApplyChanges()

        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        public void ApplyChanges()
        {
            if (_currentDirective != null)
            {
                ApplyChanges(_currentDirective, true);
            }
        }

        #endregion

        #region public void ApplyChanges(DamageItem destinationDamageItem, bool changePageName)
        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        /// <param name="destinationDamageItem">Директива</param>
        /// <param name="changePageName">Менять ли название вкладки</param>
        public void ApplyChanges(DamageItem destinationDamageItem, bool changePageName)
        {
            textboxTitle.Focus();
            if (destinationDamageItem == null)
                throw new ArgumentNullException("destinationDamageItem");
            destinationDamageItem.ATAChapter = ATAChapter;

            if (destinationDamageItem.Title != Title)
            {
                destinationDamageItem.Title = Title;
                if (changePageName)
                {
                    var caption = "";

                    if (destinationDamageItem.ParentBaseComponent != null)
                    {
                        var baseComponent = destinationDamageItem.ParentBaseComponent;

	                    if (baseComponent.BaseComponentTypeId == BaseComponentType.Frame.ItemId)
	                    {
							//у Frame всегда есть ParentAircraftId
							caption = $"{DestinationHelper.GetDestinationStringFromAircraft(baseComponent.ParentAircraftId, false, null)}. {destinationDamageItem.DirectiveType.CommonName}. {destinationDamageItem.Title}";
	                    }
                        else
                        {
                            if (baseComponent.ParentAircraftId > 0)
                                caption = $"{DestinationHelper.GetDestinationStringFromAircraft(baseComponent.ParentAircraftId, false, null)}. ";
                            else if (baseComponent.ParentStoreId > 0)
                                caption = $"{DestinationHelper.GetDestinationStringFromStore(baseComponent.ParentStoreId, null, true)}. ";

                            caption += baseComponent + ". " + destinationDamageItem.DirectiveType.CommonName + ". " + destinationDamageItem.Title;
                        }
                    }
                    if (DisplayerRequested != null)
                        DisplayerRequested(this,
                                           new ReferenceEventArgs(null,
                                                                  ReflectionTypes.ChangeTextOfContainingDisplayer,
                                                                  caption));
                }
            }
            
            destinationDamageItem.HiddenRemarks = HiddenRemarks;
            destinationDamageItem.Threshold.EffectiveDate = EffectiveDate;
            destinationDamageItem.Applicability = Applicability;
            destinationDamageItem.CorrectiveAction = Corrective;
            destinationDamageItem.ServiceBulletinNo = ServiceBulletin;
            destinationDamageItem.EngineeringOrders = EngOrderNumber;
            destinationDamageItem.InspectionDocumentsNo = InspectionDocuments;
            destinationDamageItem.Description = Subject;
            destinationDamageItem.Remarks = Remarks;
            destinationDamageItem.DamageMeasure = comboBoxMeasure.SelectedItem as Measure;
            destinationDamageItem.DamageType = (DamageType) comboBoxDamageType.SelectedItem;
            destinationDamageItem.DamageClass = (DamageClass)comboBoxClass.SelectedItem;
            destinationDamageItem.Location = textBoxLocation.Text;
            destinationDamageItem.Number = textBoxDamageNumber.Text;
            destinationDamageItem.DamageDepth = (double)numericUpDownDepth.Value;
            destinationDamageItem.DamageDepthLimit = (double)numericUpDownDepthLimit.Value;
            destinationDamageItem.DamageLenght = (double) numericUpDownLenght.Value;
            destinationDamageItem.DamageLenghtLimit = (double)numericUpDownLenghtLimit.Value;
            destinationDamageItem.DamageWidth = (double)numericUpDownWidth.Value;
            destinationDamageItem.DamageWidthLimit = (double) numericUpDownWidthLimit.Value;

            destinationDamageItem.JobCard = lookupComboboxJobCard.SelectedItem as JobCard;

            if (fileControlSB.GetChangeStatus())
            {
                fileControlSB.ApplyChanges();
                destinationDamageItem.ServiceBulletinFile = fileControlSB.AttachedFile;
            }

            if (fileControlEO.GetChangeStatus())
            {
                fileControlEO.ApplyChanges();
                destinationDamageItem.EngineeringOrderFile = fileControlEO.AttachedFile;
            }

            if (fileControlADNo.GetChangeStatus())
            {
                fileControlADNo.ApplyChanges();
                destinationDamageItem.ADNoFile = fileControlADNo.AttachedFile;
            }

            if (fileControlInspectionDocs.GetChangeStatus())
            {
                fileControlInspectionDocs.ApplyChanges();
                destinationDamageItem.InspectionDocumentsFile = fileControlInspectionDocs.AttachedFile;
            }
        }
        #endregion

        #region public void ClearFields()

        /// <summary>
        /// Очищает все поля
        /// </summary>
        public void ClearFields()
        {
            ataChapterComboBox.ClearValue();
            ADType = ADType.Airframe;
            Title = "";
            EngOrderNumber = "";
            dateTimePickerEffDate.Value = DateTime.Today;
            Applicability = "";
	        Corrective = "";
            Subject = "";
            Remarks = "";
            HiddenRemarks = "";
            ServiceBulletin = "";
            textBoxLocation.Text = "";
            textBoxDamageNumber.Text = "";
            numericUpDownDepth.Value = 0;
            numericUpDownDepthLimit.Value = 0;
            numericUpDownLenght.Value = 0;
            numericUpDownLenghtLimit.Value = 0;
            numericUpDownWidth.Value = 0;
            numericUpDownWidthLimit.Value = 0;
            numericUpDownDepthLimit.Value = 0;

            comboBoxMeasure.SelectedItem = Measure.Millimeters;
            comboBoxDamageType.SelectedItem = DamageType.Damage;
	        comboBoxClass.SelectedItem = DamageClass.Unknown;

            fileControlEO.AttachedFile = null;
            fileControlADNo.AttachedFile = null;
            fileControlSB.AttachedFile = null;
            fileControlInspectionDocs.AttachedFile = null;
        }

        #endregion

        #region public void SetFieldsUnsaved()

        /// <summary>
        /// Очищает все поля
        /// </summary>
        public void SetFieldsUnsaved()
        {

            if (fileControlEO.AttachedFile != null)
                fileControlEO.AttachedFile.ItemId = -1;
            if (fileControlADNo.AttachedFile != null)
                fileControlADNo.AttachedFile.ItemId = -1;
            if (fileControlSB.AttachedFile != null)
                fileControlSB.AttachedFile.ItemId = -1;
            if (fileControlInspectionDocs.AttachedFile != null)
                fileControlInspectionDocs.AttachedFile.ItemId = -1;
        }

        #endregion

        #region private void DateTimePickerEffDateValueChanged(object sender, EventArgs e)
        private void DateTimePickerEffDateValueChanged(object sender, EventArgs e)
        {
            InvokeEffDateChanget(EffectiveDate);
        }
        #endregion

        #region private void ComboBoxDamageTypeSelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxDamageTypeSelectedIndexChanged(object sender, EventArgs e)
        {
            DamageType damageType = comboBoxDamageType.SelectedItem != null 
                ? (DamageType)comboBoxDamageType.SelectedItem
                : DamageType.Damage;

            if (damageType == DamageType.Damage || damageType == DamageType.Repair)
            {
                numericUpDownLenght.Enabled = numericUpDownLenghtLimit.Enabled = true;
                numericUpDownWidth.Enabled = numericUpDownWidthLimit.Enabled = true;
                
                numericUpDownDepth.Value = numericUpDownDepthLimit.Value = 0;
                numericUpDownDepth.Enabled = numericUpDownDepthLimit.Enabled = false;
                numericUpDownAY.Value = 0;
            }
            if (damageType == DamageType.Dent)
            {
                numericUpDownDepth.Enabled = numericUpDownDepthLimit.Enabled = true;
                numericUpDownWidth.Enabled = numericUpDownWidthLimit.Enabled = true;

                numericUpDownLenght.Value = numericUpDownLenghtLimit.Value = 0;
                numericUpDownLenght.Enabled = numericUpDownLenghtLimit.Enabled = false;
                numericUpDownAY.Value = 0;
            }
            if (damageType == DamageType.Scratch)
            {
                numericUpDownDepth.Enabled = numericUpDownDepthLimit.Enabled = true;
                numericUpDownLenght.Enabled = numericUpDownLenghtLimit.Enabled = true;

                numericUpDownWidth.Value = numericUpDownWidthLimit.Value = 0;
                numericUpDownWidth.Enabled = numericUpDownWidthLimit.Enabled = false;
                numericUpDownAY.Value = 0;
            }
        }
        #endregion

        #region private void NumericUpDownWidthValueChanged(object sender, EventArgs e)
        private void NumericUpDownWidthValueChanged(object sender, EventArgs e)
        {
            DamageType damageType = comboBoxDamageType.SelectedItem != null
               ? (DamageType)comboBoxDamageType.SelectedItem
               : _currentDirective.DamageType;

            if (damageType == DamageType.Dent && numericUpDownDepth.Value != 0)
            {
                numericUpDownAY.Value = numericUpDownWidth.Value / numericUpDownDepth.Value;
            }    
        }
        #endregion

        #region private void NumericUpDownDepthValueChanged(object sender, EventArgs e)
        private void NumericUpDownDepthValueChanged(object sender, EventArgs e)
        {
            DamageType damageType = comboBoxDamageType.SelectedItem != null
               ? (DamageType)comboBoxDamageType.SelectedItem
               : _currentDirective.DamageType;

            if (damageType == DamageType.Dent && numericUpDownDepth.Value != 0)
            {
                numericUpDownAY.Value = numericUpDownWidth.Value / numericUpDownDepth.Value;
            } 
        }
        #endregion

        #region private void LookupComboboxJobCardSelectedIndexChanged(object sender, EventArgs e)
        private void LookupComboboxJobCardSelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #endregion

        #region IReference Members

        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        public IDisplayer Displayer { get; set; }

        /// <summary>
        /// Text of page's header that Reference lead to
        /// </summary>
        public string DisplayerText { get; set; }

        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity { get; set; }

        /// <summary>
        /// Type of reflection
        /// </summary>
        public ReflectionTypes ReflectionType { get; set; }

        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        #endregion

        #region Events
        ///<summary>
        /// Возникает во время изменения эффективной даты 
        ///</summary>
        [Category("Flight data")]
        [Description("Возникает во время изменения эффективной даты")]
        public event DateChangedEventHandler EffDateChanget;

        ///<summary>
        /// Сигнализирует об изменени эффективной даты
        ///</summary>
        ///<param name="e"></param>
        private void InvokeEffDateChanget(DateTime e)
        {
            DateChangedEventHandler handler = EffDateChanget;
            if (handler != null) handler(new DateChangedEventArgs(e));
        }
        #endregion
    }
}
