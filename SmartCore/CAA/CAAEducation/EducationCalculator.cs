using System;
using System.Linq;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.CAA.CAAEducation
{
    public static class EducationCalculator
    {
        private readonly static int _notify = 7;
        
        public static void CalculateEducation(CAAEducationRecord record, DateTime? to = null)
        {
            if(record == null)
                return;
            
            if(record.Settings.IsClosed)
                return;

            var repeat = record.Education?.Task?.Repeat;
            
            if (repeat != null && (bool)repeat?.Days.HasValue)
            {
                if (to.HasValue)
                {

                }
                else
                {
                    record.Settings.NextCompliance = new NextCompliance();

                    if (record.Settings.LastCompliances != null && record.Settings.LastCompliances.Any())
                    {
                        var last = record.Settings.LastCompliances.OrderBy(i => i.LastDate).Last().LastDate;
                        record.Settings.NextCompliance = _calculate(last.Value,repeat);
                    }
                    else return;
                }
            }
        }


        private static NextCompliance _calculate(DateTime lastDate, Lifelength repeat)
        {
            var res = new NextCompliance();
            res.Next = lastDate.AddDays(repeat.Days.Value);
            //Считаем Remain
            var days = (res.Next.Value - DateTime.Today).Days;
            res.Remains = new Lifelength(days, null, null);

            if (res.Remains.Days < 0)
                res.Condition = ConditionState.Overdue;
            else if (res.Remains.Days >= 0 && res.Remains.Days <= _notify)
                res.Condition = ConditionState.Notify;
            else res.Condition = ConditionState.Satisfactory;

            return res;
        }
    }
}