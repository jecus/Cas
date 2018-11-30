using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Directives;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.LogBookControls;

namespace CAS.UI.UIControls.ModificationsPerformed
{
    ///<summary>
    /// Отображает информацию о <see cref="ModificationItem"/>
    ///</summary>
    public class ModificationItemControl : UserControl, IReference
    {

        #region Fields

        private const int MARGIN = 10;
        private const int LABEL_WIDTH = 150;
        private const int LABEL_HEIGHT = 25;
        private const int TEXTBOX_WIDTH = 350;
        private const int CHECK_BOX_WIDTH = 150;
        private const int HEIGHT_INTERVAL = 20;
        private const int HEIGHT_LIFELENGTH_INTERVAL = HEIGHT_INTERVAL - 5;
        private const int WIDTH_INTERVAL =600;


        private ModificationItem currentItem;
        
        private readonly Label labelSBSLNo;
        private readonly Label labelEngineeringOrderNo;
        private readonly Label labelADNo;
        private readonly Label labelDescription;
        private readonly Label labelDateOfPerform;
        private readonly Label labelStampPPCD;
        private readonly Label labelWorkPackage;
        private readonly Label labelRemarks;
        private readonly TextBox textBoxSBSLNo;
        private readonly TextBox textboxEngineeringOrderNo;
        private readonly TextBox textboxADNo;
        private readonly TextBox textBoxDescription;
        private readonly DateTimePicker dateTimePickerDateOfPerform;
        private readonly TextBox textboxStampPPCD;
        private readonly TextBox textboxWorkPackage;
        private readonly TextBox textboxRemarks;

        #endregion

        #region Constructors

        #region public ModificationItemControl()

        ///<summary>
        /// Создает элемент управления, для отображания информации о <see cref="ModificationItem"/>
        ///</summary>
        public ModificationItemControl()
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Css.CommonAppearance.Colors.BackColor;
            
            labelSBSLNo = new Label();
            labelEngineeringOrderNo = new Label();
            labelADNo = new Label();
            labelDescription = new Label();
            labelDateOfPerform = new Label();
            labelStampPPCD = new Label();
            labelWorkPackage = new Label();
            labelRemarks = new Label();
            textBoxSBSLNo = new TextBox();
            textboxEngineeringOrderNo = new TextBox();
            textboxADNo = new TextBox();
            textBoxDescription = new TextBox();
            dateTimePickerDateOfPerform = new DateTimePicker();
            textboxStampPPCD = new TextBox();
            textboxWorkPackage = new TextBox();
            textboxRemarks = new TextBox();
            // 
            // labelSBSLNo
            // 
            labelSBSLNo.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelSBSLNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelSBSLNo.Location = new Point(MARGIN, MARGIN);// + LABEL_HEIGHT + HEIGHT_INTERVAL);
            labelSBSLNo.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelSBSLNo.Text = "SB/SL No";
            //
            // textBoxSBSLNo
            //
            textBoxSBSLNo.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxSBSLNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxSBSLNo.Location = new Point(labelSBSLNo.Right, MARGIN);
            textBoxSBSLNo.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxSBSLNo.MaxLength = 50;
            // 
            // labelEngineeringOrderNo
            // 
            labelEngineeringOrderNo.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelEngineeringOrderNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelEngineeringOrderNo.Location = new Point(MARGIN, labelSBSLNo.Bottom + HEIGHT_INTERVAL);
            labelEngineeringOrderNo.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelEngineeringOrderNo.Text = "Eng. Order No";
            // 
            // textboxEngineeringOrderNo
            // 
            textboxEngineeringOrderNo.BackColor = Color.White;
            textboxEngineeringOrderNo.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxEngineeringOrderNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxEngineeringOrderNo.Location = new Point(labelEngineeringOrderNo.Right, textBoxSBSLNo.Bottom + HEIGHT_INTERVAL);
            textboxEngineeringOrderNo.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textboxEngineeringOrderNo.MaxLength = 50;
            // 
            // labelEffectiveDate
            // 
            labelADNo.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelADNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelADNo.Location = new Point(MARGIN, labelEngineeringOrderNo.Bottom + HEIGHT_INTERVAL);
            labelADNo.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelADNo.Text = "AD No";
            //
            //  textboxADNo
            //
            textboxADNo.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxADNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxADNo.Location = new Point(labelADNo.Right, textboxEngineeringOrderNo.Bottom + HEIGHT_INTERVAL);
            textboxADNo.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textboxADNo.MaxLength = 50;
            // 
            // labelDescription
            // 
            labelDescription.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelDescription.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelDescription.Location = new Point(MARGIN, labelADNo.Bottom + HEIGHT_INTERVAL);
            labelDescription.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelDescription.Text = "Subject/Description";
            // 
            // textBoxDescription
            // 
            textBoxDescription.BackColor = Color.White;
            textBoxDescription.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxDescription.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxDescription.Location = new Point(labelDescription.Right, textboxADNo.Bottom + HEIGHT_INTERVAL);
            textBoxDescription.Size = new Size(TEXTBOX_WIDTH, 3 * LABEL_HEIGHT + 2 * HEIGHT_INTERVAL);
            textBoxDescription.Multiline = true;
            // 
            // labelDateOfPerform
            // 
            labelDateOfPerform.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelDateOfPerform.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelDateOfPerform.Location = new Point(WIDTH_INTERVAL, MARGIN);
            labelDateOfPerform.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelDateOfPerform.Text = "Date of Perform";
            // 
            // dateTimePickerDateOfPerform
            // 
            dateTimePickerDateOfPerform.BackColor = Color.White;
            dateTimePickerDateOfPerform.Font = Css.OrdinaryText.Fonts.RegularFont;
            dateTimePickerDateOfPerform.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            dateTimePickerDateOfPerform.Location = new Point(labelDateOfPerform.Right, MARGIN);
            dateTimePickerDateOfPerform.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            dateTimePickerDateOfPerform.Format = DateTimePickerFormat.Custom;
            dateTimePickerDateOfPerform.CustomFormat = new TermsProvider()["DateFormat"].ToString();
            // 
            // labelStampPPCD
            // 
            labelStampPPCD.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelStampPPCD.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelStampPPCD.Location = new Point(WIDTH_INTERVAL, dateTimePickerDateOfPerform.Bottom + HEIGHT_INTERVAL);
            labelStampPPCD.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelStampPPCD.Text = "Stamp PPCD";
            // 
            // textboxStampPPCD
            // 
            textboxStampPPCD.BackColor = Color.White;
            textboxStampPPCD.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxStampPPCD.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxStampPPCD.Location = new Point(labelStampPPCD.Right, dateTimePickerDateOfPerform.Bottom + HEIGHT_INTERVAL);
            textboxStampPPCD.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textboxStampPPCD.MaxLength = 10;
            // 
            // labelWorkPackage
            // 
            labelWorkPackage.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelWorkPackage.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelWorkPackage.Location = new Point(WIDTH_INTERVAL, labelStampPPCD.Bottom + HEIGHT_INTERVAL);
            labelWorkPackage.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelWorkPackage.Text = "Work Package";
            // 
            // textboxWorkPackage
            // 
            textboxWorkPackage.BackColor = Color.White;
            textboxWorkPackage.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxWorkPackage.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxWorkPackage.Location = new Point(labelWorkPackage.Right, textboxStampPPCD.Bottom + HEIGHT_INTERVAL);
            textboxWorkPackage.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textboxWorkPackage.MaxLength = 10;
            // 
            // labelRemarks
            // 
            labelRemarks.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelRemarks.Location = new Point(WIDTH_INTERVAL, labelWorkPackage.Bottom + HEIGHT_INTERVAL);
            labelRemarks.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelRemarks.Text = "Remarks";
            // 
            // textboxRemarks
            // 
            textboxRemarks.ScrollBars = ScrollBars.Vertical;
            textboxRemarks.BackColor = Color.White;
            textboxRemarks.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxRemarks.Location = new Point(labelRemarks.Right, textboxWorkPackage.Bottom + HEIGHT_INTERVAL);
            textboxRemarks.Size = new Size(TEXTBOX_WIDTH, 3 * LABEL_HEIGHT + 2 * HEIGHT_INTERVAL);
            textboxRemarks.Multiline = true;

            Controls.Add(labelSBSLNo);
            Controls.Add(textBoxSBSLNo);
            Controls.Add(labelEngineeringOrderNo);
            Controls.Add(textboxEngineeringOrderNo);
            Controls.Add(labelADNo);
            Controls.Add(textboxADNo);
            Controls.Add(labelDescription);
            Controls.Add(textBoxDescription);
            Controls.Add(labelDateOfPerform);
            Controls.Add(dateTimePickerDateOfPerform);
            Controls.Add(labelStampPPCD);
            Controls.Add(textboxStampPPCD);
            Controls.Add(labelWorkPackage);
            Controls.Add(textboxWorkPackage);
            Controls.Add(labelRemarks);
            Controls.Add(textboxRemarks);
        }

        #endregion

        #region public ModificationItemControl(ModificationItem item) : this()

        ///<summary>
        /// Создает элемент управления, для отображания информации о <see cref="ModificationItem"/>
        ///</summary>
        ///<param name="item">ModificationItem</param>
        public ModificationItemControl(ModificationItem item) : this()
        {
            if (null == item)
                throw new ArgumentNullException("item", "Argument cannot be null");
            currentItem = item;
        }

        #endregion

        #endregion

        #region Properties

        #region public ModificationItem CurrentItem

        /// <summary>
        /// Текущий ModificationItem
        /// </summary>
        public ModificationItem CurrentItem
        {
            get
            {
                return currentItem;
            }
            set
            {
                currentItem = value;
            }
        }

        #endregion

        #region public TextBox TextBoxSBSLNo

        /// <summary>
        /// Возвращает текстбокс с названием SB, в котором проводились изменения
        /// </summary>
        public TextBox TextBoxSBSLNo
        {
            get { return textBoxSBSLNo; }
        }

        #endregion

        #region public string SBSLNo

        /// <summary>
        /// Возвращает название Service Bulletin, в котором проводились изменения
        /// </summary>
        public string SBSLNo
        {
            get
            {
                return textBoxSBSLNo.Text;
            }
            set
            {
                textBoxSBSLNo.Text = value;
            }
        }

        #endregion

        #region public string EngineeringOrderNo

        /// <summary>
        /// Возвращает название Engineering Order, в котором проводились изменения
        /// </summary>
        public string EngineeringOrderNo
        {
            get
            {
                return textboxEngineeringOrderNo.Text;
            }
            set
            {
                textboxEngineeringOrderNo.Text = value;
            }
        }

        #endregion

        #region public string AirworthinessDirectiveNo

        /// <summary>
        /// Возвращает название Airworthiness Directive, в котором проводились изменения
        /// </summary>
        public string AirworthinessDirectiveNo
        {
            get
            {
                return textboxADNo.Text;
            }
            set
            {
                textboxADNo.Text = value;
            }
        }

        #endregion

        #region public string Description

        /// <summary>
        /// Description текущего ModificationItem
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

        #region public DateTime DateOfPerform

        /// <summary>
        /// Возвращает дату внесения изменений
        /// </summary>
        public DateTime DateOfPerform
        {
            get
            {
                return dateTimePickerDateOfPerform.Value;
            }
            set
            {
                dateTimePickerDateOfPerform.Value = value;
            }
        }

        #endregion

        #region public string StampPPCD

        /// <summary>
        /// Возвращает код техника, который выполнил модификацию
        /// </summary>
        public string StampPPCD
        {
            get
            {
                return textboxStampPPCD.Text;
            }
            set
            {
                textboxStampPPCD.Text = value;
            }
        }

        #endregion

        #region public string NumberWorkPackage

        /// <summary>
        /// WorkPackage текущего ModificationItem
        /// </summary>
        public string NumberWorkPackage
        {
            get
            {
                return textboxWorkPackage.Text;
            }
            set
            {
                textboxWorkPackage.Text = value;
            }
        }

        #endregion

        #region public string Remarks

        /// <summary>
        /// Возвращает замечания инженеров
        /// </summary>
        public string Remarks
        {
            get
            {
                return textboxRemarks.Text;
            }
            set
            {
                textboxRemarks.Text = value;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region public bool GetChangeStatus(bool directiveExist)

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <param name="directiveExist">Показывает, существует ли уже ModificationItem или нет</param>
        /// <returns></returns>
        public bool GetChangeStatus(bool directiveExist)
        {
            Date dateOfPerform = new Date(DateOfPerform);
            Date today = new Date(DateTime.Today);
            if (directiveExist)
                return ((SBSLNo != currentItem.SbNo) ||
                        (EngineeringOrderNo != currentItem.EngineeringOrderNo) ||
                        (AirworthinessDirectiveNo != currentItem.AirworthinessDirectiveNo) ||
                        (Description != currentItem.Description) ||
                        (DateOfPerform != currentItem.DateOfPerform) ||
                        (StampPPCD != currentItem.StampPPCD) ||
                        (NumberWorkPackage != currentItem.NumberWorkPackage) ||
                        (Remarks != currentItem.Remarks));
            else
                return ((SBSLNo != "") ||
                        (EngineeringOrderNo != "") ||
                        (AirworthinessDirectiveNo != "") ||
                        (Description != "") ||
                        (dateOfPerform.ToDateTime() != today.ToDateTime()) ||
                        (StampPPCD != "") ||
                        (NumberWorkPackage != "") ||
                        (Remarks != ""));
        }

        #endregion

        #region public void UpdateInformation()

        /// <summary>
        /// Заполняет поля для редактирования ModificationItem
        /// </summary>
        public void UpdateInformation()
        {
            if (currentItem != null)
                UpdateInformation(currentItem);
        }

        #endregion

        #region public void UpdateInformation(ModificationItem sourceModificationItem)

        /// <summary>
        /// Заполняет поля для редактирования ModificationItem
        /// </summary>
        /// <param name="sourceModificationItem"></param>
        public void UpdateInformation(ModificationItem sourceModificationItem)
        {
            if (sourceModificationItem == null) 
                throw new ArgumentNullException("sourceModificationItem");
            SBSLNo = sourceModificationItem.SbNo;
            EngineeringOrderNo = sourceModificationItem.EngineeringOrderNo;
            AirworthinessDirectiveNo = sourceModificationItem.AirworthinessDirectiveNo;
            Description = sourceModificationItem.Description;
            DateOfPerform = sourceModificationItem.DateOfPerform;
            StampPPCD = sourceModificationItem.StampPPCD;
            NumberWorkPackage = sourceModificationItem.NumberWorkPackage;
            Remarks = sourceModificationItem.Remarks;
            
            bool permission = currentItem.HasPermission(Users.CurrentUser, DataEvent.Update);

            textBoxSBSLNo.Enabled = permission;
            textboxEngineeringOrderNo.ReadOnly = !permission;
            textboxADNo.ReadOnly = !permission;
            textBoxDescription.ReadOnly = !permission;
            dateTimePickerDateOfPerform.Enabled = permission;
            textboxStampPPCD.ReadOnly = !permission;
            textboxWorkPackage.ReadOnly = !permission;
            textboxRemarks.ReadOnly = !permission;
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Данные у ModificationItem обновляются по введенным данным
        /// </summary>
        public void SaveData()
        {
            if (currentItem != null)
            {
                SaveData(currentItem, true);
            }
        }

        #endregion

        #region public void SaveData(ModificationItem destinationModificationItem, bool changePageName)

        /// <summary>
        /// Данные у ModificationItem обновляются по введенным данным
        /// </summary>
        /// <param name="destinationModificationItem">ModificationItem</param>
        /// <param name="changePageName">Менять ли название вкладки</param>
        public void SaveData(ModificationItem destinationModificationItem, bool changePageName)
        {
            textboxEngineeringOrderNo.Focus();
            if (destinationModificationItem == null) 
                throw new ArgumentNullException("destinationModificationItem");
            bool changeTitle = false;
            if (destinationModificationItem.SbNo != SBSLNo)
            {
                destinationModificationItem.SbNo = SBSLNo;
                changeTitle = true;
            }
            if (destinationModificationItem.EngineeringOrderNo != EngineeringOrderNo)
            {
                destinationModificationItem.EngineeringOrderNo = EngineeringOrderNo;
                changeTitle = true;
            }
            if (destinationModificationItem.AirworthinessDirectiveNo != AirworthinessDirectiveNo)
            {
                destinationModificationItem.AirworthinessDirectiveNo = AirworthinessDirectiveNo;
                changeTitle = true;
            }
            if (destinationModificationItem.Description != Description)
                destinationModificationItem.Description = Description;
            if (destinationModificationItem.DateOfPerform != DateOfPerform)
                destinationModificationItem.DateOfPerform = DateOfPerform;
            if (destinationModificationItem.StampPPCD != StampPPCD)
                destinationModificationItem.StampPPCD = StampPPCD;
            if (destinationModificationItem.NumberWorkPackage != NumberWorkPackage)
                destinationModificationItem.NumberWorkPackage = NumberWorkPackage;
            if (destinationModificationItem.Remarks != Remarks)
                destinationModificationItem.Remarks = Remarks;
            if (changeTitle && changePageName)
            {
                string caption = ((Aircraft) destinationModificationItem.Parent).RegistrationNumber + ". " +
                                 destinationModificationItem.SbNo + " " +
                                 destinationModificationItem.EngineeringOrderNo + " " +
                                 destinationModificationItem.AirworthinessDirectiveNo + " Record";
                if (DisplayerRequested != null)
                    DisplayerRequested(this, new ReferenceEventArgs(null, ReflectionTypes.ChangeTextOfContainingDisplayer, caption));
            }
        }
        #endregion

        #region public void ClearFields()

        /// <summary>
        /// Очищает все поля
        /// </summary>
        public void ClearFields()
        {
            SBSLNo = "";
            EngineeringOrderNo = "";
            AirworthinessDirectiveNo = "";
            Description = "";
            dateTimePickerDateOfPerform.Value = DateTime.Today;
            StampPPCD = "";
            NumberWorkPackage = "";
            Remarks = "";
        }

        #endregion
        
        #endregion

        #region IReference Members

        private IDisplayer displayer;
        private string displayerText;
        private IDisplayingEntity entity;
        private ReflectionTypes reflectionType;

        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        public IDisplayer Displayer
        {
            get { return displayer; }
            set { displayer = value; }
        }

        /// <summary>
        /// Text of page's header that Reference lead to
        /// </summary>
        public string DisplayerText
        {
            get { return displayerText; }
            set { displayerText = value; }
        }

        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        /// <summary>
        /// Type of reflection
        /// </summary>
        public ReflectionTypes ReflectionType
        {
            get { return reflectionType; }
            set { reflectionType = value; }
        }

        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        #endregion
    }
}