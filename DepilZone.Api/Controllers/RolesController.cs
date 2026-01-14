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
	public class RolesController : Controller
	{
		private readonly IRolesApp _roles;
		public RolesController(IRolesApp RolesApp)
		{
			this._roles = RolesApp;
		}
		[HttpPost]
		public async Task<Respuesta<RolesEnt>> Post(RolesEnt model)
		{
			return await _roles.Insertar(model);
		}
		[HttpGet("{IdUsuario},{idModulo}")]
		public async Task<IEnumerable<RolesMenuEnt>> Get(int IdUsuario, int idModulo)
		{
			return await _roles.ObtenerById(IdUsuario, idModulo);
		}
		[HttpGet("Roles/{IdUsuario}")]
		public async Task<IEnumerable<RolesUsuarioEnt>> ObtenerRoles(int IdUsuario)
		{
			return await _roles.ObtenerRoles(IdUsuario);
		}

		[HttpGet("Rolesmenu/{IdUsuario},{IdModulo}")]
		public async Task<IEnumerable<RolesUsuarioEnt>> ObtenerRolesMenu(int IdUsuario,int IdModulo)
		{
			return await _roles.ObtenerRolesMenu(IdUsuario, IdModulo);
		}
		[HttpPut]
		public async Task<Respuesta<RolesEnt>> Put(RolesEnt model)
		{
			return await _roles.Modificar(model);
		}
	}
}
