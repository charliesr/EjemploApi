using System.Net.Http;
using System.Threading.Tasks;

namespace Cliente.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly HttpClient _cliente;

        public UsuarioService(HttpClient cliente)
        {
            this._cliente = ServiceConfiguration.InitClient(cliente);
        }
        public async Task<UsuarioServiceModel> GetAsync()
        {
            var message = await _cliente.GetAsync("/api/UsuarioAsync/GetAsync");
            message.EnsureSuccessStatusCode();
            using (var content = message.Content)
            {
                return await content.ReadAsAsync<UsuarioServiceModel>();
            }
        }

        public async Task<UsuarioServiceModel> SetAsync(UsuarioServiceModel usuarioServiceModel)
        {
            var message = await _cliente.PostAsJsonAsync("/api/UsuarioAsync/SetAsync", usuarioServiceModel);
            message.EnsureSuccessStatusCode();
            using (var content = message.Content)
            {
                return await content.ReadAsAsync<UsuarioServiceModel>();
            }
        }

    }
}
