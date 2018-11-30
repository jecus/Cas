using System.Windows.Forms;


using Auxiliary;
using CAS.UI.UIControls.Auxiliary;
using SmartCore.Entities.General.Atlbs;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{

    /// <summary>
    /// Позволяет задать давление в шинах
    /// </summary>
    public partial class TirePressureControl : Interfaces.EditObjectControl
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

        #region public TirePressureControl()
        /// <summary>
        /// Позвовляет задать давление в шинах
        /// </summary>
        public TirePressureControl()
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
            // Первая стойка шасси
            if (Flight != null && Flight.LandingGearConditions != null && Flight.LandingGearConditions.Count >= 1)
                ApplyBundle(Flight.LandingGearConditions[0], textN11, textN12);

            // Вторая стойка шасси
            if (Flight != null && Flight.LandingGearConditions != null && Flight.LandingGearConditions.Count >= 2)
                ApplyBundle(Flight.LandingGearConditions[1], textN21, textN22);
            // Третья стойка шасси
            if (Flight != null && Flight.LandingGearConditions != null && Flight.LandingGearConditions.Count >= 3)
                ApplyBundle(Flight.LandingGearConditions[2], textN31, textN32);

            
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

            // Первая стойка шасси
            if (Flight != null && Flight.LandingGearConditions != null && Flight.LandingGearConditions.Count >= 1)
            {
                FillBundle(Flight.LandingGearConditions[0], labelTitle1, textN11, textN12);
            }
            else
            {
                FillBundle(null, labelTitle1, textN11, textN12);
            }

            // Вторая стойка шасси 
            if (Flight != null && Flight.LandingGearConditions != null && Flight.LandingGearConditions.Count >= 2)
            {
                FillBundle(Flight.LandingGearConditions[1], labelTitle2, textN21, textN22);
            }
            else
            {
                FillBundle(null, labelTitle2, textN21, textN22);
            }

            // Третья стойка шасси
            if (Flight != null && Flight.LandingGearConditions != null && Flight.LandingGearConditions.Count >= 3)
            {
                FillBundle(Flight.LandingGearConditions[2], labelTitle3, textN31, textN32);
            }
            else
            {
                FillBundle(null, labelTitle3, textN31, textN32);
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

            // Проверяем введенные данные для все трех шасси
            if (Flight != null && Flight.LandingGearConditions != null && Flight.LandingGearConditions.Count >= 1)
                if (!ValidateBundle(null, labelTitle1, textN11, textN12)) return false;

            if (Flight != null && Flight.LandingGearConditions != null && Flight.LandingGearConditions.Count >= 2)
                if (!ValidateBundle(null, labelTitle2, textN21, textN22)) return false;

            if (Flight != null && Flight.LandingGearConditions != null && Flight.LandingGearConditions.Count >= 3)
                if (!ValidateBundle(null, labelTitle3, textN31, textN32)) return false;

            
            return true;
        }
        #endregion

        /*
         * Реализация
         */

        #region private void FillBundle(LandingGearCondition condition, Label labelTitle, TextBox textN1, TextBox textN2)

        /// <summary>
        /// Заполняет контролы для агрегата шасси
        /// </summary>
        /// <param name="labelTitle"></param>
        /// <param name="textN1"></param>
        /// <param name="textN2"></param>
        /// <param name="condition"></param>
        private void FillBundle(LandingGearCondition condition, Label labelTitle, TextBox textN1, TextBox textN2)
        {
            if (condition != null && condition.LandingGearId > 0)
            {
                labelTitle.Text = condition.LandingGear != null ? condition.LandingGear.LandingGear.ToString() : "";
                textN1.Text = condition.TirePressure1.ToString();
                textN2.Text = condition.TirePressure2.ToString();
            }
            else
            {
                labelTitle.Text = textN1.Text = textN2.Text = "";
            }
        }
        #endregion

        #region private bool ValidateBundle()
        /// <summary>
        /// Проверяет правильность введенных данных
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="labelTitle"></param>
        /// <param name="textN1"></param>
        /// <param name="textN2"></param>
        /// <returns></returns>
        private bool ValidateBundle(LandingGearCondition condition, Label labelTitle, TextBox textN1, TextBox textN2)
        {
            double d;
            if (!UsefulMethods.StringToDouble(textN1.Text, out d))
            {

                SimpleBalloon.Show(textN1, ToolTipIcon.Warning, "Incorrect numeric format", "Enter valid number"); 

                return false;
            }
            if (!UsefulMethods.StringToDouble(textN2.Text, out d))
            {

                SimpleBalloon.Show(textN2, ToolTipIcon.Warning, "Incorrect numeric format", "Enter valid number"); 

                return false;
            }

            //
            return true;
        }
        #endregion

        #region private void ApplyBundle(LandingGearCondition condition, TextBox textN1, TextBox textN2)
        /// <summary>
        /// Применяет введенные данные к стойкам шасси
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="textN1"></param>
        /// <param name="textN2"></param>
        private void ApplyBundle(LandingGearCondition condition, TextBox textN1, TextBox textN2)
        {
            if (condition.LandingGear != null)
            {
                condition.TirePressure1 = UsefulMethods.StringToDouble(textN1.Text);
                condition.TirePressure2 = UsefulMethods.StringToDouble(textN2.Text);
            }
        }
        #endregion

    }
}

