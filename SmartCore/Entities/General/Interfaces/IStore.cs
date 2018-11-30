using System;

namespace SmartCore.Entities.General.Interfaces
{
	public interface IStore : IComponentFilterParams
	{
		String IdNumber { get; set; }
	}
}