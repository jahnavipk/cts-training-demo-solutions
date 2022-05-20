using MassTransit;
using Producer.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consumer.Consumers
{
    public class VideoDeletedEventConsumer : IConsumer<VideoDeletedEvent>
    {
        public Task Consume(ConsumeContext<VideoDeletedEvent> context)
        {
            var message = context.Message.Title;
            return Task.CompletedTask;
        }
    }
}
