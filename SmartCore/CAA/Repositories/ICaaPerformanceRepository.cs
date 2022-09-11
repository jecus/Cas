using System;
using SmartCore.Calculations;

namespace SmartCore.CAA.Repositories
{
    public interface ICaaPerformanceRepository
    {
        Lifelength CalcRemain(DateTime issueDateValidTo, Lifelength repeat = null);
        void GetNextPerformance(SmartCore.Entities.General.Document directive);
    }
}