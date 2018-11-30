using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCore.Entities.Dictionaries
{
    class DataEvent
    {
        #region public Int32 OperationID { get; set; }


        /// <summary>
        /// Уникальный номер оператора
        /// </summary>
        public Int32 OperationID { get; set; }

        #endregion

        #region     public String Description { get; set; }


        /// <summary>
        /// Дискриптор события
        /// </summary>
        public String Description { get; set; }

        #endregion
    }
}
