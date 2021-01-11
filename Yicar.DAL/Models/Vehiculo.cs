using System;
using System.Collections.Generic;

namespace Yicar.DAL.Models
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            Ciclomotor = new HashSet<Ciclomotor>();
            Coches = new HashSet<Coches>();
            Motocicletas = new HashSet<Motocicletas>();
            Ventas = new HashSet<Ventas>();
        }

        public int IdVehiculo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int? NumeroPuertas { get; set; }
        public string Vendido { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime? FechaSalida { get; set; }
        public decimal Precio { get; set; }
        public int NumeroRuedas { get; set; }
        public string NumeroBastidor { get; set; }
        public string TipoVehiculo { get; set; }
        public short? Ano { get; set; }
        public int? Kilometros { get; set; }
        public string Combustible { get; set; }
        public int IdConcesionarios { get; set; }

        public virtual Concesionarios IdConcesionariosNavigation { get; set; }
        public virtual ICollection<Ciclomotor> Ciclomotor { get; set; }
        public virtual ICollection<Coches> Coches { get; set; }
        public virtual ICollection<Motocicletas> Motocicletas { get; set; }
        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
