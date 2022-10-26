using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

            var repeat = Lifelength.Null;
            if (record.Settings.LastCompliances != null && record.Settings.LastCompliances.Any())
            {
                var last = record.Settings.LastCompliances.OrderBy(i => i.LastDate).Last();
                if (last.IsRepeat)
                    repeat = last.Repeat;
            }
            else repeat = record.Education?.Task?.Repeat;
            
            if (repeat != null && (bool)repeat?.Days.HasValue)
            {
                if (to.HasValue)
                {
                    record.Settings.NextCompliances = new List<NextCompliance>();
                    NextCompliance next = null;
                    if (record.Settings.LastCompliances != null && record.Settings.LastCompliances.Any())
                    {
                        var last = record.Settings.LastCompliances.OrderBy(i => i.LastDate).Last().LastDate;
                        next = _calculate(last.Value, repeat);
                        record.Settings.NextCompliances.Add(next);


                        while (next.NextDate.Value <= to.Value)
                        {
                            next = _calculate(next.NextDate.Value, repeat);
                            record.Settings.NextCompliances.Add(next);
                        }
                        
                    }
                    else return;
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


        public static T DeepClone<T>(this T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T) formatter.Deserialize(ms);
            }
        }
        
        private static NextCompliance _calculate(DateTime lastDate, Lifelength repeat)
        {
            var res = new NextCompliance();
            res.NextDate = lastDate.AddDays(repeat.Days.Value);
            //Считаем Remain
            var days = (res.NextDate.Value - DateTime.Today).Days;
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