using System;
using System.Collections.Generic;
using System.Text;

namespace Yicar.Core.DTO
{
    public class VentaTablaDTO
    {
        public int Id { get; set; }
        public string Estado { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public DateTime FechaLimite { get; set; }
        public decimal Presupuesto { get; set; }

        public ClienteNombreDTO IdClienteNavigation { get; set; }
        public VehiculoNombreDTO IdVehiculoNavigation { get; set; }
        public VendedorNombreDTO IdVendedorNavigation { get; set; }
    }
}
