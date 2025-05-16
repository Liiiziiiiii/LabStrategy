using Confluent.Kafka;

namespace StrategyLab.Service.Write
{
    public class KafkaWriter : IDataWriter
    {
        private readonly string _topic;
        private readonly IProducer<Null, string> _producer;

        public KafkaWriter(IConfiguration config)
        {
            _topic = config["Topic"];
            var configMap = new ProducerConfig { BootstrapServers = config["BootstrapServers"] };
            _producer = new ProducerBuilder<Null, string>(configMap).Build();
        }

        public void Write(string data)
        {
            _producer.Produce(_topic, new Message<Null, string> { Value = data },
                (deliveryReport) =>
                {
                    if (deliveryReport.Error.IsError)
                    {
                        Console.WriteLine($"Помилка: {deliveryReport.Error.Reason}");
                    }
                    else
                    {
                        Console.WriteLine($"Все супер: {deliveryReport.TopicPartitionOffset}");
                    }
                });
        }
        public void Flush()
        {
            _producer.Flush(TimeSpan.FromSeconds(10));
        }


    }

}
