using DepilZone.Application.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaAsignadaController : ControllerBase
    {
        private readonly ICitaAsignadaApp _citaAsignadaApp;

        public CitaAsignadaController(ICitaAsignadaApp ICitaAsignadaApp)
        {
            _citaAsignadaApp = ICitaAsignadaApp;
        }

        [HttpPost]
        public async Task<int> Post(CitaAsignadaListaDTO model)
        {
            return await _citaAsignadaApp.Insertar(model);
        }

        [HttpGet("{fecha}/{sinAsignar}")]
        public async Task<IEnumerable<CitaAsignadaGrillaDTO>> Get(DateTime fecha, bool sinAsignar)
        {
            return await _citaAsignadaApp.ObtenerCitasAsignacion(fecha, sinAsignar);
        }

        [HttpGet("reasignado/{fecha}/{idUsuarioReasignacion}")]
        public async Task<IEnumerable<CitaAsignadaGrillaDTO>> ObtenerCitasAsignada(DateTime fecha, int idUsuarioReasignacion)
        {
            return await _citaAsignadaApp.ObtenerCitasAsignada(fecha, idUsuarioReasignacion);
        }

        [HttpGet("reasignadoByIdUsuario/{tipoAsignacion}/{fechaConfirmacion}/{idUsuarioReasignacion}")]
        public async Task<IEnumerable<CitaAsignadaGrillaDTO>> ObtenerByIdUsuario(int tipoAsignacion, DateTime fechaConfirmacion, int idUsuarioReasignacion)
        {
            return await _citaAsignadaApp.ObtenerByIdUsuario(tipoAsignacion, fechaConfirmacion, idUsuarioReasignacion);
        }


        [HttpGet("lista/{fechaConfirmar}/{sinAsignar}/{asignadoA}/{tipoSiguiente}/{asignadoPor}/{idUsuario}")]
        public async Task<IEnumerable<CitaAsignadaGrillaDTO>> GetListado(DateTime fechaConfirmar, bool sinAsignar, int asignadoA, int tipoSiguiente, int asignadoPor, int idUsuario)
        {
            try
            {
                return await _citaAsignadaApp.ObtenerListado(fechaConfirmar, sinAsignar, asignadoA, tipoSiguiente, asignadoPor, idUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        [HttpGet("abandonadas/lista/{fechaConfirmar}/{sinAsignar}/{asignadoA}/{asignadoPor}/{idUsuario}")]
        public async Task<ActionResult> GetListadoAbandonados(DateTime fechaConfirmar, bool sinAsignar, int asignadoA, int asignadoPor, int idUsuario)
        {
            try
            {
                var collection = await _citaAsignadaApp.ObtenerListadoAbandonados(fechaConfirmar, sinAsignar, asignadoA, asignadoPor, idUsuario);
                return Ok(new
                {
                    data = collection,
                    message = "",
                    status = StatusCodes.Status200OK
                }) ;
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

        [HttpGet("abandonadas/{fecha}/{sinAsignar}")]
        public async Task<ActionResult> GetAbandonadas(DateTime fecha, bool sinAsignar)
        {
            try
            {
                var collection = await _citaAsignadaApp.ObtenerCitasAbandonadasAsignacion(fecha, sinAsignar);
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
                    status = StatusCodes.Status200OK
                });
            }
        }

        [HttpGet("abandonadas/en-espera/{fecha}")]
        public async Task<ActionResult> GetAbandonadasEnEspera(DateTime  fecha)
        {
            try
            {
                var collection = await _citaAsignadaApp.ObtenerCitasAbandonadasAsignacionEnEspera(fecha);
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
                    status = StatusCodes.Status200OK
                });
            }
        }

        [HttpGet("abandonadas/reasignadoByIdUsuario/{tipoAsignacion}/{fechaConfirmacion}/{idUsuarioReasignacion}")]
        public async Task<ActionResult> ObtenerAbandonadasByIdUsuario(int tipoAsignacion, DateTime fechaConfirmacion, int idUsuarioReasignacion)
        {
            try
            {
                var collection = await _citaAsignadaApp.ObtenerAbandonadasByIdUsuario(tipoAsignacion, fechaConfirmacion, idUsuarioReasignacion);
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
                    status = StatusCodes.Status200OK
                });
            }
        }

        [HttpPost("abandonadas")]
        public async Task<int> GuardarAbandonados(CitaAsignadaListaDTO model)
        {
            return await _citaAsignadaApp.GuardarAbandonados(model);
        }

        [HttpPost("abandonadas/en-espera")]
        public async Task<int> AsignarAbandonadosEnEspera(CitaAsignadaListaDTO model)
        {
            return await _citaAsignadaApp.AsignarAbandonadosEnEspera(model);
        }


        [HttpPost("cambiarFecha")]
        public async Task<ActionResult> CambiarFecha(CitaAsignadaGrillaDTO model)
        {
            try
            {
                var output = await _citaAsignadaApp.CambiarFecha(model);
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

        [HttpPut("marcarVisto")]
        public async Task<int> MarcarVisto(List<CitaAsignadaEnt> citaAsignadas) 
        {
            return await _citaAsignadaApp.MarcarVisto(citaAsignadas);
        }
    }

   

}
