using System;

namespace SmartCore.CAA.CAAEducation
{
    public static class EducationCalculator
    {
        public static void CalculateEducation(CAAEducationRecord record)
        {
            if(record == null)
                    return;
            
            if ((bool)record.Settings?.Repeat?.Days.HasValue)
                record.Settings.Next = record.Settings.StartDate.AddDays(record.Settings.Repeat.Days.Value);
            
        }
    }
}