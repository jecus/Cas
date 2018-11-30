using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Management;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.UI.Appearance;

namespace CAS.UI.UIControls.DetailsControls
{

    /// <summary>
    /// Элемент управления для отображения информации по складу
    /// </summary>
    public class DetailStoreControl : UserControl
    {
        #region Fields

        private readonly AbstractDetail currentDetail;
        private Aircraft parentStore;

        private DateTime initialDateTimeValue = DateTime.Today;
        private const int MARGIN = 10;
        private const int HEIGHT_INTERVAL = 15;
        private const int LABEL_HEIGHT = 25;
        private const int LABEL_WIDTH = 250;
        private const int TEXTBOX_WIDTH = 200;
        private const int SECOND_MARGIN = 600;
        
        private Label labelStore;
        private Label labelShelfLife;
        private Label labelLocation;
        private Label labelExpirationDate;
        private Label labelNotificationDate;
        private Panel panelStores;
        private List<RadioButton> radioButtonsStores;
        private TextBox textBoxShelfLife;
        private TextBox textBoxLocation;
        private DateTimePicker dateTimePickerExpirationDate;
        private DateTimePicker dateTimePickerNotificationDate;

        #endregion

        #region Constructors

        #region public DetailStoreControl(Aircraft parentStore)

        /// <summary>
        /// Создает элемент управления для отображения информации по складу
        /// </summary>
        public DetailStoreControl(Aircraft parentStore)
        {
            this.parentStore = parentStore;
            InitializeComponent();
            UpdateRadioButtonsStores();
            CurrentStore = parentStore;
        }

        #endregion

        #region public DetailStoreControl(AbstractDetail currentDetail)

        /// <summary>
        /// Создает элемент управления для отображения информации по складу
        /// </summary>
        /// <param name="currentDetail">Агрегат</param>
        public DetailStoreControl(AbstractDetail currentDetail)
        {
            if (null == currentDetail) 
                throw new ArgumentNullException("currentDetail", "Argument cannot be null");
            this.currentDetail = currentDetail;
            if (currentDetail is BaseDetail)
                parentStore = (Aircraft)currentDetail.Parent;
            else
            {
                parentStore = (Aircraft)currentDetail.Parent.Parent;
            }
            InitializeComponent();
        }

        #endregion
        
        #endregion

        #region Propeties

        #region public Aircraft CurrentStore

        /// <summary>
        /// Склад, на который добаляется (в котором содержится) агрегат
        /// </summary>
        public Aircraft CurrentStore
        {
            get
            {
                for (int i = 0; i < radioButtonsStores.Count; i++)
                {
                    if (radioButtonsStores[i].Checked)
                        return (Aircraft)radioButtonsStores[i].Tag;
                }
                return null;
            }
            set
            {
                for (int i = 0; i < radioButtonsStores.Count; i++)
                {
                    if (((Aircraft)radioButtonsStores[i].Tag).ID == value.ID)
                        radioButtonsStores[i].Checked = true;
                }
            }
        }

        #endregion

        #region public string ShelfLife

        /// <summary>
        /// Срок хранения агрегата на складе
        /// </summary>
        public string ShelfLife
        {
            get { return textBoxShelfLife.Text; }
            set
            {
                
                textBoxShelfLife.Text = value;
            }
        }

        #endregion
        
        #region public new string Location

        /// <summary>
        /// Расположение агрегата/расходника на складе
        /// </summary>
        public new string Location
        {
            get { return textBoxLocation.Text; }
            set
            {
                textBoxLocation.Text = value;
            }
        }

        #endregion

        #region public DateTime ExpirationDate

        /// <summary>
        /// Дата истечение хранения агрегата/расходника на складе
        /// </summary>
        public DateTime ExpirationDate
        {
            get { return dateTimePickerExpirationDate.Value; }
            set
            {
                dateTimePickerExpirationDate.Value = value;
            }
        }

        #endregion

        #region public DateTime NotificationDate

        /// <summary>
        /// Агрегат будет подсвечен с этого момента
        /// </summary>
        public DateTime NotificationDate
        {
            get { return dateTimePickerNotificationDate.Value; }
            set
            {
                dateTimePickerNotificationDate.Value = value;
            }
        }

        #endregion
        
        #endregion

        #region Methods

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            labelStore = new Label();
            labelShelfLife = new Label();
            labelLocation = new Label();
            labelExpirationDate = new Label();
            labelNotificationDate = new Label();
            panelStores = new Panel();
            radioButtonsStores = new List<RadioButton>();
            textBoxShelfLife = new TextBox();
            textBoxLocation = new TextBox();
            dateTimePickerExpirationDate = new DateTimePicker();
            dateTimePickerNotificationDate = new DateTimePicker();
            //
            // panelStores
            //
            panelStores.AutoSize = true;
            panelStores.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            // 
            // labelStore
            // 
            labelStore.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelStore.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelStore.Location = new Point(MARGIN, MARGIN);
            labelStore.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelStore.Text = "Store:";
            labelStore.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelShelfLife
            // 
            labelShelfLife.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelShelfLife.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelShelfLife.Location = new Point(SECOND_MARGIN, MARGIN);
            labelShelfLife.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelShelfLife.Text = "Shelf Life:";
            labelShelfLife.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxShelfLife
            // 
            textBoxShelfLife.BackColor = Color.White;
            textBoxShelfLife.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxShelfLife.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxShelfLife.Location = new Point(labelShelfLife.Right, MARGIN);
            textBoxShelfLife.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxShelfLife.MaxLength = 50;
            // 
            // labelLocation
            // 
            labelLocation.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelLocation.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelLocation.Location = new Point(SECOND_MARGIN, labelShelfLife.Bottom + HEIGHT_INTERVAL);
            labelLocation.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelLocation.Text = "Location:";
            labelLocation.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxLocation
            // 
            textBoxLocation.BackColor = Color.White;
            textBoxLocation.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxLocation.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxLocation.Location = new Point(labelLocation.Right, textBoxShelfLife.Bottom + HEIGHT_INTERVAL);
            textBoxLocation.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxLocation.MaxLength = 50;
            // 
            // labelExpirationDate
            // 
            labelExpirationDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelExpirationDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelExpirationDate.Location = new Point(SECOND_MARGIN, labelLocation.Bottom + HEIGHT_INTERVAL);
            labelExpirationDate.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelExpirationDate.Text = "Expiration Date:";
            labelExpirationDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dateTimePickerExpirationDate       
            // 
            dateTimePickerExpirationDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            dateTimePickerExpirationDate.CalendarForeColor = Css.OrdinaryText.Colors.ForeColor;
            dateTimePickerExpirationDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            dateTimePickerExpirationDate.Location = new Point(labelExpirationDate.Right, textBoxLocation.Bottom + HEIGHT_INTERVAL);
            dateTimePickerExpirationDate.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            dateTimePickerExpirationDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerExpirationDate.CustomFormat = new TermsProvider()["DateFormat"].ToString();
            dateTimePickerExpirationDate.Value = initialDateTimeValue;
            // 
            // labelNotificationDate
            // 
            labelNotificationDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelNotificationDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelNotificationDate.Location = new Point(SECOND_MARGIN, labelExpirationDate.Bottom + HEIGHT_INTERVAL);
            labelNotificationDate.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelNotificationDate.Text = "Notification Date:";
            labelNotificationDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dateTimePickerNotificationDate       
            // 
            dateTimePickerNotificationDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            dateTimePickerNotificationDate.CalendarForeColor = Css.OrdinaryText.Colors.ForeColor;
            dateTimePickerNotificationDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            dateTimePickerNotificationDate.Location = new Point(labelNotificationDate.Right, dateTimePickerExpirationDate.Bottom + HEIGHT_INTERVAL);
            dateTimePickerNotificationDate.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            dateTimePickerNotificationDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerNotificationDate.CustomFormat = new TermsProvider()["DateFormat"].ToString();
            dateTimePickerNotificationDate.Value = initialDateTimeValue;
            // 
            // DetailGeneralInformationControl
            //
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Css.CommonAppearance.Colors.BackColor;
            
            
            Controls.Add(labelStore);
            Controls.Add(panelStores);
            Controls.Add(labelShelfLife);
            Controls.Add(textBoxShelfLife);
            Controls.Add(labelLocation);
            Controls.Add(textBoxLocation);
            Controls.Add(labelExpirationDate);
            Controls.Add(dateTimePickerExpirationDate);
            Controls.Add(labelNotificationDate);
            Controls.Add(dateTimePickerNotificationDate);
        }

        #endregion

        #region public bool GetChangeStatus()

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        public bool GetChangeStatus()
        {
            return GetChangeStatus(currentDetail);
        }

        #endregion

        #region public bool GetChangeStatus(AbstractDetail detail)

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        public bool GetChangeStatus(AbstractDetail detail)
        {
            return ((CurrentStore.ID != parentStore.ID) ||
                    (ShelfLife != detail.ShelfLife) ||
                    (Location != detail.Location) ||
                    (detail == currentDetail && (ExpirationDate != detail.ExpirationDate || NotificationDate != detail.NotificationDate)) ||
                    (detail != currentDetail && (ExpirationDate != initialDateTimeValue || NotificationDate != initialDateTimeValue)));
        }

        #endregion

        #region public void UpdateInformation()

        /// <summary>
        /// Заполняет поля для редактирования агрегата
        /// </summary>
        public void UpdateInformation()
        {
            if (currentDetail != null)
                UpdateInformation(currentDetail);
        }

        #endregion

        #region public void UpdateInformation(AbstractDetail detail)

        /// <summary>
        /// Заполняет поля для редактирования агрегата
        /// </summary>
        public void UpdateInformation(AbstractDetail detail)
        {
            if (detail == null) 
                throw new ArgumentNullException("detail");
            UpdateRadioButtonsStores();
            CurrentStore = parentStore;
            ShelfLife = detail.ShelfLife;
            Location = detail.Location;
            ExpirationDate = currentDetail.ExpirationDate;
            NotificationDate = detail.NotificationDate;
            
            bool permission = (detail.HasPermission(Users.CurrentUser, DataEvent.Update));

            for (int i = 0; i < radioButtonsStores.Count; i++)
                radioButtonsStores[i].Enabled = permission;
            textBoxShelfLife.ReadOnly = !permission;
            textBoxLocation.ReadOnly = !permission;
            dateTimePickerExpirationDate.Enabled = permission;
            dateTimePickerNotificationDate.Enabled = permission;
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Сохранаяет данные текущего агрегата
        /// </summary>
        public void SaveData()
        {
            if (currentDetail != null)
                SaveData(currentDetail);
        }

        #endregion

        #region public void SaveData(AbstractDetail detail)

        /// <summary>
        /// Сохранаяет данные заданного агрегата
        /// </summary>
        /// <param name="detail">Агрегат</param>
        public void SaveData(AbstractDetail detail)
        {
            if (CurrentStore.ID != parentStore.ID)
                parentStore = CurrentStore;
            if (currentDetail != null)
                ((Detail)currentDetail).MoveDetail(parentStore, new TransferRecord());
            else
                parentStore.Add(detail);
            if (textBoxShelfLife.Text != detail.ShelfLife)
                detail.ShelfLife = textBoxShelfLife.Text;
            if (textBoxLocation.Text != detail.Location)
                detail.Location = textBoxLocation.Text;
            if (dateTimePickerExpirationDate.Value != detail.ExpirationDate)
                detail.ExpirationDate = dateTimePickerExpirationDate.Value;
            if (dateTimePickerNotificationDate.Value != detail.NotificationDate)
                detail.NotificationDate = dateTimePickerNotificationDate.Value;
        }

        #endregion

        #region public void ClearFields()

        /// <summary>
        /// Очищает все поля
        /// </summary>
        public void ClearFields()
        {
            UpdateRadioButtonsStores();
            ShelfLife = "";
            Location = "";
            ExpirationDate = DateTime.Today;
            NotificationDate = DateTime.Today;
        }

        #endregion
        
        #region private void UpdateRadioButtonsStores()

        private void UpdateRadioButtonsStores()
        {
            panelStores.Controls.Clear();
            radioButtonsStores.Clear();
            
            for (int i = 0; i < parentStore.Operator.Stores.Count; i++)
            {
                RadioButton radioButton = new RadioButton();
                radioButton.Cursor = Cursors.Hand;
                radioButton.FlatStyle = FlatStyle.Flat;
                radioButton.Font = new Font(Css.OrdinaryText.Fonts.RegularFont, FontStyle.Underline);
                radioButton.ForeColor = Css.SimpleLink.Colors.LinkColor;
                radioButton.Location = new Point(MARGIN, labelStore.Bottom + HEIGHT_INTERVAL + i*(LABEL_HEIGHT + HEIGHT_INTERVAL));
                radioButton.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
                radioButton.Text = parentStore.Operator.Stores[i].RegistrationNumber;
                radioButton.Tag = parentStore.Operator.Stores[i];
                radioButtonsStores.Add(radioButton);
                panelStores.Controls.Add(radioButton);
            }
        }

        #endregion

        #endregion

    }
}