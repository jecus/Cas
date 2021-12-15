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

        public DbSet<UserDTO> UserDtos { get; set; }

        #endregion
    }
}