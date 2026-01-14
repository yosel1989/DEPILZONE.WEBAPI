using System;
using System.Collections.Generic;
using System.Text;

namespace DepilZone.Entidad.DTO
{
    public class CajaCuadreDTO
    {
        public decimal SaldoInicial { get; set; }
        public decimal Ingreso { get; set; }
        public decimal Egreso { get; set; }
        public decimal Total { get; set; }
    }
}
