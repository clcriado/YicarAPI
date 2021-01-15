using System;
using System.Collections.Generic;

namespace Yicar.DAL.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Jefe = new HashSet<Jefe>();
            Mecanico = new HashSet<Mecanico>();
            Vendedor = new HashSet<Vendedor>();
        }

        public int Id { get; set; }
        public int IdConcesionario { get; set; }
        public string Login { get; set; }
        public string Clave { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public decimal Salario { get; set; }
        public string Tipo { get; set; }

        public virtual Concesionarios IdConcesionarioNavigation { get; set; }
        public virtual ICollection<Jefe> Jefe { get; set; }
        public virtual ICollection<Mecanico> Mecanico { get; set; }
        public virtual ICollection<Vendedor> Vendedor { get; set; }
    }
}
