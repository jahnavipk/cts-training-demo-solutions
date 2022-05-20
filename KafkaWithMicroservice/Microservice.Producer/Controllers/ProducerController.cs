using Confluent.Kafka;
using Microservice.Producer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice.Producer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private ProducerConfig _config;

        public ProducerController(ProducerConfig producerConfig)
        {
            _config = producerConfig;
        }

        [HttpPost("send")]
        public async Task<IActionResult> Get(string topic, [FromBody] Employee employee)
        {
            string employeeData = JsonConvert.SerializeObject(employee);

            using (var producer = new ProducerBuilder<Null, string>(_config).Build())
            {
                await producer.ProduceAsync(topic, new Message<Null, string> { Value = employeeData });
                producer.Flush(TimeSpan.FromSeconds(10));
                return Ok(true);
            }            
        }
    }
}
