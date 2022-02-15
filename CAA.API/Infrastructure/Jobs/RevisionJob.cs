using System;
using System.Linq;
using System.Threading.Tasks;
using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;

namespace CAA.API.Infrastructure.Jobs
{
    public class RevisionJob: IJob
    {
        private readonly ILogger<RevisionJob> _logger;
        private readonly IServiceProvider _provider;

        public RevisionJob(ILogger<RevisionJob> logger, IServiceProvider provider)
        {
            _logger = logger;
            _provider = provider;
        }
        
        public async Task Execute(IJobExecutionContext c)
        {
            try
            {
                var context = _provider.GetService<DataContext>();
                
                var currentRevision = await context.CheckListRevisionDtos
                    .FirstOrDefaultAsync(i => !i.IsDeleted 
                                              && i.Status == (byte)EditionRevisionStatus.Temporary 
                                              && i.Type ==  (byte)RevisionType.Revision
                                              && i.EffDate.Date <= DateTime.Today.Date);

                if (currentRevision != null)
                {
                    currentRevision.Status = (byte)EditionRevisionStatus.Close;
                    var records = await context.CheckListRevisionRecordDtos
                        .Where(i => !i.IsDeleted && i.ParentId == currentRevision.ItemId)
                        .ToListAsync();

                    var checkListIds = records.Select(i => i.CheckListId);
                    var checkList = await context.CheckListDtos.Where(i => checkListIds.Contains(i.ItemId)).ToListAsync();
                    
                    foreach (var rec in records)
                    {
                        var check = checkList.FirstOrDefault(i => i.ItemId == rec.CheckListId);
                        if(check == null)
                            continue;

                        if (rec.Settings.RevisionCheckType == RevisionCheckType.New)
                            check.EditionId = rec.ParentId;
                        else if (rec.Settings.RevisionCheckType == RevisionCheckType.Del)
                            check.IsDeleted = true;
                        else if (rec.Settings.RevisionCheckType == RevisionCheckType.Mod)
                        {
                            
                        }
                    }

                    await context.SaveChangesAsync();
                }
                
                
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
        }
    }
}