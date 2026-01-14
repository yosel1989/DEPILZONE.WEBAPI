using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InicioController : ControllerBase
    {
        [HttpGet]
        public ContentResult Index()
        {
            string content = System.IO.File.ReadAllText("plantillas/inicio.html");

            StringBuilder sb = new StringBuilder();
            sb.Append("<table>");
            if (Program.usuarios.Values.Count > 0)
            {
                foreach (IdentificacionUsuarioChatDTO usuario in Program.usuarios.Values)
                {
                    sb.Append("<tr>");
                    sb.Append("<td>" + usuario.ConnectionId + "</td>");
                    sb.Append("<td>" + usuario.FechaHoraConeccion + "</td>");
                    sb.Append("<td>" + usuario.IdUsuario + "</td>");
                    sb.Append("</tr>");
                }
            }
            sb.Append("</table>");

            content = content.Replace("@@change(table)", sb.ToString());

            return base.Content(content, "text/html");
        }

    }
}
