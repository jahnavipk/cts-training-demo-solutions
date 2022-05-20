using InventoryService.Models;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Consumers
{
    public class OrderConsumer : IConsumer<Order>
    {
        public async Task Consume(ConsumeContext<Order> context)
        {
            var msg = context.Message;

            await Console.Out.WriteLineAsync(msg.Details);
        }
    }
}
