using System;
using System.Collections.Generic;

namespace Yicar.DAL.Models
{
    public partial class Ciclomotor
    {
        public int IdCiclomotor { get; set; }
        public int? IdVehiculo { get; set; }

        public virtual Vehiculo IdVehiculoNavigation { get; set; }
    }
}
