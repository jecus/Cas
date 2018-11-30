using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCore.Entities.Dictionaries
{
    class PositionType
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
