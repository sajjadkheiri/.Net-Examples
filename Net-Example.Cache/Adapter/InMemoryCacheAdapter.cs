using Microsoft.Extensions.Caching.Memory;

namespace Net_Example.Cache;

public class InMemoryCacheAdapter : ICacheAdapter
{
    private readonly IMemoryCache _cache;

    public InMemoryCacheAdapter(IMemoryCache cache)
    {
        _cache = cache;
    }

    public T Get<T>(string key)
    {
        return _cache.Get<T>(key);
    }

    public void Set<T>(string key, T value)
    {
        _cache.Set(key, value);
    }
}
