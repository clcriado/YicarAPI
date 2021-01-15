using System;
using System.Collections.Generic;

namespace Yicar.DAL.Models
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            Reparacion = new HashSet<Reparacion>();
            Ventas = new HashSet<Ventas>();
        }

        public int Id { get; set; }
        public int IdConcesionario { get; set; }
        public int IdTipo { get; set; }
        public string Matricula { get; set; }
        public decimal? Precio { get; set; }
        public bool? SegundaMano { get; set; }
        public string Combustible { get; set; }
        public int? KmRecorridos { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }

        public virtual Concesionarios IdConcesionarioNavigation { get; set; }
        public virtual Tipo IdTipoNavigation { get; set; }
        public virtual ICollection<Reparacion> Reparacion { get; set; }
        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
