using DepilZone.Application.Interface;
using DepilZone.Entidad;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DepilZone.Entidad.DTO;

namespace DepilZone.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmpresaController : Controller
	{
		private readonly IEmpresaApp _EmpresaApp;
		public EmpresaController(IEmpresaApp IEmpresaApp)
		{
			this._EmpresaApp = IEmpresaApp;
		}
		public async Task<IEnumerable<EmpresaEnt>> Get()
		{
			return await _EmpresaApp.Obtener();
		}
		[HttpGet("ticket/{idCita}")]
		public async Task<EmpresaEmisionTicketDTO> ObtenerEmpresaEmisionTicketByCita(int idCita)
		{
			return await _EmpresaApp.ObtenerEmpresaEmisionTicketByCita(idCita);
		}
	}
	
}
