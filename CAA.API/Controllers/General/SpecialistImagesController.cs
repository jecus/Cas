

using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.General
{
    [Route("specialistimages")]
    public class SpecialistImagesController : BaseController<CAASpecialistImagesDTO>
    {
        public SpecialistImagesController(DataContext context, ILogger<BaseController<CAASpecialistImagesDTO>> logger) : base(context, logger)
        {
        }
    }
}