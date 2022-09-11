using System;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.CAA.Repositories
{
    public interface ICaaPerformanceRepository
    {
        void CalcRemain(ILightRemain parent, DateTime issueDateValidTo, Lifelength notify = null, Lifelength repeat = null);
        Lifelength CalcRemain(DateTime issueDateValidTo, Lifelength repeat = null);
        void GetNextPerformance(SmartCore.Entities.General.Document directive);
    }

    public interface ILightRemain
    {
        Lifelength Remain { get; set; }
        ConditionState Condition { get; set; }
    }
}