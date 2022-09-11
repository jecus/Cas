using System;
using SmartCore.Calculations;

namespace SmartCore.CAA.Repositories
{
    public interface ICaaPerformanceRepository
    {
        Lifelength CalcRemain(DateTime issueDateValidTo);
        void GetNextPerformance(SmartCore.Entities.General.Document directive);
    }
}