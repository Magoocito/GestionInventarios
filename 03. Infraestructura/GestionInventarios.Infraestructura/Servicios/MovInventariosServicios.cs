using AutoMapper;
using GestionInventarios.Aplicacion.Caracteristicas.Comandos.ActualizarMovInventarios;
using GestionInventarios.Aplicacion.Caracteristicas.Comandos.EliminarMovInventarios;
using GestionInventarios.Aplicacion.Caracteristicas.Comandos.InsertarMovInventarios;
using GestionInventarios.Aplicacion.Caracteristicas.Consultas.ObtenerMovInventarios;
using GestionInventarios.Aplicacion.Persistencia;
using GestionInventarios.Dominio.Entidades;

namespace GestionInventarios.Infraestructura.Servicios
{
    public class MovInventariosServicios : IMovInventariosServicios
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MovInventariosServicios(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ObtenerMovInventarioResult>> ObtenerMovInventariosAsync(ObtenerMovInventarioQuery query)
        {
            var movInventario = await _unitOfWork.MovInventarioRepositorio.ConsultarAsync(_mapper.Map<MovInventario>(query));
            var result = _mapper.Map<IEnumerable<ObtenerMovInventarioResult>>(movInventario);
            return result;
        }


        public async Task ActualizarMovInventariosAsync(ActualizarMovInventariosCommand entity)
        {
            var movInventario = _mapper.Map<MovInventario>(entity);
            _unitOfWork.MovInventarioRepositorio.ActualizarAsync(movInventario);
            await _unitOfWork.GuardarCambiosAsync();
        }

        public async Task EliminarMovInventariosAsync(EliminarMovInventariosCommand entity)
        {
            var movInventario = _mapper.Map<MovInventario>(entity);
            await _unitOfWork.MovInventarioRepositorio.EliminarAsync(movInventario);
            await _unitOfWork.GuardarCambiosAsync();
        }

        public async Task InsertarMovInventariosAsync(InsertarMovInventariosCommand entity)
        {
            await _unitOfWork.MovInventarioRepositorio.InsertarAsync(_mapper.Map<MovInventario>(entity));
            await _unitOfWork.GuardarCambiosAsync();
        }

        
    }
}
