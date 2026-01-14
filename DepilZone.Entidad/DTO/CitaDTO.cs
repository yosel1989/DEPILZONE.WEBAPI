using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class CitaDTO
    {
        public int IdCita { get; set; }
        public string Foto { get; set; }
        public int IdTipoCita { get; set; }
        public int IdCliente { get; set; }
        public int IdTipoCliente { get; set; }
        public int IdUsuario { get; set; }
        public int IdMaquina { get; set; }
        public int IdSede { get; set; }
        public int IdEstado { get; set; }
        public int? IdUsuarioAtendidoPor { get; set; }
        public string UsuarioAtendidoPor { get; set; }
        public string Sede { get; set; }
        public int? IdGenero { get; set; }
        public IList<CitaDetalleZonaDTO> ZonasCorporales { get; set; }
        public IList<CitaMensajeAvisoDTO> CitaMensajeAvisos { get; set; }
        public IList<CitaMensajeNotaDTO> CitaMensajeNotas { get; set; }
        public IList<CitaMensajeDetalleDTO> CitaMensajeDetalles { get; set; }

        public DateTime FechaCita{ get; set; }
        public string HoraInicio { get; set; }
        public string HoraTermino { get; set; }
        public int Duracion { get; set; }

        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Paciente {
            get { return Nombres + " " + Apellidos; }
        }
        public string SeudonimoPaciente { get; set; }
        public string NumeroCita
        {
            get { return "CI-" + IdCita.ToString("000000"); }
        }
        public string CodigoPaciente
        {
            get { return "PA-" + IdCliente.ToString("000000"); }
        }
        public string HoraCita { get; set; }
        public string NumeroDocumentoIdentidad { get; set; }
        public string NumeroHistoria { get; set; }
        public string NumerosCelulares { get; set; }
        public string TipoCita { get; set; }
        /// <summary>
        /// Usado para mostrar en el listado de citas de forma vertical al lado derecho
        /// </summary>
        public string TipoCitaCorto {
            get
            {
                
                return (TipoCita == null) ? "" : (TipoCita.Length > 9 ? TipoCita.Substring(0, 9) : TipoCita);
            }
        }
        public string ColorTipoCita { get; set; }
        public string ColorTextoTipoCita { get; set; }
        public int NumeroSesion { get; set; }
        public IList<string> Zonas { get; set; }
        public IList<ZonasContatenadasDTO> ZonaContatenadaCitaDetalle { get; set; }
        public IList<CitaMensajeAvisoEnt> CitaAvisos { get; set; }
        public IList<CitaMensajeDetalleEnt> CitaDetalles { get; set; }
        public decimal Total { get; set; }

        public string Estado { get; set; }
        public string ColorEstado { get; set; }
        public bool Pagado { get; set; }
        public string TextoPagado {
            get
            {
                return Pagado ? "PAGADO" : "NO PAGADO";
            }
        }
        public string ColorPagado { get; set; }
        public string TipoCliente { get; set; }
        public string ColorTipoCliente { get; set; }
        public string ColorTextoTipoCliente { get; set; }

        public DateTime FechaRegistra { get; set; }
        public string UsuarioRegistra { get; set; }
        public string Usuario { get; set; }
        public int? IdEstadoPendiente { get; set; }
        public string Resumen { get; set; }
        public CitaMaquinaDTO Maquina { get; set; }

        //// Encuesta
        public int Efectividad { get; set; }
        public int Satisfaccion { get; set; }

        // Medio contacto
        public int? IdMedioContacto { get; set; }
        public string? OtroMedioContacto { get; set; }



        public int IdDescuento { get; set; }
        public string? DescuentoAplicaA { get; set; }
        public string? CuponDescuento { get; set; }

        public DateTime FechaEncuesta { get; set; }

        public int? IdFichaAdmision { get; set; }

        public int? IdCitaAsignacion { get; set; }
        public int? IdUsuarioAsignado { get; set; }
        public DateTime? FechaConfirmacion { get; set; }

        public int? IdServicio { get; set; }
        public string? Servicio { get; set; }
        public string? ServicioColor { get; set; }

        public string? Genero { get; set; }
    }

    public class ZonasContatenadasDTO
    {
        public int IdCita { get; set; }
        public double TotalCita { get; set; }
        public string ZonaContatenada { get; set; }
    }

    public class CitaMaquinaDTO {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }

    public class CitaTotalDTO
    {
        public int IdSede { get; set; }
        public string Sede { get; set; }
        public DateTime FechaCita { get; set; }
        public int NumCitas { get; set; }
    }

    public class CitaExportarDTO
    {
        public int IdCita { get; set; }
        public string Sede { get; set; }
        public string Cliente { get; set; }
        public string FechaCita { get; set; }
        public string Zonas { get; set; }
        public string Promociones { get; set; }
        public string HoraInicio { get; set; }
        public string Estado { get; set; }
        public string Pagado { get; set; }
        public decimal Total { get; set; }
    }


    public class CitaPromocionDTO
    {
        public int IdCita { get; set; }
        public int IdSede { get; set; } 
        public string Sede { get; set; }
        public int NumeroCita { get; set; }
        public string Cliente { get; set; }
        public DateTime FechaCita { get; set; }
        public string HoraCita { get; set; }
        public string Zona { get; set; }
        public int IdZona { get; set; }
        public int Sesion { get; set; } 
        public int IdPromocion { get; set; }
        public string Promocion { get; set; } 
        public DateTime PromoFechaIni { get; set; }
        public DateTime PromoFechaFin { get; set; }
        public decimal PrecioZona { get; set; }
        public decimal TotalCita { get; set; }
        public string Estado { get; set; }
    }

    public class CitaReporteDTO
    {
        public int IdCita { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
        public string EstadoColor { get; set; }
        public int IdTipoCita { get; set; }
        public string TipoCita { get; set; }
        public string Cliente { get; set; }
        public int IdServicio { get; set; }
        public string Servicio { get; set; }
        public string ServicioColor { get; set; }
        public int IdSede { get; set; }
        public string Sede { get; set; }
        public string Zonas { get; set; }
    }

}
