using System;
using System.ComponentModel;
using CAS.UI.Interfaces;
using SmartCore.Entities.Collections;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    ///<summary>
    /// ЭУ для редактирования информации об уровне топлива
    ///</summary>
    public partial class FuelControlItem : EditObjectControl
    {
        /*
         * Своиства
         */
        #region public double RemainBefore

        /// <summary>
        /// 
        /// </summary>
        public double RemainBefore
        {
            get { return (double)numericUpDownRemain.Value; }
        }
        #endregion

        #region public double Refuel

        /// <summary>
        /// 
        /// </summary>
        public double Refuel
        {
            get { return (double)numericUpDownCorrenction.Value; }
        }
        #endregion

        #region public double OnBoard

        /// <summary>
        /// 
        /// </summary>
        public double OnBoard
        {
            get { return (double)numericUpDownOnBoard.Value; }
        }
        #endregion

        #region public double Spent

        /// <summary>
        /// 
        /// </summary>
        public double Spent
        {
            get { return (double)numericUpDownSpent.Value; }
        }
        #endregion

        #region public double RemainAfter

        /// <summary>
        /// 
        /// </summary>
        public double RemainAfter
        {
            get { return (double)numericUpDownRemainAfter.Value; }
        }
        #endregion

        #region public FuelTankCondition FuelCondition

        /// <summary>
        /// Агрегат с которым связан контрол
        /// </summary>
        public FuelTankCondition FuelCondition
        {
            get { return AttachedObject as FuelTankCondition; }
            set{AttachedObject = value;}
        }
        #endregion

        #region public FuelControlItem()
        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        public FuelControlItem()
        {
            InitializeComponent();
        }
        #endregion

        #region public FuelControlItem(FuelTankCondition cond) : this()
        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        public FuelControlItem(FuelTankCondition cond) : this()
        {
            AttachedObject = cond;
        }
        #endregion

        #region public override void ApplyChanges()
        /// <summary>
        /// Применить к объекту сделанные изменения на контроле. 
        /// Если не все данные удовлетворяют формату ввода (например при вводе чисел), свойства объекта не изменяются, возвращается false
        /// Вызов base.ApplyChanges() обязателен
        /// </summary>
        /// <returns></returns>
        public override void ApplyChanges()
        {
            if (FuelCondition != null)
            {
                FuelCondition.Tank = textBoxTitle.Text;
                FuelCondition.Remaining = (double)numericUpDownRemain.Value;
                FuelCondition.OnBoard = (double )numericUpDownOnBoard.Value;
                FuelCondition.Correction = (double )numericUpDownCorrenction.Value;
                FuelCondition.Spent = (double) numericUpDownSpent.Value;
                FuelCondition.RemainingAfter = (double) numericUpDownRemainAfter.Value;
            }

            base.ApplyChanges();
        }
        #endregion

        #region public override void FillControls()
        /// <summary>
        /// Обновляет значения полей
        /// </summary>
        public override void FillControls()
        {

            BeginUpdate();

            if (FuelCondition != null)
            {
                textBoxTitle.Text = FuelCondition.Tank;
                numericUpDownRemain.Value = (decimal)FuelCondition.Remaining;
                numericUpDownOnBoard.Value = (decimal)FuelCondition.OnBoard;
                numericUpDownCorrenction.Value = (decimal)FuelCondition.Correction;
                numericUpDownSpent.Value = (decimal)FuelCondition.Spent;
                numericUpDownRemainAfter.Value = (decimal)FuelCondition.RemainingAfter;
            }
            EndUpdate();
        }
        #endregion

        #region public bool ShowHeaders

        /// <summary>
        /// Отображать ли заголовки
        /// </summary>
        public bool ShowHeaders
        {
            get { return label17.Visible; }
            set
            {
                label17.Visible = value;
                label18.Visible = value;
                label19.Visible = value;
                labelRemainAfter.Visible = value;
                labelSpent.Visible = value;
            }
        }

        #endregion

        #region private void SetNumericValue(System.Windows.Forms.NumericUpDown nud, decimal value, bool valueChangetEventEnabled = true, EventHandler valueChangedEvent = null)
        private void SetNumericValue(System.Windows.Forms.NumericUpDown nud, decimal value, 
                                     bool valueChangetEventEnabled = true, 
                                     EventHandler valueChangedEvent = null)
        {
            if (nud == null) return;
            if (!valueChangetEventEnabled && valueChangedEvent == null)return;

            if (!valueChangetEventEnabled)
            {
                nud.ValueChanged -= valueChangedEvent;
            }

            if (value < nud.Minimum) value = nud.Minimum;
            if (value > nud.Maximum) value = nud.Maximum;
            
            nud.Value = value;

            if (!valueChangetEventEnabled)
            {
                nud.ValueChanged += valueChangedEvent;
            }
        }
        #endregion

        #region private void NumericUpDownRemainValueChanged(object sender, System.EventArgs e)
        private void NumericUpDownRemainValueChanged(object sender, EventArgs e)
        {
            InvokeBeforRemainChanget();

            decimal value = (decimal) (RemainBefore + Refuel);
            SetNumericValue(numericUpDownOnBoard, value);
        }
        #endregion

        #region private void NumericUpDownCorrenctionValueChanged(object sender, System.EventArgs e)
        private void NumericUpDownCorrenctionValueChanged(object sender, EventArgs e)
        {
            InvokeRefuelChanget();

            decimal value = (decimal)(RemainBefore + Refuel);
            SetNumericValue(numericUpDownOnBoard, value);
        }
        #endregion

        #region private void NumericUpDownOnBoardValueChanged(object sender, System.EventArgs e)
        private void NumericUpDownOnBoardValueChanged(object sender, EventArgs e)
        {
            InvokeOnBoardChanget();

            decimal value = (decimal)(OnBoard - Spent);
            SetNumericValue(numericUpDownRemainAfter, value, true, NumericUpDownRemainAfterValueChanged);
        }
        #endregion

        #region private void NumericUpDownSpentValueChanged(object sender, System.EventArgs e)
        private void NumericUpDownSpentValueChanged(object sender, EventArgs e)
        {
            InvokeSpentChanget();

            decimal value = (decimal)(OnBoard - Spent);
            SetNumericValue(numericUpDownRemainAfter, value, true, NumericUpDownRemainAfterValueChanged);
        }
        #endregion

        #region private void NumericUpDownRemainAfterValueChanged(object sender, System.EventArgs e)
        private void NumericUpDownRemainAfterValueChanged(object sender, EventArgs e)
        {
            InvokeAfterRemainChanget();
            decimal value = (decimal)(OnBoard - RemainAfter);
            SetNumericValue(numericUpDownSpent, value, true, NumericUpDownSpentValueChanged);
        }
        #endregion

        #region Events

        ///<summary>
        /// Возникает при изменении остатка топлива перед полетом
        ///</summary>
        [Category("Fuel data")]
        [Description("Возникает при изменении остатка топлива перед полетом")]
        public event EventHandler BeforeRemainChanget;

        ///<summary>
        /// Возникает при изменении значения долитого топлива
        ///</summary>
        [Category("Fuel data")]
        [Description("Возникает при изменении значения долитого топлива")]
        public event EventHandler RefuelChanget;

        ///<summary>
        /// Возникает при изменении значения топлива на борту
        ///</summary>
        [Category("Fuel data")]
        [Description("Возникает при изменении значения топлива на борту")]
        public event EventHandler OnBoardChanget;

        ///<summary>
        /// Возникает при изменении значения израсходованного топлива
        ///</summary>
        [Category("Fuel data")]
        [Description("Возникает при изменении значения израсходованного топлива")]
        public event EventHandler SpentChanget;
        
        ///<summary>
        /// Возникает при изменении остатка после посадки
        ///</summary>
        [Category("Fuel data")]
        [Description("Возникает при изменении остатка после посадки")]
        public event EventHandler AfterRemainChanget;

        ///<summary>
        /// Сигнализирует об изменении остатка топлива перед полетом
        ///</summary>
        private void InvokeBeforRemainChanget()
        {
            EventHandler handler = BeforeRemainChanget;
            if (handler != null) handler(this,EventArgs.Empty);
        }

        ///<summary>
        /// Сигнализирует об изменении значения долитого топлива
        ///</summary>
        private void InvokeRefuelChanget()
        {
            EventHandler handler = RefuelChanget;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        ///<summary>
        /// Сигнализирует об изменении топлива на борту
        ///</summary>
        private void InvokeOnBoardChanget()
        {
            EventHandler handler = OnBoardChanget;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        ///<summary>
        /// Сигнализирует об изменении значения израсходованного топлива
        ///</summary>
        private void InvokeSpentChanget()
        {
            EventHandler handler = SpentChanget;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        ///<summary>
        /// Сигнализирует об изменении остатка после посадки
        ///</summary>
        private void InvokeAfterRemainChanget()
        {
            EventHandler handler = AfterRemainChanget;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        #endregion
    }
}
