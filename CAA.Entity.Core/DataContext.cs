
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

		public DbSet<CAAAttachedFileDTO> AttachedFileDtos { get; set; }
        public DbSet<CAAItemFileLinkDTO> ItemFileLinkDtos { get; set; }
		public DbSet<CAAUserDTO> UserDtos { get; set; }
        public DbSet<CAAOperatorDTO> OperatorDtos { get; set; }

		#endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CAAItemFileLinkDTO>()
                .HasOne(i => i.File)
                .WithMany(i => i.ItemFileLinkDto)
                .HasForeignKey(i => i.FileId);
		}

	}
}