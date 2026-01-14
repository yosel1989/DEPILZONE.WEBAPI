using DepilZone.Api.Hubs;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;

namespace DepilZone.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CitaController : ControllerBase
	{
		private readonly ICitaApp _cita;
		private readonly IHubContext<SignalHub> _hubContext;

		public CitaController(ICitaApp CitaApp, IHubContext<SignalHub> hubContext)
		{
			_cita = CitaApp;
			_hubContext = hubContext;
		}

		[HttpGet("datosPreliminares")]
		public async Task<CitaDatosPreliminaresDTO> ObtenerDatosPreliminares()
		{
			return await _cita.ObtenerDatosPreliminares();
		}

		[HttpPost]
		public async Task<Respuesta<CitaEnt>> Post(CitaEnt model)
		{
			return await _cita.Insertar(model);
		}
		[HttpPut]
		public async Task<Respuesta<CitaEnt>> Put(CitaEnt model)
		{
			return await _cita.Modificar(model);
		}

		[HttpPut("estadoAtendido")]
		public async Task<int> EstadoAtendido(CitaEnt model)
		{
            try
            {
				return await _cita.EstadoAtendido(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
			
		}




		[HttpPut("actualizarCitaPendiente")]
		public async Task<Respuesta<CitaDTO>> ActualizarCondicionPendiente(CitaDTO model)
		{
            try
            {
				return await _cita.ActualizarCondicionPendiente(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
			
		}
		[HttpPut("actualizarCitaAnular")]
		public async Task<Respuesta<CitaDTO>> ActualizarCondicionAnular(CitaDTO model)
		{
			return await _cita.ActualizarCondicionAnular(model);
		}
		[HttpPut("actualizarCitaCancelar")]
		public async Task<Respuesta<CitaDTO>> ActualizarCondicionCancelar(CitaDTO model)
		{
			return await _cita.ActualizarCondicionCancelar(model);
		}
		[HttpPut("actualizarCitaConfirmar")]
		public async Task<Respuesta<CitaDTO>> ActualizarCondicionConfirmar(CitaDTO model)
		{
			return await _cita.ActualizarCondicionConfirmar(model);
		}



		[HttpPost("{fechaCita}/{idSede}")]
		public async Task<Respuesta<CitaEnt>> Reservacion(CitaEnt model)
		{
			Respuesta<CitaEnt> resultado = await _cita.InsertarReservacion(model);

			if (resultado.Exito)
			{
				MensajeSignalR mensajeSignalR = new MensajeSignalR()
				{
					Tipo = TipoAlerta.CitaReservada,
					DatosJSON = JsonSerializer.Serialize(resultado.Response),
					Exito = true,
					Mensaje = TipoAlerta.CitaReservada.ToString()
				};
				await _hubContext.Clients.All.SendAsync("mensajeroSignal", mensajeSignalR);
			}
			return resultado;
		}
		[HttpDelete("reservacion/{idUsuario}")]
		public async Task<bool> ReservacionEliminar(int idUsuario)
		{
			bool resultado = await _cita.EliminarReservacion(idUsuario);

			if (resultado)
			{
				MensajeSignalR mensajeSignalR = new MensajeSignalR()
				{
					Tipo = TipoAlerta.ReservaEliminada,
					DatosJSON = JsonSerializer.Serialize(idUsuario),
					Exito = true,
					Mensaje = TipoAlerta.ReservaEliminada.ToString()
				};
				await _hubContext.Clients.All.SendAsync("mensajeroSignal", mensajeSignalR);
			}
			return resultado;
		}

		

		/// <summary>
		/// Permite obtener el listado de citas segun los parametros asignados
		/// </summary>
		/// <param name="fechaCita">Parametro para buscar las citas con la fecha indicada</param>
		/// <param name="idSede">Codigo de la sede que tiene la cita</param>
		/// <param name="pacienteCelular">Nombre del paciente o numero de celular que coincida con la cita</param>
		/// <returns></returns>
		[HttpGet("{fechaCita},{horaInicio},{horaTermino},{idSede},{idEstado},{pacienteCelular},{tipoCita},{idServicio}")]
		public async Task<IEnumerable<CitaDTO>> Obtener(DateTime fechaCita, string horaInicio, string horaTermino, int idSede, int idEstado, string pacienteCelular, int tipoCita, int idServicio)
		{
			return await _cita.Obtener(fechaCita, horaInicio, horaTermino, idSede, idEstado, pacienteCelular, tipoCita, idServicio);
		}

		[HttpGet("exportar/{fechaCita},{horaInicio},{horaTermino},{idSede},{idEstado},{pacienteCelular},{tipoCita}")]
		public async Task<ActionResult> ObtenerExportar(DateTime fechaCita, string horaInicio, string horaTermino, int idSede, int idEstado, string pacienteCelular, int tipoCita)
		{
            try
            {
				var collection = await _cita.ObtenerExportar(fechaCita, horaInicio, horaTermino, idSede, idEstado, pacienteCelular, tipoCita);
				return Ok(new { 
					data = collection,
					message = "",
					status = StatusCodes.Status200OK
				});
			}
            catch (Exception e)
            {
				return BadRequest(new{
					data = new { },
					message = e.Message,
					status = StatusCodes.Status400BadRequest
				});
            }
		}

		[HttpGet("obtenerDashboard/{fecha},{idSede},{idPerfil}")]
		public async Task<DashBoardDTO> ObtenerDashBoard(string fecha, int idSede, int idPerfil)
		{
			return await _cita.ObtenerDashBoard(fecha, idSede, idPerfil);
		}
		[HttpGet("byId/{idCita}/{esReprogramacion}")]
		public async Task<CitaDTO> ObtenerById(int idCita, bool esReprogramacion)
		{
            try
            {
				return await _cita.ObtenerById(idCita, esReprogramacion);
            }
            catch (Exception e)
            {
                throw e;
            }
			
		}
		

		[HttpGet("detalleCitaPrecio/{idCita}")]
		public async Task<IEnumerable<CitaDetalleZonaDTO>> ObtenerDetalleCitaPrecio(int idCita)
		{
			return await _cita.ObtenerDetalleCitaPrecio(idCita);
		}
		[HttpGet("citaid/{idCita}")]
		public async Task<IEnumerable<CitaDTO>> Obtenercitaid(int idCita)
		{
			return await _cita.Obtenercitaid(idCita);
		}

		[HttpGet("resumenParaPerfil/{idCliente}")]
		public async Task<IEnumerable<CitaDTO>> ObtenerParaPerfil(int idCliente)
		{
			return await _cita.ObtenerParaPerfil(idCliente);
		}

		[HttpGet("resumenParaPerfil/{idCliente}/servicio/{idServicio}")]
		public async Task<IEnumerable<CitaDTO>> ObtenerParaPerfilPorServicio(int idCliente, int idServicio)
		{
            try
            {
				return await _cita.ObtenerParaPerfilPorServicio(idCliente, idServicio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}

		[HttpGet("resumenComisiones/{fechainicio}/{fechaTermino}/{idUsuarioOperador}")]
		public async Task<IEnumerable<CitaComisionResumenDTO>> ObtenerComisionesResumen(DateTime fechaInicio, DateTime fechaTermino, int idUsuarioOperador)
		{
			return await _cita.ObtenerComisionesResumen(fechaInicio, fechaTermino, idUsuarioOperador);
		}
		[HttpGet("detalleComisiones/{fechainicio}/{fechaTermino}/{idUsuarioOperador}")]
		public async Task<IEnumerable<CitaComisionDetalleDTO>> ObtenerComisionesDetalle(DateTime fechaInicio, DateTime fechaTermino, int idUsuarioOperador)
		{
			return await _cita.ObtenerComisionesDetalle(fechaInicio, fechaTermino, idUsuarioOperador);
		}

		[HttpGet("obtenerNotasCitaNueva/{idCliente}")]
		public async Task<IEnumerable<CitaMensajeNotaDTO>> ObtenerNotasEnCitaNueva(int idCliente)
		{
			return await _cita.ObtenerNotasEnCitaNueva(idCliente);
		}



		[HttpGet("agendadas/{fechaInicio}/{fechaFin}/{idSede}/{idGenero}")]
		public async Task<ActionResult> ObtenerAgendadas(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero)
		{
			try
			{
				List<CitaTotalDTO> citas = await _cita.ObtenerAgendadas(fechaInicio, fechaFin, idSede, idGenero);
				return Ok(new
				{
					data = citas,
					message = "",
					status = 200
				});
			}
			catch (Exception e)
			{
				return BadRequest(new
				{
					data = new { },
					message = e.Message,
					status = 400
				});
			}
		}

		[HttpGet("atendidas/{fechaInicio}/{fechaFin}/{idSede}/{idGenero}")]
		public async Task<ActionResult> ObtenerAtendidas(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero)
		{
			try
			{
				List<CitaTotalDTO> citas = await _cita.ObtenerAtendidas(fechaInicio, fechaFin, idSede, idGenero);
				return Ok(new
				{
					data = citas,
					message = "",
					status = 200
				});
			}
			catch (Exception e)
			{
				return BadRequest(new
				{
					data = new { },
					message = e.Message,
					status = 400
				});
			}
		}

		[HttpGet("cortesia/{fechaInicio}/{fechaFin}/{idSede}/{idGenero}")]
		public async Task<ActionResult> ObtenerAgendadasCortesia(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero)
		{
			try
			{
				List<CitaTotalDTO> citas = await _cita.ObtenerAgendadasCortesia(fechaInicio, fechaFin, idSede, idGenero);
				return Ok(new
				{
					data = citas,
					message = "",
					status = 200
				});
			}
			catch (Exception e)
			{
				return BadRequest(new
				{
					data = new { },
					message = e.Message,
					status = 400
				});
			}
		}


		[HttpGet("promocion/{fechaInicio}/{fechaFin}/{idSede}")]
		public async Task<ActionResult> ObtenerPorPromocion(DateTime fechaInicio, DateTime fechaFin, int idSede)
		{
			try
			{
				List<CitaPromocionDTO> citas = await _cita.ObtenerPorPromocion(fechaInicio, fechaFin, idSede);
				return Ok(new
				{
					data = citas,
					message = "",
					status = 200
				});
			}
			catch (Exception e)
			{
				return BadRequest(new
				{
					data = new { },
					message = e.Message,
					status = 400
				});
			}
		}

		[HttpGet("reporte/{fechaInicio}/{fechaFin}/{idSede}/{idEstado}/{idServicio}/{idTipoCita}")]
		public async Task<ActionResult> ObtenerReporte(DateTime fechaInicio, DateTime fechaFin, int idSede, int idEstado, int idServicio, int idTipoCita)
		{
			try
			{
				List<CitaReporteDTO> citas = await _cita.ObtenerReporte( fechaInicio,  fechaFin,  idSede,  idEstado,  idServicio,  idTipoCita);
				return Ok(new
				{
					data = citas,
					message = "",
					status = 200
				});
			}
			catch (Exception e)
			{
				return BadRequest(new
				{
					data = new { },
					message = e.Message,
					status = 400
				});
			}
		}
	}
}