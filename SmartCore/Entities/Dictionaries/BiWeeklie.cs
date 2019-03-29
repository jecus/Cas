using System;

namespace SmartCore.Entities.Dictionaries
{
    class BiWeeklie
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

        #region public Byte[] Report { get; set; }


        /// <summary>
        /// Отчет
        /// </summary>
        public Byte[] Report { get; set; }

        #endregion

        #region public DateTime RecievedDate { get; set; }


        /// <summary>
        /// Дата получения
        /// </summary>
        public DateTime RecievedDate { get; set; }

        #endregion

        #region     public String RealName { get; set; }


        /// <summary>
        /// Реальное имя
        /// </summary>
        public String RealName { get; set; }

        #endregion
    }
}
