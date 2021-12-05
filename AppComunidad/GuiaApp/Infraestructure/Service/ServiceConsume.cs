using GuiaApp;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AppComunidad.Aplicativos.GuiaApp.Infraestructure.Service
{
    public class ServiceConsume : IServiceConsume
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEnumerable<string> _Scopes;

        private readonly string _serviceURLGuia;
        private readonly string _serviceURLManagement;
        private readonly JsonSerializerSettings _serializerSettings;

        public ServiceConsume(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IOptions<AppSettings> settings)
        {
            _httpClientFactory = httpClientFactory;

            _httpContextAccessor = httpContextAccessor;
            
            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore
            };            
            _serviceURLGuia = Environment.GetEnvironmentVariable("GUIA_SERVICE");
            _serviceURLManagement = Environment.GetEnvironmentVariable("MANAGEMENT_SERVICE");
        }
        public async Task<ReponseResult<TResult>> GetAsync<TResult>(string route, int servicio, string accessToken = null)
        {

            var client = _httpClientFactory.CreateClient();

            var response = new HttpResponseMessage();

            switch (servicio)
            {
                case 1:
                    response = await client.GetAsync($"{_serviceURLGuia}{route}");
                    break;
                case 2:
                    response = await client.GetAsync($"{_serviceURLManagement}{route}");
                    break;
            }            

            var result = await HandleResponse<TResult>(response);

            return result;
        }

        public async Task<ReponseResult<Stream>> GetFileAsync(string route, int servicio)
        {
           var client = _httpClientFactory.CreateClient();

            client.Timeout = new TimeSpan(0, 10, 0);

            var response = new HttpResponseMessage();

            switch (servicio)
            {
                case 1:
                    response = await client.GetAsync($"{_serviceURLGuia}{route}");
                    break;
                case 2:
                    response = await client.GetAsync($"{_serviceURLManagement}{route}");
                    break;
            }

            var result = await HandleResponse<Stream>(response);

            return result;
        }

        public async Task<ReponseResult<Stream>> GetFileWithHiddenAsync(string route,int[] listhidden, int servicio)
        {

            var content = new StringContent(JsonConvert.SerializeObject(listhidden));

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = new HttpResponseMessage();

            switch (servicio)
            {
                case 1:
                    response = await client.PostAsync($"{_serviceURLGuia}{route}", content);
                    break;
                case 2:
                    response = await client.PostAsync($"{_serviceURLManagement}{route}", content);
                    break;
            }

            var result = await HandleResponse<Stream>(response);

            return result;
        }

        public async Task<ReponseResult<int>> PostAsync<TInput>(string route, TInput data, int servicio)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data));

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = new HttpResponseMessage();

            switch (servicio)
            {
                case 1:
                    response = await client.PostAsync($"{_serviceURLGuia}{route}", content);
                    break;
                case 2:
                    response = await client.PostAsync($"{_serviceURLManagement}{route}", content);
                    break;
            }

            var result = await HandleResponse<int>(response);

            return result;
        }

        public async Task<ReponseResult<bool>> PutAsync<TInput>(string route, TInput data, int servicio)
        {

            var content = new StringContent(JsonConvert.SerializeObject(data));

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = new HttpResponseMessage();

            switch (servicio)
            {
                case 1:
                    response = await client.PutAsync($"{_serviceURLGuia}{route}", content);
                    break;
                case 2:
                    response = await client.PutAsync($"{_serviceURLManagement}{route}", content);
                    break;
            }

            var result = await HandleResponse<bool>(response);

            return result;
        }

        public async Task<ReponseResult<bool>> DeleteAsync(string route, int servicio)
        {

            var client = _httpClientFactory.CreateClient();

            var response = new HttpResponseMessage();

            switch (servicio)
            {
                case 1:
                    response = await client.DeleteAsync($"{_serviceURLGuia}{route}");
                    break;
                case 2:
                    response = await client.DeleteAsync($"{_serviceURLManagement}{route}");
                    break;
            }

            var result = await HandleResponse<bool>(response);

            return result;
        }

        public async Task<ReponseResult<bool>> PostFileAsync(string route, object value, int servicio)
        {

            IFormFile file = value as IFormFile;

            byte[] data;
            using (var br = new BinaryReader(file.OpenReadStream()))
                data = br.ReadBytes((int)file.OpenReadStream().Length);

            ByteArrayContent bytes = new ByteArrayContent(data);


            MultipartFormDataContent multiContent = new MultipartFormDataContent();

            multiContent.Add(bytes, "file", file.FileName);


            var client = _httpClientFactory.CreateClient();

            var response = new HttpResponseMessage();

            switch (servicio)
            {
                case 1:
                    response = await client.PostAsync($"{_serviceURLGuia}{route}", multiContent);
                    break;
                case 2:
                    response = await client.PostAsync($"{_serviceURLManagement}{route}", multiContent);
                    break;
            }

            var result = await HandleResponse<bool>(response);

            return result;
        }

        private async Task<ReponseResult<TResult>> HandleResponse<TResult>(HttpResponseMessage response)
        {
            object serialized;
            var result = new ReponseResult<TResult>
            {
                Success = true,
                StatusCode = (int)HttpStatusCode.OK
            };

            if (!response.IsSuccessStatusCode)
            {
                serialized = await response.Content.ReadAsStringAsync();
                result.Success = false;
                result.StatusCode = (int)response.StatusCode;
                result.Messages = JsonConvert.DeserializeObject<ErrorMessages>((string)serialized, _serializerSettings).Messages;
            }
            else
            {
                if (typeof(TResult) == typeof(Stream))
                {
                    serialized = await response.Content.ReadAsStreamAsync();
                    result.File = (Stream)serialized;
                }
                else
                {
                    serialized = await response.Content.ReadAsStringAsync();
                    result.Result = JsonConvert.DeserializeObject<TResult>((string)serialized, _serializerSettings);
                }
            }

            return result;
        }


        public class ReponseResult<TResult>
        {
            public bool Success { get; set; }
            public string[] Messages { get; set; }
            public int StatusCode { get; set; }
            public TResult Result { get; set; }
            public Stream File { get; set; }
        }

        public class ErrorMessages
        {
            public string[] Messages { get; set; }
        }

    }
}
