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
using System.Threading.Tasks;

namespace GuiaApp.Infraestructure.Service
{
    public class GuiaServiceConsume : IGuiaServiceConsume
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly string _serviceURL;
        private readonly JsonSerializerSettings _serializerSettings;

        public GuiaServiceConsume(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IOptions<AppSettings> settings)
        {
            _httpClientFactory = httpClientFactory;

            _httpContextAccessor = httpContextAccessor;


            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore
            };
            _serviceURL = Environment.GetEnvironmentVariable("GUIA_SERVICE");
        }
        public async Task<ReponseResult<TResult>> GetAsync<TResult>(string route, string accessToken = null)
        {

            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync($"{_serviceURL}{route}");

            var result = await HandleResponse<TResult>(response);

            return result;
        }

        public async Task<ReponseResult<Stream>> GetFileAsync(string route)
        {

            var client = _httpClientFactory.CreateClient();

            client.Timeout = new TimeSpan(0, 10, 0);

            var response = await client.GetAsync($"{_serviceURL}{route}");

            var result = await HandleResponse<Stream>(response);

            return result;
        }

        public async Task<ReponseResult<Stream>> GetFileWithHiddenAsync(string route, int[] listhidden)
        {

            var content = new StringContent(JsonConvert.SerializeObject(listhidden));

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.PostAsync($"{_serviceURL}{route}", content);

            var result = await HandleResponse<Stream>(response);

            return result;
        }

        public async Task<ReponseResult<int>> PostAsync<TInput>(string route, TInput data)
        {

            var content = new StringContent(JsonConvert.SerializeObject(data));

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.PostAsync($"{_serviceURL}{route}", content);

            var result = await HandleResponse<int>(response);

            return result;
        }

        public async Task<ReponseResult<bool>> PutAsync<TInput>(string route, TInput data)
        {

            var content = new StringContent(JsonConvert.SerializeObject(data));

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var client = _httpClientFactory.CreateClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.PutAsync($"{_serviceURL}{route}", content);

            var result = await HandleResponse<bool>(response);

            return result;
        }

        public async Task<ReponseResult<bool>> DeleteAsync(string route)
        {

            var client = _httpClientFactory.CreateClient();

            var response = await client.DeleteAsync($"{_serviceURL}{route}");

            var result = await HandleResponse<bool>(response);

            return result;
        }

        public async Task<ReponseResult<bool>> PostFileAsync(string route, object value)
        {

            IFormFile file = value as IFormFile;

            byte[] data;
            using (var br = new BinaryReader(file.OpenReadStream()))
                data = br.ReadBytes((int)file.OpenReadStream().Length);

            ByteArrayContent bytes = new ByteArrayContent(data);


            MultipartFormDataContent multiContent = new MultipartFormDataContent();

            multiContent.Add(bytes, "file", file.FileName);


            var client = _httpClientFactory.CreateClient();

            var response = await client.PostAsync($"{_serviceURL}{route}", multiContent);

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
