using AutoMapper;
using GestionInventarios.Aplicacion.Persistencia;
using GestionInventarios.Dominio.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionInventarios.Aplicacion.Caracteristicas.Comandos.InsertarMovInventarios
{
    public class InsertarMovInventariosCommandHandler : IRequestHandler<InsertarMovInventariosCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public InsertarMovInventariosCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(InsertarMovInventariosCommand request, CancellationToken cancellationToken)
        {

            var movInventario = _mapper.Map<MovInventario>(request);
            await _unitOfWork.MovInventarioRepositorio.InsertarAsync(movInventario);
            await _unitOfWork.GuardarCambiosAsync();
            return Unit.Value;

        }
    }
}
