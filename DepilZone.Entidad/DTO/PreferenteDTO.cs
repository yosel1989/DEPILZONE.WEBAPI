using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class PreferenteDTO
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Promocion { get; set; }
        public int IdEstado { get; set; }
        public string IdUbicacion { get; set; }
        public string Direccion { get; set; }
        public int? IdTeleoperador { get; set; }
        public int? IdComentario { get; set; }
        public int IdMedioContacto { get; set; }
        public string OtroMedioContacto { get; set; }
        public DateTime? FechaAsignacion { get; set; }
        public string UsuarioRegistra { get; set; }
        public DateTime FechaRegistra { get; set; }
        public string UsuarioEdita { get; set; }
        public DateTime? FechaEdita { get; set; }

        public string Distrito { get; set; }
        public string Provincia { get; set; }
        public string Departamento { get; set; }

        public string Telefono { get; set; }

        public List<int> Ids { get; set; }
        public List<PreferenteTelefonoEnt> PreferenteTelefono { get; set; }
        public List<PreferenteZonaCorporalEnt> PreferenteZonaCorporal { get; set; }
        public List<PreferenteObservacionDTO> PreferenteObservacion { get; set; }
    }

    public class PreferenteImportarDTO
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string UsuarioRegistra { get; set; }
        public int IdMedioContacto { get; set; }

        public string Observacion { get; set; }
    }
    

    public class PreferenteAsignarListaDTO
    {
        public int IdPreferente { get; set; }
        public int IdUsuarioOperador { get; set; }
        public int IdUsuarioRegistra { get; set; }
    }
}