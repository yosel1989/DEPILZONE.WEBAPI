using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IUsuarioDom
    {
        Task<IEnumerable<UsuarioGridDTO>> Obtener(bool idEstado);
        Task<IEnumerable<UsuarioGridDTO>> ObtenerListadoGrilla();
        Task<UsuarioEnt> ObtenerByIdUsuario(int IdUsuario);
        Task<IEnumerable<UsuarioGridDTO>> ObtenerByIdPerfil(string idPerfil, int idSede);
        Task<IEnumerable<UsuarioGridDTO>> ObtenerResponsableCaja();
        Task<IEnumerable<UsuarioGridDTO>> ObtenerByLikeNombre(string Nombre);
        Task<Respuesta<UsuarioEnt>> Insertar(UsuarioEnt model);
        Task<Respuesta<UsuarioEnt>> Modificar(UsuarioEnt model);
        Task<Respuesta<LoginDTO>> Login(LoginDTO model);
        Task<Respuesta<UsuarioCambiarClaveDTO>> CambiarClave(UsuarioCambiarClaveDTO model);
        Task<List<UsuarioGridDTO>> ListarParaPreferentes();

        Task<List<MenuDTO>> ObtenerMenuByPerfil(int idPerfil);

        Task<List<ShortUser>> CollectionByEstado(int idEstado);

    }
}
