using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.DTO.C360;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface.C360
{
	public interface ITipoClienteDom
	{
        Task<List<TipoClienteDTO>> Listar();
        Task<List<TipoClienteDTO>> ListarByEstado(int idEstado);
        Task<bool> Registrar(TipoClienteDTO model);
        Task<bool> Modificar(int id, TipoClienteDTO model);
    }
}
