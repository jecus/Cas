using System;
using System.Windows.Forms;
using CAS.Core.Types.ReportFilters;
using CAS.UI.Appearance;
using CAS.UI.UIControls.FiltersControls;

namespace CAS.UI.UIControls.FiltersControls
{
    ///<summary>
    /// Класс, описывающий элемент отображения фильтра состояния
    ///</summary>
    public abstract partial class ConditionStatusControl : UserControl, IFilterControl
    {
        #region Constructors
        /// <summary>
        /// Создается элемегт отображения фильтра состояния
        /// </summary>
        public ConditionStatusControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

        #region public bool FilterAppliance
        ///<summary>
        /// Применимость фильтра
        ///</summary>
        public bool FilterAppliance
        {
            get
            {
                return !(checkBoxNotificationAppliance.Checked & checkBoxSatisfactoryAppliance.Checked & checkBoxUnsatisfactoryAppliance.Checked);
            }
            set
            {
            }
        }
        #endregion

        #region public bool SatisfactoryAppliance
        ///<summary>
        /// Параметр выборки состояния Satisfactory
        ///</summary>
        public bool SatisfactoryAppliance
        {
            get { return checkBoxSatisfactoryAppliance.Checked; }
            set { checkBoxSatisfactoryAppliance.Checked = value; }
        }
        #endregion

        #region public bool UnsatisfactoryAppliance
        ///<summary>
        /// Параметр выборки состояния Unsatisfactory
        ///</summary>
        public bool UnsatisfactoryAppliance
        {
            get { return checkBoxUnsatisfactoryAppliance.Checked; }
            set { checkBoxUnsatisfactoryAppliance.Checked = value; }
        }
        #endregion

        #region public bool NotificationAppliance
        ///<summary>
        /// Параметр выборки состояния Notification
        ///</summary>
        public bool NotificationAppliance
        {
            get { return checkBoxNotificationAppliance.Checked; }
            set { checkBoxNotificationAppliance.Checked = value; }
        }
        #endregion

        #endregion
        
        #region Methods
        ///<summary>
        /// Создание фильтра по заданному состоянию
        ///</summary>
        ///<returns>Созданный фильтр</returns>
        public abstract IFilter GetFilter();

        public abstract void SetFilterParameters(IFilter filter);
        
        ///<summary>
        ///Raises the <see cref="E:System.Windows.Forms.UserControl.Load"></see> event.
        ///</summary>
        ///
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Css.OrdinaryText.Adjust(this);
            groupBox1.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            groupBox1.FlatStyle = FlatStyle.Flat;
            checkBoxNotificationAppliance.FlatStyle = FlatStyle.Flat;
            checkBoxNotificationAppliance.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;

            checkBoxSatisfactoryAppliance.FlatStyle = FlatStyle.Flat;
            checkBoxSatisfactoryAppliance.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;

            checkBoxUnsatisfactoryAppliance.FlatStyle = FlatStyle.Flat;
            checkBoxUnsatisfactoryAppliance.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
        }
        #endregion

        #region public void ClearFilter()
        /// <summary>
        ///  Происходит отчистка фильтра
        /// </summary>
        public void ClearFilter()
        {
            checkBoxNotificationAppliance.Checked = true;
            checkBoxUnsatisfactoryAppliance.Checked = true;
            checkBoxSatisfactoryAppliance.Checked = true;
        }
        #endregion

    }
}