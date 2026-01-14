using DepilZone.Entidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IEstadoDat
    {
        Task<IEnumerable<EstadoEnt>> Obtener();
        Task<IEnumerable<EstadoEnt>> ObtenerByEntidad(string entidad);
    }
}
