using DepilZone.Application.Interface;
using DepilZone.Entidad;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SedeController : ControllerBase
    {

        private readonly ISedeApp _sede;
        public SedeController(ISedeApp SedeApp)
        {
            this._sede = SedeApp;
        }

        [HttpGet]
        public async Task<IEnumerable<SedeEnt>> Get()
        {
            return await _sede.Obtener();
        }

        [HttpGet("search/{str}")]
        public async Task<IEnumerable<SedeEnt>> LikeNombre(string str)
        {
            return await _sede.ObtenerByLikeNombre(str);
        }

        [HttpPost]
        public async Task<Respuesta<SedeEnt>> Post(SedeEnt model)
        {
            return await _sede.Insertar(model);
        }

        [HttpGet("{id}")]
        public async Task<SedeEnt> Get(int id)
        {
            return await _sede.ObtenerById(id);
        }

        [HttpPut]
        public async Task<Respuesta<SedeEnt>> Put(SedeEnt model)
        {
            return await _sede.Modificar(model);
        }


    }
}
