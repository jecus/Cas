using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Exceptions;
using CAS.Core.ProjectTerms;
using CAS.Core.Types;
using CAS.Core.Types.Aircrafts;
using CAS.UI.Appearance;
using CAS.UI.UIControls.Auxiliary;
using CasPresenter;
using CASTerms;

namespace CAS.UI.UIControls.StoresControls
{
    /// <summary>
    /// Форма для редактирования склада
    /// </summary>
    public class StoreForm : Form
    {
        #region Fields

        private readonly Store store;
        private readonly Operator currentOperator;
        private readonly ScreenMode mode;

        private readonly Label labelStore = new Label();
        private readonly Label labelLocation = new Label();
        private readonly Label labelRemarks = new Label();
        private readonly TextBox textBoxStore = new TextBox();
        private readonly TextBox textBoxLocation = new TextBox();
        private readonly TextBox textBoxRemarks = new TextBox();
        private readonly Button buttonOK = new Button();
        private readonly Button buttonCancel = new Button();

        private const int LEFT_MARGIN = 10;
        private const int TOP_MARGIN = 10;
        private const int INTERVAL = 10;
        private const int TEXTBOX_WIDTH = 250;
        private const int LABEL_WIDTH = 100;
        private const int LABEL_HEIGHT = 25;

        #endregion

        #region Constructors

        /// <summary>
        /// Создает форму для редактирования склада
        /// </summary>
        public StoreForm(Store store)
        {
            this.store = store;
            mode = ScreenMode.Edit;
            InitializeComponents();
            UpdateInformation();
        }

        /// <summary>
        /// Создает форму для добавления склада
        /// </summary>
        public StoreForm(Operator currentOperator)
        {
            this.currentOperator = currentOperator;
            mode = ScreenMode.Add;
            InitializeComponents();
        }

        #endregion

        #region Methods

        private void InitializeComponents()
        {
            //
            // labelStore
            //
            labelStore.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelStore.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelStore.Location = new Point(LEFT_MARGIN, TOP_MARGIN);
            labelStore.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelStore.Text = "Store:";
            labelStore.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxStore
            //
            textBoxStore.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxStore.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxStore.BackColor = Color.White;
            textBoxStore.Location = new Point(labelStore.Right, TOP_MARGIN);
            textBoxStore.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            //
            // labelLocation
            //
            labelLocation.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelLocation.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelLocation.Location = new Point(LEFT_MARGIN, labelStore.Bottom + INTERVAL);
            labelLocation.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelLocation.Text = "Location:";
            labelLocation.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxLocation
            //
            textBoxLocation.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxLocation.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxLocation.BackColor = Color.White;
            textBoxLocation.Location = new Point(labelLocation.Right, textBoxStore.Bottom + INTERVAL);
            textBoxLocation.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            //
            // labelRemarks
            //
            labelRemarks.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelRemarks.Location = new Point(LEFT_MARGIN, labelLocation.Bottom + INTERVAL);
            labelRemarks.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelRemarks.Text = "Remarks:";
            labelRemarks.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxRemarks
            //
            textBoxRemarks.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxRemarks.BackColor = Color.White;
            textBoxRemarks.Location = new Point(LEFT_MARGIN, labelRemarks.Bottom + INTERVAL);
            textBoxRemarks.Multiline = true;
            textBoxRemarks.ScrollBars = ScrollBars.Vertical;
            textBoxRemarks.Size = new Size(LABEL_WIDTH + TEXTBOX_WIDTH, 7 * LABEL_HEIGHT);
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

            MinimizeBox = false;
            MaximizeBox = false;
            CancelButton = buttonCancel;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            ClientSize = new Size(2 * LEFT_MARGIN + LABEL_WIDTH + TEXTBOX_WIDTH, TOP_MARGIN * 2 + LABEL_HEIGHT * 10 + INTERVAL * 4 + buttonOK.Height);
            BackColor = Css.CommonAppearance.Colors.BackColor;
            if (mode == ScreenMode.Edit)
                Text = "Store";
            else
                Text = "Add store";
            DialogResult = DialogResult.Cancel;

            Controls.Add(labelStore);
            Controls.Add(textBoxStore);
            Controls.Add(labelLocation);
            Controls.Add(textBoxLocation);
            Controls.Add(labelRemarks);
            Controls.Add(textBoxRemarks);
            Controls.Add(buttonOK);
            Controls.Add(buttonCancel);
        }

        private void UpdateInformation()
        {
            textBoxStore.Text = store.RegistrationNumber;
            textBoxLocation.Text = store.Model;
            textBoxRemarks.Text = store.Remarks;
        }

        private void SaveData(out Boolean dataChangingNeeded)
        {
            dataChangingNeeded = false;

            if (mode == ScreenMode.Add)
            {
                try
                {
                    Program.Presenters.StoresPresenter
                        .AddNewStoreToOperator(
                            currentOperator,
                            textBoxStore.Text.Trim(),
                            textBoxLocation.Text.Trim(),
                            textBoxRemarks.Text.Trim());
                }
                catch (CoreTypeNullException ex)
                {
                    Program.Provider.Logger.Log(String.Format("{0} is null", ex.ParamName), ex);
                }
                catch (ArgumentException argumentException)
                {
                    dataChangingNeeded = true;
                    MessageBox.Show(
                        String.Format("{0}", argumentException.Message), 
                        new GlobalTermsProvider()["SystemName"].ToString(), 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while saving data", ex);
                }
            }
            
            if (mode == ScreenMode.Edit)
            {
                try
                {
                    Program.Presenters.StoresPresenter
                        .EditStore(
                            store,
                            textBoxStore.Text.Trim(),
                            textBoxLocation.Text.Trim(),
                            textBoxRemarks.Text.Trim());
                }
                catch (CoreTypeNullException ex)
                {
                    Program.Provider.Logger.Log(String.Format("{0} is null", ex.ParamName), ex);
                }
                catch (ArgumentException argumentException)
                {
                    dataChangingNeeded = true;
                    MessageBox.Show(
                        String.Format("Invalid value of parameter {0}. {1}", argumentException.ParamName, argumentException.Message),
                        new GlobalTermsProvider()["SystemName"].ToString(),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while saving data", ex);
                }
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            buttonCancel.Location = new Point(ClientSize.Width - buttonCancel.Width - INTERVAL, textBoxRemarks.Bottom + INTERVAL);
            buttonOK.Location = new Point(buttonCancel.Left - buttonOK.Width - INTERVAL, textBoxRemarks.Bottom + INTERVAL);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Boolean dataChangingNeeded;
            SaveData(out dataChangingNeeded);
            if (!dataChangingNeeded)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion
    }
}
