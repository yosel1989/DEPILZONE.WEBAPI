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
    public class PromocionController : ControllerBase
    {
        private readonly IPromocionApp _IPromocionApp;        
        public PromocionController(IPromocionApp IPromocionApp)
        {
            this._IPromocionApp = IPromocionApp;
        }

        [HttpGet("vista/{idPromocion}")]
        public async Task<IEnumerable<PromocionVistaDetalleDTO>> ObtenerPromocionVistaDetalle(int idPromocion)
        {
            try
            {
                return await _IPromocionApp.ObtenerPromocionVistaDetalle(idPromocion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        [HttpGet("plantilla/{idPromocion}")]
        public async Task<IEnumerable<PromocionVistaDatosPlantillaDTO>> ObtenerPromocionVistaPlantilla(int idPromocion)
        {
            return await _IPromocionApp.ObtenerPromocionVistaPlantilla(idPromocion);
        }

        [HttpGet("condicion/{idPromocion}")]
        public async Task<PromocionVistaDatosCondicionadoDTO> ObtenerPromocionVistaCondicionado(int idPromocion)
        {
            return await _IPromocionApp.ObtenerPromocionVistaCondicionado(idPromocion);
        }


        [HttpGet("activo/{activo}")]
        public async Task<IEnumerable<PromocionGrillaDTO>> Obtener(int activo)
        {
            return await _IPromocionApp.Obtener(activo);
        }

        [HttpGet("activo/{activo}/servicio/{idServicio}")]
        public async Task<IEnumerable<PromocionGrillaDTO>> ObtenerPorServicio(int activo, int idServicio)
        {
            return await _IPromocionApp.ObtenerPorServicio(activo, idServicio);
        }

        [HttpGet("categoria/{idCategoria}/{activo}")]
        public async Task<IEnumerable<PromocionGrillaDTO>> ObtenerPorCategoria(int idCategoria, int activo)
        {
            return await _IPromocionApp.ObtenerPorCategoria(idCategoria, activo);
        }

        [HttpGet("{id}")]
        public async Task<PromocionDTO> ObtenerById(int id)
        {
            return await _IPromocionApp.ObtenerById(id);
        }

        [HttpGet("search/{str}")]
        public async Task<IEnumerable<PromocionGrillaDTO>> LikeNombre(string str)
        {
            return await _IPromocionApp.ObtenerByLikeNombre(str);
        }

        [HttpPost]
        public async Task<Respuesta<PromocionEnt>> Post(PromocionEnt model)
        {
            return await _IPromocionApp.Insertar(model);
        }

        [HttpPut]
        public async Task<Respuesta<PromocionEnt>> Put(PromocionEnt model)
        {
            try
            {
                return await _IPromocionApp.Modificar(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }



        [HttpGet("ranking-venta/{fechaInicio}/{fechaFin}/{idSede}/{idPromocion}")]
        public async Task<ActionResult> ObtenerRankingVenta(DateTime fechaInicio, DateTime fechaFin, int idSede, int idPromocion)
        {
            try
            {
                var collection = await _IPromocionApp.ObtenerRankingVenta( fechaInicio,  fechaFin,  idSede, idPromocion);
                return Ok(new {
                    data = collection,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }


        [HttpGet("ranking-agendados/{fechaInicio}/{fechaFin}/{idSede}/{idPromocion}")]
        public async Task<ActionResult> ObtenerRankingAgendados(DateTime fechaInicio, DateTime fechaFin, int idSede, int idPromocion)
        {
            try
            {
                var collection = await _IPromocionApp.ObtenerRanking(fechaInicio, fechaFin, idSede, idPromocion);
                return Ok(new
                {
                    data = collection,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }

        [HttpGet("ranking-atendidos/{fechaInicio}/{fechaFin}/{idSede}/{idPromocion}")]
        public async Task<ActionResult> ObtenerRankingAtendidos(DateTime fechaInicio, DateTime fechaFin, int idSede, int idPromocion)
        {
            try
            {
                var collection = await _IPromocionApp.ObtenerRankingAtendido(fechaInicio, fechaFin, idSede, idPromocion);
                return Ok(new
                {
                    data = collection,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }

        [HttpGet("top10Zonas/{fechaInicio}/{fechaFin}/{idSede}/{idTipo}/{idPromocion}")]
        public async Task<ActionResult> ObtenerTop10Zonas(DateTime fechaInicio, DateTime fechaFin, int idSede, int idTipo, int idPromocion)
        {
            try
            {
                var collection = await _IPromocionApp.ObtenerTop10Zonas(fechaInicio, fechaFin, idSede, idTipo, idPromocion);
                return Ok(new
                {
                    data = collection,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }


        [HttpGet("bottom10Zonas/{fechaInicio}/{fechaFin}/{idSede}/{idTipo}/{idPromocion}")]
        public async Task<ActionResult> ObtenerBottom10Zonas(DateTime fechaInicio, DateTime fechaFin, int idSede, int idTipo, int idPromocion)
        {
            try
            {
                var collection = await _IPromocionApp.ObtenerBottom10Zonas(fechaInicio, fechaFin, idSede, idTipo, idPromocion);
                return Ok(new
                {
                    data = collection,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }

        [HttpGet("zonasRanking/{fechaInicio}/{fechaFin}/{idSede}/{idTipo}/{idPromocion}")]
        public async Task<ActionResult> ObtenerZonasRanking(DateTime fechaInicio, DateTime fechaFin, int idSede, int idTipo, int idPromocion)
        {
            try
            {
                var collection = await _IPromocionApp.ObtenerZonasRanking(fechaInicio, fechaFin, idSede, idTipo, idPromocion);
                return Ok(new
                {
                    data = collection,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = e.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }



    }
}
