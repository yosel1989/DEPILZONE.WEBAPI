using DepilZone.Application.Interface;
using DepilZone.Entidad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class CitaMensajeNotaController : Controller
	{
		private readonly ICitaMensajeNotaApp _notas;
		public IActionResult Index()
		{
			return View();
		}

        public CitaMensajeNotaController(ICitaMensajeNotaApp NotasApp)
        {
            this._notas = NotasApp;
        }
        [HttpGet]
        public async Task<IEnumerable<CitaMensajeNotaEnt>> Get()
        {
            return await _notas.Obtener();
        }

        [HttpPost]
        public async Task<Respuesta<CitaMensajeNotaEnt>> Post(CitaMensajeNotaEnt model)
        {
            return await _notas.Insertar(model);
        }

        [HttpPut("{id}")]
        public async Task<Respuesta<CitaMensajeNotaEnt>> Put(CitaMensajeNotaEnt model)
        {
            return await _notas.Modificar(model);
        }

        [HttpGet("{id}")]
        public async Task<CitaMensajeNotaEnt> Get(int id)
        {
            return await _notas.ObtenerById(id);
        }

        [HttpGet("cita/{idCita}")]
        public async Task<ActionResult> ListarByCita(int idCita)
        {
            try
            {
                return Ok(new
                {
                    data = await _notas.ListarByCita(idCita),
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
    }
}
