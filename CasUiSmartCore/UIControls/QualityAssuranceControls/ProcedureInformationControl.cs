using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Events;
using CAS.UI.UIControls.JobCardControls;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Deprecated;
using SmartCore.Entities.General.Quality;

namespace CAS.UI.UIControls.QualityAssuranceControls
{
    ///<summary>
    ///</summary>
    [Designer(typeof(ProcedureInformationControlDesigner))]
    public partial class ProcedureInformationControl : UserControl, IReference
    {
        #region Fields

        private Procedure _currentDirective;

        #endregion

        #region Constructors

        #region public ProcedureInformationControl()

        ///<summary>
        /// Создает объект для отображения информации о директиве
        ///</summary>
        public ProcedureInformationControl()
        {
            InitializeComponent();
        }

        #endregion

        #endregion

        #region Properties

        #region public Procedure CurrentDirective
        ///<summary>
        ///Текущая директива
        ///</summary>
        public Procedure CurrentDirective
        {
            set
            {
                _currentDirective = value;
                if (_currentDirective != null)
                {
                   UpdateInformation();
                }
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
                if (_currentDirective == null || _currentDirective.ItemId <= 0)
                    dateTimePickerEffDate.Value = DateTime.Today;
                else if(value < dateTimePickerEffDate.MinDate)
                    dateTimePickerEffDate.Value = dateTimePickerEffDate.MinDate;
                else if(value > dateTimePickerEffDate.MaxDate)
                    dateTimePickerEffDate.Value = dateTimePickerEffDate.MaxDate;
                else dateTimePickerEffDate.Value = value;
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
            if (lookupComboboxCheckList != null)
                lookupComboboxCheckList.CancelAsync();
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
                return (textboxHiddenRemarks.Text != _currentDirective.HiddenRemarks ||
                        textboxTitle.Text != _currentDirective.Title ||
                        textBoxDepartment.Text != _currentDirective.AuditedObject ||
                        textboxDescription.Text != _currentDirective.Description ||
                        textboxApplicability.Text != _currentDirective.Applicability ||
                        EffectiveDate != oldEffDate ||
                        textboxRemarks.Text != _currentDirective.Remarks ||
                        _currentDirective.JobCard == null && lookupComboboxCheckList.SelectedItemId > 0 ||
                        _currentDirective.JobCard != null && lookupComboboxCheckList.SelectedItemId != _currentDirective.JobCard.ItemId ||
                        fileControlCheckList.GetChangeStatus() ||
                        fileControlProcedure.GetChangeStatus() ||
                        procedureDocRefListControl.GetChangeStatus() ||
                        numericUpDownLevel.Value != _currentDirective.Level ||
                        comboBoxRating.SelectedItem != _currentDirective.ProcedureRating);
            return (textboxHiddenRemarks.Text != "" ||
                        textboxTitle.Text != "" ||
                        textBoxDepartment.Text != "" ||
                        textboxDescription.Text != "" ||
                        textboxApplicability.Text != "" ||
                        EffectiveDate != DateTime.Today||
                        textboxRemarks.Text != "" ||
                        fileControlCheckList.GetChangeStatus() ||
                        fileControlProcedure.GetChangeStatus() ||
                        procedureDocRefListControl.GetChangeStatus());
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
            //if (ATAChapter == null || ATAChapter.ItemId <= 0)
            //{
            //    if (message != "") message += "\n ";
            //    message += "Please select ATA chapter";
            //}
            if (textboxTitle.Text == "")
            {
                if (message != "") message += "\n ";
                message += "You should enter Title";
            }

            string validateFiles;

            if (!procedureDocRefListControl.CheckData())
            {
                return false;
            }

            if (!fileControlProcedure.ValidateData(out validateFiles))
            {
                if (message != "") message += "\n ";
                message += "MPD Task File: " + validateFiles; 
            }

            if (!fileControlCheckList.ValidateData(out validateFiles))
            {
                if (message != "") message += "\n ";
                message += "MPD EO File: " + validateFiles;
            }

            if (message != "")
                return false;
            return true;
        }

        #endregion

        #region private void UpdateInformation()

        /// <summary>
        /// Заполняет поля для редактирования директивы
        /// </summary>
        private void UpdateInformation()
        {
            if (_currentDirective == null) return;
                
            dateTimePickerEffDate.ValueChanged -= DateTimePickerEffDateValueChanged;

            textboxHiddenRemarks.Text = _currentDirective.HiddenRemarks;
            textboxTitle.Text = _currentDirective.Title;
            textBoxDepartment.Text = _currentDirective.AuditedObject;
            textboxDescription.Text = _currentDirective.Description;
            textboxApplicability.Text = _currentDirective.Applicability;
            EffectiveDate = _currentDirective.Threshold.EffectiveDate;
            textboxRemarks.Text = _currentDirective.Remarks;
            numericUpDownLevel.Value = _currentDirective.Level;

            procedureDocRefListControl.Procedure = _currentDirective;

            comboBoxRating.Items.Clear();
            CommonDictionaryCollection<ProcedureRating> directiveTypes =
                ProcedureRating.Items;
            foreach (ProcedureRating t in directiveTypes)
            {
                comboBoxRating.Items.Add(t);
                if (_currentDirective.ProcedureRating == t)
                    comboBoxRating.SelectedItem = t;
            }
            if (comboBoxRating.SelectedItem == null)
                comboBoxRating.SelectedIndex = 0;

            #region Job Card

            lookupComboboxCheckList.SelectedIndexChanged -= LookupComboboxMaintenanceCheckSelectedIndexChanged;

            if (_currentDirective.ParentOperator != null)
            {
                string maintenanceScreenDisplayerText =
                    _currentDirective.ParentOperator.Name + " Job Cards";
                lookupComboboxCheckList.SetItemsScreenControl<CommonListScreen>(new[] { _currentDirective.ParentOperator }, maintenanceScreenDisplayerText);
                lookupComboboxCheckList.SetEditScreenControl<JobCardScreen>(maintenanceScreenDisplayerText);
                lookupComboboxCheckList.SetAddScreenControl<JobCardScreen>(new object[] { _currentDirective }, _currentDirective + ". New Job Card");
                lookupComboboxCheckList.LoadObjectsFunc = GlobalObjects.CasEnvironment.NewLoader.GetJobCard;
                lookupComboboxCheckList.FilterParam1 = _currentDirective;
                lookupComboboxCheckList.SelectedItemId = _currentDirective.JobCard != null
                    ? _currentDirective.JobCard.ItemId
                    : -1;
                lookupComboboxCheckList.UpdateInformation();
            }

            lookupComboboxCheckList.SelectedIndexChanged += LookupComboboxMaintenanceCheckSelectedIndexChanged;

            #endregion

            fileControlProcedure.UpdateInfo(_currentDirective.ProcedureFile,
                                                  "Adobe PDF Files|*.pdf",
                                                  "This record does not contain a file proving the Procedure File. Enclose PDF file to prove the compliance.",
                                                  "Attached file proves the Procedure File.");
            fileControlCheckList.UpdateInfo(_currentDirective.CheckListFile,
                                     "Adobe PDF Files|*.pdf",
                                     "This record does not contain a file proving the Check List. Enclose PDF file to prove the compliance.",
                                     "Attached file proves the Check List.");

            dateTimePickerEffDate.ValueChanged += DateTimePickerEffDateValueChanged;
        }

        #endregion

        #region public void ApplyChanges(Procedure destinationItem)

        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        public void ApplyChanges(Procedure destinationItem)
        {
            textboxTitle.Focus();

            if (destinationItem.Title != textboxTitle.Text)
            {
                destinationItem.Title = textboxTitle.Text;

                string caption = textboxTitle.Text;
                if (DisplayerRequested != null)
                    DisplayerRequested(this,
                                       new ReferenceEventArgs(null,
                                                              ReflectionTypes.ChangeTextOfContainingDisplayer,
                                                              caption));
            }

            destinationItem.HiddenRemarks = textboxHiddenRemarks.Text;
            destinationItem.Threshold.EffectiveDate = EffectiveDate;
            destinationItem.AuditedObject = textBoxDepartment.Text;
            destinationItem.Title = textboxTitle.Text;
            destinationItem.Applicability = textboxApplicability.Text;
            destinationItem.Description = textboxDescription.Text;
            destinationItem.Remarks = textboxRemarks.Text;
            destinationItem.JobCard = lookupComboboxCheckList.SelectedItem as JobCard;
            destinationItem.Level = (int)numericUpDownLevel.Value;
            destinationItem.ProcedureRating = (comboBoxRating.SelectedItem as ProcedureRating) ?? ProcedureRating.Unknown;

            procedureDocRefListControl.ApplyChanges();

            if (fileControlProcedure.GetChangeStatus())
            {
                fileControlProcedure.ApplyChanges();
                _currentDirective.ProcedureFile = fileControlProcedure.AttachedFile;
            }

            if (fileControlCheckList.GetChangeStatus())
            {
                fileControlCheckList.ApplyChanges();
                destinationItem.CheckListFile = fileControlCheckList.AttachedFile;
            }

        }
        #endregion

        #region public void ClearFields()

        /// <summary>
        /// Очищает все поля
        /// </summary>
        public void ClearFields()
        {
            textboxHiddenRemarks.Text = "";
            EffectiveDate = DateTime.Today;
            textBoxDepartment.Text = "";
            textboxTitle.Text = "";
            textboxApplicability.Text = "";
            textboxDescription.Text = "";
            textboxRemarks.Text = "";
            lookupComboboxCheckList.SelectedItem = null;

            procedureDocRefListControl.Procedure = null;

            fileControlProcedure.AttachedFile = null;
            fileControlCheckList.AttachedFile = null;
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
    }

    #region internal class ProcedureInformationControlDesigner : ControlDesigner

    internal class ProcedureInformationControlDesigner : ControlDesigner
    {
        protected override void PostFilterProperties(IDictionary properties)
        {
            base.PostFilterProperties(properties);
            properties.Remove("CurrentDirective");
            properties.Remove("EffectiveDate");
        }
    }
    #endregion
}
