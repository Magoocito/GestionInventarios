using MediatR;

namespace GestionInventarios.Aplicacion.Caracteristicas.Comandos.EliminarMovInventarios
{
    public class EliminarMovInventariosCommand : IRequest<Unit>
    {
        public string CodCia { get; set; }
    }
}
