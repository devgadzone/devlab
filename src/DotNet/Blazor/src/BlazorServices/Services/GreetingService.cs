namespace BlazorServices.Services;

public interface IGreetingTransientService
{
    string SayHello(string name);
}

public interface IGreetingScopedService
{
    string SayHello(string name);
}
public interface IGreetingSingletonService
{
    string SayHello(string name);
}
public class GreetingService : IGreetingTransientService, IGreetingScopedService, IGreetingSingletonService
{
    public string SayHello(string name)
    {
        return $"Hello {name}";
    } 
}
