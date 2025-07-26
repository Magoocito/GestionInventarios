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

        public Task ActualizarMovInventariosAsync(ActualizarMovInventariosCommand entity)
        {
            var movInventario = _mapper.Map<MovInventario>(entity);
            _unitOfWork.MovInventarioRepositorio.ActualizarAsync(movInventario);
            return _unitOfWork.GuardarCambiosAsync();
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

        public async Task<IEnumerable<ObtenerMovInventarioResult>> ObtenerMovInventariosAsync(DateTime? fechaInicio, DateTime? fechaFin, string tipoMovimiento, string nroDocumento)
        {
            var movInventario = await _unitOfWork.MovInventarioRepositorio.ConsultarAsync(fechaInicio, fechaFin, tipoMovimiento, nroDocumento);
            var result = _mapper.Map<IEnumerable<ObtenerMovInventarioResult>>(movInventario);
            return result.ToList();
        }
    }
}
