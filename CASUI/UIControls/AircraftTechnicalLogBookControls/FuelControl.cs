using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CAS.Core.Types.ATLBs;
using Auxiliary;
using CAS.UI.UIControls.Auxiliary;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{

    /// <summary>
    /// Объект позволяет задавать информацию о топливе 
    /// </summary>
    public partial class FuelControl : CAS.UI.Interfaces.EditObjectControl
    {

        #region public AircraftFlight Flight
        /// <summary>
        /// Полет, с которым связан контрол
        /// </summary>
        public AircraftFlight Flight
        {
            get { return AttachedObject as AircraftFlight; }
        }
        #endregion

        /*
         * Конструктор
         */

        #region public FuelControl()
        /// <summary>
        /// Контрол позволяет задавать информацию о топливе
        /// </summary>
        public FuelControl()
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

            // Сохраняем информацию о трех топливных баках
            if (Flight != null && Flight.FuelTankCollection != null && Flight.FuelTankCollection.Count >= 1)
                ApplyBundle(Flight.FuelTankCollection[0], textRemain1, textOnBoard1, textCorrection1);
            if (Flight != null && Flight.FuelTankCollection != null && Flight.FuelTankCollection.Count >= 2)
                ApplyBundle(Flight.FuelTankCollection[1], textRemain2, textOnBoard2, textCorrection2);
            if (Flight != null && Flight.FuelTankCollection != null && Flight.FuelTankCollection.Count >= 3)
                ApplyBundle(Flight.FuelTankCollection[2], textRemain3, textOnBoard3, textCorrection3);

            // Сохраняем общие параметры
            if (Flight != null && Flight.FuelTankCollection != null && Flight.FuelTankCollection.Count >= 1)
            {
                FuelTankCondition c = Flight.FuelTankCollection[0];
                c.CalculateUplift = UsefulMethods.StringToDouble(textCalculateUplift.Text);
                c.ActualUpliftLIT = UsefulMethods.StringToDouble(textActualUplift.Text);
                c.Discrepancy = UsefulMethods.StringToDouble(textDiscrepancy.Text);
                c.Density = UsefulMethods.StringToDouble(textDensity.Text);

                // Сохраняем эти значения на всякий случай во все остальные записи коллекции
                for (int i = 1; i < Flight.FuelTankCollection.Count; i++)
                {
                    Flight.FuelTankCollection[i].CalculateUplift = c.CalculateUplift;
                    Flight.FuelTankCollection[i].ActualUpliftLIT = c.ActualUpliftLIT;
                    Flight.FuelTankCollection[i].Discrepancy = c.Discrepancy;
                    Flight.FuelTankCollection[i].Density = c.Density;
                }
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
            // Первый топливный бак
            if (Flight != null && Flight.FuelTankCollection != null && Flight.FuelTankCollection.Count >= 1)
            {
                FillBundle(Flight.FuelTankCollection[0], labelTitle1, textRemain1, textOnBoard1, textCorrection1);
            }
            else
            {
                FillBundle(null, labelTitle1, textRemain1, textOnBoard1, textCorrection1);
            }

            // Второй топливный бак
            if (Flight != null && Flight.FuelTankCollection != null && Flight.FuelTankCollection.Count >= 2)
            {
                FillBundle(Flight.FuelTankCollection[1], labelTitle2, textRemain2, textOnBoard2, textCorrection2);
            }
            else
            {
                FillBundle(null, labelTitle2, textRemain2, textOnBoard2, textCorrection2);
            }

            // Третий топливный бак
            if (Flight != null && Flight.FuelTankCollection != null && Flight.FuelTankCollection.Count >= 3)
            {
                FillBundle(Flight.FuelTankCollection[2], labelTitle3, textRemain3, textOnBoard3, textCorrection3);
            }
            else
            {
                FillBundle(null, labelTitle3, textRemain3, textOnBoard3, textCorrection3);
            }

            // Суммарное количество топлива - Заполняется автоматически

            /*
            if (Flight != null && Flight.FuelTankCollection != null)
            {
                FillBundle(Flight.FuelTankCollection.TotalFuel, labelTitle4, textRemainTotal, textOnBoardTotal, textCorrectionTotal);
            }
            else
            {
                FillBundle(null, labelTitle4, textRemainTotal, textOnBoardTotal, textCorrectionTotal);
            }
            */

            // Дополнительные поля будем брать из первой записи
            if (Flight != null && Flight.FuelTankCollection != null && Flight.FuelTankCollection.Count >= 1)
            {
                textCalculateUplift.Text = Flight.FuelTankCollection[0].CalculateUplift.ToString();
                textActualUplift.Text = Flight.FuelTankCollection[0].ActualUpliftLIT.ToString();
                textDiscrepancy.Text = Flight.FuelTankCollection[0].Discrepancy.ToString();
                textDensity.Text = Flight.FuelTankCollection[0].Density.ToString();
            }
            else
            {
                textCalculateUplift.Text = textActualUplift.Text = textDiscrepancy.Text = textDensity.Text = "";
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

            // Первый топливный бак
            if (!CheckDoubleTextBox(textRemain1)) return false;
            if (!CheckDoubleTextBox(textOnBoard1)) return false;
            if (!CheckDoubleTextBox(textCorrection1)) return false;

            // Второй топливный бак
            if (!CheckDoubleTextBox(textRemain2)) return false;
            if (!CheckDoubleTextBox(textOnBoard2)) return false;
            if (!CheckDoubleTextBox(textCorrection2)) return false;

            // Третий топливный бак
            if (!CheckDoubleTextBox(textRemain3)) return false;
            if (!CheckDoubleTextBox(textOnBoard3)) return false;
            if (!CheckDoubleTextBox(textCorrection3)) return false;


            // Общаие данные
            if (!CheckDoubleTextBox(textCalculateUplift)) return false;
            if (!CheckDoubleTextBox(textActualUplift)) return false;
            if (!CheckDoubleTextBox(textDiscrepancy)) return false;
            if (!CheckDoubleTextBox(textDensity)) return false;

            //
            return true;
        }
        #endregion

        /*
         * Реализация
         */

        #region private void FillBundle(FuelTankCondition condition, Label labelTitle, TextBox textRemain, TextBox textOnBoard, TextBox textCorrection)
        /// <summary>
        /// Заполняет информацию о отпливных баках
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="labelTitle"></param>
        /// <param name="textRemain"></param>
        /// <param name="textOnBoard"></param>
        /// <param name="textCorrection"></param>
        private void FillBundle(FuelTankCondition condition, Label labelTitle, TextBox textRemain, TextBox textOnBoard, TextBox textCorrection)
        {
            if (condition != null)
            {
                labelTitle.Text = condition.Tank;
                textRemain.Text = condition.Remaining.ToString();
                textOnBoard.Text = condition.OnBoard.ToString();
                textCorrection.Text = condition.Correction.ToString();
            }
            else
            {
                labelTitle.Visible = textRemain.Visible = textOnBoard.Visible = textCorrection.Visible = false;
            }
        }
        #endregion

        #region private void ApplyBundle(FuelTankCondition condition, TextBox textRemain, TextBox textOnBoard, TextBox textCorrection)
        /// <summary> 
        /// Применяет введенные данные 
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="textRemain"></param>
        /// <param name="textOnBoard"></param>
        /// <param name="textCorrection"></param>
        private void ApplyBundle(FuelTankCondition condition, TextBox textRemain, TextBox textOnBoard, TextBox textCorrection)
        {
            if (condition != null)
            {
                condition.Remaining = UsefulMethods.StringToDouble(textRemain.Text);
                condition.OnBoard = UsefulMethods.StringToDouble(textOnBoard.Text);
                condition.Correction = UsefulMethods.StringToDouble(textCorrection.Text);
            }
        }
        #endregion

        #region private bool CheckDoubleTextBox(TextBox textBox)
        /// <summary>
        /// Проверяет правильность ввода дробного числа
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns></returns>
        private bool CheckDoubleTextBox(TextBox textBox)
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

        /*
         * События формы 
         */

        #region private void textRemain3_TextChanged(object sender, EventArgs e)
        /// <summary>
        /// Ввели изменения в один из трех полей Remain - Обновляем сумму Total
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textRemain3_TextChanged(object sender, EventArgs e)
        {
            double d1, d2, d3;
            if (UsefulMethods.StringToDouble(textRemain1.Text, out d1)
                && UsefulMethods.StringToDouble(textRemain2.Text, out d2)
                && UsefulMethods.StringToDouble(textRemain3.Text, out d3))
                textRemainTotal.Text = (d1 + d2 + d3).ToString();
            else
                textRemainTotal.Text = "";
        }
        #endregion

        #region private void textOnBoard3_TextChanged(object sender, EventArgs e)
        /// <summary>
        /// Ввели изменения в один из трех полей OnBoard - Обновляем сумму Total
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textOnBoard3_TextChanged(object sender, EventArgs e)
        {
            double d1, d2, d3;
            if (UsefulMethods.StringToDouble(textOnBoard1.Text, out d1)
                && UsefulMethods.StringToDouble(textOnBoard2.Text, out d2)
                && UsefulMethods.StringToDouble(textOnBoard3.Text, out d3))
                textOnBoardTotal.Text = (d1 + d2 + d3).ToString();
            else
                textOnBoardTotal.Text = "";
        }
        #endregion

        #region private void textCorrection3_TextChanged(object sender, EventArgs e)
        /// <summary> 
        /// Ввели изменения в один из трех полей Correction - Обновляем сумму Total
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textCorrection3_TextChanged(object sender, EventArgs e)
        {
            double d1, d2, d3;
            if (UsefulMethods.StringToDouble(textCorrection1.Text, out d1)
                && UsefulMethods.StringToDouble(textCorrection2.Text, out d2)
                && UsefulMethods.StringToDouble(textCorrection3.Text, out d3))
                textCorrectionTotal.Text = (d1 + d2 + d3).ToString();
            else
                textCorrectionTotal.Text = "";
        }
        #endregion


    }
}

