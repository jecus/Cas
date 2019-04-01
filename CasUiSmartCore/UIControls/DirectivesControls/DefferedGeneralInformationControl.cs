using System;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.AircraftTechnicalLogBookControls;
using CAS.UI.UIControls.Auxiliary.Events;
using CASTerms;
using EFCore.DTO.General;
using EFCore.Filter;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Directives;
using SmartCore.Filters;

namespace CAS.UI.UIControls.DirectivesControls
{
    ///<summary>
    ///</summary>
    public partial class DefferedGeneralInformationControl : UserControl, IReference
    {
        #region Fields
        private DeferredItem _currentDefferedItem;
        #endregion

        #region Constructors

        #region public DefferedGeneralInformationControl()

        ///<summary>
        /// Создает объект для отображения информации о директиве
        ///</summary>
        public DefferedGeneralInformationControl()
        {
            InitializeComponent();
            ataChapterComboBox.UpdateInformation();
        }
        #endregion

        #region public DefferedGeneralInformationControl(Aircraft currentAircraft)

        ///<summary>
        /// Создает объект для отображения информации о директиве
        ///</summary>
        public DefferedGeneralInformationControl(Aircraft currentAircraft)
        {
            InitializeComponent();
            ataChapterComboBox.UpdateInformation();
            if (currentAircraft != null)
            {
                DefferedCategoriesCollection defferedCategories =
                    GlobalObjects.CasEnvironment.Loader.
                        GetObjectCollection<DeferredCategory, DefferedCategoriesCollection>
                        (new ICommonFilter[]{new CommonFilter<AircraftModel>(DeferredCategory.AircraftModelProperty,currentAircraft.Model)});
                comboBoxDefferedCategory.Items.Clear();
                comboBoxDefferedCategory.Items.AddRange(defferedCategories.ToArray());
            }

        }
        #endregion

        #region public DirectiveGeneralInformationControl(DefferedItem currentDirective)

        ///<summary>
        /// Создает экземпляр класса для отображения информации о директиве
        ///</summary>
        ///<param name="currentDirective"></param>
        public DefferedGeneralInformationControl(DeferredItem currentDirective)
        {
            if (null == currentDirective)
                throw new ArgumentNullException("currentDirective", "Argument cannot be null");
            _currentDefferedItem = currentDirective;
            InitializeComponent();
            ataChapterComboBox.UpdateInformation();

            AttachedFile adNoFile = null;
            if (currentDirective.ADNoFile != null) adNoFile = currentDirective.ADNoFile;
            fileControlADNo.UpdateInfo(adNoFile, "Adobe PDF Files|*.pdf",
                                             "This record does not contain a file proving the AD No. Enclose PDF file to prove the compliance.",
                                             "Attached file proves the AD No.");

            AttachedFile sbFile = null;
            if (currentDirective.ServiceBulletinFile != null) sbFile = currentDirective.ServiceBulletinFile;
            fileControlSB.UpdateInfo(sbFile, "Adobe PDF Files|*.pdf",
                                           "This record does not contain a file proving the Service bulletin. Enclose PDF file to prove the compliance.",
                                           "Attached file proves the Service bulletin.");
            AttachedFile eoFile = null;
            if (currentDirective.EngineeringOrderFile != null) eoFile = currentDirective.EngineeringOrderFile;
            fileControlEO.UpdateInfo(eoFile, "Adobe PDF Files|*.pdf",
                                           "This record does not contain a file proving the Engineering order. Enclose PDF file to prove the compliance.",
                                           "Attached file proves the Engineering order.");
        }

        #endregion

        #endregion

        #region Properties

        #region public DefferedItem CurrentPrimaryDirective
        ///<summary>
        ///Текущая директива
        ///</summary>
        public DeferredItem CurrentDefferedItem
        {
            set
            {
                _currentDefferedItem = value;
                if (_currentDefferedItem != null)
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
            private set
            {
                ataChapterComboBox.ATAChapter = value;
            }
        }

        #endregion

        #region public string EngOrderNumber
        /// <summary>
        /// Engineering order no
        /// </summary>
        public string EngOrderNumber
        {
            private get
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
            private get
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
            private get
            {
                return textBoxServiceBulletin.Text;
            }
            set
            {
                textBoxServiceBulletin.Text = value;
            }
        }

        #endregion

        #region public string Paragraph

        /// <summary>
        /// Paragraph текущей директивы
        /// </summary>
        public string Paragraph { private get; set; }
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

        #region public bool DiscoveryDateEnabled
        /// <summary>
        /// Возвращает или задает значение, доступна ли для редактирования дата открытия директивы
        /// </summary>
        public bool DiscoveryDateEnabled
        {
            get
            {
                return dateTimePickerEffDate.Enabled;
            }
            set
            {
                dateTimePickerEffDate.Enabled = value;
            }
        }

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
        public string LogBookReferences
        {
            get
            {
                return textBoxLogBookRef.Text;
            }
            set
            {
                textBoxLogBookRef.Text = value;
            }
        }

        #endregion

        #region public string MelCdlItem

        /// <summary>
        /// References текущей директивы
        /// </summary>
        public string MelCdlItem
        {
            get
            {
                return textBoxMelCdlItem.Text;
            }
            set
            {
                textBoxMelCdlItem.Text = value;
            }
        }

        #endregion

        #region public string Extention

        /// <summary>
        /// References текущей директивы
        /// </summary>
        public string Extention
        {
            get
            {
                return textBoxExtention.Text;
            }
            set
            {
                textBoxExtention.Text = value;
            }
        }

        #endregion

        #region public string Applicability
        /// <summary>
        /// TLPNo текущей директивы
        /// </summary>
        public string Applicability
        {
            private get
            {
                return textboxApplicability.Text;
            }
            set
            {
                textboxApplicability.Text = value;
            }
        }

        #endregion

        #region public string BiWeeklyReport

        /// <summary>
        /// BiWeeklyReport текущей директивы
        /// </summary>
        public string BiWeeklyReport
        {
            private get
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
            private get { return textboxSubject.Text; }
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
            private get
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
            private get
            {
                return textboxHiddenRemarks.Text;
            }
            set
            {
                textboxHiddenRemarks.Text = value;
            }
        }

        #endregion

        #region public DefferedCategory CurrentDefferedCategory

        /// <summary>
        /// References текущей директивы
        /// </summary>
        private DeferredCategory CurrentDefferedCategory //{ get; set; }
        {
            get
            {
                if (comboBoxDefferedCategory.Items.Count == 0)
                    return null;
                return (DeferredCategory)comboBoxDefferedCategory.SelectedItem;
            }
        }

        #endregion

        #endregion

        #region Methods
       
        #region public bool GetChangeStatus(bool directiveExist)
        ///<summary>
        ///Возвращает значение, показывающее были ли изменения в данном элементе управления
        ///</summary>
        ///<param name="directiveExist">Показывает, существует ли уже директива или нет</param>
        ///<returns></returns>
        public bool GetChangeStatus(bool directiveExist)
        {
            DateTime oldEffDate = _currentDefferedItem.Threshold.EffectiveDate;
            if (directiveExist)
                return (((ATAChapter !=_currentDefferedItem.ATAChapter) ||
                    ((HiddenRemarks != _currentDefferedItem.HiddenRemarks ||
                     (Title != _currentDefferedItem.Title) ||
                     (EffectiveDate != oldEffDate) ||
                     (ServiceBulletin != _currentDefferedItem.ServiceBulletinNo) ||
                     (EngOrderNumber != _currentDefferedItem.EngineeringOrders) ||
                     (Applicability != _currentDefferedItem.Applicability) ||
                     (Subject != _currentDefferedItem.Description) ||
                     (LogBookReferences != _currentDefferedItem.DeferredLogBookRef) ||
                     (MelCdlItem != _currentDefferedItem.DeferredMelCdlItem) ||
                     (Extention != _currentDefferedItem.DeferredExtention) ||
                     (Remarks != _currentDefferedItem.Remarks) ||
                     (fileControlEO.GetChangeStatus()) ||
                     (fileControlSB.GetChangeStatus()) ||
                     (fileControlADNo.GetChangeStatus()) ||
                     (CurrentDefferedCategory != null && CurrentDefferedCategory != _currentDefferedItem.DeferredCategory)))));
            
            return ((ATAChapter != null) ||
                    (Paragraph != "") ||
                    (ADType != ADType.Airframe) ||
                    (Title != "") ||
                    (EffectiveDate != DateTime.Today) ||
                    (ServiceBulletin != "") ||
                    (EngOrderNumber != "") ||
                    (LogBookReferences != "") ||
                    (MelCdlItem != "") ||
                    (Extention != "") ||
                    (Applicability != "") ||
                    (BiWeeklyReport != "") ||
                    (Subject != "") ||
                    (Remarks != "") ||
                    (CurrentDefferedCategory != null));
        }

        #endregion

        #region private void UpdateInformation()

        /// <summary>
        /// 3аполняет поля для редактирования директивы
        /// </summary>
        private void UpdateInformation()
        {
            if (_currentDefferedItem == null)
                return;

            dateTimePickerEffDate.ValueChanged -= DateTimePickerEffDateValueChanged;

            ATAChapter = _currentDefferedItem.ATAChapter;
            DefferedCategoriesCollection defferedCategories =
                GlobalObjects.CasEnvironment.Loader.
                GetObjectCollection<DeferredCategory, DefferedCategoriesCollection>
                (new ICommonFilter[] { new CommonFilter<AircraftModel>(DeferredCategory.AircraftModelProperty, GlobalObjects.AircraftsCore.GetAircraftById(_currentDefferedItem.ParentBaseComponent.ParentAircraftId).Model) });//TODO:(Evgenii Babak) надо пересмореть т.к из Aircraft тут используется только Model
			comboBoxDefferedCategory.Items.Clear();
            comboBoxDefferedCategory.Items.AddRange(defferedCategories.ToArray());
            comboBoxDefferedCategory.SelectedItem = _currentDefferedItem.DeferredCategory;

            ADType = _currentDefferedItem.ADType == 0 ? ADType.Airframe : ADType.Apliance;
            Title = _currentDefferedItem.Title;
            EffectiveDate = _currentDefferedItem.Threshold.EffectiveDate;
            ServiceBulletin = _currentDefferedItem.ServiceBulletinNo;
            EngOrderNumber = _currentDefferedItem.EngineeringOrders;
            Applicability = _currentDefferedItem.Applicability;
            Subject = _currentDefferedItem.Description;
            LogBookReferences = _currentDefferedItem.DeferredLogBookRef;
            MelCdlItem = _currentDefferedItem.DeferredMelCdlItem;
            Extention = _currentDefferedItem.DeferredExtention;
            Remarks = _currentDefferedItem.Remarks;
            HiddenRemarks = _currentDefferedItem.HiddenRemarks;
            

            const bool permission = true; 

            ataChapterComboBox.Enabled = permission;
            textboxTitle.ReadOnly = !permission;
            dateTimePickerEffDate.Enabled = permission;
            textboxApplicability.ReadOnly = !permission;
            textboxSubject.ReadOnly = !permission;
            textboxRemarks.ReadOnly = !permission;
            textboxHiddenRemarks.ReadOnly = !permission;

            fileControlADNo.UpdateInfo(_currentDefferedItem.ADNoFile, 
                                       "Adobe PDF Files|*.pdf",
                                       "This record does not contain a file proving the AD No. Enclose PDF file to prove the compliance.",
                                       "Attached file proves the AD No.");
            fileControlSB.UpdateInfo(_currentDefferedItem.ServiceBulletinFile, 
                                     "Adobe PDF Files|*.pdf",
                                     "This record does not contain a file proving the Service bulletin. Enclose PDF file to prove the compliance.",
                                     "Attached file proves the Service bulletin.");
            fileControlEO.UpdateInfo(_currentDefferedItem.EngineeringOrderFile, 
                                     "Adobe PDF Files|*.pdf",
                                     "This record does not contain a file proving the Engineering order. Enclose PDF file to prove the compliance.",
                                     "Attached file proves the Engineering order.");


			var parentAircraft = GlobalObjects.AircraftsCore.GetParentAircraft(_currentDefferedItem);
	        var flight = GlobalObjects.AircraftFlightsCore.LoadFullAircraftFlightById(_currentDefferedItem.AircraftFlightId, parentAircraft.ItemId);//TODO:(Evgenii Babak)пересмотреть использования метода LoadFullAircraftFlightById т.к. из полета используется только ATLBId и FlightNo
			if (flight != null)
            {
                //Если отклонение было создано во время полета
                //то необходимо заблокировать дату открытия
                dateTimePickerEffDate.Enabled = false;
                lookupComboboxFlight.SetEditScreenControl<FlightScreen>
                        (parentAircraft.RegistrationNumber + ". " + flight.FlightNumber);
                var parentAtlb = GlobalObjects.CasEnvironment.NewLoader.GetObject<ATLBDTO, ATLB>(new Filter("ItemId", flight.ATLBId));
                //Проверить на значение свойтсва ParentAircraft в parentAtlb
                lookupComboboxFlight.SetItemsScreenControl<FlightsListScreen>
                    (new object[] { parentAtlb }, 
                    parentAircraft.RegistrationNumber + ". ATLB No " + parentAtlb.ATLBNo);
                lookupComboboxFlight.LoadObjectsFunc = GlobalObjects.AircraftFlightsCore.GetFlightsByAtlb;
	            lookupComboboxFlight.FilterParam1 = flight.AircraftId;
				lookupComboboxFlight.FilterParam2 = parentAtlb.ItemId;
                lookupComboboxFlight.UpdateInformation();
                lookupComboboxFlight.SelectedItemId = _currentDefferedItem.AircraftFlightId;
            }

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
                if (message != "") message += "\n ";
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
            if (_currentDefferedItem != null)
            {
                ApplyChanges(_currentDefferedItem, true);
            }
        }

        #endregion

        #region public void ApplyChanges(DefferedItem destinationPrimaryDirective, bool changePageName)
        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        /// <param name="destinationDefferedItem">Директива</param>
        /// <param name="changePageName">Менять ли название вкладки</param>
        public void ApplyChanges(DeferredItem destinationDefferedItem, bool changePageName)
        {
            textboxTitle.Focus();
            if (destinationDefferedItem == null)
                throw new ArgumentNullException("destinationDefferedItem");
            destinationDefferedItem.ATAChapter = ATAChapter;

            if (CurrentDefferedCategory != null && CurrentDefferedCategory !=  destinationDefferedItem.DeferredCategory)
                destinationDefferedItem.DeferredCategory = CurrentDefferedCategory;

            destinationDefferedItem.ADType = (ADType)(radioButtonAirFrame.Checked ? 0 : 1);
            if (destinationDefferedItem.Title != Title)
            {
                destinationDefferedItem.Title = Title;
                if (changePageName)
                {
                    string caption = "";

                    if (destinationDefferedItem.ParentBaseComponent != null)
                    {
						//TODO:(Evgenii Babak) Использовать DestinationHelper
						var baseComponent = destinationDefferedItem.ParentBaseComponent;
						if (baseComponent.BaseComponentTypeId == BaseComponentType.Frame.ItemId)
						{
							//у Frame всегда есть ParentAircraftId
							caption = $"{DestinationHelper.GetDestinationStringFromAircraft(baseComponent.ParentAircraftId, false, null)}. {destinationDefferedItem.DirectiveType.CommonName}. {destinationDefferedItem.Title}";
						}
						else
						{
							if (baseComponent.ParentAircraftId > 0)
								caption = $"{DestinationHelper.GetDestinationStringFromAircraft(baseComponent.ParentAircraftId, false, null)}. ";
							else if (baseComponent.ParentStoreId > 0)
								caption = $"{DestinationHelper.GetDestinationStringFromStore(baseComponent.ParentStoreId, null, true)}. ";

							caption += baseComponent + ". " + destinationDefferedItem.DirectiveType.CommonName + ". " + destinationDefferedItem.Title;
						}
					}
                    if (DisplayerRequested != null)
                        DisplayerRequested(this,
                                           new ReferenceEventArgs(null,
                                                                  ReflectionTypes.ChangeTextOfContainingDisplayer,
                                                                  caption));
                }
            }
            destinationDefferedItem.HiddenRemarks = HiddenRemarks;
            destinationDefferedItem.Threshold.EffectiveDate = EffectiveDate;
            destinationDefferedItem.ServiceBulletinNo = ServiceBulletin;
            destinationDefferedItem.EngineeringOrders = EngOrderNumber;
            destinationDefferedItem.Applicability = Applicability;
            destinationDefferedItem.Description = Subject;
            destinationDefferedItem.DeferredLogBookRef = LogBookReferences;
            destinationDefferedItem.DeferredMelCdlItem = MelCdlItem;
            destinationDefferedItem.DeferredExtention = Extention;
            destinationDefferedItem.Remarks = Remarks;

            if (fileControlSB.GetChangeStatus())
            {
                fileControlSB.ApplyChanges();
                fileControlSB.Save();
                destinationDefferedItem.ServiceBulletinFile = fileControlSB.AttachedFile;
            }

            if (fileControlEO.GetChangeStatus())
            {
                fileControlEO.ApplyChanges();
                fileControlEO.Save();
                destinationDefferedItem.EngineeringOrderFile = fileControlEO.AttachedFile;
            }

            if (fileControlADNo.GetChangeStatus())
            {
                fileControlADNo.ApplyChanges();
                fileControlADNo.Save();
                destinationDefferedItem.ADNoFile = fileControlADNo.AttachedFile;
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
            Subject = "";
            LogBookReferences = "";
            MelCdlItem = "";
            Extention = "";
            Remarks = "";
            HiddenRemarks = "";
            ServiceBulletin = "";

            fileControlEO.AttachedFile = null;
            fileControlADNo.AttachedFile = null;
            fileControlSB.AttachedFile = null;
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
        }

        #endregion

        #region private void DateTimePickerEffDateValueChanged(object sender, EventArgs e)
        private void DateTimePickerEffDateValueChanged(object sender, EventArgs e)
        {
            InvokeEffDateChanget(EffectiveDate);
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
