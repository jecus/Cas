using System.Data.Entity;

namespace SmartCore.Tests.DataAccess
{
	public class DataContext : DbContext
	{
		private static readonly string _connectionString = "data source=91.213.233.139;initial catalog=CASDBTest;user id=casadmin;password=casadmin001;MultipleActiveResultSets=True;App=EntityFramework";

		public DataContext() : base(_connectionString)
		{ }

		public IDbSet<NonRoutineJob> NonRoutineJobs { get; set; }
		public IDbSet<ItemFileLink> ItemFileLinks { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new NonRoutineJobMap());
			modelBuilder.Configurations.Add(new ItemFileLinkMap());
		}
	}
}
