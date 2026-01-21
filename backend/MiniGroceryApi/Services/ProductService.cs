using MiniGroceryApi.Models;
using MiniGroceryApi.Repositories;

namespace MiniGroceryApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _productRepository.GetAllProducts();
        }
    }
}
