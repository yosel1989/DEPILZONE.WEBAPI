using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class PreferenteGrillaDTO
    {
        public int Id { get; set; }
        public string X { get; set; }
        public string Nombres { get; set; }
        public string Teleoperadora { get; set; }
        public string Comentario { get; set; }
        public string Observacion { get; set; }
        public string FechaRegistra { get; set; }
        public string FechaAsignacion { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Distrito { get; set; }
        public string ZonaCorporal { get; set; }
        public string MedioContacto { get; set; }
        public int IdEstado { get; set; }
        public string EstadoAtencion { get; set; }
    }
}
