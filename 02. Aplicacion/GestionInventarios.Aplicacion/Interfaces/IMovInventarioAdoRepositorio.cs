using GestionInventarios.Dominio.Entidades;

namespace GestionInventarios.Aplicacion.Persistencia
{
    /// <summary>
    /// Interfaz para el repositorio de movimientos de inventario.
    /// </summary>
    public interface IMovInventarioAdoRepositorio
    {
        Task<IEnumerable<MovInventario>> ConsultarAsync(MovInventario mov);
        Task InsertarAsync(MovInventario mov);
        Task ActualizarAsync(MovInventario mov);
        Task EliminarAsync(MovInventario mov);
    }
}
