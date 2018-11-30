using System;

namespace SmartCore.Entities.General.Deprecated
{
    /// <summary>
    /// Описывает класс Corrosion Prevention And Control Program
    /// </summary>
    public class EngineeringOrderItem
    {
        /*
         * Свойства
         */

        #region public Boolean IsDeleted { get; set;}

        /// <summary>
        /// Удален ли объект из базы данных (легкое удаление)
        /// </summary>
        public Boolean IsDeleted { get; set; }

        #endregion
        

        /*
         * Методы
         */

        #region public String ToString()
        /// <summary>
        /// Служит для отладки
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return "";
        }

        #endregion

    }
}
