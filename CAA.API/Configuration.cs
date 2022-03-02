using System;
using System.IO;
using System.Linq;
using API.Abstractions.Abstractions.Workers;
using CAA.API.Infrastructure;
using CAA.API.Infrastructure.Jobs;
using CAA.Entity.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using WorkerExtensions.Infrastructure;

namespace CAA.API
{
    public partial class Startup
    {
        public virtual void RegisterWorkers(IServiceCollection services)
        {
            services.AddWorker<DictionaryWorker>();
            services.AddWorker<EditionJob>();
            services.AddWorker<RevisionJob>();
        }
        public virtual void RegisterDataBase(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(builder =>
            {
                builder.UseSqlServer(Configuration.GetConnectionString("CORE_CONNECTION_STRING"), optionsBuilder =>
                {
                    optionsBuilder.CommandTimeout(180);
                });
                builder.EnableSensitiveDataLogging(false);
                builder.EnableDetailedErrors();
            }, ServiceLifetime.Scoped);
        }

        public virtual void RegisterHealthCheck(IServiceCollection services)
        {
            services.AddHealthChecks();
            //.AddSqlServer(Configuration.GetConnectionString("CORE_CONNECTION_STRING"), name: "CoreContext", failureStatus: HealthStatus.Unhealthy);
        }

        public virtual void RegisterSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CasAPI", Version = "v1", });

                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml");
                foreach (var xmlFile in xmlFiles)
                    c.IncludeXmlComments(xmlFile);

                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.UseInlineDefinitionsForEnums();
                c.CustomSchemaIds(s => s.FullName);
            });
            services.AddSwaggerGenNewtonsoftSupport();
        }
    }
}
