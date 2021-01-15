using System;
using System.Collections.Generic;
using System.Text;

namespace Yicar.Core.DTO
{
    public class VendedorNombreDTO
    {
        public UsuarioNombreDTO IdUsuarioNavigation { get; set; }
        public int NumVentas { get; set; }
    }
}
