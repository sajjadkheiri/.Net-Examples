using System;

namespace Net_Example.Dependency.DI;

public class SingletonDependency : ISingletonDependency
{
    private readonly Guid _guid;

    public SingletonDependency()
    {
        _guid = Guid.NewGuid();
    }

    public string GetGuid()
    {
        return _guid.ToString();
    }
}

public interface ISingletonDependency
{
    string GetGuid();
}
