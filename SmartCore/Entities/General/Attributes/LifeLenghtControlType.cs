using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCore.Entities.General.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class LifeLenghtCalendarOnlyAttribute : Attribute
    {
        public LifeLenghtCalendarOnlyAttribute()
        {
            
        }
    }
}
