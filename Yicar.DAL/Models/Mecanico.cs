using System;
using System.Collections.Generic;

namespace Yicar.DAL.Models
{
    public partial class Mecanico
    {
        public Mecanico()
        {
            Especialidad = new HashSet<Especialidad>();
            Reparacion = new HashSet<Reparacion>();
        }

        public int Id { get; set; }
        public int Idusuario { get; set; }
        public sbyte EsJefe { get; set; }
        public int? NumReparaciones { get; set; }

        public virtual Usuario IdusuarioNavigation { get; set; }
        public virtual ICollection<Especialidad> Especialidad { get; set; }
        public virtual ICollection<Reparacion> Reparacion { get; set; }
    }
}
