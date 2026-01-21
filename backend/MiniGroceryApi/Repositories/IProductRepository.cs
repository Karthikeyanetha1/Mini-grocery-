using MiniGroceryApi.Models;

namespace MiniGroceryApi.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();
        Task<Product?> GetProductById(int id);
        Task UpdateProduct(Product product);
    }
}
