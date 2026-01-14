using DepilZone.Api.Hubs;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignalRController: ControllerBase
    {
        private readonly IHubContext<SignalHub> _hubContext;
        public SignalRController(IHubContext<SignalHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task<bool> EnviarMensajeTodos(string datosJSON, TipoAlerta tipo)
        {
            try
            {
                MensajeSignalR mensajeSignalR = new MensajeSignalR()
                {
                    Exito = true,
                    Mensaje = tipo.ToString(),
                    DatosJSON = datosJSON,
                    Tipo = tipo
                };
                await _hubContext.Clients.All.SendAsync("mensajeroSignal", mensajeSignalR);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> EnviarMensaje(string datosJSON, TipoAlerta tipo, string connectionId)
        {
            try
            {
                MensajeSignalR mensajeSignalR = new MensajeSignalR()
                {
                    Exito = true,
                    Mensaje = tipo.ToString(),
                    DatosJSON = datosJSON,
                    Tipo = tipo
                };
                await _hubContext.Clients.Client(connectionId).SendAsync("mensajeroSignal", mensajeSignalR);
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet("{action}")]
        public async Task<ActionResult<bool>> EscanearPregunta()
        {
            return await EnviarMensajeTodos(JsonSerializer.Serialize(true), TipoAlerta.Actividad);
        }

        [HttpGet("{action}/{mensaje}")]
        public async Task<ActionResult<bool>> MensajeGeneral(string mensaje)
        {
            return await EnviarMensajeTodos(JsonSerializer.Serialize(mensaje), TipoAlerta.AvisoGeneral);
        }

        [HttpPost("{action}")]
        public async Task<ActionResult<bool>> EscanearRespuesta(UsuarioEnt usuario)
        {
            return await EnviarMensajeTodos(JsonSerializer.Serialize(usuario), TipoAlerta.RespuestaActividad);
        }

        [HttpPost("{action}")]
        public async Task<ActionResult<bool>> IdentificacionUsuario(IdentificacionUsuarioChatDTO identificacion)
        {
            identificacion.FechaHoraConeccion = DateTime.Now;
            if (Program.usuarios.ContainsKey(identificacion.ConnectionId))
            {
                IEnumerable<IdentificacionUsuarioChatDTO>  usuarios = Program.usuarios.Values.Where(u => u.IdUsuario == identificacion.IdUsuario && u.ConnectionId != identificacion.ConnectionId).ToList();
                foreach (IdentificacionUsuarioChatDTO usuario in usuarios)
                {
                    Program.usuarios.Remove(usuario.ConnectionId);
                }
                Program.usuarios[identificacion.ConnectionId] = identificacion;

                //Enviar el dato de la nueva conexion a todos
                var nuevaConexion = JsonSerializer.Serialize(new { idUsuario = identificacion.IdUsuario });
                await EnviarMensajeTodos(nuevaConexion, TipoAlerta.ConexionNueva);

                ////Eliminar los que se quedaron pegados por mas de 1 minuto
                var pegados = Program.usuarios.Values.Where(u => DateTime.Now.Subtract(u.FechaHoraConeccion).Seconds > 15 && u.IdUsuario > 0).ToList();
                foreach (var peg in pegados)
                    Program.usuarios.Remove(peg.ConnectionId);

                //Enviar los datos de usuarios validados
                var usuariosValidados = (from u in Program.usuarios.Values where u.IdUsuario > 0 select u);
                var listaConectados = JsonSerializer.Serialize(usuariosValidados);

                return await EnviarMensaje(listaConectados, TipoAlerta.ConexionListaUsuario, identificacion.ConnectionId);
            }
            else
            {
                var conexionRechazada = JsonSerializer.Serialize(new { idUSuario = identificacion.IdUsuario, mensaje = "Por favor intentar nuevamente" });
                return await EnviarMensaje(conexionRechazada, TipoAlerta.ConexionRechazada, identificacion.ConnectionId);
            }
        }



    }
}
