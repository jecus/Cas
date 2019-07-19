using System.Threading.Tasks;
using CasAPI.Infrastructure;
using EntityCore.DTO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace CasAPI
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddWorker<DictionaryWorker>();
			services.AddMvc()
				.AddJsonOptions(options =>
				{
					options.AllowInputFormatterExceptionMessages = true;
					//options.SerializerSettings.Converters.Add(new StringEnumConverter());
					options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
					options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
					options.SerializerSettings.ObjectCreationHandling = ObjectCreationHandling.Reuse;
					options.UseMemberCasing();
				})
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			services.AddDbContext<DataContext>(options =>
				{
					options.UseSqlServer(Configuration.GetConnectionString("CORE_CONNECTION_STRING"), builder =>
						{
							builder.CommandTimeout(180);
							//builder.EnableRetryOnFailure(2);
						});
					//options.EnableSensitiveDataLogging(false);
					//options.EnableDetailedErrors();
				});

			services.AddResponseCompression(options =>
			{
				options.Providers.Add<BrotliCompressionProvider>();
				options.Providers.Add<GzipCompressionProvider>();
			});
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info
				{
					Version = "v1",
					Title = "API",
					Description = "CAS API "
				});
			});
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();

			app.UseResponseCompression();
			app.UseMvc();


			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API V1");
			});

			Initialize(app);
		}


		public virtual void Initialize(IApplicationBuilder app)
		{
			var scope = app.ApplicationServices.CreateScope();

			var workers = scope.ServiceProvider.GetServices<IWorker>();
			foreach (var worker in workers)
				Task.Run(() => worker.Start());
		}
	}
}
