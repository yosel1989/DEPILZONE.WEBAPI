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
    public class MaquinaSedeController : ControllerBase
    {
        private readonly IMaquinaSedeApp _IMaquinaSedeApp;

        public MaquinaSedeController(IMaquinaSedeApp IMaquinaSedeApp)
        {
            _IMaquinaSedeApp = IMaquinaSedeApp;
        }


        [HttpPost]
        public async Task<Respuesta<MaquinaSedeEnt>> Post(MaquinaSedeEnt model)
        {
            return await _IMaquinaSedeApp.Insertar(model);
        }

        [HttpPut]
        public async Task<Respuesta<MaquinaSedeEnt>> Put(MaquinaSedeEnt model)
        {
            return await _IMaquinaSedeApp.Modificar(model);
        }
        [HttpGet("{id}")]
        public async Task<MaquinaSedeEnt> Get(int id)
        {
            return await _IMaquinaSedeApp.ObtenerById(id);
        }


        [HttpGet("nombre/{nombre}")]
        public async Task<IEnumerable<MaquinaSedeGridDTO>> ObtenerByNombre(string nombre)
        {
            return await _IMaquinaSedeApp.ObtenerByNombre(nombre);
        }
        [HttpGet("sede/{idSede}")]
        public async Task<IEnumerable<MaquinaSedeGridDTO>> ObtenerBySede(int idSede)
        {
            return await _IMaquinaSedeApp.ObtenerBySede(idSede);
        }
        [HttpGet("{nombre}/{idSede}")]
        public async Task<IEnumerable<MaquinaSedeGridDTO>> ObtenerByFiltros(string nombre, int idSede)
        {
            return await _IMaquinaSedeApp.ObtenerByFiltros(nombre, idSede);
        }
        [HttpGet("listadoGrilla/{idEstado}")]
        public async Task<IEnumerable<MaquinaSedeGridDTO>> GetListadoGrilla(int idEstado)
        {
            return await _IMaquinaSedeApp.Obtener(idEstado);
        }
        [HttpGet("buscar-por-servicio/{idSede}/{idServicio}")]
        public async Task<ActionResult> BuscarPorSedeyServicio(int idSede, int idServicio)
        {
            try
            {
                List<MaquinaSedeGridDTO> collection = await _IMaquinaSedeApp.BuscarPorSedeyServicio(idSede, idServicio);
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
