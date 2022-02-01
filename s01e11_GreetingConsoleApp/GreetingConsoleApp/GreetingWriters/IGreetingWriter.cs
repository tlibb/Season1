namespace GreetingConsoleApp;

public interface IGreetingWriter 
{
    public void Write(string message);
    public void Write(Greeting greeting);
}