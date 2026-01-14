using System;
using System.Collections.Generic;
using System.Text;
namespace DepilZone.Entidad.DTO
{
    public class EmailEnvioDTO
    {
        public string EmailDestino { get; set; }
        public string EmailCopiaOculta { get; set; }
        public string Asunto { get; set; }
        public string Contenido { get; set; }
        public string Adjunto { get; set; }
        public string NombreAdjunto { get; set; }
    }
}