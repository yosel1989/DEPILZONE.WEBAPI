using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionController : ControllerBase
    {
        private readonly IConfiguracionApp _configuracion;
        public ConfiguracionController(IConfiguracionApp ConfiguracionApp)
        {
            this._configuracion = ConfiguracionApp;
        }
        [HttpPost]
        public async Task<Respuesta<ConfiguracionEnt>> Post(ConfiguracionEnt model)
        {
            return await _configuracion.Insertar(model);
        }

        [HttpPut("{IdConfiguracion}")]
        public async Task<Respuesta<ConfiguracionEnt>> Put(int IdConfiguracion, ConfiguracionEnt model)
        {
            return await _configuracion.Modificar(model);
        }
        [HttpGet("{IdConfiguracion}")]
        public async Task<ConfiguracionEnt> Get(int IdConfiguracion)
        {
            return await _configuracion.ObtenerByIdConfiguracion(IdConfiguracion);
        }

        [HttpGet("search/{str}")]
        public async Task<IEnumerable<ConfiguracionEnt>> LikeNombre(string str)
        {
            return await _configuracion.ObtenerByLikeNombre(str);
        }
        public async Task<IEnumerable<ConfiguracionEnt>> Get()
        {
            return await _configuracion.Obtener();
        }
    }
}
