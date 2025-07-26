using AutoMapper;
using GestionInventarios.Aplicacion.Persistencia;
using GestionInventarios.Dominio.Entidades;
using MediatR;

namespace GestionInventarios.Aplicacion.Caracteristicas.Consultas.ObtenerMovInventarios
{
    public class ObtenerMovInventarioQueryHandler: IRequestHandler<ObtenerMovInventarioQuery, IEnumerable<ObtenerMovInventarioResult>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ObtenerMovInventarioQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ObtenerMovInventarioResult>> Handle(ObtenerMovInventarioQuery request, CancellationToken cancellationToken)
        {

            var movInventarioFiltro = _mapper.Map<MovInventario>(request);
            var movInventario = await _unitOfWork.MovInventarioRepositorio.ConsultarAsync(movInventarioFiltro);
            var result = _mapper.Map<IEnumerable<ObtenerMovInventarioResult>>(movInventario);
            return result.ToList();
        }

    }
}
