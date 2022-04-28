using System;
using System.Linq;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.CAA.CAAEducation
{
    public static class EducationCalculator
    {
        private readonly static int _notify = 7;
        
        public static void CalculateEducation(CAAEducationRecord record)
        {
            if(record == null)
                return;
            
            if(record.Settings.IsClosed)
                return;
            
            if(record.Education == null)
                return;

            var repeat = record.Education.Task.Repeat;
            
            
            if (repeat != null &&(bool)repeat?.Days.HasValue)
            {
                if (record.Settings.LastCompliances != null && record.Settings.LastCompliances.Any())
                {
                    var last = record.Settings.LastCompliances.OrderBy(i => i.LastDate).Last().LastDate;
                    record.Settings.Next = last.Value.AddDays(repeat.Days.Value);
                }
                else return;
            }
            
            if (record.Settings.Next.HasValue)
            {
                var days = (record.Settings.Next.Value - DateTime.Today).Days;
                record.Settings.Remains = new Lifelength(days, null, null);
                
                if(record.Settings.Remains.Days < 0)
                    record.Settings.Condition = ConditionState.Overdue;
                else if (record.Settings.Remains.Days >= 0 && record.Settings.Remains.Days <= _notify)
                    record.Settings.Condition = ConditionState.Notify;
                else record.Settings.Condition = ConditionState.Satisfactory;
            }
        }
    }
}