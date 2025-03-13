using Ado.netDisconnectedOrientedExample.Dtos;
using Ado.netDisconnectedOrientedExample.Interfaces;
using Ado.netDisconnectedOrientedExample.Models;

namespace Ado.netDisconnectedOrientedExample.Services
{
    public class OrderServices : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderServices(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<bool> AddOrder(OrderDto Objord)
        {//in future the below logic replaced by automapper concept.
            Order objorder = new Order();
            objorder.OrderLocation = Objord.OrderLocation;
            objorder.OrderName = Objord.OrderName;
            var res = await _orderRepository.AddOrder(objorder);
            return res;
        }

        public async Task<bool> DeleteOrder(int OrderId)
        {
            await _orderRepository.DeleteOrder(OrderId);
            return true;
        }

        public async Task<List<OrderDto>> GetallOrders()
        {
            List<OrderDto> ordlist = new List<OrderDto>();
            var getorder = await _orderRepository.GetallOrders();
            foreach (var order in getorder)
            {
                OrderDto ordobj = new OrderDto();
                ordobj.OrderId = order.OrderId;
                ordobj.OrderName = order.OrderName;
                ordobj.OrderLocation = order.OrderLocation;
                ordlist.Add(ordobj);


            }
            return ordlist;
        }

        public async Task<OrderDto> GetOrderById(int Id)
        {
            var res = await _orderRepository.GetOrderById(Id);
            OrderDto objorder = new OrderDto();
            objorder.OrderId = res.OrderId;
            objorder.OrderName = res.OrderName;
            objorder.OrderLocation = res.OrderLocation;
            return objorder;

        }

        public async Task<bool> UpdateOrder(OrderDto Objord)
        {
            Order order = new Order();
            order.OrderId = Objord.OrderId;
            order.OrderName = Objord.OrderName;
            order.OrderLocation = Objord.OrderLocation;
            await _orderRepository.UpdateOrder(order);
            return true;
        }
    }
}
