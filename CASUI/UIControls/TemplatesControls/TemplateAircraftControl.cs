using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.Types.Aircrafts;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;

namespace CAS.UI.UIControls.TemplatesControls
{
    /// <summary>
    /// Элемент управления для отображения общей информации о шаблонном ВС
    /// </summary>
    public class TemplateAircraftControl : PictureBox, IReference
    {

        #region Fields

        private const int HEIGHT_INTERVAL = 10;
        private const int WIDTH_INTERVAL = 600;
        private const int TEXT_BOX_HEIGHT = 25;
        private const int TEXT_BOX_WIDTH = 200;
        private const int LABEL_WIDTH = 220;
        private const int TOP_MARGIN = 20;
        private const int BOTTOM_MARGIN = 20;
        private TemplateAircraft currentAircraft;

        private readonly Label labelAircraftModel = new Label();
        private readonly Label labelAircraftTypeCertificateNumber = new Label();
        private readonly Label labelLineNumber = new Label();
        private readonly Label labelVariableNumber = new Label();
        //private readonly Label labelAmount = new Label();


        private readonly TextBox textBoxAircraftModel = new TextBox();
        private readonly TextBox textBoxAircraftTypeCertificateNumber = new TextBox();
        private readonly TextBox textBoxLineNumber = new TextBox();
        private readonly TextBox textBoxVariableNumber = new TextBox();
        //private readonly TextBox textBoxAmount = new TextBox();
        private IDisplayer displayer;
        private string displayerText;
        private IDisplayingEntity entity;
        private ReflectionTypes reflectionType;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения общей информации о шаблонном ВС
        /// </summary>
        /// <param name="currentAircraft">ВС</param>
        public TemplateAircraftControl(TemplateAircraft currentAircraft)
        {
            this.currentAircraft = currentAircraft;
            Size = new Size(WIDTH_INTERVAL + LABEL_WIDTH + TEXT_BOX_WIDTH, 2* TEXT_BOX_HEIGHT + HEIGHT_INTERVAL + TOP_MARGIN + BOTTOM_MARGIN);
            //
            // labelAircraftModel
            //
            labelAircraftModel.Location = new Point(0, TOP_MARGIN);
            labelAircraftModel.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelAircraftModel.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelAircraftModel.Size = new Size(LABEL_WIDTH, TEXT_BOX_HEIGHT);
            labelAircraftModel.Text = "Aircraft Model";
            labelAircraftModel.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxAircraftModel
            //
            textBoxAircraftModel.Location = new Point(LABEL_WIDTH, TOP_MARGIN);
            textBoxAircraftModel.BackColor = Color.White;
            textBoxAircraftModel.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxAircraftModel.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxAircraftModel.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // labelAircraftTypeCertificateNumber
            //
            labelAircraftTypeCertificateNumber.Location = new Point(0, labelAircraftModel.Bottom + HEIGHT_INTERVAL);
            labelAircraftTypeCertificateNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelAircraftTypeCertificateNumber.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelAircraftTypeCertificateNumber.Size = new Size(LABEL_WIDTH, TEXT_BOX_HEIGHT);
            labelAircraftTypeCertificateNumber.Text = "Aircraft Type Certificate No";
            labelAircraftTypeCertificateNumber.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxAircraftTypeCertificateNumber
            //
            textBoxAircraftTypeCertificateNumber.Location = new Point(LABEL_WIDTH, textBoxAircraftModel.Bottom + HEIGHT_INTERVAL);
            textBoxAircraftTypeCertificateNumber.BackColor = Color.White;
            textBoxAircraftTypeCertificateNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxAircraftTypeCertificateNumber.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxAircraftTypeCertificateNumber.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // labelLineNumber
            //
            labelLineNumber.Location = new Point(WIDTH_INTERVAL, TOP_MARGIN);
            labelLineNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelLineNumber.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelLineNumber.Size = new Size(LABEL_WIDTH, TEXT_BOX_HEIGHT);
            labelLineNumber.Text = "Line Number";
            labelLineNumber.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxLineNumber
            //
            textBoxLineNumber.Location = new Point(WIDTH_INTERVAL + LABEL_WIDTH, TOP_MARGIN);
            textBoxLineNumber.BackColor = Color.White;
            textBoxLineNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxLineNumber.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxLineNumber.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // labelVariableNumber
            //
            labelVariableNumber.Location = new Point(WIDTH_INTERVAL, labelAircraftModel.Bottom + HEIGHT_INTERVAL);
            labelVariableNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelVariableNumber.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelVariableNumber.Size = new Size(LABEL_WIDTH, TEXT_BOX_HEIGHT);
            labelVariableNumber.Text = "Variable Number";
            labelVariableNumber.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxVariableNumber
            //
            textBoxVariableNumber.Location = new Point(WIDTH_INTERVAL + LABEL_WIDTH, textBoxAircraftModel.Bottom + HEIGHT_INTERVAL);
            textBoxVariableNumber.BackColor = Color.White;
            textBoxVariableNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxVariableNumber.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxVariableNumber.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
/*            //
            // labelAmount
            //
            labelAmount.Location = new Point(0, labelAircraftModel.Bottom + HEIGHT_INTERVAL);
            labelAmount.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelAmount.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelAmount.Size = new Size(LABEL_WIDTH, TEXT_BOX_HEIGHT);
            labelAmount.Text = "Amount";
            labelAmount.TextAlign = ContentAlignment.MiddleLeft;*/
            
/*            //
            // textBoxAmount
            //
            textBoxAmount.Location = new Point(LABEL_WIDTH, textBoxAircraftModel.Bottom + HEIGHT_INTERVAL);
            textBoxAmount.BackColor = Color.White;
            textBoxAmount.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxAmount.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxAmount.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);*/




            Controls.Add(labelAircraftModel);
            Controls.Add(textBoxAircraftModel);
            Controls.Add(labelAircraftTypeCertificateNumber);
            Controls.Add(textBoxAircraftTypeCertificateNumber);
            Controls.Add(labelLineNumber);
            Controls.Add(textBoxLineNumber);
            Controls.Add(labelVariableNumber);
            Controls.Add(textBoxVariableNumber);
            //Controls.Add(labelAmount);
            //Controls.Add(textBoxAmount);
                        

            UpdateControl();

        }

        #endregion

        #region Properties

        #region public TemplateAircraft Aircraft

        /// <summary>
        /// Возвращает или устанавливает текущее шаблонное ВС
        /// </summary>
        public TemplateAircraft Aircraft
        {
            get
            {
                return currentAircraft;
            }
            set
            {
                currentAircraft = value;
                UpdateControl();
            }
        }

        #endregion

        #endregion

        #region Methods

        #region private void CheckPermission()

        /// <summary>
        /// Метод, проверяющий права доступа текущего пользователя и блокирует при необходимости текстовые поля
        /// </summary>
        private void CheckPermission()
        {
            bool permission = currentAircraft.HasPermission(Users.CurrentUser, DataEvent.Update);

            textBoxAircraftModel.ReadOnly = !permission;
            textBoxAircraftTypeCertificateNumber.ReadOnly = !permission;
            textBoxLineNumber.ReadOnly = !permission;
            textBoxVariableNumber.ReadOnly = !permission;
            //textBoxAmount.ReadOnly = !permission;
        }

        #endregion

        #region public bool GetChangeStatus()

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        public bool GetChangeStatus()
        {
            if (textBoxAircraftModel.Text != currentAircraft.Model ||
                textBoxAircraftTypeCertificateNumber.Text != currentAircraft.TypeCertificateNumber ||
                textBoxLineNumber.Text != currentAircraft.LineNumber ||
                textBoxVariableNumber.Text != currentAircraft.VariableNumber)// || textBoxAmount.Text != currentAircraft.Amount.ToString())
            {
                return true;
            }
            else
                return false;
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Сохранаяет данные текущего шаблонного ВС
        /// </summary>
        public void SaveData()
        {
            //int amount;
            //CheckAmount(out amount);
            if (textBoxAircraftModel.Text != currentAircraft.Model)
                currentAircraft.Model = textBoxAircraftModel.Text;
            if (textBoxAircraftTypeCertificateNumber.Text != currentAircraft.TypeCertificateNumber)
                currentAircraft.TypeCertificateNumber = textBoxAircraftTypeCertificateNumber.Text;
            if (textBoxLineNumber.Text != currentAircraft.LineNumber)
                currentAircraft.LineNumber = textBoxLineNumber.Text;
            if (textBoxVariableNumber.Text != currentAircraft.VariableNumber)
                currentAircraft.VariableNumber = textBoxVariableNumber.Text;
            //if (textBoxAmount.Text != currentAircraft.Amount.ToString())
             //   currentAircraft.Amount = amount;
        }

        #endregion

        #region private void UpdateControl()

        /// <summary>
        /// Обновляет информацию о текущем шаблонном ВС
        /// </summary>
        private void UpdateControl()
        {
            textBoxAircraftModel.Text = currentAircraft.Model;
            textBoxAircraftTypeCertificateNumber.Text = currentAircraft.TypeCertificateNumber;
            textBoxLineNumber.Text = currentAircraft.LineNumber;
            textBoxVariableNumber.Text = currentAircraft.VariableNumber;
         //   textBoxAmount.Text = currentAircraft.Amount.ToString();
            CheckPermission();
        }

        #endregion

/*        #region public bool CheckAmount()

        ///<summary>
        /// Проверяет значение Amount
        ///</summary>
        ///<returns>Возвращает true если значение можно преобразовать в тип int, иначе возвращает false</returns>
        public bool CheckAmount()
        {
            int amount;
            return CheckAmount(out amount);
        }

        #endregion
        */
        /*#region public bool CheckAmount(out int amount)

        ///<summary>
        /// Проверяет значение Amount
        ///</summary>
        /// <param name="amount">Значение Amount</param>
        ///<returns>Возвращает true если значение можно преобразовать в тип int, иначе возвращает false</returns>
        public bool CheckAmount(out int amount)
        {
            if (!int.TryParse(textBoxAmount.Text, out amount))
            {
                MessageBox.Show("Aircraft Amount. Invalid value", (string)new TermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        #endregion*/

        #region IReference Members

        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        public IDisplayer Displayer
        {
            get { return displayer; }
            set { displayer = value; }
        }

        /// <summary>
        /// Text of page's header that Reference lead to
        /// </summary>
        public string DisplayerText
        {
            get { return displayerText; }
            set { displayerText = value; }
        }

        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        /// <summary>
        /// Type of reflection
        /// </summary>
        public ReflectionTypes ReflectionType
        {
            get { return reflectionType; }
            set { reflectionType = value; }
        }

        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        #endregion

        #endregion

    }
}