using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API.Abstractions.Abstractions.Workers;
using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CAA.API.Infrastructure.Jobs
{
    public class ClosedJob: IWorker
    {
        private readonly ILogger<ClosedJob> _logger;
        private readonly IServiceProvider _provider;

        public ClosedJob(ILogger<ClosedJob> logger, IServiceProvider provider)
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

                    var audits = await context.CAAAuditDtos
                        .AsNoTracking()
                        .Where(i => !i.IsDeleted && i.Status == RoutineStatus.Published)
                        .ToListAsync();

                    if (!audits.Any())
                    {
                        var now = DateTime.Now;
                        var tomorrow = now.AddDays(1);
                        var durationUntilMidnight = tomorrow.Date - now;
                        Thread.Sleep(durationUntilMidnight);
                    }
                    else
                    {
                        foreach (var audit in audits)
                        {
                            var evaluation = context.AuditCheckDtos.AsNoTracking()
                                .Any(i => !i.IsDeleted && i.WorkflowStageId == 2 && i.AuditId == audit.ItemId);
                            var notCAR = context.AuditCheckDtos.AsNoTracking().Any(i => !i.IsDeleted && i.WorkflowStageId > 3 && i.AuditId == audit.ItemId);

                            if (evaluation)
                                continue;

                            if (notCAR)
                            {
                                var checks = await context.AuditCheckDtos
                                    .Where(i => !i.IsDeleted && i.WorkflowStageId == 3 && i.AuditId == audit.ItemId && !i.IsSatisfactory.Value && !i.IsApplicable.Value)
                                    .ToListAsync();


                                foreach (var auditCheck in checks)
                                {
                                    auditCheck.Settings.FromWorkflowStageId = auditCheck.Settings.WorkflowStageId;
                                    auditCheck.Settings.WorkflowStageId = 6;
                                    auditCheck.Settings.WorkflowStatusId = 6;

                                    await context.AuditCheckDtos.AddAsync(auditCheck);
                                    
                                    var rec = new CheckListTransferDTO()
                                    {
                                        Created = DateTime.Now,
                                        From = -1,
                                        To = -1,
                                        AuditId = auditCheck.AuditId,
                                        CheckListId = auditCheck.CheckListId,
                                        Settings = new CheckListTransferSettings()
                                        {
                                            Remark = $"Workflow stage Updated to Closed!",
                                            WorkflowStageId = auditCheck.Settings.WorkflowStageId,
                                            IsWorkFlowChanged = true
                                        }
                                    };
                                    await context.CheckListTransferDtos.AddAsync(rec);
                                    
                                    await context.SaveChangesAsync();
                                }
                                
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