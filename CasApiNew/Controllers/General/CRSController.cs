using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("certificateofreleasetoservice")]
	public class CRSController : BaseController<CertificateOfReleaseToServiceDTO>
	{
		public CRSController(DataContext context, ILogger<BaseController<CertificateOfReleaseToServiceDTO>> logger) : base(context, logger)
		{

		}
	}
}
