using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class DocumentoTipoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Titulo { get; set; }
        public IList<DocumentoTipoPerfilDTO> Perfiles { get; set; }
        public string ImagenCabeceraDocumento { get; set; }
        public string ImagenPieDocumento { get; set; }
        public int? IdServicio { get; set; }
        public int? IdUsuarioRegistro { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? IdUsuarioModifico { get; set; }
        public DateTime? FechaModifico { get; set; }

        // secondary
        public string? Servicio { get; set; }
        public string? ServicioColor { get; set; }
        public string? UsuarioRegistro { get; set; }
        public string? UsuarioModifico { get; set; }

    }

    public class DocumentoTipoPerfilDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}