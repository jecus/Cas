using System;
using System.Collections.Generic;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.Entities.General.Interfaces
{
    /// <summary>
    /// Интерфеис описывает объект- задачу
    /// <br/> У любого объекта-задачи должны быть
    /// <br/> 1. Порог первого и след. выполнения
    /// <br/> 2. Записи о выполнении задачи
    /// <br/> 3. Доступ к последней записи о выполнении задачи
    /// <br/> 4. Список последующих выполнений задачи
    /// </summary>
    public interface IDirective : IBaseEntityObject, IPrintSettings
    {
		#region Properties

		#region BaseSmartCoreObject LifeLengthParent { get; }
		/// <summary>
		/// Возвращает родительский объект, для которого можно расчитать текущую наработку. Обычно Aircraft, BaseComponent или Component
		/// </summary>
		BaseEntityObject LifeLengthParent { get; }
        #endregion

        #region IThreshold Threshold { get; set; }
        /// <summary>
        /// Порог первого и посделующего выполнений
        /// </summary>
        IThreshold Threshold { get; set; }
        #endregion

        #region IRecordCollection PerformanceRecords { get; }
        /// <summary>
        /// Коллекция, содержащая записи о выполнении задачи
        /// </summary>
        IRecordCollection PerformanceRecords { get; }
        #endregion

        #region AbstractPerformanceRecord LastPerformance { get; }
        /// <summary>
        /// Доступ к последней записи о выполнении задачи
        /// </summary>
        AbstractPerformanceRecord LastPerformance { get;}
        #endregion

        #region List<NextPerformance> NextPerformances { get; }
        /// <summary>
        /// Список последующих выполнений задачи
        /// </summary>
        List<NextPerformance> NextPerformances { get; }
        #endregion

        #region NextPerformance NextPerformance { get; }
        /// <summary>
        /// След. выполнение задачи
        /// </summary>
        NextPerformance NextPerformance { get; }
        #endregion

        #region ConditionState Condition { get; }
        /// <summary>
        /// Возвращает состояние ближайшего выполнения задачи (если оно расчитано) или ConditionState.NotEstimated
        /// </summary>
        ConditionState Condition { get; }
        #endregion

        #region DirectiveStatus Status { get; }
        /// <summary>
        /// Возвращает текущий статус задачи
        /// </summary>
        DirectiveStatus Status { get; }
        #endregion

        #region Lifelength NextPerformanceSource { get; }
        /// <summary>
        /// Возвращает ресурс ближайшего выполнения задачи (если оно расчитано) или Lifelength.Null
        /// </summary>
        Lifelength NextPerformanceSource { get; }
        #endregion

        #region Lifelength Remains { get; }

        /// <summary>
        /// Возвращает остаток ресурса до ближайшего выполнения задачи (если оно расчитано) или Lifelength.Null
        /// </summary>
        Lifelength Remains { get; }

        #endregion

        #region Lifelength BeforeForecastResourceRemain { get; }
        /// <summary>
        /// Остаток ресурса между точкой прогноза и последним выполнением(или начальной точки) до прогноза (вычисляется только в прогнозе)
        /// </summary>
        Lifelength BeforeForecastResourceRemain { get; }
        #endregion

        #region Lifelength ForecastLifelength { get; set; }
        //ресурс прогноза
        Lifelength ForecastLifelength { get; set; }
        #endregion

        #region Lifelength AfterForecastResourceRemain { get; set; }
        /// <summary>
        /// Остаток между точкой прогноза и первым выполнением после точки прогноза(вычисляется только в прогнозе)
        /// </summary>
        Lifelength AfterForecastResourceRemain { get; set; }
        
        #endregion

        #region DateTime? NextPerformanceDate { get; }
        /// <summary>
        /// Возвращает прблизительную дату ближайшего выполнения задачи (если оно расчитано) или null
        /// </summary>
        DateTime? NextPerformanceDate { get; }
        #endregion

        #region  double? Percents { get; set; }
        /// <summary>
        /// Насколько процентов NextCompliance превосходит точку прогноза
        /// </summary>
        double? Percents { get; set; }
        #endregion

        #region Int32 Times { get;}
        /// <summary>
        /// возращает количество "след.выполнений" директивы или -1
        /// </summary>
        Int32 Times { get;}
        #endregion

        #region string TimesToString { get; }
        /// <summary>
        /// Возвращает строковое представление количества "след. выполнений"
        /// </summary>
        string TimesToString { get; }
        #endregion

        #region Boolean IsClosed { get; set; }
        ///
        /// Логический флаг, показывающий, закрыта ли директива
        /// 
        Boolean IsClosed { get; set; }

        #endregion

        #region Boolean NextPerformanceIsBlocked { get; }
        ///
        /// Логический флаг, показывающий, заблокировано ли след. выполенение директивы рабочим пакетом
        /// 
        Boolean NextPerformanceIsBlocked { get; }

        #endregion

        #endregion

        #region Methods

        void ResetMathData();

        #endregion
    }
}
