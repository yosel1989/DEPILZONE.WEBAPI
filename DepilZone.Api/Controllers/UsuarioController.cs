using DepilZone.Application.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioApp _usuario;
        public UsuarioController(IUsuarioApp UsuarioApp)
        {
            this._usuario = UsuarioApp;
        }

        [HttpPost]
        public async Task<Respuesta<UsuarioEnt>> Post(UsuarioEnt model)
        {
            return await _usuario.Insertar(model);
        }
        [HttpPost("login")]
        public async Task<Respuesta<LoginDTO>> Login(LoginDTO model)
        {
            return await _usuario.Login(model);
        }

        [HttpPut]
        public async Task<Respuesta<UsuarioEnt>> Put(UsuarioEnt model)
        {
            return await _usuario.Modificar(model);
        }

        [HttpPut("cambiarClave")]
        public async Task<Respuesta<UsuarioCambiarClaveDTO>> CambiarClave(UsuarioCambiarClaveDTO model)
        {
            return await _usuario.CambiarClave(model);
        }


        [HttpGet("estado/{idEstado}")]
        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerByEstado(bool idEstado)
        {
            return await _usuario.Obtener(idEstado);
        }
        [HttpGet("listadoGrilla")]
        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerListadoGrilla()
        {
            return await _usuario.ObtenerListadoGrilla();
        }
        [HttpGet("{id}")]
        public async Task<UsuarioEnt> Get(int id)
        {
            return await _usuario.ObtenerByIdUsuario(id);
        }
        [HttpGet("search/{str}")]
        public async Task<IEnumerable<UsuarioGridDTO>> LikeNombre(string str)
        {
            return await _usuario.ObtenerByLikeNombre(str);
        }
        [HttpGet("perfil/{idPerfil},{idSede}")]
        public async Task<IEnumerable<UsuarioGridDTO>> GetByIdPerfil(string idPerfil, int idSede)
        {
            return await _usuario.ObtenerByIdPerfil(idPerfil, idSede);
        }
        [HttpGet]
        public async Task<IEnumerable<UsuarioGridDTO>> ResponsableCaja()
        {
            return await _usuario.ObtenerResponsableCaja();
        }

        [HttpGet("perfil/preferentes")]
        public async Task<ActionResult> ListarParaPreferentes()
        {
            try
            {
                var collection = await _usuario.ListarParaPreferentes();
                return Ok(new { 
                    data = collection,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new {},
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }

        [HttpGet("menu/perfil/{idPerfil}")]
        public async Task<List<MenuDTO>> ObtenerMenuByPerfil(int idPerfil)
        {
            return await _usuario.ObtenerMenuByPerfil(idPerfil);
        }

        [HttpGet("collection/{idEstado}")]
        public async Task<ActionResult> CollectionByEstado(int idEstado)
        {
            try
            {
                return Ok(new
                {
                    data = await _usuario.CollectionByEstado(idEstado),
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception EX)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = EX.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }


    }
}
