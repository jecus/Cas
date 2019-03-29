using System;
using System.Linq;
using SmartCore.Calculations.Maintenance;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace SmartCore.Calculations
{
    /// <summary>
    /// Класс, описывает след выполнение задачи по обслуживанию
    /// </summary>
    [Serializable]
    public class MaintenanceNextPerformance : NextPerformance
    {
        #region public bool CalcForHight { get; set; }
        /// <summary>
        /// Флаг, что данное выполнение калькулировано вышестоящим чеком
        /// </summary>
        public bool CalcForHight { get; set; }
        #endregion

        #region public int PerformanceGroupNum { get; set; }
        /// <summary>
        /// номер группы выполнения 
        /// </summary>
        public int PerformanceGroupNum { get; set; }
        #endregion

        #region public MaintenanceCheckGroup PerformanceGroup { get; set; }
        /// <summary>
        /// номер группы выполнения 
        /// </summary>
        public MaintenanceCheckGroupByType PerformanceGroup { get; set; }
        #endregion

        #region public override string Title { get; }
        /// <summary>
        /// Возвращает НАЗВАНИЕ выполнения (как правило, берется описание род. задачи)
        /// </summary>
        public override string Title
        {
            get
            {
                string res = "";
#if KAC
                if (PerformanceGroup == null) return res;
                res += PerformanceGroup.GetGroupName();

                MaintenanceCheck maxCheck = PerformanceGroup.GetMinIntervalCheck();

                if (maxCheck != null &&
                    maxCheck.ParentAircraft != null && 
                    maxCheck.ParentAircraft.MSG < MSG.MSG3)
                {
                    PerformanceGroup.Sort(true);
                    res += " (";
                    res = PerformanceGroup.Checks.Aggregate(res, (current, check) => current + (check + " "));
                    res += ") ";
                }
#else
                if (PerformanceGroup == null || PerformanceGroup.GetMaxIntervalCheck() == null) return res;
                MaintenanceCheck maintenanceCheck = PerformanceGroup.GetMaxIntervalCheck();
                res += maintenanceCheck + (maintenanceCheck.Schedule ? " Schedule" : " Store");

                if (PerformanceGroup.Checks.Count == 1) return res;
                PerformanceGroup.Sort(true);

                res += " (";
                res = PerformanceGroup.Checks.Aggregate(res, (current, check) => current + (check + " "));
                res += ") ";
#endif
                return res;
            }
        }
        #endregion

        #region public override ICommonCollection<Kit> Kits { get; }
        /// <summary>
        /// Возвращает КИТы выполнения (как правило, берется из род. задачи)
        /// </summary>
        public override ICommonCollection<AccessoryRequired> Kits
        {
            get
            {
                CommonCollection<AccessoryRequired> res = new CommonCollection<AccessoryRequired>();
                if (PerformanceGroup == null) return res;
                foreach (MaintenanceCheck check in PerformanceGroup.Checks)
                {
                    res.AddRange(check.Kits.ToArray());
                }
                return res;
            }
        }
        #endregion

        #region public override string KitsToString { get; }
        /// <summary>
        /// Возвращает КИТы выполнения (как правило, берется из род. задачи)
        /// </summary>
        public override string KitsToString
        {
            get
            {
                string res = "";
                if (Kits.Count == 0) return res;
                PerformanceGroup.Sort(true);

                res = Kits.Count + " kits";
                if (PerformanceGroup.Checks.Count == 1) return res;

                res += " (";
                res = PerformanceGroup.Checks.Where(check => check.Kits.Count > 0).
                    Aggregate(res, (current, check) => current + (" " + check.Name + ":" + check.Kits.Count));
                res += " )";
                return res;
            }
        }
        #endregion

        #region public MaintenanceNextPerformance()
        public MaintenanceNextPerformance()
        {
            CalcForHight = false;
        }
        #endregion

        #region public override string ToString()

        public override string ToString()
        {
            string result = "";
            if (PerformanceDate != null)
                result = Auxiliary.Convert.GetDateFormat(PerformanceDate.Value) + " ";
            if (PerformanceDate != null && !PerformanceSource.IsNullOrZero())
            {
                MaintenanceCheck mc = Parent as MaintenanceCheck;
                if(mc != null)
                {
                    result += PerformanceSource.ToString(mc.Resource);
                }
                else result += PerformanceSource.ToString();
            }
            return result;
        }
        #endregion
    }
}
