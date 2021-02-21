using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using Yicar.Core.DTO;
using Yicar.IntegrationTests;

namespace Yicar.IntegrationTest
{
    public class VentaTest : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public VentaTest(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task TableVenta_SizeTable_ReturnsListaVenta()
        {
            // Arrange
            var request = new
            {
                Url = "/venta"
            };

            // Act
            var response = await Client.GetAsync(request.Url);
            var value = await response.Content.ReadAsStringAsync();
            var listaTabla = JsonConvert.DeserializeObject<List<VentaTablaDTO>>(value);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.True(listaTabla.Count == 17);
        }

        [Fact]
        public async Task TableVenta_ComprobarObjetoVenta_ReturnsTrue()
        {
            // Arrange
            var request = new
            {
                Url = "/venta/1"
            };

            var venta = new VentaTablaDTO
            {
                Id = 1,
                IdClienteNavigation = new ClienteNombreDTO
                {
                    Nombre = "Lucia",
                    Apellidos = "Lin"
                },
                IdVehiculoNavigation = new VehiculoNombreDTO
                {
                    Marca = "A1",
                    Modelo = "Audi",

                },
                IdVendedorNavigation = new VendedorNombreDTO
                {
                    NumVentas=10,
                    IdUsuarioNavigation = new UsuarioNombreDTO
                    {
                        Nombre = "Sara",
                        Apellidos = "López"
                    }
                },
                Estado = "pendiente",
                Inicio = DateTime.Parse("2021-01-10 00:00:00"),
                Fin = DateTime.Parse("2021-01-12 00:00:00"),
                FechaLimite = DateTime.Parse("2021-01-25"),
                Presupuesto = 14000.00M,
            };


            // Act
            var response = await Client.GetAsync(request.Url);
            var value = await response.Content.ReadAsStringAsync();
            var ventita = JsonConvert.DeserializeObject<VentaTablaDTO>(value);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.True(venta.Equals(ventita));
        }

    }

}
