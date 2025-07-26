using MediatR;

namespace GestionInventarios.Aplicacion.Caracteristicas.Comandos.EliminarMovInventarios
{
    public class EliminarMovInventariosCommand : IRequest<Unit>
    {
        public string CodCia { get; set; }
        public string CompaniaVenta3 { get; set; }
        public string AlmacenVenta { get; set; }
        public string TipoMovimiento { get; set; }
        public string TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string CodItem2 { get; set; }
    }
}
