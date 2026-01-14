using System;

namespace DepilZone.Entidad
{
    public class CitaDetalleEnt
	{
		public int Id { get; set; }
		public int IdCita { get; set; }
		public int IdZona { get; set; }
		public int Sesion { get; set; }
		public int IdPromocionPrecio { get; set; }
		public decimal Precio { get; set; }
        public int Duracion { get; set; }
        public int? IdUsuarioAgendado { get; set; }

		public bool RetroTratam { get; set; }
		public bool PagoWeb { get; set; }
		public decimal PrecioDescuento { get; set; }
	}
}
