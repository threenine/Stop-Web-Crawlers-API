using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using swcApi;
using Threenine.Map;
using Api.Database;
using Api.Database.Entity.Threats;
using Swc.Service;
using Threenine.Data;
using Api.Domain.Bots;
using Threenine.Data.DependencyInjection;
using Swashbuckle.AspNetCore;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using Microsoft.Extensions.PlatformAbstractions;

namespace swcApi
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
            // Add framework services.
            services.AddDbContext<ApiContext>(options => options.UseSqlServer(Configuration.GetConnectionString(Globals.api_database_connection_string_name)))
                .AddUnitOfWork<ApiContext>();
            services.AddTransient<IReferrerService, ReferrerService>();
         
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", 
                new Info 
                {
                    Title = "Stop Web Crawlers API", 
                    Version = "v1" ,
                    Description = "Stop Web Crawlers API to enable the update of Referer Spammer Lists",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "threenine.co.uk", Email ="support@threenine.co.uk", Url ="https://threenine.co.uk"}
                });
                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "api.xml");
                 c.IncludeXmlComments(filePath);  
            }
          );
        }
       
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SWC API V1");
            });
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                if (!serviceScope.ServiceProvider.GetService<ApiContext>().AllMigrationsApplied())
                {
                    serviceScope.ServiceProvider.GetService<ApiContext>().Database.Migrate();
                    serviceScope.ServiceProvider.GetService<ApiContext>().EnsureSeeded();
                }
               
            }

            //Set up code for automapper configuration 
           MapConfigurationFactory.Scan<Startup>();
           
           
        }
    }
}
