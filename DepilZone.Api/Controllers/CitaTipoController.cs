using DepilZone.Application.Interface;
using DepilZone.Entidad;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaTipoController : ControllerBase
    {
        private readonly ICitaTipoApp _TipoCita;

        public CitaTipoController(ICitaTipoApp TipoCitaApp)
        {
            this._TipoCita = TipoCitaApp;
        }
        [HttpPost]
        public async Task<Respuesta<CitaTipoEnt>> Post(CitaTipoEnt model)
        {
            return await _TipoCita.Insertar(model);
        }
        [HttpPut]
        public async Task<Respuesta<CitaTipoEnt>> Put(CitaTipoEnt model)
        {
            return await _TipoCita.Modificar(model);
        }
        [HttpGet]
        public async Task<IEnumerable<CitaTipoEnt>> Get()
        {
            return await _TipoCita.Obtener();
        }
        [HttpGet("search/{str}")]
        public async Task<IEnumerable<CitaTipoEnt>> LikeNombre(string str)
        {
            return await _TipoCita.ObtenerByLikeNombre(str);
        }
        [HttpGet("{id}")]
        public async Task<CitaTipoEnt> Get(int id)
        {
            return await _TipoCita.ObtenerById(id);
        }
    }
}
