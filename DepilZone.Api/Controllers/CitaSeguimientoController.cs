using DepilZone.Application.Interface;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
    public class CitaSeguimientoController : ControllerBase
    {
        private readonly ICitaSeguimientoApp _CitaSeguimiento;

        public CitaSeguimientoController(ICitaSeguimientoApp citaSeguimientoApp)
        {
            this._CitaSeguimiento = citaSeguimientoApp;
        }

        [HttpGet("{idCita}")]
        public async Task<IEnumerable<CitaSeguimientoDTO>> ObtenerGridByCita(int idCita)
        {
            return await _CitaSeguimiento.ObtenerGridByCita(idCita);
        }
        [HttpGet("cliente/{idCliente}")]
        public async Task<IEnumerable<CitaSeguimientoDTO>> ObtenerGridByCliente(int idCliente)
        {
            return await _CitaSeguimiento.ObtenerGridByCliente(idCliente);
        }
        [HttpGet("cliente/{idCliente}/servicio/{idServicio}")]
        public async Task<IEnumerable<CitaSeguimientoDTO>> ObtenerGridByClientePorServicio(int idCliente, int idServicio)
        {
            try
            {
                return await _CitaSeguimiento.ObtenerGridByClientePorServicio(idCliente, idServicio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
