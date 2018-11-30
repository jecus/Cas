using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.Appearance;
using CAS.UI.UIControls.Auxiliary;

namespace CAS.UI.UIControls.DetailsControls
{
    /// <summary>
    /// Элемент управления для отображения информации об обслуживании агрегата
    /// </summary>
    public class DetailWarrantyControl : UserControl
    {

        #region Fields

        private readonly AbstractDetail currentDetail;
        private RadioButton radioButtonNoWarranty;
        private RadioButton radioButtonExpires;
        private RadioButton radioButtonOperationalTime;
        private DateTimePicker dateTimePickerExpires;
        private LifelengthViewer lifelengthViewerWarranty;
        private LifelengthViewer lifelengthViewerRemains;
        
        //private const int MARGIN = 10;
        private const int HEIGHT_INTERVAL = 15;
        private const int LABEL_HEIGHT = 25;
        private const int RADIO_BUTTON_WIDTH = 150;
        private const int DATE_TIME_PICKER_WIDTH = 200;

        #endregion

        #region Properties

        /// <summary>
        /// Возвращает DateTimePicker
        /// </summary>
        public DateTimePicker DateTimePickerExpires
        {
            get
            {
                return dateTimePickerExpires;
            }
        }

        #endregion

        #region Constructors

        #region public DetailWarrantyControl()

        /// <summary>
        /// Создает элемент управления для добавления информации об обслуживании агрегата
        /// </summary>
        public DetailWarrantyControl()
        {
            InitializeComponent();
        }

        #endregion

        #region public DetailWarrantyControl(AbstractDetail detail)

        /// <summary>
        /// Создает элемент управления для отображения информации об обслуживании агрегата
        /// </summary>
        /// <param name="detail"></param>
        public DetailWarrantyControl(AbstractDetail detail)
        {
            currentDetail = detail;
            InitializeComponent();
        }

        #endregion


        #endregion

        #region Methods

        #region public void InitializeComponent()

        /// <summary>
        /// Инициализирует элементы управления
        /// </summary>
        public void InitializeComponent()
        {
            radioButtonNoWarranty = new RadioButton();
            radioButtonExpires = new RadioButton();
            radioButtonOperationalTime = new RadioButton();
            dateTimePickerExpires = new DateTimePicker();
            lifelengthViewerWarranty = new LifelengthViewer();
            lifelengthViewerRemains = new LifelengthViewer();
            // 
            // radioButtonNoWarranty
            // 
            radioButtonNoWarranty.Cursor = Cursors.Hand;
            radioButtonNoWarranty.FlatStyle = FlatStyle.Flat;
            radioButtonNoWarranty.Font = new Font(Css.OrdinaryText.Fonts.SmallRegularFont, FontStyle.Underline);
            radioButtonNoWarranty.ForeColor = Css.SimpleLink.Colors.LinkColor;
            radioButtonNoWarranty.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonNoWarranty.Text = "No Warranty";
            radioButtonNoWarranty.TextAlign = ContentAlignment.MiddleLeft;
            radioButtonNoWarranty.CheckedChanged += radioButtonNoWarranty_CheckedChanged;
            radioButtonNoWarranty.Checked = true;
            // 
            // radioButtonExpires
            // 
            radioButtonExpires.Cursor = Cursors.Hand;
            radioButtonExpires.FlatStyle = FlatStyle.Flat;
            radioButtonExpires.Font = new Font(Css.OrdinaryText.Fonts.SmallRegularFont, FontStyle.Underline);
            radioButtonExpires.ForeColor = Css.SimpleLink.Colors.LinkColor;
            radioButtonExpires.Location = new Point(0, radioButtonNoWarranty.Bottom + HEIGHT_INTERVAL);
            radioButtonExpires.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonExpires.Text = "Expires";
            radioButtonExpires.CheckedChanged += radioButtonExpires_CheckedChanged;
            // 
            // dateTimePickerExpires       
            // 
            dateTimePickerExpires.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            dateTimePickerExpires.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            dateTimePickerExpires.Location = new Point(radioButtonExpires.Right, radioButtonNoWarranty.Bottom + HEIGHT_INTERVAL);
            dateTimePickerExpires.Size = new Size(DATE_TIME_PICKER_WIDTH, LABEL_HEIGHT);
            dateTimePickerExpires.Format = DateTimePickerFormat.Custom;
            dateTimePickerExpires.CustomFormat = new TermsProvider()["DateFormat"].ToString();
            // 
            // radioButtonOperationalTime
            // 
            radioButtonOperationalTime.Cursor = Cursors.Hand;
            radioButtonOperationalTime.FlatStyle = FlatStyle.Flat;
            radioButtonOperationalTime.Font = new Font(Css.OrdinaryText.Fonts.SmallRegularFont, FontStyle.Underline);
            radioButtonOperationalTime.ForeColor = Css.SimpleLink.Colors.LinkColor;
            radioButtonOperationalTime.Location = new Point(0, radioButtonExpires.Bottom + HEIGHT_INTERVAL);
            radioButtonOperationalTime.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonOperationalTime.Text = "Operational Time";
            radioButtonOperationalTime.CheckedChanged += radioButtonOperationalTime_CheckedChanged;
            //
            // lifelengthViewerWarranty
            //
            lifelengthViewerWarranty.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            lifelengthViewerWarranty.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            lifelengthViewerWarranty.LeftHeaderWidth = 0;
            lifelengthViewerWarranty.ShowMinutes = false;
            lifelengthViewerWarranty.Location = new Point(radioButtonOperationalTime.Right, radioButtonExpires.Bottom + HEIGHT_INTERVAL);
            //
            // lifelengthViewerRemains
            //
            lifelengthViewerRemains.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            lifelengthViewerRemains.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            lifelengthViewerRemains.LeftHeader = "Remains";
            lifelengthViewerRemains.LeftHeaderWidth = RADIO_BUTTON_WIDTH;
            lifelengthViewerRemains.ShowMinutes = false;
            lifelengthViewerRemains.Location = new Point(lifelengthViewerWarranty.Right + 100, radioButtonExpires.Bottom + HEIGHT_INTERVAL);
            lifelengthViewerRemains.Enabled = false;
            // 
            // DetailGeneralInformationControl
            //
            AutoSize = true;
            BackColor = Css.CommonAppearance.Colors.BackColor;
            Controls.Add(radioButtonNoWarranty);
            Controls.Add(radioButtonExpires);
            Controls.Add(dateTimePickerExpires);
            Controls.Add(radioButtonOperationalTime);
            Controls.Add(lifelengthViewerWarranty);
            Controls.Add(lifelengthViewerRemains);
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
            return (dateTimePickerExpires.Value != detail.ManufactureDate.AddDays(detail.Warranty.Calendar.TotalDays) ||
                    lifelengthViewerWarranty.Modified);
        }

        #endregion

        #region public void UpdateInformation()

        /// <summary>
        /// Заполняет поля для редактирования агрегата
        /// </summary>
        public void UpdateInformation()
        {
            double e = 0.00000001;
            /*if ((currentDetail.Warranty.IsHoursApplicable && currentDetail.Warranty.Hours.TotalHours > 0) ||
                (currentDetail.Warranty.IsCyclesApplicable && currentDetail.Warranty.Cycles > 0))
                radioButtonOperationalTime.Checked = true;
            else if (currentDetail.Warranty.IsCalendarApplicable && currentDetail.Warranty.Calendar.TotalDays > 0)
                radioButtonExpires.Checked = true;*/
            if (Math.Abs(currentDetail.Warranty.Hours.TotalHours) > e || currentDetail.Warranty.Cycles > 0)
                radioButtonOperationalTime.Checked = true;
            else if (Math.Abs(currentDetail.Warranty.Calendar.TotalDays) > e)
                radioButtonExpires.Checked = true;
            else
                radioButtonNoWarranty.Checked = true;
            lifelengthViewerWarranty.Lifelength = currentDetail.Warranty;
            lifelengthViewerRemains.Lifelength = currentDetail.WarrantyRemains;
            dateTimePickerExpires.Value = currentDetail.ManufactureDate.AddDays(currentDetail.Warranty.Calendar.TotalDays);

            bool permission = (currentDetail.HasPermission(Users.CurrentUser, DataEvent.Update));

            lifelengthViewerWarranty.ReadOnly = !permission;
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
            if (detail == null)
                throw new ArgumentNullException("detail");
            if (radioButtonExpires.Checked)
            {
                detail.Warranty.Calendar = new TimeSpan(dateTimePickerExpires.Value.Ticks - detail.ManufactureDate.Ticks);
/*                detail.Warranty.IsCalendarApplicable = true;
                detail.Warranty.IsHoursApplicable = false;
                detail.Warranty.IsCyclesApplicable = false;
                detail.LifelengthDataChanged();*/
            }
            else if (radioButtonOperationalTime.Checked)
            {
                lifelengthViewerWarranty.SaveData(detail.Warranty);
                lifelengthViewerRemains.SaveData(detail.WarrantyRemains);
/*                detail.Warranty.IsHoursApplicable = true;
                detail.Warranty.IsCyclesApplicable = true;
                detail.Warranty.IsCalendarApplicable = true;
                detail.LifelengthDataChanged();*/

            }
/*            else
            {
                detail.Warranty.IsHoursApplicable = false;
                detail.Warranty.IsCyclesApplicable = false;
                detail.Warranty.IsCalendarApplicable = false;
                detail.LifelengthDataChanged();
            }*/
            
        }

        #endregion

        #region public void ClearFields()

        /// <summary>
        /// Очищает все поля
        /// </summary>
        public void ClearFields()
        {
            lifelengthViewerWarranty.Lifelength = new Lifelength();
            lifelengthViewerRemains.Lifelength = new Lifelength();
        }

        #endregion




        #region private void SetEnabledToControls()

        private void SetEnabledToControls()
        {
            if (radioButtonNoWarranty.Checked)
            {
                dateTimePickerExpires.Enabled =
                    lifelengthViewerWarranty.Enabled = false;
            }
            else if (radioButtonExpires.Checked)
            {
                dateTimePickerExpires.Enabled = true;
                lifelengthViewerWarranty.Enabled = false;
            }
            else
            {
                dateTimePickerExpires.Enabled = false;
                lifelengthViewerWarranty.Enabled = true;
            }
        }

        #endregion
        
        #region private void radioButtonNoWarranty_CheckedChanged(object sender, EventArgs e)

        private void radioButtonNoWarranty_CheckedChanged(object sender, EventArgs e)
        {
            SetEnabledToControls();
        }

        #endregion

        #region private void radioButtonExpires_CheckedChanged(object sender, EventArgs e)

        private void radioButtonExpires_CheckedChanged(object sender, EventArgs e)
        {
            SetEnabledToControls();
        }

        #endregion

        #region private void radioButtonOperationalTime_CheckedChanged(object sender, EventArgs e)

        private void radioButtonOperationalTime_CheckedChanged(object sender, EventArgs e)
        {
            SetEnabledToControls();
        }

        #endregion

        #endregion

    }
}
