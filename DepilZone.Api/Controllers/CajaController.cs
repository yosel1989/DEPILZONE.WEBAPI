using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DepilZone.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CajaController : Controller
	{
		private readonly ICajaApp _caja;
		public CajaController(ICajaApp CajaApp)
		{
			this._caja = CajaApp;
		}

		[HttpGet]
		public async Task<IEnumerable<CajaEnt>> Get()
		{
			return await _caja.Obtener();
		}

		[HttpGet("{id}")]
		public async Task<CajaEnt> Get(int id)
		{
			return await _caja.ObtenerById(id);
		}

		[HttpPost]
		public async Task<Respuesta<CajaEnt>> Post(CajaEnt model)
		{
			return await _caja.Insertar(model);
		}

		[HttpPut]
		public async Task<Respuesta<CajaEnt>> Put(CajaEnt model)
		{
			return await _caja.Modificar(model);
		}
		[HttpPut("abrirCerrar")]
		public async Task<Respuesta<CajaEnt>> AbrirCerrar(CajaEnt model)
		{
			return await _caja.AbrirCerrar(model);
		}

		[HttpGet("search/{str}")]
		public async Task<IEnumerable<CajaEnt>> LikeNombre(string str)
		{
			return await _caja.ObtenerByLikeNombre(str);
		}
		
		[HttpGet("consultarAperturaCaja/{idsede}")]
		public async Task<CajaValidacionDTO> ConsultarAperturaCaja(int idsede)
		{
			return await _caja.ConsultarAperturaCaja(idsede);
		}

		[HttpGet("cuadre/{fecha}/{idCaja}")]
		public async Task<CajaCuadreDTO> CuadreDeCaja(DateTime fecha, int idCaja)
		{
			return await _caja.CuadreDeCaja(fecha, idCaja);
		}

		[HttpGet("verificaEstado/{fecha}/{idCaja}")]
		public async Task<int> VerificaEstadoCaja(DateTime fecha, int idCaja)
		{
			return await _caja.VerificaEstadoCaja(fecha, idCaja);
		}
	}
}
