using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Jones.Extensions
{
    public static class HttpClientExtensions
    {
        public static Task<T?> GetFromJsonAsync<T>(
            this HttpClient client,
            string? requestUri,
            IEnumerable<object>? parameters,
            JsonSerializerOptions? options,
            CancellationToken cancellationToken = default) =>
            client.GetFromJsonAsync<T>(requestUri.CreateGetMethodUrl(parameters), options, cancellationToken);
        
        public static Task<T?> GetFromJsonAsync<T>(
            this HttpClient client,
            string? requestUri,
            object? parameter,
            JsonSerializerOptions? options,
            CancellationToken cancellationToken = default) =>
            client.GetFromJsonAsync<T>(requestUri.CreateGetMethodUrl(parameter), options, cancellationToken);
    }
}