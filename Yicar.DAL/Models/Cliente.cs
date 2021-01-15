using System;
using System.Collections.Generic;

namespace Yicar.DAL.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Reparacion = new HashSet<Reparacion>();
            Ventas = new HashSet<Ventas>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<Reparacion> Reparacion { get; set; }
        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
