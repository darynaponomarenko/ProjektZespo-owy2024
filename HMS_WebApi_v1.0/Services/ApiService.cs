
using AutoMapper;

namespace HMS_WebApi_v1._0.Services
{
    public class ApiService<T> : IApiService<T> where T : class
    {
        private readonly HttpClient _httpClient;
        //private readonly IMapper _mapper;
        private readonly string? _apiBaseUrl;

        public ApiService(HttpClient httpClient, /*IMapper mapper,*/ IConfiguration configuration)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            //_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _apiBaseUrl = configuration["ApiBaseUrl"];
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/api/{typeof(T).Name}");
            response.EnsureSuccessStatusCode();

            var entities = await response.Content.ReadAsAsync<IEnumerable<T>>();
            /*var mappedResponse = _mapper.Map<T>(entities);
            return (IEnumerable<T>)mappedResponse;*/
            return entities;
        }

        public async Task<T> GetById(long id)
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/api/{typeof(T).Name}/{id}");
            response.EnsureSuccessStatusCode();

            var entity = await response.Content.ReadAsAsync<T>();
            /*var mappedEntity = _mapper.Map<T>(entity);
            return mappedEntity;*/
            return entity;
        }

        public async Task Add(T entity)
        {
            //var mappedModel = _mapper.Map<T, T>(model);
            var response = await _httpClient.PostAsJsonAsync($"{_apiBaseUrl}/api/{typeof(T).Name}", entity);
            response.EnsureSuccessStatusCode();
        }

        public async Task Update(T entity)
        {
            //var mappedEntity = _mapper.Map<T, T>(entity);
            var response = await _httpClient.PutAsJsonAsync($"{_apiBaseUrl}/api/{typeof(T).Name}", entity);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete(long id)
        {
            var response = await _httpClient.DeleteAsync($"{_apiBaseUrl}/api/{typeof(T).Name}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
