using System.Drawing;
using System.Windows.Forms;

namespace CAS.UI.UIControls.Auxiliary
{
    ///<summary>
    ///</summary>
    internal partial class WaitingControl : PictureBox
    {
        private int currentImage = 0;

        ///<summary>
        ///</summary>
        public WaitingControl()
        {
            InitializeComponent();
            SizeMode = PictureBoxSizeMode.Zoom;
        }

        /// <summary>
        /// Показывает задержку между сменой изображений
        /// </summary>
        public int Delay
        {
            get
            {
                return timer.Interval;
            }
            set
            {
                timer.Interval = value;
            }
        }

        /// <summary>
        /// Перезапустить отображение
        /// </summary>
        public void Start()
        {
            currentImage = 0;
            timer.Start();
        }

        /// <summary>
        /// Приостановить
        /// </summary>
        public void Pause()
        {
            timer.Stop();
        }

        /// <summary>
        /// Продолжить
        /// </summary>
        public void Continue()
        {
            timer.Start();
        }

        /// <summary>
        /// Остановить
        /// </summary>
        public void Stop()
        {
            timer.Stop();
            Image = null;
        }

        private void timer_Tick(object sender, System.EventArgs e)
        {
            Image = NextImage;
        }

        private Image NextImage
        {
            get
            {
                currentImage = (currentImage + 1)%imageList.Images.Count;
                return imageList.Images[currentImage];
            }
        }
    }
}