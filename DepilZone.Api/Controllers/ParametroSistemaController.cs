using DepilZone.Application.Interface;
using DepilZone.Entidad;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametroSistemaController : ControllerBase
    {
        private readonly IParametroSistemaApp _IParametroSistemaApp;

        public ParametroSistemaController(IParametroSistemaApp parametroSistemaApp)
        {
            this._IParametroSistemaApp = parametroSistemaApp;
        }

        [HttpGet("{Id}")]
        public async Task<Respuesta<ParametroSistemaEnt>> ObtenerById(int Id)
        {
            return await _IParametroSistemaApp.ObtenerById(Id);
        }
    }
}
