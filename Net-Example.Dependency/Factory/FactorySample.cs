namespace Net_Example.Dependency;

public interface IFactorySample
{
    string GetName();
}

public class FirstFactorySample : IFactorySample
{
    public string GetName()
    {
        return nameof(FirstFactorySample);
    }
}

public class SecondFactorySample : IFactorySample
{
    public string GetName()
    {
        return nameof(SecondFactorySample);
    }
}