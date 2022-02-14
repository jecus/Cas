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
    public class EditionJob: IJob
    {
        private readonly ILogger<EditionJob> _logger;
        private readonly IServiceProvider _provider;

        public EditionJob(ILogger<EditionJob> logger, IServiceProvider provider)
        {
            _logger = logger;
            _provider = provider;
        }
        
        public async Task Execute(IJobExecutionContext c)
        {
            try
            {
                var context = _provider.GetService<DataContext>();

                var nextEdition = await context.CheckListRevisionDtos
                    .FirstOrDefaultAsync(i => !i.IsDeleted 
                                              && i.Status == (byte)EditionRevisionStatus.Temporary 
                                              && i.Type ==  (byte)RevisionType.Edition
                                              && i.EffDate.Date <= DateTime.Today.Date);

                if (nextEdition != null)
                {
                    
                    var currentEdition = await context.CheckListRevisionDtos
                        .OrderBy(i => i.EffDate)
                        .FirstOrDefaultAsync(i => !i.IsDeleted && i.Status == (byte)EditionRevisionStatus.Open && i.Type ==  (byte)RevisionType.Edition);
                    
                    currentEdition.Status = (byte)EditionRevisionStatus.Close;

                    var currentRevisions = await context.CheckListRevisionDtos
                        .Where(i => !i.IsDeleted && i.Type ==  (byte)RevisionType.Revision && i.EditionId == currentEdition.ItemId)
                        .ToListAsync();
                    
                    foreach (var revision in currentRevisions)
                        revision.Status = (byte)EditionRevisionStatus.Close;
                    
                    nextEdition.Status = (byte)EditionRevisionStatus.Open;
                    var nextRevisions = await context.CheckListRevisionDtos
                        .Where(i => !i.IsDeleted && i.Type ==  (byte)RevisionType.Revision && i.EditionId == currentEdition.ItemId)
                        .ToListAsync();
                    
                    foreach (var revision in nextRevisions)
                        revision.Status = (byte)EditionRevisionStatus.Open;
                    
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