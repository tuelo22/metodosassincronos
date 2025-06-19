using metodosassincronos.domain.DTO;
using Newtonsoft.Json;

namespace metodosassincronos.domain.Servicos
{
    public class JsonplaceholderService(IHttpClientFactory _HttpClientFactory)
    {
        private const string URL = "https://jsonplaceholder.typicode.com/";

        public async Task<UserDto?> GetUsuario(string username, string email)
        {
            var url = string.Format("{0}users?username={1}&email={2}", URL, username, email);

            HttpRequestMessage request = new(HttpMethod.Get, url);

            var httpClient = _HttpClientFactory.CreateClient();

            var response = await httpClient.SendAsync(request);

            var responseContent = await response.Content.ReadAsStringAsync();

            if (responseContent != null)
            {
                var list = JsonConvert.DeserializeObject<List<UserDto>>(responseContent);

                return list?.FirstOrDefault();
            }

            return null;
        }

        public async Task<List<PostDto>?> GetPostUsuario(int id)
        {
            var url = string.Format("{0}posts?userId={1}", URL, id);

            HttpRequestMessage request = new(HttpMethod.Get, url);

            var httpClient = _HttpClientFactory.CreateClient();

            var response = await httpClient.SendAsync(request);

            var responseContent = await response.Content.ReadAsStringAsync();

            if (responseContent != null)
            {
                return JsonConvert.DeserializeObject<List<PostDto>>(responseContent);
            }

            return null;
        }

        public async Task<List<AlbumDto>?> GetAlbumsUsuario(int id)
        {
            var url = string.Format("{0}albums?userId={1}", URL, id);

            HttpRequestMessage request = new(HttpMethod.Get, url);

            var httpClient = _HttpClientFactory.CreateClient();

            var response = await httpClient.SendAsync(request);

            var responseContent = await response.Content.ReadAsStringAsync();

            if (responseContent != null)
            {
                return JsonConvert.DeserializeObject<List<AlbumDto>>(responseContent);
            }

            return null;
        }
    }
}