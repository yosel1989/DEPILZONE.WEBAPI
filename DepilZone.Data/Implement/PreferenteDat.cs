using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class PreferenteDat : IPreferenteDat
    {
        public async Task<Respuesta<PreferenteEnt>> Asignar(PreferenteEnt model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_Asignar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Id", model.Id);
                cmd.Parameters.AddWithValue("IdTeleoperador", model.IdTeleoperador);
                cmd.Parameters.AddWithValue("UsuarioEdita", model.UsuarioEdita);
                cmd.Parameters.AddWithValue("PreferenteObservacion", JsonSerializer.Serialize(model.PreferenteObservacion));
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

        public async Task<Respuesta<PreferenteEnt>> Atendido(PreferenteEnt model)        
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_Atendido", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Id", model.Id);
                cmd.Parameters.AddWithValue("IdEstadoAtendido", model.IdEstadoAtencion);
                cmd.Parameters.AddWithValue("PreferenteComentario", model.Comentario);
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

        public async Task<Respuesta<PreferenteEnt>> Insertar(PreferenteEnt model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Nombres", model.Nombres.ToUpper());
                cmd.Parameters.AddWithValue("Apellidos", model.Apellidos.ToUpper());
                cmd.Parameters.AddWithValue("Email", model.Email.ToUpper());
                cmd.Parameters.AddWithValue("Promocion", model.Promocion.ToUpper());
                cmd.Parameters.AddWithValue("IdUbicacion", model.IdUbicacion);
                cmd.Parameters.AddWithValue("Direccion", model.Direccion.ToUpper());
                cmd.Parameters.AddWithValue("IdTeleoperador", model.IdTeleoperador);
                cmd.Parameters.AddWithValue("IdComentario", model.IdComentario);
                cmd.Parameters.AddWithValue("IdMedioContacto", model.IdMedioContacto);
                cmd.Parameters.AddWithValue("IdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("OtroMedioContacto", model.OtroMedioContacto);
                cmd.Parameters.AddWithValue("UsuarioRegistra", model.UsuarioRegistra);
                cmd.Parameters.AddWithValue("PreferenteTelefono", JsonSerializer.Serialize(model.PreferenteTelefono));
                cmd.Parameters.AddWithValue("PreferenteZonaCorporal", JsonSerializer.Serialize(model.PreferenteZonaCorporal));
                cmd.Parameters.AddWithValue("PreferenteObservacion", JsonSerializer.Serialize(model.PreferenteObservacion));
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

        public async Task<Respuesta<PreferenteEnt>> Modificar(PreferenteEnt model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Id", model.Id);
                cmd.Parameters.AddWithValue("Nombres", model.Nombres.ToUpper());
                cmd.Parameters.AddWithValue("Apellidos", model.Apellidos.ToUpper());
                cmd.Parameters.AddWithValue("Email", model.Email.ToUpper());
                cmd.Parameters.AddWithValue("Promocion", model.Promocion.ToUpper());
                cmd.Parameters.AddWithValue("IdUbicacion", model.IdUbicacion);
                cmd.Parameters.AddWithValue("Direccion", model.Direccion.ToUpper());
                cmd.Parameters.AddWithValue("IdTeleoperador", model.IdTeleoperador);
                cmd.Parameters.AddWithValue("IdComentario", model.IdComentario);
                cmd.Parameters.AddWithValue("IdMedioContacto", model.IdMedioContacto);
                cmd.Parameters.AddWithValue("IdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("OtroMedioContacto", model.OtroMedioContacto);
                cmd.Parameters.AddWithValue("UsuarioEdita", model.UsuarioEdita);
                cmd.Parameters.AddWithValue("PreferenteTelefono", JsonSerializer.Serialize(model.PreferenteTelefono));
                cmd.Parameters.AddWithValue("PreferenteZonaCorporal", JsonSerializer.Serialize(model.PreferenteZonaCorporal));
                cmd.Parameters.AddWithValue("PreferenteObservacion", JsonSerializer.Serialize(model.PreferenteObservacion));

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

        public async Task<IEnumerable<PreferenteGrillaDTO>> Obtener(DateTime? FechaDesde, DateTime? FechaHasta, int? IdEstado, int? IdUsuario, int? IdMedioContacto, int IdUsuarioSistema)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("FechaDesde", FechaDesde);
                cmd.Parameters.AddWithValue("FechaHasta", FechaHasta);
                cmd.Parameters.AddWithValue("IdEstado", IdEstado);
                cmd.Parameters.AddWithValue("IdTeleOperador", IdUsuario);
                cmd.Parameters.AddWithValue("IdMedioContacto", IdMedioContacto);
                cmd.Parameters.AddWithValue("IdUsuarioSistema", IdUsuarioSistema);
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

        public async Task<PreferenteDTO> ObtenerById(int Id, int IdUsuarioSistema)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_ObtenerById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("IdUsuarioSistema", IdUsuarioSistema);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await Read(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> RetornarSinAtender()
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_RetornarSinAtender", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                object scalar = await cmd.ExecuteScalarAsync();

                conn.Close();

                return Convert.ToInt32(scalar);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> ActualizaEstadoVisto(ListaIdsDTO idsPreferente)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_ActualizarEstadoVisto", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                string IdsString = string.Join(", ", idsPreferente.Ids);


                cmd.Parameters.AddWithValue("PreferenteIds", IdsString);

                object scalar = await cmd.ExecuteScalarAsync();

                conn.Close();

                return Convert.ToInt32(scalar);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ImportarExcel(List<PreferenteImportarDTO> listado)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_ImportarExcel", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pPreferentes", JsonSerializer.Serialize(listado));
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadExportarExcel(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> AsignarLista(List<PreferenteAsignarListaDTO> listado)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Preferente_AsignarLista", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pPreferentes", JsonSerializer.Serialize(listado));
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadExportarExcel(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        // READERS


        static async Task<bool> ReadExportarExcel(DbDataReader reader)
        {
            try
            {
                bool success = false;
                string mensaje = "";
                while (await reader.ReadAsync())
                {
                    success = Convert.ToBoolean(reader["Exito"]);
                    mensaje = reader["Mensaje"].ToString() + " " + reader["ErrorDetalle"].ToString();
                }

                if (!success)
                {
                    throw new SystemException(mensaje);
                }

                return success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<PreferenteDTO> Read(DbDataReader reader)
        {
            try
            {
                PreferenteDTO obj = new PreferenteDTO();
                while (await reader.ReadAsync())
                {
                    obj.Id = Convert.ToInt32(reader["Id"]);
                    obj.Nombres = Convert.ToString(reader["Nombres"]);
                    obj.Apellidos = Convert.ToString(reader["Apellidos"]);
                    obj.Email = Convert.ToString(reader["Email"]);
                    obj.Promocion = Convert.ToString(reader["Promocion"]);
                    obj.IdUbicacion = Convert.ToString(reader["IdUbicacion"]);
                    obj.Direccion = Convert.ToString(reader["Direccion"]);
                    obj.IdTeleoperador = reader["IdTeleoperador"] as int? ?? null;
                    obj.IdComentario = reader["IdComentario"] as int? ?? null;
                    obj.IdMedioContacto = Convert.ToInt32(reader["IdMedioContacto"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.OtroMedioContacto = Convert.ToString(reader["OtroMedioContacto"]);
                    obj.FechaAsignacion = reader["FechaAsignacion"] != DBNull.Value ? Convert.ToDateTime(reader["FechaAsignacion"]) : (DateTime?)null;
                    obj.UsuarioRegistra = Convert.ToString(reader["UsuarioRegistra"]);
                    obj.FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]);
                    obj.UsuarioEdita = reader["UsuarioEdita"] as string;
                    obj.FechaEdita = reader["FechaEdita"] as DateTime? ?? null;

                    obj.Distrito = reader["Distrito"] as string;
                    obj.Provincia = reader["Provincia"] as string;
                    obj.Departamento = reader["Departamento"] as string;

                    obj.PreferenteTelefono = reader["PreferenteTelefono"] != DBNull.Value ? JsonSerializer.Deserialize<List<PreferenteTelefonoEnt>>(reader["PreferenteTelefono"].ToString()) : null;
                    obj.PreferenteZonaCorporal = reader["PreferenteZonaCorporal"] != DBNull.Value ? JsonSerializer.Deserialize<List<PreferenteZonaCorporalEnt>>(reader["PreferenteZonaCorporal"].ToString()) : null;
                    obj.PreferenteObservacion = reader["PreferenteObservacion"] != DBNull.Value ? JsonSerializer.Deserialize<List<PreferenteObservacionDTO>>(reader["PreferenteObservacion"].ToString()) : null;
                }


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<Respuesta<PreferenteEnt>> ReadItem(DbDataReader reader)
        {
            try
            {
                Respuesta<PreferenteEnt> obj = new Respuesta<PreferenteEnt>
                {
                    Response = new PreferenteEnt()
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
                        obj.Response.Nombres = Convert.ToString(reader["Nombres"]);
                        obj.Response.Apellidos = Convert.ToString(reader["Apellidos"]);
                        obj.Response.Email = Convert.ToString(reader["Email"]);
                        obj.Response.Promocion = Convert.ToString(reader["Promocion"]);
                        obj.Response.IdUbicacion = Convert.ToString(reader["IdUbicacion"]);
                        obj.Response.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        obj.Response.Direccion = Convert.ToString(reader["Direccion"]);
                        obj.Response.IdTeleoperador = reader["IdTeleoperador"] as int? ?? null;
                        obj.Response.IdComentario = reader["IdComentario"] as int? ?? null;
                        obj.Response.IdMedioContacto = Convert.ToInt32(reader["IdMedioContacto"]);
                        obj.Response.OtroMedioContacto = Convert.ToString(reader["OtroMedioContacto"]);
                        obj.Response.FechaAsignacion = reader["FechaAsignacion"] != DBNull.Value ? Convert.ToDateTime(reader["FechaAsignacion"]) : (DateTime?)null;
                        obj.Response.UsuarioRegistra = Convert.ToString(reader["UsuarioRegistra"]);
                        obj.Response.FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]);
                        obj.Response.PreferenteTelefono = reader["PreferenteTelefono"] != DBNull.Value ? JsonSerializer.Deserialize<List<PreferenteTelefonoEnt>>(reader["PreferenteTelefono"].ToString()) : null;
                    }
                }


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        static async Task<IEnumerable<PreferenteGrillaDTO>> ReadItems(DbDataReader reader)
        {
            try
            {
                IList<PreferenteGrillaDTO> lista = new List<PreferenteGrillaDTO>();
                while (await reader.ReadAsync())
                {
                    PreferenteGrillaDTO obj = new PreferenteGrillaDTO
                    {
                        Id = reader.GetFieldValue<int>(0),
                        X = "",
                        Nombres = reader["Nombres"].ToString(),
                        Teleoperadora = reader["Teleoperador"].ToString(),
                        Comentario = reader["Comentario"].ToString(),
                        FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]).ToString("dd-MM-yyyy"),
                        FechaAsignacion = reader["FechaAsignacion"] != DBNull.Value ? Convert.ToDateTime(reader["FechaAsignacion"]).ToString("dd-MM-yyyy") : null,
                        Celular = reader["Celular"].ToString(),
                        Email = reader["Email"].ToString(),
                        Distrito = reader["Distrito"].ToString(),
                        ZonaCorporal = reader["ZonaCorporal"].ToString(),
                        MedioContacto = Convert.ToString(reader["MedioContacto"]),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        EstadoAtencion = Convert.ToString(reader["EstadoAtencion"])
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
