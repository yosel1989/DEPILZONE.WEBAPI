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
    public class DocumentoTipoController : ControllerBase
    {
        private readonly IDocumentoTipoApp _documentoTipo;
        public DocumentoTipoController(IDocumentoTipoApp DocumentoTipoApp)
        {
            _documentoTipo = DocumentoTipoApp;
        }

        [HttpGet]
        public async Task<IEnumerable<DocumentoTipoDTO>> ObtenerListado()
        {
            return await _documentoTipo.ObtenerListado();
        }
        [HttpPost]
        public async Task<ActionResult> Create(DocumentoTipoDTO model)
        {
            try
            {
                return Ok(new
                {
                    data = await _documentoTipo.Insertar(model),
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
        [HttpGet("{id}")]
        public async Task<ActionResult> Find(int id)
        {
            try
            {
                return Ok(new
                {
                    data = await _documentoTipo.ObtenerById(id),
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
        [HttpPut]
        public async Task<ActionResult> Update(DocumentoTipoDTO model)
        {
            try
            {
                return Ok(new
                {
                    data = await _documentoTipo.Modificar(model),
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
        [HttpGet("{id}/perfiles")]
        public async Task<IEnumerable<DocumentoTipoPerfilDTO>> FindProfiles(int id)
        {
            return await _documentoTipo.ObtenerPerfilesById(id);
        }
        [HttpPut("{id}/perfiles")]
        public async Task<Respuesta<DocumentoTipoEnt>> AssignProfiles( int id, int[] profiles )
        {
            return await _documentoTipo.AsignarPerfiles(id, profiles);
        }

        [HttpGet("servicio/{idServicio}")]
        public async Task<ActionResult> ListarByServicio(int idServicio)
        {
            try
            {
                return Ok(new
                {
                    data = await _documentoTipo.ListarByServicio(idServicio),
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

    }
}