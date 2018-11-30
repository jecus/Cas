﻿using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Dictionaries;
using CAS.UI.Appearance;
using CAS.UI.Management;
using CAS.UI.UIControls.Auxiliary;
using CAS.Core.Types.Aircrafts.Parts;
using CASTerms;

namespace CAS.UI.UIControls.ComplianceControls
{
    /// <summary>
    /// Форма для редактирования свойств записи Compliance
    /// </summary>
    public class TransferRecordForm : Form
    {

        #region Fields

        private readonly AbstractDetail currentDetail;
        private readonly TransferRecord currentRecord;

        private TabControl tabControl;
        private TabPage tabPageGeneral;
        private Label labelComponent;
        private Label labelFrom;
        private Label labelFromAdditional;
        private Label labelDate;
        private Label labelTo;
        private Label labelToAdditional;
        private Label labelRemarks;
        private TextBox textBoxSerialNumber;
        private TextBox textBoxPartNumber;
        private TextBox textBoxFrom;
        private TextBox textBoxFromAdditional;
        private TextBox textBoxDate;
        private TextBox textBoxTo;
        private TextBox textBoxToAdditional;
        private TextBox textBoxRemarks;
        private WindowsFormAttachedFileControl fileControl;
        private Label labelSeparator;
        private Label labelSeparator2;
        private Label labelSeparator3;
        private Label labelSeparator4;
        private Button buttonOK;
        private Button buttonApply;
        private Button buttonCancel;

        private readonly Icons icons = new Icons();

        #endregion

        #region Constructors

        #region public TransferRecordForm(AbstractDetail detail, TransferRecord detailRecord)

        /// <summary>
        /// Создает форму для редактирования записи Compliance агрегата
        /// </summary>
        /// <param name="detail">Агрегат</param>
        /// <param name="detailRecord">Transfer Record</param>
        public TransferRecordForm(AbstractDetail detail, TransferRecord detailRecord)
        {
            currentDetail = detail;
            currentRecord = detailRecord;
            InitializeComponent();
            UpdateInformation();
        }

        #endregion

        #endregion
        
        #region Methods
        
        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            labelComponent = new Label();
            labelFrom = new Label();
            labelFromAdditional = new Label();
            labelDate = new Label();
            labelTo = new Label();
            labelToAdditional = new Label();
            labelRemarks = new Label();
            textBoxSerialNumber = new TextBox();
            textBoxPartNumber = new TextBox();
            textBoxFrom = new TextBox();
            textBoxFromAdditional = new TextBox();
            textBoxDate = new TextBox();
            textBoxTo = new TextBox();
            textBoxToAdditional = new TextBox();
            textBoxRemarks = new TextBox();
            fileControl = new WindowsFormAttachedFileControl(currentRecord.AttachedFile, "Adobe PDF Files|*.pdf",
                    "This record does not contain a file proving the compliance. Enclose PDF file to prove the compliance.",
                    "Attached file proves the compliance.", icons.PDFSmall);
            buttonOK = new Button();
            buttonApply = new Button();
            buttonCancel = new Button();
            tabControl = new TabControl();
            tabPageGeneral = new TabPage();
            labelSeparator = new Label();
            labelSeparator2 = new Label();
            labelSeparator3 = new Label();
            labelSeparator4 = new Label();
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
            tabPageGeneral.Controls.Add(labelComponent);
            tabPageGeneral.Controls.Add(textBoxSerialNumber);
            tabPageGeneral.Controls.Add(textBoxPartNumber);
            tabPageGeneral.Controls.Add(labelDate);
            tabPageGeneral.Controls.Add(textBoxDate);
            tabPageGeneral.Controls.Add(labelSeparator);
            tabPageGeneral.Controls.Add(labelFrom);
            tabPageGeneral.Controls.Add(textBoxFrom);
            tabPageGeneral.Controls.Add(labelFromAdditional);
            tabPageGeneral.Controls.Add(textBoxFromAdditional);
            tabPageGeneral.Controls.Add(labelSeparator2);
            tabPageGeneral.Controls.Add(labelTo);
            tabPageGeneral.Controls.Add(textBoxTo);
            tabPageGeneral.Controls.Add(labelToAdditional);
            tabPageGeneral.Controls.Add(textBoxToAdditional);
            tabPageGeneral.Controls.Add(labelSeparator3);
            tabPageGeneral.Controls.Add(labelRemarks);
            tabPageGeneral.Controls.Add(textBoxRemarks);
            tabPageGeneral.Controls.Add(labelSeparator4);
            tabPageGeneral.Controls.Add(fileControl);
            //
            // labelComponent
            //
            labelComponent.Font = Css.WindowsForm.Fonts.RegularFont;
            labelComponent.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelComponent.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, Css.WindowsForm.Constants.TAB_TOP_MARGIN);
            labelComponent.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelComponent.Text = "Component:";
            labelComponent.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxSerialNumber
            //
            textBoxSerialNumber.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxSerialNumber.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxSerialNumber.Location = new Point(labelComponent.Right, Css.WindowsForm.Constants.TAB_TOP_MARGIN);
            textBoxSerialNumber.ReadOnly = true;
            //
            // textBoxPartNumber
            //
            textBoxPartNumber.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxPartNumber.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxPartNumber.Location = new Point(labelComponent.Right, labelComponent.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            textBoxPartNumber.ReadOnly = true;
            //
            // labelDate
            //
            labelDate.Font = Css.WindowsForm.Fonts.RegularFont;
            labelDate.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelDate.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, textBoxPartNumber.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelDate.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelDate.Text = "Date:";
            labelDate.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxDate
            //
            textBoxDate.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxDate.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxDate.Location = new Point(labelDate.Right, textBoxPartNumber.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            textBoxDate.ReadOnly = true;
            //
            // labelSeparator
            //
            labelSeparator.AutoSize = false;
            labelSeparator.Location = new Point(Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN, textBoxDate.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelSeparator.Height = 2;
            labelSeparator.BorderStyle = BorderStyle.Fixed3D;
            //
            // labelFrom
            //
            labelFrom.Font = Css.WindowsForm.Fonts.RegularFont;
            labelFrom.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelFrom.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelSeparator.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelFrom.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelFrom.Text = "From:";
            labelFrom.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxFrom
            //
            textBoxFrom.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxFrom.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxFrom.Location = new Point(labelFrom.Right, labelSeparator.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            textBoxFrom.ReadOnly = true;
            // 
            // labelFromAdditional
            // 
            labelFromAdditional.Font = Css.WindowsForm.Fonts.RegularFont;
            labelFromAdditional.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelFromAdditional.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, textBoxFrom.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelFromAdditional.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelFromAdditional.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxFromAdditional
            //
            textBoxFromAdditional.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxFromAdditional.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxFromAdditional.Location = new Point(labelFromAdditional.Right, textBoxFrom.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            textBoxFromAdditional.ReadOnly = true;
            //
            // labelSeparator2
            //
            labelSeparator2.AutoSize = false;
            labelSeparator2.Height = 2;
            labelSeparator2.Location = new Point(Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN, textBoxFromAdditional.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelSeparator2.BorderStyle = BorderStyle.Fixed3D;
            //
            // labelTo
            //
            labelTo.Font = Css.WindowsForm.Fonts.RegularFont;
            labelTo.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelTo.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelSeparator2.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelTo.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelTo.Text = "To:";
            labelTo.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxTo
            //
            textBoxTo.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxTo.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxTo.Location = new Point(labelTo.Right, labelSeparator2.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            textBoxTo.ReadOnly = true;
            //
            // labelToAdditional
            //
            labelToAdditional.Font = Css.WindowsForm.Fonts.RegularFont;
            labelToAdditional.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelToAdditional.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, textBoxTo.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelToAdditional.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelToAdditional.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxToAdditional
            //
            textBoxToAdditional.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxToAdditional.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxToAdditional.Location = new Point(labelTo.Right, textBoxTo.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            //textBoxToAdditional.ReadOnly = true;
            //
            // labelSeparator3
            //
            labelSeparator3.AutoSize = false;
            labelSeparator3.Height = 2;
            labelSeparator3.BorderStyle = BorderStyle.Fixed3D;
            labelSeparator3.Location = new Point(Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN, textBoxToAdditional.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            //
            // labelRemarks
            //
            labelRemarks.Font = Css.WindowsForm.Fonts.RegularFont;
            labelRemarks.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelRemarks.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelSeparator3.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelRemarks.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelRemarks.Text = "Remarks:";
            labelRemarks.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxRemarks
            //
            textBoxRemarks.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxRemarks.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxRemarks.BackColor = Color.White;
            textBoxRemarks.Multiline = true;
            textBoxRemarks.Height = Css.WindowsForm.Constants.BIG_TEXT_BOX_HEIGHT;
            textBoxRemarks.Location = new Point(labelRemarks.Right, labelSeparator3.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            //
            // labelSeparator4
            //
            labelSeparator4.AutoSize = false;
            labelSeparator4.Height = 2;
            labelSeparator4.BorderStyle = BorderStyle.Fixed3D;
            labelSeparator4.Location = new Point(Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN, textBoxRemarks.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            //
            // fileControl
            //
            fileControl.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelSeparator4.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
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


            Text = "SN " + currentDetail.SerialNumber + ". Transfer record";
            AcceptButton = buttonOK;
            CancelButton = buttonCancel;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = Css.WindowsForm.Constants.DefaultFormSize;
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
            textBoxSerialNumber.Text = "S/N " + currentDetail.SerialNumber;
            textBoxPartNumber.Text = "P/N " + currentDetail.PartNumber;

            TransferRecord preRecord = currentDetail.GetPreLastTransferRecord();
            if (preRecord != null)
            {
                if (preRecord.TransferContainer is Aircraft || preRecord.TransferContainer is BaseDetail)
                {
                    Aircraft aircraft;
                    Store store = null;
                    if (preRecord.TransferContainer is Aircraft)
                        aircraft = (Aircraft) preRecord.TransferContainer;
                    else
                    {
                        BaseDetail baseDetail = (BaseDetail)preRecord.TransferContainer;
                        aircraft = baseDetail.ParentAircraft;
                        if (aircraft.Type == AircraftType.Store)
                            store = baseDetail.Store;
                    }
                    if (store != null)
                    {
                        textBoxFrom.Text = store.Name;
                        labelFromAdditional.Text = "Location:";
                        textBoxFromAdditional.Text = preRecord.Position;
                    }
                    else
                    {
                        textBoxFrom.Text = aircraft.RegistrationNumber;
                        labelFromAdditional.Text = "Position:";
                        textBoxFromAdditional.Text = preRecord.Position;
                    }
                }
            }
            textBoxDate.Text = currentRecord.RecordDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            if (currentRecord.TransferContainer is Aircraft || currentRecord.TransferContainer is BaseDetail)
            {
                Aircraft aircraft;
                Store store = null;
                if (currentRecord.TransferContainer is Aircraft)
                    aircraft = (Aircraft)currentRecord.TransferContainer;
                else
                {
                    BaseDetail baseDetail = (BaseDetail) currentRecord.TransferContainer;
                    aircraft = baseDetail.ParentAircraft;
                    if (aircraft.Type == AircraftType.Store)
                        store = baseDetail.Store;
                }
                if (store != null)
                {
                    textBoxTo.Text = store.Name;
                    labelToAdditional.Text = "Location:";
                    textBoxToAdditional.Text = currentRecord.Position;
                }
                else
                {
                    textBoxTo.Text = aircraft.RegistrationNumber;
                    labelToAdditional.Text = "Position:";
                    textBoxToAdditional.Text = currentRecord.Position;
                }
            }
            textBoxRemarks.Text = currentRecord.Description;
        }

        #endregion

        #region private bool SaveData()

        /// <summary>
        /// Данные работы обновляются по введенным значениям
        /// </summary>
        private bool SaveData()
        {
            if (currentRecord.Position != textBoxToAdditional.Text)
                currentRecord.Position = textBoxToAdditional.Text;
            if (fileControl.AttachedFile != currentRecord.AttachedFile)
            {
                currentRecord.AttachedFile.FileName = fileControl.AttachedFile.FileName;
                currentRecord.AttachedFile.FileData = fileControl.AttachedFile.FileData;
            }
            if (currentRecord.Description != textBoxRemarks.Text)
                currentRecord.Description = textBoxRemarks.Text;
            try
            {
                currentRecord.Save(true);
                if (RecordChanged != null)
                    RecordChanged(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
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
            textBoxSerialNumber.Width =
            textBoxPartNumber.Width =
            textBoxFrom.Width =
            textBoxFromAdditional.Width =
            textBoxDate.Width = 
            textBoxTo.Width = 
            textBoxToAdditional.Width = 
            textBoxRemarks.Width = tabControl.Width - Css.WindowsForm.Constants.TAB_LEFT_MARGIN - Css.WindowsForm.Constants.TAB_RIGHT_MARGIN - Css.WindowsForm.Constants.DefaultLabelSize.Width;
            labelSeparator.Width =
            labelSeparator2.Width =
            labelSeparator3.Width =
            labelSeparator4.Width = tabControl.Width - Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN - Css.WindowsForm.Constants.TAB_SEPARATOR_RIGHT_MARGIN;
            fileControl.MinimumSize = new Size(Width - Css.WindowsForm.Constants.TAB_LEFT_MARGIN - Css.WindowsForm.Constants.TAB_RIGHT_MARGIN, 0);
            fileControl.MaximumSize = new Size(Width - Css.WindowsForm.Constants.TAB_LEFT_MARGIN - Css.WindowsForm.Constants.TAB_RIGHT_MARGIN, 300);
            buttonApply.Location = new Point(ClientSize.Width - Css.WindowsForm.Constants.RIGHT_MARGIN - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            buttonCancel.Location = new Point(buttonApply.Left - Css.WindowsForm.Constants.BUTTON_INTERVAL - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            buttonOK.Location = new Point(buttonCancel.Left - Css.WindowsForm.Constants.BUTTON_INTERVAL - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
        }

        #endregion
        
        #endregion

        #region Events

        /// <summary>
        /// Событие изменения записи
        /// </summary>
        public event EventHandler RecordChanged;

        #endregion
    }
}
