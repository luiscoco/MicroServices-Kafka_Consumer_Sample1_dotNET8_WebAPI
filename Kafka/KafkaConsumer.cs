using Confluent.Kafka;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace dotNet8WebAPI_Consume_Kafka_JSON_messages.Kafka
{
    public class KafkaConsumer
    {
        private ConsumerConfig _config;
        private string _topic;

        public KafkaConsumer(string bootstrapServers, string topic, string groupId)
        {
            _config = new ConsumerConfig
            {
                BootstrapServers = bootstrapServers,
                GroupId = groupId,
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = false
            };
            _topic = topic;
        }

        public List<string> ConsumeMessages(int count, CancellationToken cancellationToken)
        {
            var messages = new List<string>();

            using (var consumer = new ConsumerBuilder<string, string>(_config).Build())
            {
                consumer.Subscribe(_topic);
                try
                {
                    for (int i = 0; i < count; i++)
                    {
                        var consumeResult = consumer.Consume(cancellationToken);
                        messages.Add(consumeResult.Message.Value);
                        Console.WriteLine($"Message: {consumeResult.Message.Value} received from {consumeResult.TopicPartitionOffset}");
                    }
                }
                catch (OperationCanceledException)
                {
                    // Handle cancellation
                }
                finally
                {
                    consumer.Close();
                }
            }

            return messages;
        }
    }
}
