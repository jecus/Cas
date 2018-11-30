using System;
using System.Collections.Generic;
using SmartCore.Entities.General.Directives;

namespace SmartCore.Entities.Collections
{

    /// <summary>
    /// Коллекция директив с удобным доступом
    /// </summary>
    public class DirectiveCollection : CommonCollection<Directive>
    {

        #region public DirectiveCollection()
        /// <summary>
        /// Создает пустую коллекцию директив
        /// </summary>
        public DirectiveCollection()
        {
        }
        #endregion

        #region public DirectiveCollection(List<Directive> directives)
        /// <summary>
        /// Создает коллекцию директив агрегатова на основе передаваемого листа директив агрегата
        /// </summary>
        /// <param name="directives"></param>
        public DirectiveCollection(List<Directive> directives):base(directives.ToArray())
        {
        }
        #endregion

        #region public DirectiveCollection(Directive[]directives) : base(directives)
        /// <summary>
        /// Создает коллекцию директив агрегатова на основе передаваемого массива директив агрегата
        /// </summary>
        /// <param name="directives"></param>
        public DirectiveCollection(IEnumerable<Directive> directives) : base(directives)
        {
        }
        #endregion

        #region public Directive GetDirectiveById(Int32 directiveId)
        /// <summary>
        /// Возвращает директиву  с указанным номером, либо null если директива не был найден в коллекции
        /// </summary>
        /// <param name="directiveId"></param>
        /// <returns></returns>
        public Directive GetDirectiveById(Int32 directiveId)
        {
            return GetItemById(directiveId);
        }
        #endregion
    }
}
