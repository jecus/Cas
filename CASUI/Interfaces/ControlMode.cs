using System;

namespace CAS.UI
{
    /// <summary>
    /// Состояние, в котором может находиться элемент управления
    /// </summary>
    public enum ControlMode
    {
        /// <summary>
        /// Добавление нового объекта
        /// </summary>
        Add,

        /// <summary>
        /// Редактирование объекта
        /// </summary>
        EditView,
    }
}
