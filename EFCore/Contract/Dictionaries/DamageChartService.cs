﻿using EFCore.DTO;
using EFCore.DTO.Dictionaries;
using EFCore.Repository;

namespace EFCore.Contract.Dictionaries
{
	public class DamageChartService : Repository<DamageChartDTO>, IDamageChartService
	{
		public DamageChartService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<DamageChartDTO>();
		}
	}
}