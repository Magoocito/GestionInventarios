using GestionInventarios.Aplicacion.Persistencia;
using GestionInventarios.Infraestructura.Persistencia.AdoConexion;
using Microsoft.Data.SqlClient;

namespace GestionInventarios.Infraestructura.Persistencia.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMovInventarioAdoRepositorio _inventarioAdoRepositorio;
        private readonly SqlConnection _connection;
        public IMovInventarioAdoRepositorio MovInventarioRepositorio => _inventarioAdoRepositorio;

        public UnitOfWork(AdoConfig config, IMovInventarioAdoRepositorio inventarioAdoRepositorio)
        {
            _connection = new SqlConnection(config.ConnectionString);
            _connection.Open(); 
            _inventarioAdoRepositorio = inventarioAdoRepositorio;
        }

        public async Task GuardarCambiosAsync()
        {
            try
            {
                await _connection.CloseAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
