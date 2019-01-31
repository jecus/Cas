using System;
using System.Reflection;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.Packages
{
    /// <summary>
    /// Класс, Описывающий запись в пакете задач
    /// </summary>
    public class BaseDirectivePackageRecord : BaseEntityObject
    {
        private static Type _thisType;

        /*
         *  Свойства
         */

        #region public Int32 ParentId { get; set; }
        /// <summary>
		/// ID Рабочего пакета
		/// </summary>
        [TableColumn("ParentId")]
        public Int32 ParentId { get; set; }

        public static PropertyInfo ParentIdProperty
        {
            get { return GetCurrentType().GetProperty("ParentId"); }
        }

		#endregion

        #region public Int32 DirectiveId { get; set; }
        /// <summary>
		/// ID директивы хранящейся в пакете
		/// </summary>
        [TableColumn("DirectivesId")]
        public Int32 DirectiveId { get; set; }

        public static PropertyInfo DirectiveIdProperty
        {
            get { return GetCurrentType().GetProperty("DirectiveId"); }
        }

		#endregion

        #region public SmartCoreType PackageItemType { get; set; }
        /// <summary>
		/// Тип задачи, которой пренадлежит данная запись
		/// </summary>
        [TableColumn("PackageItemTypeId")]
        public SmartCoreType PackageItemType { get; set; }

        public static PropertyInfo PackageItemTypeProperty
        {
            get { return GetCurrentType().GetProperty("PackageItemType"); }
        }

		#endregion

        #region public IDirective Task { get; set; }
        /// <summary>
        /// Задача, привязанная к данной записи
        /// </summary>
        public IDirective Task { get; set; }
        #endregion

        #region public IDirectivePackage ParentPackage { get; set; }
        /// <summary>
        /// Родительский рабочий пакет
        /// </summary>
        public IDirectivePackage ParentPackage { get; set; }
        #endregion

        /*
		*  Методы 
		*/

        #region public BaseDirectivePackageRecord()
        public BaseDirectivePackageRecord()
        {
            PackageItemType = SmartCoreType.Unknown;
        }
        #endregion

        #region public override string ToString()
        public override string ToString()
        {
            return string.Format("Dir:id {0} desc:{1} ",DirectiveId, Task != null ? Task.ToString() : "");
        }
        #endregion

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(BaseDirectivePackageRecord));
        }
        #endregion

    }
}
