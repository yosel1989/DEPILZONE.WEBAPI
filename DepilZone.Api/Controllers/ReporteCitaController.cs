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
using Microsoft.AspNetCore.Http;

namespace DepilZone.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReporteCitaController : Controller
	{
		private readonly IReporteCitaApp _ReporteCitaApp;
		public ReporteCitaController(IReporteCitaApp IReporteCitaApp)
		{
			this._ReporteCitaApp = IReporteCitaApp;
		}

		[HttpGet("especialista/atendidos/{idSede}/{fechainicio}/{fechaTermino}/{idUsuario}")]
		public async Task<List<EspecialistaDTO>> ObtenerEspecialistasCitas(int idSede, DateTime fechaInicio, DateTime fechaTermino, int idUsuario)
		{
            try
            {
				return await _ReporteCitaApp.ObtenerEspecialistasCitas(idSede, fechaInicio, fechaTermino, idUsuario);
            }
            catch (Exception e)
            {
                throw e;
            }
			
		}

		[HttpGet("especialista/atendidos/detalle/{idUsuario}/{fecha}/{idSede}")]
		public async Task<List<EspecialistaCitaDTO>> ObtenerEspecialistasCitasDetalle(int idUsuario, DateTime fecha, int idSede)
		{
			try
			{
				return await _ReporteCitaApp.ObtenerEspecialistasCitasDetalle(idUsuario, fecha, idSede);
			}
			catch (Exception e)
			{
				throw e;
			}

		}


		[HttpGet("cronograma-citas-atendidas/{idSede}/{fechaDesde}/{fechaHasta}")]
		public async Task<ActionResult> ObtenerCronogramaCitasAtendidas(int idSede, DateTime fechaDesde, DateTime fechaHasta)
		{
			try
			{
				var collection = await _ReporteCitaApp.ObtenerCronogramaCitasAtendidas(idSede, fechaDesde, fechaHasta);
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
					data = new {},
					message = e.Message,
					status = StatusCodes.Status400BadRequest
				});
			}

		}

	}
}
