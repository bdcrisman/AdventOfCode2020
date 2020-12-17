using System.Net.Http;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    public class InputGetter
    {
        public HttpClient _client;

        public async Task<string> GetAsync(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return null;

            using (_client = new HttpClient())
            {
                var resp = await _client.GetAsync(url);
                if (!resp.IsSuccessStatusCode)
                    return null;

                return await resp.Content.ReadAsStringAsync();
            }
        }
    }
}
