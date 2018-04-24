using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Service
{
    public interface IUsuarioService
    {
        Task<UsuarioServiceModel> GetAsync();
        Task<UsuarioServiceModel> SetAsync(UsuarioServiceModel usuarioServiceModel);
    }
}
