
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DepilZone.Application.Interface;
using DepilZone.Data.Response;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteContratoController : ControllerBase
    {
        private readonly IClienteContratoApp _contrato;
        private RClienteContrato _response;
        public ClienteContratoController(IClienteContratoApp ClienteContratoApp)
        {
            _contrato = ClienteContratoApp;
            _response = new RClienteContrato();
        }

        [HttpPost]
        public async Task<ActionResult> GuardarContrato( ClienteContratoDTO model )
        {
            try
            {
                var response = await _contrato.GuardarContrato(model);
                return Ok(new {
                    data = response,
                    message = "",
                    status = StatusCodes.Status200OK
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

        [HttpGet("cliente/{idCliente}")]
        public async Task<ActionResult> ListarByIdCliente(int idCLiente)
        {
            try
            {
                var collection = await _contrato.ListarByIdCliente(idCLiente);
                return Ok(new
                {
                    data = collection,
                    message = "",
                    status = StatusCodes.Status200OK
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

        [HttpGet("cliente/{idCliente}/servicio/{idServicio}")]
        public async Task<ActionResult> ListarByIdClientePorServicio(int idCLiente, int idServicio)
        {
            try
            {
                var collection = await _contrato.ListarByIdClientePorServicio(idCLiente, idServicio);
                return Ok(new
                {
                    data = collection,
                    message = "",
                    status = StatusCodes.Status200OK
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


        [HttpPut("anular")]
        public async Task<ActionResult> AnularContrato(ClienteContratoDTO model)
        {
            try
            {
                await _contrato.AnularContrato(model.Id, model);
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

        [HttpGet("{idContrato}")]
        public async Task<ActionResult> verContrato(int idContrato)
        {
            try
            {
                var response = await _contrato.verContrato(idContrato);
                return Ok(new
                {
                    data = _response.VerContrato(response),
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
                    data = new {},
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }

        [HttpPost("enviarEmail")]
        public async Task<ActionResult> sendMailToClient(ClienteContratoDTO model)
        {
            try
            {
                await _contrato.EnviarContratoPorCorreo(model);
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

    }
}