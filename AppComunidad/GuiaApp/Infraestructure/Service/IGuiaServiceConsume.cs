using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static GuiaApp.Infraestructure.Service.GuiaServiceConsume;

namespace GuiaApp.Infraestructure.Service
{
    public interface IGuiaServiceConsume
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
