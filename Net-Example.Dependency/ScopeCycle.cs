namespace Net_Example.Dependency;

public class ScopeCycle
{


    private readonly Guid _guid;
    public ScopeCycle()
    {
        _guid = Guid.NewGuid();
    }

    public string GetGuid()
    {
        return _guid.ToString();
    }
}

public interface IScopeCycle
{
    string GetGuid();
}