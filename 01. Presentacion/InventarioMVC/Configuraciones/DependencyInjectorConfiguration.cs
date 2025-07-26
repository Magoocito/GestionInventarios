using GestionInventarios.Aplicacion.Caracteristicas.Comandos.ActualizarMovInventarios;
using GestionInventarios.Aplicacion.Caracteristicas.Comandos.EliminarMovInventarios;
using GestionInventarios.Aplicacion.Caracteristicas.Comandos.InsertarMovInventarios;
using GestionInventarios.Aplicacion.Caracteristicas.Consultas.ObtenerMovInventarios;
using GestionInventarios.Aplicacion.Persistencia;
using GestionInventarios.Infraestructura.Persistencia.AdoContexto;
using GestionInventarios.Infraestructura.Persistencia.UnitOfWork;
using GestionInventarios.Infraestructura.Servicios;
using MediatR;
using System.Reflection;

namespace GestionInventarios.Web.Configuraciones
{
    public static class DependencyInjectorConfiguration
    {
        public static void UseDependencyInjectorConfiguration(this IServiceCollection services, 
                IConfiguration configuration)
        {
            services.AddMediatR(cfg => 
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            var sp = services.BuildServiceProvider();

            // Aplicacion
            services.AddScoped<IMovInventarioAdoRepositorio, MovInventarioAdoRepositorio>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Servicios
            services.AddScoped<IMovInventariosServicios, MovInventariosServicios>();

            //MediatR
            services.AddScoped<IRequestHandler<ObtenerMovInventarioQuery, IEnumerable<ObtenerMovInventarioResult>>, ObtenerMovInventarioQueryHandler>();
            services.AddScoped<IRequestHandler<InsertarMovInventariosCommand, Unit>, InsertarMovInventariosCommandHandler>();
            services.AddScoped<IRequestHandler<ActualizarMovInventariosCommand, Unit>, ActualizarMovInventariosCommandHandler>();
            services.AddScoped<IRequestHandler<EliminarMovInventariosCommand, Unit>, EliminarMovInventariosCommandHandler>();
        }
    }
}
