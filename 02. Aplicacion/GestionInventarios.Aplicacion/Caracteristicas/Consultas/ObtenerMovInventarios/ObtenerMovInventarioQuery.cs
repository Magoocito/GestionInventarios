using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionInventarios.Aplicacion.Caracteristicas.Consultas.ObtenerMovInventarios
{
    public class ObtenerMovInventarioQuery : IRequest<IEnumerable<ObtenerMovInventarioResult>>
    {
        //campos necesarios para la consulta
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string TipoMovimiento { get; set; }
        public string NroDocumento { get; set; }
    }
}
