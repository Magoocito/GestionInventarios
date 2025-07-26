using AutoMapper;
using GestionInventarios.Aplicacion.Persistencia;
using GestionInventarios.Dominio.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionInventarios.Aplicacion.Caracteristicas.Comandos.EliminarMovInventarios
{
    public class EliminarMovInventariosCommandHandler : IRequestHandler<EliminarMovInventariosCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EliminarMovInventariosCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(EliminarMovInventariosCommand request, CancellationToken cancellationToken)
        {
            var movInventario = _mapper.Map<MovInventario>(request);
            await _unitOfWork.MovInventarioRepositorio.EliminarAsync(movInventario);
            await _unitOfWork.GuardarCambiosAsync();
            return Unit.Value;
        }
    }
}
