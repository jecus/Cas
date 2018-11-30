using System.Configuration;
using EFCore.DTO;
using EFCore.DTO.General;
using EFCore.Repository;

namespace EFCore.Contract.General
{
	public class SpecialistMedicalRecordService : Repository<SpecialistMedicalRecordDTO>, ISpecialistMedicalRecordService
	{
		public SpecialistMedicalRecordService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<SpecialistMedicalRecordDTO>();
		}
	}
}