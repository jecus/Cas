using System;
using SmartCore.Entities.General;

namespace SmartCore.Entities.Dictionaries
{
    [Serializable]
    public abstract class AbstractDictionary : BaseEntityObject, IDictionaryItem
    {
        /*
        * Свойства
        */

        #region public abstract String ShortName { get; set; }
        /// <summary>
        /// Короткое имя
        /// </summary>
        public abstract String ShortName { get; set; }

        #endregion

        #region public abstract String FullName { get; set; }
        /// <summary>
        /// Полное имя
        /// </summary>
        public abstract String FullName { get; set; }

        #endregion

        #region public abstract String CommonName { get; set; }
        /// <summary>
        /// Общее имя 
        /// </summary>
        public abstract String CommonName { get; set; }

        #endregion

        #region public abstract string Category { get; set; }
        /// <summary>
        /// категория записи
        /// </summary>
        public abstract string Category { get; set; }
        #endregion

        #region public abstract void SetProperties(AbstractDictionary dict)

        public abstract void SetProperties(AbstractDictionary dict);
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Переводит тип директивы в строку
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return FullName;
        }
		#endregion

		public override BaseEntityObject GetCopyUnsaved(bool marked = true)
		{
			var abstractDictionary = (AbstractDictionary)MemberwiseClone();
			abstractDictionary.ItemId = -1;
			abstractDictionary.UnSetEvents();

            if(marked)
				abstractDictionary.FullName += " Copy";

			return abstractDictionary;
		}
	}
}

