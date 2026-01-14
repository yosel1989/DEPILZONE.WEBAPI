using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class ParametroSistemaApp: IParametroSistemaApp
    {
        private readonly IParametroSistemaDom _IParametroSistemaDom;
        public ParametroSistemaApp(IParametroSistemaDom IParametroSistemaDom)
        {
            this._IParametroSistemaDom = IParametroSistemaDom;
        }

        public async Task<Respuesta<ParametroSistemaEnt>> ObtenerById(int Id)
        {
            return await _IParametroSistemaDom.ObtenerById(Id);
        }
    }
}
