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
    public class EvolucionCitaMensualController : ControllerBase
    {
        private readonly IEvolucionCitaMensualApp _evolucionCitaMensual;
        public EvolucionCitaMensualController(IEvolucionCitaMensualApp EvolucionCitaMensualApp)
        {
            this._evolucionCitaMensual = EvolucionCitaMensualApp;
        }

        [HttpGet("{fecha}/{idSede}")]
        public async Task<EvolucionCitaMensualDTO> Get(DateTime fecha, int idSede)
        {
            return await _evolucionCitaMensual.Obtener(fecha, idSede);
        }

        [HttpPost]
        public async Task<Respuesta<EvolucionCitaMensualEnt>> Post(System.DateTime fecha)
        {
            return await _evolucionCitaMensual.Insertar(fecha);
        }

    }
}
