using System;
using System.Collections.Generic;
using System.Linq;
using SmartCore.Calculations;
using SmartCore.Calculations.Maintenance;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace SmartCore.Entities.Collections
{
    public class MaintenanceCheckCollection : CommonCollection<MaintenanceCheck>
    {
        #region public MaintenanceCheckCollection()
        /// <summary>
        /// Создает пустую коллекцию 
        /// </summary>
        public MaintenanceCheckCollection()
        {
        }
        #endregion

        #region MaintenanceCheckCollection(IEnumerable<MaintenanceCheck> items)
        /// <summary>
        /// Создает коллекцию описывающую созданные чеки для определённого борта  на основе передаваемого массива 
        /// </summary>
        public MaintenanceCheckCollection(IEnumerable<MaintenanceCheck> items) : base(items)
        {
        }
        #endregion

        #region MaintenanceCheckCollection(List<MaintenanceCheck> items)
        /// <summary>
        /// Создает коллекцию описывающую созданные чеки для определённого борта  на основе передаваемой коллекции
        /// </summary>
        public MaintenanceCheckCollection(List<MaintenanceCheck> items) : base(items.ToArray())
        {
        }
        #endregion

        #region public List<MaintenanceCheck> GetChecksByAircraftId(Int32 id, bool schedule)
        /// <summary>
        /// Возвращает MaintenanceCheck по заданному AircraftID и типу программы (Schedule/Unschedule) 
        /// </summary>
        /// <param name="id">AircraftID</param>
        /// <param name="schedule"></param>
        /// <returns></returns>
        public List<MaintenanceCheck> GetChecksByAircraftId(Int32 id, bool schedule)
        {
            return Items.Where(check => check.ParentAircraftId == id && check.Schedule == schedule).ToList();
        }

        #endregion

        #region public int? FindMinStep(bool schedule)
        /// <summary>
        /// Находит минимальный шаг(интервал) (5*)
        /// </summary>
        public int? FindMinStep(bool schedule)
        {
            List<int?> list;
            int? minStep;
            if (schedule)
            {
                list =
               (from check in Items
                where check.Schedule == schedule
                orderby check.Interval.Hours
                select check.Interval.Hours).ToList();
            }
            else
            {
                list =
               (from check in Items
                where check.Schedule == schedule
                orderby check.Interval.Days
                select check.Interval.Days).ToList();
            }
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

        #region public MaintenanceCheckRecord GetLastCheckRecordWhereCheckIsSenior(MaintenanceCheck check)
        /// <summary>
        /// Расчитывает последнюю группу записей о выполнении чеков программы обслуживания в которой заданный чек будет старшим
        /// <br/> и возвращает запись о выполнении заданного чека
        /// </summary>
        /// <param name="check">Чек, для которого нужно найти группу</param>
        /// <returns>запись о выполнении или null</returns>
        public MaintenanceCheckRecord GetLastCheckRecordWhereCheckIsSenior(MaintenanceCheck check)
        {
            if (check == null)
                return null;
            List<MaintenanceCheck> aircraftScheduleChecks =
                Items.Where(c => c.Schedule == check.Schedule &&
                                 c.ParentAircraftId == check.ParentAircraftId &&
                                 c.Grouping == check.Grouping &&
                                 c.Resource == check.Resource).ToList();

            List<MaintenanceCheckRecordGroup> checkGroupsCollections = new List<MaintenanceCheckRecordGroup>();

            foreach (MaintenanceCheck checkItem in aircraftScheduleChecks)
            {
                foreach (MaintenanceCheckRecord record in checkItem.PerformanceRecords)
                {
                    //Поиск коллекции групп, в которую входят группы с нужными критериями
                    //по плану, группировка и основному ресурсу
                    MaintenanceCheckRecordGroup collection = checkGroupsCollections
                        .FirstOrDefault(g => g.Schedule == check.Schedule &&
                                             g.Grouping == check.Grouping &&
                                             g.Resource == check.Resource &&
                                             g.GroupComplianceNum == record.NumGroup);
                    if (collection != null)
                    {
                        //Коллекция найдена
                        collection.Records.Add(record);
                    }
                    else
                    {
                        //Коллекции с нужными критериями нет
                        //Созадние и добавление
                        collection = new MaintenanceCheckRecordGroup(check.Schedule, check.Grouping, check.Resource, record.NumGroup);
                        collection.Records.Add(record);
                        checkGroupsCollections.Add(collection);
                    } 
                } 
            }

            MaintenanceCheckRecordGroup result = checkGroupsCollections
                    .OrderByDescending(cg => cg.GroupComplianceNum)
                    .FirstOrDefault(cg => cg.CheckIsSenior(check));

            return result == null ? null : result.Records.FirstOrDefault(r=>r.ParentId == check.ItemId);
        }
        #endregion

        #region public MaintenanceCheck GetMinStepCheck(bool schedule)
        /// <summary>
        /// Возвращает чек с минимальным интервалом
        /// </summary>
        public MaintenanceCheck GetMinStepCheck(bool schedule)
        {
            List<MaintenanceCheck> list;
            if (schedule)
            {
                list =
               (from check in Items
                where check.Schedule == schedule
                orderby check.Interval.Hours
                select check).ToList();
            }
            else
            {
                list =
               (from check in Items
                where check.Schedule == schedule
                orderby check.Interval.Days
                select check).ToList();
            }
            return list.FirstOrDefault();
        }
        #endregion

        #region public MaintenanceCheck GetMinStepCheck(bool schedule, bool grouping, LifelengthSubResource resource, MaintenanceCheckType mct = null)
        /// <summary>
        /// Возвращает чек с минимальным интервалом
        /// </summary>
        public MaintenanceCheck GetMinStepCheck(bool schedule, bool grouping, LifelengthSubResource resource, MaintenanceCheckType mct = null)
        {
            if(mct != null)
            {
                List<MaintenanceCheck> list =
                        (from check in Items
                         where check.Schedule == schedule 
                            && check.Grouping == grouping 
                            && check.Resource == resource
                            && check.CheckType == mct
                         orderby check.Interval.GetSubresource(resource)
                         select check).ToList();
                return list.FirstOrDefault();    
            }
            else
            {
                List<MaintenanceCheck> list = 
                        (from check in Items
                         where check.Schedule == schedule && check.Grouping == grouping && check.Resource == resource
                         orderby check.Interval.GetSubresource(resource)
                         select check).ToList();
                return list.FirstOrDefault();
            }
        }

        #endregion

        #region public Int32 GetMaxGroupNumber()
        public Int32 GetMaxGroupNumber(Int32 aircraftId, bool maintenanceType)
        {
            Int32 maxGroupNum = 0;
            foreach (MaintenanceCheck check in Items)
            {
                if (check.ParentAircraftId == aircraftId && check.Schedule == maintenanceType &&
                    check.LastPerformance != null && check.LastPerformance.NumGroup > maxGroupNum)
                    maxGroupNum = check.LastPerformance.NumGroup;
            }
            return maxGroupNum;
        }
        #endregion
    }
}
