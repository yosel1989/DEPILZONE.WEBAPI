using DepilZone.Data.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class EstadoDat : IEstadoDat
    {

        public async Task<IEnumerable<EstadoEnt>> Obtener()
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Estado_Obtener", conn)
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

        public async Task<IEnumerable<EstadoEnt>> ObtenerByEntidad(string entidad)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Estado_ObtenerByEntidad", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pEntidad", entidad);
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

        static async Task<IEnumerable<EstadoEnt>> ReadItems(DbDataReader reader)
        {
            try
            {
                IList<EstadoEnt> lista = new List<EstadoEnt>();
                while (await reader.ReadAsync())
                {
                    EstadoEnt obj = new EstadoEnt
                    {
                        Id = reader.GetFieldValue<int>(0),
                        Descripcion = reader["Descripcion"].ToString()
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
