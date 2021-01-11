using System;
using System.Collections.Generic;

namespace Yicar.DAL.Models
{
    public partial class Coches
    {
        public int IdCoches { get; set; }
        public int? IdVehiculo { get; set; }

        public virtual Vehiculo IdVehiculoNavigation { get; set; }
    }
}
