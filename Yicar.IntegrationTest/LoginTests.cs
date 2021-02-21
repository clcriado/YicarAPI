using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Yicar.IntegrationTests;

namespace Yicar.IntegrationTest
{
    public class LoginTests : IClassFixture<TestFixture<Startup>>
    {
        
        private HttpClient Client;

        public LoginTests(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task LoginTests_LoginCorrect_ReturnsTrue()
        {
            // Arrange
            var request = new
            {
                Url = "/login",
                Body = new
                {
                    Login = "jefe",
                    Clave = "1234"
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.True(value == "true");
        }

        [Fact]
        public async Task LoginTests_LoginIncorrect_ReturnsFalse()
        {
            // Arrange
            var request = new
            {
                Url = "/login",
                Body = new
                {
                    Login = "jose",
                    Clave = "lolete"
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.True(value == "false");
        }

        [Fact]
        public async Task LoginTests_LoginIsNotJefe_ReturnsFalse()
        {
            // Arrange
            var request = new
            {
                Url = "/login",
                Body = new
                {
                    Login = "mecanico_jefe",
                    Clave = "1234"
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.True(value == "false");
        }
    }
}
