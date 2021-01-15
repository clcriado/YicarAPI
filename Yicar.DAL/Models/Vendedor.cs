using System;
using System.Collections.Generic;

namespace Yicar.DAL.Models
{
    public partial class Vendedor
    {
        public Vendedor()
        {
            Ventas = new HashSet<Ventas>();
        }

        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int? NumVentas { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
