using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class UsuarioApp: IUsuarioApp
    {

        private readonly IUsuarioDom _IUsuarioDom;
        public UsuarioApp(IUsuarioDom IUsuarioDom)
        {
            this._IUsuarioDom = IUsuarioDom;
        }

        public async Task<IEnumerable<UsuarioGridDTO>> Obtener(bool idEstado)
        {
            return await _IUsuarioDom.Obtener(idEstado);
        }
        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerListadoGrilla()
        {
            return await _IUsuarioDom.ObtenerListadoGrilla();
        }
        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerByLikeNombre(string Nombre)
        {
            return await _IUsuarioDom.ObtenerByLikeNombre(Nombre);
        }
        public async Task<UsuarioEnt> ObtenerByIdUsuario(int IdUsuario)
        {
            return await _IUsuarioDom.ObtenerByIdUsuario(IdUsuario);
        }

        public async Task<Respuesta<UsuarioEnt>> Insertar(UsuarioEnt model)
        {
            return await  _IUsuarioDom.Insertar(model);
        }
        public async Task<Respuesta<UsuarioEnt>> Modificar(UsuarioEnt model)
        {
            return await _IUsuarioDom.Modificar(model);
        }

        public async Task<Respuesta<UsuarioCambiarClaveDTO>> CambiarClave(UsuarioCambiarClaveDTO model)
        {
            return await _IUsuarioDom.CambiarClave(model);
        }

        public async Task<Respuesta<LoginDTO>> Login(LoginDTO model)
        {
            return await _IUsuarioDom.Login(model);
        }

        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerByIdPerfil(string idPerfil, int idSede)
        {
            return await _IUsuarioDom.ObtenerByIdPerfil(idPerfil, idSede);
        }
        public async Task<IEnumerable<UsuarioGridDTO>> ObtenerResponsableCaja()
        {
            return await _IUsuarioDom.ObtenerResponsableCaja();
        }

        public async Task<List<UsuarioGridDTO>> ListarParaPreferentes()
        {
            return await _IUsuarioDom.ListarParaPreferentes();
        }

        public async Task<List<MenuDTO>> ObtenerMenuByPerfil(int idPerfil)
        {
            return await _IUsuarioDom.ObtenerMenuByPerfil(idPerfil);
        }

        public async Task<List<ShortUser>> CollectionByEstado(int idEstado)
        {
            return await _IUsuarioDom.CollectionByEstado(idEstado);
        }

    }
}
