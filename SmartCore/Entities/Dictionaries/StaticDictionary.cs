using System;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.Dictionaries
{
    /// <summary>
    /// Представляет стастический словарь. 
    /// <br/>Каждый статический словарь должен содержать открытый конструктор без параметров
    /// <br/>Каждый статический словарь должен содержать открытое статичесоке своиство Items
    /// <br/>Каждый статический словарь должен содержать открытое статичесоке своиство Unknown c id равным -1
    /// </summary>
    [Serializable]
    public abstract class StaticDictionary : BaseEntityObject, IDictionaryItem
    {

        /*
        * Свойства
        */

        #region public String ShortName { get; set; }
        /// <summary>
        /// Короткое имя
        /// </summary>
        public String ShortName { get; set; }

        #endregion

        #region public String FullName { get; set; }
        /// <summary>
        /// Полное имя
        /// </summary>
        [FormControl(250, "Full name", Enabled = false, Order = 1)]
        [ListViewData(0.20f, "Full name",1)]
        public String FullName { get; set; }

        #endregion

        #region public String CommonName { get; set; }
        /// <summary>
        /// Общее имя 
        /// </summary>
        public String CommonName { get; set; }

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
    }
}

