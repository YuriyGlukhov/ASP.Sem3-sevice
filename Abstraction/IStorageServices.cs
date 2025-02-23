using GraphQlStorage.Model.DTO;

namespace GraphQlStorage.Abstraction
{
    public interface IStorageServices
    {
        Task<List<ProductDTO>> GetProductsInStorage(int storageId);


    }
}
