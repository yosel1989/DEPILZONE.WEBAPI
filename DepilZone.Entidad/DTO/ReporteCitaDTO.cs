using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
	public class ReporteCitaDTO
	{
		//public int idcita { get; set; }
		public string fechacita { get; set; }
		public int cantidad { get; set; }

		public int idUsuarioAtendio { get; set; }
	}

	public class EspecialistaDTO
    {
		public int Id { get; set; }
		public string Nombre { get; set; }
		public List<ReporteCitaDTO> CitasAtendidas { get; set; }
    }

	public class EspecialistaCitaDTO
    {
		public int IdCita { get; set; }
		public int IdCliente { get; set; }
		public string Cliente { get; set; }
		public DateTime Fecha { get; set; }
		public int? IdProximaCitaAtendida { get; set; }
		public DateTime? ProximaCitaAtendida { get; set; }
		public string Hora { get; set; }
		public string Sede { get; set; }


		public DateTime? FechaProximaCita { get; set; }
		public int? IdProximaCita { get; set; }
		public string? ColorProximaCita { get; set; }
		public string? EstadoProximaCita { get; set; }
	}


	public class CronogramaCitasAtendidasDTO
	{
		//public int idcita { get; set; }
		public string Sede { get; set; }
		public DateTime Fecha { get; set; }
		public int Anio { get; set; }
		public int Mes { get; set; }
		public int Dia { get; set; }
		public int Numero { get; set; }

		public int H8 { get; set; }
		public int H9 { get; set; }
		public int H10 { get; set; }
		public int H11 { get; set; }
		public int H12 { get; set; }
		public int H13 { get; set; }
		public int H14 { get; set; }
		public int H15 { get; set; }
		public int H16 { get; set; }
		public int H17 { get; set; }
		public int H18 { get; set; }
		public int H19 { get; set; }
		public int H20 { get; set; }
		public int H21 { get; set; }
	}

}
