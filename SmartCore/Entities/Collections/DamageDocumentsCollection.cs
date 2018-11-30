using System;
using System.Collections.Generic;
using System.Linq;
using SmartCore.Entities.General;

namespace SmartCore.Entities.Collections
{

    /// <summary>
    /// Коллекция директив с удобным доступом
    /// </summary>
    public class DamageDocumentsCollection : CommonCollection<DamageDocument>
    {

        #region public DamageDocumentsCollection()
        /// <summary>
        /// Создает пустую коллекцию директив
        /// </summary>
        public DamageDocumentsCollection()
        {
        }
        #endregion

        #region public DamageChartCollection(IEnumerable<DamageDocument> docs)
        /// <summary>
        /// Создает коллекцию документов повреждения
        /// </summary>
        /// <param name="docs"></param>
        public DamageDocumentsCollection(IEnumerable<DamageDocument> docs) : base(docs)
        {
        }
        #endregion

        /*
         * Реализация
         */
        #region override public String ToString()
        /// <summary>
        /// Для отладки
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return Items.Count(i => i.DocumentTypeId == 1) + " charts and " + Items.Count(i => i.DocumentTypeId == 2) + " images.";
        }
        #endregion
    }
}
