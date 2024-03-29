using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using HFMaracay.Business.Process;
namespace HFMaracay.API
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
            services.AddControllers();
            services.AddScoped<IAreasProcess, AreasProcess>();
            services.AddScoped<INivelProcess, NivelProcess>();
            services.AddScoped<IUsuariosProcess, UsuariosProcess>();
            services.AddScoped<ITipoLocalidadesProcess, TipoLocalidadesProcess>();
            services.AddScoped<ILocalidadesProcess, LocalidadesProcess>();
            services.AddScoped<IGaleriaProcess, GaleriaProcess>();
            services.AddScoped<IEventosProcess, EventosProcess>();
            services.AddScoped<IBlogProcess, BlogProcess>();       
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
