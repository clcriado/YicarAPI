using System;
using System.Collections.Generic;

namespace Yicar.DAL.Models
{
    public partial class Reparaciones
    {
        public int IdReparacion { get; set; }
        public int? IdVehiculo { get; set; }
        public string Componente { get; set; }
        public string Estado { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Presupuesto { get; set; }
        public int IdCliente { get; set; }
        public int IdMecánicos { get; set; }
    }
}
