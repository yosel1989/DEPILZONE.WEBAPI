using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain
{
    public class UsuarioDom: IUsuarioDom
    {

        private readonly IUsuarioDat _IUsuarioDat;
        public UsuarioDom(IUsuarioDat IUsuarioDat)
        {
            this._IUsuarioDat = IUsuarioDat;
        }
        public async Task<IEnumerable<UsuarioGridDTO>> Obtener(bool idEstado)
        {
            return await _IUsuarioDat.Obtener(idEstado);
        }
        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerListadoGrilla()
        {
            return await _IUsuarioDat.ObtenerListadoGrilla();
        }
        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerByLikeNombre(string Nombre)
        {
            return await _IUsuarioDat.ObtenerByLikeNombre(Nombre);
        }

        public async Task<Respuesta<UsuarioEnt>> Insertar(UsuarioEnt model)
        {
            return await _IUsuarioDat.Insertar(model);
        }
        public async Task<Respuesta<UsuarioEnt>> Modificar(UsuarioEnt model)
        {
            return await _IUsuarioDat.Modificar(model);
        }

        public async Task<Respuesta<UsuarioCambiarClaveDTO>> CambiarClave(UsuarioCambiarClaveDTO model)
        {
            return await _IUsuarioDat.CambiarClave(model);
        }

        public async Task<UsuarioEnt> ObtenerByIdUsuario(int IdUsuario)
        {
            return await _IUsuarioDat.ObtenerByIdUsuario(IdUsuario);
        }
        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerByIdPerfil(string idPerfil, int idSede)
        {
            return await _IUsuarioDat.ObtenerByIdPerfil(idPerfil, idSede);
        }
        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerResponsableCaja()
        {
            return await _IUsuarioDat.ObtenerResponsableCaja();
        }


        public async Task<Respuesta<LoginDTO>> Login(LoginDTO model)
        {
            return await _IUsuarioDat.Login(model);
        }
        
        public async Task<List<UsuarioGridDTO>> ListarParaPreferentes()
        {
            return await _IUsuarioDat.ListarParaPreferentes();
        }

        public async Task<List<MenuDTO>> ObtenerMenuByPerfil(int idPerfil)
        {
            return await _IUsuarioDat.ObtenerMenuByPerfil(idPerfil);
        }

        public async Task<List<ShortUser>> CollectionByEstado(int idEstado)
        {
            return await _IUsuarioDat.CollectionByEstado(idEstado);
        }

    }
}
