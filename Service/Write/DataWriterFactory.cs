namespace StrategyLab.Service.Write
{
    public class DataWriterFactory
    {
        private readonly IConfiguration _config;

        public DataWriterFactory(IConfiguration config)
        {
            _config = config;
        }

        public IDataWriter CreateWriter()
        {
            string strategy = _config["OutputStrategy"];

            return strategy switch
            {
                "Console" => new ConsoleWriter(),
                "Kafka" => new KafkaWriter(_config.GetSection("Kafka")),
                "Redis" => new RedisWriter(_config.GetSection("Redis")),
                _ => throw new InvalidOperationException("Unknown strategy")
            };
        }
    }

}
