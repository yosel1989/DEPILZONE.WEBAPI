using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class ParametroSistemaDom : IParametroSistemaDom
    {
        private readonly IParametroSistemaDat _IParametroSistemaDat;
        public ParametroSistemaDom(IParametroSistemaDat IParametroSistemaDat)
        {
            this._IParametroSistemaDat = IParametroSistemaDat;
        }

        public async Task<Respuesta<ParametroSistemaEnt>> ObtenerById(int Id)
        {
            return await _IParametroSistemaDat.ObtenerById(Id);
        }
        public async Task<IEnumerable<ParametroSistemaEnt>> ObtenerConfgCorreo()
        {
            return await _IParametroSistemaDat.ObtenerParametrosEmail();
        }


    }
}
