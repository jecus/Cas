using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("CRS")]
	public class CRSController : BaseController<CertificateOfReleaseToServiceDTO>
	{
		public CRSController(DataContext context, ILogger<BaseController<CertificateOfReleaseToServiceDTO>> logger) : base(context, logger)
		{

		}
	}
}
