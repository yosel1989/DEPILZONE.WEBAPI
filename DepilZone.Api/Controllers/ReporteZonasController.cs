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
	public class ReporteZonasController : Controller
	{
		private readonly IReporteZonasApp _ReporteZonasApp;
		public ReporteZonasController(IReporteZonasApp IReporteZonasApp)
		{
			this._ReporteZonasApp = IReporteZonasApp;
		}

		public async Task<IEnumerable<ReporteZonaDTO>> Get()
		{
			return await _ReporteZonasApp.Obtener();
		}
		[HttpGet("maximo/{fechainicio}/{fechaTermino}")]
		public async Task<IEnumerable<ReporteZonaDTO>> Obtenerfecha(DateTime fechaInicio, DateTime fechaTermino)
		{
			return await _ReporteZonasApp.Obtenerfecha(fechaInicio, fechaTermino);
		}
		[HttpGet("minimo/")]
		public async Task<IEnumerable<ReporteZonaDTO>> Obtenerminimo()
		{
			return await _ReporteZonasApp.Obtenerminimo();
		}
		[HttpGet("minimo/{fechainicio}/{fechaTermino}")]
		public async Task<IEnumerable<ReporteZonaDTO>> Obtenerminimofecha(DateTime fechaInicio, DateTime fechaTermino)
		{
			return await _ReporteZonasApp.Obtenerminimofecha(fechaInicio, fechaTermino);
		}
		[HttpGet("especialistas/")]
		public async Task<IEnumerable<EspecialistasDTO>> Obtenerespecialista()
		{
			return await _ReporteZonasApp.Obtenerespecialista();
		}
		[HttpGet("especialistas/{fechainicio}/{fechaTermino}")]
		public async Task<IEnumerable<EspecialistasDTO>> Obtenerespecialistafecha(DateTime fechaInicio, DateTime fechaTermino)
		{
			return await _ReporteZonasApp.Obtenerespecialistafecha(fechaInicio, fechaTermino);
		}
		[HttpGet("cita/")]
		public async Task<IEnumerable<ReporteCitaDTO>> Obtenercita()
		{
			return await _ReporteZonasApp.Obtenercita();
		}
		[HttpGet("cita/{fechainicio}/{fechaTermino}")]
		public async Task<IEnumerable<ReporteCitaDTO>> Obtenercitafecha(DateTime fechaInicio, DateTime fechaTermino)
		{
			return await _ReporteZonasApp.Obtenercitafecha(fechaInicio, fechaTermino);
		}
		[HttpGet("ple/{fechainicio}/{fechaTermino}")]
		public async Task<IEnumerable<PleEnt>> Obtenerple(DateTime fechaInicio, DateTime fechaTermino)
		{
			return await _ReporteZonasApp.Obtenerple(fechaInicio, fechaTermino);
		}
	}
}
