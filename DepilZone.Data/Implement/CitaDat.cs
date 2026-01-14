using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;


namespace DepilZone.Data.Implement
{
    public class CitaDat : ICitaDat
    {

        public async Task<IEnumerable<CitaDetalleZonaDTO>> ObtenerDetalleCitaPrecio(int idCita)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("sp_cita_obtenerdetalleprecio", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("idCita", idCita);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsZonaCita(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<IEnumerable<CitaDTO>> Obtener(DateTime fechaCita, string horaInicio, string horaTermino, int idSede, int idEstado, string pacienteCelular, int tipoCita, int idServicio)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_Obtener", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                if (pacienteCelular == "null") { pacienteCelular = null;  }
                if (horaInicio == "null") { horaInicio = null;  }
                if (horaTermino == "null") { horaTermino = null; }
                cmd.Parameters.AddWithValue("pFechaCita", fechaCita);
                cmd.Parameters.AddWithValue("pHoraInicio", horaInicio);
                cmd.Parameters.AddWithValue("pHoraTermino", horaTermino);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdEstado", idEstado);
                cmd.Parameters.AddWithValue("pPacienteCelular", pacienteCelular);
                cmd.Parameters.AddWithValue("pIdTipoCita", tipoCita);
                cmd.Parameters.AddWithValue("pIdServicio", idServicio);
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

        public async Task<List<CitaExportarDTO>> ObtenerExportar(DateTime fechaCita, string horaInicio, string horaTermino, int idSede, int idEstado, string pacienteCelular, int tipoCita)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ObtenerExportar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                if (pacienteCelular == "null") { pacienteCelular = null; }
                if (horaInicio == "null") { horaInicio = null; }
                if (horaTermino == "null") { horaTermino = null; }
                cmd.Parameters.AddWithValue("pFechaCita", fechaCita);
                cmd.Parameters.AddWithValue("pHoraInicio", horaInicio);
                cmd.Parameters.AddWithValue("pHoraTermino", horaTermino);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdEstado", idEstado);
                cmd.Parameters.AddWithValue("pPacienteCelular", pacienteCelular);
                cmd.Parameters.AddWithValue("pIdTipoCita", tipoCita);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsExportar(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<CitaDatosPreliminaresDTO> ObtenerDatosPreliminares()
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ObtenerDatosPreliminares", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadDatosPreliminares(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
            
        }

        public async Task<DashBoardDTO> ObtenerDashBoard(string fecha, int idSede, int idPerfil)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_Dashboard", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFecha", fecha);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdPerfil", idPerfil);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsDashBoard(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<IEnumerable<CitaDTO>> Obtenercitaid(int idCita)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ObtenerById2", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", idCita);
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
        public async Task<IEnumerable<CitaDTO>> ObtenerParaPerfil(int idCliente)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ObtenerParaPerfil", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCliente", idCliente);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsParaPerfil(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<IEnumerable<CitaDTO>> ObtenerParaPerfilPorServicio(int idCliente, int idServicio)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ObtenerParaPerfilPorServicio", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCliente", idCliente);
                cmd.Parameters.AddWithValue("pIdServicio", idServicio);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsParaPerfil(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<CitaDTO> ObtenerById(int idCita, bool esReprogramacion)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ObtenerById", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", idCita);
                cmd.Parameters.AddWithValue("pEsReprogramacion", esReprogramacion);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemById(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<Respuesta<CitaEnt>> Insertar(CitaEnt model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_Insertar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdTipoCita", model.IdTipoCita);
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pIdTipoCliente", model.IdTipoCliente);
                cmd.Parameters.AddWithValue("pIdMedioContacto", model.IdMedioContacto);
                cmd.Parameters.AddWithValue("pIdUsuario", model.IdUsuario);
                cmd.Parameters.AddWithValue("pIdMaquina", model.IdMaquina);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pIdDescuento", model.IdDescuento);
                cmd.Parameters.AddWithValue("pDescuentoAplicaA", model.DescuentoAplicaA);
                cmd.Parameters.AddWithValue("pCuponDescuento", model.CuponDescuento);

                cmd.Parameters.AddWithValue("pFechaCita", model.FechaCita);
                cmd.Parameters.AddWithValue("pHoraInicio", model.HoraInicio);
                cmd.Parameters.AddWithValue("pHoraTermino", model.HoraTermino);
                cmd.Parameters.AddWithValue("pTotal", model.Total);
                cmd.Parameters.AddWithValue("pUsuarioRegistra", model.UsuarioRegistra);
                cmd.Parameters.AddWithValue("pDetalles", JsonSerializer.Serialize(model.Detalles));
                cmd.Parameters.AddWithValue("pCitaMensajeAvisos", JsonSerializer.Serialize(model.CitaMensajeAvisos));
                cmd.Parameters.AddWithValue("pCitaMensajeNotas", JsonSerializer.Serialize(model.CitaMensajeNotas));
                cmd.Parameters.AddWithValue("pCitaMensajeDetalles", JsonSerializer.Serialize(model.CitaMensajeDetalles));
                cmd.Parameters.AddWithValue("pIdServicio", model.IdServicio);


                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemInsertar(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<Respuesta<CitaEnt>> Modificar(CitaEnt model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_Modificar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", model.IdCita);
                cmd.Parameters.AddWithValue("pIdTipoCita", model.IdTipoCita);
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pIdTipoCliente", model.IdTipoCliente);
                cmd.Parameters.AddWithValue("pIdMedioContacto", model.IdMedioContacto);
                cmd.Parameters.AddWithValue("pIdUsuario", model.IdUsuario);
                cmd.Parameters.AddWithValue("pIdMaquina", model.IdMaquina);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pIdDescuento", model.IdDescuento);
                cmd.Parameters.AddWithValue("pDescuentoAplicaA", model.DescuentoAplicaA);
                cmd.Parameters.AddWithValue("pCuponDescuento", model.CuponDescuento);

                cmd.Parameters.AddWithValue("pFechaCita", model.FechaCita);
                cmd.Parameters.AddWithValue("pHoraInicio", model.HoraInicio);
                cmd.Parameters.AddWithValue("pHoraTermino", model.HoraTermino);
                cmd.Parameters.AddWithValue("pTotal", model.Total);
                cmd.Parameters.AddWithValue("pUsuarioEdita", model.UsuarioRegistra);
                cmd.Parameters.AddWithValue("pDetalles", JsonSerializer.Serialize(model.Detalles));
                cmd.Parameters.AddWithValue("pCitaMensajeAvisos", JsonSerializer.Serialize(model.CitaMensajeAvisos));
                cmd.Parameters.AddWithValue("pCitaMensajeNotas", JsonSerializer.Serialize(model.CitaMensajeNotas));
                cmd.Parameters.AddWithValue("pCitaMensajeDetalles", JsonSerializer.Serialize(model.CitaMensajeDetalles));
                cmd.Parameters.AddWithValue("pIdServicio", model.IdServicio);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemInsertar(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        
        
        public async Task<Respuesta<CitaDTO>> ActualizarCondicionAnular(CitaDTO model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_Update_Anular", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", model.IdCita);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pCitaMensajeAvisos", JsonSerializer.Serialize(model.CitaMensajeAvisos));
                cmd.Parameters.AddWithValue("pCitaMensajeNotas", JsonSerializer.Serialize(model.CitaMensajeNotas));
                cmd.Parameters.AddWithValue("pCitaMensajeDetalles", JsonSerializer.Serialize(model.CitaMensajeDetalles));
                cmd.Parameters.AddWithValue("pIdUsuario", model.IdUsuario);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsCondicion(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<Respuesta<CitaDTO>> ActualizarCondicionCancelar(CitaDTO model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_Update_Cancelar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", model.IdCita);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pCitaMensajeAvisos", JsonSerializer.Serialize(model.CitaMensajeAvisos));
                cmd.Parameters.AddWithValue("pCitaMensajeNotas", JsonSerializer.Serialize(model.CitaMensajeNotas));
                cmd.Parameters.AddWithValue("pCitaMensajeDetalles", JsonSerializer.Serialize(model.CitaMensajeDetalles));
                cmd.Parameters.AddWithValue("pIdUsuario", model.IdUsuario);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsCondicion(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<Respuesta<CitaDTO>> ActualizarCondicionConfirmar(CitaDTO model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_Update_Confirmar", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", model.IdCita);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pCitaMensajeAvisos", JsonSerializer.Serialize(model.CitaMensajeAvisos));
                cmd.Parameters.AddWithValue("pCitaMensajeNotas", JsonSerializer.Serialize(model.CitaMensajeNotas));
                cmd.Parameters.AddWithValue("pCitaMensajeDetalles", JsonSerializer.Serialize(model.CitaMensajeDetalles));
                cmd.Parameters.AddWithValue("pIdUsuario", model.IdUsuario);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsCondicion(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<Respuesta<CitaDTO>> ActualizarCondicionPendiente(CitaDTO model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_Update_Pendiente", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", model.IdCita);
                cmd.Parameters.AddWithValue("pIdEstado", model.IdEstado);
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pCitaMensajeAvisos", JsonSerializer.Serialize(model.CitaMensajeAvisos));
                cmd.Parameters.AddWithValue("pCitaMensajeNotas", JsonSerializer.Serialize(model.CitaMensajeNotas));
                cmd.Parameters.AddWithValue("pCitaMensajeDetalles", JsonSerializer.Serialize(model.CitaMensajeDetalles));
                cmd.Parameters.AddWithValue("pIdUsuario", model.IdUsuario);
                cmd.Parameters.AddWithValue("pIdEstadoPendiente", model.IdEstadoPendiente);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsCondicion(reader);

                conn.Close();

                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public async Task<int> EstadoAtendido(CitaEnt model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_EstadoAtendido", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCita", model.IdCita);
                cmd.Parameters.AddWithValue("pIdUsuarioAtendidoPor", model.IdUsuarioAtendidoPor);
                cmd.Parameters.AddWithValue("pIdUsuarioModifico", model.IdUsuario);
                var reader = await cmd.ExecuteReaderAsync();

                int output = 0;

                while (await reader.ReadAsync())
                {
                    output = output + 1;
                }

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<Respuesta<CitaEnt>> InsertarReservacion(CitaEnt model)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_InsertarReservacion", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCliente", model.IdCliente);
                cmd.Parameters.AddWithValue("pIdUsuario", model.IdUsuario);
                cmd.Parameters.AddWithValue("pIdMaquina", model.IdMaquina);
                cmd.Parameters.AddWithValue("pIdSede", model.IdSede);

                cmd.Parameters.AddWithValue("pFechaCita", model.FechaCita);
                cmd.Parameters.AddWithValue("pHoraInicio", model.HoraInicio);
                cmd.Parameters.AddWithValue("pHoraTermino", model.HoraTermino);

                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemInsertar(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<bool> EliminarReservacion(int idUsuario)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_EliminarReservacion", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdUsuario", idUsuario);

                var output = cmd.ExecuteNonQuery() > 0;

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<IEnumerable<CitaComisionResumenDTO>> ObtenerComisionesResumen(DateTime fechaInicio, DateTime fechaTermino, int idUsuarioOperador)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ObtenerComisionesResumen", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaTermino", fechaTermino);
                cmd.Parameters.AddWithValue("pIdUsuarioOperador", idUsuarioOperador);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemComisionResumen(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<IEnumerable<CitaComisionDetalleDTO>> ObtenerComisionesDetalle(DateTime fechaInicio, DateTime fechaTermino, int idUsuarioOperador)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ObtenerComisionesDetalle", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaTermino", fechaTermino);
                cmd.Parameters.AddWithValue("pIdUsuarioOperador", idUsuarioOperador);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemComisionDetalle(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
       

        public async Task<IEnumerable<CitaMensajeNotaDTO>> ObtenerNotasEnCitaNueva(int idCliente)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ObtenerNotasCitaNueva", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pIdCliente", idCliente);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemNotaCitaNueva(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }



        public async Task<List<CitaTotalDTO>> ObtenerAgendadas(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ListarAgendadas", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaFin", fechaFin);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdGenero", idGenero);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsTotales(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<List<CitaTotalDTO>> ObtenerAtendidas(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ListarAtendidas", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaFin", fechaFin);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdGenero", idGenero);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsTotales(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<List<CitaTotalDTO>> ObtenerAgendadasCortesia(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ListarAgendadasCortesia", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaFin", fechaFin);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdGenero", idGenero);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsTotales(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }


        public async Task<List<CitaPromocionDTO>> ObtenerPorPromocion(DateTime fechaInicio, DateTime fechaFin, int idSede)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ListarPorPromocion", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaFin", fechaFin);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadItemsPromociones(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }



        public async Task<List<CitaReporteDTO>> ObtenerReporte(DateTime fechaInicio, DateTime fechaFin, int idSede, int idEstado, int idServicio, int idTipoCita)
        {
            try
            {
                using SqlConnection conn = DBConn.ConexionSQL();
                await conn.OpenAsync();
                using SqlCommand cmd = new SqlCommand("SP_Cita_ObtenerReporte", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("pFechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("pFechaFin", fechaFin);
                cmd.Parameters.AddWithValue("pIdSede", idSede);
                cmd.Parameters.AddWithValue("pIdEstado", idEstado);
                cmd.Parameters.AddWithValue("pIdServicio", idServicio);
                cmd.Parameters.AddWithValue("pIdTipoCita", idTipoCita);
                var reader = await cmd.ExecuteReaderAsync();
                var output = await ReadObtenerReporte(reader);

                conn.Close();

                return output;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }




        //****************************************************************** READERS

        static async Task<List<CitaTotalDTO>> ReadItemsTotales(DbDataReader reader)
        {
            try
            {
                List<CitaTotalDTO> collection = new List<CitaTotalDTO>();
                while (await reader.ReadAsync())
                {
                    var obj = new CitaTotalDTO();
                    obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                    obj.Sede = Convert.ToString(reader["Sede"]);
                    obj.FechaCita = Convert.ToDateTime(reader["FechaCita"]);
                    obj.NumCitas = Convert.ToInt32(reader["NumCitas"]);
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        static async Task<List<CitaPromocionDTO>> ReadItemsPromociones(DbDataReader reader)
        {
            try
            {
                List<CitaPromocionDTO> collection = new List<CitaPromocionDTO>();
                while (await reader.ReadAsync())
                {
                    var obj = new CitaPromocionDTO();
                    obj.IdCita = Convert.ToInt32(reader["IdCita"]);
                    obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                    obj.Sede = reader["Sede"].ToString();
                    obj.NumeroCita = Convert.ToInt32(reader["NumeroCita"]);
                    obj.Cliente = reader["Cliente"].ToString();
                    obj.FechaCita = Convert.ToDateTime(reader["FechaCita"]);
                    obj.HoraCita = reader["HoraCita"].ToString();
                    obj.Zona = reader["Zona"].ToString();
                    obj.IdZona = Convert.ToInt32(reader["IdZona"]);
                    obj.Sesion = Convert.ToInt32(reader["Sesion"]);
                    obj.IdPromocion = Convert.ToInt32(reader["IdPromocion"]);
                    obj.Promocion = reader["Promocion"].ToString();
                    obj.PromoFechaIni = Convert.ToDateTime(reader["PromoFechaIni"]);
                    obj.PromoFechaFin = Convert.ToDateTime(reader["PromoFechaFin"]);
                    obj.PrecioZona = Convert.ToDecimal(reader["PrecioZona"]);
                    obj.TotalCita = Convert.ToDecimal(reader["TotalCita"]);
                    obj.Estado = reader["Estado"].ToString();
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        static async Task<IEnumerable<CitaMensajeNotaDTO>> ReadItemNotaCitaNueva(DbDataReader reader)
        {
            try
            {
                IList<CitaMensajeNotaDTO> lista = new List<CitaMensajeNotaDTO>();
                while (await reader.ReadAsync())
                {
                    CitaMensajeNotaDTO obj = new CitaMensajeNotaDTO
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        IdCita = Convert.ToInt32(reader["IdCita"]),
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        Nota = Convert.ToString(reader["Nota"]),
                        FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                        InicialesUsuario = Convert.ToString(reader["InicialesUsuario"]),
                        UsuarioRegistra = Convert.ToString(reader["UsuarioRegistra"])
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
        static async Task<CitaDatosPreliminaresDTO> ReadDatosPreliminares(DbDataReader reader)
        {
            try
            {
                CitaDatosPreliminaresDTO datosPreliminares = new CitaDatosPreliminaresDTO();

                datosPreliminares.CitaTipos = new List<CitaTipoEnt>();
                while (await reader.ReadAsync())
                {
                    datosPreliminares.CitaTipos.Add(new CitaTipoEnt
                    {
                        IdTipoCita = Convert.ToInt32(reader["IdTipoCita"]),
                        Nombre = reader["Nombre"].ToString(),
                        IdEstado = Convert.ToInt32(reader["IdEstado"])
                    });
                }


                if (reader.NextResult())
                {
                    datosPreliminares.ClienteTipos = new List<TipoClienteEnt>();
                    while (await reader.ReadAsync())
                    {
                        datosPreliminares.ClienteTipos.Add(new TipoClienteEnt
                        {
                            IdTipoCliente = Convert.ToInt32(reader["IdTipoCliente"]),
                            TipoCliente = reader["TipoCliente"].ToString()
                        });
                    }
                }

                //if (reader.NextResult())
                //{
                //    datosPreliminares.Usuarios = new List<UsuarioGridDTO>();
                //    while (await reader.ReadAsync())
                //    {
                //        datosPreliminares.Usuarios.Add(new UsuarioGridDTO
                //        {
                //            IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                //            Nombre = reader["Nombre"].ToString(),
                //            Usuario = reader["Usuario"].ToString(),
                //            Clave = reader["Clave"].ToString(),
                //            IdPerfil = Convert.ToInt32(reader["IdPerfil"]),
                //            IdEstado = Convert.ToInt32(reader["IdEstado"]),
                //            Perfil = reader["Perfil"].ToString(),
                //            UsuarioRegistra = reader["UsuarioRegistra"].ToString(),
                //            FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]).ToString("dd-MM-yyyy"),
                //            IdSede = Convert.ToInt32(reader["IdSede"]),
                //            Sede = reader["Sede"].ToString(),
                //            Foto = reader["Foto"].ToString()
                //        });
                //    }
                //}

                if (reader.NextResult())
                {
                    datosPreliminares.Sedes = new List<SedeEnt>();
                    while (await reader.ReadAsync())
                    {
                        SedeEnt sede = new SedeEnt
                        {
                            IdSede = Convert.ToInt32(reader["IdSede"]),
                            IdUbicacion = reader["IdUbicacion"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Estado = Convert.ToInt32(reader["Estado"]),
                            Direccion = reader["Direccion"].ToString(),
                        };
                        sede.Ubicacion.IdUbicacion = reader["IdUbicacion"].ToString();
                        sede.Ubicacion.Departamento = reader["Departamento"].ToString();
                        sede.Ubicacion.Ciudad = reader["Ciudad"].ToString();
                        sede.Ubicacion.Distrito = reader["Distrito"].ToString();
                        sede.HoraInicio = reader["HoraInicio"].ToString();
                        sede.HoraFin = reader["HoraFin"].ToString();

                        datosPreliminares.Sedes.Add(sede);
                    }
                }

                if (reader.NextResult())
                {
                    datosPreliminares.ZonasCorporales = new List<ZonaCorporalGridDTO>();
                    while (await reader.ReadAsync())
                    {
                        datosPreliminares.ZonasCorporales.Add(new ZonaCorporalGridDTO
                        {
                            Id = reader.GetFieldValue<int>(0),
                            Descripcion = reader["Descripcion"].ToString(),
                            Duracion = Convert.ToInt32(reader["Duracion"]),
                            IdEstado = Convert.ToInt32(reader["IdEstado"]),
                            Genero = reader["Genero"].ToString(),
                            Sesion = 1,
                        });
                    }
                }

                if (reader.NextResult())
                {
                    datosPreliminares.MaquinaSedes = new List<MaquinaSedeGridDTO>();
                    while (await reader.ReadAsync())
                    {
                        datosPreliminares.MaquinaSedes.Add(new MaquinaSedeGridDTO
                        {
                            Id = reader.GetFieldValue<int>(0),
                            HoraInicio = reader["HoraInicio"].ToString(),
                            HoraFin = reader["HoraFin"].ToString(),
                            Descripcion = reader["Descripcion"].ToString(),
                            Maquina = reader["Descripcion"].ToString(),
                            Sede = reader["Sede"].ToString(),
                            IdEstado = Convert.ToInt32(reader["IdEstado"]),
                            IdMaquina = Convert.ToInt32(reader["IdMaquina"]),
                            IdSede = Convert.ToInt32(reader["IdSede"])
                        });
                    }
                }



                return datosPreliminares;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        static async Task<Respuesta<CitaEnt>> ReadItemInsertar(DbDataReader reader)
        {
            try
            {
                Respuesta<CitaEnt> obj = new Respuesta<CitaEnt>
                {
                    Response = new CitaEnt()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    obj.ErrorNumero = Convert.ToInt32(reader["ErrorNumero"]);
                    obj.ErrorDetalle = reader["ErrorDetalle"].ToString();
                    if (obj.Exito)
                    {
                        obj.Response.IdCita = Convert.ToInt32(reader["IdCita"]);
                        obj.Response.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                        obj.Response.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                        obj.Response.FechaCita = Convert.ToDateTime(reader["FechaCita"]);
                        obj.Response.HoraInicio = reader["HoraInicio"].ToString();
                        obj.Response.HoraTermino = reader["HoraTermino"].ToString();
                        obj.Response.IdMaquina = Convert.ToInt32(reader["IdMaquina"].ToString());
                        obj.Response.IdSede = Convert.ToInt32(reader["IdSede"].ToString());
                    }
                }



                return obj;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        static async Task<DashBoardDTO> ReadItemsDashBoard(DbDataReader reader)
        {
            try
            {
                DashBoardDTO dashBoard = new DashBoardDTO();

                //Obtener informacion de los dashboard permitidos
                dashBoard.ElementosPermitidos = new List<DashboardElementosPermitidosDTO>();
                while (await reader.ReadAsync())
                {
                    dashBoard.ElementosPermitidos.Add(new DashboardElementosPermitidosDTO()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = Convert.ToString(reader["Nombre"])
                    });
                }

                for (int i = 0; i < dashBoard.ElementosPermitidos.Count; i++)
                {
                    int idElemento = dashBoard.ElementosPermitidos[i].Id;
                    if (reader.NextResult())
                        dashBoard = await LeerSiguienteResultado(reader, dashBoard, idElemento);
                }



                return dashBoard;
            }
            catch (Exception EX)
            {
                throw EX;
            }
            
        }
        static async Task<DashBoardDTO> LeerSiguienteResultado(DbDataReader reader, DashBoardDTO dashboard, int IdElemento)
        {
            try
            {
                switch (IdElemento)
                {
                    case 1:
                        //Evolucion de citas
                        dashboard.ResumenCantidad = new CitaResumenCantidadDTO();
                        while (await reader.ReadAsync())
                        {
                            dashboard.Mes = Convert.ToString(reader["Mes"]);
                            dashboard.Anio = Convert.ToInt32(reader["Anio"]);
                            dashboard.DiaInicioMes = Convert.ToInt32(reader["DiaInicioMes"]);
                            dashboard.DiaTerminoMes = Convert.ToInt32(reader["DiaTerminoMes"]);
                            dashboard.ResumenCantidad.CitasTotales = Convert.ToInt32(reader["CitasTotales"]);
                            dashboard.ResumenCantidad.CitasRegistradas = Convert.ToInt32(reader["CitasRegistradas"]);
                            dashboard.ResumenCantidad.CitasConfirmadas = Convert.ToInt32(reader["CitasConfirmadas"]);
                            dashboard.ResumenCantidad.CitasAtendidas = Convert.ToInt32(reader["CitasAtendidas"]);
                            dashboard.ResumenCantidad.CitasCanceladas = Convert.ToInt32(reader["CitasCanceladas"]);
                            dashboard.ResumenCantidad.CitasAnuladas = Convert.ToInt32(reader["CitasAnuladas"]);
                            dashboard.ResumenCantidad.CitasReprogramadas = Convert.ToInt32(reader["CitasReprogramadas"]);
                        }
                        break;
                    case 2:
                        //Ultimas 5 citas atendidas
                        dashboard.UltimasAtendidas = new List<CitaUltimaAtendidadDTO>();
                        while (await reader.ReadAsync())
                        {
                            dashboard.UltimasAtendidas.Add(new CitaUltimaAtendidadDTO()
                            {
                                Apellidos = Convert.ToString(reader["Apellidos"]),
                                Foto = Convert.ToString(reader["Foto"]),
                                Nombres = Convert.ToString(reader["Nombres"]),
                                HoraInicio = Convert.ToString(reader["HoraInicio"]),
                                IdCliente = Convert.ToInt32(reader["Id"])
                            });
                        }
                        break;
                    case 3:
                        //Grafico semanal de citas
                        dashboard.CitasSemanal = new List<CitaAtendidaSemanalDTO>();
                        while (await reader.ReadAsync())
                        {
                            dashboard.CitasSemanal.Add(new CitaAtendidaSemanalDTO()
                            {
                                Day = Convert.ToString(reader["Day"]),
                                Value = Convert.ToInt32(reader["Value"])
                            });
                        }
                        break;
                    case 4:
                        //Grafico anual por mes de citas
                        dashboard.CitasAnual = new List<CitaAtendidaAnualDTO>();
                        while (await reader.ReadAsync())
                        {
                            CitaAtendidaAnualDTO citaAnual = new CitaAtendidaAnualDTO()
                            {
                                Year = Convert.ToString(reader["Year"]),
                                Value = Convert.ToInt32(reader["Value"]),
                                Value2 = Convert.ToInt32(reader["Value2"]),
                            };
                            dashboard.CitasAnual.Add(citaAnual);
                        }
                        break;
                    case 5:
                        //Grafico Zonas mas atendidas por dia
                        dashboard.CitasZonasAtendidas = new List<CitaAtendidaZonaCantidadDTO>();
                        while (await reader.ReadAsync())
                        {
                            dashboard.CitasZonasAtendidas.Add(new CitaAtendidaZonaCantidadDTO()
                            {
                                ZonaCorporal = Convert.ToString(reader["Zona"]),
                                Valor = Convert.ToInt32(reader["Cantidad"]),
                                Color1 = Convert.ToString(reader["Color1"]),
                                Color2 = Convert.ToString(reader["Color2"]),
                            });
                        }
                        break;
                    case 6:
                        //Grafico mensual por dia de citas
                        dashboard.CitasMensual = new List<CitaAtendidaMensualDTO>();
                        while (await reader.ReadAsync())
                        {
                            dashboard.CitasMensual.Add(new CitaAtendidaMensualDTO()
                            {
                                Average = Convert.ToString(reader["Average"]),
                                Value = Convert.ToInt32(reader["Value"]),
                                Color1 = Convert.ToString(reader["Color1"]),
                                Color2 = Convert.ToString(reader["Color2"]),
                            });
                        }
                        break;
                }



                return dashboard;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        static async Task<IEnumerable<CitaDTO>> ReadItems(DbDataReader reader)
        {
            try
            {
                IList<CitaDTO> lista = new List<CitaDTO>();
                while (await reader.ReadAsync())
                {
                    CitaDTO obj = new CitaDTO
                    {
                        IdCita = reader.GetFieldValue<int>(0),
                        Foto = reader["Foto"]==DBNull.Value ? "" :  reader["Foto"].ToString(),
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        IdSede = Convert.ToInt32(reader["IdSede"]),
                        IdMaquina = Convert.ToInt32(reader["IdMaquina"]),
                        Sede = reader["Sede"].ToString(),
                        Nombres = reader["Nombres"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        SeudonimoPaciente = reader["Seudonimo"].ToString(),
                        NumeroDocumentoIdentidad = reader["Documento"].ToString(),
                        FechaCita = Convert.ToDateTime(reader["FechaCita"]),
                        NumerosCelulares = reader["Celular1"].ToString() + " - " + reader["Celular2"].ToString(),
                        HoraCita = reader["HoraInicio"].ToString(),
                        HoraInicio = reader["HoraInicio"].ToString(),
                        HoraTermino = reader["HoraTermino"].ToString(),
                        Duracion = Convert.ToInt32(reader["Duracion"]),
                        TipoCita = reader["TipoCita"].ToString(),
                        NumeroHistoria = reader["IdHistoriaClinica"].ToString(),
                        ColorTipoCita = reader["ColorTipoCita"].ToString(),
                        ColorTextoTipoCita = reader["ColorTextoTipoCita"].ToString(),
                        Estado = reader["Estado"].ToString().ToUpper(),
                        ColorEstado = reader["ColorEstado"].ToString(),
                        Pagado = Convert.ToBoolean(reader["Pagado"]),
                        ColorPagado = reader["ColorPagado"].ToString(),
                        TipoCliente = reader["TipoCliente"].ToString(),
                        ColorTipoCliente = reader["ColorTipoCliente"].ToString(),
                        IdGenero = reader["IdGenero"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["IdGenero"]),
                        FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                        UsuarioRegistra = Convert.ToString(reader["UsuarioRegistra"]),
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        Usuario = reader["Usuario"].ToString(),
                        Efectividad = Convert.ToInt32(reader["Efectividad"]),
                        Satisfaccion = Convert.ToInt32(reader["Satisfaccion"].ToString()),
                        IdFichaAdmision = reader["IdFichaAdmision"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["IdFichaAdmision"]),
                        IdServicio = reader["IdServicio"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdServicio"]),
                        Servicio = reader["Servicio"] == DBNull.Value ? null : Convert.ToString(reader["Servicio"]),
                        ServicioColor = reader["ServicioColor"] == DBNull.Value ? null : Convert.ToString(reader["ServicioColor"]),
                    };
                    lista.Add(obj);
                }

                //Leer los avisos
                List<CitaMensajeAvisoEnt> avisos = new List<CitaMensajeAvisoEnt>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        CitaMensajeAvisoEnt aviso = new CitaMensajeAvisoEnt()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Aviso = reader["Aviso"].ToString(),
                            FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                            IdCita = Convert.ToInt32(reader["IdCita"])
                        };
                        avisos.Add(aviso);
                    }
                }
                //Leer los detalles
                List<CitaMensajeDetalleEnt> detalles = new List<CitaMensajeDetalleEnt>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        CitaMensajeDetalleEnt detalle = new CitaMensajeDetalleEnt()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Detalle = reader["Detalle"].ToString(),
                            FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                            IdCita = Convert.ToInt32(reader["IdCita"])
                        };
                        detalles.Add(detalle);
                    }
                }

                //Leer las zonas concatenadas
                List<ZonasContatenadasDTO> zonasConcatenadas = new List<ZonasContatenadasDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        ZonasContatenadasDTO zonas = new ZonasContatenadasDTO()
                        {
                            IdCita = Convert.ToInt32(reader["IdCita"]),
                            TotalCita = Convert.ToDouble(reader["Total"]),
                            ZonaContatenada = Convert.ToString(reader["Zonas"])
                        };
                        zonasConcatenadas.Add(zonas);
                    }
                }

                foreach (CitaDTO cita in lista)
                {
                    if (avisos.Count > 0)
                        cita.CitaAvisos = (from aviso in avisos where aviso.IdCita == cita.IdCita select aviso).ToList();
                    if (detalles.Count > 0)
                        cita.CitaDetalles = (from detalle in detalles where detalle.IdCita == cita.IdCita select detalle).ToList();
                    if (zonasConcatenadas.Count > 0)
                    {
                        var item = (from zona in zonasConcatenadas where zona.IdCita == cita.IdCita select zona).FirstOrDefault();
                        cita.Zonas = item.ZonaContatenada.Split("***");
                        cita.Total = Convert.ToDecimal(item.TotalCita);
                    }
                }



                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async Task<List<CitaExportarDTO>> ReadItemsExportar(DbDataReader reader)
        {
            try
            {
                List<CitaExportarDTO> lista = new List<CitaExportarDTO>();
                while (await reader.ReadAsync())
                {
                    CitaExportarDTO obj = new CitaExportarDTO
                    {
                        IdCita = Convert.ToInt32(reader["IdCita"]),
                        Sede = reader["Sede"].ToString(),
                        Cliente = reader["Cliente"].ToString(),
                        FechaCita = reader["FechaCita"].ToString(),
                        Zonas = reader["Zonas"].ToString(),
                        Promociones = reader["Promociones"].ToString(),
                        HoraInicio = reader["HoraInicio"].ToString(),
                        Estado = reader["Estado"].ToString(),
                        Pagado = reader["Pagado"].ToString(),
                        Total = Convert.ToDecimal(reader["Total"])
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

        static async Task<IEnumerable<CitaDTO>> ReadItemsParaPerfil(DbDataReader reader)
        {
            try
            {
                IList<CitaDTO> lista = new List<CitaDTO>();
                while (await reader.ReadAsync())
                {
                    CitaDTO obj = new CitaDTO
                    {
                        IdCita = Convert.ToInt32(reader["IdCita"]),
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        IdSede = Convert.ToInt32(reader["IdSede"]),
                        Sede = reader["Sede"].ToString(),
                        FechaCita = Convert.ToDateTime(reader["FechaCita"]),
                        IdEstado = Convert.ToInt32(reader["IdEstado"]),
                        HoraCita = reader["HoraInicio"].ToString(),
                        Duracion = Convert.ToInt32(reader["Duracion"]),
                        Estado = reader["Estado"].ToString(),
                        ColorEstado = reader["ColorEstado"].ToString(),
                        TipoCita = reader["TipoCita"].ToString(),
                        Pagado = Convert.ToBoolean(reader["Pagado"]),
                        Resumen = reader["Resumen"].ToString(),
                        Servicio = reader["Servicio"] == DBNull.Value ? null : Convert.ToString(reader["Servicio"]),
                        ServicioColor = reader["ServicioColor"] == DBNull.Value ? null : Convert.ToString(reader["ServicioColor"]),
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
        static async Task<Respuesta<CitaDTO>> ReadItemsCondicion(DbDataReader reader)
        {
            try
            {
                Respuesta<CitaDTO> obj = new Respuesta<CitaDTO>
                {
                    Response = new CitaDTO()
                };
                while (await reader.ReadAsync())
                {
                    obj.Exito = Convert.ToBoolean(reader["Exito"]);
                    obj.Mensaje = Convert.ToString(reader["Mensaje"]);
                    obj.ErrorNumero = Convert.ToInt32(reader["ErrorNumero"]);
                    obj.ErrorDetalle = reader["ErrorDetalle"].ToString();
                    if (obj.Exito)
                    {
                        obj.Response.IdCita = Convert.ToInt32(reader["IdCita"]);
                        obj.Response.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                        obj.Response.IdSede = Convert.ToInt32(reader["IdSede"]);
                        obj.Response.IdMaquina = Convert.ToInt32(reader["IdMaquina"]);
                        obj.Response.Sede = reader["Sede"].ToString();
                        obj.Response.Nombres = reader["Nombres"].ToString();
                        obj.Response.Apellidos = reader["Apellidos"].ToString();
                        obj.Response.NumeroDocumentoIdentidad = reader["Documento"].ToString();
                        obj.Response.NumeroHistoria = reader["IdHistoriaClinica"].ToString();
                        obj.Response.FechaCita = Convert.ToDateTime(reader["FechaCita"]);
                        obj.Response.NumerosCelulares = reader["Celular1"].ToString() + " - " + reader["Celular2"].ToString();
                        obj.Response.HoraCita = reader["HoraInicio"].ToString();
                        obj.Response.HoraInicio = reader["HoraInicio"].ToString();
                        obj.Response.HoraTermino = reader["HoraTermino"].ToString();
                        obj.Response.Duracion = Convert.ToInt32(reader["Duracion"]);
                        obj.Response.Total = Convert.ToDecimal(reader["Total"]);
                        obj.Response.Zonas = reader["Zonas"].ToString().Split(',');
                        obj.Response.TipoCita = reader["TipoCita"].ToString();
                        obj.Response.Estado = reader["Estado"].ToString();
                        obj.Response.ColorEstado = reader["ColorEstado"].ToString();
                    }
                }



                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        static async Task<IEnumerable<CitaDetalleZonaDTO>> ReadItemsZonaCita(DbDataReader reader)
        {
            try
            {
                IList<CitaDetalleZonaDTO> lista = new List<CitaDetalleZonaDTO>();
                while (await reader.ReadAsync())
                {
                    CitaDetalleZonaDTO obj = new CitaDetalleZonaDTO
                    {
                        IdCita = reader.GetFieldValue<int>(0),
                        Descripcion = Convert.ToString(reader["Descripcion"]),
                        Precio = Convert.ToDecimal(reader["Precio"]),
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
        static async Task<CitaDTO> ReadItemById(DbDataReader reader)
        {
            try
            {
                CitaDTO cita = new CitaDTO();
                while (await reader.ReadAsync())
                {
                    cita.IdCita = Convert.ToInt32(reader["IdCita"]);
                    cita.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                    cita.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                    cita.FechaCita = Convert.ToDateTime(reader["FechaCita"]);
                    cita.IdTipoCita = Convert.ToInt32(reader["IdTipoCita"]);
                    cita.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    cita.IdUsuarioAtendidoPor = Convert.ToInt32(reader["IdUsuarioAtendidoPor"]);
                    cita.UsuarioAtendidoPor = reader["UsuarioAtendidoPor"].ToString();
                    cita.HoraCita = reader["HoraInicio"].ToString();
                    cita.HoraInicio = reader["HoraInicio"].ToString();
                    cita.HoraTermino = reader["HoraTermino"].ToString();
                    cita.IdTipoCliente = Convert.ToInt32(reader["IdTipoCliente"]);
                    cita.IdSede = Convert.ToInt32(reader["IdSede"]);
                    cita.IdMaquina = Convert.ToInt32(reader["IdMaquina"]);
                    cita.Sede = reader["Sede"].ToString();
                    cita.Apellidos = reader["Apellidos"].ToString();
                    cita.Nombres = reader["Nombres"].ToString();
                    cita.NumerosCelulares = reader["NumerosCelulares"].ToString();
                    cita.NumeroDocumentoIdentidad = reader["Documento"].ToString();
                    cita.Duracion = Convert.ToInt32(reader["Duracion"]);
                    cita.Total = Convert.ToDecimal(reader["Total"]);
                    cita.FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]);
                    cita.UsuarioRegistra = Convert.ToString(reader["UsuarioRegistra"]);
                    cita.ColorEstado = Convert.ToString(reader["ColorEstado"]);
                    cita.IdMedioContacto = reader["IdMedioContacto"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdMedioContacto"]);
                    cita.OtroMedioContacto = reader["OtroMedioContacto"] == DBNull.Value ? null : reader["OtroMedioContacto"].ToString();


                    cita.IdDescuento = Convert.ToInt32(reader["IdDescuento"]);
                    cita.DescuentoAplicaA = reader["DescuentoAplicaA"] == DBNull.Value ? null : reader["DescuentoAplicaA"].ToString();
                    cita.CuponDescuento = reader["CuponDescuento"] == DBNull.Value ? null : reader["CuponDescuento"].ToString();

                    CitaMaquinaDTO citaMaquina = new CitaMaquinaDTO
                    {
                        Id = Convert.ToInt32(reader["IdMaquina"]),
                        Descripcion = reader["Maquina"].ToString()
                    };

                    cita.Maquina = citaMaquina;
                    cita.IdServicio = reader["IdServicio"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdServicio"]);

                    cita.IdCitaAsignacion = reader["IdCitaAsignacion"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdCitaAsignacion"]);
                    cita.FechaConfirmacion = reader["FechaConfirmacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaConfirmacion"]);
                    cita.IdUsuarioAsignado = reader["IdUsuarioAsignado"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdUsuarioAsignado"]);

                }

                //Leer detalle
                List<CitaDetalleZonaDTO> citaDetalles = new List<CitaDetalleZonaDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        CitaDetalleZonaDTO citaDetalle = new CitaDetalleZonaDTO()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            IdCita = Convert.ToInt32(reader["IdCita"]),
                            IdZona = Convert.ToInt32(reader["IdZona"]),
                            Sesion = Convert.ToInt32(reader["Sesion"]),
                            IdPromocionPrecio = reader["IdPromocionPrecio"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["IdPromocionPrecio"]),
                            Precio = Convert.ToDecimal(reader["Precio"]),
                            PrecioDescuento = Convert.ToDecimal(reader["PrecioDescuento"]),
                            PagoWeb = Convert.ToBoolean(reader["PagoWeb"]),
                            RetroTratam = Convert.ToBoolean(reader["RetroTratam"]),
                            //HoraInicio = reader["HoraInicio"].ToString(),
                            //HoraTermino = reader["HoraTermino"].ToString(),
                            Descripcion = reader["Descripcion"].ToString(),
                            Duracion = Convert.ToInt32(reader["Duracion"]),
                            IdUsuarioAgendado = reader["IdUsuarioAgendado"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["IdUsuarioAgendado"]),
                            UsuarioAgendado = reader["usuarioAgendado"].ToString()
                        };
                        citaDetalles.Add(citaDetalle);
                    }
                    cita.ZonasCorporales = citaDetalles;
                }

                //Leer Promociones Involucradas por cada zona del detalle
                List<PromocionZonaDTO> citaPromocionZonas = new List<PromocionZonaDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        PromocionZonaDTO citaPromocionZona = new PromocionZonaDTO()
                        {
                            Descripcion = reader["Descripcion"].ToString(),
                            Sexo = reader["Sexo"].ToString(),
                            IdPromocionPrecio = Convert.ToInt32(reader["IdPromocionPrecio"]),
                            IdPromocionZona = Convert.ToInt32(reader["IdPromocionZona"]),
                            IdZona = Convert.ToInt32(reader["IdZona"]),
                            PrecioBase = Convert.ToDecimal(reader["PrecioBase"]),
                            PrecioPromocion = Convert.ToDecimal(reader["Precio"])
                        };
                        citaPromocionZonas.Add(citaPromocionZona);
                    }
                }

                //relacionar las promociones al detalle
                foreach (CitaDetalleZonaDTO citaDetalle in citaDetalles)
                {
                    citaDetalle.Promociones = new List<PromocionZonaDTO>();
                    foreach(PromocionZonaDTO promocion in citaPromocionZonas)
                    {
                        if(citaDetalle.IdZona == promocion.IdZona || citaDetalle.IdPromocionPrecio == promocion.IdPromocionPrecio)
                        {
                            citaDetalle.Promociones.Add(promocion);
                        }
                    }

                    // citaDetalle.Promociones = (from pz in citaPromocionZonas where pz.IdZona == citaDetalle.IdZona select pz).ToList();
                }

                //Leer Mensaje Detalle
                List<CitaMensajeDetalleDTO> citaMensajeDetalles = new List<CitaMensajeDetalleDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        CitaMensajeDetalleDTO citaMensajeDetalle = new CitaMensajeDetalleDTO()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            IdCita = Convert.ToInt32(reader["IdCita"]),
                            Detalle = reader["Detalle"].ToString(),
                            FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                            InicialesUsuario = reader["InicialesUsuario"].ToString(),
                            UsuarioRegistra = reader["UsuarioRegistra"].ToString()
                        };
                        citaMensajeDetalles.Add(citaMensajeDetalle);
                    }
                    cita.CitaMensajeDetalles = citaMensajeDetalles;
                }

                //Leer Mensaje Nota
                List<CitaMensajeNotaDTO> citaMensajeNotas = new List<CitaMensajeNotaDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        CitaMensajeNotaDTO citaMensajeNota = new CitaMensajeNotaDTO()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            IdCita = Convert.ToInt32(reader["IdCita"]),
                            Nota = reader["Nota"].ToString(),
                            FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                            InicialesUsuario = reader["InicialesUsuario"].ToString(),
                            IdCliente = Convert.ToInt32(reader["IdCliente"]),
                            UsuarioRegistra = reader["UsuarioRegistra"].ToString()
                        };
                        citaMensajeNotas.Add(citaMensajeNota);
                    }
                    cita.CitaMensajeNotas = citaMensajeNotas;
                }

                //Leer Mensaje Aviso
                List<CitaMensajeAvisoDTO> citaMensajeAvisos = new List<CitaMensajeAvisoDTO>();
                if (reader.NextResult())
                {
                    while (await reader.ReadAsync())
                    {
                        CitaMensajeAvisoDTO citaMensajeAviso = new CitaMensajeAvisoDTO()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            IdCita = Convert.ToInt32(reader["IdCita"]),
                            Aviso = reader["Aviso"].ToString(),
                            FechaRegistra = Convert.ToDateTime(reader["FechaRegistra"]),
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                            InicialesUsuario = reader["InicialesUsuario"].ToString(),
                            UsuarioRegistra = reader["UsuarioRegistra"].ToString()
                        };
                        citaMensajeAvisos.Add(citaMensajeAviso);
                    }
                    cita.CitaMensajeAvisos = citaMensajeAvisos;
                }



                return cita;
            }
            catch (Exception EX)
            {
                throw EX;
            }
            
        }
        static async Task<IEnumerable<CitaComisionResumenDTO>> ReadItemComisionResumen(DbDataReader reader)
        {
            try
            {
                IList<CitaComisionResumenDTO> lista = new List<CitaComisionResumenDTO>();
                while (await reader.ReadAsync())
                {
                    CitaComisionResumenDTO obj = new CitaComisionResumenDTO
                    {
                        IdUsuarioOperador = Convert.ToInt32(reader["IdUsuarioOperador"]),
                        NumCitas = Convert.ToInt32(reader["NumCitas"]),
                        MontoComision = Convert.ToDecimal(reader["MontoComision"]),
                        MontoComisionIgv = Convert.ToDecimal(reader["MontoComisionIgv"]),
                        MontoTotal = Convert.ToDecimal(reader["MontoTotal"]),
                        NumZonas = Convert.ToInt32(reader["NumZonas"]),
                        UsuarioOperador = reader["UsuarioOperador"].ToString()
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
        static async Task<IEnumerable<CitaComisionDetalleDTO>> ReadItemComisionDetalle(DbDataReader reader)
        {

            try
            {
                IList<CitaComisionDetalleDTO> lista = new List<CitaComisionDetalleDTO>();
                while (await reader.ReadAsync())
                {
                    CitaComisionDetalleDTO obj = new CitaComisionDetalleDTO
                    {
                        IdCita = Convert.ToInt32(reader["IdCita"]),
                        IdZona = Convert.ToInt32(reader["IdZona"]),
                        ZonaCorporal = reader["ZonaCorporal"].ToString(),
                        IdUsuarioAgendado = Convert.ToInt32(reader["IdUsuarioAgendado"]),
                        Operador = reader["Operador"].ToString(),
                        Precio = Convert.ToDecimal(reader["Precio"]),
                        FechaCita = Convert.ToDateTime(reader["FechaCita"]),
                        PorcentajeComision = Convert.ToDecimal(reader["PorcentajeComision"]),
                        Comision = Convert.ToDecimal(reader["Comision"]),
                        Cliente = reader["Cliente"].ToString()
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

        static async Task<List<CitaReporteDTO>> ReadObtenerReporte(DbDataReader reader)
        {
            try
            {
                List<CitaReporteDTO> collection = new List<CitaReporteDTO>();
                while (await reader.ReadAsync())
                {
                    var obj = new CitaReporteDTO();
                    obj.IdCita = Convert.ToInt32(reader["IdCita"]);
                    obj.IdSede = Convert.ToInt32(reader["IdSede"]);
                    obj.Sede = Convert.ToString(reader["Sede"]);
                    obj.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                    obj.Cliente = Convert.ToString(reader["Cliente"]);
                    obj.Zonas = Convert.ToString(reader["Zonas"]);
                    obj.Fecha = Convert.ToDateTime(reader["Fecha"]);
                    obj.IdServicio = Convert.ToInt32(reader["IdServicio"]);
                    obj.Servicio = Convert.ToString(reader["Servicio"]);
                    obj.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                    obj.IdTipoCita = Convert.ToInt32(reader["IdTipoCita"]);
                    obj.TipoCita = Convert.ToString(reader["TipoCita"]);
                    obj.Zonas = Convert.ToString(reader["Zonas"]);
                    obj.Estado = Convert.ToString(reader["Estado"]);
                    obj.EstadoColor = Convert.ToString(reader["EstadoColor"]);
                    collection.Add(obj);
                }

                return collection;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
    }
}