﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAA.Entity.Models.DTO
{
    [Table("Users", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class UserDTO : BaseEntity, IIdentityCAAUser
	{
		
		[Column("Name"), MaxLength(100)]
		public string Name { get; set; }

		
		[Column("Surname"), MaxLength(100)]
		public string Surname { get; set; }

		
		[Column("Login"), MaxLength(100)]
		public string Login { get; set; }

		
		[Column("Password"), MaxLength(100)]
		public string Password { get; set; }


		public override string ToString()
		{
			return Name.Equals(Surname) ? Name : $"{Surname} {Name}";
		}
	}

	public interface IIdentityCAAUser : IBaseEntity
	{
		string Name { get; set; }
		string Surname { get; set; }
		string Login { get; set; }
		string Password { get; set; }
    }
}