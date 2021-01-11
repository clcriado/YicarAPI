using System;
using System.Collections.Generic;

namespace Yicar.DAL.Models
{
    public partial class Mecanicos
    {
        public Mecanicos()
        {
            EspecialidadesMecanico = new HashSet<EspecialidadesMecanico>();
            InverseIdJefeNavigation = new HashSet<Mecanicos>();
        }

        public int IdMecánicos { get; set; }
        public int? IdJefe { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Mecanicos IdJefeNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<EspecialidadesMecanico> EspecialidadesMecanico { get; set; }
        public virtual ICollection<Mecanicos> InverseIdJefeNavigation { get; set; }
    }
}
