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
	public class DetalleCitaHorarioController : Controller
	{
		private readonly IDetalleCitaHorarioApp _detalleCitaHorario;
		public IActionResult Index()
		{
			return View();
		}
		public DetalleCitaHorarioController(IDetalleCitaHorarioApp DetalleCitaHorarioApp)
		{
			this._detalleCitaHorario = DetalleCitaHorarioApp;
		}
		[HttpGet]
		public async Task<IEnumerable<DetalleCitaHorarioEnt>> Get()
		{
			return await _detalleCitaHorario.Obtener();
		}

		[HttpPost]
		public async Task<Respuesta<DetalleCitaHorarioEnt>> Post(DetalleCitaHorarioEnt model)
		{
			return await _detalleCitaHorario.Insertar(model);
		}

		[HttpPut("{id}")]
		public async Task<Respuesta<DetalleCitaHorarioEnt>> Put(DetalleCitaHorarioEnt model)
		{
			return await _detalleCitaHorario.Modificar(model);
		}

		[HttpGet("{id}")]
		public async Task<DetalleCitaHorarioEnt> Get(int id)
		{
			return await _detalleCitaHorario.ObtenerById(id);
		}
		[HttpGet("{horainicio},{horafin},{IdMaquina},{IdSede}")]
		public async Task<IEnumerable<RangoHorarioEnt>> Obteneridhorariocita(string horainicio, string horafin, int IdMaquina,int IdSede)
		{
			return await _detalleCitaHorario.Obteneridhorariocita(horainicio, horafin, IdMaquina , IdSede);
		}
	}
}
