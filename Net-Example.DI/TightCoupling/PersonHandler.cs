namespace Net_Example.DIP;

public class PersonHandler
{
    public void CreateHandler(string firstName, string lastName)
    {
        Person person = new Person
        {
            FirstName = firstName,
            LastName = lastName
        };

        ICouplingRepository repo = CouplingFactory.Instance();
        repo.Add(new Person
        {
            FirstName = "Sajjad",
            LastName = "Kheiri"
        });
    }
}

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public interface ICouplingRepository
{
    void Add(Person person);
}

public class CouplingRepository : ICouplingRepository
{
    public void Add(Person person)
    {
        throw new NotImplementedException();
    }
}

/// <summary>
/// Type broker or Factory pattern
/// </summary>
public class CouplingFactory
{
    public static ICouplingRepository Instance()
    {
        return new CouplingRepository();
    }
}