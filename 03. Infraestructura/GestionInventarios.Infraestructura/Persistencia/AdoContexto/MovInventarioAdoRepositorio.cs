using GestionInventarios.Aplicacion.Persistencia;
using GestionInventarios.Dominio.Entidades;
using Microsoft.Data.SqlClient;

namespace GestionInventarios.Infraestructura.Persistencia.AdoContexto
{
    public class MovInventarioAdoRepositorio : IMovInventarioAdoRepositorio
    {
        private readonly SqlConnection _connection;

        public MovInventarioAdoRepositorio(SqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<MovInventario>> ConsultarAsync(MovInventario mov)
        {
            var lista = new List<MovInventario>();
            using var command = new SqlCommand("sp_ConsultarMovInventario", _connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@TipoMovimiento", mov.TipoMovimiento ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@NumeroDocumento", mov.NroDocumento ?? (object)DBNull.Value);

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                lista.Add(new MovInventario
                {
                    CodCia = reader["COD_CIA"].ToString(),
                    CompaniaVenta3 = reader["COMPANIA_VENTA_3"].ToString(),
                    AlmacenVenta = reader["ALMACEN_VENTA"].ToString(),
                    TipoMovimiento = reader["TIPO_MOVIMIENTO"].ToString(),
                    TipoDocumento = reader["TIPO_DOCUMENTO"].ToString(),
                    NroDocumento = reader["NRO_DOCUMENTO"].ToString(),
                    CodItem2 = reader["COD_ITEM_2"].ToString(),
                    Proveedor = reader["PROVEEDOR"] as string,
                    AlmacenDestino = reader["ALMACEN_DESTINO"] as string,
                    Cantidad = reader["CANTIDAD"] as int?,
                    DocRef1 = reader["DOC_REF_1"] as string,
                    DocRef2 = reader["DOC_REF_2"] as string,
                    DocRef3 = reader["DOC_REF_3"] as string,
                    DocRef4 = reader["DOC_REF_4"] as string,
                    DocRef5 = reader["DOC_REF_5"] as string,
                    FechaTransaccion = reader["FECHA_TRANSACCION"] as DateTime?
                });
            }
            return lista;
        }

        public async Task InsertarAsync(MovInventario mov)
        {
            using var command = new SqlCommand("sp_InsertarMovInventario", _connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@COD_CIA", mov.CodCia);
            command.Parameters.AddWithValue("@COMPANIA_VENTA_3", mov.CompaniaVenta3);
            command.Parameters.AddWithValue("@ALMACEN_VENTA", mov.AlmacenVenta);
            command.Parameters.AddWithValue("@TIPO_MOVIMIENTO", mov.TipoMovimiento);
            command.Parameters.AddWithValue("@TIPO_DOCUMENTO", mov.TipoDocumento);
            command.Parameters.AddWithValue("@NRO_DOCUMENTO", mov.NroDocumento);
            command.Parameters.AddWithValue("@COD_ITEM_2", mov.CodItem2);
            command.Parameters.AddWithValue("@PROVEEDOR", mov.Proveedor ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ALMACEN_DESTINO", mov.AlmacenDestino ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CANTIDAD", mov.Cantidad ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@DOC_REF_1", mov.DocRef1 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@DOC_REF_2", mov.DocRef2 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@DOC_REF_3", mov.DocRef3 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@DOC_REF_4", mov.DocRef4 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@DOC_REF_5", mov.DocRef5 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@FECHA_TRANSACCION", mov.FechaTransaccion ?? (object)DBNull.Value);

            await command.ExecuteNonQueryAsync();
        }

        public async Task ActualizarAsync(MovInventario mov)
        {
            using var command = new SqlCommand("sp_ActualizarMovInventario", _connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@COD_CIA", mov.CodCia);
            command.Parameters.AddWithValue("@COMPANIA_VENTA_3", mov.CompaniaVenta3);
            command.Parameters.AddWithValue("@ALMACEN_VENTA", mov.AlmacenVenta);
            command.Parameters.AddWithValue("@TIPO_MOVIMIENTO", mov.TipoMovimiento);
            command.Parameters.AddWithValue("@TIPO_DOCUMENTO", mov.TipoDocumento);
            command.Parameters.AddWithValue("@NRO_DOCUMENTO", mov.NroDocumento);
            command.Parameters.AddWithValue("@COD_ITEM_2", mov.CodItem2);
            command.Parameters.AddWithValue("@PROVEEDOR", mov.Proveedor ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ALMACEN_DESTINO", mov.AlmacenDestino ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CANTIDAD", mov.Cantidad ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@DOC_REF_1", mov.DocRef1 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@DOC_REF_2", mov.DocRef2 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@DOC_REF_3", mov.DocRef3 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@DOC_REF_4", mov.DocRef4 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@DOC_REF_5", mov.DocRef5 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@FECHA_TRANSACCION", mov.FechaTransaccion ?? (object)DBNull.Value);

            await command.ExecuteNonQueryAsync();
        }

        public async Task EliminarAsync(MovInventario mov)
        {
            using var command = new SqlCommand("sp_EliminarMovInventario", _connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@COD_CIA", mov.CodCia);

            await command.ExecuteNonQueryAsync();
        }
    }
}
