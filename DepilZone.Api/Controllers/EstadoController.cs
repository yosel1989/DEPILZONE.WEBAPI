using DepilZone.Application.Interface;
using DepilZone.Entidad;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly IEstadoApp _IEstadoApp;

        public EstadoController(IEstadoApp IEstadoApp)
        {
            _IEstadoApp = IEstadoApp;
        }

        [HttpGet]
        public async Task<IEnumerable<EstadoEnt>> Get()
        {
            return await _IEstadoApp.Obtener();
        }

        [HttpGet("{entidad}")]
        public async Task<IEnumerable<EstadoEnt>> GetByEntidad(string entidad)
        {
            return await _IEstadoApp.ObtenerByEntidad(entidad);
        }

    }
}
