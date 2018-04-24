using EjemploApi.Business.Logic;
using EjemploApi.Common.Logic;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace EjemploApi.Business.Facade.WebApi.Controllers
{
    public class UsuarioAsyncController : ApiController
    {
        private readonly IUsuarioBlAsync _usuarioBlAsync;

        public UsuarioAsyncController(IUsuarioBlAsync usuarioBlAsync)
        {
            this._usuarioBlAsync = usuarioBlAsync;
        }

        [HttpGet()]
        public async Task<IHttpActionResult> GetAsync()
        {
            return Ok(await this._usuarioBlAsync.GetAsync());
        }

        [HttpPost()]
        public async Task<IHttpActionResult> SetAsync(Usuario usuario)
        {
            return Ok(await this._usuarioBlAsync.SetAsync(usuario));
        }
    }
}
