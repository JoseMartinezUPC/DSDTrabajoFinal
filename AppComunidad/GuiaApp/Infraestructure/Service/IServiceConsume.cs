using System.IO;
using System.Threading.Tasks;
using static AppComunidad.Aplicativos.GuiaApp.Infraestructure.Service.ServiceConsume;

namespace AppComunidad.Aplicativos.GuiaApp.Infraestructure.Service
{
    public interface IServiceConsume
    {
        Task<ReponseResult<TResult>> GetAsync<TResult>(string route, string accessToken = null);
        Task<ReponseResult<Stream>> GetFileAsync(string route);
        Task<ReponseResult<Stream>> GetFileWithHiddenAsync(string route, int[] listhidden);
        Task<ReponseResult<int>> PostAsync<TInput>(string route, TInput data);
        Task<ReponseResult<bool>> PutAsync<TInput>(string route, TInput data);
        Task<ReponseResult<bool>> DeleteAsync(string route);
        Task<ReponseResult<bool>> PostFileAsync(string route, object file);
    }
}
