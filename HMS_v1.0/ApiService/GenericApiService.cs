using HMS_v1._0.ApiService;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HMS_v1._0
{
    public class GenericApiService<T> : IGenericApiService<T> where T : class
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        public GenericApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _apiBaseUrl = configuration["https://localhost:7057/"];
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/api/{typeof(T).Name}");
            response.EnsureSuccessStatusCode();
            var entities = await response.Content.ReadAsAsync<IEnumerable<T>>();
            return entities;
        }

        public async Task<T> GetById(long id)
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/api/{typeof(T).Name}/{id}");
            response.EnsureSuccessStatusCode();

            var entity = await response.Content.ReadAsAsync<T>();
            return entity;
        }

        public async Task Add(T entity)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_apiBaseUrl}/api/{typeof(T).Name}", entity);
            response.EnsureSuccessStatusCode();
        }

        public async Task Update(T entity)
        {
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
