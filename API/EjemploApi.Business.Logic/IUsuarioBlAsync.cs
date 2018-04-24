using EjemploApi.Common.Logic;
using System.Threading.Tasks;

namespace EjemploApi.Business.Logic
{
    public interface IUsuarioBlAsync
    {
        Task<Usuario> GetAsync();
        Task<Usuario> SetAsync(Usuario usuario);
    }
}