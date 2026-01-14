using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
	public class CajaDat : ICajaDat
	{
        public async Task<IEnumerable<CajaEnt>> Obtener()
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Caja_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItems(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<IEnumerable<CajaEnt>> ObtenerByLikeNombre(string Nombre)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("Sp_Caja__ObtenerByLikeNombre", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Nombre", Nombre);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItems(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<CajaEnt> ObtenerById(int id)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Caja_ObtenerById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Id", id);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await Read(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<CajaValidacionDTO> ConsultarAperturaCaja(int idSede)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Caja_ConsultarApertura", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                var reader = await cmd.ExecuteReaderAsync();

                CajaValidacionDTO obj = new CajaValidacionDTO();
                while (await reader.ReadAsync())
                {
                    obj.CajaPermitida = Convert.ToBoolean(reader["CajaPermitida"]);
                    obj.Mensaje = reader["Mensaje"].ToString();
                }
                return obj;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<Respuesta<CajaEnt>> Insertar(CajaEnt model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Caja_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pDescripcion", model.Descripcion);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pUsuarioRegistra", model.UsuarioRegistra);
                cmd.Parameters.AddWithValue("pIdUsuarioResponsable", model.IdUsuarioResponsable);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItem(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<Respuesta<CajaEnt>> Modificar(CajaEnt model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Caja_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pId", model.Id);
                cmd.Parameters.AddWithValue("pDescripcion", model.Descripcion);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pUsuarioEdita", model.UsuarioRegistra);
                cmd.Parameters.AddWithValue("pIdUsuarioResponsable", model.IdUsuarioResponsable);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItem(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<Respuesta<CajaEnt>> AbrirCerrar(CajaEnt model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Caja_AbrirCerrar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCaja", model.Id);
                cmd.Parameters.AddWithValue("pAbrirCaja", model.AbrirCaja);
                cmd.Parameters.AddWithValue("pIdUsuarioResponsable", model.IdUsuarioResponsable);
                cmd.Parameters.AddWithValue("pFechaApertura", model.FechaHoraAperturaStr);
                cmd.Parameters.AddWithValue("pSaldoInicial", model.SaldoInicial);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItem(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<CajaCuadreDTO> CuadreDeCaja(DateTime fecha, int idCaja)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Caja_CuadreTicket", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCaja", idCaja);
                cmd.Parameters.AddWithValue("pFecha", fecha);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemCuadre(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> VerificaEstadoCaja(DateTime fecha, int idCaja)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Caja_VerificaEstado", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCaja", idCaja);
                cmd.Parameters.AddWithValue("pFechaCaja", fecha);
                var reader = await cmd.ExecuteScalarAsync();

                conn.Close();

                return Convert.ToInt32(reader);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        // READERS

        static async Task<CajaEnt> Read(DbDataReader reader)
        {
            try
            {
                CajaEnt obj = new CajaEnt();
                while (await reader.ReadAsync())
                {
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Descripcion = reader["Descripcion"].ToString();
                    obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.UsuarioResponsable = Convert.ToString(reader["UsuarioResponsable"]);
                    obj.IdUsuarioResponsable = Convert.ToInt32(reader["IdUsuarioResponsable"]);
                }



                return obj;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        static async Task<Respuesta<CajaEnt>> ReadItem(DbDataReader reader)
        {
            try
            {
                Respuesta<CajaEnt> obj = new Respuesta<CajaEnt>
                {
                    Response = new CajaEnt()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    obj.ErrorNumero = Convert.ToInt32(reader["ErrorNumero"]);
                    obj.ErrorDetalle = reader["ErrorDetalle"].ToString();
                    obj.Response.Id = Convert.ToInt32(reader["Id"]);
                    if (obj.Exito)
                    {
                        obj.Response.Descripcion = Convert.ToString(reader["Descripcion"]);
                    }
                }



                return obj;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        static async Task<IEnumerable<CajaEnt>> ReadItems(DbDataReader reader)
        {
            try
            {
                IList<CajaEnt> lista = new List<CajaEnt>();
                while (await reader.ReadAsync())
                {
                    CajaEnt obj = new CajaEnt
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Descripcion = reader["Descripcion"].ToString(),
                        Sede = Convert.ToString(reader["Sede"]),
                        IdSede = Convert.ToInt32(reader["IdSede"]),
                        Apertura = reader["Apertura"].ToString(),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        FechaHoraApertura = reader["FechaHoraApertura"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaHoraApertura"]),
                        UsuarioResponsable = reader["UsuarioResponsable"].ToString(),
                        IdUsuarioResponsable = Convert.ToInt32(reader["IdUsuarioResponsable"])
                    };
                    lista.Add(obj);
                }



                return lista;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        static async Task<CajaCuadreDTO> ReadItemCuadre(DbDataReader reader)
        {
            try
            {
                CajaCuadreDTO obj = new CajaCuadreDTO();
                while (await reader.ReadAsync())
                {
                    obj.SaldoInicial = Convert.ToDecimal(reader["SaldoInicial"]);
                    obj.Ingreso = Convert.ToDecimal(reader["Ingreso"]);
                    obj.Egreso = Convert.ToDecimal(reader["Egreso"]);
                    obj.Total = Convert.ToDecimal(reader["Total"]);
                }



                return obj;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


    }
}
