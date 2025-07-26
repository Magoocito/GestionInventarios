using GestionInventarios.Aplicacion.Caracteristicas.Comandos.ActualizarMovInventarios;
using GestionInventarios.Aplicacion.Caracteristicas.Comandos.EliminarMovInventarios;
using GestionInventarios.Aplicacion.Caracteristicas.Comandos.InsertarMovInventarios;
using GestionInventarios.Aplicacion.Caracteristicas.Consultas.ObtenerMovInventarios;

namespace GestionInventarios.Aplicacion.Persistencia
{
    /// <summary>
    /// Interfaz genérica para repositorios.
    /// </summary>
    public interface IMovInventariosServicios
    {
        /// <summary>
        /// Consulta registros según los parámetros proporcionados.
        /// </summary>
        /// <param name="fechaInicio">Fecha de inicio del filtro.</param>
        /// <param name="fechaFin">Fecha de fin del filtro.</param>
        /// <param name="tipoMovimiento">Tipo de movimiento a filtrar.</param>
        /// <param name="nroDocumento">Número de documento a filtrar.</param>
        /// <returns>Lista de registros filtrados.</returns>
        Task<IEnumerable<ObtenerMovInventarioResult>> ObtenerMovInventariosAsync(ObtenerMovInventarioQuery query);
        /// <summary>
        /// Inserta un nuevo registro.
        /// </summary>
        /// <param name="entity">Entidad a insertar.</param>
        Task InsertarMovInventariosAsync(InsertarMovInventariosCommand entity);
        /// <summary>
        /// Actualiza un registro existente.
        /// </summary>
        /// <param name="entity">Entidad a actualizar.</param>
        Task ActualizarMovInventariosAsync(ActualizarMovInventariosCommand entity);
        /// <summary>
        /// Elimina un registro.
        /// </summary>
        /// <param name="entity">Entidad a eliminar.</param>
        Task EliminarMovInventariosAsync(EliminarMovInventariosCommand entity);

    }
}
