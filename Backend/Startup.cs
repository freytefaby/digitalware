using DigitalwareTest.Entity;
using DigitalwareTest.Servicios;
using DigitalwareTest.Servicios.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace DigitalwareTest
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
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DigitalWareContext>(options=> {
                options.UseSqlServer(connection);
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularLocal", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().Build());
            });
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IProductoService, ProductoService>();
            services.AddTransient<IMovimientoService, MovimientoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowAngularLocal");
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
