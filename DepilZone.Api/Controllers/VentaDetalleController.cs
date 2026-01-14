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
	public class VentaDetalleController : Controller
	{
		private readonly IVentaApp _VentaApp;
		public VentaDetalleController(IVentaApp IVentaApp)
		{
			this._VentaApp = IVentaApp;
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
		//[HttpGet("anularticket/{Documento}")]
		//public async Task<IEnumerable<FactuaEliminaEnt>> AnularTicket(string Documento)
		//{
		//	return await _VentaApp.AnularTicket(Documento);
		//}
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
	}
}
