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
    public class CitaMensajeDetalleController : Controller
	{
	
		private readonly ICitaMensajeDetalleApp _detalle;
		public IActionResult Index()
		{
			return View();
		}
        public CitaMensajeDetalleController(ICitaMensajeDetalleApp DetalleApp)
        {
            this._detalle = DetalleApp;
        }
        [HttpGet]
        public async Task<IEnumerable<CitaMensajeDetalleEnt>> Get()
        {
            return await _detalle.Obtener();
        }

        [HttpPost]
        public async Task<Respuesta<CitaMensajeDetalleEnt>> Post(CitaMensajeDetalleEnt model)
        {
            return await _detalle.Insertar(model);
        }

        [HttpPut("{id}")]
        public async Task<Respuesta<CitaMensajeDetalleEnt>> Put(CitaMensajeDetalleEnt model)
        {
            return await _detalle.Modificar(model);
        }

        [HttpGet("{id}")]
        public async Task<CitaMensajeDetalleEnt> Get(int id)
        {
            return await _detalle.ObtenerById(id);
        }

        [HttpGet("cita/{idCita}")]
        public async Task<ActionResult> ListarByCita(int idCita)
        {
            try
            {
                return Ok(new
                {
                    data = await _detalle.ListarByCita(idCita),
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new {},
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
    }
}
