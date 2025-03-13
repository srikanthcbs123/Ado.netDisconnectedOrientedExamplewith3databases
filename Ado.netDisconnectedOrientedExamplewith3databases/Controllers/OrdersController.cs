using Ado.netDisconnectedOrientedExample.Dtos;
using Ado.netDisconnectedOrientedExample.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ado.netDisconnectedOrientedExample.Controllers
{
    [Route("api/[controller]")]//attributes provides a additiona information to compiler.
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost]
        [Route("AddOrder")]
        public async Task<IActionResult> Post(OrderDto objorder)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var ord = await _orderService.AddOrder(objorder);
                    return StatusCode(StatusCodes.Status200OK, ord);

                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpPut]
        [Route("UpdateOrder")]
        public async Task<IActionResult> Updateorder(OrderDto objorder)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var ord = await _orderService.UpdateOrder(objorder);
                    return StatusCode(StatusCodes.Status201Created, ord);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");

            }

        }
        [HttpDelete]
        [Route("DeleteOrder")]
        public async Task<IActionResult> Deleteorder(int OrderId)
        {

            if (OrderId < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad Request");
            }
            try
            {
                var order = await _orderService.DeleteOrder(OrderId);
                if (order != null)
                {
                    return StatusCode(StatusCodes.Status200OK, "Order Deleted Successfully");
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Order Not Found");
                 
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet]
        [Route("GetOrder")]
        public async Task<IActionResult> GetOrder()
        {
            var order = await _orderService.GetallOrders();
            if (order == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Order Details Not Fount");
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, order);
            }
        }
        [HttpGet]
        [Route("GetOrdersbyId")]
        public async Task<IActionResult> GetorderbyId(int OrderId)
        {
            if (OrderId < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad Request");
            }
            try
            {
                var res = await _orderService.GetOrderById(OrderId);
                if (res == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Order Not Found");

                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, res);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }

        }

    }
}
