#region

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Auxiliary;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using Convert = System.Convert;

#endregion

namespace CAS.UI.UIControls.Auxiliary
{
    ///<summary>
    /// Класс, описывающий отображение наработки
    ///</summary>
    [Designer(typeof(LifelengthViewerDesigner))]
    public partial class LifelengthViewer : UserControl
    {
        #region Fields

        private const string NotApplicableString = "n/a";

        private CalendarTypes _calendarTypes;
        private Color _fieldsBackColor = SystemColors.Window;
        private bool _isFirstTimeCycles = true;
        private bool _isFirstTimeHours = true;
	    private bool _showFormattedCalendar = false;
		private Lifelength _lifelength;
        private Lifelength _minLifelength;
        private Lifelength _maxLifelength;
        private bool _readOnly;
        private bool _showMinutes = true;
        private string _temporaryCyclesField;
        private string temporaryHoursField;
	    private bool _showHeaders = true;
	    private DateTime _dateFrom = DateTime.Today;
	    private bool _showCalendarOnly;

	    #endregion

		#region Constructors

		#region public LifelengthViewer() : this(new Lifelength())

		///<summary>
		/// Создается объект для отображения пустой наработки
		///</summary>
		public LifelengthViewer()
            : this(new Lifelength())
        {
        }

		#endregion

		#region public LifelengthViewer(Lifelength lifelength)

		///<summary>
		/// Создается объект для отображения заданной наработки
		///</summary>
		///<param name="lifelength">Отображаемая наработка</param>
		public LifelengthViewer(Lifelength lifelength)
        {
            InitializeComponent();
            Initialize();
            Lifelength = new Lifelength(lifelength);
            SystemCalculated = true;
            comboBoxCalendarType.SelectedIndex = 0;
            comboBoxCalendarType.SelectedIndexChanged += ComboBoxCalendarTypeSelectedIndexChanged;
            textBoxHours.GotFocus += TextBoxHoursGotFocus;
            textBoxCycles.GotFocus += TextBoxCyclesGotFocus;
            textBoxCalendar.GotFocus += TextBoxCalendarGotFocus;
            textBoxHours.LostFocus += TextBoxHoursLostFocus;
            textBoxCycles.LostFocus += TextBoxCyclesLostFocus;
            textBoxCalendar.LostFocus += TextBoxCalendarLostFocus;
        }

        #endregion

        #endregion

        #region Properties

        #region public bool ShowLeftHeader

        /// <summary>
        /// Отображать ли левый заголовок
        /// </summary>
        [Category("Appearance"), Description("Отображать левый заголовок")]
        [DefaultValue(true)]
        public bool ShowLeftHeader
        {
            get { return labelLeftHeader.Visible; }
            set { labelLeftHeader.Visible = value; }
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

        #region public int LeftHeaderWidth

        /// <summary>
        /// Размер левого заголовка
        /// </summary>
        public int LeftHeaderWidth
        {
            get { return tableLayoutPanelMain.GetColumnWidths()[0]; }
        }

        #endregion

        #region public int WidthWithoutLeftHeader

        /// <summary>
        /// Размер контрола без левого заголовка
        /// </summary>
        public int WidthWithoutLeftHeader
        {
            get { return tableLayoutPanelMain.Width - tableLayoutPanelMain.GetColumnWidths()[0]; }
        }

		#endregion

		[DefaultValue(false)]
		public bool ShowCalendarOnly
	    {
		    get { return _showCalendarOnly; }
			set
			{
				_showCalendarOnly = value;
				textBoxCycles.Visible = !value;
				textBoxHours.Visible = !value;
				labelCyclesHeader.Visible = !value;
				labelHoursHeader.Visible = !value;
			}
	    }

	    #region public bool ShowHeaders

        /// <summary>
        /// Отображать ли заголовки
        /// </summary>
        [Category("Appearance"), Description("Отображать заголовки параметров")]
        [DefaultValue(true)]
        public bool ShowHeaders
        {
            get { return _showHeaders; }
            set
            {
	            _showHeaders = value;
				if(_showFormattedCalendar)
					FormattedCalendarHeader.Visible = _showHeaders;
				else CalendarHeader.Visible = _showHeaders;

				labelCyclesHeader.Visible = _showHeaders;
                labelHoursHeader.Visible = _showHeaders;
	            
	            //panelHeaders.Visible = value;
	            //panelVoid.Visible = value;
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

		#region public string HeaderFormattedCalendar
		/// <summary>
		/// Текст заголовка сверху поля календарной наработки(отформатированной)
		/// </summary>
		public string HeaderFormattedCalendar
	    {
		    get { return FormattedCalendarHeader.Text; }
		    set { FormattedCalendarHeader.Text = value; }
	    }

	    #endregion

		#region public Color FieldsBackColor

		/// <summary>
		/// Фон полей в режиме
		/// </summary>
		public Color FieldsBackColor
        {
            get { return _fieldsBackColor; }
            set { _fieldsBackColor = value; }
        }

        #endregion

        #region public Lifelength Lifelength

        /// <summary>
        /// Отображаемая наработка
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DefaultValue(null)]
        public Lifelength Lifelength
        {
            get { return _lifelength; }
            set
            {
                if (_lifelength != null && _lifelength.IsEqual(value)) return;

                _lifelength = null;
                _lifelength = new Lifelength(value);
                //lifelength.DateChanged += lifelength_DateChanged;
                UpdateData();

            }
        }

        #endregion

        #region public Lifelength MinLifelength

        /// <summary>
        /// Возвращает или задает минимальное значение наработки, которое может быть задано в элементе управления
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DefaultValue(null)]
        public Lifelength MinLifelength
        {
            get { return _minLifelength; }
            set
            {
                if (_minLifelength != null && _minLifelength.IsEqual(value)) return;
                
                _minLifelength = new Lifelength(value);
            }
        }

        #endregion

        #region public Lifelength MaxLifelength

        /// <summary>
        /// Возвращает или задает масимальное значение наработки, которое может быть задано в элементе управления
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DefaultValue(null)]
        public Lifelength MaxLifelength
        {
            get { return _maxLifelength; }
            set
            {
                if (_maxLifelength != null && _maxLifelength.IsEqual(value)) return;

                _maxLifelength = new Lifelength(value);
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
            get { return _lifelength.TotalMinutes != null; }
            set
            {
                if (value == false)
                    _lifelength.TotalMinutes = null;
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
            get { return _lifelength.Cycles != null; }
            set
            {
                if (!value)
                    _lifelength.Cycles = null;
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
            get { return _lifelength.Days != null; }
            set
            {
                if (!value)
                    _lifelength.CalendarValue = null;
            }
        }

        #endregion

        #region public bool ReadOnly

        ///<summary>
        /// Отображать наработку только для чтения
        ///</summary>
        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                textBoxCalendar.ReadOnly = value;
                textBoxCycles.ReadOnly = value;
                textBoxHours.ReadOnly = value;

				textBoxCycles.ForeColor = Css.OrdinaryText.Colors.ForeColor;
                textBoxHours.ForeColor = Css.OrdinaryText.Colors.ForeColor;
                textBoxCalendar.ForeColor = Css.OrdinaryText.Colors.ForeColor;
				textBoxFormattedCalendar.ForeColor = Css.OrdinaryText.Colors.ForeColor;
				if (value)
                {
                    textBoxCycles.BackColor = SystemColors.Control;
                    textBoxHours.BackColor = SystemColors.Control;
                    textBoxCalendar.BackColor = SystemColors.Control;
					textBoxFormattedCalendar.BackColor = SystemColors.Control;
				}
                else
                {
                    textBoxCycles.BackColor = SystemColors.Window;
                    textBoxHours.BackColor = SystemColors.Window;
                    textBoxCalendar.BackColor = SystemColors.Window;
					textBoxFormattedCalendar.BackColor = SystemColors.Window;
				}
            }
        }

        #endregion

        #region public int? Cycles

        /// <summary>
        /// Значение наработки по циклам
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? Cycles
        {
            get { return _lifelength.Cycles; }
            set
            {
                _lifelength.Cycles = value;
                if (_isFirstTimeCycles)
                {
                    _temporaryCyclesField = _lifelength.Cycles.ToString();
                    _isFirstTimeCycles = false;
                }

                if (_minLifelength != null && _minLifelength.Cycles != null)
                {
                    if (value != null && value < _minLifelength.Cycles)
                    {
                        textBoxCycles.BackColor = Color.Red;
                        return;
                    }
                    textBoxCycles.BackColor = Color.White;
                }
                if (_maxLifelength != null && _maxLifelength.Cycles != null)
                {
                    if (value != null && value > _maxLifelength.Cycles)
                    {
                        textBoxCycles.BackColor = Color.Red;
                        return;
                    }
                    textBoxCycles.BackColor = Color.White;
                }
            }
        }

        #endregion

        #region public int? Hours

        /// <summary>
        /// Значение наработки по часам
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? TotalMinutes
        {
            get { return _lifelength.TotalMinutes; }
            set
            {
                _lifelength.TotalMinutes = value;
                /* if (isFirstTimeHours)
                {
                    temporaryHoursField = Lifelength.GetHoursString(value, showMinutes);
                    isFirstTimeHours = false;
                }*/
                if (_minLifelength != null && _minLifelength.TotalMinutes != null)
                {
                    if (value != null && value < _minLifelength.TotalMinutes)
                    {
                        textBoxHours.BackColor = Color.Red;
                        return;
                    }
                    textBoxHours.BackColor = Color.White;
                }
                if (_maxLifelength != null && _maxLifelength.TotalMinutes != null)
                {
                    if (value != null && value > _maxLifelength.TotalMinutes)
                    {
                        textBoxHours.BackColor = Color.Red;
                        return;
                    }
                    textBoxHours.BackColor = Color.White;
                }
            }
        }

        #endregion

        #region public int? CalendarValue

        /// <summary>
        /// Значение наработки по дням
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? CalendarValue
        {
            set
            {
                _lifelength.CalendarValue = value;

                if (_minLifelength != null && _minLifelength.CalendarValue != null)
                {
                    if (value != null && _lifelength.CalendarSpan < _minLifelength.CalendarSpan)
                    {
                        textBoxCalendar.BackColor = Color.Red;
                        return;
                    }
                    textBoxCalendar.BackColor = Color.White;
                }
                if (_maxLifelength != null && _maxLifelength.CalendarValue != null)
                {
                    if (value != null && _lifelength.CalendarSpan > _maxLifelength.CalendarSpan)
                    {
                        textBoxCalendar.BackColor = Color.Red;
                        return;
                    }
                    textBoxCalendar.BackColor = Color.White;
                }
            }
        }

        #endregion

        #region public TimeSpan Calendar

        /// <summary>
        /// Значение наработки по часам
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private TimeSpan Calendar
        {
            get { return _lifelength.Days != null ? new TimeSpan((int)_lifelength.Days, 0, 0, 0) : new TimeSpan(0, 0, 0); }
        }

		#endregion

		#region public DateTime DateFrom { set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
	    public DateTime DateFrom
	    {
		    set { _dateFrom = value; }
	    }

	    #endregion

		#region public bool ShowCalendar

		/// <summary>
		/// Показывать ли поле календарь
		/// </summary>
		public bool ShowCalendar
        {
            get { return textBoxCalendar.Visible; }
            set
            {
				textBoxCalendar.Visible = value;
				comboBoxCalendarType.Visible = value;
				CalendarHeader.Visible = _showHeaders && value;

	            _showFormattedCalendar = !value;
	            textBoxFormattedCalendar.Visible = !value;
	            FormattedCalendarHeader.Visible = _showHeaders && !value;
            }
        }

		#endregion
		
		#region public bool ShowFormattedCalendar

		public bool ShowFormattedCalendar
	    {
		    get { return textBoxFormattedCalendar.Visible; }
		    set
		    {
			    textBoxCalendar.Visible = !value;
			    comboBoxCalendarType.Visible = !value;
			    CalendarHeader.Visible = _showHeaders && !value;

			    _showFormattedCalendar = value;
			    textBoxFormattedCalendar.Visible = value;
			    FormattedCalendarHeader.Visible = _showHeaders && value;
		    }
	    }

		#endregion

		#region private bool Modified

		/// <summary>
		/// Возвращает или устанавливает значение, показывающее были ли изменения в отображаемой наработке
		/// </summary>
		public bool Modified { get; set; }

        #endregion

        #region public ComboBox ComboBoxCalendarType

        /// <summary>
        /// Возвращает ComboBox с типом календаря
        /// </summary>
        public ComboBox ComboBoxCalendarType
        {
            get { return comboBoxCalendarType; }
        }

        #endregion

        #region public TextBox TextBoxHours

        /// <summary>
        /// Возвращает текстовое поле с количеством часов наработки
        /// </summary>
        public TextBox TextBoxHours
        {
            get { return textBoxHours; }
        }

        #endregion

        #region public bool ShowMinutes

        /// <summary>
        /// Возвращает или устанавливает свойство, показывающее нужно ли отображать минуты в поле Hours
        /// </summary>
        public bool ShowMinutes
        {
            get { return _showMinutes; }
            set { _showMinutes = value; }
        }

        #endregion

        #region private CalendarTypes CalendarTypes

        private CalendarTypes CalendarType
        {
            get { return _calendarTypes; }
            set
            {
                _calendarTypes = value;
                if (value == CalendarTypes.Months)
                    comboBoxCalendarType.SelectedIndex = 1;
                else if (value == CalendarTypes.Years)
                    comboBoxCalendarType.SelectedIndex = 2;
                else
                    comboBoxCalendarType.SelectedIndex = 0;

                _lifelength.CalendarType = value;

                if (_minLifelength != null && _minLifelength.CalendarValue != null)
                {
                    if (_lifelength.CalendarSpan < _minLifelength.CalendarSpan)
                    {
                        textBoxCalendar.BackColor = Color.Red;
                        return;
                    }
                    textBoxCalendar.BackColor = Color.White;
                }
                if (_maxLifelength != null && _maxLifelength.CalendarValue != null)
                {
                    if (_lifelength.CalendarSpan > _maxLifelength.CalendarSpan)
                    {
                        textBoxCalendar.BackColor = Color.Red;
                        return;
                    }
                    textBoxCalendar.BackColor = Color.White;
                }
            }
        }

        #endregion

        #region public bool SystemCalculated

        /// <summary>
        /// Если данные в Lifelenfgt калькулировала система тогда true, если пользователь false
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public bool SystemCalculated { get; set; }

        #endregion

        #region EnabledCalendar
        ///<summary>
        /// Флаг, показвающий, доступен ли календарь
        ///</summary>
        public bool EnabledCalendar
        {
            get { return textBoxCalendar.Enabled; }
            set
            {
				textBoxFormattedCalendar.Enabled = value;
				textBoxCalendar.Enabled = value;
                comboBoxCalendarType.Enabled = value;
            }
        }

        #endregion

        #region EnabledCycle
        ///<summary>
        /// Флаг, показвающий, доступны ли циклы
        ///</summary>
        public bool EnabledCycle
        {
            get { return textBoxCycles.Enabled; }
            set
            {
                textBoxCycles.Enabled = value;
            }
        }

        #endregion

        #region EnabledHours
        ///<summary>
        /// Флаг, показвающий, доступны ли часы
        ///</summary>
        public bool EnabledHours
        {
            get { return textBoxHours.Enabled; }
            set
            {
                textBoxHours.Enabled = value;
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
			Css.OrdinaryText.Adjust(FormattedCalendarHeader);
			comboBoxCalendarType.ForeColor = Css.OrdinaryText.Colors.ForeColor;

            //tableLayoutPanel1.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxCycles.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxCalendar.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxHours.ForeColor = Css.OrdinaryText.Colors.ForeColor;
			textBoxFormattedCalendar.ForeColor = Css.OrdinaryText.Colors.ForeColor;
		}

        #endregion

        #region private void UpdateData()
        ///<summary>
        /// Обноыляет данные в контроле
        ///</summary>
        public void UpdateData()
        {
            HoursApplicable = _lifelength.Hours != null;
            //CalendarApplicable = _lifelength.Days != null;
            CalendarApplicable = _lifelength.CalendarValue != null;
            CyclesApplicable = _lifelength.Cycles != null;
            Cycles = _lifelength.Cycles;
            TotalMinutes = _lifelength.TotalMinutes;
            if (_lifelength.Hours != null)
            {
                int totalMinutes = Convert.ToInt32(_lifelength.TotalMinutes);
                int hours = totalMinutes / 60;
                int minutes = totalMinutes - (hours*60);
                SetData(GetHoursString(new TimeSpan(hours, minutes, 0), _showMinutes), 
                        HoursApplicable,
                        textBoxHours);
            }
            else
                SetData(GetHoursString(new TimeSpan(), _showMinutes), HoursApplicable, textBoxHours);
            SetData(_lifelength.Cycles.ToString(), CyclesApplicable, textBoxCycles);
            SetCalendarData(_lifelength.CalendarSpan, true);
        }

		#endregion

		#region private void SetCalendarData(CalendarSpan calendarSpan, bool changeCalendarTypes)

		private void SetCalendarData(CalendarSpan calendarSpan, bool changeCalendarTypes)
        {
            int days = Convert.ToInt32(calendarSpan.CalendarValue);
            if (_readOnly || changeCalendarTypes)
            {
                if (!CalendarApplicable)
                {
                    textBoxCalendar.Text = NotApplicableString;
	                textBoxFormattedCalendar.Text = NotApplicableString;
                }
                else
                {
	                if (_showFormattedCalendar)
		                SetTextBoxFormattedCalendarValue(days);
	                else
	                {
						textBoxCalendar.Text = days.ToString();
						CalendarType = calendarSpan.CalendarType;
					}	
                }
            }
            else
            {
				if (_showFormattedCalendar)
					SetTextBoxFormattedCalendarValue(days);
				else SetTextBoxCalendarValue(days);
            }
        }

        #endregion

        #region private void SetTextBoxCalendarValue(double days)

        private void SetTextBoxCalendarValue(double days)
        {
            if (CalendarType == CalendarTypes.Years)
                textBoxCalendar.Text = Math.Round(days / 365.0, 1).ToString();
            else if (CalendarType == CalendarTypes.Months)
                textBoxCalendar.Text = Math.Round(days / 30.0, 1).ToString();
            else
                textBoxCalendar.Text = Math.Round(days, 1).ToString();
        }

		#endregion

	    private void SetTextBoxFormattedCalendarValue(double days)
	    {
		    var dateTo = _dateFrom.AddDays(days);
		    var difference = _dateFrom.DifferenceDateTime(dateTo);

			var sb = new StringBuilder();

		    if (difference.Years > 0)
			    sb.AppendFormat($"{difference.Years}y");
		    if (difference.Months > 0)
		    {
			    if (sb.Length > 0)
				    sb.AppendFormat(" ");
			    sb.AppendFormat($"{difference.Months}m");
		    }
		    if (difference.Days > 0)
		    {
				if (sb.Length > 0)
					sb.AppendFormat(" ");
				sb.AppendFormat($"{difference.Days}d");
			}

			textBoxFormattedCalendar.Text = sb.ToString();
	    }


		#region private void SetData(string data, bool applicable, TextBox destinationTextBox)

		private void SetData(string data, bool applicable, TextBox destinationTextBox)
        {
            if (applicable)
                destinationTextBox.Text = data;
            else
                destinationTextBox.Text = NotApplicableString;
        }

        #endregion

        #region private void lifelength_DateChanged(object sender, EventArgs e)

        private void lifelength_DateChanged(object sender, EventArgs e)
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

        #region private void TextBoxHoursValidating(object sender, CancelEventArgs e)

        private void TextBoxHoursValidating(object sender, CancelEventArgs e)
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

        #region private void TextBoxCyclesValidating(object sender, CancelEventArgs e)

        private void TextBoxCyclesValidating(object sender, CancelEventArgs e)
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

        #region private void TextBoxCalendarValidating(object sender, CancelEventArgs e)

        private void TextBoxCalendarValidating(object sender, CancelEventArgs e)
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

        #region private void ComboBoxCalendarTypeSelectedIndexChanged(object sender, EventArgs e)

        private void ComboBoxCalendarTypeSelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCalendarType.SelectedIndex == 0)
                _calendarTypes = CalendarTypes.Days;
            else if (comboBoxCalendarType.SelectedIndex == 1)
                _calendarTypes = CalendarTypes.Months;
            else
                _calendarTypes = CalendarTypes.Years;


            if (_readOnly)
            {
                SetTextBoxCalendarValue(Calendar.TotalDays);
            }
            else
            {
                _lifelength.CalendarType = _calendarTypes;
                //double calendar;
                //if (double.TryParse(textBoxCalendar.Text, out calendar))
                //{
                //    SetCalendarData(ParseCalendar(calendar, CalendarType), false);
                //    //Код по новому принципу
                //    _lifelength.CalendarType = _calendarTypes;
                //}

                int data;
                if (int.TryParse(textBoxCalendar.Text, out data))
                {
                    SetCalendarData(_lifelength.CalendarSpan, true);
                }
            }
            TextBoxCalendarTextChanged(null, null);
        }

        #endregion

        #region private void TextBoxHoursTextChanged(object sender, EventArgs e)

        private void TextBoxHoursTextChanged(object sender, EventArgs e)
        {
            bool applicable = (!IsNotApplicableString(textBoxHours.Text) && textBoxHours.Text != "");
            if (applicable)
            {
                try
                {
                    TimeSpan timeSpan = ParseHours(textBoxHours.Text);
                    TotalMinutes = (int)timeSpan.TotalMinutes;
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid value for hours parameter",
                                        new GlobalTermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                    return;
                }
            }
            HoursApplicable = applicable;
        }

        #endregion

        #region private void TextBoxCyclesTextChanged(object sender, EventArgs e)

        private void TextBoxCyclesTextChanged(object sender, EventArgs e)
        {
            bool applicable = (!IsNotApplicableString(textBoxCycles.Text) && textBoxCycles.Text != "");
            if (applicable)
            {
                try
                {
                    Cycles = Int32.Parse(textBoxCycles.Text);
                }
                catch (Exception)
                {
                    return;
                }
            }
            CyclesApplicable = applicable;
        }

        #endregion

        #region private void TextBoxCalendarTextChanged(object sender, EventArgs e)

        private void TextBoxCalendarTextChanged(object sender, EventArgs e)
        {
            bool applicable = (!IsNotApplicableString(textBoxCalendar.Text) && textBoxCalendar.Text != "");
            if (applicable && !_readOnly)
            {
                try
                {
                    int data = int.Parse(textBoxCalendar.Text);
                    CalendarValue = data;
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid value for calendar parameter",
                                        new GlobalTermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                    return;
                }
            }
            CalendarApplicable = applicable;
        }

        #endregion

        #region private void TextBoxHoursKeyUp(object sender, KeyEventArgs e)

        private void TextBoxHoursKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab || !ValidateHours()) return;

            if (LifelengthChanged != null)
                LifelengthChanged(this, EventArgs.Empty);
        }
        #endregion

        #region private void TextBoxCyclesKeyUp(object sender, KeyEventArgs e)

        private void TextBoxCyclesKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab || !ValidateCycles()) return;

            if (LifelengthChanged != null)
                LifelengthChanged(this, EventArgs.Empty);
        }
        #endregion

        #region private void TextBoxCalendarKeyUp(object sender, KeyEventArgs e)

        private void TextBoxCalendarKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Tab || !ValidateCalendar()) return;

            if (LifelengthChanged != null)
                LifelengthChanged(this, EventArgs.Empty);
        }
        #endregion

        #region public bool ValidateData()

        /// <summary>
        /// Проверяется корректность введенных данных
        /// </summary>
        /// <returns></returns>
        public bool ValidateData()
        {
            if (!_readOnly)
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
            if (_readOnly)
                return true;
            string text = textBoxHours.Text;
            if (!IsNotApplicableString(text))
            {
                try
                {
                    ParseHours(text);
                }
                catch
                {
                    MessageBox.Show("Invalid value for hours parameter",
                                    new GlobalTermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region private bool ValidateCycles()

        private bool ValidateCycles()
        {
            if (!_readOnly)
            {
                string text = textBoxCycles.Text;
                if (!IsNotApplicableString(text))
                {
                    int value;
                    if (!((Int32.TryParse(textBoxCycles.Text, out value)) && value >= 0))
                    {
                        MessageBox.Show("Invalid value for cycles parameter",
                                        new GlobalTermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK,
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
            if (!_readOnly)
            {
                string text = textBoxCalendar.Text;
                if (!IsNotApplicableString(text))
                {
                    try
                    {
                        Int32.Parse(text);
                    }
                    catch
                    {
                        MessageBox.Show("Invalid value for calendar parameter",
                                        new GlobalTermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
            }
            return true;
        }

        #endregion

        #region private void TextBoxHoursPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)

        private void TextBoxHoursPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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

        #region private void TextBoxCyclesPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)

        private void TextBoxCyclesPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                textBoxCalendar.Focus();
            }
            if (e.KeyData == Keys.Escape)
            {
                textBoxCycles.Text = _temporaryCyclesField;
            }
        }

        #endregion

        #region private void TextBoxCalendarPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)

        private void TextBoxCalendarPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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

        #region private void TextBoxHoursGotFocus(object sender, EventArgs e)

        private void TextBoxHoursGotFocus(object sender, EventArgs e)
        {
            if (IsNotApplicableString(textBoxHours.Text))
                textBoxHours.Text = "";
        }

        #endregion

        #region private void TextBoxCyclesGotFocus(object sender, EventArgs e)

        private void TextBoxCyclesGotFocus(object sender, EventArgs e)
        {
            if (IsNotApplicableString(textBoxCycles.Text))
                textBoxCycles.Text = "";
        }

        #endregion

        #region private void TextBoxCalendarGotFocus(object sender, EventArgs e)

        private void TextBoxCalendarGotFocus(object sender, EventArgs e)
        {
            if (IsNotApplicableString(textBoxCalendar.Text))
                textBoxCalendar.Text = "";
        }

        #endregion

        #region private void TextBoxHoursLostFocus(object sender, EventArgs e)

        private void TextBoxHoursLostFocus(object sender, EventArgs e)
        {
            if (textBoxHours.Text == "")
                textBoxHours.Text = NotApplicableString;
        }

        #endregion

        #region private void TextBoxCyclesLostFocus(object sender, EventArgs e)

        private void TextBoxCyclesLostFocus(object sender, EventArgs e)
        {
            if (textBoxCycles.Text == "")
                textBoxCycles.Text = NotApplicableString;
            //  Lifelength.IsCyclesApplicable = (textBoxCycles.Text.ToLower() != NotApplicableString && textBoxCycles.Text != "");
        }

        #endregion

        #region private void TextBoxCalendarLostFocus(object sender, EventArgs e)

        private void TextBoxCalendarLostFocus(object sender, EventArgs e)
        {
            if (textBoxCalendar.Text == "")
                textBoxCalendar.Text = NotApplicableString;
            //  Lifelength.IsCalendarApplicable = (textBoxCalendar.Text.ToLower() != NotApplicableString && textBoxCalendar.Text != "");
        }

        #endregion

        #region private static TimeSpan ParseHours(string text)

        /// <summary>
        /// Преобразование данных из строки в <see cref="TimeSpan"/> согласно формату отображения часовой наработки
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static TimeSpan ParseHours(string text)
        {
            Regex regex = new Regex(@"^(?<Hours>-?\d+)(:(?<Minutes>([0-9]|[0-5][0-9])))?$");
            Match match = regex.Match(text);

            if (!match.Success)
                throw new ArgumentException("Parameter is not valid and cannot be converted", "text");
            int hours = Int32.Parse(match.Groups["Hours"].Value);
            int minutes;
            Int32.TryParse(match.Groups["Minutes"].Value, out minutes);

            return new TimeSpan(hours, minutes, 0);
        }

        #endregion

        #region private static string GetHoursString(TimeSpan data, bool showMinutes)

        /// <summary>
        /// Преобразование часовой наработки в строковый формат
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <param name="showMinutes">Показывать ли минуты</param>
        private static string GetHoursString(TimeSpan data, bool showMinutes)
        {
            int hours = (int)data.TotalHours;
            int minutes = data.Minutes;
            if (hours < 0) minutes = Math.Abs(minutes);
            if (showMinutes)
                return $"{hours}:{minutes.ToString().PadLeft(2, '0')}";
            return hours.ToString();
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


    internal class LifelengthViewerDesigner : ControlDesigner
    {
        protected override void PostFilterProperties(IDictionary properties)
        {
            base.PostFilterProperties(properties);
            properties.Remove("Lifelength");
            properties.Remove("Hours");
            properties.Remove("Cycles");
            properties.Remove("Days");
			properties.Remove("Calendar");
			properties.Remove("TotalMinutes");
        }
    }
}