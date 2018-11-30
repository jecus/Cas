namespace SmartCore.Entities
{
    /// <summary>
    /// Описывает состояние процесса загрузки
    /// </summary>
    public class LoadingState
    {
        #region public int CurrentStage { get; set; }
        /// <summary>
        /// Текушая стадия выполнения загрузки
        /// </summary>
        public int CurrentStage { get; set; }

        #endregion

        #region public string CurrentStageDescription { get; set; }
        /// <summary>
        /// Описание текущей стандии загрузки
        /// </summary>
        public string CurrentStageDescription { get; set; }

        #endregion

        #region public int Stages { get; set; }
        /// <summary>
        /// Количество стадий выполнения загрузки
        /// </summary>
        public int Stages { get; set; }

        #endregion

        #region public double CurrentPersentage{ get; set; }
        /// <summary>
        /// Текущая процентовка на текущей стадии закрузки (должна быть меньше либо равной  <see cref="MaxPersentage"/>)
        /// </summary>
        public double CurrentPersentage { get; set; }

        #endregion

        #region public string CurrentPersentageDescription { get; set; }
        /// <summary>
        /// Описание текущей процентовки загрузки
        /// </summary>
        public string CurrentPersentageDescription { get; set; }

        #endregion

        #region public double MaxPersentage { get; set; }
        /// <summary>
        /// Максимальня процентовка на текущей стадии закрузки (может быть больше 100)
        /// </summary>
        public double MaxPersentage { get; set; }

        #endregion
    }
}
