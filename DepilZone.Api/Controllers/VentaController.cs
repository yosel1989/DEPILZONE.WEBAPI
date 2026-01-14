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
	public class VentaController : Controller
	{
		private readonly IVentaApp _VentaApp;
		public VentaController(IVentaApp IFacturacionApp)
		{
			this._VentaApp = IFacturacionApp;
		}


		[HttpGet("numeroSerie/{idTipoComprobante},{idSede}")]
		public async Task<UltimaSerieDTO> ObtenerNumeroSerie(int idTipoComprobante, int idSede)
		{
			return await _VentaApp.ObtenerNumeroSerie(idTipoComprobante, idSede);
		}
		[HttpGet("tipoPago")]
		public async Task<IEnumerable<TipoPagoEnt>> ObtenerTipoPago()
		{
			return await _VentaApp.ObtenerTipoPago();
		}
		[HttpPost]
		public async Task<Respuesta<VentaEnt>> Post(VentaEnt model)
		{
			return await _VentaApp.Insertar(model);
		}
		[HttpPost("citaPagada")]
		public async Task<Respuesta<CitaEnt>> ActualizarCitaPagada(VentaEnt model)
		{
			return await _VentaApp.ActualizarCitaPagada(model);
		}
		[HttpGet("ticket/listado/{idSede}/{fechaInicio}/{fechaTermino}")]
		public async Task<IEnumerable<VentaTicketDTO>> Obtener(int idSede, DateTime fechaInicio, DateTime fechaTermino)
		{
            try
            {
				return await _VentaApp.ObtenerTickets(idSede, fechaInicio, fechaTermino);
            }
            catch (Exception ex)
            {
                throw ex;
            }
			
		}
		[HttpGet("anularTicket/{idVenta}/{idUsuarioModifica}")]
		public async Task<Respuesta<VentaEnt>> AnularVentaTicket(int idVenta, int idUsuarioModifica)
		{
			return await _VentaApp.AnularVentaTicket(idVenta, idUsuarioModifica);
		}


		/// <summary>
		/// JOSE
		/// </summary>
		/// <returns></returns>
		//[HttpGet("search/{str}")]
		//public async Task<IEnumerable<FacturacionEnt>> LikeNombre(string str)
		//{
		//	return await _FacturacionApp.ObtenerByLikeNombre(str);
		//}
		[HttpGet("detallefactura/")]
		public async Task<IEnumerable<DetalleventaEnt>> Obtenerdetallefactura()
		{
			return await _VentaApp.Obtenerdetallefactura();
		}
		[HttpGet("detallefacturaid/{idventa}")]
		public async Task<IEnumerable<DetalleventaEnt>> Obtenerdetallefacturaid(int idventa)
		{
			return await _VentaApp.Obtenerdetallefacturaid(idventa);
		}
		[HttpGet("detallecita/{idcita}")]
		public async Task<IEnumerable<DetalleCitaFacturacionEnt>> Obtenerdetallecita(int IdCita)
		{
			return await _VentaApp.Obtenerdetallecita(IdCita);
		}
	
		[HttpGet("reenvio/{Documento},{tipooper},{fecha}")]
		public async Task<IEnumerable<ReenvioDTO>> reenvio(string Documento,int tipooper,string fecha)
		{
			return await _VentaApp.reenvio(Documento, tipooper, fecha);
		}
		[HttpGet("venta/{idventa}")]
		public async Task<IEnumerable<VentaEnt>> Obtenerventaporid(int idventa)
		{
			return await _VentaApp.Obtenerventaporid(idventa);
		}
		[HttpGet("numerodocumento/{NumeroDocumento}")]
		public async Task<IEnumerable<VentaEnt>> Obtenerventaporidnumerodocumento(string NumeroDocumento)
		{
			return await _VentaApp.Obtenerventaporidnumerodocumento(NumeroDocumento);
		}
		[HttpGet("ventaporcita/{idcita}")]
		public async Task<IEnumerable<VentaEnt>> Obtenerventaporidcita(int idcita)
		{
			return await _VentaApp.Obtenerventaporidcita(idcita);
		}
		[HttpGet("validacionsedeusuariocita/{idusuario}/{idcita}")]
		public async Task<IEnumerable<AperturaEnd>> Validacionsedeusuariocita(int idusuario, int idcita)
		{
			return await _VentaApp.Validacionsedeusuariocita(idusuario,idcita);
		}

		[HttpGet("reporte/{fechaInicio}/{fechaFin}/{idSede}/{idGenero}/{numeroSesion}")]
		public async Task<ActionResult> ObtenerVentasTotales(DateTime fechaInicio, DateTime fechaFin, int idSede, int idGenero, int numeroSesion)
		{
			try
			{
				List<VentaDTO> ventas = await _VentaApp.ObtenerVentasTotales(fechaInicio, fechaFin, idSede, idGenero, numeroSesion);
				return Ok(new
				{
					data = ventas,
					message = "",
					status = 200
				});
			}
			catch (Exception e)
			{
				return BadRequest(new
				{
					data = new { },
					message = e.Message,
					status = 400
				});
			}
		}
	}
}
