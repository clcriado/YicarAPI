using System;
using System.Collections.Generic;

namespace Yicar.DAL.Models
{
    public partial class Motocicletas
    {
        public int IdMotocicletas { get; set; }
        public int? IdVehiculo { get; set; }

        public virtual Vehiculo IdVehiculoNavigation { get; set; }
    }
}
