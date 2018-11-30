using System;
using System.Collections.Generic;
using System.Linq;
using SmartCore.Auxiliary;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.MaintenanceWorkscope;
using Convert = System.Convert;

namespace SmartCore.Calculations.Maintenance
{
    /// <summary>
    /// Представляет список чеков сгруппированных по ресурсу выполнения
    /// <br/>Возможна дополнительная группировка по ресурсу (часы, циклы, дни)  
    /// <br/>и по признаку группирутся/НЕ группируется (с другими чеками по ресурсу выполнения)
    /// </summary>
    public class MaintenanceCheckComplianceGroup
    {
        #region Properties
        /// <summary>
        /// Колекция чеков для этой группы
        /// </summary>
        public List<MaintenanceCheck> Checks { get; set; }

        /// <summary>
        /// номер группы выполнения данных чеков; 
        /// </summary>
        public int GroupComplianceNum { get; set; }

        /// <summary>
        /// Указывает на вышестоящую группу чеков 
        /// </summary>
        public MaintenanceCheckGroupByType ParentGroup { get; set; }
        
        /// <summary>
        /// Цикл текущего типа чеков
        /// </summary>
        public int CheckCycle { get; set; }

        public bool Schedule { get; set; }

        public bool Grouping { get; set; }

        public LifelengthSubResource Resource { get; set; }

        #region public DateTime LastGroupComplianceDate
        /// <summary>
        /// Возвращает дату самого последнего выполнения в данной группе чеков, или Datetime.MinValue
        /// </summary>
        public DateTime LastGroupComplianceDate
        {
            get
            {
                List<MaintenanceCheckRecord> list =
                    Checks.Where(c => c.LastPerformance != null)
                          .OrderByDescending(c => c.LastPerformance.RecordDate)
                          .Select(c => c.LastPerformance)
                          .ToList();
                if (list.Count > 0 && list[0] != null)
                {
                    return list[0].RecordDate;
                }
                return DateTime.MinValue;
            }
        }
        #endregion

        #region public Lifelength LastGroupComplianceLifelength
        /// <summary>
        /// Возвращает ресурс на котором было сделано последнее выполнение в данной группе чеков
        /// </summary>
        public Lifelength LastGroupComplianceLifelength
        {
            get
            {
                List<MaintenanceCheckRecord> list =
                    Checks.Where(c => c.LastPerformance != null)
                          .OrderByDescending(c => c.LastPerformance.RecordDate)
                          .Select(c => c.LastPerformance)
                          .ToList();
                if (list.Count > 0 && list[0] != null)
                {
                    return list[0].OnLifelength;
                }
                return Lifelength.Null;
            }
        }
        #endregion

        #region public int LastComplianceGroupNum
        /// <summary>
        /// Возвращает номер группы на котором было сделано последнее выполнение в данной группе чеков
        /// </summary>
        public int LastComplianceGroupNum
        {
            get
            {
                List<MaintenanceCheckRecord> list;
                if (Schedule)
                {
                    list =
                 (from check in Checks
                  where check.LastPerformance != null
                  orderby check.LastPerformance.RecordDate descending
                  select check.LastPerformance).ToList();
                }
                else
                {
                    list =
                 (from check in Checks
                  where check.LastPerformance != null
                  orderby check.LastPerformance.RecordDate descending
                  select check.LastPerformance).ToList();
                }
                if (list.Count > 0 && list[0] != null)
                {
                    return list[0].NumGroup;
                }
                return 0;
            }
        }
        #endregion

        #region public string Remarks
        /// <summary>
        /// Возвращает Заметку к последнему выполнению, или пестую строку если его нет
        /// </summary>
        public string Remarks
        {
            get
            {
                if (Checks.Count == 0 || Checks[0].LastPerformance == null) return "";
                
                return Checks[0].LastPerformance.Remarks;
            }
        }
        #endregion

        #endregion

        #region public MaintenanceCheckComplianceGroup(bool schedule)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schedule"></param>
        public MaintenanceCheckComplianceGroup(bool schedule)
        {
            Schedule = schedule;
            Checks = new List<MaintenanceCheck>();
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            if (Checks.Count == 0)
            {
                return "0";
            }

            return string.Format("Type:{0}  Count:{1}  IsHasParent:{2}  CheckCycle:{3}",
                Checks[0].CheckType.FullName, Checks.Count, ParentGroup != null, CheckCycle);
        }

        public string ToStringCheckNames()
        {
            if (Checks.Count == 0)
            {
                return "";
            }
            return Checks.Aggregate("", (current, check) => current + (check.Name + " "));
        }

        #region public void Sort(bool descending = false)
        /// <summary>
        /// Производит сортировку чеков в зависимости от значения своиства Resource. 
        /// </summary>
        public void Sort(bool descending = false)
        {
            if (Checks == null)
            {
                return;
            }
            if (descending)
            {
                Checks = (from check in Checks
                          orderby check.Interval.GetSubresource(Resource) descending
                          select check).ToList();
            }
            else
            {
                Checks = (from check in Checks
                          orderby check.Interval.GetSubresource(Resource)
                          select check).ToList();
            }
        }
        #endregion

        #region public MaintenanceCheck GetMaxIntervalCheck()
        /// <summary>
        /// Возвращает чек с максимальным интервалом выполнения
        /// </summary>
        /// <returns>Объект MaintenanceCheck или null</returns>
        public MaintenanceCheck GetMaxIntervalCheck()
        {
            if (Checks == null || Checks.Count == 0)
            {
                return null;
            }

            Sort();

            return Checks.Last();
        }

        #endregion

        #region public MaintenanceCheck GetMinIntervalCheck()
        /// <summary>
        /// Возвращает чек с минимальным интервалом выполнения
        /// </summary>
        /// <returns>Объект MaintenanceCheck или null</returns>
        public MaintenanceCheck GetMinIntervalCheck()
        {
            if (Checks == null || Checks.Count == 0)
            {
                return null;
            }

            Sort();

            return Checks.First();
        }
        #endregion

        #region public MaintenanceCheck GetMinIntervalCheck(MaintenanceCheckType checkType)
        /// <summary>
        /// Возвращает чек с максимальным интервалом выполнения заданного типа
        /// </summary>
        /// <returns>Объект MaintenanceCheck или null</returns>
        public MaintenanceCheck GetMinIntervalCheck(MaintenanceCheckType checkType)
        {
            if (Checks == null || Checks.Count == 0)
            {
                return null;
            }

            Sort();

            return Checks.FirstOrDefault(c => c.CheckType == checkType);
        }

        #endregion

        #region public List<MaintenanceCheck> GetLastComplianceChecks()
        /// <summary>
        /// Возвращает чеки имеющие последнее выполнение 
        /// <br/> часть ресурса (заданное полем Resource) последнего выполнения которых не равна Null
        /// <br/> и упорядоченную по части ресурса выполнения
        /// </summary>
        /// <returns>список Чеков или пустой список</returns>
        public List<MaintenanceCheck> GetLastComplianceChecks()
        {
            List<MaintenanceCheck> checkLast =
                Checks.Where(check => check.LastPerformance != null &&
                                      check.LastPerformance.OnLifelength != null &&
                                      check.LastPerformance.OnLifelength.GetSubresource(check.Resource) != null)
                      .OrderBy(check => check.Interval.GetSubresource(check.Resource))
                      .ToList();
            return checkLast;
        }
        #endregion

        /// <summary>
        /// Самое последние выполнение в этой группе
        /// </summary>
        /// <returns>hours</returns>
        public int MaxCompliance()
        {
            List<int?> list;
            if (Schedule)
            {
                list =
             (from check in Checks
              where check.LastPerformance != null
              orderby check.LastPerformance.OnLifelength.Hours descending
              select check.LastPerformance.OnLifelength.Hours).ToList();
            }
            else
            {
                list =
             (from check in Checks
              where check.LastPerformance != null
              orderby check.LastPerformance.OnLifelength.Days descending
              select check.LastPerformance.OnLifelength.Days).ToList();
            }
            if (list.Count > 0 && list[0] != null)
            {
                return Convert.ToInt32(list[0]);
            }
            return -1;
        }

        #region public bool CheckIsSenior(MaintenanceCheck check)
        public bool CheckIsSenior(MaintenanceCheck check)
        {
            if (check == null || GetMaxIntervalCheck() == null) return false;
            return GetMaxIntervalCheck().ItemId == check.ItemId;
        }
        #endregion

        #region public string GetGroupName()
        /// <summary>
        /// Возвращает имя группы
        /// <br/> имя группы составляется из номера группы = (Макс % Мин чек высшего приоритета)
        /// <br/> т имени высшего типа чеков Н 10А или 5С
        /// </summary>
        /// <returns>Название группы чеков или пустую строку</returns>
        public string GetGroupName()
        {
            MaintenanceCheck maxCheck = GetMaxIntervalCheck();
            if (maxCheck == null)
                return "";
            if (maxCheck.ParentAircraft == null ||
                maxCheck.ParentAircraft.MaintenanceProgramCheckNaming == false)
                return maxCheck.Name;
            MaintenanceCheck minCheckSameType = GetMinIntervalCheck(maxCheck.CheckType);
            if (minCheckSameType == null)
                return maxCheck.Name;
            MaintenanceCheck minIntervalCheck = GetMinIntervalCheck();
            if (minIntervalCheck == null)
                return maxCheck.Name;
            int countMinStepsInCurrCheckCycle = CheckCycle / Convert.ToInt32(minIntervalCheck.Interval.GetSubresource(maxCheck.Resource));
            int countMinStepsOnLowerCheckCycle = Convert.ToInt32(minCheckSameType.Interval.GetSubresource(maxCheck.Resource)) /
                                                 Convert.ToInt32(minIntervalCheck.Interval.GetSubresource(maxCheck.Resource));
            if (countMinStepsInCurrCheckCycle == 0 || countMinStepsOnLowerCheckCycle == 0)
                return maxCheck.Name;
            int numStepOnCurrCheckCycle = GroupComplianceNum % countMinStepsInCurrCheckCycle;
            string suffix = maxCheck.CheckType.ShortName;
            if (numStepOnCurrCheckCycle == 0)
            {
                return GroupComplianceNum / (GroupComplianceNum / countMinStepsInCurrCheckCycle * countMinStepsOnLowerCheckCycle)
                    + suffix;
            }
            int num = numStepOnCurrCheckCycle % countMinStepsOnLowerCheckCycle;
            return num <= 0
                ? (numStepOnCurrCheckCycle / countMinStepsOnLowerCheckCycle) + suffix
                : num + suffix;
        }

        #endregion

        #region public string GetComplianceGroupName()
        /// <summary>
        /// Возвращает имя последней группы выполнения группы
        /// </summary>
        /// <returns>Имя последней группы выполнения группы</returns>
        public string GetComplianceGroupName()
        {
            MaintenanceCheck maxCheck = GetMaxIntervalCheck();
            if (maxCheck == null)
                return "";
            MaintenanceCheckRecord mcr = maxCheck.PerformanceRecords.FirstOrDefault(r => r.NumGroup == GroupComplianceNum);
            if (mcr == null || string.IsNullOrEmpty(mcr.ComplianceCheckName))
                return maxCheck.Name;

            return mcr.ComplianceCheckName;
        }

        #endregion

        #region public DateTime GetNextComplianceDate()

        public DateTime GetNextComplianceDate()
        {
            if (GetMaxIntervalCheck() == null)
                return DateTimeExtend.GetCASMinDateTime();
            Sort();

            DateTime nextDate = DateTimeExtend.GetCASMinDateTime();
            if (Grouping)
            {
                MaintenanceCheck lastOrMinCheck =
                    GetLastComplianceChecks().FirstOrDefault() != null
                        ? GetLastComplianceChecks().First()
                        : GetMinIntervalCheck();
                if (lastOrMinCheck.Interval.Days != null && lastOrMinCheck.Interval.Days > 0)
                {
                    nextDate = lastOrMinCheck.NextPerformances.Count != 0 && lastOrMinCheck.NextPerformances[0].PerformanceDate != null
                                            ? lastOrMinCheck.NextPerformances[0].PerformanceDate.Value
                                            : lastOrMinCheck.LastPerformance != null
                                                  ? lastOrMinCheck.LastPerformance.RecordDate.AddDays(Convert.ToInt32(lastOrMinCheck.Interval.Days))
                                                  : lastOrMinCheck.ParentAircraft.ManufactureDate.AddDays(Convert.ToInt32(lastOrMinCheck.Interval.Days));
                }
                else
                {

                    nextDate = lastOrMinCheck.NextPerformances.Count != 0 &&
                               lastOrMinCheck.NextPerformances[0].PerformanceDate != null
                        ? lastOrMinCheck.NextPerformances[0].PerformanceDate.Value
                        : DateTimeExtend.GetCASMinDateTime();
                }

            }
            else
            {
                foreach (MaintenanceCheck maintenanceCheck in Checks)
                {
                    if (maintenanceCheck.Interval.Days != null && maintenanceCheck.Interval.Days > 0)
                    {
                        nextDate =
                            maintenanceCheck.NextPerformances.Count != 0 && maintenanceCheck.NextPerformances[0].PerformanceDate != null
                                            ? maintenanceCheck.NextPerformances[0].PerformanceDate.Value
                                            : maintenanceCheck.LastPerformance != null
                                                  ? maintenanceCheck.LastPerformance.RecordDate.AddDays(Convert.ToInt32(maintenanceCheck.Interval.Days))
                                                  : maintenanceCheck.ParentAircraft.ManufactureDate.AddDays(Convert.ToInt32(maintenanceCheck.Interval.Days));
                    }
                    else
                    {
                        nextDate = maintenanceCheck.NextPerformanceDate != null
                            ? maintenanceCheck.NextPerformanceDate.Value
                            : DateTimeExtend.GetCASMinDateTime();
                    }
                }
            }

            return nextDate;
        }
        #endregion

        #endregion
    }
}
