using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjemploApi.DataAccess.Redis;
using EjemploApi.Common.Logic;

namespace EjemploApi.Business.Logic
{
    public class UsuarioBlAsync : IUsuarioBlAsync
    {
        private readonly IGetAsync<Usuario> _getAsync;
        private readonly ISetAsync<Usuario> _setAsync;

        public UsuarioBlAsync(IGetAsync<Usuario> getAsync, ISetAsync<Usuario> setAsync)
        {
            this._getAsync = getAsync;
            this._setAsync = setAsync;
        }
        public Task<Usuario> GetAsync(string key)
        {
            return _getAsync.GetAsync(key);
        }

        public Task<Usuario> SetAsync(Usuario usuario, string key)
        {
            return _setAsync.AddAsync(usuario,key);

        }
    }
}
