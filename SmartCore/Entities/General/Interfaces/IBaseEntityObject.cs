using System;
using System.Collections.Generic;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.Entities.General.Interfaces
{
    /// <summary>
    /// Интерфейс, описывающий объект, который может сохранятся в БД
    /// </summary>
    public interface IBaseEntityObject : IBaseCoreObject, IEqualityComparer<IBaseEntityObject>, IEquatable<IBaseEntityObject>
    {
        #region SmartCoreType ObjectType { get; }
        /// <summary>
        /// Тип объекта - директива, деталь, чек и т.д.
        /// </summary>
        SmartCoreType SmartCoreObjectType { get; }
        #endregion

        #region Boolean IsDeleted { get; set; }

        /// <summary>
        /// Действителен ли объект
        /// </summary>     
        Boolean IsDeleted { get; set; }
        #endregion

        #region Int32 ItemId { get; set; }
        /// <summary>
        /// Идентификатор записи
        /// </summary>
        Int32 ItemId { get; set; }
		#endregion

		DateTime Updated { get; }

		int CorrectorId { get; set; }

		#region IBaseEntityObject GetCopyUnsaved();
		/// <summary>
		/// Возвращает полную копию объекта (полностью копирую вложенные элементы и коллекции),
		/// <br/>с ItemId равным -1
		/// </summary>
		/// <returns></returns>
		IBaseEntityObject GetCopyUnsaved(bool marked = true);
        #endregion
    }
}
