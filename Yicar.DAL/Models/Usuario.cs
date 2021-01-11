using System;
using System.Collections.Generic;

namespace Yicar.DAL.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Jefe = new HashSet<Jefe>();
            Mecanicos = new HashSet<Mecanicos>();
            Vendedor = new HashSet<Vendedor>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Dni { get; set; }
        public decimal Salario { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Jefe> Jefe { get; set; }
        public virtual ICollection<Mecanicos> Mecanicos { get; set; }
        public virtual ICollection<Vendedor> Vendedor { get; set; }
    }
}
