using System;
using System.Collections.Generic;

namespace Yicar.DAL.Models
{
    public partial class Vendedor
    {
        public int IdVenta { get; set; }
        public int IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
