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
    /// Представляет список чеков сгруппированных по типу (A,B,C,D и т.д.)
    /// <br/>Возможна дополнительная группировка по ресурсу (часы, циклы, дни)  
    /// <br/>и по признаку группирутся/НЕ группируется (с другими чеками по ресурсу выполнения)
    /// </summary>
    public class MaintenanceCheckGroupByType
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
        /// Интервал при котором программа в таблице повторяется.
        /// Например цикл А чеков на боенге 737-800 будет 6000 часов
        /// </summary>
        public int CheckCycle { get; set; }

        public bool Schedule { get; set; }

        public bool Grouping { get; set; }

        public LifelengthSubResource Resource { get; set; }

        public MaintenanceCheckType CheckType { get; set; }

        public DateTime GroupComplianceDate { get; set; }
        /// <summary>
        /// Ресурс, на котором должна выполнится данная группа
        /// </summary>
        public Lifelength GroupComplianceLifelength { get; set; }

        #region public Lifelength LastGroupComplianceLifelength
        /// <summary>
        /// Возвращает ресурс на котором было сделано последнее выполнение в данной группе чеков
        /// </summary>
        public Lifelength LastGroupComplianceLifelength
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

        #region public int LastComplianceGroupDate
        /// <summary>
        /// Возвращает дату последнего выполнения в данной группе чеков
        /// </summary>
        public DateTime LastComplianceGroupDate
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
                    return list[0].RecordDate;
                }
                return DateTimeExtend.GetCASMinDateTime();
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

        #region Initialize

        /// <summary>
        /// 
        /// </summary>
        /// <param name="schedule"></param>
        public MaintenanceCheckGroupByType(bool schedule)
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
                          orderby check.CheckType.Priority descending 
                          orderby check.Interval.GetSubresource(Resource) descending
                          select check).ToList();
            }
            else
            {
                Checks = (from check in Checks
                          orderby check.CheckType.Priority 
                          orderby check.Interval.GetSubresource(Resource)
                          select check).ToList();
            }
        }
        #endregion

        public int MinInterval()
        {
            if (Checks == null || Checks.Count == 0)
            {
                return -1;
            }

            if (Schedule)
            {
                return Checks[0].Interval.Hours ?? -1;
            }
            return Checks[0].Interval.Days ?? -1;
        }

        public int MinIntervalByResource()
        {
            if (Checks == null || Checks.Count == 0)
            {
                return -1;
            }
            return Checks[0].Interval.GetSubresource(Resource) ?? -1;
        }

        public int MaxInterval()
        {
            if (Checks == null || Checks.Count == 0)
            {
                return -1;
            }
            if (Schedule)
            {
                return Checks[Checks.Count - 1].Interval.Hours ?? -1;
            }
            return Checks[Checks.Count - 1].Interval.Days ?? -1;
        }

        public int MaxIntervalByResource()
        {
            if (Checks == null || Checks.Count == 0)
            {
                return -1;
            }
            return Checks[Checks.Count - 1].Interval.GetSubresource(Resource) ?? -1;
        }

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

            return Checks.FirstOrDefault();
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
            string suffix =  maxCheck.CheckType.ShortName;
            if( numStepOnCurrCheckCycle == 0)
            {
                return GroupComplianceNum/(GroupComplianceNum/countMinStepsInCurrCheckCycle*countMinStepsOnLowerCheckCycle)
                    + suffix;
            }
            int num = numStepOnCurrCheckCycle % countMinStepsOnLowerCheckCycle;
            return num <= 0
                ? (numStepOnCurrCheckCycle / countMinStepsOnLowerCheckCycle) + suffix
                : num + suffix;
        }

        #endregion

        #endregion
    }
}
