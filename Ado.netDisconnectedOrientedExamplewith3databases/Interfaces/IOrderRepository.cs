using Ado.netDisconnectedOrientedExample.Models;

namespace Ado.netDisconnectedOrientedExample.Interfaces
{
    public interface IOrderRepository
    {
        Task<bool> AddOrder(Order Objord);
        Task<bool> UpdateOrder(Order Objord);
        Task<bool> DeleteOrder(int OrderId);
        Task<List<Order>> GetallOrders();
        Task<Order> GetOrderById(int Id);
    }
}
