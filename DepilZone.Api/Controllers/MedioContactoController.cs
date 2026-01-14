using DepilZone.Data.Interface;
using DepilZone.Entidad;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedioContactoController : ControllerBase
    {
        private readonly IMedioContactoApp _IMedioContactoApp;

        public MedioContactoController(IMedioContactoApp IMedioContactoApp)
        {
            this._IMedioContactoApp = IMedioContactoApp;
        }

        [HttpGet]
        public async Task<IEnumerable<MedioContactoEnt>> Get()
        {
            return await _IMedioContactoApp.Obtener();
        }
    }
}
