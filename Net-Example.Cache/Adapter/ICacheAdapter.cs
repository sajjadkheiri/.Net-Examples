namespace Net_Example.Cache;

public interface ICacheAdapter
{
    T Get<T>(string key);
    void Set<T>(string key,T value);
}
