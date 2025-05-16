using StackExchange.Redis;

namespace StrategyLab.Service.Write
{
    public class RedisWriter : IDataWriter
    {
        private readonly IDatabase _db;
        private readonly string _key = "DataOutput";

        public RedisWriter(IConfiguration config)
        {
            var redis = ConnectionMultiplexer.Connect($"{config["Host"]}:{config["Port"]}");
            _db = redis.GetDatabase();
        }

        public void Write(string data)
        {
            var result = _db.ListRightPush(_key, data);
            Console.WriteLine($"Дані збережено. Поточна довжина списку: {result}");

        }
    }

}
