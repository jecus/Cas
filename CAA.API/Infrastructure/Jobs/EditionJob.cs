﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API.Abstractions.Abstractions.Workers;
using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CAA.API.Infrastructure.Jobs
{
    public class EditionJob: IWorker
    {
        private readonly ILogger<EditionJob> _logger;
        private readonly IServiceProvider _provider;

        public EditionJob(ILogger<EditionJob> logger, IServiceProvider provider)
        {
            _logger = logger;
            _provider = provider;
        }
        
        public void Dispose()
        {
			
        }
        
        public async Task Start()
        {
            while (true)
            {
                try
            {
                var context = _provider.GetService<DataContext>();

                var nextEditions = await context.CheckListRevisionDtos
                    .Where(i => !i.IsDeleted 
                                              && i.Status == (byte)EditionRevisionStatus.Temporary 
                                              && i.Type ==  (byte)RevisionType.Edition
                                              && i.EffDate.Date <= DateTime.Today.Date).ToListAsync();

                if (!nextEditions.Any())
                {
                    var now = DateTime.Now;
                    var tomorrow = now.AddDays(1);
                    var durationUntilMidnight = tomorrow.Date - now;
                    Thread.Sleep(durationUntilMidnight);
                }
                else
                {
                    foreach (var nextEdition in nextEditions)
                {
                    if (nextEdition != null)
                    {
                        var currentEdition = await context.CheckListRevisionDtos
                            .OrderBy(i => i.EffDate)
                            .FirstOrDefaultAsync(i => !i.IsDeleted && i.Status == (byte)EditionRevisionStatus.Current && i.Type ==  (byte)RevisionType.Edition);
                    
                        currentEdition.Status = (byte)EditionRevisionStatus.Previous;

                        var currentRevisions = await context.CheckListRevisionDtos
                            .Where(i => !i.IsDeleted && i.Type ==  (byte)RevisionType.Revision && i.EditionId == currentEdition.ItemId)
                            .ToListAsync();
                    
                        foreach (var revision in currentRevisions)
                            revision.Status = (byte)EditionRevisionStatus.Previous;
                    
                        nextEdition.Status = (byte)EditionRevisionStatus.Current;
                        var nextRevisions = await context.CheckListRevisionDtos
                            .Where(i => !i.IsDeleted && i.Type ==  (byte)RevisionType.Revision && i.EditionId == currentEdition.ItemId)
                            .ToListAsync();
                    
                        foreach (var revision in nextRevisions)
                            revision.Status = (byte)EditionRevisionStatus.Current;
                        
                        
                        var revisions = await context.CheckListRevisionDtos
                            .Where(i => !i.IsDeleted
                                        && i.Type ==  (byte)RevisionType.Revision).ToListAsync();

                        foreach (var revision in revisions)
                            revision.Status = (byte)EditionRevisionStatus.Previous;


                        await context.SaveChangesAsync();
                    }
                }
                }

                
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            }
            
            
        }
    }
}