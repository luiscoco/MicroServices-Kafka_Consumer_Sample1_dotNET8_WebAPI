namespace dotNet8WebAPI_Consume_Kafka_JSON_messages.Config
{
    public class KafkaSettings
    {
        public string BootstrapServers { get; set; } = string.Empty;
        public string Topic { get; set; } = string.Empty;
        public string GroupId { get; set; } = string.Empty;
    }
}
