using Confluent.Kafka;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;
using dotNet8WebAPI_Consume_Kafka_JSON_messages.Models;
using dotNet8WebAPI_Consume_Kafka_JSON_messages.Config;
using System.Collections.Concurrent;
using Microsoft.Extensions.Options;
using dotNet8WebAPI_Consume_Kafka_JSON_messages.Kafka;

namespace dotNet8WebAPI_Consume_Kafka_JSON_messages.Services
{
    public class KafkaConsumerService
    {
        private readonly KafkaConsumer _kafkaConsumer;

        public KafkaConsumerService(IOptions<KafkaSettings> kafkaSettings)
        {
            // Assuming KafkaSettings is a class that holds your Kafka configuration
            var settings = kafkaSettings.Value;
            _kafkaConsumer = new KafkaConsumer(settings.BootstrapServers, settings.Topic, settings.GroupId);
        }

        public List<string> ConsumeMessages(int count, CancellationToken cancellationToken)
        {
            return _kafkaConsumer.ConsumeMessages(count, cancellationToken);
        }
    }
}
