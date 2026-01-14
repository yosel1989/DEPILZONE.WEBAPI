using DepilZone.Application.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoriaClinicasController : ControllerBase
    {
        private readonly IHistoriaClinicaApp _historiaClinicaApp;

        /*public HistoriaClinicasController(IHistoriaClinicaApp HistoriaClinicaApp)
        {
            _historiaClinicaApp = HistoriaClinicaApp;
        }

        [HttpPost]
        public async Task<ActionResult> Post(HistoriaClinicaDTO model)
        {
            try
            {
                var historia = await _historiaClinicaApp.GrabarHistoria(model);
                return Ok(new
                {
                    data = historia,
                    mensaje = "",
                    status = 200
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    mensaje = ex.Message,
                    status = 400
                });
            }
        }

        [HttpGet("cita/{idCita}")]
        public async Task<ActionResult> ObtenerByCita(int idCita)
        {
            try
            {
                var historia =  await _historiaClinicaApp.ObtenerByCita(idCita);
                return Ok(new{
                    data = historia,
                    mensaje = "",
                    status = 200
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    mensaje = ex.Message,
                    status = 400
                });
            }
        }

        [HttpGet("cliente/{idCliente}")]
        public async Task<ActionResult> ObtenerListadoByIdCliente(int idCliente)
        {
            try
            {
                var collection = await _historiaClinicaApp.ObtenerListadoByIdCliente(idCliente);
                return Ok(new
                {
                    data = collection,
                    mensaje = "",
                    status = 200
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    mensaje = ex.Message,
                    status = 400
                });
            }
        }

        [HttpGet("{idHistoria}")]
        public async Task<ActionResult> ObtenerById(int idHistoria)
        {
            try
            {
                var historia = await _historiaClinicaApp.ObtenerById(idHistoria);
                return Ok(new
                {
                    data = historia,
                    mensaje = "",
                    status = 200
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    mensaje = ex.Message,
                    status = 400
                });
            }
        }


        [HttpGet("historiaZona/{idHistoriaClinicaZona}/fotos")]
        public async Task<ActionResult<FotoHistorialClinicoDTO>> ObtenerFotosByIdHistoriaZona(int idHistoriaClinicaZona)
        {
            try
            {
                var fotos = await _historiaClinicaApp.ObtenerFotosById(idHistoriaClinicaZona);
                return Ok(new
                {
                    data = fotos,
                    mensaje = "",
                    status = 200
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    mensaje = ex.Message,
                    status = 400
                });
            }
        }
        */

    }
}
