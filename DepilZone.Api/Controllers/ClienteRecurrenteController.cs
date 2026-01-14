using DepilZone.Api.Hubs;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using DepilZone.Entidad.DTO;

namespace DepilZone.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClienteRecurrenteController : Controller
	{
		//public IActionResult Index()
		//{
		//	return View();
		//}
		private readonly IClienteRecurrenteApp _ClienteRecurrenteApp;
		public ClienteRecurrenteController(IClienteRecurrenteApp IClienteRecurrenteApp)
		{
			this._ClienteRecurrenteApp = IClienteRecurrenteApp;
		}

		public async Task<IEnumerable<ClienteRecurrenteDTO>> Get()
		{
			return await _ClienteRecurrenteApp.Obtener();
		}
		[HttpGet("cita/{fechainicio}/{fechaTermino}")]
		public async Task<IEnumerable<ClienteRecurrenteDTO>> Obtenercitafecha(DateTime fechaInicio, DateTime fechaTermino)
		{
			return await _ClienteRecurrenteApp.Obtenercitafecha(fechaInicio, fechaTermino);
		}
	}
}
