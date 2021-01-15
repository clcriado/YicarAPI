using System;
using System.Collections.Generic;

namespace Yicar.DAL.Models
{
    public partial class Especialidad
    {
        public int Id { get; set; }
        public int Idmecanico { get; set; }
        public int Idtipo { get; set; }

        public virtual Mecanico IdmecanicoNavigation { get; set; }
        public virtual Tipo IdtipoNavigation { get; set; }
    }
}
