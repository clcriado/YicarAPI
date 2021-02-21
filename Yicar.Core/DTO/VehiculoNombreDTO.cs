using System;
using System.Collections.Generic;
using System.Text;

namespace Yicar.Core.DTO
{
    public class VehiculoNombreDTO
    {
        public string Modelo { get; set; }
        public string Marca { get; set; }

        public override bool Equals(object obj)
        {
            return obj is VehiculoNombreDTO dTO &&
                   Modelo == dTO.Modelo &&
                   Marca == dTO.Marca;
        }

        public static bool operator ==(VehiculoNombreDTO left, VehiculoNombreDTO right)
        {
            return EqualityComparer<VehiculoNombreDTO>.Default.Equals(left, right);
        }

        public static bool operator !=(VehiculoNombreDTO left, VehiculoNombreDTO right)
        {
            return !(left == right);
        }
    }
}
