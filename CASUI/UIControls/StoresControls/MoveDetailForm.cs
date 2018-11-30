using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.Core.Types;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.Appearance;
using CAS.UI.Management;
using CAS.UI.UIControls.Auxiliary;

namespace CAS.UI.UIControls.StoresControls
{
    /// <summary>
    /// Форма для установки агрегата со склада на ВС
    /// </summary>
    public class MoveDetailForm : Form
    {
        
        #region Fields

        private readonly AbstractDetail currentDetail;
        private readonly List<AbstractDetail> currentDetailsList;
        private readonly List<BaseDetail> currentBaseDetailsList;
        private Aircraft checkedBaseDetailContainer;
        private Aircraft currentContainer;
        private MoveDetailFormMode mode;
        private bool moveBaseDetails;

        private TabControl tabControl;
        private TabPage tabPageGeneral;
        private Label labelComponent;
        private TextBox textBoxComponent;
        private Label labelDate;
        private DateTimePicker dateTimePickerDate;
        private Label labelMoveTo;
        private ComboBox comboBoxBaseDetailContainer;
        private Label labelInstallToBaseDetails;
        private ComboBox comboBoxBaseDetails;
        private Label labelPosition;
        private TextBox textBoxPosition;
        private Label labelReference;
        private TextBox textBoxReference;
        private Label labelRemarks;
        private TextBox textBoxRemarks;
        private WindowsFormAttachedFileControl fileControl;
        private Label labelSeparator;
        private Label labelSeparator2;
        private Label labelSeparator3;
        private Button buttonOK;
        private Button buttonApply;
        private Button buttonCancel;
        
        private const int FLOW_LAYOUT_PANEL_INTERVAL = 15;
        private const int MAX_FLOW_LAYOUT_PANEL_HEIGHT = 120;
        private readonly Icons icons = new Icons();
                
        #endregion

        #region Constructors

        #region public MoveDetailForm(AbstractDetail currentDetail, Aircraft currentAircraft)

        /// <summary>
        /// Создает форму для установки агрегата на ВС
        /// </summary>
        public MoveDetailForm(AbstractDetail currentDetail, MoveDetailFormMode mode, Aircraft currentContainer)
        {
            this.mode = mode;
            this.currentContainer = currentContainer;
            this.currentDetail = currentDetail;
            if (currentDetail is BaseDetail)
                moveBaseDetails = true;
            InitializeComponent();
            FillComboBoxes();
        }

        #endregion

        #region public MoveDetailForm(List<AbstractDetail> detailsList, Store currentStore)

        /// <summary>
        /// Создает форму для установки агрегатов со склада на ВС
        /// </summary>
        public MoveDetailForm(List<AbstractDetail> detailsList, MoveDetailFormMode mode, Aircraft currentContainer)
        {
            this.mode = mode;
            this.currentContainer = currentContainer;
            currentDetailsList = new List<AbstractDetail>(detailsList);
            InitializeComponent();
            FillComboBoxes();
        }

        #endregion

        #region public MoveDetailForm(List<BaseDetail> detailsList, MoveDetailFormMode mode, Aircraft currentContainer)

        /// <summary>
        /// Создает форму для установки базовых агрегатов на склад
        /// </summary>
        public MoveDetailForm(List<BaseDetail> detailsList, MoveDetailFormMode mode, Aircraft currentContainer)
        {
            this.mode = mode;
            this.currentContainer = currentContainer;
            currentBaseDetailsList = detailsList;
            moveBaseDetails = true;
            InitializeComponent();
            FillComboBoxes();
        }

        #endregion

        #endregion

        #region Methods

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            tabControl = new TabControl();
            tabPageGeneral = new TabPage();
            labelComponent = new Label();
            textBoxComponent = new TextBox();
            labelDate = new Label();
            dateTimePickerDate = new DateTimePicker();
            labelMoveTo = new Label();
            comboBoxBaseDetailContainer = new ComboBox();
            labelInstallToBaseDetails = new Label();
            comboBoxBaseDetails = new ComboBox();
            labelPosition = new Label();
            textBoxPosition = new TextBox();
            labelReference = new Label();
            textBoxReference = new TextBox();
            labelRemarks = new Label();
            textBoxRemarks = new TextBox();
            fileControl = new WindowsFormAttachedFileControl(null, "Adobe PDF Files|*.pdf",
                    "This record does not contain a file proving the tranfering of the component.\r\nEnclose PDF file to prove the transfer of the component.",
                    "Attached file proves the transfer of the component.", icons.PDFSmall);
            labelSeparator = new Label();
            labelSeparator2 = new Label();
            labelSeparator3 = new Label();
            buttonOK = new Button();
            buttonApply = new Button();
            buttonCancel = new Button();
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
            tabPageGeneral.Controls.Add(textBoxComponent);
            tabPageGeneral.Controls.Add(labelSeparator);
            tabPageGeneral.Controls.Add(labelDate);
            tabPageGeneral.Controls.Add(dateTimePickerDate);
            tabPageGeneral.Controls.Add(labelMoveTo);
            tabPageGeneral.Controls.Add(comboBoxBaseDetailContainer);
            tabPageGeneral.Controls.Add(labelInstallToBaseDetails);
            tabPageGeneral.Controls.Add(comboBoxBaseDetails);
            tabPageGeneral.Controls.Add(labelPosition);
            tabPageGeneral.Controls.Add(textBoxPosition);
            tabPageGeneral.Controls.Add(labelSeparator2);
            tabPageGeneral.Controls.Add(labelReference);
            tabPageGeneral.Controls.Add(textBoxReference);
            tabPageGeneral.Controls.Add(labelRemarks);
            tabPageGeneral.Controls.Add(textBoxRemarks);
            tabPageGeneral.Controls.Add(labelSeparator3);
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
            // textBoxComponent
            //
            textBoxComponent.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxComponent.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxComponent.Location = new Point(labelComponent.Right, Css.WindowsForm.Constants.TAB_TOP_MARGIN);
            textBoxComponent.ReadOnly = true;
            //
            // labelSeparator
            //
            labelSeparator.AutoSize = false;
            labelSeparator.Location = new Point(Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN, labelComponent.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelSeparator.Height = 2;
            labelSeparator.BorderStyle = BorderStyle.Fixed3D;
            //
            // labelDate
            //
            labelDate.Font = Css.WindowsForm.Fonts.RegularFont;
            labelDate.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelDate.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelSeparator.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelDate.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelDate.Text = "Date:";
            labelDate.TextAlign = ContentAlignment.MiddleLeft;
            //
            // dateTimePickerDate
            //
            dateTimePickerDate.Font = Css.WindowsForm.Fonts.RegularFont;
            dateTimePickerDate.ForeColor = Css.WindowsForm.Colors.ForeColor;
            dateTimePickerDate.BackColor = Color.White;
            dateTimePickerDate.Location = new Point(labelDate.Right, labelSeparator.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            dateTimePickerDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerDate.CustomFormat = new TermsProvider()["DateFormat"].ToString();
            //
            // labelMoveTo
            //
            labelMoveTo.Font = Css.WindowsForm.Fonts.RegularFont;
            labelMoveTo.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelMoveTo.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, dateTimePickerDate.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelMoveTo.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelMoveTo.TextAlign = ContentAlignment.MiddleLeft;
            //
            // comboBoxWorkType
            //
            comboBoxBaseDetailContainer.BackColor = Color.White;
            comboBoxBaseDetailContainer.Font = Css.WindowsForm.Fonts.RegularFont;
            comboBoxBaseDetailContainer.ForeColor = Css.WindowsForm.Colors.ForeColor;
            comboBoxBaseDetailContainer.Location = new Point(labelMoveTo.Right, dateTimePickerDate.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            comboBoxBaseDetailContainer.SelectedIndexChanged += new EventHandler(comboBoxBaseDetailContainer_SelectedIndexChanged);
            //
            // labelPosition
            //
            labelPosition.Font = Css.WindowsForm.Fonts.RegularFont;
            labelPosition.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelPosition.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelPosition.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxPosition
            //
            textBoxPosition.BackColor = Color.White;
            textBoxPosition.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxPosition.ForeColor = Css.WindowsForm.Colors.ForeColor;
            if (mode == MoveDetailFormMode.MoveToAircraft)
                labelPosition.Text = "Position:";
            else
                labelPosition.Text = "Location:";


            if (mode == MoveDetailFormMode.MoveToAircraft && !moveBaseDetails)
            {
                labelMoveTo.Text = "Aircraft:";
                //
                // labelInstallToBaseDetails
                //
                labelInstallToBaseDetails.Font = Css.WindowsForm.Fonts.RegularFont;
                labelInstallToBaseDetails.ForeColor = Css.WindowsForm.Colors.ForeColor;
                labelInstallToBaseDetails.Size = Css.WindowsForm.Constants.DefaultLabelSize;
                labelInstallToBaseDetails.TextAlign = ContentAlignment.MiddleLeft;
                labelInstallToBaseDetails.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, comboBoxBaseDetailContainer.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
                labelInstallToBaseDetails.Text = "Base Detail:";
                //
                // comboBoxBaseDetails
                //
                comboBoxBaseDetails.BackColor = Color.White;
                comboBoxBaseDetails.Font = Css.WindowsForm.Fonts.RegularFont;
                comboBoxBaseDetails.ForeColor = Css.WindowsForm.Colors.ForeColor;
                comboBoxBaseDetails.Location = new Point(labelInstallToBaseDetails.Right, comboBoxBaseDetailContainer.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);



                labelPosition.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, comboBoxBaseDetails.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
                textBoxPosition.Location = new Point(labelPosition.Right, comboBoxBaseDetails.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            }
            else
            {
                labelMoveTo.Text = "Store:";
                labelInstallToBaseDetails.Visible = false;
                comboBoxBaseDetails.Visible = false;
                labelPosition.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, comboBoxBaseDetailContainer.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
                textBoxPosition.Location = new Point(labelPosition.Right, comboBoxBaseDetailContainer.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            }
            //
            // labelSeparator2
            //
            labelSeparator2.AutoSize = false;
            labelSeparator2.Height = 2;
            labelSeparator2.BorderStyle = BorderStyle.Fixed3D;
            labelSeparator2.Location = new Point(Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN, textBoxPosition.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            //
            // labelReference
            //
            labelReference.Font = Css.WindowsForm.Fonts.RegularFont;
            labelReference.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelReference.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelReference.TextAlign = ContentAlignment.MiddleLeft;
            labelReference.Text = "Reference:";
            labelReference.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelSeparator2.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            //
            // textBoxReference
            //
            textBoxReference.BackColor = Color.White;
            textBoxReference.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxReference.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxReference.Location = new Point(labelPosition.Right, labelSeparator2.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            //
            // labelRemarks
            //
            labelRemarks.Font = Css.WindowsForm.Fonts.RegularFont;
            labelRemarks.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelRemarks.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelRemarks.Text = "Remarks:";
            labelRemarks.TextAlign = ContentAlignment.MiddleLeft;
            labelRemarks.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, textBoxReference.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            //
            // textBoxRemarks
            //
            textBoxRemarks.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxRemarks.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxRemarks.BackColor = Color.White;
            textBoxRemarks.Multiline = true;
            textBoxRemarks.Height = Css.WindowsForm.Constants.BIG_TEXT_BOX_HEIGHT;
            textBoxRemarks.Location = new Point(labelRemarks.Right, textBoxReference.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            //
            // labelSeparator3
            //
            labelSeparator3.AutoSize = false;
            labelSeparator3.Location = new Point(Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN, textBoxRemarks.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelSeparator3.Height = 2;
            labelSeparator3.BorderStyle = BorderStyle.Fixed3D;
            //
            // fileControl
            //
            fileControl.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelSeparator3.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
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
            Text = "Install";
            StartPosition = FormStartPosition.CenterScreen;
            Controls.Add(tabControl);
            Controls.Add(buttonOK);
            Controls.Add(buttonApply);
            Controls.Add(buttonCancel);
        }

        #endregion

        #region private void FillComboBoxes()

        private void FillComboBoxes()
        {
            if (currentDetail != null)
            {
                if (currentDetail is BaseDetail)
                    textBoxComponent.Text = currentDetail.ToString();
                else
                    textBoxComponent.Text = "P/N " + currentDetail.PartNumber + ", S/N " + currentDetail.SerialNumber;
                if (mode == MoveDetailFormMode.MoveToAircraft)
                    UpdateListOfAircraftsOfDetail(currentDetail);
                else
                    UpdateListOfStoresOfDetail(currentDetail);
            }
            else if (currentDetailsList != null && currentDetailsList.Count > 0)
            {
                if (currentDetailsList.Count == 1)
                {
                    if (currentDetailsList[0] is BaseDetail)
                        textBoxComponent.Text = currentDetailsList[0].ToString();
                    else
                        textBoxComponent.Text = "P/N " + currentDetailsList[0].PartNumber + ", S/N " + currentDetailsList[0].SerialNumber;
                }
                else
                    textBoxComponent.Text = currentDetailsList.Count + " items";
                if (mode == MoveDetailFormMode.MoveToAircraft)
                    UpdateListOfAircraftsOfDetail(currentDetailsList[0]);
                else
                    UpdateListOfStoresOfDetail(currentDetailsList[0]);
            }
            else if (currentBaseDetailsList != null && currentBaseDetailsList.Count > 0)
            {
                if (currentBaseDetailsList.Count == 1)
                    textBoxComponent.Text = currentBaseDetailsList[0].ToString();
                else
                    textBoxComponent.Text = currentBaseDetailsList.Count + " items";
                if (mode == MoveDetailFormMode.MoveToAircraft)
                    UpdateListOfAircraftsOfDetail(currentBaseDetailsList[0]);
                else
                    UpdateListOfStoresOfDetail(currentBaseDetailsList[0]);
            }
        }

        #endregion
        
        #region private void UpdateListOfAircraftsOfDetail(AbstractDetail detail)

        private void UpdateListOfAircraftsOfDetail(AbstractDetail detail)
        {
            List<Aircraft> aircrafts;
            if (detail is BaseDetail)
                aircrafts = ((Operator) detail.Parent.Parent).Aircrafts;
            else
                aircrafts = ((Operator) detail.Parent.Parent.Parent).Aircrafts;
            comboBoxBaseDetailContainer.Items.Clear();
            TransferRecord transferRecord = detail.GetPreLastTransferRecord();
            int aircraftID = transferRecord != null ? transferRecord.TransferContainer != null ? transferRecord.TransferContainer.Id : -1 : -1;
            int selectedIndex = 0;
            for (int i = 0; i < aircrafts.Count; i++)
            {
                comboBoxBaseDetailContainer.Items.Add(aircrafts[i]);
                if (aircrafts[i].ID == aircraftID)
                    selectedIndex = i;
            }
            if (comboBoxBaseDetailContainer.Items.Count > 0)
                comboBoxBaseDetailContainer.SelectedIndex = selectedIndex;
        }

        #endregion

        #region private void UpdateListOfStoresOfDetail(AbstractDetail detail)

        private void UpdateListOfStoresOfDetail(AbstractDetail detail)
        {
            List<Store> stores;
            if (detail is BaseDetail)
                stores = ((Operator)detail.Parent.Parent).Stores;
            else
                stores = ((Operator)detail.Parent.Parent.Parent).Stores;
            comboBoxBaseDetailContainer.Items.Clear();
            TransferRecord transferRecord = detail.GetPreLastTransferRecord();
            int storeID = transferRecord != null ? transferRecord.TransferContainer != null ? transferRecord.TransferContainer.Id : -1 : -1;
            int selectedIndex = 0;
            for (int i = 0; i < stores.Count; i++)
            {
                if (currentContainer == null || stores[i].ID != currentContainer.ID)
                    comboBoxBaseDetailContainer.Items.Add(stores[i]);
                if (stores[i].ID == storeID)
                    selectedIndex = i;
            }
            if (comboBoxBaseDetailContainer.Items.Count > 0)
                comboBoxBaseDetailContainer.SelectedIndex = selectedIndex;
        }

        #endregion
        
        #region private void UpdateListOfBaseDetails()

        private void UpdateListOfBaseDetails()
        {
            if (currentDetail != null)
                UpdateListOfBaseDetailsOfDetail(currentDetail);
            else if (currentDetailsList != null && currentDetailsList.Count > 0)
                UpdateListOfBaseDetailsOfDetail(currentDetailsList[0]);
            else if (currentBaseDetailsList != null && currentBaseDetailsList.Count > 0)
                UpdateListOfBaseDetailsOfDetail(currentBaseDetailsList[0]);
        }

        #endregion
        
        #region private void UpdateListOfBaseDetailsOfDetail(AbstractDetail detail)

        private void UpdateListOfBaseDetailsOfDetail(AbstractDetail detail)
        {
            comboBoxBaseDetails.Items.Clear();
            TransferRecord transferRecord = detail.GetPreLastTransferRecord();
            int baseDetailID = transferRecord != null ? transferRecord.TransferContainer != null ? transferRecord.TransferContainerId : -1: -1;
            int selectedIndex = 0;
            for (int i = 0; i < checkedBaseDetailContainer.BaseDetails.Length; i++)
            {
                comboBoxBaseDetails.Items.Add(checkedBaseDetailContainer.BaseDetails[i]);
                if (checkedBaseDetailContainer.BaseDetails[i].ID == baseDetailID)
                    selectedIndex = i;
            }
            if (comboBoxBaseDetails.Items.Count > 0)
                comboBoxBaseDetails.SelectedIndex = selectedIndex;
        }

        #endregion

        #region private void MoveToBaseDetail()

        private void MoveToBaseDetail()
        {
            if (currentDetail != null)
                MoveDetailToBaseDetail(currentDetail);
            else if (currentDetailsList != null)
            {
                int count = currentDetailsList.Count;
                if (count > 0)
                    for (int i = 0; i < count; i++ )
                        MoveDetailToBaseDetail(currentDetailsList[i]);
            }
            else if (currentBaseDetailsList != null)
            {
                int count = currentBaseDetailsList.Count;
                if (count > 0)
                    for (int i = 0; i < count; i++)
                        MoveDetailToBaseDetail(currentBaseDetailsList[i]);
            }
            DialogResult = DialogResult.OK;
        }

        #endregion

        #region private void MoveDetailToBaseDetail(AbstractDetail detail)

        private void MoveDetailToBaseDetail(AbstractDetail detail)
        {
            TransferRecord transferRecord = new TransferRecord();
            transferRecord.Description = textBoxRemarks.Text;
            transferRecord.RecordDate = dateTimePickerDate.Value;
            transferRecord.Position = textBoxPosition.Text;
            transferRecord.Reference = textBoxReference.Text;
            //transferRecord.AttachedFile = fileControl.AttachedFile;

            if (detail is Detail)
                ((Detail)detail).MoveDetail((BaseDetail)comboBoxBaseDetails.SelectedItem, transferRecord);
            if (detail is BaseDetail)
                ((BaseDetail)detail).MoveBaseDetail(checkedBaseDetailContainer, transferRecord);
            if (fileControl.AttachedFile != null)
            {
                transferRecord.AttachedFile.FileData = fileControl.AttachedFile.FileData;
                transferRecord.AttachedFile.FileName = fileControl.AttachedFile.FileName;
                transferRecord.Save(true);
            }
        }

        #endregion

        #region private void MoveToStore()

        private void MoveToStore()
        {
            if (currentDetail != null)
                MoveDetailToStore(currentDetail);
            else if (currentDetailsList != null)
            {
                int count = currentDetailsList.Count;
                if (count > 0)
                    for (int i = 0; i < count; i++)
                        MoveDetailToStore(currentDetailsList[i]);
            }
            else if (currentBaseDetailsList != null)
            {
                int count = currentBaseDetailsList.Count;
                if (count > 0)
                    for (int i = 0; i < count; i++)
                        MoveDetailToStore(currentBaseDetailsList[i]);
            }
            DialogResult = DialogResult.OK;
        }

        #endregion

        #region private void MoveDetailToStore(AbstractDetail detail)

        private void MoveDetailToStore(AbstractDetail detail)
        {
            TransferRecord transferRecord = new TransferRecord();
            transferRecord.RecordDate = dateTimePickerDate.Value;
            transferRecord.Description = textBoxRemarks.Text;
            transferRecord.Position = textBoxPosition.Text;
            transferRecord.Reference = textBoxReference.Text;

            if (detail is Detail)
                ((Detail)detail).MoveDetail(checkedBaseDetailContainer, transferRecord);
            if (detail is BaseDetail)
                ((BaseDetail)detail).MoveBaseDetail(checkedBaseDetailContainer, transferRecord);
            if (fileControl.AttachedFile != null)
            {
                transferRecord.AttachedFile.FileData = fileControl.AttachedFile.FileData;
                transferRecord.AttachedFile.FileName = fileControl.AttachedFile.FileName;
                transferRecord.Save(true);
            }
        }

        #endregion

        #region private void comboBoxBaseDetailContainer_SelectedIndexChanged(object sender, EventArgs e)

        private void comboBoxBaseDetailContainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedBaseDetailContainer = (Aircraft)((ComboBox)sender).SelectedItem;
            if (mode == MoveDetailFormMode.MoveToAircraft && !moveBaseDetails)
                UpdateListOfBaseDetails();
        }

        #endregion

        #region private void buttonOK_Click(object sender, EventArgs e)

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (mode == MoveDetailFormMode.MoveToAircraft)
                MoveToBaseDetail();
            else
                MoveToStore();
            Close();
        }

        #endregion

        #region private void buttonApply_Click(object sender, EventArgs e)

        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (mode == MoveDetailFormMode.MoveToAircraft)
                MoveToBaseDetail();
            else
                MoveToStore();
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
            textBoxComponent.Width =
            dateTimePickerDate.Width =
            comboBoxBaseDetailContainer.Width =
            comboBoxBaseDetails.Width =
            textBoxPosition.Width =
            textBoxReference.Width =
            textBoxRemarks.Width = tabControl.Width - Css.WindowsForm.Constants.TAB_LEFT_MARGIN - Css.WindowsForm.Constants.TAB_RIGHT_MARGIN - Css.WindowsForm.Constants.DefaultLabelSize.Width;
            labelSeparator.Width =
            labelSeparator2.Width =
            labelSeparator3.Width = tabControl.Width - Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN - Css.WindowsForm.Constants.TAB_SEPARATOR_RIGHT_MARGIN;
            fileControl.MinimumSize = new Size(Width - Css.WindowsForm.Constants.TAB_LEFT_MARGIN - Css.WindowsForm.Constants.TAB_RIGHT_MARGIN, 0);
            fileControl.MaximumSize = new Size(Width - Css.WindowsForm.Constants.TAB_LEFT_MARGIN - Css.WindowsForm.Constants.TAB_RIGHT_MARGIN, 300);
            buttonApply.Location = new Point(ClientSize.Width - Css.WindowsForm.Constants.RIGHT_MARGIN - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            buttonCancel.Location = new Point(buttonApply.Left - Css.WindowsForm.Constants.BUTTON_INTERVAL - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            buttonOK.Location = new Point(buttonCancel.Left - Css.WindowsForm.Constants.BUTTON_INTERVAL - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
        }

        #endregion

        #endregion

    }

    #region public enum MoveDetailFormMode

    /// <summary>
    /// Режим формы переноса
    /// </summary>
    public enum MoveDetailFormMode
    {
        /// <summary>
        /// Перенос агрегата(-ов) на ВС
        /// </summary>
        MoveToAircraft,
        /// <summary>
        /// Перенос агрегата(-ов) на склад
        /// </summary>
        MoveToStore
    }

    #endregion

}
