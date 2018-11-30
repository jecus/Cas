using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.Appearance;

namespace CAS.UI.UIControls.LogBookControls
{
/*
    /// <summary>
    /// Элемент управления для отображения нароботки агрегата
    /// </summary>
    public partial class BaseDetailLogBookItem : PictureBox
    {

        #region Fields

        private const int DATE_CELL_WIDTH = 150;
        private const int CELL_WIDTH = 100;
        private const int CELL_HEIGHT = 25;
        private readonly List<TextBox> textBoxItems = new List<TextBox>();
        private readonly MaskedTextBox textBoxHRS;
        private readonly TextBox textBoxCYC;
        private readonly LifelengthIncrement lifelengthIncrement;
        private readonly BaseDetail currentDetail;
        private string oldHRS = "";
        private string oldCYC = "";
        private bool readOnly = true;

        #endregion

        #region Constructors

        #region public BaseDetailLogBookItem()

        /// <summary>
        /// Создает заголовок для отображения нароботок
        /// </summary>
        public BaseDetailLogBookItem()
        {
            for (int i = 0; i < 7; i++)
            {
                textBoxItems.Add(new TextBox());
                if (i == 0)
                {
                    textBoxItems[i].Width = DATE_CELL_WIDTH;
                    textBoxItems[i].Location = new Point(0, 0);
                }
                else
                {
                    textBoxItems[i].Width = CELL_WIDTH;
                    textBoxItems[i].Location = new Point(textBoxItems[i-1].Right - 1, 0);
                }
            }
            SetCustomParameters(true);
            textBoxItems[0].Text = "Date";
            textBoxItems[1].Text = "HRS";
            textBoxItems[2].Text = "CYC";
            textBoxItems[3].Text = "TSN";
            textBoxItems[4].Text = "CSN";
            textBoxItems[5].Text = "TSOH";
            textBoxItems[6].Text = "CSOH";
        }

        #endregion

        #region public BaseDetailLogBookItem(LifelengthIncrement lifelengthIncrement)

        /// <summary>
        /// Создает элемент управления для отображения нароботки агрегата
        /// </summary>
        /// <param name="lifelengthIncrement">Добавочная наработка</param>
        /// <param name="currentDetail">Текущий базовай агрегат</param>
        public BaseDetailLogBookItem(LifelengthIncrement lifelengthIncrement, BaseDetail currentDetail)
        {
            this.lifelengthIncrement = lifelengthIncrement;
            this.currentDetail = currentDetail;
            //
            // textBoxHRS
            //
            textBoxHRS = new MaskedTextBox("00:00");
            textBoxHRS.BackColor = Color.White;
            textBoxHRS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //textBoxHRS.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxHRS.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxHRS.Location = new Point(DATE_CELL_WIDTH - 1, 0);
            textBoxHRS.ReadOnly = readOnly;
            textBoxHRS.TabIndex = 1;
            textBoxHRS.TextAlign = HorizontalAlignment.Center;
            textBoxHRS.Width = CELL_WIDTH;
            textBoxHRS.PreviewKeyDown += textBoxHRS_PreviewKeyDown;
            textBoxHRS.KeyPress += textBoxHRS_KeyPress;
            textBoxHRS.Leave += textBoxHRS_Leave;
            textBoxHRS.GotFocus += textBoxHRS_GotFocus;
            Controls.Add(textBoxHRS);
            //
            // textBoxCYC
            //
            textBoxCYC = new TextBox();
            textBoxCYC.BackColor = Color.White;
            textBoxCYC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //textBoxCYC.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxCYC.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxCYC.Location = new Point(textBoxHRS.Right - 1, 0);
            textBoxCYC.ReadOnly = readOnly;
            textBoxCYC.TabIndex = 2;
            textBoxCYC.TextAlign = HorizontalAlignment.Center;
            textBoxCYC.Width = CELL_WIDTH;
            textBoxCYC.PreviewKeyDown += textBoxCYC_PreviewKeyDown;
            textBoxCYC.KeyPress += textBoxCYC_KeyPress;
            textBoxCYC.Leave += textBoxCYC_Leave;
            textBoxCYC.GotFocus += textBoxCYC_GotFocus;
            Controls.Add(textBoxCYC);
            for (int i = 0; i < 5; i++)
            {
                textBoxItems.Add(new TextBox());
                if (i == 0)
                {
                    
                    textBoxItems[i].Location = new Point(0, 0);
                    textBoxItems[i].TabIndex = 0;
                    textBoxItems[i].Width = DATE_CELL_WIDTH;
                }
                else
                {
                    if (i == 1)
                        textBoxItems[i].Location = new Point(textBoxCYC.Right - 1, 0);
                    else
                        textBoxItems[i].Location = new Point(textBoxItems[i-1].Right - 1, 0);
                    textBoxItems[i].TabIndex = i + 2;
                    textBoxItems[i].Width = CELL_WIDTH;
                }
            }
            SetCustomParameters(false);
            textBoxItems[0].Text = lifelengthIncrement.AdditionDate.ToString(new TermsProvider()["DateFormat"].ToString());

            UpdateInformation();

            oldHRS = textBoxHRS.Text;
            oldCYC = textBoxCYC.Text;
        }

        #endregion

        #endregion

        #region Properties

        #region public static Size DefaultItemSize

        /// <summary>
        /// Возвращает размеры элемента управления по умолчанию
        /// </summary>
        public static Size DefaultItemSize
        {
            get
            {
                return new Size(DATE_CELL_WIDTH + 6 * CELL_WIDTH, CELL_HEIGHT);
            }
        }

        #endregion

        #region public bool ReadOnly

        /// <summary>
        /// Возвращает или устанавливает значение readOnly которое определяет, можно ли редактировать наработки
        /// </summary>
        public bool ReadOnly
        {
            get
            {
                return readOnly;
            }
            set
            {
                readOnly = value;
                if (textBoxHRS!= null) textBoxHRS.ReadOnly = value;
                if (textBoxCYC != null) textBoxCYC.ReadOnly = value;
            }
        }

        #endregion

        #endregion
        
        #region Methods

        #region private void SetCustomParameters(bool boldFont)

        /// <summary>
        /// Задает первоначальные параметры textBox-ов
        /// </summary>
        /// <param name="boldFont">Установить жирный шрифт?</param>
        private void SetCustomParameters(bool boldFont)
        {
            InitializeComponent();
            Size = DefaultItemSize;
            for (int i = 0; i < textBoxItems.Count; i++)
            {
                textBoxItems[i].BackColor = Color.White;
                textBoxItems[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                //textBoxItems[i].ForeColor = Css.OrdinaryText.Colors.ForeColor;
                if (boldFont)
                    textBoxItems[i].Font = Css.OrdinaryText.Fonts.BoldFont;
                else
                    textBoxItems[i].Font = Css.OrdinaryText.Fonts.RegularFont;
                textBoxItems[i].ReadOnly = true;
                textBoxItems[i].TextAlign = HorizontalAlignment.Center;
                textBoxItems[i].PreviewKeyDown += BaseDetailLogBookItem_PreviewKeyDown;
                textBoxItems[i].GotFocus += BaseDetailLogBookItem_GotFocus;
                Controls.Add(textBoxItems[i]);
            }
        }

        #endregion

        #region private bool HandleTextBoxHRS()

        private bool HandleTextBoxHRS()
        {
            if (!lifelengthIncrement.HasPermission(Users.CurrentUser, DataEvent.Update))
                return false;
            int hours;
            int minutes = 0;
            string[] hoursAndMinutes = textBoxHRS.Text.Split(new string[] { ":" }, StringSplitOptions.None);
            string resultHours = textBoxHRS.Text.Split(new string[] { ":" }, StringSplitOptions.None)[0];
            int.TryParse(resultHours, out hours);
            if (hours > 23)
            {
                MessageBox.Show("This is not valid value. Value of hours must be between 0 and 23.", (string)new TermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxHRS.Focus();
                textBoxHRS.SelectionStart = 0;
                textBoxHRS.SelectionLength = 2;
                return false;
            }
            if (hoursAndMinutes.Length > 1)
            {
                string resultMinutes = textBoxHRS.Text.Split(new string[] { ":" }, StringSplitOptions.None)[1];
                int.TryParse(resultMinutes, out minutes);
            }
            if (minutes > 59)
            {
                MessageBox.Show("This is not valid value. Value of minutes must be between 0 and 59.", (string)new TermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxHRS.Focus();
                textBoxHRS.SelectionStart = 2;
                textBoxHRS.SelectionLength = textBoxHRS.Text.Length;
                return false;
            }


            TimeSpan timeSpan = new TimeSpan(hours,minutes,0);
            lifelengthIncrement.Lifelength.Hours = timeSpan;
            if (lifelengthIncrement.ExistAtDataBase)
                lifelengthIncrement.Save();
            else if (lifelengthIncrement.Lifelength != Lifelength.NullLifelength)
                currentDetail.AddLifelengthIncrement(lifelengthIncrement);
            oldHRS = textBoxHRS.Text;
            if (ValueChanged != null)
                ValueChanged(this,new EventArgs());

            return true;
        }

        #endregion

        #region private bool HandleTextBoxCYC()

        private bool HandleTextBoxCYC()
        {
            if (!lifelengthIncrement.HasPermission(Users.CurrentUser, DataEvent.Update))
                return false;
            int cycles;
            if (int.TryParse(textBoxCYC.Text, out cycles))
            {
                lifelengthIncrement.Lifelength.Cycles = cycles;
                if (lifelengthIncrement.ExistAtDataBase)
                    lifelengthIncrement.Save();
                else if (lifelengthIncrement.Lifelength != Lifelength.NullLifelength)
                    currentDetail.AddLifelengthIncrement(lifelengthIncrement);
                oldCYC = textBoxCYC.Text;
                if (ValueChanged != null)
                    ValueChanged(this, new EventArgs());
                return true;
            }
            else
            {
                MessageBox.Show("This is not valid value. Value of cycles must contain only digits.", (string)new TermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxCYC.Focus();
                textBoxCYC.SelectAll();
                return false;
            }
        }

        #endregion
        
        #region private void textBoxHRS_Leave(object sender, EventArgs e)

        private void textBoxHRS_Leave(object sender, EventArgs e)
        {
            HandleTextBoxHRS();
            currentDetail.GetLifelengthIncrements();
        }

        #endregion

        #region private void textBoxCYC_Leave(object sender, EventArgs e)

        private void textBoxCYC_Leave(object sender, EventArgs e)
        {
            HandleTextBoxCYC();
        }

        #endregion

        #region private void textBoxHRS_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)

        private void textBoxHRS_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyValue == '\r' || e.KeyValue == '\n')
            {
                e.IsInputKey = true;
                textBoxHRS_KeyPress(sender, new KeyPressEventArgs('\r'));
            }
            else if (e.KeyValue == 33 || e.KeyValue == 38)
            {
                e.IsInputKey = true;
                textBoxHRS_KeyPress(sender, new KeyPressEventArgs((char)33));
            }
            else if (e.KeyValue == 34 || e.KeyValue == 40)
            {
                e.IsInputKey = true;
                textBoxHRS_KeyPress(sender, new KeyPressEventArgs((char)34));
            }
        }

        #endregion

        #region private void textBoxCYC_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)

        private void textBoxCYC_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
                textBoxCYC.Paste();
            if (e.Control && e.KeyCode == Keys.C)
                textBoxCYC.Copy();
            if (e.Control && e.KeyCode == Keys.X)
                textBoxCYC.Cut();
            if (e.KeyValue == '\r' || e.KeyValue == '\n')
            {
                e.IsInputKey = true;
                textBoxCYC_KeyPress(sender, new KeyPressEventArgs('\r'));
            }
            else if (e.KeyValue == 33 || e.KeyValue == 38)
            {
                e.IsInputKey = true;
                textBoxCYC_KeyPress(sender, new KeyPressEventArgs((char)33));
            }
            else if (e.KeyValue == 34 || e.KeyValue == 40)
            {
                e.IsInputKey = true;
                textBoxCYC_KeyPress(sender, new KeyPressEventArgs((char)34));
            }
        }

        #endregion

        #region private void BaseDetailLogBookItem_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)

        private void BaseDetailLogBookItem_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            int id;
            if (e.KeyValue == 33 || e.KeyValue == 38)
            {
                e.IsInputKey = true;
                id = textBoxItems.IndexOf(sender as TextBox);
                if (id > 0) id = id + 2;
                Tag = id;
                if (PageUpPressed != null)
                    PageUpPressed(this, new EventArgs());
            }
            else if (e.KeyValue == 34 || e.KeyValue == 40)
            {
                e.IsInputKey = true;
                id = textBoxItems.IndexOf(sender as TextBox);
                if (id > 0) id = id + 2;
                Tag = id;
                if (PageDownPressed != null)
                    PageDownPressed(this, new EventArgs());
            }
        }

        #endregion

        #region private void textBoxHRS_KeyPress(object sender, KeyPressEventArgs e)

        private void textBoxHRS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                textBoxCYC.Focus();
                textBoxCYC.SelectionStart = 0;
                textBoxCYC.SelectionLength = textBoxCYC.Text.Length;
                return;
            }
            if (((e.KeyChar == '\t') || (e.KeyChar == '\r')) && (HandleTextBoxHRS() == false))
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == 27)
            {
                textBoxHRS.Text = oldHRS;
                textBoxHRS.SelectionStart = 0;
                textBoxHRS.SelectionLength = textBoxHRS.Text.Length;
                return;
            }
            if ((e.KeyChar == 33) && (PageUpPressed != null))
            {
                Tag = 1;
                PageUpPressed(this, new EventArgs());
                return;
            }
            if ((e.KeyChar == 34) && (PageDownPressed != null))
            {
                Tag = 1;
                PageDownPressed(this, new EventArgs());
                return;
            }
        }

        #endregion

        #region private void textBoxCYC_KeyPress(object sender, KeyPressEventArgs e)

        private void textBoxCYC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < '0') || (e.KeyChar > '9')) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (e.KeyChar == '\r')
            {
                textBoxItems[1].Focus();
                textBoxItems[1].SelectionStart = 0;
                textBoxItems[1].SelectionLength = textBoxItems[1].Text.Length;
                return;
            }
            if (((e.KeyChar == '\t') || (e.KeyChar == '\r')) && (HandleTextBoxCYC() == false))
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == 27)
            {
                textBoxCYC.Text = oldCYC;
                textBoxCYC.SelectionStart = 0;
                textBoxCYC.SelectionLength = textBoxCYC.Text.Length;
                return;
            }
            if (e.KeyChar == 33 && PageUpPressed != null)
            {
                Tag = 2;
                PageUpPressed(this, new EventArgs());
                return;
            }
            if (e.KeyChar == 34 && PageDownPressed != null)
            {
                Tag = 2;
                PageDownPressed(this, new EventArgs());
                return;
            }
        }

        #endregion
        
        #region private void textBoxHRS_GotFocus(object sender, EventArgs e)

        private void textBoxHRS_GotFocus(object sender, EventArgs e)
        {
            textBoxHRS.SelectionStart = 0;
            textBoxHRS.SelectionLength = textBoxHRS.Text.Length;
            if (TextBoxFocused != null)
                TextBoxFocused(sender, new EventArgs());
        }

        #endregion

        #region private void textBoxCYC_GotFocus(object sender, EventArgs e)

        private void textBoxCYC_GotFocus(object sender, EventArgs e)
        {
            textBoxCYC.SelectionStart = 0;
            textBoxCYC.SelectionLength = textBoxCYC.Text.Length;
            if (TextBoxFocused != null)
                TextBoxFocused(sender, new EventArgs());
        }

        #endregion

        #region private void BaseDetailLogBookItem_GotFocus(object sender, EventArgs e)

        private void BaseDetailLogBookItem_GotFocus(object sender, EventArgs e)
        {
            if (TextBoxFocused != null)
                TextBoxFocused(sender, new EventArgs());
        }

        #endregion

        #region public void ActivateTextBox(int id)

        /// <summary>
        /// Активирует заданный TextBox
        /// </summary>
        /// <param name="id">Номер TextBox-са</param>
        public void ActivateTextBox(int id)
        {
            if (id == 0)
                textBoxItems[0].Focus();
            else if (id == 1)
                textBoxHRS.Focus();
            else if (id == 2)
                textBoxCYC.Focus();
            else
                textBoxItems[id - 2].Focus();
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Обновляет информацию в колонках TSN, CSN, TSOH, CSOH
        /// </summary>
        public void UpdateInformation()
        {
            textBoxHRS.Text = lifelengthIncrement.Lifelength.ToString(true);
            textBoxCYC.Text = lifelengthIncrement.Lifelength.Cycles.ToString();
            textBoxItems[1].Text = currentDetail.Limitation.GetSNResource(lifelengthIncrement.AdditionDate).ToString(true);
            textBoxItems[2].Text = currentDetail.Limitation.GetSNResource(lifelengthIncrement.AdditionDate).ToCyclesString();
            textBoxItems[3].Text = currentDetail.Limitation.GetSOHResource(lifelengthIncrement.AdditionDate).ToString(true);
            textBoxItems[4].Text = currentDetail.Limitation.GetSOHResource(lifelengthIncrement.AdditionDate).ToCyclesString();
        }
        #endregion
        
        #endregion

        #region Events

        #region public event EventHandler PageUpPressed;

        /// <summary>
        /// Событие нажатия клавиши PageUp
        /// </summary>
        public event EventHandler PageUpPressed;

        #endregion
        
        #region public event EventHandler PageDownPressed;

        /// <summary>
        /// Событие нажатия клавиши PageDown
        /// </summary>
        public event EventHandler PageDownPressed;

        #endregion
        
        #region public event EventHandler TextBoxFocused;

        /// <summary>
        /// Событие принятия фокуса для TextBox-са
        /// </summary>
        public event EventHandler TextBoxFocused;

        #endregion

        #region public event EventHandler ValueChanged;

        /// <summary>
        /// Событие изменения значения
        /// </summary>
        public event EventHandler ValueChanged;

        #endregion
        
        #endregion

    }
*/
}