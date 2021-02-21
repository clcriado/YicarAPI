using System;
using System.Collections.Generic;
using System.Text;

namespace Yicar.Core.DTO
{
    public class VentaTablaDTO
    {
        public int Id { get; set; }
        public string Estado { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public DateTime FechaLimite { get; set; }
        public decimal Presupuesto { get; set; }

        public ClienteNombreDTO IdClienteNavigation { get; set; }
        public VehiculoNombreDTO IdVehiculoNavigation { get; set; }
        public VendedorNombreDTO IdVendedorNavigation { get; set; }

        public override bool Equals(object obj)
        {
            return obj is VentaTablaDTO dTO &&
                   Id == dTO.Id &&
                   Estado == dTO.Estado &&
                   Inicio == dTO.Inicio &&
                   Fin == dTO.Fin &&
                   FechaLimite == dTO.FechaLimite &&
                   Presupuesto == dTO.Presupuesto &&
                   EqualityComparer<ClienteNombreDTO>.Default.Equals(IdClienteNavigation, dTO.IdClienteNavigation) &&
                   EqualityComparer<VehiculoNombreDTO>.Default.Equals(IdVehiculoNavigation, dTO.IdVehiculoNavigation) &&
                   EqualityComparer<VendedorNombreDTO>.Default.Equals(IdVendedorNavigation, dTO.IdVendedorNavigation);
        }

        public static bool operator ==(VentaTablaDTO left, VentaTablaDTO right)
        {
            return EqualityComparer<VentaTablaDTO>.Default.Equals(left, right);
        }

        public static bool operator !=(VentaTablaDTO left, VentaTablaDTO right)
        {
            return !(left == right);
        }
    }
}
