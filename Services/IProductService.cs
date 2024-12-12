using EndPointParametersTask.ProductDTO;
using System.Collections.Generic;
namespace EndPointParametersTask.Services
{
    public interface IProductService
    {
        List<ProductOutputDTO> GetAllProducts(int pageNumber, int pageSize);
        ProductOutputDTO GetProductById(int id);
        ProductOutputDTO AddProduct(ProductInputDTO productInput);
        ProductOutputDTO UpdateProduct(int id, ProductInputDTO productInput);
        string DeleteProduct(int id);
    }
}
