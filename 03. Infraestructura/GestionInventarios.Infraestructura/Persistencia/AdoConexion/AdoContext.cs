using Microsoft.Extensions.Configuration;

namespace GestionInventarios.Infraestructura.Persistencia.AdoConexion
{
    /// <summary>
    /// Contexto para la conexión ADO.NET
    /// </summary>
    public class AdoContext
    {
        private readonly IConfiguration _configuration;
        public AdoContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
