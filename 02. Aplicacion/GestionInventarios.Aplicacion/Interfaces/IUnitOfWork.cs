namespace GestionInventarios.Aplicacion.Persistencia
{
    /// <summary>
    /// Unidad de trabajo para la persistencia de datos.
    /// </summary>
    public interface IUnitOfWork
    {
        IMovInventarioAdoRepositorio MovInventarioRepositorio { get; }
        Task GuardarCambiosAsync();
    }
}
