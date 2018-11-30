using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary.Dialogs;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.ComponentControls
{
    ///<summary>
    /// Форма для редактирования записи о смене LLP категории
    ///</summary>
    public partial class ComponentChangeLLPCategoryRecordForm : ComplianceDialog
    {
        #region Fields

        private Component _currentComponent;
        private ComponentLLPCategoryChangeRecord _currentRecord;

        #endregion

        #region Properties

        #region string Remarks { get; }

        ///<summary>
        ///</summary>
        public string Remarks { get { return textBox_Remarks.Text; } }

        #endregion

        #endregion

        #region Constructors

        #region DetailChangeLLPCategoryRecordForm()
        ///<summary>
        /// Конструктор по умолчанию для простого создания диалогового окна
        ///</summary>
        public ComponentChangeLLPCategoryRecordForm()
        {
            InitializeComponent();
        }

        #endregion

        #region public DetailChangeLLPCategoryRecordForm(Detail currentDirective, DetailLLPCategoryChangeRecord currentRecord) : this()
        ///<summary>
        /// Конструктор принимающий в качестве параметров уже готовую запись
        ///</summary>
        ///<param name="currentComponentеталь, которой принадлежит запись</param>
        ///<param name="currentRecord">Сама запись</param>
        public ComponentChangeLLPCategoryRecordForm(Component currentComponent, ComponentLLPCategoryChangeRecord currentRecord) : this()
        {
            _currentComponent = currentComponent;
            _currentRecord = currentRecord;

            UpdateInformation();
        }

        #endregion

        #endregion

        #region Methods

        #region private bool SaveData()

        /// <summary>
        /// Данные работы обновляются по введенным значениям
        /// </summary>
        private bool SaveData()
        {
            if (dateTimePicker1.Value.Date > DateTime.Today.Date) return false;
            if (comboBoxCategories.SelectedIndex == -1)
            {
                MessageBox.Show(@"You did not select a new category for detail",
                                  new GlobalTermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK,
                                  MessageBoxIcon.Exclamation);
                return false;
            }
            if (_currentComponent.ChangeLLPCategoryRecords.GetLast() != null &&
                _currentComponent.ChangeLLPCategoryRecords[dateTimePicker1.Value] != null &&
                _currentComponent.ChangeLLPCategoryRecords[dateTimePicker1.Value].ItemId != _currentRecord.ItemId)
            {
                MessageBox.Show(@"On this day there is a record of the change of category.\n
                                  Change record date",
                                  new GlobalTermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK,
                                  MessageBoxIcon.Exclamation);
                return false;
            }

            if (lifelengthViewer_LastCompliance.Lifelength.Days == null)
            {
                if (_currentRecord.ParentComponent != null)
                {
                    lifelengthViewer_LastCompliance.Lifelength.Days = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay
                        (_currentRecord.ParentComponent, dateTimePicker1.Value).Days;
                }
            }   
            _currentRecord.ToCategory = ((LLPLifeLimitCategory) comboBoxCategories.SelectedItem);
            _currentRecord.RecordDate = dateTimePicker1.Value;
            _currentRecord.Remarks = Remarks;
            _currentRecord.OnLifelength = lifelengthViewer_LastCompliance.Lifelength;


	        var actualStateRecord = new ActualStateRecord
	        {
		        ComponentId = _currentComponent.ItemId,
		        OnLifelength = lifelengthViewer_LastCompliance.Lifelength,
				RecordDate = dateTimePicker1.Value,
				Remarks = $"{(LLPLifeLimitCategory)comboBoxCategories.SelectedItem} Category"
		};

			if (fileControl.GetChangeStatus())
            {
                fileControl.ApplyChanges();
                _currentRecord.AttachedFile = fileControl.AttachedFile;
            }
            try
            {
                GlobalObjects.ComponentCore.RegisterChangeLLPCategory(_currentComponent, _currentRecord);
                GlobalObjects.ComponentCore.RegisterActualState(_currentComponent, actualStateRecord);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
                return false;
            }
            return true;
        }

        #endregion

        #region public void UpdateInformation()
        /// <summary>
        /// Обновление информации ЭУ
        /// </summary>
        public void UpdateInformation()
        {
            fileControl.UpdateInfo(null, "Adobe PDF Files|*.pdf",
                               "This record does not contain a file proving the compliance. Enclose PDF file to prove the compliance.",
                               "Attached file proves the compliance.");

            if (_currentRecord == null) 
                return;
            fileControl.AttachedFile = _currentRecord.AttachedFile;

            #region Обработка категорий для LLPCategoryComboBox
            List<LLPLifeLimitCategory> categories = null;
			var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(_currentComponent.ParentAircraftId);//TODO:(Evgenii Babak) надо пересмотреть т.к из Aircraft тут используется только Model

			if (aircraft != null) //деталь находится на самолете
            {
                var llps = GlobalObjects.CasEnvironment.GetDictionary<LLPLifeLimitCategory>();
                categories = llps
                    .OfType<LLPLifeLimitCategory>()
                    .Where(c => c.AircraftModel?.ItemId == aircraft.Model.ItemId)
                    .ToList();
            }
            else //деталь на складу
            {
                LLPLifeLimitCategory current = _currentComponent.ChangeLLPCategoryRecords.GetLast().ToCategory;
                if (current != null)
                {
                    var llps = GlobalObjects.CasEnvironment.GetDictionary<LLPLifeLimitCategory>();
                    categories = llps
                        .OfType<LLPLifeLimitCategory>()
                        .Where(c => c.AircraftModel == current.AircraftModel)
                        .ToList();
                }
            }
            if(categories != null && categories.Count > 0)
            {
                comboBoxCategories.Items.AddRange(categories.ToArray());
                comboBoxCategories.SelectedItem = _currentRecord.ToCategory;
            }
            #endregion

            textBox_Remarks.Text = _currentRecord.Remarks ?? "";

            //DateTime StartDate = new DateTime(1950, 1, 1);
            if (_currentRecord.RecordDate < DateTimeExtend.GetCASMinDateTime())
                dateTimePicker1.Value = DateTime.Today;
            else dateTimePicker1.Value = _currentRecord.RecordDate;

            if (_currentRecord.OnLifelength.IsNullOrZero())
            {
                if (_currentRecord.ParentComponent != null)
                    lifelengthViewer_LastCompliance.Lifelength =
                        GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_currentRecord.ParentComponent);
            }
            else lifelengthViewer_LastCompliance.Lifelength = _currentRecord.OnLifelength;
        }
       
        #endregion

        #endregion

        #region Events

        #region private void ButtonCancelClick(object sender, EventArgs e)

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion

        #region private void ButtonOkClick(object sender, EventArgs e)

        private void ButtonOkClick(object sender, EventArgs e)
        {
            if (SaveData())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        #endregion

        #region private void ButtonApplyClick(object sender, EventArgs e)

        private void ButtonApplyClick(object sender, EventArgs e)
        {
            if (SaveData())
            {
                DialogResult = DialogResult.Yes;
            }
        }
        #endregion

        #region private void DateTimePicker1ValueChanged(object sender, EventArgs e)

        private void DateTimePicker1ValueChanged(object sender, EventArgs e)
        {
            if (_currentRecord.ParentComponent != null)  
            {
                if (_currentRecord.ParentComponent.IsBaseComponent)
                {
                    BaseComponent bd =
                        GlobalObjects.ComponentCore.GetBaseComponentById(_currentRecord.ParentComponent.ItemId);
                    if(bd!=null)
                    {
                        lifelengthViewer_LastCompliance.Lifelength =
                        GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(bd,dateTimePicker1.Value);
                    }
                }
                else
                {
                    lifelengthViewer_LastCompliance.Lifelength =
                    GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(_currentRecord.ParentComponent,
                                                                      dateTimePicker1.Value);
                }
            }
        }
        #endregion

        #endregion
    }
}
