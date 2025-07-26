using AutoMapper;
using GestionInventarios.Aplicacion.Persistencia;
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
            var movInventario = await _unitOfWork.MovInventarioRepositorio.ConsultarAsync(request.FechaInicio, request.FechaFin, request.TipoMovimiento, request.NroDocumento);
            var result = _mapper.Map<IEnumerable<ObtenerMovInventarioResult>>(movInventario);
            return result.ToList();
        }

    }
}
