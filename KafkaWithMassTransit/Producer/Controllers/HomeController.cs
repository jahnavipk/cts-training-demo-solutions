using MassTransit.KafkaIntegration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Producer.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Producer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private ITopicProducer<VideoDeletedEvent> _topicProducer;
        public HomeController(ITopicProducer<VideoDeletedEvent> topicProducer)
        {
            _topicProducer = topicProducer;
        }

        [HttpPost("{title}")]
        public async Task<IActionResult> PostAsync(string title)
        {
            await _topicProducer.Produce(new VideoDeletedEvent { Title = title });
            return Ok(title);
        }
    }
}
