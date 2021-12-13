using StackExchange.Redis;

namespace MinApiRedis.Services
{
    public class RedisService
    {
        private ConnectionMultiplexer _connectionMultiplexer;

        public void Connect() => _connectionMultiplexer = 
            ConnectionMultiplexer.Connect("localhost:6379");
        public IDatabase GetDatabase(int db = 1) => _connectionMultiplexer.GetDatabase(db);
    }
}
