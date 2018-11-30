using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Types;
using CAS.Core.Types.Directives;
using CAS.UI.Appearance;

namespace CAS.UI.UIControls.EngineeringOrdersDirectives
{
    /// <summary>
    /// ‘орма дл€ редактировани€ названи€ документа <see cref="EngineeringOrderTask"/>
    /// </summary>
    public class EngineeringOrderDirectiveRenameDocumentForm : Form
    {

        #region Fields

        private readonly Document document;

        private readonly Label labelFileName = new Label();
        private readonly TextBox textBoxFileName = new TextBox();
        private readonly Button buttonOK = new Button();
        private readonly Button buttonCancel = new Button();

        private const int MARGIN = 20;

        #endregion


        /// <summary>
        /// —оздает форму дл€ редактировани€ названи€ документа <see cref="EngineeringOrderTask"/>
        /// </summary>
        public EngineeringOrderDirectiveRenameDocumentForm(Document document)
        {
            this.document = document;
            //
            // labelFileName
            //
            labelFileName.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelFileName.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelFileName.Location = new Point(MARGIN, MARGIN);
            labelFileName.Size = new Size(100, 25);
            labelFileName.Text = "File Name:";
            //
            // textBoxFileName
            //
            textBoxFileName.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxFileName.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxFileName.Location = new Point(labelFileName.Right, MARGIN);
            textBoxFileName.Size = new Size(250, 25);
            //
            // buttonOK
            //
            buttonOK.Font = Css.OrdinaryText.Fonts.RegularFont;
            buttonOK.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            buttonOK.Size = new Size(100, 25);
            buttonOK.Text = "OK";
            buttonOK.Click += buttonOK_Click;
            //
            // buttonCancel
            //
            buttonCancel.Font = Css.OrdinaryText.Fonts.RegularFont;
            buttonCancel.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            buttonCancel.Size = new Size(100, 25);
            buttonCancel.Text = "Cancel";
            buttonCancel.Click += buttonCancel_Click;

            AcceptButton = buttonOK;
            CancelButton = buttonCancel;
            MaximizeBox = false;
            MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            BackColor = Css.CommonAppearance.Colors.BackColor;
            Text = "Rename file";
            ClientSize = new Size(labelFileName.Width + textBoxFileName.Width + 2 * MARGIN, textBoxFileName.Height + buttonOK.Height + 2 * MARGIN + 10);
            buttonOK.Location = new Point((labelFileName.Width + textBoxFileName.Width + 2 * MARGIN) / 2 - buttonOK.Width - 5, textBoxFileName.Bottom + 10);
            buttonCancel.Location = new Point((labelFileName.Width + textBoxFileName.Width + 2 * MARGIN) / 2 + 5, textBoxFileName.Bottom + 10);
            Controls.Add(labelFileName);
            Controls.Add(textBoxFileName);
            Controls.Add(buttonOK);
            Controls.Add(buttonCancel);

            textBoxFileName.Text = document.FileName;
        }

        #region Methods

        #region private void buttonOK_Click(object sender, EventArgs e)

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (document.FileName != textBoxFileName.Text)
                document.FileName = textBoxFileName.Text;
            DialogResult = DialogResult.OK;
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
