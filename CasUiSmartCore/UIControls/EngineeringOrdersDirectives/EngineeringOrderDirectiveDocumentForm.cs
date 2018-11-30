using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Types.Directives;
using CAS.UI.Appearance;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.BiWeekliesReportsControls;

namespace CAS.UI.UIControls.EngineeringOrdersDirectives
{
    /// <summary>
    /// Форма для добавления/редактирования документов <see cref="EngineeringOrderDirective"/>
    /// </summary>
    public class EngineeringOrderDirectiveDocumentForm : Form
    {

        #region Fields

        private readonly List<Label> labels = new List<Label>();
        private readonly List<TextBox> textBoxs = new List<TextBox>();
        private readonly Button buttonOK = new Button();
        private readonly Button buttonCancel = new Button();

        private readonly ScreenMode mode;
        private List<string> row = new List<string>();

        private const int MARGIN = 10;
        private const int LABEL_WIDTH = 150;
        private const int LABEL_HEIGHT = 25;
        private const int TEXTBOX_WIDTH = 250;
        private const int HEIGHT_INTERVAL = 20;
        private const int BUTTON_WIDTH = 100;
        
        #endregion

        #region Constructors

        #region public EngineeringOrderDirectiveDocumentForm(string[] fields)

        /// <summary>
        /// Создает форму для добавления/редактирования документов <see cref="EngineeringOrderDirective"/>
        /// </summary>
        /// <param name="fields">Поля</param>
        public EngineeringOrderDirectiveDocumentForm(string[] fields)
        {
            mode = ScreenMode.Add;
            this.mode = mode;
            InitializeComponents(fields);
        }

        #endregion

        #region public EngineeringOrderDirectiveDocumentForm(string[] fields, List<string> row, ScreenMode mode)

        /// <summary>
        /// Создает форму для добавления/редактирования документов <see cref="EngineeringOrderDirective"/>
        /// </summary>
        /// <param name="fields">Поля</param>
        /// <param name="row">Редактируемая строка</param>
        /// <param name="mode">Режим окна</param>
        public EngineeringOrderDirectiveDocumentForm(string[] fields, List<string> row, ScreenMode mode)
        {
            this.mode = mode;
            InitializeComponents(fields);
            for (int i = 0; i < fields.Length; i++)
                textBoxs[i].Text = row[i];
        }

        #endregion

        #endregion

        #region Properties

        #region public List<string> Row

        /// <summary>
        /// Возвращает конечную строку
        /// </summary>
        public List<string> Row
        {
            get
            {
                return row;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region private void InitializeComponents(string[] fields)

        private void InitializeComponents(string[] fields)
        {
            for (int i = 0; i < fields.Length; i++)
            {
                Label label = new Label();
                TextBox textBox = new TextBox();

                if (i == 0)
                {
                    label.Location = new Point(MARGIN, MARGIN);
                    textBox.Location = new Point(MARGIN + LABEL_WIDTH, MARGIN);
                }
                else
                {
                    label.Location = new Point(MARGIN, labels[i - 1].Bottom + HEIGHT_INTERVAL);
                    textBox.Location = new Point(MARGIN + LABEL_WIDTH, labels[i - 1].Bottom + HEIGHT_INTERVAL);
                }
                //
                // label
                //
                label.Font = Css.OrdinaryText.Fonts.RegularFont;
                label.ForeColor = Css.OrdinaryText.Colors.ForeColor;
                label.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
                label.Text = fields[i];
                label.TextAlign = ContentAlignment.MiddleLeft;
                labels.Add(label);
                //
                // textBox
                //
                textBox.BackColor = Color.White;
                textBox.Font = Css.OrdinaryText.Fonts.RegularFont;
                textBox.ForeColor = Css.OrdinaryText.Colors.ForeColor;
                textBox.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
                textBox.MaxLength = 50;
                textBoxs.Add(textBox);
            }
            //
            // buttonOK
            //
            buttonOK.Font = Css.OrdinaryText.Fonts.RegularFont;
            buttonOK.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            buttonOK.Size = new Size(BUTTON_WIDTH, LABEL_HEIGHT);
            buttonOK.Location = new Point((LABEL_WIDTH + TEXTBOX_WIDTH + 2 * MARGIN) / 2 - buttonOK.Width - 5, labels[labels.Count - 1].Bottom + HEIGHT_INTERVAL);
            buttonOK.Text = "OK";
            buttonOK.Click += buttonOK_Click;
            //
            // buttonCancel
            //
            buttonCancel.Font = Css.OrdinaryText.Fonts.RegularFont;
            buttonCancel.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            buttonCancel.Size = new Size(BUTTON_WIDTH, LABEL_HEIGHT);
            buttonCancel.Location = new Point((LABEL_WIDTH + TEXTBOX_WIDTH + 2 * MARGIN) / 2 + 5, labels[labels.Count - 1].Bottom + HEIGHT_INTERVAL);
            buttonCancel.Text = "Cancel";
            buttonCancel.Click += buttonCancel_Click;
            if (mode == ScreenMode.Add)
                Text = "Add Document";
            else if (mode == ScreenMode.Edit)
                Text = "Edit Document";
            else
                Text = "View Document";

            AcceptButton = buttonOK;
            CancelButton = buttonCancel;
            MaximizeBox = false;
            MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            BackColor = Css.CommonAppearance.Colors.BackColor;
            Controls.AddRange(labels.ToArray());
            Controls.AddRange(textBoxs.ToArray());
            Controls.Add(buttonOK);
            Controls.Add(buttonCancel);
            ClientSize = new Size(2 * MARGIN + LABEL_WIDTH + TEXTBOX_WIDTH, (labels.Count + 1) * LABEL_HEIGHT + labels.Count * HEIGHT_INTERVAL + 2 * MARGIN);
        }

        #endregion

        #region private void buttonOK_Click(object sender, EventArgs e)

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (mode == ScreenMode.Edit)
            {
                for (int i = 0; i < textBoxs.Count; i++)
                    row.Add(textBoxs[i].Text);
                DialogResult = DialogResult.OK;
            }
            else if (mode == ScreenMode.Add)
            {
                row = new List<string>();
                for (int i = 0; i < textBoxs.Count; i++)
                    row.Add(textBoxs[i].Text);
                DialogResult = DialogResult.OK;
            }
            else 
                DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion

        #region private void buttonCancel_Click(object sender, EventArgs e)

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion

        #endregion

    }
}
