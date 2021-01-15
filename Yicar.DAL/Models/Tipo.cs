using System;
using System.Collections.Generic;

namespace Yicar.DAL.Models
{
    public partial class Tipo
    {
        public Tipo()
        {
            Especialidad = new HashSet<Especialidad>();
            Vehiculo = new HashSet<Vehiculo>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Especialidad> Especialidad { get; set; }
        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
    }
}
