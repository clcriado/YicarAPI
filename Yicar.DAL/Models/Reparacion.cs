using System;
using System.Collections.Generic;

namespace Yicar.DAL.Models
{
    public partial class Reparacion
    {
        public int Id { get; set; }
        public int Idvehiculo { get; set; }
        public int Idcliente { get; set; }
        public int Idmecanico { get; set; }
        public decimal? Presupuesto { get; set; }
        public DateTime? Inicio { get; set; }
        public DateTime? Fin { get; set; }
        public string Componentes { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }

        public virtual Cliente IdclienteNavigation { get; set; }
        public virtual Mecanico IdmecanicoNavigation { get; set; }
        public virtual Vehiculo IdvehiculoNavigation { get; set; }
    }
}
