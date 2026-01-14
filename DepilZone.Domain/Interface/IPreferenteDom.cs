using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Interface
{
    public interface IPreferenteDom
    {
        Task<IEnumerable<PreferenteGrillaDTO>> Obtener(DateTime? FechaDesde, DateTime? FechaHasta, int? IdEstado, int? IdTeleoperador, int? IdMedioContacto, int IdUsuarioSistema);
        Task<PreferenteDTO> ObtenerById(int Id, int IdUsuarioSistema);
        Task<Respuesta<PreferenteEnt>> Insertar(PreferenteEnt model);
        Task<Respuesta<PreferenteEnt>> Modificar(PreferenteEnt model);
        Task<Respuesta<PreferenteEnt>> Asignar(PreferenteEnt model);
        Task<Respuesta<PreferenteEnt>> Atendido(PreferenteEnt model);

        Task<bool> ImportarExcel(List<PreferenteImportarDTO> listado);

        Task<bool> AsignarLista(List<PreferenteAsignarListaDTO> listado);

        Task<int> ObtenerSinAtender();
        Task<int> ActualizaEstadoVisto(ListaIdsDTO idsPreferente);
    }
}
