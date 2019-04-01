using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using AvControls;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.KitControls;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using TempUIExtentions;

namespace CAS.UI.UIControls.MaintananceProgram
{
    ///<summary>
    /// ЭУ для отображения директивы детали
    ///</summary>
    [Designer(typeof(MaintenanceDirectiveParametersControlDesigner))]
    public partial class MaintenanceDirectiveParametersControl : UserControl
    {
        #region Fields

        private DateTime _effDate = DateTimeExtend.GetCASMinDateTime();
        private MaintenanceDirective _currentDirective;
	    private IList<IDirective> _bindedItems; 

        #endregion

        #region Constructor

        #region MaintenanceDirectiveParametersControl()
        ///<summary>
        /// конструктор по умолчанию без параметров
        ///</summary>
        public MaintenanceDirectiveParametersControl()
        {
            InitializeComponent();
        }

        #endregion

        #region public MaintenanceDirectiveParametersControl(MaintenanceDirective maintenanceDirective) : this()

        /// <summary>
        /// Создает элемент управления, использующийся для редактирования отдельной информации Compliance/Performance
        /// </summary>
        /// <param name="maintenanceDirective">Работа агрегата</param>
        public MaintenanceDirectiveParametersControl(MaintenanceDirective maintenanceDirective)
            : this()
        {
            _currentDirective = maintenanceDirective;
            UpdateInformation();
        }

		#endregion

		#endregion

		#region Propeties

		#region public void Updateparameters(MaintenanceDirective maintenanceDirective, IList<IDirective> bindedItems)

		public void Updateparameters(MaintenanceDirective maintenanceDirective, IList<IDirective> bindedItems)
		{
			_currentDirective = maintenanceDirective;
			_bindedItems = bindedItems;
			UpdateInformation();
		}

		#endregion

		#region public bool isClosed { get; set; }
		///<summary>
		///</summary>
		private bool IsClosed { get; set; }

        #endregion

        #region public DateTime EffectiveDate
        /// <summary>
        /// Дата начала использования текущей директивы
        /// </summary>
        public DateTime EffectiveDate
        {
            set { _effDate = value; }
        }

        #endregion

        #endregion

        #region Methods

        #region private void SetTextBoxComponentsString()
        private void SetTextBoxComponentsString(IList<IDirective> bindedItems)
		{
	        if (_currentDirective.ItemRelations.IsAllRelationWith(SmartCoreType.ComponentDirective))
	        {
				var bindedDetailDirectives = bindedItems.Cast<ComponentDirective>().ToList();
				if (_currentDirective.ItemRelations.Count == 0)
					textBoxComponents.Text = "Select Items";
				else if (bindedDetailDirectives.Count(dd => dd.ParentComponent != null) == 0)
					textBoxComponents.Text = _currentDirective.ItemRelations.Count + " Items";
				else
				{
					var sb = new StringBuilder();
					var bindedDirectivesWithParent = bindedDetailDirectives.Where(dd => dd.ParentComponent != null);
					foreach (var directive in bindedDirectivesWithParent)
					{
						sb.Append($"P/N:{directive.ParentComponent.PartNumber} S/N: {directive.ParentComponent.SerialNumber} Desc. {directive.ParentComponent.Description}; ");
					}

					var nullComponentCount = bindedDetailDirectives.Count(dd => dd.ParentComponent == null);
					if (nullComponentCount > 0)
						sb.Append($"and more {nullComponentCount} Items");

					textBoxComponents.Text = sb.ToString();
				}
			}
	        else
	        {
				textBoxComponents.Text = " Incorrect";
			}
	        
        }
        #endregion

        #region public bool GetChangeStatus(MaintenanceDirective directive)

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        public bool GetChangeStatus(MaintenanceDirective directive)
        {
            double manHours;
            double elapsed;
            double cost;
            if (!CheckDoubleValue("Man Hours", textBoxManHours.Text, out manHours))
                return false;
            if (!CheckDoubleValue("Elapsed", textBoxElapsed.Text, out elapsed))
                return false;
            if (!CheckDoubleValue("Cost", textBoxCost.Text, out cost))
                return false;

            MaintenanceDirectiveThreshold threshold = new MaintenanceDirectiveThreshold();
            threshold.EffectiveDate = _effDate;
            threshold.FirstPerformanceSinceNew = new Lifelength(lifelengthViewer_SinceNew.Lifelength);
            threshold.FirstPerformanceSinceEffectiveDate = new Lifelength(lifelengthViewer_SinceEffDate.Lifelength);
            threshold.FirstNotification = new Lifelength(lifelengthViewer_FirstNotify.Lifelength);
            threshold.RepeatInterval = new Lifelength(lifelengthViewer_Repeat.Lifelength);
            threshold.RepeatNotification = new Lifelength(lifelengthViewer_RepeatNotify.Lifelength);
            threshold.FirstPerformanceConditionType = radio_FirstWhicheverFirst.Checked
                                                      ? ThresholdConditionType.WhicheverFirst
                                                      : ThresholdConditionType.WhicheverLater;
            threshold.RepeatPerformanceConditionType = radio_RepeatWhicheverFirst.Checked
                                                      ? ThresholdConditionType.WhicheverFirst
                                                      : ThresholdConditionType.WhicheverLater; 

            try
            {
                if (directive.MaintenanceCheck == null && lookupComboboxMaintenanceCheck.SelectedItemId > 0 ||
                    directive.MaintenanceCheck != null && lookupComboboxMaintenanceCheck.SelectedItemId != directive.MaintenanceCheck.ItemId ||
                    directive.ManHours != manHours ||
                    directive.Elapsed != elapsed ||
                    directive.Cost != cost ||
					directive.NDTType.ItemId != ((NDTType)comboBoxNdt.SelectedItem).ItemId ||
					directive.Skill.ItemId != ((Skill)comboBoxSkill.SelectedItem).ItemId ||
                    directive.IsClosed != IsClosed ||
                    directive.Threshold.ToString() != threshold.ToString() ||
                    directive.WorkType != comboBoxWorkType.SelectedItem ||
					directive.KitsApplicable != checkBoxKitsApplicable.Checked)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
                return true;
            }
            return false;
        }

        #endregion

        #region private void UpdateInformation()

        private void UpdateInformation()
        {
            if(_currentDirective == null)
                return;

	        var relationType = ItemRelationHelper.ConvertBLItemRelationToUIITem(
				_currentDirective.WorkItemsRelationType,
				_currentDirective.IsFirst.HasValue && _currentDirective.IsFirst.Value);
			SetControlsEnable(relationType != WorkItemsRelationTypeUI.ThisItemDependsFromAnother);

			_effDate = _currentDirective.Threshold.EffectiveDate;

            GlobalObjects.PerformanceCalculator.GetNextPerformance(_currentDirective);

			comboBoxNdt.Items.Clear();
			comboBoxNdt.Items.AddRange(NDTType.Items.ToArray());
	        comboBoxNdt.SelectedItem = _currentDirective.NDTType;

			comboBoxSkill.Items.Clear();
	        comboBoxSkill.Items.AddRange(Skill.Items.ToArray());
	        comboBoxSkill.SelectedItem = _currentDirective.Skill;

			comboBoxWorkType.Items.Clear();
            var directiveTypes = MaintenanceDirectiveTaskType.Items;
            foreach (MaintenanceDirectiveTaskType t in directiveTypes)
            {
                comboBoxWorkType.Items.Add(t);
                if (_currentDirective.WorkType.ItemId == t.ItemId)
                    comboBoxWorkType.SelectedItem = t;
            }
            if (comboBoxWorkType.SelectedItem == null)
                comboBoxWorkType.SelectedIndex = 0;

            if (_currentDirective.Condition == ConditionState.Overdue)
                imageLinkLabelStatus.Status = Statuses.NotSatisfactory;
            if (_currentDirective.Condition == ConditionState.Notify)
                imageLinkLabelStatus.Status = Statuses.Notify;
            if (_currentDirective.Condition == ConditionState.Satisfactory)
                imageLinkLabelStatus.Status = Statuses.Satisfactory;
            if (Math.Abs(_currentDirective.ManHours) > 0.000001)
                textBoxManHours.Text = _currentDirective.ManHours.ToString(CultureInfo.InvariantCulture);
            if (Math.Abs(_currentDirective.Elapsed) > 0.000001)
                textBoxElapsed.Text = _currentDirective.Elapsed.ToString(CultureInfo.InvariantCulture);
            if (Math.Abs(_currentDirective.Cost) > 0.000001)
                textBoxCost.Text = _currentDirective.Cost.ToString(CultureInfo.InvariantCulture);

			checkBoxKitsApplicable.CheckedChanged -= checkBoxKitsApplicable_CheckedChanged;
			checkBoxClose.Checked = _currentDirective.IsClosed;

	        checkBoxKitsApplicable.Checked = _currentDirective.KitsApplicable;
		    linkLabelEditKit.Enabled = _currentDirective.KitsApplicable;
		    textBoxKitRequired.Enabled = _currentDirective.KitsApplicable;
			textBoxKitRequired.Text = _currentDirective.KitsApplicable ? $"{_currentDirective.Kits.Count} kits" : "N/A";
			checkBoxKitsApplicable.CheckedChanged += checkBoxKitsApplicable_CheckedChanged;

			//MPD Item может иметь привязку либо на MaintenanceCheck либо на Компоненты
			if (_currentDirective.MaintenanceCheck != null)
            {
                linkLabelEditComponents.Enabled = false;
                lookupComboboxMaintenanceCheck.Enabled = true;
            }
            else if(_currentDirective.ItemRelations.Count > 0)
            {
                linkLabelEditComponents.Enabled = true;
                lookupComboboxMaintenanceCheck.Enabled = false;
            }

            SetTextBoxComponentsString(_bindedItems);

            #region MaintenanceCheck

            lookupComboboxMaintenanceCheck.SelectedIndexChanged -= LookupComboboxMaintenanceCheckSelectedIndexChanged;

            if (_currentDirective.ParentBaseComponent.BaseComponentType == BaseComponentType.Frame)
            {
                var maintenanceScreenDisplayerText =
                    $"{_currentDirective.ParentBaseComponent.GetParentAircraftRegNumber()} Maintenance Program";
				var pareAircraft = GlobalObjects.AircraftsCore.GetAircraftById(_currentDirective.ParentBaseComponent.ParentAircraftId);//TODO:(Evgenii Babak) пересмотреть использование ParentAircrafId здесь
				lookupComboboxMaintenanceCheck.SetItemsScreenControl<MaintenanceScreen>(new[] { pareAircraft }, 
																						   maintenanceScreenDisplayerText);
                lookupComboboxMaintenanceCheck.LoadObjectsFunc = GlobalObjects.MaintenanceCore.GetMaintenanceCheck;
                lookupComboboxMaintenanceCheck.FilterParam1 = pareAircraft;
                lookupComboboxMaintenanceCheck.SelectedItemId = _currentDirective.MaintenanceCheck != null
                    ? _currentDirective.MaintenanceCheck.ItemId
                    : -1;
                lookupComboboxMaintenanceCheck.UpdateInformation();
            }

            lookupComboboxMaintenanceCheck.SelectedIndexChanged += LookupComboboxMaintenanceCheckSelectedIndexChanged;

			#endregion

            if (_currentDirective.Threshold != null)
            {
                lifelengthViewer_SinceNew.Lifelength = _currentDirective.Threshold.FirstPerformanceSinceNew;
                lifelengthViewer_SinceEffDate.Lifelength = _currentDirective.Threshold.FirstPerformanceSinceEffectiveDate;
                lifelengthViewer_FirstNotify.Lifelength = _currentDirective.Threshold.FirstNotification;
                lifelengthViewer_Repeat.Lifelength = _currentDirective.Threshold.RepeatInterval;
                lifelengthViewer_RepeatNotify.Lifelength = _currentDirective.Threshold.RepeatNotification;
                if (_currentDirective.Threshold.FirstPerformanceConditionType == ThresholdConditionType.WhicheverFirst)
                    radio_FirstWhicheverFirst.Checked = true;
                else radio_FirstWhicheverLast.Checked = true;
                if (_currentDirective.Threshold.RepeatPerformanceConditionType == ThresholdConditionType.WhicheverFirst)
                    radio_RepeatWhicheverFirst.Checked = true;
                else radio_RepeatWhicheverLast.Checked = true;
            }
        }

        #endregion

        #region public void ApplyChanges(MaintenanceDirective directive))

        /// <summary>
        /// Применение изменений
        /// </summary>
        /// <returns></returns>
        public void ApplyChanges(MaintenanceDirective directive)
        {
            double manHours;
            double elapsed;
            double cost;
            if (!CheckDoubleValue("Man Hours", textBoxManHours.Text, out manHours))
                return;
            if (!CheckDoubleValue("Elapsed", textBoxElapsed.Text, out elapsed))
                return;
            if (!CheckDoubleValue("Cost", textBoxCost.Text, out cost))
                return;
            directive.MaintenanceCheck = lookupComboboxMaintenanceCheck.SelectedItem as MaintenanceCheck;
            directive.WorkType = ((MaintenanceDirectiveTaskType)comboBoxWorkType.SelectedItem);
            directive.ManHours = manHours;
            directive.Elapsed = elapsed;
            directive.Cost = cost;
            directive.IsClosed = IsClosed;
			directive.NDTType = comboBoxNdt.SelectedItem as NDTType;
			directive.Skill = comboBoxSkill.SelectedItem as Skill;
	        directive.KitsApplicable = checkBoxKitsApplicable.Checked;

	        if (!checkBoxKitsApplicable.Checked && directive.Kits.Count > 0)
	        {
				foreach (var kit in directive.Kits)
					kit.IsDeleted = true;
			}

	        var threshold = new MaintenanceDirectiveThreshold
	        {
		        EffectiveDate = _effDate,
		        FirstPerformanceSinceNew = new Lifelength(lifelengthViewer_SinceNew.Lifelength),
		        FirstPerformanceSinceEffectiveDate = new Lifelength(lifelengthViewer_SinceEffDate.Lifelength),
		        FirstNotification = new Lifelength(lifelengthViewer_FirstNotify.Lifelength),
		        RepeatInterval = new Lifelength(lifelengthViewer_Repeat.Lifelength),
		        RepeatNotification = new Lifelength(lifelengthViewer_RepeatNotify.Lifelength),
		        FirstPerformanceConditionType = radio_FirstWhicheverFirst.Checked
			        ? ThresholdConditionType.WhicheverFirst
			        : ThresholdConditionType.WhicheverLater,
		        RepeatPerformanceConditionType = radio_RepeatWhicheverFirst.Checked
			        ? ThresholdConditionType.WhicheverFirst
			        : ThresholdConditionType.WhicheverLater
	        };
	        if (directive.Threshold.ToString() != threshold.ToString())
                directive.Threshold = threshold;
        }

        #endregion

        #region private bool CheckDoubleValue(string paramName, string checkedString, out double value)

        /// <summary>
        /// Проверяет значение ManHours
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="checkedString">Строковое значение value</param>
        /// <param name="value">Значение ManHours</param>
        /// <returns>Возвращает true если значение можно преобразовать в тип double, иначе возвращает false</returns>
        private bool CheckDoubleValue(string paramName, string checkedString, out double value)
        {
            if (checkedString == "")
            {
                value = 0;
                return true;
            }
            if (double.TryParse(checkedString, NumberStyles.Float, new NumberFormatInfo(), out value) == false)
            {
                MessageBox.Show(paramName + ". Invalid value", (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        #endregion

        #region public void ClearFields()

        /// <summary>
        /// Очищает поля
        /// </summary>
        public void ClearFields()
        {
            _currentDirective.Kits.Clear();

            textBoxComponents.Text = "";
            comboBoxWorkType.SelectedItem = null;
            imageLinkLabelStatus.Status = Statuses.NotActive;
            textBoxManHours.Text = "";
            textBoxElapsed.Text = "";
            textBoxCost.Text = "";
            textBoxKitRequired.Text = "";
            checkBoxClose.Checked = false;
	        comboBoxNdt.SelectedItem = null;
            lifelengthViewer_SinceNew.Lifelength = Lifelength.Null;
            lifelengthViewer_SinceEffDate.Lifelength = Lifelength.Null;
            lifelengthViewer_FirstNotify.Lifelength = Lifelength.Null;
            lifelengthViewer_Repeat.Lifelength = Lifelength.Null;
            lifelengthViewer_RepeatNotify.Lifelength = Lifelength.Null;
            radio_FirstWhicheverFirst.Checked = true;
            radio_RepeatWhicheverFirst.Checked = true;
        }

        #endregion

        #region public void CancelAsync()
        ///<summary>
        /// запрашивает отмену асинхронной операции
        ///</summary>
        public void CancelAsync()
        {
            if(lookupComboboxMaintenanceCheck != null)
                lookupComboboxMaintenanceCheck.CancelAsync();
        }
        #endregion

        #region private void LinkLabelEditKitLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        private void LinkLabelEditKitLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KitForm dlg = new KitForm(_currentDirective);
            if (dlg.ShowDialog() == DialogResult.OK)
                textBoxKitRequired.Text = _currentDirective.Kits.Count + " kits";
        }
        #endregion

        #region private void CheckBoxCloseCheckedChanged(object sender, EventArgs e)
        private void CheckBoxCloseCheckedChanged(object sender, EventArgs e)
        {
            IsClosed = checkBoxClose.Checked;
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

        #region private void LinkLabelEditComponentsLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        private void LinkLabelEditComponentsLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var dlg = new MaintenanceDirectiveBindComponentForm(_currentDirective);
            dlg.ShowDialog();

	        if (dlg.DialogResult == DialogResult.OK)
				InvokeDataWereChanged(null);
        }
		#endregion

		#region private void SetControlsEnable(bool enable)

		private void SetControlsEnable(bool enable)
	    {
		    radio_FirstWhicheverLast.Enabled = enable;
		    radio_FirstWhicheverFirst.Enabled = enable;
		    lifelengthViewer_SinceEffDate.Enabled = enable;
		    lifelengthViewer_SinceNew.Enabled = enable;
		    lifelengthViewer_FirstNotify.Enabled = enable;
			

			radio_RepeatWhicheverLast.Enabled = enable;
		    lifelengthViewer_RepeatNotify.Enabled = enable;
		    radio_RepeatWhicheverFirst.Enabled = enable;
		    lifelengthViewer_Repeat.Enabled = enable;
	    }

	    #endregion


		#endregion

		private void checkBoxKitsApplicable_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxKitsApplicable.Checked == false)
			{
				if (_currentDirective.Kits.Count > 0)
				{
					var res = MessageBox.Show("If you press OK, all kits for this directive will be deleted, after you click on save button", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
					if (res == DialogResult.OK)
					{
						linkLabelEditKit.Enabled = false;
						textBoxKitRequired.Enabled = false;
						textBoxKitRequired.Text = "N/A";
					}
					else
					{
						//TODO:(Evgenii Babak) сделать так чтобы это присвоение не возбуждало новое событие
						checkBoxKitsApplicable.Checked = true;					
					}
				}
				else
				{
					linkLabelEditKit.Enabled = false;
					textBoxKitRequired.Enabled = false;
					textBoxKitRequired.Text = "N/A";
				}
			}
			else
			{
				linkLabelEditKit.Enabled = true;
				textBoxKitRequired.Enabled = true;
				textBoxKitRequired.Text = $"{_currentDirective.Kits.Count} kits";
			}
			
		}

		#region Events

		///<summary>
		///</summary>
		public event EventHandler DataWereChanged;

		///<summary>
		///</summary>
		///<param name="e"></param>
		public void InvokeDataWereChanged(EventArgs e)
		{
			EventHandler handler = DataWereChanged;
			if (handler != null) handler(this, e);
		}

		#endregion
	}

	#region internal class MaintenanceDirectiveParametersControlDesigner : ControlDesigner

	internal class MaintenanceDirectiveParametersControlDesigner : ControlDesigner
    {
        protected override void PostFilterProperties(IDictionary properties)
        {
            base.PostFilterProperties(properties);
            properties.Remove("CurrentDirective");
            properties.Remove("Interval");
            properties.Remove("IsClosed");
        }
    }
    #endregion
}
