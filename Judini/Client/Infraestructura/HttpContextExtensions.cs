using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Judini.Client.Infraestructura
{
    public static class HttpContentExtensions
    {
        public static async Task<T> ReadAsAsync<T>(this HttpContent httpContent)
        {
            using var stream = await httpContent.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<T>(stream);
        }
    }
}
