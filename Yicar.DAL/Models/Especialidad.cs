using System;
using System.Collections.Generic;

namespace Yicar.DAL.Models
{
    public partial class Especialidad
    {
        public Especialidad()
        {
            EspecialidadesMecanico = new HashSet<EspecialidadesMecanico>();
        }

        public int IdEspecialidad { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<EspecialidadesMecanico> EspecialidadesMecanico { get; set; }
    }
}
