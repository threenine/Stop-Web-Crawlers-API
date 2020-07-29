using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSwag;
using Threenine.Data.DependencyInjection;
using Threenine.Diogel.Database.Postgre;
using Threenine.Diogel.Service;
using Threenine.Map;

namespace Threenine.Diogel.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOpenApiDocument();
            services.AddControllers();
            services.AddDbContext<DiogelContext>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("postgre")))
                .AddUnitOfWork<DiogelContext>();
            
            services.AddTransient<IReferrerService, ReferrerService>();
                
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            MapConfigurationFactory.Scan<Startup>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Register the Swagger generator and the Swagger UI middleware
            app.UseSwaggerUi3();
            app.UseReDoc(); // serve ReDoc UI

            app.UseOpenApi(settings =>
            {
                settings.PostProcess = (document, request) =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Stop Web Crawlers API";
                    document.Info.Description =
                        "Stop Web Crawlers Update API to enable the update of Referer Spammer Lists";
                    document.Info.TermsOfService = "Coming Soon";
                    document.Info.Contact = new OpenApiContact
                        {Name = "threenine.co.uk", Email = "support@threenine.co.uk", Url = "https://threenine.co.uk"};
                    
                };
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}