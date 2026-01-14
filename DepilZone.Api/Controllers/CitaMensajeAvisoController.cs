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
	public class CitaMensajeAvisoController : Controller
	{
        private readonly ICitaMensajeAvisosApp _avisos;
        public IActionResult Index()
		{
			return View();
		}
        public CitaMensajeAvisoController(ICitaMensajeAvisosApp AvisosApp)
        {
            this._avisos = AvisosApp;
        }
        [HttpGet("{idCita}")]
        public async Task<IEnumerable<CitaMensajeAvisoEnt>> Get(int idCita)
        {
            return await _avisos.Obtener(idCita);
        }

        [HttpPost]
        public async Task<Respuesta<CitaMensajeAvisoEnt>> Post(CitaMensajeAvisoEnt model)
        {
            return await _avisos.Insertar(model);
        }

        [HttpPut]
        public async Task<Respuesta<CitaMensajeAvisoEnt>> Put(CitaMensajeAvisoEnt model)
        {
            return await _avisos.Modificar(model);
        }


        [HttpGet("cita/{idCita}")]
        public async Task<ActionResult> ListarByCita(int idCita)
        {
            try
            {
                return Ok(new
                {
                    data = await _avisos.ListarByCita(idCita),
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

        //[HttpGet("{id}")]
        //public async Task<CitaMensajeAvisoEnt> Get(int id)
        //{
        //    return await _avisos.ObtenerById(id);
        //}
    }
}
