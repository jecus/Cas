using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.UIControls.Auxiliary;
using CAS.Core.Types.ATLBs;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{

    /// <summary>
    /// Компонент редактирует данные о залитом масле для одного агрегата
    /// </summary>
    public partial class ComponentOilControl : CAS.UI.Interfaces.EditObjectControl
    {

        #region public ComponentOilCondition OilCondition
        /// <summary>
        /// Агрегат с которым связан контрол
        /// </summary>
        public ComponentOilCondition OilCondition
        {
            get { return AttachedObject as ComponentOilCondition; }
            set { AttachedObject = value; }
        }
        #endregion

        /*
         * Конструктор
         */

        #region public ComponentOilControl()
        /// <summary>
        /// Контрол редактирует данные о залитом масле для одного агрегата
        /// </summary>
        public ComponentOilControl()
        {
            InitializeComponent();
        }
        #endregion

        /*
         * Перегружаемые методы
         */

        #region public override void ApplyChanges()
        /// <summary>
        /// Применить к объекту сделанные изменения на контроле. 
        /// Если не все данные удовлетворяют формату ввода (например при вводе чисел), свойства объекта не изменяются, возвращается false
        /// Вызов base.ApplyChanges() обязателен
        /// </summary>
        /// <returns></returns>
        public override void ApplyChanges()
        {
            if (OilCondition != null)
            {
                OilCondition.Detail = textDetail.Text;
                OilCondition.OilAdded = UsefulMethods.StringToDouble(textAdded.Text);
                OilCondition.OnBoard = UsefulMethods.StringToDouble(textOnBoard.Text);
            }
            //
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
            if (OilCondition != null)
            {
                textDetail.Text = OilCondition.Detail;
                textAdded.Text = OilCondition.OilAdded.ToString();
                textOnBoard.Text = OilCondition.OnBoard.ToString();
            }
            else
            {
                textDetail.Text = textAdded.Text = textOnBoard.Text = "";
            }
            EndUpdate();
        }
        #endregion

        #region public override bool CheckData()
        /// <summary>
        /// Проверяет введенные данные.
        /// Если какое-либо поле не подходит по формату, следует сразу кидать MessageBox, ставить курсор в необходимое поле и возвращать false в качестве результата метода
        /// </summary>
        /// <returns></returns>
        public override bool CheckData()
        {
            if (!ValidateDoubleTextBox(textAdded)) return false;
            if (!ValidateDoubleTextBox(textOnBoard)) return false;

            //
            return true;
        }
        #endregion

        /*
         * Реализация
         */

        #region private bool ValidateDoubleTextBox(TextBox textBox)
        /// <summary>
        /// Проверяет правильность ввода дробного числа
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns></returns>
        private bool ValidateDoubleTextBox(TextBox textBox)
        {
            double d;
            if (!UsefulMethods.StringToDouble(textBox.Text, out d))
            {

                //
                SimpleBalloon.Show(textBox, ToolTipIcon.Warning, "Incorrect numeric format", "Enter valid number"); 
                return false;
            }

            //
            return true;
        }
        #endregion


    }
}

