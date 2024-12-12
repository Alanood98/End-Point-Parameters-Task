using EndPointParametersTask.Models;
using EndPointParametersTask.Repositories;
using EndPointParametersTask;
using Microsoft.Identity.Client;



namespace EndPointParametersTask.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDbContext _context;

        public ProductRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts(int pageNumber, int pageSize)
        {
            try
            {
                return _context.Products
                    .OrderByDescending(p => p.DateAdded)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error retrieving Product: {ex.Message}");
                throw; 
            }

        }

        public Product GetProductById(int Productid)
        {
            try
            {
                return _context.Products.FirstOrDefault(a => a.Id == Productid);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error retrieving Product with ID {Productid}: {ex.Message}");
                throw; // Rethrow the exception if necessary
            }
        }

        public string AddProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return product.Name.ToString();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error adding new Product: {ex.Message}");
                throw; // Rethrow the exception if necessary
            }

        }
        public Product UpdateProduct(Product product)
            {
                try
                {
                    _context.Products.Update(product);
                    _context.SaveChanges();
                    return product;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating Product with ID {product.Id}: {ex.Message}");
                    throw;
                }
            }
        public bool DeleteProduct(Product product)
        {
            try
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return true; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting Product with ID {product.Id}: {ex.Message}");
                throw;
            }
        }

    }
}