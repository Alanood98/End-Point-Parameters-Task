using EndPointParametersTask.Models;

namespace EndPointParametersTask.Repositories
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetAllProducts(int pageNumber, int pageSize);
        Product GetProductById(int Productid);
        Product AddProduct(Product product);
        Product UpdateProduct(Product product);
        bool DeleteProduct(Product product);

    }
}
