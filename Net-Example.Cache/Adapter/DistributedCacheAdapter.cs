using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Net_Example.Cache;

public class DistributedCacheAdapter : ICacheAdapter
{
    private readonly IDistributedCache _cache;
    public DistributedCacheAdapter(IDistributedCache cache)
    {
        _cache = cache;
    }

    public T Get<T>(string key)
    {
        var result = _cache.GetString(key);
        return string.IsNullOrEmpty(result) ? default(T) : JsonConvert.DeserializeObject<T>(result);
    }

    public void Set<T>(string key, T value)
    {
        string Serialization = JsonConvert.SerializeObject(value);
        _cache.SetString(key,Serialization);
    }
}
