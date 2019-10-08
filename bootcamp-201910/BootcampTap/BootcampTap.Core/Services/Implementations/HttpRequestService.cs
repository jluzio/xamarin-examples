using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BootcampTap.Core.Services.Abstractions;

namespace BootcampTap.Core.Services.Implementations
{
    public class HttpRequestService : IHttpRequestService
    {
        private static readonly string _basePath = "http://bcwebapi.azurewebsites.net/api/";

        private HttpClient _httpClient;

        private HttpClient HttpClient =>
            _httpClient ?? (_httpClient = new HttpClient() {BaseAddress = new Uri(_basePath)});

        public async Task PostAsync(string resource, object body = null, CancellationToken ct = default)
        {
            var contentPost = CreateSerializedHttpContent(body);

            await SendAsync(HttpMethod.Post, resource, contentPost, ct).ConfigureAwait(false);
        }

        public async Task<T> PostAsync<T>(string resource, object body = null, CancellationToken ct = default)
        {
            var contentPost = CreateSerializedHttpContent(body);

            var response = await SendAsync(HttpMethod.Post, resource, contentPost, ct).ConfigureAwait(false);

            var result = await DeserializeAsync<T>(response).ConfigureAwait(false);

            return result;
        }

        public async Task<T> GetAsync<T>(string resource, CancellationToken ct = default)
        {
            var response = await SendAsync(HttpMethod.Get, resource, null, ct).ConfigureAwait(false);

            try
            {
                var obj = await DeserializeAsync<T>(response);
                return obj;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error while deserializing GET request: {resource}");
                throw;
            }
        }

        public async Task PutAsync(string resource, object body, CancellationToken ct = default)
        {
            var contentPost = CreateSerializedHttpContent(body);

            await SendAsync(HttpMethod.Put, resource, contentPost, ct).ConfigureAwait(false);
        }

        public async Task<T> PutAsync<T>(string resource, object body, CancellationToken ct = default)
        {
            var contentPost = CreateSerializedHttpContent(body);

            var response = await SendAsync(HttpMethod.Put, resource, contentPost, ct).ConfigureAwait(false);

            var result = await DeserializeAsync<T>(response);

            return result;
        }

        private async Task<HttpResponseMessage> SendAsync(HttpMethod httpMethod, string resource,
            HttpContent content = null, CancellationToken ct = default)
        {
            var requestMessage = new HttpRequestMessage(httpMethod, resource)
            {
                Content = content
            };

            var response = await HttpClient.SendAsync(requestMessage, ct);

            response.EnsureSuccessStatusCode();

            return response;
        }

        private static HttpContent CreateSerializedHttpContent(object body)
        {
            if (body == null) return null;

            var serializedObject = JsonConvert.SerializeObject(body);
            var content = new StringContent(serializedObject, Encoding.UTF8, "application/json");

            return content;
        }

        private static async Task<T> DeserializeAsync<T>(HttpResponseMessage httpResponseMessage)
        {
            if (!httpResponseMessage.IsSuccessStatusCode)
                return default;

            var json = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

            var deserializedData = JsonConvert.DeserializeObject<T>(json);

            return deserializedData;
        }
    }
}