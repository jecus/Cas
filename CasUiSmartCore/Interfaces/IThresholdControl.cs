using SmartCore.Calculations;

namespace CAS.UI.Interfaces
{
    /// <summary>
    /// Интерфеис для контролов отобража.щих пороговые значения выполнения задач
    /// </summary>
    interface IThresholdControl
    {
        #region int MaxFirstColLabelWidth
        ///<summary>
        /// Возвращает максимальную длину заголовка в первой колонке
        ///</summary>
        int MaxFirstColLabelWidth { get; }
        #endregion

        #region int MaxFirstColControlWidth
        ///<summary>
        /// Возвращает максимальную длину контрола без заголовка в первой колонке
        ///</summary>
        int MaxFirstColControlWidth { get; }

        #endregion

        #region int MaxSecondColLabelWidth
        ///<summary>
        /// Возвращает максимальную длину заголовка во второй колонке
        ///</summary>
        int MaxSecondColLabelWidth { get; }

        #endregion

        #region int MaxSecondColControlWidth
        ///<summary>
        /// Возвращает максимальную длину контролов без заголовков во второй колонке
        ///</summary>
        int MaxSecondColControlWidth { get; }

        #endregion

        #region void SetFirstColumnPos(int pos)
        /// <summary>
        /// Устанавливает отступ первой колонки от левого края контрола
        /// (выравнивание производится по 1 textbox-у lifelenghtviewer-а)
        /// </summary>
        /// <param name="pos">отступ</param>
        void SetFirstColumnPos(int pos);

        #endregion

        #region void SetSecondColumnPos(int pos)
        /// <summary>
        /// Устанавливает отступ второй колонки от левого края контрола
        /// (выравнивание производится по 1-му textbox-у lifelenghtviewer-а)
        /// </summary>
        /// <param name="pos">отступ</param>
        void SetSecondColumnPos(int pos);

        #endregion

        #region private ApplyThreshold(DirectiveThreshold treshold)

        /// <summary>
        /// Заполняет все контролы в связи с заданным Threshold
        /// </summary>
        void ApplyThreshold(IThreshold threshold);

        #endregion
    }
}
