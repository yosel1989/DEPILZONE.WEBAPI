using DepilZone.Application.Interface;
using DepilZone.Entidad;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoIdentidadTipoController : ControllerBase
    {
        private readonly IDocumentoIdentidadTipoApp _IDocumentoIdentidadTipoApp;
        public DocumentoIdentidadTipoController(IDocumentoIdentidadTipoApp IDocumentoIdentidadTipo)
        {
            _IDocumentoIdentidadTipoApp = IDocumentoIdentidadTipo;
        }

        [HttpGet]
        public async Task<IEnumerable<DocumentoIdentidadTipoEnt>> Get()
        {
            return await _IDocumentoIdentidadTipoApp.Obtener();
        }
    }
}
