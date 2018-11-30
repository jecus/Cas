using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.Types.Directives.Templates;
using CAS.UI.Appearance;

namespace CAS.UI.UIControls.DirectivesControls
{
    /// <summary>
    /// Класс для отображения атрибутов и дополнительной информации о директиве
    /// </summary>
    public class TemplateDirectiveAttributesControl : UserControl
    {

        #region Fields

        private const int MARGIN = 10;
        private const int CHECKBOX_WIDTH = 80;
        private const int LABEL_REMARK_WIDTH = 500;
        private const int LABEL_HEIGHT = 25;
        private const int HEIGHT_INTERVAL = 20;
        private const int WIDTH_INTERVAL = 600;
        

        private readonly TemplateBaseDetailDirective currentDirective;
        
        private readonly CheckBox checkBoxNDT;
        private readonly Label labelAttributes;
        private readonly Label labelNDT;

        #endregion

        #region Constructors

        #region public TemplateDirectiveAttributesControl()

        /// <summary>
        /// Создает объект для отображения атрибутов и дополнительной информации о шаблонной директиве
        /// </summary>
        public TemplateDirectiveAttributesControl()
        {
            AutoSize = true;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;

            labelAttributes = new Label();
            checkBoxNDT = new CheckBox();
            labelNDT = new Label();
            // 
            // labelAttributes
            // 
            labelAttributes.AutoSize = true;
            labelAttributes.Font = Css.SmallHeader.Fonts.RegularFont;
            labelAttributes.ForeColor = Css.SmallHeader.Colors.ForeColor;
            labelAttributes.Location = new Point(MARGIN, MARGIN);
            labelAttributes.Size = new Size(LABEL_REMARK_WIDTH, LABEL_HEIGHT);
            labelAttributes.Text = "Attributes";
            // 
            // checkBoxNDT
            // 
            checkBoxNDT.Cursor = Cursors.Hand;
            checkBoxNDT.FlatStyle = FlatStyle.Flat;
            checkBoxNDT.Font = Css.SimpleLink.Fonts.Font;
            checkBoxNDT.ForeColor = Css.SimpleLink.Colors.LinkColor;
            checkBoxNDT.Location = new Point(MARGIN, labelAttributes.Bottom + HEIGHT_INTERVAL);
            checkBoxNDT.Size = new Size(CHECKBOX_WIDTH, LABEL_HEIGHT);
            checkBoxNDT.Text = "NDT";
            // 
            // labelNDT
            // 
            labelNDT.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelNDT.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelNDT.Location = new Point(checkBoxNDT.Right, labelAttributes.Bottom + HEIGHT_INTERVAL);
            labelNDT.Size = new Size(LABEL_REMARK_WIDTH, LABEL_HEIGHT);
            labelNDT.Text = "The work requires Non Destructive Test equipment";
            labelNDT.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // DirectiveAttributesControl
            // 
            BackColor = Css.CommonAppearance.Colors.BackColor;
            
            Controls.Add(labelAttributes);
            Controls.Add(checkBoxNDT);
            Controls.Add(labelNDT);
        }

        #endregion

        #region public TemplateDirectiveAttributesControl(TemplateBaseDetailDirective currentDirective) : this()

        /// <summary>
        /// Создает объект для отображения атрибутов и дополнительной информации о шаблонной директиве
        /// </summary>
        /// <param name="currentDirective"></param>
        public TemplateDirectiveAttributesControl(TemplateBaseDetailDirective currentDirective) : this()
        {
            if (null == currentDirective)
                throw new ArgumentNullException("currentDirective", "Argument cannot be null");
            this.currentDirective = currentDirective;
        }

        #endregion

        #endregion

        #region Properties

        #region public bool Ndt

        /// <summary>
        /// NDT parameter
        /// </summary>
        public bool Ndt
        {
            get
            {
                return checkBoxNDT.Checked;
            }
            set
            {
                checkBoxNDT.Checked = value;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region public bool GetChangeStatus(bool directiveExist)

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <param name="directiveExist">Показывает, существует ли уже директива или нет</param>
        /// <returns></returns>
        public bool GetChangeStatus(bool directiveExist)
        {
            if (directiveExist)
                return (Ndt != currentDirective.NonDestructiveTest);
            else
                return Ndt;
        }

        #endregion

        #region public void UpdateInformation()

        /// <summary>
        /// 3аполняет поля для редактирования шаблонной директивы
        /// </summary>
        public void UpdateInformation()
        {
            Ndt = currentDirective.NonDestructiveTest;
            checkBoxNDT.Enabled = currentDirective.HasPermission(Users.CurrentUser, DataEvent.Update);
        }

        #endregion

        #region public void SaveData(TemplateBaseDetailDirective destinationDirective)

        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        public void SaveData(TemplateBaseDetailDirective destinationDirective)
        {
            if (destinationDirective == null) 
                throw new ArgumentNullException("destinationDirective");
            destinationDirective.NonDestructiveTest = Ndt;
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        public void SaveData()
        {
            if (currentDirective != null)
            {
                SaveData(currentDirective);
            }
        }

        #endregion

        #region public void ClearFields()

        /// <summary>
        /// Очищает все поля
        /// </summary>
        public void ClearFields()
        {
            Ndt = false;
        }

        #endregion
        
        #endregion
    }
}