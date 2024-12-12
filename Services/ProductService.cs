using EndPointParametersTask.Models;
using EndPointParametersTask.ProductDTO;
using EndPointParametersTask.Repositories;
using EndPointParametersTask.Services;

using System.Text.RegularExpressions;

namespace EndPointParametersTask.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepo _productRepo;

        public ProductService(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public List<ProductOutputDTO> GetAllProducts(int pageNumber, int pageSize)
        {
            var products = _productRepo.GetAllProducts(pageNumber, pageSize);
            return products.Select(p => new ProductOutputDTO
            {
                Name = p.Name,
                Price = p.Price,
                Category = p.Category,
                DateAdded = p.DateAdded ?? DateTime.MinValue
            }).ToList();
        }

        public ProductOutputDTO GetProductById(int id)
        {
            var product = _productRepo.GetProductById(id);
            if (product == null) throw new KeyNotFoundException("Product not found.");

            return new ProductOutputDTO
            {
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
                DateAdded = product.DateAdded ?? DateTime.MinValue
            };
        }

        public ProductOutputDTO AddProduct(ProductInputDTO productInput)
        {
            var product = new Product
            {
                Name = productInput.Name,
                Price = productInput.Price,
                Category = productInput.Category,
                DateAdded = DateTime.Now
            };

            var addedProduct = _productRepo.AddProduct(product);

            return new ProductOutputDTO
            {
                Name = addedProduct.Name,
                Price = addedProduct.Price,
                Category = addedProduct.Category,
                DateAdded = addedProduct.DateAdded ?? DateTime.MinValue
            };
        }


        public ProductOutputDTO UpdateProduct(int id, ProductInputDTO productInput)
        {
            var product = _productRepo.GetProductById(id);
            if (product == null) throw new KeyNotFoundException("Product not found.");

            product.Name = productInput.Name;
            product.Price = productInput.Price;
            product.Category = productInput.Category;

            var updatedProduct = _productRepo.UpdateProduct(product);

            return new ProductOutputDTO
            {
                Name = updatedProduct.Name,
                Price = updatedProduct.Price,
                Category = updatedProduct.Category,
                DateAdded = updatedProduct.DateAdded ?? DateTime.MinValue
            };
        }

        public bool DeleteProduct(int id)
        {
            var product = _productRepo.GetProductById(id);
            if (product == null) throw new KeyNotFoundException("Product not found.");

            _productRepo.DeleteProduct(product);
            return true;
        }
    }
}



