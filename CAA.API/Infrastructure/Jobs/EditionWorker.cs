using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Quartz;
using WorkerExtensions.Workers;

namespace CAA.API.Infrastructure.Jobs
{
    public class EditionWorker<TJob> : BaseWorker<TJob> where TJob: class, IJob
    {
        private readonly ILogger<TJob> _logger;
        private readonly IOptionsMonitor<ScheduleConfiguration> _opt;

        public EditionWorker(IScheduler scheduler,
            ILogger<TJob> logger,
            IOptionsMonitor<ScheduleConfiguration> opt) : base(scheduler, logger)
        {
            _logger = logger;
            _opt = opt;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug( "Starting new EditionWorker job...");
            try
            {
                await ScheduleWorker<EditionWorker<TJob>>(_opt.CurrentValue.CronExpression, stoppingToken, nameof(EditionWorker<TJob>));

                _logger.LogDebug("EditionWorker is done!");
            }
            catch (Exception ex)
            {
                _logger.LogDebug("EditionWorker hasn't been created. Exception caught: " + ex.Message);
            }
        }
    }
}