using System;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary.Events;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Directives;

namespace CAS.UI.UIControls.DirectivesControls
{
    ///<summary>
    ///</summary>
    public partial class OutOfPhaseReferenceGeneralInformationControl : UserControl, IReference
    {
        #region Fields
        private Directive _currentOutOfPhaseItem;
        #endregion

        #region Constructors

        #region public OutOfPhaseReferenceGeneralInformationControl()

        ///<summary>
        /// Создает объект для отображения информации о директиве
        ///</summary>
        public OutOfPhaseReferenceGeneralInformationControl()
        {
            InitializeComponent();
            ataChapterComboBox.UpdateInformation();
        }
        #endregion

        #region public OutOfPhaseReferenceGeneralInformationControl(Aircraft currentAircraft)

        ///<summary>
        /// Создает объект для отображения информации о директиве
        ///</summary>
        public OutOfPhaseReferenceGeneralInformationControl(Aircraft currentAircraft)
        {
            InitializeComponent();
            ataChapterComboBox.UpdateInformation();
        }
        #endregion

        #endregion

        #region Properties

        #region public Directive CurrentOutOfPhaseItem
        ///<summary>
        ///Текущая директива
        ///</summary>
        public Directive CurrentOutOfPhaseItem
        {
            get
            {
                return _currentOutOfPhaseItem;
            }
            set
            {
                _currentOutOfPhaseItem = value;
                if (_currentOutOfPhaseItem != null)
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
            get { return radioButtonAirFrame.Checked ? ADType.Airframe : ADType.Apliance; }
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
       
        #region public bool GetChangeStatus(bool directiveExist)
        ///<summary>
        ///Возвращает значение, показывающее были ли изменения в данном элементе управления
        ///</summary>
        ///<param name="directiveExist">Показывает, существует ли уже директива или нет</param>
        ///<returns></returns>
        public bool GetChangeStatus(bool directiveExist)
        {
            DateTime oldEffDate = _currentOutOfPhaseItem.Threshold.EffectiveDate;
            if (directiveExist)
                return (((ATAChapter != _currentOutOfPhaseItem.ATAChapter) ||
                    (EffectiveDate != oldEffDate) ||
                    ((HiddenRemarks != _currentOutOfPhaseItem.HiddenRemarks ||
                     (Title != _currentOutOfPhaseItem.Title) ||
                     (ServiceBulletin != _currentOutOfPhaseItem.ServiceBulletinNo) ||
                     (EngOrderNumber != _currentOutOfPhaseItem.EngineeringOrders) ||
                     (Subject != _currentOutOfPhaseItem.Description) ||
                     (fileControlEO.GetChangeStatus()) ||
                     (fileControlSB.GetChangeStatus()) ||
                     (fileControlADNo.GetChangeStatus()) ||
                     (Remarks != _currentOutOfPhaseItem.Remarks)))));
            return ((ATAChapter != null) ||
                    (Paragraph != "") ||
                    (ADType != ADType.Airframe) ||
                    (Title != "") ||
                    (EffectiveDate != DateTime.Today) ||
                    (ServiceBulletin != "") ||
                    (EngOrderNumber != "") ||
                    (References != "") ||
                    (Applicability != "") ||
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
            if (_currentOutOfPhaseItem == null)
                return;

            dateTimePickerEffDate.ValueChanged -= DateTimePickerEffDateValueChanged;

            ATAChapter = _currentOutOfPhaseItem.ATAChapter;
            Title = _currentOutOfPhaseItem.Title;
            EffectiveDate = _currentOutOfPhaseItem.Threshold.EffectiveDate;
            ServiceBulletin = _currentOutOfPhaseItem.ServiceBulletinNo;
            EngOrderNumber = _currentOutOfPhaseItem.EngineeringOrders;
            Applicability = "";// sourceOutOfPhaseItem.Applicability;
            Subject = _currentOutOfPhaseItem.Description;
            Remarks = _currentOutOfPhaseItem.Remarks;
            HiddenRemarks = _currentOutOfPhaseItem.HiddenRemarks;

            fileControlADNo.UpdateInfo(_currentOutOfPhaseItem.ADNoFile, 
                                             "Adobe PDF Files|*.pdf",
                                             "This record does not contain a file proving the AD No. Enclose PDF file to prove the compliance.",
                                             "Attached file proves the AD No.");
            fileControlSB.UpdateInfo(_currentOutOfPhaseItem.ServiceBulletinFile, 
                                           "Adobe PDF Files|*.pdf",
                                           "This record does not contain a file proving the Service bulletin. Enclose PDF file to prove the compliance.",
                                           "Attached file proves the Service bulletin.");
            fileControlEO.UpdateInfo(_currentOutOfPhaseItem.EngineeringOrderFile, 
                                           "Adobe PDF Files|*.pdf",
                                           "This record does not contain a file proving the Engineering order. Enclose PDF file to prove the compliance.",
                                           "Attached file proves the Engineering order.");
            bool permission = true; 

            ataChapterComboBox.Enabled = permission;
            textboxTitle.ReadOnly = !permission;
            dateTimePickerEffDate.Enabled = permission;
            textboxApplicability.ReadOnly = !permission;
            textboxSubject.ReadOnly = !permission;
            textboxRemarks.ReadOnly = !permission;
            textboxHiddenRemarks.ReadOnly = !permission;

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
            if (_currentOutOfPhaseItem != null)
            {
                ApplyChanges(_currentOutOfPhaseItem, true);
            }
        }

        #endregion

        #region  public void SaveData(Directive destinationOutOfPhaseItem, bool changePageName)
        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        /// <param name="destinationOutOfPhaseItem">Директива</param>
        /// <param name="changePageName">Менять ли название вкладки</param>
        public void ApplyChanges(Directive destinationOutOfPhaseItem, bool changePageName)
        {
            textboxTitle.Focus();
            if (destinationOutOfPhaseItem == null)
                throw new ArgumentNullException("destinationOutOfPhaseItem");
            destinationOutOfPhaseItem.ATAChapter = ATAChapter;
            if (destinationOutOfPhaseItem.Title != Title)
            {
                destinationOutOfPhaseItem.Title = Title;
                if (changePageName)
                {
                    var caption = "";
					if (destinationOutOfPhaseItem.ParentBaseComponent != null)
                    {
                        var baseComponent = destinationOutOfPhaseItem.ParentBaseComponent;

						if (baseComponent.BaseComponentTypeId == BaseComponentType.Frame.ItemId)
						{
							//у Frame всегда есть ParentAircraftId
							caption = $"{DestinationHelper.GetDestinationStringFromAircraft(baseComponent.ParentAircraftId, false, null)}. {destinationOutOfPhaseItem.DirectiveType.CommonName}. {destinationOutOfPhaseItem.Title}";
						}
						else
						{
							if (baseComponent.ParentAircraftId > 0)
								caption = $"{DestinationHelper.GetDestinationStringFromAircraft(baseComponent.ParentAircraftId, false, null)}. ";
							else if (baseComponent.ParentStoreId > 0)
								caption = $"{DestinationHelper.GetDestinationStringFromStore(baseComponent.ParentStoreId, null, true)}. ";

							caption += baseComponent + ". " + destinationOutOfPhaseItem.DirectiveType.CommonName + ". " + destinationOutOfPhaseItem.Title;
						}
					}
                    if (DisplayerRequested != null)
                        DisplayerRequested(this,
                                           new ReferenceEventArgs(null,
                                                                  ReflectionTypes.ChangeTextOfContainingDisplayer,
                                                                  caption));
                }
            }
            destinationOutOfPhaseItem.HiddenRemarks = HiddenRemarks;
            destinationOutOfPhaseItem.Threshold.EffectiveDate = EffectiveDate;
            destinationOutOfPhaseItem.ServiceBulletinNo = ServiceBulletin;
            destinationOutOfPhaseItem.EngineeringOrders = EngOrderNumber;
            //if (destinationOutOfPhaseItem.Applicability != Applicability)
            destinationOutOfPhaseItem.Applicability = Applicability;
            destinationOutOfPhaseItem.Description = Subject;
            destinationOutOfPhaseItem.Remarks = Remarks;

            if (fileControlSB.GetChangeStatus())
            {
                fileControlSB.ApplyChanges();
                fileControlSB.Save();
                destinationOutOfPhaseItem.ServiceBulletinFile = fileControlSB.AttachedFile;
            }

            if (fileControlEO.GetChangeStatus())
            {
                fileControlEO.ApplyChanges();
                fileControlEO.Save();
                destinationOutOfPhaseItem.EngineeringOrderFile = fileControlEO.AttachedFile;
            }

            if (fileControlADNo.GetChangeStatus())
            {
                fileControlADNo.ApplyChanges();
                fileControlADNo.Save();
                destinationOutOfPhaseItem.ADNoFile = fileControlADNo.AttachedFile;
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
            //Paragraph = "";
            dateTimePickerEffDate.Value = DateTime.Today;
            Applicability = "";
            Subject = "";
            Remarks = "";
            HiddenRemarks = "";
            fileControlSB.AttachedFile = null;
            fileControlADNo.AttachedFile = null;
            fileControlEO.AttachedFile = null;
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
