using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Events;
using CAS.UI.UIControls.JobCardControls;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Deprecated;
using SmartCore.Entities.General.MaintenanceWorkscope;
using TempUIExtentions;

namespace CAS.UI.UIControls.MaintananceProgram
{
    ///<summary>
    ///</summary>
    [Designer(typeof(MaintenanceDirectiveInformationControlDesigner))]
    public partial class MaintenanceDirectiveInformationControl : UserControl, IReference
    {
        #region Fields

        //private MaintenanceDirective _currentDirective;

        #endregion

        #region Constructors

        #region public MaintenanceDirectiveInformationControl()

        ///<summary>
        /// Создает объект для отображения информации о директиве
        ///</summary>
        public MaintenanceDirectiveInformationControl()
        {
            InitializeComponent();
            ataChapterComboBox.UpdateInformation();
        }

		#endregion

		#endregion

		#region Properties

		#region public void Updateparameters(MaintenanceDirective maintenanceDirective)

		public void Updateparameters(MaintenanceDirective maintenanceDirective)
		{
			ataChapterComboBox.UpdateInformation();
			UpdateInformation(maintenanceDirective);
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

        #region private string EngOrderNumber

        /// <summary>
        /// Engineering order no
        /// </summary>
        private string EngOrderNumber
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

        #region public string TaskNumberCheck
        ///<summary>
        ///Имя текущей директивы
        ///</summary>
        public string TaskNumberCheck
        {
            get
            {
                return textboxTaskNumberCheck.Text;
            }
            set
            {
                textboxTaskNumberCheck.Text = value;
            }
        }

        #endregion

        #region public string Paragraph

        /// <summary>
        /// Paragraph текущей директивы
        /// </summary>
        public string Paragraph { private get; set; }

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
                if(value < dateTimePickerEffDate.MinDate)
                    dateTimePickerEffDate.Value = dateTimePickerEffDate.MinDate;
                else if(value > dateTimePickerEffDate.MaxDate)
                    dateTimePickerEffDate.Value = dateTimePickerEffDate.MaxDate;
                else dateTimePickerEffDate.Value = value;
            }
        }

        #endregion

        #region public string References

        /// <summary>
        /// References текущей директивы
        /// </summary>
        public string References { private get; set; }

        #endregion

        #region public string TLPNo
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
            private get { return textboxDescription.Text; }
            set
            {
                textboxDescription.Text = value;
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

        #region public bool GetChangeStatus(MaintenanceDirective directive)
        ///<summary>
        ///Возвращает значение, показывающее были ли изменения в данном элементе управления
        ///</summary>
        ///<param name="directive">Директива для которой производится проверка</param>
        ///<returns></returns>
        public bool GetChangeStatus(MaintenanceDirective directive)
        {
            DateTime oldEffDate = directive.Threshold.EffectiveDate;
            if (directive.ItemId > 0)
                return (ATAChapter != directive.ATAChapter ||
                        HiddenRemarks != directive.HiddenRemarks ||
                        comboBoxCategory.SelectedItem != directive.Category ||
                        TaskNumberCheck != directive.TaskNumberCheck ||
                        textBoxMpdTaskNumber.Text != directive.MPDTaskNumber ||
                        textBoxMaintenanceManual.Text != directive.MaintenanceManual ||
                        textBoxZone.Text != directive.Zone ||
                        textBoxAccess.Text != directive.Access ||
                        textBoxMpdRef.Text != directive.MpdRef ||
						textBoxMpdRevNum.Text != directive.MpdRevisionNum ||
						checkBoxIsApplicability.Checked != directive.IsApplicability ||
						checkBoxOperatorTask.Checked != directive.IsOperatorTask ||
						textBoxScheuleRef.Text != directive.ScheduleRef ||
						textBoxScheuleRev.Text != directive.ScheduleRevisionNum ||
						comboBoxCriticalSystem.SelectedItem != directive.CriticalSystem ||
                        comboBoxProgram.SelectedItem != directive.Program ||
                        comboBoxProgramIndicator.SelectedItem != directive.ProgramIndicator ||
                        textBoxScheduleItem.Text != directive.ScheduleItem ||
			dateTimePickerEffDate.Value != oldEffDate ||
                        EngOrderNumber != directive.EngineeringOrders ||
                        textBoxTaskCardNumber.Text != directive.TaskCardNumber ||
                        textBoxMRB.Text != directive.MRB ||
                        EngOrderNumber != directive.EngineeringOrders ||
                        Subject != directive.Description ||
                        Remarks != directive.Remarks ||
                        Applicability != directive.Applicability ||
                        directive.JobCard == null && lookupComboboxJobCard.SelectedItemId > 0 ||
                        directive.JobCard != null && lookupComboboxJobCard.SelectedItemId != directive.JobCard.ItemId || 
                        fileControlEO.GetChangeStatus() ||
                        fileControlTaskNumberCheck.GetChangeStatus() ||
                        fileControlMaintenanceManual.GetChangeStatus() ||
                        fileControlTaskCardNumber.GetChangeStatus() ||
                        FileControlMRB.GetChangeStatus());
            return (ATAChapter != null ||
                    Paragraph != "" ||
                    TaskNumberCheck != "" ||
                    textBoxMpdTaskNumber.Text != "" ||
                    textBoxMaintenanceManual.Text != "" ||
                    textBoxMpdTaskNumber.Text != "" ||
                    textBoxTaskCardNumber.Text != "" ||
                    textBoxMpdRef.Text != "" ||
                    textBoxMpdRevNum.Text != "" ||
                    textBoxScheuleRef.Text != "" ||
                    textBoxScheuleRev.Text != "" ||
					textBoxZone.Text != "" ||
                    textBoxAccess.Text != "" ||
                    dateTimePickerEffDate.Value.Date != DateTime.Today ||
                    EngOrderNumber != "" ||
                    References != "" ||
                    Applicability != "" ||
                    BiWeeklyReport != "" ||
                    Subject != "" ||
                    Applicability != "" ||
                    Remarks != "" ||
                    comboBoxCriticalSystem.SelectedItem != null ||
                    comboBoxProgramIndicator.SelectedItem != null ||
                    comboBoxProgram.SelectedItem != null ||
                    fileControlTaskNumberCheck.GetChangeStatus() ||
                    fileControlEO.GetChangeStatus() ||
                    fileControlMaintenanceManual.GetChangeStatus() ||
                    FileControlMRB.GetChangeStatus() ||
                    fileControlTaskCardNumber.GetChangeStatus());
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
            if (TaskNumberCheck == "")
            {
                if (message != "") message += "\n ";
                message += "You should enter Title";
            }
	        if (comboBoxCategory.SelectedItem == null)
	        {
		        if (message != "") message += "\n ";
		        message += "Please select Category";
	        }
			string validateFiles;
            if (!fileControlTaskNumberCheck.ValidateData(out validateFiles))
            {
                if (message != "") message += "\n ";
                message += "MPD Task File: " + validateFiles; 
            }

            if (!fileControlEO.ValidateData(out validateFiles))
            {
                if (message != "") message += "\n ";
                message += "MPD EO File: " + validateFiles;
            }

            if (!fileControlMaintenanceManual.ValidateData(out validateFiles))
            {
                if (message != "") message += "\n ";
                message += "MPD Maintenance Manual File: " + validateFiles;
            }

            if (!fileControlTaskCardNumber.ValidateData(out validateFiles))
            {
                if (message != "") message += "\n ";
                message += "MPD Task Card Number File: " + validateFiles;
            }

            if (!FileControlMRB.ValidateData(out validateFiles))
            {
                if (message != "") message += "\n ";
                message += "MPD MRB File: " + validateFiles;
            }

            if (message != "")
                return false;
            return true;
        }

        #endregion

        #region private void UpdateInformation(MaintenanceDirective directive)

        /// <summary>
        /// Заполняет поля для редактирования директивы
        /// </summary>
        private void UpdateInformation(MaintenanceDirective directive)
        {
            if (directive == null) return;

	        var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(directive.ParentBaseComponent.ParentAircraftId);//TODO:(Evgenii Babak) пересмотреть использование ParentAircrafId здесь
			MSG aircraftMSG = parentAircraft != null
                                  ? parentAircraft.MSG
								  : MSG.MSG2;

            comboBoxCriticalSystem.Items.Clear();
            comboBoxCriticalSystem.Items.AddRange(CriticalSystemList.Items.ToArray());

            comboBoxProgram.Items.Clear();
            comboBoxProgram.Items.AddRange(MaintenanceDirectiveProgramType.Items.ToArray());

	        comboBoxProgramIndicator.Items.Clear();
	        comboBoxProgramIndicator.Items.AddRange(MaintenanceDirectiveProgramIndicator.Items.ToArray());


			dateTimePickerEffDate.ValueChanged -= DateTimePickerEffDateValueChanged;

            ATAChapter = directive.ATAChapter;
            TaskNumberCheck = directive.TaskNumberCheck;
            textBoxMpdTaskNumber.Text = directive.MPDTaskNumber;
            textBoxMaintenanceManual.Text = directive.MaintenanceManual;
            textBoxZone.Text = directive.Zone;
            textBoxAccess.Text = directive.Access;
            textBoxTaskCardNumber.Text = directive.TaskCardNumber;
            textBoxMRB.Text = directive.MRB;
            comboBoxProgram.SelectedItem = directive.Program;
	        comboBoxProgramIndicator.SelectedItem = directive.ProgramIndicator;
            comboBoxCriticalSystem.SelectedItem = directive.CriticalSystem;
            dateTimePickerEffDate.Value = directive.ItemId > 0 ? directive.Threshold.EffectiveDate : DateTime.Today;
            EngOrderNumber = directive.EngineeringOrders;
            Subject = directive.Description;
            Remarks = directive.Remarks;
            HiddenRemarks = directive.HiddenRemarks;
	        checkBoxIsApplicability.Checked = directive.IsApplicability;
			Applicability = directive.IsApplicability ? $"APL  {directive.Applicability}" : $"N/A  {directive.Applicability}"; 
	        textBoxMpdRef.Text = directive.MpdRef;
	        textBoxMpdRevNum.Text = directive.MpdRevisionNum;
	        textBoxScheuleRef.Text = directive.ScheduleRef;
	        textBoxScheuleRev.Text = directive.ScheduleRevisionNum;
	        textBoxScheduleItem.Text = directive.ScheduleItem;
			dateTimePickerRevDate.Value = directive.MpdRevisionDate;
	        dateTimePickerScheuleDate.Value = directive.ScheduleRevisionDate;
	        textBoxOldTaslCard.Text = directive.MpdOldTaskCard;
	        textBoxWorkArea.Text = directive.Workarea;
	        
			checkBoxOperatorTask.Checked = directive.IsOperatorTask;

			comboBoxCategory.Items.Clear();
			comboBoxCategory.Items.AddRange(MpdCategory.Items.ToArray());
	        comboBoxCategory.SelectedItem = directive.Category;

			#region Job Card

			lookupComboboxJobCard.SelectedIndexChanged -= LookupComboboxMaintenanceCheckSelectedIndexChanged;

            if (parentAircraft != null)
            {
                var maintenanceScreenDisplayerText =
                    $"{directive.ParentBaseComponent.GetParentAircraftRegNumber()} Job Cards";
				lookupComboboxJobCard.SetItemsScreenControl<CommonListScreen>(new[] { parentAircraft }, maintenanceScreenDisplayerText);
                lookupComboboxJobCard.SetEditScreenControl<JobCardScreen>(maintenanceScreenDisplayerText);
                lookupComboboxJobCard.SetAddScreenControl<JobCardScreen>(new object[] { directive }, directive + ". New Job Card");
                lookupComboboxJobCard.LoadObjectsFunc = GlobalObjects.CasEnvironment.NewLoader.GetJobCard;
                lookupComboboxJobCard.FilterParam1 = directive;
                lookupComboboxJobCard.SelectedItemId = directive.JobCard != null
                    ? directive.JobCard.ItemId
                    : -1;
                lookupComboboxJobCard.UpdateInformation();
            }

            lookupComboboxJobCard.SelectedIndexChanged += LookupComboboxMaintenanceCheckSelectedIndexChanged;

            #endregion

            fileControlTaskNumberCheck.UpdateInfo(directive.TaskNumberCheckFile, 
                                                  "Adobe PDF Files|*.pdf",
                                                  "This record does not contain a file proving the Task Number Check. Enclose PDF file to prove the compliance.",
                                                  "Attached file proves the Task Number Check.");
            fileControlEO.UpdateInfo(directive.EngineeringOrderFile, 
                                     "Adobe PDF Files|*.pdf",
                                     "This record does not contain a file proving the Engineering order. Enclose PDF file to prove the compliance.",
                                     "Attached file proves the Engineering order.");

            fileControlMaintenanceManual.UpdateInfo(directive.MaintenanceManualFile,
                                     "Adobe PDF Files|*.pdf",
                                     "This record does not contain a file proving the Maintenance Manual. Enclose PDF file to prove the compliance.",
                                     "Attached file proves the Maintenance Manual.");

            FileControlMRB.UpdateInfo(directive.MRBFile,
                                     "Adobe PDF Files|*.pdf",
                                     "This record does not contain a file proving the MRB file. Enclose PDF file to prove the compliance.",
                                     "Attached file proves the MRB file.");

            fileControlTaskCardNumber.UpdateInfo(directive.TaskCardNumberFile,
                                     "Adobe PDF Files|*.pdf",
                                     "This record does not contain a file proving the Task Card Number. Enclose PDF file to prove the compliance.",
                                     "Attached file proves the Task Card Number.");
            dateTimePickerEffDate.ValueChanged += DateTimePickerEffDateValueChanged;
        }

        #endregion

        #region public void ApplyChanges(MaintenanceDirective directive)

        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        public void ApplyChanges(MaintenanceDirective directive)
        {
            textboxTaskNumberCheck.Focus();
            directive.ATAChapter = ATAChapter;
            if (directive.TaskNumberCheck != TaskNumberCheck)
            {
                directive.TaskNumberCheck = TaskNumberCheck;

                string caption = "";
                if (directive.ParentBaseComponent != null)
                {
                    if (directive.ParentBaseComponent.BaseComponentType == BaseComponentType.Frame)
                    {
                        caption = directive.ParentBaseComponent.GetParentAircraftRegNumber();
					}
                    else
                    {
                        if (directive.ParentBaseComponent.ParentAircraftId > 0)
                            caption = directive.ParentBaseComponent.GetParentAircraftRegNumber() + ". " + 
									  directive.ParentBaseComponent;
                        else
                            caption = directive.ParentBaseComponent.ToString();
                    }
                    caption += ". MPD. " + directive.WorkType.CommonName + ". " + directive.TaskNumberCheck; 
                }
                if (DisplayerRequested != null)
                    DisplayerRequested(this,
                                       new ReferenceEventArgs(null,
                                                              ReflectionTypes.ChangeTextOfContainingDisplayer,
                                                              caption));
            }

	        directive.IsApplicability = checkBoxIsApplicability.Checked;
	        directive.IsOperatorTask = checkBoxOperatorTask.Checked;
            directive.HiddenRemarks = HiddenRemarks;
            directive.Threshold.EffectiveDate = EffectiveDate;
            directive.EngineeringOrders = EngOrderNumber;
            directive.MPDTaskNumber = textBoxMpdTaskNumber.Text;
            directive.MaintenanceManual = textBoxMaintenanceManual.Text;
            directive.Zone = textBoxZone.Text;
            directive.Access = textBoxAccess.Text;
            directive.TaskCardNumber = textBoxTaskCardNumber.Text;
            directive.MRB = textBoxMRB.Text;
            directive.Applicability = Applicability;

	        if (checkBoxIsApplicability.Checked)
		        directive.Applicability = directive.Applicability.Replace("APL", "").TrimStart();
	        else directive.Applicability = directive.Applicability.Replace("N/A", "").TrimStart();

			directive.Description = Subject;
            directive.Remarks = Remarks;
            directive.CriticalSystem = comboBoxCriticalSystem.SelectedItem as CriticalSystemList;
            directive.Program = comboBoxProgram.SelectedItem as MaintenanceDirectiveProgramType;
            directive.ProgramIndicator = comboBoxProgramIndicator.SelectedItem as MaintenanceDirectiveProgramIndicator;

            directive.JobCard = lookupComboboxJobCard.SelectedItem as JobCard;


			directive.MpdRef = textBoxMpdRef.Text;
			directive.MpdRevisionNum = textBoxMpdRevNum.Text;
	        directive.ScheduleRef = textBoxScheuleRef.Text;
	        directive.ScheduleRevisionNum = textBoxScheuleRev.Text;
	        directive.ScheduleItem = textBoxScheduleItem.Text;
			directive.MpdRevisionDate = dateTimePickerRevDate.Value;
			directive.ScheduleRevisionDate = dateTimePickerScheuleDate.Value;
			directive.MpdOldTaskCard = textBoxOldTaslCard.Text;
			directive.Workarea = textBoxWorkArea.Text;
	        directive.Category = comboBoxCategory.SelectedItem as MpdCategory;


			if (fileControlTaskNumberCheck.GetChangeStatus())
            {
                fileControlTaskNumberCheck.ApplyChanges();
                directive.TaskNumberCheckFile = fileControlTaskNumberCheck.AttachedFile;    
            }

            if(fileControlEO.GetChangeStatus())
            {
                fileControlEO.ApplyChanges();
                directive.EngineeringOrderFile = fileControlEO.AttachedFile;    
            }

            if (fileControlTaskCardNumber.GetChangeStatus())
            {
                fileControlTaskCardNumber.ApplyChanges();
                directive.TaskCardNumberFile = fileControlTaskCardNumber.AttachedFile;
            }

            if (fileControlMaintenanceManual.GetChangeStatus())
            {
                fileControlMaintenanceManual.ApplyChanges();
                directive.MaintenanceManualFile = fileControlMaintenanceManual.AttachedFile;
            }

            if (FileControlMRB.GetChangeStatus())
            {
                FileControlMRB.ApplyChanges();
                directive.MRBFile = FileControlMRB.AttachedFile;
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
            TaskNumberCheck = "";
            dateTimePickerEffDate.Value = DateTime.Today;
            EngOrderNumber = "";
            Applicability = "";
            Subject = "";
            Remarks = "";
            HiddenRemarks = "";
            textBoxMpdTaskNumber.Text = "";
            textBoxMaintenanceManual.Text = "";
            textBoxZone.Text = "";
            textBoxAccess.Text = "";
            textBoxMRB.Text = "";
            textBoxTaskCardNumber.Text = "";
            comboBoxCriticalSystem.SelectedItem = null;
            comboBoxProgram.SelectedItem = null;
	        comboBoxProgramIndicator.SelectedItem = null;

	        textBoxMpdRef.Text = "";
	        textBoxMpdRevNum.Text = "";
	        textBoxOldTaslCard.Text = "";
	        textBoxWorkArea.Text = "";
	        comboBoxCategory.SelectedItem = null;

			fileControlEO.AttachedFile = null;
            fileControlMaintenanceManual.AttachedFile = null;
            fileControlTaskCardNumber.AttachedFile = null;
            fileControlTaskNumberCheck.AttachedFile = null;
            FileControlMRB.AttachedFile = null;
        }

        #endregion

        #region private void DateTimePickerEffDateValueChanged(object sender, EventArgs e)
        private void DateTimePickerEffDateValueChanged(object sender, EventArgs e)
        {
            InvokeEffDateChanget(EffectiveDate);
        }
        #endregion

        #region private void LookupComboboxMaintenanceCheckSelectedIndexChanged(object sender, EventArgs e)
        private void LookupComboboxMaintenanceCheckSelectedIndexChanged(object sender, EventArgs e)
        {
            //if (lookupComboboxMaintenanceCheck.SelectedItem != null)
            //{
            //    MaintenanceCheck mc = (MaintenanceCheck)lookupComboboxMaintenanceCheck.SelectedItem;

            //    lifelengthViewer_SinceNew.Lifelength = mc.Interval;
            //    lifelengthViewer_SinceEffDate.Lifelength = Lifelength.Null;
            //    lifelengthViewer_FirstNotify.Lifelength = mc.Notify;
            //    lifelengthViewer_Repeat.Lifelength = mc.Interval;
            //    lifelengthViewer_RepeatNotify.Lifelength = mc.Notify;
            //    radio_FirstWhicheverFirst.Checked = true;
            //    radio_RepeatWhicheverFirst.Checked = true;

            //    lifelengthViewer_SinceNew.Enabled = false;
            //    lifelengthViewer_SinceEffDate.Enabled = false;
            //    lifelengthViewer_FirstNotify.Enabled = false;
            //    lifelengthViewer_Repeat.Enabled = false;
            //    lifelengthViewer_RepeatNotify.Enabled = false;
            //    radio_FirstWhicheverFirst.Enabled = false;
            //    radio_RepeatWhicheverFirst.Enabled = false;
            //}
            //else
            //{
            //    lifelengthViewer_SinceNew.Enabled = true;
            //    lifelengthViewer_SinceEffDate.Enabled = true;
            //    lifelengthViewer_FirstNotify.Enabled = true;
            //    lifelengthViewer_Repeat.Enabled = true;
            //    lifelengthViewer_RepeatNotify.Enabled = true;
            //    radio_FirstWhicheverFirst.Enabled = true;
            //    radio_RepeatWhicheverFirst.Enabled = true;
            //}
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

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			fileControlEO.Enabled = lookupComboboxJobCard.Enabled = checkBoxOperatorTask.Checked;
		}

		private void checkBoxIsApplicability_CheckedChanged(object sender, EventArgs e)
		{
			textboxApplicability.Text = checkBoxIsApplicability.Checked ? "APL" : "N/A";
		}
	}

	#region internal class MaintenanceDirectiveInformationControlDesigner : ControlDesigner

	internal class MaintenanceDirectiveInformationControlDesigner : ControlDesigner
    {
        protected override void PostFilterProperties(IDictionary properties)
        {
            base.PostFilterProperties(properties);
            properties.Remove("CurrentDirective");
            properties.Remove("CurrentBaseDetail");
            properties.Remove("EffectiveDate");
        }
    }
    #endregion
}
