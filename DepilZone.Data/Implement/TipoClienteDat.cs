using DepilZone.Data.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
	public class TipoClienteDat : ITipoClienteDat
	{
        public async Task<IEnumerable<TipoClienteEnt>> Obtener()
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_TipoCliente_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItems(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // READERS


        static async Task<IEnumerable<TipoClienteEnt>> ReadItems(DbDataReader reader)
        {
            try
            {
                IList<TipoClienteEnt> lista = new List<TipoClienteEnt>();
                while (await reader.ReadAsync())
                {
                    TipoClienteEnt obj = new TipoClienteEnt
                    {
                        IdTipoCliente = Convert.ToInt32(reader["IdTipoCliente"]),
                        TipoCliente = reader["TipoCliente"].ToString(),
                    };
                    lista.Add(obj);
                }


                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
