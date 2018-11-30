using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SmartCore.Auxiliary;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace SmartCore.Calculations.Maintenance
{
    /// <summary>
    /// Представляет список чеков сгруппированных по ресурсу выполнения
    /// <br/> Возможна дополнительная группировка по ресурсу (часы, циклы, дни)  
    /// <br/> и по признаку группирутся/НЕ группируется (с другими чеками по ресурсу выполнения)
    /// </summary>
    public class MaintenanceCheckRecordGroup : IEnumerable<MaintenanceCheckRecord>
    {
        #region Properties

        private List<MaintenanceCheckRecord> _records = new List<MaintenanceCheckRecord>();
        /// <summary>
        /// Коллекция записей о выполнении чеков
        /// </summary>
        public List<MaintenanceCheckRecord> Records
        {
            get { return _records; }
        }

        /// <summary>
        /// номер группы выполнения данных чеков; 
        /// </summary>
        public int GroupComplianceNum { get; set; }

        /// <summary>
        /// Указывает на вышестоящую группу чеков 
        /// </summary>
        public MaintenanceCheckGroupByType ParentGroup { get; set; }

        /// <summary>
        /// кол-во групп в цикле
        /// </summary>
        public int GroupCountCycle { get; set; }

        /// <summary>
        /// Локальное значение последнего выполнение для этой группы
        /// т.е. если фактическое выполнение было на 6502ч и 
        /// есть вышестоящяя группа чеков которая была выполнена на 6000ч
        /// то локальное значение буде равно 502ч (6502-6000)
        /// это нужно для синхронизации с таблицей обслуживания (maintenance schedule)
        /// </summary>
        public int LocalLastCompliance { get; set; }

        public bool Schedule { get; set; }

        public bool Grouping { get; set; }

        public LifelengthSubResource Resource { get; set; }

        public MaintenanceCheckType CheckType { get; set; }

        private int MinStep { get; set; }

        public DateTime GroupComplianceDate { get; set; }

        /// <summary>
        /// Ресурс, на котором должна выполнится данная группа
        /// </summary>
        public Lifelength GroupComplianceLifelength { get; set; }

        #region public DateTime LastGroupComplianceDate
        /// <summary>
        /// Возвращает дату самого последнего выполнения в данной группе записей, или Datetime.MinValue
        /// </summary>
        public DateTime LastGroupComplianceDate
        {
            get
            {
                Sort(true);

                if (Records.Count > 0 && Records[0] != null)
                {
                    return Records[0].RecordDate;
                }
                return DateTimeExtend.GetCASMinDateTime();
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
                Sort(true);
                if (Records.Count > 0 && Records[0] != null)
                {
                    return Records[0].OnLifelength;
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
                Sort(true);
                if (Records.Count > 0 && Records[0] != null)
                {
                    return Records[0].NumGroup;
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
                if (Records.Count == 0 || Records[0] == null) return "";
                
                return Records[0].Remarks;
            }
        }
        #endregion

        #endregion

        #region private MaintenanceRecordGroup()
        /// <summary>
        /// 
        /// </summary>
        private MaintenanceCheckRecordGroup()
        {
        }

        #endregion

        #region public MaintenanceCheckRecordGroup(bool schedule, bool grouping, LifelengthSubResource resource) : this()
        /// <summary>
        /// 
        /// </summary>
        public MaintenanceCheckRecordGroup(bool schedule, bool grouping, LifelengthSubResource resource) : this()
        {
            Schedule = schedule;
            Grouping = grouping;
            Resource = resource;
        }

        #endregion

        #region public MaintenanceCheckRecordGroup(bool schedule, bool grouping, LifelengthSubResource resource, int numGroup) : this()
        /// <summary>
        /// 
        /// </summary>
        public MaintenanceCheckRecordGroup(bool schedule, bool grouping, LifelengthSubResource resource, int numGroup)
            : this()
        {
            Schedule = schedule;
            Grouping = grouping;
            Resource = resource;
            GroupComplianceNum = numGroup;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            if (Records.Count == 0)
            {
                return "";
            }

            return string.Format("{0}  Date:{1}", !string.IsNullOrEmpty(Records[0].ComplianceCheckName) 
                                                    ? Records[0].ComplianceCheckName
                                                    : GetMaxIntervalCheck() != null 
                                                        ? GetMaxIntervalCheck().Name 
                                                        : "", 
                                                   Auxiliary.Convert.GetDateFormat(Records[0].RecordDate));
        }

        public string ToStringCheckNames()
        {
            return Records.Count == 0 
                ? "" 
                : Records.Aggregate("", (current, record) => current + (record.ParentCheck.Name + " "));
        }

        #region public void Sort(bool descending = false)
        /// <summary>
        /// Производит сортировку чеков в зависимости от значения своиства Resource. 
        /// </summary>
        public void Sort(bool descending = false)
        {
            if (_records == null)
            {
                return;
            }
            _records = descending
                ? _records.OrderByDescending(r => r.RecordDate).ToList()
                : _records.OrderBy(r => r.RecordDate).ToList();
        }

        #endregion

        #region public MaintenanceCheck GetMaxIntervalCheck()
        /// <summary>
        /// Возвращает чек с максимальным интервалом выполнения
        /// </summary>
        /// <returns>Объект MaintenanceCheck или null</returns>
        public MaintenanceCheck GetMaxIntervalCheck()
        {

            if (Records == null || Records.Count == 0)
            {
                return null;
            }

            return Records.Where(r => r.ParentCheck != null)
                          .Select(r => r.ParentCheck)
                          .OrderBy(c => c.Interval.GetSubresource(Resource))
                          .LastOrDefault();
        }

        #endregion

        #region public MaintenanceCheck GetMinIntervalCheck()
        /// <summary>
        /// Возвращает чек с минимальным интервалом выполнения
        /// </summary>
        /// <returns>Объект MaintenanceCheck или null</returns>
        public MaintenanceCheck GetMinIntervalCheck()
        {
            if (Records == null || Records.Count == 0)
            {
                return null;
            }

            return Records.Where(r => r.ParentCheck != null)
                          .Select(r => r.ParentCheck)
                          .OrderBy(c => c.Interval.GetSubresource(Resource))
                          .FirstOrDefault();
        }
        #endregion

        #region public MaintenanceCheck GetMinIntervalCheck(MaintenanceCheckType checkType)
        /// <summary>
        /// Возвращает чек с максимальным интервалом выполнения заданного типа
        /// </summary>
        /// <returns>Объект MaintenanceCheck или null</returns>
        public MaintenanceCheck GetMinIntervalCheck(MaintenanceCheckType checkType)
        {
            if (Records == null || Records.Count == 0)
            {
                return null;
            }

            return Records.Where(r => r.ParentCheck != null && r.ParentCheck.CheckType == checkType)
                          .Select(r => r.ParentCheck)
                          .OrderBy(c => c.Interval.GetSubresource(Resource))
                          .FirstOrDefault();
        }

        #endregion

        #region public MaintenanceCheckRecord GetMinIntervalCheckRecord()
        /// <summary>
        /// Возвращает чек с минимальным интервалом выполнения
        /// </summary>
        /// <returns>Объект MaintenanceCheck или null</returns>
        public MaintenanceCheckRecord GetMinIntervalCheckRecord()
        {
            MaintenanceCheck minCheck = GetMinIntervalCheck();
            if (minCheck == null)
            {
                return null;
            }

            return Records.Where(r => r.ParentCheck == minCheck)
                          .OrderBy(r => r.RecordDate)
                          .LastOrDefault();
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
                Records.Where(record => record.OnLifelength != null &&
                                        record.OnLifelength.GetSubresource(record.ParentCheck.Resource) != null)
                       .OrderBy(record => record.ParentCheck.Interval.GetSubresource(record.ParentCheck.Resource))
                       .Select(record => record.ParentCheck)
                       .ToList();
            return checkLast;
        }
        #endregion

        #region public bool CheckIsSenior(MaintenanceCheck check)
        public bool CheckIsSenior(MaintenanceCheck check)
        {
            if (check == null || GetMaxIntervalCheck() == null) return false;
            return GetMaxIntervalCheck().ItemId == check.ItemId;
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
            return Records.GetEnumerator();
        }
        #endregion

        #region IEnumerator<MaintenanceCheckRecord> IEnumerable<MaintenanceCheckComplianceGroup>.GetEnumerator()
        /// <summary>
        /// Возвращает перечислитель, выполняющий перебор элементов в коллекции.
        /// </summary>
        /// <returns>
        /// Интерфейс <see cref="T:System.Collections.Generic.IEnumerator`1"/>, который может использоваться для перебора элементов коллекции.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<MaintenanceCheckRecord> GetEnumerator()
        {
            return Records.GetEnumerator();
        }
        #endregion

        #endregion
    }
}
