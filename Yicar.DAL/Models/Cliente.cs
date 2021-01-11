using System;
using System.Collections.Generic;

namespace Yicar.DAL.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Ventas = new HashSet<Ventas>();
        }

        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public DateTime FechaNac { get; set; }
        public string Direccion { get; set; }
        public string Sexo { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string TipoComunicacion { get; set; }

        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
