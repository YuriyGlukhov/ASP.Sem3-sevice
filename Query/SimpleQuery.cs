using GraphQlStorage.Model.DTO;
using GraphQlStorage.Services;

namespace GraphQlStorage.Query
{
    public class SimpleQuery
    {
        public async Task<List<ProductDTO>> GetProductsByStorage([Service] StorageService productService, int id)
        {
            // Асинхронно получаем список продуктов, используя сервис
            return await productService.GetProductsInStorage(id);
        }
    }
}
