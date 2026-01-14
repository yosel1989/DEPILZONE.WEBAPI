using DepilZone.Application.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvolucionTratamientoController : ControllerBase
    {
        private readonly IEvolucionTratamientoApp _historiaClinicaApp;

        public EvolucionTratamientoController(IEvolucionTratamientoApp EvolucionTratamientoApp)
        {
            _historiaClinicaApp = EvolucionTratamientoApp;
        }

        [HttpPost]
        public async Task<ActionResult> Post(EvolucionTratamientoDTO model)
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
            catch (AlertException ex)
            {
                return Ok(new
                {
                    data = new { },
                    mensaje = ex.Message,
                    status = 400
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    mensaje = ex.Message + ex.StackTrace.ToString(),
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


        [HttpGet("historiaZona/{idEvolucionTratamientoZona}/fotos")]
        public async Task<ActionResult<ET_ZonaFotosDTO>> ObtenerFotosByIdHistoriaZona(int idEvolucionTratamientoZona)
        {
            try
            {
                var fotos = await _historiaClinicaApp.ObtenerFotosById(idEvolucionTratamientoZona);
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


    }
}
