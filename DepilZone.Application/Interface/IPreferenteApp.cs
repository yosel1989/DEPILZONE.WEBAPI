using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IPreferenteApp
    {
        Task<IEnumerable<PreferenteGrillaDTO>> Obtener(DateTime? FechaDesde, DateTime? FechaHasta, int? IdEstado, int? IdTeleoperador, int? IdMedioContacto, int IdUsuarioSistema);
        Task<Respuesta<PreferenteEnt>> Insertar(PreferenteEnt model);
        Task<Respuesta<PreferenteEnt>> Modificar(PreferenteEnt model);
        Task<PreferenteDTO> ObtenerById(int Id, int IdUsuarioSistema);
        Task<Respuesta<PreferenteEnt>> Asignar(PreferenteEnt model);
        Task<Respuesta<PreferenteEnt>> Atendido(PreferenteEnt model);
        Task<int> ObtenerSinAtender();

        Task<bool> ImportarExcel(List<PreferenteImportarDTO> listado);
        Task<int> ActualizaEstadoVisto(ListaIdsDTO idsPreferente);

        Task<bool> AsignarLista(List<PreferenteAsignarListaDTO> listado);
    }
}
