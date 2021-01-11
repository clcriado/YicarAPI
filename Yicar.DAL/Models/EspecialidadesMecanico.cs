using System;
using System.Collections.Generic;

namespace Yicar.DAL.Models
{
    public partial class EspecialidadesMecanico
    {
        public int IdEspecialidad { get; set; }
        public int IdMecánicos { get; set; }

        public virtual Especialidad IdEspecialidadNavigation { get; set; }
        public virtual Mecanicos IdMecánicosNavigation { get; set; }
    }
}
