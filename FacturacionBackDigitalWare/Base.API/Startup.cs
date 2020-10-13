using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Base.Datos.Contexto;
using Base.Datos.DAL;
using Base.Datos.Entidades.DAL;
using Base.Negocio.BL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Base.API
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
            services.AddDbContext<ContextoFacturacion>(options => options.UseSqlServer(Configuration.GetConnectionString("AppConnection")));
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();

            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", build =>
            {
                build.WithOrigins("http://localhost:4200")
                     .AllowAnyMethod()
                     .AllowAnyHeader();
            }));

            // Inyección Cliente
            services.AddScoped<ClienteDAL>();
            services.AddScoped<ClienteBL>();

            // Inyección Producto
            services.AddScoped<ProductoDAL>();
            services.AddScoped<ProductoBL>();

            // Inyección Factura
            services.AddScoped<FacturaDAL>();
            services.AddScoped<FacturaBL>();

            // Inyección Categoria
            services.AddScoped<CategoriaDAL>();
            services.AddScoped<CategoriaBL>();

            // Inyección DetalleFactura
            services.AddScoped<DetalleFacturaDAL>();
            services.AddScoped<DetalleFacturaBL>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("ApiCorsPolicy");

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
