using GestionInventarios.Dominio.Entidades;

namespace GestionInventarios.Aplicacion.Persistencia
{
    /// <summary>
    /// Interfaz para el repositorio de movimientos de inventario.
    /// </summary>
    public interface IMovInventarioAdoRepositorio
    {
        Task<IEnumerable<MovInventario>> ConsultarAsync(DateTime? fechaInicio, DateTime? fechaFin, string tipoMovimiento, string nroDocumento);
        Task InsertarAsync(MovInventario mov);
        Task ActualizarAsync(MovInventario mov);
        Task EliminarAsync(MovInventario mov);
    }
}
