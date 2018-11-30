using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAS.UI.UIControls.DocumentationControls;
using CAS.UI.UIControls.MaintananceProgram;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.MaintenanceWorkscope;
using TempUIExtentions;

namespace CAS.UI.UIControls.ComponentControls
{
    ///<summary>
    ///</summary>
    public partial class ComponentAddCompliancePerformanceControl : UserControl
    {
	    private readonly Component _parentComponent;

	    #region Fields

	    private ComponentDirective _currentComponentDirective;
        #endregion

        #region Constructor

        #region DetailAddCompliancePerformanceControl()
        ///<summary>
        ///</summary>
        public ComponentAddCompliancePerformanceControl()
        {
            InitializeComponent();
        }

        #endregion

        #region public DetailAddCompliancePerformanceControl(object aircraft) : this()
        /// <summary>
        /// Создает элемент управления, использующийся для задания отдельной информации Compliance/Performance при добавлении агрегата
        /// </summary>
        /// <param name="parentComponentеталь, для которой добавляется задача</param>
        public ComponentAddCompliancePerformanceControl(Component parentComponent) : this()
        {
	        _parentComponent = parentComponent;
			_currentComponentDirective = new ComponentDirective();
			UpdateInformation(parentComponent);
        }
        #endregion

        #endregion

        #region Propeties

        #region public bool AddActualStateRecordToAircraft

        /// <summary>
        /// Добавлять ли ActualStareRecord к ВС
        /// </summary>
        public bool AddActualStateRecordToAircraft
        {
            get
            {
                return lifelengthViewer_FirstNotify.Modified;
            }
        }

        #endregion

        #region public bool AddActualStateRecordToDetail

        /// <summary>
        /// Добавлять ли ActualStareRecord к агрегату
        /// </summary>
        public bool AddActualStateRecordToDetail
        {
            get
            {
                return lifelengthViewer_FirstPerformance.Modified;
            }
        }

        #endregion

        #region public Lifelength AircraftLastPerformance

        /// <summary>
        /// Возвращает наработку Last Compliance ВС
        /// </summary>
        public Lifelength AircraftLastPerformance
        {
            get
            {
                return lifelengthViewer_FirstNotify.Lifelength;
            }
        }

        #endregion

        #region public Lifelength ComponentLastPerformance

        /// <summary>
        /// Возвращает наработку Last Compliance агрегата
        /// </summary>
        public Lifelength ComponentLastPerformance
        {
            get
            {
                return lifelengthViewer_FirstPerformance.Lifelength;
            }
        }

        #endregion

        #region public Lifelength Interval

        /// <summary>
        /// Возвращает интервал обслуживания
        /// </summary>
        public Lifelength Interval
        {
            get
            {
                return lifelengthViewerRptInterval.Lifelength;
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
            if (lookupComboboxMaintenanceDirective != null)
                lookupComboboxMaintenanceDirective.CancelAsync();
        }
        #endregion

        #region private void UpdateInformation(Detail parentDetail)

        private void UpdateInformation(Component parentComponent)
        {
            UpdateWorkTypes(parentComponent.GoodsClass);

            comboBoxMpdTaskType.Items.Clear();
            comboBoxMpdTaskType.Items.AddRange(MaintenanceDirectiveTaskType.Items.ToArray());
            comboBoxMpdTaskType.SelectedItem = MaintenanceDirectiveTaskType.Unknown;

			documentControl1.Added += DocumentControl1_Added;

			#region MaintenanceDirective

			lookupComboboxMaintenanceDirective.SelectedIndexChanged -= LookupComboboxMaintenanceDirectiveSelectedIndexChanged;
			var pareAircraft = GlobalObjects.AircraftsCore.GetAircraftById(parentComponent.ParentAircraftId);//TODO:(Evgenii Babak) пересмотреть использование ParentAircrafId здесь
			if (pareAircraft != null)
            {
                var maintenanceScreenDisplayerText = $"{parentComponent.GetParentAircraftRegNumber()}. MPD";
				
				lookupComboboxMaintenanceDirective.SetEditScreenControl<MaintenanceDirectiveScreen>
                    (maintenanceScreenDisplayerText);
                lookupComboboxMaintenanceDirective.SetItemsScreenControl<MaintenanceDirectiveListScreen>
                    (new[] { pareAircraft }, maintenanceScreenDisplayerText);
                lookupComboboxMaintenanceDirective.LoadObjectsFunc = GlobalObjects.MaintenanceCore.GetMaintenanceDirectives;
                lookupComboboxMaintenanceDirective.FilterParam1 = pareAircraft;
                lookupComboboxMaintenanceDirective.SelectedItemId = -1;
                lookupComboboxMaintenanceDirective.UpdateInformation();
            }

            lookupComboboxMaintenanceDirective.SelectedIndexChanged += LookupComboboxMaintenanceDirectiveSelectedIndexChanged;

            #endregion
        }
		#endregion

		#region private void DocumentControl1_Added(object sender, EventArgs e)

		private void DocumentControl1_Added(object sender, EventArgs e)
	    {
		    var docSubType = GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Component CRS Form") as DocumentSubType;
		    var partNumber = _parentComponent.PartNumber;
		    var serialNumber = _parentComponent.SerialNumber;
		    var description = _parentComponent.Description;


		    var newDocument = new Document
		    {
			    Parent = _currentComponentDirective,
			    ParentTypeId = _currentComponentDirective.SmartCoreObjectType.ItemId,
			    DocType = DocumentType.TechnicalRecords,
			    DocumentSubType = docSubType,
			    IsClosed = true,
			    ContractNumber = $"P/N:{partNumber} S/N:{serialNumber}",
			    Description = description,
				ParentAircraftId = _parentComponent.ParentAircraftId
		    };
		    var form = new DocumentForm(newDocument, false);
		    if (form.ShowDialog() == DialogResult.OK)
		    {
			    _currentComponentDirective.Document = newDocument;
			    documentControl1.CurrentDocument = newDocument;

		    }
	    }

	    #endregion

		#region public void UpdateWorkTypes(GoodsClass goodsClass)
		///<summary>
		/// Изменяет доступные типы задач для переданного типа компонентов
		///</summary>
		///<param name="goodsClass">Тип компонента, для которого нужно определить типы задач</param>
		public void UpdateWorkTypes(GoodsClass goodsClass)
        {
            comboBoxWorkType.Items.Clear();
            var directiveTypes = new CommonDictionaryCollection<ComponentRecordType>(ComponentRecordType.Items);

            if (goodsClass.IsNodeOrSubNodeOf(GoodsClass.ControlTestEquipment))
                directiveTypes.Remove(ComponentRecordType.Calibration);

            comboBoxWorkType.Items.AddRange(directiveTypes.OrderBy(x => x.FullName).ToArray());

            if (comboBoxWorkType.SelectedItem == null)
                comboBoxWorkType.SelectedIndex = 0;
        }

        #endregion

        #region public bool GetChangeStatus()

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        public bool GetChangeStatus()
        {
			var manHours = ConvertDoubleValue(textBoxManHours.Text);
			var cost = ConvertDoubleValue(textBoxCost.Text);

			if (!lifelengthViewer_FirstPerformance.Lifelength.IsNullOrZero() ||
                lookupComboboxMaintenanceDirective.SelectedItemId > 0 ||
                comboBoxMpdTaskType.SelectedItem != null
                || fileControl.GetChangeStatus()
                || (manHours > 0.0001)
                || (cost > 0.0001))
            {
                return true;
            }

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
			var sb = new StringBuilder();
			string manHourMessage, costMessage, validateFiles;
			ValidateDoubleValue("Man Hours", textBoxManHours.Text, out manHourMessage);
			ValidateDoubleValue("Cost", textBoxCost.Text, out costMessage);

			if (!string.IsNullOrEmpty(manHourMessage))
				sb.AppendLine(manHourMessage);
			if (!string.IsNullOrEmpty(costMessage))
				sb.AppendLine(costMessage);
			if (!fileControl.ValidateData(out validateFiles))
				sb.AppendLine("FAA File: " + validateFiles);

			message = sb.ToString();
			if (message != "")
				return false;
			return true;
		}

		#endregion

		#region private bool ValidateDoubleValue(string paramName, string checkedString)

		/// <summary>
		/// Проверяет значение ManHours
		/// </summary>
		/// <param name="paramName"></param>
		/// <param name="checkedString">Строковое значение value</param>
		/// <returns>Возвращает true если значение можно преобразовать в тип double, иначе возвращает false</returns>
		private void ValidateDoubleValue(string paramName, string checkedString, out string message)
		{
			message = "";
			double value;
			if (checkedString != "" && double.TryParse(checkedString, NumberStyles.Float, new NumberFormatInfo(), out value) == false)
			{
				message = paramName + ". Invalid value";
			}
		}

		#endregion

		#region private double ConvertDoubleValue(string checkedString)

		private double ConvertDoubleValue(string checkedString)
		{
			return checkedString == "" ? 0 : double.Parse(checkedString, NumberStyles.Float, new NumberFormatInfo());
		}

		#endregion

		#region public void ApplyChanges(DetailDirective currentDetailDirective)


		public void ApplyChanges()
        {
			var manHours = ConvertDoubleValue(textBoxManHours.Text);
			var cost = ConvertDoubleValue(textBoxCost.Text);

			_currentComponentDirective.DirectiveType = (ComponentRecordType)comboBoxWorkType.SelectedItem;

            _currentComponentDirective.ManHours = manHours;
            _currentComponentDirective.Cost = cost;
            _currentComponentDirective.KitRequired = textBoxKitRequired.Text;
            _currentComponentDirective.Remarks = textBoxRemarks.Text;
            _currentComponentDirective.HiddenRemarks = textBoxHiddenRemarks.Text;
            _currentComponentDirective.MPDTaskType = ((MaintenanceDirectiveTaskType)comboBoxMpdTaskType.SelectedItem);

            var md = lookupComboboxMaintenanceDirective.SelectedItem as MaintenanceDirective;
            if (md != null)
            {
                _currentComponentDirective.MaintenanceDirective = md;
            }

            var threshold = new ComponentDirectiveThreshold();

            if (_currentComponentDirective.DirectiveType == ComponentRecordType.Preservation)
            {
                threshold.EffectiveDate = dateTimePickerEffDate.Value;
                threshold.FirstPerformanceSinceNew.Reset();
                threshold.FirstPerformanceSinceEffectiveDate = lifelengthViewer_FirstPerformance.Lifelength;
            }
            else
            {
                threshold.EffectiveDate = DateTimeExtend.GetCASMinDateTime();
                threshold.FirstPerformanceSinceNew = lifelengthViewer_FirstPerformance.Lifelength;
                threshold.FirstPerformanceSinceEffectiveDate.Reset();
            }
            threshold.FirstNotification = lifelengthViewer_FirstNotify.Lifelength;
            threshold.RepeatInterval = lifelengthViewerRptInterval.Lifelength;
            threshold.RepeatNotification = lifelengthViewerRptNotify.Lifelength;
            threshold.Warranty = lifelengthViewerWarranty.Lifelength;
            threshold.WarrantyNotification = lifelengthViewerWarrantyNotify.Lifelength;
            threshold.FirstPerformanceConditionType = radio_WhicheverFirst.Checked
                                                      ? ThresholdConditionType.WhicheverFirst
                                                      : ThresholdConditionType.WhicheverLater;

            if (_currentComponentDirective.Threshold == null || 
                _currentComponentDirective.Threshold.ToString() != threshold.ToString())
                _currentComponentDirective.Threshold = threshold;

            if (fileControl.GetChangeStatus() || fileControl.AttachedFile != null)
            {
                fileControl.ApplyChanges();
                _currentComponentDirective.FaaFormFile = fileControl.AttachedFile;
            }		
        }

		#endregion

		#region public void ApplyChanges(Component component)

		public void ApplyChanges(Component component)
	    {
		    if (component == null)
			    return;

		    ApplyChanges();
		    component.ComponentDirectives.Add(_currentComponentDirective);
	    }

	    #endregion

		#region public void SaveData(Detail detail)

		public void SaveData(Component component)
        {
	        try
	        {
		        GlobalObjects.ComponentCore.AddComponentDirective(component, _currentComponentDirective);
	        }
	        catch (Exception ex)
	        {
				Program.Provider.Logger.Log("Error while saving data", ex);
			}
		}

        #endregion

        #region private void checkBoxLastCompliance_CheckedChanged(object sender, EventArgs e)

        private void CheckBoxLastComplianceCheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Repeat.Checked)
            {
                lifelengthViewerRptInterval.Enabled = true;
                lifelengthViewerRptNotify.Enabled = true;

            }
            else
            {
                lifelengthViewerRptInterval.Enabled = false;
                lifelengthViewerRptNotify.Enabled = false;
            }
        }

        #endregion

        #region private void lifelengthViewerInterval_LifelengthChanged(object sender, EventArgs e)

        private void lifelengthViewerInterval_LifelengthChanged(object sender, EventArgs e)
        {
        }

        #endregion

        #region private void lifelengthViewerComponentLastPerformance_LifelengthChanged(object sender, EventArgs e)

        private void lifelengthViewerComponentLastPerformance_LifelengthChanged(object sender, EventArgs e)
        {
            //if (checkBox_Repeat.Checked)
            //{
            //    Lifelength tempLifelength = new Lifelength(lifelengthViewer_TSN.Lifelength);
            //    tempLifelength.Add(lifelengthViewerInterval.Lifelength);
            //    lifelengthViewerNext.Lifelength = tempLifelength;
            //    tempLifelength = new Lifelength(lifelengthViewerNext.Lifelength);
            //    tempLifelength.Substract(lifelengthViewer_TSN.Lifelength);
            //    lifelengthViewerRemains.Lifelength = tempLifelength;
            //}
            //else
            //    lifelengthViewerNext.Lifelength = lifelengthViewerRemains.Lifelength = lifelengthViewerInterval.Lifelength;
        }

        #endregion

        #region private void ComboBoxWorkTypeSelectedIndexChanged(object sender, EventArgs e)

        private void ComboBoxWorkTypeSelectedIndexChanged(object sender, EventArgs e)
        {
            ComponentRecordType drt = comboBoxWorkType.SelectedItem as ComponentRecordType;
            if (drt == null || drt != ComponentRecordType.Preservation)
            {
                labelEffectivityDate.Visible = false;
                dateTimePickerEffDate.Visible = false;
                lifelengthViewer_FirstPerformance.LeftHeader = "Perform at:";
            }
            else
            {
                labelEffectivityDate.Visible = true;
                dateTimePickerEffDate.Visible = true;
                lifelengthViewer_FirstPerformance.LeftHeader = "Since Cons. Date:";
            }
        }
        #endregion

        #region private void LookupComboboxMaintenanceDirectiveSelectedIndexChanged(object sender, EventArgs e)
        private void LookupComboboxMaintenanceDirectiveSelectedIndexChanged(object sender, EventArgs e)
        {
            if (lookupComboboxMaintenanceDirective.SelectedItem != null)
            {
                MaintenanceDirective md = (MaintenanceDirective)lookupComboboxMaintenanceDirective.SelectedItem;
                MaintenanceDirectiveThreshold mdt = md.Threshold;
                comboBoxMpdTaskType.SelectedItem = md.WorkType;
                lifelengthViewer_FirstPerformance.Lifelength = new Lifelength(mdt.FirstPerformanceSinceNew);
                lifelengthViewer_FirstNotify.Lifelength = new Lifelength(mdt.FirstNotification);
                lifelengthViewerRptInterval.Lifelength = new Lifelength(mdt.RepeatInterval);
                lifelengthViewerRptNotify.Lifelength = new Lifelength(mdt.RepeatNotification);
                radio_WhicheverFirst.Checked = true;

                lifelengthViewer_FirstPerformance.Enabled = false;
                lifelengthViewer_FirstNotify.Enabled = false;
                lifelengthViewerRptInterval.Enabled = false;
                lifelengthViewerRptNotify.Enabled = false;
                radio_WhicheverFirst.Enabled = false;
                radio_WhicheverLater.Enabled = false;
            }
            else
            {
                lifelengthViewer_FirstPerformance.Enabled = true;
                lifelengthViewer_FirstNotify.Enabled = true;
                lifelengthViewerRptInterval.Enabled = true;
                lifelengthViewerRptNotify.Enabled = true;
                radio_WhicheverFirst.Enabled = true;
                radio_WhicheverLater.Enabled = true;
            }
        }
        #endregion

        #endregion
    }
}
