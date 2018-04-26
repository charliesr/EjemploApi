using System;
using System.Net.Http;
using System.Threading.Tasks;
using EjemploApi.Common.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace EjemploApi.Business.Facade.IntegrationTest
{
    [TestClass]
    public class FacadeIntegrationTests
    {
        private HttpClient client;

        [TestInitialize]
        public void Init()
        {
            this.client = new HttpClient();
            this.client.BaseAddress = new Uri("http://localhost:9413/");
        }


        [DataTestMethod]
        [DataRow(1,"Carlos","Sanchez Romero")]
        [DataRow(2,"Elisabet","Bayot Bertran")]
        [DataRow(3,"Noa","Sanchez Bayot")]
        public async Task SetAsync_Test(int id, string nombre, string apellidos)
        {

            var usuario = new Usuario
            {
                Id = id,
                Nombre = nombre,
                Apellidos = apellidos,
            };

            var response = await client.PostAsJsonAsync("/api/UsuarioAsync/SetAsync",usuario);

            response.EnsureSuccessStatusCode();

            //Assert.ThrowsException<HttpRequestException>(() => response.EnsureSuccessStatusCode());
            var usuarioResponse = response.Content.ReadAsAsync<Usuario>().Result;
            Assert.AreEqual(usuarioResponse, usuario);
            
        }
    }
}
