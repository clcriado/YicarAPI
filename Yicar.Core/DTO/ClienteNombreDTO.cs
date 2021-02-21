using System;
using System.Collections.Generic;
using System.Text;

namespace Yicar.Core.DTO
{
    public class ClienteNombreDTO
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ClienteNombreDTO dTO &&
                   Nombre == dTO.Nombre &&
                   Apellidos == dTO.Apellidos;
        }

        public static bool operator ==(ClienteNombreDTO left, ClienteNombreDTO right)
        {
            return EqualityComparer<ClienteNombreDTO>.Default.Equals(left, right);
        }

        public static bool operator !=(ClienteNombreDTO left, ClienteNombreDTO right)
        {
            return !(left == right);
        }
    }
}
