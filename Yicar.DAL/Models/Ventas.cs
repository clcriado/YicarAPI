using System;
using System.Collections.Generic;

namespace Yicar.DAL.Models
{
    public partial class Ventas
    {
        public int Id { get; set; }
        public int IdVendedor { get; set; }
        public int IdCliente { get; set; }
        public int? IdVehiculo { get; set; }
        public string Estado { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime? Fin { get; set; }
        public DateTime FechaLimite { get; set; }
        public decimal? Presupuesto { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Vehiculo IdVehiculoNavigation { get; set; }
        public virtual Vendedor IdVendedorNavigation { get; set; }
    }
}
