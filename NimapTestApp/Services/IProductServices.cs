using NimapTestApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NimapTestApp.Services
{
    public interface IProductServices
    {
        Task<List<Product>> GetProducts(int page, int pageSize);
        Task<int> GetTotalProducts();
        Task<Product> GetProductById(int id);
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int id);
    }
}
