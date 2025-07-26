using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionInventarios.Aplicacion.Caracteristicas.Comandos.ActualizarMovInventarios
{
    public class ActualizarMovInventariosCommand : IRequest<Unit>
    {
        public int Id { get; set; } 
        public DateTime FechaMovimiento { get; set; }
        public string TipoMovimiento { get; set; }
        public string NroDocumento { get; set; }
        public string Detalle { get; set; }
        public int Cantidad { get; set; }
        public string UsuarioModificacion { get; set; } 
    }
}
