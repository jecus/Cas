using System;
using System.Collections;
using System.Collections.Generic;
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
using SmartCore.Entities.General.Commercial;
using SmartCore.Entities.General.Deprecated;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UIControls.CommercialControls
{
    ///<summary>
    ///</summary>
    [Designer(typeof(WorkOrderControl))]
    public partial class WorkOrderControl : UserControl, IReference
    {
        private CommonCollection<Specialist> _specialists = new CommonCollection<Specialist>();
        private CommonDictionaryCollection<AircraftWorkerCategory> _qualifications = 
            new CommonDictionaryCollection<AircraftWorkerCategory>();

        #region Fields

        private WorkOrder _currentDirective;

        #endregion

        #region Constructors

        #region public WorkOrderControl()

        ///<summary>
        /// Создает объект для отображения информации о директиве
        ///</summary>
        public WorkOrderControl()
        {
            InitializeComponent();
        }

        #endregion

        #endregion

        #region Properties

        #region public WorkOrder CurrentDirective
        ///<summary>
        ///Текущая директива
        ///</summary>
        public WorkOrder CurrentDirective
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
                return (comboBoxApprovedBy.SelectedItem != _currentDirective.ApprovedBy ||
                        comboBoxChechedBy.SelectedItem != _currentDirective.CheckedBy ||
                        comboBoxPreparedBy.SelectedItem != _currentDirective.PreparedBy ||
                        dateTimePickerApprovedDate.Value != _currentDirective.ApprovedByDate ||
                        dateTimePickerCheckedDate.Value != _currentDirective.CheckedByDate ||
                        dateTimePickerFormRevDate.Value != _currentDirective.FormDate ||
                        dateTimePickerPreparedDate.Value != _currentDirective.PreparedByDate ||
                        textBoxAttachedTo.Text != "" ||
                        textBoxForm.Text != _currentDirective.Form ||
                        textboxFormRev.Text != _currentDirective.FormRevision ||
                        textBoxTitle.Text != _currentDirective.Title ||
                        textBoxDescription.Text != _currentDirective.Description ||
                        textboxWorkOrderHeader.Text != _currentDirective.JobCardHeader ||
                        //textBoxMMRevisionNumber.Text != _currentDirective.MaintenanceManualRevision ||
                        //textBoxMRO.Text != _currentDirective.MRO ||
                        //textBoxPhase.Text != _currentDirective.Phase ||
                        textboxNumber.Text != _currentDirective.Number ||
                        textBoxStation.Text != _currentDirective.Station ||
                        _currentDirective.PackageRecords.Any(pr => pr.ItemId <= 0)
                        //textBoxWorkArea.Text != _currentDirective.WorkArea ||
                        //textBoxZone.Text != _currentDirective.Zone
                        );
            return (textBoxTitle.Text != "" &&
                    textBoxDescription.Text != "" &&
                    textboxNumber.Text != "" &&
                    textboxWorkOrderHeader.Text != "" &&
                    textboxNumber.Text != "");

            return false;
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

            if (textboxWorkOrderHeader.Text == "")
            {
                if (message != "") message += "\n ";
                message += "You should enter Job Card Header";
            }

            if (textboxNumber.Text == "")
            {
                if (message != "") message += "\n ";
                message += "You should enter Job Card Title";
            }

            string m = "";
            if (!workOrderViewControl.ValidateData(out m))
            {
                if (message != "") message += "\n ";
                message += m;
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
            _specialists.Clear();
            _specialists.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<SpecialistDTO ,Specialist>());
            _qualifications.Clear();

            var awcs = GlobalObjects.CasEnvironment.GetDictionary<AircraftWorkerCategory>();
            if (awcs != null)
                _qualifications.AddRange(awcs.OfType<AircraftWorkerCategory>());

            comboBoxPreparedBy.Items.Clear();
            comboBoxPreparedBy.Items.AddRange(_specialists.GetValidEntries());
            comboBoxChechedBy.Items.Clear();
            comboBoxChechedBy.Items.AddRange(_specialists.GetValidEntries());
            comboBoxApprovedBy.Items.Clear();
            comboBoxApprovedBy.Items.AddRange(_specialists.GetValidEntries());
            comboBoxRequest.Items.Clear();
            comboBoxRequest.Items.AddRange(RefDocType.Items.ToArray());

            commonListViewControlEqipmentAndMaterials.ViewedType = typeof (AccessoryRequired);
            workOrderViewControl.ViewedType = typeof(BaseEntityObject);

            if (_currentDirective == null) return;

            textboxFormRev.Text = _currentDirective.FormRevision;
            textboxWorkOrderHeader.Text = _currentDirective.JobCardHeader;
            dateTimePickerFormRevDate.Value = _currentDirective.FormDate;
            textboxNumber.Text = _currentDirective.Number;
            textBoxStation.Text = _currentDirective.Station;
            //textBoxMRO.Text = _currentDirective.MRO;
            textBoxTitle.Text = _currentDirective.Title;
            textBoxDescription.Text = _currentDirective.Description;
            //textboxFooter.Text = _currentDirective.JobCardFooter;
            //textBoxAccess.Text = _currentDirective.Access;
            //textBoxZone.Text = _currentDirective.Zone;
            textBoxForm.Text = _currentDirective.Form;
            //textBoxApplicability.Text = _currentDirective.Applicability;
            //textBoxPhase.Text = _currentDirective.Phase;
            //textBoxWorkArea.Text = _currentDirective.WorkArea;
            //textBoxMMRevisionNumber.Text = _currentDirective.MaintenanceManualRevision;
            //dateTimePickerMMRevisionDate.Value = _currentDirective.MaintenanceManualRevisionDate;
            //numericUpDownManHours.Value = (decimal)_currentDirective.ManHours;
            //numericUpDownMan.Value = _currentDirective.Man;
            textBoxAttachedTo.Text = "";
            dateTimePickerCheckedDate.Value = _currentDirective.CheckedByDate;
            dateTimePickerApprovedDate.Value = _currentDirective.ApprovedByDate;
            dateTimePickerPreparedDate.Value = _currentDirective.PreparedByDate;

            commonListViewControlEqipmentAndMaterials.SetItemsArray(_currentDirective.Kits.ToArray());

            IEnumerable<IDirective> directives =
                _currentDirective.PackageRecords.Where(pr => pr.Task != null).Select(pr => pr.Task).ToArray();
            workOrderViewControl.SetItemsArray(directives.Select(pr => pr as BaseEntityObject));
            numericUpDownMan.Value = directives.OfType<IEngineeringDirective>().Sum(d => d.Mans);
            numericUpDownManHours.Value = (Decimal)directives.OfType<IEngineeringDirective>().Sum(d => d.ManHours);
            numericUpDownCost.Value = (Decimal)directives.OfType<IEngineeringDirective>().Sum(d => d.Cost);

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

            //if (_currentDirective.Qualification != null)
            //{
            //    Specialist selectedSpec = _specialists.GetItemById(_currentDirective.Qualification.ItemId);
            //    if(selectedSpec != null)
            //        comboBoxQualification.SelectedItem = selectedSpec;
            //    else
            //    {
            //        //Искомый специалист недействителен
            //        comboBoxQualification.Items.Add(_currentDirective.Qualification);
            //        comboBoxQualification.SelectedItem = _currentDirective.Qualification;
            //    }   
            //}
            
            //comboBoxWorkType.SelectedItem = _currentDirective.WorkType;
            //if (comboBoxWorkType.SelectedItem == null)
            //    comboBoxWorkType.SelectedIndex = 0;

            //comboBoxMMRef.SelectedItem = _currentDirective.MaintenanceManual;
            //if (comboBoxMMRef.SelectedItem == null)
            //    comboBoxMMRef.SelectedIndex = 0;

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
        }

        #endregion

        #region public void ApplyChanges()

        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        public void ApplyChanges()
        {
            textboxNumber.Focus();

            if (_currentDirective.Number != textboxNumber.Text)
            {
                _currentDirective.Number = textboxNumber.Text;

                string caption = _currentDirective.Title;

                if (DisplayerRequested != null)
                    DisplayerRequested(this,
                                       new ReferenceEventArgs(null,
                                                              ReflectionTypes.ChangeTextOfContainingDisplayer,
                                                              caption));
            }

            //_currentDirective.AtaChapter = ATAChapter;
            //_currentDirective.Applicability = textBoxApplicability.Text;
            _currentDirective.FormRevision = textboxFormRev.Text;
            _currentDirective.JobCardHeader = textboxWorkOrderHeader.Text;
            _currentDirective.FormDate = dateTimePickerFormRevDate.Value;
            _currentDirective.Title = textboxNumber.Text;
            _currentDirective.Station = textBoxStation.Text;
            //_currentDirective.MRO = textBoxMRO.Text;
            _currentDirective.Title = textBoxTitle.Text;
            //_currentDirective.JobCardFooter = textboxFooter.Text;
            //_currentDirective.Access = textBoxAccess.Text;
            //_currentDirective.Zone = textBoxZone.Text;
            _currentDirective.Form = textBoxForm.Text;
            _currentDirective.Description = textBoxDescription.Text;
            //_currentDirective.Phase = textBoxPhase.Text;
            //_currentDirective.WorkArea = textBoxWorkArea.Text;
            //_currentDirective.MaintenanceManualRevision = textBoxMMRevisionNumber.Text;
            //_currentDirective.MaintenanceManualRevisionDate = dateTimePickerMMRevisionDate.Value;
            //_currentDirective.ManHours = (double)numericUpDownManHours.Value;
            //_currentDirective.Man = (int)numericUpDownMan.Value;
            textBoxAttachedTo.Text = "";
            _currentDirective.CheckedByDate = dateTimePickerCheckedDate.Value;
            _currentDirective.ApprovedByDate = dateTimePickerApprovedDate.Value;
            _currentDirective.PreparedByDate = dateTimePickerPreparedDate.Value;

            //jobCardTaskListControl.ApplyChanges();

            _currentDirective.PreparedBy = comboBoxPreparedBy.SelectedItem as Specialist;
            _currentDirective.CheckedBy = comboBoxChechedBy.SelectedItem as Specialist;
            _currentDirective.ApprovedBy = comboBoxApprovedBy.SelectedItem as Specialist;
            //_currentDirective.Qualification = comboBoxQualification.SelectedItem as AircraftWorkerCategory;
            //_currentDirective.MaintenanceManual = comboBoxMMRef.SelectedItem as RefDocType ?? RefDocType.Unknown;
            //_currentDirective.WorkType = comboBoxWorkType.SelectedItem as MaintenanceDirectiveTaskType ?? MaintenanceDirectiveTaskType.Unknown;

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
            textboxFormRev.Text = "";
            textboxWorkOrderHeader.Text = "";
            dateTimePickerFormRevDate.Value = DateTime.Today;
            textboxNumber.Text = "";
            textBoxStation.Text = "";
            textBoxMRO.Text = "";
            textBoxTitle.Text = "";
            textboxFooter.Text = "";
            textBoxDescription.Text = "";
            textBoxCustomer.Text = "";
            textBoxForm.Text = "";
            numericUpDownManHours.Value = new decimal(0);
            numericUpDownMan.Value = 1;
            textBoxAttachedTo.Text = "";
            dateTimePickerCheckedDate.Value = DateTime.Today;
            dateTimePickerApprovedDate.Value = DateTime.Today;
            dateTimePickerPreparedDate.Value = DateTime.Today;
            comboBoxPreparedBy.SelectedItem = null;
            comboBoxChechedBy.SelectedItem = null;
            comboBoxApprovedBy.SelectedItem = null;
            comboBoxRequest.SelectedItem = RefDocType.Unknown;
            commonListViewControlEqipmentAndMaterials.ItemListView.Items.Clear();

            workOrderViewControl.ClearItems();

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

        #region private void ButtonAddTaskClick(object sender, EventArgs e)
        private void ButtonAddTaskClick(object sender, EventArgs e)
        {
            DirectivePackageBindTaskForm form = new DirectivePackageBindTaskForm(_currentDirective);
            if (form.ShowDialog() == DialogResult.OK)
            {
                foreach (IDirective obj in form.SelectedItems.OfType<IDirective>())
                {
                    WorkOrderRecord newRecord = new WorkOrderRecord
                    {
                        ParentId = _currentDirective.ItemId,
                        DirectiveId = obj.ItemId,
                        PackageItemType = obj.SmartCoreObjectType,
                        Task = obj,
                        ParentPackage = _currentDirective
                    };
                    _currentDirective.PackageRecords.Add(newRecord);
                }
                IEnumerable<IDirective> directives =
                    _currentDirective.PackageRecords.Where(pr => pr.Task != null).Select(pr => pr.Task).ToArray();
                workOrderViewControl.SetItemsArray(directives.Select(pr => pr as BaseEntityObject));
                numericUpDownMan.Value = directives.OfType<IEngineeringDirective>().Sum(d => d.Mans);
                numericUpDownManHours.Value = (Decimal)directives.OfType<IEngineeringDirective>().Sum(d => d.ManHours);
                numericUpDownCost.Value = (Decimal)directives.OfType<IEngineeringDirective>().Sum(d => d.Cost);
            }
        }
        #endregion

        #region private void ButtonDeleteTaskClick(object sender, EventArgs e)
        private void ButtonDeleteTaskClick(object sender, EventArgs e)
        {
            if (workOrderViewControl.SelectedItems == null ||
                workOrderViewControl.SelectedItems.Count == 0) return;

            DialogResult confirmResult =
                MessageBox.Show(workOrderViewControl.SelectedItems.Count == 1
                        ? "Do you really want to delete Record " + workOrderViewControl.SelectedItems[0] + "?"
                        : "Do you really want to delete selected Records? ", "Confirm delete operation",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    GlobalObjects.PackageCore.DeleteFromDirectivePackage<WorkOrder, WorkOrderRecord>(workOrderViewControl.SelectedItems.ToArray(), _currentDirective);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while deleting data", ex);
                    return;
                }

                IEnumerable<IDirective> directives =
                    _currentDirective.PackageRecords.Where(pr => pr.Task != null).Select(pr => pr.Task).ToArray();
                workOrderViewControl.SetItemsArray(directives.Select(pr => pr as BaseEntityObject));
                numericUpDownMan.Value = directives.OfType<IEngineeringDirective>().Sum(d => d.Mans);
                numericUpDownManHours.Value = (Decimal)directives.OfType<IEngineeringDirective>().Sum(d => d.ManHours);
                numericUpDownCost.Value = (Decimal)directives.OfType<IEngineeringDirective>().Sum(d => d.Cost);
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

    #region internal class WorkOrderControlDesigner : ControlDesigner

    internal class WorkOrderControlDesigner : ControlDesigner
    {
        protected override void PostFilterProperties(IDictionary properties)
        {
            base.PostFilterProperties(properties);
            properties.Remove("CurrentDirective");
        }
    }
    #endregion
}
