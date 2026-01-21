using MiniGroceryApi.Models;

namespace MiniGroceryApi.Repositories
{
    public interface IOrderRepository
    {
        Task CreateOrder(Order order);
    }
}
