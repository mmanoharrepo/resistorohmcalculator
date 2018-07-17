using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OhmValueCalcApi.Middleware;
using OhmValueCalcApi.Services;
using OhmValueCalcApi.Services.Interfaces;
using Swashbuckle.AspNetCore.Swagger;

namespace OhmValueCalcApi
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
            services.AddMvc();

            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddSingleton<IMasterDataService, MasterDataService>();
            services.AddSingleton<IOhmValueCalcService, OhmValueCalcService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "OhmValue Calculator Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "OhmValue Calculator V1");
            });

            app.UseMiddleware(typeof(ExceptionHandlingMiddleware));

            app.UseCors("CorsPolicy");

            app.UseMvc();
            
        }
    }
}
