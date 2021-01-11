using System;
using System.Collections.Generic;

namespace Yicar.DAL.Models
{
    public partial class Concesionarios
    {
        public Concesionarios()
        {
            Vehiculo = new HashSet<Vehiculo>();
        }

        public int IdConcesionarios { get; set; }
        public int? CantidadVehiculo { get; set; }
        public int? NumeroVentas { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string Pais { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
    }
}
