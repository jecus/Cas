using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UIControls.PersonnelControls
{
    ///<summary>
    ///</summary>
    [Designer(typeof(EmployeeCategoriesControlDesigner))]
    public partial class EmployeeCategoriesControl : UserControl, IReference
    {
        #region Fields

        private Specialist _currentItem;

        #endregion

        #region Constructors

        #region public EmployeeCategoriesControl()
        ///<summary>
        /// Создает объект для отображения информации о директиве
        ///</summary>
        public EmployeeCategoriesControl()
        {
            InitializeComponent();
        }

        #endregion

        #endregion

        #region Properties

        #region public Specialist CurrentItem
        ///<summary>
        ///Текущая директива
        ///</summary>
        public Specialist CurrentItem
        {
            set
            {
                _currentItem = value;
                if (_currentItem != null)
                {
                    UpdateInformation();
                }
            }
        }

        #endregion

        #endregion

        #region Methods

        #region public bool GetChangeStatus()
        ///<summary>
        ///Возвращает значение, показывающее были ли изменения в данном элементе управления
        ///</summary>
        ///<returns></returns>
        public bool GetChangeStatus()
        {
            return employeeCategoriesListControl.CheckData();
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

            if (!employeeCategoriesListControl.CheckData())
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
            if (_currentItem == null) 
                return;
            employeeCategoriesListControl.Employee = _currentItem;

            //backgroundWorker.RunWorkerAsync();
        }

        #endregion

        #region public void ApplyChanges()

        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        public void ApplyChanges()
        {
            employeeCategoriesListControl.ApplyChanges();
        }
        #endregion

        #region public void ClearFields()

        /// <summary>
        /// Очищает все поля
        /// </summary>
        public void ClearFields()
        {
            employeeCategoriesListControl.Employee = _currentItem;
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
        /////<summary>
        ///// Возникает во время изменения эффективной даты 
        /////</summary>
        //[Category("Flight data")]
        //[Description("Возникает во время изменения эффективной даты")]
        //public event DateChangedEventHandler EffDateChanget;

        /////<summary>
        ///// Сигнализирует об изменени эффективной даты
        /////</summary>
        /////<param name="e"></param>
        //private void InvokeEffDateChanget(DateTime e)
        //{
        //    DateChangedEventHandler handler = EffDateChanget;
        //    if (handler != null) handler(new DateChangedEventArgs(e));
        //}
        #endregion
    }

    #region internal class EmployeeCategoriesControlDesigner : ControlDesigner

    internal class EmployeeCategoriesControlDesigner : ControlDesigner
    {
        protected override void PostFilterProperties(IDictionary properties)
        {
            base.PostFilterProperties(properties);
            properties.Remove("CurrentItem");
        }
    }
    #endregion
}
