using GraphQlStorage.Model;
using GraphQlStorage.Model.DTO;

namespace GraphQlStorage.GraphQL
{
    public class GraphQLResponse<T>
    {
        public T Data { get; set; }
    }

    public class ProductsByStorageResponse
    {
        public List<ProductDTO> ProductsByStorage { get; set; }
    }
}
