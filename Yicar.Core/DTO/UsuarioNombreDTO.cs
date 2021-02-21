using System;
using System.Collections.Generic;
using System.Text;

namespace Yicar.Core.DTO
{
    public class UsuarioNombreDTO
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        public override bool Equals(object obj)
        {
            UsuarioNombreDTO casteo = (UsuarioNombreDTO) obj;
            return Nombre == casteo.Nombre && Apellidos == casteo.Apellidos;
        }
    }
}
