using MiniGroceryApi.Data;
using MiniGroceryApi.Models;
using MiniGroceryApi.Repositories;

namespace MiniGroceryApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderService(
            AppDbContext context,
            IProductRepository productRepository,
            IOrderRepository orderRepository)
        {
            _context = context;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public async Task<string> PlaceOrder(int productId, int quantity)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // 1. Check product exists
                var product = await _productRepository.GetProductById(productId);
                if (product == null)
                {
                    return "Product not found";
                }

                // 2. Check stock availability
                if (product.Stock < quantity)
                {
                    return "Insufficient stock";
                }

                // 3. Reduce stock
                product.Stock -= quantity;
                await _productRepository.UpdateProduct(product);

                // 4. Create order
                var order = new Order
                {
                    ProductId = productId,
                    Quantity = quantity,
                    TotalPrice = product.Price * quantity,
                    CreatedAt = DateTime.UtcNow
                };

                await _orderRepository.CreateOrder(order);

                // 5. Commit transaction
                await transaction.CommitAsync();

                return "Order placed successfully";
            }
            catch
            {
                // Rollback on any failure
                await transaction.RollbackAsync();
                return "Order failed";
            }
        }
    }
}
