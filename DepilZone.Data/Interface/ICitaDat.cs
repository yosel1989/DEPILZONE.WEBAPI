using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
	public interface ICitaDat
	{
		Task<IEnumerable<CitaDTO>> Obtener(DateTime fechaCita, string horaInicio, string horaTermino, int idSede, int idEstado, string pacienteCelular, int tipoCita, int idServicio);
		Task<List<CitaExportarDTO>> ObtenerExportar(DateTime fechaCita, string horaInicio, string horaTermino, int idSede, int idEstado, string pacienteCelular, int tipoCita);
		Task<DashBoardDTO> ObtenerDashBoard(string fecha, int idSede, int idPerfil);
		Task<IEnumerable<CitaDTO>> Obtenercitaid(int idCita);
		Task<IEnumerable<CitaDTO>> ObtenerParaPerfil(int idCliente);
		Task<IEnumerable<CitaDTO>> ObtenerParaPerfilPorServicio(int idCliente, int idServicio);
		Task<CitaDTO> ObtenerById(int idCita, bool esReprogramacion);
		Task<CitaDatosPreliminaresDTO> ObtenerDatosPreliminares();
		Task<IEnumerable<CitaDetalleZonaDTO>> ObtenerDetalleCitaPrecio(int idCita);
		Task<Respuesta<CitaEnt>> Insertar(CitaEnt model);
		Task<Respuesta<CitaEnt>> Modificar(CitaEnt model);
		
		Task<int> EstadoAtendido(CitaEnt model);
		Task<Respuesta<CitaDTO>> ActualizarCondicionPendiente(CitaDTO model);
		Task<Respuesta<CitaDTO>> ActualizarCondicionAnular(CitaDTO model);
		Task<Respuesta<CitaDTO>> ActualizarCondicionCancelar(CitaDTO model);
		Task<Respuesta<CitaDTO>> ActualizarCondicionConfirmar(CitaDTO model);


		Task<Respuesta<CitaEnt>> InsertarReservacion(CitaEnt model);
		Task<bool> EliminarReservacion(int idUsuario);
		Task<IEnumerable<CitaComisionResumenDTO>> ObtenerComisionesResumen(DateTime fechaInicio, DateTime fechaTermino, int idUsuarioOperador);
		Task<IEnumerable<CitaComisionDetalleDTO>> ObtenerComisionesDetalle(DateTime fechaInicio, DateTime fechaTermino, int idUsuarioOperador);
		Task<IEnumerable<CitaMensajeNotaDTO>> ObtenerNotasEnCitaNueva(int idCliente);

		Task<List<CitaTotalDTO>> ObtenerAgendadas(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero);
		Task<List<CitaTotalDTO>> ObtenerAtendidas(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero);
		Task<List<CitaTotalDTO>> ObtenerAgendadasCortesia(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero);
		Task<List<CitaPromocionDTO>> ObtenerPorPromocion(DateTime fechaInicio, DateTime fechaFin, int idSede);
		Task<List<CitaReporteDTO>> ObtenerReporte(DateTime fechaInicio, DateTime fechaFin, int idSede, int idEstado, int idServicio, int idTipoCita);


	}
}
