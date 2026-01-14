using DepilZone.Application.Interface;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteAccesoController : ControllerBase
    {
        private readonly IClienteAccesoApp _ClienteAcceso;
        public ClienteAccesoController(IClienteAccesoApp ClienteAccesoApp)
        {
            _ClienteAcceso = ClienteAccesoApp;
        }


        [HttpPut("{idCliente}/correo")]
        public async Task<ActionResult> ModificarCorreo(int idCliente, ClienteAccesoDTO model)
        {
            try
            {
                await _ClienteAcceso.ModificarCorreo(idCliente, model);
                return Ok(new
                {
                    data = new {},
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch(AlertException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            
        }

        [HttpPut("{idCliente}/clave")]
        public async Task<ActionResult> ModificarClave(int idCliente, ClienteAccesoDTO model)
        {
            try
            {
                await _ClienteAcceso.ModificarClave(idCliente, model);
                return Ok(new
                {
                    data = new { },
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (AlertException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }

        }

        [HttpGet("{idCliente}/credenciales")]
        public async Task<ActionResult> ObtenerCredenciales(int idCliente)
        {
            try
            {
                ClienteAccesoDTO output = await _ClienteAcceso.ObtenerCredenciales(idCliente);
                return Ok(new
                {
                    data = output,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (AlertException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }

        }


    }
}