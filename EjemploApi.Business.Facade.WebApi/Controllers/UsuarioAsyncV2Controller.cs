using EjemploApi.Business.Logic;
using EjemploApi.Common.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace EjemploApi.Business.Facade.WebApi.Controllers
{
    public class UsuarioAsyncV2Controller : ApiController
    {
        private readonly IUsuarioBlAsync _usuarioBlAsync;

        public UsuarioAsyncV2Controller(IUsuarioBlAsync usuarioBlAsync)
        {
            this._usuarioBlAsync = usuarioBlAsync;
        }

        [HttpGet()]
        public async Task<IHttpActionResult> GetAsync()
        {
            return Ok(await this._usuarioBlAsync.GetAsync("Pepe"));
        }

        [HttpPost()]
        public async Task<IHttpActionResult> SetAsync(Usuario usuario)
        {
            return Ok(await this._usuarioBlAsync.SetAsync(usuario, "Pepe"));
        }
    }
}