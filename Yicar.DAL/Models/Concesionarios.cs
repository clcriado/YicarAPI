using System;
using System.Collections.Generic;

namespace Yicar.DAL.Models
{
    public partial class Concesionarios
    {
        public Concesionarios()
        {
            Usuario = new HashSet<Usuario>();
            Vehiculo = new HashSet<Vehiculo>();
        }

        public int Id { get; set; }
        public string Ciudad { get; set; }
        public string Provincia { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
    }
}
