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
    public class PromocionZonaController : ControllerBase
    {
        private readonly IPromocionZonaApp _IPromocionZonaApp;
        public PromocionZonaController(IPromocionZonaApp IPromocionZonaApp)
        {
            this._IPromocionZonaApp = IPromocionZonaApp;
        }

        [HttpGet("{idPromocion}/{idGenero}")]
        public async Task<IEnumerable<PromocionZonaDTO>> Get(int idPromocion, int idGenero)
        {
            return await _IPromocionZonaApp.Obtener(idPromocion, idGenero);
        }
        [HttpGet("servicio/{idServicio}/{idPromocion}/{idGenero}")]
        public async Task<IEnumerable<PromocionZonaDTO>> ObtenerByServicio(int idServicio, int idPromocion, int idGenero)
        {
            return await _IPromocionZonaApp.ObtenerByServicio( idServicio, idPromocion, idGenero);
        }
        [HttpGet("zonasCorporales/{idsZonasCorporales}")]
        public async Task<IEnumerable<PromocionZonaDTO>> GetByIdsZonasCorporales(string idsZonasCorporales)
        {
            return await _IPromocionZonaApp.ObtenerByIdsZonasCorporales(idsZonasCorporales);
        }

        [HttpGet("zona/{idZona}")]
        public async Task<ActionResult> ListarByZona(int idZona)
        {
            try
            {
                return Ok(new
                {
                    data = await _IPromocionZonaApp.ListarByZona(idZona),
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


        [HttpPut]
        public async Task<Respuesta<PromocionZonaEnt>> Put(PromocionZonaEnt model)
        {
            return await _IPromocionZonaApp.ModificarPrecioBase(model);
        }

        [HttpPost]
        public async Task<Respuesta<PromocionZonaDTO>> Post(PromocionZonaEnt model)
        {
            return await _IPromocionZonaApp.Insertar(model);
        }

        [HttpDelete("{id}")]
        public async Task<Respuesta<PromocionZonaEnt>> Delete(int id)
        {
            return await _IPromocionZonaApp.DeleteById(id);
        }
    }
}