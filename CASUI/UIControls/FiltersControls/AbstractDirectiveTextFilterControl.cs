using System;
using System.Windows.Forms;
using CAS.Core.Types.ReportFilters;
//using CAS.UI.Appearance;

namespace CAS.UI.UIControls.FiltersControls
{
    public abstract partial class AbstractDirectiveTextFilterControl : UserControl, IFilterControl
    {
        #region Fileds

        #endregion

        #region Constructor

        /// <summary>
        /// Создается элемент отображения фильтра по Title
        /// </summary>
        public AbstractDirectiveTextFilterControl()
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
            get { return checkBoxSerialFilterAppliance.Checked; }
            set
            {
                checkBoxSerialFilterAppliance.Checked = value;
                textBoxSerialMask.ReadOnly = !value;
            }
        }

        #endregion

        #region public string Mask

        /// <summary>
        /// Возвращает или устанавливает маску фильтра
        /// </summary>
        public string Mask
        {
            get
            {
                return textBoxSerialMask.Text;
            }
            set
            {
                textBoxSerialMask.Text = value;
            }
        }

        #endregion

        #region public bool SerialFilterAppliance

        /// <summary>
        /// Возвращает или устанавливает значение, показывающее применимость SerialFilter...честно ен знал что написать *crazy*
        /// </summary>
        public bool SerialFilterAppliance
        {
            get
            {
                return checkBoxSerialFilterAppliance.Checked;
            }
            set
            {
                checkBoxSerialFilterAppliance.Checked = value;
            }
        }

        #endregion

        #region public protected FilterTitle
        /// <summary>
        /// Заголовок фильтра
        /// </summary>
        protected string FilterTitle
        {
            get { return checkBoxSerialFilterAppliance.Text; }
            set { checkBoxSerialFilterAppliance.Text = value; }
        }

        #endregion

        #endregion

        #region Methods

        #region public abstract IFilter GetFilter();

        ///<summary>
        /// Создание фильтра по заданному состоянию
        ///</summary>
        ///<returns>Созданный фильтр</returns>
        public abstract IFilter GetFilter();

        #endregion

        #region public abstract void SetFilterParameters(IFilter filter);

        /// <summary>
        /// Задаются параметры фильтра
        /// </summary>
        /// <param name="filter">Источник параметров фильтра</param>
        public abstract void SetFilterParameters(IFilter filter);

        #endregion

        #region protected override void OnLoad(EventArgs e)

        ///<summary>
        ///Raises the <see cref="E:System.Windows.Forms.UserControl.Load"></see> event.
        ///</summary>
        ///
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //Css.OrdinaryText.Adjust(this);
            this.ForeColor = System.Drawing.Color.FromArgb(122, 122, 122);
            this.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            checkBoxSerialFilterAppliance.FlatStyle = FlatStyle.Flat;
            checkBoxSerialFilterAppliance.ForeColor = System.Drawing.Color.FromArgb(62, 155, 246);
            textBoxSerialMask.BorderStyle = BorderStyle.FixedSingle;
        }

        #endregion

        #region public void ClearFilter()
        /// <summary>
        /// Происходит отчистка фильтра
        /// </summary>
        public void ClearFilter()
        {
            checkBoxSerialFilterAppliance.Checked = true;
            textBoxSerialMask.Text = "*";
        }
        #endregion

        #endregion
    }
}
