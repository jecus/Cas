using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAA.Entity.Models.DTO
{
    [Table("Users", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class CAAUserDTO : BaseEntity, IIdentityUser
	{
		
		[Column("Name"), MaxLength(100)]
		public string Name { get; set; }

		
		[Column("Surname"), MaxLength(100)]
		public string Surname { get; set; }

		
		[Column("Login"), MaxLength(100)]
		public string Login { get; set; }

		
		[Column("Password"), MaxLength(100)]
		public string Password { get; set; }

        [Column("CAAUserType")]
		public CAAUserType CAAUserType { get; set; }

		[NotMapped]
		public UserType UserType { get; set; }

        [NotMapped]
        public UiType UiType { get; set; }
        [Column("PersonnelId")]
		public int PersonnelId { get; set; }

		[NotMapped]
        public int OperatorId { get; set; }


        public override string ToString()
		{
			return Name.Equals(Surname) ? Name : $"{Surname} {Name}";
		}
	}
}