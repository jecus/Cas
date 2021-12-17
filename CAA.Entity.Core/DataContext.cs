using CAA.Entity.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace CAA.Entity.Core
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions opt) : base(opt)
		{
			
		}

        #region dbo

        public DbSet<CAAUserDTO> UserDtos { get; set; }

        #endregion
    }
}