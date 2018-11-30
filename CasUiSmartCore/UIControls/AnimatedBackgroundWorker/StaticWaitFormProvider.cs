using System;

namespace CAS.UI.UIControls.AnimatedBackgroundWorker
{
    /// <summary>
    /// Провайдер статичкой формы ожидания
    /// </summary>
    public static class StaticWaitFormProvider
    {
        #region Fields

        private static readonly WaitForm waitForm;
        private static bool _isActive;

        #endregion

        #region Constructors

        #region static StaticWaitFormProvider()

        static StaticWaitFormProvider()
        {
            waitForm = new WaitForm();
            waitForm.ShowInTaskbar = false;
        }

        #endregion

        #endregion

        #region Properties

        #region public static WaitForm WaitForm
        /// <summary>
        /// Форма ожидания
        /// </summary>
        public static WaitForm WaitForm
        {
            get { return waitForm; }
        }

        #endregion

        #region public static bool IsActive
        /// <summary>
        /// Исрользуется ли форма в данный момент
        /// </summary>
        public static bool IsActive
        {
            get { return _isActive; }
            set
            {
                _isActive = value;
                if (StatusChaged!=null)
                    StatusChaged(waitForm,new EventArgs());
            }
        }

        #endregion

        #endregion

        #region Events
        /// <summary>
        /// Возникает когда статус формы изменяется
        /// </summary>
        public static event EventHandler StatusChaged;

        #endregion


    }
}
