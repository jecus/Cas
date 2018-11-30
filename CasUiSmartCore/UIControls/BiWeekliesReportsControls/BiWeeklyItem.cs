using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Types.Dictionaries;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using Microsoft.VisualBasic.Devices;

namespace CAS.UI.UIControls.BiWeekliesReportsControls
{
    /// <summary>
    /// Элемент управления для отображения элемента коллекции BiWeekly отчетов
    /// </summary>
    public class BiWeeklyItem : Control, IReference
    {

        #region Fields

        private BiWeekly report;
        private readonly PictureBox pictureBoxIcon = new PictureBox();
        private readonly Label labelCaption = new Label();
        private readonly Size defaultSize = new Size(110, 140);
        private const int LABEL_HEIGHT = 30;
        private int oldWidth = 0;
        private int oldHeight = 0;
        private IDisplayer displayer;
        private string displayerText;
        private IDisplayingEntity entity;
        private ReflectionTypes reflectionType;
        private Cursor cursor = Cursors.Hand;

        #endregion

        #region Constructors

        #region public BiWeeklyItem(Image icon, string  caption, Cursor cursor) : this(icon, caption, cursor, null)

        /// <summary>
        /// Создаёт новый экземпляр класса BiWeeklyItem
        /// </summary>
        public BiWeeklyItem(Image icon, string  caption, Cursor cursor) : this(icon, caption, cursor, null)
        {
        }

        #endregion

        #region public BiWeeklyItem(Image icon, string  caption, Cursor cursor, BiWeekly report)

        /// <summary>
        /// Создаёт новый экземпляр класса BiWeeklyItem
        /// </summary>
        public BiWeeklyItem(Image icon, string  caption, Cursor cursor, BiWeekly report)
        {
            this.report = report;
            InitializeComponents(icon, caption, cursor);
        }

        #endregion

        #endregion

        #region Properties

        #region public Image Icon

        /// <summary>
        /// Возвращает или устанавливает иконку элемента правления
        /// </summary>
        public Image Icon
        {
            get
            {
                return pictureBoxIcon.BackgroundImage;
            }
            set
            {
                pictureBoxIcon.BackgroundImage = value;
            }
        }

        #endregion

        #region public string Caption

        /// <summary>
        /// Возвращает или устанавливает нижнюю подпись элемента управления
        /// </summary>
        public string Caption
        {
            get
            {
                return labelCaption.Text;
            }
            set
            {
                labelCaption.Text = value;
            }
        }

        #endregion

        #region public BiWeekly Report

        /// <summary>
        /// Возвращает или устанавливает текущий отчет BiWeekly
        /// </summary>
        public BiWeekly Report
        {
            get { return report; }
            set { report = value; }
        }

        #endregion

        #region public Cursor Cursor

        /// <summary>
        /// Возвращает или устанавливает текущий курсор
        /// </summary>
        public Cursor Cursor
        {
            get
            {
                return cursor;
            }
            set
            {
                cursor = value;
                pictureBoxIcon.Cursor = cursor;
                labelCaption.Cursor = cursor;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region private void InitializeComponents(Image icon, string  caption, Cursor cursor)

        private void InitializeComponents(Image icon, string  caption, Cursor cursor)
        {
            //
            // pictureBoxIcon
            //
            pictureBoxIcon.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxIcon.Cursor = cursor;
            pictureBoxIcon.Height = Height - LABEL_HEIGHT;
            pictureBoxIcon.BackgroundImage = icon;
            pictureBoxIcon.BackgroundImageLayout = ImageLayout.Center;
            pictureBoxIcon.Click += Control_Click;
            //
            // labelCaption
            //
            labelCaption.Cursor = cursor;
            labelCaption.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelCaption.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelCaption.Location = new Point(0, pictureBoxIcon.Height);
            labelCaption.Size = new Size(defaultSize.Height, LABEL_HEIGHT);
            labelCaption.Text = caption;
            labelCaption.TextAlign = ContentAlignment.MiddleCenter;
            labelCaption.Click += Control_Click;

            Size = defaultSize;
            Controls.Add(pictureBoxIcon);
            Controls.Add(labelCaption);   
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
            if (Width != oldWidth)
            {
                pictureBoxIcon.Width = Width;
                labelCaption.Width = Width;
                oldWidth = Width;
            }
            if (Height != oldHeight)
            {
                pictureBoxIcon.Height = Height - LABEL_HEIGHT;
                labelCaption.Top = pictureBoxIcon.Height;
                oldHeight = Height;
            }
            base.OnSizeChanged(e);
        }

        #endregion

        #region protected void OnDisplayerRequested()

        /// <summary>
        /// Метод обработки события DisplayerRequested
        /// </summary>
        protected void OnDisplayerRequested()
        {
            if (DisplayerRequested != null)
            {
                ReflectionTypes reflection = reflectionType;
                Keyboard keyboard = new Keyboard();
                if (keyboard.ShiftKeyDown && reflection == ReflectionTypes.DisplayInCurrent) 
                    reflection = ReflectionTypes.DisplayInNew;
                if (displayer != null)
                {
                    DisplayerRequested(this, new ReferenceEventArgs(entity, reflection, displayer, displayerText));
                }
                else
                {
                    DisplayerRequested(this, new ReferenceEventArgs(entity, reflection, displayerText));
                }
            }
        }

        #endregion

        #region private void Control_Click(object sender, EventArgs e)

        private void Control_Click(object sender, EventArgs e)
        {
            OnDisplayerRequested();
        }

        #endregion

        #region public void MarkCaption()

        /// <summary>
        /// Выделяет название жирным шрифтом
        /// </summary>
        public void MarkCaption()
        {
            labelCaption.Font = new Font(labelCaption.Font, FontStyle.Bold);
        }

        #endregion

        #endregion

        #region IReference Members

        public IDisplayer Displayer
        {
            get { return displayer; }
            set { displayer = value; }
        }

        public string DisplayerText
        {
            get { return displayerText; }
            set { displayerText = value; }
        }

        public IDisplayingEntity Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        public ReflectionTypes ReflectionType
        {
            get { return reflectionType; }
            set { reflectionType = value; }
        }

        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        #endregion
    }
}