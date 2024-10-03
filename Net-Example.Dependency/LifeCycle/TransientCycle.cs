namespace Net_Example.Dependency;

public class TransientCycle : ITransientCycle
{
    private readonly Guid _guid;
    public TransientCycle()
    {
        _guid = Guid.NewGuid();
    }

    public string GetGuid()
    {
        return _guid.ToString();
    }
}

public interface ITransientCycle
{
    string GetGuid();
}
