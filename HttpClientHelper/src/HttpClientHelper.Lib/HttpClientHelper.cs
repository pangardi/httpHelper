using HttpClientHelper.Lib;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HttpClientHelper
{
    public class HttpClientHelper : IHttpClientHelper, IDisposable
    {
        private HttpClient _client { get; set; }
        public HttpClientHelper(string urlBase)
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(urlBase)
            };
        }

        public async Task<OperationResult<T>> Get<T>(string path)
        {
            var response = await _client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadFromJsonAsync<T>();
                return new OperationResult<T>() { Response = content };
            }
            throw new Exception("Ocorreu um erro na requisição " + response.StatusCode);
        }

        public async Task<OperationResult<T>> Get<T>(string path, string authenticationType, string key)
        {
            _client.DefaultRequestHeaders.Add(authenticationType, key);
            var response = await _client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadFromJsonAsync<T>();
                return new OperationResult<T>() { Response = content };
            }
            throw new Exception("Ocorreu um erro na requisição " + response.StatusCode);
        }

        public async Task<OperationResult<T>> Post<T>(string path, T body)
        {
            var response = await _client.PostAsJsonAsync(path, body);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadFromJsonAsync<T>();
                return new OperationResult<T>() { Response = content };
            }
            throw new Exception("Ocorreu um erro na requisição " + response.StatusCode);
        }
     
        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}
