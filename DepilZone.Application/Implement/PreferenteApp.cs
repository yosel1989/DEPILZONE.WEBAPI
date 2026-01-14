using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class PreferenteApp: IPreferenteApp
    {

        private readonly IPreferenteDom _IPreferenteDom;
        public PreferenteApp(IPreferenteDom IPreferenteDom)
        {
            _IPreferenteDom = IPreferenteDom;
        }

      

        public async Task<Respuesta<PreferenteEnt>> Asignar(PreferenteEnt model)
        {
            return await _IPreferenteDom.Asignar(model);
        }
        public async Task<Respuesta<PreferenteEnt>> Atendido(PreferenteEnt model)
        {
            return await _IPreferenteDom.Atendido(model);
        }


        public async Task<Respuesta<PreferenteEnt>> Insertar(PreferenteEnt model)
        {
            return await _IPreferenteDom.Insertar(model);
        }

        public async Task<Respuesta<PreferenteEnt>> Modificar(PreferenteEnt model)
        {
            return await _IPreferenteDom.Modificar(model);
        }

        public async Task<IEnumerable<PreferenteGrillaDTO>> Obtener(DateTime? FechaDesde, DateTime? FechaHasta, int? IdEstado, int? IdUsuario, int? IdMedioContacto, int IdUsuarioSistema)
        {
            return await _IPreferenteDom.Obtener(FechaDesde, FechaHasta, IdEstado, IdUsuario, IdMedioContacto, IdUsuarioSistema);
        }

        public async Task<PreferenteDTO> ObtenerById(int Id, int IdUsuarioSistema)
        {
            return await _IPreferenteDom.ObtenerById(Id, IdUsuarioSistema);
        }

        public async Task<int> ObtenerSinAtender()
        {
            return await _IPreferenteDom.ObtenerSinAtender();
        }
        public async Task<int> ActualizaEstadoVisto(ListaIdsDTO idsPreferente)
        {
            return await _IPreferenteDom.ActualizaEstadoVisto(idsPreferente);
        }

        public async Task<bool> ImportarExcel(List<PreferenteImportarDTO> listado)
        {
            return await _IPreferenteDom.ImportarExcel(listado);
        }

        public async Task<bool> AsignarLista(List<PreferenteAsignarListaDTO> listado)
        {
            return await _IPreferenteDom.AsignarLista(listado);
        }
    }
}
