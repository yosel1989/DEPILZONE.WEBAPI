using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Application.Interface.C360
{
    public interface IServicioApp
	{
		Task<List<ServicioDTO>> Listar();
		Task<List<ServicioDTO>> ListarByEstado(int idEstado);
		Task<bool> Registrar(ServicioDTO model);
		Task<bool> Modificar(int id, ServicioDTO model);
	}
}
