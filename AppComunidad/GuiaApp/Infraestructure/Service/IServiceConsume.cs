using System.IO;
using System.Threading.Tasks;
using static AppComunidad.Aplicativos.GuiaApp.Infraestructure.Service.ServiceConsume;

namespace AppComunidad.Aplicativos.GuiaApp.Infraestructure.Service
{
    public interface IServiceConsume
    {
        Task<ReponseResult<TResult>> GetAsync<TResult>(string route, int servicio, string accessToken = null);
        Task<ReponseResult<Stream>> GetFileAsync(string route, int servicio);
        Task<ReponseResult<Stream>> GetFileWithHiddenAsync(string route, int[] listhidden, int servicio);
        Task<ReponseResult<int>> PostAsync<TInput>(string route, TInput data, int servicio);
        Task<ReponseResult<bool>> PutAsync<TInput>(string route, TInput data, int servicio);
        Task<ReponseResult<bool>> DeleteAsync(string route, int servicio);
        Task<ReponseResult<bool>> PostFileAsync(string route, object file, int servicio);
    }
}
