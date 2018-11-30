using System;
using System.Threading;
using System.Windows.Forms;

namespace CAS.UI.UIControls.AnimatedBackgroundWorker
{
    /// <summary>
    /// Класс для запуска метода в другом потоке
    /// </summary>
    public class AnimatedThreadWorker
    {
        #region Fields

        private readonly Thread thread;
        private static WaitForm waitForm;
        private readonly BackgroundMethod method;
        private readonly ParametrizedBackgroundMethod parametrizedMethod;
        private readonly Object parametr;
        private Control control;
        private Object result;
        private Delegate userMethod;
        private Object[] arguments;

        #endregion

        #region Constructors

        #region private AnimatedThreadWorker()

        private AnimatedThreadWorker()
        {
            waitForm = StaticWaitFormProvider.WaitForm;
        }

        #endregion

        #region public AnimatedThreadWorker(BackgroundMethod method, Control control) : this()
        /// <summary>
        /// Создается новый экземпляр класса
        /// </summary>
        /// <param name="method">Метод загружаемый в другой поток</param>
        /// <param name="control">Элемент управления для котрого создается класс</param>
        public AnimatedThreadWorker(BackgroundMethod method, Control control) : this()
        {
            userMethod = method;
            arguments = new Object[0];
            this.control = control;

            control.Disposed += control_Disposed;
            thread = new Thread(InternalMethod);
        }
        #endregion

        #region public AnimatedThreadWorker(BackgroundMethod method, Control control) : this()
        /// <summary>
        /// Создается новый экземпляр класса
        /// </summary>
        /// <param name="method">Метод загружаемый в другой поток</param>
        /// <param name="obj">Параметр загружаемого метода</param>
        /// <param name="control">Элемент управления для котрого создается класс</param>
        public AnimatedThreadWorker(ParametrizedBackgroundMethod method, Object obj, Control control) : this()
        {
            userMethod = method;
            arguments = new Object[] { obj };
            this.control = control;

            control.Disposed += control_Disposed;
            thread = new Thread(InternalMethod);
            
        }
        #endregion

        #region public AnimatedThreadWorker(BackgroundMethod method, Control control) : this()
        /// <summary>
        /// Создается новый экземпляр класса
        /// </summary>
        /// <param name="method">Метод загружаемый в другой поток</param>
        /// <param name="obj">Параметр загружаемого метода</param>
        /// <param name="control">Элемент управления для котрого создается класс</param>
        public AnimatedThreadWorker(ParametrizedBackgroundMethodWithResult method, Object obj, Control control):this()
        {
            userMethod = method;
            arguments = new Object[] { obj, result };
            this.control = control;

            control.Disposed += control_Disposed;
            thread = new Thread(InternalMethod);
            
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
            get { return waitForm.AnimationDelay; }
            set
            {
                waitForm.AnimationDelay = value;
            }
        }

        #endregion

        #region public int ProgressValue
        /// <summary>
        /// Прогресс операции в процентах
        /// </summary>
        public int ProgressValue
        {
            get { return waitForm.ProgressValue; }
            set
            {
                waitForm.ProgressValue = value;
            }
        }

        #endregion

        #region public string State
        /// <summary>
        /// Сотстояние выполняюшеся операции
        /// </summary>
        public string State
        {
            get { return waitForm.State; }
            set
            {
                waitForm.State = value;
            }
        }

        #endregion

        #region public bool ShowProgress
        /// <summary>
        /// Показывать ли прогресс в процентах
        /// </summary>
        public bool ShowProgress
        {
            get { return waitForm.ShowProgress; }
            set
            {
                waitForm.ShowProgress = value;
            }
        }


        #endregion

        #region public object Result
        /// <summary>
        /// Результат выполнения операции.
        /// </summary>
        public object Result
        {
            get { return result; }
        }
        #endregion

        #endregion

        #region Methods

        #region private static void InitializeWaitForm()

        private void InitializeWaitForm()
        {
                waitForm = new WaitForm();
                waitForm.TopLevel = true;
                waitForm.TopMost = true;
                waitForm.ShowInTaskbar = false;
        }

        #endregion

        #region public void StartAnimation()
        /// <summary>
        /// Запуск анимации
        /// </summary>
        public void StartAnimation()
        {
            waitForm.StartAnimation();
        }

        #endregion
        
        #region public void StopAnimation()
        /// <summary>
        /// Остановит анимацию
        /// </summary>
        public void StopAnimation()
        {
            waitForm.StopAnimation();
        }

        #endregion
        
        #region public void StartThread()
        /// <summary>
        /// Запускает поток с заданым методом
        /// </summary>
        public void StartThread()
        {
            waitForm.Visible = true;
            waitForm.Show();
            StaticWaitFormProvider.IsActive = true;
            thread.Start();
        }

        #endregion

        #region public void StopThread()
        /// <summary>
        /// Остановит поток
        /// </summary>
        public void StopThread()
        {
            thread.Abort();
            waitForm.Hide();
            StaticWaitFormProvider.IsActive = false;

        }

        #endregion
        
        #region void control_Disposed(object sender, EventArgs e)

        void control_Disposed(object sender, EventArgs e)
        {
            StopThread();
        }

        #endregion

        #region private void InternalMethod()

        private void InternalMethod()
        {
            userMethod.DynamicInvoke(arguments);
            if (arguments.Length == 2)
                result = arguments[1];

            waitForm.HideForm();
            OnWorkFinished();
        }

        #endregion
        
        #region private void OnWorkFinished()
        private void OnWorkFinished()
        {
            if (control.InvokeRequired)
                control.Invoke(new BackgroundMethod(OnWorkFinished));
            else
            {
                if (WorkFinished != null)
                    WorkFinished(this, new EventArgs());
            }
            StopThread();
        }

        #endregion

        #endregion

        #region Delegates

        public delegate void BackgroundMethod();

        public delegate void ParametrizedBackgroundMethod(Object obj);
        
        public delegate void ParametrizedBackgroundMethodWithResult(Object obj, out Object result);

        #endregion

        #region Events

        /// <summary>
        /// Событие оповещает об окнчании работы метода
        /// </summary>
        public event EventHandler WorkFinished;

        #endregion

    }
}