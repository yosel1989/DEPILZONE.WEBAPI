using DepilZone.Application.Interface;
using DepilZone.Entidad;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnuncioController : ControllerBase
    {
        private readonly IAnuncioApp _anuncio;
        public AnuncioController(IAnuncioApp AnuncioApp)
        {
            this._anuncio = AnuncioApp;
        }

        [HttpGet]
        public async Task<IEnumerable<AnuncioEnt>> Get()
        {
            return await _anuncio.Obtener();
        }

        [HttpGet("{id}")]
        public async Task<AnuncioEnt> Get(int id)
        {
            return await _anuncio.ObtenerById(id);
        }

        [HttpPost]
        public async Task<Respuesta<AnuncioEnt>> Post(AnuncioEnt model)
        {
            return await _anuncio.Insertar(model);
        }

        [HttpPut]
        public async Task<Respuesta<AnuncioEnt>> Put(AnuncioEnt model)
        {
            return await _anuncio.Modificar(model);
        }

    }
}
