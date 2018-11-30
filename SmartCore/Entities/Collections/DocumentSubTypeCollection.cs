using System;
using System.Collections.Generic;
using System.Linq;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.Entities.Collections
{

    /// <summary>
    /// Коллекция возушных судов с удобным доступом к воздушным судам
    /// </summary>
    public class DocumentSubTypeCollection : CommonDictionaryCollection<DocumentSubType>
    {

        #region public DocumentSubTypeCollection()
        /// <summary>
        /// Констуктор по умолчанию, необходим при использовании рефлексии 
        /// </summary>
        public DocumentSubTypeCollection()
        {
        }
        #endregion

        #region public DocumentSubTypeCollection(List<DocumentSubType>  docSubTypes)
        /// <summary>
        /// Создает коллекцию подтипов документов на основе передаваемого списка 
        /// </summary>
        /// <param name="docSubTypes"></param>
        public DocumentSubTypeCollection(List<DocumentSubType> docSubTypes)
            : base(docSubTypes.ToArray())
        {
        }
        #endregion

        #region public DocumentSubType GetCertificateSubTypeById(Int32 id)
        /// <summary>
        /// Возвращает тип сертификата по заданному имени или null
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DocumentSubType GetTypeByName(string name)
        {
            return Items.FirstOrDefault(item => item.FullName == name);
        }
        #endregion

        #region public List<DocumentSubType> GetSubTypesByDocType(DocumentType parentDocType)
        /// <summary>
        /// Возвращает все подтипы документов по заданному родительскому документу или null
        /// </summary>
        /// <returns></returns>
        public List<DocumentSubType> GetSubTypesByDocType(DocumentType parentDocType)
        {
            return Items.Where(item => item.DocumentTypeId == parentDocType.ItemId).ToList();
        }
        #endregion

        #region public DocumentSubType GetDictionaryItemById(Int32 id)
        /// <summary>
        /// Возвращает объект заданному ItemID или создает новый объект по умолчанию
        /// </summary>
        /// <param name="id">ItemID</param>
        /// <returns></returns>
        public override DocumentSubType GetItemById(Int32 id)
        {
            DocumentSubType result = Items.FirstOrDefault(item => item.ItemId == id);
            if (result != null) return result;
            return id <= 0 ? new DocumentSubType { FullName = "", ItemId = -1 }
                           : new DocumentSubType { FullName = "Can't Find item with id:" + id, ItemId = id };
        }
        #endregion
    }
}
