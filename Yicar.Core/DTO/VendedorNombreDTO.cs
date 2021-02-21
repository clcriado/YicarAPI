using System;
using System.Collections.Generic;
using System.Text;

namespace Yicar.Core.DTO
{
    public class VendedorNombreDTO
    {
        public UsuarioNombreDTO IdUsuarioNavigation { get; set; }
        public int NumVentas { get; set; }

        public override bool Equals(object obj)
        {
            return obj is VendedorNombreDTO dTO &&
                   EqualityComparer<UsuarioNombreDTO>.Default.Equals(IdUsuarioNavigation, dTO.IdUsuarioNavigation) &&
                   NumVentas == dTO.NumVentas;
        }

        public static bool operator ==(VendedorNombreDTO left, VendedorNombreDTO right)
        {
            return EqualityComparer<VendedorNombreDTO>.Default.Equals(left, right);
        }

        public static bool operator !=(VendedorNombreDTO left, VendedorNombreDTO right)
        {
            return !(left == right);
        }
    }
}
