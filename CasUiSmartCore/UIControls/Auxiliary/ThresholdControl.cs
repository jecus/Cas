using System.Windows.Forms;
using SmartCore.Calculations;

namespace CAS.UI.UIControls.Auxiliary
{
    ///<summary>
    /// Общий контрол для предстваленя порогвых значений выполнеия задач
    ///</summary>
    public partial class ThresholdControl : UserControl
    {
        #region Properties

        #region public IThreshold Threshold { get; set; }
        ///<summary>
        ///</summary>
        public IThreshold Threshold
        {
            get { return GetThreshold(); }
            set { ApplyThreshold(value); }
        }
        #endregion

        #region int MaxFirstColLabelWidth
        ///<summary>
        /// Возвращает максимальную длину заголовка в первой колонке
        ///</summary>
        public virtual int MaxFirstColLabelWidth { get; set; }
        #endregion

        #region int MaxFirstColControlWidth
        ///<summary>
        /// Возвращает максимальную длину контрола без заголовка в первой колонке
        ///</summary>
        public virtual int MaxFirstColControlWidth { get; set; }

        #endregion

        #region int MaxSecondColLabelWidth
        ///<summary>
        /// Возвращает максимальную длину заголовка во второй колонке
        ///</summary>
        public virtual int MaxSecondColLabelWidth { get; set; }

        #endregion

        #region int MaxSecondColControlWidth
        ///<summary>
        /// Возвращает максимальную длину контролов без заголовков во второй колонке
        ///</summary>
        public virtual int MaxSecondColControlWidth { get; set; }

        #endregion

        #endregion

        #region Constructors
        ///<summary>
        ///</summary>
        protected ThresholdControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods

        #region public virtual SetFirstColumnPos(int pos)
        /// <summary>
        /// Устанавливает отступ первой колонки от левого края контрола
        /// (выравнивание производится по 1 textbox-у lifelenghtviewer-а)
        /// </summary>
        /// <param name="pos">отступ</param>
        public virtual void SetFirstColumnPos(int pos)
        {
        }

        #endregion

        #region public virtual SetSecondColumnPos(int pos)
        /// <summary>
        /// Устанавливает отступ второй колонки от левого края контрола
        /// (выравнивание производится по 1-му textbox-у lifelenghtviewer-а)
        /// </summary>
        /// <param name="pos">отступ</param>
        public virtual void SetSecondColumnPos(int pos)
        {
        }

        #endregion

        #region protected virtual DirectiveThreshold GetThreshold()
        /// <summary>
        /// Считывает все контролы и формирует один Threshold
        /// </summary>
        protected virtual IThreshold GetThreshold()
        {
            return null;
        }
        #endregion

        #region protected virtual void ApplyThreshold(DirectiveThreshold treshold)

        /// <summary>
        /// Заполняет все контролы в связи с заданным Threshold
        /// </summary>
        protected virtual void ApplyThreshold(IThreshold threshold)
        {

        }

        #endregion

        #region public virtual bool ValidateData()

        /// <summary>
        /// Проверяет правильность заполненных данных Threshold
        /// </summary>
        public virtual bool ValidateData()
        {
            return true;
        }

        #endregion

        #endregion
    }
}
