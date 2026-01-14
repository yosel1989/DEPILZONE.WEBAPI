using DepilZone.Application.Interface;
using DepilZone.Entidad;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TipoClienteController : ControllerBase
	{
		private readonly ITipoClienteApp _TipoCliente;
		public TipoClienteController(ITipoClienteApp TipoClienteApp)
		{
			this._TipoCliente = TipoClienteApp;
		}

		[HttpGet]
		public async Task<IEnumerable<TipoClienteEnt>> Get()
		{
			return await _TipoCliente.Obtener();
		}
	}
}
