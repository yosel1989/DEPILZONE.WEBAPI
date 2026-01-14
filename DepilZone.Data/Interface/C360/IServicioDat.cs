using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Data.Interface.C360
{
	public interface IServicioDat
	{
		Task<List<ServicioDTO>> Listar();
		Task<List<ServicioDTO>> ListarByEstado(int idEstado);
		Task<bool> Registrar(ServicioDTO model);
		Task<bool> Modificar(int id, ServicioDTO model);
	}
}
