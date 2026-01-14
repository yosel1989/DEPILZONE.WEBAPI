using DepilZone.Application.Interface;
using DepilZone.Entidad;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioApp _IComentarioApp;

        public ComentarioController(IComentarioApp IComentarioApp)
        {
            this._IComentarioApp = IComentarioApp;
        }


        [HttpGet]
        public async Task<IEnumerable<ComentarioEnt>> Get()
        {
            return await _IComentarioApp.Obtener();
        }
    }
}
