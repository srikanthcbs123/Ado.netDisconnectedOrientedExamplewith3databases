using Ado.netDisconnectedOrientedExample.Dtos;

namespace Ado.netDisconnectedOrientedExample.Interfaces
{
    public interface IOrderService
    {
        Task<bool> AddOrder(OrderDto Objord);
        Task<bool> UpdateOrder(OrderDto Objord);
        Task<bool> DeleteOrder(int OrderId);
        Task<List<OrderDto>> GetallOrders();
        Task<OrderDto> GetOrderById(int Id);
    }
}
