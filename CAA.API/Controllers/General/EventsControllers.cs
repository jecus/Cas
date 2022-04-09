using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.General
{
    [Route("event")]
    public class EventController : BaseController<CAAEventDTO>
    {
        public EventController(DataContext context, ILogger<BaseController<CAAEventDTO>> logger) : base(context, logger)
        {
        }
    }
    
    
    [Route("eventcondition")]
    public class EventConditionController : BaseController<CAAEventConditionDTO>
    {
        public EventConditionController(DataContext context, ILogger<BaseController<CAAEventConditionDTO>> logger) : base(context, logger)
        {
        }
    }
    
    
    [Route("eventcategorie")]
    public class EventCategorieController : BaseController<CAAEventCategorieDTO>
    {
        public EventCategorieController(DataContext context, ILogger<BaseController<CAAEventCategorieDTO>> logger) : base(context, logger)
        {
        }
    }
    
    [Route("eventclass")]
    public class EventClasseController : BaseController<CAAEventClassDTO>
    {
        public EventClasseController(DataContext context, ILogger<BaseController<CAAEventClassDTO>> logger) : base(context, logger)
        {
        }
    }
    
    [Route("smseventtype")]
    public class SmsEventTypeController : BaseController<CAASmsEventTypeDTO>
    {
        public SmsEventTypeController(DataContext context, ILogger<BaseController<CAASmsEventTypeDTO>> logger) : base(context, logger)
        {
        }
    }
    
    [Route("eventtyperisklevelchangerecord")]
    public class EventTypeRiskLevelChangeRecordController : BaseController<CAAEventTypeRiskLevelChangeRecordDTO>
    {
        public EventTypeRiskLevelChangeRecordController(DataContext context, ILogger<BaseController<CAAEventTypeRiskLevelChangeRecordDTO>> logger) : base(context, logger)
        {
        }
    }
}