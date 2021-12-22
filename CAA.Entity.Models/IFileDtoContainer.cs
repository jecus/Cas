using System.Collections.Generic;
using CAA.Entity.Models.DTO;
using Entity.Abstractions;

namespace CAA.Entity.Models
{
	public interface ICAAFileDtoContainer : IBaseEntity
	{
		ICollection<CAAItemFileLinkDTO> Files { get; set; }
	}
}