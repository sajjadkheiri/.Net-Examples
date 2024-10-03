namespace Net_Example.Dependency.Dip;

public class FirstSampleApplicationService
{
    public void Handle()
    {
        IRepository repo = RepoFactory.GetRepository();
        repo.Get("");
    }
}

public class RepoFactory
{
    public static IRepository GetRepository() => new Repository();
}

public interface IRepository
{
    void Save();
    string Get(string input);
}

public class Repository : IRepository
{
    public string Get(string input)
    {
        throw new NotImplementedException();
    }

    public void Save()
    {
        throw new NotImplementedException();
    }
}
