using System;

namespace Net_Example.DIP;

public class SingletonDependency : ISingletonDependency
{

}

public interface ISingletonDependency
{
    string GetGuid();
}
