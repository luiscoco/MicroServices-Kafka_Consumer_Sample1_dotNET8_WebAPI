using dotNet8WebAPI_Consume_Kafka_JSON_messages.Models;
using Microsoft.AspNetCore.Mvc;
using dotNet8WebAPI_Consume_Kafka_JSON_messages.Services;
using dotNet8WebAPI_Consume_Kafka_JSON_messages.Kafka;

namespace dotNet8WebAPI_Consume_Kafka_JSON_messages.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KafkaController : ControllerBase
    {
        private readonly KafkaConsumerService _kafkaConsumerService;

        public KafkaController(KafkaConsumerService kafkaConsumerService)
        {
            _kafkaConsumerService = kafkaConsumerService;
        }

        [HttpGet("get-messages")]
        public IActionResult GetMessages(int count = 5)
        {
            var cancellationToken = new CancellationToken(); // Consider a more appropriate way to handle cancellation
            List<string> messages = _kafkaConsumerService.ConsumeMessages(count, cancellationToken);
            return Ok(messages);
        }
    }
}
