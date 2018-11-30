using SmartCore.Entities.Collections;
using SmartCore.Entities.General.Accessory;

namespace SmartCore.Entities.General.Interfaces
{
    /// <summary>
    /// Интерфейс, запрашивающий наличие KIT-ов
    /// </summary>
    public interface IKitRequired : IBaseEntityObject
    {
        #region string KitParentString { get; }
        /// <summary>
        /// Возвращает строку для описания родителя КИТа
        /// </summary>
        string KitParentString { get; }
        #endregion

        #region public CommonCollection<Kit> Kits { get; }
        CommonCollection<AccessoryRequired> Kits { get; }
        #endregion
    }
}
