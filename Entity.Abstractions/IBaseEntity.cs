﻿namespace Entity.Abstractions
{
	public interface IBaseEntity
	{
		bool IsDeleted { get; set; }
		int ItemId { get; set; }
	}
}