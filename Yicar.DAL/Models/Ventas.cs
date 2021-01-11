using System;
using System.Collections.Generic;

namespace Yicar.DAL.Models
{
    public partial class Ventas
    {
        public int IdVentas { get; set; }
        public string NombreCliente { get; set; }
        public string PrimerApellido { get; set; }
        public string Dni { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Propuesta { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaLimiteAceptación { get; set; }
        public int IdVehiculo { get; set; }
        public int IdCliente { get; set; }
        public int IdVendedor { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Vehiculo IdVehiculoNavigation { get; set; }
    }
}
