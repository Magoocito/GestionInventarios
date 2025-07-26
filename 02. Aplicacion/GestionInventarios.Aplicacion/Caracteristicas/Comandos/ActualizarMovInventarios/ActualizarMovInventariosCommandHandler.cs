using AutoMapper;
using GestionInventarios.Aplicacion.Persistencia;
using GestionInventarios.Dominio.Entidades;
using MediatR;

namespace GestionInventarios.Aplicacion.Caracteristicas.Comandos.ActualizarMovInventarios
{
    public class ActualizarMovInventariosCommandHandler : IRequestHandler<ActualizarMovInventariosCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ActualizarMovInventariosCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(ActualizarMovInventariosCommand request, CancellationToken cancellationToken)
        {
            var movInventario = _mapper.Map<MovInventario>(request);
            await _unitOfWork.MovInventarioRepositorio.ActualizarAsync(movInventario);
            await _unitOfWork.GuardarCambiosAsync();
            return Unit.Value;
        }
    }
}
