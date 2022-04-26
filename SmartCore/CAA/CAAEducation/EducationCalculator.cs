using System;
using System.Linq;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.CAA.CAAEducation
{
    public static class EducationCalculator
    {
        public static void CalculateEducation(CAAEducationRecord record)
        {
            if(record == null)
                return;
            
            
            if(record.Settings.IsClosed)
                return;
            
            if (record.Settings?.Repeat != null &&(bool)record.Settings?.Repeat?.Days.HasValue)
            {
                if (record.Settings.LastCompliances != null && record.Settings.LastCompliances.Any())
                {
                    var last = record.Settings.LastCompliances.OrderBy(i => i.LastDate).Last().LastDate;
                    record.Settings.Next = last.Value.AddDays(record.Settings.Repeat.Days.Value);
                }
                else
                {
                    record.Settings.Next = record.Settings.StartDate.AddDays(record.Settings.Repeat.Days.Value);
                }
            }
            
            if (record.Settings.Next.HasValue)
            {
                var days = (record.Settings.Next.Value - DateTime.Today).Days;
                record.Settings.Remains = new Lifelength(days, null, null);
                
                if(record.Settings.Remains.Days < 0)
                    record.Settings.Condition = ConditionState.Overdue;
                else if (record.Settings.Remains.Days >= 0 && record.Settings.Remains.Days <= record.Settings.Notify.Days)
                    record.Settings.Condition = ConditionState.Notify;
                else record.Settings.Condition = ConditionState.Satisfactory;
            }
        }
    }
}