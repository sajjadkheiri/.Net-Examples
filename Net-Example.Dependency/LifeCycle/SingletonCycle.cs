namespace Net_Example.Dependency;

public class SingletonCycle
{

    private readonly Guid _guid;
    public SingletonCycle()
    {
        _guid = Guid.NewGuid();
    }

    public string GetGuid()
    {
        return _guid.ToString();
    }
}

public interface ISingletonCycle
{
    string GetGuid();
}
