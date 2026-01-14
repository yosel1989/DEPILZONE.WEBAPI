using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class PreferenteDom: IPreferenteDom
    {

        private readonly IPreferenteDat _IPreferenteDat;
        public PreferenteDom(IPreferenteDat IPreferenteDat)
        {
            this._IPreferenteDat = IPreferenteDat;
        }

        public async Task<Respuesta<PreferenteEnt>> Asignar(PreferenteEnt model)
        {
            return await _IPreferenteDat.Asignar(model);
        }

        public async Task<Respuesta<PreferenteEnt>> Atendido(PreferenteEnt model)
        {
            return await _IPreferenteDat.Atendido(model);
        }

        public async Task<Respuesta<PreferenteEnt>> Insertar(PreferenteEnt model)
        {
            return await _IPreferenteDat.Insertar(model);
        }

        public async Task<Respuesta<PreferenteEnt>> Modificar(PreferenteEnt model)
        {
            return await _IPreferenteDat.Modificar(model);
        }

        public async Task<IEnumerable<PreferenteGrillaDTO>> Obtener(DateTime? FechaDesde, DateTime? FechaHasta, int? IdEstado, int? IdUsuario, int? IdMedioContacto, int IdUsuarioSistema)
        {
            return await _IPreferenteDat.Obtener(FechaDesde, FechaHasta, IdEstado, IdUsuario, IdMedioContacto, IdUsuarioSistema);
        }

        public async Task<PreferenteDTO> ObtenerById(int Id, int IdUsuarioSistema)
        {
            return await _IPreferenteDat.ObtenerById(Id, IdUsuarioSistema);
        }

        public async Task<int> ObtenerSinAtender()
        {
            return await _IPreferenteDat.RetornarSinAtender();
        }

        public async Task<int> ActualizaEstadoVisto(ListaIdsDTO idsPreferente)
        {
            return await _IPreferenteDat.ActualizaEstadoVisto(idsPreferente);
        }

        public async Task<bool> ImportarExcel(List<PreferenteImportarDTO> listado)
        {
            return await _IPreferenteDat.ImportarExcel(listado);
        }

        public async Task<bool> AsignarLista(List<PreferenteAsignarListaDTO> listado)
        {
            return await _IPreferenteDat.AsignarLista(listado);
        }
    }
}
