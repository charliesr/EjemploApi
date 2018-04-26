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
        public Task<Usuario> GetAsync()
        {
            try
            {
                return _getAsync.GetAsync("Pepe");

            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message, ex);
            }
        }

        public Task<Usuario> SetAsync(Usuario usuario)
        {
            try
            {
                return _setAsync.AddAsync(usuario, "Pepe");
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message, ex);
            }

        }
    }
}
