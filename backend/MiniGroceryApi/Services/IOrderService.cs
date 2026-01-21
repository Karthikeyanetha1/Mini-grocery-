



namespace MiniGroceryApi.Services
{
    public interface IOrderService
    {
        Task<string> PlaceOrder(int productId, int quantity);
    }
}    }
}
