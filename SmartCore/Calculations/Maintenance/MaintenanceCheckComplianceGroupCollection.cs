using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace SmartCore.Calculations.Maintenance
{
    public class MaintenanceCheckComplianceGroupCollection : IEnumerable<MaintenanceCheckComplianceGroup>
    {
        #region public MaintenanceCheckComplianceGroupCollection()
        /// <summary>
        /// Создает пустую коллекцию 
        /// </summary>
        public MaintenanceCheckComplianceGroupCollection()
        {
        }
        #endregion

        #region public MaintenanceCheckComplianceGroupCollection(MaintenanceCheckComplianceGroup[] items)
        /// <summary>
        /// Создает коллекцию описывающую созданные чеки для определённого борта  на основе передаваемого массива 
        /// </summary>
        public MaintenanceCheckComplianceGroupCollection(MaintenanceCheckComplianceGroup[] items)
        {
            _checkGroupItems.AddRange(items);
            //_MaintenanceSubCheckReferenceJobCard.Sort();
        }
        #endregion

        #region MaintenanceCheckComplianceGroupCollection(List<MaintenanceCheckComplianceGroup> items)
        /// <summary>
        /// Создает коллекцию описывающую созданные чеки для определённого борта  на основе передаваемой коллекции
        /// </summary>
        public MaintenanceCheckComplianceGroupCollection(List<MaintenanceCheckComplianceGroup> items)
        {
            _checkGroupItems.AddRange(items.ToArray());
        }
        #endregion

        #region public MaintenanceCheckComplianceGroup GetCheckGroupNum(Int32 id)
        /// <summary>
        /// Возвращает MaintenanceCheckComplianceGroup по заданному ItemID
        /// </summary>
        /// <param name="id">ItemID</param>
        /// <returns></returns>
        public MaintenanceCheckComplianceGroup GetCheckGroupNum(Int32 id)
        {
            foreach (MaintenanceCheckComplianceGroup item in _checkGroupItems)
            {
                if (item.GroupComplianceNum == id)
                {
                    return item;
                }
            }
            return null;
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
            foreach (MaintenanceCheckComplianceGroup group in _checkGroupItems)
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

        #region  public void Clear()
        /// <summary>
        /// Очищает коллекцию чеков
        /// </summary>
        public void Clear()
        {
            _checkGroupItems.Clear();
        }
        #endregion

        #region public void Add(MaintenanceCheckComplianceGroup group)
        /// <summary>
        /// Добавляет Cas3MaintenanceSubCheckReferenceJobCardItem в коллекцию
        /// </summary>
        public void Add(MaintenanceCheckComplianceGroup group)
        {
            _checkGroupItems.Add(group);
        }
        #endregion

        #region public void AddRange(MaintenanceCheckComplianceGroup[] groups)
        /// <summary>
        /// Добавляет список директив в коллекцию
        /// </summary>
        /// <param name="groups"></param>
        public void AddRange(MaintenanceCheckComplianceGroup[] groups)
        {
            _checkGroupItems.AddRange(groups);
        }

        #endregion

        #region public void Add(MaintenanceCheck check, int complianceGroupNum, int checkCycle)
        /// <summary>
        /// Добавляет Cas3MaintenanceSubCheckReferenceJobCardItem в коллекцию
        /// </summary>
        public void Add(MaintenanceCheck check, int complianceGroupNum, int checkCycle)
        {
            MaintenanceCheckComplianceGroup group = null;
            foreach (MaintenanceCheckComplianceGroup maintenanceCheckGroup in _checkGroupItems)
                if (maintenanceCheckGroup.GroupComplianceNum == complianceGroupNum &&
                    maintenanceCheckGroup.Schedule == check.Schedule &&
                    maintenanceCheckGroup.Grouping == check.Grouping &&
                    maintenanceCheckGroup.Resource == check.Resource)
                    group = maintenanceCheckGroup;
   
            if(group == null)
            {
                group = new MaintenanceCheckComplianceGroup(check.Schedule);
                group.Grouping = check.Grouping;
                group.Resource = check.Resource;
                group.GroupComplianceNum = complianceGroupNum;
                group.CheckCycle = checkCycle;
                _checkGroupItems.Add(group);
            }
                
            group.Checks.Add(check);
            if (group.CheckCycle < checkCycle)
                group.CheckCycle = checkCycle;
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
                foreach (MaintenanceCheckComplianceGroup maintenanceCheckGroup in _checkGroupItems)
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

        #region public MaintenanceCheckComplianceGroup[] ToArray()
        /// <summary>
        /// Преобразует коллекцию в массив
        /// </summary>
        /// <returns></returns>
        public MaintenanceCheckComplianceGroup[] ToArray()
        {
            return _checkGroupItems.ToArray();
        }
        #endregion

        #region Члены IEnumerable
        /// <summary>
        /// Возвращает перечислитель, который осуществляет перебор элементов коллекции.
        /// </summary>
        /// <returns>
        /// Объект <see cref="T:System.Collections.IEnumerator"/>, который может использоваться для перебора элементов коллекции.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _checkGroupItems.GetEnumerator();
        }
        #endregion

        #region IEnumerator<MaintenanceCheckComplianceGroup> IEnumerable<MaintenanceCheckComplianceGroup>.GetEnumerator()
        /// <summary>
        /// Возвращает перечислитель, выполняющий перебор элементов в коллекции.
        /// </summary>
        /// <returns>
        /// Интерфейс <see cref="T:System.Collections.Generic.IEnumerator`1"/>, который может использоваться для перебора элементов коллекции.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<MaintenanceCheckComplianceGroup> GetEnumerator()
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

        #region public MaintenanceCheckComplianceGroup this[Int32 indexCollection]
        /// <summary>
        /// Возвращает объект из колекции по заданному индексу
        /// </summary>
        /// <param name="indexCollection">Порядковый номер элемента в колекции</param>
        /// <returns></returns>
        public MaintenanceCheckComplianceGroup this[Int32 indexCollection]
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

        #region public List<MaintenanceCheckComplianceGroup> GetGroupsWhereCheckIsSenior(MaintenanceCheck check)
        public List<MaintenanceCheckComplianceGroup> GetGroupsWhereCheckIsSenior(MaintenanceCheck check)
        {
            return _checkGroupItems.Where(g => g.GetMaxIntervalCheck() != null && g.GetMaxIntervalCheck() == check).ToList();
        }
        #endregion

        /*
         * Реализация
         */

        #region List<MaintenanceCheckComplianceGroup> _CheckGroupItems = new List<MaintenanceCheckComplianceGroup>();
        /// <summary>
        /// 
        /// </summary>
        private List<MaintenanceCheckComplianceGroup> _checkGroupItems = new List<MaintenanceCheckComplianceGroup>();
        #endregion
    }
}
