using DepilZone.Entidad.DTO.C360;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Data.Interface.C360
{
	public interface ITipoClienteDat
	{
		Task<List<TipoClienteDTO>> Listar();
		Task<List<TipoClienteDTO>> ListarByEstado(int idEstado);
		Task<bool> Registrar(TipoClienteDTO model);
		Task<bool> Modificar(int id, TipoClienteDTO model);
	}
}
