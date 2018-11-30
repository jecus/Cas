using System.ComponentModel;
using CAS.UI.Interfaces;

namespace CAS.UI.Management.Dispatchering
{
    /// <summary>
    /// Аргументы для события отображателя, которое может быть отменено
    /// </summary>
    public class EntityCancelEventArgs : CancelEventArgs
    {
        #region Fields
        
        /// <summary>
        /// Содержимое, в котором произошло событие
        /// </summary>
        private IDisplayingEntity _entity;

        #endregion
        
        #region Constructors

        /// <summary>
        /// Создает новый объект аргумента
        /// </summary>
        /// <param name="entity">Содержимое, в котором произошло событие</param>>
        public EntityCancelEventArgs(IDisplayingEntity entity)
        {
            _entity = entity;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Содержимое, в котором произошло событие
        /// </summary>
        public IDisplayingEntity Entity
        {
            get { return _entity; }
        }

        #endregion
    }
}