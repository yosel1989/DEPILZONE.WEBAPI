using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocionPrecioController : ControllerBase
    {
        private readonly IPromocionPrecioApp _IProgramacionPrecioApp;
        public PromocionPrecioController(IPromocionPrecioApp IProgramacionPrecioApp)
        {
            _IProgramacionPrecioApp = IProgramacionPrecioApp;
        }

        [HttpPost]
        public async Task<Respuesta<PromocionPrecioEnt>> Post(PromocionPrecioEnt model)
        {
            return await _IProgramacionPrecioApp.Insertar(model);
        }
        [HttpGet("{idPromocion}")]
        public async Task<IEnumerable<PromocionPrecioEnt>> ObtenerByIdPromocion(int idPromocion)
        {
            return await _IProgramacionPrecioApp.ObtenerByIdPromocion(idPromocion);
        }
        [HttpGet("{idzona},{sesiones},{idpromocion}")]
        public async Task<IEnumerable<PrecioZonaPromocion>> Obtenerpreciosesionpromocion(int idzona,int sesiones,int idpromocion)
        {
            return await _IProgramacionPrecioApp.Obtenerpreciosesionpromocion(idzona,sesiones,idpromocion);
        }
        [HttpDelete("{id}")]
        public async Task<Respuesta<PromocionPrecioEnt>> DeleteById(int id)
        {
            return await _IProgramacionPrecioApp.DeleteById(id);
        }
        

    }
}
