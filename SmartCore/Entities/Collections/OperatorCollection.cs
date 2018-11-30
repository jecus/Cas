using System;
using SmartCore.Entities.General;

namespace SmartCore.Entities.Collections
{
    /// <summary>
    /// Коллекция операторов с удобным доступом к воздушным судам
    /// </summary>
    public class OperatorCollection: CommonCollection<Operator>
    {

        #region public OperatorCollection()

        /// <summary>
        /// Создает пустую коллекцию операторов
        /// </summary>
        public OperatorCollection()
        {
        }

        #endregion

        #region public OperatorCollection(Operator[] operators) : base(operators)
        /// <summary>
        /// Создает коллекцию операторов на основе передаваемого массива 
        /// </summary>
        /// <param name="operators"></param>
        public OperatorCollection(Operator[] operators) : base(operators)
        {
        }
        #endregion

        #region  public Operator  GetOperatorByID(Int32 operatorId)
        /// <summary>
        /// Возвращает оператора с указанным номером, либо null если оператор не был найден в коллекции
        /// </summary>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        public Operator  GetOperatorById(Int32 operatorId)
        {
            return GetItemById(operatorId);
        }
        #endregion
    }
}
