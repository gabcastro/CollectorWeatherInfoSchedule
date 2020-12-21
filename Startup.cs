using System;
using System.IO;
using System.Reflection;
using System.Xml.XPath;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WeatherCollector.IO;
using WeatherCollector.Timers;

namespace WeatherCollector
{
    public class Startup
    {
        private static string GetPathOfXmlFromAssembly() => Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Ticket = new ScheduleTimer(Configuration);
            DirectoryHelper = new FileDirectoryHelper(Configuration);
        }

        public IConfiguration Configuration { get; }
        public ScheduleTimer Ticket { get; }
        public FileDirectoryHelper DirectoryHelper { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Documentação da API", Version = "v1"});
                options.IncludeXmlComments(GetPathOfXmlFromAssembly());
            });
        }        
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Documentação da API (V1)");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
