using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
	public class CitaDom : ICitaDom
	{
		private readonly ICitaDat _ICitaDat;
		public CitaDom(ICitaDat ICitaDat)
		{
			this._ICitaDat = ICitaDat;
		}
		public async Task<Respuesta<CitaEnt>> Insertar(CitaEnt model)
		{
			return await _ICitaDat.Insertar(model);
		}
		public async Task<Respuesta<CitaEnt>> Modificar(CitaEnt model)
		{
			return await _ICitaDat.Modificar(model);
		}
		
		
		
		
		public async Task<Respuesta<CitaDTO>> ActualizarCondicionAnular(CitaDTO model)
		{
			return await _ICitaDat.ActualizarCondicionAnular(model);
		}
		public async Task<Respuesta<CitaDTO>> ActualizarCondicionCancelar(CitaDTO model)
		{
			return await _ICitaDat.ActualizarCondicionCancelar(model);
		}
		public async Task<Respuesta<CitaDTO>> ActualizarCondicionConfirmar(CitaDTO model)
		{
			return await _ICitaDat.ActualizarCondicionConfirmar(model);
		}
		public async Task<Respuesta<CitaDTO>> ActualizarCondicionPendiente(CitaDTO model)
		{
			return await _ICitaDat.ActualizarCondicionPendiente(model);
		}


		public async Task<Respuesta<CitaEnt>> InsertarReservacion(CitaEnt model)
		{
			return await _ICitaDat.InsertarReservacion(model);
		}
		public async Task<bool> EliminarReservacion(int idUsuario)
		{
			return await _ICitaDat.EliminarReservacion(idUsuario);
		}
		public async Task<IEnumerable<CitaDTO>> Obtener(DateTime fecha, string horaInicio, string horaTermino, int idSede, int idEstado, string pacienteCelular, int tipoCita, int idServicio)
		{
			return await _ICitaDat.Obtener(fecha, horaInicio, horaTermino, idSede, idEstado, pacienteCelular, tipoCita, idServicio);
		}
		public async Task<List<CitaExportarDTO>> ObtenerExportar(DateTime fecha, string horaInicio, string horaTermino, int idSede, int idEstado, string pacienteCelular, int tipoCita)
		{
			return await _ICitaDat.ObtenerExportar(fecha, horaInicio, horaTermino, idSede, idEstado, pacienteCelular, tipoCita);
		}
		public async Task<CitaDatosPreliminaresDTO> ObtenerDatosPreliminares()
		{
			return await _ICitaDat.ObtenerDatosPreliminares();
		}
		public async Task<DashBoardDTO> ObtenerDashBoard(string fecha, int idSede, int idPerfil)
		{
			return await _ICitaDat.ObtenerDashBoard(fecha, idSede, idPerfil);
		}
		public async Task<IEnumerable<CitaDTO>> Obtenercitaid(int idCita)
		{
			return await _ICitaDat.Obtenercitaid(idCita);
		}

		public async Task<IEnumerable<CitaDTO>> ObtenerParaPerfil(int idCliente)
		{
			return await _ICitaDat.ObtenerParaPerfil(idCliente);
		}
		public async Task<IEnumerable<CitaDTO>> ObtenerParaPerfilPorServicio(int idCliente, int idServicio)
		{
			return await _ICitaDat.ObtenerParaPerfilPorServicio(idCliente, idServicio);
		}

		public async Task<CitaDTO> ObtenerById(int idCita, bool esReprogramacion)
		{
			return await _ICitaDat.ObtenerById(idCita, esReprogramacion);
		}
		public async Task<IEnumerable<CitaDetalleZonaDTO>> ObtenerDetalleCitaPrecio(int idCita)
		{
			return await _ICitaDat.ObtenerDetalleCitaPrecio(idCita);
		}

        public async Task<IEnumerable<CitaComisionResumenDTO>> ObtenerComisionesResumen(DateTime fechaInicio, DateTime fechaTermino, int idUsuarioOperador)
        {
			return await _ICitaDat.ObtenerComisionesResumen(fechaInicio, fechaTermino, idUsuarioOperador);
        }
		public async Task<IEnumerable<CitaComisionDetalleDTO>> ObtenerComisionesDetalle(DateTime fechaInicio, DateTime fechaTermino, int idUsuarioOperador)
		{
			return await _ICitaDat.ObtenerComisionesDetalle(fechaInicio, fechaTermino, idUsuarioOperador);
		}

        public async Task<int> EstadoAtendido(CitaEnt model)
        {
			return await _ICitaDat.EstadoAtendido(model);
        }
		
		public async Task<IEnumerable<CitaMensajeNotaDTO>> ObtenerNotasEnCitaNueva(int idCliente)
		{
			return await _ICitaDat.ObtenerNotasEnCitaNueva(idCliente);
		}

		public async Task<List<CitaTotalDTO>> ObtenerAgendadas(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero)
		{
			return await _ICitaDat.ObtenerAgendadas(fechaInicio, fechaFin, idSede, idGenero);
		}
		public async Task<List<CitaTotalDTO>> ObtenerAtendidas(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero)
		{
			return await _ICitaDat.ObtenerAtendidas(fechaInicio, fechaFin, idSede, idGenero);
		}
		public async Task<List<CitaTotalDTO>> ObtenerAgendadasCortesia(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero)
		{
			return await _ICitaDat.ObtenerAgendadasCortesia(fechaInicio, fechaFin, idSede, idGenero);
		}

		public async Task<List<CitaPromocionDTO>> ObtenerPorPromocion(DateTime fechaInicio, DateTime fechaFin, int idSede)
        {
			return await _ICitaDat.ObtenerPorPromocion(fechaInicio, fechaFin, idSede);
		}

		public async Task<List<CitaReporteDTO>> ObtenerReporte(DateTime fechaInicio, DateTime fechaFin, int idSede, int idEstado, int idServicio, int idTipoCita)
        {
			return await _ICitaDat.ObtenerReporte(fechaInicio, fechaFin, idSede, idEstado, idServicio, idTipoCita);
		}
	}
}

