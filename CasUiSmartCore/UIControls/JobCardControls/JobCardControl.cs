using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary.Events;
using CAS.UI.UIControls.KitControls;
using CASTerms;
using EFCore.DTO.General;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Deprecated;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UIControls.JobCardControls
{
    ///<summary>
    ///</summary>
    [Designer(typeof(JobCardControlDesigner))]
    public partial class JobCardControl : UserControl, IReference
    {
        private readonly CommonCollection<Specialist> _specialists = new CommonCollection<Specialist>();
        private readonly CommonDictionaryCollection<AircraftWorkerCategory> _qualifications = 
            new CommonDictionaryCollection<AircraftWorkerCategory>();

        #region Fields

        private JobCard _currentDirective;

        #endregion

        #region Constructors

        #region public JobCardControl()

        ///<summary>
        /// Создает объект для отображения информации о директиве
        ///</summary>
        public JobCardControl()
        {
            InitializeComponent();
        }

        #endregion

        #endregion

        #region Properties

        #region public JobCard CurrentDirective
        ///<summary>
        ///Текущая директива
        ///</summary>
        public JobCard CurrentDirective
        {
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
            private set
            {
                ataChapterComboBox.ATAChapter = value;
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
            if (directiveExist)
                return (ATAChapter != _currentDirective.AtaChapter ||
                        comboBoxApprovedBy.SelectedItem != _currentDirective.ApprovedBy ||
                        comboBoxChechedBy.SelectedItem != _currentDirective.CheckedBy ||
                        comboBoxPreparedBy.SelectedItem != _currentDirective.PreparedBy ||
                        comboBoxQualification.SelectedItem != _currentDirective.Qualification ||
                        comboBoxMMRef.SelectedItem != _currentDirective.MaintenanceManual ||
                        comboBoxWorkType.SelectedItem != _currentDirective.WorkType ||
                        dateTimePickerApprovedDate.Value != _currentDirective.ApprovedByDate ||
                        dateTimePickerCheckedDate.Value != _currentDirective.CheckedByDate ||
                        dateTimePickerFormRevDate.Value != _currentDirective.FormDate ||
                        dateTimePickerJCRevDate.Value != _currentDirective.JobCardRevisionDate ||
                        dateTimePickerMMRevisionDate.Value != _currentDirective.MaintenanceManualRevisionDate ||
                        dateTimePickerPreparedDate.Value != _currentDirective.PreparedByDate || 
                        jobCardTaskListControl.GetChangeStatus() ||
                        numericUpDownMan.Value != _currentDirective.Man ||
                        numericUpDownManHours.Value != (decimal)_currentDirective.ManHours ||
                        textBoxAccess.Text != _currentDirective.Access ||
                        textBoxApplicability.Text != _currentDirective.Applicability ||
                        textBoxAttachedTo.Text != "" ||
                        textBoxForm.Text != _currentDirective.Form ||
                        textboxFormRev.Text != _currentDirective.FormRevision ||
                        textboxFooter.Text != _currentDirective.JobCardFooter ||
                        textBoxJCRevNumber.Text != _currentDirective.JobCardNumber ||
                        textboxJobCardHeader.Text != _currentDirective.JobCardHeader ||
                        textBoxMMRevisionNumber.Text != _currentDirective.MaintenanceManualRevision ||
                        textBoxMRO.Text != _currentDirective.MRO ||
                        textBoxPhase.Text != _currentDirective.Phase ||
                        textboxTitle.Text != _currentDirective.Title ||
                        textBoxStation.Text != _currentDirective.Station ||
                        textBoxWorkArea.Text != _currentDirective.WorkArea ||
                        textBoxZone.Text != _currentDirective.Zone);
            return (ATAChapter != null &&
                    jobCardTaskListControl.GetChangeStatus() &&
                    textboxJobCardHeader.Text != "" &&
                    textboxTitle.Text != "");
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

            if (textboxJobCardHeader.Text == "")
            {
                if (message != "") message += "\n ";
                message += "You should enter Job Card Header";
            }

            if (textboxTitle.Text == "")
            {
                if (message != "") message += "\n ";
                message += "You should enter Job Card Title";
            }

            if (!jobCardTaskListControl.CheckData())
            {
                if (message != "") message += "\n ";
                message += "Check Job Card Tasks: ";
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
            ataChapterComboBox.UpdateInformation();

            _specialists.Clear();
            _specialists.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<SpecialistDTO, Specialist>());
            _qualifications.Clear();
            var aircraftWorkerCategoties = GlobalObjects.CasEnvironment.GetDictionary<AircraftWorkerCategory>();
            if (aircraftWorkerCategoties != null)
                _qualifications.AddRange(aircraftWorkerCategoties.OfType<AircraftWorkerCategory>());

            comboBoxPreparedBy.Items.Clear();
            comboBoxPreparedBy.Items.AddRange(_specialists.GetValidEntries());
            comboBoxChechedBy.Items.Clear();
            comboBoxChechedBy.Items.AddRange(_specialists.GetValidEntries());
            comboBoxApprovedBy.Items.Clear();
            comboBoxApprovedBy.Items.AddRange(_specialists.GetValidEntries());
            comboBoxQualification.Items.Clear();
            comboBoxQualification.Items.AddRange(_qualifications.ToArray());
            comboBoxMMRef.Items.Clear();
            comboBoxMMRef.Items.AddRange(RefDocType.Items.ToArray());
            comboBoxWorkType.Items.Clear();
            comboBoxWorkType.Items.AddRange(MaintenanceDirectiveTaskType.Items.ToArray());

            commonListViewControlEqipmentAndMaterials.ViewedType = typeof (AccessoryRequired);

            if (_currentDirective == null) return;

            ATAChapter = _currentDirective.AtaChapter;
            textboxFormRev.Text = _currentDirective.FormRevision;
            textboxJobCardHeader.Text = _currentDirective.JobCardHeader;
            dateTimePickerFormRevDate.Value = _currentDirective.FormDate;
            textboxTitle.Text = _currentDirective.Title;
            textBoxStation.Text = _currentDirective.Station;
            textBoxMRO.Text = _currentDirective.MRO;
            textBoxJCRevNumber.Text = _currentDirective.JobCardRevision;
            textboxFooter.Text = _currentDirective.JobCardFooter;
            textBoxAccess.Text = _currentDirective.Access;
            textBoxZone.Text = _currentDirective.Zone;
            textBoxForm.Text = _currentDirective.Form;
            dateTimePickerJCRevDate.Value = _currentDirective.JobCardRevisionDate;
            textBoxApplicability.Text = _currentDirective.Applicability;
            textBoxPhase.Text = _currentDirective.Phase;
            textBoxWorkArea.Text = _currentDirective.WorkArea;
            textBoxMMRevisionNumber.Text = _currentDirective.MaintenanceManualRevision;
            dateTimePickerMMRevisionDate.Value = _currentDirective.MaintenanceManualRevisionDate;
            numericUpDownManHours.Value = (decimal)_currentDirective.ManHours;
            numericUpDownMan.Value = _currentDirective.Man;
            textBoxAttachedTo.Text = "";
            dateTimePickerCheckedDate.Value = _currentDirective.CheckedByDate;
            dateTimePickerApprovedDate.Value = _currentDirective.ApprovedByDate;
            dateTimePickerPreparedDate.Value = _currentDirective.PreparedByDate;

            commonListViewControlEqipmentAndMaterials.SetItemsArray(_currentDirective.Kits.ToArray());
            
            jobCardTaskListControl.JobCard = _currentDirective;

            if (_currentDirective.PreparedBy != null)
            {
                Specialist selectedSpec = _specialists.GetItemById(_currentDirective.PreparedBy.ItemId);
                if(selectedSpec != null)
                    comboBoxPreparedBy.SelectedItem = selectedSpec;
                else
                {
                    //Искомый специалист недействителен
                    comboBoxPreparedBy.Items.Add(_currentDirective.PreparedBy);
                    comboBoxPreparedBy.SelectedItem = _currentDirective.PreparedBy;
                }   
            }

            if (_currentDirective.CheckedBy != null)
            {
                Specialist selectedSpec = _specialists.GetItemById(_currentDirective.CheckedBy.ItemId);
                if(selectedSpec != null)
                    comboBoxChechedBy.SelectedItem = selectedSpec;
                else
                {
                    //Искомый специалист недействителен
                    comboBoxChechedBy.Items.Add(_currentDirective.CheckedBy);
                    comboBoxChechedBy.SelectedItem = _currentDirective.CheckedBy;
                }   
            }

            if (_currentDirective.ApprovedBy != null)
            {
                Specialist selectedSpec = _specialists.GetItemById(_currentDirective.ApprovedBy.ItemId);
                if(selectedSpec != null)
                    comboBoxApprovedBy.SelectedItem = selectedSpec;
                else
                {
                    //Искомый специалист недействителен
                    comboBoxApprovedBy.Items.Add(_currentDirective.ApprovedBy);
                    comboBoxApprovedBy.SelectedItem = _currentDirective.ApprovedBy;
                }   
            }

            if (_currentDirective.Qualification != null)
            {
                Specialist selectedSpec = _specialists.GetItemById(_currentDirective.Qualification.ItemId);
                if(selectedSpec != null)
                    comboBoxQualification.SelectedItem = selectedSpec;
                else
                {
                    //Искомый специалист недействителен
                    comboBoxQualification.Items.Add(_currentDirective.Qualification);
                    comboBoxQualification.SelectedItem = _currentDirective.Qualification;
                }   
            }
            
            comboBoxWorkType.SelectedItem = _currentDirective.WorkType;
            if (comboBoxWorkType.SelectedItem == null)
                comboBoxWorkType.SelectedIndex = 0;

            comboBoxMMRef.SelectedItem = _currentDirective.MaintenanceManual;
            if (comboBoxMMRef.SelectedItem == null)
                comboBoxMMRef.SelectedIndex = 0;

            //labelACTypeValue;
            //labelACRegValue;
            //labelACTATValue;
            //labelACTACValue;
            //labelRelatedTaskValue;
            //labelDateValue;
            //labelIntervalValue;

            if (comboBoxPreparedBy.SelectedItem != null && ((Specialist)comboBoxPreparedBy.SelectedItem).IsDeleted)
                comboBoxPreparedBy.BackColor = Color.FromArgb(Highlight.Red.Color);
            else comboBoxPreparedBy.BackColor = Color.White;

            if (comboBoxChechedBy.SelectedItem != null && ((Specialist)comboBoxChechedBy.SelectedItem).IsDeleted)
                comboBoxChechedBy.BackColor = Color.FromArgb(Highlight.Red.Color);
            else comboBoxChechedBy.BackColor = Color.White;

            if (comboBoxApprovedBy.SelectedItem != null && ((Specialist)comboBoxApprovedBy.SelectedItem).IsDeleted)
                comboBoxApprovedBy.BackColor = Color.FromArgb(Highlight.Red.Color);
            else comboBoxApprovedBy.BackColor = Color.White;

            if (comboBoxQualification.SelectedItem != null && ((AircraftWorkerCategory)comboBoxQualification.SelectedItem).IsDeleted)
                comboBoxQualification.BackColor = Color.FromArgb(Highlight.Red.Color);
            else comboBoxQualification.BackColor = Color.White;
        }

        #endregion

        #region public void ApplyChanges()

        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        public void ApplyChanges()
        {
            textboxTitle.Focus();

            if (_currentDirective.Title != textboxTitle.Text)
            {
                _currentDirective.Title = textboxTitle.Text;

                string caption = _currentDirective.Title;

                if (DisplayerRequested != null)
                    DisplayerRequested(this,
                                       new ReferenceEventArgs(null,
                                                              ReflectionTypes.ChangeTextOfContainingDisplayer,
                                                              caption));
            }

            _currentDirective.AtaChapter = ATAChapter;
            _currentDirective.Applicability = textBoxApplicability.Text;
            _currentDirective.FormRevision = textboxFormRev.Text;
            _currentDirective.JobCardHeader = textboxJobCardHeader.Text;
            _currentDirective.FormDate = dateTimePickerFormRevDate.Value;
            _currentDirective.Title = textboxTitle.Text;
            _currentDirective.Station = textBoxStation.Text;
            _currentDirective.MRO = textBoxMRO.Text;
            _currentDirective.JobCardRevision = textBoxJCRevNumber.Text;
            _currentDirective.JobCardFooter =  textboxFooter.Text;
            _currentDirective.Access =  textBoxAccess.Text;
            _currentDirective.Zone = textBoxZone.Text;
            _currentDirective.Form = textBoxForm.Text;
            _currentDirective.JobCardRevisionDate = dateTimePickerJCRevDate.Value;
            _currentDirective.Phase = textBoxPhase.Text;
            _currentDirective.WorkArea = textBoxWorkArea.Text;
            _currentDirective.MaintenanceManualRevision = textBoxMMRevisionNumber.Text;
            _currentDirective.MaintenanceManualRevisionDate = dateTimePickerMMRevisionDate.Value;
            _currentDirective.ManHours = (double)numericUpDownManHours.Value;
            _currentDirective.Man = (int)numericUpDownMan.Value;
            textBoxAttachedTo.Text = "";
            _currentDirective.CheckedByDate = dateTimePickerCheckedDate.Value;
            _currentDirective.ApprovedByDate = dateTimePickerApprovedDate.Value;
            _currentDirective.PreparedByDate = dateTimePickerPreparedDate.Value;
            
            jobCardTaskListControl.ApplyChanges();

            _currentDirective.PreparedBy = comboBoxPreparedBy.SelectedItem as Specialist;
            _currentDirective.CheckedBy = comboBoxChechedBy.SelectedItem as Specialist;
            _currentDirective.ApprovedBy = comboBoxApprovedBy.SelectedItem as Specialist;
            _currentDirective.Qualification = comboBoxQualification.SelectedItem as AircraftWorkerCategory;
            _currentDirective.MaintenanceManual = comboBoxMMRef.SelectedItem as RefDocType ?? RefDocType.Unknown;
            _currentDirective.WorkType = comboBoxWorkType.SelectedItem as MaintenanceDirectiveTaskType ?? MaintenanceDirectiveTaskType.Unknown;

            //labelACTypeValue;
            //labelACRegValue;
            //labelACTATValue;
            //labelACTACValue;
            //labelRelatedTaskValue;
            //labelDateValue;
            //labelIntervalValue;
        }
        #endregion

        #region public void ClearFields()

        /// <summary>
        /// Очищает все поля
        /// </summary>
        public void ClearFields()
        {
            ATAChapter = null;
            textboxFormRev.Text = "";
            textboxJobCardHeader.Text = "";
            dateTimePickerFormRevDate.Value = DateTime.Today;
            textboxTitle.Text = "";
            textBoxStation.Text = "";
            textBoxMRO.Text = "";
            textBoxJCRevNumber.Text = "";
            textboxFooter.Text = "";
            textBoxAccess.Text = "";
            textBoxZone.Text = "";
            textBoxForm.Text = "";
            dateTimePickerJCRevDate.Value = DateTime.Today;
            textBoxApplicability.Text = "";
            textBoxPhase.Text = "";
            textBoxWorkArea.Text = "";
            textBoxMMRevisionNumber.Text = "";
            dateTimePickerMMRevisionDate.Value = DateTime.Today;
            numericUpDownManHours.Value = new decimal(0);
            numericUpDownMan.Value = 1;
            textBoxAttachedTo.Text = "";
            dateTimePickerCheckedDate.Value = DateTime.Today;
            dateTimePickerApprovedDate.Value = DateTime.Today;
            dateTimePickerPreparedDate.Value = DateTime.Today;
            comboBoxPreparedBy.SelectedItem = null;
            comboBoxChechedBy.SelectedItem = null;
            comboBoxApprovedBy.SelectedItem = null;
            comboBoxQualification.SelectedItem = null;
            comboBoxMMRef.SelectedItem = RefDocType.Unknown;
            comboBoxWorkType.SelectedItem = MaintenanceDirectiveTaskType.Unknown;
            commonListViewControlEqipmentAndMaterials.ItemListView.Items.Clear();

            jobCardTaskListControl.JobCard = null;

            //labelACTypeValue;
            //labelACRegValue;
            //labelACTATValue;
            //labelACTACValue;
            //labelRelatedTaskValue;
            //labelDateValue;
            //labelIntervalValue;
        }

        #endregion

        #region private void ButtonAddClick(object sender, EventArgs e)
        private void ButtonAddClick(object sender, EventArgs e)
        {
            try
            {
                KitForm form = new KitForm(_currentDirective);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    commonListViewControlEqipmentAndMaterials.SetItemsArray(_currentDirective.Kits.ToArray());
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while building new object", ex);
            }
        }
        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (commonListViewControlEqipmentAndMaterials.SelectedItems == null ||
                commonListViewControlEqipmentAndMaterials.SelectedItems.Count == 0) return;

            DialogResult confirmResult =
                MessageBox.Show(commonListViewControlEqipmentAndMaterials.SelectedItems.Count == 1
                        ? "Do you really want to delete KIT " + commonListViewControlEqipmentAndMaterials.SelectedItems[0] + "?"
                        : "Do you really want to delete selected KITs? ", "Confirm delete operation",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (confirmResult == DialogResult.Yes)
            {
                commonListViewControlEqipmentAndMaterials.ItemListView.BeginUpdate();
                foreach (BaseEntityObject directive in commonListViewControlEqipmentAndMaterials.SelectedItems)
                {
                    try
                    {
                        GlobalObjects.CasEnvironment.Manipulator.Delete(directive);
                        _currentDirective.Kits.RemoveById(directive.ItemId);
                    }
                    catch (Exception ex)
                    {
                        Program.Provider.Logger.Log("Error while deleting data", ex);
                        return;
                    }
                }
                commonListViewControlEqipmentAndMaterials.ItemListView.EndUpdate();

                commonListViewControlEqipmentAndMaterials.SetItemsArray(_currentDirective.Kits.ToArray());
            }
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

    #region internal class JobCardControlDesigner : ControlDesigner

    internal class JobCardControlDesigner : ControlDesigner
    {
        protected override void PostFilterProperties(IDictionary properties)
        {
            base.PostFilterProperties(properties);
            properties.Remove("CurrentDirective");
        }
    }
    #endregion
}
