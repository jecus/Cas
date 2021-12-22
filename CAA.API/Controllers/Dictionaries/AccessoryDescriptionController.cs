using System;
using CAA.Entity.Core;
using CAA.Entity.Models.Dictionary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.Dictionaries
{
	[Route("accessorydescription")]
	public class AccessoryDescriptionController : BaseController<CAAAccessoryDescriptionDTO>
	{
		private Type _type = typeof(CAAAccessoryDescriptionDTO);


		public AccessoryDescriptionController(DataContext context, ILogger<BaseController<CAAAccessoryDescriptionDTO>> logger) : base(context, logger)
		{
			
		}
	}
}