using System;
using System.Collections.Generic;

namespace DepilZone.Entidad
{
    public class CitaEnt
	{
        public int IdCita { get; set; }
        public int IdTipoCita { get; set; }
        public int IdCliente { get; set; }
        public int IdTipoCliente { get; set; }
        public int IdUsuario { get; set; }
        public int IdMaquina { get; set; }
        public int IdSede { get; set; }

        public DateTime FechaCita { get; set; }
        public string HoraInicio { get; set; }
        public string HoraTermino { get; set; }

        public decimal Total { get; set; }
        public bool Pagado { get; set; }
        public string UsuarioRegistra { get; set; }
        public string UsuarioEdita { get; set; }
        public DateTime FechaEdita { get; set; }
		public DateTime FechaRegistra { get; set; }
        public int IdEstado { get; set; }
        public int? IdEstadoPendiente { get; set; }
        public int? IdUsuarioAtendidoPor { get; set; }
        

        public List<CitaDetalleEnt> Detalles { get; set; }
        public List<CitaMensajeAvisoEnt> CitaMensajeAvisos { get; set; }
        public List<CitaMensajeNotaEnt> CitaMensajeNotas { get; set; }
        public List<CitaMensajeDetalleEnt> CitaMensajeDetalles { get; set; }

        // Medio contacto
        public int? IdMedioContacto { get; set; }
        public string? OtroMedioContacto { get; set; }

        public int IdDescuento { get; set; }
        public string? DescuentoAplicaA { get; set; }
        public string? CuponDescuento { get; set; }

        public int? IdServicio { get; set; }
        public string? Servicio { get; set; }
    }
}
