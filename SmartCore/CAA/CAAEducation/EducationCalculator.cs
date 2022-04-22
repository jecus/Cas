using System;
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
            
            if ((bool)record.Settings?.Repeat?.Days.HasValue)
                record.Settings.Next = record.Settings.StartDate.AddDays(record.Settings.Repeat.Days.Value);

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