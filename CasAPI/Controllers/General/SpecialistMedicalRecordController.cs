using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("specialistmedicalrecord")]
	public class SpecialistMedicalRecordController : BaseController<SpecialistMedicalRecordDTO>
	{
		public SpecialistMedicalRecordController(DataContext context, ILogger<BaseController<SpecialistMedicalRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}

