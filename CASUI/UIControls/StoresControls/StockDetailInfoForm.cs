using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.Appearance;
using CAS.UI.UIControls.Auxiliary;

namespace CAS.UI.UIControls.StoresControls
{
    /// <summary>
    /// ‘орма дл€ редактировани€/добавлени€ <see cref="StockDetailInfo"/>
    /// </summary>
    public class StockDetailInfoForm : Form
    {

        #region Fields

        private readonly Store parentStore;
        private readonly StockDetailInfo currentStockDetailInfo;
        private ScreenMode mode;

        private TabControl tabControl;
        private TabPage tabPageGeneral;
        private Label labelStore;
        private Label labelCurrent;
        private Label labelPartNumber;
        private Label labelDescription;
        private Label labelAmount;
        private TextBox textBoxStore;
        private TextBox textBoxCurrent;
        private TextBox textBoxPartNumber;
        private TextBox textBoxDescription;
        private TextBox textBoxAmount;
        private Label labelSeparator;
        private Button buttonOK;
        private Button buttonApply;
        private Button buttonCancel;

        #endregion

        #region Constructors

        #region public StockDetailInfoForm(StockDetailInfo stockDetailInfo)

        /// <summary>
        /// —оздает форму дл€ редактировани€/добавлени€ <see cref="StockDetailInfo"/>
        /// </summary>
        /// <param name="stockDetailInfo">StockDetailInfo</param>
        public StockDetailInfoForm(StockDetailInfo stockDetailInfo)
        {
            currentStockDetailInfo = stockDetailInfo;
            mode = ScreenMode.Edit;
            InitializeComponent();
            UpdateInformation();
        }

        #endregion

        #region public StockDetailInfoForm(Store parentStore)

        /// <summary>
        /// —оздает форму дл€ редактировани€/добавлени€ <see cref="StockDetailInfo"/>
        /// </summary>
        /// <param name="parentStore">—клад, куда добавл€етс€ StockDetailInfo</param>
        public StockDetailInfoForm(Store parentStore)
        {
            this.parentStore = parentStore;
            currentStockDetailInfo = new StockDetailInfo();
            mode = ScreenMode.Add;
            InitializeComponent();
            UpdateInformation();
        }

        #endregion

        #endregion
        
        #region Properties

        #region public string PartNumber

        /// <summary>
        /// ¬озвращает или устанавливает партийный номер
        /// </summary>
        public string PartNumber
        {
            get
            {
                return textBoxPartNumber.Text;
            }
            set
            {
                textBoxPartNumber.Text = value;
            }
        }

        #endregion

        #region public string Description

        /// <summary>
        /// ¬озвращает или устанавливает описание
        /// </summary>
        public string Description
        {
            get
            {
                return textBoxDescription.Text;
            }
            set
            {
                textBoxDescription.Text = value;
            }
        }

        #endregion

        #region public string Amount

        /// <summary>
        /// ¬озвращает или устанавливает количесво агрегатов на складе
        /// </summary>
        public string Amount
        {
            get
            {
                return textBoxAmount.Text;
            }
            set
            {
                textBoxAmount.Text = value;
            }
        }

        #endregion

        #endregion
        
        #region Methods
        
        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            labelStore = new Label();
            textBoxStore = new TextBox();
            labelPartNumber = new Label();
            textBoxPartNumber = new TextBox();
            labelAmount = new Label();
            textBoxAmount = new TextBox();
            labelCurrent = new Label();
            textBoxCurrent = new TextBox();
            labelDescription = new Label();
            textBoxDescription = new TextBox();
            buttonOK = new Button();
            buttonApply = new Button();
            buttonCancel = new Button();
            tabControl = new TabControl();
            tabPageGeneral = new TabPage();
            labelSeparator = new Label();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPageGeneral);
            tabControl.Location = new Point(Css.WindowsForm.Constants.LEFT_MARGIN, Css.WindowsForm.Constants.TOP_MARGIN);
            // 
            // tabPageGeneral
            // 
            tabPageGeneral.BackColor = Css.WindowsForm.Colors.TabBackColor;
            tabPageGeneral.Text = "General";
            tabPageGeneral.Controls.Add(labelStore);
            tabPageGeneral.Controls.Add(textBoxStore);
            tabPageGeneral.Controls.Add(labelPartNumber);
            tabPageGeneral.Controls.Add(textBoxPartNumber);
            tabPageGeneral.Controls.Add(labelAmount);
            tabPageGeneral.Controls.Add(textBoxAmount);
            tabPageGeneral.Controls.Add(labelCurrent);
            tabPageGeneral.Controls.Add(textBoxCurrent);
            tabPageGeneral.Controls.Add(labelSeparator);
            tabPageGeneral.Controls.Add(labelDescription);
            tabPageGeneral.Controls.Add(textBoxDescription);
            //
            // labelStore
            //
            labelStore.Font = Css.WindowsForm.Fonts.RegularFont;
            labelStore.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelStore.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, Css.WindowsForm.Constants.TAB_TOP_MARGIN);
            labelStore.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelStore.Text = "Store:";
            labelStore.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxStore
            //
            textBoxStore.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxStore.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxStore.Location = new Point(labelStore.Right, Css.WindowsForm.Constants.TAB_TOP_MARGIN);
            textBoxStore.ReadOnly = true;
            //
            // labelPartNumber
            //
            labelPartNumber.Font = Css.WindowsForm.Fonts.RegularFont;
            labelPartNumber.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelPartNumber.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelStore.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelPartNumber.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelPartNumber.Text = "Part Number:";
            labelPartNumber.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxPartNumber
            //
            textBoxPartNumber.BackColor = Color.White;
            textBoxPartNumber.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxPartNumber.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxPartNumber.Location = new Point(labelPartNumber.Right, labelStore.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            //
            // labelAmount
            //
            labelAmount.Font = Css.WindowsForm.Fonts.RegularFont;
            labelAmount.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelAmount.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelPartNumber.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelAmount.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelAmount.Text = "Amount:";
            labelAmount.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxAmount
            //
            textBoxAmount.BackColor = Color.White;
            textBoxAmount.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxAmount.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxAmount.Location = new Point(labelAmount.Right, labelPartNumber.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            //
            // labelCurrent
            //
            labelCurrent.Font = Css.WindowsForm.Fonts.RegularFont;
            labelCurrent.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelCurrent.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelAmount.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelCurrent.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelCurrent.Text = "Current:";
            labelCurrent.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxCurrent
            //
            textBoxCurrent.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxCurrent.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxCurrent.Location = new Point(labelCurrent.Right, labelAmount.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            textBoxCurrent.ReadOnly = true;
            //
            // labelSeparator
            //
            labelSeparator.AutoSize = false;
            labelSeparator.Location = new Point(Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN, labelCurrent.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelSeparator.Height = 2;
            labelSeparator.BorderStyle = BorderStyle.Fixed3D;
            //
            // labelDescription
            //
            labelDescription.Font = Css.WindowsForm.Fonts.RegularFont;
            labelDescription.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelDescription.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelSeparator.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelDescription.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelDescription.Text = "Description:";
            labelDescription.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxDescription
            //
            textBoxDescription.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxDescription.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxDescription.BackColor = Color.White;
            textBoxDescription.Location = new Point(labelDescription.Right, labelSeparator.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            textBoxDescription.Multiline = true;
            textBoxDescription.Height = Css.WindowsForm.Constants.BIG_TEXT_BOX_HEIGHT;
            //
            // buttonOK
            //
            buttonOK.Font = Css.WindowsForm.Fonts.RegularFont;
            buttonOK.ForeColor = Css.WindowsForm.Colors.ForeColor;
            buttonOK.Size = new Size(Css.WindowsForm.Constants.BUTTON_WIDTH, Css.WindowsForm.Constants.BUTTON_HEIGHT);
            buttonOK.Text = "OK";
            buttonOK.Click += buttonOK_Click;
            //
            // buttonApply
            //
            buttonApply.Font = Css.WindowsForm.Fonts.RegularFont;
            buttonApply.ForeColor = Css.WindowsForm.Colors.ForeColor;
            buttonApply.Size = new Size(Css.WindowsForm.Constants.BUTTON_WIDTH, Css.WindowsForm.Constants.BUTTON_HEIGHT);
            buttonApply.Text = "Apply";
            buttonApply.Click += buttonApply_Click;
            //
            // buttonCancel
            //
            buttonCancel.Font = Css.WindowsForm.Fonts.RegularFont;
            buttonCancel.ForeColor = Css.WindowsForm.Colors.ForeColor;
            buttonCancel.Size = new Size(Css.WindowsForm.Constants.BUTTON_WIDTH, Css.WindowsForm.Constants.BUTTON_HEIGHT);
            buttonCancel.Text = "Cancel";
            buttonCancel.Click += buttonCancel_Click;


            AcceptButton = buttonOK;
            CancelButton = buttonCancel;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = Css.WindowsForm.Constants.DefaultFormSize;
            if (mode == ScreenMode.Add)
                Text = "Add new record";
            else
                Text = "Record " + currentStockDetailInfo.PartNumber;
            StartPosition = FormStartPosition.CenterScreen;
            Controls.Add(tabControl);
            Controls.Add(buttonOK);
            Controls.Add(buttonApply);
            Controls.Add(buttonCancel);
        }

        #endregion
        
        #region private void UpdateInformation()

        private void UpdateInformation()
        {
            if (parentStore != null)
                textBoxStore.Text = parentStore.RegistrationNumber;
            else 
                textBoxStore.Text = currentStockDetailInfo.Store.RegistrationNumber;
            PartNumber = currentStockDetailInfo.PartNumber;
            Amount = currentStockDetailInfo.Amount.ToString();
            textBoxCurrent.Text = currentStockDetailInfo.Current.ToString();
            Description = currentStockDetailInfo.Description;
        }

        #endregion

        #region private bool SaveData()

        /// <summary>
        /// ƒанные работы обновл€ютс€ по введенным значени€м
        /// </summary>
        private bool SaveData()
        {
            int amount;
            if (!CheckAmount(out amount))
                return false;
            if (PartNumber != currentStockDetailInfo.PartNumber)
                currentStockDetailInfo.PartNumber = PartNumber;
            if (currentStockDetailInfo.Amount != amount)
                currentStockDetailInfo.Amount = amount;
            if (Description != currentStockDetailInfo.Description)
                currentStockDetailInfo.Description = Description;
            try
            {
                if (mode == ScreenMode.Add)
                {
                    parentStore.AddStockDetailInfo(currentStockDetailInfo);
                    mode = ScreenMode.Edit;
                }
                else 
                    currentStockDetailInfo.Save();
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex); return false;
            }


            return true;
        }

        #endregion

        #region public bool CheckAmount(out int amount)

        /// <summary>
        /// ѕровер€ет значение Amount
        /// </summary>
        /// <param name="amount">«начение Amount</param>
        /// <returns>¬озвращает true если значение можно преобразовать в тип int, иначе возвращает false</returns>
        public bool CheckAmount(out int amount)
        {
            if (int.TryParse(Amount, NumberStyles.Float, new NumberFormatInfo(), out amount) == false || amount < 0)
            {
                MessageBox.Show("Amount. Invalid value", (string)new TermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        #endregion

        #region private void buttonOK_Click(object sender, EventArgs e)

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (SaveData())
                Close();
        }

        #endregion

        #region private void buttonApply_Click(object sender, EventArgs e)

        private void buttonApply_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        #endregion

        #region private void buttonCancel_Click(object sender, EventArgs e)

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region protected override void OnSizeChanged(EventArgs e)

        ///<summary>
        ///Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged"></see> event.
        ///</summary>
        ///
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            tabControl.Size = new Size(ClientSize.Width - Css.WindowsForm.Constants.LEFT_MARGIN - Css.WindowsForm.Constants.RIGHT_MARGIN, ClientSize.Height - Css.WindowsForm.Constants.TOP_MARGIN - Css.WindowsForm.Constants.BOTTOM_MARGIN - Css.WindowsForm.Constants.BUTTON_HEIGHT - Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            textBoxStore.Width =
            textBoxPartNumber.Width =
            textBoxAmount.Width = 
            textBoxCurrent.Width = 
            textBoxDescription.Width = tabControl.Width - Css.WindowsForm.Constants.TAB_LEFT_MARGIN - Css.WindowsForm.Constants.TAB_RIGHT_MARGIN - Css.WindowsForm.Constants.DefaultLabelSize.Width;
            labelSeparator.Width = tabControl.Width - Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN - Css.WindowsForm.Constants.TAB_SEPARATOR_RIGHT_MARGIN;
            buttonApply.Location = new Point(ClientSize.Width - Css.WindowsForm.Constants.RIGHT_MARGIN - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            buttonCancel.Location = new Point(buttonApply.Left - Css.WindowsForm.Constants.BUTTON_INTERVAL - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            buttonOK.Location = new Point(buttonCancel.Left - Css.WindowsForm.Constants.BUTTON_INTERVAL - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
        }

        #endregion
        
        #endregion
        
    }
}