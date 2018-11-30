using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SmartCore.Auxiliary;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.MaintenanceWorkscope;
using Convert = System.Convert;

namespace SmartCore.Calculations.Maintenance
{
    public class MaintenanceCheckGroupCollection : IEnumerable<MaintenanceCheckGroupByType>
    {
        #region public MaintenanceCheckGroupCollection()
        /// <summary>
        /// Создает пустую коллекцию 
        /// </summary>
        public MaintenanceCheckGroupCollection()
        {
        }
        #endregion

        #region MaintenanceCheckGroupCollection(MaintenanceCheckGroup[] items)
        /// <summary>
        /// Создает коллекцию описывающую созданные чеки для определённого борта  на основе передаваемого массива 
        /// </summary>
        public MaintenanceCheckGroupCollection(IEnumerable<MaintenanceCheckGroupByType> items)
        {
            _checkGroupItems.AddRange(items);
            //_MaintenanceSubCheckReferenceJobCard.Sort();
        }
        #endregion

        #region MaintenanceCheckGroupCollection(List<MaintenanceCheckGroup> items)
        /// <summary>
        /// Создает коллекцию описывающую созданные чеки для определённого борта  на основе передаваемой коллекции
        /// </summary>
        public MaintenanceCheckGroupCollection(List<MaintenanceCheckGroupByType> items)
        {
            _checkGroupItems.AddRange(items.ToArray());
        }
        #endregion

        public bool Schedule { get; set; }

        public bool Grouping { get; set; }

        public LifelengthSubResource Resource { get; set; }

        #region public DateTime GetLastComplianceDate()
        /// <summary>
        /// Возвращает дату самого последнего выполнения в данной коллекции групп чеков
        /// </summary>
        /// <returns></returns>
        public DateTime GetLastComplianceDate()
        {
            List<DateTime> dates = _checkGroupItems.SelectMany(item => item.Checks)
                                                   .SelectMany(c => c.PerformanceRecords)
                                                   .Select(r => r.RecordDate)
                                                   .OrderByDescending(d => d)
                                                   .ToList();
            return dates.Count > 0 ? dates.First() : DateTimeExtend.GetCASMinDateTime();
        }

        #endregion

        #region public DateTime GetLastComplianceDate(bool schedule, LifelengthSubResource subResource, bool grouping, MaintenanceCheckType checkType)
        /// <summary>
        /// Возвращает дату самого последнего выполнения в данной коллекции групп чеков
        /// </summary>
        /// <returns></returns>
        public DateTime GetLastComplianceDateOfCheckWithHigherType(bool schedule, LifelengthSubResource subResource,
                                                                   bool grouping, MaintenanceCheckType checkType)
        {
            List<DateTime> dates = 
                _checkGroupItems.SelectMany(item => item.Checks)
                                .Where(c => c.Schedule == schedule 
                                         && c.Resource == subResource
                                         && c.Grouping == grouping
                                         && c.CheckType.Priority > checkType.Priority)
                                .SelectMany(c => c.PerformanceRecords)
                                .Select(r => r.RecordDate)
                                .OrderByDescending(d => d)
                                .ToList();
            return dates.Count > 0 ? dates.First() : DateTimeExtend.GetCASMinDateTime();
        }

        #endregion

        #region public int Count { get; }
        /// <summary>
        /// Возвращает количество элементов в коллекции
        /// </summary>
        public int Count { get { return _checkGroupItems.Count; } }
        #endregion

        #region public Int32 GetMaxGroupNumber()
        public Int32 GetMaxGroupNumber(Int32 aircraftId, bool maintenanceType)
        {
            Int32 maxGroupNum = 0;
            foreach (MaintenanceCheckGroupByType group in _checkGroupItems)
            {
                if (group.GroupComplianceNum > maxGroupNum)
                    maxGroupNum = group.GroupComplianceNum;
            }
            return maxGroupNum;
        }
        #endregion

        #region public void OrderByGroupComplianceNum(bool ascending = true)
        /// <summary>
        /// Производит упорядочивание групп выполнения чеков
        /// </summary>
        /// <param name="ascending">Задает порядок сортировки чеков true-возрастание, false-убывание</param>
        public void OrderByGroupComplianceNum(bool ascending = true)
        {
            _checkGroupItems = ascending 
                ? _checkGroupItems.OrderBy(mcg => mcg.GroupComplianceNum).ToList() 
                : _checkGroupItems.OrderByDescending(mcg => mcg.GroupComplianceNum).ToList();
        }
        #endregion

        #region public void OrderByLastComplianceGroupNum(bool ascending = true)
        /// <summary>
        /// Производит упорядочивание групп выполнения чеков по номеру последней группы выполнения
        /// </summary>
        /// <param name="ascending">Задает порядок сортировки чеков true-возрастание, false-убывание</param>
        public void OrderByLastComplianceGroupNum(bool ascending = true)
        {
            _checkGroupItems = ascending
                ? _checkGroupItems.OrderBy(mcg => mcg.LastComplianceGroupNum).ToList()
                : _checkGroupItems.OrderByDescending(mcg => mcg.LastComplianceGroupNum).ToList();
        }
        #endregion

        #region public void OrderByLastComplianceGroupDate(bool ascending = true)
        /// <summary>
        /// Производит упорядочивание групп выполнения чеков по дате последней группы выполнения
        /// </summary>
        /// <param name="ascending">Задает порядок сортировки чеков true-возрастание, false-убывание</param>
        public void OrderByLastComplianceGroupDate(bool ascending = true)
        {
            _checkGroupItems = ascending
                ? _checkGroupItems.OrderBy(mcg => mcg.LastComplianceGroupDate).ToList()
                : _checkGroupItems.OrderByDescending(mcg => mcg.LastComplianceGroupDate).ToList();
        }
        #endregion

        #region  public void Clear()
        /// <summary>
        /// Очищает коллекцию чеков
        /// </summary>
        public void Clear()
        {
            _checkGroupItems.Clear();
        }
        #endregion

        #region public void Add(MaintenanceCheckGroup group)
        /// <summary>
        /// Добавляет Cas3MaintenanceSubCheckReferenceJobCardItem в коллекцию
        /// </summary>
        public void Add(MaintenanceCheckGroupByType group)
        {
            _checkGroupItems.Add(group);
        }
        #endregion

        #region public void AddRange(MaintenanceCheckGroup[] groups)
        /// <summary>
        /// Добавляет список директив в коллекцию
        /// </summary>
        /// <param name="groups"></param>
        public void AddRange(MaintenanceCheckGroupByType[] groups)
        {
            _checkGroupItems.AddRange(groups);
        }

        #endregion

        #region public void Add(MaintenanceCheck check, int complianceGroupNum)
        /// <summary>
        /// Добавляет Cas3MaintenanceSubCheckReferenceJobCardItem в коллекцию
        /// </summary>
        public void Add(MaintenanceCheck check, int complianceGroupNum)
        {
            MaintenanceCheckGroupByType group = null;
            foreach (MaintenanceCheckGroupByType maintenanceCheckGroup in _checkGroupItems)
                if (maintenanceCheckGroup.GroupComplianceNum == complianceGroupNum)
                    group = maintenanceCheckGroup;
   
            if(group == null)
            {
                group = new MaintenanceCheckGroupByType(check.Schedule);
                group.GroupComplianceNum = complianceGroupNum;
                _checkGroupItems.Add(group);
            }
                
            group.Checks.Add(check);
        }
        #endregion

        #region public void AddRange(Cas3MaintenanceCheck[] checks)
        /// <summary>
        /// Добавляет список директив в коллекцию
        /// </summary>
        /// <param name="checks"></param>
        public void AddRange(MaintenanceCheck[] checks)
        {
            foreach (MaintenanceCheck maintenanceCheck in checks)
            {
                foreach (MaintenanceCheckGroupByType maintenanceCheckGroup in _checkGroupItems)
                {
                    if(maintenanceCheckGroup.GroupComplianceNum == maintenanceCheck.ComplianceGroupNum)
                    {
                        maintenanceCheckGroup.Checks.Add(maintenanceCheck);
                        break;
                    }
                }
            }
        }

        #endregion

        #region public MaintenanceCheckGroup[] ToArray()
        /// <summary>
        /// Преобразует коллекцию в массив
        /// </summary>
        /// <returns></returns>
        public MaintenanceCheckGroupByType[] ToArray()
        {
            return _checkGroupItems.ToArray();
        }
        #endregion

        #region public IEnumerator GetEnumerator()
        /// <summary>
        /// Реализация цикла foreach 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _checkGroupItems.GetEnumerator();
        }
        #endregion

        #region IEnumerator<MaintenanceCheckGroupByType> IEnumerable<MaintenanceCheckGroupByType>.GetEnumerator()
        /// <summary>
        /// Возвращает перечислитель, выполняющий перебор элементов в коллекции.
        /// </summary>
        /// <returns>
        /// Интерфейс <see cref="T:System.Collections.Generic.IEnumerator`1"/>, который может использоваться для перебора элементов коллекции.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<MaintenanceCheckGroupByType> GetEnumerator()
        {
            return _checkGroupItems.GetEnumerator();
        }
        #endregion

        #region override public String ToString()

        /// <summary>
        /// Для отладки
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return "Count = " + Count;
        }
        #endregion

        #region public MaintenanceCheckGroup this[Int32 indexCollection]
        /// <summary>
        /// Возвращает объект из колекции по заданному индексу
        /// </summary>
        /// <param name="indexCollection">Порядковый номер элемента в колекции</param>
        /// <returns></returns>
        public MaintenanceCheckGroupByType this[Int32 indexCollection]
        {
            get
            {
                try
                {
                    return _checkGroupItems[indexCollection];
                }
                catch
                {

                    return null;
                }
            }
        }

        #endregion

        #region public int? FindMinStep()
        /// <summary>
        /// Находит минимальный шаг(интервал) (5*)
        /// </summary>
        public int? FindMinStep()
        {
            int? minStep;

            List<int?> list = (from groupByType in _checkGroupItems
                               from check in groupByType.Checks
                               where check.Schedule == Schedule && check.Grouping == Grouping && check.Resource == Resource
                               orderby check.Interval.GetSubresource(Resource)
                               select check.Interval.GetSubresource(Resource)).ToList();

            if (list.Count > 0 && list[0] != null)
            {
                minStep = Convert.ToInt32(list[0]);
            }
            else
            {
                minStep = null;
            }

            return minStep;
        }
        #endregion

        #region public MaintenanceCheck GetMinStepCheck()
        /// <summary>
        /// Возвращает чек с минимальным интервалом
        /// </summary>
        public MaintenanceCheck GetMinStepCheck()
        {
            List<MaintenanceCheck> list = (from groupByType in _checkGroupItems
                                           from check in groupByType.Checks
                                           where check.Schedule == Schedule && check.Grouping == Grouping && check.Resource == Resource
                                           orderby check.Interval.GetSubresource(Resource)
                                           select check).ToList();

            return list.FirstOrDefault();
        }
        #endregion

        #region public List<int> GetLastComplianceGroupNums()
        /// <summary>
        /// Возвращает список состоящий из номера последнего выполнения каждого чека
        /// </summary>
        public List<int> GetLastComplianceGroupNums()
        {
            List<int> list = (from groupByType in _checkGroupItems
                              from check in groupByType.Checks
                              where check.LastPerformance != null && check.Schedule == Schedule && 
                                    check.Grouping == Grouping && check.Resource == Resource
                              orderby check.LastPerformance.NumGroup descending
                              select check.LastPerformance.NumGroup).ToList();

            return list;
        }
        #endregion
        /*
         * Реализация
         */

        #region List<MaintenanceCheckGroup> _CheckGroupItems = new List<MaintenanceCheckGroup>();
        /// <summary>
        /// 
        /// </summary>
        private List<MaintenanceCheckGroupByType> _checkGroupItems = new List<MaintenanceCheckGroupByType>();
        #endregion
    }
}
