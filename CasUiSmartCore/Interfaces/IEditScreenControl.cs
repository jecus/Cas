using SmartCore.Entities.General;

namespace CAS.UI.Interfaces
{
    /// <summary>
    /// Интерфейс, опеределяющий экран редактирования элемента
    /// </summary>
    public interface IEditScreenControl
    {
        /// <summary>
        /// Редактируемый элемент
        /// </summary>
        BaseEntityObject EditedObject { get; }

        //protected bool GetChangeStatus()
    }
}
