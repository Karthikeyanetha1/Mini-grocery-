using MiniGroceryApi.Models;

namespace MiniGroceryApi.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
    }
}
