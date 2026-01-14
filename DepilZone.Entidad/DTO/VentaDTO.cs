using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class VentaDTO
    {
        public int Id { get; set; }
        public int IdSede { get; set; }
        public string Sede { get; set; }
        public decimal TotalVenta { get; set; }

        public DateTime Fecha { get; set; }
    }
}
