using System.Windows.Forms;
using CAS.Core.Types.ReportFilters;

namespace CAS.UI.UIControls.FiltersControls
{
    /// <summary>
    /// Класс, описывающий элемент отображения фильтра по Serial number 
    /// </summary>
    public partial class SerialNoFilterControl : UserControl, IFilterControl
    {
        #region Fields
        #endregion

        #region Constructors

        #region public SerialNoFilterControl()
        /// <summary>
        /// Создается элемент отображения фильтра по Serial number 
        /// </summary>
        public SerialNoFilterControl()
        {
            InitializeComponent();
        }
        #endregion

        #endregion

        #region Properties
        ///<summary>
        /// Применимость фильтра
        ///</summary>
        public bool FilterAppliance
        {
            get { return checkBoxSerialFilterAppliance.Checked; }
            set 
            {
                checkBoxSerialFilterAppliance.Checked = value;
            }
        }

        /// <summary>
        /// Параметр применимости фильтра
        /// </summary>
        public CheckBox CheckBoxSerialFilterAppliance
        {
            get { return checkBoxSerialFilterAppliance; }
        }

        /// <summary>
        /// Поле ввода маски 
        /// </summary>
        public TextBox TextBoxSerialMask
        {
            get { return textBoxSerialMask; }
        }
        #endregion

        #region Methods

        ///<summary>
        /// Создание фильтра по заданному состоянию
        ///</summary>
        ///<returns>Созданный фильтр</returns>
        public IFilter GetFilter()
        {
            return new Core.Types.ReportFilters.SerialNumberFilter(textBoxSerialMask.Text);
        }

        public void SetFilterParameters(IFilter filter)
        {
            
        }

        private void checkBoxSerialFilterAppliance_CheckedChanged(object sender, System.EventArgs e)
        {
            if (FilterAppliance) textBoxSerialMask.Focus();
        }
        #endregion

        private void textBoxSerialMask_TextChanged(object sender, System.EventArgs e)
        {
            checkBoxSerialFilterAppliance.Checked = textBoxSerialMask.Text != "";
        }
    }
}