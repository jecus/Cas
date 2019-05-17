using System.ComponentModel;
using MetroFramework.Forms;

namespace CAS.UI.UIControls.AnimatedBackgroundWorker
{
    ///<summary>
    /// Форма, отображает ожидание заверщениея асинхронной операции
    ///</summary>
    public partial class WaitCancelForm : MetroForm
    {
        #region Fields

        private BackgroundWorker _backGroundWorker;

        #endregion

        #region Constructors
        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        private WaitCancelForm()
        {
            InitializeComponent();
        }

        ///<summary>
        /// Создает форму и инициализирует параметр _backGroundWorker
        ///</summary>
        ///<param name="worker"></param>
        public WaitCancelForm(BackgroundWorker worker) :this()
        {
            _backGroundWorker = worker;
            _backGroundWorker.RunWorkerCompleted += BackGroundWorkerRunWorkerCompleted;
        }
        #endregion

        #region Methods
        void BackGroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
        }
        #endregion
    }
}
