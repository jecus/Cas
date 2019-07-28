using System;
using System.Linq;
using EntityCore.DTO.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.Entities.General.SMS
{
    #region public class EventCondition
    /// <summary>
    /// Описывает условие события системы безопасности полетов
    /// </summary>
    [Table("EventConditions", "dbo", "ItemId")]
    [Dto(typeof(EventConditionDTO))]
	public class EventCondition : BaseEntityObject, IComparable<EventCondition>
    {
        private SmartCoreType _valueType;
        private object _conditionValue;
        /*
        *  Свойства
        */

        #region public SmartCoreType EventConditionType { get; set; }
        /// <summary>
        /// Тип условия события
        /// </summary>
        [TableColumn("EventConditionTypeId")]
        [ListViewData(0.2f, "Event Condition Type")]
        public SmartCoreType EventConditionType
        {
            get 
            {
                if (_conditionValue == null && _valueType == null)
                    _valueType = SmartCoreType.Unknown;
                return _valueType;
            } 
            set { _valueType = value; }
        }

        #endregion

        #region public BaseEntityObject Value { get; set; }
        /// <summary>
        /// Значение условия
        /// </summary>
        [TableColumn("ValueId", "EventConditionType")]
        [ListViewData(0.2f, "Value")]
        public object Value
        {
            get { return _conditionValue; }
            set
            {
                if (value == null)
                    _valueType = SmartCoreType.Unknown;
                else if (value is BaseEntityObject)
                    _valueType = ((BaseEntityObject) value).SmartCoreObjectType;
                else if (value.GetType().IsEnum)
                    _valueType = SmartCoreType.Items.Where(i => i.ObjectType != null && i.ObjectType.Name == value.GetType().Name).First();
                else _valueType = SmartCoreType.Unknown;

                if(_conditionValue != value)
                {
                    _conditionValue = value;
                    OnPropertyChanged("Value");
                }
            }
        }

        #endregion

        #region public Int32 ParentId { get; set; }

        /// <summary>
        /// ID Родителя
        /// </summary>
        [TableColumn("ParentId")]
        public Int32 ParentId { get; set; }

        #endregion

        #region public SmartCoreType ParentType { get; set; }

        /// <summary>
        /// ID Типа Родителя
        /// </summary>
        [TableColumn("ParentTypeId")]
        public SmartCoreType ParentType { get; set; }

        #endregion

        #region Implement of ICompdreble

        public int CompareTo(EventCondition y)
        {
            return ItemId.CompareTo(y.ItemId);
        }

        #endregion

        /*
		*  Методы 
		*/

        #region public EventCondition()
        /// <summary>
        /// Создает условие без дополнительной информации
        /// </summary>
        public EventCondition()
        {
            //задаем все ID в -1
            ItemId = -1;
            EventConditionType = SmartCoreType.EventCondition;
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Перегружаем для отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _conditionValue != null ? _conditionValue.ToString() : "";
        }

        #endregion 

    }
    #endregion
}
