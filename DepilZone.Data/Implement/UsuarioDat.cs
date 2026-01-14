using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DepilZone.Data
{
    public class UsuarioDat: IUsuarioDat
    {
        public async Task<IEnumerable<UsuarioGridDTO>> Obtener(bool idEstado)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("IdEstado", idEstado);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsObtener(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerListadoGrilla()
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_ObtenerListadoGrilla", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsObtener(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UsuarioEnt> ObtenerByIdUsuario(Int32 IdUsuario)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_ObtenerById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", IdUsuario);
                cmd.Parameters.AddWithValue("pParametro", DBConn.ParametroCripto());
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
        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerByIdPerfil(string idPerfil, int idSede)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_ObtenerByIdPerfil", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                if (idPerfil == "0") idPerfil = "";

                cmd.Parameters.AddWithValue("IdPerfil", idPerfil);
                cmd.Parameters.AddWithValue("IdSede", idSede);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsByPerfil(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerResponsableCaja()
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_ObtenerResponsableCaja", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsByPerfil(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerByLikeNombre(string Nombre)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_ObtenerByLikeNombre", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("Nombre", Nombre);
                var reader = await cmd.ExecuteReaderAsync();
                UsuarioGridDTO obj = null;
                IList<UsuarioGridDTO> lista = new List<UsuarioGridDTO>();
                while (await reader.ReadAsync())
                {
                    obj = new UsuarioGridDTO
                    {
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        Nombre = reader["Nombre"].ToString(),
                        Usuario = reader["Usuario"].ToString(),
                        Clave = reader["Clave"].ToString(),
                        IdPerfil = Convert.ToInt32(reader["IdPerfil"]),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        Perfil = reader["Perfil"].ToString(),
                        Sede = reader["Sede"].ToString(),
                        UsuarioRegistra = reader["UsuarioRegistra"].ToString(),
                        FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]).ToString("dd-MM-yyyy")
                    };
                    lista.Add(obj);
                }


                conn.Close();

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Respuesta<UsuarioEnt>> Insertar(UsuarioEnt model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pNombre", model.Nombre);
                cmd.Parameters.AddWithValue("pUsuario", model.Usuario);
                cmd.Parameters.AddWithValue("pClave", model.Clave);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pIdPerfil", model.IdPerfil);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pFoto", model.Foto);
                cmd.Parameters.AddWithValue("pUsuarioRegistra", model.UsuarioRegistra);
                cmd.Parameters.AddWithValue("pParametro", DBConn.ParametroCripto());
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
        public async Task<Respuesta<UsuarioEnt>> Modificar(UsuarioEnt model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", model.IdUsuario);
                cmd.Parameters.AddWithValue("pNombre", model.Nombre);
                cmd.Parameters.AddWithValue("pUsuario", model.Usuario);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pIdPerfil", model.IdPerfil);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pFoto", model.Foto);
                cmd.Parameters.AddWithValue("pUsuarioEdita", model.UsuarioEdita);
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

        public async Task<Respuesta<UsuarioCambiarClaveDTO>> CambiarClave(UsuarioCambiarClaveDTO model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_CambiarClave", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", model.IdUsuario);
                cmd.Parameters.AddWithValue("pClaveActual", model.ClaveActual);
                cmd.Parameters.AddWithValue("pClaveNueva", model.ClaveNueva);
                cmd.Parameters.AddWithValue("pParametro", DBConn.ParametroCripto());
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemCambiarClave(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Respuesta<LoginDTO>> Login(LoginDTO model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Login", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pUsuario", model.Usuario);
                cmd.Parameters.AddWithValue("pClave", model.Password);
                cmd.Parameters.AddWithValue("pParametro", DBConn.ParametroCripto());
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadLogin(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<MenuDTO>> ObtenerMenuByPerfil(int idPerfil)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_ObtenerMenuByPerfil", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdPerfil", idPerfil);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerMenuByPerfil(reader);

                conn.Close();

                return output.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<UsuarioGridDTO>> ListarParaPreferentes()
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_ObtenerByPreferentes", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                UsuarioGridDTO obj = null;
                List<UsuarioGridDTO> lista = new List<UsuarioGridDTO>();
                while (await reader.ReadAsync())
                {
                    obj = new UsuarioGridDTO
                    {
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        Nombre = reader["Nombre"].ToString(),
                        Usuario = reader["Usuario"].ToString(),
                    };
                    lista.Add(obj);
                }


                conn.Close();

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<ShortUser>> CollectionByEstado(int idEstado)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Usuario_CollectionByEstado", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdEstado", idEstado);
                var reader = await cmd.ExecuteReaderAsync();
                List<ShortUser> lista = new List<ShortUser>();
                while (await reader.ReadAsync())
                {
                    var obj = new ShortUser
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"].ToString()
                    };
                    lista.Add(obj);
                }


                conn.Close();

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // READERS

        static async Task<Respuesta<UsuarioCambiarClaveDTO>> ReadItemCambiarClave(DbDataReader reader)
        {
            try
            {
                Respuesta<UsuarioCambiarClaveDTO> obj = new Respuesta<UsuarioCambiarClaveDTO>
                {
                    Response = new UsuarioCambiarClaveDTO()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    obj.ErrorNumero = Convert.ToInt32(reader["ErrorNumero"]);
                    obj.ErrorDetalle = reader["ErrorDetalle"].ToString();
                    if (obj.Exito)
                    {
                        obj.Response.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                    }
                }


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static async Task<UsuarioEnt> Read(DbDataReader reader)
        {
            try
            {
                UsuarioEnt obj = new UsuarioEnt();
                while (await reader.ReadAsync())
                {
                    obj.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                    obj.Nombre = Convert.ToString(reader["Nombre"]);
                    obj.Usuario = Convert.ToString(reader["Usuario"]);
                    obj.Clave = Convert.ToString(reader["Clave"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.IdPerfil = Convert.ToInt32(reader["IdPerfil"]);
                    obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                    obj.UsuarioRegistra = Convert.ToString(reader["UsuarioRegistra"]);
                    obj.FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]);
                    obj.Foto = reader["Foto"].ToString();
                }


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static async Task<Respuesta<UsuarioEnt>> ReadItem(DbDataReader reader)
        {
            try
            {
                Respuesta<UsuarioEnt> obj = new Respuesta<UsuarioEnt>
                {
                    Response = new UsuarioEnt()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    obj.ErrorNumero = Convert.ToInt32(reader["ErrorNumero"]);
                    obj.ErrorDetalle = reader["ErrorDetalle"].ToString();
                    if (obj.Exito)
                    {
                        obj.Response.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                        obj.Response.Nombre = Convert.ToString(reader["Nombre"]);
                        obj.Response.Usuario = Convert.ToString(reader["Usuario"]);
                        obj.Response.Clave = Convert.ToString(reader["Clave"]);
                        obj.Response.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        obj.Response.IdPerfil = Convert.ToInt32(reader["IdPerfil"]);
                        obj.Response.IdSede = Convert.ToInt32(reader["IdSede"]);
                        obj.Response.Foto = reader["Foto"] != DBNull.Value ? reader["Foto"].ToString() : null;
                        obj.Response.UsuarioRegistra = Convert.ToString(reader["UsuarioRegistra"]);
                        obj.Response.FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]);
                    }
                }


                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static async Task<Respuesta<LoginDTO>> ReadLogin(DbDataReader reader)
        {
            try
            {
                Respuesta<LoginDTO> obj = new Respuesta<LoginDTO>
                {
                    Response = new LoginDTO()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    if (obj.Exito)
                    {
                        obj.Response.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                        obj.Response.Nombre = Convert.ToString(reader["Nombre"]);
                        obj.Response.Usuario = Convert.ToString(reader["Usuario"]);
                        obj.Response.Perfil = Convert.ToString(reader["Perfil"]);
                        obj.Response.IdPerfil = Convert.ToInt32(reader["IdPerfil"]);
                        obj.Response.Foto = reader["Foto"].ToString();
                        obj.Response.IdSede = Convert.ToInt32(reader["idSede"]);
                        obj.Response.Sede = reader["Sede"].ToString();
                    }
                }

                //Leer el menu
                List<MenuDTO> listaMenu = new List<MenuDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        MenuDTO menu = new MenuDTO()
                        {
                            IdMenu = Convert.ToInt32(reader["IdMenu"]),
                            IdPadre = reader["IdPadre"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdPadre"]),
                            Title = reader["Title"].ToString(),
                            IdMenuTipo = reader["IdMenuTipo"].ToString(),
                            Icon = reader["Icon"] == DBNull.Value ? "" : reader["Icon"].ToString(),
                            Url = reader["Url"].ToString(),
                            Id = reader["Id"].ToString(),
                            Visible = Convert.ToBoolean(reader["Visible"]),
                            Nivel = Convert.ToInt32(reader["Nivel"]),
                            Type = reader["Type"].ToString()
                        };
                        listaMenu.Add(menu);
                    }
                    IList<MenuDTO> resultado = OrdenarMenuPadreHijos(listaMenu, null);
                    obj.Response.Menu = resultado;
                }



                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<IList<MenuDTO>> ReadObtenerMenuByPerfil(DbDataReader reader)
        {
            try
            {
               

                //Leer el menu
                List<MenuDTO> listaMenu = new List<MenuDTO>();
               
                while (await reader.ReadAsync())
                {
                    MenuDTO menu = new MenuDTO()
                    {
                        IdMenu = Convert.ToInt32(reader["IdMenu"]),
                        IdPadre = reader["IdPadre"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdPadre"]),
                        Title = reader["Title"].ToString(),
                        IdMenuTipo = reader["IdMenuTipo"].ToString(),
                        Icon = reader["Icon"] == DBNull.Value ? "" : reader["Icon"].ToString(),
                        Url = reader["Url"].ToString(),
                        Id = reader["Id"].ToString(),
                        Visible = Convert.ToBoolean(reader["Visible"]),
                        Nivel = Convert.ToInt32(reader["Nivel"]),
                        Type = reader["Type"].ToString()
                    };
                    listaMenu.Add(menu);
                }
                IList<MenuDTO> resultado = OrdenarMenuPadreHijos(listaMenu, null);
              
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static IList<MenuDTO> OrdenarMenuPadreHijos(List<MenuDTO> Menus, int? IdPadre)
        {
            try
            {
                List<MenuDTO> MenuResultado = new List<MenuDTO>();

                //obtener los datos del nivel indicado
                List<MenuDTO> menuNivel = Menus.Where(x => x.IdPadre == IdPadre).ToList();
                foreach (MenuDTO menu in menuNivel)
                {
                    MenuDTO menuDto = new MenuDTO
                    {
                        Id = menu.Id,
                        Title = menu.Title,
                        IdPadre = menu.IdPadre,
                        Type = menu.Type,
                        Url = menu.Url,
                        Icon = menu.Icon,
                        IdMenu = menu.IdMenu,
                        Visible = menu.Visible,
                        Children = OrdenarMenuPadreHijos(Menus, menu.IdMenu)
                    };
                    MenuResultado.Add(menuDto);
                }

                return MenuResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static async Task<IEnumerable<UsuarioGridDTO>> ReadItemsByPerfil(DbDataReader reader)
        {
            try
            {
                IList<UsuarioGridDTO> lista = new List<UsuarioGridDTO>();
                while (await reader.ReadAsync())
                {
                    UsuarioGridDTO obj = new UsuarioGridDTO
                    {
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        Nombre = reader["Nombre"].ToString(),
                        Usuario = reader["Usuario"].ToString(),
                        Clave = reader["Clave"].ToString(),
                        IdPerfil = Convert.ToInt32(reader["IdPerfil"]),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        Perfil = reader["Perfil"].ToString(),
                        UsuarioRegistra = reader["UsuarioRegistra"].ToString(),
                        FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]).ToString("dd-MM-yyyy"),
                        IdSede = Convert.ToInt32(reader["IdSede"]),
                        Sede = reader["Sede"].ToString(),
                        Foto = reader["Foto"].ToString()
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
        static async Task<IEnumerable<UsuarioGridDTO>> ReadItemsObtener(DbDataReader reader)
        {
            try
            {
                IList<UsuarioGridDTO> lista = new List<UsuarioGridDTO>();
                while (await reader.ReadAsync())
                {
                    UsuarioGridDTO obj = new UsuarioGridDTO
                    {
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        Nombre = reader["Nombre"].ToString(),
                        Usuario = reader["Usuario"].ToString(),
                        Clave = reader["Clave"].ToString(),
                        IdPerfil = Convert.ToInt32(reader["IdPerfil"]),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        Perfil = reader["Perfil"].ToString(),
                        UsuarioRegistra = reader["UsuarioRegistra"].ToString(),
                        FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]).ToString("dd-MM-yyyy"),
                        IdSede = Convert.ToInt32(reader["IdSede"]),
                        Sede = reader["Sede"].ToString(),
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
