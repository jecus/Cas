using System.Collections.Generic;
using System.Linq;
using SmartCore.Calculations;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace SmartCore.Entities.Collections
{
    public static class MaintenanceEnumerableExtention
    {
        #region public MaintenanceCheck GetMaxStepCheck(this IEnumerable<MaintenanceCheck> items, bool schedule)
        /// <summary>
        /// Возвращает чек с максимальным интервалом
        /// </summary>
        public static MaintenanceCheck GetMaxStepCheck(this IEnumerable<MaintenanceCheck> items, bool schedule)
        {
            MaintenanceCheck maxHours =
                items.Where(i => i.Schedule == schedule &&
                                 i.Resource == LifelengthSubResource.Hours &&
                                 i.Interval.Hours != null)
                     .OrderBy(i => i.Interval.Hours)
                     .LastOrDefault();

            MaintenanceCheck maxCycles =
                items.Where(i => i.Schedule == schedule &&
                                 i.Resource == LifelengthSubResource.Cycles &&
                                 i.Interval.Cycles != null)
                     .OrderBy(i => i.Interval.Cycles)
                     .LastOrDefault();

            MaintenanceCheck maxDays =
                items.Where(i => i.Schedule == schedule &&
                                 i.Resource == LifelengthSubResource.Calendar &&
                                 i.Interval.Days != null)
                     .OrderBy(i => i.Interval.Days)
                     .LastOrDefault();

            // Выбираем максимум
            MaintenanceCheck max = null;
            if (maxHours != null) max = maxHours;
            if (maxCycles != null && (max == null || maxCycles.Interval.GetSubresource(maxCycles.Resource) > 
                                      max.Interval.GetSubresource(max.Resource))) max = maxCycles;
            if (maxDays != null && (max == null || maxDays.Interval.GetSubresource(maxDays.Resource) > 
                                    max.Interval.GetSubresource(max.Resource))) max = maxDays;

            return max;
        }
        #endregion

        #region public MaintenanceCheck GetMaxCheck(this IEnumerable<MaintenanceCheck> items)
        /// <summary>
        /// Возвращает чек с максимальным интервалом
        /// </summary>
        public static MaintenanceCheck GetMaxCheck(this IEnumerable<MaintenanceCheck> items)
        {
            MaintenanceCheck maxHours =
                items.Where(i => i.Resource == LifelengthSubResource.Hours &&
                                 i.Interval.Hours != null)
                     .OrderBy(i => i.Interval.Hours)
                     .LastOrDefault();

            MaintenanceCheck maxCycles =
                items.Where(i => i.Resource == LifelengthSubResource.Cycles &&
                                 i.Interval.Cycles != null)
                     .OrderBy(i => i.Interval.Cycles)
                     .LastOrDefault();

            MaintenanceCheck maxDays =
                items.Where(i => i.Resource == LifelengthSubResource.Calendar &&
                                 i.Interval.Days != null)
                     .OrderBy(i => i.Interval.Days)
                     .LastOrDefault();

            // Выбираем максимум
            MaintenanceCheck max = null;
            if (maxHours != null) max = maxHours;
            if (maxCycles != null && (max == null || maxCycles.Interval.GetSubresource(maxCycles.Resource) >
                                      max.Interval.GetSubresource(max.Resource))) max = maxCycles;
            if (maxDays != null && (max == null || maxDays.Interval.GetSubresource(maxDays.Resource) >
                                    max.Interval.GetSubresource(max.Resource))) max = maxDays;

            return max;
        }
        #endregion
    }
}
