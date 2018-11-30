using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.Core.Types;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.Appearance;
using CAS.UI.UIControls.Auxiliary;

namespace CAS.UI.UIControls.StoresControls
{
    /// <summary>
    /// Форма для снятия агрегата с ВС на склад
    /// </summary>
    public class PickOffDetailForm : Form
    {

        #region Fields

        private readonly AbstractDetail currentDetail;
        private Aircraft checkedAircraft;

        private readonly Label labelSummary = new Label();
        private readonly Label labelMoveToStore = new Label();
        private readonly FlowLayoutPanel panelStores = new FlowLayoutPanel();
        private readonly List<RadioButton> radioButtonsStores = new List<RadioButton>();
        private readonly Label labelDate = new Label();
        private readonly DateTimePicker dateTimePickerDate = new DateTimePicker();
        private readonly Label labelRemarks = new Label();
        private readonly TextBox textBoxRemarks = new TextBox();
        private readonly Button buttonOK = new Button();
        private readonly Button buttonCancel = new Button();
               

        private const int LEFT_MARGIN = 10;
        private const int TOP_MARGIN = 10;
        private const int INTERVAL = 10;
        private const int TEXTBOX_WIDTH = 250;
        private const int LABEL_WIDTH_LONG = 200;
        private const int LABEL_WIDTH_SHORT = 120;
        private const int LABEL_HEIGHT = 25;
        
        #endregion

        #region Constructor

        /// <summary>
        /// Создает форму для снятия агрегата с ВС на склад
        /// </summary>
        public PickOffDetailForm(AbstractDetail currentDetail)
        {
            this.currentDetail = currentDetail;
            //
            // labelSummary
            //
            labelSummary.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelSummary.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelSummary.Location = new Point(LEFT_MARGIN, 0);
            labelSummary.Size = new Size(LABEL_WIDTH_LONG, LABEL_HEIGHT*3);
            labelSummary.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelMoveToStore
            //
            labelMoveToStore.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelMoveToStore.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelMoveToStore.Location = new Point(LEFT_MARGIN, labelSummary.Bottom + INTERVAL);
            labelMoveToStore.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            labelMoveToStore.Text = "Move to store:";
            //
            // panelStores
            //
            panelStores.AutoSize = true;
            panelStores.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelStores.FlowDirection = FlowDirection.TopDown;
            panelStores.Location = new Point(LEFT_MARGIN, labelMoveToStore.Bottom);
            panelStores.SizeChanged += panelOperators_SizeChanged;
            //
            // labelDate
            //
            labelDate.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelDate.Size = new Size(LABEL_WIDTH_SHORT, LABEL_HEIGHT);
            labelDate.TextAlign = ContentAlignment.MiddleLeft;
            labelDate.Text = "Pick-off Date:";
            //
            // dateTimePickerDate
            //
            dateTimePickerDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            dateTimePickerDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            dateTimePickerDate.Size = new Size(LABEL_WIDTH_LONG, LABEL_HEIGHT);
            dateTimePickerDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerDate.CustomFormat = new TermsProvider()["DateFormat"].ToString();
            dateTimePickerDate.Value = DateTime.Today;
            //
            // labelRemarks
            //
            labelRemarks.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelRemarks.Size = new Size(LABEL_WIDTH_LONG, LABEL_HEIGHT);
            labelRemarks.TextAlign = ContentAlignment.MiddleLeft;
            labelRemarks.Text = "Remarks:";
            //
            // textBoxRemarks
            //
            textBoxRemarks.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxRemarks.Size = new Size(LABEL_WIDTH_LONG + LABEL_WIDTH_SHORT, LABEL_HEIGHT * 5);
            textBoxRemarks.Multiline = true;
            textBoxRemarks.ScrollBars = ScrollBars.Vertical;
            // 
            // buttonOK
            // 
            buttonOK.Font = Css.OrdinaryText.Fonts.RegularFont;
            buttonOK.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            buttonOK.Size = new Size(100, 25);
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Font = Css.OrdinaryText.Fonts.RegularFont;
            buttonCancel.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            buttonCancel.Size = new Size(100, 25);
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            
            CancelButton = buttonCancel;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            BackColor = Css.CommonAppearance.Colors.BackColor;
            Text = "Pick-off";

            Controls.Add(labelSummary);
            Controls.Add(labelMoveToStore);
            Controls.Add(panelStores);
            Controls.Add(labelDate);
            Controls.Add(dateTimePickerDate);
            Controls.Add(labelRemarks);
            Controls.Add(textBoxRemarks);
            Controls.Add(buttonOK);
            Controls.Add(buttonCancel);

            UpdateInformation();
        }

        #endregion

        #region Methods

        #region private void UpdateInformation()

        private void UpdateInformation()
        {
            labelSummary.Text = "P/N " + currentDetail.PartNumber + Environment.NewLine + "S/N " +
                                currentDetail.SerialNumber + Environment.NewLine + currentDetail.Remarks;
            
            List<Store> stores = ((Operator) currentDetail.Parent.Parent.Parent).Stores;

            for (int i = 0; i < stores.Count; i++)
            {
                RadioButton radioButton = new RadioButton();
                radioButton.AutoSize = true;
                radioButton.Font = Css.OrdinaryText.Fonts.RegularFont;
                radioButton.ForeColor = Css.OrdinaryText.Colors.ForeColor;
                radioButton.Text = stores[i].RegistrationNumber + ", " + stores[i].Model;
                radioButton.Tag = stores[i];
                radioButton.CheckedChanged += radioButton_CheckedChanged;
                radioButtonsStores.Add(radioButton);
                panelStores.Controls.Add(radioButton);
                if (i == 0)
                    radioButton.Checked = true;
            }

         /*   for (int i = 0; i < checkedAircraft.BaseDetails.Length; i++)
            {
                RadioButton radioButton = new RadioButton();
                radioButton.AutoSize = true;
                radioButton.Text = checkedAircraft.BaseDetails[i].ToString();
                radioButtonsBaseDetails.Add(radioButton);
                panelBaseDetails.Controls.Add(radioButton);
                if (i == 0)
                    radioButton.Checked = true;
            }*/
        }

        #endregion

        #region private void radioButton_CheckedChanged(object sender, EventArgs e)

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton) sender;
            if (radioButton.Checked)
                checkedAircraft = (Aircraft) radioButton.Tag;
        }

        #endregion


        #region private void buttonOK_Click(object sender, EventArgs e)

        private void buttonOK_Click(object sender, EventArgs e)
        {
            TransferRecord transferRecord = new TransferRecord();
            transferRecord.RecordsAddDate = dateTimePickerDate.Value;
            transferRecord.Description = textBoxRemarks.Text;

            if (currentDetail is Detail)
              ((Detail)currentDetail).MoveDetail(checkedAircraft, transferRecord);
            if (currentDetail is BaseDetail)
              ((BaseDetail)currentDetail).MoveBaseDetail(checkedAircraft, transferRecord);

            DialogResult = DialogResult.OK;
            Close();
        }

        #endregion

        #region private void buttonCancel_Click(object sender, EventArgs e)

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region private void panelOperators_SizeChanged(object sender, EventArgs e)

        private void panelOperators_SizeChanged(object sender, EventArgs e)
        {
            labelDate.Location = new Point(LEFT_MARGIN, panelStores.Bottom + INTERVAL);
            dateTimePickerDate.Location = new Point(labelDate.Right, panelStores.Bottom + INTERVAL);
            labelRemarks.Location = new Point(LEFT_MARGIN, labelDate.Bottom + INTERVAL);
            textBoxRemarks.Location = new Point(LEFT_MARGIN, labelRemarks.Bottom + INTERVAL);
            
            ClientSize = new Size(LEFT_MARGIN * 2 + LABEL_WIDTH_LONG + LABEL_WIDTH_SHORT, textBoxRemarks.Bottom + INTERVAL + buttonOK.Height + TOP_MARGIN);
            buttonCancel.Location = new Point(ClientSize.Width - buttonCancel.Width - INTERVAL, textBoxRemarks.Bottom + INTERVAL);
            buttonOK.Location = new Point(buttonCancel.Left - buttonOK.Width - INTERVAL, textBoxRemarks.Bottom + INTERVAL);
        }

        #endregion

        #endregion


    }
}
