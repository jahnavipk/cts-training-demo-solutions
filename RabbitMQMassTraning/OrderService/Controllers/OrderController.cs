using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IBus _bus;

        public OrderController(IBus bus)
        {
            _bus = bus;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            if (order != null)
            {
                Uri uri = new Uri("rabbitmq://localhost/orderQueue");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(order);
                return Ok();
            }
            return BadRequest();
        }
    }
}
