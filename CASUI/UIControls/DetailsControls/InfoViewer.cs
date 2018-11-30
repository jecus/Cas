using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.Appearance;
using CAS.UI.UIControls.Auxiliary;

namespace CAS.UI.UIControls.DetailsControls
{
    /// <summary>
    /// Элемент управления, предназначеный для отображения отдельной информации об агрегате
    /// </summary>
    public partial class InfoViewer : FlowLayoutPanel
    {
        #region Fields

        private readonly Label labelTitle = new Label();
        private readonly List<LifelengthViewer> lifeLengthViewers = new List<LifelengthViewer>();
        private bool readOnly = false;
        private bool lastLifelengthViewerLostFocusByTabClicked = false;
        private bool firstLifelengthViewerLostFocusByShiftTabClicked = false;
        private bool showMinutes = true;
        private int leftHeaderWidth = 130;
        private const int MARGIN = 0;
        private const int LIFELENGTH_VIEWER_HEIGHT = 40;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения отдельной информации об агрегате
        /// </summary>
        /// <param name="lifelengthViewersCount"></param>
        public InfoViewer(int lifelengthViewersCount)
        {
            AutoSize = true;
            MaximumSize = new Size(520, 1000);
            FlowDirection = FlowDirection.TopDown;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //
            // labelTitle
            //
            labelTitle.Font = Css.SmallHeader.Fonts.BoldFont;
            labelTitle.ForeColor = Css.SmallHeader.Colors.ForeColor;
            labelTitle.Location = new Point(0, 0);
            labelTitle.Padding = new Padding(3);
            labelTitle.Height = LIFELENGTH_VIEWER_HEIGHT;
            labelTitle.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lifeLengthViewers
            //
            for (int i = 0; i < lifelengthViewersCount; i++)
            {
                lifeLengthViewers.Add(new LifelengthViewer());
                lifeLengthViewers[i].Location = new Point(0, labelTitle.Bottom + i * (lifeLengthViewers[i].Height + MARGIN));
                lifeLengthViewers[i].ShowHeaders = false;
                lifeLengthViewers[i].ReadOnly = true;
                lifeLengthViewers[i].BackColor = Color.Transparent;
                lifeLengthViewers[i].LeftHeader = (i+1).ToString();
                lifeLengthViewers[i].LeftHeaderWidth = leftHeaderWidth;
                lifeLengthViewers[i].Padding = new Padding(0, 0, 0, MARGIN);
                lifeLengthViewers[i].ComboBoxCalendarType.PreviewKeyDown += LifelengthViewerComboBoxCalendarType_PreviewKeyDown;
                lifeLengthViewers[i].TextBoxHours.PreviewKeyDown += LifelengthViewerTextBoxHours_PreviewKeyDown;
                lifeLengthViewers[i].LostFocus += InfoViewer_LostFocus;
            }
            Controls.Add(labelTitle);
            Controls.AddRange(lifeLengthViewers.ToArray());
        }

        #endregion
        
        #region Properties

        #region public int LeftHeaderWidth

        /// <summary>
        /// Ширина левого заголовка
        /// </summary>
        public int LeftHeaderWidth
        {
            get { return leftHeaderWidth; }
            set 
            {
                leftHeaderWidth = value;
                for (int i = 0; i < lifeLengthViewers.Count; i++)
                    lifeLengthViewers[i].LeftHeaderWidth = leftHeaderWidth;
                MaximumSize = new Size(lifeLengthViewers[0].Width, 1000);
                Width = lifeLengthViewers[0].Width;
            }
        }

        #endregion

        #region public List<LifelengthViewer> LifeLengthViewers

        /// <summary>
        /// Возвращает все LifelengthViewer-ы
        /// </summary>
        public List<LifelengthViewer> LifeLengthViewers
        {
            get { return lifeLengthViewers; }
        }

        #endregion

        #region public Button LabelTitle

        /// <summary>
        /// Возвращает label, для отображения заголовка
        /// </summary>
        public Label LabelTitle
        {
            get
            {
                return labelTitle;
            }
        }

        #endregion

        #region public bool ReadOnly

        /// <summary>
        /// Возвращает или устанавливает текущее состояние элемента управления
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
                for (int i = 0; i < lifeLengthViewers.Count; i++)
                    lifeLengthViewers[i].ReadOnly = value;
            }
        }

        #endregion

        #region public bool Modified

        /// <summary>
        /// Возвращает или устанавливает значение, показывающее были ли изменения в отображаемых наработках
        /// </summary>
        public bool Modified
        {
            get
            {
                bool modified = false;
                for (int i = 0; i < lifeLengthViewers.Count; i++)
                    if (lifeLengthViewers[i].Modified)
                        modified = true;
                return modified;
            }
        }

        #endregion

        #region public bool LastLifelengthViewerLostFocusByTabClicked

        /// <summary>
        /// Возвращает или устанавливает значение, показывающее передевать ли фокус следующему элементу управления, 
        /// при нажатии клавиши Tab на последнем элементе управления последнего LifelengthViewer-а
        /// </summary>
        public bool LastLifelengthViewerLostFocusByTabClicked
        {
            get
            {
                return lastLifelengthViewerLostFocusByTabClicked;
            }
            set
            {
                lastLifelengthViewerLostFocusByTabClicked = value;
            }
        }

        #endregion

        #region public bool FirstLifelengthViewerLostFocusByShiftTabClicked

        /// <summary>
        /// Возвращает или устанавливает значение, показывающее передевать ли фокус предыдущему элементу управления, 
        /// при нажатии клавиш Shift+Tab на первом элементе управления первого LifelengthViewer-а
        /// </summary>
        public bool FirstLifelengthViewerLostFocusByShiftTabClicked
        {
            get
            {
                return firstLifelengthViewerLostFocusByShiftTabClicked;
            }
            set
            {
                firstLifelengthViewerLostFocusByShiftTabClicked = value;
            }
        }

        #endregion

        #region public bool ShowMinutes

        /// <summary>
        /// Возвращает или устанавливает значение, показывающее нужно ли отображать минуты в полях Hours в LifelengthViewer-ах
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
                for (int i = 0; i < lifeLengthViewers.Count; i++)
                    lifeLengthViewers[i].ShowMinutes = showMinutes;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region public void SetLeftHeader(int i, String text)

        /// <summary>
        /// Задается заголовок элемента, на определенном месте
        /// </summary>
        /// <param name="i">Определяет номер изменяемого элемента</param>
        /// <param name="text">Новое значение заголовка</param>
        public void SetLeftHeader(int i, String text)
        {
            if (i >= 0 && i <= lifeLengthViewers.Count)
                lifeLengthViewers[i].LeftHeader = text;
        }

        #endregion

        #region public void SetVisibleItemsAmount(int amount)

        /// <summary>
        /// Задается количество отображаемых элементов
        /// </summary>
        /// <param name="amount">Количество отображаемых элементов</param>
        public void SetVisibleItemsAmount(int amount)
        {
            if (amount < 0) amount = 0;
            if (amount > lifeLengthViewers.Count) amount = lifeLengthViewers.Count;
            for (int i = 0; i < lifeLengthViewers.Count; i++)
            {
                LifelengthViewer viewer = lifeLengthViewers[i];
                viewer.Visible = i < amount;
            }
        }

        #endregion

        #region public void SetValue(int i, Lifelength lifelength)

        /// <summary>
        /// Задается отображаемое значение у элемента
        /// </summary>
        /// <param name="i">Номер элемента</param>
        /// <param name="lifelength">Задаваемое значение</param>
        public void SetValue(int i, Lifelength lifelength)
        {
            if (i >= 0 && i <= lifeLengthViewers.Count)
                lifeLengthViewers[i].Lifelength = lifelength;
        }

        #endregion

        #region public Lifelength GetValue(int i)

        /// <summary>
        /// Возвращается отображаемое значение у элемента
        /// </summary>
        /// <param name="i">Номер элемента</param>
        public Lifelength GetValue(int i)
        {
            if (i >= 0 && i <= lifeLengthViewers.Count)
                return lifeLengthViewers[i].Lifelength;
            return null;
        }

        #endregion

        #region public void SaveData(int i, Lifelength lifelength)

        /// <summary>
        /// Сохраняет наработки
        /// </summary>
        /// <param name="i"></param>
        /// <param name="lifelength"></param>
        public void SaveData(int i, Lifelength lifelength)
        {
            if (i >= 0 && i <= lifeLengthViewers.Count)
                lifeLengthViewers[i].SaveData(lifelength);
        }

        #endregion

        #region public void FocusFirstElement(int position)

        /// <summary>
        /// Фокусирует первый текст-бокс
        /// </summary>
        /// <param name="position"></param>
        public void FocusFirstElement(int position)
        {
            lifeLengthViewers[position].TextBoxHours.Focus();
        }

        #endregion

        #region public void FocusLastElement(int position)

        /// <summary>
        /// Фокусирует последнйи комбо-бокс
        /// </summary>
        /// <param name="position"></param>
        public void FocusLastElement(int position)
        {
            lifeLengthViewers[position].ComboBoxCalendarType.Focus();
        }

        #endregion

        #region private void LifelengthViewerComboBoxCalendarType_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)

        private void LifelengthViewerComboBoxCalendarType_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            int position = lifeLengthViewers.IndexOf((LifelengthViewer)(((ComboBox)sender).Parent.Parent));
            if (!e.Shift && e.KeyCode == Keys.Tab && LastLifelengthViewerTabClicked != null)
            {
                if ((lifeLengthViewers[lifeLengthViewers.Count - 1].Visible && position < lifeLengthViewers.Count - 1) ||
                    (!lifeLengthViewers[lifeLengthViewers.Count - 1].Visible && position < lifeLengthViewers.Count - 2) ||
                    !LastLifelengthViewerLostFocusByTabClicked)
                {
                    e.IsInputKey = true;
                    LastLifelengthViewerTabClicked(position);
                }
            }
        }

        #endregion

        #region private void LifelengthViewerTextBoxHours_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)

        private void LifelengthViewerTextBoxHours_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            int position = lifeLengthViewers.IndexOf((LifelengthViewer)(((TextBox)sender).Parent.Parent));
            if (e.Shift && e.KeyCode == Keys.Tab && FirstLifelengthViewerShiftTabClicked != null)
            {
                if (position > 0 || !FirstLifelengthViewerLostFocusByShiftTabClicked)
                {
                    e.IsInputKey = true;
                    FirstLifelengthViewerShiftTabClicked(position);
                }
            }
        }

        #endregion

        #region private void InfoViewer_LostFocus(object sender, EventArgs e)

        private void InfoViewer_LostFocus(object sender, EventArgs e)
        {
            int position = lifeLengthViewers.IndexOf((LifelengthViewer)sender);
            if (LifelengthViewerLostFocus != null)
                LifelengthViewerLostFocus(position);
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
            labelTitle.Width = Width;
        }

        #endregion

        #endregion

        #region Delegates

        public delegate void LifelengthViewerLostFocusEventHandler(int position);

        #endregion

        #region Events

        public event LifelengthViewerLostFocusEventHandler LastLifelengthViewerTabClicked;
        public event LifelengthViewerLostFocusEventHandler FirstLifelengthViewerShiftTabClicked;
        public event LifelengthViewerLostFocusEventHandler LifelengthViewerLostFocus;


        #endregion


    }

}