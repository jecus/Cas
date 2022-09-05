namespace SmartCore.CAA.Repositories
{
    public interface ICaaPerformanceRepository
    {
        void GetNextPerformance(SmartCore.Entities.General.Document directive);
    }
}