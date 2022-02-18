using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Quartz;
using WorkerExtensions.Workers;

namespace CAA.API.Infrastructure.Jobs
{
    public class EditionWorker<TJob> : BaseWorker<TJob> where TJob: class, IJob
    {
        private readonly ILogger<TJob> _logger;
        private readonly IConfiguration _conf;

        public EditionWorker(IScheduler scheduler,
            ILogger<TJob> logger,
            IConfiguration conf) : base(scheduler, logger)
        {
            _logger = logger;
            _conf = conf;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug( "Starting new EditionWorker job...");
            try
            {
                await ScheduleWorker<EditionWorker<TJob>>(_conf["Setup:ScheduleEditionWorker"], stoppingToken, nameof(EditionWorker<TJob>));

                _logger.LogDebug("EditionWorker is done!");
            }
            catch (Exception ex)
            {
                _logger.LogError("EditionWorker hasn't been created. Exception caught: " + ex.Message);
            }
        }
    }
}