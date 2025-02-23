using AutoMapper;
using GraphQlStorage.Abstraction;
using GraphQlStorage.GraphQL;
using GraphQlStorage.Model.DTO;
using Microsoft.Extensions.Caching.Memory;
using System.Net.Http;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GraphQlStorage.Services
{
    public class StorageService : IStorageServices
    {
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly HttpClient _httpClient;

        public StorageService(IMapper mapper, IMemoryCache memoryCache, HttpClient httpClient)
        {
            _mapper = mapper;
            _cache = memoryCache;
            _httpClient = httpClient;
        }

        public async Task<List<ProductDTO>> GetProductsInStorage(int storageId)
        {
            var query = new
            {
                query = @"
                query ($storageId: Int!) {
                   productsByStorage(storageId: $storageId) {
                    id
                    name
                    description
                   }
                 }",
                variables = new { storageId }
            };

            var response = await _httpClient.PostAsJsonAsync("https://localhost:7040/graphql", query);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Ошибка при вызове GraphQL API.");
            }

            var result = await response.Content.ReadFromJsonAsync<GraphQLResponse<ProductsByStorageResponse>>();

            return result?.Data?.ProductsByStorage ?? new List<ProductDTO>();
        }
    }
}
