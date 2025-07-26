using AutoMapper;
using GestionInventarios.Aplicacion.Caracteristicas.Comandos.ActualizarMovInventarios;
using GestionInventarios.Aplicacion.Caracteristicas.Comandos.EliminarMovInventarios;
using GestionInventarios.Aplicacion.Caracteristicas.Comandos.InsertarMovInventarios;
using GestionInventarios.Aplicacion.Caracteristicas.Consultas.ObtenerMovInventarios;
using GestionInventarios.Aplicacion.ViewModel;
using GestionInventarios.Dominio.Entidades;

namespace GestionInventarios.Infraestructura.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // Mapeo entre entidad y ViewModel
            CreateMap<MovInventario, MovInventarioViewModel>().ReverseMap();

            // Mapeo entre ViewModel y Command
            CreateMap<MovInventarioViewModel, InsertarMovInventariosCommand>().ReverseMap();
            CreateMap<MovInventarioViewModel, ActualizarMovInventariosCommand>().ReverseMap();
            CreateMap<MovInventarioViewModel, InsertarMovInventariosCommand>().ReverseMap();
            CreateMap<MovInventarioViewModel, EliminarMovInventariosCommand>().ReverseMap();

            // Mapeos para consultas y resultados
            CreateMap<MovInventario, ObtenerMovInventarioQuery>().ReverseMap();
            CreateMap<MovInventario, ObtenerMovInventarioResult>().ReverseMap();
            CreateMap<ObtenerMovInventarioResult, MovInventarioViewModel>().ReverseMap();

            // Mapeos para comandos
            CreateMap<MovInventario, InsertarMovInventariosCommand>().ReverseMap();
            CreateMap<MovInventario, ActualizarMovInventariosCommand>().ReverseMap();
            CreateMap<MovInventario, EliminarMovInventariosCommand>().ReverseMap();

            // Mapeo de entidad a ViewModel
            CreateMap<ObtenerMovInventarioResult, MovInventarioViewModel>().ReverseMap();

            // Si necesitas mapear listas:
            CreateMap<List<ObtenerMovInventarioResult>, List<MovInventarioViewModel>>()
                .ConvertUsing((src, dest, context) => context.Mapper.Map<List<MovInventarioViewModel>>(src));
        }
    }
}