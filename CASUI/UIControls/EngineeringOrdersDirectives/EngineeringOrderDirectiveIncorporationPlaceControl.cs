using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.Types.Directives;
using CAS.UI.Appearance;

namespace CAS.UI.UIControls.EngineeringOrdersDirectives
{
    /// <summary>
    /// Элемент управления для отображения информации о месте проведения инженерного задания
    /// </summary>
    public class EngineeringOrderDirectiveIncorporationPlaceControl : Control
    {

        #region Fields

        private readonly EngineeringOrderDirective directive;

        private readonly Label labelShop = new Label();
        private readonly Label labelHangar = new Label();
        private readonly Label labelOther = new Label();

        private readonly TextBox textBoxShop = new TextBox();
        private readonly RadioButton radioButtonYes = new RadioButton();
        private readonly RadioButton radioButtonNo = new RadioButton();
        private readonly RadioButton radioButtonUnknown = new RadioButton();
        private readonly TextBox textBoxOther = new TextBox();

        private const int MARGIN = 10;
        private const int LABEL_WIDTH = 150;
        private const int LABEL_HEIGHT = 25;
        private const int TEXTBOX_WIDTH = 350;
        private const int RADIO_BUTTON_WIDTH = 90;
        private const int HEIGHT_INTERVAL = 20;
        
        #endregion

        #region Constructors

        #region public EngineeringOrderDirectiveIncorporationPlaceControl()

        /// <summary>
        /// Создает элемент управления для отображения информации о месте проведения инженерного задания
        /// </summary>
        public EngineeringOrderDirectiveIncorporationPlaceControl()
        {
            InitializeComponents();
        }

        #endregion

        #region public EngineeringOrderDirectiveIncorporationPlaceControl(EngineeringOrderDirective directive)

        /// <summary>
        /// Создает элемент управления для отображения информации о месте проведения инженерного задания
        /// </summary>
        /// <param name="directive">Отображаемая директива</param>
        public EngineeringOrderDirectiveIncorporationPlaceControl(EngineeringOrderDirective directive)
        {
            this.directive = directive;
            InitializeComponents();
        }

        #endregion

        #endregion

        #region Properties

        #region public Hangar Hangar

        /// <summary>
        /// Возвращает значение свойства Hangar
        /// </summary>
        public Hangar Hangar
        {
            get
            {
                if (radioButtonYes.Checked)
                    return Hangar.Yes;
                else if (radioButtonNo.Checked)
                    return Hangar.No;
                else
                    return Hangar.Unknown;
            }
            set
            {
                if (value == Hangar.Yes)
                    radioButtonYes.Checked = true;
                else if (value == Hangar.No)
                    radioButtonNo.Checked = true;
                else
                    radioButtonUnknown.Checked = true;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region private void InitializeComponents()

        private void InitializeComponents()
        {
            // 
            // labelShop
            // 
            labelShop.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelShop.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelShop.Location = new Point(MARGIN, MARGIN);
            labelShop.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelShop.Text = "Shop";
            // 
            // textBoxShop
            // 
            textBoxShop.BackColor = Color.White;
            textBoxShop.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxShop.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxShop.Location = new Point(labelShop.Right, MARGIN);
            textBoxShop.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxShop.MaxLength = 150;
            // 
            // labelHangar
            // 
            labelHangar.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelHangar.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelHangar.Location = new Point(MARGIN, labelShop.Bottom + HEIGHT_INTERVAL);
            labelHangar.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelHangar.Text = "Hangar";
            //
            // radioButtonYes
            //
            radioButtonYes.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonYes.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonYes.Location = new Point(labelHangar.Right, labelShop.Bottom + HEIGHT_INTERVAL);
            radioButtonYes.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonYes.Text = "Yes";
            //
            // radioButtonNo
            //
            radioButtonNo.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonNo.Location = new Point(radioButtonYes.Right, labelShop.Bottom + HEIGHT_INTERVAL);
            radioButtonNo.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonNo.Text = "No";
            //
            // radioButtonUnknown
            //
            radioButtonUnknown.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonUnknown.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonUnknown.Location = new Point(radioButtonNo.Right, labelShop.Bottom + HEIGHT_INTERVAL);
            radioButtonUnknown.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonUnknown.Text = "Unknown";
            // 
            // labelOther
            // 
            labelOther.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelOther.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelOther.Location = new Point(MARGIN, labelHangar.Bottom + HEIGHT_INTERVAL);
            labelOther.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelOther.Text = "Other";
            //
            // textBoxOther
            //
            textBoxOther.BackColor = Color.White;
            textBoxOther.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxOther.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxOther.Location = new Point(MARGIN, labelOther.Bottom);
            textBoxOther.Multiline = true;
            textBoxOther.Size = new Size(LABEL_WIDTH + TEXTBOX_WIDTH, 3 * LABEL_HEIGHT);
            textBoxOther.ScrollBars = ScrollBars.Vertical;
            textBoxOther.MaxLength = 150;

            BackColor = Css.CommonAppearance.Colors.BackColor;
            Size = new Size(MARGIN + LABEL_WIDTH + TEXTBOX_WIDTH, 2 * MARGIN + 6 * LABEL_HEIGHT + 2 * HEIGHT_INTERVAL);
            Controls.Add(labelShop);
            Controls.Add(textBoxShop);
            Controls.Add(labelHangar);
            Controls.Add(radioButtonYes);
            Controls.Add(radioButtonNo);
            Controls.Add(radioButtonUnknown);
            Controls.Add(labelOther);
            Controls.Add(textBoxOther);
        }

        #endregion

        #region public bool GetChangeStatus(bool directiveExist)

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <param name="directiveExist">Показывает, существует ли уже директива или нет</param>
        /// <returns></returns>
        public bool GetChangeStatus(bool directiveExist)
        {
            if (directiveExist)
                return (textBoxShop.Text != directive.Shop ||
                        Hangar != directive.Hangar ||
                        textBoxOther.Text != directive.Other);
            else
                return (textBoxShop.Text != "" ||
                        Hangar != Hangar.Unknown ||
                        textBoxOther.Text != "");
        }

        #endregion

        #region public void UpdateInformation()

        /// <summary>
        /// Заполняет поля для редактирования директивы
        /// </summary>
        public void UpdateInformation()
        {
            if (directive != null)
                UpdateInformation(directive);
        }

        #endregion

        #region public void UpdateInformation(EngineeringOrderDirective sourceDirective)

        /// <summary>
        /// 3аполняет поля для редактирования директивы
        /// </summary>
        /// <param name="sourceDirective"></param>
        public void UpdateInformation(EngineeringOrderDirective sourceDirective)
        {
            if (sourceDirective == null)
                throw new ArgumentNullException("sourceDirective");
            textBoxShop.Text = sourceDirective.Shop;
            Hangar = sourceDirective.Hangar;
            textBoxOther.Text = sourceDirective.Other;
            
            bool permission = directive.HasPermission(Users.CurrentUser, DataEvent.Update);

            textBoxShop.ReadOnly = !permission;
            radioButtonYes.Enabled = permission;
            radioButtonNo.Enabled = permission;
            radioButtonUnknown.Enabled = permission;
            textBoxOther.ReadOnly = !permission;
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        public void SaveData()
        {
            if (directive != null)
            {
                SaveData(directive);
            }
        }

        #endregion

        #region public void SaveData(EngineeringOrderDirective destinationDirective)

        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        /// <param name="destinationDirective">Директива</param>
        public void SaveData(EngineeringOrderDirective destinationDirective)
        {
            if (destinationDirective.Shop != textBoxShop.Text)
                destinationDirective.Shop = textBoxShop.Text;
            if (destinationDirective.Hangar != Hangar)
                destinationDirective.Hangar = Hangar;
            if (destinationDirective.Other != textBoxOther.Text)
                destinationDirective.Other = textBoxOther.Text;
        }
        #endregion

        #region public void ClearFields()

        /// <summary>
        /// Очищает все поля
        /// </summary>
        public void ClearFields()
        {
            textBoxShop.Text = "";
            Hangar = Hangar.Unknown;
            textBoxOther.Text = "";
        }

        #endregion

        #endregion

    }
}
