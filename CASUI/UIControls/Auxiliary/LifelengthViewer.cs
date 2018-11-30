using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.Appearance;

namespace CAS.UI.UIControls.Auxiliary
{
    ///<summary>
    /// Класс, описывающий отображение наработки
    ///</summary>
    public partial class LifelengthViewer : UserControl
    {

        #region Fields

        private bool readOnly = false;
        private Lifelength.CalendarTypes calendarTypes = Lifelength.CalendarTypes.Days;
        private string temporaryHoursField;
        private string temporaryCyclesField;
       // private string temporaryCalendarField;
        private Lifelength lifelength;
        private Color fieldsBackColor = SystemColors.Window;
        private static readonly string NotApplicableString = "n/a";
        private bool modified = false;

        private bool isFirstTimeHours = true;
        private bool isFirstTimeCycles = true;
        private bool isCalenderVisible = true;
        private bool showMinutes = true;
        private bool takeIntoAccountLifelengthChanging = false;

        #endregion

        #region Constructors

        #region public LifelengthViewer() : this(new ActualState())

        ///<summary>
        /// Создается объект для отображения пустой наработки
        ///</summary>
        public LifelengthViewer() : this(new Lifelength())
        {
        }

        #endregion

        #region public LifelengthViewer(ActualState lifelength)
        ///<summary>
        /// Создается объект для отображения заданной наработки
        ///</summary>
        ///<param name="lifelength">Отображаемая наработка</param>
        public LifelengthViewer(Lifelength lifelength)
        {
            InitializeComponent();
            Initialize();
            Lifelength = new Lifelength(lifelength);
            comboBoxCalendarType.SelectedIndex = 0;
            textBoxHours.GotFocus += textBoxHours_GotFocus;
            textBoxCycles.GotFocus += textBoxCycles_GotFocus;
            textBoxCalendar.GotFocus += textBoxCalendar_GotFocus;
            textBoxHours.LostFocus += textBoxHours_LostFocus;
            textBoxCycles.LostFocus += textBoxCycles_LostFocus;
            textBoxCalendar.LostFocus += textBoxCalendar_LostFocus;
        }

        #endregion

        #endregion

        #region Properties

        #region public bool ShowLeftHeader
        /// <summary>
        /// Отображать ли левый заголовок
        /// </summary>
        public bool ShowLeftHeader
        {
            get
            {
                return labelLeftHeader.Visible;
            }
            set
            {
                labelLeftHeader.Visible = value;
            }
        }
        #endregion
        
        #region public String LeftHeader
        /// <summary>
        /// Текст левого заголовка
        /// </summary>
        public String LeftHeader
        {
            get { return labelLeftHeader.Text; }
            set { labelLeftHeader.Text = value; }
        }
        #endregion

        #region public bool ShowHeaders
        /// <summary>
        /// Отображать ли заголовки
        /// </summary>
        public bool ShowHeaders
        {
            get
            {
                return CalendarHeader.Visible;
            }
            set
            {
                CalendarHeader.Visible = value;
                labelCyclesHeader.Visible = value;
                labelHoursHeader.Visible = value;
            }
        }
        #endregion

        #region public string HeaderHours
        /// <summary>
        /// Текст заголовка сверху поля наработки по часам
        /// </summary>
        public string HeaderHours
        {
            get { return labelHoursHeader.Text; }
            set { labelHoursHeader.Text = value; }
        }
        #endregion

        #region public string HeaderCycles
        /// <summary>
        /// Текст заголовка сверху поля наработки по циклам
        /// </summary>
        public string HeaderCycles
        {
            get { return labelCyclesHeader.Text; }
            set { labelCyclesHeader.Text = value; }
        }
        #endregion

        #region public string HeaderCalendar
        /// <summary>
        /// Текст заголовка сверху поля календарной наработки
        /// </summary>
        public string HeaderCalendar
        {
            get { return CalendarHeader.Text; }
            set { CalendarHeader.Text = value; }
        }
        #endregion

        #region public Color FieldsBackColor
        /// <summary>
        /// Фон полей в режиме
        /// </summary>
        public Color FieldsBackColor
        {
            get { return fieldsBackColor; }
            set { fieldsBackColor = value; }
        }
        #endregion

        #region public ActualState ActualState
        /// <summary>
        /// Отображаемая наработка
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Lifelength Lifelength
        {
            get { return lifelength; }
            set
            {
                if (lifelength != null)
                {
                    lifelength.DataChanged -= lifelength_DataChanged;
                }
                lifelength = new Lifelength(value);
                lifelength.DataChanged += lifelength_DataChanged;
                UpdateData();
            }
        }
        #endregion

        #region public bool HoursApplicable
        /// <summary>
        /// Ведется ли наработка по часам
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public bool HoursApplicable
        {
            get { return lifelength.IsHoursApplicable; }
            set
            {
                lifelength.IsHoursApplicable = value;
            }
        }
        #endregion

        #region public bool CyclesApplicable
        /// <summary>
        /// Ведется ли наработка по циклам
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public bool CyclesApplicable
        {
            get { return lifelength.IsCyclesApplicable; }
            set
            {
                lifelength.IsCyclesApplicable = value;
            }
        }
        #endregion

        #region public bool CalendarApplicable
        /// <summary>
        /// Ведется ли наработка по календарю
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public bool CalendarApplicable
        {
            get { return lifelength.IsCalendarApplicable; }
            set
            {
                lifelength.IsCalendarApplicable = value;
            }
        }
        #endregion

        #region public bool ReadOnly
        ///<summary>
        /// Отображать наработку только для чтения
        ///</summary>
        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;
                textBoxCalendar.ReadOnly = value;
                textBoxCycles.ReadOnly = value;
                textBoxHours.ReadOnly = value;

                textBoxCycles.ForeColor = Css.OrdinaryText.Colors.ForeColor;
                textBoxHours.ForeColor = Css.OrdinaryText.Colors.ForeColor;
                textBoxCalendar.ForeColor = Css.OrdinaryText.Colors.ForeColor;
                if (value)
                {
                    textBoxCycles.BackColor = SystemColors.Control;
                    textBoxHours.BackColor = SystemColors.Control;
                    textBoxCalendar.BackColor = SystemColors.Control;
                }
                else
                {
                    textBoxCycles.BackColor = SystemColors.Window;
                    textBoxHours.BackColor = SystemColors.Window;
                    textBoxCalendar.BackColor = SystemColors.Window;
                }
            }
        }

        #endregion

        #region public float LeftHeaderWidth
        /// <summary>
        /// Ширина левого заголовка
        /// </summary>
        public float LeftHeaderWidth
        {
            get
            {
                return tableLayoutPanel1.ColumnStyles[0].Width;
            }
            set
            {
                tableLayoutPanel1.ColumnStyles[0].Width = value;
                Width = tableLayoutPanel1.Width;
            }
        }
        #endregion

        #region public int Cycles
        /// <summary>
        /// Значение наработки по циклам
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Cycles
        {
            get
            {
                return lifelength.Cycles;
            }
            set
            {
                lifelength.Cycles = value;
                if (isFirstTimeCycles)
                {
                    temporaryCyclesField = lifelength.Cycles.ToString();
                    isFirstTimeCycles = false;
                }
            }
        }
        #endregion

        #region public TimeSpan Hours
        /// <summary>
        /// Значение наработки по часам
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TimeSpan Hours
        {
            get
            {
                return lifelength.Hours;
            }
            set
            {
                lifelength.Hours = value;
                if (isFirstTimeHours)
                {
                    temporaryHoursField = Lifelength.GetHoursString(value, showMinutes);
                    isFirstTimeHours = false;
                }

            }
        }
        #endregion

        #region public TimeSpan Calendar
        /// <summary>
        /// Значение наработки по часам
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TimeSpan Calendar
        {
            get
            {
                return lifelength.Calendar;
            }
        }
        #endregion

        #region public bool ShowCalendar
        /// <summary>
        /// Показывать ли поле календарь
        /// </summary>
        public bool ShowCalendar
        {
            get { return isCalenderVisible; }
            set
            {
                isCalenderVisible = false;
                if (!isCalenderVisible)
                {
                    textBoxCalendar.Visible = false;
                    CalendarHeader.Visible = false;
                    comboBoxCalendarType.Visible = false;
                }
                else
                {
                    textBoxCalendar.Visible = true;
                    CalendarHeader.Visible = true;
                    comboBoxCalendarType.Visible = true;                    
                }
            }
        }
        #endregion

        #region private bool Modified

        /// <summary>
        /// Возвращает или устанавливает значение, показывающее были ли изменения в отображаемой наработке
        /// </summary>
        public bool Modified
        {
            get
            {
                return modified;
            }
            set
            {
                modified = value;
            }
        }

        #endregion

        #region public ComboBox ComboBoxCalendarType

        /// <summary>
        /// Возвращает ComboBox с типом календаря
        /// </summary>
        public ComboBox ComboBoxCalendarType
        {
            get
            {
                return comboBoxCalendarType;
            }
        }

        #endregion

        #region public TextBox TextBoxHours

        /// <summary>
        /// Возвращает текстовое поле с количеством часов наработки
        /// </summary>
        public TextBox TextBoxHours
        {
            get
            {
                return textBoxHours;
            }
        }

        #endregion

        #region public bool ShowMinutes

        /// <summary>
        /// Возвращает или устанавливает свойство, показывающее нужно ли отображать минуты в поле Hours
        /// </summary>
        public bool ShowMinutes
        {
            get
            {
                return showMinutes;
            }
            set
            {
                showMinutes = value;
            }
        }

        #endregion

        #region private ActualState.CalendarTypes CalendarTypes

        private Lifelength.CalendarTypes CalendarTypes
        {
            get
            {
                return calendarTypes;
            }
            set
            {
                calendarTypes = value;
                if (value == Lifelength.CalendarTypes.Months)
                    comboBoxCalendarType.SelectedIndex = 1;
                else if (value == Lifelength.CalendarTypes.Years)
                    comboBoxCalendarType.SelectedIndex = 2;
                else
                    comboBoxCalendarType.SelectedIndex = 0;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region private void Initialize()

        private void Initialize()
        {
            Css.OrdinaryText.Adjust(labelLeftHeader);
            Css.OrdinaryText.Adjust(labelHoursHeader);
            Css.OrdinaryText.Adjust(labelCyclesHeader);
            Css.OrdinaryText.Adjust(CalendarHeader);
            comboBoxCalendarType.ForeColor = Css.OrdinaryText.Colors.ForeColor;

            tableLayoutPanel1.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxCycles.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxCalendar.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxHours.ForeColor = Css.OrdinaryText.Colors.ForeColor;
        }

        #endregion

        #region private void UpdateData()

        private void UpdateData()
        {
            takeIntoAccountLifelengthChanging = false;

            HoursApplicable = lifelength.IsHoursApplicable;
            CalendarApplicable = lifelength.IsCalendarApplicable;
            CyclesApplicable = lifelength.IsCyclesApplicable;
            Cycles = lifelength.Cycles;
            Hours = lifelength.Hours;
            
            SetData(Lifelength.GetHoursString(lifelength.Hours, showMinutes), HoursApplicable, textBoxHours);
            SetData(lifelength.Cycles.ToString(), CyclesApplicable, textBoxCycles);
            SetCalendarData(lifelength.Calendar, true);

            takeIntoAccountLifelengthChanging = true;
        }

        #endregion

        #region public void SaveData(ActualState destinationLifelength)

        /// <summary>
        /// Сохраняет наработку
        /// </summary>
        /// <param name="destinationLifelength"></param>
        public void SaveData(Lifelength destinationLifelength)
        {
            destinationLifelength.Hours = Lifelength.Hours;
            destinationLifelength.Cycles = Lifelength.Cycles;
            destinationLifelength.Calendar = Lifelength.Calendar;
            destinationLifelength.IsHoursApplicable = Lifelength.IsHoursApplicable;
            destinationLifelength.IsCyclesApplicable = Lifelength.IsCyclesApplicable;
            destinationLifelength.IsCalendarApplicable = Lifelength.IsCalendarApplicable;
            //destinationLifelength.IsHoursApplicable = (textBoxHours.Text.ToLower() != NotApplicableString && textBoxHours.Text != "");
            //destinationLifelength.IsCyclesApplicable = (textBoxCycles.Text.ToLower() != NotApplicableString && textBoxCycles.Text != "");
            //destinationLifelength.IsCalendarApplicable = (textBoxCalendar.Text.ToLower() != NotApplicableString && textBoxCalendar.Text != "");
            Modified = false;
        }

        #endregion



        #region private void SetCalendarData(TimeSpan calendar, bool changeCalendarTypes)

        private void SetCalendarData(TimeSpan calendar, bool changeCalendarTypes)
        {
            int days = (int)Math.Round(calendar.TotalDays);
            if (readOnly || changeCalendarTypes)
            {
                if (!CalendarApplicable)
                {
                    textBoxCalendar.Text = NotApplicableString;
                }
                else if (days%365 == 0)
                {
                    CalendarTypes = Lifelength.CalendarTypes.Years;
                    textBoxCalendar.Text = (days/365).ToString();
                }
                else if (days%360 == 0)
                {
                    CalendarTypes = Lifelength.CalendarTypes.Years;
                    textBoxCalendar.Text = (days/360).ToString();
                }
                else if (days%30 == 0)
                {
                    CalendarTypes = Lifelength.CalendarTypes.Months;
                    textBoxCalendar.Text = (days/30).ToString();
                }
                else
                {
                    CalendarTypes = Lifelength.CalendarTypes.Days;
                    textBoxCalendar.Text = days.ToString();
                }
            }
            else
            {
                SetTextBoxCalendarValue(days);
            }
        }

        #endregion

        #region private void SetTextBoxCalendarValue(double days)

        private void SetTextBoxCalendarValue(double days)
        {
            if (CalendarTypes == Lifelength.CalendarTypes.Years)
                textBoxCalendar.Text = Math.Round(days/360.0, 1).ToString();
            else if (CalendarTypes == Lifelength.CalendarTypes.Months)
                textBoxCalendar.Text = Math.Round(days / 30.0, 1).ToString();
            else
                textBoxCalendar.Text = Math.Round(days, 1).ToString();
        }

        #endregion



        #region private void SetData(string data, bool applicable, TextBox destinationTextBox)

        private void SetData(string data, bool applicable, TextBox destinationTextBox)
        {
            if (applicable)
                destinationTextBox.Text = data;
            else
                destinationTextBox.Text = NotApplicableString;
        }

        #endregion

        #region private void lifelength_DataChanged(object sender, EventArgs e)

        private void lifelength_DataChanged(object sender, EventArgs e)
        {
            if (!Modified)
                Modified = true;
            if (LifelengthChanged != null)
                LifelengthChanged(this, EventArgs.Empty);
        }

        #endregion

        #region private bool IsNotApplicableString(string text)
        private bool IsNotApplicableString(string text)
        {
            return Regex.IsMatch(text, @"([nN][/\][aA])") || text == "-";
        }
        #endregion


        #region private void textBoxHours_Validating(object sender, CancelEventArgs e)

        private void textBoxHours_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxHours.Text == "")
                textBoxHours.Text = NotApplicableString;
            if (!ValidateHours())
            {
                e.Cancel = true;
                return;
            }
        }

        #endregion

        #region private void textBoxCycles_Validating(object sender, CancelEventArgs e)

        private void textBoxCycles_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxCycles.Text == "")
                textBoxCycles.Text = NotApplicableString;
            if (!ValidateCycles())
            {
                e.Cancel = true;
                return;
            }
/*            bool applicable = !IsNotApplicableString(textBoxCycles.Text);
            if (applicable)
                Cycles = Int32.Parse(textBoxCycles.Text);
            CyclesApplicable = applicable;*/
        }

        #endregion

        #region private void textBoxCalendar_Validating(object sender, CancelEventArgs e)

        private void textBoxCalendar_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxCalendar.Text == "")
                textBoxCalendar.Text = NotApplicableString;
            if (!ValidateCalendar())
            {
                e.Cancel = true;
                return;
            }
/*            bool applicable = !IsNotApplicableString(textBoxCalendar.Text);
            if (applicable && !blockValidatindCalendar)
                SetCalendarData(ActualState.ParseCalendar(textBoxCalendar.Text, CalendarTypes), false);
            CalendarApplicable = applicable;*/
        }

        #endregion

        #region private void comboBoxCalendarType_SelectedIndexChanged(object sender, EventArgs e)

        private void comboBoxCalendarType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCalendarType.SelectedIndex == 0)
                calendarTypes = Lifelength.CalendarTypes.Days;
            else if (comboBoxCalendarType.SelectedIndex == 1)
                calendarTypes = Lifelength.CalendarTypes.Months;
            else
                calendarTypes = Lifelength.CalendarTypes.Years;

            
            if (readOnly)
            {
                //blockValidatindCalendar = true;
                SetTextBoxCalendarValue(Calendar.TotalDays);
                //blockValidatindCalendar = false;
            }
            else
            {
                double calendar;
                if (double.TryParse(textBoxCalendar.Text, out calendar))
                    SetCalendarData(Lifelength.ParseCalendar(calendar, CalendarTypes), false);
            }
        }

        #endregion


        #region private void textBoxHours_TextChanged(object sender, EventArgs e)

        private void textBoxHours_TextChanged(object sender, EventArgs e)
        {
            bool applicable = (!IsNotApplicableString(textBoxHours.Text) && textBoxHours.Text != "");
            if (applicable)
            {
                try
                {
                    Hours = Lifelength.ParseHours(textBoxHours.Text);
                }
                catch (Exception ex)
                {
                    return;
                }
            }
            HoursApplicable = applicable;
        }

        #endregion

        #region private void textBoxCycles_TextChanged(object sender, EventArgs e)

        private void textBoxCycles_TextChanged(object sender, EventArgs e)
        {
            bool applicable = (!IsNotApplicableString(textBoxCycles.Text) && textBoxCycles.Text != "");
            if (applicable)
            {
                try
                {
                    Cycles = Int32.Parse(textBoxCycles.Text);
                }
                catch (Exception ex)
                {
                    return;
                }
            }
            CyclesApplicable = applicable;
        }

        #endregion

        #region private void textBoxCalendar_TextChanged(object sender, EventArgs e)

        private void textBoxCalendar_TextChanged(object sender, EventArgs e)
        {
            bool applicable = (!IsNotApplicableString(textBoxCalendar.Text) && textBoxCalendar.Text != "");
            if (applicable && !readOnly && takeIntoAccountLifelengthChanging)
            {
                try
                {
                    lifelength.Calendar = Lifelength.ParseCalendar(textBoxCalendar.Text, CalendarTypes);
                }
                catch (Exception ex)
                {
                    return;
                }
            }
            CalendarApplicable = applicable;
        }

        #endregion


        #region public bool ValidateData()

        /// <summary>
        /// Проверяется корректность введенных данных
        /// </summary>
        /// <returns></returns>
        public bool ValidateData()
        {
            if (!readOnly)
            {
                if (!ValidateHours() || !ValidateCycles() || !ValidateCalendar())
                    return false;
            }
            return true;
        }

        #endregion

        #region private bool ValidateHours()

        private bool ValidateHours()
        {
            if (readOnly)
                return true;
            string text = textBoxHours.Text;
            if (!IsNotApplicableString(text))
            {
                try
                {
                    TimeSpan value = Lifelength.ParseHours(text);
                }
                catch
                {
                    MessageBox.Show("Invalid value for hours parameter", new TermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region private bool ValidateCycles()

        private bool ValidateCycles()
        {
            if (!readOnly)
            {
                string text = textBoxCycles.Text;
                if (!IsNotApplicableString(text))
                {
                    int value = 0;
                    if (!((Int32.TryParse(textBoxCycles.Text, out value)) && value >= 0))
                    {
                        MessageBox.Show("Invalid value for cycles parameter", new TermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
            }
            return true;
        }

        #endregion

        #region private bool ValidateCalendar()

        private bool ValidateCalendar()
        {
            if (!readOnly)
            {
                string text = textBoxCalendar.Text;
                if (!IsNotApplicableString(text))
                {
                    try
                    {
                        TimeSpan value = Lifelength.ParseCalendar(text, CalendarTypes); //todo тут
                    }
                    catch
                    {
                        MessageBox.Show("Invalid value for calendar parameter", new TermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
            }
            return true;
        }

        #endregion
        


        #region private void textBoxHours_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)

        private void textBoxHours_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBoxCycles.Focus();
            }
            if (e.KeyData == Keys.Escape)
            {
                textBoxHours.Text = temporaryHoursField;
            }
        }

        #endregion

        #region private void textBoxCycles_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)

        private void textBoxCycles_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBoxCalendar.Focus();
            }
            if (e.KeyData == Keys.Escape)
            {
                textBoxCycles.Text = temporaryCyclesField;
            }

        }

        #endregion
        
        #region private void textBoxCalendar_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)

        private void textBoxCalendar_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                comboBoxCalendarType.Focus();
            }
/*            if (e.KeyData == Keys.Escape)
            {
                textBoxCalendar.Text = temporaryCalendarField;
            }*/

        }

        #endregion


        #region private void textBoxHours_GotFocus(object sender, EventArgs e)

        private void textBoxHours_GotFocus(object sender, EventArgs e)
        {
            if (IsNotApplicableString(textBoxHours.Text))
                textBoxHours.Text = "";
        }

        #endregion

        #region private void textBoxCycles_GotFocus(object sender, EventArgs e)

        private void textBoxCycles_GotFocus(object sender, EventArgs e)
        {
            if (IsNotApplicableString(textBoxCycles.Text))
                textBoxCycles.Text = "";
        }

        #endregion

        #region private void textBoxCalendar_GotFocus(object sender, EventArgs e)

        private void textBoxCalendar_GotFocus(object sender, EventArgs e)
        {
            if (IsNotApplicableString(textBoxCalendar.Text))
                textBoxCalendar.Text = "";
        }

        #endregion



        #region private void textBoxHours_LostFocus(object sender, EventArgs e)

        private void textBoxHours_LostFocus(object sender, EventArgs e)
        {
            if (textBoxHours.Text == "")
                textBoxHours.Text = NotApplicableString;
            //Lifelength.IsHoursApplicable = (textBoxHours.Text.ToLower() != NotApplicableString && textBoxHours.Text != "");
        }

        #endregion

        #region private void textBoxCycles_LostFocus(object sender, EventArgs e)

        private void textBoxCycles_LostFocus(object sender, EventArgs e)
        {
            if (textBoxCycles.Text == "")
                textBoxCycles.Text = NotApplicableString;
          //  Lifelength.IsCyclesApplicable = (textBoxCycles.Text.ToLower() != NotApplicableString && textBoxCycles.Text != "");
        }

        #endregion

        #region private void textBoxCalendar_LostFocus(object sender, EventArgs e)

        private void textBoxCalendar_LostFocus(object sender, EventArgs e)
        {
            if (textBoxCalendar.Text == "")
                textBoxCalendar.Text = NotApplicableString;
          //  Lifelength.IsCalendarApplicable = (textBoxCalendar.Text.ToLower() != NotApplicableString && textBoxCalendar.Text != "");
        }

        #endregion

        #endregion

        #region Events

        /// <summary>
        /// Событие изменения наработки
        /// </summary>
        public event EventHandler LifelengthChanged;

        #endregion

    }
}