using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Text.Json.Serialization;
using WebApiHow.Data;
using WebApiHow.Services;

namespace WebApiHow
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
            
            // Context DB
            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));

            services.AddControllers().AddJsonOptions(x =>  x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            services.AddControllers();

            services.AddTransient<IngresoService>();

            // Generador Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                { Title = "Api REST Hogwarts",Description="Para ser consumida por Hogwarts", Version = "v1" });
                // Directorio actual
                var basePath = AppContext.BaseDirectory;
                //Nombre de la dll (usando reflexion)
                var assemblyName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
                //Al nombre del assembly se le agrega extension xml
                var fileName = Path.GetFileName(assemblyName + ".xml");
                // Agregar Path
                var xmlPath = Path.Combine(basePath, fileName);
                c.IncludeXmlComments(xmlPath);
                // Agrupar y ordenar por metodos http.
                c.TagActionsBy(p => p.HttpMethod);
                
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Habilitar Swagger
            app.UseSwagger();
            // Ruta para generar la configuración de Swagger
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api REST Hogwarts");
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
