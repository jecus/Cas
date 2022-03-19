using System;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.CAA.Audit
{
    [Serializable]
    public class WorkFlowStage : StaticDictionary
    {
        #region public static CommonDictionaryCollection<WorkFlowStage> _Items = new CommonDictionaryCollection<WorkFlowStage>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<WorkFlowStage> _Items = new CommonDictionaryCollection<WorkFlowStage>();
        #endregion

        public static WorkFlowStage View = new WorkFlowStage(1, "View", "View", "View");
        public static WorkFlowStage Evaluation = new WorkFlowStage(2, "Evaluation", "Evaluation", "Evaluation");
        public static WorkFlowStage CAR = new WorkFlowStage(3, "Corrective Action Report (CAR)", "Corrective Action Report (CAR)", "Corrective Action Report (CAR)");
        public static WorkFlowStage RCA = new WorkFlowStage(4, "Root Causes Analysis (RCA) ", "Root Causes Analysis (RCA)", "Root Causes Analysis (RCA)");
        public static WorkFlowStage CAP = new WorkFlowStage(5, "Corrective Action Plan (CAP)", "Corrective Action Plan (CAP)", "Corrective Action Plan (CAP)");
        public static WorkFlowStage Closed = new WorkFlowStage(6, "Closed ", "Closed ", "Closed");
        public static WorkFlowStage Unknown = new WorkFlowStage(-1, "Unknown", "Unknown", "Unknown");

        /*
         * Методы
         */

        #region public static WorkFlowStage GetItemById(Int32 DirectiveTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="directiveTypeId"></param>
        /// <returns></returns>
        public static WorkFlowStage GetItemById(int directiveTypeId)
        {
            foreach (WorkFlowStage t in _Items)
                if (t.ItemId == directiveTypeId)
                    return t;
            //
            return Unknown;
        }

        #endregion

        #region static public CommonDictionaryCollection<WorkFlowStage> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<WorkFlowStage> Items
        {
            get
            {
                return _Items;
            }
        }
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

        /*
        * Свойства
        */

        /*
         * Реализация
         */
        #region public WorkFlowStage()
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        public WorkFlowStage()
        {
        }
        #endregion

        #region public WorkFlowStage(Int32 ItemId, String shortName, String fullName, String commonName)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="commonName"></param>
        public WorkFlowStage(Int32 itemID, String shortName, String fullName, String commonName)
        {
            ItemId = itemID;
            ShortName = shortName;
            FullName = fullName;
            CommonName = commonName;

            //if (_Items == null) _Items = new List<DetailType>();
            _Items.Add(this);
        }
        #endregion
	}
}
