using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.Management;

namespace CAS.UI.UIControls.AnimatedBackgroundWorker
{
    /// <summary>
    /// Форма для отбражения процесса загрузки
    /// </summary>
    public partial class WaitForm : Form
    {
        #region Fields

        private int _imageCount;
        private int _progressValue;
        private List<Image> imageList = new List<Image>();

        #endregion

        #region Constructors

        #region public WaitForm()
        /// <summary>
        /// Создается экземпляр формы
        /// </summary>
        public WaitForm()
        {
            InitializeComponent();
            timerLocationChange.Interval = 15;
            timerLocationChange.Enabled = true;
            timerLocationChange.Tick += timerLocationChange_Tick;
            timerLocationChange.Start();
            timerPictureChange.Interval = 150;
            timerPictureChange.Enabled = true;
            timerPictureChange.Tick += timerPictureChange_Tick;
            timerPictureChange.Start();
            imageList.AddRange(Icons.WaitAnimations);
        }

        #endregion

        #endregion

        #region Properties

        #region public int AnimationDelay
        /// <summary>
        /// Задержка смены кадров
        /// </summary>
        public int AnimationDelay
        {
            get { return timerPictureChange.Interval; }
            set
            {
                SetAnimationDelay(value);
            }
        }

        #endregion

        #region public int ProgressValue
        /// <summary>
        /// Прогресс операции в процентах
        /// </summary>
        public int ProgressValue
        {
            get { return _progressValue; }
            set
            {
                _progressValue = value;
                SetLabelProgress(value + "%");
            }
        }

        #endregion

        #region public string State
        /// <summary>
        /// Сотстояние выполняюшеся операции
        /// </summary>
        public string State
        {
            get { return labelState.Text; }
            set
            {
                SetLabelStatus(value);
            }
        }

        #endregion

        #region public bool ShowProgress
        /// <summary>
        /// Показывать ли прогресс в процентах
        /// </summary>
        public bool ShowProgress
        {
            get { return labelProgress.Visible; }
            set
            {
                SetShowProgress(value);
            }
        }


        #endregion

        #endregion

        #region Methods

        #region public void StartAnimation()
        /// <summary>
        /// Запуск анимации
        /// </summary>
        public void StartAnimation()
        {
            if (InvokeRequired)
                Invoke(new StartAnimationDelegate(StartAnimation));
            else
            {
                timerPictureChange.Enabled = true;
                timerPictureChange.Start();
            }
        }

        #endregion

        #region public void StopAnimation()
        /// <summary>
        /// Остановит анимацию
        /// </summary>
        public void StopAnimation()
        {
            if (InvokeRequired)
                StopAnimation();
            else
            {
                timerPictureChange.Stop();
            }
        }

        #endregion

        #region public void CloseForm()
        /// <summary>
        /// Закрытие формы из другого потока
        /// </summary>
        public void CloseForm()
        {
            if (InvokeRequired)
                CloseForm();
            else
                Close();

        }

        #endregion

        #region public void HideForm()
        /// <summary>
        /// Спрятать форму из другог потока
        /// </summary>
        public void HideForm()
        {
            if (InvokeRequired)
                HideForm();
            else
                Hide();
        }

        #endregion

        #region public void ShowForm()
        /// <summary>
        /// Показать форму из другого потока
        /// </summary>
        public void ShowForm()
        {
            if (InvokeRequired)
               ShowForm();
            else
                Show();
        }

        #endregion

        #region void timerPictureChange_Tick(object sender, EventArgs e)

        void timerPictureChange_Tick(object sender, EventArgs e)
        {

            if (_imageCount >= imageList.Count) _imageCount = 0;
            pictureBox1.Image = imageList[_imageCount];
            _imageCount++;

        }

        #endregion

        #region void timerPictureChange_Tick(object sender, EventArgs e)

        void timerLocationChange_Tick(object sender, EventArgs e)
        {
            Location = new Point(MousePosition.X + 20, MousePosition.Y + 20);

        }

        #endregion

        #region private void Form1_Load(object sender, EventArgs e)

        private void Form1_Load(object sender, EventArgs e)
        {
            TransparencyKey = BackColor;
            Focus();
        }

        #endregion

        #region private void SetLabelProgress(string text)

        private void SetLabelProgress(string text)
        {
            if (labelProgress.InvokeRequired)
                labelProgress.Invoke(new SetLabelProgressDelegate(SetLabelProgress), text);
            else
                labelProgress.Text = text;
        }

        #endregion

        #region private void SetLabelStatus(string text)

        private void SetLabelStatus(string text)
        {
            if (labelState.InvokeRequired)
                labelState.Invoke(new SetLabelStatusDelegate(SetLabelStatus), text);
            else
                labelState.Text = text;
        }

        #endregion

        #region private void SetAnimationDelay(int interval)

        private void SetAnimationDelay(int interval)
        {
            if (InvokeRequired)
                Invoke(new SetAnimationDelayDelegate(SetAnimationDelay), interval);
            else
                timerPictureChange.Interval = interval;
        }

        #endregion

        #region private void SetShowProgress(bool isShow)

        private void SetShowProgress(bool isShow)
        {
            if (labelProgress.InvokeRequired)
                labelProgress.Invoke(new SetShowProgressDelegate(SetShowProgress), isShow);
            else
                labelProgress.Visible = isShow;
        }

        #endregion

        #endregion

        #region Delegates

        private delegate void SetLabelProgressDelegate(string text);

        private delegate void SetLabelStatusDelegate(string text);

        private delegate void SetAnimationDelayDelegate(int interval);

        private delegate void CloseFormDelegate();

        private delegate void HideFormDelegate();

        private delegate void ShowFormDelegate();

        private delegate void SetShowProgressDelegate(bool isShow);

        private delegate void StartAnimationDelegate();

        private delegate void StopAnimationDelegate();

        #endregion
    }
}