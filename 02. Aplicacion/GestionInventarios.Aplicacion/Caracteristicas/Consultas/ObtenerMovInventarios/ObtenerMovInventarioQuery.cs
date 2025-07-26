using MediatR;

namespace GestionInventarios.Aplicacion.Caracteristicas.Consultas.ObtenerMovInventarios
{
    public class ObtenerMovInventarioQuery : IRequest<IEnumerable<ObtenerMovInventarioResult>>
    {
        public ObtenerMovInventarioQuery()
        {
                
        }

        public string TipoMovimiento { get; set; }
        public string NroDocumento { get; set; }

    }
}
