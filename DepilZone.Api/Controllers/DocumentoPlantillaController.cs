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
    public class DocumentoPlantillaController : ControllerBase
    {
        private readonly IDocumentoPlantillaApp _documentoPlantilla;
        public DocumentoPlantillaController(IDocumentoPlantillaApp DocumentoPlantillaApp)
        {
            _documentoPlantilla = DocumentoPlantillaApp;
        }

        [HttpGet]
        public async Task<IEnumerable<DocumentoPlantillaDTO>> ObtenerListado()
        {
            return await _documentoPlantilla.ObtenerListado();
        }

        [HttpGet("{id}")]
        public async Task<Respuesta<DocumentoPlantillaEnt>> Find(int id)
        {
            return await _documentoPlantilla.ObtenerById(id);
        }

        [HttpPost]
        public async Task<Respuesta<DocumentoPlantillaEnt>> Create(DocumentoPlantillaDTO model)
        {
            return await _documentoPlantilla.Insertar(model);
        }

        [HttpPut]
        public async Task<Respuesta<DocumentoPlantillaEnt>> Update(DocumentoPlantillaDTO model)
        {
            return await _documentoPlantilla.Modificar(model);
        }
    }
}