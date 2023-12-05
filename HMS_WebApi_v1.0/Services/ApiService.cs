using NPOI.SS.Formula.Functions;

namespace HMS_WebApi_v1._0.Services
{
    public class ApiService<T> : IApiService<T>
    {
        private readonly HttpClient _httpClient;
        private readonly string? _apiBaseUrl;

        public ApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiBaseUrl = configuration["ApiBaseUrl"] ;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/api/{typeof(T).Name.ToLower()}");
            response.EnsureSuccessStatusCode();

            var entities = await response.Content.ReadAsAsync<IEnumerable<T>>();
            return entities;
        }

        public async Task<T> GetById(long id)
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/api/{typeof(T).Name.ToLower()}/{id}");
            response.EnsureSuccessStatusCode();

            var entity = await response.Content.ReadAsAsync<T>();
            return entity;
        }

        public async Task Add(T entity)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_apiBaseUrl}/api/{typeof(T).Name.ToLower()}", entity);
            response.EnsureSuccessStatusCode();
        }

        public async Task Update(T entity)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_apiBaseUrl}/api/{typeof(T).Name.ToLower()}", entity);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete(long id)
        {
            var response = await _httpClient.DeleteAsync($"{_apiBaseUrl}/api/{typeof(T).Name.ToLower()}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
