﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Quartz;
using WorkerExtensions.Workers;

namespace CAA.API.Infrastructure.Jobs
{
    public class RevisionWorker<TJob> : BaseWorker<TJob> where TJob: class, IJob
    {
        private readonly ILogger<TJob> _logger;
        private readonly IConfiguration _conf;

        public RevisionWorker(IScheduler scheduler,
            ILogger<TJob> logger,
            IConfiguration conf) : base(scheduler, logger)
        {
            _logger = logger;
            _conf = conf;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug( "Starting new RevisionWorker job...");
            try
            {
                await ScheduleWorker<RevisionWorker<TJob>>(_conf["Setup:ScheduleRevisionWorker"], stoppingToken, nameof(RevisionWorker<TJob>));

                _logger.LogDebug("RevisionWorker is done!");
            }
            catch (Exception ex)
            {
                _logger.LogError("RevisionWorker hasn't been created. Exception caught: " + ex.Message);
            }
        }
    }
}