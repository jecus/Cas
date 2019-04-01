using System;

namespace SmartCore.Entities.Dictionaries
{
    /// <summary>
    /// хз для чего. Может быть понадобиться
    /// </summary>
    class MaintenanceJobCardSkill
    {
        #region public Int32 ItemID { get; set; }


        /// <summary>
        /// номер записи в базе данных
        /// </summary>
        public Int32 ItemID { get; set; }

        #endregion

        #region         public String ShortName { get; set; }


        /// <summary>
        /// Короткое имя
        /// </summary>
        public String ShortName { get; set; }

        #endregion

        #region public String FullName { get; set; }


        /// <summary>
        /// Полное имя
        /// </summary>
        public String FullName { get; set; }

        #endregion
    }
}
