using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class LoginDTO
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Perfil { get; set; }
        public int IdPerfil { get; set; }
        public int IdSede { get; set; }
        public string Sede { get; set; }
        public string Foto { get; set; }

        public IList<MenuDTO> Menu { get; set; }

    }
}
