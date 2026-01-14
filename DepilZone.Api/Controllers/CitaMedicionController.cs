using DepilZone.Application.Interface;
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
    public class CitaMedicionController : ControllerBase
    {
        private readonly ICitaMedicionApp _citaMedicion;
        public CitaMedicionController(ICitaMedicionApp CitaMedicionApp)
        {
            this._citaMedicion = CitaMedicionApp;
        }

        [HttpPost]
        public async Task<ActionResult> Post(CitaMedicionDTO model)
        {
            try
            {
                await _citaMedicion.Grabar(model);
 

                return Ok(new
                {
                    data = new { },
                    mensaje = "",
                    status = StatusCodes.Status201Created
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    mensaje = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }


        [HttpGet("cita/{idCita}/{idTipoMedicion}")]
        public async Task<ActionResult> ObtenerByIdCita(int idCita, int idTipoMedicion)
        {
            try
            {
                var citamedicion = await _citaMedicion.ObtenerByIdCita(idCita, idTipoMedicion);

                return Ok(new
                {
                    data = citamedicion,
                    mensaje = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    mensaje = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }


        [HttpGet("reporteGeneral/{IdSede}/{Fdesde}/{Fhasta}/{IdTipoMedicion}")]
        public async Task<ActionResult> ObtenerReporteGeneral(int IdSede, DateTime? Fdesde, DateTime? Fhasta, int IdTipoMedicion)
        {
            try
            {
                CitaMedicion_ParametrosDTO parametros = new CitaMedicion_ParametrosDTO()
                {
                    IdSede = IdSede,
                    Fdesde = Fdesde,
                    Fhasta = Fhasta,
                    IdTipoMedicion = IdTipoMedicion
                };
                var collection = await _citaMedicion.ObtenerReporteGeneral(parametros);
                return Ok(new
                {
                    data = collection,
                    mensaje = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    mensaje = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }


        [HttpGet("citasEncuestadas/{Fdesde}/{Fhasta}/{idSede}")]
        public async Task<ActionResult> ObtenerCitasEncuestadas(DateTime Fdesde, DateTime Fhasta, int idSede)
        {
            try
            {
                var output = await _citaMedicion.ObtenerCitasEncuestadas(Fdesde, Fhasta, idSede);
                return Ok(new
                {
                    data = output,
                    mensaje = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    mensaje = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }

    }
}
