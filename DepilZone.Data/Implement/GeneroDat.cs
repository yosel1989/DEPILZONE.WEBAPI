using DepilZone.Data.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class GeneroDat : IGeneroDat
    {
        public async Task<IEnumerable<GeneroEnt>> Obtener()
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Genero_Obtener", conn)
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


        static async Task<IEnumerable<GeneroEnt>> ReadItems(DbDataReader reader)
        {
            try
            {
                GeneroEnt obj = null;
                IList<GeneroEnt> lista = new List<GeneroEnt>();
                while (await reader.ReadAsync())
                {
                    obj = new GeneroEnt();
                    obj.Id = reader.GetFieldValue<int>(0);
                    obj.Descripcion = reader["Descripcion"].ToString();
                    obj.Activo = Convert.ToInt32(reader["Activo"]);
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
