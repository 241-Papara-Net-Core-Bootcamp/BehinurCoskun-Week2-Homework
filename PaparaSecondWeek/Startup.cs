using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PaparaSecondWeek.Middlewares;
using PaparaSecondWeek.Models;
using PaparaSecondWeek.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PaparaSecondWeek
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PaparaSecondWeek", Version = "v1" });
            });

            //Geçici. Servis her istenildiðinde yeni instance alýnýr.
            services.AddTransient<IOwnerServices, OwnerServices>();
            //Kapsamlý. Yeni bir istek geldiðinde obje oluþturulur.
            //services.AddScoped<IOwnerServices, OwnerServices>();
            // Tek. Ýlk istek geldiðinde bir tane instance sonra gelen tüm istekler ayný instance üzerinden
            //devam ettirilir.
            //services.AddSingleton<IOwnerServices, OwnerServices>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PaparaSecondWeek v1"));
            }
           

            app.UseHttpsRedirection();

            app.UseRouting();
            //app.UseHeaderCheckMiddleware();
            app.UseExceptionMiddleware();  // ExceptionMiddleware ini register ettim.
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

           

            //app.UseMiddleware<HeaderCheckMiddleware>(); //2. farklý register etme yöntemi
        }
    }
}
