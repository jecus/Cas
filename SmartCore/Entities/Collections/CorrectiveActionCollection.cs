using System.Collections.Generic;
using SmartCore.Entities.General.Atlbs;

namespace SmartCore.Entities.Collections
{

    /// <summary>
    /// Содержит список корректирующих действий для отклоненения воздушного судна. 
    /// На самом деле отклонение может иметь только одно корректирующее действие (связь один к одному)
    /// </summary>
    public class CorrectiveActionCollection
    {
        #region private List<CorrectiveAction> _Components = new List<ComponentOilCondition>();
        /// <summary>
        /// Внутренняя коллекция агрегатов
        /// </summary>
        private List<CorrectiveAction>_Actions = new List<CorrectiveAction>();
        #endregion

        //#region private daLoggable dataAccessProvider = null;
        ///// <summary>
        ///// Объект, отвечающий за связь коллекции с базой данных
        ///// </summary>
        //private daLoggable dataAccessProvider = null;
        //#endregion

        //#region protected override CAS.daCore.daLoggable CreateLoggableDataAccessProvider()
        ///// <summary>
        ///// Создаем объект, отвечающий за связь коллекции с базой данных 
        ///// </summary>
        ///// <returns></returns>
        //protected override CAS.daCore.daLoggable CreateLoggableDataAccessProvider()
        //{
        //    if (dataAccessProvider == null) dataAccessProvider = new daCorrectiveAction();
        //    return dataAccessProvider;
        //}
        //#endregion

        //#region public override bool HasPermission(UserRole userRole, DataEvent operation)
        ///// <summary>
        ///// Имеет ли пользователь заданной категории права на выполнение заданной операции
        ///// </summary>
        ///// <param name="userRole">Категория пользователя</param>
        ///// <param name="operation">Тип выполняемой операции</param>
        ///// <returns>true, если имеются права на выполнение данной операции и false если нет</returns>
        ///// <remarks>Метод должен быть обязательно переопределен в наследниках</remarks>
        //public override bool HasPermission(UserRole userRole, DataEvent operation)
        //{
        //    return DirectiveCollection.HasAccess(userRole, operation);
        //}
        //#endregion

        /// <summary>
        /// Содержит список корректирующих действия для отклонения воздушного судна.
        /// На самом деле отклонение может иметь только одно корректирующее действие (связь один к одному)
        /// </summary>
        /// <param name="parent"></param>
        public CorrectiveActionCollection(Discrepancy parent)// : base(parent)
        {
        }

        public CorrectiveActionCollection()
        {
        }

        #region public CorrectiveAction this[int index]
        /// <summary>
        /// Уровень масла агрегата под указананным порядковым номером
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public CorrectiveAction this[int index]
        {
            get { return _Actions[index]; }
            set { _Actions[index] = value; }
        }
        #endregion

        #region public int Count
        /// <summary>
        /// Количество агрегатов
        /// </summary>
        public int Count
        {
            get { return _Actions.Count; }
        }
        #endregion

        #region public void Add(ComponentOilCondition oilCondition)
        /// <summary>
        /// Добавляет информацию об агрегате в коллекцию
        /// </summary>
        public void Add(CorrectiveAction Action )
        {
            _Actions.Add(Action);
            //    oilCondition.DataChange += ComponentOilConditionCollection_DataChange;
            //    OnCollectionChange();
        }
		#endregion

	    public void AddRange(IEnumerable<CorrectiveAction> action)
	    {
			_Actions.AddRange(action);
	    }

	    #region public void RemoveAt(int index)
			/// <summary>
			/// Удаляет информацию об агрегате под заданным номером
			/// </summary>
			/// <param name="index"></param>
		public void RemoveAt(int index)
        {
            _Actions.RemoveAt(index);
            //    OnCollectionChange();
        }
        #endregion

        #region public void Remove(CorrectiveAction RemovedAction)
        /// <summary>
        /// Удаляет информацию об заданном агрегате
        /// </summary>
        /// <param name="index"></param>
        public void Remove(CorrectiveAction RemovedAction)
        {
            int i;
            //CorrectiveAction action = null;
            for (i = 0; i<_Actions.Count; i++)
            {
                if(_Actions[i] == RemovedAction)
                {
                    _Actions.RemoveAt(i);
                    break;
                }
            }
            //_Actions.RemoveAt(i);
            //    OnCollectionChange();
        }
        #endregion

        #region public bool Contains(CorrectiveAction ContainedAction)
        /// <summary>
        /// Удаляет информацию об заданном агрегате
        /// </summary>
        /// <param name="index"></param>
        public bool Contains(CorrectiveAction ContainedAction)
        {
            int i;
            for (i = 0; i < _Actions.Count; i++)
            {
                if (_Actions[i] == ContainedAction)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

    }
}
