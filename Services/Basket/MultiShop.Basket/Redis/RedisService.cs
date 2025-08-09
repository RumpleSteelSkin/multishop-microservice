using StackExchange.Redis;

namespace MultiShop.Basket.Redis;

public class RedisService(ConnectionMultiplexer connectionMultiplexer)
{
    public IDatabase GetDatabase(int db = 0) => connectionMultiplexer.GetDatabase(db);
}