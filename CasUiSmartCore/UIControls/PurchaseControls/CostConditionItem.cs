using System;
using System.Windows.Forms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls
{
    ///<summary>
    /// ЭУ для отображени одного ценового состояния в закупочном акте
    ///</summary>
    public partial class CostConditionItem : UserControl
    {
        #region Fields

        #endregion

        #region Properties

        #region public String MainText
        ///<summary>
        /// Основной текст(над чекбоксом)
        ///</summary>
        public String MainText
        {
            set { labelCostCondition.Text = value; }
        }
        #endregion

        #region public bool Checked
        ///<summary>
        /// Возвращает, выбрано ли данное ценовое состояние
        ///</summary>
        public bool Checked
        {
            get { return checkBoxCost.Checked; }
        }
        #endregion

        #region public double Quantity
        ///<summary>
        /// возвращает количество КИТов по данному ценовому состоянию
        ///</summary>
        public double Quantity
        {
            get { return (int) numericUpDownQuantity.Value; }
            set { numericUpDownQuantity.Value = (decimal)value; }
        }
        #endregion

        #region public DetailStatus CostCondition

        ///<summary>
        /// возвращает тип ценового состояния
        ///</summary>
        public ComponentStatus CostCondition { get; set; }

        #endregion

        #region public double Cost
        ///<summary>
        /// возвращает цену данного КИТа по данному ценовому состоянию
        ///</summary>
        public double Cost
        {
            get { return (double) numericUpDownCost.Value; }
            set { numericUpDownCost.Value = (decimal) value; }
        }
        #endregion

        #endregion

        #region Constructors
        ///<summary>
        ///</summary>
        public CostConditionItem()
        {
            InitializeComponent();
        }

        ///<summary>
        ///</summary>
        public CostConditionItem(PurchaseRequestRecord request)
        {
            InitializeComponent();

            UpdateInformation(request);
        }
        #endregion

        #region Methods

        private void UpdateInformation(PurchaseRequestRecord request)
        {
            if(request != null)
            {
                checkBoxCost.Checked = true;
                checkBoxCost.Visible = false;
            }
        }

        private void CheckBoxCostCheckedChanged(object sender, EventArgs e)
        {
            numericUpDownQuantity.Enabled = checkBoxCost.Checked;
            numericUpDownCost.Enabled = checkBoxCost.Checked;
        }
        #endregion
    }
}
