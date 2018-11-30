using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl;


namespace CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls
{
    /// <summary>
    /// Элемент управления для отображения информации о двигателях и ВСУ ВС
    /// </summary>
    public class EngineControl : PictureBox
    {

        #region Fields

        private const int HEIGHT_INTERVAL = 10;
        private const int TEXT_BOX_HEIGHT = 25;
        private const int TEXT_BOX_WIDTH = 150;
        private const int MARGIN = 20;
        private const int TOP_MARGIN = 20;
        private const int BOTTOM_MARGIN = 20;
        
        //private static readonly Size STANDART_SIZE = new Size(TEXT_BOX_WIDTH * 2, (TEXT_BOX_HEIGHT + HEIGHT_INTERVAL) * 16 + TOP_MARGIN + BOTTOM_MARGIN);
        private static readonly Size STANDART_SIZE = new Size(TEXT_BOX_WIDTH * 2, (TEXT_BOX_HEIGHT + HEIGHT_INTERVAL) * 6 + TOP_MARGIN + BOTTOM_MARGIN);
        
        private readonly Label labelCaption = new Label();
        private readonly Label labelEngineModel = new Label();
        private readonly Label labelManufacturer = new Label();
        private readonly Label labelPosition = new Label();
        private readonly Label labelSerialNumber = new Label();
        private readonly Label labelTSNCSN = new Label();
        private readonly Label labelCompliance = new Label();
        private readonly Label labelComplianceTSNCSN = new Label();
        private readonly Label labelComplianceDate = new Label();
        private readonly Label labelComplianceWorkType = new Label();
        private readonly Label labelNext = new Label();
        private readonly Label labelNextTSNCSN = new Label();
        private readonly Label labelNextDate = new Label();
        private readonly Label labelNextRemains = new Label();
        private readonly Label labelNextWorkType = new Label();
        private readonly TextBox textBoxEngineModel = new TextBox();
        private readonly TextBox textBoxManufacturer = new TextBox();
        private readonly TextBox textBoxPosition = new TextBox();
        private readonly TextBox textBoxSerialNumber = new TextBox();
        private readonly TextBox textBoxTSNCSN = new TextBox();
        private readonly TextBox textBoxComplianceTSNCSN = new TextBox();
        private readonly TextBox textBoxComplianceDate = new TextBox();
        private readonly TextBox textBoxComplianceWorktype = new TextBox();
        private readonly TextBox textBoxNextTSNCSN = new TextBox();
        private readonly TextBox textBoxNextDate = new TextBox();
        private readonly TextBox textBoxNextRemains = new TextBox();
        private readonly TextBox textBoxNextWorkType = new TextBox();
        private readonly ReferenceLinkLabel linkViewInfo = new ReferenceLinkLabel();
        private BaseDetail currentBaseDetail;
        private DateTime dateAsOf;
        private bool showLabels;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения информации о двигателях и ВСУ ВС
        /// </summary>
        public EngineControl(BaseDetail currentBaseDetail, DateTime dateAsOf, bool showLabels, bool showCaption)
        {
            this.currentBaseDetail = currentBaseDetail;
            this.dateAsOf = dateAsOf;
            this.showLabels = showLabels;
            labelCaption.Visible = showCaption;
            //
            // labelCaption
            //
            labelCaption.Location = new Point(TEXT_BOX_WIDTH, TOP_MARGIN);
            labelCaption.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelCaption.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelCaption.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            labelCaption.Text = "Engine Pos #" + currentBaseDetail.PositionNumber;
            labelCaption.TextAlign = ContentAlignment.MiddleCenter;
            //
            // labelEngineModel
            //
            labelEngineModel.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelEngineModel.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelEngineModel.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            labelEngineModel.Text = "Engine Model";
            labelEngineModel.TextAlign = ContentAlignment.MiddleLeft;
            if (showCaption)
            {
                labelEngineModel.Location = new Point(0, labelCaption.Bottom + HEIGHT_INTERVAL);
                textBoxEngineModel.Location = new Point(TEXT_BOX_WIDTH, labelCaption.Bottom + HEIGHT_INTERVAL);
                Size = STANDART_SIZE;
            }
            else
            {
                labelEngineModel.Location = new Point(0, TOP_MARGIN);
                textBoxEngineModel.Location = new Point(TEXT_BOX_WIDTH, TOP_MARGIN);
                Size = new Size(STANDART_SIZE.Width, STANDART_SIZE.Height - HEIGHT_INTERVAL - TEXT_BOX_HEIGHT);
            }
            //
            // labelManufacturer
            //
            labelManufacturer.Location = new Point(0, labelEngineModel.Bottom + HEIGHT_INTERVAL);
            labelManufacturer.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelManufacturer.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelManufacturer.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            labelManufacturer.Text = "Manufacturer";
            labelManufacturer.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelPosition
            //
            labelPosition.Location = new Point(0, labelManufacturer.Bottom + HEIGHT_INTERVAL);
            labelPosition.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelPosition.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelPosition.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            labelPosition.Text = "Position";
            labelPosition.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelSerialNumber
            //
            labelSerialNumber.Location = new Point(0, labelPosition.Bottom + HEIGHT_INTERVAL);
            labelSerialNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelSerialNumber.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelSerialNumber.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            labelSerialNumber.Text = "Serial Number";
            labelSerialNumber.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelTSNCSN
            //
            labelTSNCSN.Location = new Point(0, labelSerialNumber.Bottom + HEIGHT_INTERVAL);
            labelTSNCSN.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelTSNCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelTSNCSN.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            labelTSNCSN.Text = "TSN/CSN";
            labelTSNCSN.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelCompliance
            //
            labelCompliance.Location = new Point(0, labelTSNCSN.Bottom + HEIGHT_INTERVAL);
            labelCompliance.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelCompliance.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelCompliance.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            labelCompliance.Text = "Compliance";
            labelCompliance.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelComplianceTSNCSN
            //
            labelComplianceTSNCSN.Location = new Point(MARGIN, labelCompliance.Bottom + HEIGHT_INTERVAL);
            labelComplianceTSNCSN.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelComplianceTSNCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelComplianceTSNCSN.Size = new Size(TEXT_BOX_WIDTH - MARGIN, TEXT_BOX_HEIGHT);
            labelComplianceTSNCSN.Text = "TSN/CSN";
            labelComplianceTSNCSN.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelComplianceDate
            //
            labelComplianceDate.Location = new Point(MARGIN, labelComplianceTSNCSN.Bottom + HEIGHT_INTERVAL);
            labelComplianceDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelComplianceDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelComplianceDate.Size = new Size(TEXT_BOX_WIDTH - MARGIN, TEXT_BOX_HEIGHT);
            labelComplianceDate.Text = "Date";
            labelComplianceDate.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelComplianceWorkType
            //
            labelComplianceWorkType.Location = new Point(MARGIN, labelComplianceDate.Bottom + HEIGHT_INTERVAL);
            labelComplianceWorkType.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelComplianceWorkType.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelComplianceWorkType.Size = new Size(TEXT_BOX_WIDTH - MARGIN, TEXT_BOX_HEIGHT);
            labelComplianceWorkType.Text = "Work Type";
            labelComplianceWorkType.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelNext
            //
            labelNext.Location = new Point(0, labelComplianceWorkType.Bottom + HEIGHT_INTERVAL);
            labelNext.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelNext.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelNext.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            labelNext.Text = "Next";
            labelNext.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelNextTSNCSN
            //
            labelNextTSNCSN.Location = new Point(MARGIN, labelNext.Bottom + HEIGHT_INTERVAL);
            labelNextTSNCSN.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelNextTSNCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelNextTSNCSN.Size = new Size(TEXT_BOX_WIDTH - MARGIN, TEXT_BOX_HEIGHT);
            labelNextTSNCSN.Text = "TSN/CSN";
            labelNextTSNCSN.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelNextDate
            //
            labelNextDate.Location = new Point(MARGIN, labelNextTSNCSN.Bottom + HEIGHT_INTERVAL);
            labelNextDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelNextDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelNextDate.Size = new Size(TEXT_BOX_WIDTH - MARGIN, TEXT_BOX_HEIGHT);
            labelNextDate.Text = "Date";
            labelNextDate.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelNextRemains
            //
            labelNextRemains.Location = new Point(MARGIN, labelNextDate.Bottom + HEIGHT_INTERVAL);
            labelNextRemains.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelNextRemains.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelNextRemains.Size = new Size(TEXT_BOX_WIDTH - MARGIN, TEXT_BOX_HEIGHT);
            labelNextRemains.Text = "Remains";
            labelNextRemains.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelNextRemains
            //
            labelNextWorkType.Location = new Point(MARGIN, labelNextRemains.Bottom + HEIGHT_INTERVAL);
            labelNextWorkType.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelNextWorkType.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelNextWorkType.Size = new Size(TEXT_BOX_WIDTH - MARGIN, TEXT_BOX_HEIGHT);
            labelNextWorkType.Text = "Work Type";
            labelNextWorkType.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxEngineModel
            //
            textBoxEngineModel.BackColor = Color.White;
            textBoxEngineModel.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxEngineModel.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxEngineModel.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxManufacturer
            //
            textBoxManufacturer.Location = new Point(TEXT_BOX_WIDTH, textBoxEngineModel.Bottom + HEIGHT_INTERVAL);
            textBoxManufacturer.BackColor = Color.White;
            textBoxManufacturer.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxManufacturer.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxManufacturer.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxPosition
            //
            textBoxPosition.Location = new Point(TEXT_BOX_WIDTH, textBoxManufacturer.Bottom + HEIGHT_INTERVAL);
            textBoxPosition.BackColor = Color.White;
            textBoxPosition.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxPosition.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxPosition.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxSerialNumber
            //
            textBoxSerialNumber.Location = new Point(TEXT_BOX_WIDTH, textBoxPosition.Bottom + HEIGHT_INTERVAL);
            textBoxSerialNumber.BackColor = Color.White;
            textBoxSerialNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxSerialNumber.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxSerialNumber.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxTSNCSN
            //
            textBoxTSNCSN.Location = new Point(TEXT_BOX_WIDTH, textBoxSerialNumber.Bottom + HEIGHT_INTERVAL);
            textBoxTSNCSN.BackColor = Color.White;
            textBoxTSNCSN.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxTSNCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxTSNCSN.ReadOnly = true;
            textBoxTSNCSN.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxComplianceTSNCSN
            //
            textBoxComplianceTSNCSN.Location = new Point(TEXT_BOX_WIDTH, labelCompliance.Bottom + HEIGHT_INTERVAL);
            textBoxComplianceTSNCSN.BackColor = Color.White;
            textBoxComplianceTSNCSN.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxComplianceTSNCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxComplianceTSNCSN.ReadOnly = true;
            textBoxComplianceTSNCSN.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxComplianceDate
            //
            textBoxComplianceDate.Location = new Point(TEXT_BOX_WIDTH, textBoxComplianceTSNCSN.Bottom + HEIGHT_INTERVAL);
            textBoxComplianceDate.BackColor = Color.White;
            textBoxComplianceDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxComplianceDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxComplianceDate.ReadOnly = true;
            textBoxComplianceDate.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxComplianceWorktype
            //
            textBoxComplianceWorktype.Location = new Point(TEXT_BOX_WIDTH, textBoxComplianceDate.Bottom + HEIGHT_INTERVAL);
            textBoxComplianceWorktype.BackColor = Color.White;
            textBoxComplianceWorktype.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxComplianceWorktype.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxComplianceWorktype.ReadOnly = true;
            textBoxComplianceWorktype.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxNextTSNCSN
            //
            textBoxNextTSNCSN.Location = new Point(TEXT_BOX_WIDTH, labelNext.Bottom + HEIGHT_INTERVAL);
            textBoxNextTSNCSN.BackColor = Color.White;
            textBoxNextTSNCSN.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxNextTSNCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxNextTSNCSN.ReadOnly = true;
            textBoxNextTSNCSN.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxNextDate
            //
            textBoxNextDate.Location = new Point(TEXT_BOX_WIDTH, textBoxNextTSNCSN.Bottom + HEIGHT_INTERVAL);
            textBoxNextDate.BackColor = Color.White;
            textBoxNextDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxNextDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxNextDate.ReadOnly = true;
            textBoxNextDate.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxNextRemains
            //
            textBoxNextRemains.Location = new Point(TEXT_BOX_WIDTH, textBoxNextDate.Bottom + HEIGHT_INTERVAL);
            textBoxNextRemains.BackColor = Color.White;
            textBoxNextRemains.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxNextRemains.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxNextRemains.ReadOnly = true;
            textBoxNextRemains.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxNextWorkType
            //
            textBoxNextWorkType.Location = new Point(TEXT_BOX_WIDTH, textBoxNextRemains.Bottom + HEIGHT_INTERVAL);
            textBoxNextWorkType.BackColor = Color.White;
            textBoxNextWorkType.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxNextWorkType.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxNextWorkType.ReadOnly = true;
            textBoxNextWorkType.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // linkViewInfo
            //
            //linkViewInfo.Location = new Point(0, textBoxNextWorkType.Bottom + HEIGHT_INTERVAL);
            linkViewInfo.Location = new Point(0, textBoxTSNCSN.Bottom + HEIGHT_INTERVAL);
            linkViewInfo.Font = Css.SimpleLink.Fonts.Font;
            linkViewInfo.LinkColor = Css.SimpleLink.Colors.LinkColor;
            linkViewInfo.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            linkViewInfo.Text = "View Info";
            linkViewInfo.TextAlign = ContentAlignment.MiddleLeft;
            linkViewInfo.ReflectionType = ReflectionTypes.DisplayInNew;
            linkViewInfo.DisplayerText = currentBaseDetail.ParentAircraft.RegistrationNumber + ". Base Component " + currentBaseDetail.SerialNumber;
            linkViewInfo.DisplayerRequested += linkViewInfo_DisplayerRequested;

            

            Controls.Add(labelCaption);
            Controls.Add(labelEngineModel);
            Controls.Add(labelManufacturer);
            Controls.Add(labelPosition);
            Controls.Add(labelSerialNumber);
            Controls.Add(labelTSNCSN);
/*            Controls.Add(labelCompliance);
            Controls.Add(labelComplianceTSNCSN);
            Controls.Add(labelComplianceDate);
            Controls.Add(labelComplianceWorkType);
            Controls.Add(labelNext);
            Controls.Add(labelNextTSNCSN);
            Controls.Add(labelNextDate);
            Controls.Add(labelNextRemains);
            Controls.Add(labelNextWorkType);*/
            Controls.Add(textBoxEngineModel);
            Controls.Add(textBoxManufacturer);
            Controls.Add(textBoxPosition);
            Controls.Add(textBoxSerialNumber);
            Controls.Add(textBoxTSNCSN);
            /*Controls.Add(textBoxComplianceTSNCSN);
            Controls.Add(textBoxComplianceDate);
            Controls.Add(textBoxComplianceWorktype);
            Controls.Add(textBoxNextTSNCSN);
            Controls.Add(textBoxNextDate);
            Controls.Add(textBoxNextRemains);
            Controls.Add(textBoxNextWorkType);*/
            Controls.Add(linkViewInfo);

            UpdateControl();
            HideShowLabels(showLabels);

        }
        

        #endregion

        #region Properties

        #region public BaseDetail BaseDetail

        /// <summary>
        /// Возвращает или устанавливает текущий базовый агрегат
        /// </summary>
        public BaseDetail BaseDetail
        {
            get
            {
                return currentBaseDetail;
            }
            set
            {
                currentBaseDetail = value;
                UpdateControl();
            }
        }

        #endregion
        
        #region public static Size StandartSize

        /// <summary>
        /// Возвращает стандартный размер данного элемента управления
        /// </summary>
        public static Size StandartSize
        {
            get
            {
                return STANDART_SIZE;
            }
        }

        #endregion

        #region public bool ShowLabels

        /// <summary>
        /// Возвращает или устанавливает значение, показывающее нужно ли отображать названия полей
        /// </summary>
        public bool ShowLabels
        {
            get
            {
                return showLabels;
            }
            set
            {
                showLabels = value;
                HideShowLabels(value);
            }
        }

        #endregion

        #region public DateTime DateAsOf

        /// <summary>
        /// Возвращает или устанавливает дату DateAsOf
        /// </summary>
        public DateTime DateAsOf
        {
            get
            {
                return dateAsOf;
            }
            set
            {
                dateAsOf = value;
                UpdateDateAsOf();
            }
        }

        #endregion

        #endregion

        #region Methods

        #region private void HideShowLabels(bool showLabels)

        /// <summary>
        /// Метод, предназначенный для скрытия названий полей
        /// </summary>
        /// <param name="showTextBoxNames">Нужно ли показывать названия полей</param>
        private void HideShowLabels(bool showTextBoxNames)
        {
            labelEngineModel.Visible = showTextBoxNames;
            labelManufacturer.Visible = showTextBoxNames;
            labelPosition.Visible = showTextBoxNames;
            labelSerialNumber.Visible = showTextBoxNames;
            labelTSNCSN.Visible = showTextBoxNames;
            labelCompliance.Visible = showTextBoxNames;
            labelComplianceTSNCSN.Visible = showTextBoxNames;
            labelComplianceDate.Visible = showTextBoxNames;
            labelComplianceWorkType.Visible = showTextBoxNames;
            labelNext.Visible = showTextBoxNames;
            labelNextTSNCSN.Visible = showTextBoxNames;
            labelNextDate.Visible = showTextBoxNames;
            labelNextRemains.Visible = showTextBoxNames;
            labelNextWorkType.Visible = showTextBoxNames;
            int left;
            if (showTextBoxNames)
            {
                left = TEXT_BOX_WIDTH;
                Width = STANDART_SIZE.Width;
            }
            else
            {
                left = 0;
                Width = TEXT_BOX_WIDTH;
            }
            textBoxEngineModel.Left = left;
            textBoxManufacturer.Left = left;
            textBoxPosition.Left = left;
            textBoxSerialNumber.Left = left;
            textBoxTSNCSN.Left = left;
            textBoxComplianceTSNCSN.Left = left;
            textBoxComplianceDate.Left = left;
            textBoxComplianceWorktype.Left = left;
            textBoxNextTSNCSN.Left = left;
            textBoxNextDate.Left = left;
            textBoxNextRemains.Left = left;
            textBoxNextWorkType.Left = left;
            labelCaption.Left = left;
            linkViewInfo.Left = left;
        }

        #endregion

        #region private void CheckPermission()

        /// <summary>
        /// Метод, проверяющий права доступа текущего пользователя и блокирует при необходимости текстовые поля
        /// </summary>
        private void CheckPermission()
        {
            bool permission = currentBaseDetail.HasPermission(Users.CurrentUser, DataEvent.Update);

            textBoxEngineModel.ReadOnly = !permission;
            textBoxManufacturer.ReadOnly = !permission;
            textBoxPosition.ReadOnly = !permission;
            textBoxSerialNumber.ReadOnly = !permission;
        }

        #endregion

        #region public bool GetChangeStatus()

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        public bool GetChangeStatus()
        {
            return ((textBoxEngineModel.Text != currentBaseDetail.Model) ||
                    (textBoxManufacturer.Text != currentBaseDetail.Manufacturer) ||
                    (textBoxPosition.Text != currentBaseDetail.PositionNumber) ||
                    (textBoxSerialNumber.Text != currentBaseDetail.SerialNumber));
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Сохранаяет данные текущего базового агрегата
        /// </summary>
        public void SaveData()
        {
            if (currentBaseDetail == null)
                return;
            if (textBoxEngineModel.Text != currentBaseDetail.Model)
                currentBaseDetail.Model = textBoxEngineModel.Text;
            if (textBoxManufacturer.Text != currentBaseDetail.Manufacturer)
                currentBaseDetail.Manufacturer = textBoxManufacturer.Text;
            if (textBoxPosition.Text != currentBaseDetail.PositionNumber)
            {
                TransferRecord transferRecord = currentBaseDetail.GetLastTransferRecord();
                transferRecord.Position = textBoxPosition.Text;
                transferRecord.Save();
            }
            if (textBoxSerialNumber.Text != currentBaseDetail.SerialNumber)
                currentBaseDetail.SerialNumber = textBoxSerialNumber.Text;
        }

        #endregion

        #region private void UpdateControl()

        /// <summary>
        /// Обновляет информацию о базовом агрегате текущего ВС
        /// </summary>
        private void UpdateControl()
        {
            if (currentBaseDetail == null)
                return;
            textBoxSerialNumber.Text = currentBaseDetail.SerialNumber;
            textBoxEngineModel.Text = currentBaseDetail.Model;
            textBoxManufacturer.Text = currentBaseDetail.Manufacturer;
            textBoxPosition.Text = currentBaseDetail.PositionNumber;
            textBoxTSNCSN.Text = currentBaseDetail.Lifelength.ToComplianceItemString();
            CheckPermission();
        }

        #endregion

        #region private void UpdateDateAsOf()

        private void UpdateDateAsOf()
        {
/*
            BaseDetail clonedBaseDetail;
            object objectClone = currentBaseDetail.CloneAsDateOf(dateAsOf);
            if (!(objectClone is BaseDetail))
                return;
            clonedBaseDetail = (BaseDetail) objectClone;
            textBoxTSNCSN.Text = clonedBaseDetail.Lifelength.ToComplianceItemString();
            if (clonedBaseDetail.Limitation.LastPerformance != null)
                textBoxComplianceTSNCSN.Text = clonedBaseDetail.Limitation.LastPerformance.Lifelength.ToComplianceItemString();
            else
                textBoxComplianceTSNCSN.Text = "";
            if (clonedBaseDetail.Limitation.LastPerformance != null)
                textBoxComplianceDate.Text = clonedBaseDetail.Limitation.LastPerformance.RecordDate.ToString(new TermsProvider()["DateFormat"].ToString());
            else
                textBoxComplianceDate.Text = "";
            if (clonedBaseDetail.Limitation.LastPerformance != null)
                textBoxComplianceWorktype.Text = clonedBaseDetail.Limitation.LastPerformance.RecordType.FullName;
            else
                textBoxComplianceWorktype.Text = "";
            textBoxNextTSNCSN.Text = clonedBaseDetail.Limitation.NextPerformance.ToComplianceItemString();
            textBoxNextDate.Text = UsefulMethods.NormalizeDate(clonedBaseDetail.Limitation.NextPerformanceDate);
            textBoxNextRemains.Text = clonedBaseDetail.Limitation.LeftTillNextPerformance.ToComplianceItemStringFull();
            if (clonedBaseDetail.Limitation.NextWorkType != null)
                textBoxNextWorkType.Text = clonedBaseDetail.Limitation.NextWorkType.FullName;
            else
                textBoxNextWorkType.Text = ""; todo
*/
        }

        #endregion
        
        #region private void linkLogBook_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkLogBook_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            //e.RequestedEntity = new DispatcheredBaseDetailLogBookScreen(currentBaseDetail);
        }

        #endregion

        #region private void linkViewInfo_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkViewInfo_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.RequestedEntity = new DispatcheredDetailScreen(currentBaseDetail);
        }

        #endregion

        #endregion

    }
}
