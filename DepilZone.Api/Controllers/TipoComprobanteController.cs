using DepilZone.Application.Interface;
using DepilZone.Entidad;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TipoComprobanteController : ControllerBase
    {
        private readonly ITipoComprobanteApp _ITipoComprobanteApp;

        public TipoComprobanteController(ITipoComprobanteApp iTipoComprobanteApp)
        {
            _ITipoComprobanteApp = iTipoComprobanteApp;
        }

        [HttpGet]
        public async Task<IEnumerable<TipoComprobanteEnt>> Get()
        {
            return await _ITipoComprobanteApp.Obtener();
        }


        [HttpGet("{id}")]
        public async Task<TipoComprobanteEnt> GetById(int id)
        {
            return await _ITipoComprobanteApp.ObtenerById(id);
        }


        [HttpPost]
        public async Task<Respuesta<TipoComprobanteEnt>> Post(TipoComprobanteEnt model)
        {
            return await _ITipoComprobanteApp.Insertar(model);
        }

        [HttpPut]
        public async Task<Respuesta<TipoComprobanteEnt>> Put(TipoComprobanteEnt model)
        {
            return await _ITipoComprobanteApp.Modificar(model);
        }


    }
}
