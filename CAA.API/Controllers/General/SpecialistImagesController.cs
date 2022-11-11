using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.General
{
    
    [Route("specialist-images")]
    public class SpecialistImagesController : BaseController<SpecialistImagesDTO>
    {
        public SpecialistImagesController(DataContext context, ILogger<BaseController<SpecialistImagesDTO>> logger) : base(context, logger)
        {
        }
    }
}