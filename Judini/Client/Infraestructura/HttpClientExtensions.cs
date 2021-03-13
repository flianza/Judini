using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Judini.Client.Infraestructura
{
    public static class HttpClientExtensions
    {
        public static async Task<T> GetAsync<T>(this HttpClient httpClient, string requestUri, CancellationToken cancellationToken)
        {
            return await GetAsync<T>(httpClient, requestUri, headers: null, cancellationToken);
        }

        public static async Task<T> GetAsync<T>(this HttpClient httpClient, string requestUri, IEnumerable<(string name, string value)> headers, CancellationToken cancellationToken)
        {
            headers ??= Enumerable.Empty<(string name, string value)>();

            HttpResponseMessage response;

            using (var request = new HttpRequestMessage(HttpMethod.Get, requestUri))
            {
                foreach ((string name, string value) in headers)
                {
                    request.Headers.Add(name, value);
                }

                response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
            }

            using (response)
            {
                return await response.Content.ReadAsAsync<T>();
            }
        }

        public static async Task PutAsync<T>(this HttpClient httpClient, string requestUri, T value, CancellationToken cancellationToken)
        {
            await SendAsync(httpClient, HttpMethod.Put, requestUri, value, cancellationToken);
        }

        public static async Task PatchAsync<T>(this HttpClient httpClient, string requestUri, T value, CancellationToken cancellationToken)
        {
            await SendAsync(httpClient, new HttpMethod("PATCH"), requestUri, value, cancellationToken);
        }

        public static async Task DeleteAsync<T>(this HttpClient httpClient, string requestUri, T value, CancellationToken cancellationToken)
        {
            await SendAsync(httpClient, HttpMethod.Delete, requestUri, value, cancellationToken);
        }

        public static async Task PostAsync<T>(this HttpClient httpClient, string requestUri, T value, CancellationToken cancellationToken)
        {
            await SendAsync(httpClient, HttpMethod.Post, requestUri, value, cancellationToken);
        }

        public static async Task<TResponse> PostAsync<TRequest, TResponse>(this HttpClient httpClient, string requestUri, TRequest value, CancellationToken cancellationToken)
        {
            HttpResponseMessage response;

            response = await SendAsync(httpClient, HttpMethod.Post, requestUri, value, cancellationToken);

            using (response)
            {
                return await response.Content.ReadAsAsync<TResponse>();
            }
        }

        private static async Task<HttpResponseMessage> SendAsync(HttpClient httpClient, HttpMethod httpMethod, string requestUri, object value, CancellationToken cancellationToken)
        {
            HttpContent content;

            using var stream = new MemoryStream();
            using (var jsonWriter = new Utf8JsonWriter(stream))
            {
                JsonSerializer.Serialize(jsonWriter, value);
                jsonWriter.Flush();
            }

            stream.Seek(0, SeekOrigin.Begin);
            content = new StreamContent(stream);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using var request = new HttpRequestMessage(httpMethod, requestUri);
            request.Content = content;
            return await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
        }
    }
}
