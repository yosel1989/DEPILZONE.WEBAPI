using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Application.Implement
{
	public class CitaApp : ICitaApp
	{
		private readonly ICitaDom _ICitaDom;
		public CitaApp(ICitaDom ICitaDom)
		{
			this._ICitaDom = ICitaDom;
		}
		public async Task<Respuesta<CitaEnt>> Insertar(CitaEnt model)
		{
			return await _ICitaDom.Insertar(model);
		}
		public async Task<Respuesta<CitaEnt>> Modificar(CitaEnt model)
		{
			return await _ICitaDom.Modificar(model);
		}
		
		
		
		public async Task<Respuesta<CitaDTO>> ActualizarCondicionAnular(CitaDTO model)
		{
			return await _ICitaDom.ActualizarCondicionAnular(model);
		}
		public async Task<Respuesta<CitaDTO>> ActualizarCondicionCancelar(CitaDTO model)
		{
			return await _ICitaDom.ActualizarCondicionCancelar(model);
		}
		public async Task<Respuesta<CitaDTO>> ActualizarCondicionConfirmar(CitaDTO model)
		{
			return await _ICitaDom.ActualizarCondicionConfirmar(model);
		}
		public async Task<Respuesta<CitaDTO>> ActualizarCondicionPendiente(CitaDTO model)
		{
			return await _ICitaDom.ActualizarCondicionPendiente(model);
		}


		public async Task<Respuesta<CitaEnt>> InsertarReservacion(CitaEnt model)
		{
			return await _ICitaDom.InsertarReservacion(model);
		}
		public async Task<bool> EliminarReservacion(int idUsuario)
		{
			return await _ICitaDom.EliminarReservacion(idUsuario);
		}

		public async Task<IEnumerable<CitaDTO>> Obtener(DateTime fechaCita, string horaInicio, string horaTermino, int idSede, int idEstado, string pacienteCelular, int tipoCita, int idServicio)
		{
			return await _ICitaDom.Obtener(fechaCita, horaInicio, horaTermino, idSede, idEstado, pacienteCelular, tipoCita, idServicio);
		}

		public async Task<List<CitaExportarDTO>> ObtenerExportar(DateTime fechaCita, string horaInicio, string horaTermino, int idSede, int idEstado, string pacienteCelular, int tipoCita)
		{
			return await _ICitaDom.ObtenerExportar(fechaCita, horaInicio, horaTermino, idSede, idEstado, pacienteCelular, tipoCita);
		}

		public async Task<CitaDatosPreliminaresDTO> ObtenerDatosPreliminares()
		{
			return await _ICitaDom.ObtenerDatosPreliminares();
		}
		public async Task<DashBoardDTO> ObtenerDashBoard(string fecha, int idSede, int idPerfil)
		{
			return await _ICitaDom.ObtenerDashBoard(fecha, idSede, idPerfil);
		}
		public async Task<IEnumerable<CitaDTO>> Obtenercitaid(int idCita)
		{
			return await _ICitaDom.Obtenercitaid(idCita);
		}

		public async Task<IEnumerable<CitaDTO>> ObtenerParaPerfil(int idCliente) {
			return await _ICitaDom.ObtenerParaPerfil(idCliente);
		}
		public async Task<IEnumerable<CitaDTO>> ObtenerParaPerfilPorServicio(int idCliente, int idServicio)
		{
			return await _ICitaDom.ObtenerParaPerfilPorServicio(idCliente, idServicio);
		}
		public async Task<CitaDTO> ObtenerById(int idCita, bool esReprogramacion)
		{
			return await _ICitaDom.ObtenerById(idCita, esReprogramacion);
		}
		public async Task<IEnumerable<CitaDetalleZonaDTO>> ObtenerDetalleCitaPrecio(int idCita)
		{
			return await _ICitaDom.ObtenerDetalleCitaPrecio(idCita);
		}

        public async Task<IEnumerable<CitaComisionResumenDTO>> ObtenerComisionesResumen(DateTime fechaInicio, DateTime fechaTermino, int idUsuarioOperador)
        {
			return await _ICitaDom.ObtenerComisionesResumen(fechaInicio, fechaTermino, idUsuarioOperador);

		}
		public async Task<IEnumerable<CitaComisionDetalleDTO>> ObtenerComisionesDetalle(DateTime fechaInicio, DateTime fechaTermino, int idUsuarioOperador)
		{
			return await _ICitaDom.ObtenerComisionesDetalle(fechaInicio, fechaTermino, idUsuarioOperador);

		}
        public async Task<int> EstadoAtendido(CitaEnt model)
        {
			return await _ICitaDom.EstadoAtendido(model);
        }
		

		public async Task<IEnumerable<CitaMensajeNotaDTO>> ObtenerNotasEnCitaNueva(int idCliente)
		{
			return await _ICitaDom.ObtenerNotasEnCitaNueva(idCliente);
		}

		public async Task<List<CitaTotalDTO>> ObtenerAgendadas(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero)
		{
			return await _ICitaDom.ObtenerAgendadas(fechaInicio, fechaFin, idSede, idGenero);
		}
		public async Task<List<CitaTotalDTO>> ObtenerAtendidas(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero)
		{
			return await _ICitaDom.ObtenerAtendidas(fechaInicio, fechaFin, idSede, idGenero);
		}
		public async Task<List<CitaTotalDTO>> ObtenerAgendadasCortesia(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero)
		{
			return await _ICitaDom.ObtenerAgendadasCortesia(fechaInicio, fechaFin, idSede, idGenero);
		}

		public async Task<List<CitaPromocionDTO>> ObtenerPorPromocion(DateTime fechaInicio, DateTime fechaFin, int idSede)
		{
			return await _ICitaDom.ObtenerPorPromocion(fechaInicio, fechaFin, idSede);
		}

		public async Task<List<CitaReporteDTO>> ObtenerReporte(DateTime fechaInicio, DateTime fechaFin, int idSede, int idEstado, int idServicio, int idTipoCita)
        {
			return await _ICitaDom.ObtenerReporte( fechaInicio,  fechaFin,  idSede,  idEstado,  idServicio,  idTipoCita);
		}
	}
}