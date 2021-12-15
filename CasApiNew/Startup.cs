using System.IO.Compression;
using System.Threading.Tasks;
using CAS.API.Abstractions.Helpers;
using CAS.API.Abstractions.Middleware;
using CAS.API.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace CAS.API
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Formatting = Formatting.Indented;
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
                options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.ObjectCreationHandling = ObjectCreationHandling.Replace;
                options.SerializerSettings.ContractResolver = new OrderedContractResolver();
                options.UseMemberCasing();
            });

            RegisterDataBase(services);
            RegisterWorkers(services);
            RegisterSwagger(services);
            RegisterHealthCheck(services);

            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal;
            });
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.EnableForHttps = true;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseResponseCompression();
            app.UseMiddleware(typeof(ErrorHandlerMiddleware));

            app.UseCors(builder => builder.AllowAnyOrigin());
            app.UseRouting();
            app.UseHealthChecks(Configuration["HealthCheck:Endpoint"]);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks(Configuration["HealthCheck:Endpoint"]);
            });

            app.UseSwagger(o => { o.SerializeAsV2 = true; });
            app.UseSwaggerUI(o =>
            {
                o.DocExpansion(DocExpansion.None);
                o.DefaultModelsExpandDepth(-1);//Disable schemas
                o.RoutePrefix = "swagger";
                o.SwaggerEndpoint("v1/swagger.json", "Cas API v1");
            });


            Initialize(app);
        }


        public void Initialize(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var workers = scope.ServiceProvider.GetServices<IWorker>();
            foreach (var worker in workers)
                Task.Run(() => worker.Start());
        }
    }
}
