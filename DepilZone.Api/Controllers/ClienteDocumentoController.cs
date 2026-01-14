using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteDocumentoController : ControllerBase
    {
        private readonly IClienteDocumentoApp _clienteDocumento;
        public ClienteDocumentoController(IClienteDocumentoApp ClienteDocumentoApp)
        {
            _clienteDocumento = ClienteDocumentoApp;
        }

        [HttpGet]
        public async Task<ActionResult> obtenerListado(int id)
        {
            var documento = await _clienteDocumento.obtenerListado();

            try
            {
                return Ok(new
                {
                    data = documento,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (SystemException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
                throw ex;
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> obtenerDocumentoById(int id)
        {
            var documento = await _clienteDocumento.ObtenerDocumentoById(id);

            try
            {
                return Ok(new
                {
                    data = documento,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (SystemException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
                throw ex;
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new {},
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
                throw ex;
            }
        }

        [HttpPut("{id}/anular")]
        public async Task<ActionResult> cancelDocument(int id, ClienteDocumentoDTO model)
        {
            try
            {
                var res = await _clienteDocumento.AnularDocumento(id, model);
                return Ok(new
                {
                    data = res,
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
                    status = StatusCodes.Status200OK
                });

            }
        }


        [HttpPut("{id}/restaurar")]
        public async Task<ActionResult> restoreDocument(int id, ClienteDocumentoDTO model)
        {
            try
            {
                var res = await _clienteDocumento.RestaurarDocumento(id, model);
                return Ok(new
                {
                    data = res,
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
                    status = StatusCodes.Status200OK
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult> insertDocument(ClienteDocumentoDTO model)
        {
            try
            {
                var documento = await _clienteDocumento.InsertarDocumento(model);
                return Ok(new
                {
                    data = documento,
                    message = "",
                    status = StatusCodes.Status201Created
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
            catch (SystemException ex)
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

        [HttpPost("enviarEmail")]
        public async Task<ActionResult> sendMailToClient(ClienteDocumentoDTO model)
        {
            try
            {
                var response = await _clienteDocumento.EnviarDocumentoPorCorreo(model);
                return Ok(new
                {
                    data = new { },
                    message = response.Mensaje,
                    status = StatusCodes.Status200OK
                });
            }
            catch (SystemException ex)
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
                throw;
            }
        }

        [HttpGet("cliente/{idCliente}")]
        public async Task<ActionResult> listarByCliente(int idCliente)
        {
            var listado = await _clienteDocumento.obtenerListadoByCliente(idCliente);

            try
            {
                return Ok(new
                {
                    data = listado,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (SystemException ex)
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

        [HttpGet("cliente/{idCliente}/servicio/{idServicio}")]
        public async Task<ActionResult> listarByClientePorServicio(int idCliente, int idServicio)
        {
            var listado = await _clienteDocumento.obtenerListadoByClientePorServicio(idCliente, idServicio);

            try
            {
                return Ok(new
                {
                    data = listado,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (SystemException ex)
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


        [HttpGet("cliente/{idCliente}/{fecha}")]
        public async Task<ActionResult> ListarByIdClienteByFecha(int idCLiente, DateTime fecha)
        {
            try
            {
                var collection = await _clienteDocumento.obtenerListadoByIdClienteByFecha(idCLiente, fecha);
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

        [HttpGet("cliente/{idCliente}/{fecha}/{idServicio}")]
        public async Task<ActionResult> ListarByIdClienteByFechaPorServicio(int idCLiente, DateTime fecha, int idServicio)
        {
            try
            {
                var collection = await _clienteDocumento.obtenerListadoByIdClienteByFechaPorServicio(idCLiente, fecha, idServicio);
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
    }
}