using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepilZone.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CitaDetalleController : Controller
	{
		private readonly ICitaDetalleApp _citaDetalle;
		public IActionResult Index()
		{
			return View();
		}
		public CitaDetalleController(ICitaDetalleApp DetalleCitaApp)
		{
			this._citaDetalle = DetalleCitaApp;
		}
		//[HttpGet]
		//public async Task<IEnumerable<CitaDetalleEnt>> Get()
		//{
		//	return await _citaDetalle.Obtener();
		//}

		//[HttpPost]
		//public async Task<Respuesta<CitaDetalleEnt>> Post(CitaDetalleEnt model)
		//{
		//	return await _citaDetalle.Insertar(model);
		//}

		//[HttpPut]
		//public async Task<Respuesta<CitaDetalleEnt>> Put(CitaDetalleEnt model)
		//{
		//	return await _citaDetalle.Modificar(model);
		//}

		[HttpGet("horarioNoDisponible/{fecha},{idMaquina},{idSede},{idUsuario},{idAccion}, {idCita}")]
		public async Task<IEnumerable<CitaNoDisponibleDTO>> GetHorarioNoDisponible(DateTime fecha, int idMaquina, int idSede, int idUsuario,int idAccion, int idCita)
		{
			return await _citaDetalle.GetHorarioNoDisponible(fecha, idMaquina, idSede, idUsuario, idAccion, idCita);
		}

		[HttpGet("cita/{idCita}")]
		public async Task<IEnumerable<CitaDetalleZonaDTO>> ObtenerDetalleCitaByCita( int idCita )
        {
			return await _citaDetalle.ObtenerDetallesCitaByCita(idCita);
        }

	}
}
