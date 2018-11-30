using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.ComponentControls
{
    ///<summary>
    /// ЭУ для отображения информации о русурсе деталей и параметрах выполнения директив
    ///</summary>
    public partial class ComponentCompliancePerformanceListControl : UserControl
    {
		#region Fields
		//TODO:(Evgenii Babak) избавиться от локальной переменной _currentDetail. Деталь должна передаваться как параметр в методы.
		private Component _currentComponent;
        private List<ComponentCompliancePerformanceControl> addedPerformances 
            = new List<ComponentCompliancePerformanceControl>();
        private List<ComponentCompliancePerformanceControl> existPerformances
            = new List<ComponentCompliancePerformanceControl>();
        ///<summary>
        ///</summary>
        private ComponentComplianceLifeLimitControl _componentLifeLimit;
        #endregion

        #region Constructor

        #region public DetailCompliancePerformanceListControl()
        ///<summary>
        /// конструктор по умолчанию
        ///</summary>
        public ComponentCompliancePerformanceListControl()
        {
            InitializeComponent();
        }

        #endregion

        #region public DetailCompliancePerformanceListControl(object detail)

        /// <summary>
        /// Создает элемент управления, использующийся для редактирования Compliance/Performance
        /// </summary>
        public ComponentCompliancePerformanceListControl(Component component)
        {
            if (component != null)
            {
                _currentComponent = component;
                InitializeComponent();
                UpdateInformation();
            }
            else
            {
                InitializeComponent();
                ClearFields();
            }
        }

        #endregion

        #endregion

        #region Propeties

        #region public Detail CurrentDetail
        ///<summary>
        /// Задает редактируемую деталь
        ///</summary>
        public Component CurrentComponent
        {
            set
            {
                if (value != null)
                {
                    _currentComponent = value;
                    UpdateInformation();
                }
                else
                {
                    ClearFields();
                }
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
            foreach (ComponentCompliancePerformanceControl control in existPerformances)
                control.CancelAsync();
            foreach (ComponentCompliancePerformanceControl control in addedPerformances)
                control.CancelAsync();
        }
        #endregion

        #region public void ComponentManufactureDateChanged(DateTime manufactureDate)

        ///<summary>
        /// Изменяет данные при изменении даты производства компонента
        ///</summary>
        ///<param name="manufactureDate">Дата производства компонента</param>
        public void ComponentManufactureDateChanged(DateTime manufactureDate)
        {
            if( _componentLifeLimit == null)
                return;
            _componentLifeLimit.ManufactureDate = manufactureDate;
        }
        #endregion

        #region public void ChangeDirectivesTasksForComponentType(GoodsClass goodsClass)
        ///<summary>
        /// Изменяет доступные типы задач для переданного типа компонентов
        ///</summary>
        ///<param name="goodsClass">Тип компонента, для которого нужно определить типы задач</param>
        public void ChangeDirectivesTasksForComponentType(GoodsClass goodsClass)
        {
            foreach (Control c in flowLayoutPanelPerformances.Controls)
            {
                if (c is ComponentCompliancePerformanceControl)
                    ((ComponentCompliancePerformanceControl)c).UpdateWorkTypes(goodsClass);
                if (c is ComponentAddCompliancePerformanceControl)
                    ((ComponentAddCompliancePerformanceControl)c).UpdateWorkTypes(goodsClass);
            }       
        }
        #endregion

        #region public bool GetChangeStatus()
        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        public bool GetChangeStatus()
        {
            if (_componentLifeLimit != null && _componentLifeLimit.GetChangeStatus(_currentComponent))
                return true;
            return existPerformances.Any(item => item.GetChangeStatus()) || addedPerformances.Any(item => item.GetChangeStatus());
        }

		#endregion

		#region public void ApplyChanges(Detail detail)

		public void ApplyChanges(Component component)
		{
			_componentLifeLimit.ApplyChanges(component);

			foreach (var detailCompliancePerformanceControl in existPerformances)
				detailCompliancePerformanceControl.ApplyChanges();

			foreach (var detailAddCompliancePerformanceControl in addedPerformances)
				detailAddCompliancePerformanceControl.ApplyChanges(component);
		}

		#endregion

		#region public bool ValidateData(out string message)

		public bool ValidateData(out string message)
	    {
		    message = "";

		    foreach (var detailCompliancePerformanceControl in existPerformances)
		    {
			    if (detailCompliancePerformanceControl.ValidateData(out message) == false)
				    return false;
		    }

			foreach (var detailAddCompliancePerformanceControl in addedPerformances)
			{
				if (detailAddCompliancePerformanceControl.ValidateData(out message) == false)
					return false;
			}

		    return true;
	    }

	    #endregion

	    #region public void UpdateInformation()
        /// <summary>
        /// Обновляет данные
        /// </summary>
        public void UpdateInformation()
        {
            flowLayoutPanelPerformances.Controls.Clear();
            existPerformances.Clear();
            addedPerformances.Clear();
            List<ComponentDirective> detailDirectives = _currentComponent != null 
                                        ? new List<ComponentDirective>(_currentComponent.ComponentDirectives.ToArray()) 
                                        : new List<ComponentDirective>();

            _componentLifeLimit = new ComponentComplianceLifeLimitControl(_currentComponent);
            foreach (Control c in flowLayoutPanelPerformances.Controls)
            {
                if(c is ComponentCompliancePerformanceControl)
                {
                    ((ComponentCompliancePerformanceControl) c).Deleted -= CompliancePerformanceControlDeleted;
                }
            }
            flowLayoutPanelPerformances.Controls.Add(_componentLifeLimit);
            
            foreach (ComponentDirective t in detailDirectives)
            {
				//TODO:(Evgenii Babak) пересмотреть подход, мы не должны каждый раз создавать новые контролы (при обновлении DetailScreenNew) 
                ComponentCompliancePerformanceControl compliancePerformanceControl = new ComponentCompliancePerformanceControl(t);
                if (detailDirectives.Count == 1) compliancePerformanceControl.EnableExtendedControl = false;
                compliancePerformanceControl.Deleted += CompliancePerformanceControlDeleted;
                existPerformances.Add(compliancePerformanceControl);
                flowLayoutPanelPerformances.Controls.Add(compliancePerformanceControl);
            }
            if (_currentComponent != null) flowLayoutPanelPerformances.Controls.Add(linkLabelAddNew); 
        }
        #endregion

        #region public bool SaveData()

        /// <summary>
        /// Сохраняет данные
        /// </summary>
        /// <returns></returns>
        public void SaveData()
        {
	        ApplyChanges(_currentComponent);
            SaveData(_currentComponent);
        }

        #endregion

        #region public bool SaveData(AbstractDetail detail)

        /// <summary>
        /// Сохранаяет данные заданного агрегата
        /// </summary>
        /// <param name="componentгрегат</param>
        public void SaveData(Component component)
        {
			ApplyChanges(component);

            //Сохранение данных в detailLifeLimit
            _componentLifeLimit.SaveData(component);

	        foreach (var detailCompliancePerformanceControl in existPerformances)
		        detailCompliancePerformanceControl.SaveData();

            //Сохранение данных добавленных директив
            foreach (var detailAddCompliancePerformanceControl in addedPerformances)
				detailAddCompliancePerformanceControl.SaveData(component);
        }

        #endregion

        #region public void ClearFields()

        /// <summary>
        /// Очищает поля
        /// </summary>
        public void ClearFields()
        {
            flowLayoutPanelPerformances.Controls.Clear();
            existPerformances.Clear();
            addedPerformances.Clear();

            _componentLifeLimit = new ComponentComplianceLifeLimitControl(_currentComponent);
            flowLayoutPanelPerformances.Controls.Add(_componentLifeLimit);

            if (_currentComponent != null) flowLayoutPanelPerformances.Controls.Add(linkLabelAddNew);
		}

        #endregion

        #region private void CompliancePerformanceControlDeleted(object sender, EventArgs e)

        private void CompliancePerformanceControlDeleted(object sender, EventArgs e)
        {
            ComponentCompliancePerformanceControl control = (ComponentCompliancePerformanceControl)sender;
            ComponentDirective directive = control.ComponentDirective;
            existPerformances.Remove(control);
            flowLayoutPanelPerformances.Controls.Remove(control);
            try
            {
               // ((Detail)currentDetail).DetailDirectives.Remove(directive);
                GlobalObjects.ComponentCore.DeleteComponentDirective(directive);
                if(DirectiveRemoved != null) DirectiveRemoved(this,new EventArgs());
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while removing data", ex);
            }
        }

        #endregion

        #region private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ComponentCompliancePerformanceControl performance =
                new ComponentCompliancePerformanceControl(new ComponentDirective(_currentComponent));
            addedPerformances.Add(performance);
            flowLayoutPanelPerformances.Controls.Remove(linkLabelAddNew);
            flowLayoutPanelPerformances.Controls.Add(performance);
            flowLayoutPanelPerformances.Controls.Add(linkLabelAddNew);
        }

        #endregion

        #endregion

        #region Events

        ///<summary>
        ///</summary>
        public event EventHandler DirectiveRemoved;

        ///<summary>
        ///</summary>
        public event EventHandler LLPLifeLimitChanged;

        #endregion
    }
}
