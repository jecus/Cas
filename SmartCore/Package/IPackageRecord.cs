using System;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.Packages
{
    /// <summary>
    /// Класс, Описывающий запись в пакете элементов
    /// </summary>
    public interface IPackageRecord : IBaseEntityObject
    {
        /// <summary>
        /// ID Пакета, которому пренадлежит данная запись
        /// </summary>
        Int32 ParentPackageId { get; set; }
        /// <summary>
        /// Пакет, которому пренадлежит данная запись
        /// </summary>
        IPackage ParentPackage { get; set; }
        /// <summary>
        /// ID директивы хранящейся в пакете
        /// </summary>
        Int32 PackageItemId { get; set; }
        /// <summary>
        /// Тип элемента, которой пренадлежит данная запись
        /// </summary>
        SmartCoreType PackageItemType { get; set; }
        /// <summary>
        /// Задача, привязанная к данной записи
        /// </summary>
        IBaseEntityObject PackageItem { get; set; }
    }
}
