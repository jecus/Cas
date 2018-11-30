using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Controls;
using Controls.AvButtonStatus;
using Controls.ExtendableList;
using LTR.Core.Types.Aircrafts.Parts;
using LTR.Core.Types.Dictionaries;
using LTR.UI.Appearance;

namespace LTR.UI.UIControls.LogBookControls
{
    public partial class AircraftBaseDetailItem : PictureBox, IExtendableItem
    {
        #region Constructors
        /// <summary>
        /// Создается элемент управления для отбражения нароботок базовой детали
        /// </summary>
        /// <param name="baseDetail"></param>
        public AircraftBaseDetailItem(BaseDetail baseDetail)
        {
            this.baseDetail = baseDetail;
            name = baseDetail.GetType().Name;
            serialNumber = baseDetail.SerialNumber;
            condition = baseDetail.Condition;
            InitializeComponent();
            InitializeItem();
        }
        #endregion

        #region Fields
        private AvButtonStatus avButtonStatusBaseDetail;
        private Label labelNameHours;
        private Label labelNameCycles;
        private TextBox textBoxHours;
        private TextBox textBoxMinutes;
        private Label labelSplitter;
        private TextBox textBoxCycles;

        private readonly string name;
        private readonly string serialNumber;
        private readonly DirectiveConditionState condition;
        private BaseDetail baseDetail;

        private const int EXTANDED_HEIGTH = 130;
        private const int SHORT_HEIGHT = 54;
        private const int LABEL_HORIZONTAL_MARGIN = 50;
        private const int LABEL_VERTICAL_MARGIN = 15;
        private const int LABEL_HEIGHT = 20;
        private readonly Color EXTENDED_CONTROL_COLOR = Color.FromArgb(255, 233, 166);
        #endregion

        #region Events

        #region public event EventHandler Extended;
        /// <summary>
        /// Событии вызываемое на развернутое состояние элемета управления 
        /// </summary>
        public event EventHandler Extended;
            #endregion

        #region public event EventHandler Extending;
        /// <summary>
        /// Событие вызываемое на переход элемента управления в расширенное состояние
        /// </summary>
        public event EventHandler Extending;
        #endregion

        #endregion

        #region Properties

        #region public string BaseDetailName
        /// <summary>
        /// Название базовой детали
        /// </summary>
        public string BaseDetailName
        {
            get { return name; }
        }
        #endregion

        #region public string SerialNumber
        /// <summary>
        /// Серийный номер детали
        /// </summary>
        public string SerialNumber
        {
            get { return serialNumber; }
        }
        #endregion

        #region public DirectiveConditionState Condition
        /// <summary>
        /// Состояние директивы
        /// </summary>
        public DirectiveConditionState Condition
        {
            get { return condition; }
        }
        #endregion

        #region public string Hours
        /// <summary>
        /// Количество часов использования агрегата
        /// </summary>
        public string Hours
        {
            get { return textBoxHours.Text; }
            set { textBoxHours.Text = value; }
        }
        #endregion

        #region public string Minutes
        /// <summary>
        /// Количество минут использование агрегата
        /// </summary>
        public string Minutes
        {
            get { return textBoxMinutes.Text; }
            set
            {
                textBoxMinutes.Text = value;       
            }
        }
        #endregion

        #region public string Cycles
        /// <summary>
        /// Количество циклов использования агрегата
        /// </summary>
        public string Cycles
        {
            get { return textBoxCycles.Text; }
            set
            {
                textBoxCycles.Text = value;
            }
        }
        #endregion

        #region private RegularFont TextFont
        private Font TextFont
        {
            get
            {
                return textBoxHours.Font;
            }
            set
            {
                textBoxHours.Font = value;
                textBoxCycles.Font = value;
                textBoxMinutes.Font = value;
                labelSplitter.Font = value;
                labelNameCycles.Font = value;
                labelNameHours.Font = value;
            }
        }
        #endregion

        #region private Color TextColor
        private Color TextColor
        {
            get { return textBoxHours.ForeColor; }
            set
            {
                textBoxHours.ForeColor = value;
                textBoxCycles.ForeColor = value;
                textBoxMinutes.ForeColor = value;
                labelSplitter.ForeColor = value;
                labelNameCycles.ForeColor = value;
                labelNameHours.ForeColor = value;
            }
        }

        #region IScrollLayoutPanelItem Members

        public int BlocksCount
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        #endregion


        #endregion

        #region Methods

        #region private void InitializeItem()
        private void InitializeItem()
        {
            BackColor = Color.Transparent;
            Height = SHORT_HEIGHT;
            Margin = new Padding(0);
            
            avButtonStatusBaseDetail = new AvButtonStatus();
            labelNameHours = new Label();
            labelSplitter = new Label();
            labelNameCycles = new Label();
            textBoxHours = new TextBox();
            textBoxMinutes = new TextBox();
            textBoxCycles = new TextBox();
            TextFont = Css.OrdinaryText.Fonts.RegularFont;
            TextColor = Css.OrdinaryText.Colors.ForeColor;
            //
            // avButtonStatusBaseDetail
            //
            avButtonStatusBaseDetail.Location = new Point(0,0);
            avButtonStatusBaseDetail.TextMain = name;
            avButtonStatusBaseDetail.TextSecondary = serialNumber;
            avButtonStatusBaseDetail.Status = (Statuses)condition;
            Width = avButtonStatusBaseDetail.Width;
            //
            // labelNameHours
            //
            labelNameHours.Text = "Hours";
            labelNameHours.TextAlign = ContentAlignment.MiddleCenter;
            labelNameHours.Location = new Point(LABEL_HORIZONTAL_MARGIN,avButtonStatusBaseDetail.Bottom+LABEL_VERTICAL_MARGIN);
            labelNameHours.Size = new Size((Width/2)-LABEL_HORIZONTAL_MARGIN,LABEL_HEIGHT);
            //
            // labelNameCycles
            //
            labelNameCycles.Text = "Cycles";
            labelNameCycles.TextAlign = ContentAlignment.MiddleCenter;
            labelNameCycles.Location = new Point(labelNameHours.Right,labelNameHours.Top);
            labelNameCycles.Size = labelNameHours.Size;
            //
            // textBoxHours
            //
            textBoxHours.ReadOnly = true;
            textBoxHours.MaxLength = 2;
            textBoxHours.BackColor = EXTENDED_CONTROL_COLOR;
            textBoxHours.TextAlign = HorizontalAlignment.Center;
            textBoxHours.BorderStyle = BorderStyle.None;
            textBoxHours.Text = baseDetail.Lifelength.Hours.TotalHours.ToString();
            textBoxHours.Location = new Point(labelNameHours.Left,labelNameHours.Bottom);
            textBoxHours.Size = new Size((labelNameHours.Width/3),LABEL_HEIGHT);
            textBoxHours.Click += textBoxHours_Click;
            textBoxHours.TextChanged += textBoxHours_TextChanged;
            textBoxHours.KeyPress += textBoxHours_KeyPress;
            // 
            // labelSplitter
            //
            labelSplitter.TextAlign = ContentAlignment.MiddleCenter;
            labelSplitter.Text = ":";
            labelSplitter.Location = new Point(textBoxHours.Right,textBoxHours.Top);
            labelSplitter.Size = new Size(20,textBoxHours.Height);
            //
            // textBoxMinutes
            //
            textBoxMinutes.ReadOnly = true; 
            textBoxMinutes.MaxLength = 2;
            textBoxMinutes.BackColor = EXTENDED_CONTROL_COLOR;
            textBoxMinutes.TextAlign = HorizontalAlignment.Center;
            textBoxMinutes.BorderStyle = BorderStyle.None;
            textBoxMinutes.Text = baseDetail.Lifelength.Hours.Minutes.ToString();
            textBoxMinutes.Location = new Point(labelSplitter.Right,labelSplitter.Top);
            textBoxMinutes.Click += textBoxMinutes_Click;
            textBoxMinutes.Size = textBoxHours.Size ;
            textBoxMinutes.TextChanged += textBoxMinutes_TextChanged;
            textBoxMinutes.KeyPress += textBoxMinutes_KeyPress;
            //
            // textBoxCycles
            //
            textBoxCycles.ReadOnly = true; 
            textBoxCycles.MaxLength = 3;
            textBoxCycles.BackColor = EXTENDED_CONTROL_COLOR;
            textBoxCycles.TextAlign = HorizontalAlignment.Center;
            textBoxCycles.BorderStyle = BorderStyle.None;
            textBoxCycles.Text = baseDetail.Lifelength.Cycles.ToString();
            textBoxCycles.Location = new Point(labelNameCycles.Left,labelNameCycles.Bottom);
            textBoxCycles.Size = labelNameCycles.Size;
            textBoxCycles.Click += textBoxCycles_Click;
            textBoxCycles.TextChanged += textBoxCycles_TextChanged;
            textBoxCycles.KeyPress += textBoxCycles_KeyPress;
           

            Controls.Add(avButtonStatusBaseDetail);
            Controls.Add(labelNameHours);
            Controls.Add(labelNameCycles);
            Controls.Add(textBoxCycles);
            Controls.Add(textBoxHours);
            Controls.Add(labelSplitter);
            Controls.Add(textBoxMinutes);
        }

      
        #endregion

        #region public void SetShortView()
        public void SetShortView()
        {
            Height = SHORT_HEIGHT;
        }
        #endregion

        #region public void SetExtendedView()
        public void SetExtendedView()
        {
            Height = EXTANDED_HEIGTH;
            BackColor = EXTENDED_CONTROL_COLOR;
        }
        #endregion

        #region protected override void OnSizeChanged(EventArgs e)
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (avButtonStatusBaseDetail!=null) Width = avButtonStatusBaseDetail.Width;
        }
        #endregion

        #region private bool CheckText(string text)
        private bool CheckText(string text)
        {
            if (Regex.IsMatch(text, @"^\d+$")) return true; else return false;
        }
        #endregion

        #region private bool CheckMinutes(string text)
        private string CheckMinutes(string text)
        {
            if (text == "") return text;
            int tempInt = Convert.ToInt32(text);
            if (tempInt > 59) return "59";
            return text;
        }
        #endregion

        #region void textBoxHours_TextChanged(object sender, EventArgs e)
        void textBoxHours_TextChanged(object sender, EventArgs e)
        {
            if (!CheckText(textBoxCycles.Text)) textBoxCycles.Text = "";
        }
        #endregion

        #region void textBoxMinutes_TextChanged(object sender, EventArgs e)
        void textBoxMinutes_TextChanged(object sender, EventArgs e)
        {
            if (CheckText(textBoxMinutes.Text))
            {
                textBoxMinutes.Text = CheckMinutes(textBoxMinutes.Text);
            }
            else textBoxMinutes.Text = "";
        }
        #endregion

        #region void textBoxHours_KeyPress(object sender, KeyPressEventArgs e)
        void textBoxHours_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < '0') || (e.KeyChar > '9')) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        #endregion

        #region void textBoxMinutes_KeyPress(object sender, KeyPressEventArgs e)
        void textBoxMinutes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < '0') || (e.KeyChar > '9')) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        #endregion

        #region private void textBoxCycles_KeyPress(object sender, KeyPressEventArgs e)
        private void textBoxCycles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < '0') || (e.KeyChar > '9')) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        #endregion

        #region void textBoxCycles_TextChanged(object sender, EventArgs e)
        void textBoxCycles_TextChanged(object sender, EventArgs e)
        {
            if (!CheckText(textBoxCycles.Text)) textBoxCycles.Text = "";
        }
        #endregion

        #region void textBoxHours_Click(object sender, EventArgs e)
        void textBoxHours_Click(object sender, EventArgs e)
        {
            textBoxHours.ReadOnly = false;
        }
        #endregion

        #region void textBoxCycles_Click(object sender, EventArgs e)
        void textBoxCycles_Click(object sender, EventArgs e)
        {
            textBoxCycles.ReadOnly = false;
        }
        #endregion

        #region void textBoxMinutes_Click(object sender, EventArgs e)
        void textBoxMinutes_Click(object sender, EventArgs e)
        {
            textBoxMinutes.ReadOnly = false;
        }
        #endregion

        #endregion

    }
}
