using Confluent.Kafka;

namespace InventoryProducer.Services
{
    public class ProducerService
    {
        private readonly IConfiguration _configuration;
        private readonly IProducer<string, string> _producer;

        public ProducerService(IConfiguration configuration)
        {
            _configuration = configuration;

            var producerconfig = new ProducerConfig
            {
                BootstrapServers = _configuration["Kafka:BootstrapServers"]
            };
            _producer = new ProducerBuilder<string, string>(producerconfig).Build();
        }

        public async Task ProduceAsync(string topic, string message)
        {
            var kafkamessage = new Message<string, string>
            {
                Key = Guid.NewGuid().ToString(),
                Value = message,
            };
            await _producer.ProduceAsync(topic, kafkamessage);
        }
    }
}
